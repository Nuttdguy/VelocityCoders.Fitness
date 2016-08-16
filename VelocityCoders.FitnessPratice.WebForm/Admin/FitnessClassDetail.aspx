<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FitnessClassDetail.aspx.cs" Inherits="VelocityCoders.FitnessPratice.WebForm.Admin.FitnessClassDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Fitness Class Detail</title>
</head>
<body>
    <form id="form1" runat="server">
    <h1>Fitness Class Details</h1>
    <a href="FitnessClassCollection.aspx">Back</a><a href="../index.aspx">Home</a><br /><br />
    <div>
        <b>Fitness Class ID: </b><asp:Label runat="server" ID="lblFitnessClassId" /><br />
        <b>Fitness Class Name: </b><asp:Label runat="server" ID="lblFitnessClassName" /><br />
        <b>Description: </b><asp:Label runat="server" ID="lblDescription" /><br />       
    </div>
    </form>
</body>
</html>
