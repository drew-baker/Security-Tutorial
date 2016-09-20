<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Logout.aspx.cs" Inherits="Logout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Panel ID="Panel1" runat="server">
        <h1>Logout</h1>
    You've been logged out.<br />
        To log in, please return to the 
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Login.aspx">Login page.</asp:HyperLink>
</asp:Panel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LoginContent" Runat="Server">
    
    
</asp:Content>

