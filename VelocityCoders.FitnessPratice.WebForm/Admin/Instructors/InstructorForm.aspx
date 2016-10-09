<%@ Page Language="C#" Theme="Main" AutoEventWireup="true" MasterPageFile="~/MasterPages/Site2Column.Master" CodeBehind="InstructorForm.aspx.cs" Inherits="VelocityCoders.FitnessPratice.WebForm.Admin.Instructors.InstructorForm" EnableViewState="true" %>

<%@ Register TagPrefix="CustomVelocityCoders" TagName="MessageArea" Src="~/UserControls/MessageBrokenRulesControl.ascx" %>
<%@ Register TagPrefix="CustomVelocityCoders" TagName="InstructorNavigation" Src="~/UserControls/InstructorNavigationControl.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

	<script type="text/javascript" src="/Scripts/InstructorForm.js" ></script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
	<asp:HiddenField runat="server" ID="hidInstructorId" Value="0" />
	<asp:HiddenField runat="server" ID="hidPersonId" Value="0" />

	<CustomVelocityCoders:InstructorNavigation runat="server" ID="instructorNavigation"/>
		
	<div id="InstructorContainer" class="BorderRadiusBottom" >
	 <CustomVelocityCoders:MessageArea runat="server" ID="CustomMessageArea" Visible="false" />

			<table class="tableForm">
				<tr class="tableRow">
					<td><label class="Required">FirstName: </label></td>
					<td>
						<div class="LineLeft LineHeightMid">
							<asp:TextBox runat="server" ID="txtFirstName" MaxLength="50" CssClass="ValidateFirstName" />
						</div>
						<div id="ValidationMessageFirstName" class="ValidationBoxFirstName">
							<div class="ValidationBoxArrowBorder"></div>
							<div class="ValidationBoxArrow"></div>
							<div class="ValidationContent">First Name is a required field.</div>
						</div>
					</td>
				</tr>
				<tr class="tableRow">
					<td><label>Preferred First Name: </label></td>
					<td>
						<asp:TextBox runat="server" ID="txtPreferredFirstName" MaxLength="50" />
					</td>
				</tr>
				<tr class="tableRow">
					<td><label class="Required">Last Name:</label></td>
					<td>
						<div class="LineLeft LineHeightMid">
							<asp:TextBox runat="server" ID="txtLastName" CssClass="ValidateLastName" />
						</div>
						<div id="ValidationMessageLastName" class="ValidationBoxLastName" >
							<div class="ValidationBoxArrowBorder"></div>
							<div class="ValidationBoxArrow"></div>
							<div class="ValidationContent">Last Name is a required field.</div>
						</div>
					</td>
				</tr>
				<tr class="tableRow">
					<td><label>Date of Birth:</label></td>
					<td>
						<div class="LineLeft LineHeightMid">
							<asp:TextBox runat="server" ID="txtBirthDate" MaxLength="10"  CssClass="ValidateDate" data-message-id="ValidationMessageDOB "/>
						</div>
						<div id="ValidationMessageDOB" class="ValidationBoxDOB">
							<div class="ValidationBoxArrowBorder"></div>
							<div class="ValidationBoxArrow"></div>
							<div class="ValidationContent">Invalid date. Format must be mm/dd/yyyy.</div>
						</div>
					</td>
				</tr>
				<tr class="tableRow">
					<td><label>Date of Hire:</label></td>
					<td>
						<div class="LineLeft LineHeightMid">
							<asp:TextBox runat="server" ID="txtHireDate" MaxLength="10" CssClass="ValidateDate" data-message-id="ValidationMessageDateOfHire" />
						</div>
						<div id="ValidationMessageDateOfHire" class="ValidationBoxHireDate" >
							<div class="ValidationBoxArrowBorder"></div>
							<div class="ValidationBoxArrow"></div>
							<div class="ValidationContent">Invalid date. Format must be mm/dd/yyyy.</div>
						</div>
					</td>
				</tr>
				<tr class="tableRow">
					<td><label>Date of Termination:</label></td>
					<td>
						<div class="LineLeft LineHeightMid" >
							<asp:TextBox runat="server" ID="txtTermDate" MaxLength="10" CssClass="ValidateDate" data-message-id="ValidationMessageDateOfTerm" />
						</div>
						<div id="ValidationMessageDateOfTerm" class="ValidationBoxTerminateDate">
							<div class="ValidationBoxArrowBorder"></div>
							<div class="ValidationBoxArrow"></div>
							<div class="ValidationContent">Invalid date. Format must be mm/dd/yyyy.</div>
						</div>
					</td>
				</tr>
				<tr class="tableRow">
					<td><label>Employee Type:</label></td>
					<td>
						<asp:DropDownList runat="server" ID="drpEmployeeType" DataTextField="EntityTypeName" DataValueField="EntityTypeId" />
					</td>
				</tr>
				<tr class="tableRow">
					<td><label>Gender:</label></td>
					<td>
						<asp:DropDownList runat="server" ID="drpGender">
							<asp:ListItem Text="(Select Gender)" Value="0" />
							<asp:ListItem Text="Male" Value="Male" />
							<asp:ListItem Text="Female" Value="Female" />
						</asp:DropDownList>
					</td>
				</tr>
				<tr class="tableRow">
					<td><label>Notes:</label></td>
					<td><asp:TextBox runat="server" ID="txtNotes" TextMode="MultiLine" /></td>
				</tr>

			</table>
			<br />
			<div class="ContainerBar" >
				<asp:Button runat="server" Text="Save" ID="btnSave" OnClick="Save_Click" CssClass="SaveButton"  />
				<asp:Button runat="server" Text="Cancel" ID="btnCancel" OnClick="Cancel_Click" />
				<span class="FloatRight" ><asp:Button runat="server" Text="Delete" ID="btnDelete" OnClick="Delete_Click" Visible="false" /></span>
			</div>

		</div> <!-- END INSTRUCTOR CONTAINER -->
</asp:Content>
