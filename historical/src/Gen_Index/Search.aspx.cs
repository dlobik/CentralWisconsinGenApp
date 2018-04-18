using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Search : System.Web.UI.Page
{
    private bool _obitDateValid = false;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSearch_OnClick(object sender, EventArgs e)
    {
       if (_obitDateValid)
       {
           string urlParams = String.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}{12}{13}{14}{15}", "?lnm=", txtLast.Text, "&fnm=", txtFirst.Text, "&cty=", ddlCounty.SelectedValue, "&odt=", txtDate.Text, "&eyr=", txtYear.Text, "&ord=", cbObits.Checked, "&crd=", cbCensus.Checked, "&nrd=", cbNatural.Checked);
           Response.Redirect("SearchResults.aspx" + urlParams, false);
    
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

        _obitDateValid = args.IsValid;

    }
}
