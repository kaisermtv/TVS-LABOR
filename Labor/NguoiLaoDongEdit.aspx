<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="NguoiLaoDongEdit.aspx.cs" Inherits="Admin_NguoiLaoDongEdit" %>

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
            <td style="width: 10%; text-align: right; padding-right: 5px;">Mã NLĐ:</td>
            <td style="width: 10%;">
                <asp:TextBox ID="txtMa" runat="server" CssClass="form-control"></asp:TextBox>
            </td>
            <td style="width: 10%; text-align: right; padding-right: 5px;">Họ và tên:</td>
            <td style="width: 40%;">
                <asp:TextBox ID="txtHoVaTen" runat="server" CssClass="form-control"></asp:TextBox>
            </td>
            <td style="width: 10%; text-align: right; padding-right: 5px;">Ngày sinh:</td>
            <td style="width: 20%;">
                <div class='input-group date' id='datetimepicker1' style="margin-left: 0px; width: 100% !important; float: right;">
                    <input type='text' class="form-control" id="txtNgaySinh" runat="server" />
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
        </tr>

        <tr style="height: 40px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">Giới tính:</td>
            <td style="width: 10%;">
                <asp:DropDownList ID="ddlGioiTinh" CssClass ="form-control" runat="server" Style="width: 100%;">
                </asp:DropDownList>
            </td>
            <td style="width: 10%; text-align: right; padding-right: 5px;">Nơi sinh:</td>
            <td style="width: 70%;" colspan="3">
                <asp:TextBox ID="txtNoiSinh" runat="server" CssClass="form-control"></asp:TextBox>
            </td>
        </tr>

        <tr style="height: 40px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">Quê quán:</td>
            <td style="width: 90%;" colspan="5">
                <asp:TextBox ID="txtQueQuan" runat="server" CssClass="form-control"></asp:TextBox>
            </td>
        </tr>

        <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional">
            <ContentTemplate>

                <tr style="height: 40px;">
                    <td style="width: 10%; text-align: right; padding-right: 5px;">Nơi thường trú:</td>
                    <td style="width: 10%;">
                        <asp:DropDownList ID="ddlTinh_TT" AutoPostBack="true" runat="server" CssClass="form-control" Style="width: 100%;" OnSelectedIndexChanged="ddlTinh_TT_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td style="width: 10%; text-align: right; padding-right: 5px;">Quận, huyện:</td>
                    <td style="width: 40%;">
                        <table style="width: 100%;">
                            <tr>
                                <td style="width: 35%;">
                                    <asp:DropDownList ID="ddlHuyen_TT" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlHuyen_TT_SelectedIndexChanged" CssClass="form-control" Style="width: 100%;">
                                    </asp:DropDownList>
                                </td>
                                <td style="text-align: right; width: 110px; padding-right: 5px;">Phường, xã:</td>
                                <td>
                                    <asp:DropDownList ID="ddlXa_TT" AutoPostBack="true" runat="server" CssClass="form-control" Style="width: 100%;">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="width: 10%; text-align: right; padding-right: 5px;">Khối, xóm:</td>
                    <td style="width: 20%;">
                        <asp:TextBox ID="txtXom_TT" runat="server" CssClass="form-control"></asp:TextBox>
                    </td>
                </tr>

                <tr style="height: 40px;">
                    <td style="width: 10%; text-align: right; padding-right: 5px;">Địa chỉ:</td>
                    <td style="width: 10%;">
                        <asp:DropDownList ID="ddlTinh_DC" AutoPostBack="true" runat="server" CssClass="form-control" Style="width: 100%;" OnSelectedIndexChanged="ddlTinh_DC_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td style="width: 10%; text-align: right; padding-right: 5px;">Quận, huyện:</td>
                    <td style="width: 40%;">
                        <table style="width: 100%;">
                            <tr>
                                <td style="width: 35%;">
                                    <asp:DropDownList ID="ddlHuyen_DC" AutoPostBack="true" runat="server" CssClass="form-control" Style="width: 100%;" OnSelectedIndexChanged="ddlHuyen_DC_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td style="text-align: right; width: 110px; padding-right: 5px;">Phường, xã:</td>
                                <td>
                                    <asp:DropDownList ID="ddlXa_DC" AutoPostBack="true" runat="server" CssClass="form-control" Style="width: 100%;">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="width: 10%; text-align: right; padding-right: 5px;">Khối, xóm:</td>
                    <td style="width: 20%;">
                        <asp:TextBox ID="txtXom_DC" runat="server" CssClass="form-control"></asp:TextBox>
                    </td>
                </tr>

            </ContentTemplate>
        </asp:UpdatePanel>

        <tr style="height: 40px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">Điện thoại:</td>
            <td style="width: 10%;">
                <asp:TextBox ID="txtDienThoai" runat="server" CssClass="form-control"></asp:TextBox>
            </td>
            <td style="width: 10%; text-align: right; padding-right: 5px;">Địa chỉ email:</td>
            <td colspan="3">
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
            </td>
        </tr>

        <tr style="height: 40px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">Dân tộc:</td>
            <td style="width: 10%;">
                <asp:DropDownList ID="ddlDanToc" CssClass ="form-control" runat="server" Style="width: 100%;">
                </asp:DropDownList>
            </td>
            <td style="width: 10%; text-align: right; padding-right: 5px;">Tôn giáo:</td>
            <td style="width: 70%;" colspan="3">
                <asp:DropDownList ID="ddlTonGiao" CssClass ="form-control" runat="server" Style="width: 100%;">
                </asp:DropDownList>
            </td>
        </tr>

        <tr style="height: 40px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">Trường THPT:</td>
            <td colspan="5">
                <table border="0" style="width: 100%;">
                    <tr>
                        <td style="width: 38%;">
                            <asp:TextBox ID="txtTruongTHPT" runat="server" CssClass="form-control"></asp:TextBox>
                        </td>
                        <td style="text-align: right; padding-right: 5px; width: 108px;">Địa chỉ:
                        </td>
                        <td style="width: 19%;">
                            <asp:TextBox ID="txtTruongDiaChi" runat="server" CssClass="form-control"></asp:TextBox>
                        </td>
                        <td style="text-align: right; padding-right: 5px; width: 125px;">Niên khóa:
                        </td>
                        <td>
                            <asp:TextBox ID="txtNienKhoa" runat="server" CssClass="form-control"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>

        <tr style="height: 40px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">Sức khỏe:</td>
            <td colspan="5">
                <table border="0" style="width: 100%;">
                    <tr>
                        <td style="width: 38%;">
                            <asp:TextBox ID="txtSucKhoe" runat="server" CssClass="form-control"></asp:TextBox>
                        </td>
                        <td style="text-align: right; padding-right: 5px; width: 108px;">Chiều cao:
                        </td>
                        <td style="width: 19%;">
                            <asp:TextBox ID="txtChieuCao" runat="server" CssClass="form-control"></asp:TextBox>
                        </td>
                        <td style="text-align: right; padding-right: 5px; width: 125px;">Cân nặng:
                        </td>
                        <td>
                            <asp:TextBox ID="txtCanNang" runat="server" CssClass="form-control"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>

        <tr style="height: 40px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">Ngoại ngữ:</td>
            <td colspan="5">
                <table border="0" style="width: 100%;">
                    <tr>
                        <td style="width: 38%;">
                            <asp:DropDownList ID="ddlNgoaiNgu" CssClass="form-control" runat="server" Style="width: 100%;">
                            </asp:DropDownList>
                        </td>
                        <td style="text-align: right; padding-right: 5px; width: 108px;">TĐ phổ thông:
                        </td>
                        <td style="width: 19%;">
                            <asp:DropDownList ID="ddlTrinhDoPhoThong" CssClass="form-control" runat="server" Style="width: 100%;">
                            </asp:DropDownList>
                        </td>
                        <td style="text-align: right; padding-right: 5px; width: 125px;">TĐ tin học:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlTinHoc" CssClass="form-control" runat="server" Style="width: 100%;">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>

        <tr style="height: 40px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">Số CMND:</td>
            <td colspan="5">
                <table border="0" style="width: 100%;">
                    <tr>
                        <td style="width: 38%;">
                            <asp:TextBox ID="txtCMND" runat="server" CssClass="form-control"></asp:TextBox>
                        </td>
                        <td style="text-align: right; padding-right: 5px; width: 108px;">TNgày cấp:
                        </td>
                        <td style="width: 19%;">
                            <div class='input-group date' id='datetimepicker2' style="margin-left: 0px; width: 100% !important; float: right;">
                                <input type='text' class="form-control" id="txtNgayCapCMND" runat="server" />
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
                        <td style="text-align: right; padding-right: 5px; width: 125px;">Nơi cấp:
                        </td>
                        <td>
                            <asp:TextBox ID="txtNoiCap" runat="server" CssClass="form-control"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>

        <tr style="height: 40px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">Số BHXH:</td>
            <td colspan="5">
                <table border="0" style="width: 100%;">
                    <tr>
                        <td style="width: 38%;">
                            <asp:TextBox ID="txtBHXH" runat="server" CssClass="form-control"></asp:TextBox>
                        </td>
                        <td style="text-align: right; padding-right: 5px; width: 108px;">TK Ngân hàng:
                        </td>
                        <td style="width: 19%;">
                            <asp:TextBox ID="txtTaikhoan" runat="server" CssClass="form-control"></asp:TextBox>
                        </td>
                        <td style="text-align: right; padding-right: 5px; width: 125px;">Nội dung khác:
                        </td>
                        <td>
                            <asp:TextBox ID="txtNoiDungKhac" runat="server" CssClass="form-control"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>

        <tr style="height: 40px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">Giới tính:</td>
            <td style="width: 10%;">
                <asp:CheckBox ID="ckbState" Checked="true" runat="server" Style="font-weight: normal;" />&nbsp;&nbsp;Kích hoạt
            </td>
            <td colspan="4" style="padding-left: 10px;">
                <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
            </td>
        </tr>

        <tr style="height: 40px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">&nbsp;</td>
            <td style="width: 90%;" colspan="5">
                <asp:Button ID="btnSave" runat="server" Text="Ghi nhận" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                <button class="btn btn-success" type="button" onclick="OpenForm1()" id="btnQuaTrinhDaoTao" runat="server">Quá trình đào tạo</button>
                <button class="btn btn-success" type="button" onclick="OpenForm2()" id="btnQuaTrinhCongTac" runat="server">Quá trình công tác</button>
                <button class="btn btn-success" type="button" onclick="OpenForm3()" id="btnKinhNghiem" runat="server">Kinh nghiệm làm việc</button>
                <asp:Button ID="btnCancel" runat="server" Text="Thoát" CssClass="btn btn-default" OnClick="btnCancel_Click" />
            </td>
        </tr>

    </table>

    <input type="hidden" id="txtIDNguoiLaoDong" runat="server" />

    <script type="text/javascript">
        function OpenForm1() {

            var IdNguoiLaoDong = document.getElementById("MainContent_txtIDNguoiLaoDong").value;

            if (IdNguoiLaoDong != 0) {

                var w = 1000;
                var h = 600;

                var dualScreenLeft = window.screenLeft != undefined ? window.screenLeft : screen.left;
                var dualScreenTop = window.screenTop != undefined ? window.screenTop : screen.top;

                var width = window.innerWidth ? window.innerWidth : document.documentElement.clientWidth ? document.documentElement.clientWidth : screen.width;
                var height = window.innerHeight ? window.innerHeight : document.documentElement.clientHeight ? document.documentElement.clientHeight : screen.height;

                var left = ((width / 2) - (w / 2)) + dualScreenLeft;
                var top = ((height / 2) - (h / 2)) + dualScreenTop;
                var newWindow = window.open("QuaTrinhDaoTao.aspx?id=" + IdNguoiLaoDong, "QUÁ TRÌNH ĐÀO TẠO", 'scrollbars=yes, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);

                if (window.focus) {
                    newWindow.focus();
                }
            }
        }

        function OpenForm2() {

            var IdNguoiLaoDong = document.getElementById("MainContent_txtIDNguoiLaoDong").value;

            if (IdNguoiLaoDong != 0) {

                var w = 1000;
                var h = 600;

                var dualScreenLeft = window.screenLeft != undefined ? window.screenLeft : screen.left;
                var dualScreenTop = window.screenTop != undefined ? window.screenTop : screen.top;

                var width = window.innerWidth ? window.innerWidth : document.documentElement.clientWidth ? document.documentElement.clientWidth : screen.width;
                var height = window.innerHeight ? window.innerHeight : document.documentElement.clientHeight ? document.documentElement.clientHeight : screen.height;

                var left = ((width / 2) - (w / 2)) + dualScreenLeft;
                var top = ((height / 2) - (h / 2)) + dualScreenTop;
                var newWindow = window.open("QuaTrinhCongTac.aspx?id=" + IdNguoiLaoDong, "QUÁ TRÌNH CÔNG TÁC", 'scrollbars=yes, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);

                if (window.focus) {
                    newWindow.focus();
                }
            }
        }

        function OpenForm3() {

            var IdNguoiLaoDong = document.getElementById("MainContent_txtIDNguoiLaoDong").value;

            if (IdNguoiLaoDong != 0) {

                var w = 1000;
                var h = 600;

                var dualScreenLeft = window.screenLeft != undefined ? window.screenLeft : screen.left;
                var dualScreenTop = window.screenTop != undefined ? window.screenTop : screen.top;

                var width = window.innerWidth ? window.innerWidth : document.documentElement.clientWidth ? document.documentElement.clientWidth : screen.width;
                var height = window.innerHeight ? window.innerHeight : document.documentElement.clientHeight ? document.documentElement.clientHeight : screen.height;

                var left = ((width / 2) - (w / 2)) + dualScreenLeft;
                var top = ((height / 2) - (h / 2)) + dualScreenTop;
                var newWindow = window.open("KinhNghiemLamViec.aspx?id=" + IdNguoiLaoDong, "KINH NGHIỆM LÀM VIỆC", 'scrollbars=yes, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);

                if (window.focus) {
                    newWindow.focus();
                }
            }
        }

    </script>

</asp:Content>

