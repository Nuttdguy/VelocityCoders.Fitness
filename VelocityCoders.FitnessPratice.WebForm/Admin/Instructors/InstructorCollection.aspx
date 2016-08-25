<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InstructorCollection.aspx.cs" Inherits="VelocityCoders.FitnessPratice.WebForm.Admin.Instructors.InstructorCollection" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Instructor Collection</title>
        <style>
        table { border-collapse: collapse; }
        td { padding: 4px 12px;  font-weight: bold; }
        tr:hover:nth-child(1n+2) {background-color: #ff6a00; transition: background-color 1s;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <h1>Instructor Collection</h1>
    <a href="../../Index.aspx">Back</a><br /><br />
    <div>
        <table>
            <asp:Repeater runat="server" ID="repeaterText">
                <HeaderTemplate>
                    <tr>
                        <td>Instructor ID: </td>
                        <td>Person ID: </td>
                        <td>Hire Date: </td>
                        <td>Term Date: </td>
                        <td>Description: </td>
                        <td>Create Date: </td>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("InstructorId") %></td>
                        <td><%# Eval("PersonId") %></td>
                        <td><%# Eval("HireDate") %></td>
                        <td><%# Eval("TermDate") %></td>
                        <td><%# Eval("Description") %></td>
                        <td><%# Eval("CreateDate") %></td>
                        <td><a href="InstructorDetail.aspx?InstructorId=<%# Eval("InstructorId") %>">Details</a></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
    </form>
</body>
</html>
