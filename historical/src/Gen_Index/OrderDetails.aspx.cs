using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net.Mail;

public partial class OrderDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //save orderid from the query string to a variable
        string orderID = Request.Params["OrderID"].ToString();
        
        if (!Page.IsPostBack)
            PopulateControls();
    }
    protected void PopulateControls()
    {
        //create the orderManager object which has the GtOrderDetails method
        OrderManager om = new OrderManager();

        //the orderinfo object will be populated by calling
        OrderInfo orderInfo;

        //'we receive the order id in the query string
        string orderID = Request.Params["OrderID"];

        //populate the text boxes with order information
        orderInfo = om.GetOrderInfo(orderID);
        orderIDTextBox.Text = orderInfo.OrderID;
        TransID.Text = orderInfo.TransID;
        int iAmount = Convert.ToInt32(orderInfo.TotalAmount);
        totalAmountLabel.Text = GetOrderTotal(); //string.Format("{0:c}", iAmount);
        dateCreatedTextBox.Text = orderInfo.DateCreated;
        dateShippedTextBox.Text = orderInfo.DateShipped;
        verifiedTextBox.Text = orderInfo.Verified;
        completedTextBox.Text = orderInfo.Completed;
        canceledTextBox.Text = orderInfo.Canceled;
        commentsTextBox.Text = orderInfo.Comments;
        tbLast.Text = orderInfo.LastName;
        tbFirst.Text = orderInfo.FirstName;
        shippingAddressTextBox.Text = orderInfo.ShippingAddress1;
        txtEmail.Text = orderInfo.CustomerEmail;
        tbAdd2.Text = orderInfo.ShippingAddress2;
        tbCity.Text = orderInfo.City;
        tbState.Text = orderInfo.State;
        tbZip.Text = orderInfo.Zip;
        tbCountry.Text = orderInfo.Country;
        tbProvince.Text = orderInfo.Province;
        tbPostalCode.Text = orderInfo.PostalCode;

        //the order id can't be changed so we disable its textbox
        orderIDTextBox.Enabled = false;

        //populate the data grid and set its datakey field
        //gvCart.DataSource = om.GetOrderDetailsWithName(orderID);
        //gvCart.DataKeyField = "OrderID";
        //gvCart.DataBind();    
        BindShoppingCart();
    }//End PopulateControls

    protected void SetEditMode(bool value)
    {
        dateCreatedTextBox.Enabled = value;
        dateShippedTextBox.Enabled = value;
        verifiedTextBox.Enabled = value;
        completedTextBox.Enabled = value;
        canceledTextBox.Enabled = value;
        commentsTextBox.Enabled = value;
        tbLast.Enabled = value;
        tbFirst.Enabled = value;
        shippingAddressTextBox.Enabled = value;
        tbAdd2.Enabled = value;
        tbCity.Enabled = value;
        tbState.Enabled = value;
        tbZip.Enabled = value;
        tbCountry.Enabled = value;
        tbProvince.Enabled = value;
        tbPostalCode.Enabled = value;
        txtEmail.Enabled = value;
        updateButton.Enabled = value;
    }//		End SetEditMode


    protected void updateButton_Click(Object sender, EventArgs e)
    {
        // Store the new order details in an OrderInfo object
        OrderInfo orderInfo = new OrderInfo();
        orderInfo.OrderID = orderIDTextBox.Text;
        orderInfo.DateCreated = dateCreatedTextBox.Text;
        orderInfo.DateShipped = dateShippedTextBox.Text;
        orderInfo.Verified = verifiedTextBox.Text;
        orderInfo.Completed = completedTextBox.Text;
        orderInfo.Canceled = canceledTextBox.Text;
        orderInfo.Comments = commentsTextBox.Text;
        orderInfo.LastName = tbLast.Text;
        orderInfo.FirstName = tbFirst.Text;
        orderInfo.ShippingAddress1 = shippingAddressTextBox.Text;
        orderInfo.ShippingAddress2 = tbAdd2.Text;
        orderInfo.City = tbCity.Text;
        orderInfo.State = tbState.Text;
        orderInfo.Zip = tbZip.Text;
        orderInfo.Country = tbCountry.Text;
        orderInfo.Province = tbProvince.Text;
        orderInfo.PostalCode = tbPostalCode.Text;
        orderInfo.CustomerEmail = txtEmail.Text;

        try
        {
            // Update the order
            OrderManager om = new OrderManager();
            om.UpdateOrder(orderInfo);
        }
        catch
        {
            // Do nothing in case the update fails
        }

        // Exit edit mode and update controls' information
        PopulateControls();
    }//	End updateButton_Click

    protected void cancelButton_Click(System.Object sender, System.EventArgs e)
    {
        SetEditMode(false);
        PopulateControls();
    }//	End Sub

    protected void markAsVerifiedButton_Click(Object sender, EventArgs e)
    {
        OrderManager om = new OrderManager();
        string orderId = orderIDTextBox.Text;
        om.MarkOrderAsVerified(orderId);
        PopulateControls();
    }//	End Sub

    protected void markAsCompletedButton_Click(System.Object sender, System.EventArgs e)
    {
        OrderManager om = new OrderManager();
        string orderId = orderIDTextBox.Text;
        om.MarkOrderAsCompleted(orderId);
        
        PopulateControls();
        //send an email to customer saying order is completed and in mail
        //only if an email adress exists though
        if (txtEmail.Text.Length > 0)
        {
            SendEmail();
        }
    }//End Sub

    protected void markAsCanceledButton_Click(System.Object sender, System.EventArgs e)
    {
        OrderManager om = new OrderManager();
        string orderId = orderIDTextBox.Text;
        om.MarkOrderAsCanceled(orderId);
        PopulateControls();
        //send email to customer saying order was cancelled
        SendCancel();
    }//End Sub
    //sends email to users
    public void SendEmail()
    {
        //Set the body
        string strBody = "<TABLE id=\"Table1\" cellSpacing=\"1\" cellPadding=\"1\" width=\"458\" border=\"1\">";
        strBody = strBody + "<TR><TD align=\"middle\" colSpan=\"2\"><asp:Label id=\"Label1\" runat=\"server\" Font-Bold=\"True\" Font-Size=\"Medium\">Your order has been shipped!  Thank you!</asp:Label></TD></TR>";
        strBody = strBody + "<TR><TD><asp:Label id=\"Label3\" runat=\"server\">Order ID#:</asp:Label></TD><TD><asp:Label id=\"lblOID\" runat=\"server\">" + orderIDTextBox.Text + "</asp:Label></TD></TR>";
        strBody += "<TR><TD></TD></TR><TR><TD>You may reply to this message if you have any questions.  Thank You!</TD></TR>";
        //Create an instance of the MailMessage class
        MailMessage objMM = new MailMessage(txtEmail.Text, "archives@uwsp.edu", "UWSP Archives Census Order Shipped", strBody);
        objMM.IsBodyHtml = true;

        //Specify to use the default Smtp Server
        SmtpClient sc = new SmtpClient("smtp.uwsp.edu");

        //Now, to send the message, use the Send method of the SmtpMail class
        sc.Send(objMM);

    }//End Sub
    public void SendCancel()
    {
        //Set the body
        string strBody = "<TABLE id=\"Table1\" cellSpacing=\"1\" cellPadding=\"1\" width=\"458\" border=\"1\">";
        strBody = strBody + "<TR><TD align=\"middle\" colSpan=\"2\"><asp:Label id=\"Label1\" runat=\"server\" Font-Bold=\"True\" Font-Size=\"Medium\">Your order has been cancelled.  You may reply to this email if you have any questions.</asp:Label></TD></TR>";
        strBody = strBody + "<TR><TD><asp:Label id=\"Label3\" runat=\"server\">Order ID#:</asp:Label></TD><TD><asp:Label id=\"lblOID\" runat=\"server\">" + orderIDTextBox.Text + "</asp:Label></TD></TR>";

        //Create an instance of the MailMessage class
        MailMessage objMM = new MailMessage(txtEmail.Text, "archives@uwsp.edu", "UWSP Archives Census Order Cancelled", strBody);

        //Specify to use the default Smtp Server
        SmtpClient sc = new SmtpClient("smtp.uwsp.edu");

        //Now, to send the message, use the Send method of the SmtpMail class
        sc.Send(objMM);
    }

    private void BindShoppingCart()
    {
        //Trace.Warn("Binding Shopping Cart...");
        //populate the data grid and set its datakey field
        SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["conSQL"]);

        string strSQL = "SELECT distinct OrderDetail.Quantity, (GEN_NAME.GN_LAST_NM + ', ' + GEN_NAME.GN_FIRST_NM) AS FULL_NAME, " +
                "GEN_NAME.GN_RECORD_TYPE_CD AS GN_RECORD_TYPE_CD, GEN_NAME.GN_LOCATION AS LOCATION, OBITS_DATES.N_ABBR, " +
                "GEN_NAME.GN_DATE_OF_RECORD, GEN_NAME.GN_COUNTY, OrderDetail.GN_ID AS GN_ID " +
            "FROM OrderDetail INNER JOIN GEN_NAME ON OrderDetail.GN_ID = GEN_NAME.GN_ID LEFT OUTER JOIN " +
                "OBITS_DATES ON GEN_NAME.GN_ID = OBITS_DATES.GN_ID " +
            "WHERE OrderDetail.OrderID = @OrderID";
        
        SqlCommand command = new SqlCommand(strSQL, connection);
        command.Parameters.AddWithValue("OrderID", Request.QueryString["OrderID"].ToString());
        SqlDataAdapter adap = new SqlDataAdapter(command);
        DataSet ds = new DataSet();

        //open the connection, execute the command and close the connection
        connection.Open();
        adap.Fill(ds);
        connection.Close();

        gvCart.DataSource = ds;
        gvCart.DataBind();
    }
    /// <summary>
    /// Returns the location or source of the record
    /// Census uses GN_LOCATION
    /// Naturalization builds a string with index information
    /// </summary>
    /// <param name="intRecordType"></param>
    /// <param name="strLocation"></param>
    /// <returns></returns>
    public string GetLocation(int intRecordType, string strLocation, string strRecord_ID)
    {
        switch (intRecordType)
        {
            case 1: //census 
                return GetCensusTown(strRecord_ID) + " (" + strLocation + ")";
            default: //naturalization record so we need to build the string
                string strSQL = "SELECT * FROM NATURALIZATION_DATA WHERE GN_ID=" + strRecord_ID;
                SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["conSQL"]);
                SqlCommand cmd = new SqlCommand(strSQL, con);
                con.Open();
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                string strLoc = ""; //holds location data
                dr.Read();
                strLoc = "";
                try
                {
                    if (dr["ND_SERIES"].ToString().Length > 0)
                        strLoc += " Series: " + dr["ND_SERIES"].ToString();
                }
                catch { }
                try
                {
                    if (dr["ND_BOX"].ToString().Length > 0)
                        strLoc += " Box: " + dr["ND_BOX"].ToString();
                }
                catch { }
                try
                {
                    if (dr["ND_FOLDER"].ToString().Length > 0)
                        strLoc += " Folder: " + dr["ND_FOLDER"].ToString();
                }
                catch { }
                try
                {
                    if (dr["ND_VOL_NUM"].ToString().Length > 0)
                        strLoc += " Vol#: " + dr["ND_VOL_NUM"].ToString();
                }
                catch { }
                try
                {
                    if (dr["ND_PAGE_CERT_NUM"].ToString().Length > 0)
                        strLoc += " Page Cert#: " + dr["ND_PAGE_CERT_NUM"].ToString();
                }
                catch { }

                con.Close();
                //CHECK FOR BLANKS
                if (strLoc.Length > 0) strLoc = strLocation + " (" + strLoc.Trim() + ")";
                else strLoc = strLocation;

                return strLoc;
        }
    }
    public string GetCensusTown(string strGN_ID)
    {
        string strSQL = "SELECT CENSUS_TOWN.CT_NAME FROM GEN_NAME INNER JOIN CENSUS_TOWN ON GEN_NAME.CT_ID = CENSUS_TOWN.CT_ID " +
            "WHERE GN_ID=" + strGN_ID;
        SqlConnection conSQL = new SqlConnection(ConfigurationManager.AppSettings["conSQL"]);
        SqlCommand cmd = new SqlCommand(strSQL, conSQL);
        conSQL.Open();
        string strTown = Convert.ToString(cmd.ExecuteScalar());
        conSQL.Close();

        return strTown;
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
    protected string GetOrderTotal()
    {
        string strSQL = "SELECT CEILING(SUM(OrderDetail.Quantity) / 5.0) * 10 AS Subtotal " +
                "FROM OrderDetail INNER JOIN GEN_NAME ON OrderDetail.GN_ID = GEN_NAME.GN_ID " +
                "WHERE (OrderDetail.OrderID = @OrderID) AND (GEN_NAME.GN_RECORD_TYPE_CD = 0)";
        SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["conSQL"]);
        SqlCommand command = new SqlCommand(strSQL, connection);
        command.Parameters.AddWithValue("OrderID", Request.QueryString["OrderID"].ToString());
        connection.Open();
        int intObitsAmount = 0;
        try
        {
            intObitsAmount = Convert.ToInt32(command.ExecuteScalar());
        }
        catch { }
        connection.Close();
        //get census and naturalization total
        strSQL = "SELECT SUM(OrderDetail.Quantity) * 10 AS Subtotal " +
                "FROM OrderDetail INNER JOIN GEN_NAME ON OrderDetail.GN_ID = GEN_NAME.GN_ID " +
                "WHERE (OrderDetail.OrderID = @OrderID) AND (GEN_NAME.GN_RECORD_TYPE_CD <> 0)";
        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conSQL"]);
        SqlCommand cmd = new SqlCommand(strSQL, conn);
        cmd.Parameters.AddWithValue("OrderID", Request.QueryString["OrderID"].ToString());
        conn.Open();
        int intRestTotal = 0;
        try
        {
            intRestTotal = Convert.ToInt32(cmd.ExecuteScalar());
        }
        catch { }
        conn.Close();

        return "Total: $" + Convert.ToString(intObitsAmount + intRestTotal);
    }
     
}
