using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using AjaxControlToolkit;
using Repository;


public partial class _Default : System.Web.UI.Page 
{
   
    ShoppingCart cart;
    public SqlConnection conSQL;
    private bool obitDateValid = false;
    IGenIndexDbRepository _repository = new GenIndexDbRepository();
     
   
    protected void Page_Load(object sender, EventArgs e)
    {
        //Session["RunningMode"] = GetMode();
        //Response.Redirect("Search.aspx",false);
        if (!Page.IsPostBack)
        {
            //Master.SetActiveTabIndex(0);
            Bind_gvSearchList();
            BindShoppingCart();
        }
        cart = new ShoppingCart();

    }

   // /// <summary>
   // /// Use to switch database connections between test and prod
   // /// NOT CURRENTLY USED becauase there is no test database for app on MS SQL 
   // /// </summary>
   // /// <returns></returns>
   //private string GetMode()
   // {
   //     var mode = "Test";
   //     try
   //     {
   //         // Determine if its a web app or a console app
   //         if (System.Web.HttpContext.Current != null)
   //         {
   //             // Web App
   //             // Determine what Mode(Test/Production) to run as

   //             var path = HttpContext.Current.Request.ServerVariables["PATH_TRANSLATED"];

   //             int last = path.LastIndexOf("\\", System.StringComparison.Ordinal);
   //             string newpath = path.Remove(last + 1, (path.Length - last - 1));
   //             mode = File.Exists(newpath + "prod.txt") ? "Prod" : "Test";
   //         }
   //     }
   //     catch (Exception e)
   //     {
   //         return "Test";
   //     }

   //     return mode;
   // }

   // #region Shopping cart functions
   // protected void BindShoppingCart()
   // {
   //     if (Request.Cookies["UWSPLibrary_GEN_INDEX_CartID"] != null)
   //     {
   //         //Trace.Warn("Binding Shopping Cart...");
   //         //populate the data grid and set its datakey field
   //         //SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["conSQL"]);

   //         //string strSQL = "SELECT DISTINCT GEN_NAME.GN_ID, GEN_NAME.GN_LAST_NM + ', ' + GEN_NAME.GN_FIRST_NM AS FULL_NM, " +
   //         //    "GEN_NAME.GN_RECORD_TYPE_CD, GEN_NAME.GN_COUNTY, 0 AS Subtotal " +
   //         //    "FROM ShoppingCart INNER JOIN GEN_NAME ON ShoppingCart.GN_ID = GEN_NAME.GN_ID " +
   //         //    "WHERE (ShoppingCart.CartID = @CartID)";//'f0fc1b79-1c29-48e9-abc2-77c282fb2a96')";
   //         //SqlCommand command = new SqlCommand(strSQL, connection);
   //         //command.Parameters.AddWithValue("CartID", Request.Cookies["UWSPLibrary_GEN_INDEX_CartID"].Value);
   //         //SqlDataAdapter adap = new SqlDataAdapter(command);
   //         //DataSet ds = new DataSet();

   //         ////open the connection, execute the command and close the connection
   //         //connection.Open();
   //         //adap.Fill(ds);
   //         //connection.Close();

   //         var ds = _repository.GetShoppingCart(Request.Cookies["UWSPLibrary_GEN_INDEX_CartID"].Value);

   //         gvCart.DataSource = ds;
   //         gvCart.DataBind();            
   //     }
   // }
    
   // protected string GetCartQuantity()
   // {
   //     //return number of items in cart
   //     ShoppingCart cart = new ShoppingCart();
   //     string strCount = cart.GetShoppingCartItemCount().ToString();
   //     return "View Cart (" + strCount + ")";
   // }
    
   // protected string GetOrderTotal()
   // {
   //     ShoppingCart cart = new ShoppingCart();
   //     return "$" + cart.GetTotalAmount().ToString();
   // }

   // protected void gvCart_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
   // {
   //     string strItemID = gvCart.DataKeys[e.RowIndex].Value.ToString();

   //     cart.RemoveProduct(strItemID);
   //     BindShoppingCart();

   // }

   // protected void btnCloseCart_OnClick(object sender, EventArgs e)
   // {
   //     Bind_gvSearchList();
   //     mpeShoppingCart.Hide();
   //     upTop.Update();
   // }
   // #endregion

   // #region Search Grid functions

    //private IEnumerable<string> GetRecordTypes()
    //{
    //    IList<string> types = new List<string>();

    //    if (cbObits.Checked) types.Add("0");
    //    if (cbCensus.Checked) types.Add("1");
    //    if (cbNatural.Checked) types.Add("2");

