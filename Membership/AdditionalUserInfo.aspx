<%@ Page Title="Additional User Information" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AdditionalUserInfo.aspx.cs" Inherits="Membership_AdditionalUserInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Label ID="SettingsUpdatedMessage" runat="server" Text="Your information has been updated." Visible="False"></asp:Label>
    <asp:DetailsView ID="UserProfile" runat="server" AutoGenerateRows ="False" DataKeyNames="UserId" DataSourceID="UserProfileDataSource" EnableModelValidation="True" DefaultMode="Edit" OnItemUpdated="UserProfile_ItemUpdated">
        <Fields>
            <asp:BoundField DataField="HomeTown" HeaderText="HomeTown" SortExpression="HomeTown" />
            <asp:BoundField DataField="HomepageUrl" HeaderText="HomepageUrl" SortExpression="HomepageUrl" />
            <asp:BoundField DataField="Signature" HeaderText="Signature" SortExpression="Signature" />
            <asp:CommandField ShowEditButton="True" />
        </Fields>
    </asp:DetailsView>
    <asp:SqlDataSource ID="UserProfileDataSource" runat="server" 
                       ConnectionString="<%$ ConnectionStrings:SecurityTutorialsConnectionString %>" 
                       SelectCommand="SELECT [UserId], [HomeTown], [HomepageUrl], [Signature] 
                                      FROM [UserProfiles] WHERE ([UserId] = @UserId)" 
                       OnSelecting="UserProfileDataSource_Selecting" 
                       UpdateCommand="UPDATE UserProfiles  
                                      SET HomeTown = @HomeTown, HomepageUrl = @HomepageUrl, Signature = @Signature
                                      WHERE UserId = @UserId">
        <SelectParameters>
            <asp:Parameter Name="UserId" Type="Object" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>


