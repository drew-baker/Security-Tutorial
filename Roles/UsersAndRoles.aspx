<%@ Page Title="Users and Roles" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="UsersAndRoles.aspx.cs" Inherits="Roles_UsersAndRoles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <h2>User Role Management</h2>
    <p style="text-align: center">
        <asp:Label ID="ActionStatus" runat="server" CssClass="Important" ForeColor="Red"></asp:Label>
    </p>
    <fieldset style="border-radius:10pt; border-color:cornflowerblue">
        <h3>Manage Roles By User</h3>
        <p>
            <strong>Select a user:</strong>
            <asp:DropDownList ID="UserList" runat="server"
                DataTextField="UserName"
                DataValueField="UserName" AutoPostBack="True" 
                OnSelectedIndexChanged="UserList_SelectedIndexChanged">
            </asp:DropDownList>
        </p>
        <p>
            <asp:Repeater ID="UsersRoleList" runat="server">
                <ItemTemplate>
                    <asp:CheckBox ID="RoleCheckBox" AutoPostBack="true" runat="server" 
                        Text="<%# Container.DataItem %>" 
                        OnCheckedChanged="RoleCheckBox_CheckChanged" />
                    <br />
                </ItemTemplate>
            </asp:Repeater>
        </p>
    </fieldset>
    <fieldset style="border-radius:10pt; border-color:cornflowerblue">
        <h3>Manage Users By Role</h3>
        <p>
            <b>Select a Role:</b>
            <asp:DropDownList ID="RoleList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RoleList_SelectedIndexChanged"></asp:DropDownList>
        </p>
        <p>
            <asp:GridView ID="RolesUserList" runat="server" AutoGenerateColumns="False" EnableModelValidation="True">
                <Columns>
                    <asp:CommandField DeleteText="Remove" ShowDeleteButton="True" />
                    <asp:TemplateField HeaderText="Users">
                        <ItemTemplate>
                            <asp:Label ID="UserNameLabel" runat="server" Text="<%# Container.DataItem %>"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </p>
    </fieldset>
</asp:Content>


