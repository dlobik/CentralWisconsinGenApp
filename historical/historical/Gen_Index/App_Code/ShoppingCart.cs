using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.IO;
using System.Configuration;

	/// <summary>
	/// Summary description for ShoppingCart.
	/// </summary>
	public class ShoppingCart
	{
		public ShoppingCart()
		{
			HttpContext context = HttpContext.Current;
            //' if the UWSPLibraryGEN_INDEX_CartID cookie doesn't exist
			//' on client machine we create it with a new GUID
            if (context.Request.Cookies["UWSPLibrary_GEN_INDEX_CartID"] == null)
			{
				//'Generate a new GUID
				Guid cartid = Guid.NewGuid();
				//'create the cookie and set its value
                HttpCookie cookie = new HttpCookie("UWSPLibrary_GEN_INDEX_CartID", cartid.ToString());
				//'current date
				DateTime currentDate = DateTime.Now;
				//'set the time span to 12 hours
				TimeSpan ts = new TimeSpan(0, 12, 0, 0, 0);
				//expiration date
				DateTime expirationDate = currentDate.Add(ts);
				//'set the expiration date to the cookie
				cookie.Expires = expirationDate;
				//'set the cookie on client's browser
				context.Response.Cookies.Add(cookie);
			}
			//'the value stored in UWSPLibraryObits_CartID
			//'is returned, as it contains the visitor's cart ID
			//return context.Request.Cookies["UWSPLibraryCensus_CartID"].Value;
		}
		public string GetCartID()
		{
            return HttpContext.Current.Request.Cookies["UWSPLibrary_GEN_INDEX_CartID"].Value;
		}
		private string connectionString()
		{
			return ConfigurationSettings.AppSettings["conSQL"];
		}
		
		public void AddProduct(string productID)
		{
			//'create the connection object
			SqlConnection connection = new SqlConnection(connectionString());

			//create and initialize the command object
			SqlCommand command = new SqlCommand("AddProductToCart", connection);
			command.CommandType = CommandType.StoredProcedure;

			//add an input parameter and supply a value for it
			command.Parameters.Add("@CartID", SqlDbType.VarChar, 50);
			command.Parameters["@CartID"].Value = GetCartID();

			//'add an input parameter and supply a value for it
			command.Parameters.Add("@ProductID", SqlDbType.Int, 4);
			command.Parameters["@ProductID"].Value = productID;

			//'open the connection, execute the command and close the connection
			connection.Open();
			command.ExecuteNonQuery();
			connection.Close();
		}//end add product

		public void UpdateProductQuantity(string productID, int quantity)
		{
			//'create the connection object
			SqlConnection connection = new SqlConnection(connectionString());

			//create and initialize the command object
			SqlCommand command = new SqlCommand("UpdateCartItem", connection);
			command.CommandType = CommandType.StoredProcedure;

			//'add an input parameter and supply a value for it
			command.Parameters.Add("@CartID", SqlDbType.VarChar, 50);
			command.Parameters["@CartID"].Value = GetCartID();

			//'add an input parameter and supply a value for it
			command.Parameters.Add("@ProductID", SqlDbType.Int, 4);
			command.Parameters["@ProductID"].Value = productID;

			//add an input parameter and supply a value for it
			command.Parameters.Add("@Quantity", SqlDbType.Int, 4);
			command.Parameters["@Quantity"].Value = quantity;

			//'open the connection, execute the command and close the connection
			connection.Open();
			command.ExecuteNonQuery();
			connection.Close();
		}//end UpdateProductQuantity 

		public void RemoveProduct(string productID)
		{
			//'create the connection object
			SqlConnection connection = new SqlConnection(connectionString());

			//'create and initialize the command object
			SqlCommand command = new SqlCommand("RemoveProductFromCart", connection);
			command.CommandType = CommandType.StoredProcedure;

			//'add an input parameter and supply a value for it
			command.Parameters.Add("@CartID", SqlDbType.VarChar, 50);
			command.Parameters["@CartID"].Value = GetCartID();

			//'add an input parameter and supply a value for it
			command.Parameters.Add("@ProductID", SqlDbType.Int, 4);
			command.Parameters["@ProductID"].Value = productID;

			//'open the connection, execute the command and close the connection
			connection.Open();
			command.ExecuteNonQuery();
			connection.Close();
		}//end RemoveProduct

		public SqlDataReader GetProducts()
		{
			//'create the connection object
			SqlConnection connection = new SqlConnection(connectionString());

			// 'create and initialize the command object
			SqlCommand command = new SqlCommand("GetShoppingCartProducts", connection);
			command.CommandType = CommandType.StoredProcedure;

			// 'add an input parameter and supply a value for it
			command.Parameters.Add("@CartID", SqlDbType.VarChar, 50);
			command.Parameters["@CartID"].Value = GetCartID();

			//'open the connection, execute the command and close the connection
			connection.Open();
			return command.ExecuteReader(CommandBehavior.CloseConnection);
		}

        //public SqlDataReader GetProductsIDs(string cartID) 
        //{
        //    //'create the connection object
        //    //SqlConnection connection = new SqlConnection(connectionString());

        //    ////'create and initialize the command object
        //    //SqlCommand command = new SqlCommand("GetShoppingCartProductsIDs", connection);
        //    //command.CommandType = CommandType.StoredProcedure;

        //    ////'add an input parameter and supply a value for it
        //    //command.Parameters.Add("@CartID", SqlDbType.VarChar, 50);
        //    //command.Parameters["@CartID"].Value = cartID;

        //    //// 'open the connection, execute the command and close the connection
        //    //connection.Open();
        //    //try
        //    //{
        //    //	return command.ExecuteReader(CommandBehavior.CloseConnection);
        //    //}
        //    //catch (Exception exc)
        //    //{
        //        //Trace.Warn("error in getproductids: " + exc.Message);
        //    //}
        //}
		public int GetShoppingCartItemCount()
		{
			//'create the connection object
			SqlConnection connection = new SqlConnection(connectionString());

			//'create and initialize the command object
			SqlCommand command = new SqlCommand("GetShoppingCartItemCount", connection);
			command.CommandType = CommandType.StoredProcedure;

			//'add an input parameter and supply a value for it
			command.Parameters.Add("@CartID", SqlDbType.VarChar, 50);
			command.Parameters["@CartID"].Value = GetCartID();

			// 'open the connection, execute the command and close the connection
			connection.Open();
			int iCount = Convert.ToInt32(command.ExecuteScalar());
			connection.Close();
			return iCount;
		}
		public Decimal GetTotalAmount() 
		{
			//'create the connection object
			SqlConnection connection = new SqlConnection(connectionString());

			//'create and initialize the command object
			SqlCommand command = new SqlCommand("GetShoppingCartTotalAmount", connection);
			command.CommandType = CommandType.StoredProcedure;

			//'add an input parameter and supply a value for it
			command.Parameters.Add("@CartID", SqlDbType.VarChar, 50);
			command.Parameters["@CartID"].Value = GetCartID();

			// 'save the total amount to a variable
			int amount; 
			connection.Open();
			try
			{
				amount = Convert.ToInt32(command.ExecuteScalar());
			}
			catch
			{
				//'getting an error so set amount = 0
				amount = 0;
			}
						
			connection.Close();
			return amount;
		}
        
		public string CreateOrder() 
		{
			//'create the connection object
			SqlConnection connection = new SqlConnection(connectionString());

			//'create and initialize the command object
			SqlCommand command = new SqlCommand("CreateOrder", connection);
			command.CommandType = CommandType.StoredProcedure;

			//'add an input parameter and supply a value for it
			command.Parameters.Add("@CartID", SqlDbType.VarChar, 50);
			command.Parameters["@CartID"].Value = GetCartID();

			//'save the value that needs to be returned to a variable
			string orderID; 
			connection.Open();
			orderID = Convert.ToString(command.ExecuteScalar());

			connection.Close();

			return orderID;
		}
	
		public string CreateOrderSaveCart()
		{
			//'create the connection object
			SqlConnection connection = new SqlConnection(connectionString());

			//'create and initialize the command object
			SqlCommand command = new SqlCommand("CreateOrderSaveCart", connection);
			command.CommandType = CommandType.StoredProcedure;

			//'add an input parameter and supply a value for it
			command.Parameters.Add("@CartID", SqlDbType.VarChar, 50);
			command.Parameters["@CartID"].Value = GetCartID();

			//'save the value that needs to be returned to a variable
			String orderID ; 
			connection.Open();
			orderID = Convert.ToString(command.ExecuteScalar());

			connection.Close();

			return orderID;
		}
	
		public void EmptyShoppingCart(String CartID)
		{
			//'this function empties the shopping cart without having to create an order
			//'create the connection object
			SqlConnection connection = new SqlConnection(connectionString());

			//'create and initialize the command object
			SqlCommand command = new SqlCommand("EmptyShoppingCart", connection);
			command.CommandType = CommandType.StoredProcedure;

			//'add an input parameter and supply a value for it
			command.Parameters.Add("@CartID", SqlDbType.VarChar, 50);
			command.Parameters["@CartID"].Value = CartID;

			// 'open and execute
			connection.Open();
			command.ExecuteNonQuery();

			connection.Close();
		}
		
	}


																																																									 
