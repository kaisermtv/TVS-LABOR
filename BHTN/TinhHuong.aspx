<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin.master" CodeFile="TinhHuong.aspx.cs" Inherits="Labor_TinhHuong" %>
<%@ Register src="uctLichThongBao.ascx" tagname="uctLichThongBao" tagprefix="uc1" %>
<%@ Register src="uctLog.ascx" tagname="uctLog" tagprefix="uc2" %>
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
        th{ width:13% !important;}
    
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
            var newWindow = window.open("ChonDoanhNghiep2.aspx", "CHỌN DOANH NGHIỆP", 'scrollbars=yes, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);

            if (window.focus) {
                newWindow.focus();
            }
        }

 
    </script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div style="width: 83%; float: left; margin-top:-15px!important;">
        <div class="row headlabel" style="padding:3px; padding-left: 15px; background-color: #00ffff; margin-right:6px!important;">
         <b>Thông tin tính hưởng</b></div>
        <div class="row line">
            <div class="label1">
                Họ và tên: 
            </div>
            <div style="width: 20%; float: left">
                <asp:TextBox ID="txtHoVaTen" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
            </div>

            <div class="label2">
                Ngày sinh: 
            </div>
            <div style="width: 20%; float: left">
                <div class='input-group date' style="margin-left: 0px; width: 100% !important; float: right;">
                    <input type='text' class="form-control dateinput" id="txtNgaySinh" readonly="true" runat="server" />
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>           
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
                <asp:TextBox ID="txtCMND" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="label2">
                Ngày cấp: 
            </div>
            <div style="width: 20%; float: left">
                <div class='input-group date' style="margin-left: 0px; width: 100% !important; float: right;">
                    <input type='text' class="form-control dateinput" readonly="true" id="txtNgayCap" runat="server" />
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>        
            </div>

           <div class="label2">    
               Nơi cấp:        
            </div>
            <div style="width: 20%; float: left">
               <asp:TextBox ID="txtNoiCap" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>          
            </div>  
        </div>

        <div class="row line">
            <div class="label1">
               Số sổ BHXH:
            </div>
            <div style="width: 20%; float: left">
                <asp:TextBox ID="txtSoBHXH" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="label2">
                Số tháng đóng:
            </div>
            <div style="width: 20%; float: left">
                <asp:TextBox ID="txtSoThangDongBHXH" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="row line">
         <div class="label1">
            Số điện thoại: 
            </div>
            <div style="width: 20%; float: left">
                <asp:TextBox ID="txtSoDienThoai" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
            </div>

            

        </div>
        <div class="row line">
            <div class="label1">
             Nơi cư trú: 
            </div>

            <div style="width: 52%; float: left">
                <asp:TextBox ID="txtNoiThuongTru" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

        </div>
        <div class="row line">
            <div class="label1">
                Chỗ ở hiện tại: 
            </div>
            <div style="width: 52%; float: left">
                <asp:TextBox ID="txtChoOHienTai" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="row line">     
       
            <div class="label1">
            Ngày nghỉ việc:
            </div>
            <div style="width: 20%; float: left">
                <div class='input-group date' style="margin-left: 0px; width: 100% !important; float: right;">
                    <input type='text' class="form-control dateinput" id="txtNgayNghiViec" readonly="true" runat="server" />
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>           
            </div>

             <div class="label2">
             Ngày nộp HS:
            </div>
            <div style="width: 20%; float: left">
                <div class='input-group date' style="margin-left: 0px; width: 100% !important; float: right;">
                    <input type='text' readonly="true" class="form-control dateinput" id="txtNgayNopHoSo" runat="server" />
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>           
            </div>
        </div>
        <div class="row line">
            <div class="label1">Nơi ĐBH cuối: </div>
            <div style="width: 20%; float: left">
                <asp:DropDownList ID="ddlLuongToiThieu" CssClass="form-control" runat="server" Style="width: 100%;">
                </asp:DropDownList>
            </div>

        </div>
        <div class="row line">            
            <div class="label1">
                6 tháng gần nhất 
            </div>
            <div style="width: 84%; float: left">
                <table style="border: 1px solid; width: 100%">
                    <tr>
                        <th style="width: 120px"></th>
                        <th>Tháng đóng</th>
                        <th>Mức đóng</th>
                        <th>&nbsp;</th>
                        <th>&nbsp;</th>                       
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
                            <asp:TextBox ID="txtMucDongThang6" runat="server" CssClass="form-control money"></asp:TextBox></td>
                        <th>
                            Mức đóng trung bình:
                        </th>
                        <td>
                            <asp:TextBox ID="txtLuongTrungBinh" runat="server" CssClass="form-control money"></asp:TextBox></td>
                   
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
                            <asp:TextBox ID="txtMucDongThang5" runat="server" CssClass="form-control money"></asp:TextBox></td>
                        <th>
                            Mức hưởng tối đa:

                        </th>
                        <td>
                            <asp:TextBox ID="txtMucHuongToiDa" runat="server" CssClass="form-control money"></asp:TextBox></td>
                
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
                            <asp:TextBox ID="txtMucDongThang4" runat="server" CssClass="form-control money"></asp:TextBox></td>
                        <th>
                            Mức hưởng:
                        </th>
                        <td>
                            <asp:TextBox ID="txtMucHuong" runat="server" CssClass="form-control money"></asp:TextBox></td>
                  
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
                            <asp:TextBox ID="txtMucDongthang3" runat="server" CssClass="form-control money"></asp:TextBox></td>
                        <th>
                            Số tháng hưởng TCTN:
                        </th>
                        <td>
                            <asp:TextBox ID="txtSoThangHuong" runat="server" CssClass="form-control"></asp:TextBox></td>
                  
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
                            <asp:TextBox ID="txtMucDongThang2" runat="server" CssClass="form-control money"></asp:TextBox></td>
                        <th>
                            Số tháng bảo lưu:
                        </th>
                        <td>
                            <asp:TextBox ID="txtSoThangBaoLuu" runat="server" CssClass="form-control"></asp:TextBox></td>
                  
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
                            <asp:TextBox ID="txtMucDongThang1" runat="server" CssClass="form-control money"></asp:TextBox></td>
                        <th>
                            Hưởng từ ngày:

                        </th>
                        <td>
                            <div class='input-group date' style="margin-left: 0px; width: 100% !important; float: right;">
                                <input type='text' class="form-control dateinput" id="txtHuongTuNgay" runat="server" />
                                <span class="input-group-addon">
                                    <span class="glyphicon glyphicon-calendar"></span>
                                </span>
                            </div>

                        </td>
                   
                    </tr>                 
                    <tr>
                        <th>&nbsp;</th>
                        <td>                            
                        </td>
                        <td>
                        </td>
                        <th>  
                            Hưởng đến ngày:
                        </th>
                        <td>
                            <div class='input-group date' style="margin-left: 0px; width: 100% !important; float: right;">
                                <input type='text' class="form-control dateinput" id="txtHuongDenNgay" runat="server" />
                                <span class="input-group-addon">
                                    <span class="glyphicon glyphicon-calendar"></span>
                                </span>
                            </div>

                        </td>                     
                    </tr>
                </table>
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
                Ngày đăng ký: <asp:Label ID="lblNgayDangKy" runat="server" Text="" style="color:red;float: right;"></asp:Label><br />
                <br />
                <br />

                <div class="list-group list-group-alternate">
                    <a href="#" class="list-group-item" runat="server" onserverclick="Unnamed_ServerClick"><span class="badge1" style ="left:140px;">></span>Phiếu tính hưởng </a>
                    <a href="#" class="list-group-item" data-toggle="modal" data-target="#lichthongbao" runat="server"><span class="badge1" style ="left:140px;">></span>Lịch thông báo</a>
                    <a href="#" class="list-group-item" runat="server" onserverclick="InQuyetDinhHuongTroCap_ServerClick" visible="false"><span class="badge1" style ="left:140px;">></span>Tải quyết định </a>
                    <a href="#" class="list-group-item" data-toggle="modal" data-target="#log" runat="server"><span class="badge1" style ="left:140px;">></span>Nhật ký</a>
                </div>
               
                <asp:Button ID="btnTinhHuong" runat="server" Text="Tính hưởng" Style="width: 100% !important; margin-top:10px;" CssClass="btn btn-primary" OnClick="btnTinhHuong_Click" />
              
                 <asp:Button ID="btnChuyenTraHoSo" runat="server" Text="Chuyển trả hồ sơ" Style="width: 100% !important;margin-top:10px;" CssClass="btn btn-primary" OnClick="btnChuyenTraHoSo_Click" />
             
                <asp:Button ID="btnChuyenThamDinh" runat="server" Text="Chuyển thẩm định" Style="width: 100% !important;margin-top:10px;" CssClass="btn btn-primary" OnClick="btnChuyenThamDinh_Click" />
               
                <asp:Button ID="btnTraQuyetDinh" runat="server" Text="Trả quyết định" Style="width: 100% !important;margin-top:10px;" CssClass="btn btn-primary" OnClick="btnTraQuyetDinh_Click" />
            
            </div>
        </div>
    </div>


    <footer style="z-index: 100; height: 43px !important; margin-bottom: 0px; margin-left: -14px; width: 100%; text-align: justify; background-color: #f0f0f0; padding-top: 4px">
        <div class="warning">
            <asp:Label ID="lblMsg" runat="server" Text="" Font-Size="Larger" ForeColor="Red" />
        </div>
        </footer>

     <!-- Modal -->
    <div id="lichthongbao" class="modal fade" role="dialog">
        <div class="modal-dialog" style="width:80%;">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Lịch thông báo</h4>
                </div>
                <div class="modal-body">
                <uc1:uctLichThongBao ID="LichThongBao1" runat="server"  />
                </div>
                <div class="modal-footer">                 
                </div>
            </div>

        </div>
    </div> 

       <div id="log" class="modal fade" role="dialog">
        <div class="modal-dialog" style="width:80%;">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Nhật ký</h4>
                </div>
                <div class="modal-body">
                <uc2:uctLog ID="uctLog1" runat="server" />
                </div>
                <div class="modal-footer">                 
                </div>
            </div>

        </div>
    </div> 

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


        });
        $("#MainContent_txtMucDongThang6").blur(function () {
            var SoThangDong = $("#MainContent_txtSoThangDongBHXH").val();
            if (SoThangDong.trim() == "") {
                $("#MainContent_txtSoThangHuong").val("");
                $("#MainContent_txtSoThangBaoLuu").val("");
            }
            var SoThangDuocHuong = 0, SoThangBaoLuu = 0, temp = 0;
            temp = SoThangDong;
            if (SoThangDong >= 12 && SoThangDong <= 36) {
                SoThangDuocHuong = 3;
            }
            if (SoThangDong > 36) {
                SoThangDuocHuong = 3;
                SoThangDong = SoThangDong - 36;
                SoThangDong = Math.round((SoThangDong / 12));
                SoThangDuocHuong = SoThangDuocHuong + SoThangDong;
                if (SoThangDuocHuong > 12) {
                    SoThangDuocHuong = 12;
                }
            }

            SoThangBaoLuu = temp - SoThangDuocHuong * 12;
            if (SoThangBaoLuu < 0) {
                SoThangBaoLuu = 0;
            }

            $("#MainContent_txtSoThangHuong").val(SoThangDuocHuong);
            $("#MainContent_txtSoThangBaoLuu").val(SoThangBaoLuu);
        });
        $("#MainContent_ddlLuongToiThieu").change(function () {
            $("#MainContent_txtMucHuongToiDa").val($(this).val() * 5);
        });
        $("#MainContent_txtSoThangDongBHXH").blur(function () {
            var SoThangDong = $(this).val();
            if (SoThangDong.trim() == "") {
                $("#MainContent_txtSoThangHuong").val("");
                $("#MainContent_txtSoThangBaoLuu").val("");
            }
            var SoThangDuocHuong = 0, SoThangBaoLuu = 0, temp = 0;
            temp = SoThangDong;
            if (SoThangDong >= 12 && SoThangDong <= 36) {
                SoThangDuocHuong = 3;
            }
            if (SoThangDong > 36) {
                SoThangDuocHuong = 3;
                SoThangDong = SoThangDong - 36;
                SoThangDong = Math.round((SoThangDong / 12));
                SoThangDuocHuong = SoThangDuocHuong + SoThangDong;
                if (SoThangDuocHuong > 12) {
                    SoThangDuocHuong = 12;
                }
            }

            SoThangBaoLuu = temp - SoThangDuocHuong * 12;
            if (SoThangBaoLuu < 0) {
                SoThangBaoLuu = 0;
            }

            $("#MainContent_txtSoThangHuong").val(SoThangDuocHuong);
            $("#MainContent_txtSoThangBaoLuu").val(SoThangBaoLuu);
        });
        var _msg = '<%=_msg%>';
        if (_msg != '') {
            alert(_msg);
        }

        (function (e) { if (typeof define === "function" && define.amd) { define(["jquery"], e) } else { e(window.jQuery || window.Zepto) } })(function (e) { "use strict"; var t = function (t, n, r) { var i = this, s; t = e(t); n = typeof n === "function" ? n(t.val(), undefined, t, r) : n; i.init = function () { r = r || {}; i.byPassKeys = [9, 16, 17, 18, 36, 37, 38, 39, 40, 91]; i.translation = { 0: { pattern: /\d/ }, 9: { pattern: /\d/, optional: true }, "#": { pattern: /\d/, recursive: true }, A: { pattern: /[a-zA-Z0-9]/ }, S: { pattern: /[a-zA-Z]/ } }; i.translation = e.extend({}, i.translation, r.translation); i = e.extend(true, {}, i, r); t.each(function () { if (r.maxlength !== false) { t.attr("maxlength", n.length) } if (r.placeholder) { t.attr("placeholder", r.placeholder) } t.attr("autocomplete", "off"); o.destroyEvents(); o.events(); var e = o.getCaret(); o.val(o.getMasked()); o.setCaret(e + o.getMaskCharactersBeforeCount(e, true)) }) }; var o = { getCaret: function () { var e, n = 0, r = t.get(0), i = document.selection, s = r.selectionStart; if (i && !~navigator.appVersion.indexOf("MSIE 10")) { e = i.createRange(); e.moveStart("character", t.is("input") ? -t.val().length : -t.text().length); n = e.text.length } else if (s || s === "0") { n = s } return n }, setCaret: function (e) { if (t.is(":focus")) { var n, r = t.get(0); if (r.setSelectionRange) { r.setSelectionRange(e, e) } else if (r.createTextRange) { n = r.createTextRange(); n.collapse(true); n.moveEnd("character", e); n.moveStart("character", e); n.select() } } }, events: function () { t.on("keydown.mask", function () { s = o.val() }); t.on("keyup.mask", o.behaviour); t.on("paste.mask drop.mask", function () { setTimeout(function () { t.keydown().keyup() }, 100) }); t.on("change.mask", function () { t.data("changeCalled", true) }); t.on("blur.mask", function (t) { var n = e(t.target); if (n.prop("defaultValue") !== n.val()) { n.prop("defaultValue", n.val()); if (!n.data("changeCalled")) { n.trigger("change") } } n.data("changeCalled", false) }); t.on("focusout.mask", function () { if (r.clearIfNotMatch && o.val().length < n.length) { o.val("") } }) }, destroyEvents: function () { t.off("keydown.mask keyup.mask paste.mask drop.mask change.mask blur.mask focusout.mask").removeData("changeCalled") }, val: function (e) { var n = t.is("input"); return arguments.length > 0 ? n ? t.val(e) : t.text(e) : n ? t.val() : t.text() }, getMaskCharactersBeforeCount: function (e, t) { for (var r = 0, s = 0, o = n.length; s < o && s < e; s++) { if (!i.translation[n.charAt(s)]) { e = t ? e + 1 : e; r++ } } return r }, determineCaretPos: function (e, t, r, s) { var u = i.translation[n.charAt(Math.min(e - 1, n.length - 1))]; return !u ? o.determineCaretPos(e + 1, t, r, s) : Math.min(e + r - t - s, r) }, behaviour: function (t) { t = t || window.event; var n = t.keyCode || t.which; if (e.inArray(n, i.byPassKeys) === -1) { var r = o.getCaret(), s = o.val(), u = s.length, a = r < u, f = o.getMasked(), l = f.length, c = o.getMaskCharactersBeforeCount(l - 1) - o.getMaskCharactersBeforeCount(u - 1); if (f !== s) { o.val(f) } if (a && !(n === 65 && t.ctrlKey)) { if (!(n === 8 || n === 46)) { r = o.determineCaretPos(r, u, l, c) } o.setCaret(r) } return o.callbacks(t) } }, getMasked: function (e) { var t = [], s = o.val(), u = 0, a = n.length, f = 0, l = s.length, c = 1, h = "push", d = -1, v, m; if (r.reverse) { h = "unshift"; c = -1; v = 0; u = a - 1; f = l - 1; m = function () { return u > -1 && f > -1 } } else { v = a - 1; m = function () { return u < a && f < l } } while (m()) { var g = n.charAt(u), y = s.charAt(f), b = i.translation[g]; if (b) { if (y.match(b.pattern)) { t[h](y); if (b.recursive) { if (d === -1) { d = u } else if (u === v) { u = d - c } if (v === d) { u -= c } } u += c } else if (b.optional) { u += c; f -= c } else if (b.defaults) { t[h](b.defaults); u += c; f -= c } f += c } else { if (!e) { t[h](g) } if (y === g) { f += c } u += c } } var w = n.charAt(v); if (a === l + 1 && !i.translation[w]) { t.push(w) } return t.join("") }, callbacks: function (e) { var i = o.val(), u = o.val() !== s; if (u === true) { if (typeof r.onChange === "function") { r.onChange(i, e, t, r) } } if (u === true && typeof r.onKeyPress === "function") { r.onKeyPress(i, e, t, r) } if (typeof r.onComplete === "function" && i.length === n.length) { r.onComplete(i, e, t, r) } } }; i.remove = function () { var e = o.getCaret(), t = o.getMaskCharactersBeforeCount(e); o.destroyEvents(); o.val(i.getCleanVal()).removeAttr("maxlength"); o.setCaret(e - t) }; i.getCleanVal = function () { return o.getMasked(true) }; i.init() }; e.fn.mask = function (n, r) { this.unmask(); return this.each(function () { e(this).data("mask", new t(this, n, r)) }) }; e.fn.unmask = function () { return this.each(function () { try { e(this).data("mask").remove() } catch (t) { } }) }; e.fn.cleanVal = function () { return e(this).data("mask").getCleanVal() }; e("*[data-mask]").each(function () { var t = e(this), n = {}, r = "data-mask-"; if (t.attr(r + "reverse") === "true") { n.reverse = true } if (t.attr(r + "maxlength") === "false") { n.maxlength = false } if (t.attr(r + "clearifnotmatch") === "true") { n.clearIfNotMatch = true } t.mask(t.attr("data-mask"), n) }) })
        $('.money').mask("#.##0", { reverse: true, maxlength: false });

    </script>  
    <asp:HiddenField ID="hdIDNguoiLaoDong" runat="server" />
</asp:Content>
