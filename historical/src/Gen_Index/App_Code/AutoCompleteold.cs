using System;
using System.Collections;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
 

/// <summary>
/// Summary description for AutoComplete
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class AutoCompleteold : System.Web.Services.WebService {

    public AutoCompleteold () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    private SqlConnection Connection
    {
        get
        {
            SqlConnection cn = new SqlConnection();

            cn.ConnectionString = ConfigurationManager.AppSettings["conSQL"];
            cn.Open();
            return cn;
        }
    }
    [WebMethod] public string[] GetProducts22(string prefixText, int count)
    {
        string strSQL = "SELECT (GN_LAST_NM + ', ' + GN_FIRST_NM) + '(' + GN_ID + ')' AS FULL_NAME " +
            "FROM GEN_NAME " +
            "WHERE GN_RECORD_TYPE_CD = 0 AND (GN_LAST_NM + ', ' + GN_FIRST_NM LIKE '" + prefixText + "%') " +
            "ORDER BY FULL_NAME";
        ArrayList arrResults = new ArrayList();
        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conSQL"]);
        try
        {
            SqlCommand cmd = new SqlCommand(strSQL, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            conn.Open();
            da.Fill(ds);
            conn.Close();

            int Counter = 0;
            //        while (dr.Read())
            //        {
            //            if (Counter == count) break;
            //            arrResults.Add(dr["FULL_NAME"].ToString() + " (" + dr["GN_ID"].ToString() + ")");
            //            Counter += 1;
            //        }

            string[] strResultsArray = new string[ds.Tables[0].Rows.Count];
            foreach (DataRow dr in ds.Tables)
            {
                strResultsArray[Counter] = dr[0].ToString();
            }
            //strResultsArray = (string[])arrResults.ToArray(typeof(string));
            //conn.Close();
            return strResultsArray;
        }
        catch (Exception ex)
        {

            throw ex;
        }
        
    }//end GetProducts
    
    [WebMethod] public string[] GetCompletionList(string prefixText, int count)
    {
        string strSQL = "SELECT GN_ID, (GN_LAST_NM + ', ' + GN_FIRST_NM) AS FULL_NAME FROM GEN_NAME " +
            "WHERE GN_RECORD_TYPE_CD = 0 AND (GN_LAST_NM + ', ' + GN_FIRST_NM LIKE '" + prefixText + "%') ORDER BY FULL_NAME";
        ArrayList arrResults = new ArrayList();
        //SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conSQL"]);
        try
        {
            using (SqlCommand cmd = new SqlCommand(strSQL, Connection))
            {
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    //conn.Open();
                    //dr = cmd.ExecuteReader();
                    int Counter = 0;
                    while (dr.Read())
                    {
                        if (Counter == count) break;
                        arrResults.Add(dr["FULL_NAME"].ToString() + " (" + dr["GN_ID"].ToString() + ")");
                        Counter += 1;
                    }
                }
                string[] strResultsArray = new string[arrResults.Count - 1];
                strResultsArray = (string[])arrResults.ToArray(typeof(string));
                //conn.Close();
                return strResultsArray;
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }

    }//end GetProducts
}

