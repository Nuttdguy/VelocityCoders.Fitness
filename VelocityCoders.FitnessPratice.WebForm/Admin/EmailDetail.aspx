<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmailDetail.aspx.cs" Inherits="VelocityCoders.FitnessPratice.WebForm.Admin.EmailDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Email Detail</title>
</head>
<body>
    <form id="form1" runat="server">
    <h1>Email Detail</h1>
    <a href="EmailCollection.aspx">Back</a><a href="../index.aspx">Home</a><br />
    <div>
        <b>Email ID:</b><asp:Label runat="server" ID="lblEmailId" /><br />
        <b>Entity Type ID:</b><asp:Label runat="server" ID="lblEntityTypeId" /><br />
        <b>Instructor ID:</b><asp:Label runat="server" ID="lblInstructorId" /><br />
        <b>Email Address:</b><asp:Label runat="server" ID="lblEmailAddress" /><br />
        <b>Description:</b><asp:Label runat="server" ID="lblDescription" /><br />
     </div>
    </form>
</body>
</html>
