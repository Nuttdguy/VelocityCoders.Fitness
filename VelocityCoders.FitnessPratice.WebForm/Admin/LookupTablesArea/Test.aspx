<%@ Page Title="Entity Lookup"  Trace="true" Theme="Main" Language="C#" MasterPageFile="~/MasterPages/Site2Column.Master" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="VelocityCoders.FitnessPratice.WebForm.Admin.LookupTablesArea.Test" %>


<%@ Register TagPrefix="CustomVelocityCoders" TagName="LookupTablesNavigation" Src="~/UserControls/LookupTableNavigationControl.ascx" %>
<%@ Register TagPrefix="CustomVelocityCoders" TagName="MessageArea" Src="~/UserControls/MessageBrokenRulesControl.ascx" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:HiddenField runat="server" ID="HiddenEntityId" Value="0" />

	<CustomVelocityCoders:LookupTablesNavigation runat="server" ID="lookupTablesNavigation" />
	<div id="InstructorContainer" class="BorderRadiusBottom" >

		<CustomVelocityCoders:MessageArea runat="server" ID="customMessageArea" Visible="false" />
		<div class="SectionMessageArea SmallText"><label class="Required">*</label> = Required Field</div>

		<label> Entity ID:</label>
		<asp:TextBox runat="server" ID="txtEntityId" /> <br />

		<label> Entity Name</label>
		<asp:TextBox runat="server" ID="txtEntityName" /> <br />

		<asp:Button runat="server" ID="btnSubmit" Text="Add" OnClick="btnSubmit_Click" />
		<asp:Button runat="server" ID="btnDelete" Text="Delete" OnClick="btnDelete_Click" />


	</div>

</asp:Content>
