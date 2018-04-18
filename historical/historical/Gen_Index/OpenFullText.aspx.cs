using System;
//using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class OpenFullText : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["ID"] != null)
        {
            //get the full web text
            string strSQL = "Select OD_WEB_ENTRY from OBITS_DATES where OD_ID=@OD_ID";
            SqlConnection conObits = new SqlConnection(ConfigurationManager.AppSettings["conSQL"]);
            SqlCommand cmdObits = new SqlCommand(strSQL, conObits);
            cmdObits.Parameters.Add("OD_ID", Request.QueryString["ID"].ToString());
            conObits.Open();
            string strHTML = "";
            strHTML = Convert.ToString(cmdObits.ExecuteScalar());

            Response.Write(strHTML);
            //'Trace.Warn("test: " & strHTML)
            conObits.Dispose();
            conObits.Close();
        }
        else
        {
            string url = "http://" + Request.Url.Host + "/Library/gen_index/Default.aspx"; 

            Response.Redirect(url);
        }
    }
}
