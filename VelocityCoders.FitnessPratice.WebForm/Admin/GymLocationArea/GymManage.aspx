<%@ Page Title="Manage Gym" Theme="Main" Language="C#" MasterPageFile="~/MasterPages/Site2Column.Master" AutoEventWireup="true" CodeBehind="GymManage.aspx.cs" Inherits="VelocityCoders.FitnessPratice.WebForm.Admin.GymLocationArea.GymManage" %>

<%@ Register TagPrefix="CustomVelocityCoders" TagName="GymLocationNavigation" Src="~/UserControls/GymLocationNavigationControl.ascx" %>
<%@ Register TagPrefix="CustomVelocityCoders" TagName="MessageArea" Src="~/UserControls/MessageBrokenRulesControl.ascx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:HiddenField runat="server" ID="HiddenGymId" Value="0" Visible="false" />
	<CustomVelocityCoders:GymLocationNavigation runat="server" ID="gymLocationNavigation" />

	<div id="GenericContainer" class="BorderRadiusBottom">
		<CustomVelocityCoders:MessageArea runat="server" ID="customMessageArea" Visible="false" />
		<div class="SectionMessageArea SmallText"><label class="Required">*</label> = Required Field</div>

		<table>
			<tr>
				<td><label class="Required">Gym Name*</label></td>
				<td><asp:TextBox runat="server" ID="txtGymName" MaxLength="50" /></td>
			</tr>

			<tr>
				<td><label>Gym Abbreviation</label></td>
				<td><asp:TextBox runat="server" ID="txtGymAbbreviation" MaxLength="10" /></td>
			</tr>

			<tr>
				<td><label>Website</label></td>
				<td><asp:TextBox runat="server" ID="txtWebsite" MaxLength="100" /></td>
			</tr>

			<tr>
				<td><label>Description</label></td>
				<td><asp:TextBox runat="server" ID="txtDescription" TextMode="MultiLine" /></td>
			</tr>
		</table>

		<div class="ContainerBar" >
			<asp:Button runat="server" Text="Add Gym" ID="SaveButton" OnClick="Save_Click" />
			<span class="FloatRight" >
				<asp:Button runat="server" ID="btnCancel" Text="Cancel" Visible="false" OnClick="Cancel_Click" />
			</span>
		</div>

	</div>

	<asp:Repeater runat="server" ID="rptGymList" OnItemDataBound="GymList_OnItemDataBound" >

		<HeaderTemplate>
			<div id="GenericContainer">
			<table class="ListStyle BorderRadiusAll">
				<tr>
					<th>&nbsp;</th>
					<th>Gym</th>
					<th>Abbreviation</th>
					<th>WebSite</th>
				</tr>
		</HeaderTemplate>

		<ItemTemplate>
			<tr>
				<td class="CenterText">
					<asp:LinkButton runat="server" ID="EditButton" Text="Edit" CssClass="Button ButtonRoundedLeft" OnCommand="GymButton_Command" CommandName="Edit" />
					<asp:LinkButton runat="server" ID="DeleteButton" Text="Delete" CssClass="Button ButtonRoundedRight" OnCommand="GymButton_Command"
						commandName="Delete" />
				</td>
				<td class="CenterText"><%# Eval("GymName") %></td>
				<td class="CenterText"><%# Eval("GymAbbreviation") %></td>
				<td class="CenterText"><%# Eval("Website") %></td>
			</tr>
		</ItemTemplate>

		<AlternatingItemTemplate>
			<tr>
				<td class="CenterText ListStyleAlternative">
					<asp:LinkButton runat="server" ID="EditButton" Text="Edit" CssClass="Button ButtonRoundedLeft" OnCommand="GymButton_Command" CommandName="Edit" />
					<asp:LinkButton runat="server" ID="DeleteButton" Text="Delete" CssClass="Button ButtonRoundedRight" OnCommand="GymButton_Command"
						commandName="Delete" />
				</td>
				<td class="ListStyleAlternative CenterText"><%# Eval("GymName") %></td>
				<td class="ListStyleAlternative CenterText"><%# Eval("GymAbbreviation") %></td>
				<td class="ListStyleAlternative CenterText"><%# Eval("Website") %></td>
			</tr>
		</AlternatingItemTemplate>

		<FooterTemplate>
			</table>
			</div>
		</FooterTemplate>

	</asp:Repeater>

</asp:Content>
