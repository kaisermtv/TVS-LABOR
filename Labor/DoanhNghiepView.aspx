<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DoanhNghiepView.aspx.cs" Inherits="Labor_DoanhNghiepView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>XEM THÔNG TIN DOANH NGHIỆP</title>
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
<body>
    <form id="form1" runat="server">
    <div>
        
    <table border="0">
        <tr style="height: 40px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">Mã đơn vị:</td>
            <td style="width: 12%;">
                <asp:TextBox ID="txtMaDonVi"  Enabled="false" runat="server" CssClass="form-control"></asp:TextBox>
            </td>
            <td style="width: 8%; text-align: right; padding-right: 5px;">Tên đơn vị *:</td>
            <td style="width: 40%;">
                <asp:TextBox ID="txtTenDonVi"  Enabled="false" runat="server" CssClass="form-control"></asp:TextBox>
            </td>
            <td style="width: 10%; text-align: right; padding-right: 5px;">Ngành nghề *:</td>
            <td style="width: 20%;">
                <asp:TextBox ID="ddlIDNganhNghe"  Enabled="false" runat="server" CssClass="form-control"></asp:TextBox>
            </td>
        </tr>

        <tr style="height: 40px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">Quy mô:</td>
            <td style="width: 90%;" colspan="5">
                <table style="width: 100%;">
                    <tr>
                        <td style="width: 67%;">
                            <asp:TextBox ID="txtQuyMo"  Enabled="false" runat="server" CssClass="form-control"></asp:TextBox>
                        </td>
                        <td style="text-align: right; width: 10.7%;">Loại hình:&nbsp;
                        </td>
                        <td>
                            <asp:TextBox ID="ddlIdLoaiHinh"  Enabled="false" runat="server" CssClass="form-control"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>

        <tr style="height: 40px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">Địa chỉ *:</td>
            <td style="width: 90%;" colspan="5">
                <asp:TextBox ID="txtDiaChi" runat="server"  Enabled="false" CssClass="form-control"></asp:TextBox>
            </td>
        </tr>

        <tr style="height: 40px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">Tỉnh, thành phố *:</td>
            <td style="width: 12%;">
                <asp:TextBox ID="ddlIDTinh" runat="server"  Enabled="false" CssClass="form-control"></asp:TextBox>
            </td>
            <td style="width: 8%; text-align: right; padding-right: 5px;">Quận, huyện:</td>
            <td style="width: 40%;">
                <asp:TextBox ID="ddlIDHuyen" runat="server"  Enabled="false" CssClass="form-control"></asp:TextBox>
            </td>
            <td style="width: 10%; text-align: right; padding-right: 5px;">Điện thoại DN :</td>
            <td style="width: 20%;">
                <asp:TextBox ID="txtDienThoaiDonVi" runat="server"  Enabled="false" CssClass="form-control"></asp:TextBox>
            </td>
        </tr>

        <tr style="height: 40px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">Địa chỉ Email DN:</td>
            <td style="width: 90%;" colspan="5">
                <table style="width: 100%;">
                    <tr>
                        <td style="width: 67%;">
                            <asp:TextBox ID="txtEmailDonVi"  Enabled="false" runat="server" CssClass="form-control"></asp:TextBox>
                        </td>
                        <td style="text-align: right; width: 10.7%;">Website:&nbsp;
                        </td>
                        <td>
                            <asp:TextBox ID="txtWebsite"  Enabled="false" runat="server" CssClass="form-control"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>

        <tr style="height: 40px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">Người đại diện *:</td>
            <td style="width: 12%;">
                <asp:TextBox ID="txtNguoiDaiDien" runat="server"  Enabled="false" CssClass="form-control"></asp:TextBox>
            </td>
            <td style="width: 8%; text-align: right; padding-right: 5px;">Điện thoại *:</td>
            <td style="width: 40%;">
                <asp:TextBox ID="txtDienThoai" runat="server"  Enabled="false" CssClass="form-control"></asp:TextBox>
            </td>
            <td style="width: 10%; text-align: right; padding-right: 5px;">Địa chỉ Email:</td>
            <td style="width: 20%;">
                <asp:TextBox ID="txtEmail" runat="server"  Enabled="false" CssClass="form-control"></asp:TextBox>
            </td>
        </tr>


        <tr style="height: 40px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">Chức vụ: </td>
            <td style="width: 12%;">
                <asp:TextBox ID="txtChucVu" runat="server"  Enabled="false" CssClass="form-control"></asp:TextBox>
            </td>
            <td style="width: 8%; text-align: right; padding-right: 5px;">Ngày đăng ký:</td>
            <td style="width: 40%;">
                <asp:TextBox ID="txtNgayDangKy" runat="server"  Enabled="false" CssClass="form-control"></asp:TextBox>
            </td>
            <td style="width: 10%; text-align: right; padding-right: 5px;"></td>
            <td style="width: 20%;">
                <asp:CheckBox ID="ckbNuocNgoai" runat="server"  Enabled="false" Style="font-weight: normal; padding-top: 10px !important;" Text="&nbsp;&nbsp;<span style = 'font-weight:normal;'>Doanh nghiệp nước ngoài</span>" />
            </td>
        </tr>

    </table>
    </div>
    </form>
</body>
</html>
