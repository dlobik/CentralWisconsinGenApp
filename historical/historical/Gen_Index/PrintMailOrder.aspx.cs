using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Net.Mail;
using Repository;

/// <summary>
	/// Summary description for PrintMailOrder.
	/// </summary>
	public partial class PrintMailOrder : System.Web.UI.Page
	{
        ShoppingCart cart;
        IGenIndexDbRepository _repository = new GenIndexDbRepository();

		protected void Page_Load(object sender, EventArgs e)
		{
            ClearErrors();

            if (!IsPostBack)
			    BindShoppingCart();

            cart = new ShoppingCart();

            //StringBuilder cstext1 = new StringBuilder();
            //cstext1.Append("function pagePrint() { ");
            //cstext1.Append("var valid; ");
            //cstext1.Append("var add = $('#txtAdd1').val() ");
            //cstext1.Append("var first = $('#txtFirst').val() ");
            //cstext1.Append("var last = $('#txtLast').val() ");
            //cstext1.Append("var city = $('#txtCity').val() ");
            //cstext1.Append("var country = $('#ddlCountry option:selected').val() ");
            //cstext1.Append("var province = $('#txtProvince').val() ");
            //cstext1.Append("var postal = $('#txtPostalCode').val() ");
            //cstext1.Append("var zip = $('#txtZip').val() ");
            //cstext1.Append("var termsYes = $('input:radio[name=rbTermsYes]:checked').val(); ");
            //cstext1.Append("var termsNo = $('input:radio[name=rbTermsNo]:checked').val(); ");
            //cstext1.Append("PageMethods.CheckPageForErrors(add,first,last,city,country,province,postal,zip,termsYes,termsNo); ");
            //cstext1.Append("function onSucess(result) { ");
            //cstext1.Append("if (result) { ");
            //cstext1.Append("window.print(); } ");
            //cstext1.Append("} ");
            //cstext1.Append("function onError(result) { ");
            //cstext1.Append("} ");
            //cstext1.Append("} ");
            //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "PrintScript", cstext1.ToString(), true);
            //btnPrint.Attributes.Add("onclick","pagePrint()");
             

        }

        #region Shopping Cart Functions
        private void BindShoppingCart()
		{
            if (Request.Cookies["UWSPLibrary_GEN_INDEX_CartID"] != null)
            {
                //Trace.Warn("Binding Shopping Cart...");
                //populate the data grid and set its datakey field
                SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["conSQL"]);

                //string strSQL = "SELECT DISTINCT GEN_NAME.GN_ID, GEN_NAME.GN_LAST_NM + ', ' + GEN_NAME.GN_FIRST_NM AS FULL_NM, " +
                //    "GEN_NAME.GN_RECORD_TYPE_CD, GEN_NAME.GN_COUNTY, ShoppingCart.Quantity, " +
                //    "(ShoppingCart.Quantity - 1) * 0.25 + 10 AS Subtotal " +
                //    "FROM ShoppingCart INNER JOIN GEN_NAME ON ShoppingCart.GN_ID = GEN_NAME.GN_ID " +
                //    "WHERE (ShoppingCart.CartID = @CartID)";//'f0fc1b79-1c29-48e9-abc2-77c282fb2a96')";
            //    string strSQL = "SELECT distinct OrderDetail.Quantity, (GEN_NAME.GN_LAST_NM + ', ' + GEN_NAME.GN_FIRST_NM) AS FULL_NAME, " +
            //    "GEN_NAME.GN_RECORD_TYPE_CD, GEN_NAME.GN_LOCATION, OBITS_DATES.N_ABBR, " +
            //    "GEN_NAME.GN_DATE_OF_RECORD, GEN_NAME.GN_COUNTY, OrderDetail.GN_ID " +
            //"FROM OrderDetail INNER JOIN GEN_NAME ON OrderDetail.GN_ID = GEN_NAME.GN_ID LEFT OUTER JOIN " +
            //    "OBITS_DATES ON GEN_NAME.GN_ID = OBITS_DATES.GN_ID " +
            //"WHERE OrderDetail.OrderID = @CartID";


                //string strSQL = "SELECT DISTINCT GEN_NAME.GN_ID, " +
                //    "GEN_NAME.GN_LAST_NM + ', ' + GEN_NAME.GN_FIRST_NM AS FULL_NAME, " +
                //    "GEN_NAME.GN_RECORD_TYPE_CD, GEN_NAME.GN_COUNTY, ShoppingCart.Quantity, " +
                //    "GEN_NAME.GN_LOCATION, OBITS_DATES.N_ABBR, GEN_NAME.GN_DATE_OF_RECORD " +
                //    "FROM ShoppingCart INNER JOIN GEN_NAME ON ShoppingCart.GN_ID = GEN_NAME.GN_ID LEFT OUTER JOIN " +
                //        "OBITS_DATES ON GEN_NAME.GN_ID = OBITS_DATES.GN_ID " +
                //    "WHERE (ShoppingCart.CartID = @CartID)";//'f0fc1b79-1c29-48e9-abc2-77c282fb2a96')";
                //SqlCommand command = new SqlCommand(strSQL, connection);
                //command.Parameters.AddWithValue("CartID", Request.Cookies["UWSPLibrary_GEN_INDEX_CartID"].Value);
                //SqlDataAdapter adap = new SqlDataAdapter(command);
                //DataSet ds = new DataSet();
                //Trace.Warn("sql: " + strSQL);
                ////open the connection, execute the command and close the connection
                //connection.Open();
                //adap.Fill(ds);
                //connection.Close();

                var ds = _repository.PrintMailOrder(Request.Cookies["UWSPLibrary_GEN_INDEX_CartID"].Value);
              
                gvCart.DataSource = ds;
                gvCart.DataBind();
            }
			
		}
        protected string GetOrderTotal()
        {
            ShoppingCart cart = new ShoppingCart();
            return "$" + cart.GetTotalAmount().ToString();
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
        protected void gvCart_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string strItemID = gvCart.DataKeys[e.RowIndex].Value.ToString();

            cart.RemoveProduct(strItemID);
            BindShoppingCart();
        }
    
       
        #endregion

		public void btnPrint_Click(Object sender, EventArgs e)
		{
            ClearErrors();
			//have to do manual error checking 
			if (!CheckErrors())	return;

			try
			{
                ClientScript.RegisterStartupScript(this.GetType(), "printer", "<script language=javascript>window.print();</script>");
             }
			catch (Exception err)
			{
				//Trace.Warn("Print Failed: " + err.Message);
                System.Web.Mail.MailMessage message = new System.Web.Mail.MailMessage();
                message.From = "ais@uwsp.edu";
                message.To = "ais@uwsp.edu; plepak@uwsp.edu";
                message.Subject = "Gen Index Print Failed";
                message.Body = err.ToString();
                System.Web.Mail.SmtpMail.SmtpServer = "smtp.uwsp.edu";
                System.Web.Mail.SmtpMail.Send(message);
			}
	
			//'empty the shopping cart
			ShoppingCart cart = new ShoppingCart();
            cart.EmptyShoppingCart(Request.Cookies["UWSPLibrary_GEN_INDEX_CartID"].Value);
		}

	    [System.Web.Services.WebMethod]
  	    public static void CheckPageForErrors(string addTxt, string firstTxt, string lastTxt, string cityTxt, string countryTxt,
            string provinceTxt, string postalTxt, string zipTxt, string stateTxt, string agreeTxt, string emailTxt)
	    {
	        var pmoPage = new PrintMailOrder();
            var valid = pmoPage.CheckErrors2(addTxt, firstTxt, lastTxt, cityTxt, countryTxt, provinceTxt, postalTxt, zipTxt, stateTxt, agreeTxt, emailTxt);
	        //return valid;
	    }

	    public bool CheckErrors2(string addTxt, string firstTxt, string lastTxt, string cityTxt, string countryTxt,
            string provinceTxt, string postalTxt, string zipTxt, string stateTxt, string agreeTxt, string emailTxt)
	    {
            ClearErrors();
            //'error checking routine
            var valid = true;

            //Check for name, address and city
            lblFNameErr.Visible = String.IsNullOrEmpty(firstTxt);
            lblLNameErr.Visible = String.IsNullOrEmpty(lastTxt);
            lblAddrErr.Visible = String.IsNullOrEmpty(addTxt);
            lblCityErr.Visible = String.IsNullOrEmpty(cityTxt);

            valid = (lblFNameErr.Visible) && (lblLNameErr.Visible) && (lblAddrErr.Visible) && (lblCityErr.Visible);

            if (agreeTxt != "Yes")
            {
                lblTermsErr.Visible = true;
                valid = false;
            }

            //'check for country issues
            if (countryTxt != "United States")
            {
                if (stateTxt != "Not In US")
                {
                    lblStateErr.Visible = true;
                    valid = false;
                }

                //'make sure zip error is not visible 
                lblZipErr.Visible = false;

                //'check to see if province and postal code are filled in as required for non-US addresses
                if (String.IsNullOrEmpty(provinceTxt))
                {
                    lblProvinceErr.Visible = true;
                    valid = false;
                }

                if (String.IsNullOrEmpty(postalTxt))
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
                if (String.IsNullOrEmpty(zipTxt))
                {
                    lblZipErr.Visible = true;
                    valid = false;
                }

                if (stateTxt == "Not In US")
                {
                    lblStateErr.Text = "Must select a valid State when country is United States";
                    lblStateErr.Visible = true;
                    valid = false;
                }

            }

            const string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                    @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                    @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

            var re = new Regex(strRegex);
            if ((!String.IsNullOrEmpty(txtEmail.Text)) &&(!re.IsMatch(emailTxt)))
            {
                lblEmailErr.Visible = true;
                valid = false;
            }

            return valid;

	        //if (addTxt == "" || firstTxt == "" || txtLast.Text == "" || txtCity.Text == "")
	        //{
	        //    lblAdd1Error.Visible = addTxt == "";

	        //    lblFirstError.Visible = firstTxt == "";

	        //    lblLastError.Visible = lastTxt == "";

	        //    lblCityError.Visible = cityTxt == "";

	        //    valid = false;
	        //}
	        //else
	        //{
	        //    //'none are blank so turn off all error messages
	        //    lblAdd1Error.Visible = false;
	        //    lblFirstError.Visible = false;
	        //    lblLastError.Visible = false;
	        //    lblCityError.Visible = false;
	        //    valid = true;
	        //}

	        ////'check for country issues
	        //if (countryTxt != "United States")
	        //{
	        //    //'make sure zip is not visible
	        //    lblZipError.Visible = false;
	        //    //'check to see if province and postal code are filled in as required for non-US addresses
	        //    if (provinceTxt == "" || postalTxt == "")
	        //    {
	        //        lblProvinceError.Visible = provinceTxt == "";

	        //        lblPostalCodeError.Visible = postalTxt == "";

	        //        valid = false;
	        //    }
	        //    else
	        //    {
	        //        //'they aren't blank so make sure error labels are invisible
	        //        lblProvinceError.Visible = false;
	        //        lblPostalCodeError.Visible = false;
	        //        valid = true;
	        //    }
	        //}
	        //else
	        //{
	        //    //'check the zip code, the rest are automatic
	        //    //'make sure some errors are not visible if not necesary
	        //    lblPostalCodeError.Visible = false;
	        //    lblProvinceError.Visible = false;
	        //    if (zipTxt == "")
	        //    {
	        //        lblZipError.Visible = true;
	        //        valid = false;
	        //    }
	        //    else
	        //    {
	        //        lblZipError.Visible = false;
	        //        valid = true;
	        //    }
	        //}


	        //if ((termsCheckedNo) && (!termsCheckedYes))
	        //{
	        //    lblTerms.Visible = true;
	        //    valid = false;
	        //}
	        //else
	        //{
	        //    lblTerms.Visible = false;
	        //    valid = true;
	        //}

	        //bool result = valid;
	        //return result;
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
            if ((!String.IsNullOrEmpty(txtEmail.Text)) && (!re.IsMatch(txtEmail.Text)))
            {
                lblEmailErr.Visible = true;
                valid = false;
            }

            return valid;

	        //return ((cvTxtProvince.IsValid) && (cvTxtZip.IsValid) && (cvTxtPostalCode.IsValid) && (Page.IsValid));

	        ////'error checking routine
	        ////'always see if names, addys or city are blank
	        //if (txtAdd1.Text == "" || txtFirst.Text == "" || txtLast.Text == "" || txtCity.Text == "")
	        //{
	        //    if (txtAdd1.Text == "")
	        //        lblAdd1Error.Visible = true;
	        //    else
	        //        lblAdd1Error.Visible = false;

	        //    if (txtFirst.Text == "")
	        //        lblFirstError.Visible = true;
	        //    else
	        //        lblFirstError.Visible = false;

	        //    if (txtLast.Text == "")
	        //        lblLastError.Visible = true;
	        //    else
	        //        lblLastError.Visible = false;

	        //    if (txtCity.Text == "")
	        //        lblCityError.Visible = true;
	        //    else
	        //        lblCityError.Visible = false;

	        //    return true;
	        //}
	        //else 
	        //{
	        //    //'none are blank so turn off all error messages
	        //    lblAdd1Error.Visible = false;
	        //    lblFirstError.Visible = false;
	        //    lblLastError.Visible = false;
	        //    lblCityError.Visible = false;
	        //}

	        ////'check for country issues
	        //if (ddlCountry.SelectedItem.Text != "United States")
	        //{
	        //    //'make sure zip is not visible
	        //    lblZipError.Visible = false;
	        //    //'check to see if province and postal code are filled in as required for non-US addresses
	        //    if (txtProvince.Text == "" || txtPostalCode.Text == "")
	        //    {
	        //        if (txtProvince.Text == "")
	        //            lblProvinceError.Visible = true;
	        //        else
	        //            lblProvinceError.Visible = false;

	        //        if (txtPostalCode.Text == "")
	        //            lblPostalCodeError.Visible = true;
	        //        else
	        //            lblPostalCodeError.Visible = false;

	        //        return true;
	        //    }
	        //    else 
	        //    {
	        //        //'they aren't blank so make sure error labels are invisible
	        //        lblProvinceError.Visible = false;
	        //        lblPostalCodeError.Visible = false;
	        //    }
	        //}
	        //else
	        //{
	        //    //'check the zip code, the rest are automatic
	        //    //'make sure some errors are not visible if not necesary
	        //    lblPostalCodeError.Visible = false;
	        //    lblProvinceError.Visible = false;
	        //    if (txtZip.Text == "")
	        //    {
	        //        lblZipError.Visible = true;
	        //        return true;
	        //    }
	        //    else    lblZipError.Visible = false;

	        //}
	        //if (rbTermsNo.Checked || rbTermsYes.Checked == false)
	        //{
	        //    lblTerms.Visible = true;
	        //    return true;
	        //}
	        //else
	        //{
	        //    lblTerms.Visible = false;
	        //    return false;
	        //}

	        ////return false;
		}//end checkerrors

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
            lblPhoneErr.Visible = false;
            lblZipErr.Visible = false;
        }

		protected void btnSearch_Click(object sender, System.EventArgs e)
		{
            string url = "http://" + Request.Url.Host + "/Library/gen_index/Default.aspx"; 
            Response.Redirect(url);
			//Response.Redirect("https://mypoint.uwsp.edu/Library/Gen_Index/Default.aspx");
		}

        //this function gets the obits ID and newspaper and returns a concatenated string of article dates
        protected string GetDateofRecord(int intGN_ID, int intRecord_Type, string strNews, string strDateOfRecord)
        {
            string strReturn = "";

            if (intRecord_Type == 0)
            {
                //obituary - return dates
                string strSQL = "SELECT * FROM OBITS_DATES WHERE GN_ID=" + intGN_ID + " AND N_ABBR='" + strNews + "'";
                SqlConnection conImages = new SqlConnection(ConfigurationManager.AppSettings["conSQL"]);
                SqlCommand cmdImages = new SqlCommand(strSQL, conImages);
                conImages.Open();
                SqlDataReader drImages;
                drImages = cmdImages.ExecuteReader();

                while (drImages.Read())
                {
                    //need to add the full text hyperlink here
                    if (drImages["OD_WEB_ENTRY"].ToString() != "")
                    {
                        if (drImages["OD_WEB_ENTRY"].ToString().Trim().Length > 0)
                        {
                            strReturn = strReturn.Trim() + ", <a href=\"OpenFullText.aspx?id=" + drImages["OD_ID"].ToString() + "\" target=\"_blank\">" + drImages["OD_ARTICLE_DATE"].ToString() + "</a>";
                        }
                        else
                            strReturn = strReturn.Trim() + ", " + drImages["OD_ARTICLE_DATE"].ToString();
                    }
                    else
                        strReturn = strReturn.Trim() + ", " + drImages["OD_ARTICLE_DATE"].ToString();
                }

                strReturn = strNews + " " + strReturn.Substring(2);
                conImages.Close();
            }
            else
            {
                // just return the date of record itself for census and naturalization records.
                strReturn = strDateOfRecord;
            }

            return strReturn;
        }


        protected void IfStateZipRequiredValidate(object source, ServerValidateEventArgs args)
        {
            if (ddlState.SelectedValue != "NotInUS")
            {
                args.IsValid = !String.IsNullOrEmpty(txtZip.Text);
                if (String.IsNullOrEmpty(txtZip.Text)) { txtZip.Focus(); }
            }

            Match m = Regex.Match(txtZip.Text.ToString(CultureInfo.InvariantCulture), @"^[0-9\-]+$");
            if ((!String.IsNullOrEmpty(txtZip.Text)) && (m.Success))
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }


        protected void IfNotUsProvinceRequiredValidate(object source, ServerValidateEventArgs args)
        {
            if (ddlCountry.SelectedValue != "United States")
            {
                args.IsValid = !String.IsNullOrEmpty(txtProvince.Text);
                if (!String.IsNullOrEmpty(txtProvince.Text)) { txtProvince.Focus(); }
            }
        }

        protected void IfNotUsPostalRequiredValidate(object source, ServerValidateEventArgs args)
        {
            if (ddlCountry.SelectedValue != "United States")
            {
                args.IsValid = !String.IsNullOrEmpty(txtPostalCode.Text);
                if (!String.IsNullOrEmpty(txtPostalCode.Text)) { txtPostalCode.Focus(); }
            }
        }
	}


