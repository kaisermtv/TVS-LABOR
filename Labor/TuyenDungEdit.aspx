<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="TuyenDungEdit.aspx.cs" Inherits="Admin_TuyenDungEdit" %>

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

    <script type="text/javascript">
        function ShowPopup() {
            $("#btnShowPopup").click();
        }
    </script>

    <div style="border: solid 1px red; display: table; z-index:10000;">
        <button type="button" style="display: none;" id="btnShowPopup" class="btn btn-primary btn-lg"
            data-toggle="modal" data-target="#myModal">
            Launch demo modal
        </button>
        <div class="modal fade" id="myModal">
            <div class="modal-dialog" style="margin: auto; width: 600px; left: 0px;">
                <div class="modal-content" style="margin: auto;">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title">Thông báo</h4>
                    </div>
                    <div class="modal-body">
                        <asp:Label ID="lblMessage" runat="server" />
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            Close</button>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <table border="0" style="margin-top: -20px;">
        <tr style="height: 40px;">
            <td colspan="6">
                <b>I. THÔNG TIN ĐƠN VỊ TUYỂN DỤNG</b>
            </td>
        </tr>
        <tr style="height: 40px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">Mã tuyển dụng:</td>
            <td style="width: 12%;">
                <asp:TextBox ID="txtMaTuyenDung" runat="server" CssClass="form-control"></asp:TextBox>
            </td>
            <td style="width: 8%; text-align: right; padding-right: 5px;">Tên đơn vị:</td>
            <td style="width: 40%;">
                <input type="hidden" name="txtIDDonVi" id="txtIDDonVi" runat="server" />
                <asp:TextBox ID="txtTenDonVi" ReadOnly="true" runat="server" CssClass="form-control" Style="width: 80% !important; float: left;"></asp:TextBox>
                <button class="btn btn-primary" type="button" onclick="SelectName()" style="height: 34px !important; margin-left: 10px; line-height: 14px !important;">Chọn</button>
            </td>
            <td style="width: 10%; text-align: right; padding-right: 5px;">Ngành nghề:</td>
            <td style="width: 20%;">
                <asp:DropDownList ID="ddlIDNganhNghe" runat="server" CssClass="form-control" Style="width: 100%;">
                </asp:DropDownList>
            </td>
        </tr>
        <tr style="height: 40px;">
            <td colspan="6">
                <b>II. THÔNG TIN TUYỂN DỤNG</b>
            </td>
        </tr>

        <tr style="height: 40px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">Chức vụ:</td>
            <td style="width: 12%;">
                <asp:DropDownList ID="ddlIDChucVu" runat="server" CssClass="form-control" Style="width: 100%;">
                </asp:DropDownList>
            </td>
            <td style="width: 8%; text-align: right; padding-right: 5px;">Số lượng:</td>
            <td style="width: 40%;">
                <asp:TextBox ID="txtSoLuongTuyenDung" runat="server" CssClass="form-control"></asp:TextBox>
            </td>
            <td style="width: 10%; text-align: right; padding-right: 5px;">Nhóm ngành:</td>
            <td style="width: 20%;">
                <asp:DropDownList ID="ddlNhomNganh" runat="server" CssClass="form-control" Style="width: 100%; float: left;">
                    <asp:ListItem Value="0"> Không chọn </asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>

        <tr style="height: 40px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">Giới tính:</td>
            <td style="width: 12%;">
                <asp:DropDownList ID="ddlIDGioiTinh" runat="server" CssClass="form-control" Style="width: 100%;">
                </asp:DropDownList>
            </td>
            <td style="width: 8%; text-align: right; padding-right: 5px;">Độ tuổi:</td>
            <td style="width: 40%;">
                <asp:DropDownList ID="ddlIDDoTuoi" runat="server" CssClass="form-control" Style="width: 30%;">
                </asp:DropDownList>
            </td>
            <td style="width: 10%; text-align: right; padding-right: 5px;">&nbsp;</td>
            <td style="width: 20%;">&nbsp;
            </td>
        </tr>

        <tr style="height: 40px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">TĐ Chuyên môn:</td>
            <td style="width: 12%;">
                <asp:DropDownList ID="ddlIDTrinhDoChuyenMon" CssClass="form-control" runat="server" Style="width: 100%;">
                </asp:DropDownList>
            </td>
            <td style="width: 8%; text-align: right; padding-right: 5px;">YC.Ngoại ngữ:</td>
            <td>
                <table style="width: 90%;" >
                    <tr>
                        <td style="width: 33%;">
                            <asp:DropDownList ID="ddlyeuCauNgoaiNgu" CssClass="form-control" runat="server" Style="width: 100%;">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 33%;text-align:right;padding-right:10px">
                            YC.Tin Học:
                        </td>
                        <td style="width: 33%;">
                            <asp:DropDownList ID="ddlyeuCauTinHoc" runat="server" CssClass="form-control" Style="width: 100%;">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>

                
            </td>
            <td style="width: 10%; text-align: right; padding-right: 5px;">Năm kinh nghiệm:</td>
            <td style="width: 20%;">
                <asp:TextBox ID="txtNamKinhNghiem" runat="server" CssClass="form-control"></asp:TextBox>
            </td>
            
        </tr>

        <tr style="height: 40px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">Nội dung:</td>
            <td style="width: 90%;" colspan="5">
                <asp:TextBox ID="txtNoiDungKhac" runat="server" TextMode="MultiLine" CssClass="form-control" style="resize: vertical;"></asp:TextBox>
            </td>
        </tr>

        <tr style="height: 40px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">Mô tả:</td>
            <td style="width: 90%;" colspan="5">
                <asp:TextBox ID="txtMoTa" runat="server" CssClass="form-control"></asp:TextBox>
            </td>
        </tr>


        <tr style="height: 40px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">Ưu tiên:</td>
            <td colspan="5">
                <asp:TextBox ID="txtUuTien" runat="server" CssClass="form-control"></asp:TextBox>
            </td>
        </tr>

        <tr style="height: 40px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">Quyền lợi:</td>
            <td style="width: 90%;" colspan="5">
                <asp:TextBox ID="txtQuyenLoi" runat="server" CssClass="form-control"></asp:TextBox>
            </td>
        </tr>

        <tr style="height: 40px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">Địa điểm:</td>
            <td style="width: 90%;" colspan="5">
                <asp:TextBox ID="txtDiaDiem" runat="server" CssClass="form-control"></asp:TextBox>
            </td>
        </tr>

        <tr style="height: 40px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">Tỉnh, thành phố:</td>
            <td style="width: 12%;">
                <asp:DropDownList ID="ddlIDTinh" runat="server" Style="width: 100%;" CssClass="form-control" OnSelectedIndexChanged="ddlIDTinh_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td style="width: 8%; text-align: right; padding-right: 5px;">Mức lương:</td>
            <td colspan="2">
                <table style="width: 90%;" >
                    <tr>
                        <td style="width: 33%;">
                            <asp:DropDownList ID="ddlIDMucLuong" runat="server" CssClass="form-control" Style="width: 100%;">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 33%;text-align:right;padding-right:10px">
                            Thời gian làm việc:
                        </td>
                        <td style="width: 33%;">
                            <asp:DropDownList ID="ddlThoiGianLamViec" runat="server" CssClass="form-control" Style="width: 100%;">
                                <asp:ListItem Value="1"> Hành chính </asp:ListItem>
                                <asp:ListItem Value="2"> Bán thời gian </asp:ListItem>
                                <asp:ListItem Value="3"> Theo ca </asp:ListItem>
                                <asp:ListItem Value="4"> Toàn thời gian </asp:ListItem>
                                <asp:ListItem Value="5"> Thỏa thuận </asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width: 20%;">
                <asp:CheckBox ID="ckbNuocNgoai" runat="server" Style="font-weight: normal;" />&nbsp;&nbsp;Làm việc ở nước ngoài
            </td>
        </tr>

        <tr style="height: 40px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">Ngày bắt đầu:</td>
            <td style="width: 12%;">
                <div class='input-group date' id='datetimepicker1' style="margin-left: 0px; width: 100% !important; float: right;">
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
            <td style="width: 8%; text-align: right; padding-right: 5px;">Ngày kết thúc:</td>
            <td style="width: 40%;">
                <div class='input-group date' id='datetimepicker2' style="margin-left: 0px; width: 160px !important;">
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
            <td style="width: 10%; text-align: right; padding-right: 5px;">Trạng thái:</td>
            <td style="width: 20%;">
                <asp:CheckBox ID="ckbState" Checked="true" runat="server" Style="font-weight: normal;" />&nbsp;&nbsp;Kích hoạt
            </td>
        </tr>

        <tr style="height: 50px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">&nbsp;</td>
            <td colspan="5"></td>
        </tr>

    </table>

    <br /><br />&nbsp;

    <footer style="height: 43px !important; margin-bottom: 0px; margin-left: -30px; width: 100%; text-align: justify; background-color: #f0f0f0;z-index:10">
        <table border="0" style="width: 100%; margin-top: -8px;">
            <tr>
                <td style="width: 11%; text-align: right; padding-right: 5px;">&nbsp;</td>
                <td>
                    <asp:Button ID="btnSave" runat="server" Text="Lưu thông tin" Width="150px" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                    <asp:Button ID="btnUuTien" runat="server" CssClass="btn btn-success" Text="Ưu tiên cao nhất" OnClick="btnUuTien_Click" />
                </td>
                <td>
                    <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red"></asp:Label></td>
                <td style="text-align: right; padding-right: 65px;">
                    <a href="/Labor/TuyenDungEdit.aspx" class="btn btn-default">Thêm mới</a>
                    <a href="/Labor/TuyenDung.aspx" class="btn btn-default">Thoát</a>
                </td>
            </tr>
        </table>
    </footer>
    <input type="hidden" id="txtIDTuyenDung" runat="server" />

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
            var newWindow = window.open("ChonDoanhNghiep.aspx", "CHỌN DOANH NGHIỆP", 'scrollbars=yes, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);

            if (window.focus) {
                newWindow.focus();
            }
        }
    </script>

</asp:Content>

