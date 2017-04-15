<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QuaTrinhDaoTao.aspx.cs" Inherits="Admin_QuaTrinhDaoTao" %>

<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>QUÁ TRÌNH ĐÀO TẠO</title>
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
        <div style="width: 100%;">
            <table class="DataListTableHeader" border="0">
                <tr style="height: 40px;">
                    <td class="DataListTableHeaderTdItemTT" style="width: 4%;">#
                    </td>
                    <td class="DataListTableHeaderTdItemJustify" style="width: 40%;">Chuyên ngành
                    </td>
                    <td class="DataListTableHeaderTdItemJustify" style="width: 21%;">Trình độ chuyên môn
                    </td>
                    <td class="DataListTableHeaderTdItemCenter" style="width: 15%;">Ngày bắt đầu
                    </td>
                    <td class="DataListTableHeaderTdItemCenter" style="width: 15%;">Ngày kết thúc
                    </td>
                </tr>
                <tr style="height: 40px;">
                    <td class="DataListTableHeaderTdItemTT" style="width: 4%;"></td>
                    <td class="DataListTableHeaderTdItemJustify" style="width: 40%;">
                        <asp:TextBox ID="txtDonVi" runat="server" class="AdminTextControl"></asp:TextBox>
                    </td>
                    <td class="DataListTableHeaderTdItemJustify" style="width: 21%;">
                        <asp:DropDownList ID="ddlTrinhDoChuyenMon" AutoPostBack="true" runat="server" Style="width: 100%; height: 30px; line-height: 30px;">
                        </asp:DropDownList>
                    </td>
                    <td class="DataListTableHeaderTdItemCenter" style="width: 15%;">
                        <div class='input-group date' id='datetimepicker1' style="margin-left: 0px; width: 95% !important; float: right;">
                            <input type='text' class="form-control" id="txtNgayBatDau" runat="server" />
                            <span class="input-group-addon">
                                <span class="glyphicon glyphicon-calendar"></span>
                            </span>
                        </div>

                        <script type="text/javascript">
                            $(function () {
                                $('#datetimepicker1').datetimepicker();
                            });
                        </script>
                    </td>
                    <td class="DataListTableHeaderTdItemCenter" style="width: 15%;">
                        <div class='input-group date' id='datetimepicker2' style="margin-left: 0px; width: 95% !important; float: right;">
                            <input type='text' class="form-control" id="txtNgayKetThuc" runat="server" />
                            <span class="input-group-addon">
                                <span class="glyphicon glyphicon-calendar"></span>
                            </span>
                        </div>

                        <script type="text/javascript">
                            $(function () {
                                $('#datetimepicker2').datetimepicker();
                            });
                        </script>
                    </td>
                </tr>

                <tr style="height: 44px;">
                    <td></td>
                    <td colspan="3" style="padding-left: 10px; padding-bottom: 8px;">
                        <asp:Button ID="btnSave" runat="server" Text="Ghi nhận" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                        <asp:Button ID="btnAdd" runat="server" Text="Thêm mới" CssClass="btn btn-success" OnClick="btnAdd_Click" />
                        &nbsp;&nbsp;
                        <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
                    </td>
                    <td style="text-align: right; padding-bottom: 8px;">
                        <asp:Button ID="btnDel" runat="server" Text="Xóa mục" CssClass="btn btn-primary" OnClick="btnDel_Click" /></td>
                </tr>

            </table>
        </div>

        <asp:DataList ID="dtlNldQuaTrinhDaoTao" runat="server" RepeatDirection="Horizontal" RepeatColumns="1"
            Width="100%">
            <ItemTemplate>
                <table class="DataListTable" border="0">
                    <tr style="height: 40px;">
                        <td class="DataListTableTdItemTT" style="width: 4%;">
                            <%# Eval("TT") %>
                        </td>
                        <td class="DataListTableTdItemJustify" style="width: 40%;">
                            <a href = "?id=<%# Eval("IDNguoiLaoDong") %>&idDT=<%# Eval("IDNldQuaTrinhDaoTao") %>"><%# Eval("Donvi") %>
                        </td>
                        <td class="DataListTableTdItemJustify" style="width: 21%;">
                            <%# Eval("NameTrinhdoChuyenMon") %>
                        </td>
                        <td class="DataListTableTdItemCenter" style="width: 15%;">
                            <%# Eval("NgayBatDau","{0:dd/MM/yyyy}") %>
                        </td>
                        <td class="DataListTableTdItemCenter" style="width: 15%;">
                            <%# Eval("NgayKetThuc","{0:dd/MM/yyyy}") %>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>
        <table width="100%" cellpadding="0" cellspacing="0" border="0" style="margin-top: 5px; background-color: #fbf4f4; height: 26px;"
            id="tblABC" runat="server">
            <tr>
                <td style="padding-left: 6px;">
                    <cc1:CollectionPager ID="cpNldQuaTrinhDaoTao" runat="server" BackText="" FirstText="Đầu"
                        ControlCssClass="ProductPage" LabelText="" LastText="Cuối" NextText="" UseSlider="true"
                        ResultsFormat="" BackNextLinkSeparator="" ResultsLocation="None" BackNextLocation="None"
                        PageNumbersSeparator="&nbsp;">
                    </cc1:CollectionPager>
                </td>
            </tr>
        </table>

    </form>
</body>
</html>
