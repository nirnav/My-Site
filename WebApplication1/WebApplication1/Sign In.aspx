<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sign In.aspx.cs" Inherits="WebApplication1.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sign In</title>
</head>
<body>
    <h3>Sign In Page</h3>
    <p>Enter your user name and password to sign in.<br /> Not a member? Sign up <a href = "Sign Up.aspx"><u> here. </u></a></p>

    <form id="signin" runat="server">
    <div>
        <input type="text" name="Username" placeholder="Username" />
    </div>
    <div>
        <input type="password" name="Password"  placeholder="Password" />
    </div>
    <div>
        <input type="submit" />
    </div>
    </form>
    <h5> <%=failed%></h5>
</body>
</html>
