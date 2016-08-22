<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonCollection.aspx.cs" Inherits="VelocityCoders.FitnessPratice.WebForm.FitnessPractice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Person Collection</title>
    <style>
        table { border-collapse: collapse; }
        td { padding: 4px 12px;  font-weight: bold; }
        tr:hover:nth-child(1n+2) {background-color: #ff6a00; transition: background-color 1s;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Person Collection</h1>
        <a href="../Index.aspx">Home</a>
        <asp:Label runat="server" ID="lblMessage" />
        <table>
            <asp:Repeater runat="server" ID="repeaterText">
                <HeaderTemplate>
                    <tr>
                        <td>Person Id</td>
                        <td>First Name</td>
                        <td>Last Name</td>
                        <td>Display Name</td>
                        <td>Gender</td>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("PersonId") %></td>
                        <td><%# Eval("FirstName") %></td>
                        <td><%# Eval("LastName") %></td>
                        <td><%# Eval("DisplayFirstName") %></td>
                        <td><%# Eval("Gender") %></td>
                        <td><a href="PersonDetail.aspx?PersonId=<%# Eval("PersonId") %>">Details</a></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <!-- <asp:Label runat="server" ID="label0" /> -->
    </div>
    </form>
</body>
</html>
