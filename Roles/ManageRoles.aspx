<%@ Page Title="Manage Roles" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ManageRoles.aspx.cs" Inherits="Roles_ManageRoles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1>Manage Roles</h1>
    Create a Role
    <asp:TextBox ID="RoleName" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="CreateRoleButton" runat="server" Text="Create Role" OnClick="CreateRoleButton_Click" />
    <br />
    <asp:RequiredFieldValidator ID="RequiredRoleName" runat="server" 
                                ErrorMessage="Please enter a role name to create." 
                                ControlToValidate="RoleName">
    </asp:RequiredFieldValidator>
<%--    <br />
    <asp:RegularExpressionValidator ID="SpecialCharValidator" runat="server" 
                                ErrorMessage="Special characters are not allowed." 
                                ControlToValidate="RoleName">
    </asp:RegularExpressionValidator>--%>
    <br />
    <asp:gridview id="RoleList" runat="server" autogeneratecolumns="False" enablemodelvalidation="True" onrowdeleting="RoleList_RowDeleting">
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="Button1" runat="server" CausesValidation="False" 
                        CommandName="Delete" Text="Delete Role" 
                        OnClientClick="return confirm('Are you sure you want to delete this product?')" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Role">
                <ItemTemplate>
                    <asp:Label ID="RoleNameLabel" runat="server" Text="<%# Container.DataItem %>"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:gridview>
</asp:Content>


