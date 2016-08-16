<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InstructorDetail.aspx.cs" Inherits="VelocityCoders.FitnessPratice.WebForm.Admin.InstructorDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Instructor Detail</title>
</head>
<body>
    <form id="form1" runat="server">
    <h1>Instructor Detail</h1>
    <a href="InstructorCollection.aspx">Back</a><a href="../index.aspx">Home</a>
    <div>
        <b>Instructor ID:</b><asp:Label runat="server" ID="lblInstructorId" /><br />
        <b>Person ID:</b><asp:Label runat="server" ID="lblPersonId" /><br />
        <b>Hire Date:</b><asp:Label runat="server" ID="lblHireDate" /><br />
        <b>Term Date:</b><asp:Label runat="server" ID="lblDescription" /><br />
        <b>Create Date:</b><asp:Label runat="server" ID="lblCreateDate" /><br />
    </div>
    </form>
</body>
</html>
