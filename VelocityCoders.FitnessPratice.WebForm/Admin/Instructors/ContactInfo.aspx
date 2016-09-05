<%@ Page Title="Instructor Contact Info" Theme="Main" Language="C#" MasterPageFile="~/MasterPages/Site2Column.Master" AutoEventWireup="true" CodeBehind="ContactInfo.aspx.cs" Inherits="VelocityCoders.FitnessPratice.WebForm.Admin.Instructors.ContactInfo" %>

<%@ Register TagPrefix="CustomVelocityCoders" TagName="InstructorNavigation" Src="~/UserControls/InstructorNavigationControl.ascx" %>
<%@ Register TagPrefix="CustomVelocityCoders" TagName="MessageArea" Src="~/UserControls/MessageBrokenRulesControl.ascx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <asp:HiddenField runat="server" ID="hidEmailId" Value="0" />
  <CustomVelocityCoders:InstructorNavigation runat="server" ID="instructorNavigation"/>
      <div id="InstructorContainer" class="BorderRadiusBottom" >
      <CustomVelocityCoders:MessageArea runat="server" ID="CustomMessageArea" Visible="false" />

<%--        <div class="PageMessage"><asp:Label runat="server" ID="lblPageMessage" /></div>--%>

        <table>
          <tr>
            <td><label>Email Address:</label></td>
            <td><asp:TextBox runat="server" ID="txtEmailAddress" MaxLength="50" /> </td>
          </tr>
          <tr>
            <td><label>Email Type:</label></td>
            <td>
              <asp:DropDownList runat="server" ID="drpEmailType"  DataTextField="EntityTypeName" DataValueField="EntityTypeId" />
            </td>
          </tr>
        </table>
        <div class="ContainerBar">
          <asp:Button runat="server" Text="Add Email" ID="SaveButton" OnClick="Save_Click" />
        </div>
        <asp:Repeater runat="server" ID="rptEmailList" OnItemDataBound="EmailList_OnItemDataBound" >
          <HeaderTemplate>
            <table class="ListStyle BorderRadiusAll">
              <tr> 
                <th>&nbsp;</th>
                <th>Email Address</th>
                <th>Email Type</th>
              </tr>
          </HeaderTemplate>
          <ItemTemplate>
            <tr>
              <td class="CenterText">
                <asp:LinkButton runat="server" ID="EditButton" Text="Edit" CssClass="Button ButtonRoundedLeft" OnCommand="EmailButton_Command" CommandName="Edit" />
                <asp:LinkButton runat="server" ID="DeleteButton" Text="Delete" CssClass="Button ButtonRoundedRight" OnCommand="EmailButton_Command" CommandName="Delete" />
              </td>
              <td class="CenterText"><%# Eval("EmailValue") %></td>
              <td class="CenterText"><%# Eval("EmailType.EntityTypeName") %></td>
            </tr>
          </ItemTemplate>
          <AlternatingItemTemplate>
            <tr>
              <td class="ListStyleAlternative CenterText">
                <asp:LinkButton runat="server" ID="EditButton" Text="Edit" CssClass="Button ButtonRoundedLeft" OnCommand="EmailButton_Command" CommandName="Edit" />
                <asp:LinkButton runat="server" ID="DeleteButton" Text="Delete" CssClass="Button ButtonRoundedRight" OnCommand="EmailButton_Command" CommandName="Delete" />
              </td>
              <td class="ListStyleAlternative CenterText"><%# Eval("EmailValue") %></td>
              <td class="ListStyleAlternative CenterText"><%# Eval("EmailType.EntityTypeName") %></td>
            </tr>
          </AlternatingItemTemplate>
          <FooterTemplate>
            </table>
          </FooterTemplate>
        </asp:Repeater>
      </div>
</asp:Content>
