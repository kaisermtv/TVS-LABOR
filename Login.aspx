<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Admin_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ĐĂNG NHẬP HỆ THỐNG</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="Content/TVSStyle.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="css/Adminstyle.css" />
    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>
    <webopt:BundleReference runat="server" Path="~/Content/css" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <style>
        .frmLogin {
            width: 500px;
            margin: 0 auto;
            border-radius: 5px;
            background: #40486f;
            padding: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server">
            <Scripts>
                <%--To learn more about bundling scripts in ScriptManager see http://go.microsoft.com/fwlink/?LinkID=301884 --%>
                <%--Framework Scripts--%>
                <asp:ScriptReference Name="MsAjaxBundle" />
                <asp:ScriptReference Name="jquery" />
                <asp:ScriptReference Name="bootstrap" />
                <asp:ScriptReference Name="respond" />
                <asp:ScriptReference Name="WebForms.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebForms.js" />
                <asp:ScriptReference Name="WebUIValidation.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebUIValidation.js" />
                <asp:ScriptReference Name="MenuStandards.js" Assembly="System.Web" Path="~/Scripts/WebForms/MenuStandards.js" />
                <asp:ScriptReference Name="GridView.js" Assembly="System.Web" Path="~/Scripts/WebForms/GridView.js" />
                <asp:ScriptReference Name="DetailsView.js" Assembly="System.Web" Path="~/Scripts/WebForms/DetailsView.js" />
                <asp:ScriptReference Name="TreeView.js" Assembly="System.Web" Path="~/Scripts/WebForms/TreeView.js" />
                <asp:ScriptReference Name="WebParts.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebParts.js" />
                <asp:ScriptReference Name="Focus.js" Assembly="System.Web" Path="~/Scripts/WebForms/Focus.js" />
                <asp:ScriptReference Name="WebFormsBundle" />
                <%--Site Scripts--%>
            </Scripts>
        </asp:ScriptManager>
        <div class="container" style ="padding-top:100px;">
            <div class="row">
                <div class="col-md-12">
                    <div class="frmLogin">
                        <div class="form-group">
                            <label class="sr-only" for="email">Email address:</label>
                            <input runat = "server" type="text" class="form-control" id="txtUserName" placeholder="Tên tài khoản" style ="width:460px !important; max-width:500px !important;"/>
                        </div>
                        <div class="form-group">
                            <label class="sr-only" for="pwd">Password:</label>
                            <input runat = "server" type="password" class="form-control" id="txtPassWord" placeholder="Mật khẩu" style ="width:460px !important; max-width:500px !important;"/>
                        </div>
                        <asp:Label ID="lblMsg" runat="server" Text="-:-" ForeColor ="Red"></asp:Label>
                        <br />
                        <br />
                        <asp:Button runat = "server" CssClass="btn btn-primary" style ="width:110px !important; max-width:110px !important;" Text ="Đăng nhập" ID = "btnLogin" OnClick="btnLogin_Click"></asp:Button>
                        &nbsp;&nbsp;<a href ="../"><input type ="button" class ="btn btn-default" value ="Trang chủ"></a>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
