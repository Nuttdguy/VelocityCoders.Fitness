<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EntityTypeDetail.aspx.cs" Inherits="VelocityCoders.FitnessPratice.WebForm.Admin.EntityTypeDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Entity Detail</title>
</head>
<body>
    <h1>Entity Detail</h1>
    <a href="EntityTypeCollection.aspx">Back</a><a href="../index.aspx">Home</a><br />
    <form id="form1" runat="server">
    <div>
        <b>Entity Type ID:</b><asp:Label runat="server" ID="lblEntityTypeId" /><br />
        <b>Entity ID:</b><asp:Label runat="server" ID="lblEntityType" /><br />
        <b>Description:</b><asp:Label runat="server" ID="lblDescription" /><br />
        <b>Display Name:</b><asp:Label runat="server" ID="lblDisplayName" /><br />
        <b>Entity Type Name:</b><asp:Label runat="server" ID="lblEntityTypeName" /><br />
    </div>
    </form>
</body>
</html>