    //    return (types);
    //}

//    protected void Bind_gvSearchList()
//    {  
//        //if (Session["RunningMode"].ToString() == "Prod")
//        //{
//           // conSQL = new SqlConnection(ConfigurationManager.AppSettings["conSQL"]);
//        //}
//        //string strSQL = GenerateHeadSQL();


//        var ds = _repository.SearchGenIndex(txtLast.Text, txtFirst.Text, ddlCounty.SelectedValue, txtYear.Text, txtDate.Text, cbObits.Checked, cbCensus.Checked, cbNatural.Checked);


//        //SqlCommand cmd = new SqlCommand();
//        //cmd.CommandType = CommandType.StoredProcedure;
//        //cmd.CommandText = "GetFullNameList";
//        //cmd.Connection = conSQL;
//        //conSQL.Open();
//        //SqlDataAdapter adap = new SqlDataAdapter(cmd);
//        ////DataSet ds = new DataSet();
//        //adap.Fill(ds);
//        //conSQL.Close();

////        //build a Waupaca search.  They only have Naturalization records at this time.  
////        //We have to do it this way because the sql fails when there are no obits or census records in a Waupaca search
////        //Database: Lib_Geneaology_Index  Table: GEN_NAME  Column: GN_RECORD_TYPE_CD 0=Obituary, 1=Census, 2=Naturalization
////        if (ddlCounty.SelectedValue == "Waupaca")
////        {
////            strSQL = "SELECT DISTINCT TOP 1000 " +
////                      "GEN_NAME.GN_ID, (GEN_NAME.GN_LAST_NM + ', ' + GEN_NAME.GN_FIRST_NM) AS FULL_NM, " +
////                      "GEN_NAME.GN_BIRTH_YEAR_OR_AGE, GEN_NAME.GN_RECORD_TYPE_CD,  " +
////                      "GEN_NAME.GN_LOCATION, GEN_NAME.GN_DATE_OF_RECORD, GEN_NAME.GN_COUNTY, 'NONE' as N_ABBR " +
////                "FROM GEN_NAME WHERE GN_RECORD_TYPE_CD=2 AND GN_COUNTY='Waupaca' AND ";

////            if (txtLast.Text.Length > 0)
////            {
////                strSQL += "(GEN_NAME.GN_LAST_NM LIKE '%" + txtLast.Text.Replace("'", "''") + "%') AND ";
////            }
////            if (txtFirst.Text.Length > 0)
////            {
////                strSQL += "(GEN_NAME.GN_FIRST_NM LIKE '%" + txtFirst.Text.Replace("'", "''") + "%') AND ";
////            }
////            if (txtYear.Text.Length > 0)
////            {
////                strSQL += "(GEN_NAME.GN_DATE_OF_RECORD LIKE '%" + txtYear.Text + "%') AND ";
////            }
////            if (txtDate.Text.Length > 0)
////            {
////                strSQL += "(GEN_NAME.GN_DATE_OF_RECORD LIKE '%" + txtDate.Text + "%') AND ";
////            }
////            //remove extra "and "
////            if (strSQL.IndexOf("WHERE") > 0)
////            {
////                strSQL = strSQL.Substring(0, strSQL.Length - 4);
////            }
////            strSQL += " ORDER BY FULL_NM";
////            Trace.Warn("sql Waupaca Search: " + strSQL);
////            SqlCommand cmd = new SqlCommand(strSQL, conSQL);
////            SqlDataAdapter da = new SqlDataAdapter(cmd);
////            conSQL.Open();
////            da.Fill(ds);
////            conSQL.Close();
////        }
////        //build a separate query for just naturalization records so it executes faster        
////        #region Naturalization only search
////        else if (cbNatural.Checked && !cbCensus.Checked & !cbObits.Checked)
////        {
////            strSQL = "SELECT DISTINCT TOP 1000 " +
////                      "GEN_NAME.GN_ID, (GEN_NAME.GN_LAST_NM + ', ' + GEN_NAME.GN_FIRST_NM) AS FULL_NM, " +
////                      "GEN_NAME.GN_BIRTH_YEAR_OR_AGE, GEN_NAME.GN_RECORD_TYPE_CD,  " +
////                      "GEN_NAME.GN_LOCATION, GEN_NAME.GN_DATE_OF_RECORD, GEN_NAME.GN_COUNTY, 'NONE' as N_ABBR " +
////                "FROM GEN_NAME WHERE GN_RECORD_TYPE_CD=2 AND ";
         
////            if (txtLast.Text.Length > 0)
////            {
////                strSQL += "(GEN_NAME.GN_LAST_NM LIKE '%" + txtLast.Text.Replace("'", "''") + "%') AND ";
////            }
////            if (txtFirst.Text.Length > 0)
////            {
////                strSQL += "(GEN_NAME.GN_FIRST_NM LIKE '%" + txtFirst.Text.Replace("'", "''") + "%') AND ";                               
////            }
////            if (txtYear.Text.Length > 0)
////            {
////                strSQL += "(GEN_NAME.GN_DATE_OF_RECORD LIKE '%" + txtYear.Text + "%') AND ";
////            }
////            if (txtDate.Text.Length > 0)
////            {
////                strSQL += "(GEN_NAME.GN_DATE_OF_RECORD LIKE '%" + txtDate.Text + "%') AND ";
////            }
////            if (ddlCounty.SelectedValue != "All") strSQL += "GEN_NAME.GN_COUNTY = '" + ddlCounty.SelectedValue.ToString() + "' AND ";
////            //remove extra "and "
////            if (strSQL.IndexOf("WHERE") > 0)
////            {
////                strSQL = strSQL.Substring(0, strSQL.Length - 4);
////            }
////            strSQL += " ORDER BY FULL_NM";
////            Trace.Warn("sql Nat: " + strSQL);
////            SqlCommand cmd = new SqlCommand(strSQL, conSQL);
////            SqlDataAdapter da = new SqlDataAdapter(cmd);
////            conSQL.Open();
////            da.Fill(ds);
////            conSQL.Close();
////        }
////#endregion
////        else if (txtFirst.Text.Length > 0 || txtLast.Text.Length > 0 || txtYear.Text.Length > 0 ||
////            txtDate.Text.Length > 0 || ddlCounty.SelectedValue != "All" || !cbObits.Checked ||
////            !cbNatural.Checked ||!cbCensus.Checked)
////        {
////            //use search parameters
////            strSQL = "SELECT DISTINCT TOP 1000 " +
////                      "GEN_NAME.GN_ID, (GEN_NAME.GN_LAST_NM + ', ' + GEN_NAME.GN_FIRST_NM) AS FULL_NM, GEN_NAME.GN_BIRTH_YEAR_OR_AGE, GEN_NAME.GN_RECORD_TYPE_CD,  " +
////                      "GEN_NAME.GN_LOCATION, GEN_NAME.GN_DATE_OF_RECORD, OBITS_DATES.N_ABBR, GEN_NAME.GN_COUNTY " +
////                "FROM GEN_NAME LEFT OUTER JOIN " +
////                      "OBITS_ALTNAME ON GEN_NAME.GN_ID = OBITS_ALTNAME.GN_ID LEFT OUTER JOIN " +
////                      "OBITS_DATES ON GEN_NAME.GN_ID = OBITS_DATES.GN_ID " +
////                "WHERE ";

////            if (txtLast.Text.Length > 0)
////            {
////                strSQL += "(GEN_NAME.GN_LAST_NM LIKE '%" + txtLast.Text.Replace("'", "''") + "%' OR " +
////                      "OBITS_ALTNAME.OA_ALTNAME LIKE '%" + txtLast.Text.Replace("'", "''") + "%') AND ";
////            }
////            if (txtFirst.Text.Length > 0)
////            {
////                if (txtLast.Text.Length > 0)
////                {
////                    strSQL += "GEN_NAME.GN_FIRST_NM LIKE '%" + txtFirst.Text.Replace("'", "''") + "%' AND ";
////                }
////                else
////                {
////                    strSQL += "(GEN_NAME.GN_FIRST_NM LIKE '%" + txtFirst.Text.Replace("'", "''") + "%'OR " +
////                      "OBITS_ALTNAME.OA_ALTNAME LIKE '%" + txtFirst.Text.Replace("'", "''") + "%') AND ";
////                }
////            }
////            if (txtYear.Text.Length > 0)
////            {
////                strSQL += "((GEN_NAME.GN_DATE_OF_RECORD LIKE '%" + txtYear.Text + "%') OR " +
////                           "(OBITS_DATES.OD_ARTICLE_DATE LIKE '%" + txtYear.Text + "%')) AND ";
////            }
////            if (txtDate.Text.Length > 0) strSQL += "((GEN_NAME.GN_DATE_OF_RECORD LIKE '%" + txtDate.Text + "%') OR " +
////                           "(OBITS_DATES.OD_ARTICLE_DATE LIKE '%" + txtDate.Text + "%')) AND ";
////            if (ddlCounty.SelectedValue != "All") strSQL += "GEN_NAME.GN_COUNTY = '" + ddlCounty.SelectedValue.ToString() + "' AND ";
////            if (!cbObits.Checked || !cbNatural.Checked || !cbCensus.Checked)
////            {
////                //string strRecordType = "AND (";
////                string strRecordType = " (";
////                if (cbObits.Checked) strRecordType += "GEN_NAME.GN_RECORD_TYPE_CD = 0 OR ";
////                if (cbCensus.Checked) strRecordType += "GEN_NAME.GN_RECORD_TYPE_CD = 1 OR ";
////                if (cbNatural.Checked) strRecordType += "GEN_NAME.GN_RECORD_TYPE_CD = 2 OR ";
////                strSQL += strRecordType.Substring(0, strRecordType.Length - 4) + ") ";
////            }
////            //remove extra "and "
////            if (strSQL.Substring(strSQL.Length - 4, 4) == "AND ")
////            {
////                strSQL = strSQL.Substring(0, strSQL.Length - 4);
////            }
////            strSQL += "ORDER BY FULL_NM";
////            Trace.Warn("sql: " + strSQL);
////            SqlCommand cmd = new SqlCommand(strSQL, conSQL);
////            SqlDataAdapter da = new SqlDataAdapter(cmd);
////            conSQL.Open();
////            da.Fill(ds);
////            conSQL.Close();
////        }
////        else
////        {
////            SqlCommand cmd = new SqlCommand();
////            cmd.CommandType = CommandType.StoredProcedure;
////            cmd.CommandText = "GetFullNameList";
////            cmd.Connection = conSQL;
////            conSQL.Open();
////            SqlDataAdapter adap = new SqlDataAdapter(cmd);
////            //DataSet ds = new DataSet();
////            adap.Fill(ds);
////            conSQL.Close();
////        }

//        gvSearchList.DataSource = ds;
//        gvSearchList.DataBind();
//    }
        
//    protected void gvSearchList_OnRowDataBound(object sender, GridViewRowEventArgs e)
//    {
//        if (e.Row.RowType == DataControlRowType.DataRow)
//        {
//                int rowindex = e.Row.RowIndex;
//                string strCH_ID = gvSearchList.DataKeys[rowindex].Value.ToString();

//                    //we need to see if this is a Census or Naturalization record and load the appropriate gridview
//                    DataRow dr = ((DataRowView)e.Row.DataItem).Row;
//                    if (dr[3].ToString() == "1")
//                    {
//                        //string strSQL = "SELECT * FROM CENSUS_MEMBER WHERE GN_ID=" + strCH_ID;// +" ORDER BY CM_AGE desc";
//                        //SqlConnection conSQL = new SqlConnection(ConfigurationManager.AppSettings["conSQL"]);
//                        //SqlCommand cmd = new SqlCommand(strSQL, conSQL);
//                        //conSQL.Open();
//                        //SqlDataAdapter adap = new SqlDataAdapter(cmd);
//                        //DataSet ds = new DataSet();
//                        //adap.Fill(ds);
//                        //conSQL.Close();
//                        var ds = _repository.GetCensusMemberData(strCH_ID);
//                        if (ds.Tables[0].Rows.Count != 0)
//                        {
//                            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#4A4A4A'; this.style.cursor='pointer'; this.style.color='white'");
//                            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='whitesmoke'; this.style.color='#330066'");
//                            for (int i = 0; i < 8; i++)
//                            {
//                                e.Row.Cells[i].ToolTip = "Click here to see family members";
//                                e.Row.Cells[i].Attributes.Add("onclick", "javascript:CollapseExpand('" + strCH_ID + "','" + strCH_ID + "2" + "')");
//                            }
//                            GridView gv = (GridView)e.Row.FindControl("gvSearchList_Family");
//                            gv.DataSource = ds;
//                            gv.DataBind();
//                        }
//                    }
//                    else if (dr[3].ToString() == "2") //e.Row.Cells[3].Text == "2")
//                    {
//                        //load the naturalization gridview
//                        //string strSQL = "SELECT ND_COUNTRY As 'Country of Origin', ND_DATE_FILED as 'Date Filed' FROM NATURALIZATION_DATA WHERE GN_ID=" + strCH_ID;
//                        //SqlConnection conSQL = new SqlConnection(ConfigurationManager.AppSettings["conSQL"]);
//                        //SqlCommand cmd = new SqlCommand(strSQL, conSQL);
//                        //conSQL.Open();
//                        //SqlDataAdapter adap = new SqlDataAdapter(cmd);
//                        //DataSet ds = new DataSet();
//                        //adap.Fill(ds);
//                        //conSQL.Close();
//                        var ds = _repository.GetNaturaliaztionData(strCH_ID);

//                        if (ds.Tables[0].Rows.Count != 0)
//                        {
//                            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#4A4A4A'; this.style.cursor='pointer'; this.style.color='white'");
//                            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='whitesmoke'; this.style.color='#330066'");
//                            for (int i = 0; i < 8; i++)
//                            {
//                                e.Row.Cells[i].ToolTip = "Click here to see naturalization data";
//                                e.Row.Cells[i].Attributes.Add("onclick", "javascript:CollapseExpand('" + strCH_ID + "','" + strCH_ID + "2" + "')");
//                            }
//                            GridView gv = (GridView)e.Row.FindControl("gvSearchList_Nat");
//                            gv.DataSource = ds;
//                            gv.DataBind();
//                        }
//                    }
                
//        }        
//    }

//    protected void gvSearchList_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
//    {
//        gvSearchList.PageIndex = e.NewPageIndex;
//        Bind_gvSearchList();
//    }

//    //protected void gvSearchList_OnRowCommand(object sender, GridViewCommandEventArgs e)
//    protected void btnAddToOrder_OnClick(object sender, EventArgs e)
//    {
//        Button btn = (Button)sender;
//        GridViewRow row = (GridViewRow)btn.NamingContainer;
//        string strIndex = gvSearchList.DataKeys[row.RowIndex].Value.ToString();
//        if (!InOrder(strIndex))
//        {
//            cart.AddProduct(strIndex);
//        }
//        BindShoppingCart();
//        Bind_gvSearchList();
//    }

    
//    //this function gets the obits ID and newspaper and returns a concatenated string of article dates
//    protected string GetDateofRecord(int intGN_ID, int intRecord_Type, string strNews, string strDateOfRecord)
//    {
//        string strReturn = "";

//        if (intRecord_Type == 0)
//        {
//            //obituary - return dates
//            //string strSQL = "SELECT * FROM OBITS_DATES WHERE GN_ID=" + intGN_ID + " AND N_ABBR='" + strNews + "'";
//            //SqlConnection conImages = new SqlConnection(ConfigurationManager.AppSettings["conSQL"]);
//            //SqlCommand cmdImages = new SqlCommand(strSQL, conImages);
//            //conImages.Open();
//            //SqlDataReader drImages;
//            //drImages = cmdImages.ExecuteReader();

//            var ds = _repository.GetObitsDates(intGN_ID.ToString(CultureInfo.InvariantCulture), strNews);

//            if (ds.Tables[0].Rows.Count != 0)
//            {
//                var drImages = ds.Tables[0].Rows[0];

//                // while (drImages.Read())
//               // {
//                    //need to add the full text hyperlink here
//                    if (drImages["OD_WEB_ENTRY"].ToString() != "")
//                    {
//                        if (drImages["OD_WEB_ENTRY"].ToString().Trim().Length > 0)
//                        {
//                            strReturn = strReturn.Trim() + ", <a href=\"OpenFullText.aspx?id=" +
//                                        drImages["OD_ID"].ToString() + "\" target=\"_blank\">" +
//                                        drImages["OD_ARTICLE_DATE"].ToString() + "</a>";
//                        }
//                        else
//                            strReturn = strReturn.Trim() + ", " + drImages["OD_ARTICLE_DATE"].ToString();
//                    }
//                    else
//                        strReturn = strReturn.Trim() + ", " + drImages["OD_ARTICLE_DATE"].ToString();
//                //}
//            }
//            //strReturn = strNews + " " + strReturn.Substring(2);
//            strReturn = strNews + " " + (!String.IsNullOrEmpty(strReturn) ? strReturn.Substring(2) : "");           
//            //conImages.Close();
//        }
//        else 
//        {
//            // just return the date of record itself for census and naturalization records.
//            strReturn = strDateOfRecord;
//        }
        
//        return strReturn;
//    }

    
//    /// <summary>
//    /// Returns the location or source of the record
//    /// Census uses GN_LOCATION
//    /// Naturalization builds a string with index information
//    /// </summary>
//    /// <param name="intRecordType"></param>
//    /// <param name="strLocation"></param>
//    /// <returns></returns>
//    public string GetLocation(int intRecordType, string strLocation, string strRecord_ID)
//    {
//        switch (intRecordType)
//        {
//            case 1: //census 
//                return GetCensusTown(strRecord_ID) + " (" + strLocation + ")";
//            default: //naturalization record so we need to build the string
//                string strSQL = "SELECT * FROM NATURALIZATION_DATA WHERE GN_ID=" + strRecord_ID;
//                SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["conSQL"]);
//                SqlCommand cmd = new SqlCommand(strSQL, con);
//                con.Open();
//                SqlDataReader dr;
//                dr = cmd.ExecuteReader();
//                string strLoc = ""; //holds location data
//                dr.Read();
//                strLoc = "";
//                try
//                {
//                    if (dr["ND_SERIES"].ToString().Length > 0) {strLoc += " Series: " + dr["ND_SERIES"].ToString();}
//                }
//                catch {}
//                try {
//                if (dr["ND_BOX"].ToString().Length > 0){strLoc += " Box: " + dr["ND_BOX"].ToString();}
//                }
//                catch {}
//                try {
//                if (dr["ND_FOLDER"].ToString().Length > 0) {strLoc += " Folder: " + dr["ND_FOLDER"].ToString();}
//                }
//                catch {}
//                try {
//                if (dr["ND_VOL_NUM"].ToString().Length > 0) {strLoc += " Vol#: " + dr["ND_VOL_NUM"].ToString();}
//                }
//                catch {}
//                try {
//                if (dr["ND_PAGE_CERT_NUM"].ToString().Length > 0) {strLoc += " Page Cert#: " + dr["ND_PAGE_CERT_NUM"].ToString();}
//                }
//                catch {}

//                con.Close();
//                //CHECK FOR BLANKS
//                if (strLoc.Length > 0) strLoc = strLocation + " (" + strLoc.Trim() + ")";
//                else strLoc = strLocation;

//                return strLoc;                    
//        }        
//    }

//    public string GetAltNames(int intRecordType, string strGN_ID)
//    {
//        if (intRecordType == 0)
//        {
//            string strSQL = "SELECT * FROM OBITS_ALTNAME WHERE GN_ID=" + strGN_ID;
//            SqlConnection conAlts = new SqlConnection(ConfigurationManager.AppSettings["conSQL"]);
//            SqlCommand cmdAlts = new SqlCommand(strSQL, conAlts);
//            conAlts.Open();
//            SqlDataReader drAlts;
//            drAlts = cmdAlts.ExecuteReader();

//            string strAlts = "";

//            while (drAlts.Read())
//            {
//                strAlts += ", " + drAlts["OA_ALTNAME"].ToString();
//            }
//            conAlts.Close();
//            if (strAlts.Length > 0)
//                return strAlts.Substring(2);
//            else return "";
//        }

//        return "";
//    }
//    #endregion

//    public string GetRecordType(int intRecordType, string strCounty)
//    {
//        switch (intRecordType)
//        {
//            case 0: return strCounty + " Obituary";
//            case 1: return strCounty + " Census";
//            case 2: return strCounty + " Naturalization";
//            default: return "";
//        }
//    }

//    protected bool InOrder(string strGN_ID)
//    {
//        //this function will tell us if an item is already in the shopping cart
//        //ShoppingCart cart = new ShoppingCart();
//        String cartID = Request.Cookies["UWSPLibrary_GEN_INDEX_CartID"].Value;
//        //get the list of products from shopping cart
//        //'create the connection object
//        SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["conSQL"]);

//        //'create and initialize the command object
//        SqlCommand command = new SqlCommand("GetShoppingCartProductsIDs", connection);
//        command.CommandType = CommandType.StoredProcedure;

//        //'add an input parameter and supply a value for it
//        command.Parameters.Add("@CartID", SqlDbType.VarChar, 50);
//        command.Parameters["@CartID"].Value = cartID;

//        // 'open the connection, execute the command and close the connection
//        connection.Open();
			
//        SqlDataReader drID = command.ExecuteReader();
//        while (drID.Read())
//        {
//            //check each shopping cart id to see if it matches the current line 
//            if (drID["GN_ID"].ToString() == strGN_ID)
//            {
//                //there is a match so just return a true saying it was found
//                connection.Close();
//                return true;
//            }
//        }
//        connection.Close();
//        return false; //junk return to get rid of errors
//    }//	End InOrder

//    public string GetCensusTown(string strGN_ID)
//    {
//        string strSQL = "SELECT CENSUS_TOWN.CT_NAME FROM GEN_NAME INNER JOIN CENSUS_TOWN ON GEN_NAME.CT_ID = CENSUS_TOWN.CT_ID " +
//            "WHERE GN_ID=" + strGN_ID;
//        SqlConnection conSQL = new SqlConnection(ConfigurationManager.AppSettings["conSQL"]);
//        SqlCommand cmd = new SqlCommand(strSQL, conSQL);
//        conSQL.Open();
//        string strTown = Convert.ToString(cmd.ExecuteScalar());
//        conSQL.Close();

//        return strTown;                
//    }

//    protected void btnCheckoutCredit_OnClick(object sender, EventArgs e)
//    {
//        string url = "http://" + Request.Url.Host + "/Library/gen_index/CustomerInfo.aspx"; 

//        Response.Redirect(url);
//    }
//    protected void btnCheckoutPrint_OnClick(object sender, EventArgs e)
//    {
//        string url = "http://" + Request.Url.Host + "/Library/gen_index/PrintMailOrder.aspx"; 

//        Response.Redirect(url);
//    }
//    protected void btnViewCart_OnClick(object sender, EventArgs e)
//    {
//        BindShoppingCart();
//        mpeShoppingCart.Show();
//    }
    
