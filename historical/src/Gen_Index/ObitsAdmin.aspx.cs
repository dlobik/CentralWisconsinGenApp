using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Caching;
using System.Configuration;
using System.Reflection;

public partial class ObitsAdmin : System.Web.UI.Page
{
    SqlConnection conSQL;

    protected void Page_Load(object sender, EventArgs e)
    {
        //Trace.IsEnabled = true;
        //Trace.Warn("Namespace: " + Page.GetType().BaseType.ToString());
 
        //set the newspaper from the cookie
        HttpCookie cookie = new HttpCookie("UWSP_OBITS_NEWSPAPER");
        cookie = Request.Cookies["UWSP_OBITS_NEWSPAPER"];
        if (cookie != null)
            ddlNews.SelectedItem.Text = cookie.Value;

        conSQL = new SqlConnection(ConfigurationSettings.AppSettings["conSQL"]);
    }

    
   public DataTable LoadFullNameInDropDownList(string strSQL)
   {
       //SqlConnection objConn = new SqlConnection(ConfigurationSettings.AppSettings["conSQL"]);
       DataTable tblCategory = new DataTable();

       try
       {
           conSQL.Open();
           //Using helps to dispose object as soon as 
           //required process gets complete
           using (SqlDataAdapter objAdpOnCat = new SqlDataAdapter(strSQL, conSQL))
           {  
               objAdpOnCat.Fill(tblCategory);                       
           }
       }
       catch(SqlException e)
       {
           throw new Exception("Invalid Connection Error Occured  "+e.Message);   
       }
       finally
       {
           if (conSQL.State.ToString() == "Open")
           {
               conSQL.Dispose();
               conSQL.Close();                       
           }
       }
       return tblCategory;
   }//end LoadFullNameInDropDownList

   protected void btnLoadName_Click(object sender, EventArgs e)
   {
       BindAltName();
       BindArticles();
   }

   protected void btnNewName_Click(object sender, EventArgs e)
   {
       try
       {
           string strLast = txtNewRealname.Text.Substring(0, txtNewRealname.Text.IndexOf(","));
           string strFirst = txtNewRealname.Text.Substring(txtNewRealname.Text.IndexOf(",")+1).Trim();
           string strSQL = "INSERT INTO GEN_NAME(GN_LAST_NM, GN_FIRST_NM, GN_RECORD_TYPE_CD, GN_COUNTY) VALUES (" +
               "@Last_NM, @First_NM, 0, 'Portage')";

           SqlCommand cmd = new SqlCommand(strSQL, conSQL);
           cmd.Parameters.Add("Last_NM", strLast);
           cmd.Parameters.Add("First_NM", strFirst);
           conSQL.Open();
           cmd.ExecuteNonQuery();
           conSQL.Close();

           txtNewRealname.Text = "New Name Entered";
       }
       catch (Exception exc)
       {
           txtNewRealname.Text = "Error in name format.  Use \"Doe, John A.\"";
       }
   }
         

    #region Alternate Name Gridview Functions
    protected void BindAltName()
   {
       //get the altnames based on the ID next to Fullname
       int last = txtNameList.Text.LastIndexOf("(");
       int last2 = txtNameList.Text.LastIndexOf(")");
       string strSQL = "SELECT * FROM OBITS_ALTNAME WHERE GN_ID=@GN_ID order by OA_ALTNAME";

       SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["conSQL"]);
       SqlCommand cmd = new SqlCommand(strSQL, con);
       cmd.Parameters.Add("GN_ID", txtNameList.Text.Substring(txtNameList.Text.LastIndexOf("(") + 1,
           (txtNameList.Text.LastIndexOf(")")) - (txtNameList.Text.LastIndexOf("(")) - 1));
       SqlDataAdapter da = new SqlDataAdapter(cmd);
       DataSet ds = new DataSet();
       con.Open();
       da.Fill(ds);

       gvAltName.DataSource = ds;
       gvAltName.DataBind();

