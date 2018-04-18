using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Net.Mail;
using System.Configuration;

public partial class CustomerReceipt : System.Web.UI.Page
{    
    private void Page_Load(object sender, EventArgs e)
    {
        // CustomerReceipt.aspx&TransId=12345678901234&CCNum=xxxxxxxxxxxx2134&ExpDate=0803&Name=Rob Clint&Amt=1
            //&TransId=12345678901234&CCNum=xxxxxxxxxxxx2134&ExpDate=0803&Name=Rob Clint&Amt=1
        //fill the labels
        lblTransID.Text = Request.QueryString["TransID"];
        lblCC.Text = Request.QueryString["CCNum"];
        lblExp.Text = Request.QueryString["ExpDate"];
        lblCName.Text = Request.QueryString["Name"];
        lblAmt.Text = "$" + Request.QueryString["Amt"].ToString() + ".00";

        //get customer info from table and cookie
        string strSQL;
        int CID = Convert.ToInt32(Request.Cookies["UWSPLibrary_CustomerID"].Value);
        
        //display order info
        strSQL = "Select * from CustomerInfo where CustID = " + CID;
        SqlConnection conObits = new SqlConnection(ConfigurationSettings.AppSettings["conSQL"]);
        SqlCommand cmdObits = new SqlCommand(strSQL, conObits);

        conObits.Open();
        SqlDataReader drObits;
        drObits = cmdObits.ExecuteReader();

        drObits.Read();

        //verify the order as paid
        OrderManager om = new OrderManager();
        om.MarkOrderAsVerified(drObits["OrderID"].ToString());
        
        //insert transactionID into orders table
        string strTID = "UPDATE Orders SET TransID = '" + lblTransID.Text.Trim() + "' WHERE ORDERID=" + drObits["OrderID"];
        SqlConnection conTID = new SqlConnection(ConfigurationSettings.AppSettings["conSQL"]);
        SqlCommand cmdTID = new SqlCommand(strTID, conTID);

        conTID.Open();
        cmdTID.ExecuteNonQuery();
        conTID.Close();

        lblName.Text = drObits["Firstname"] + " " + drObits["Lastname"];
        lblAdd1.Text = drObits["Address1"].ToString();
        lblAdd2.Text = drObits["Address2"].ToString();
        lblCity.Text = drObits["City"].ToString();
        lblCountry.Text = drObits["Country"].ToString();
        //check the country to determine information to display
        if (drObits["country"].ToString() == "United States")
        {
            lblZip.Text = drObits["Zip"].ToString();
            lblState.Text = drObits["State"].ToString();
        }
        else
        {
            //non-US country
            lblZip.Text = drObits["Postal Code"].ToString();
            lblState.Text = drObits["Province"].ToString();
            lblZipOrPost.Text = "Postal Code:";
            lblStateOrProvince.Text = "Province:";
        }
        lblOID.Text = drObits["OrderID"].ToString();
        lblProvince.Text = drObits["Province"].ToString();
        lblPostalCode.Text = drObits["PostalCode"].ToString();

        //email receipt to the user if they entered one previously
        //only email the first time on the page
        if (!Page.IsPostBack)
        {
            string strEmail = drObits["email"].ToString();
            if (strEmail.Trim().Length > 0)
            {
                lblEmail.Text = drObits["email"].ToString();
                //do the email section here
                SendEmail(drObits);
            }
        }
        conObits.Close();
        drObits = null;
        BindShoppingCart();
    }

