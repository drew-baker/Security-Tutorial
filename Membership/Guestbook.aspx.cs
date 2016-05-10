using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.Security;

public partial class Membership_Guestbook : System.Web.UI.Page
{
    protected void PostCommentButton_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid)
            return;
        // Get current user's id
        MembershipUser currentUser = Membership.GetUser();
        Guid currentUserId = (Guid)currentUser.ProviderUserKey;

        string connStr = ConfigurationManager.ConnectionStrings["SecurityTutorialsConnectionString"].ConnectionString;
        string insertSql = "INSERT INTO GuestbookComments(Subject, Body, UserId) VALUES(@Subject, @Body, @UserId)";

        using(SqlConnection myConn = new SqlConnection(connStr))
        {
            myConn.Open();
            SqlCommand myCmd = new SqlCommand(insertSql, myConn);
            myCmd.Parameters.AddWithValue("@Subject", Subject.Text.Trim());
            myCmd.Parameters.AddWithValue("@Body", Body.Text.Trim());
            myCmd.Parameters.AddWithValue("@UserId", currentUserId);
            myCmd.ExecuteNonQuery();
            myConn.Close();
        }

        Subject.Text = string.Empty;
        Body.Text = string.Empty;
    }
}