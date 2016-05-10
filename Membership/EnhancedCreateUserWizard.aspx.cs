using System;
using System.Web.Security;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Membership_EnhancedCreateUserWizard : System.Web.UI.Page
{
    protected void NewUserWizard_CreatedUser(object sender, EventArgs e)
    {
        // Get the UserId just added
        MembershipUser newUser = Membership.GetUser(NewUserWizard.UserName);
        Guid newUserId = (Guid)newUser.ProviderUserKey;

        // Get connection string from configuration manager
        string conStr = ConfigurationManager.ConnectionStrings["SecurityTutorialsConnectionString"].ConnectionString;
        // Create a Sql insert statement
        string insertSql = @"INSERT INTO UserProfiles(UserId, HomeTown, HomepageUrl, Signature) 
                             VALUES(@UserId, @HomeTown, @HomepageUrl, @Signature)";

        // Connect to DB, create a Sql command object. 
        // Set parameter values, execute and close connection.
        using (SqlConnection myConn = new SqlConnection(conStr))
        {
            myConn.Open();
            SqlCommand myCmd = new SqlCommand(insertSql, myConn);
            myCmd.Parameters.AddWithValue("@UserId", newUserId);
            myCmd.Parameters.AddWithValue("@HomeTown", DBNull.Value);
            myCmd.Parameters.AddWithValue("@HomepageUrl", DBNull.Value);
            myCmd.Parameters.AddWithValue("@Signature", DBNull.Value);
            myCmd.ExecuteNonQuery();
            myConn.Close();
        }
    }

    protected void NewUserWizard_ActiveStepChanged(object sender, EventArgs e)
    {
        // Have we JUST reached the 'Complete' step?
        if(NewUserWizard.ActiveStep.Title == "Complete")
        {
            // Get a WizardStep reference to UserSettings
            WizardStep UserSettings = NewUserWizard.FindControl("UserSettings") as WizardStep;

            // Get references to the TextBox controls
            TextBox HomeTown = UserSettings.FindControl("HomeTown") as TextBox;
            TextBox HomepageUrl = UserSettings.FindControl("HomepageUrl") as TextBox;
            TextBox Signature = UserSettings.FindControl("Signature") as TextBox;

            // Get the UserId just added
            MembershipUser newUser = Membership.GetUser(NewUserWizard.UserName);
            Guid newUserId = (Guid)newUser.ProviderUserKey;

            // Get connection string from configuration manager
            string conStr = ConfigurationManager.ConnectionStrings["SecurityTutorialsConnectionString"].ConnectionString;
            // Create a Sql update statement
            string updateSql = @"UPDATE UserProfiles 
                                 SET HomeTown = @HomeTown, 
                                     HomepageUrl = @HomepageUrl, 
                                     Signature = @Signature
                                 WHERE UserId= @UserId";

            // Connect to DB, create a Sql command object. 
            // Set parameter values, execute and close connection.
            using (SqlConnection myConn = new SqlConnection(conStr))
            {
                myConn.Open();
                SqlCommand myCmd = new SqlCommand(updateSql, myConn);
                myCmd.Parameters.AddWithValue("@UserId", newUserId);
                myCmd.Parameters.AddWithValue("@HomeTown", HomeTown.Text.Trim());
                myCmd.Parameters.AddWithValue("@HomepageUrl", HomepageUrl.Text.Trim());
                myCmd.Parameters.AddWithValue("@Signature", Signature.Text.Trim());
                myCmd.ExecuteNonQuery();
                myConn.Close();
            }
        }
    }
}