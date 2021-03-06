﻿<%@ Page Title="" Language="C#" Theme="Main" MasterPageFile="~/MasterPages/Site2Column.Master" AutoEventWireup="true" CodeBehind="Testing.aspx.cs" Inherits="VelocityCoders.FitnessPratice.WebForm.Testing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div id="InstructorContainer" class="BorderRadiusBottom">
<%--		<asp:TextBox runat="server" ID="txtGymName" />
		<asp:Button Text="Submit" ID="submitBtn" OnClick="submitBtn_Click" runat="server" />
		<br /><br />

		<asp:TextBox runat="server" ID="txtGymId" />
		<asp:Button Text="Delete" ID="DeleteBtn" OnClick="deleteBtn_Click" runat="server" />--%>

		<label>Fitness ID</label><asp:TextBox runat="server" ID="txtfitnessId" />
		<label>Instructor ID:</label><asp:TextBox runat="server" ID="txtInstructorId" />
		<asp:Button runat="server" Text="Save Class" ID="FitnessBtn" OnClick="SaveFitnessBtn_Click" />



		<%--  GET LOCATION ITEM  --%>
<%--		<asp:TextBox runat="server" ID="txtLocationId" />
		<asp:Button Text="Submit" ID="locationId" OnClick="GetLocationItemBtn_Click" runat="server" />
		<br /><br />
		<asp:Label ID="lblLocationName" runat="server"></asp:Label>--%>

		<%--  SAVE LOCATION ITEM  --%>
		<label>Location Name</label><asp:TextBox runat="server" ID="txtLocationName" />
		<label>Location ID:</label><asp:TextBox runat="server" ID="txtSaveLocationId" />
		<asp:Button runat="server" Text="Save Location" ID="SaveLocationBtn" OnClick="SaveLocationBtn_Click" />


<%--		<asp:TextBox runat="server" ID="TextBox2" />--%>
		<asp:Button Text="Delete Location" ID="deleteLocationBtn" OnClick="deleteLocationBtn_Click" runat="server" />



		
		<%--  SAVE STATE ITEM  --%>
		<label>State Name</label><asp:TextBox runat="server" ID="txtStateName" />
		<label>State ID:</label><asp:TextBox runat="server" ID="txtStateId" />
		<asp:Button runat="server" Text="Save State" ID="Button1" OnClick="SaveStateBtn_Click" />


<%--		<asp:TextBox runat="server" ID="TextBox2" />--%>
		<asp:Button Text="Delete State" ID="Button2" OnClick="deleteStateBtn_Click" runat="server" />





		<%--  FOR LOCATION COLLECTION  --%>
		<asp:Repeater runat="server" ID="rptCollection" >
			<ItemTemplate>
				<p><%# Eval("FitnessClassId") %></p>
				<p><%# Eval("FitnessClassName") %></p>
				<p><%# Eval("Description") %></p>
			</ItemTemplate>
		</asp:Repeater>


<%--		<asp:Repeater runat="server" ID="rptCollection" >
			<ItemTemplate>
				<p><%# Eval("GymId") %>  || <%# Eval("GymName") %></p>
			</ItemTemplate>
		</asp:Repeater>--%>
	</div>
</asp:Content>