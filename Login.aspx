<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="ContentForLoginForm" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1>Login</h1>
    <%--<p>Username: 
        <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
    </p>
    <p>Password: 
        <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
    </p>
    <p>
        <asp:CheckBox ID="RememberMe" runat="server" Text="Remember Me" />
    </p>
    <p>
        <asp:Button ID="LoginButton" runat="server" OnClick="LoginButton_Click" Text="Login" />
    </p>
    <p>
        <asp:Label ID="InvalidCredentialsMessage" runat="server" ForeColor="Red" Visible="false"
            Text="Your username or password is invalid. Please try again."></asp:Label>
    </p>--%>
    <asp:Login ID="myLogin" runat="server" CreateUserText="Not registered yet? Create an account!" CreateUserUrl="~/Membership/EnhancedCreateUserWizard.aspx" TitleText="" UserNameLabelText="Username:" OnAuthenticate="myLogin_Authenticate">
        <LayoutTemplate>
            <table style="border-collapse:collapse; padding:0">
                <tr>
                    <td>
                        <table style="padding:0">
                            <tr>
                                <td style="text-align:right">
                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Username:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="myLogin">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:right">
                                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="myLogin">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:right">
                                    <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">Email:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Email" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Email" ErrorMessage="Email is required" ValidationGroup="myLogin" ToolTip="Email is required">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:CheckBox ID="RememberMe" runat="server" Text="Remember me next time." />
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:center; color:red" colspan="2">
                                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:right" colspan="2">
                                    <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" ValidationGroup="myLogin" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:HyperLink ID="CreateUserLink" runat="server" NavigateUrl="~/Membership/EnhancedCreateUserWizard.aspx">Not registered yet? Create an account!</asp:HyperLink>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
    </asp:Login>
</asp:Content>

    <asp:Content ID="Content2" runat="server" contentplaceholderid="LoginContent">

   </asp:Content>


