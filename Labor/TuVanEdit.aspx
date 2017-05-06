<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="TuVanEdit.aspx.cs" Inherits="Admin_TuVanEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <!-- Đặt ở đây không phải master - vì bị đè -->
    <script src="../Scripts/select2.min.js"></script>
    <link href="../css/select2.min.css" rel="stylesheet" />

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
        function submitButton(event) {
            if (event.which == 13) {
                $('#btnGetInformation').trigger('click');
            }
        }
    </script>
    <style>
        a {
            text-decoration: none;
            color: #000;
        }

            a:link {
                text-decoration: none;
                color: #000;
            }

            a:hover {
                text-decoration: none;
                color: #000;
            }
    </style>

    <table border="0" style="margin-top: -20px;">
        <tr style="height: 40px;">
            <td style="width: 90%;" colspan="7">
                <table border="0" style="width: 100%;">
                    <tr>
                        <td style="width: 20%;">
                            <b>I. THÔNG TIN NGƯỜI LAO ĐỘNG</b>
                        </td>
                        <td style="width: 10%; text-align: right; padding-right: 5px;">&nbsp;</td>
                        <td>&nbsp;
                        </td>
                        <td style="width: 20%; text-align: right;">
                            <asp:Button ID="btnCancel" runat="server" Text="Thoát" CssClass="btn btn-default" OnClick="btnCancel_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>

        <tr style="height: 40px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">Loại lao động:
                
            </td>
            <td style="width: 10%;">
                <asp:DropDownList ID="ddlIdLoaiLaoDong" CssClass="form-control" runat="server" Style="width: 100%;">
                    <asp:ListItem Value="1">Lao động BHTN</asp:ListItem>
                    <asp:ListItem Value="0">Lao động tự do</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="width: 10%; text-align: right; padding-right: 5px;">Tìm kiếm:
            </td>
            <td style="width: 40%;" colspan="4">

                <table style="width: 100%;">
                    <tr>
                        <td style="width: 200px;">
                            <asp:TextBox ID="txtMa" runat="server" CssClass="form-control" onKeyDown="submitButton(event)" Style="background-color: aqua;"></asp:TextBox>
                        </td>
                        <td style="width: 40px; padding-left: 5px;">

                            <asp:Button ID="btnGetInformation" runat="server" Text="..." OnClick="btnGetInformation_Click" />
                        </td>
                        <td style="text-align: right; width: 90px; padding-right: 5px;">Họ và tên:</td>
                        <td style="width: 150px">
                            <asp:TextBox ID="txtHoVaTen" runat="server" CssClass="form-control"></asp:TextBox>
                        </td>
                        <td style="text-align: right; padding-right: 5px;">Giới tính: </td>
                        <td>
                            <asp:DropDownList ID="ddlGioiTinh" CssClass="form-control" runat="server" Style="width: 100%;">
                                <asp:ListItem Value="1">Nam</asp:ListItem>
                                <asp:ListItem Value="0">Nữ</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="text-align: right; padding-right: 5px;">Ngày sinh :</td>
                        <td style="width: 150px">
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
                </table>

            </td>
        </tr>

        <tr style="height: 40px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">Số CMND:</td>
            <td style="width: 10%;">
                <asp:TextBox ID="txtCMND" runat="server" CssClass="form-control" MaxLength="9"></asp:TextBox>
            </td>

            <td style="width: 10%; text-align: right; padding-right: 5px;">Ngày cấp:</td>
            <td style="width: 20%;">
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

            <td style="width: 10%; text-align: right; padding-right: 5px;">Nơi cấp:</td>
            <td style="width: 40%;" colspan="2">
                <asp:TextBox ID="txtNoiCap" runat="server" CssClass="form-control"></asp:TextBox>
            </td>
        </tr>

        <tr style="height: 40px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">Số sổ BHXH:</td>
            <td style="width: 10%;">
                <asp:TextBox ID="txtBHXH" runat="server" CssClass="form-control" MaxLength="10"></asp:TextBox>
            </td>
            <td style="width: 10%; text-align: right; padding-right: 5px;">Điện thoại:</td>
            <td style="width: 40%;">
                <asp:TextBox ID="txtDienThoai" runat="server" CssClass="form-control"></asp:TextBox>
            </td>
            <td style="width: 10%; text-align: right; padding-right: 5px;">Địa chỉ email:</td>
            <td style="width: 20%;" colspan="2">
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
            </td>
        </tr>

        <tr style="height: 40px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">Dân tộc:</td>
            <td style="width: 10%;">
                <asp:DropDownList ID="ddlDanToc" CssClass="form-control" runat="server" Style="width: 100%;">
                </asp:DropDownList>
            </td>
            <td style="width: 10%; text-align: right; padding-right: 5px;">Tôn giáo:</td>
            <td style="width: 70%;" colspan="4">
                <asp:DropDownList ID="ddlTonGiao" CssClass="form-control" runat="server" Style="width: 100%;">
                </asp:DropDownList>
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
                                    <asp:DropDownList ID="ddlXa_TT" runat="server" CssClass="form-control" Style="width: 100%;">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="width: 10%; text-align: right; padding-right: 5px;">Khối, xóm:</td>
                    <td style="width: 20%;">
                        <asp:TextBox ID="txtXom_TT" runat="server" CssClass="form-control"></asp:TextBox>
                    </td>

                    <td rowspan="2">
                        <asp:Button ID="btnCopy" runat="server" Text="&dArr;" Style="height: 75px; margin-left: 3px" CssClass="btn btn-primary" OnClick="btnCopy_Click" /></td>
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
                                    <asp:DropDownList ID="ddlXa_DC" runat="server" CssClass="form-control" Style="width: 100%;">
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
            <td style="width: 10%; text-align: right; padding-right: 5px;">Sức khỏe:</td>
            <td style="width: 10%;">
                <asp:TextBox ID="txtSucKhoe" runat="server" CssClass="form-control" Style="width: 100%;"></asp:TextBox>
            </td>
            <td style="width: 10%; text-align: right; padding-right: 5px;">Chiều cao (cm):</td>
            <td style="width: 40%;">
                <table style="width: 100%;">
                    <tr>
                        <td style="width: 35%;">
                            <asp:TextBox ID="txtChieuCao" runat="server" CssClass="form-control"></asp:TextBox>
                        </td>
                        <td style="text-align: right; width: 110px; padding-right: 5px;">Cân nặng (Kg):</td>
                        <td>
                            <asp:TextBox ID="txtCanNang" runat="server" CssClass="form-control"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width: 10%; text-align: right; padding-right: 5px;">TĐ phổ thông:</td>
            <td style="width: 20%;" colspan="2">
                <asp:DropDownList ID="ddlTrinhDoPhoThong" CssClass="form-control" runat="server" Style="width: 100%;">
                </asp:DropDownList>
            </td>
        </tr>

        <tr style="height: 40px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">Ngoại ngữ:</td>
            <td style="width: 10%;">
                <asp:DropDownList ID="ddlNgoaiNgu" CssClass="form-control" runat="server" Style="width: 100%;">
                </asp:DropDownList>
            </td>
            <td style="width: 10%; text-align: right; padding-right: 5px;">Trình độ:</td>
            <td style="width: 40%;">
                <table style="width: 100%;">
                    <tr>
                        <td style="width: 35%;">
                            <asp:DropDownList ID="ddlTrinhDoNgoaiNgu" CssClass="form-control" runat="server" Style="width: 100%;">
                            </asp:DropDownList>
                        </td>
                        <td style="text-align: right; width: 110px; padding-right: 5px;">Tin học:</td>
                        <td>
                            <asp:DropDownList ID="ddlTinHoc" CssClass="form-control" runat="server" Style="width: 100%;">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width: 10%; text-align: right; padding-right: 5px;">Trình độ:</td>
            <td style="width: 20%;" colspan="2">
                <asp:DropDownList ID="ddlTrinhDoTinHoc" CssClass="form-control" runat="server" Style="width: 100%;">
                </asp:DropDownList>
            </td>
        </tr>

        <tr style="height: 40px;">
            <td colspan="7">
                <table style="width: 100%;" border="0">
                    <tr>
                        <td style="width: 9.5%; text-align: right; padding-right: 5px;">Trình độ đào tạo:</td>
                        <td style="width: 32.5%;">
                            <asp:TextBox ID="txtTrinhDoDaoTao" runat="server" CssClass="form-control"></asp:TextBox>
                        </td>
                        <td style="text-align: right; width: 110px; padding-right: 5px;">Kỹ năng nghề:</td>
                        <td>
                            <asp:TextBox ID="txtTrinhDoKyNangNghe" runat="server" CssClass="form-control" Style="width: 100%;"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>

        <tr style="height: 40px;">
            <td colspan="7">
                <table style="width: 100%;">
                    <tr>
                        <td style="width: 9.5%; text-align: right; padding-right: 5px;">Khả năng nổi trội:</td>
                        <td style="width: 32.5%;">
                            <asp:TextBox ID="txtKhaNangNoiTroi" runat="server" CssClass="form-control"></asp:TextBox>
                        </td>
                        <td style="width: 110px; text-align: right; padding-right: 5px;">Mức lương TN:</td>
                        <td style="width: 10%;">
                            <asp:TextBox ID="txtMucLuongTN" runat="server" Text="0" CssClass="form-control" Style="width: 100%;"></asp:TextBox>
                        </td>
                        <td style="width: 75px; text-align: right; padding-right: 5px;">Lý do TN:</td>
                        <td>
                            <asp:TextBox ID="txtLyDoTN" runat="server" CssClass="form-control"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>

        <tr style="height: 40px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">CV trước TN:</td>
            <td style="width: 90%;" colspan="6">
                <asp:TextBox ID="txtCongViecTruocThatNghiep" runat="server" CssClass="form-control"></asp:TextBox>
            </td>
        </tr>

        <tr style="height: 40px;">
            <td style="width: 90%;" colspan="7">
                <b>II. TÌNH TRẠNG TÌM KIẾM VIỆC LÀM HIỆN NAY</b>
            </td>
        </tr>

        <tr style="height: 40px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">DN liên hệ xin việc:</td>
            <td style="width: 90%;" colspan="6">
                <asp:TextBox ID="txtDnDaLienHe" runat="server" CssClass="form-control"></asp:TextBox>
            </td>
        </tr>

        <tr style="height: 40px;">
            <td style="width: 90%;" colspan="7">
                <b>III. NHU CẦU TƯ VẤN, GIỚI THIỆU VIỆC LÀM</b>
            </td>
        </tr>

        <tr style="height: 40px;">
            <td style="width: 90%;" colspan="7">
                <b>1.Tư vấn:</b>
            </td>
        </tr>

        <tr style="height: 40px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">Đăng ký tư vấn: </td>
            <td style="width: 90%;" colspan="6">
                <table border="0">
                    <tr>
                        <td style="width: 30px"></td>
                        <td>
                            <asp:CheckBox ID="ckbTuVanPhapLuat" runat="server" />&nbsp;Chính sách, pháp luật lao động&nbsp;&nbsp;&nbsp;</td>
                        <td>
                            <asp:CheckBox ID="ckbTuVanViecLam" runat="server" />&nbsp;Việc làm trong nước&nbsp;&nbsp;&nbsp;</td>
                        <td>
                            <asp:CheckBox ID="ckbTuVanBHTN" runat="server" />&nbsp;Bảo hiểm thất nghiệp&nbsp;&nbsp;&nbsp;</td>
                        <td>&nbsp;</td>
                        <td rowspan="2" style="padding-left: 10px;">
                            <button class="btn btn-success" type="button" onclick="XemTinTuyenDung('0')"><% Response.Write(this.strBtnViecLamTrongNuoc); %></button>
                            <button class="btn btn-success" type="button" onclick="XemTinTuyenDung('1')"><% Response.Write(this.strBtnViecLamNgoai); %></button>
                            <button class="btn btn-success" type="button" onclick="ChonKhoaHoc()"><% Response.Write(this.strBtnDaoTaoNghe); %></button>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:CheckBox ID="ckbTuVanXuatKhauLaoDong" runat="server" />&nbsp;Xuất khẩu lao động&nbsp;&nbsp;&nbsp;</td>
                        <td>
                            <asp:CheckBox ID="ckbTuVanDuHoc" runat="server" />&nbsp;Du học&nbsp;&nbsp;&nbsp;</td>
                        <td>
                            <asp:CheckBox ID="ckbTuVanHocNghe" runat="server" />&nbsp;Tư vấn đào tạo&nbsp;&nbsp;&nbsp;</td>
                        <td>
                            <asp:CheckBox ID="ckbTuVanKhac" runat="server" />&nbsp;Khác&nbsp;&nbsp;&nbsp;</td>
                    </tr>
                </table>

            </td>
        </tr>

        <tr style="height: 40px;">
            <td style="width: 90%;" colspan="7">
                <b>2.Giới thiệu việc làm:</b>
            </td>
        </tr>

    </table>

    <ul class="nav nav-tabs">
        <li class="active"><a data-toggle="tab" href="#home">Đề xuất thứ nhất</a></li>
        <li><a data-toggle="tab" href="#menu1">Đề xuất thứ hai</a></li>
    </ul>

    <div class="tab-content">
        <div id="home" class="tab-pane fade in active" style="margin: 0px;">
            <table border="0" style="width: 100%; margin-top: 10px;">
                <tr style="height: 40px;">
                    <td style="width: 10%; text-align: right; padding-right: 5px;">Vị trí công việc:</td>
                    <td style="width: 90%;" colspan="6">
                        <asp:TextBox ID="txtViTriCongViec" CssClass="form-control" Visible="true" runat="server" Height="0" Width="0" BorderWidth="0" Style="margin-top: -10px; z-index: 10; visibility: hidden;"></asp:TextBox>
                        <!---Tự động hoàn tất -->
                        <select class="js-example-basic-multiple" id="ddlQickSelect" multiple="multiple" style="width: 100%">
                            <%foreach (string i in lv_Vitri)
                              {%>
                            <option value="<%=i.ToString() %>"><%=i.ToString() %></option>
                            <%} %>
                        </select>

                    </td>
                </tr>

                <tr style="height: 40px;">
                    <td style="width: 10%; text-align: right; padding-right: 5px;">Lương thấp nhất:</td>
                    <td style="width: 90%;" colspan="6">
                        <asp:TextBox ID="txtMucLuongThapNhat" runat="server" CssClass="form-control"></asp:TextBox>
                    </td>
                </tr>

                <tr style="height: 40px;">
                    <td style="width: 10%; text-align: right; padding-right: 5px;">Điều kiện làm việc:</td>
                    <td style="width: 90%;" colspan="6">
                        <asp:TextBox ID="txtDieuKienLamViec" runat="server" CssClass="form-control"></asp:TextBox>
                    </td>
                </tr>

                <tr style="height: 40px;">
                    <td style="width: 10%; text-align: right; padding-right: 5px;">Địa điểm làm việc:</td>
                    <td style="width: 90%;" colspan="6">
                        <asp:TextBox ID="txtDiaDiemLamViec" runat="server" CssClass="form-control"></asp:TextBox>
                    </td>
                </tr>

                <tr style="height: 40px;">
                    <td style="width: 10%; text-align: right; padding-right: 5px;">Nội dung khác:</td>
                    <td style="width: 90%;" colspan="6">
                        <asp:TextBox ID="txtNoiDungKhac" runat="server" CssClass="form-control"></asp:TextBox>
                    </td>
                </tr>

                <tr style="height: 20px;">
                    <td style="width: 10%; text-align: right; padding-right: 5px;">&nbsp;</td>
                    <td style="width: 90%;" colspan="6">&nbsp;
                    </td>
                </tr>
            </table>
        </div>
        <div id="menu1" class="tab-pane fade">
            <table border="0" style="width: 100%; margin-top: 10px;">
                <tr style="height: 40px;">
                    <td style="width: 10%; text-align: right; padding-right: 5px;">Vị trí công việc:</td>
                    <td style="width: 90%;" colspan="6">
                        <asp:TextBox ID="txtViTriCongViec2" CssClass="form-control" Visible="true" runat="server" Height="0" Width="0" BorderWidth="0" Style="margin-top: -10px; z-index: 10; visibility: hidden;"></asp:TextBox>
                        <!---Tự động hoàn tất -->
                        <select class="js-example-basic-multiple2" id="ddlQickSelect2" multiple="multiple" style="width: 100%">
                            <%foreach (string i in lv_Vitri)
                              {%>
                            <option class="op1" value="<%=i.ToString() %>"><%=i.ToString() %></option>
                            <%} %>
                        </select>
                    </td>
                </tr>

                <tr style="height: 40px;">
                    <td style="width: 10%; text-align: right; padding-right: 5px;">Lương thấp nhất:</td>
                    <td style="width: 90%;" colspan="6">
                        <asp:TextBox ID="txtMucLuongThapNhat2" runat="server" CssClass="form-control"></asp:TextBox>
                    </td>
                </tr>

                <tr style="height: 40px;">
                    <td style="width: 10%; text-align: right; padding-right: 5px;">Điều kiện làm việc:</td>
                    <td style="width: 90%;" colspan="6">
                        <asp:TextBox ID="txtDieuKienLamViec2" runat="server" CssClass="form-control"></asp:TextBox>
                    </td>
                </tr>

                <tr style="height: 40px;">
                    <td style="width: 10%; text-align: right; padding-right: 5px;">Địa điểm làm việc:</td>
                    <td style="width: 90%;" colspan="6">
                        <asp:TextBox ID="txtDiaDiemLamViec2" runat="server" CssClass="form-control"></asp:TextBox>
                    </td>
                </tr>

                <tr style="height: 40px;">
                    <td style="width: 10%; text-align: right; padding-right: 5px;">Nội dung khác:</td>
                    <td style="width: 90%;" colspan="6">
                        <asp:TextBox ID="txtNoiDungKhac2" runat="server" CssClass="form-control"></asp:TextBox>
                    </td>
                </tr>
                <tr style="height: 20px;">
                    <td style="width: 10%; text-align: right; padding-right: 5px;">&nbsp;</td>
                    <td style="width: 90%;" colspan="6">&nbsp;
                    </td>
                </tr>
            </table>
        </div>
    </div>

    <footer style="height: 43px !important; margin-bottom: 0px; margin-left: -30px; width: 100%; text-align: justify; background-color: #f0f0f0;">
        <table border="0" style="width: 100%; margin-top: -8px;">
            <tr>
                <td style="width: 800px; padding-left: 15px;">
                    <asp:Button ID="btnSave" runat="server" Text="Lưu thông tin" Style="width: 125px !important;" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                    <button class="btn btn-success" type="button" onclick="OpenForm1()" id="btnQuaTrinhDaoTao" runat="server">QT đào tạo</button>
                    <button class="btn btn-success" type="button" onclick="OpenForm2()" id="btnQuaTrinhCongTac" runat="server">QT công tác</button>
                    <button class="btn btn-primary" type="button" style="width: 110px;" onclick="InPhieuTuVan()" id="btnInPhieu" runat="server">Phiếu tư vấn</button>
                    <button id="btnPrint" type="button" class="btn btn-primary" onclick="InPhieuGioiThieu()">Phiếu giới thiệu</button>

                    <button class="btn btn-primary" type="button" onclick="InPhieuKetQua()" id="btnPhieuKetQua">Phiếu kết quả</button>
                </td>
                <td>
                    <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>
    </footer>

    <input type="hidden" id="txtIDNguoiLaoDong" runat="server" />
    <input type="hidden" id="txtIDNldTuVan" runat="server" />

    <script type="text/javascript">
        function OpenForm1() {

            var IdNguoiLaoDong = document.getElementById("MainContent_txtIDNguoiLaoDong").value;

            if (IdNguoiLaoDong != 0) {

                var w = 1100;
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

                var w = 1100;
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
                var newWindow = window.open("ThongTinTuVan.aspx?id=" + IdNguoiLaoDong, "THÔNG TIN TƯ VẤN", 'scrollbars=yes, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);

                if (window.focus) {
                    newWindow.focus();
                }
            }
        }

        function InPhieuTuVan() {

            // kiểm tra xem có là lao động tự do hay không ??
            var NLDKieu = document.getElementById('MainContent_ddlIdLoaiLaoDong').value;

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
                if (NLDKieu == "0") {
                    // Kieu Lao Động Tự Do
                    var newWindow = window.open("PrintBanDangKyTuVanTimViecLam.aspx?id=" + IDNldTuVan, "IN PHIẾU TƯ VẤN", 'scrollbars=yes, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);
                    return;
                }
                else {
                    var newWindow = window.open("PrintPhieuTuVan.aspx?id=" + IDNldTuVan, "IN PHIẾU TƯ VẤN", 'scrollbars=yes, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);
                }

                if (window.focus) {
                    newWindow.focus();
                }
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
                var newWindow = window.open("PrintThongBaoKetQua.aspx?id=" + IDNldTuVan, "IN PHIẾU KẾT QUẢ", 'scrollbars=yes, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);

                if (window.focus) {
                    newWindow.focus();
                }
            }
        }

        function XemTinTuyenDung(value) {

            var IDNldTuVan = document.getElementById("MainContent_txtIDNldTuVan").value;
            var vitri = document.getElementById("MainContent_txtViTriCongViec").value;
            var mucluong = document.getElementById("MainContent_txtMucLuongThapNhat").value;
            var dieukien = document.getElementById("MainContent_txtDieuKienLamViec").value;
            var diadiem = document.getElementById("MainContent_txtDiaDiemLamViec").value;
            var w = screen.width;
            var h = screen.height;

            var dualScreenLeft = window.screenLeft != undefined ? window.screenLeft : screen.left;
            var dualScreenTop = window.screenTop != undefined ? window.screenTop : screen.top;

            var width = w;//window.innerWidth ? window.innerWidth : document.documentElement.clientWidth ? document.documentElement.clientWidth : screen.width;
            var height = h;//window.innerHeight ? window.innerHeight : document.documentElement.clientHeight ? document.documentElement.clientHeight : screen.height;

            var left = 0;//((width / 2) - (w / 2));// + dualScreenLeft;
            var top = 0;//((height / 2) - (h / 2));// + dualScreenTop;

            var newWindow = window.open("XemTinTuyenDung.aspx?id=" + value + "&IDNldTuVan=" + IDNldTuVan + "&vitri=" + vitri + "&mucluong=" + mucluong + "&dieukien=" + dieukien + "&diadiem=" + diadiem + "&nuocngoai=" + value, "TIN TUYỂN DỤNG", 'scrollbars=yes, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);

            if (window.focus) {
                newWindow.moveTo(0, 0);
                newWindow.resizeTo(screen.width, screen.height);
                newWindow.focus();
            }
        }

        function ChonKhoaHoc() {

            var w = 1000;
            var h = 600;

            var IdNguoiLaoDong = document.getElementById("MainContent_txtIDNguoiLaoDong").value;
            if (IdNguoiLaoDong != 0) {
                var dualScreenLeft = window.screenLeft != undefined ? window.screenLeft : screen.left;
                var dualScreenTop = window.screenTop != undefined ? window.screenTop : screen.top;

                var width = window.innerWidth ? window.innerWidth : document.documentElement.clientWidth ? document.documentElement.clientWidth : screen.width;
                var height = window.innerHeight ? window.innerHeight : document.documentElement.clientHeight ? document.documentElement.clientHeight : screen.height;

                var left = ((width / 2) - (w / 2)) + dualScreenLeft;
                var top = ((height / 2) - (h / 2)) + dualScreenTop;
                var newWindow = window.open("ChonKhoaHoc1.aspx?IdNguoiLaoDong=" + IdNguoiLaoDong, "CHỌN DOANH NGHIỆP", 'scrollbars=yes, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);

                if (window.focus) {
                    newWindow.focus();
                }
            }
        }

    </script>
    <script>
        function getValue() {               // lấy nội dung vào txtVitriCongviec
            var x = document.getElementsByClassName("select2-selection__rendered")[0].getElementsByClassName("select2-selection__choice");
            var i;
            var str = '';
            for (i = 0; i < x.length; i++) {
                str += x[i].textContent;
            }
            return str;
        }
        function getValue2() {               // lấy nội dung vào txtVitriCongviec2 , tạm thời viết thế này đả
            var x = document.getElementsByClassName("select2-selection__rendered")[1].getElementsByClassName("select2-selection__choice");
            var i;
            var str = '';
            for (i = 0; i < x.length; i++) {
                str += x[i].textContent;
            }
            return str;
        }

        function load()      // load dử liệu vào textbox
        {
            document.getElementById('MainContent_txtViTriCongViec').value = getValue();
            document.getElementById('MainContent_txtViTriCongViec2').value = getValue2();
        }
    </script>
    <script type="text/javascript">
        $(".js-example-basic-multiple").select2();
        $(".js-example-basic-multiple2").select2();

    </script>
    <script type="text/javascript" language="javascript">
        $(document).ready(function () {
            $('#<%= btnSave.ClientID %>').click(function (e) {
                load();     // gọi đến sự kiện lưu lại
            });
        });
    </script>
</asp:Content>

