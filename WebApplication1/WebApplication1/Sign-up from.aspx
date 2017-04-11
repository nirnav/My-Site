<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sign-up from.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SignUp</title>
    <script type="text/javascript">
        function validateForm() {
          
            var form = document.forms["signup"];
            var username = form["Username"].value;
            var fullname = form["FullName"].value;
            var email = form["Email"].value;
            var password = form["Password"].value;
            var password2 = form["Password2"].value;
            var sclass = form["Sclass"].value;
            var check = true;
          
            if (sclass == null)
            {
                alert("Please choose your sailing class");
                check = false;
            }
            if ((username.length < 3) || (username.length > 24))
            {
                alert("Your username should be between 6 and 24 characters long");
                check = false;
            }
            if (password.length < 8)
            {
                alert("Your password should be 8 characters or more");
                check = false;
            }
            if (password != password2)
            {
                alert("Password and validation do not match");
                check = false;
            }
            if (!validateEmail(email))
            {
                alert("Enter a valid email address");
                check = false;
            }
            return check;
            
    }
    function validateEmail(email) {
    var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(email);
}
    </script>
</head>
<body>
<h3>SignUp Form</h3>
<h5><%=messege%></h5>
    <form id="signup" runat="server" onsubmit="return validateForm()" method="post">
    <div>
        <input type="text" name="FullName" placeholder="Full Name" />
    </div>
    <div>
        <input type="text" name="Username"  placeholder="Username" />
    </div>
    <div>
        <input type="text" name="Email" placeholder="E-mail" />
    </div>
    <div>
        <input type="password" name="Password" placeholder="Password" />
    </div>
    <div>
        <input type="password" name="Password2" placeholder="Password Confirmation" />
    </div>
    <div>
        <select name="Sclass" id="Sclass">
        <option value="laser 4.7">Laser 4.7</option>
        <option value="laser Radial">Laser Radial</option>
        <option value="laser Standard">Laser Standard</option>
        <option value="optimist">Optimist</option>
        <option value="470">470</option>
        <option value="420">420</option>
        <option value="RS:x">RS:X</option>
        </select>
    </div>
    <div>
        <input type="submit" />
    </div>
    </form>
</body>
</html>