    //sends email to users
    public void SendEmail(SqlDataReader dr)
    {
        //Set the body
        string strBody = "<TABLE id=\"Table1\" cellSpacing=\"1\" cellPadding=\"1\" width=\"458\" border=\"1\">";
        strBody = strBody + "<TR><TD align=\"middle\" colSpan=\"2\"><asp:Label id=\"Label5\" runat=\"server\" Font-Bold=\"True\" Font-Size=\"X-Large\" Font-Underline=\"True\">UWSP Archives Order Receipt</asp:Label></TD></TR>";
        strBody = strBody + "<TR><TD align=\"middle\" colSpan=\"2\"><asp:Label id=\"Label1\" runat=\"server\" Font-Bold=\"True\" Font-Size=\"Medium\">Thank you for your order!</asp:Label></TD></TR>";
        strBody = strBody + "<TR><TD><asp:Label id=\"Label18\" runat=\"server\">Transaction #:</asp:Label></TD><TD><asp:Label id=\"lblTransID\" runat=\"server\">" + Request.QueryString["transid"] + "</asp:Label></TD></TR>";
        strBody = strBody + "<TR><TD><asp:Label id=\"Label2\" runat=\"server\">Name:</asp:Label></TD><TD><asp:Label id=\"lblName\" runat=\"server\">" + lblName.Text + "</asp:Label></TD></TR>";
        strBody = strBody + "<TR><TD><asp:Label id=\"Label4\" runat=\"server\">Address (Line 1):</asp:Label></TD><TD><asp:Label id=\"lblAdd1\" runat=\"server\">" + lblAdd1.Text + "</asp:Label></TD></TR>";
        strBody = strBody + "<TR><TD><asp:Label id=\"Label6\" runat=\"server\">Address (Line 2):</asp:Label></TD><TD><asp:Label id=\"lblAdd2\" runat=\"server\">" + lblAdd2.Text + "</asp:Label></TD></TR>";
        strBody = strBody + "<TR><TD><asp:Label id=\"Label7\" runat=\"server\">City:</asp:Label></TD><TD><asp:Label id=\"lblCity\" runat=\"server\">" + lblCity.Text + "</asp:Label></TD></TR>";
        strBody = strBody + "<TR><TD><asp:Label id=\"Label10\" runat=\"server\">State:</asp:Label></TD><TD><asp:Label id=\"lblState\" runat=\"server\">" + lblState.Text + "</asp:Label></TD></TR>";
        strBody = strBody + "<TR><TD><asp:Label id=\"Label11\" runat=\"server\">Zipcode:</asp:Label></TD><TD><asp:Label id=\"lblZip\" runat=\"server\">" + lblZip.Text + "</asp:Label></TD></TR>";
        strBody = strBody + "<TR><TD><asp:Label id=\"Label14\" runat=\"server\">Credit Card #:</asp:Label></TD><TD><asp:Label id=\"lblCC\" runat=\"server\">" + Request.QueryString["ccnum"] + "</asp:Label></TD></TR>";
        strBody = strBody + "<TR><TD><asp:Label id=\"Label15\" runat=\"server\">Expiration Date:</asp:Label></TD><TD><asp:Label id=\"lblExp\" runat=\"server\">" + Request.QueryString["expdate"] + "</asp:Label></TD></TR>";
        strBody = strBody + "<TR><TD><asp:Label id=\"Label16\" runat=\"server\">Name on Card:</asp:Label></TD><TD><asp:Label id=\"lblCName\" runat=\"server\">" + Request.QueryString["name"] + "</asp:Label></TD></TR>";
        strBody = strBody + "<TR><TD><asp:Label id=\"Label17\" runat=\"server\">Amount:</asp:Label></TD><TD><asp:Label id=\"lblAmt\" runat=\"server\">" + lblAmt.Text + "</asp:Label></TD></TR>";
        strBody = strBody + "<TR><TD><asp:Label id=\"Label3\" runat=\"server\">Order ID#:</asp:Label></TD><TD><asp:Label id=\"lblOID\" runat=\"server\">" + lblOID.Text + "</asp:Label></TD></TR>";

        //Create an instance of the MailMessage class
        MailMessage objMM = new MailMessage("archives@uwsp.edu", lblEmail.Text, "UWSP Archives Census Order Receipt", strBody);
        objMM.IsBodyHtml = true;
        //Specify to use the default Smtp Server
        SmtpClient sc = new SmtpClient("smtp.uwsp.edu");

        //Now, to send the message, use the Send method of the SmtpMail class
        sc.Send(objMM);
    }//	End sendmail

    protected void btnPrint_OnClick(object sender, ImageClickEventArgs e)
    {
        ClientScript.RegisterStartupScript(this.GetType(), "printer", "<script>javascript:window.print();</script>");               
    }

    private void BindShoppingCart()
    {
        ////Trace.Warn("Binding Shopping Cart...");
        ////populate the data grid and set its datakey field
        //ShoppingCart cart = new ShoppingCart();
        //SqlDataReader dr = cart.GetProducts();
        //dgCart.DataSource = dr;
        ////'dgCart.DataSource = cart.GetProducts
        //dgCart.DataKeyField = "CH_ID";
        //dgCart.DataBind();

        ////set the total amount label using the currency format
        ////totalAmountLabel.Text = String.Format("{0:c}", cart.GetTotalAmount());
        //dr.Close();
        if (Request.Cookies["UWSPLibrary_GEN_INDEX_CartID"] != null)
        {
            //Trace.Warn("Binding Shopping Cart...");
            //populate the data grid and set its datakey field
            SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["conSQL"]);

            string strSQL = "SELECT DISTINCT GEN_NAME.GN_ID, GEN_NAME.GN_LAST_NM + ', ' + GEN_NAME.GN_FIRST_NM AS FULL_NM, " +
                "GEN_NAME.GN_RECORD_TYPE_CD, GEN_NAME.GN_COUNTY, ShoppingCart.Quantity, " +
                "(ShoppingCart.Quantity - 1) * 0.25 + 10 AS Subtotal " +
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
    //protected string GetOrderTotal()
    //{
    //    //ShoppingCart cart = new ShoppingCart();
    //    //return cart.GetTotalAmount().ToString();

    //}
    protected string GetOrderTotal()
    {
        string strSQL = "SELECT CEILING(SUM(OrderDetail.Quantity) / 5.0) * 10 AS Subtotal " +
                "FROM OrderDetail INNER JOIN GEN_NAME ON OrderDetail.GN_ID = GEN_NAME.GN_ID " +
                "WHERE (OrderDetail.OrderID = @OrderID) AND (GEN_NAME.GN_RECORD_TYPE_CD = 0)";
        SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["conSQL"]);
        SqlCommand command = new SqlCommand(strSQL, connection);
        command.Parameters.AddWithValue("OrderID", Request.Cookies["UWSPLibrary_GEN_INDEX_CartID"].Value);
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
        cmd.Parameters.AddWithValue("OrderID", Request.Cookies["UWSPLibrary_GEN_INDEX_CartID"].Value);
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

