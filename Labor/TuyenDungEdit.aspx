<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="TuyenDungEdit.aspx.cs" Inherits="Admin_TuyenDungEdit" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
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

    <div style="border: solid 1px red; display: table; z-index: 10000;">
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
                <asp:TextBox ID="txtMaTuyenDung" ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>
            </td>
            <td style="width: 8%; text-align: right; padding-right: 5px;">Tên đơn vị:</td>
            <td style="width: 70%;" colspan="3">
                <input type="hidden" name="txtIDDonVi" id="txtIDDonVi" runat="server" />
                <asp:TextBox ID="txtTenDonVi" ReadOnly="true" runat="server" CssClass="form-control" Style="width: 92% !important; float: left;"></asp:TextBox>
                <button class="btn btn-primary" type="button" onclick="SelectName()" style="height: 34px !important; margin-left: 10px; line-height: 14px !important;">Chọn</button>
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
                <asp:DropDownList ID="ddlIdVitri" runat="server" CssClass="form-control" Style="width: 100%;">
                </asp:DropDownList>
            </td>
            <td style="width: 8%; text-align: right; padding-right: 5px;">Nhóm ngành:</td>
            <td style="width: 40%;">
                <table style="width: 100%">
                    <tr>
                        <td style="width: 45%">
                            <asp:DropDownList ID="ddlNhomNganh" AutoPostBack="true" runat="server" CssClass="form-control" Style="width: 100%; float: left;" OnSelectedIndexChanged="ddlNhomNganh_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 20%; padding-right: 5px; text-align: right">Ngành nghề: </td>
                        <td>
                            <asp:DropDownList ID="ddlNganhNghe" runat="server" CssClass="form-control" Style="width: 100%; float: left;">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width: 10%; text-align: right; padding-right: 5px;">Chức vụ:</td>
            <td style="width: 20%;">
                <asp:DropDownList ID="ddlIDChucVu" runat="server" CssClass="form-control" Style="width: 100%;">
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
                <table style="width: 100%">
                    <tr>
                        <td style="width: 45%">
                            <asp:DropDownList ID="ddlIDDoTuoi" runat="server" CssClass="form-control" Style="width: 100%;">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 20%; padding-right: 5px; text-align: right">Kinh nghiệm: </td>
                        <td>
                            <asp:TextBox ID="txtNamKinhNghiem" runat="server" CssClass="form-control"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width: 10%; text-align: right; padding-right: 5px;">Số lượng:</td>
            <td style="width: 20%;">
                <asp:TextBox ID="txtSoLuongTuyenDung" runat="server" CssClass="form-control"></asp:TextBox>
            </td>
        </tr>

        <tr style="height: 40px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">TĐ Chuyên môn:</td>
            <td style="width: 90%;" colspan="5">
                <asp:DropDownList ID="ddlIDTrinhDoChuyenMon" CssClass="form-control" runat="server" Style="width: 100%;">
                </asp:DropDownList>
            </td>
        </tr>

        <tr style="height: 40px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">YC.Ngoại ngữ:</td>
            <td style="width: 12%;">
                <asp:DropDownList ID="ddlyeuCauNgoaiNgu" CssClass="form-control" runat="server" Style="width: 100%;">
                </asp:DropDownList>
            </td>
            <td style="width: 8%; text-align: right; padding-right: 5px;">Trình độ:</td>
            <td style="width: 40%;">
                <table style="width: 100%">
                    <tr>
                        <td style="width: 45%">
                            <asp:DropDownList ID="ddlTrinhDoNgoaiNgu" CssClass="form-control" runat="server" Style="width: 100%;">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 20%; padding-right: 5px; text-align: right">YC.Tin Học:</td>
                        <td>
                            <asp:DropDownList ID="ddlyeuCauTinHoc" runat="server" CssClass="form-control" Style="width: 100%;">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width: 10%; text-align: right; padding-right: 5px;">Tin học:</td>
            <td style="width: 20%;">
                <asp:DropDownList ID="ddlTinHoc" CssClass="form-control" runat="server" Style="width: 100%;">
                </asp:DropDownList>
            </td>
        </tr>

        <tr style="height: 40px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">Vị trí mô tả:</td>
            <td style="width: 90%;" colspan="5">
                <asp:TextBox ID="txtNoiDungKhac" runat="server" CssClass="form-control"></asp:TextBox>
            </td>
        </tr>

        <%--<tr style="height: 40px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">Nội dung:</td>
            <td style="width: 90%;" colspan="5">
                <CKEditor:CKEditorControl ID="txtNoiDungKhac" CssClass="form-control" runat="server" Height="210" Width="100%" Style="resize: vertical;" BasePath="~/ckeditor"></CKEditor:CKEditorControl>
            </td>
        </tr>--%>

        <tr style="height: 40px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">Yêu cầu:</td>
            <td style="width: 90%;" colspan="5">
                <CKEditor:CKEditorControl ID="txtMoTa" CssClass="form-control" runat="server" Height="210" Width="100%" Style="resize: vertical;" BasePath="~/ckeditor"></CKEditor:CKEditorControl>
            </td>
        </tr>


        <tr style="height: 40px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">Ưu tiên:</td>
            <td colspan="5">
                <asp:TextBox ID="txtUuTien" runat="server" TextMode="MultiLine" style="resize:vertical" Rows="1" CssClass="form-control"></asp:TextBox>
            </td>
        </tr>

        <tr style="height: 40px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">Quyền lợi:</td>
            <td style="width: 90%;" colspan="5">
                <asp:TextBox ID="txtQuyenLoi" runat="server" TextMode="MultiLine" style="resize:vertical"  Rows="1" CssClass="form-control"></asp:TextBox>
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
            <td style="width: 40%;">
                <table style="width: 100%" border="0">
                    <tr>
                        <td style="width: 45%">
                            <asp:DropDownList ID="ddlIDMucLuong" runat="server" CssClass="form-control" Style="width: 100%;">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 20%; padding-right: 5px; text-align: right">TG làm việc:</td>
                        <td>
                            <asp:DropDownList ID="ddlThoiGianLamViec" runat="server" CssClass="form-control" Style="width: 100%;">
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
            <td style="width: 30%;" colspan="2">
                <table border="0" style ="width:100%;">
                    <tr>
                        <td style ="padding-left:10px;">
                            <asp:CheckBox ID="ckbNuocNgoai" runat="server" Style="font-weight: normal;" />&nbsp;Nước ngoài
                        </td>
                        <td style ="padding-right:10px;">
                            <input type="hidden" name="txtIdQuocGia" id="txtIdQuocGia" runat="server" />
                            <input id="txtNameQuocGia" readonly="true" runat="server" class="form-control" style="width: 100% !important; float: left;"/>
                        </td>
                        <td style ="width:50px;">
                            <button class="btn btn-primary" type="button" onclick="SelectNational()" style="height: 34px !important; line-height: 14px !important;">Chọn</button>
                        </td>
                    </tr>
                </table>
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
            <td style="width: 30%; padding-left:10px;" colspan="2">
                <asp:CheckBox ID="ckbState" Checked="true" runat="server" Style="font-weight: normal;" />&nbsp;&nbsp;Kích hoạt
            </td>
        </tr>

        <tr style="height: 50px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">&nbsp;</td>
            <td colspan="5"></td>
        </tr>

    </table>

    <br />
    <br />
    &nbsp;

    <footer style="height: 43px !important; margin-bottom: 0px; margin-left: -30px; width: 100%; text-align: justify; background-color: #f0f0f0; z-index: 10">
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
                    <a href="/Labor/DoanhNghiepEdit.aspx?id=<%=txtIDDonVi.Value %>" class="btn btn-danger" style="color: #fff;">Thông tin doanh nghiệp</a>
                    <a href="/Labor/TuyenDungEdit.aspx?did=<%=txtIDDonVi.Value %>&n=<%= HttpUtility.UrlEncode(txtTenDonVi.Text) %>" class="btn btn-default">Thêm mới</a>
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

        function SelectNational() {

            var ckbNuocNgoai = document.getElementById("MainContent_ckbNuocNgoai").checked;

            if (ckbNuocNgoai) {

                var w = 1000;
                var h = 600;

                var dualScreenLeft = window.screenLeft != undefined ? window.screenLeft : screen.left;
                var dualScreenTop = window.screenTop != undefined ? window.screenTop : screen.top;

                var width = window.innerWidth ? window.innerWidth : document.documentElement.clientWidth ? document.documentElement.clientWidth : screen.width;
                var height = window.innerHeight ? window.innerHeight : document.documentElement.clientHeight ? document.documentElement.clientHeight : screen.height;

                var left = ((width / 2) - (w / 2)) + dualScreenLeft;
                var top = ((height / 2) - (h / 2)) + dualScreenTop;
                var newWindow = window.open("ChonQuocGia.aspx", "CHỌN QUỐC GIA", 'scrollbars=yes, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);

                if (window.focus) {
                    newWindow.focus();
                }
            }
        }

    </script>

</asp:Content>

