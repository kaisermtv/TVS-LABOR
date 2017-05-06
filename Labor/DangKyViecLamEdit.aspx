<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="DangKyViecLamEdit.aspx.cs" Inherits="Admin_DangKyViecLamEdit" %>

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

        $(function () {
            $('#datetimepicker3').datetimepicker({
                format: 'DD/MM/YYYY'
            });
        });

        $(function () {
            $('#datetimepicker4').datetimepicker({
                format: 'DD/MM/YYYY'
            });
        });

    </script>

    <table border="0" style="width: 100%; margin-top: -20px;">

        <tr style="height: 40px;">
            <td colspan="6">
                <b>I. THÔNG TIN NGƯỜI LAO ĐỘNG ĐĂNG KÝ</b>
            </td>
        </tr>

        <tr style="height: 40px;">
            <td colspan="6">
                <table border="0" style="width: 100%;">
                    <tr>
                        <td style="width: 10%; text-align: right; padding-right: 5px;">Người lao động:</td>
                        <td style="width: 20%;">
                            <input type="hidden" id="txtIDNguoiLaoDong" name="txtIDNguoiLaoDong" runat="server" />
                            <asp:Label ID="txtTenNguoiLaoDong" runat="server" Style="width: 100% !important; float: left; height: 40px; line-height: 40px;"></asp:Label>
                        </td>
                        <td style="width: 8%; text-align: right; padding-right: 5px;">Tên công việc:</td>
                        <td style="width: 20%;">
                            <asp:Label ID="txtTenCongViec" runat="server" Style="width: 100%; float: left; height: 40px; line-height: 40px;"></asp:Label>
                        </td>
                        <td style="width: 8%; text-align: right; padding-right: 5px;">&nbsp;</td>
                        <td>
                            &nbsp;
                        </td>
                        <td>&nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>

        <tr style="height: 40px;">
            <td colspan="6">
                <table border="0" style="width: 100%;">
                    <tr>
                        <td style="width: 10%; text-align: right; padding-right: 5px;">Lương thấp nhất:</td>
                        <td style="width: 20%;">
                            <asp:Label ID="lblMucLuong" runat="server" Style="width: 100%; float: left; height: 20px; line-height: 20px;"></asp:Label>
                        </td>
                        <td style="width: 8%; text-align: right; padding-right: 5px;">Tỉnh, TP:</td>
                        <td style="width: 20%;">
                            <asp:Label ID="lblIDTinh" runat="server" Style="width: 100%; float: left; height: 20px; line-height: 20px; margin-bottom: -38px;"></asp:Label>
                            <asp:DropDownList ID="ddlIDTinh" AutoPostBack="true" runat="server" Style="width: 100%; visibility: hidden;" OnSelectedIndexChanged="ddlIDTinh_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 8%; text-align: right; padding-right: 5px;">Quận, huyện:</td>
                        <td>
                            <asp:Label ID="lblIDHuyen" runat="server" Style="width: 100%; float: left; height: 20px; line-height: 20px; margin-bottom: -38px;"></asp:Label>
                            <asp:DropDownList ID="ddlIDHuyen" AutoPostBack="true" runat="server" Style="width: 50%; visibility: hidden;">
                            </asp:DropDownList>
                        </td>
                        <td>&nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>

        <tr style="height: 40px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">Nội dung khác:</td>
            <td style="width: 90%;" colspan="5">
                <asp:Label ID="txtNoiDungKhac" runat="server"></asp:Label>
            </td>
        </tr>

        <tr style="height: 42px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">Ngày đăng ký:</td>
            <td style="width: 20%;">
                <div class='input-group date' id='datetimepicker2' style="margin-left: 0px; width: 160px !important;">
                    <input type='text' id="txtNgayDangKy" runat="server" style ="border:none; background-color:#f8f8f8;" />
                </div>

                <script type="text/javascript">
                    $(function () {
                        $('#datetimepicker2').datetimepicker();
                    });
                </script>
            </td>
            <td colspan="5">
                <table border="0" style="width: 100%;">
                    <tr>
                        <td style="text-align: right; padding-right: 5px; width: 12%;">Nước ngoài:
                        </td>
                        <td style="width: 60%;">
                            <asp:CheckBox ID="ckbNuocNgoai" Enabled ="false" runat="server" Style="font-weight: normal;" />
                            &nbsp;Làm việc ở nước ngoài
                        </td>
                        <td style="text-align: right; padding-right: 5px; width: 10%;">
                            &nbsp;
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlState" Font-Bold="true" runat="server" CssClass="form-control" Visible ="false">
                                <asp:ListItem Value="0">Chưa xử lý</asp:ListItem>
                                <asp:ListItem Value="1">Đang xử lý</asp:ListItem>
                                <asp:ListItem Value="2">Đã xử lý</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>

        <tr style="height: 40px;">
            <td colspan="6">
                <b>II. THÔNG TIN GIỚI THIỆU</b>
            </td>
        </tr>

        <tr style="height: 40px;">
            <td colspan="6">
                <table border="0" style="width: 100%;">
                    <tr>
                        <td style="width: 10%; text-align: right; padding-right: 5px;">Đơn vị:</td>
                        <td style="width: 20%;">
                            <input type="hidden" id="txtIDDonVi" name="txtIDDonVi" runat="server" />
                            <asp:Label ID="txtTenDonVi" runat="server"></asp:Label>
                        </td>
                        <td style="width: 8%; text-align: right; padding-right: 5px;">Ngày GT:</td>
                        <td style="width: 20%;">
                            <div class='input-group date' id='datetimepicker3' style="margin-left: 0px; width: 160px !important;">
                                <input type='text' id="txtNgayGioiThieu" style ="border:none; background-color:#f8f8f8;" runat="server" />
                            </div>

                            <script type="text/javascript">
                                $(function () {
                                    $('#datetimepicker3').datetimepicker();
                                });
                            </script>
                        </td>
                        <td style="width: 8%; text-align: right; padding-right: 5px;">Vị trí:</td>
                        <td>
                            <input type="hidden" id="txtIDChucVu" name="txtIDChucVu" runat="server" />
                            <asp:Label ID="txtNameChucVu" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>

        <tr style="height: 40px;">
            <td colspan="6">
                <b>III. KẾT QUẢ TƯ VẤN, GIỚI THIỆU VIỆC LÀM</b>
            </td>
        </tr>

        <tr style="height: 10px;">
            <td style="width: 10%;">&nbsp</td>
            <td colspan="5">
                <asp:RadioButton ID="rdbKetQuaTrungTuyen" runat="server" GroupName="rdbKetQua" />&nbsp;<b>Trúng tuyển</b>
            </td>
        </tr>

        <tr style="height: 40px;">
            <td colspan="6">
                <table border="0" style="width: 100%; margin-top: 10px;">
                    <tr>
                        <td style="width: 10%; text-align: right; padding-right: 5px;">Đơn vị:</td>
                        <td style="width: 48%;">
                            <input type="hidden" id="txtIDDonVi1" name="txtIDDonVi1" runat="server" />
                            <asp:TextBox ID="txtTenDonVi1" runat="server" CssClass="form-control" Style="width: 85% !important; float: left;"></asp:TextBox>
                            <button class="btn btn-primary" type="button" onclick="ChonTinTuyenDung1()" style="height: 34px !important; line-height: 14px !important; margin-left: 6px;">Chọn</button>
                        </td>
                        <td style="width: 8%; text-align: right; padding-right: 5px;">Vị trí:</td>
                        <td style="width: 17%;">
                            <asp:DropDownList ID="ddlIDChucVu" CssClass="form-control" runat="server" Style="width: 100%;">
                            </asp:DropDownList>
                        </td>
                        <td>&nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>

        <tr style="height: 40px;">
            <td colspan="6">
                <table border="0" style="width: 100%;">
                    <tr>
                        <td style="width: 10%; text-align: right; padding-right: 5px;">Loại hợp đồng:</td>
                        <td style="width: 20%;">
                            <asp:DropDownList ID="ddlIDLoaiHopDong" CssClass="form-control" runat="server" Style="width: 100%;">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 8%; text-align: right; padding-right: 5px;">Ngày nhận việc:</td>
                        <td style="width: 20%;">
                            <div class='input-group date' id='datetimepicker4' style="margin-left: 0px; width: 160px !important;">
                                <input type='text' class="form-control" id="txtNgayNhanViec" runat="server" />
                                <span class="input-group-addon">
                                    <span class="glyphicon glyphicon-calendar"></span>
                                </span>
                            </div>

                            <script type="text/javascript">
                                $(function () {
                                    $('#datetimepicker4').datetimepicker();
                                });
                            </script>
                        </td>
                        <td style="width: 8%; text-align: right; padding-right: 5px;">Thời gian thử việc:</td>
                        <td style="width: 17%;">
                            <asp:TextBox ID="txtThoiGianThuViec" runat="server" CssClass="form-control"></asp:TextBox>
                        </td>
                        <td>&nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>

        <tr style="height: 40px;">
            <td style="width: 10%;">&nbsp</td>
            <td colspan="5">
                <asp:RadioButton ID="rdbKetQuaKhongTrungTuyen" runat="server" GroupName="rdbKetQua" />&nbsp;<b style="color: red;">Không trúng tuyển</b>
            </td>
        </tr>

        <tr style="height: 40px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">Lý do:</td>
            <td style="width: 90%;" colspan="5">
                <asp:TextBox ID="txtLyDoKhongTrungTuyen" runat="server" CssClass="form-control"></asp:TextBox>
            </td>
        </tr>

    </table>

    <footer style="height: 43px !important; margin-bottom: 0px; margin-left: -30px; width: 100%; text-align: justify; background-color: #f0f0f0;">
        <table border="0" style="width: 100%; margin-top: -8px;">
            <tr>
                <td style="width: 10%; text-align: right; padding-right: 5px;">&nbsp;</td>
                <td>
                    <asp:Button ID="btnSave" runat="server" Text="Ghi nhận" CssClass="btn btn-primary" OnClick="btnSave_Click" Visible="false" />
                    <button id="btnPrint" runat="server" class="btn btn-primary" onclick="InPhieuGioiThieu()">Phiếu giới thiệu</button>
                    <button id="btnPrintResult" runat="server" class="btn btn-primary" onclick="InPhieuKetQua()">Phiếu thông báo kết quả</button>
                </td>
                <td>
                    <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
                <td style="text-align: right; padding-right: 65px;">
                    <asp:Button ID="btnCancel" runat="server" Text="Thoát" CssClass="btn btn-default" OnClick="btnCancel_Click" />
                </td>
            </tr>
        </table>
    </footer>

    <input type="hidden" id="txtIDNldTuVan" runat="server" />

    <script type="text/javascript">
        function SelectName() {

            var w = 1000;
            var h = 600;

            var dualScreenLeft = window.screenLeft != undefined ? window.screenLeft : screen.left;
            var dualScreenTop = window.screenTop != undefined ? window.screenTop : screen.top;

            var width = window.innerWidth ? window.innerWidth : document.documentElement.clientWidth ? document.documentElement.clientWidth : screen.width;
            var height = window.innerHeight ? window.innerHeight : document.documentElement.clientHeight ? document.documentElement.clientHeight : screen.height;

            var left = ((width / 2) - (w / 2)) + dualScreenLeft;
            var top = ((height / 2) - (h / 2)) + dualScreenTop;
            var newWindow = window.open("ChonNguoiLaoDong.aspx", "CHỌN NGƯỜI LAO ĐỘNG", 'scrollbars=yes, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);

            if (window.focus) {
                newWindow.focus();
            }
        }

        function ChonTinTuyenDung() {

            var w = 1000;
            var h = 600;

            var dualScreenLeft = window.screenLeft != undefined ? window.screenLeft : screen.left;
            var dualScreenTop = window.screenTop != undefined ? window.screenTop : screen.top;

            var width = window.innerWidth ? window.innerWidth : document.documentElement.clientWidth ? document.documentElement.clientWidth : screen.width;
            var height = window.innerHeight ? window.innerHeight : document.documentElement.clientHeight ? document.documentElement.clientHeight : screen.height;

            var left = ((width / 2) - (w / 2)) + dualScreenLeft;
            var top = ((height / 2) - (h / 2)) + dualScreenTop;
            var newWindow = window.open("ChonTinTuyenDung.aspx", "CHỌN TIN TUYỂN DỤNG", 'scrollbars=yes, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);

            if (window.focus) {
                newWindow.focus();
            }
        }

        function ChonTinTuyenDung1() {

            var w = 1000;
            var h = 600;

            var dualScreenLeft = window.screenLeft != undefined ? window.screenLeft : screen.left;
            var dualScreenTop = window.screenTop != undefined ? window.screenTop : screen.top;

            var width = window.innerWidth ? window.innerWidth : document.documentElement.clientWidth ? document.documentElement.clientWidth : screen.width;
            var height = window.innerHeight ? window.innerHeight : document.documentElement.clientHeight ? document.documentElement.clientHeight : screen.height;

            var left = ((width / 2) - (w / 2)) + dualScreenLeft;
            var top = ((height / 2) - (h / 2)) + dualScreenTop;
            var newWindow = window.open("ChonTinTuyenDung1.aspx", "CHỌN TIN TUYỂN DỤNG", 'scrollbars=yes, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);

            if (window.focus) {
                newWindow.focus();
            }
        }

        function InPhieuGioiThieu() {

            var IDNldTuVan = document.getElementById("MainContent_txtIDNldTuVan").value;

            if (IDNldTuVan != 0) {

                var w = 1000;
                var h = 1600;

                var dualScreenLeft = window.screenLeft != undefined ? window.screenLeft : screen.left;
                var dualScreenTop = window.screenTop != undefined ? window.screenTop : screen.top;

                var width = window.innerWidth ? window.innerWidth : document.documentElement.clientWidth ? document.documentElement.clientWidth : screen.width;
                var height = window.innerHeight ? window.innerHeight : document.documentElement.clientHeight ? document.documentElement.clientHeight : screen.height;

                var left = ((width / 2) - (w / 2)) + dualScreenLeft;
                var top = ((height / 2) - (h / 2)) + dualScreenTop;
                var newWindow = window.open("PrintPhieuGioiThieu.aspx?id=" + IDNldTuVan, "IN PHIẾU GIỚI THIỆU", 'scrollbars=yes, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);

                if (window.focus) {
                    newWindow.focus();
                }
            }
        }

        function InPhieuKetQua() {

            var IDNldTuVan = document.getElementById("MainContent_txtIDNldTuVan").value;

            if (IDNldTuVan != 0) {

                var w = 1000;
                var h = 1600;

                var dualScreenLeft = window.screenLeft != undefined ? window.screenLeft : screen.left;
                var dualScreenTop = window.screenTop != undefined ? window.screenTop : screen.top;

                var width = window.innerWidth ? window.innerWidth : document.documentElement.clientWidth ? document.documentElement.clientWidth : screen.width;
                var height = window.innerHeight ? window.innerHeight : document.documentElement.clientHeight ? document.documentElement.clientHeight : screen.height;

                var left = ((width / 2) - (w / 2)) + dualScreenLeft;
                var top = ((height / 2) - (h / 2)) + dualScreenTop;
                var newWindow = window.open("PrintThongBaoKetQua.aspx?id=" + IDNldTuVan, "IN PHIẾU GIỚI THIỆU", 'scrollbars=yes, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);

                if (window.focus) {
                    newWindow.focus();
                }
            }
        }

    </script>

</asp:Content>

