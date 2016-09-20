using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Roles_RoleBasedAuthorization : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
            BindUserGrid();
    }

    private void BindUserGrid()
    {
        MembershipUserCollection allUsers = Membership.GetAllUsers();
        UserGrid.DataSource = allUsers;
        UserGrid.DataBind();
    }
}