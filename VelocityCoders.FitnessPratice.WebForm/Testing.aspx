<%@ Page Title="" Language="C#" Theme="Main" MasterPageFile="~/MasterPages/Site2Column.Master" AutoEventWireup="true" CodeBehind="Testing.aspx.cs" Inherits="VelocityCoders.FitnessPratice.WebForm.Testing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div id="InstructorContainer" class="BorderRadiusBottom">
		<asp:TextBox runat="server" ID="txtGymName" />
		<asp:Button Text="Submit" ID="submitBtn" OnClick="submitBtn_Click" runat="server" />
		<br /><br />

		<asp:TextBox runat="server" ID="txtGymId" />
		<asp:Button Text="Delete" ID="DeleteBtn" OnClick="deleteBtn_Click" runat="server" />

<%--		<asp:Repeater runat="server" ID="rptCollection" >
			<ItemTemplate>
				<p><%# Eval("GymId") %>  || <%# Eval("GymName") %></p>
			</ItemTemplate>
		</asp:Repeater>--%>
	</div>
</asp:Content>