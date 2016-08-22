<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Thanks.aspx.cs" Inherits="HTML_Forms.Thanks" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Thank You</title>
    <script type="text/javascript">
        function getValue(varname)
        {
            var url = window.location.href;
            var uparts = url.split("?");

            if (uparts.length == 0) { return ""; }
            
            var query = uparts[1];
            var vars = query.split("&");
            var value = "";
            for ( i = 0; i < vars.length; i++ )
            {
                var parts = vars[i].split("=");
                if( parts[0] == varname )
                {
                    value = parts[1];
                    break;
                }
            }

            value = unescape(value);
            value.replace(/\+/g, " ");
            return value;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <p>Thank you for clicking on the submit button</p>
        <table>
            <tr>
                <td>
                    You entered the First Name:
                </td>
                <td>
                    <script type="text/javascript">
                        var name = getValue("firstName");
                        document.write(name);
                    </script>
                </td>
                <td>
                    <script type="text/javascript">
                        var name = getValue("lastName");
                        document.write(name);
                    </script>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
