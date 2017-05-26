<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TuVanXuatKhauNhatKy.aspx.cs" Inherits="Labor_TuVanXuatKhauNhatKy" %>

<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>NHẬT KÝ TƯ VẤN XUẤT KHẨU LAO ĐỘNG</title>
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
    <script src="../js/jquery.maskedinput.js" type="text/javascript"></script>
</head>
<body style="margin: 0px !important; height: 500px !important; padding: 10px;">
    <script type="text/javascript">
        $(function () {
            $('#datetimepicker1').datetimepicker({
                format: 'DD/MM/YYYY'
            });
        });

    </script>

    <script type="text/javascript">
        jQuery(function ($) {
            $("#MainContent_txtNgayNhatKy").mask("99/99/9999", { placeholder: "DD/MM/yyyy" });
        });

    </script>
    <form id="form1" runat="server">
        <table class="DataListTable" border="0">

            <tr style="height: 40px; border-top: solid 1px #808080;">
                <td class="DataListTableHeaderTdItemJustify" style="width: 4%; font-weight: bold;">TT
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 16%; font-weight: bold;">Ngày ghi nhận
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="font-weight: bold;">Trạng thái / Nội dung
                </td>
            </tr>

            <asp:Repeater ID="dtlNldQuatrinhCongTac" runat="server">
                <ItemTemplate>

                    <tr style="height: 40px;">
                        <td class="DataListTableTdItemTT">
                            <%# Eval("TT") %>
                        </td>
                        <td class="DataListTableTdItemJustify">
                            <%# ((DateTime)Eval("NgayNhatKy")).ToString("dd/MM/yyyy") %>
                        </td>
                         <td class="DataListTableTdItemJustify">
                            <a href="?id=<%# Eval("IDNldXuatKhauNhatKy") %>&idXK=<%# Eval("IDNldXuatKhau") %>"><%# Eval("Note") %>
                        </td>
                    </tr>

                </ItemTemplate>
            </asp:Repeater>
        </table>

        <table width="100%" cellpadding="0" cellspacing="0" border="0" style="margin-top: 5px; background-color: #fbf4f4; height: 26px;"
            id="tblABC" runat="server">
            <tr>
                <td style="padding-left: 6px;">
                    <cc1:CollectionPager ID="cpNldQuatrinhCongTac" runat="server" BackText="" FirstText="Đầu"
                        ControlCssClass="ProductPage" LabelText="" LastText="Cuối" NextText="" UseSlider="true"
                        ResultsFormat="" BackNextLinkSeparator="" ResultsLocation="None" BackNextLocation="None"
                        PageNumbersSeparator="&nbsp;">
                    </cc1:CollectionPager>
                </td>
            </tr>
        </table>

        <br />

        <footer style="height: 120px !important; margin-bottom: 0px; width: 100%; text-align: justify; background-color: #f0f0f0; z-index: 10">
            <div style="width: 100%;">
                <table class="DataListTableHeader" border="0">

                    <tr style="height: 40px;">
                        <td class="DataListTableHeaderTdItemTT" style="width: 4%;">#
                        </td>

                        <td class="DataListTableHeaderTdItemJustify" style="width: 16%;">Ngày ghi nhận
                        </td>

                        <td class="DataListTableHeaderTdItemJustify" style="width: 80%;">Trạng thái / Nội dung
                        </td>

                    </tr>

                    <tr style="height: 40px;">
                        <td class="DataListTableHeaderTdItemTT" style="width: 4%;"></td>

                        <td class="DataListTableHeaderTdItemJustify" style="width: 16%; padding-left:0px;">
                            <div class='input-group date' id='datetimepicker1' style="margin-left: 0px; width: 95% !important; float: right;">
                                <input type='text' class="form-control" id="txtNgayNhatKy" runat="server" />
                                <span class="input-group-addon">
                                    <span class="glyphicon glyphicon-calendar"></span>
                                </span>
                            </div>
                            <script type="text/javascript">
                                $(function () {
                                    $('#datetimepicker1').datetimepicker({ format: 'DD/MM/YYYY' });
                                });
                            </script>
                        </td>

                        <td class="DataListTableHeaderTdItemJustify" style="width: 70%; padding-right:10px;">
                            <asp:TextBox ID="txtNote" runat="server" class="form-control"></asp:TextBox>
                        </td>

                    </tr>

                    <tr style="height: 44px;">
                        <td style="width: 4%;"></td>

                        <td style="text-align: right; padding-bottom: 8px; width: 16%; padding-right: 10px;">&nbsp;
                        </td>

                        <td style="padding-left: 10px; padding-bottom: 8px; width: 80%; padding-right:10px; padding-top:5px;">
                            <asp:Button ID="btnSave" runat="server" Text="Ghi nhận" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                            <asp:Button ID="btnAdd" runat="server" Text="Thêm mới" CssClass="btn btn-success" OnClick="btnAdd_Click" />
                            &nbsp;&nbsp;
                        <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red" Width ="300px"></asp:Label>
                            &nbsp;
                            <asp:Button ID="btnDel" runat="server" Text="Xóa mục" CssClass="btn btn-primary" Style ="float:right;" OnClick="btnDel_Click" />
                        </td>

                    </tr>

                </table>
            </div>
        </footer>

    </form>
</body>
</html>
