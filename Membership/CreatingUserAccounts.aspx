<%@ Page Title="Creating User Accounts" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CreatingUserAccounts.aspx.cs" Inherits="Membership_CreatingUserAccounts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h2>Create a New User Account</h2>
    <asp:CreateUserWizard ID="RegisterUser" runat="server" DisplayCancelButton="True" CancelDestinationPageUrl="~/Default.aspx" ContinueDestinationPageUrl="~/Default.aspx" OnCreatingUser="RegisterUser_CreatingUser">
        <WizardSteps>
            <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
            </asp:CreateUserWizardStep>
            <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
            </asp:CompleteWizardStep>
        </WizardSteps>
    </asp:CreateUserWizard>
    <asp:Label ID="InvalidUserNameOrPasswordMessage" Visible="False" ForeColor="Red" EnableViewState="False" runat="server" EnableTheming="True"></asp:Label>
    <%--<p>
        Enter a username:<asp:TextBox ID="Username" runat="server"></asp:TextBox>
        <br />
        Choose a password:<asp:TextBox ID="Password" TextMode="Password"  runat="server" />
        <br />
        Enter your email address:<asp:TextBox ID="Email" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="SecurityQuestion" runat="server" Text="What is your favorite color?"></asp:Label>:
        <asp:TextBox ID="SecurityAnswer" runat="server" Text="" />
        <asp:Button ID="CreateAccountButton" runat="server" Text="Create the User Account" OnClick="CreateAccountButton_Click" />
        <br /><br />
        <asp:Label ID="CreateAccountResults" runat="server" Text=""></asp:Label>
    </p>--%>
</asp:Content>


