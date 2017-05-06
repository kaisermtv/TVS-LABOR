<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChonKhoaHoc1.aspx.cs" Inherits="Labor_ChonKhoaHoc1" %>

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
    <style>
        font {
            font-size: 14px;
        }
    </style>
</head>
<body style="margin: 0px !important; height: 600px !important;">
    <form id="form1" runat="server">
        <table class="table">
            <tr>
                <td>
                    <input type="text" id="txtSearch" placeholder="Nhập tên khóa học để tìm kiếm" runat="server" class="form-control" />
                </td>
                <td style="width: 40px !important; text-align: center;">
                    <asp:ImageButton ID="btnSearch" ImageUrl="../images/Search.png" runat="server" Style="margin-bottom: -15px; margin-left: -15px;" OnClick="btnSearch_Click" />
                </td>
            </tr>
        </table>

        <div style="margin-top: -60px; margin: 15px;">
            <div style="width: 100%;">
                <table class="DataListTableHeader" border="0" style="margin-top: -20px;">
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
                            <td class="DataListTableTdItemTT" style="width: 3%;">&nbsp;
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

            <input type="hidden" id="txtLoaiKhoaHoc" runat="server" />
            <input type="hidden" id="txtIdDtKhoaHoc" runat="server" />
            <input type="hidden" id="txtIDNguoiLaoDong" runat="server" />

        </div>

        <footer style="height: 160px !important; margin-bottom: 0px; width: 100%; text-align: justify; background-color: #f0f0f0;">
            <table style="margin-top: -10px; margin-left: -15px;">

                <tr style="height: 36px;">
                    <td style="width: 10%; text-align: right; padding-right: 5px; font-size: 14px;">Loại hình:</td>
                    <td style="width: 40%;">
                        <input id="txtTenLoaiKhoaHoc" readonly="true" style="background-color: #fff;" runat="server" class="form-control" />
                    </td>
                    <td style="width: 10%; text-align: right; padding-right: 5px; font-size: 14px;">Tên khóa học:</td>
                    <td style="width: 15%;">
                        <input id="txtNameKhoaHoc" readonly="true" style="background-color: #fff;" runat="server" class="form-control" />
                    </td>
                    <td style="width: 10%; text-align: right; padding-right: 5px; font-size: 14px;">Thời gian:</td>
                    <td style="width: 15%;">
                        <input id="txtThoiGian" readonly="true" style="background-color: #fff;" runat="server" class="form-control" />
                    </td>
                </tr>

                <tr style="height: 36px;">
                    <td style="width: 10%; text-align: right; padding-right: 5px; font-size: 14px;">Trường học:</td>
                    <td colspan="3">
                        <input id="txtTruongHoc" runat="server" class="form-control" />
                    </td>
                    <td style="width: 10%; text-align: right; padding-right: 5px; font-size: 14px;">Mức hỗ trợ:</td>
                    <td style="width: 15%;">
                        <input type="text" id="txtMucHoTro" readonly="true" style="background-color: #fff;" runat="server" class="form-control" />
                    </td>
                </tr>

                <tr style="height: 36px;">
                    <td style="width: 10%; text-align: right; padding-right: 5px; font-size: 14px;">Địa chỉ học:</td>
                    <td>
                        <input id="txtDiaChiHoc" runat="server" class="form-control" />
                    </td>
                    <td style="width: 10%; text-align: right; padding-right: 5px; font-size: 14px;">Khóa học:</td>
                    <td style="width: 15%;">
                        <input id="txtKhoaHoc" runat="server" class="form-control" />
                    </td>
                    <td style="width: 10%; text-align: right; padding-right: 5px; font-size: 14px;">ĐT liên hệ:</td>
                    <td style="width: 15%;">
                        <input id="txtDTLienHe" runat="server" class="form-control" />
                    </td>
                </tr>

                <tr style="height: 45px;">
                    <td style="width: 10%; text-align: right; padding-right: 5px;">&nbsp;</td>
                    <td style="width: 90%;" colspan="2">
                        <asp:Button ID="btnSave" runat="server" Text="Ghi nhận" CssClass="btn btn-primary" OnClick="btnSave_Click" OnClientClick="javascript:window.close();" />
                        <asp:Button ID="btnCancel" runat="server" Text="Thoát" CssClass="btn btn-default" OnClientClick="javascript:window.close();" />
                    </td>
                    <td colspan="2">
                        <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </table>
        </footer>
        <script type="text/javascript">
            function SetName(value1, value2, value3, value4, value5) {
                var txtNameId = window.document.getElementById("txtIdDtKhoaHoc");
                txtNameId.value = value1;

                var txtName = window.document.getElementById("txtNameKhoaHoc");
                txtName.value = value2;

                var txtThoiGian = window.document.getElementById("txtThoiGian");
                txtThoiGian.value = value3;

                var txtMucHoTro = window.document.getElementById("txtMucHoTro");
                txtMucHoTro.value = value4;

                var txtLoaiKhoaHoc = window.document.getElementById("txtLoaiKhoaHoc");
                txtLoaiKhoaHoc.value = value5;

                var txtTenLoaiKhoaHoc = document.getElementById("txtTenLoaiKhoaHoc");

                if (value5 == "1") {
                    txtTenLoaiKhoaHoc.value = "Học nghề";
                }
                else {
                    txtTenLoaiKhoaHoc.value = "Học tiếng";
                }
            }
        </script>
    </form>
</body>
</html>
