<%@ Page Title="Enhanced Create User Wizard" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="EnhancedCreateUserWizard.aspx.cs" Inherits="Membership_EnhancedCreateUserWizard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:CreateUserWizard ID="NewUserWizard" runat="server" ContinueDestinationPageUrl="~/Membership/AdditionalUserInfo.aspx" OnCreatedUser="NewUserWizard_CreatedUser" OnActiveStepChanged="NewUserWizard_ActiveStepChanged">
        <WizardSteps>
            <asp:CreateUserWizardStep runat="server" />
            <asp:WizardStep ID="UserSettings" runat="server" StepType="Step" Title="Your Settings">
                <p>
                    <b>Home Town:</b><br />
                    <asp:TextBox ID="HomeTown" runat="server"></asp:TextBox>
                </p>
                <p>
                    <b>Homepage URL:</b><br />
                    <asp:TextBox ID="HomepageUrl" runat="server" Columns="40"></asp:TextBox>
                </p>
                <p>
                    <b>Signature:</b><br />
                    <asp:TextBox ID="Signature" runat="server" TextMode="MultiLine" Width="95%" Rows="5"></asp:TextBox>
                </p>
            </asp:WizardStep>
            <asp:CompleteWizardStep runat="server" />
        </WizardSteps>
    </asp:CreateUserWizard>
</asp:Content>


