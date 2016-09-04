<%@ Page Title="" Language="C#"  Theme="Main" MasterPageFile="~/MasterPages/Site2Column.Master" AutoEventWireup="true" CodeBehind="InstructorList.aspx.cs" Inherits="VelocityCoders.FitnessPratice.WebForm.Admin.Instructors.InstructorList" %>

<%@ Register TagPrefix="CustomVelocityCoders" TagName="InstructorNavigation" Src="~/UserControls/InstructorNavigationControl.ascx" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--BEGIN CUSTOM NAVIGATION CONTROL--%>
    <CustomVelocityCoders:InstructorNavigation runat="server" ID="instructorNavigation"/>
    <%--END CUSTOM NAVIGATION CONTROL--%>

    
    <%--BEGIN CONTENT | MAIN--%>
    <div id="InstructorContainer" class="BorderRadiusBottom" >

      <table>
        <asp:Repeater runat="server" ID="rptInstructorList" >
          <HeaderTemplate>
            <tr>
              <td>First Name</td>
              <td>Last Name</td>
              <td>Display Name</td>
              <td>Gender</td>
              <td>Hire Date</td>
              <td>Term Date</td>
              <td>Employee Type</td>
              <td class="spacer"></td>
            </tr>
          </HeaderTemplate>

          <ItemTemplate>
            <tr>
              <td><%# Eval("FirstName") %></td>
              <td><%# Eval("LastName") %></td>
              <td><%# Eval("DisplayFirstName") %></td>
              <td><%# Eval("Gender") %></td>
              <td><%# Eval("HireDate") %></td>
              <td><%# Eval("TermDate") %></td>
              <td><%# Eval("Description") %></td>
              <td><a href="InstructorForm.aspx?InstructorId=<%# Eval("InstructorId") %>" >Edit</a></td>
            </tr>
          </ItemTemplate>
        </asp:Repeater>
      </table>

    </div>

    <%--END CONTENT | MAIN--%>


</asp:Content>
