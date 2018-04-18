using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;

namespace Repository
{
    /// <summary>
    /// Summary description for GenIndexDbRepository
    /// </summary>
    public class GenIndexDbRepository : IGenIndexDbRepository
    {
        public GenIndexDbRepository()
        {
        }

        private readonly SqlConnection conSQL = new SqlConnection(ConfigurationManager.AppSettings["conSQL"]);

        public DataSet SearchGenIndex(string lastName, string firstName, string county, string eventYear, string dateObitPub, bool obituaries, bool census, bool naturalization)
        {
            var ds = new DataSet();

            IList<SqlParameter> parameters = new List<SqlParameter>();
            //SELECT DISTINCT TOP 1000 
            var strSQL =
                @"SELECT DISTINCT GEN_NAME.GN_ID, (GEN_NAME.GN_LAST_NM + ', ' + GEN_NAME.GN_FIRST_NM) AS FULL_NM, 
                          GEN_NAME.GN_BIRTH_YEAR_OR_AGE, GEN_NAME.GN_RECORD_TYPE_CD, GEN_NAME.GN_LOCATION, GEN_NAME.GN_DATE_OF_RECORD, 
                          GEN_NAME.GN_COUNTY, ";
            var strFrom = "FROM GEN_NAME";
            var strWhere = "";
            const string strOrder = " ORDER BY FULL_NM";

            try
            {
                //Build the WHERE clause based on data entered for search
                //County dropdown 
                if (county != "All")
                {
                    strWhere += String.Format("{0}GEN_NAME.GN_COUNTY = @GN_COUNTY",
                        (!String.IsNullOrEmpty(strWhere) ? " AND " : ""));
                    parameters.Add(new SqlParameter("@GN_COUNTY", county));
                }

                //Record Type checkboxes 
                IEnumerable<string> types = GetRecordTypes(obituaries, census, naturalization);
                if (types.Any())
                {
                    strWhere += String.Format("{0}GN_RECORD_TYPE_CD IN ({1})",
                        (!String.IsNullOrEmpty(strWhere) ? " AND " : ""), String.Join(",", types.ToArray()));
                }

                //Last Name 
                if (lastName.Trim().Length > 0)
                {
                    //strFrom += !String.IsNullOrEmpty(strFrom) ? ", OBITS_ALTNAME " : "";
                    strFrom += !String.IsNullOrEmpty(strFrom) ? " LEFT OUTER JOIN OBITS_ALTNAME ON GEN_NAME.GN_ID = OBITS_ALTNAME.GN_ID " : "";
                    strWhere += String.Format("{0}(GEN_NAME.GN_LAST_NM LIKE @GN_LAST_NM",
                        (!String.IsNullOrEmpty(strWhere) ? " AND " : null));
                    strWhere += String.Format(" OR OBITS_ALTNAME.OA_ALTNAME LIKE @GN_LAST_NM{0}", ")");
                    parameters.Add(new SqlParameter("@GN_LAST_NM",
                        String.Format("%{0}%", UppercaseFirst(lastName.Replace("'", "''")))));
                }

                //First name
                if (firstName.Trim().Length > 0)
                {
                    if (lastName.Trim().Length > 0)
                    {
                        strWhere += String.Format("{0}GEN_NAME.GN_FIRST_NM LIKE @GN_FIRST_NM",
                            (!String.IsNullOrEmpty(strWhere) ? " AND " : null));
                    }
                    else
                    {
                        strFrom += !String.IsNullOrEmpty(strFrom) ? " LEFT OUTER JOIN OBITS_ALTNAME ON GEN_NAME.GN_ID = OBITS_ALTNAME.GN_ID " : "";
                        strWhere += String.Format("{0}(GEN_NAME.GN_FIRST_NM LIKE @GN_FIRST_NM",
                            (!String.IsNullOrEmpty(strWhere) ? " AND " : null));
                        strWhere += String.Format(" OR OBITS_ALTNAME.OA_ALTNAME LIKE @GN_FIRST_NM{0}", ")");
                    }

                    parameters.Add(new SqlParameter("@GN_FIRST_NM",
                        String.Format("%{0}%", UppercaseFirst(firstName.Replace("'", "''")))));
                }

                //Event Year
                if (eventYear.Length > 0)
                {
                    strWhere += String.Format("{0}GEN_NAME.GN_DATE_OF_RECORD LIKE @GN_DATE_OF_RECORD",
                        (!String.IsNullOrEmpty(strWhere) ? " AND " : null));
                    parameters.Add(new SqlParameter("@GN_DATE_OF_RECORD", String.Format("%{0}%", eventYear)));
                }

                //Obituary Published Date  
                //if ((obituaries) && (dateObitPub.Length > 0))
                if (obituaries)
                {
                    const string strNabbr = "OBITS_DATES.N_ABBR as N_ABBR ";
                    strSQL = strSQL + strNabbr;
                    strFrom += !String.IsNullOrEmpty(strFrom)
                        ? " LEFT OUTER JOIN OBITS_DATES ON GEN_NAME.GN_ID = OBITS_DATES.GN_ID "
                        : "";
                    strWhere += String.Format("{0}(GEN_NAME.GN_DATE_OF_RECORD LIKE @GN_DATE_OF_RECORD",
                        (!String.IsNullOrEmpty(strWhere) ? " AND " : null));
                    strWhere += String.Format(" OR OBITS_DATES.OD_ARTICLE_DATE LIKE @GN_DATE_OF_RECORD{0}", ")");

                    parameters.Add(new SqlParameter("@GN_DATE_OF_RECORD", String.Format("%{0}%", dateObitPub)));

                }

                //Add the FROM, computed WHERE clause and ORDER BY clause to the SELECT string
                strSQL = strSQL + strFrom + (!String.IsNullOrEmpty(strWhere) ? " WHERE " : "") + strWhere +
                         strOrder;

                // .Execute(strSQL + (!String.IsNullOrEmpty(strWHERE)) ? " WHERE " : null) + strWHERE);
                //Execute statement
                var cmd = new SqlCommand(strSQL, conSQL);
                cmd.Parameters.AddRange(parameters.ToArray());
                var da = new SqlDataAdapter(cmd);
                conSQL.Open();
                da.Fill(ds);
                conSQL.Close();
            }
            catch (Exception e)
            {
                throw;
            }

            return ds;
        }