    protected void btnSearch_OnClick(object sender, EventArgs e)
    {
        if (obitDateValid)
        {
           // string urlParams = String.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}{12}{13}{14}{15}", "?lnm=", txtLast.Text, "&fnm=", txtFirst.Text, "&cty=", ddlCounty.SelectedValue, "&odt=", txtDate.Text, "&eyr=", txtYear.Text, "&ord=", cbObits.Checked, "&crd=", cbCensus.Checked, "&nrd=", cbNatural.Checked);
           // Response.Redirect("SearchResults.aspx" + urlParams, false);
            gvSearchList.PageIndex = 0;
            Bind_gvSearchList();
            //tcPage.ActiveTabIndex = 1;
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "anchor", "location.hash = 'results';", true);
            upTop.Update();

            //gvSearchList.PageIndex = 0;
            //Bind_gvSearchList();
            //string strSQL = "SELECT DISTINCT TOP 1000 " +
            //    "GEN_NAME.GN_ID, (GEN_NAME.GN_LAST_NM + ', ' + GEN_NAME.GN_FIRST_NM) AS FULL_NM, GEN_NAME.GN_BIRTH_YEAR_OR_AGE, " +
            //    "GEN_NAME.GN_RECORD_TYPE_CD, GEN_NAME.GN_LOCATION, GEN_NAME.GN_DATE_OF_RECORD, OBITS_DATES.N_ABBR, GEN_NAME.GN_COUNTY " +
            //    "FROM GEN_NAME LEFT OUTER JOIN OBITS_DATES ON GEN_NAME.GN_ID = OBITS_DATES.GN_ID ";
            //bool anyWheres = false;
            //if (txtLast.Text.Trim().Length > 0)
            //{
            //    strSQL += "WHERE GEN_NAME.GN_LAST_NM LIKE '%" + txtLast.Text.Trim() + "%' ";
            //    anyWheres = true;
            //}
            //if (txtFirst.Text.Trim().Length > 0)
            //{
            //    if (anyWheres) strSQL += "AND GEN_NAME.GN_FIRST_NM LIKE '%" + txtFirst.Text.Trim() + "%' ";
            //    else
            //    {
            //        strSQL += "WHERE GEN_NAME.GN_FIRST_NM LIKE '%" + txtFirst.Text.Trim() + "%' ";
            //        anyWheres = true;
            //    }
            //}
            //if (ddlCounty.SelectedValue != "All")
            //{
            //    if (anyWheres) strSQL += "AND GEN_NAME.GN_COUNTY = '" + ddlCounty.SelectedValue + "' ";
            //    else
            //    {
            //        strSQL += "WHERE GEN_NAME.GN_COUNTY = '" + ddlCounty.SelectedValue + "' ";
            //        anyWheres = true;
            //    }
            //}
            //if (txtDate.Text.Trim().Length > 0)
            //{
            //    if (anyWheres) strSQL += "AND OBITS_DATES.OD_ARTICLE_DT LIKE '%" + txtDate.Text.Trim() + "%' ";
            //    else
            //    {
            //        strSQL += "WHERE OBITS_DATES.OD_ARTICLE_DT LIKE '%" + txtDate.Text.Trim() + "%' ";
            //        anyWheres = true;
            //    }
            //}
            //if (txtYear.Text.Trim().Length > 0)
            //{
            //    if (anyWheres) strSQL += "AND GEN_NAME.GN_DATE_OF_RECORD LIKE '%" + txtYear.Text.Trim() + "%' ";
            //    else
            //    {
            //        strSQL += "WHERE GEN_NAME.GN_DATE_OF_RECORD LIKE '%" + txtYear.Text.Trim() + "%' ";
            //        anyWheres = true;
            //    }
            //}
            //if (!cbCensus.Checked || !cbObits.Checked || !cbNatural.Checked)
            //{
            //    if (anyWheres) strSQL += "AND (";
            //    else strSQL += "WHERE (";

            //    if (cbCensus.Checked)
            //    {
            //        strSQL += "GEN_NAME.GN_RECORD_TYPE_CD = 1 OR ";
            //    }
            //    if (cbObits.Checked)
            //    {
            //        strSQL += "GEN_NAME.GN_RECORD_TYPE_CD = 0 OR ";
            //    }
            //    if (cbNatural.Checked)
            //    {
            //        strSQL += "GEN_NAME.GN_RECORD_TYPE_CD = 2 OR ";
            //    }
            //    strSQL = strSQL.Substring(0, strSQL.Length - 3) + ")";
            //}

            //strSQL += "ORDER BY FULL_NM";
            //SqlConnection conSQL = new SqlConnection(ConfigurationManager.AppSettings["conSQL"]);
            //SqlCommand cmd = new SqlCommand(strSQL, conSQL);
            //conSQL.Open();
            //SqlDataAdapter adap = new SqlDataAdapter(cmd);
            //DataSet ds = new DataSet();
            //adap.Fill(ds);
            //conSQL.Close();
            //Trace.Warn(strSQL);

            //gvSearchList.DataSource = ds;
            //gvSearchList.DataBind();

            //tcPage.ActiveTabIndex = 1;
            //upTop.Update();
        }
    }

    protected void btnClear_OnClick(object sender, EventArgs e)
    {
        txtLast.Text = "";
        txtFirst.Text = "";
        ddlCounty.SelectedIndex = 0;
        txtYear.Text = "";
        txtDate.Text = "";
        cbObits.Checked = true;
        cbCensus.Checked = true;
        cbNatural.Checked = true;
        //string url = "http://" + Request.Url.Host + "/Library/gen_index/default.aspx"; 

        //Response.Redirect(url);
    }   

    protected void ValidateDateObit(object source, ServerValidateEventArgs args)
    {
        DateTime minDate = DateTime.Parse("1000/12/28");
        DateTime maxDate = DateTime.Parse("9999/12/28");
        DateTime dt;

        args.IsValid = (DateTime.TryParse(args.Value, out dt)
                        && dt <= maxDate
                        && dt >= minDate) || String.IsNullOrEmpty(args.Value);

        obitDateValid = args.IsValid;

    }

    #region Shopping cart functions
    protected void BindShoppingCart()
    {
        string cartId = Request.Cookies["UWSPLibrary_GEN_INDEX_CartID"].Value.ToString(CultureInfo.InvariantCulture);
        if (cartId != null)
        {
            //populate the data grid and set its datakey field
            var ds = _repository.GetShoppingCart(cartId);

            gvCart.DataSource = ds;
            gvCart.DataBind();
        }
    }

    protected string GetCartQuantity()
    {
        //return number of items in cart
        //var cart = new ShoppingCart();     
        if (cart == null) {cart = new ShoppingCart();}
        string strCount = cart.GetShoppingCartItemCount().ToString(CultureInfo.InvariantCulture);
       return "View Cart (" + strCount + ")";
       
    }

    protected string GetOrderTotal()
    {
        //var cart = new ShoppingCart();
        return "$" + cart.GetTotalAmount().ToString(CultureInfo.InvariantCulture);
    }

    protected void gvCart_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string strItemID = gvCart.DataKeys[e.RowIndex].Value.ToString();

        cart.RemoveProduct(strItemID);
        BindShoppingCart();

    }

    protected void btnCloseCart_OnClick(object sender, EventArgs e)
    {
        Bind_gvSearchList();
        mpeShoppingCart.Hide();
        upTop.Update();
    }

    protected void btnCheckoutCredit_OnClick(object sender, EventArgs e)
    {
        string url = "http://" + Request.Url.Host + "/Library/gen_index/CustomerInfo.aspx";

        Response.Redirect(url);
    }

    protected void btnCheckoutPrint_OnClick(object sender, EventArgs e)
    {
        string url = "http://" + Request.Url.Host + "/Library/gen_index/PrintMailOrder.aspx";

        Response.Redirect(url);
    }

    protected void btnViewCart_OnClick(object sender, EventArgs e)
    {
        BindShoppingCart();
        mpeShoppingCart.Show();
    }
    #endregion

    #region Search Grid functions

    //private IEnumerable<string> GetRecordTypes()
    //{
    //    IList<string> types = new List<string>();

    //    if (cbObits.Checked) types.Add("0");
    //    if (cbCensus.Checked) types.Add("1");
    //    if (cbNatural.Checked) types.Add("2");

    //    return (types);
    //}

    protected void Bind_gvSearchList()
    {
        //if (Session["RunningMode"].ToString() == "Prod")
        //{
        // conSQL = new SqlConnection(ConfigurationManager.AppSettings["conSQL"]);
        //}
        //string strSQL = GenerateHeadSQL();


       // var ds = _repository.SearchGenIndex(_lastName, _firstName, _county, _eventYear, _obitDate, _obitRecords, _censusRecords, _naturaliznRecords);
        var ds = _repository.SearchGenIndex(txtLast.Text, txtFirst.Text, ddlCounty.SelectedValue, txtYear.Text, txtDate.Text, cbObits.Checked, cbCensus.Checked, cbNatural.Checked);


        //SqlCommand cmd = new SqlCommand();
        //cmd.CommandType = CommandType.StoredProcedure;
        //cmd.CommandText = "GetFullNameList";
        //cmd.Connection = conSQL;
        //conSQL.Open();
        //SqlDataAdapter adap = new SqlDataAdapter(cmd);
        ////DataSet ds = new DataSet();
        //adap.Fill(ds);
        //conSQL.Close();

        //        //build a Waupaca search.  They only have Naturalization records at this time.  
        //        //We have to do it this way because the sql fails when there are no obits or census records in a Waupaca search
        //        //Database: Lib_Geneaology_Index  Table: GEN_NAME  Column: GN_RECORD_TYPE_CD 0=Obituary, 1=Census, 2=Naturalization
        //        if (ddlCounty.SelectedValue == "Waupaca")
        //        {
        //            strSQL = "SELECT DISTINCT TOP 1000 " +
        //                      "GEN_NAME.GN_ID, (GEN_NAME.GN_LAST_NM + ', ' + GEN_NAME.GN_FIRST_NM) AS FULL_NM, " +
        //                      "GEN_NAME.GN_BIRTH_YEAR_OR_AGE, GEN_NAME.GN_RECORD_TYPE_CD,  " +
        //                      "GEN_NAME.GN_LOCATION, GEN_NAME.GN_DATE_OF_RECORD, GEN_NAME.GN_COUNTY, 'NONE' as N_ABBR " +
        //                "FROM GEN_NAME WHERE GN_RECORD_TYPE_CD=2 AND GN_COUNTY='Waupaca' AND ";

        //            if (txtLast.Text.Length > 0)
        //            {
        //                strSQL += "(GEN_NAME.GN_LAST_NM LIKE '%" + txtLast.Text.Replace("'", "''") + "%') AND ";
        //            }
        //            if (txtFirst.Text.Length > 0)
        //            {
        //                strSQL += "(GEN_NAME.GN_FIRST_NM LIKE '%" + txtFirst.Text.Replace("'", "''") + "%') AND ";
        //            }
        //            if (txtYear.Text.Length > 0)
        //            {
        //                strSQL += "(GEN_NAME.GN_DATE_OF_RECORD LIKE '%" + txtYear.Text + "%') AND ";
        //            }
        //            if (txtDate.Text.Length > 0)
        //            {
        //                strSQL += "(GEN_NAME.GN_DATE_OF_RECORD LIKE '%" + txtDate.Text + "%') AND ";
        //            }
        //            //remove extra "and "
        //            if (strSQL.IndexOf("WHERE") > 0)
        //            {
        //                strSQL = strSQL.Substring(0, strSQL.Length - 4);
        //            }
        //            strSQL += " ORDER BY FULL_NM";
        //            Trace.Warn("sql Waupaca Search: " + strSQL);
        //            SqlCommand cmd = new SqlCommand(strSQL, conSQL);
        //            SqlDataAdapter da = new SqlDataAdapter(cmd);
        //            conSQL.Open();
        //            da.Fill(ds);
        //            conSQL.Close();
        //        }
        //        //build a separate query for just naturalization records so it executes faster        
        //        #region Naturalization only search
        //        else if (cbNatural.Checked && !cbCensus.Checked & !cbObits.Checked)
        //        {
        //            strSQL = "SELECT DISTINCT TOP 1000 " +
        //                      "GEN_NAME.GN_ID, (GEN_NAME.GN_LAST_NM + ', ' + GEN_NAME.GN_FIRST_NM) AS FULL_NM, " +
        //                      "GEN_NAME.GN_BIRTH_YEAR_OR_AGE, GEN_NAME.GN_RECORD_TYPE_CD,  " +
        //                      "GEN_NAME.GN_LOCATION, GEN_NAME.GN_DATE_OF_RECORD, GEN_NAME.GN_COUNTY, 'NONE' as N_ABBR " +
        //                "FROM GEN_NAME WHERE GN_RECORD_TYPE_CD=2 AND ";

        //            if (txtLast.Text.Length > 0)
        //            {
        //                strSQL += "(GEN_NAME.GN_LAST_NM LIKE '%" + txtLast.Text.Replace("'", "''") + "%') AND ";
        //            }
        //            if (txtFirst.Text.Length > 0)
        //            {
        //                strSQL += "(GEN_NAME.GN_FIRST_NM LIKE '%" + txtFirst.Text.Replace("'", "''") + "%') AND ";                               
        //            }
        //            if (txtYear.Text.Length > 0)
        //            {
        //                strSQL += "(GEN_NAME.GN_DATE_OF_RECORD LIKE '%" + txtYear.Text + "%') AND ";
        //            }
        //            if (txtDate.Text.Length > 0)
        //            {
        //                strSQL += "(GEN_NAME.GN_DATE_OF_RECORD LIKE '%" + txtDate.Text + "%') AND ";
        //            }
        //            if (ddlCounty.SelectedValue != "All") strSQL += "GEN_NAME.GN_COUNTY = '" + ddlCounty.SelectedValue.ToString() + "' AND ";
        //            //remove extra "and "
        //            if (strSQL.IndexOf("WHERE") > 0)
        //            {
        //                strSQL = strSQL.Substring(0, strSQL.Length - 4);
        //            }
        //            strSQL += " ORDER BY FULL_NM";
        //            Trace.Warn("sql Nat: " + strSQL);
        //            SqlCommand cmd = new SqlCommand(strSQL, conSQL);
        //            SqlDataAdapter da = new SqlDataAdapter(cmd);
        //            conSQL.Open();
        //            da.Fill(ds);
        //            conSQL.Close();
        //        }
        //#endregion
        //        else if (txtFirst.Text.Length > 0 || txtLast.Text.Length > 0 || txtYear.Text.Length > 0 ||
        //            txtDate.Text.Length > 0 || ddlCounty.SelectedValue != "All" || !cbObits.Checked ||
        //            !cbNatural.Checked ||!cbCensus.Checked)
        //        {
        //            //use search parameters
        //            strSQL = "SELECT DISTINCT TOP 1000 " +
        //                      "GEN_NAME.GN_ID, (GEN_NAME.GN_LAST_NM + ', ' + GEN_NAME.GN_FIRST_NM) AS FULL_NM, GEN_NAME.GN_BIRTH_YEAR_OR_AGE, GEN_NAME.GN_RECORD_TYPE_CD,  " +
        //                      "GEN_NAME.GN_LOCATION, GEN_NAME.GN_DATE_OF_RECORD, OBITS_DATES.N_ABBR, GEN_NAME.GN_COUNTY " +
        //                "FROM GEN_NAME LEFT OUTER JOIN " +
        //                      "OBITS_ALTNAME ON GEN_NAME.GN_ID = OBITS_ALTNAME.GN_ID LEFT OUTER JOIN " +
        //                      "OBITS_DATES ON GEN_NAME.GN_ID = OBITS_DATES.GN_ID " +
        //                "WHERE ";

        //            if (txtLast.Text.Length > 0)
        //            {
        //                strSQL += "(GEN_NAME.GN_LAST_NM LIKE '%" + txtLast.Text.Replace("'", "''") + "%' OR " +
        //                      "OBITS_ALTNAME.OA_ALTNAME LIKE '%" + txtLast.Text.Replace("'", "''") + "%') AND ";
        //            }
        //            if (txtFirst.Text.Length > 0)
        //            {
        //                if (txtLast.Text.Length > 0)
        //                {
        //                    strSQL += "GEN_NAME.GN_FIRST_NM LIKE '%" + txtFirst.Text.Replace("'", "''") + "%' AND ";
        //                }
        //                else
        //                {
        //                    strSQL += "(GEN_NAME.GN_FIRST_NM LIKE '%" + txtFirst.Text.Replace("'", "''") + "%'OR " +
        //                      "OBITS_ALTNAME.OA_ALTNAME LIKE '%" + txtFirst.Text.Replace("'", "''") + "%') AND ";
        //                }
        //            }
        //            if (txtYear.Text.Length > 0)
        //            {
        //                strSQL += "((GEN_NAME.GN_DATE_OF_RECORD LIKE '%" + txtYear.Text + "%') OR " +
        //                           "(OBITS_DATES.OD_ARTICLE_DATE LIKE '%" + txtYear.Text + "%')) AND ";
        //            }
        //            if (txtDate.Text.Length > 0) strSQL += "((GEN_NAME.GN_DATE_OF_RECORD LIKE '%" + txtDate.Text + "%') OR " +
        //                           "(OBITS_DATES.OD_ARTICLE_DATE LIKE '%" + txtDate.Text + "%')) AND ";
        //            if (ddlCounty.SelectedValue != "All") strSQL += "GEN_NAME.GN_COUNTY = '" + ddlCounty.SelectedValue.ToString() + "' AND ";
        //            if (!cbObits.Checked || !cbNatural.Checked || !cbCensus.Checked)
        //            {
        //                //string strRecordType = "AND (";
        //                string strRecordType = " (";
        //                if (cbObits.Checked) strRecordType += "GEN_NAME.GN_RECORD_TYPE_CD = 0 OR ";
        //                if (cbCensus.Checked) strRecordType += "GEN_NAME.GN_RECORD_TYPE_CD = 1 OR ";
        //                if (cbNatural.Checked) strRecordType += "GEN_NAME.GN_RECORD_TYPE_CD = 2 OR ";
        //                strSQL += strRecordType.Substring(0, strRecordType.Length - 4) + ") ";
        //            }
        //            //remove extra "and "
        //            if (strSQL.Substring(strSQL.Length - 4, 4) == "AND ")
        //            {
        //                strSQL = strSQL.Substring(0, strSQL.Length - 4);
        //            }
        //            strSQL += "ORDER BY FULL_NM";
        //            Trace.Warn("sql: " + strSQL);
        //            SqlCommand cmd = new SqlCommand(strSQL, conSQL);
        //            SqlDataAdapter da = new SqlDataAdapter(cmd);
        //            conSQL.Open();
        //            da.Fill(ds);
        //            conSQL.Close();
        //        }
        //        else
        //        {
        //            SqlCommand cmd = new SqlCommand();
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.CommandText = "GetFullNameList";
        //            cmd.Connection = conSQL;
        //            conSQL.Open();
        //            SqlDataAdapter adap = new SqlDataAdapter(cmd);
        //            //DataSet ds = new DataSet();
        //            adap.Fill(ds);
        //            conSQL.Close();
        //        }

        gvSearchList.DataSource = ds;
        gvSearchList.DataBind();

        //tcPage.ActiveTabIndex = 0;
        //Page.ClientScript.RegisterStartupScript(this.GetType(), "anchor", "location.hash = 'search';", true);
    }

    protected void gvSearchList_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int rowindex = e.Row.RowIndex;
            string strCH_ID = gvSearchList.DataKeys[rowindex].Value.ToString();

            //we need to see if this is a Census or Naturalization record and load the appropriate gridview
            DataRow dr = ((DataRowView)e.Row.DataItem).Row;
            if (dr[3].ToString() == "1")
            {
                //string strSQL = "SELECT * FROM CENSUS_MEMBER WHERE GN_ID=" + strCH_ID;// +" ORDER BY CM_AGE desc";
                //SqlConnection conSQL = new SqlConnection(ConfigurationManager.AppSettings["conSQL"]);
                //SqlCommand cmd = new SqlCommand(strSQL, conSQL);
                //conSQL.Open();
                //SqlDataAdapter adap = new SqlDataAdapter(cmd);
                //DataSet ds = new DataSet();
                //adap.Fill(ds);
                //conSQL.Close();
                var ds = _repository.GetCensusMemberData(strCH_ID);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#4A4A4A'; this.style.cursor='pointer'; this.style.color='white'");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='whitesmoke'; this.style.color='#330066'");
                    for (int i = 0; i < 8; i++)
                    {
                        e.Row.Cells[i].ToolTip = "Click here to see family members";
                        e.Row.Cells[i].Attributes.Add("onclick", "javascript:CollapseExpand('" + strCH_ID + "','" + strCH_ID + "2" + "')");
                    }
                    GridView gv = (GridView)e.Row.FindControl("gvSearchList_Family");
                    gv.DataSource = ds;
                    gv.DataBind();
                }
            }
            else if (dr[3].ToString() == "2") //e.Row.Cells[3].Text == "2")
            {
                //load the naturalization gridview
                //string strSQL = "SELECT ND_COUNTRY As 'Country of Origin', ND_DATE_FILED as 'Date Filed' FROM NATURALIZATION_DATA WHERE GN_ID=" + strCH_ID;
                //SqlConnection conSQL = new SqlConnection(ConfigurationManager.AppSettings["conSQL"]);
                //SqlCommand cmd = new SqlCommand(strSQL, conSQL);
                //conSQL.Open();
                //SqlDataAdapter adap = new SqlDataAdapter(cmd);
                //DataSet ds = new DataSet();
                //adap.Fill(ds);
                //conSQL.Close();
                var ds = _repository.GetNaturaliaztionData(strCH_ID);

                if (ds.Tables[0].Rows.Count != 0)
                {
                    e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#4A4A4A'; this.style.cursor='pointer'; this.style.color='white'");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='whitesmoke'; this.style.color='#330066'");
                    for (int i = 0; i < 8; i++)
                    {
                        e.Row.Cells[i].ToolTip = "Click here to see naturalization data";
                        e.Row.Cells[i].Attributes.Add("onclick", "javascript:CollapseExpand('" + strCH_ID + "','" + strCH_ID + "2" + "')");
                    }
                    GridView gv = (GridView)e.Row.FindControl("gvSearchList_Nat");
                    gv.DataSource = ds;
                    gv.DataBind();
                }
            }

        }
    }

    protected void gvSearchList_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvSearchList.PageIndex = e.NewPageIndex;
        Bind_gvSearchList();
    }

    //protected void gvSearchList_OnRowCommand(object sender, GridViewCommandEventArgs e)
    protected void btnAddToOrder_OnClick(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        GridViewRow row = (GridViewRow)btn.NamingContainer;
        string strIndex = gvSearchList.DataKeys[row.RowIndex].Value.ToString();
        if (!InOrder(strIndex))
        {
            cart.AddProduct(strIndex);
        }
        BindShoppingCart();
        Bind_gvSearchList();
    }


    //this function gets the obits ID and newspaper and returns a concatenated string of article dates
    protected string GetDateofRecord(int intGN_ID, int intRecord_Type, string strNews, string strDateOfRecord)
    {
        string strReturn = "";

        if (intRecord_Type == 0)
        {
            //obituary - return dates
            //string strSQL = "SELECT * FROM OBITS_DATES WHERE GN_ID=" + intGN_ID + " AND N_ABBR='" + strNews + "'";
            //SqlConnection conImages = new SqlConnection(ConfigurationManager.AppSettings["conSQL"]);
            //SqlCommand cmdImages = new SqlCommand(strSQL, conImages);
            //conImages.Open();
            //SqlDataReader drImages;
            //drImages = cmdImages.ExecuteReader();

            var ds = _repository.GetObitsDates(intGN_ID.ToString(CultureInfo.InvariantCulture), strNews);

            if (ds.Tables[0].Rows.Count != 0)
            {
                var drImages = ds.Tables[0].Rows[0];

                // while (drImages.Read())
                // {
                //need to add the full text hyperlink here
                if (drImages["OD_WEB_ENTRY"].ToString() != "")
                {
                    if (drImages["OD_WEB_ENTRY"].ToString().Trim().Length > 0)
                    {
                        strReturn = strReturn.Trim() + ", <a href=\"OpenFullText.aspx?id=" +
                                    drImages["OD_ID"].ToString() + "\" target=\"_blank\">" +
                                    drImages["OD_ARTICLE_DATE"].ToString() + "</a>";
                    }
                    else
                        strReturn = strReturn.Trim() + ", " + drImages["OD_ARTICLE_DATE"].ToString();
                }
                else
                    strReturn = strReturn.Trim() + ", " + drImages["OD_ARTICLE_DATE"].ToString();
                //}
            }
            //strReturn = strNews + " " + strReturn.Substring(2);
            strReturn = strNews + " " + (!String.IsNullOrEmpty(strReturn) ? strReturn.Substring(2) : "");
            //conImages.Close();
        }
        else
        {
            // just return the date of record itself for census and naturalization records.
            strReturn = strDateOfRecord;
        }

        return strReturn;
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
            case 2: //naturalization record so we need to build the string
                // default: //naturalization record so we need to build the string
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
                    if (dr["ND_SERIES"].ToString().Length > 0) { strLoc += " Series: " + dr["ND_SERIES"].ToString(); }
                }
                catch { }
                try
                {
                    if (dr["ND_BOX"].ToString().Length > 0) { strLoc += " Box: " + dr["ND_BOX"].ToString(); }
                }
                catch { }
                try
                {
                    if (dr["ND_FOLDER"].ToString().Length > 0) { strLoc += " Folder: " + dr["ND_FOLDER"].ToString(); }
                }
                catch { }
                try
                {
                    if (dr["ND_VOL_NUM"].ToString().Length > 0) { strLoc += " Vol#: " + dr["ND_VOL_NUM"].ToString(); }
                }
                catch { }
                try
                {
                    if (dr["ND_PAGE_CERT_NUM"].ToString().Length > 0) { strLoc += " Page Cert#: " + dr["ND_PAGE_CERT_NUM"].ToString(); }
                }
                catch { }

                con.Close();
                //CHECK FOR BLANKS
                if (strLoc.Length > 0) strLoc = strLocation + " (" + strLoc.Trim() + ")";
                else strLoc = strLocation;

                return strLoc;
            default:
                return "";
        }
    }

    public string GetAltNames(int intRecordType, string strGN_ID)
    {
        if (intRecordType == 0)
        {
            string strSQL = "SELECT * FROM OBITS_ALTNAME WHERE GN_ID=" + strGN_ID;
            SqlConnection conAlts = new SqlConnection(ConfigurationManager.AppSettings["conSQL"]);
            SqlCommand cmdAlts = new SqlCommand(strSQL, conAlts);
            conAlts.Open();
            SqlDataReader drAlts;
            drAlts = cmdAlts.ExecuteReader();

            string strAlts = "";

            while (drAlts.Read())
            {
                strAlts += ", " + drAlts["OA_ALTNAME"].ToString();
            }
            conAlts.Close();
            if (strAlts.Length > 0)
                return strAlts.Substring(2);
            else return "";
        }

        return "";
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

    protected bool InOrder(string strGN_ID)
    {
        //this function will tell us if an item is already in the shopping cart
        //ShoppingCart cart = new ShoppingCart();
        String cartID = Request.Cookies["UWSPLibrary_GEN_INDEX_CartID"].Value;
        //get the list of products from shopping cart
        //'create the connection object
        SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["conSQL"]);

        //'create and initialize the command object
        SqlCommand command = new SqlCommand("GetShoppingCartProductsIDs", connection);
        command.CommandType = CommandType.StoredProcedure;

        //'add an input parameter and supply a value for it
        command.Parameters.Add("@CartID", SqlDbType.VarChar, 50);
        command.Parameters["@CartID"].Value = cartID;

        // 'open the connection, execute the command and close the connection
        connection.Open();

        SqlDataReader drID = command.ExecuteReader();
        while (drID.Read())
        {
            //check each shopping cart id to see if it matches the current line 
            if (drID["GN_ID"].ToString() == strGN_ID)
            {
                //there is a match so just return a true saying it was found
                connection.Close();
                return true;
            }
        }
        connection.Close();
        return false; //junk return to get rid of errors
    }//	End InOrder

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

    #endregion

   // protected void tcPage_OnActiveTabChanged(object sender, EventArgs e)
   // {
       // TabContainer container = sender as TabContainer;
      //  if (container != null) Master.SetActiveTabIndex(container.ActiveTabIndex); // Update the ActiveTabIndex property
      //  Master.AddHistoryPoint("ActiveTabIndex", Master.GetActiveTabIndex()); 
        //if (container != null)
        //    switch (container.ActiveTabIndex)
        //    {
        //        case 0:
        //            Page.ClientScript.RegisterStartupScript(
        //                this.GetType(), "anchor", "location.hash = '#search';", true);
        //            break;
        //        case 1:
        //            Page.ClientScript.RegisterStartupScript(
        //                this.GetType(), "anchor", "location.hash = '#results';", true);
        //            break;
        //    }
   // }


}
