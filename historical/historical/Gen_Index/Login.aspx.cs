using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.Security;

public partial class Login : System.Web.UI.Page
{

    protected void Page_Load(object sender, System.EventArgs e)
    {
        lblError.Text = "Please enter your login and password";
    }

    protected void loginButton_Click(object sender, System.EventArgs e)
    {
        //'store the entered user name in a variable
        string user = txtUserName.Text;

        //'store the entered pasword in a variable
        string pass = txtPassword.Text;

        //'this variable is True when persistcheckbox is checked
        bool persist = persistCheckBox.Checked;

        //'check if the (user, pass) combination exists
        if (FormsAuthentication.Authenticate(user, pass))
        {
            //'attempt to load the originally solicited page using
            //'the supplied credentials
            FormsAuthentication.RedirectFromLoginPage(user, persist);
        }
    }
}

