<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmailCollection.aspx.cs" Inherits="VelocityCoders.FitnessPratice.WebForm.Admin.EmailCollection" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Email Collection</title>
        <style>
        table { border-collapse: collapse; }
        td { padding: 4px 12px;  font-weight: bold; }
        tr:hover:nth-child(1n+2) {background-color: #ff6a00; transition: background-color 1s;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <h1>Email Collection</h1>
    <a href="../index.aspx">Back</a>
    <div>
        <table>
            <asp:Repeater runat="server" ID="repeaterText">
                <HeaderTemplate>
                    <tr>
                        <td>Email Id</td>
                        <td>Entity Type Id</td>
                        <td>Instructor Id</td>
                        <td>Email Address</td>
                        <td>Description</td>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("EmailId") %></td>
                        <td><%# Eval("EntityTypeId") %></td>
                        <td><%# Eval("InstructorId") %></td>
                        <td><%# Eval("EmailAddress") %></td>
                        <td><%# Eval("Description") %></td>
                        <td><a href="EmailDetail.aspx?EmailId=<%# Eval("EmailId") %>">Detail</a></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
    </form>
</body>
</html>
