<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChonNguoiLaoDong2.aspx.cs" Inherits="Labor_ChonNguoiLaoDong2" %>

<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CHỌN NGƯỜI LAO ĐỘNG</title>
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
<body style="margin: 0px !important; height: 500px !important;">
    <form id="form1" runat="server">

        <table class="table">
            <tr>
                <td>
                    <input type="text" id="txtSearch" placeholder="Nhập mã hoặc tên người lao động để tìm kiếm" runat="server" class="form-control" />
                </td>
                <td style="width: 40px !important; text-align: center;">
                    <asp:ImageButton ID="btnSearch" ImageUrl="../images/Search.png" runat="server" Style="margin-bottom: -15px; margin-left: -15px;" OnClick="btnSearch_Click" />
                </td>
            </tr>
        </table>

        <div style="margin-top: -20px;">
            <div style="width: 100%; padding: 15px;">
                <table class="DataListTableHeader" border="0">
                    <tr style="height: 40px;">
                        <td class="DataListTableHeaderTdItemTT" style="width: 3%;">#
                        </td>
                        <td class="DataListTableHeaderTdItemJustify" style="width: 25%;">Họ và tên
                        </td>
                        <td class="DataListTableHeaderTdItemJustify" style="width: 59%;">Địa chỉ
                        </td>
                        <td class="DataListTableHeaderTdItemCenter" style="width: 13%;">Điện thoại
                        </td>
                    </tr>
                </table>
            </div>

            <div style="width: 100%; padding: 15px; margin-top: -28px;">
                <asp:DataList ID="dtlNguoiLaoDong" runat="server" RepeatDirection="Horizontal" RepeatColumns="1"
                    Width="100%">
                    <ItemTemplate>
                        <table class="DataListTable" border="0">
                            <tr style="height: 40px;">
                                <td class="DataListTableTdItemTT" style="width: 3%;">
                                    <%# Eval("TT") %>
                                </td>
                                <td class="DataListTableTdItemJustify" style="width: 25%;">
                                    <a href="#" onclick="return SetName('<%# Eval("IDNguoiLaoDong") %>','<%# Eval("HoVaTen") %>','<%# Eval("NgaySinh","{0:dd/MM/yyyy}") %>','<%# Eval("IDGioiTinh") %>','<%# Eval("DiaChi") %>','<%# Eval("CMND") %>','<%# Eval("DienThoai") %>');"><%# Eval("HoVaTen") %></a>
                                </td>
                                <td class="DataListTableTdItemJustify" style="width: 59%;">
                                    <%# Eval("DiaChi") %>
                                </td>
                                <td class="DataListTableTdItemCenter" style="width: 13%;">
                                    <%# Eval("DienThoai") %>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
                <table width="100%" cellpadding="0" cellspacing="0" border="0" style="margin-top: 5px; background-color: #fbf4f4; height: 26px;"
                    id="tblABC" runat="server">
                    <tr>
                        <td style="padding-left: 6px;">
                            <cc1:CollectionPager ID="cpNguoiLaoDong" runat="server" BackText="" FirstText="Đầu"
                                ControlCssClass="ProductPage" LabelText="" LastText="Cuối" NextText="" UseSlider="true"
                                ResultsFormat="" BackNextLinkSeparator="" ResultsLocation="None" BackNextLocation="None"
                                PageNumbersSeparator="&nbsp;">
                            </cc1:CollectionPager>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <script type="text/javascript">
            function SetName(value1, value2, value3, value4, value5, value6, value7) {
                if (window.opener != null && !window.opener.closed) {
                    var txtNameId = window.opener.document.getElementById("MainContent_txtIDNldDangKy");
                    txtNameId.value = value1;

                    var txtName = window.opener.document.getElementById("MainContent_txtNameNldDangKy");
                    txtName.value = value2;

                    var txtNgaySinh = window.opener.document.getElementById("MainContent_txtNgaySinh");
                    txtNgaySinh.value = value3;

                    var txtGioiTinh = window.opener.document.getElementById("MainContent_txtGioiTinh");
                    txtGioiTinh.value = value4.replace("1", "Nam").replace("2", "Nữ");

                    var txtNLDDiaChi = window.opener.document.getElementById("MainContent_txtNLDDiaChi");
                    txtNLDDiaChi.value = value5;

                    var txtCMND = window.opener.document.getElementById("MainContent_txtCMND");
                    txtCMND.value = value6;

                    var txtNLDDienThoai = window.opener.document.getElementById("MainContent_txtNLDDienThoai");
                    txtNLDDienThoai.value = value7;

                }
                window.close();
            }
        </script>
    </form>
</body>
</html>
