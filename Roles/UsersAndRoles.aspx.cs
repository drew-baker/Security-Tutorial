using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Roles_UsersAndRoles : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            // Populate users and roles.
            BindUsersToUserList();
            BindRolesToList();

            // Check the selected user's roles
            CheckRolesForSelectedUser();

            // Display users belonging to the currently selected role
            DisplayUsersBelongingToRole();
        }
    }

    // Populate the DropDownList with users
    private void BindUsersToUserList()
    {
        // Get collection of MembershipUsers instances
        MembershipUserCollection users = Membership.GetAllUsers();

        // Bind collection of users to DropDownList box
        UserList.DataSource = users;
        UserList.DataBind();
    }

    // Populate repeater with list of roles
    private void BindRolesToList()
    {
        // Get all Roles
        string[] roles = Roles.GetAllRoles();

        // Assign array of roles to the repeaters 
        // data source, then bind the data.
        UsersRoleList.DataSource = roles;
        UsersRoleList.DataBind();

        // Also bind the roles to the RoleList DropDownList
        RoleList.DataSource = roles;
        RoleList.DataBind();
    }

    private void DisplayUsersBelongingToRole()
    {
        // Get the selected role
        string selectedRoleName = RoleList.SelectedValue;

        // Get the list of users that belong to that role
        string[] usersBelongingToRole = Roles.GetUsersInRole(selectedRoleName);

        // Bind the list to the GridView
        RolesUserList.DataSource = usersBelongingToRole;
        RolesUserList.DataBind();
    }

    private void CheckRolesForSelectedUser()
    {
        string selectedUserName = UserList.SelectedValue;
        string[] selectedUserRoles = Roles.GetRolesForUser(selectedUserName);

        foreach (RepeaterItem ri in UsersRoleList.Items)
        {
            // Get reference to the CheckBox
            CheckBox RoleCheckBox = ri.FindControl("RoleCheckBox") as CheckBox;

            // Set the appropiate CheckBox Checked property
            if (selectedUserRoles.Contains<string>(RoleCheckBox.Text))
                RoleCheckBox.Checked = true;
            else
                RoleCheckBox.Checked = false;
        }
    }

    protected void UserList_SelectedIndexChanged(object sender, EventArgs e)
    {
        CheckRolesForSelectedUser();
    }

    protected void RoleCheckBox_CheckChanged(object sender, EventArgs e)
    {
        // Reference the CheckBox that raised this event
        CheckBox RoleCheckBox = sender as CheckBox;

        // Get the currently selected user and role
        string selectedUserName = UserList.SelectedValue;
        string roleName = RoleCheckBox.Text;

        // Determine is we need to add or remove the user from this role
        if (RoleCheckBox.Checked)
        {
            // Add user to the role
            Roles.AddUserToRole(selectedUserName, roleName);
            // Display status message
            ActionStatus.Text = string.Format("User {0} was added to role {1}.", selectedUserName, roleName);
        }
        else
        {
            // Remove the user from the role
            Roles.RemoveUserFromRole(selectedUserName, roleName);
            // Display status message
            ActionStatus.Text = string.Format("User {0} was removed from role {1}.", selectedUserName, roleName);
        }
    }


    protected void RoleList_SelectedIndexChanged(object sender, EventArgs e)
    {
        DisplayUsersBelongingToRole();
    }
}