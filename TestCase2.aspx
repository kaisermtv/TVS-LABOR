<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestCase2.aspx.cs" Inherits="TestCase2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>



</head>
<body>
    <form id="form1" runat="server">
    <div>
    

          <h2>Select Box with Search Option Jquery Select2.js</h2>


 <select class="js-example-basic-multiple" multiple="multiple" style="height:500px">

	  <option>Laravel</option>

	  <option>Laravel ACL</option>

	  <option>Laravel PDF</option>

	  <option>Laravel Helper</option>

	  <option>Laravel API</option>

	  <option>Laravel CRUD</option>

	  <option>Laravel Angural JS Crud</option>

	  <option>C++</option>

  </select>


</div>

<script type="text/javascript">
    $(".js-example-basic-multiple").select2();
</script>

    </div>
    </form>
</body>
</html>
