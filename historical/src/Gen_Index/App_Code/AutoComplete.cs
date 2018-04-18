// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Public License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.


using System;
using System.Collections.Generic;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Extensions;

//[WebService(Namespace = "http://tempuri.org/")]
[WebService(Namespace = "http://mypoint.uwsp.edu/library/gen_index")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService]
public class AutoComplete : WebService
{
    public AutoComplete()
    {
    }

    [WebMethod]
    public string[] GetCompletionList(string prefixText, int count)
    {
        if (count == 0)
        {
            count = 10;
        }

        if (prefixText.Equals("xyz"))
        {
            return new string[0];
        }

        //Random random = new Random();
        //List<string> items = new List<string>(count);
        //for (int i = 0; i < count; i++)
        //{
        //    char c1 = (char)random.Next(65, 90);
        //    char c2 = (char)random.Next(97, 122);
        //    char c3 = (char)random.Next(97, 122);

        //    items.Add(prefixText + c1 + c2 + c3);
        //}
        //return items.ToArray();

        //string strSQL = "SELECT GN_ID, (GN_LAST_NM + ', ' + GN_FIRST_NM) AS FULL_NAME FROM GEN_NAME " +
        //    "WHERE GN_RECORD_TYPE_CD = 0 AND (GN_LAST_NM + ', ' + GN_FIRST_NM LIKE '" + prefixText + "%') ORDER BY FULL_NAME";
        //string strSQL = "SELECT TOP " + count + " GN_ID, (GN_LAST_NM + ', ' + GN_FIRST_NM) AS FULL_NAME FROM GEN_NAME " +
        //            "WHERE GN_RECORD_TYPE_CD = 0 AND (GN_LAST_NM + ', ' + GN_FIRST_NM LIKE '" + prefixText + "%') ORDER BY FULL_NAME";
        //string strSQL = "SELECT TOP 22 " +
        //    " (GN_LAST_NM + ', ' + GN_FIRST_NM + ' (' + rtrim(CONVERT(char, GN_ID)) + ')') AS FULL_NAME " +
        //    "FROM GEN_NAME " +
        //    "WHERE GN_RECORD_TYPE_CD = 0 AND (GN_LAST_NM + ', ' + GN_FIRST_NM LIKE '" + prefixText + "%') " +
        //    "ORDER BY FULL_NAME";
        string strSQL = "SELECT TOP 22 " +
                    " (GN_LAST_NM + ', ' + GN_FIRST_NM + ' (' + rtrim(CONVERT(char, GN_ID)) + ')') AS FULL_NAME " +
                    "FROM GEN_NAME " +
                    "WHERE GN_RECORD_TYPE_CD = 0 AND (GN_LAST_NM + ', ' + GN_FIRST_NM LIKE @paraPrefix) " +
                    "ORDER BY FULL_NAME";

        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conSQL"]);
        SqlCommand cmd = new SqlCommand(strSQL, conn);
        cmd.Parameters.Add("@paraPrefix", prefixText + "%");
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        conn.Open();
        da.Fill(ds);
        conn.Close();
        //int Counter = 0;
        //string[] strResultsArray = new string[count];
        //foreach (DataRow dr in ds.Tables)
        //{
        //    if (Counter == count) break;
        //    strResultsArray[Counter] = dr[0].ToString();
        //}

        int rowcount = ds.Tables[0].Rows.Count;
        if (rowcount == 0)
        {
            string[] empty = new string[1];
            empty[0] = "No records for that name";
            return empty;
        }
        if (rowcount < count) count = rowcount;

        List<string> items = new List<string>(count);
        for (int i = 0; i < count; i++)
        {
            items.Add(ds.Tables[0].Rows[i][0].ToString());
        }
        return items.ToArray();

        //return strResultsArray;
    }
}