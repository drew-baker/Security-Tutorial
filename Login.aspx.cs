using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.IsAuthenticated && !string.IsNullOrEmpty(Request.QueryString["ReturnUrl"]))
                Response.Redirect("~/UnauthorizedAccess.aspx");
        }
    }

    //protected void LoginButton_Click(object sender, EventArgs e)
    //{
    //    if(Membership.ValidateUser(UserName.Text, Password.Text))
    //    {
    //        FormsAuthentication.RedirectFromLoginPage(UserName.Text, RememberMe.Checked);
    //    }
    //    // If we reach here, the user's credentials were invalid
    //    InvalidCredentialsMessage.Visible = true;
    //}


    protected void myLogin_Authenticate(object sender, AuthenticateEventArgs e)
    {
        // Get the email address entered
        TextBox EmailTextBox = myLogin.FindControl("Email") as TextBox;
        string email = EmailTextBox.Text.Trim();

        // Verify that the username/password pair is valid
        if (Membership.ValidateUser(myLogin.UserName, myLogin.Password))
        {
            // Username/password are valid, check email
            MembershipUser usrInfo = Membership.GetUser(myLogin.UserName);
            if (usrInfo != null && string.Compare(usrInfo.Email, email, true) == 0)
            {
                // Email matches, the credentials are valid
                e.Authenticated = true;
            }
            else
            {
                // Email address is invalid...
                e.Authenticated = false;
            }
        }
        else
        {
            // Username/password are not valid...
            e.Authenticated = false;
        }

    }
}