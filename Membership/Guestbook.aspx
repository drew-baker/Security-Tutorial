<%@ Page Title="Guestbook" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Guestbook.aspx.cs" Inherits="Membership_Guestbook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h3>Leave a Comment</h3>
    <p>
        <b>Subject:</b>
        <asp:RequiredFieldValidator ID="SubjectReqValidator" runat="server" 
            ErrorMessage="You must enter a subject." 
            ControlToValidate="Subject" 
            ValidationGroup="EnterComment">
        </asp:RequiredFieldValidator><br />
        <asp:TextBox ID="Subject" runat="server" Columns="40"></asp:TextBox>
    </p>
    <p>
        <b>Body:</b>
        <asp:RequiredFieldValidator ID="BodyReqValidator" runat="server" 
            ErrorMessage="You must enter something for the body." 
            ControlToValidate="Body" 
            ValidationGroup="EnterComment">
        </asp:RequiredFieldValidator><br />
        <asp:TextBox ID="Body" runat="server" Rows="8" TextMode="MultiLine" Width="95%"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="PostCommentButton" runat="server" Text="Post Your Comment" ValidationGroup="EnterComment" OnClick="PostCommentButton_Click" />
    </p>
    <p>
        <asp:ListView ID="CommentList" runat="server" DataSourceID="CommentsDataSource" EnableModelValidation="True" EnableViewState="False">
            <LayoutTemplate>
                <span id="itemPlaceholder" runat="server" />
                <p>
                    <asp:DataPager ID="DataPager1" runat="server">
                        <Fields>
                            <asp:NextPreviousPagerField ButtonType="Button" 
                                ShowFirstPageButton="True" 
                                ShowLastPageButton="True" /> 
                        </Fields>
                    </asp:DataPager>
                </p>
            </LayoutTemplate>
            <ItemTemplate>
                <h4>
                    <asp:Label ID="SubjectLabel" runat="server" Text='<%# Eval("Subject") %>' />
                </h4>
                <asp:Label ID="BodyLabel" runat="server" 
                    Text='<%# Eval("Body").ToString().Replace(Environment.NewLine, "<br />") %>' />
                <p>
                    ---<br />
                    <asp:Label ID="SignatureLabel" runat="server" Font-Italic="true" 
                        Text='<%# Eval("Signature") %>' />
                    <br /><br />
                    My Home Town:
                    <asp:Label ID="HomeTownLabel" runat="server"
                        Text='<%# Eval("HomeTown") %>' />
                    <br />
                    My Home Page:
                    <asp:HyperLink ID="HomepageUrlLink" runat="server" 
                        NavigateUrl='<%# Eval("HomepageUrl") %>'
                        Text='<%# Eval("HomepageUrl") %>' /> 
                </p>
                <p style="text-align:center">
                    Posted by 
                    <asp:Label ID="UserNameLabel" runat="server"
                        Text='<%# Eval("UserName") %>' /> on
                    <asp:Label ID="CommentDateLabel" runat="server"
                        Text='<%# Eval("CommentDate") %>' />
                </p>
            </ItemTemplate>
            <ItemSeparatorTemplate>
                <hr />
            </ItemSeparatorTemplate>
        </asp:ListView>
        <asp:SqlDataSource ID="CommentsDataSource" runat="server" 
            ConnectionString="<%$ ConnectionStrings:SecurityTutorialsConnectionString %>" 
            SelectCommand="SELECT aspnet_Users.UserName, GuestbookComments.Subject, GuestbookComments.Body, GuestbookComments.CommentDate, UserProfiles.HomeTown, UserProfiles.HomepageUrl, UserProfiles.Signature FROM aspnet_Users 
                            INNER JOIN GuestbookComments ON aspnet_Users.UserId = GuestbookComments.UserId 
                            INNER JOIN UserProfiles ON aspnet_Users.UserId = UserProfiles.UserId 
                            ORDER BY CommentDate DESC">
        </asp:SqlDataSource>
    </p>
</asp:Content>


