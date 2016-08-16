<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EntityTypeCollection.aspx.cs" Inherits="VelocityCoders.FitnessPratice.WebForm.Admin.EntityTypeCollection" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Entity Collection</title>
        <style>
        table { border-collapse: collapse; }
        td { padding: 4px 12px;  font-weight: bold; }
        tr:hover:nth-child(1n+2) {background-color: #ff6a00; transition: background-color 1s;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <h1>Entity Collection</h1>
    <a href="../Index.aspx">Back</a><br /><br />
    <div>
        <table>
        <asp:Repeater runat="server" ID="repeaterText">
            <HeaderTemplate>
                <tr>
                    <td>Entity Type ID</td>
                    <td>Entity ID</td>
                    <td>Description</td>
                    <td>Display Name</td>
                    <td>Entity Type Name</td>
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("EntityTypeId") %></td>
                    <td><%# Eval("EntityId") %></td>
                    <td><%# Eval("Description") %></td>
                    <td><%# Eval("DisplayName") %></td>
                    <td><%# Eval("EntityTypeName") %></td>
                    <td><a href="EntityTypeDetail.aspx?EntityTypeId=<%# Eval("EntityTypeId") %>">Details</a></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        </table>
    </div>
    </form>
</body>
</html>
