using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.EnterpriseServices;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Net.Mail;

	public partial class CustomerInfo : System.Web.UI.Page
	{
        ShoppingCart cart = new ShoppingCart();

		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
                ClearErrors();

				//bind the shopping cart
				BindShoppingCart();
			}
		}

        protected void btnSubmit_Click(Object sender, EventArgs e)
		{
			//'have to do manual error checking 
			if (!CheckErrors()) return;
			//'create the order and empty the shopping cart at this point
			ShoppingCart cart = new ShoppingCart();
			string orderid = cart.CreateOrderSaveCart();

			//'save the user information to the database and then redirect to the credit card page.
			string strSQL;
			strSQL = "INSERT INTO CustomerInfo(FirstName, LastName, Address1, Address2, City, State, Zip, Country, Province, PostalCode, OrderID, Email) " +
				"Values ('" + txtFirst.Text + "', '" + txtLast.Text + "', '" + txtAdd1.Text + "', '" + txtAdd2.Text + "', '" + txtCity.Text + "', '" + ddlState.SelectedItem.Text + "', '" + txtZip.Text + "', '" + ddlCountry.SelectedItem.Text + "', '" + txtProvince.Text + "', '" + txtPostalCode.Text + "', " + orderid + ", '" + txtEmail.Text + "')" +
				";SELECT @@Identity as id";
			SqlConnection conCust = new SqlConnection(ConfigurationSettings.AppSettings["conSQL"]);
			SqlCommand cmdCust = new SqlCommand(strSQL, conCust);
			conCust.Open();
			int CID = 0;
			try
			{
				CID = Convert.ToInt32(cmdCust.ExecuteScalar());
			}
			catch (Exception exc)
			{
				//Trace.Warn(exc.Message);
				Response.Write("Customer Information was not saved.  Contact Patty Lepak at (715)346-2333 or plepak@uwsp.edu for assistance.");
                SendErrorEmail(exc.Message);
			}
		
			//Trace.Warn("strSQL: " + strSQL);
			//'get the user ID and save it to a cookie so we can use it in the receipt later
		
			conCust.Close();
			cmdCust = null;
			//Trace.Warn("CID: " + CID);
			//'cookie the id
			HttpCookie cookie = new HttpCookie("UWSPLibrary_CustomerID", CID.ToString());
			//'set the expiration on the cookie
			//'current date
			DateTime currentDate = DateTime.Now;
			//'set the timespan of cookie to 1 hour
			TimeSpan ts = new TimeSpan(3, 0, 0);
			//'expiration date
			DateTime expirationDate = currentDate.Add(ts);
			//'set the expiration date to the cookie
			cookie.Expires = expirationDate;
			//'set the cookie on client's browser
			Response.Cookies.Add(cookie);
			Response.Redirect("https://ais-ccweb.uwsp.edu/epay/epay001/default.aspx?Amt=" + GetOrderTotal() + "&Pid=99100182");
		}//	End Sub

        
        protected void btnCancel_Click(Object sender, EventArgs e)
		{
            string url = "http://" + Request.Url.Host + "/Library/gen_index/"; 
            Response.Redirect(url);
            //Response.Redirect("https://mypoint.uwsp.edu/Library/gen_index/");
		}
		
		public bool CheckErrors()
		{
		    ClearErrors();
			//'error checking routine
		    var valid = true;

            //Check for name, address and city
		    lblFNameErr.Visible = String.IsNullOrEmpty(txtFirst.Text);
            lblLNameErr.Visible = String.IsNullOrEmpty(txtLast.Text);
            lblAddrErr.Visible = String.IsNullOrEmpty(txtAdd1.Text);
            lblCityErr.Visible = String.IsNullOrEmpty(txtCity.Text);

		    valid = (lblFNameErr.Visible) && (lblLNameErr.Visible) && (lblAddrErr.Visible) && (lblCityErr.Visible);

            if (rblAgree.SelectedItem.Text != "Yes")
		    {
		        lblTermsErr.Visible = true;
		        valid = false;
		    }

            //'check for country issues
			if (ddlCountry.SelectedItem.Text != "United States")
			{
			    if (ddlState.SelectedItem.Text != "Not In US")
			    {
			        lblStateErr.Visible = true;
			        valid = false;
			    }

				//'make sure zip error is not visible 
				lblZipErr.Visible = false;
                             
				//'check to see if province and postal code are filled in as required for non-US addresses
				if (String.IsNullOrEmpty(txtProvince.Text))
				{
				    lblProvinceErr.Visible = true;
					valid = false;
				}

                if (String.IsNullOrEmpty(txtPostalCode.Text))
                {
                    lblPostalCodeErr.Visible = true;
                    valid = false;
                }
			}
			else
			{
				//'check the zip code, the rest are automatic
				//'make sure some errors are not visible if not necesary
				lblPostalCodeErr.Visible = false;
				lblProvinceErr.Visible = false;
				if (String.IsNullOrEmpty(txtZip.Text))
				{
					lblZipErr.Visible = true;
				    valid = false;
				}

                if (ddlState.SelectedItem.Text == "Not In US")
                {
                    lblStateErr.Text = "Must select a valid State when country is United States";
                    lblStateErr.Visible = true;
                    valid = false;
                }

			}

            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" + 
                    @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                    @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

            var re = new Regex(strRegex);
		    if  (!re.IsMatch(txtEmail.Text))
		    {
		        lblEmailErr.Visible = true;
		        valid = false;
		    }

            return valid;
        }

	    public void ClearErrors()
	    {
	        lblFNameErr.Visible = false;
	        lblLNameErr.Visible = false;
	        lblAddrErr.Visible = false;
	        lblCityErr.Visible = false;
	        lblPostalCodeErr.Visible = false;
	        lblProvinceErr.Visible = false;
	        lblStateErr.Visible = false;
	        lblTermsErr.Visible = false;
	        lblZipErr.Visible = false;
	        lblEmailErr.Visible = false;
	    }

        #region Shopping Cart functions
        private void BindShoppingCart()
		{
            if (Request.Cookies["UWSPLibrary_GEN_INDEX_CartID"] != null)
            {
                //Trace.Warn("Binding Shopping Cart...");
                //populate the data grid and set its datakey field
                SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["conSQL"]);

                string strSQL = "SELECT DISTINCT GEN_NAME.GN_ID, GEN_NAME.GN_LAST_NM + ', ' + GEN_NAME.GN_FIRST_NM AS FULL_NM, " +
                    "GEN_NAME.GN_RECORD_TYPE_CD, GEN_NAME.GN_COUNTY, ShoppingCart.Quantity, " +
                    "case when GEN_NAME.GN_RECORD_TYPE_CD=0 then (ceiling(ShoppingCart.Quantity / 5.0))*10 " +
		                "else ShoppingCart.Quantity*10 end as Subtotal " +
                    "FROM ShoppingCart INNER JOIN GEN_NAME ON ShoppingCart.GN_ID = GEN_NAME.GN_ID " +
                    "WHERE (ShoppingCart.CartID = @CartID)";//'f0fc1b79-1c29-48e9-abc2-77c282fb2a96')";
                SqlCommand command = new SqlCommand(strSQL, connection);
                command.Parameters.AddWithValue("CartID", Request.Cookies["UWSPLibrary_GEN_INDEX_CartID"].Value);
                SqlDataAdapter adap = new SqlDataAdapter(command);
                DataSet ds = new DataSet();

                //open the connection, execute the command and close the connection
                connection.Open();
                adap.Fill(ds);
                connection.Close();

                gvCart.DataSource = ds;
                gvCart.DataBind();
            }
			
			//'set the total amount label using the currency format
			//totalAmountLabel.Text = String.Format("{0:c}", cart.GetTotalAmount());
			
		}
        protected string GetOrderTotal()
        {
            ShoppingCart cart = new ShoppingCart();
            return cart.GetTotalAmount().ToString();
        }
        
        public string GetRecordType(int intRecordType, string strCounty)
        {
            switch (intRecordType)
            {
                case 0: return strCounty + " Obituary";
                case 1: return strCounty + " Census";
                case 2: return strCounty + " Naturalization";
                default: return "";
            }
        }

        protected string GetDollarSign(string strPrice)
        {
            return "$" + strPrice;
        }

        protected void btnUpdateQuantity_OnClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            foreach (GridViewRow row in gvCart.Rows)
            {
                //update quantity of each row
                string strIndex = gvCart.DataKeys[row.DataItemIndex].Value.ToString();
                TextBox tb = (TextBox)row.Cells[2].FindControl("txtQuantity");
                int intQuantity = Convert.ToInt32(tb.Text);
                cart.UpdateProductQuantity(strIndex, intQuantity);

            }
            BindShoppingCart();            
        }

        protected void gvCart_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TextBox txtQuantity = (TextBox)e.Row.Cells[2].FindControl("txtQuantity");
                txtQuantity.Text = DataBinder.Eval(e.Row.DataItem, "Quantity").ToString();
            }
        }


        protected void gvCart_OnRowDeleteing(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                var dataKey = gvCart.DataKeys[e.RowIndex];
                if (dataKey != null)
                {
                    string strItemID = dataKey.Value.ToString();

                    cart.RemoveProduct(strItemID);
                }
                BindShoppingCart();
            }
            catch (Exception ex)
            {
                SendErrorEmail(ex.Message);
            }

        }
        #endregion

        protected void SendErrorEmail(string strError)
        {
            MailMessage mm = new MailMessage("ais@uwsp.edu", "ais@uwsp.edu;plepak@uwsp.edu", "ERROR in GEN_INDEX", strError);
            SmtpClient sc = new SmtpClient("smtp.uwsp.edu");
            sc.Send(mm);
        }

	}

