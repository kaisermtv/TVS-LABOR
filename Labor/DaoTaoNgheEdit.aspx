﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="DaoTaoNgheEdit.aspx.cs" Inherits="Labor_DaoTaoNgheEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
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

    <table border="0" style="width: 100%; margin-top: -20px;">

        <tr style="height: 40px;">
            <td colspan="6">
                <b>I. THÔNG TIN NGƯỜI LAO ĐỘNG</b>
            </td>
        </tr>

        <tr style="height: 36px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">Họ và tên:</td>
            <td style="width: 40%;">
                <asp:TextBox ID="txtHoTen" runat="server" ReadOnly="true" Style="background-color: #fff;" CssClass="form-control"></asp:TextBox>
            </td>
            <td style="width: 10%; text-align: right; padding-right: 5px;">Ngày sinh:</td>
            <td style="width: 15%;">
                <asp:TextBox ID="txtNgaySinh" runat="server" ReadOnly="true" Style="background-color: #fff;" CssClass="form-control"></asp:TextBox>
            </td>
            <td style="width: 10%; text-align: right; padding-right: 5px;">Giới tính:</td>
            <td style="width: 15%;">
                <asp:TextBox ID="txtGioiTinh" runat="server" ReadOnly="true" Style="background-color: #fff;" CssClass="form-control"></asp:TextBox>
            </td>
        </tr>

        <tr style="height: 36px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">Địa chỉ:</td>
            <td colspan="3">
                <asp:TextBox ID="txtDiaChi" runat="server" ReadOnly="true" Style="background-color: #fff;" CssClass="form-control"></asp:TextBox>
            </td>
            <td style="width: 10%; text-align: right; padding-right: 5px;">Giới tính:</td>
            <td style="width: 15%;">
                <asp:TextBox ID="txtSoDienThoai" runat="server" ReadOnly="true" Style="background-color: #fff;" CssClass="form-control"></asp:TextBox>
            </td>
        </tr>

    </table>
    <br />
    <table border="0" style="width: 100%; margin-top: -20px;">

        <tr style="height: 40px;">
            <td colspan="6">
                <b>II. THÔNG TIN ĐĂNG KÝ</b>
            </td>
        </tr>

        <tr style="height: 36px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">Ngành học:</td>
            <td style="width: 40%;">
                <asp:DropDownList ID="ddlIDDTNganhNghe" runat="server" CssClass="form-control" Style="width: 100%;">
                </asp:DropDownList>
            </td>
            <td style="width: 10%; text-align: right; padding-right: 5px;">Môn học:</td>
            <td style="width: 15%;">
                <asp:DropDownList ID="ddlIDDTMonHoc" runat="server" CssClass="form-control" Style="width: 100%;">
                </asp:DropDownList>
            </td>
            <td style="width: 10%; text-align: right; padding-right: 5px;">Thời gian:</td>
            <td style="width: 15%;">
                <asp:TextBox ID="txtThoiGian" runat="server" CssClass="form-control"></asp:TextBox>
            </td>
        </tr>

        <tr style="height: 36px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">Trường học:</td>
            <td colspan="3">
                <asp:TextBox ID="txtTenDonVi" runat="server" CssClass="form-control"></asp:TextBox>
            </td>
            <td style="width: 10%; text-align: right; padding-right: 5px;">Mức hỗ trợ:</td>
            <td style="width: 15%;">
                <asp:TextBox ID="txtMucHoTro" runat="server" CssClass="form-control"></asp:TextBox>
            </td>
        </tr>

        <tr style="height: 36px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">Địa chỉ học:</td>
            <td>
                <asp:TextBox ID="txtDiaChiHoc" runat="server" CssClass="form-control"></asp:TextBox>
            </td>
            <td style="width: 10%; text-align: right; padding-right: 5px;">Khóa học:</td>
            <td style="width: 15%;">
                <asp:TextBox ID="txtKhoaHoc" runat="server" CssClass="form-control"></asp:TextBox>
            </td>
            <td style="width: 10%; text-align: right; padding-right: 5px;">ĐT liên hệ:</td>
            <td style="width: 15%;">
                <asp:TextBox ID="txtDTLienHe" runat="server" CssClass="form-control"></asp:TextBox>
            </td>
        </tr>

    </table>
    <br />
    <table border="0" style="width: 100%; margin-top: -20px;">

        <tr style="height: 40px;">
            <td colspan="6">
                <b>III. THÔNG TIN KHÁC</b>
            </td>
        </tr>

        <tr style="height: 36px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">Số QĐ học nghề:</td>
            <td style="width: 15%;">
                <asp:TextBox ID="txtSoQDHN" runat="server" CssClass="form-control"></asp:TextBox>
            </td>
            <td style="width: 10%; text-align: right; padding-right: 5px;">Số QĐ TN:</td>
            <td style="width: 15%;">
                <asp:TextBox ID="txtSoQDHTN" runat="server" CssClass="form-control"></asp:TextBox>
            </td>
            <td style="width: 10%; text-align: right; padding-right: 5px;">Ngày bắt đầu:</td>
            <td style="width: 15%;">
                <div class='input-group date' id='datetimepicker1' style="margin-left: 0px; width: 100% !important;">
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
            <td style="width: 10%; text-align: right; padding-right: 5px;">Ngày kết thúc:</td>
            <td style="width: 15%;">
                <div class='input-group date' id='datetimepicker2' style="margin-left: 0px; width: 100% !important;">
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

    </table>
    <br />
    <br />
    <table border="0" style="width: 100%; margin-top: -20px;">
        <tr style="height: 40px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">
                <b>Trạng thái:</b>
            </td>
            <td style="width: 15%;" colspan="2">
                <asp:DropDownList ID="ddlState" Font-Bold = "true" runat="server" CssClass="form-control">
                    <asp:ListItem Value="0" Selected="True">Chưa xử lý</asp:ListItem>
                    <asp:ListItem Value="1">Đang xử lý</asp:ListItem>
                    <asp:ListItem Value="2">Đã xử lý</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td></td>
        </tr>
    </table>
    <br />
    <table border="0" style="width: 100%; margin-top: -20px;">
        <tr style="height: 40px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">&nbsp;</td>
            <td style="width: 90%;" colspan="2">
                <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
            </td>
        </tr>

        <tr style="height: 40px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">&nbsp;</td>
            <td style="width: 90%;" colspan="2">
                <asp:Button ID="btnSave" runat="server" Text="Ghi nhận" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Thoát" CssClass="btn btn-default" OnClick="btnCancel_Click" />
            </td>
        </tr>
    </table>
</asp:Content>

