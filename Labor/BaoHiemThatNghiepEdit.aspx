<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin.master" CodeFile="BaoHiemThatNghiepEdit.aspx.cs" Inherits="Labor_BaoHiemThatNghiepEdit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="Server">
    <style>
        .label1 {
            width: 14%;
            float: left;
            text-align: right;
            font-size: 15px;
            padding-right: 5px;
            height: 34px;
            padding-top: 8px;
        }

        .label2 {
            width: 12%;
            float: left;
            text-align: right;
            font-size: 15px;
            padding-right: 5px;
            height: 34px;
            padding-top: 8px;
        }

        .labela {
            width: 16%;
            float: left;
            text-align: right;
            font-size: 15px;
            padding-right: 5px;
            height: 34px;
            padding-top: 8px;
        }

        label {
            font-size: 15px;
        }

        .chkLabel {
            width: 20%;
            float: left;
            font-size: 15px;
            height: 34px;
            padding-top: 8px;
            padding-left: 20px;
        }

        .line {
            margin-top: 10px;
        }

        .headlabel {
            margin-top: 10px;
            font-size: 16px;
        }

        .checkboxuser input {
            width: 25px;
            height: 25px;
        }

        .checkboxuserinput {
            width: 25px;
            height: 25px;
        }

        .checkboxuser label {
            height: 34px;
            font-size: 15px;
        }

        span.badge1 {
            right: 10px;
            left: 170px;
        }

        .warning {
            color: red;
        }
    </style>
    <script>
        $(function () {
            $('.date').datetimepicker({
                format: 'DD/MM/YYYY'
            });

            $(".dateinput").mask("99/99/9999", { placeholder: "dd/MM/yyyy" });
        });
        $(function () {
            $('.date1').datetimepicker({
                format: 'MM/YYYY'
            });

            $(".dateinput1").mask("99/9999", { placeholder: "MM/yyyy" });
        });


        function hidenDangkyTre(obj) {
            //inp = document.getElementsByName('MainContent_ddlDangKyTre');
            //alert(obj.checked);
            if (obj.checked) {

                $("#MainContent_ddlDangKyTre").show();
                //inp.style.visibility = 'visible';
            } else {
                $("#MainContent_ddlDangKyTre").hide();
                //inp.style.visibility = 'hidden';
            }
        }

        function hidenXacNhanDangKy(obj) {
            //inp = document.getElementsByName('MainContent_ddlDangKyTre');
            //alert(obj.checked);
            if (obj.checked) {

                $("#MainContent_ddlNoiDKXacNhan").show()
                //inp.style.visibility = 'visible';
            } else {
                $("#MainContent_ddlNoiDKXacNhan").hide()
                //inp.style.visibility = 'hidden';
            }
        }

        function SelectName() {

            var w = 1000;
            var h = 600;

            var dualScreenLeft = window.screenLeft != undefined ? window.screenLeft : screen.left;
            var dualScreenTop = window.screenTop != undefined ? window.screenTop : screen.top;

            var width = window.innerWidth ? window.innerWidth : document.documentElement.clientWidth ? document.documentElement.clientWidth : screen.width;
            var height = window.innerHeight ? window.innerHeight : document.documentElement.clientHeight ? document.documentElement.clientHeight : screen.height;

            var left = ((width / 2) - (w / 2)) + dualScreenLeft;
            var top = ((height / 2) - (h / 2)) + dualScreenTop;
            var newWindow = window.open("ChonDoanhNghiep2.aspx", "CHỌN DOANH NGHIỆP", 'scrollbars=yes, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);

            if (window.focus) {
                newWindow.focus();
            }
        }

        function DeleteName() {
            document.getElementById("MainContent_txtIDDonVi").value = "";
            document.getElementById("MainContent_txtTenDonVi").value = "";
            document.getElementById("MainContent_txtDiaChiDN").value = "";
            document.getElementById("MainContent_txtPhoneDN").value = "";
            document.getElementById("MainContent_txtFaxDN").value = "";
            document.getElementById("MainContent_txtSoDKKD").value = "";

            document.getElementById("MainContent_ddlLoaiHinhDN").selectedIndex = "0";
            document.getElementById("MainContent_ddlIdNganhNgheDN").selectedIndex = "0";
            document.getElementById("MainContent_txtEmailDN").value = "";
            document.getElementById("MainContent_txtWebsiteDN").value = "";

            document.getElementById("MainContent_btnXoaDonVi").disabled = "disabled";

        }
    </script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div style="width: 83%; float: left; margin-top:-15px!important;">
        <div class="row headlabel" style="padding:3px; padding-left: 15px; background-color: #00ffff; margin-right:6px!important;">
            <b>I. Thông tin người lao động</b>
        </div>
        <div class="row line">
            <div class="label1">
                Họ và tên: 
            </div>
            <div style="width: 20%; float: left">
                <asp:TextBox ID="txtHoVaTen" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="label2">
                Ngày sinh: 
            </div>
            <div style="width: 20%; float: left">
                <div class='input-group date' style="margin-left: 0px; width: 100% !important; float: right;">
                    <input type='text' class="form-control dateinput" id="txtNgaySinh" runat="server" />
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>
                <%--<asp:TextBox ID="txtNgaySinh" runat="server" CssClass="form-control"></asp:TextBox>--%>
            </div>

            <div class="label2">
                Giới tính: 
            </div>
            <div class="chkLabel">
                <asp:RadioButton ID="chkGioiTinhNam" GroupName="GioiTinh" runat="server" Text="&nbsp;Nam" TextAlign="Right" />
                &nbsp;&nbsp;&nbsp;
            <asp:RadioButton ID="chkGioiTinhNu" GroupName="GioiTinh" runat="server" Text="&nbsp;Nữ" TextAlign="Right" />

            </div>
        </div>
        <div class="row line">
            <div class="label1">
                Số CMND/HC: 
            </div>
            <div style="width: 20%; float: left">
                <asp:TextBox ID="txtCMND" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="label2">
                Ngày cấp: 
            </div>
            <div style="width: 20%; float: left">
                <div class='input-group date' style="margin-left: 0px; width: 100% !important; float: right;">
                    <input type='text' class="form-control dateinput" id="txtNgayCap" runat="server" />
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>
                <%--<asp:TextBox ID="txtNgayCap" runat="server" CssClass="form-control"></asp:TextBox>--%>
            </div>

            <div class="label2">
                Nơi cấp: 
            </div>
            <div style="width: 20%; float: left">
                <asp:DropDownList ID="ddlNoiCap" CssClass="form-control" runat="server" Style="width: 100%;">
                    <asp:ListItem Value="0">Không chọn</asp:ListItem>
                </asp:DropDownList>
                <%--<asp:TextBox ID="txtNoiCap" runat="server" CssClass="form-control"></asp:TextBox>--%>
            </div>
        </div>
        <div class="row line">
            <div class="label1">
                Số điện thoại: 
            </div>
            <div style="width: 20%; float: left">
                <asp:TextBox ID="txtSoDienThoai" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="label2">
                Nơi cư trú: 
            </div>
            <div style="width: 52%; float: left">
                <asp:TextBox ID="txtNoiThuongTru" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="row headlabel" style="padding:3px; padding-left: 15px; background-color: #00ffff; margin-right:6px!important;">
            <a class="pa_italic collapsed" role="button" data-toggle="collapse" href="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo">
                <b>II. Thông tin cá nhân bổ sung <span class="lnr lnr-chevron-down"></span><i class="lnr lnr-chevron-up"></i></b>
            </a>
        </div>

        <div id="collapseTwo" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingOne" aria-expanded="false">
            <div class="panel-body panel_text">
                <div class="row line">
                    <div class="labela">
                        Số tài khoản: 
                    </div>
                    <div style="width: 30%; float: left">
                        <asp:TextBox ID="txtSoTaiKhoan" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>

                    <div class="labela">
                        Ngân hàng: 
                    </div>
                    <div style="width: 30%; float: left">
                        <asp:DropDownList ID="ddlNganHang" CssClass="form-control" runat="server" Style="width: 100%;">
                            <asp:ListItem Value="0">Không chọn</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="row line">
                    <div class="labela">
                        Mã số thuế: 
                    </div>
                    <div style="width: 30%; float: left">
                        <asp:TextBox ID="txtMaSoThue" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>

                    <div class="labela">
                        Email: 
                    </div>
                    <div style="width: 30%; float: left">
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>

        <div class="row line">
            <div class="label1">
                Số BHXH: 
            </div>
            <div style="width: 20%; float: left">
                <asp:TextBox ID="txtBHXH" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="label2">
                Ngày cấp BHXH: 
            </div>
            <div style="width: 20%; float: left">
                <div class='input-group date' style="margin-left: 0px; width: 100% !important; float: right;">
                    <input type='text' class="form-control dateinput" id="txtNgayCapBHXH" runat="server" />
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>
                <%--<asp:TextBox ID="txtNgayCapBHXH" runat="server" CssClass="form-control"></asp:TextBox>--%>
            </div>

            <div class="label2">
                Nơi cấp BHXH: 
            </div>
            <div style="width: 20%; float: left">
                <asp:DropDownList ID="ddlNoiCapBHXH" CssClass="form-control" runat="server" Style="width: 100%;">
                    <asp:ListItem Value="0">Không chọn</asp:ListItem>
                </asp:DropDownList>
                <%--<asp:TextBox ID="txtNoiCapBHXH" runat="server" CssClass="form-control"></asp:TextBox>--%>
            </div>
        </div>
        <div class="row line">
            <div class="label1">
                Nơi ĐK KCB: 
            </div>
            <div style="width: 84%; float: left">
                <asp:DropDownList ID="ddlNoiKhamBenh" CssClass="form-control" runat="server" Style="width: 100%;">
                    <asp:ListItem Value="0">Không chọn</asp:ListItem>
                </asp:DropDownList>
                <%--<asp:TextBox ID="TextBox3" runat="server" CssClass="form-control"></asp:TextBox>--%>
            </div>
        </div>
        <div class="row line">
            <div class="label1">
                Trình độ CMKT: 
            </div>
            <div style="width: 20%; float: left">
                <asp:DropDownList ID="ddlTDCM" CssClass="form-control" runat="server" Style="width: 100%;">
                    <asp:ListItem Value="0">Không chọn</asp:ListItem>
                </asp:DropDownList>
                <%--<asp:TextBox ID="TextBox4" runat="server" CssClass="form-control"></asp:TextBox>--%>
            </div>

            <div class="label2">
                Lĩnh vực đào tạo: 
            </div>
            <div style="width: 20%; float: left">
                <asp:DropDownList ID="ddlLinhVucDT" CssClass="form-control" runat="server" Style="width: 100%;">
                    <asp:ListItem Value="0">Không chọn</asp:ListItem>
                </asp:DropDownList>
                <%--<asp:TextBox ID="TextBox5" runat="server" CssClass="form-control"></asp:TextBox>--%>
            </div>
        </div>
        <div class="row line">
            <div class="label1">
                Công việc đã làm: 
            </div>
            <div style="width: 84%; float: left">
                <asp:TextBox ID="txtCongViecDaLam" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="row line">
            <div class="label1">
                Tên DN: 
            </div>
            <div style="width: 84%; float: left; margin-right: -200px; padding-right: 200px;">
                <input type="hidden" name="txtIDDonVi" id="txtIDDonVi" runat="server" />
                <asp:TextBox ID="txtTenDonVi" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div style="width: 200px; float: right;">
                <button class="btn btn-primary" type="button" onclick="SelectName()" style="width: 80px; height: 34px !important; line-height: 14px !important;">Chọn</button>
                <button id="btnXoaDonVi" runat="server" class="btn btn-danger" type="button" onclick="DeleteName()" style="margin-left: 10px; width: 80px; height: 34px !important; line-height: 14px !important;" disabled="disabled">Xóa</button>
            </div>
        </div>
        <div class="row line">
            <div class="label1">
                Địa chỉ DN: 
            </div>
            <div style="width: 84%; float: left">
                <asp:TextBox ID="txtDiaChiDN" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="row line">
            <div class="label1">
                Điện thoại: 
            </div>
            <div style="width: 20%; float: left">
                <asp:TextBox ID="txtPhoneDN" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="label2">
                Fax: 
            </div>
            <div style="width: 20%; float: left">
                <asp:TextBox ID="txtFaxDN" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
       <div class="row headlabel" style="padding:3px; padding-left: 15px; background-color: #00ffff; margin-right:6px!important;">
            <a class="pa_italic collapsed" role="button" data-toggle="collapse" href="#collapseOne" aria-expanded="false" aria-controls="collapseOne">
                <b>III. Thông tin DN bổ sung <span class="lnr lnr-chevron-down"></span><i class="lnr lnr-chevron-up"></i></b>
            </a>
        </div>

        <div id="collapseOne" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingOne" aria-expanded="false">
            <div class="panel-body panel_text">
                <div class="row line">
                    <div class="labela">
                        Số ĐKKD: 
                    </div>
                    <div style="width: 30%; float: left">
                        <asp:TextBox ID="txtSoDKKD" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>

                    <div class="labela">
                        Loại hình DN: 
                    </div>
                    <div style="width: 30%; float: left">
                        <asp:DropDownList ID="ddlLoaiHinhDN" CssClass="form-control" runat="server" Style="width: 100%">
                            <asp:ListItem Value="0">Không chọn</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="row line">
                    <div class="labela">
                        Ngành nghề SX - KD: 
                    </div>
                    <div style="width: 30%; float: left">
                        <asp:DropDownList ID="ddlIdNganhNgheDN" CssClass="form-control" runat="server" Style="width: 100%">
                            <asp:ListItem Value="0">Không chọn</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="labela">
                        Email: 
                    </div>
                    <div style="width: 30%; float: left">
                        <asp:TextBox ID="txtEmailDN" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                <div class="row line">
                    <div class="labela">
                        Website:
                    </div>
                    <div style="width: 30%; float: left">
                        <asp:TextBox ID="txtWebsiteDN" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>

                </div>
            </div>
        </div>
        <div class="row line">
            <div class="label1">
                Ngày nghỉ việc: 
            </div>
            <div style="width: 20%; float: left">
                <div class='input-group date' style="margin-left: 0px; width: 100% !important; float: right;">
                    <input type='text' class="form-control dateinput" id="txtNgayNghiViec" runat="server" />
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>
            </div>

            <div class="label2" style="width: 15%;">
                Số tháng đóng BHXH: 
            </div>
            <div style="width: 20%; float: left">
                <asp:TextBox ID="txtSoThangDongBHXH" runat="server" CssClass="form-control"></asp:TextBox>
            </div>


        </div>

        <div class="row line">
            <div class="label1">
                Nhu cầu: 
            </div>
            <div style="width: 15%; float: left">
                <asp:CheckBox ID="chkTuVan" CssClass="checkboxuser" runat="server" Text="&nbsp;Tư vấn" TextAlign="Right" />
            </div>
            <div style="width: 20%; float: left">
                <asp:CheckBox ID="chkGioiThieu" CssClass="checkboxuser" runat="server" Text="&nbsp;Giới thiệu việc làm" TextAlign="Right" />
            </div>
            <div style="width: 20%; float: left">
                <asp:CheckBox ID="chkHocNghe" CssClass="checkboxuser" runat="server" Text="&nbsp;Học nghề" TextAlign="Right" />
            </div>
        </div>
        <div class="row line">
            <div class="label1">
                Ngày ĐK thất nghiệp: 
            </div>
            <div style="width: 20%; float: left">
                <div class='input-group date' style="margin-left: 0px; width: 100% !important; float: right;">
                    <input type='text' class="form-control dateinput" id="txtNgayDangKyTN" runat="server" />
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>
                <%--<asp:TextBox ID="txtNgayDangKyTN" runat="server" CssClass="form-control"></asp:TextBox>--%>
            </div>

            <div class="label2">
                <label for="chkDangKyTre">Đăng ký trễ</label>
            </div>
            <div style="width: 3%; float: left">
                <input type="checkbox" id="chkDangKyTre" runat="server" onchange="hidenDangkyTre(this)" class="checkboxuserinput" />
                <%--<asp:CheckBox ID="chkDangKyTre" onchange="hidenDangkyTre(this)" CssClass="checkboxuser" runat="server" TextAlign="Left" />--%>
            </div>

            <%--<div class="label2">
            Lý do đăng ký trễ: 
        </div>--%>
            <div style="width: 49%; float: left">
                <asp:DropDownList ID="ddlDangKyTre" CssClass="form-control" runat="server" Style="width: 100%; display: none;">
                    <asp:ListItem Value="0">--Chọn lý do đăng ký trễ--</asp:ListItem>
                    <asp:ListItem Value="1">Thiên tai dịch họa</asp:ListItem>
                    <asp:ListItem Value="2">Ốm đau thai sản</asp:ListItem>
                    <asp:ListItem Value="3">Tai nạn giao thông</asp:ListItem>
                    <asp:ListItem Value="4">Khác</asp:ListItem>
                </asp:DropDownList>
                <%--<asp:TextBox ID="txtLiDoDangKyTre" runat="server" CssClass="form-control"></asp:TextBox>--%>
            </div>
            <% if (chkDangKyTre.Checked)
               { %>
            <script>
                $("#MainContent_ddlDangKyTre").show();
            </script>
            <% } %>
        </div>
        <div class="row line">
            <div class="label1">
                Người tiếp nhận ĐK: 
            </div>
            <div style="width: 20%; float: left">
                <asp:DropDownList ID="ddlNguoiTiepNhan" CssClass="form-control" runat="server" Style="width: 100%;">
                    <asp:ListItem Value="0">Không chọn</asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="label2">
                Ngày hoàn thiện: 
            </div>
            <div style="width: 20%; float: left">
                <div class='input-group date' style="margin-left: 0px; width: 100% !important; float: right;">
                    <input type='text' class="form-control dateinput" id="txtNgayHoanThien" runat="server" />
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>
                <%--<asp:TextBox ID="TextBox16" runat="server" CssClass="form-control"></asp:TextBox>--%>
            </div>
            <div class="label2">Nơi ĐBH cuối: </div>
            <div style="width: 20%; float: left">
                <asp:DropDownList ID="ddlLuongToiThieu" CssClass="form-control" runat="server" Style="width: 100%;">
                    <asp:ListItem Value="3750000">Vùng I</asp:ListItem>
                    <asp:ListItem Value="3320000">Vùng II</asp:ListItem>
                    <asp:ListItem Value="2900000">Vùng III</asp:ListItem>
                    <asp:ListItem Value="2580000">Vùng IV</asp:ListItem>
                </asp:DropDownList>
            </div>

        </div>


        <div class="row line" <%= type != 1?"style=\"display:none\"":"" %>>
            <div class="label1">
                6 tháng gần nhất 
            </div>
            <div style="width: 84%; float: left">
                <table style="border: 1px solid; width: 100%">
                    <tr>
                        <th style="width: 120px"></th>
                        <th>Tháng đóng</th>
                        <th>HS Lương</th>
                        <th>HS phụ cấp</th>
                        <th>Lương cơ bản</th>
                        <th>Mức đóng</th>
                    </tr>
                    <tr>
                        <th>Tháng thứ 6</th>
                        <td>
                            <div class='input-group date1' style="margin-left: 0px; width: 100% !important; float: right;">
                                <input type='text' class="form-control dateinput1" id="txtThangThu6" runat="server" />
                                <span class="input-group-addon">
                                    <span class="glyphicon glyphicon-calendar"></span>
                                </span>
                            </div>
                        </td>
                        <td>
                            <asp:TextBox ID="txtHeSoLuongThang6" runat="server" CssClass="form-control"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txtPhuCapThang6" runat="server" CssClass="form-control"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txtLuongCoBanThang6" runat="server" CssClass="form-control"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txtMucDongThang6" runat="server" CssClass="form-control"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <th>Tháng thứ 5</th>
                        <td>
                            <div class='input-group date1' style="margin-left: 0px; width: 100% !important; float: right;">
                                <input type='text' class="form-control dateinput1" id="txtThangThu5" runat="server" />
                                <span class="input-group-addon">
                                    <span class="glyphicon glyphicon-calendar"></span>
                                </span>
                            </div>
                        </td>
                        <td>
                            <asp:TextBox ID="txtHeSoLuongThang5" runat="server" CssClass="form-control"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txtPhuCapThang5" runat="server" CssClass="form-control"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txtLuongCoBanThang5" runat="server" CssClass="form-control"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txtMucDongThang5" runat="server" CssClass="form-control"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <th>Tháng thứ 4</th>
                        <td>
                            <div class='input-group date1' style="margin-left: 0px; width: 100% !important; float: right;">
                                <input type='text' class="form-control dateinput1" id="txtThangThu4" runat="server" />
                                <span class="input-group-addon">
                                    <span class="glyphicon glyphicon-calendar"></span>
                                </span>
                            </div>
                        </td>
                        <td>
                            <asp:TextBox ID="txtHeSoLuongThang4" runat="server" CssClass="form-control"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txtPhuCapThang4" runat="server" CssClass="form-control"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txtLuongCoBanThang4" runat="server" CssClass="form-control"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txtMucDongThang4" runat="server" CssClass="form-control"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <th>Tháng thứ 3</th>
                        <td>
                            <div class='input-group date1' style="margin-left: 0px; width: 100% !important; float: right;">
                                <input type='text' class="form-control dateinput1" id="txtThangThu3" runat="server" />
                                <span class="input-group-addon">
                                    <span class="glyphicon glyphicon-calendar"></span>
                                </span>
                            </div>
                        </td>
                        <td>
                            <asp:TextBox ID="txtHeSoLuongThang3" runat="server" CssClass="form-control"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txtPhuCapThang3" runat="server" CssClass="form-control"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txtLuongCoBanThang3" runat="server" CssClass="form-control"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txtMucDongthang3" runat="server" CssClass="form-control"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <th>Tháng thứ 2</th>
                        <td>
                            <div class='input-group date1' style="margin-left: 0px; width: 100% !important; float: right;">
                                <input type='text' class="form-control dateinput1" id="txtThangThu2" runat="server" />
                                <span class="input-group-addon">
                                    <span class="glyphicon glyphicon-calendar"></span>
                                </span>
                            </div>
                        </td>
                        <td>
                            <asp:TextBox ID="txtHeSoluongThang2" runat="server" CssClass="form-control"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txtPhuCapThang2" runat="server" CssClass="form-control"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txtLuongCoBanThang2" runat="server" CssClass="form-control"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txtMucDongThang2" runat="server" CssClass="form-control"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <th>Tháng thứ 1</th>
                        <td>
                            <div class='input-group date1' style="margin-left: 0px; width: 100% !important; float: right;">
                                <input type='text' class="form-control dateinput1" id="txtThangThu1" runat="server" />
                                <span class="input-group-addon">
                                    <span class="glyphicon glyphicon-calendar"></span>
                                </span>
                            </div>
                        </td>
                        <td>
                            <asp:TextBox ID="txtHeSoLuongThang1" runat="server" CssClass="form-control"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txtPhuCapThang1" runat="server" CssClass="form-control"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txtLuongCoBanThang1" runat="server" CssClass="form-control"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txtMucDongThang1" runat="server" CssClass="form-control"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <th>Mức hưởng tối đa:</th>
                        <td>
                            <asp:TextBox ID="txtMucHuongToiDa" runat="server" CssClass="form-control"></asp:TextBox></td>
                        <th>Số tháng hưởng</th>
                        <td>
                            <asp:TextBox ID="txtSoThangHuong" runat="server" CssClass="form-control"></asp:TextBox></td>
                        <th style="text-align: right">Lương trung bình(VND)</th>
                        <td>
                            <asp:TextBox ID="txtLuongTrungBinh" runat="server" CssClass="form-control"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <th>Hưởng từ ngày:</th>
                        <td>
                            <div class='input-group date' style="margin-left: 0px; width: 100% !important; float: right;">
                                <input type='text' class="form-control dateinput" id="txtHuongTuNgay" runat="server" />
                                <span class="input-group-addon">
                                    <span class="glyphicon glyphicon-calendar"></span>
                                </span>
                            </div>
                        </td>
                        <th>Đến ngày:</th>
                        <td>
                            <div class='input-group date' style="margin-left: 0px; width: 100% !important; float: right;">
                                <input type='text' class="form-control dateinput" id="txtHuongDenNgay" runat="server" />
                                <span class="input-group-addon">
                                    <span class="glyphicon glyphicon-calendar"></span>
                                </span>
                            </div>

                        </td>
                        <th style="text-align: right">Mức hưởng(VND)</th>
                        <td>
                            <asp:TextBox ID="txtMucHuong" runat="server" CssClass="form-control"></asp:TextBox></td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="row line">
            <div class="label1">
                Nơi nhận bảo hiểm: 
            </div>
            <div style="width: 20%; float: left">
                <asp:DropDownList ID="ddlNoiNhanbaoHiem" CssClass="form-control" runat="server" Style="width: 100%;">
                    <asp:ListItem Value="0">Không chọn</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="label2" style="width: 20%">
                Hình thức nhận tiền: 
            </div>
            <div class="chkLabel" style="width: 42%">
                <asp:RadioButton ID="cbkATM" GroupName="HinhThucNhanTien" runat="server" Text="&nbsp;Qua ATM" TextAlign="Right" />
                &nbsp;&nbsp;&nbsp;
            <asp:RadioButton ID="cbkTienMat" GroupName="HinhThucNhanTien" runat="server" Text="&nbsp;Qua tiền mặt" TextAlign="Right" />
            </div>
        </div>
        <div class="row line">
            <div class="label1">
                Nơi chốt sổ cuối: 
            </div>
            <div style="width: 20%; float: left">
                <asp:DropDownList ID="ddlNoiChotSoCuoi" CssClass="form-control" runat="server" Style="width: 100%;">
                    <asp:ListItem Value="0">Không chọn</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="row line">
            <div class="label1" style="width: 50%">
                <span class="warning">* Check chọn đã xác nhận chưa đăng ký nếu NLD có giấy xác nhận chưa ĐK</span>
            </div>
            <div style="width: 3%; float: left">
                <input type="checkbox" id="chkXacNhanDangKy" runat="server" onchange="hidenXacNhanDangKy(this)" class="checkboxuserinput" />
            </div>
            <div class="label1" style="width: 18%; text-align: left;">
                <label for="chkXacNhanDangKy">Đã xác nhận đăng ký</label>
            </div>
            <div style="width: 25%; float: left">
                <asp:DropDownList ID="ddlNoiDKXacNhan" CssClass="form-control" runat="server" Style="width: 100%; display: none">
                    <asp:ListItem Value="0">--Chọn nơi xác nhận đăng ký--</asp:ListItem>
                </asp:DropDownList>
                <% if (chkXacNhanDangKy.Checked)
                   { %>
                <script>
                    $("#MainContent_ddlNoiDKXacNhan").show();
                </script>
                <% } %>
                <%--<asp:TextBox ID="txtLiDoDangKyTre" runat="server" CssClass="form-control"></asp:TextBox>--%>
            </div>
        </div>

        <br />
        <br />
        <br />
    </div>

    <div style="width: 16%; float: right; margin-top:-5px;">
        <div style ="height:28px; background-color:red; line-height:28px; color:#fff; text-align:center; font-size:12PX; font-weight:bold;">Thông tin đóng hưởng</div>
        <div class="panel-body1" style ="padding-top:10px; margin-top:2px;">
            <div class="row">
                Ngày đăng ký: <%= txtNgayDangKyTN.Value %><br />
                Hạn hoàn thiện:<br />
                Ngày hoàn thiện:<br />
                Ngày trả QĐ:
                <br />
                <br />

                <div class="list-group list-group-alternate">
                    <a href="#" class="list-group-item"><span class="badge1" style ="left:140px;">></span>Thông tin đăng ký </a>
                    <a href="#" class="list-group-item"><span class="badge1" style ="left:140px;">></span>Đăng ký TCTN</a>
                    <a href="#" class="list-group-item" runat="server" onserverclick="DeNghiHuong_Click"><span class="badge1" style ="left:140px;">></span>Đề nghị hưởng </a>
                    <a href="#" class="list-group-item" runat="server" onserverclick="GiayBienNhan_Click"><span class="badge1" style ="left:140px;">></span>Giấy biên nhận ĐK </a>
                    <a href="#" class="list-group-item"><span class="badge1" style ="left:140px;">></span>Phiếu hẹn trả KQ </a>
                    <a href="#" class="list-group-item" runat="server" onserverclick="Unnamed_ServerClick"><span class="badge1" style ="left:140px;">></span>Phiếu tính hưởng </a>
                    <a href="#" class="list-group-item"><span class="badge1" style ="left:140px;">></span>Tải quyết định </a>
                </div>
                <br />
                <asp:Button ID="btnSave" runat="server" Text="Lưu thông tin" Style="width: 100% !important;" CssClass="btn btn-primary" OnClick="btnSave_Click " />
                <%--<br />
                <br />
                  <asp:Button ID="btnTinhHuong" runat="server" Text="Tính hưởng" Style="width: 100% !important;" CssClass="btn btn-primary" OnClick="btnTinhHuong_Click" />--%>
                <br />
                <br />
                <a href="#" class="btn btn-danger" style="width: 100%">Chuyển hồ sơ</a>
            </div>
        </div>
    </div>
    <footer style="z-index: 100; height: 43px !important; margin-bottom: 0px; margin-left: -14px; width: 100%; text-align: justify; background-color: #f0f0f0; padding-top: 4px">
        <div class="warning">
            <asp:Label ID="lblMsg" runat="server" Text="" Font-Size="Larger" ForeColor="Red" />
        </div>
        <a href="BaoHiemThatNghiep.aspx<%= type == 1?"?type=1":""  %>" class="btn btn-default" style ="float:right; margin-right:52px;">Thoát</a>
    </footer>
    <script type="text/javascript">
        $(document).ready(function () {
            for (i = 6; i > 0; i--) {
                SetThang(i);
            }
        });
        function SetThang(id) {
            $("#MainContent_txtThangThu" + id).blur(function () {
                var ThangThu6 = $(this).val();
                if (ThangThu6.trim() != '') {
                    var thang6, nam6;
                    thang6 = ThangThu6.substring(0, 2);
                    nam6 = ThangThu6.substring(3, 7);
                    for (i = 1; i < id; i++) {
                        var thang = thang6 - 1;
                        var nam = nam6;
                        if (thang < 1) {
                            nam = nam - 1;
                            thang = 12;
                        }
                        if (thang - 10 < 0) {
                            thang = "0" + thang;
                        }

                        $("#MainContent_txtThangThu" + (id - i)).val(thang + "/" + nam);
                        thang6 = thang;
                        nam6 = nam;
                    }
                }
            });
        }
        $(document).ready(function () {
            $("#MainContent_txtMucHuongToiDa").val($("#MainContent_ddlLuongToiThieu").val() * 5);
        });
        $("#MainContent_ddlLuongToiThieu").change(function () {
            $("#MainContent_txtMucHuongToiDa").val($(this).val() * 5);
        });
        $("#MainContent_txtSoThangDongBHXH").blur(function () {
            var SoThangDong = $(this).val();
            if (SoThangDong.trim() == "") {
                $("#MainContent_txtSoThangHuong").val("");
            }
            var SoThangDuocHuong;
            if (SoThangDong >= 12 && SoThangDong <= 36) {
                SoThangDuocHuong = 3;
                $("#MainContent_txtSoThangHuong").val(SoThangDuocHuong);
            }
            if (SoThangDong > 36) {
                SoThangDuocHuong = 3;
                SoThangDong = SoThangDong - 36;
                SoThangDong = Math.round((SoThangDong / 12));
                SoThangDuocHuong = SoThangDuocHuong + SoThangDong;
                $("#MainContent_txtSoThangHuong").val(SoThangDuocHuong);
            }
        });
        var _msg = '<%=_msg%>';
        if (_msg != '') {
            alert(_msg);
        }

    </script>

    
</asp:Content>
