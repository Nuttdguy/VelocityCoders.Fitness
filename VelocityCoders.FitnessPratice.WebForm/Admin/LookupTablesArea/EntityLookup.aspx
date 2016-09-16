<%@ Page Title="Entity Lookup"  Theme="Main" Language="C#" MasterPageFile="~/MasterPages/Site2Column.Master" AutoEventWireup="true" CodeBehind="EntityLookup.aspx.cs" Inherits="VelocityCoders.FitnessPratice.WebForm.Admin.LookupTablesArea.EntityLookup" %>

<%@ Register TagPrefix="CustomVelocityCoders" TagName="LookupTablesNavigation" Src="~/UserControls/LookupTableNavigationControl.ascx" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  <CustomVelocityCoders:LookupTablesNavigation runat="server" ID="lookupTablesNavigation" />
  <div id="InstructorContainer" class="BorderRadiusBottom" >

    <div class="SectionMessageArea SmallText"><label class="Required">*</label> = Required Field</div>

  </div>

</asp:Content>
