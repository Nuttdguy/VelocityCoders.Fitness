<%@ Page Title="Entity Type Lookup" Theme="Main" Language="C#" MasterPageFile="~/MasterPages/Site2Column.Master" AutoEventWireup="true" CodeBehind="EntityTypeLookup.aspx.cs" Inherits="VelocityCoders.FitnessPratice.WebForm.Admin.LookupTablesArea.EntityTypeLookup" %>
<%@ Register TagPrefix="CustomVelocityCoders" TagName="LookupTablesNavigation" Src="~/UserControls/LookupTableNavigationControl.ascx" %>
<%@ Register TagPrefix="CustomVelocityCoders" TagName="MessageArea" Src="~/UserControls/MessageBrokenRulesControl.ascx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <asp:HiddenField runat="server" ID="HiddenEntityTypeId" Value="0" />

  <CustomVelocityCoders:LookupTablesNavigation runat="server" ID="lookupTablesNavigation" />
  <div id="InstructorContainer" class="BorderRadiusBottom" >

    <CustomVelocityCoders:MessageArea runat="server" ID="customMessageArea" Visible="false" />
    <div class="SectionMessageArea SmallText"><label class="Required">*</label> = Required Field</div>

    <table>

      <tr>
        <td><label class="Required"> Entity*: </label></td>
        <td><asp:DropDownList runat="server" ID="drpEntity" DataTextField="EntityName" DataValueField="EntityId" AutoPostBack="true"  OnSelectedIndexChanged="EntityList_Selected" /> </td>
      </tr>

      <tr runat="server" ID="EntityNameTableRow" visible="false">
        <td><label>Lookup Name:</label></td>
        <td><asp:TextBox runat="server" ID="txtEntityName" /></td>
      </tr>

      <tr runat="server" id="EntityDisplayNameTableRow" visible="false">
        <td><label>Display Name</label></td>
        <td><asp:TextBox runat="server" ID="txtEntityDisplayName" /></td>
      </tr>

    </table>

    <div class="ContainerBar">
      <asp:Button runat="server" Text="Add Lookup Value" ID="SaveButton" OnClick="Save_Click" />
      <span class="FloatRight" >
        <asp:Button runat="server" ID="btnCancel" Text="Cancel" Visible="false" OnClick="Cancel_Click" />
      </span>
    </div>

    <br />

    <%--    BEGIN REPEATER CONTROL    --%> 
    <asp:Repeater runat="server" ID="rptLookupList" OnItemDataBound="LookupList_OnItemDataBound" >

      <HeaderTemplate>
        <table class="ListStyle BorderRadiusAll" >
          <tr>
            <th>&nbsp;</th>
            <th>Lookup Name</th>
            <th>Display Name</th>
          </tr>
      </HeaderTemplate>

      <ItemTemplate>
        <tr>
          <td class="CenterText" >
            <asp:LinkButton runat="server" ID="EditButton" Text="Edit" CssClass="Button ButtonRoundedLeft" OnCommand="EntityTypeButton_Command" CommandName="Edit" />
            <asp:LinkButton runat="server" ID="DeleteButton" Text="Delete" CssClass="Button ButtonRoundedRight" OnCommand="EntityTypeButton_Command" CommandName="Delete" />
          </td>
          <td class="CenterText" ><%# Eval("EntityTypeName") %></td>
          <td class="CenterText" ><%# Eval("DisplayName") %></td>
        </tr>
      </ItemTemplate>

      <AlternatingItemTemplate>
        <tr>
          <td class="CenterText" >
            <asp:LinkButton runat="server" ID="EditButton" Text="Edit" CssClass="Button ButtonRoundedLeft" OnCommand="EntityTypeButton_Command" CommandName="Edit" />
            <asp:LinkButton runat="server" ID="DeleteButton" Text="Delete" CssClass="Button ButtonRoundedRight" OnCommand="EntityTypeButton_Command" CommandName="Delete" />
          </td>
          <td class="ListStyleAlternate CenterText" ><%# Eval("EntityTypeName") %></td>
          <td class="ListStyleAlternate CenterText" ><%# Eval("DisplayName") %></td>
        </tr>
      </AlternatingItemTemplate>

      <FooterTemplate>
      </table>
      </FooterTemplate>
    </asp:Repeater>

  </div>

</asp:Content>
