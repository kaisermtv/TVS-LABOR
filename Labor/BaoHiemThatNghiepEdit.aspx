<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin.master" CodeFile="BaoHiemThatNghiepEdit.aspx.cs" Inherits="Labor_BaoHiemThatNghiepEdit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="Server">
    <style>
        .label1{
            width:12%;
            float:left;
            text-align:right;
            font-size:15px;
            padding-right:5px;
            height:34px;    
            padding-top:8px;
        }

        .line{
            margin-top:10px;
        }

        .headlabel{
            margin-top:10px;
            font-size:16px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
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

        <div class="label1">
            Ngày sinh: 
        </div>
        <div style="width:20%;float:left">
            <asp:TextBox ID="txtNgaySinh" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="label1">
            Giới tính: 
        </div>
        <div style="width:20%;float:left">
            <asp:DropDownList ID="ddlGioiTinh" CssClass="form-control" runat="server" Style="width: 100%;">
                <asp:ListItem Value="0">Không chọn</asp:ListItem>
                <asp:ListItem Value="1">Nam</asp:ListItem>
                <asp:ListItem Value="2">Nữ</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <div class="row line">
        <div class="label1">
            Số CMND/HC: 
        </div>
        <div style="width:20%;float:left">
            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="label1">
            Ngày cấp: 
        </div>
        <div style="width:20%;float:left">
            <asp:TextBox ID="txtNgayCap" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="label1">
            Nơi cấp: 
        </div>
        <div style="width:20%;float:left">
            <asp:TextBox ID="txtNoiCap" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="row line">
        <div class="label1">
            Số điện thoại: 
        </div>
        <div style="width:20%;float:left">
            <asp:TextBox ID="txtSoDienThoai" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="label1">
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

        <div class="label1">
            Ngày cấp BHXH: 
        </div>
        <div style="width:20%;float:left">
            <asp:TextBox ID="txtNgayCapBHXH" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="label1">
            Nơi cấp BHXH: 
        </div>
        <div style="width:20%;float:left">
            <asp:TextBox ID="txtNoiCapBHXH" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="row line">
        <div class="label1">
            Nơi ĐK khám bệnh: 
        </div>
        <div style="width:84%;float:left">
            <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="row line">
        <div class="label1">
            Trình độ CMKT: 
        </div>
        <div style="width:20%;float:left">
            <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="label1">
            Lĩnh vực đào tạo: 
        </div>
        <div style="width:20%;float:left">
            <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="row line">
        <div class="label1">
            Công việc đã làm: 
        </div>
        <div style="width:20%;float:left">
            <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="label1">
            Địa chỉ doanh nghiệp: 
        </div>
        <div style="width:52%;float:left">
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

        <div class="label1">
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
            <asp:TextBox ID="TextBox10" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="label1">
            Số tháng đóng BHXH: 
        </div>
        <div style="width:20%;float:left">
            <asp:TextBox ID="TextBox11" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="label1">
            Ngày ĐK thất nghiệp: 
        </div>
        <div style="width:20%;float:left">
            <asp:TextBox ID="TextBox13" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>

    <div class="row line">
        <div class="label1">
            Nhu cầu: 
        </div>
        <div style="width:84%;float:left">
            <asp:TextBox ID="TextBox12" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="row line">
        <div class="label1">
            Đăng ký trễ: 
        </div>
        <div style="width:20%;float:left">
            <asp:TextBox ID="TextBox14" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="label1">
            Lý do đăng ký trễ: 
        </div>
        <div style="width:52%;float:left">
            <asp:TextBox ID="TextBox15" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
</asp:Content>