       con.Dispose();
       con.Close();
   }
    protected void gvAltName_OnRowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow row = gvAltName.Rows[e.RowIndex];
        string strOA_ID = gvAltName.DataKeys[e.RowIndex].Value.ToString();
        string strName = ((TextBox)(row.Cells[1].Controls[0])).Text;

        string strSQL = "UPDATE OBITS_ALTNAME SET OA_ALTNAME=@strName " +
            "WHERE OA_ID=@strOA_ID";
        SqlCommand cmd = new SqlCommand(strSQL, conSQL);
        cmd.Parameters.Add("strName", strName);
        cmd.Parameters.Add("strOA_ID", strOA_ID);
        conSQL.Open();
        cmd.ExecuteNonQuery();
        conSQL.Close();

        gvAltName.EditIndex = -1;
        BindAltName();
    }    
    protected void gvAltName_OnRowEditing(object sender, GridViewEditEventArgs e) 
    {
        gvAltName.EditIndex = e.NewEditIndex;
        BindAltName();
    } 
    protected void gvAltName_OnRowDeleting(object sender, GridViewDeleteEventArgs e) 
    {
        GridViewRow row = gvAltName.Rows[e.RowIndex];
        string strOA_ID = gvAltName.DataKeys[e.RowIndex].Value.ToString();
        string strSQL = "DELETE FROM OBITS_ALTNAME WHERE OA_ID=" + strOA_ID;
        SqlCommand cmd = new SqlCommand(strSQL, conSQL);
        conSQL.Open();
        cmd.ExecuteNonQuery();
        conSQL.Close();

        BindAltName();
    }
    protected void gvAltName_OnRowCancelingEdit(object sender, GridViewCancelEditEventArgs e) 
    {
        gvAltName.EditIndex = -1;
        BindAltName();
    }

    protected void btnNewAltname_Click(object sender, EventArgs e)
    {
        //enter the new alternate name
        lblSuccess.Visible = false;
        if (txtNewAltName.Text.Trim() == "")
        {
            //no new altname in box so ignore the click
            return;
        }

        //something is in the box so lets add it to altname database
        string strGN_ID = txtNameList.Text.Substring(txtNameList.Text.LastIndexOf("(") + 1,
                (txtNameList.Text.LastIndexOf(")")) - (txtNameList.Text.LastIndexOf("(")) - 1);
        string strSQL = "INSERT INTO OBITS_ALTNAME(GN_ID, OA_ALTNAME) VALUES (@GN_ID, @NewAlt)";
        SqlCommand cmd = new SqlCommand(strSQL, conSQL);
        cmd.Parameters.Add("GN_ID", strGN_ID);
        cmd.Parameters.Add("NewAlt", txtNewAltName.Text.Trim().Replace("'", "''"));
        conSQL.Open();
        cmd.ExecuteNonQuery();
        conSQL.Close();

        txtNewAltName.Text = "";

        BindAltName();
    }
    #endregion

    #region Articles Gridview Functions
    protected void BindArticles() 
    {
        string strSQL = "SELECT * FROM OBITS_DATES WHERE GN_ID=" + 
            txtNameList.Text.Substring(txtNameList.Text.LastIndexOf("(") + 1,
                (txtNameList.Text.LastIndexOf(")")) - (txtNameList.Text.LastIndexOf("(")) - 1) + " order by OD_ARTICLE_DATE";
        SqlCommand cmd = new SqlCommand(strSQL, conSQL);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        conSQL.Open();
        da.Fill(ds);

        gvArticles.DataSource = ds;
        gvArticles.DataBind();

        conSQL.Close();           
    }
    protected void gvArticles_OnRowEditing(object sender, GridViewEditEventArgs e) 
    {
        gvArticles.EditIndex = e.NewEditIndex;
        BindArticles();
    } 
	protected void gvArticles_OnRowDeleting(object sender, GridViewDeleteEventArgs e) 
    {
        GridViewRow row = gvArticles.Rows[e.RowIndex];
        string strOA_ID = gvArticles.DataKeys[e.RowIndex].Value.ToString();
        string strSQL = "DELETE FROM OBITS_DATES WHERE OD_ID=" + strOA_ID;        
        SqlCommand cmd = new SqlCommand(strSQL, conSQL);
        conSQL.Open();
        cmd.ExecuteNonQuery();
        conSQL.Close();

        BindArticles();
    }
    protected void gvArticles_OnRowCancelingEdit(object sender, GridViewCancelEditEventArgs e) 
    {
        gvArticles.EditIndex = -1;
        BindArticles();
    }
    protected void gvArticles_OnRowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow row = gvArticles.Rows[e.RowIndex];
        string strOD_ID = gvArticles.DataKeys[e.RowIndex].Value.ToString();
        string strNews = ((TextBox)(row.Cells[1].Controls[0])).Text.Trim();
        string strDate = ((TextBox)(row.Cells[2].Controls[0])).Text.Trim();

        string strSQL = "UPDATE OBITS_DATES SET OD_ARTICLE_DATE=@strDate, N_ABBR=@strNews " +
            "WHERE OD_ID=@strOD_ID";
        SqlCommand cmd = new SqlCommand(strSQL, conSQL);
        cmd.Parameters.Add("strOD_ID", strOD_ID);
        cmd.Parameters.Add("strDate", strDate);
        cmd.Parameters.Add("strNews", strNews);
        conSQL.Open();
        cmd.ExecuteNonQuery();
        conSQL.Close();

        gvArticles.EditIndex = -1;
        BindArticles();

    }
    protected void btnNewArticleDate_Click(object sender, EventArgs e)
    {
        if (txtNewDate.Text.Trim() == "")
        {
            return;
        }
        string strGN_ID = txtNameList.Text.Substring(txtNameList.Text.LastIndexOf("(") + 1,
                (txtNameList.Text.LastIndexOf(")")) - (txtNameList.Text.LastIndexOf("(")) - 1);
        string strSQL = "INSERT INTO OBITS_DATES (GN_ID, N_ABBR, OD_ARTICLE_DATE, OD_WEB_ENTRY) VALUES (" +
            "@strGN_ID, @News, @NewDate, @NewWeb)";
        SqlCommand cmd = new SqlCommand(strSQL, conSQL);
        cmd.Parameters.Add("strGN_ID", strGN_ID);
        cmd.Parameters.Add("News", ddlNews.SelectedValue);
        cmd.Parameters.Add("NewDate", txtNewDate.Text.Trim());
        cmd.Parameters.Add("NewWeb", txtNewWeb.Text.Trim());
        conSQL.Open();
        cmd.ExecuteNonQuery();
        conSQL.Close();

        txtNewWeb.Text = txtNewDate.Text = "";

        BindArticles();
    }
   
    #endregion

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public string[] GetCompletionList(string prefixText, int count)
    {
        //Trace.Warn("GetCompleteList");
        return default(string[]);
    }

    //[System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    //public static string[] GetProducts(string prefixText, int count)
    //{  
    //    return default(string[]);  
    //}  

}
