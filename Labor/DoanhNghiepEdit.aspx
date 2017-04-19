<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="DoanhNghiepEdit.aspx.cs" Inherits="Admin_DoanhNghiepEdit" %>

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

    <table border="0">
        <tr style="height: 40px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">Mã đơn vị:</td>
            <td style="width: 12%;">
                <asp:TextBox ID="txtMaDonVi" runat="server" CssClass="form-control"></asp:TextBox>
            </td>
            <td style="width: 8%; text-align: right; padding-right: 5px;">Tên đơn vị *:</td>
            <td style="width: 40%;">
                <asp:TextBox ID="txtTenDonVi" runat="server" CssClass="form-control"></asp:TextBox>
            </td>
            <td style="width: 10%; text-align: right; padding-right: 5px;">Ngành nghề *:</td>
            <td style="width: 20%;">
                <asp:DropDownList ID="ddlIDNganhNghe" runat="server" CssClass ="form-control" Style="width: 100%;">
                </asp:DropDownList>
            </td>
        </tr>

        <tr style="height: 40px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">Quy mô:</td>
            <td style="width: 90%;" colspan="5">
                <table style="width: 100%;">
                    <tr>
                        <td style="width: 67%;">
                            <asp:TextBox ID="txtQuyMo" runat="server" CssClass="form-control"></asp:TextBox>
                        </td>
                        <td style="text-align: right; width: 10.7%;">Loại hình:&nbsp;
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlIdLoaiHinh" runat="server" CssClass ="form-control" Style="width: 100%;">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>

        <tr style="height: 40px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">Địa chỉ *:</td>
            <td style="width: 90%;" colspan="5">
                <asp:TextBox ID="txtDiaChi" runat="server" CssClass="form-control"></asp:TextBox>
            </td>
        </tr>

        <tr style="height: 40px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">Tỉnh, thành phố *:</td>
            <td style="width: 12%;">
                <asp:DropDownList ID="ddlIDTinh" AutoPostBack="true" runat="server" CssClass ="form-control" Style="width: 100%;" OnSelectedIndexChanged="ddlIDTinh_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td style="width: 8%; text-align: right; padding-right: 5px;">Quận, huyện:</td>
            <td style="width: 40%;">
                <asp:DropDownList ID="ddlIDHuyen" AutoPostBack="true" runat="server" CssClass ="form-control" Style="width: 100%;">
                </asp:DropDownList>
            </td>
            <td style="width: 10%; text-align: right; padding-right: 5px;">Điện thoại DN :</td>
            <td style="width: 20%;">
                <asp:TextBox ID="txtDienThoaiDonVi" runat="server" CssClass="form-control"></asp:TextBox>
            </td>
        </tr>

        <tr style="height: 40px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">Địa chỉ Email DN:</td>
            <td style="width: 90%;" colspan="5">
                <table style="width: 100%;">
                    <tr>
                        <td style="width: 67%;">
                            <asp:TextBox ID="txtEmailDonVi" runat="server" CssClass="form-control"></asp:TextBox>
                        </td>
                        <td style="text-align: right; width: 10.7%;">Website:&nbsp;
                        </td>
                        <td>
                            <asp:TextBox ID="txtWebsite" runat="server" CssClass="form-control"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>

        <tr style="height: 40px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">Người đại diện *:</td>
            <td style="width: 12%;">
                <asp:TextBox ID="txtNguoiDaiDien" runat="server" CssClass="form-control"></asp:TextBox>
            </td>
            <td style="width: 8%; text-align: right; padding-right: 5px;">Điện thoại *:</td>
            <td style="width: 40%;">
                <asp:TextBox ID="txtDienThoai" runat="server" CssClass="form-control"></asp:TextBox>
            </td>
            <td style="width: 10%; text-align: right; padding-right: 5px;">Địa chỉ Email:</td>
            <td style="width: 20%;">
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
            </td>
        </tr>


        <tr style="height: 40px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">Chức vụ: </td>
            <td style="width: 12%;">
                <asp:TextBox ID="txtChucVu" runat="server" CssClass="form-control"></asp:TextBox>
            </td>
            <td style="width: 8%; text-align: right; padding-right: 5px;">Ngày đăng ký:</td>
            <td style="width: 40%;">
                <div class='input-group date' id='datetimepicker2' style="margin-left: 0px; width: 50% !important;">
                    <input type='text' class="form-control" id="txtNgayDangKy" runat="server" />
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>

                <script type="text/javascript">
                    $(function () {
                        $('#datetimepicker2').datetimepicker();
                    });
                </script>
                &nbsp;&nbsp;
                <asp:CheckBox ID="ckbNuocNgoai" runat="server" Style="font-weight: normal; padding-top: 10px !important;" Text="&nbsp;&nbsp;<span style = 'font-weight:normal;'>Doanh nghiệp nước ngoài</span>" />
            </td>
            <td style="width: 10%; text-align: right; padding-right: 5px;">Trạng thái:</td>
            <td style="width: 20%;">
                <asp:CheckBox ID="ckbState" Checked="true" runat="server" Style="font-weight: normal;" />&nbsp;&nbsp;Kích hoạt
            </td>
        </tr>

        <tr style="height: 40px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">&nbsp;</td>
            <td colspan="5" style="padding-left: 10px;">
                <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
            </td>
        </tr>

        <tr style="height: 40px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">&nbsp;</td>
            <td style="width: 90%;" colspan="5">
                <asp:Button ID="btnSave" runat="server" Text="Ghi nhận" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Thoát" CssClass="btn btn-default" OnClick="btnCancel_Click" />

                <% if(itemId != 0){ %>
                <a href="/Labor/DoanhNghiepEdit.aspx" style="float:right;margin-left:10px" class="btn btn-default">Thêm mới</a>
                <asp:Button ID="btnRedirect" runat="server" style="float:right"  Text="Đăng tuyển dụng" CssClass="btn btn-danger" OnClick="btnRedirect_Click" />
                <% } %>

            </td>
        </tr>

    </table>

    <input type="hidden" id="txtIDDoanhNghiep" runat="server" />

</asp:Content>

