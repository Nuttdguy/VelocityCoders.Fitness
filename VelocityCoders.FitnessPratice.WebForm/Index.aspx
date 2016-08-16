<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="VelocityCoders.FitnessPratice.WebForm.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Content Management</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Content Management</h1>
        <a href="Admin/PersonCollection.aspx">View Person List</a><br />
        <a href="Admin/InstructorCollection.aspx">View Instructor List</a><br />
        <a href="Admin/FitnessClassCollection.aspx">View Fitness Class List</a><br />
        <a href="Admin/EntityTypeCollection.aspx">View Entity Types</a><br />
        <a href="Admin/EmailCollection.aspx">View Email List</a><br />
    </div>
    </form>
</body>
</html>
