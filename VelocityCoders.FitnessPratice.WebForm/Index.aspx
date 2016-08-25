<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="VelocityCoders.FitnessPratice.WebForm.Index" %>
<!-- STEP-1: WHEN THE SERVER RECIEVES THE REQUEST FOR THIS PAGE, THIS META-DATA AT TOP TELLS THE BROWSER -->
<!-- THERE IS SERVER-SIDE CODE TO EXECUTE, .CS FILE, BEFORE CONTINUING TO LOAD THIS HTML PAGE -->
<!-- STEP 3.2: AND RETURN HERE TO CONTINUE TO RENDER THE REMAINING CONTENT ON THIS HTML PAGE -->

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Content Management</title>
    <style>
        a { padding: 4px 12px 4px 0; display: inline-block; text-decoration: none; font-size: 21px;}
        a:hover { color: #ff6a00; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Content Management</h1><br />
        <a href="Admin/PersonCollection.aspx">View Person List</a><br />
        <a href="Admin/Instructors/InstructorCollection.aspx">View Instructor List</a><br />
        <a href="Admin/FitnessClassCollection.aspx">View Fitness Class List</a><br />
        <a href="Admin/EntityTypeCollection.aspx">View Entity Types</a><br />
        <a href="Admin/EmailCollection.aspx">View Email List</a><br />
    </div>
    </form>
</body>
</html>
