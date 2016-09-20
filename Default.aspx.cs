using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.IsAuthenticated)
        {
            WelcomeBackMessage.Text = "Welcome back, " + User.Identity.Name + "!";

            // Get User Data from FormsAuthenticationTicket and show it in WelcomeBackMessage
            CustomIdentity ident = User.Identity as CustomIdentity;

            if (ident != null)

            {
                WelcomeBackMessage.Text += string.Format(" You are the {0} of {1}.", ident.Title, ident.CompanyName);
            }
            AuthenticatedMessagePanel.Visible = true;
            AnonymousMessagePanel.Visible = false;
        }
        else
        {
            AuthenticatedMessagePanel.Visible = false;
            AnonymousMessagePanel.Visible = true;
        }
    }
}