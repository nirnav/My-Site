<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Create Event.aspx.cs" Inherits="WebApplication1.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Create Event Page</title>
    <link rel="stylesheet" type="text/css" href="style.css">
 <script type="text/javascript">
     function validateForm() {

         var form = document.forms["createEvent"];
         var name = form["name"].value;
         var loc = form["location"].value;
         var date = form["date"].value;
         var desc = form["description"].value;
         var sclass = form["Sclass"].value;
         var check = true;
        
         if ((username.length < 5) || (username.length > 50)) {
             alert("Your username should be between 5 and 50 characters long");
             check = false;
         }
         if (loc == null) {
             alert("Enter a location for your event");
             check = false;
         }
         if (date == null) {
             alert("Enter a date for your event");
             check = false;
         }
         if (desc == null) {
             alert("Enter a description for your event");
             check = false;
         }
         if (sclass == 'NA') {
             alert("Please choose a sailing class");
             check = false;
         }
         return check;
     }
    </script>
</head>
<body>
<h3>Create your own custom event!</h3>
<h5><%%></h5>
    <form id="createEvnet" runat="server" onsubmit="return validateForm()" method="post">
    <table>
        <tr>
       <td>Enter your event's name:</td>
        <td><input type="text" name="name"  placeholder="Name" /></td>
    </tr>
    <tr>
        <td>Enter a date for your event:</td>
        <td><input type="date" name="date" min="1979-12-31"/></td>
    </tr>
    <tr>
        <td>Enter the location for your event:</td>
        <td><input type="text" name="location" placeholder="Location" /></td>
    </tr>
    <tr>
        <td>Enter the sailing class for your event</td>
        <td><select name="Sclass" id="Sclass">
        <option value="NA">Choose a class</option>
        <option value="Laser 4.7">Laser 4.7</option>
        <option value="Laser Radial">Laser Radial</option>
        <option value="Laser Standard">Laser Standard</option>
        <option value="Optimist">Optimist</option>
        <option value="470">470</option>
        <option value="420">420</option>
        <option value="RS:X">RS:X</option>
        </select></td>
    </tr>
    </table>
    <div>
        <textarea name="description"cols="60" rows="20" placeholder="write a short description of your event."></textarea>
    </div>
    <div>
        <input type="submit" />
    </div>
    </form>
</body>
</html>
