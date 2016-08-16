<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FitnessClassCollection.aspx.cs" Inherits="VelocityCoders.FitnessPratice.WebForm.Admin.FitnessClassCollection" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Fitness Class Collection</title>
        <style>
        table { border-collapse: collapse; }
        td { padding: 4px 12px;  font-weight: bold; }
        tr:hover:nth-child(1n+2) {background-color: #ff6a00; transition: background-color 1s;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <h1>Fitness Class Collection</h1>
    <a href="../Index.aspx">Back</a><br /><br />
    <div>
        <table>
        <asp:Repeater runat="server" id="repeaterText">
            <HeaderTemplate>
                <tr>
                    <td>Fitness Class ID </td>
                    <td>Fitness Class Name </td>
                    <td>Description </td>
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("FitnessClassId") %></td>
                    <td><%# Eval("FitnessClassName") %></td>
                    <td><%# Eval("Description") %></td>
                    <td><a href="FitnessClassDetail.aspx?FitnessClassId=<%# Eval("FitnessClassId") %>">Details</a></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        </table>
    </div>
    </form>
</body>
</html>
