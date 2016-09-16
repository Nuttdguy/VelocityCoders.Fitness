<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LookupTableNavigationControl.ascx.cs" Inherits="VelocityCoders.FitnessPratice.WebForm.UserControls.LookupTableNavigationControl" %>

<div class="GenericNavigationContainer BorderRadius BorderRadiusTop">
  <span class="HeaderText">
    Manage Lookup Tables:
    &nbsp;
    <asp:DropDownList runat="server" ID="drpSelectLookupTable" DataTextField="Text" DataValueField="Value"  OnSelectedIndexChanged="LookupTables_Selected" AutoPostBack="true" />
  </span>
</div>
