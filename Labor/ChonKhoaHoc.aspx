<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChonKhoaHoc.aspx.cs" Inherits="Labor_ChonKhoaHoc" %>

<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CHỌN KHÓA HỌC</title>
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
<body style="margin: 0px !important; height: 600px !important;">
    <form id="form1" runat="server">
         <table class ="table">
            <tr>
                <td>
                    <input type ="text" id = "txtSearch" placeholder ="Nhập tên khóa học để tìm kiếm" runat ="server" class ="form-control" />
                </td>
                <td style ="width:40px !important; text-align:center;">
                    <asp:ImageButton ID="btnSearch" ImageUrl="../images/Search.png" runat="server" Style="margin-bottom: -15px; margin-left:-15px;" OnClick="btnSearch_Click" />
                </td>
            </tr>
        </table>
       
        <div style ="margin-top:-20px;">
            <div style="width: 100%;">
                <table class="DataListTableHeader" border="0">
                    <tr style="height: 40px;">
                        <td class="DataListTableHeaderTdItemTT" style="width: 3%;">#
                        </td>
                        <td class="DataListTableHeaderTdItemJustify" style="width: 42%;">Tên khóa học
                        </td>
                        <td class="DataListTableHeaderTdItemJustify" style="width: 42%;">Thời gian
                        </td>
                        <td class="DataListTableHeaderTdItemCenter" style="width: 13%;">Mức hỗ trợ
                        </td>
                    </tr>
                </table>
            </div>

            <asp:DataList ID="dtlKhoaHoc" runat="server" RepeatDirection="Horizontal" RepeatColumns="1"
                Width="100%">
                <ItemTemplate>
                    <table class="DataListTable" border="0">
                        <tr style="height: 40px;">
                            <td class="DataListTableTdItemTT" style="width: 3%;">
                               &nbsp;
                            </td>
                            <td class="DataListTableTdItemJustify" style="width: 42%;">
                                <a href="#" onclick="return SetName('<%# Eval("IdDtKhoaHoc") %>','<%# Eval("NameKhoaHoc") %>','<%# Eval("ThoiGianHoc") %>','<%# Eval("MucHoTro") %>','<%# Eval("LoaiKhoaHoc") %>');"><%# Eval("NameKhoaHoc") %></a>
                            </td>
                            <td class="DataListTableTdItemJustify" style="width: 42%;">
                                <%# Eval("ThoiGianHoc") %>
                            </td>
                            <td class="DataListTableTdItemRight" style="width: 13%;">
                                <%# Eval("MucHoTro","{0:0,0}") %>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
            <table width="100%" cellpadding="0" cellspacing="0" border="0" style="margin-top: 5px; height: 26px;"
                id="tblABC" runat="server">
                <tr>
                    <td style="padding-left: 6px;">
                        <cc1:CollectionPager ID="cpKhoaHoc" runat="server" BackText="" FirstText="Đầu"
                            ControlCssClass="ProductPage" LabelText="" LastText="Cuối" NextText="" UseSlider="true"
                            ResultsFormat="" BackNextLinkSeparator="" ResultsLocation="None" BackNextLocation="None"
                            PageNumbersSeparator="&nbsp;">
                        </cc1:CollectionPager>
                    </td>
                </tr>
            </table>

        </div>
        <script type="text/javascript">
            function SetName(value1, value2, value3, value4, value5) {
                if (window.opener != null && !window.opener.closed) {
                    var txtNameId = window.opener.document.getElementById("MainContent_txtIdDtKhoaHoc");
                    txtNameId.value = value1;

                    var txtName = window.opener.document.getElementById("MainContent_txtNameKhoaHoc");
                    txtName.value = value2;

                    var txtThoiGian = window.opener.document.getElementById("MainContent_txtThoiGian");
                    txtThoiGian.value = value3;

                    var txtMucHoTro = window.opener.document.getElementById("MainContent_txtMucHoTro");
                    txtMucHoTro.value = value4;

                    var txtLoaiKhoaHoc = window.opener.document.getElementById("MainContent_txtLoaiKhoaHoc");
                    txtLoaiKhoaHoc.value = value5;

                    var txtTenLoaiKhoaHoc = window.opener.document.getElementById("MainContent_txtTenLoaiKhoaHoc");

                    if (value5 == "1") {
                        txtTenLoaiKhoaHoc.value = "Học nghề";
                    }
                    else {
                        txtTenLoaiKhoaHoc.value = "Học tiếng";
                    }
                }
                window.close();
            }
        </script>
    </form>
</body>
</html>
