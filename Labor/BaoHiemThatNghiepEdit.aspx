<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin.master" CodeFile="BaoHiemThatNghiepEdit.aspx.cs" Inherits="Labor_BaoHiemThatNghiepEdit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="Server">
    <style>
        .label1{
            width:14%;
            float:left;
            text-align:right;
            font-size:15px;
            padding-right:5px;
            height:34px;    
            padding-top:8px;
        }

        .label2{
            width:12%;
            float:left;
            text-align:right;
            font-size:15px;
            padding-right:5px;
            height:34px;    
            padding-top:8px;
        }

        .chkLabel{
            width:20%;
            float:left;
            font-size:15px;
            height:34px;    
            padding-top:8px;
            padding-left:20px;
        }

        .line{
            margin-top:10px;
        }

        .headlabel{
            margin-top:10px;
            font-size:16px;
        }

        .checkboxuser input {
            width: 25px;
            height: 25px;
        }

        .checkboxuser label{
            height:34px;
            font-size:15px;
        }

        span.badge1{
            right:10px;
        }
    </style>
    <script>
        $(function () {
            $('.date').datetimepicker({
                format: 'DD/MM/YYYY'
            });

            $(".dateinput").mask("99/99/9999", { placeholder: "dd/MM/yyyy" });
        });
    </script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div style="width:80%;float:left;">
    <div class="row headlabel" >
        <b>I. Thông tin người lao động</b>
    </div>
    <div class="row line">
        <div class="label1">
            Họ và tên: 
        </div>
        <div style="width:20%;float:left">
            <asp:TextBox ID="txtHoVaTen" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="label2">
            Ngày sinh: 
        </div>
        <div style="width:20%;float:left">
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
            <asp:RadioButton ID="RadioButton1" GroupName="GioiTinh" runat="server" Text="&nbsp;Nam" TextAlign="Right" />
            &nbsp;&nbsp;&nbsp;
            <asp:RadioButton ID="RadioButton2" GroupName="GioiTinh" runat="server" Text="&nbsp;Nữ" TextAlign="Right" />

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
        <div style="width:20%;float:left">
            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="label2">
            Ngày cấp: 
        </div>
        <div style="width:20%;float:left">
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
        <div style="width:20%;float:left">
            <asp:DropDownList ID="ddlNoiCap" CssClass="form-control" runat="server" Style="width: 100%;"></asp:DropDownList>
            <%--<asp:TextBox ID="txtNoiCap" runat="server" CssClass="form-control"></asp:TextBox>--%>
        </div>
    </div>
    <div class="row line">
        <div class="label1">
            Số điện thoại: 
        </div>
        <div style="width:20%;float:left">
            <asp:TextBox ID="txtSoDienThoai" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="label2">
            Nơi cư trú: 
        </div>
        <div style="width:52%;float:left">
            <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="row headlabel" >
        <b>II. Thông tin cá nhân bổ sung</b>
    </div>
    <div class="row line">
        <div class="label1">
            Số BHXH: 
        </div>
        <div style="width:20%;float:left">
            <asp:TextBox ID="txtBHXH" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="label2">
            Ngày cấp BHXH: 
        </div>
        <div style="width:20%;float:left">
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
        <div style="width:20%;float:left">
            <asp:DropDownList ID="ddlNoiCapBHXH" CssClass="form-control" runat="server" Style="width: 100%;"></asp:DropDownList>
            <%--<asp:TextBox ID="txtNoiCapBHXH" runat="server" CssClass="form-control"></asp:TextBox>--%>
        </div>
    </div>
    <div class="row line">
        <div class="label1" style="width:15%;">
            Nơi ĐK khám bệnh: 
        </div>
        <div style="width:81%;float:left">
            <asp:DropDownList ID="DropDownList2" CssClass="form-control" runat="server" Style="width: 100%;"></asp:DropDownList>
            <%--<asp:TextBox ID="TextBox3" runat="server" CssClass="form-control"></asp:TextBox>--%>
        </div>
    </div>
    <div class="row line">
        <div class="label1">
            Trình độ CMKT: 
        </div>
        <div style="width:20%;float:left">
            <asp:DropDownList ID="DropDownList5" CssClass="form-control" runat="server" Style="width: 100%;"></asp:DropDownList>
            <%--<asp:TextBox ID="TextBox4" runat="server" CssClass="form-control"></asp:TextBox>--%>
        </div>

        <div class="label2">
            Lĩnh vực đào tạo: 
        </div>
        <div style="width:20%;float:left">
            <asp:DropDownList ID="DropDownList6" CssClass="form-control" runat="server" Style="width: 100%;"></asp:DropDownList>
            <%--<asp:TextBox ID="TextBox5" runat="server" CssClass="form-control"></asp:TextBox>--%>
        </div>
    </div>
    <div class="row line">
        <div class="label1">
            Công việc đã làm: 
        </div>
        <div style="width:84%;float:left">
            <asp:TextBox ID="TextBox6" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="row line">
        <div class="label1">
            Địa chỉ DN: 
        </div>
        <div style="width:84%;float:left">
            <asp:TextBox ID="TextBox7" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="row line">
        <div class="label1">
            Điện thoại: 
        </div>
        <div style="width:20%;float:left">
            <asp:TextBox ID="TextBox8" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="label2">
            Fax: 
        </div>
        <div style="width:20%;float:left">
            <asp:TextBox ID="TextBox9" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="row headlabel" >
        <b>III. Thông tin DN bổ sung</b>
    </div>
    <div class="row line">
        <div class="label1">
            Ngày nghỉ việc: 
        </div>
        <div style="width:20%;float:left">
            <div class='input-group date' style="margin-left: 0px; width: 100% !important; float: right;">
                    <input type='text' class="form-control dateinput" id="txtNgayNghiViec" runat="server" />
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>
        </div>

        <div class="label2" style="width:15%;" >
            Số tháng đóng BHXH: 
        </div>
        <div style="width:20%;float:left">
            <asp:TextBox ID="TextBox11" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        
    </div>

    <div class="row line">
        <div class="label1">
            Nhu cầu: 
        </div>
        <div style="width:84%;float:left">
            <asp:CheckBox ID="CheckBox1" CssClass="checkboxuser" runat="server" Text="&nbsp;Tư vấn" TextAlign="Right" />&nbsp;&nbsp;&nbsp;
            <asp:CheckBox ID="CheckBox2" CssClass="checkboxuser" runat="server" Text="&nbsp;Giới thiệu việc làm" TextAlign="Right" />&nbsp;&nbsp;&nbsp;   
            <asp:CheckBox ID="CheckBox3" CssClass="checkboxuser" runat="server" Text="&nbsp;Học nghề" TextAlign="Right" />
        </div>
    </div>
    <div class="row line">
        <div class="label1">
            Ngày ĐK thất nghiệp: 
        </div>
        <div style="width:20%;float:left">
            <div class='input-group date' style="margin-left: 0px; width: 100% !important; float: right;">
                    <input type='text' class="form-control dateinput" id="txtNgayDangKyTN" runat="server" />
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>
            <%--<asp:TextBox ID="txtNgayDangKyTN" runat="server" CssClass="form-control"></asp:TextBox>--%>
        </div>

        <div class="label2">
            <label for="MainContent_chkDangKyTre">Đăng ký trễ</label>
        </div>
        <div style="width:3%;float:left">
            <asp:CheckBox ID="chkDangKyTre" CssClass="checkboxuser" runat="server" TextAlign="Left" />
        </div>

        <div class="label2">
            Lý do đăng ký trễ: 
        </div>
        <div style="width:38%;float:left">
            <asp:TextBox ID="TextBox15" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="row line">
        <div class="label1">
            Người tiếp nhận ĐK: 
        </div>
        <div style="width:20%;float:left">
            <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server" Style="width: 100%;">
                <asp:ListItem Value="0">Không chọn</asp:ListItem>
            </asp:DropDownList>
        </div>

        <div class="label2">
            Ngày hoàn thiện: 
        </div>
        <div style="width:20%;float:left">
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
        <div style="width:20%;float:left">
            <asp:DropDownList ID="DropDownList3" CssClass="form-control" runat="server" Style="width: 100%;">
                <asp:ListItem Value="0">Không chọn</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="label2" style="width:20%">
            Hình thức nhận tiền: 
        </div>
        <div class="chkLabel" style="width:42%">
            <asp:RadioButton ID="cbkATM" GroupName="HinhThucNhanTien" runat="server" Text="&nbsp;Qua ATM" TextAlign="Right" />
            &nbsp;&nbsp;&nbsp;
            <asp:RadioButton ID="cbkTienMat" GroupName="HinhThucNhanTien" runat="server" Text="&nbsp;Qua tiền mặt" TextAlign="Right" />
        </div>
    </div>
    <div class="row line">
        <div class="label1">
            Nơi chốt sổ cuối: 
        </div>
        <div style="width:20%;float:left">
            <asp:DropDownList ID="DropDownList4" CssClass="form-control" runat="server" Style="width: 100%;">
                <asp:ListItem Value="0">Không chọn</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <div class="row line"></div>
    <br />
    <br />
    <br />
        </div>
    <div style="width:19%;float:right;">
        <div class="panel-body1">
            <div class="row">
                Ngày đăng ký: <%= txtNgayDangKyTN.Value %><br />
                Hạn hoàn thiện:<br />
                Ngày trả QĐ: <br />
                <br />

                <div class="list-group list-group-alternate">
                    <a href="#" class="list-group-item"><span class="badge1">></span>Thông tin đăng ký </a>
                    <a href="#" class="list-group-item"><span class="badge1">></span>Đăng ký TCTN</a>
                    <a href="#" class="list-group-item"><span class="badge1">></span>Đề nghị hưởng </a>
                    <a href="#" class="list-group-item"><span class="badge1">></span>Giấy biên nhận ĐK </a>
                    <a href="#" class="list-group-item"><span class="badge1">></span></i>Phiếu hẹn trả KQ </a>
                    <a href="#" class="list-group-item"><span class="badge1">></span>Phiếu tính hưởng </a>
                    <a href="#" class="list-group-item"><span class="badge1">></span>Tải quyết định </a>     
                </div>
            </div>
        </div>
    </div>
    <footer style="z-index:100;height: 43px !important; margin-bottom: 0px; margin-left: -30px; width: 100%; text-align: justify; background-color: #f0f0f0;padding-top:4px">
        <asp:Button ID="btnSave" runat="server" Text="Lưu thông tin" Style="width: 125px !important;" CssClass="btn btn-primary" OnClick="btnSave_Click" />
        <a href="#" class="btn btn-default">Thoát</a>
        <div class="warning">
            <asp:Label ID="lblMsg" runat="server" Text="" Font-Size="Larger" ForeColor="Red"/>
        </div>
    </footer>
</asp:Content>
