<%@ Page Language="C#" AutoEventWireup="true" CodeFile="XemTinTuyenDung.aspx.cs" Inherits="Labor_XemTinTuyenDung" %>

<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>XEM TIN TUYỂN DỤNG</title>
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
        .DataListTable td{
            padding-top:5px;
            padding-bottom:5px;
        }
    </style>
</head>
<body style="margin: 0px !important;">
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server">
        </asp:ScriptManager>
        <table class="table" border="0">
            <tr>
                <td>
                    <input type="text" id="txtSearch" placeholder="Tên công việc cần tìm kiếm" runat="server" class="form-control" />
                </td>
                <td style="width: 200px; padding-right: 0px;">
                    <asp:DropDownList ID="ddlIDChucVu" runat="server" CssClass="form-control" Style="width: 100%;">
                    </asp:DropDownList></td>
                <td style="width: 250px; padding-right: 0px;">
                    <asp:DropDownList ID="ddlMucLuong" runat="server" CssClass="form-control" Style="width: 100%;">
                    </asp:DropDownList></td>
                <td style="width: 40px !important; text-align: center;">
                    <asp:ImageButton ID="btnSearch" ImageUrl="../images/Search.png" runat="server" Style="margin-bottom: -15px; margin-left: -15px;" OnClick="btnSearch_Click" />
                </td>
            </tr>
        </table>

        <div style="margin-top: -20px;">
            <div style="width: 100%;">
                <asp:Repeater ID="dtlTuyenDung" runat="server" EnableViewState="False">
                    <HeaderTemplate>
                        <table class="DataListTable" border="0">
                            <tr style="height: 40px;" class="DataListTableHeader">
                                <td class="DataListTableHeaderTdItemTT" style="width: 3%;">#</td>
                                <td class="DataListTableHeaderTdItemJustify" style="width: 10%;">Ngày bắt đầu</td>
                                <td class="DataListTableHeaderTdItemJustify" style="width: 28%;">Tên doanh nghiệp</td>
                                <td class="DataListTableHeaderTdItemJustify" style="width: 15%;">Vị trí tuyển</td>
                                <td class="DataListTableHeaderTdItemCenter" style="width: 8%;">Số lượng</td>
                                <td class="DataListTableHeaderTdItemJustify" style="width: 17%;">Mức lương</td>
                                <td class="DataListTableHeaderTdItemJustify">Địa điểm làm việc</td>
                                <td>::</td>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td class="DataListTableTdItemTT"><%# this.index++ %></td>
                            <td class="DataListTableTdItemJustify"><%# ((DateTime)Eval("NgayBatDau")).ToString("dd/MM/yyyy") %></td>
                            <td class="DataListTableTdItemJustify">
                                <a href="#" onclick="return ItemSelect('<%# Eval("IDTuyenDung") %>','<%# Eval("IDDonVi") %>','<%# Eval("IdViTri") %>','<%# Eval("TenDonVi") %>','<%# Eval("NameVitri") %>');"><%# Eval("TenDonVi") %></a>
                                &nbsp;<a href ="#"><img src ="../Images/View.png" style ="margin-top:-3px;"></a>
                            </td>
                            <td class="DataListTableTdItemJustify"><%# Eval("NameVitri") %>&nbsp;<a href ="#"><img src ="../Images/View.png" style ="margin-top:-3px;"></a></td>
                            <td class="DataListTableTdItemCenter">
                                <%# Eval("SoLuongTuyenDung") %>
                                &nbsp;<a href ="#"><div onclick="XemTinTuyenDung('<%# Eval("IdTuyenDung") %>','<%# Eval("CountItem") %>')" class="badge"><%# Eval("CountItem") %></div></a>
                            </td>
                            <td class="DataListTableTdItemJustify"><%# Eval("NameMucLuong") %></td>
                            <td class="DataListTableTdItemJustify"><%# Eval("DiaDiem") %></td>
                            <td>
                                123
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
            <table width="100%" cellpadding="0" cellspacing="0" border="0" style="margin-top: 5px; height: 26px;"
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
            <br />
            <input type="hidden" id="txtIDTuyenDung" class="form-control" runat="server" />
            <input type="text" id="txtTenDonVi" class="form-control" runat="server" style="width: 72%; float: left; margin-left:15px; margin-right:10px;" />
            <input type="text" id="txtNameChucVu" class="form-control" runat="server" style="width: 24%; margin-left: 10px!important; margin-right:15px;" />
            <br />
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Button ID="btnSave" runat="server" Text="Lưu thông tin" CssClass="btn btn-primary" Style="margin-left: 15px; margin-top: -10px;" OnClick="btnSave_Click" OnClientClick="javascript:window.close();" />&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel>
            <input type="hidden" id="txtIDDonVi" runat="server" />
            <input type="hidden" id="txtIDChucVu" runat="server" />
        </div>

        <script type="text/javascript">
            function ItemSelect(IDTuyenDung, IDDonVi, IDChucVu, TenDonVi, NameChucVu) {

                var txtIDTuyenDung = document.getElementById("txtIDTuyenDung");
                txtIDTuyenDung.value = IDTuyenDung;

                var txtIDDonVi = document.getElementById("txtIDDonVi");
                txtIDDonVi.value = IDDonVi;

                var txtIDChucVu = document.getElementById("txtIDChucVu");
                txtIDChucVu.value = IDChucVu;

                var txtTenDonVi = document.getElementById("txtTenDonVi");
                txtTenDonVi.value = TenDonVi;

                var txtNameChucVu = document.getElementById("txtNameChucVu");
                txtNameChucVu.value = NameChucVu;
            }

            function XemTinTuyenDung(value, count) {

                if (count == 0) {
                    return;
                }
                else {
                    var w = 1000;
                    var h = 620;

                    var dualScreenLeft = window.screenLeft != undefined ? window.screenLeft : screen.left;
                    var dualScreenTop = window.screenTop != undefined ? window.screenTop : screen.top;

                    var width = window.innerWidth ? window.innerWidth : document.documentElement.clientWidth ? document.documentElement.clientWidth : screen.width;
                    var height = window.innerHeight ? window.innerHeight : document.documentElement.clientHeight ? document.documentElement.clientHeight : screen.height;

                    var left = ((width / 2) - (w / 2)) + dualScreenLeft;
                    var top = ((height / 2) - (h / 2)) + dualScreenTop;
                    var newWindow = window.open("XemDangKyViecLam.aspx?id=" + value, "TIN TUYỂN DỤNG", 'scrollbars=yes, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);

                    if (window.focus) {
                        newWindow.focus();
                    }
                }
            }
    </script>

    </form>
</body>
</html>
