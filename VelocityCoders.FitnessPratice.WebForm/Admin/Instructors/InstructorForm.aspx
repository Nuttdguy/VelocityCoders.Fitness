<%@ Page Language="C#" Theme="Main" AutoEventWireup="true" MasterPageFile="~/MasterPages/Site2Column.Master" CodeBehind="InstructorForm.aspx.cs" Inherits="VelocityCoders.FitnessPratice.WebForm.Admin.Instructors.InstructorForm" EnableViewState="true" %>

<%@ Register TagPrefix="CustomVelocityCoders" TagName="InstructorNavigation" Src="~/UserControls/InstructorNavigationControl.ascx" %>




<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >

  <CustomVelocityCoders:InstructorNavigation runat="server" ID="instructorNavigation"/>
    <div id="InstructorContainer" class="BorderRadiusBottom" >         
      <p><asp:Label runat="server" ID="lblPageMessage" /></p>
      <br />
      <table>
        <tr>
          <td><label>FirstName: </label></td>
          <td><asp:TextBox runat="server" ID="txtFirstName" MaxLength="50" /></td>
        </tr>
        <tr>
          <td><label>Preferred First Name: </label></td>
          <td><asp:TextBox runat="server" ID="txtPreferredFirstName" MaxLength="50" /></td>
        </tr>
        <tr>
          <td><label>Last Name:</label></td>
          <td><asp:TextBox runat="server" ID="txtLastName" /></td>
        </tr>
        <tr>
          <td><label>Date of Birth:</label></td>
          <td><asp:TextBox runat="server" ID="txtBirthDate" MaxLength="10"/></td>
        </tr>
        <tr>
          <td colspan="2"><hr /></td>
        </tr>
        <tr>
          <td><label>Date of Hire:</label></td>
          <td><asp:TextBox runat="server" ID="txtHireDate" MaxLength="10" /></td>
        </tr>
        <tr>
          <td><label>Date of Termination:</label></td>
          <td><asp:TextBox runat="server" ID="txtTermDate" MaxLength="10" /></td>
        </tr>
        <tr>
          <td><label>Employee Type:</label></td>
          <td>
            <asp:DropDownList runat="server" ID="drpEmployeeType">
              <asp:ListItem Text="(Select one)" Value="" />
              <asp:ListItem Text="Hourly" Value="True" />
            </asp:DropDownList>
          </td>
        </tr>
        <tr>
          <td><label>Gender:</label></td>
          <td>
            <asp:DropDownList runat="server" ID="drpGender">
              <asp:ListItem Text="(Select Gender)" Value="0" />
              <asp:ListItem Text="Male" Value="Male" />
              <asp:ListItem Text="Female" Value="Female" />
            </asp:DropDownList>
          </td>
        </tr>
        <tr>
          <td><label>Notes:</label></td>
          <td><asp:TextBox runat="server" ID="txtNotes" TextMode="MultiLine" /></td>
        </tr>

      </table>
      <br />
      <asp:Button runat="server" Text="Save" OnClick="Save_Click"/>
    </div> <!-- END INSTRUCTOR CONTAINER -->
</asp:Content>
