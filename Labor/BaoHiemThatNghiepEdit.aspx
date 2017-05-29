﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin.master" CodeFile="BaoHiemThatNghiepEdit.aspx.cs" Inherits="Labor_BaoHiemThatNghiepEdit" %>

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
            font-size: 15px;
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

        function hidenDangkyTre(obj) {
            //inp = document.getElementsByName('MainContent_ddlDangKyTre');
            //alert(obj.checked);
            if (obj.checked) {

                $("#MainContent_ddlDangKyTre").show()
                //inp.style.visibility = 'visible';
            } else {
                $("#MainContent_ddlDangKyTre").hide()
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

        function donViChang(txtbox) {
            alert(id);
        }
    </script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

    <div style="width: 82%; float: left; margin-top: -15px;">
        <div class="row headlabel">
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

                <%--            <asp:DropDownList ID="ddlGioiTinh" CssClass="form-control" runat="server" Style="width: 100%;">
                <asp:ListItem Value="0">Không chọn</asp:ListItem>
                <asp:ListItem Value="1">Nam</asp:ListItem>
                <asp:ListItem Value="2">Nữ</asp:ListItem>
            </asp:DropDownList>--%>
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
        <div class="row headlabel">
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
            <div class="label1" style="width: 15%;">
                Nơi ĐK khám bệnh: 
            </div>
            <div style="width: 81%; float: left">
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
            <div style="width: 84%; float: left; margin-right: -100px; padding-right: 100px;">
                <input type="hidden" name="txtIDDonVi" id="txtIDDonVi" runat="server" />
                <asp:TextBox ID="txtTenDonVi" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div style="width: 100px; float: right;">
                <button class="btn btn-primary" type="button" onclick="SelectName()" style="width: 80px; height: 34px !important; line-height: 14px !important;">Chọn</button>
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
                <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="label2">
                Fax: 
            </div>
            <div style="width: 20%; float: left">
                <asp:TextBox ID="txtFax" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="row headlabel">
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
                        <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>

                    <div class="labela">
                        Loại hình DN: 
                    </div>
                    <div style="width: 30%; float: left">
                        <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                <div class="row line">
                    <div class="labela">
                        Ngành nghề SX - KD: 
                    </div>
                    <div style="width: 30%; float: left">
                        <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>

                    <div class="labela">
                        Email: 
                    </div>
                    <div style="width: 30%; float: left">
                        <asp:TextBox ID="TextBox10" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                <div class="row line">
                    <div class="labela">
                        Website:
                    </div>
                    <div style="width: 30%; float: left">
                        <asp:TextBox ID="TextBox12" runat="server" CssClass="form-control"></asp:TextBox>
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
                <asp:TextBox ID="TextBox11" runat="server" CssClass="form-control"></asp:TextBox>
            </div>


        </div>

        <div class="row line">
            <div class="label1">
                Nhu cầu: 
            </div>
            <div style="width: 15%; float: left">
                <asp:CheckBox ID="CheckBox1" CssClass="checkboxuser" runat="server" Text="&nbsp;Tư vấn" TextAlign="Right" />
            </div>
            <div style="width: 20%; float: left">
                <asp:CheckBox ID="CheckBox2" CssClass="checkboxuser" runat="server" Text="&nbsp;Giới thiệu việc làm" TextAlign="Right" />
            </div>
            <div style="width: 20%; float: left">
                <asp:CheckBox ID="CheckBox3" CssClass="checkboxuser" runat="server" Text="&nbsp;Học nghề" TextAlign="Right" />
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
                <input type="checkbox" id="chkDangKyTre" onchange="hidenDangkyTre(this)" class="checkboxuserinput" />
                <%--<asp:CheckBox ID="chkDangKyTre" onchange="hidenDangkyTre(this)" CssClass="checkboxuser" runat="server" TextAlign="Left" />--%>
            </div>

            <%--<div class="label2">
            Lý do đăng ký trễ: 
        </div>--%>
            <div style="width: 49%; float: left">
                <asp:DropDownList ID="ddlDangKyTre" CssClass="form-control" runat="server" Style="width: 100%; display: none">
                    <asp:ListItem Value="0">--Chọn lý do đăng ký trễ--</asp:ListItem>
                    <asp:ListItem Value="0">Thiên tai dịch họa</asp:ListItem>
                    <asp:ListItem Value="0">Ốm đau thai sản</asp:ListItem>
                    <asp:ListItem Value="0">Tai nạn giao thông</asp:ListItem>
                    <asp:ListItem Value="0">Khác</asp:ListItem>
                </asp:DropDownList>
                <%--<asp:TextBox ID="txtLiDoDangKyTre" runat="server" CssClass="form-control"></asp:TextBox>--%>
            </div>
        </div>
        <div class="row line">
            <div class="label1">
                Người tiếp nhận ĐK: 
            </div>
            <div style="width: 20%; float: left">
                <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server" Style="width: 100%;">
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
        </div>
        <div class="row line">
            <div class="label1">
                Nơi nhận bảo hiểm: 
            </div>
            <div style="width: 20%; float: left">
                <asp:DropDownList ID="DropDownList3" CssClass="form-control" runat="server" Style="width: 100%;">
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
                <asp:DropDownList ID="DropDownList4" CssClass="form-control" runat="server" Style="width: 100%;">
                    <asp:ListItem Value="0">Không chọn</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="row line">
            <div class="label1" style="width: 50%">
                <span class="warning">* Check chọn đã xác nhận chưa đăng ký nếu NLD có giấy xác nhận chưa ĐK</span>
            </div>
            <div style="width: 3%; float: left">
                <input type="checkbox" id="chkXacNhanDangKy" onchange="hidenXacNhanDangKy(this)" class="checkboxuserinput" />
            </div>
            <div class="label1" style="width: 18%; text-align: left;">
                <label for="chkXacNhanDangKy">Đã xác nhận đăng ký</label>
            </div>
            <div style="width: 25%; float: left">
                <asp:DropDownList ID="ddlNoiDKXacNhan" CssClass="form-control" runat="server" Style="width: 100%; display: none">
                    <asp:ListItem Value="0">--Chọn nơi xác nhận đăng ký--</asp:ListItem>
                </asp:DropDownList>
                <%--<asp:TextBox ID="txtLiDoDangKyTre" runat="server" CssClass="form-control"></asp:TextBox>--%>
            </div>
        </div>

        <br />
        <br />
        <br />
    </div>

    <div style="width: 17%; float: right;">
        <div class="row" style="background-color: red; margin-left:0px; margin-right:0px; color:#fff; font-size:13px; font-family:Arial; font-weight:bold; padding:5px;">
            Thông tin đăng ký     
        </div>
        <div class="panel-body1" style ="margin-top:0px;">
            <div class="row" style="font-size: 13.5px; padding-top:-30px!important;">
                Ngày đăng ký: <%= txtNgayDangKyTN.Value %><br />
                Hạn hoàn thiện: -:- <br />
                Ngày hoàn thiện: -:- <br />
                Ngày trả QĐ: -:- 
                <br />
                <br />

                <div class="list-group list-group-alternate">
                    <a href="#" class="list-group-item"><span class="badge1">></span>Thông tin đăng ký </a>
                    <a href="#" class="list-group-item"><span class="badge1">></span>Đăng ký TCTN</a>
                    <a href="#" class="list-group-item"><span class="badge1">></span>Đề nghị hưởng </a>
                    <a href="#" class="list-group-item"><span class="badge1">></span>Giấy biên nhận ĐK </a>
                    <a href="#" class="list-group-item"><span class="badge1">></span>Phiếu hẹn trả KQ </a>
                    <a href="#" class="list-group-item"><span class="badge1">></span>Phiếu tính hưởng </a>
                    <a href="#" class="list-group-item"><span class="badge1">></span>Tải quyết định </a>
                </div>
                <br />
                <br />
                <asp:Button ID="btnSave" runat="server" Text="Lưu thông tin" Style="width: 100% !important;" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                <br />
                <br />
                <a href="#" class="btn btn-success" style="width: 100%">Chuyển hồ sơ</a>
                <br />
                <br />
                <br />
                <a href="#" class="btn btn-default" style="width: 100%">Thoát</a>
            </div>
        </div>
    </div>

    <footer style="z-index: 100; height: 30px !important; margin-bottom: 0px; margin-left: -28px; width: 100%; text-align: justify; background-color: #f0f0f0; padding-top: 5px; text-align: center;">
        <span id="lblMsg" runat="server" class="warning"></span>
    </footer>

</asp:Content>
