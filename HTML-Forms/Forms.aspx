<%@ Page Language="C#" AutoEventWireup="true" Theme="Main" CodeBehind="Forms.aspx.cs" Inherits="HTML_Forms.Forms" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div class="form">
        <form id="form1" runat="server" action="Thanks.aspx" method="get" >
            <div class="datagrid" >
            
              <table id="table1">
                <caption>Administrator Input</caption>
                <thead>
                    <tr>
                        <th>Item</th>
                        <th>Selection</th>
                    </tr>
                </thead>
                <tbody>
                <tr id="tr1">
                    <td id="tr1td1">First Name:</td>
                    <td id="tr1td2">
                        <input type="text" name="firstName" />
                    </td>
                </tr>
                <tr id="tr2"> 
                    <td id="tr2td1">Last Name:</td>
                    <td id="tr2td2">
                        <input type="text" name="lastName" />
                    </td>
                </tr>
                <tr>
                    <td>Pay Grade:</td>
                    <td>
                        <select name="grade">
                            <option value="admin">Admin</option>
                            <option value="admin2">Admin 2</option>
                            <option value="admin3">Admin 3</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>Date of Hire:</td>
                    <td>
                        <input type="date" name="dateHire" />
                    </td>
                </tr>
                <tr>
                    <td>Date of Termination:</td>
                    <td>
                        <input type="date" name="dateTerm" />
                    </td>
                </tr>
                <tr>
                    <td>Comments:</td>
                    <td colspan="2">
                        <textarea name="comments" rows="4" cols="25"></textarea>
                    </td>
                </tr>
                <tr>
                    <td>Marital Status:</td>
                    <td>
                        <input type="radio" name="marital" value="single" /><span>Single</span><br />
                        <input type="radio" name="marital" value="married" /><span>Married</span><br />
                        <input type="radio" name="marital" value="divorced" /><span>Divorced</span><br />
                        <input type="radio" name="marital" value="other" /><span>Other</span><br />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        Terminate Employee: 
                        <input type="checkbox" name="chkTerm" value="term" />
                    </td>
                </tr>
                </tbody>
              </table>
              </div>
            </form>
        <center><input  class="btn" type="submit" value="Submit Form"/></center>
    </div>
</body>
</html>
