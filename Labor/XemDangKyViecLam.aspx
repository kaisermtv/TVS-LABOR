<%@ Page Language="C#" AutoEventWireup="true" CodeFile="XemDangKyViecLam.aspx.cs" Inherits="Labor_XemDangKyViecLam" %>

<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>XEM TIN GIỚI THIỆU VIỆC LÀM</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="../css/TVSStyle.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="../css/Adminstyle.css" />
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel='stylesheet' type='text/css' />
    <!-- Custom CSS -->
    <link href="../css/style.css" rel='stylesheet' type='text/css' />
    <!-- Graph CSS -->
    <link href="../css/font-awesome.css" rel="stylesheet" />
    <!-- jQuery -->
    <!-- lined-icons -->
    <link rel="stylesheet" href="../css/icon-font.min.css" type='text/css' />
</head>
<body style="margin: 0px !important; height:600px!important;"  onkeypress="ESC_Press(event)">
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server">
        </asp:ScriptManager>
       <table class="table" style="margin-top:0px;">
        <tr>
            <td>
                <input type="text" id="txtSearch" placeholder="Nhập mã hoặc tên doanh nghiệp để tìm kiếm" runat="server" class="form-control" />
            </td>
            <td style="width: 40px !important; text-align: center;">
                <asp:ImageButton ID="btnSearch" ImageUrl="../images/Search.png" runat="server" Style="margin-bottom: -15px; margin-left: -15px;" OnClick="btnSearch_Click" />
            </td>
        </tr>
    </table>

    <div style="width: 100%; margin-top:-20px;">
        <table class="DataListTableHeader" border ="0">
            <tr style ="height:40px;">
                <td class="DataListTableHeaderTdItemTT" style="width: 3%;">#
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 15%;">Người lao động
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 46%;">Tên công ty
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 15%;">Vị trí giới thiệu
                </td>
                <td class="DataListTableHeaderTdItemCenter" style="width: 10%;">Ngày giới thiệu
                </td>
                <td class="DataListTableHeaderTdItemCenter" style="width: 10%;">Ngày nhận việc
                </td>
            </tr>
        </table>
    </div>

    <asp:DataList ID="dtlGioiThieuViecLam" runat="server" RepeatDirection="Horizontal" RepeatColumns="1"
        Width="100%">
        <ItemTemplate>
            <table class="DataListTable" border="0">
                <tr style ="height:40px;">
                    <td class="DataListTableTdItemTT" style="width: 3%;">
                        <%# Eval("TT") %>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 15%;">
                        <%# Eval("HoVaTen") %>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 46%;">
                        <%# Eval("TenDonVi") %>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 15%;">
                        <%# Eval("NameChucVu") %>
                    </td>
                    <td class="DataListTableTdItemCenter" style="width: 10%;">
                        <%# Eval("NgayGioiThieu","{0:dd/MM/yyyy}") %>
                    </td>
                    <td class="DataListTableTdItemCenter" style="width: 10%;">
                        <%# Eval("NgayNhanViec","{0:dd/MM/yyyy}") %>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
    <table width="100%" cellpadding="0" cellspacing="0" border="0" style="margin-top: 5px; background-color: #fbf4f4; height: 26px;"
        id="tblABC" runat="server">
        <tr>
            <td style="padding-left: 6px;">
                <cc1:CollectionPager ID="cpGioiThieuViecLam" runat="server" BackText="" FirstText="Đầu"
                    ControlCssClass="ProductPage" LabelText="" LastText="Cuối" NextText="" UseSlider="true"
                    ResultsFormat="" BackNextLinkSeparator="" ResultsLocation="None" BackNextLocation="None"
                    PageNumbersSeparator="&nbsp;">
                </cc1:CollectionPager>
            </td>
        </tr>
    </table>
    </form>
    <script src="../js/TvsProcessPage.js"></script>
</body>
</html>
