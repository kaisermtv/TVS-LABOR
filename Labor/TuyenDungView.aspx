<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TuyenDungView.aspx.cs" Inherits="Labor_TuyenDungView" %>

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
        .DataListTable td {
            padding-top: 5px;
            padding-bottom: 5px;
        }
    </style>
</head>
<body style="padding: 10px; padding-left: 20px; padding-right: 20px; background-color: #fff;">
    <form id="form1" runat="server">
        <table border="0">
            <tr style="height: 40px;">
                <td colspan="6">
                    <b>I. THÔNG TIN ĐƠN VỊ TUYỂN DỤNG</b>
                </td>
            </tr>
            <tr style="height: 40px;">
                <td style="width: 10%; text-align: right; padding-right: 5px;">Mã tuyển dụng:</td>
                <td style="width: 12%;">
                    <asp:Label ID="txtMaTuyenDung" runat="server" ReadOnly="true"></asp:Label>
                </td>
                <td style="width: 8%; text-align: right; padding-right: 5px;">Tên đơn vị:</td>
                <td style="width: 40%;">
                    <input type="hidden" name="txtIDDonVi" id="txtIDDonVi" runat="server" />
                    <asp:Label ID="txtTenDonVi" ReadOnly="true" runat="server" Style="width: 100% !important; float: left;"></asp:Label>
                </td>
                <td style="width: 10%; text-align: right; padding-right: 5px;">Ngành nghề:</td>
                <td style="width: 20%;">
                    <asp:DropDownList ID="ddlIDNganhNghe" Enabled="false" runat="server" Style="width: 100%; border:none; background-color:#fff;">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr style="height: 40px;">
                <td colspan="6">
                    <b>II. THÔNG TIN TUYỂN DỤNG</b>
                </td>
            </tr>

            <tr style="height: 40px;">
                <td style="width: 10%; text-align: right; padding-right: 5px;">Vị trí:</td>
                <td style="width: 12%;">
                    <asp:DropDownList ID="ddlIdVitri" runat="server" Enabled="false" Style="width: 100%; border:none; background-color:#fff;">
                    </asp:DropDownList>
                </td>
                <td style="width: 8%; text-align: right; padding-right: 5px;">Chức vụ:</td>
                <td style="width: 40%;">
                    <table style="width: 100%">
                        <tr>
                            <td style="width: 45%">
                                <asp:DropDownList ID="ddlIDChucVu" runat="server" Enabled="false" Style="width: 100%; border:none; background-color:#fff;">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 25%; padding-right: 5px; text-align: right">Số lượng: </td>
                            <td>
                                <asp:Label ID="txtSoLuongTuyenDung" runat="server" ReadOnly="true"></asp:Label>
                            </td>
                        </tr>
                    </table>

                </td>
                <td style="width: 10%; text-align: right; padding-right: 5px;">Nhóm ngành:</td>
                <td style="width: 20%;">
                    <asp:DropDownList ID="ddlNhomNganh" runat="server" Enabled ="false" Style="width: 100%; border:none; background-color:#fff;">
                        <asp:ListItem Value="0"> Không chọn </asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>

            <tr style="height: 40px;">
                <td style="width: 10%; text-align: right; padding-right: 5px;">Giới tính:</td>
                <td style="width: 12%;">
                    <asp:DropDownList ID="ddlIDGioiTinh" runat="server" Enabled="false" Style="width: 100%; border:none; background-color:#fff;">
                    </asp:DropDownList>
                </td>
                <td style="width: 8%; text-align: right; padding-right: 5px;">Độ tuổi:</td>
                <td style="width: 40%;">
                    <asp:DropDownList ID="ddlIDDoTuoi" runat="server" Enabled="false" Style="width: 100%; border:none; background-color:#fff;">
                    </asp:DropDownList>
                </td>
                <td style="width: 10%; text-align: right; padding-right: 5px;">&nbsp;</td>
                <td style="width: 20%;">&nbsp;
                </td>
            </tr>

            <tr style="height: 40px;">
                <td style="width: 10%; text-align: right; padding-right: 5px;">TĐ Chuyên môn:</td>
                <td style="width: 12%;">
                    <asp:DropDownList ID="ddlIDTrinhDoChuyenMon" Enabled="false" runat="server" Style="width: 100%; border:none; background-color:#fff;">
                    </asp:DropDownList>
                </td>
                <td style="width: 8%; text-align: right; padding-right: 5px;">Ngoại ngữ:</td>
                <td>
                    <table style="width: 90%;">
                        <tr>
                            <td style="width: 33%;">
                                <asp:DropDownList ID="ddlyeuCauNgoaiNgu" Enabled="false" runat="server" Style="width: 100%; border:none; background-color:#fff;">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 45%; text-align: right; padding-right: 10px">Tin Học:
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlyeuCauTinHoc" Enabled ="false" runat="server" Style="width: 100%; border:none; background-color:#fff;">
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>

                </td>
                <td style="width: 10%; text-align: right; padding-right: 5px;">Kinh nghiệm:</td>
                <td style="width: 20%;">
                    <asp:Label ID="txtNamKinhNghiem" runat="server" ReadOnly ="true"></asp:Label>
                </td>

            </tr>

            <tr style="height: 40px;">
                <td style="width: 10%; text-align: right; padding-right: 5px;">Nội dung:</td>
                <td style="width: 90%;" colspan="5">
                    <%--<asp:TextBox ID="txtNoiDungKhac" runat="server" TextMode="MultiLine" CssClass="form-control" style="resize: vertical;"></asp:TextBox>--%>
                </td>
            </tr>

            <tr style="height: 40px;">
                <td style="width: 10%; text-align: right; padding-right: 5px;">Mô tả:</td>
                <td style="width: 90%;" colspan="5">
                    <asp:Label ID="txtMoTa" runat="server"></asp:Label>
                </td>
            </tr>


            <tr style="height: 40px;">
                <td style="width: 10%; text-align: right; padding-right: 5px;">Ưu tiên:</td>
                <td colspan="5">
                    <asp:Label ID="txtUuTien" runat="server"></asp:Label>
                </td>
            </tr>

            <tr style="height: 40px;">
                <td style="width: 10%; text-align: right; padding-right: 5px;">Quyền lợi:</td>
                <td style="width: 90%;" colspan="5">
                    <asp:Label ID="txtQuyenLoi" runat="server"></asp:Label>
                </td>
            </tr>

            <tr style="height: 40px;">
                <td style="width: 10%; text-align: right; padding-right: 5px;">Địa điểm:</td>
                <td style="width: 90%;" colspan="5">
                    <asp:Label ID="txtDiaDiem" runat="server"></asp:Label>
                </td>
            </tr>

            <tr style="height: 40px;">
                <td style="width: 10%; text-align: right; padding-right: 5px;">Tỉnh, thành phố:</td>
                <td style="width: 12%;">
                    <%--<asp:DropDownList ID="ddlIDTinh" runat="server" Style="width: 100%;" CssClass="form-control" OnSelectedIndexChanged="ddlIDTinh_SelectedIndexChanged">
                </asp:DropDownList>--%>
                </td>
                <td style="width: 8%; text-align: right; padding-right: 5px;">Mức lương:</td>
                <td colspan="2">
                    <table style="width: 90%;">
                        <tr>
                            <td style="width: 33%;">
                                <asp:DropDownList ID="ddlIDMucLuong" Enabled ="false" runat="server" Style="width: 100%; border:none; background-color:#fff;">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 33%; text-align: right; padding-right: 10px">Thời gian làm việc:
                            </td>
                            <td style="width: 33%;">
                                <asp:DropDownList ID="ddlThoiGianLamViec" Enabled ="false" runat="server" Style="width: 100%; border:none; background-color:#fff;">
                                    <asp:ListItem Value="5"> Thỏa thuận </asp:ListItem>
                                    <asp:ListItem Value="1"> Hành chính </asp:ListItem>
                                    <asp:ListItem Value="2"> Bán thời gian </asp:ListItem>
                                    <asp:ListItem Value="3"> Theo ca </asp:ListItem>
                                    <asp:ListItem Value="4"> Toàn thời gian </asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 20%;">
                    <asp:CheckBox ID="ckbNuocNgoai" runat="server" Style="font-weight: normal;" Enabled ="false" />&nbsp;&nbsp;Làm việc ở nước ngoài
                </td>
            </tr>

            <tr style="height: 40px;">
                <td style="width: 10%; text-align: right; padding-right: 5px;">Ngày bắt đầu:</td>
                <td style="width: 12%;">
                    <div class='input-group date' id='datetimepicker1' style="margin-left: 0px; width: 100% !important; float: right;">
                        <input type='text' id="txtNgayBatDau" runat="server" style ="border:none;" />
                    </div>

                    <script type="text/javascript">
                        $(function () {
                            $('#datetimepicker1').datetimepicker();
                        });
                    </script>
                </td>
                <td style="width: 8%; text-align: right; padding-right: 5px;">Kết thúc:</td>
                <td style="width: 40%;">
                    <div class='input-group date' id='datetimepicker2' style="margin-left: 0px; width: 160px !important;">
                        <input type='text' id="txtNgayKetThuc" runat="server" style ="border:none;" />
                    </div>

                    <script type="text/javascript">
                        $(function () {
                            $('#datetimepicker2').datetimepicker();
                        });
                    </script>

                </td>
                <td style="width: 10%; text-align: right; padding-right: 5px;">Trạng thái:</td>
                <td style="width: 20%;">
                    <asp:CheckBox ID="ckbState" Checked="true" runat="server" Style="font-weight: normal;" Enabled ="false" />&nbsp;&nbsp;Kích hoạt
                </td>
            </tr>

            <tr style="height: 50px;">
                <td style="width: 10%; text-align: right; padding-right: 5px;">&nbsp;</td>
                <td colspan="5"></td>
            </tr>

        </table>
    </form>
</body>
</html>
