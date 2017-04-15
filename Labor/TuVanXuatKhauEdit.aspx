<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="TuVanXuatKhauEdit.aspx.cs" Inherits="Labor_TuVanXuatKhauEdit" %>

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

        $(function () {
            $('#datetimepicker5').datetimepicker({
                format: 'DD/MM/YYYY'
            });
        });

        $(function () {
            $('#datetimepicker6').datetimepicker({
                format: 'DD/MM/YYYY'
            });
        });

        $(function () {
            $('#datetimepicker7').datetimepicker({
                format: 'DD/MM/YYYY'
            });
        });

        $(function () {
            $('#datetimepicker8').datetimepicker({
                format: 'DD/MM/YYYY'
            });
        });

        $(function () {
            $('#datetimepicker9').datetimepicker({
                format: 'DD/MM/YYYY'
            });
        });

        $(function () {
            $('#datetimepicker10').datetimepicker({
                format: 'DD/MM/YYYY'
            });
        });

    </script>

    <table border="0" style="width: 100%; margin-top: -20px;">
        <tr style="height: 36px;">
            <td colspan="5">
                <b>1. Thông tin đơn vị tuyển dụng</b>
            </td>
            <td style ="color:blue; font-weight:bold;"><% Response.Write(this.strHtmlDuHoc); %></td>
        </tr>
        <tr style="height: 36px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">Tên đơn vị:</td>
            <td style="width: 40%;">
                <input type="hidden" name="" id="txtIDDonViTuyenDung" runat="server" />
                <asp:TextBox ID="txtDonViTuyenDungName" runat="server" class="form-control" Style="width: 87% !important; float:left; margin-right:5px;"></asp:TextBox>
                <button class="btn btn-primary" type="button" onclick="ChonTinTuyenDung2()" style="height: 34px !important; line-height: 14px !important;">Chọn</button>
            </td>
            <td style="width: 8%; text-align: right; padding-right: 5px;">Đại diện:</td>
            <td style="width: 18%;">
                <asp:TextBox ID="txtNguoiDaiDien" runat="server" class="form-control"></asp:TextBox>
            </td>
            <td style="width: 10%; text-align: right; padding-right: 5px;">Chức vụ:</td>
            <td style="width: 14%;">
                <asp:TextBox ID="txtChucVu" runat="server" class="form-control"></asp:TextBox>
            </td>
        </tr>
        <tr style="height: 36px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">Địa chỉ:</td>
            <td style="width: 40%;">
                <asp:TextBox ID="txtDiaChi" runat="server" class="form-control" Style="width: 100% !important;"></asp:TextBox>
            </td>
            <td style="width: 8%; text-align: right; padding-right: 5px;">Chức năng:</td>
            <td style="width: 18%;">
                <asp:TextBox ID="txtChucNang" runat="server" class="form-control"></asp:TextBox>
            </td>
            <td style="width: 10%; text-align: right; padding-right: 5px;">Điện thoại:</td>
            <td style="width: 14%;">
                <asp:TextBox ID="txtDienThoai" runat="server" class="form-control"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td colspan="6">

                <ul class="nav nav-tabs" style="margin-left: -15px; margin-top: 10px;">
                    <li class="active"><a data-toggle="tab" href="#home"><b>2. Thông tin người lao động</b></a></li>
                    <li><a data-toggle="tab" href="#menu1">Thông tin phụ huynh</a></li>
                </ul>

                <div class="tab-content">
                    <div id="home" class="tab-pane fade in active">
                        <table border="0" style="width: 100%; margin-top: 10px;">
                            <tr style="height: 36px;">
                                <td style="width: 10%; text-align: right; padding-right: 5px;">Họ tên:</td>
                                <td style="width: 40%;">
                                    <input type="hidden" name="txtIDNldDangKy" id="txtIDNldDangKy" runat="server" />
                                    <asp:TextBox ID="txtNameNldDangKy" runat="server" class="form-control" Style="width: 87% !important; float:left; margin-right:5px;"></asp:TextBox>
                                    <button class="btn btn-primary" type="button" onclick="ChonNguoiLaoDong()" style="height: 34px !important; line-height: 14px !important;">Chọn</button>
                                </td>
                                <td style="width: 8%; text-align: right; padding-right: 5px;">Ngày sinh:</td>
                                <td style="width: 18%;">
                                    <asp:TextBox ID="txtNgaySinh" runat="server" class="form-control"></asp:TextBox>
                                </td>
                                <td style="width: 10%; text-align: right; padding-right: 5px;">Giới tính:</td>
                                <td style="width: 14%;">
                                    <asp:TextBox ID="txtGioiTinh" runat="server" class="form-control"></asp:TextBox>
                                </td>
                            </tr>
                            <tr style="height: 36px;">
                                <td style="width: 10%; text-align: right; padding-right: 5px;">Địa chỉ:</td>
                                <td style="width: 40%;">
                                    <asp:TextBox ID="txtNLDDiaChi" runat="server" class="form-control" Style="width: 100% !important;"></asp:TextBox>
                                </td>
                                <td style="width: 8%; text-align: right; padding-right: 5px;">Số CMND:</td>
                                <td style="width: 18%;">
                                    <asp:TextBox ID="txtCMND" runat="server" class="form-control"></asp:TextBox>
                                </td>
                                <td style="width: 10%; text-align: right; padding-right: 5px;">Điện thoại:</td>
                                <td style="width: 14%;">
                                    <asp:TextBox ID="txtNLDDienThoai" runat="server" class="form-control"></asp:TextBox>
                                </td>
                            </tr>
                            <tr style="height: 36px;">
                                <td style="width: 10%; text-align: right; padding-right: 5px;">Trình độ văn hóa:</td>
                                <td style="width: 40%;">
                                    <asp:TextBox ID="txtTrinhDoVanHoa" runat="server" class="form-control" Style="width: 100% !important;"></asp:TextBox>
                                </td>
                                <td style="width: 8%; text-align: right; padding-right: 5px;">TĐ học vấn:</td>
                                <td style="width: 18%;">
                                    <asp:TextBox ID="TextBox12" runat="server" class="form-control"></asp:TextBox>
                                </td>
                                <td style="width: 10%; text-align: right; padding-right: 5px;">Chuyên ngành:</td>
                                <td style="width: 14%;">
                                    <asp:TextBox ID="TextBox13" runat="server" class="form-control"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="menu1" class="tab-pane fade">
                        <table border="0" style="width: 100%; margin-top: 10px;">
                            <tr style="height: 36px;">
                                <td style="width: 10%; text-align: right; padding-right: 5px;">Họ tên bố:</td>
                                <td style="width: 40%;">
                                    <asp:TextBox ID="txtHoTenBo" runat="server" class="form-control"></asp:TextBox>
                                </td>
                                <td style="width: 8%; text-align: right; padding-right: 5px;">Họ tên mẹ:</td>
                                <td style="width: 42%;">
                                    <asp:TextBox ID="txtHoTenMe" runat="server" class="form-control"></asp:TextBox>
                                </td>
                            </tr>

                            <tr style="height: 36px;">
                                <td style="width: 10%; text-align: right; padding-right: 5px;">Ngày sinh:</td>
                                <td style="width: 40%;">
                                    <div class='input-group date' id='datetimepicker9' style="margin-left: 0px; width: 100% !important; float: right;">
                                        <input type='text' class="form-control" id="txtNgaySinhBo" runat="server" />
                                        <span class="input-group-addon">
                                            <span class="glyphicon glyphicon-calendar"></span>
                                        </span>
                                    </div>

                                    <script type="text/javascript">
                                        $(function () {
                                            $('#datetimepicker9').datetimepicker();
                                        });
                                    </script>
                                </td>
                                <td style="width: 8%; text-align: right; padding-right: 5px;">Ngày sinh:</td>
                                <td style="width: 42%;">
                                    <div class='input-group date' id='datetimepicker10' style="margin-left: 0px; width: 100% !important; float: right;">
                                        <input type='text' class="form-control" id="txtNgaySinhMe" runat="server" />
                                        <span class="input-group-addon">
                                            <span class="glyphicon glyphicon-calendar"></span>
                                        </span>
                                    </div>

                                    <script type="text/javascript">
                                        $(function () {
                                            $('#datetimepicker10').datetimepicker();
                                        });
                                    </script>
                                </td>
                            </tr>

                            <tr style="height: 36px;">
                                <td style="width: 10%; text-align: right; padding-right: 5px;">Địa chỉ:</td>
                                <td style="width: 40%;">
                                    <asp:TextBox ID="txtDiaChiBo" runat="server" class="form-control"></asp:TextBox>
                                </td>
                                <td style="width: 8%; text-align: right; padding-right: 5px;">Địa chỉ:</td>
                                <td style="width: 42%;">
                                    <asp:TextBox ID="txtDiaChiMe" runat="server" class="form-control"></asp:TextBox>
                                </td>
                            </tr>

                            <tr style="height: 36px;">
                                <td style="width: 10%; text-align: right; padding-right: 5px;">Điện thoại:</td>
                                <td style="width: 40%;">
                                    <asp:TextBox ID="txtDienThoaiBo" runat="server" class="form-control"></asp:TextBox>
                                </td>
                                <td style="width: 8%; text-align: right; padding-right: 5px;">Điện thoại:</td>
                                <td style="width: 42%;">
                                    <asp:TextBox ID="txtDienThoaiMe" runat="server" class="form-control"></asp:TextBox>
                                </td>
                            </tr>

                            <tr style="height: 36px;">
                                <td style="width: 10%; text-align: right; padding-right: 5px;">Đơn vị:</td>
                                <td style="width: 40%;">
                                    <asp:TextBox ID="txtDonViBo" runat="server" class="form-control"></asp:TextBox>
                                </td>
                                <td style="width: 8%; text-align: right; padding-right: 5px;">Đơn vị:</td>
                                <td style="width: 42%;">
                                    <asp:TextBox ID="txtDonViMe" runat="server" class="form-control"></asp:TextBox>
                                </td>
                            </tr>

                            <tr style="height: 36px;">
                                <td style="width: 10%; text-align: right; padding-right: 5px;">Chức vụ:</td>
                                <td style="width: 40%;">
                                    <asp:TextBox ID="txtChucVuBo" runat="server" class="form-control"></asp:TextBox>
                                </td>
                                <td style="width: 8%; text-align: right; padding-right: 5px;">Chức vụ:</td>
                                <td style="width: 42%;">
                                    <asp:TextBox ID="txtChucVuMe" runat="server" class="form-control"></asp:TextBox>
                                </td>
                            </tr>

                            <tr style="height: 36px;">
                                <td style="width: 10%; text-align: right; padding-right: 5px;">Địa chỉ đơn vị:</td>
                                <td style="width: 40%;">
                                    <asp:TextBox ID="txtDiaChiDonViBo" runat="server" class="form-control"></asp:TextBox>
                                </td>
                                <td style="width: 8%; text-align: right; padding-right: 5px;">Địa chỉ đơn vị:</td>
                                <td style="width: 42%;">
                                    <asp:TextBox ID="txtDiaChiDonViMe" runat="server" class="form-control"></asp:TextBox>
                                </td>
                            </tr>

                            <tr style="height: 36px;">
                                <td style="width: 10%; text-align: right; padding-right: 5px;">Thu nhập:</td>
                                <td style="width: 40%;">
                                    <asp:TextBox ID="txtThuNhapThangBo" runat="server" class="form-control"></asp:TextBox>
                                </td>
                                <td style="width: 8%; text-align: right; padding-right: 5px;">Thu nhập:</td>
                                <td style="width: 42%;">
                                    <asp:TextBox ID="txtThuNhapThangMe" runat="server" class="form-control"></asp:TextBox>
                                </td>
                            </tr>

                            <tr style="height: 36px;">
                                <td style="width: 10%; text-align: right; padding-right: 5px;">Sổ tiết kiệm:</td>
                                <td style="width: 40%;">
                                    <asp:TextBox ID="txtSoTietKiemBo" runat="server" class="form-control"></asp:TextBox>
                                </td>
                                <td style="width: 8%; text-align: right; padding-right: 5px;">Sổ tiết kiệm:</td>
                                <td style="width: 42%;">
                                    <asp:TextBox ID="txtSoTietKiemMe" runat="server" class="form-control"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>

            </td>
        </tr>



        <tr style="height: 36px;">
            <td colspan="6">
                <b>3. Thông tin tình trạng hồ sơ học sinh</b>
            </td>
        </tr>
        <tr style="height: 36px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">Ngày đăng ký TV:</td>
            <td style="width: 40%;">
                <div class='input-group date' id='datetimepicker1' style="margin-left: 0px; width: 100% !important; float: right;">
                    <input type='text' class="form-control" id="txtNgayDangKyTuVan" runat="server" />
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
            <td style="width: 8%; text-align: right; padding-right: 5px;">Thị trường:</td>
            <td style="width: 18%;">
                <asp:TextBox ID="txtDiaDiem" runat="server" class="form-control"></asp:TextBox>
            </td>
            <td style="width: 10%; text-align: right; padding-right: 5px;">Cán bộ tư vấn:</td>
            <td style="width: 14%;">
                <asp:DropDownList ID="ddlIDCanbo" AutoPostBack="true" runat="server" Style="width: 100%;" CssClass ="form-control">
                </asp:DropDownList>
            </td>
        </tr>
        <tr style="height: 36px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">Kết quả tư vấn:</td>
            <td style="width: 40%;">
                <asp:DropDownList ID="ddlIDKetQuaTuVan" AutoPostBack="true" runat="server" Style="width: 100%;" CssClass ="form-control">
                </asp:DropDownList>
            </td>
            <td style="width: 8%; text-align: right; padding-right: 5px;">Ngày đặt cọc:</td>
            <td style="width: 18%;">
                <div class='input-group date' id='datetimepicker2' style="margin-left: 0px; width: 100% !important; float: right;">
                    <input type='text' class="form-control" id="txtNgayCocTien" runat="server" />
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
            <td style="width: 10%; text-align: right; padding-right: 5px;">Người xử lý:</td>
            <td style="width: 14%;">
                <asp:TextBox ID="txtNguoiXuLy" runat="server" class="form-control"></asp:TextBox>
            </td>
        </tr>
        <tr style="height: 36px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">Đơn vị tiếp nhận:</td>
            <td style="width: 40%;">
                <input type="hidden" name="txtIDDonVi" id="txtIDDonVi" runat="server" />
                <asp:TextBox ID="txtIDDonViName" runat="server" class="form-control" Style="width: 87% !important; float:left; margin-right:5px;"></asp:TextBox>
                <button class="btn btn-primary" type="button" onclick="SelectName()" style="height: 34px !important; line-height: 14px !important;">Chọn</button>
            </td>
            <td style="width: 8%; text-align: right; padding-right: 5px;">Học tiếng:</td>
            <td style="width: 18%;">
                <asp:DropDownList ID="ddlIDDaoTaoMonHoc" AutoPostBack="true" runat="server" Style="width: 100%;" CssClass ="form-control">
                </asp:DropDownList>
            </td>
            <td style="width: 10%; text-align: right; padding-right: 5px;">Nơi học:</td>
            <td style="width: 14%;">
                <asp:TextBox ID="txtNoiDaoTao" runat="server" class="form-control"></asp:TextBox>
            </td>
        </tr>

        <tr style="height: 36px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">Ngày nhập học:</td>
            <td style="width: 40%;">
                <div class='input-group date' id='datetimepicker3' style="margin-left: 0px; width: 100% !important; float: right;">
                    <input type='text' class="form-control" id="txtNgayBatDau" runat="server" />
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>

                <script type="text/javascript">
                    $(function () {
                        $('#datetimepicker3').datetimepicker();
                    });
                </script>
            </td>
            <td style="width: 8%; text-align: right; padding-right: 5px;">Kết thúc:</td>
            <td style="width: 18%;">
                <div class='input-group date' id='datetimepicker4' style="margin-left: 0px; width: 100% !important; float: right;">
                    <input type='text' class="form-control" id="txtNgayKetThuc" runat="server" />
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
            <td style="width: 10%; text-align: right; padding-right: 5px;">DK xuất cảnh:</td>
            <td style="width: 14%;">
                <div class='input-group date' id='datetimepicker5' style="margin-left: 0px; width: 100% !important; float: right;">
                    <input type='text' class="form-control" id="txtNgayXuatCanhDuKien" runat="server" />
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>

                <script type="text/javascript">
                    $(function () {
                        $('#datetimepicker5').datetimepicker();
                    });
                </script>
            </td>
        </tr>

        <tr style="height: 36px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">Ngày Visa:</td>
            <td style="width: 40%;">
                <div class='input-group date' id='datetimepicker6' style="margin-left: 0px; width: 100% !important; float: right;">
                    <input type='text' class="form-control" id="txtNgayViSa" runat="server" />
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>

                <script type="text/javascript">
                    $(function () {
                        $('#datetimepicker6').datetimepicker();
                    });
                </script>
            </td>
            <td style="width: 8%; text-align: right; padding-right: 5px;">Xuất cảnh:</td>
            <td style="width: 18%;">
                <div class='input-group date' id='datetimepicker7' style="margin-left: 0px; width: 100% !important; float: right;">
                    <input type='text' class="form-control" id="txtNgayXuatCanh" runat="server" />
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>

                <script type="text/javascript">
                    $(function () {
                        $('#datetimepicker7').datetimepicker();
                    });
                </script>
            </td>
            <td style="width: 10%; text-align: right; padding-right: 5px;">Ngày về:</td>
            <td style="width: 14%;">
                <div class='input-group date' id='datetimepicker8' style="margin-left: 0px; width: 100% !important; float: right;">
                    <input type='text' class="form-control" id="txtNgayVe" runat="server" />
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>

                <script type="text/javascript">
                    $(function () {
                        $('#datetimepicker8').datetimepicker();
                    });
                </script>
            </td>
        </tr>

        <tr style="height: 36px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">Ghi chú:</td>
            <td style="width: 40%;">
                <asp:TextBox ID="txtNoiDungKhac" runat="server" class="form-control" Style="width: 100% !important;"></asp:TextBox>
            </td>
            <td style="width: 8%; text-align: right; padding-right: 5px;">Người giới thiệu:</td>
            <td style="width: 18%;">
                <asp:TextBox ID="txtNguoiGioiThieu" runat="server" class="form-control"></asp:TextBox>
            </td>
            <td style="width: 10%; text-align: right; padding-right: 5px;">Kết quả:</td>
            <td style="width: 14%;">
                <asp:DropDownList ID="ddlIDKetQuaHoSo" AutoPostBack="true" runat="server" Style="width: 100%;" CssClass ="form-control">
                </asp:DropDownList>
            </td>
        </tr>

        <tr style="height: 60px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;"><b>Trạng thái:</b></td>
            <td style="width: 90%;" colspan="3">
                <asp:DropDownList ID="ddlState" Font-Bold = "true" runat="server" CssClass="form-control" style = "width:18%;">
                    <asp:ListItem Value="0" Selected="True">Chưa xử lý</asp:ListItem>
                    <asp:ListItem Value="1">Đang xử lý</asp:ListItem>
                    <asp:ListItem Value="2">Đã xử lý</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>

        <tr style="height: 20px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">&nbsp;</td>
            <td style="width: 90%;" colspan="3">
                <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
            </td>
        </tr>

        <tr style="height: 36px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">&nbsp;</td>
            <td style="width: 90%;" colspan="3">
                <asp:Button ID="btnSave" runat="server" Text="Ghi nhận" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Thoát" CssClass="btn btn-default" OnClick="btnCancel_Click" />
            </td>
        </tr>

    </table>

    <script type="text/javascript">
        function ChonNguoiLaoDong() {

            var w = 1000;
            var h = 600;

            var dualScreenLeft = window.screenLeft != undefined ? window.screenLeft : screen.left;
            var dualScreenTop = window.screenTop != undefined ? window.screenTop : screen.top;

            var width = window.innerWidth ? window.innerWidth : document.documentElement.clientWidth ? document.documentElement.clientWidth : screen.width;
            var height = window.innerHeight ? window.innerHeight : document.documentElement.clientHeight ? document.documentElement.clientHeight : screen.height;

            var left = ((width / 2) - (w / 2)) + dualScreenLeft;
            var top = ((height / 2) - (h / 2)) + dualScreenTop;
            var newWindow = window.open("ChonNguoiLaoDong2.aspx", "CHỌN NGƯỜI LAO ĐỘNG", 'scrollbars=yes, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);

            if (window.focus) {
                newWindow.focus();
            }
        }

        function ChonTinTuyenDung2() {

            var w = 1000;
            var h = 600;

            var dualScreenLeft = window.screenLeft != undefined ? window.screenLeft : screen.left;
            var dualScreenTop = window.screenTop != undefined ? window.screenTop : screen.top;

            var width = window.innerWidth ? window.innerWidth : document.documentElement.clientWidth ? document.documentElement.clientWidth : screen.width;
            var height = window.innerHeight ? window.innerHeight : document.documentElement.clientHeight ? document.documentElement.clientHeight : screen.height;

            var left = ((width / 2) - (w / 2)) + dualScreenLeft;
            var top = ((height / 2) - (h / 2)) + dualScreenTop;
            var newWindow = window.open("ChonTinTuyenDung2.aspx", "CHỌN TIN TUYỂN DỤNG", 'scrollbars=yes, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);

            if (window.focus) {
                newWindow.focus();
            }
        }

    </script>

</asp:Content>

