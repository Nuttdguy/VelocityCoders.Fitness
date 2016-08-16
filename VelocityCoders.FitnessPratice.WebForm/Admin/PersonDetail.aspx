<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonDetail.aspx.cs" Inherits="VelocityCoders.FitnessPratice.WebForm.PersonDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Person Detail</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Person Detail</h1>
        <a href="PersonCollection.aspx">Back</a><a href="../index.aspx">Home</a><br />
        <asp:Label runat="server" ID="lblMessage" /><br />
        <b>Person ID:</b> &nbsp; <asp:Label runat="server" ID="lblPersonId" /><br />
        <b>First Name:</b> &nbsp; <asp:Label runat="server" ID="lblFirstName" /><br />
        <b>Last Name:</b> &nbsp; <asp:Label runat="server" ID="lblLastName" /><br />
        <b>Display Name:</b> &nbsp; <asp:Label runat="server" ID="lblDisplayName" /><br />
        <b>Gender:</b> &nbsp; <asp:Label runat="server" ID="lblGender" /><br />
    </div>
    </form>
</body>
</html>
