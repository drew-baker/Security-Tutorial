using System;
using System.Collections.Generic;
using System.Web.Security;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Roles_ManageRoles : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
            DisplayRolesInGrid();
    }

    protected void CreateRoleButton_Click(object sender, EventArgs e)
    {
        string newRoleName = RoleName.Text.Trim();

        if (!Roles.RoleExists(newRoleName))
        {
            // Create the role
            Roles.CreateRole(newRoleName);

            // Refresh the list
            DisplayRolesInGrid();
        }
        // Clear RoleName text property
        RoleName.Text = string.Empty;
    }

    private void DisplayRolesInGrid()
    {
        // Get all the roles and assign them to the
        // GridView's DataSource
        RoleList.DataSource = Roles.GetAllRoles();
        // Bind the data source to the GridView control
        RoleList.DataBind();
    }
    protected void RoleList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        // Get the RoleNameLabel
        Label RoleNameLabel = RoleList.Rows[e.RowIndex].FindControl("RoleNameLabel") as Label;

        // Delete the role
        Roles.DeleteRole(RoleNameLabel.Text, false);

        // Rebind data to GridView
        DisplayRolesInGrid();
    }
}