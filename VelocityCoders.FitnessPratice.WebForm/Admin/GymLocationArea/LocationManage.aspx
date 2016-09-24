<%@ Page Title="Manage Location" Theme="Main" Language="C#" MasterPageFile="~/MasterPages/Site2Column.Master" AutoEventWireup="true" CodeBehind="LocationManage.aspx.cs" Inherits="VelocityCoders.FitnessPratice.WebForm.Admin.GymLocationArea.LocationManage" %>

<%@ Register TagPrefix="CustomVelocityCoders" TagName="GymLocationNavigation" Src="~/UserControls/GymLocationNavigationControl.ascx" %>
<%@ Register TagPrefix="CustomVelocityCoders" TagName="MessageArea" Src="~/UserControls/MessageBrokenRulesControl.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:HiddenField runat="server" ID="HiddenGymId" Value="0" Visible="false" />
	<CustomVelocityCoders:GymLocationNavigation runat="server" ID="gymLocationNavigation" />

	<div id="GenericContainer" class="BorderRadiusBottom">
		<CustomVelocityCoders:MessageArea runat="server" ID="customMessageArea" Visible="false" />
		<div class="SectionMessageArea SmallText"><label class="Required">*</label> = Required Field </div>
		 
		<table>
			<tr>
				<td><label>Gym Name</label></td>
				<td>
					<asp:DropDownList runat="server" ID="drpGymName" MaxLength="100"  DataValueField='GymId' DataTextField='GymName'>
					</asp:DropDownList>
				</td>
			</tr>
			<tr>
				<td><label>Location Name</label></td>
				<td><asp:TextBox runat="server" ID="txtLocationName"  MaxLength="100" /></td>
			</tr>
			<tr>
				<td><label>Address 1</label></td>
				<td><asp:TextBox runat="server" ID="txtAddress01" MaxLength="100" /></td>
			</tr>
			<tr>
				<td><label>Address 2</label></td>
				<td><asp:TextBox runat="server" ID="txtAddress02" MaxLength="100" /></td>
			</tr>
			<tr>
				<td><label>City</label></td>
				<td><asp:TextBox runat="server" ID="txtCity" MaxLength="100" /></td>
			</tr>
			<tr>
				<td><label>Zip Code</label></td>
				<td><asp:TextBox runat="server" ID="txtZipCode" MaxLength="5"/></td>
			</tr>
			<tr>
				<td><label>Zip Code (2)</label></td>
				<td><asp:TextBox runat="server" ID="txtZipCodePlusFour" MaxLength="4" /></td>
			</tr>
		</table>

		<div class="ContainerBar" >
			<asp:Button runat="server" Text="Add Location" ID="SaveButton" />
			<asp:Button runat="server" Text="View Locations" ID="ViewButton" OnClick="ViewButton_Click" />

			<span class="FloatRight" >
				<asp:Button runat="server" ID="btnCancel" Text="Cancel" Visible="false" />
			</span>
		</div>

	</div>

	<asp:Repeater runat="server" ID="rptLocationList"  >
		
		<HeaderTemplate>
			<div id="GenericContainer">
				<table class="ListStyle BorderRadiusAll" >
					<tr>
						<th>&nbsp;</th>
						<th>Gym Name:</th>
						<th>Address 01</th>
						<th>City</th>
						<th>Zip Code</th>
					</tr>
		</HeaderTemplate>

		<ItemTemplate>
			<tr>
				<td class="CenterText">
					<asp:LinkButton runat="server" ID="EditBtn" Text="Edit" CssClass="Button ButtonRoundedLeft" OnCommand="LocationBtn_Command" CommandName="Edit" />
					<asp:LinkButton runat="server" ID="DeleteBtn" Text="Delete" CssClass="Button ButtonRoundedRight" OnCommand="LocationBtn_Command"
						commandName="DeleteBtn" />
				</td>
				<td class="CenterText"><%# Eval("Gym.GymName") %></td>
				<td class="CenterText"><%# Eval("Address01") %></td>
				<td class="CenterText"><%# Eval("City") %></td>
				<td class="CenterText"><%# Eval("ZipCode") %></td>
			</tr>
		</ItemTemplate>

		<AlternatingItemTemplate>
			<tr>
				<td class="CenterText ListStyleAlternative">
					<asp:LinkButton runat="server" ID="EditBtn" Text="Edit" CssClass="Button ButtonRoundedLeft" OnCommand="LocationBtn_Command" CommandName="Edit" />
					<asp:LinkButton runat="server" ID="DeleteBtn" Text="Delete" CssClass="Button ButtonRoundedRight" OnCommand="LocationBtn_Command"
						commandName="DeleteBtn" />
				</td>
				<td class="CenterText ListStyleAlternative"><%# Eval("Gym.GymName") %></td>
				<td class="CenterText ListStyleAlternative"><%# Eval("Address01") %></td>
				<td class="CenterText ListStyleAlternative"><%# Eval("City") %></td>
				<td class="CenterText ListStyleAlternative"><%# Eval("ZipCode") %></td>
			</tr>

		</AlternatingItemTemplate>
		<FooterTemplate>
			</table>
		  </div>
		</FooterTemplate>
	</asp:Repeater>


</asp:Content>
