using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Membership_UserBasedAuthorization : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string appPath = Request.PhysicalApplicationPath;
            DirectoryInfo dirInfo = new DirectoryInfo(appPath);

            FileInfo[] files = dirInfo.GetFiles();

            FilesGrid.DataSource = files;
            FilesGrid.DataBind();

            string userName = User.Identity.Name;

            if (string.Compare(userName, "Tito", true) == 0)
                FilesGrid.Columns[1].Visible = true;
            else
                FilesGrid.Columns[1].Visible = false;
        }
    }

    protected void FilesGrid_SelectedIndexChanged(object sender, EventArgs e)
    {
        string fullFileName = FilesGrid.SelectedValue.ToString();
        string contents = File.ReadAllText(fullFileName);
        TextBox FileContentsTextBox = LoginViewForFileContentsTextBox.FindControl("FileContents") as TextBox;
        FileContentsTextBox.Text = contents;
    }

    protected void FilesGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string fullFileName = FilesGrid.DataKeys[e.RowIndex].Value.ToString();
        TextBox FileContentsTextBox = LoginViewForFileContentsTextBox.FindControl("FileContents") as TextBox;
        FileContentsTextBox.Text = string.Format("You have chosen to delete {0}.", fullFileName); ;

        //File.Delete(fullFileName);
    }
}