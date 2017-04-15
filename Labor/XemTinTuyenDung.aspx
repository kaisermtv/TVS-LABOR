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
                <table class="DataListTableHeader" border="0">
                    <tr style="height: 40px;">
                        <td class="DataListTableHeaderTdItemTT" style="width: 3%;">#
                        </td>
                        <td class="DataListTableHeaderTdItemJustify" style="width: 32%;">Tên doanh nghiệp
                        </td>
                        <td class="DataListTableHeaderTdItemJustify" style="width: 28%;">Mô tả
                        </td>
                        <td class="DataListTableHeaderTdItemJustify" style="width: 12%;">Vị trí
                        </td>
                        <td class="DataListTableHeaderTdItemJustify" style="width: 17%;">Mức lương
                        </td>
                        <td class="DataListTableHeaderTdItemCenter" style="width: 8%;">Số lượng
                        </td>
                    </tr>
                </table>
            </div>

            <asp:DataList ID="dtlTuyenDung" runat="server" RepeatDirection="Horizontal" RepeatColumns="1"
                Width="100%">
                <ItemTemplate>
                    <table class="DataListTable" border="0">
                        <tr style="height: 40px;">
                            <td class="DataListTableTdItemTT" style="width: 3%;">
                                <%# Eval("TT") %>
                            </td>
                            <td class="DataListTableTdItemJustify" style="width: 32%;">
                                <a href="#" onclick="return ItemSelect('<%# Eval("IDTuyenDung") %>','<%# Eval("IDDonVi") %>','<%# Eval("IDChucVu") %>','<%# Eval("TenDonVi") %>','<%# Eval("NameChucVu") %>');"><%# Eval("TenDonVi") %></a>
                            </td>
                            <td class="DataListTableTdItemJustify" style="width: 28%;">
                                <%# Eval("Mota") %>
                            </td>
                            <td class="DataListTableTdItemJustify" style="width: 12%;">
                                <%# Eval("NameChucVu") %>
                            </td>
                            <td class="DataListTableTdItemJustify" style="width: 17%;">
                                <%# Eval("NameMucLuong") %>
                            </td>
                            <td class="DataListTableTdItemCenter" style="width: 8%;">
                                <%# Eval("SoLuongTuyenDung") %>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
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
        </script>
    </form>
</body>
</html>
