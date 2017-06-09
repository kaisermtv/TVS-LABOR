<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/BHTN.master"  CodeFile="NhapThongTinHoSo.aspx.cs" Inherits="BHTN_NhapThongTinHoSo" %>

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
            margin-top: 6px;
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

        function SelectName() {

            var w = 1000;
            var h = 600;

            var dualScreenLeft = window.screenLeft != undefined ? window.screenLeft : screen.left;
            var dualScreenTop = window.screenTop != undefined ? window.screenTop : screen.top;

            var width = window.innerWidth ? window.innerWidth : document.documentElement.clientWidth ? document.documentElement.clientWidth : screen.width;
            var height = window.innerHeight ? window.innerHeight : document.documentElement.clientHeight ? document.documentElement.clientHeight : screen.height;

            var left = ((width / 2) - (w / 2)) + dualScreenLeft;
            var top = ((height / 2) - (h / 2)) + dualScreenTop;
            var newWindow = window.open("/Labor/ChonDoanhNghiep2.aspx", "CHỌN DOANH NGHIỆP", 'scrollbars=yes, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);

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


        function getQuanHuyen(id, selectid, phuongxaid) {
            $.get("/ajax/QuanHuyenOption.aspx?id=" + id, function (data, status) {
                var selectout = document.getElementById("MainContent_" + selectid);
                var phuongxaout = document.getElementById("MainContent_" + phuongxaid);

                //selectout.innerHTML = "";

                if (status == "success") {
                    selectout.innerHTML = data;
                    //$("#" + selectid).html(data);
                } else {
                    selectout.innerHTML = "";
                    //$("#MainContent_" + selectid).html("");
                    alert("Mất kết nôi! Xin thử lại.");
                }

                getPhuongXa(selectout.options[selectout.selectedIndex].value, phuongxaid);

                //selectout.
            });
        }

        function getPhuongXa(id, selectid) {
            $.get("/ajax/PhuongXaOption.aspx?id=" + id, function (data, status) {
                var selectout = document.getElementById("MainContent_" + selectid);

                if (status == "success") {
                    selectout.innerHTML = data;
                } else {
                    selectout.innerHTML = "";
                    alert("Mất kết nôi! Xin thử lại.");
                }
            });
        }

        function CopyTinhThanh() {
            var selectout1 = document.getElementById("MainContent_ddlTinh_TT");
            var selectout2 = document.getElementById("MainContent_ddlHuyen_TT");
            var selectout3 = document.getElementById("MainContent_ddlXa_TT");
            var selectout4 = document.getElementById("MainContent_ddlTinh_DC");
            var selectout5 = document.getElementById("MainContent_ddlHuyen_DC");
            var selectout6 = document.getElementById("MainContent_ddlXa_DC");


            var selectout7 = document.getElementById("MainContent_txtXom_TT");
            var selectout8 = document.getElementById("MainContent_txtXom_DC");


            selectout4.selectedIndex = selectout1.selectedIndex;

            selectout5.innerHTML = selectout2.innerHTML;
            selectout5.selectedIndex = selectout2.selectedIndex;

            selectout6.innerHTML = selectout3.innerHTML;
            selectout6.selectedIndex = selectout3.selectedIndex;

            selectout8.value = selectout7.value;

        }

    </script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div style="width: 83%; float: left; margin-top:-15px!important;">
        <div class="row line">
            <div class="label1">
                Ngày nộp hồ sơ: 
            </div>
            <div style="width: 20%; float: left">
                <div class='input-group date' style="margin-left: 0px; width: 100% !important; float: right;">
                    <input type='text' class="form-control dateinput" id="txtNgayNopHS" runat="server" />
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>
            </div>

            <div class="label2">
                Người nhận: 
            </div>
            <div style="width: 20%; float: left">
                <asp:DropDownList ID="ddlNguoiNhan" CssClass="form-control" runat="server" Style="width: 100%;">
                    <asp:ListItem Value="0">Không chọn</asp:ListItem>
                </asp:DropDownList>
            </div>


            <div class="label2">
                Nơi nhận: 
            </div>
            <div style="width: 20%; float: left">
                <asp:DropDownList ID="ddlNoiNhan" CssClass="form-control" runat="server" Style="width: 100%;">
                    <asp:ListItem Value="0">Không chọn</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>

        <div class="row headlabel" style="padding:3px; padding-left: 15px; background-color: #00ffff; margin-right:6px!important;">
            <b>I. Thông tin người lao động</b>
        </div>

        <div class="row line">
            <div class="label1">
                Họ và tên: 
            </div>
            <div style="width: 20%; float: left">
                <input type="hidden" runat="server" id="IdNLD" />
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
                Dân tộc: 
            </div>
            <div style="width: 20%; float: left">
                <asp:DropDownList ID="ddlDanToc" CssClass="form-control" runat="server" Style="width: 100%;">
                    <asp:ListItem Value="0">Không chọn</asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="label2">
                Tôn giáo: 
            </div>
            <div style="width: 20%; float: left">
                <asp:DropDownList ID="ddlTonGiao" CssClass="form-control" runat="server" Style="width: 100%;">
                    <asp:ListItem Value="0">Không chọn</asp:ListItem>
                </asp:DropDownList>
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
                        Số tài khoản: 
                    </div>
                    <div style="width: 20%; float: left">
                        <asp:TextBox ID="txtSoTaiKhoan" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>

                    <div class="label2">
                        Ngân hàng: 
                    </div>
                    <div style="width: 20%; float: left">
                        <asp:DropDownList ID="ddlNganHang" CssClass="form-control" runat="server" Style="width: 100%;">
                            <asp:ListItem Value="0">Không chọn</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
        <div class="row line">
                    <div class="label1">
                        Mã số thuế: 
                    </div>
                    <div style="width: 20%; float: left">
                        <asp:TextBox ID="txtMaSoThue" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>

                    <div class="label2">
                        Email: 
                    </div>
                    <div style="width: 20%; float: left">
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
        <div class="row">
            <div style="float:left;margin-right:-60px;width:100%">
                <div class="line" style="display:table;width:100%">
                    <div class="label1">
                        Nơi thường trú: 
                    </div>
                    <div style="width: 15%; float: left;margin-right:10px">
                        <asp:DropDownList ID="ddlTinh_TT" onChange="getQuanHuyen(this.options[this.selectedIndex].value,'ddlHuyen_TT','ddlXa_TT')" runat="server" CssClass=" multiple-style form-control" Style="width: 100%;">
                        </asp:DropDownList>
                    </div>
                    <div style="width: 15%; float: left;margin-right:10px">
                        <asp:DropDownList ID="ddlHuyen_TT"  onChange="getPhuongXa(this.options[this.selectedIndex].value,'ddlXa_TT')" runat="server" CssClass="multiple-style form-control" Style="width: 100%;">
                        </asp:DropDownList>
                    </div>
                    <div style="width: 15%; float: left;margin-right:10px">
                        <asp:DropDownList ID="ddlXa_TT" runat="server" CssClass=" multiple-style form-control" Style="width: 100%;">
                        </asp:DropDownList>
                    </div>
                    <div style="width: 32%; float: left">
                        <asp:TextBox ID="txtXom_TT" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="line" style="display:table;width:100%">
                    <div class="label1">
                        Nơi thường trú: 
                    </div>
                    <div style="width: 15%; float: left;margin-right:10px">
                        <asp:DropDownList ID="ddlTinh_DC" onChange="getQuanHuyen(this.options[this.selectedIndex].value,'ddlHuyen_DC','ddlXa_DC')" runat="server" CssClass="multiple-style  form-control" Style="width: 100%;">
                        </asp:DropDownList>
                    </div>
                    <div style="width: 15%; float: left;margin-right:10px">
                        <asp:DropDownList ID="ddlHuyen_DC" onChange="getPhuongXa(this.options[this.selectedIndex].value,'ddlXa_DC')" runat="server" CssClass="multiple-style form-control" Style="width: 100%;">
                        </asp:DropDownList>
                    </div>
                    <div style="width: 15%; float: left;margin-right:10px">
                        <asp:DropDownList ID="ddlXa_DC" runat="server" CssClass=" multiple-style  form-control" Style="width: 100%;">
                        </asp:DropDownList>
                    </div>
                    <div style="width: 32%; float: left">
                        <asp:TextBox ID="txtXom_DC" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div style="float:right;width:59px" class="line">
                <input type="button" value="&dArr;" style="height: 78px; margin-left: 3px" class="btn btn-primary" onclick="CopyTinhThanh()" />
            </div>
        </div>
        <div class="row line">
            <div class="label1">
                Nơi ĐK KB: 
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
                <asp:TextBox ID="txtCMKT" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="label2">
                Lĩnh vực đào tạo: 
            </div>
            <div style="width: 20%; float: left">
                <asp:TextBox ID="txtLinhVucDaotao" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="row headlabel" style="padding:3px; padding-left: 15px; background-color: #00ffff; margin-right:6px!important;">
            <b>II. Thông tin cá nhân bổ sung</b>
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

            <div class="label2">
                        Email: 
                    </div>
                    <div style="width: 20%; float: left">
                        <asp:TextBox ID="txtEmailDN" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
        </div>
        <div class="row line">
                    <div class="label1">
                        Số ĐKKD: 
                    </div>
                    <div style="width: 20%; float: left">
                        <asp:TextBox ID="txtSoDKKD" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>

                    <div class="label2">
                        Loại hình DN: 
                    </div>
                    <div style="width: 20%; float: left">
                        <asp:DropDownList ID="ddlLoaiHinhDN" CssClass="form-control" runat="server" Style="width: 100%">
                            <asp:ListItem Value="0">Không chọn</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="row line">
                    <div class="label1">
                        Ngành nghề SX - KD: 
                    </div>
                    <div style="width: 20%; float: left">
                        <asp:DropDownList ID="ddlIdNganhNgheDN" CssClass="form-control" runat="server" Style="width: 100%">
                            <asp:ListItem Value="0">Không chọn</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="label2">
                        Website:
                    </div>
                    <div style="width: 30%; float: left">
                        <asp:TextBox ID="txtWebsiteDN" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

       <div class="row headlabel" style="padding:3px; padding-left: 15px; background-color: #00ffff; margin-right:6px!important;">
            <b>III. Thông tin đăng ký thất nghiệp</b>
        </div>

        <div class="row line">
            <div class="label1" style="width: 15%;">
                Số tháng đóng BHTN: 
            </div>
            <div style="width: 20%; float: left">
                <asp:TextBox ID="txtSoThangDongBHXH" runat="server" CssClass="form-control" Style ="width:100%;"></asp:TextBox>
            </div>
            <div class="label1" style="width: 15%;">
                Loại hợp đồng:  
            </div>
            <div style="width:48%; float: left">
                <asp:DropDownList ID="ddlLoaiHopDong" CssClass="form-control" runat="server" Style="width: 100%;">
                    <asp:ListItem Value="0">--Chọn loại hợp đồng--</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>

        <div class="row line">
             <div class="label1" style="width: 15%;">
                Giấy tờ kèm theo: 
            </div>
            <div style="width: 83%; float: left">
                <asp:DropDownList ID="ddlGiayToKemtheo" CssClass="form-control" runat="server" Style="width: 100%;">
                    <asp:ListItem Value="0">Không chọn</asp:ListItem>
                </asp:DropDownList>
            </div>
            </div>
        <div class="row line">

            <div class="label1" style="width: 15%;">
                Hạn hoàn thiện: 
            </div>
            <div style="width: 20%; float: left">
                <div class='input-group date' style="margin-left: 0px; width: 100% !important; float: right;">
                    <input type='text' class="form-control dateinput" id="txtHanHoanThien" runat="server" />
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>
                <%--<asp:TextBox ID="TextBox16" runat="server" CssClass="form-control"></asp:TextBox>--%>
            </div>

            <div class="label2" style="width: 15%;">
                Nơi nhận TCTN: 
            </div>
            <div style="width: 48%; float: left">
                <asp:DropDownList ID="ddlNoiNhanTCTN" CssClass="form-control" runat="server" Style="width: 100%;">
                    <asp:ListItem Value="0">Không chọn</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>


        <div class="row line">
            <div class="label1" style="width: 15%;">
                Nơi chốt sổ cuối: 
            </div>
            <div style="width: 20%; float: left">
                <asp:DropDownList ID="ddlNoiChotSoCuoi" CssClass="form-control" runat="server" Style="width: 100%;">
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
       
    </div>

    <div style="width: 16%; float: right; margin-top:-5px; background-color:#fff; height:1180px; padding:5px;">
        <div style ="height:28px; background-color:red; line-height:28px; color:#fff; text-align:center; font-size:12PX; font-weight:bold;">Thông tin đóng hưởng</div>
        <div class="panel-body1" style ="padding:20px; padding-top:10px; margin-top:2px;">
            <div class="row">
                Ngày đăng ký: <%= txtNgayNopHS.Value %><br />
                Hạn hoàn thiện:<br />
                Ngày hoàn thiện:<br />
                Ngày trả QĐ:
                <br />
                <br />

                <div class="list-group list-group-alternate">
                    <%--<a href="#" class="list-group-item"><span class="badge1" style ="left:140px;">></span>Thông tin đăng ký </a>--%>
                    <%--<a href="#" class="list-group-item"><span class="badge1" style ="left:140px;">></span>Đăng ký TCTN</a>--%>
                    <a href="#" class="list-group-item" runat="server" onserverclick="DeNghiHuong_Click"><span class="badge1" style ="left:140px;">></span>Đề nghị hưởng </a>
                    <%--<a href="#" class="list-group-item" runat="server" onserverclick="GiayBienNhan_Click"><span class="badge1" style ="left:140px;">></span>Giấy biên nhận ĐK </a>--%>
                    <%--<a href="#" class="list-group-item"><span class="badge1" style ="left:140px;">></span>Phiếu hẹn trả KQ </a>--%>
                </div>
                <br />
                <asp:Button ID="btnSave" runat="server" Text="Lưu thông tin" Style="width: 100% !important;" CssClass="btn btn-primary" OnClick="btnSave_Click " />
                <br />
                <br />
                <button class="btn btn-danger" style="width: 100%" data-toggle="modal" data-target="#HoanThienModal">Chuyển hồ sơ</button>
            </div>
        </div>
    </div>

    <footer style="z-index: 100; height: 43px !important; margin-bottom: 0px; margin-left: -14px; width: 100%; text-align: justify; background-color: #f0f0f0; padding-top: 4px">
        <div class="warning">
            <asp:Label ID="lblMsg" runat="server" Text="" Font-Size="Larger" ForeColor="Red" />
        </div>
        <a href="DangKyHoSo.aspx" class="btn btn-default" style ="float:right; margin-right:52px;">Thoát</a>
    </footer>

    <div id="HoanThienModal" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Xác nhận hoàn thiện hồ sơ</h4>
                </div>
                <div class="modal-body">
                    <p>Bạn xác nhận chuyển hồ sơ này</p>
                </div>
                <div class="modal-footer">
                    <div style="width: 60%; float: left">
                        <div class='input-group date' style="margin-left: 0px; width: 100% !important; float: right;">
                            <input type='text' class="form-control dateinput" id="txtNgayHoanThanh" runat="server" />
                            <span class="input-group-addon">
                                <span class="glyphicon glyphicon-calendar"></span>
                            </span>
                        </div>
                    </div>

                    <asp:Button ID="btnHoanThienHoSo" runat="server" CssClass="btn btn-primary" Text="Xác nhận" OnClick="btnHoanThienHoSo_Click" />
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
