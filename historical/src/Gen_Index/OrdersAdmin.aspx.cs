using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class OrdersAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnMostRecent_OnClick(object sender, EventArgs e)
    {
        OrderManager om = new OrderManager();
        int recordCount;

        recordCount = Int32.Parse(recordCountTextBox.Text);

        dgOrders.DataSource = om.GetMostRecentOrders(recordCount);
        dgOrders.DataKeyField = "OrderID";
        dgOrders.DataBind();
    }
    protected void btnLogout_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        Response.Redirect("census.aspx");
    }
    //this is the view details button click event
    protected void dgOrders_SelectedIndexChanged(Object sender, EventArgs e)
    {
        string orderID;
        orderID = dgOrders.DataKeys[dgOrders.SelectedIndex].ToString();
        Response.Write("<script language=javascript>window.open('OrderDetails.aspx?OrderID=" + orderID + "','_new')</script>");
    }
    protected void btnBetweenDates_OnClick(object sender, EventArgs e)
    {
        OrderManager om = new OrderManager();
        string startDate;
        string endDate;
        try
        {
            startDate = txtStartDate.Text;
            endDate = txtEndDate.Text;
            dgOrders.DataSource = om.GetOrdersBetweenDates(startDate, endDate);
            dgOrders.DataKeyField = "OrderID";
            dgOrders.DataBind();
        }
        catch (Exception exc)
        {
            lblError.Text = "Could not get the requested data!";
        }
    }
    protected void btnVerifiedOrders_OnClick(object sender, EventArgs e)
    {
        try
        {
            string strSQL = "SELECT O.OrderID, O.DateCreated, O.DateShipped, O.Verified, O.Completed, O.Canceled, O.Comments, " +
                "O.TransID, C.LastName + ', ' + C.FirstName AS CUSTOMERNAME " +
                "FROM Orders AS O INNER JOIN CustomerInfo AS C ON O.OrderID = C.OrderID " +
                "WHERE (O.Verified = '1') AND (O.Completed = '0' OR O.Completed = 'N') " +
                "ORDER BY O.DateCreated DESC";
            SqlConnection conSQL = new SqlConnection(ConfigurationManager.AppSettings["conSQL"]);
            SqlCommand cmd = new SqlCommand(strSQL, conSQL);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            conSQL.Open();
            da.Fill(ds);
            conSQL.Close();
            dgOrders.DataSource = ds;
            dgOrders.DataKeyField = "OrderID";
            dgOrders.DataBind();
        }
        catch (Exception exc)
        {
            lblError.Text = "ERROR: " + exc.Message;
        }
        //OrderManager om = new OrderManager();
        //try
        //{
        //    dgOrders.DataSource = om.GetVerifiedUncompletedOrders();
        //    dgOrders.DataKeyField = "OrderID";
        //    dgOrders.DataBind();
        //}
        //catch (Exception exc)
        //{
        //    lblError.Text = "Could not get the requested data!";
        //}
    }
    protected void btnCust_OnClick(object sender, EventArgs e)
    {
        //find the customer name and orders
        OrderManager om = new OrderManager();
        try
        {
            dgOrders.DataSource = om.GetCustomerOrders(txtCust.Text.Trim());
            dgOrders.DataKeyField = "OrderID";
            dgOrders.DataBind();
        }
        catch (Exception exc)
        {
            lblError.Text = "Could not get the requested data!";
        }
    }
}
