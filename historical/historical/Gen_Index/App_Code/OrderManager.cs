using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

public class OrderInfo
	{
		public string OrderID;
		public string TransID;
		public string TotalAmount;
		public string DateCreated;
		public string DateShipped;
		public string Verified;
		public string Completed;
		public string Canceled;
		public string Comments;
		public string LastName;
		public string FirstName;
		public string ShippingAddress1;
		public string ShippingAddress2;
		public string City;
		public string State;
		public string Country;
		public string Zip;
		public string Province;
		public string PostalCode;
		public string CustomerEmail;
	}
	/// <summary>
	/// Summary description for OrderManager.
	/// </summary>
	public class OrderManager
	{
		
		public OrderManager()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		private string connectionString()
		{
			return ConfigurationSettings.AppSettings["conSQL"];
		}
		public SqlDataReader GetMostRecentOrders(int count) 
		{
			//create the connection object
			SqlConnection connection = new SqlConnection(connectionString());

			//create and initialize the command object
			SqlCommand command = new SqlCommand("GetMostRecentOrders", connection);
			command.CommandType = CommandType.StoredProcedure;

			//add an input parameter and supply a value or it
			command.Parameters.Add("@Count", SqlDbType.Int, 4);
			command.Parameters["@Count"].Value = count;

			//return the results
			connection.Open();
			return command.ExecuteReader(CommandBehavior.CloseConnection);
		}

		public SqlDataReader GetOrdersBetweenDates(string startDate, string endDate)  
		{
			//create the connection object
			SqlConnection connection = new SqlConnection(connectionString());

			//create and initialize the command object
			SqlCommand command = new SqlCommand("GetOrdersBetweenDates", connection);
			command.CommandType = CommandType.StoredProcedure;

			//add an input parameter and supply a value or it
			command.Parameters.Add("@StartDate", SqlDbType.SmallDateTime);
			command.Parameters["@StartDate"].Value = startDate;

			//add an input parameter and supply a value or it
			command.Parameters.Add("@EndDate", SqlDbType.SmallDateTime);
			command.Parameters["@EndDate"].Value = endDate;

			//return the results
			connection.Open();
			return command.ExecuteReader(CommandBehavior.CloseConnection);
		}

		public SqlDataReader GetUnverifiedUncanceledOrders()
		{
			//create the connection object
			SqlConnection connection = new SqlConnection(connectionString());

			//create and initialize the command object
			SqlCommand command = new SqlCommand("GetUnverifiedUncanceledOrders", connection);
			command.CommandType = CommandType.StoredProcedure;

			//return the results
			connection.Open();
			return command.ExecuteReader(CommandBehavior.CloseConnection);
		}

		public SqlDataReader GetVerifiedUncompletedOrders()
		{
			//create the connection object
			SqlConnection connection = new SqlConnection(connectionString());

			//create and initialize the command object
			SqlCommand command = new SqlCommand("GetVerifiedUncompletedOrders", connection);
			command.CommandType = CommandType.StoredProcedure;

			//return the results
			connection.Open();
			return command.ExecuteReader(CommandBehavior.CloseConnection);
		}

		public OrderInfo GetOrderInfo(string orderID)
		{
			//Create teh conenction object
			SqlConnection connection = new SqlConnection(connectionString());

			//Create and initalize the command object
			SqlCommand command = new SqlCommand("GetOrderInfo", connection);
			command.CommandType = CommandType.StoredProcedure;

			//add an input parameter and supply a value or it
			command.Parameters.Add("@OrderID", SqlDbType.Int);
			command.Parameters["@OrderID"].Value = orderID;

			connection.Open();
			SqlDataReader reader;
			reader = command.ExecuteReader(CommandBehavior.CloseConnection);

			//we move to the first and only record in the reader object
			//and store the information in an OrderInfo object
			OrderInfo orderInfo = new OrderInfo();
			if (reader.Read()) //returns true if there are records
			{
				orderInfo.OrderID = reader["OrderID"].ToString();
				orderInfo.TransID = reader["TransID"].ToString();
				//orderInfo.TotalAmount = reader["TotalAmount"].ToString();
				orderInfo.DateCreated = reader["DateCreated"].ToString();
				orderInfo.DateShipped = reader["DateShipped"].ToString();
				orderInfo.Verified = reader["Verified"].ToString();
				orderInfo.Completed = reader["Completed"].ToString();
				orderInfo.Canceled = reader["Canceled"].ToString();
				orderInfo.Comments = reader["Comments"].ToString();
				orderInfo.LastName = reader["LastName"].ToString();
				orderInfo.FirstName = reader["FirstName"].ToString();
				orderInfo.ShippingAddress1 = reader["Address1"].ToString();
				orderInfo.ShippingAddress2 = reader["Address2"].ToString();
				orderInfo.City = reader["City"].ToString();
				orderInfo.State = reader["State"].ToString();
				orderInfo.Zip = reader["Zip"].ToString();
				orderInfo.Country = reader["Country"].ToString();
				orderInfo.Province = reader["Province"].ToString();
				orderInfo.PostalCode = reader["PostalCode"].ToString();
				orderInfo.CustomerEmail = reader["Email"].ToString();
				reader.Close();
				connection.Close();
			}
			return orderInfo;
		}

		public SqlDataReader GetOrderDetails(string orderID)
		{
			//Create teh conenction object
			SqlConnection connection = new SqlConnection(connectionString());

			//Create and initalize the command object
			SqlCommand command = new SqlCommand("GetOrderDetails", connection);
			command.CommandType = CommandType.StoredProcedure;

			//add an input parameter and supply a value or it
			command.Parameters.Add("@OrderID", SqlDbType.Int);
			command.Parameters["@OrderID"].Value = orderID;

			connection.Open();
			return command.ExecuteReader(CommandBehavior.CloseConnection);
		}
		public SqlDataReader GetOrderDetailsWithName(string orderID)
		{
			//Create teh conenction object
			SqlConnection connection = new SqlConnection(connectionString());

			//Create and initalize the command object
			SqlCommand command = new SqlCommand("GetOrderDetailsWithName", connection);
			command.CommandType = CommandType.StoredProcedure;

			//add an input parameter and supply a value or it
			command.Parameters.Add("@OrderID", SqlDbType.Int);
			command.Parameters["@OrderID"].Value = orderID;

			connection.Open();
			return command.ExecuteReader(CommandBehavior.CloseConnection);
		}
	
		public string UpdateOrder(OrderInfo orderInfo)
		{
			// Create the Connection object
			SqlConnection connection = new SqlConnection(connectionString());

			// Create and initialize the Command object
			SqlCommand command = new SqlCommand("UpdateOrder", connection);
			command.CommandType = CommandType.StoredProcedure;

			// We need to make sure orderInfo.Verified is a bit value
			if (orderInfo.Verified.ToUpper() == "TRUE" || orderInfo.Verified == "1")
			{
				command.Parameters.Add("@Verified", SqlDbType.Bit);
				command.Parameters["@Verified"].Value = 1;
			}
			else
			{
				command.Parameters.Add("@Verified", SqlDbType.Bit);
				command.Parameters["@Verified"].Value = 0;
			}
	
			// We need to make sure orderInfo.Completed is a bit value
			if (orderInfo.Completed.ToUpper() == "TRUE" || orderInfo.Completed == "1")
			{
				command.Parameters.Add("@Completed", SqlDbType.Bit);
				command.Parameters["@Completed"].Value = 1;
			}
			else
			{
				command.Parameters.Add("@Completed", SqlDbType.Bit);
				command.Parameters["@Completed"].Value = 0;
			}
	
			// We need to make sure orderInfo.Canceled is a bit value
			if (orderInfo.Canceled.ToUpper() == "TRUE" || orderInfo.Canceled == "1")
			{
				command.Parameters.Add("@Canceled", SqlDbType.Bit);
				command.Parameters["@Canceled"].Value = 1;
			}
			else
			{
				command.Parameters.Add("@Canceled", SqlDbType.Bit);
				command.Parameters["@Canceled"].Value = 0;
			}

			command.Parameters.Add("@OrderID", SqlDbType.Int);
			command.Parameters["@OrderID"].Value = orderInfo.OrderID;

			command.Parameters.Add("@DateCreated", SqlDbType.SmallDateTime);
			command.Parameters["@DateCreated"].Value = orderInfo.DateCreated;

			// @DateShipped will be sent only if the user typed a date in that
			// checkbox; otherwise we don//t send this parameter, as its default
			// value in the stored procedure is NULL
			if (orderInfo.DateShipped.Trim() != "")
			{
				command.Parameters.Add("@DateShipped", SqlDbType.SmallDateTime);
				command.Parameters["@DateShipped"].Value = orderInfo.DateShipped;
			}
			
			command.Parameters.Add("@Comments", SqlDbType.VarChar, 200);
			command.Parameters["@Comments"].Value = orderInfo.Comments;

			command.Parameters.Add("@LastName", SqlDbType.VarChar, 50);
			command.Parameters["@LastName"].Value = orderInfo.LastName;

			command.Parameters.Add("@FirstName", SqlDbType.VarChar, 50);
			command.Parameters["@FirstName"].Value = orderInfo.FirstName;

			command.Parameters.Add("@ShippingAddress1", SqlDbType.VarChar, 200);
			command.Parameters["@ShippingAddress1"].Value = orderInfo.ShippingAddress1;

			command.Parameters.Add("@ShippingAddress2", SqlDbType.VarChar, 200);
			command.Parameters["@ShippingAddress2"].Value = orderInfo.ShippingAddress2;

			command.Parameters.Add("@City", SqlDbType.VarChar, 50);
			command.Parameters["@City"].Value = orderInfo.City;

			command.Parameters.Add("@State", SqlDbType.VarChar, 50);
			command.Parameters["@State"].Value = orderInfo.State;

			command.Parameters.Add("@Zip", SqlDbType.VarChar, 50);
			command.Parameters["@Zip"].Value = orderInfo.Zip;

			command.Parameters.Add("@Country", SqlDbType.VarChar, 50);
			command.Parameters["@Country"].Value = orderInfo.Country;

			command.Parameters.Add("@Province", SqlDbType.VarChar, 50);
			command.Parameters["@Province"].Value = orderInfo.Province;

			command.Parameters.Add("@PostalCode", SqlDbType.VarChar, 50);
			command.Parameters["@PostalCode"].Value = orderInfo.PostalCode;

			command.Parameters.Add("@CustomerEmail", SqlDbType.VarChar, 50);
			command.Parameters["@CustomerEmail"].Value = orderInfo.CustomerEmail;

			// Execute the command
			connection.Open();
			command.ExecuteNonQuery();
			connection.Close();
			return command.CommandText.ToString();
		}
		
		public void MarkOrderAsVerified(string orderId)
		{
			// Create the Connection object
			SqlConnection connection = new SqlConnection(connectionString());

			// Create and initialize the Command object
			SqlCommand command = new SqlCommand("MarkOrderAsVerified", connection);
			command.CommandType = CommandType.StoredProcedure;

			// Add an input parameter and set a value for it
			command.Parameters.Add("@OrderID", SqlDbType.Int);
			command.Parameters["@OrderID"].Value = orderId;

			// Execute the Command
			connection.Open();
			command.ExecuteNonQuery();
			connection.Close();
		}
		public void MarkOrderAsCompleted(string orderId)
		{
			// Create the Connection object
			SqlConnection connection = new SqlConnection(connectionString());

			// Create and initialize the Command object
			SqlCommand command = new SqlCommand("MarkOrderAsCompleted", connection);
			command.CommandType = CommandType.StoredProcedure;

			// Add an input parameter and set a value for it
			command.Parameters.Add("@OrderID", SqlDbType.Int);
			command.Parameters["@OrderID"].Value = orderId;

			// Execute the Command
			connection.Open();
			command.ExecuteNonQuery();
			connection.Close();
		}
		
		public void MarkOrderAsCanceled(string orderId)
		{
			// Create the Connection object
			SqlConnection connection = new SqlConnection(connectionString());

			// Create and initialize the Command object
			SqlCommand command = new SqlCommand("MarkOrderAsCanceled", connection);
			command.CommandType = CommandType.StoredProcedure;

			// Add an input parameter and set a value for it
			command.Parameters.Add("@OrderID", SqlDbType.Int);
			command.Parameters["@OrderID"].Value = orderId;

			// Execute the Command
			connection.Open();
			command.ExecuteNonQuery();
			connection.Close();
		}
		

		public SqlDataReader GetCustomerOrders(string strName)
		{
			//create the connection object
			SqlConnection connection = new SqlConnection(connectionString());

			//create and initialize the command object
			SqlCommand command = new SqlCommand("GetCustomerOrders", connection);
			command.CommandType = CommandType.StoredProcedure;

			//add an input parameter and supply a value or it
			command.Parameters.Add("@Search", SqlDbType.VarChar, 50);
			command.Parameters["@Search"].Value = strName;

			//return the results
			connection.Open();
			return command.ExecuteReader(CommandBehavior.CloseConnection);
		}
			
		public void DeleteOrder(int orderID)
		{
			// Create the Connection object
			SqlConnection connection = new SqlConnection(connectionString());

			// Create and initialize the Command object
			SqlCommand command = new SqlCommand("DeleteOrder", connection);
			command.CommandType = CommandType.StoredProcedure;

			// add the orderID paramter to send to the stored procedure
			command.Parameters.Add("@OrderID", SqlDbType.Int);
			command.Parameters["@OrderID"].Value = orderID;

			// Execute the command
			connection.Open();
			command.ExecuteNonQuery();
			connection.Close();
		}
		
	}

