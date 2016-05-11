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

    //---------------------------------------------------//
    //  Method to populate the DropDownList with users.  //
    //               Manage Roles by User                //
    //---------------------------------------------------//
    private void BindUsersToUserList()
    {
        // Get collection of MembershipUsers instances
        MembershipUserCollection users = Membership.GetAllUsers();

        // Bind collection of users to DropDownList box
        UserList.DataSource = users;
        UserList.DataBind();
    }

    //---------------------------------------------------//
    //  Method to populate repeater with list of roles.  //
    //---------------------------------------------------//
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

    //----------------------------------------------------------------//
    //  Method to show a list of users belonging to a selected role.  //
    //                   Manage Users by Role                         //
    //----------------------------------------------------------------//
    private void DisplayUsersBelongingToRole()
    {
        // Get the selected role name from DropDownList
        string selectedRoleName = RoleList.SelectedValue;

        // Get the list of users that belong to that role
        string[] usersBelongingToRole = Roles.GetUsersInRole(selectedRoleName);

        // Bind the list to the GridView
        RolesUserList.DataSource = usersBelongingToRole;
        RolesUserList.DataBind();
    }

    //------------------------------------------------------------//
    //   Method to set check boxes of roles for a selected user.  //
    //                      Manage Roles by User                  //
    //------------------------------------------------------------//
    private void CheckRolesForSelectedUser()
    {
        // Get selected user name from DropDownList of users.
        string selectedUserName = UserList.SelectedValue;

        // Get list of roles for selected user.
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

    //-------------------------------------------------------------------//
    //   DropDownList (UserList) selected index changed event handler.   //
    //-------------------------------------------------------------------//
    protected void UserList_SelectedIndexChanged(object sender, EventArgs e)
    {
        CheckRolesForSelectedUser();
    }

    //----------------------------------------//
    //  Role CheckBox Changed event handler.  //
    //----------------------------------------//
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

    //-------------------------------------------------------------------//
    //   DropDownList (RoleList) selected index changed event handler.   //
    //-------------------------------------------------------------------//
    protected void RoleList_SelectedIndexChanged(object sender, EventArgs e)
    {
        DisplayUsersBelongingToRole();
    }

    //-------------------------------------------------------//
    //  GridView (RoleUserList) deleting row event handler.  //
    //-------------------------------------------------------//
    protected void RolesUserList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        // Get the selected role name.
        string selectedRoleName = RoleList.SelectedValue;

        // Get reference to the UserNameLabel.
        Label UserNameLabel = RolesUserList.Rows[e.RowIndex].FindControl("UserNameLabel") as Label;

        // Remove user from role
        Roles.RemoveUserFromRole(UserNameLabel.Text, selectedRoleName);

        // Refresh GridView
        DisplayUsersBelongingToRole();
        CheckRolesForSelectedUser();
        // Display Status message.
        ActionStatus.Text = string.Format("User {0} was removed from role {1}.", UserNameLabel.Text, selectedRoleName);
    }

    //  
    protected void AddUserToRoleButton_Click(object sender, EventArgs e)
    {
        // Get selected role and username.
        string selectedRoleName = RoleList.SelectedValue;
        string userNameToAddToRole = UserNameToAddToRole.Text;

        // Make sure a username is not empty.
        if (userNameToAddToRole.Trim().Length == 0)
        {
            ActionStatus.Text = "You must enter a username in the textbox.";
            return;
        }

        // Make sure the user exists
        MembershipUser userInfo = Membership.GetUser(userNameToAddToRole);
        if (userInfo == null)
        {
            ActionStatus.Text = string.Format("The user {0} does not exist in the system.", userNameToAddToRole);
            return;
        }

        // Make sure the user doesn't already belong to the role.
        if (Roles.IsUserInRole(userNameToAddToRole, selectedRoleName))
        {
            ActionStatus.Text = string.Format("User {0} is already a member of role {1}.", userNameToAddToRole, selectedRoleName);
            return;
        }

        // If we're here then we need to add the user to the role.
        Roles.AddUserToRole(userNameToAddToRole, selectedRoleName);

        // Clear the TextBox, refresh GridView, display status message.
        UserNameToAddToRole.Text = string.Empty;
        DisplayUsersBelongingToRole();
        CheckRolesForSelectedUser();
        ActionStatus.Text = string.Format("User {0} was added to role {1}.", userNameToAddToRole, selectedRoleName);
    }
}