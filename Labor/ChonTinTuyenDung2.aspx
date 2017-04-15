<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChonTinTuyenDung2.aspx.cs" Inherits="Labor_ChonTinTuyenDung2" %>

<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CHỌN TIN TUYỂN DỤNG</title>
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
                    <input type="text" id="txtSearch" placeholder="Nhập mã hoặc tên doanh nghiệp để tìm kiếm" runat="server" class="form-control" />
                </td>
                <td style="width: 40px !important; text-align: center;">
                    <asp:ImageButton ID="btnSearch" ImageUrl="../images/Search.png" runat="server" Style="margin-bottom: -15px; margin-left: -15px;" OnClick="btnSearch_Click" />
                </td>
            </tr>
        </table>

        <div style="margin-top: -20px;">
            <div style="width: 100%;">
                <table class="DataListTableHeader" border="0">
                    <tr style="height: 40px;">
                        <td class="DataListTableHeaderTdItemJustify" style="width: 30%;">Tên doanh nghiệp
                        </td>
                        <td class="DataListTableHeaderTdItemJustify" style="width: 15%;">Người đại diện
                        </td>
                        <td class="DataListTableHeaderTdItemJustify" style="width: 20%;">Địa chỉ
                        </td>
                        <td class="DataListTableHeaderTdItemJustify" style="width: 15%;">Điện thoại
                        </td>
                        <td class="DataListTableHeaderTdItemJustify" style="width: 20%;">Vị trí tuyển dụng
                        </td>
                    </tr>
                </table>
            </div>

            <asp:DataList ID="dtlTuyenDung" runat="server" RepeatDirection="Horizontal" RepeatColumns="1"
                Width="100%">
                <ItemTemplate>
                    <table class="DataListTable" border="0">
                        <tr style="height: 40px;">
                            <td class="DataListTableTdItemJustify" style="width: 30%;">
                                <a href="#" onclick="return SetName('<%# Eval("IDDonVi") %>','<%# Eval("TenDonVi") %>','<%# Eval("NguoiDaiDien") %>','<%# Eval("DiaChi") %>','<%# Eval("DienThoai") %>');"><%# Eval("TenDonVi") %></a>
                            </td>
                            <td class="DataListTableTdItemJustify" style="width: 15%;">
                                <%# Eval("NguoiDaiDien") %>
                            </td>
                            <td class="DataListTableTdItemJustify" style="width: 20%;">
                                <%# Eval("DiaChi") %>
                            </td>
                            <td class="DataListTableTdItemJustify" style="width: 15%;">
                                <%# Eval("DienThoai") %>
                            </td>
                            <td class="DataListTableTdItemJustify" style="width: 20%;">
                                <%# Eval("NameChucVu") %>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
            <table width="100%" cellpadding="0" cellspacing="0" border="0" style="margin-top: 5px; background-color: #fbf4f4; height: 26px;"
                id="tblABC" runat="server">
                <tr>
                    <td style="padding-left: 6px;">
                        <cc1:CollectionPager ID="cpTuyenDung" runat="server" BackText="" FirstText="Đầu"
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
                    var txtNameId = window.opener.document.getElementById("MainContent_txtIDDonViTuyenDung");
                    txtNameId.value = value1;

                    var txtName = window.opener.document.getElementById("MainContent_txtDonViTuyenDungName");
                    txtName.value = value2;

                    var txtNguoiDaiDien = window.opener.document.getElementById("MainContent_txtNguoiDaiDien");
                    txtNguoiDaiDien.value = value3;

                    var txtDiaChi = window.opener.document.getElementById("MainContent_txtDiaChi");
                    txtDiaChi.value = value4;

                    var txtDienThoai = window.opener.document.getElementById("MainContent_txtDienThoai");
                    txtDienThoai.value = value5;
                }
                window.close();
            }
        </script>
    </form>
</body>
</html>
