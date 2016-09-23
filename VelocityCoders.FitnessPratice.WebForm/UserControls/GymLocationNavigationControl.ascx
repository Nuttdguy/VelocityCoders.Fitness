<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GymLocationNavigationControl.ascx.cs" Inherits="VelocityCoders.FitnessPratice.WebForm.UserControls.GymLocationNavigationControl" %>


<div class="GenericNavigationContainer BorderRadius BorderRadiusTop " >
	<span class="HeaderText">
		Manage: &nbsp; 
		<asp:DropDownList runat="server" ID="drpSelectGymLocation" DataTextField="Text" DataValueField="Value" OnSelectedIndexChanged="GymLocation_Selected" AutoPostBack="true" />
	</span>
</div>