        public DataSet PrintMailOrder(string cartId)
        {
            var ds = new DataSet();
            const string strSQL = @"SELECT DISTINCT GEN_NAME.GN_ID, GEN_NAME.GN_LAST_NM + ', ' + GEN_NAME.GN_FIRST_NM AS FULL_NAME,  
                    GEN_NAME.GN_RECORD_TYPE_CD, GEN_NAME.GN_COUNTY, ShoppingCart.Quantity,  
                    GEN_NAME.GN_LOCATION, OBITS_DATES.N_ABBR, GEN_NAME.GN_DATE_OF_RECORD  
                    FROM ShoppingCart INNER JOIN GEN_NAME ON ShoppingCart.GN_ID = GEN_NAME.GN_ID LEFT OUTER JOIN  
                    OBITS_DATES ON GEN_NAME.GN_ID = OBITS_DATES.GN_ID 
                    WHERE (ShoppingCart.CartID = @CartID)";

            try
            {
                var cmd = new SqlCommand(strSQL, conSQL);
                cmd.Parameters.AddWithValue("CartID", cartId);
                var da = new SqlDataAdapter(cmd);
                conSQL.Open();
                da.Fill(ds);
                conSQL.Close();
            }
            catch (Exception e)
            {
                throw;
            }

            return ds;
        }

        public DataSet GetShoppingCart(string cartId)
        {
            var ds = new DataSet();
            const string strSQL = @"SELECT DISTINCT GEN_NAME.GN_ID, GEN_NAME.GN_LAST_NM + ', ' + GEN_NAME.GN_FIRST_NM AS FULL_NM,  
              GEN_NAME.GN_RECORD_TYPE_CD, GEN_NAME.GN_COUNTY, 0 AS Subtotal  
              FROM ShoppingCart INNER JOIN GEN_NAME ON ShoppingCart.GN_ID = GEN_NAME.GN_ID  
              WHERE (ShoppingCart.CartID = @CartID)"; //'f0fc1b79-1c29-48e9-abc2-77c282fb2a96')";
        
            try
            {
                var cmd = new SqlCommand(strSQL, conSQL);
                cmd.Parameters.AddWithValue("CartID", cartId);
                var da = new SqlDataAdapter(cmd);
                conSQL.Open();
                da.Fill(ds);
                conSQL.Close();
            }
            catch (Exception e)
            {
                throw;
            }

            return ds;
        }

        public DataSet GetNaturaliaztionData(string gnId)
        {
            var ds = new DataSet();
            const string strSQL = @"SELECT ND_COUNTRY As 'Country of Origin', ND_DATE_FILED as 'Date Filed' FROM NATURALIZATION_DATA WHERE GN_ID = (@GNID)"; //'f0fc1b79-1c29-48e9-abc2-77c282fb2a96')";

            try
            {
                var cmd = new SqlCommand(strSQL, conSQL);
                cmd.Parameters.AddWithValue("GNID", gnId);
                var da = new SqlDataAdapter(cmd);
                conSQL.Open();
                da.Fill(ds);
                conSQL.Close();
            }
            catch (Exception e)
            {
                throw;
            }

            return ds;
        }

        public DataSet GetCensusMemberData(string gnId)
        {
            var ds = new DataSet();
            const string strSQL = @"SELECT * FROM CENSUS_MEMBER WHERE GN_ID = (@GNID)"; //'f0fc1b79-1c29-48e9-abc2-77c282fb2a96')";

            try
            {
                var cmd = new SqlCommand(strSQL, conSQL);
                cmd.Parameters.AddWithValue("GNID", gnId);
                var da = new SqlDataAdapter(cmd);
                conSQL.Open();
                da.Fill(ds);
                conSQL.Close();
            }
            catch (Exception e)
            {
                throw;
            }

            return ds;
        }

        public DataSet GetObitsDates(string gnId, string nabbr)
        {
            var ds = new DataSet();
            const string strSQL = "SELECT * FROM OBITS_DATES WHERE GN_ID = (@GNID) AND N_ABBR = (@NABBR)";

            try
            {
                var cmd = new SqlCommand(strSQL, conSQL);
                cmd.Parameters.AddWithValue("GNID", gnId);
                cmd.Parameters.AddWithValue("NABBR", nabbr);
                var da = new SqlDataAdapter(cmd);
                conSQL.Open();
                da.Fill(ds);
                conSQL.Close();
            }
            catch (Exception e)
            {
                throw;
            }

            return ds;
        }

        private IEnumerable<string> GetRecordTypes(bool obituaries, bool census, bool naturalization)
        {
            IList<string> types = new List<string>();
            //Database: Lib_Geneaology_Index  Table: GEN_NAME  Column: GN_RECORD_TYPE_CD 0=Obituary, 1=Census, 2=Naturalization
            if (obituaries) types.Add("0");
            if (census) types.Add("1");
            if (naturalization) types.Add("2");

            return (types);
        }

        private string UppercaseFirst(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            char[] a = s.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }
    }
}