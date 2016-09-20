<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="ContentForDefaultForm" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Panel ID="AuthenticatedMessagePanel" runat="server">
        <asp:Label ID="WelcomeBackMessage" runat="server"></asp:Label>
    </asp:Panel>
    <asp:Panel ID="AnonymousMessagePanel" runat="server">
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Login.aspx">Log in</asp:HyperLink>
    </asp:Panel>
</asp:Content>