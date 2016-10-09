<%@ Page Title="Fitness Class Admin" Language="C#" Theme="Main" MasterPageFile="~/MasterPages/Site2Column.Master" AutoEventWireup="true" CodeBehind="InstructorFitnessClassAdmin.aspx.cs" Inherits="VelocityCoders.FitnessPratice.WebForm.Admin.Instructors.InstructorFitnessClassAdmin" %>

<%@ Register TagPrefix="CustomVelocityCoders" TagName="MessageArea" Src="~/UserControls/MessageBrokenRulesControl.ascx" %>
<%@ Register TagPrefix="CustomVelocityCoders" TagName="InstructorNavigation" Src="~/UserControls/InstructorNavigationControl.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<script type="text/javascript" src="/Scripts/FitnessClassAdmin.js" ></script>
	<asp:Literal runat="server" ID="litInstructorId" />

	<CustomVelocityCoders:InstructorNavigation runat="server" ID="InstructorNavigation" />

	<div id="InstructorContainer" class="BorderRadiusBottom" >

		<div id="MessageArea" class="PageMessage BorderRadiusAll">
			<ul id="MessageAreaList"></ul>
		</div>

		<table>
			<tr>
				<td><label class="Required">Instructor:</label></td>
				<td><div id="InstructorName"></div></td>
			</tr>

			<tr>
				<td><label class="Required">Fitness Class*:</label></td>
				<td>
					<select id="drpFitnessClass">
						<option>(Select fitness class)</option>
					</select>
					<button class="ManageButton" data-option-name="FitnessClass" data-option-display="Fitness Class">Add</button>
				</td>
			</tr>

		</table>

		<div class="ContainerBar">
			<asp:Button runat="server" Text="Associate Fitness Class" CssClass="AssociateFitnessClassButton" ID="SaveButton" OnClientClick="return ValidateClientForm()" />
		</div>
		<br />
		<br />
		<table class="ListStyle BorderRadiusAll" id="FitnessClassTable" >
			<tr>
				<th>&nbsp;</th>
				<th>Fitness Class</th>
			</tr>
		</table>

	</div>

	<div id="FitnessClassPopupForm">
		<p class="ValidateTips" >All form fields are required.</p>

		<table class="BaseTable">
			<tr>
				<td><label>Name:</label></td>
				<td>
					<input type="text" name="FitnessClassPopupForm_NameValue" id="FitnessClassPopupForm_NameValue" maxlength="50" />
				</td>
			</tr>

			<tr>
				<td><label>Description:</label></td>
				<td>
					<input type="text" maxlength="50" name="FitnessClassPopupForm_DescValue" id="FitnessClassPopupForm_DescValue" />
				</td>
			</tr>
		</table>

	</div>

</asp:Content>
