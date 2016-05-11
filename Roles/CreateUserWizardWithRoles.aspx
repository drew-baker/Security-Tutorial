<%@ Page Title="Create User Wizard With Roles" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CreateUserWizardWithRoles.aspx.cs" Inherits="Roles_CreateUserWizardWithRoles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:CreateUserWizard ID="RegisterUserWithRoles" runat="server" ContinueDestinationPageUrl="~/Default.aspx" LoginCreatedUser="False" OnActiveStepChanged="RegisterUserWithRoles_ActiveStepChanged">
        <WizardSteps>
            <asp:CreateUserWizardStep runat="server" />
            <asp:WizardStep ID="SpecifyRolesStep" runat="server" AllowReturn="False" StepType="Step" Title="Specify Roles">
                <asp:CheckBoxList runat="server" ID="RoleList"></asp:CheckBoxList>
            </asp:WizardStep>
            <asp:CompleteWizardStep runat="server" />
        </WizardSteps>
    </asp:CreateUserWizard>
</asp:Content>


