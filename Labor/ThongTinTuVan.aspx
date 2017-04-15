<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ThongTinTuVan.aspx.cs" Inherits="Admin_ThongTinTuVan" %>

<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>THÔNG TIN TƯ VẤN</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="../css/TVSStyle.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="../css/Adminstyle.css" />
    <!-- Bootstrap Core CSS -->
    <link href="css/bootstrap.min.css" rel='stylesheet' type='text/css' />
    <!-- Custom CSS -->
    <link href="css/style.css" rel='stylesheet' type='text/css' />
    <!-- Graph CSS -->
    <link href="css/font-awesome.css" rel="stylesheet" />
    <!-- jQuery -->
    <!-- lined-icons -->
    <link rel="stylesheet" href="css/icon-font.min.css" type='text/css' />
    <!-- DateTime Picker -->
    <link rel="stylesheet" type="text/css" media="screen" href="../Content/bootstrap.min.css" />
    <link href="../Content/bootstrap-datetimepicker.css" rel="stylesheet" />
    <script src="../Scripts/bootstrap.min.js"></script>
    <script src="../Scripts/jquery-2.1.1.min.js"></script>
    <script src="../Scripts/moment-with-locales.js"></script>
    <script src="../Scripts/bootstrap-datetimepicker.js"></script>
    <!-- -->
</head>
<body style="margin: 0px !important; height: 500px !important;">
     <script type="text/javascript">
         $(function () {
             $('#datetimepicker1').datetimepicker({
                 format: 'DD/MM/YYYY'
             });
         });

         $(function () {
             $('#datetimepicker2').datetimepicker({
                 format: 'DD/MM/YYYY'
             });
         });

    </script>
    <form id="form1" runat="server">
       
        
    </form>
</body>
</html>
