﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin.master" CodeFile="LoaiHinhDoanhNghiepEdit.aspx.cs" Inherits="Category_LoaiHinhDoanhNghiepEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="AdminHeaderItem">
        THÔNG TIN LOẠI HÌNH DOANH NGHIỆP
    </div>
    <div class="AdminItem">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;Mã số:
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtCodeLoaiHinh" runat="server" class="AdminTextControl"></asp:TextBox>
        </div>
    </div>
    <div class="AdminItem">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;Tên loại hình:
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtNameLoaiHinh" runat="server" class="AdminTextControl"></asp:TextBox>
        </div>
    </div>
     <div class="AdminItem">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;Ghi chú:
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtNote" runat="server" class="AdminTextControl"></asp:TextBox>
        </div>
    </div>

    <div style="width: 100%; height: 35px; line-height: 35px; margin-top: 10px;">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;Trạng thái: 
        </div>
        <div class="AdminRightItem">
            <asp:CheckBox ID="ckbState" Text="&nbsp;&nbsp;Kích hoạt" runat="server" Style="font-weight: normal;" />
        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;
        </div>
        <div class="AdminRightItem">
            <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;
        </div>
        <div class="AdminRightItem">
            <asp:Button ID="btnSave" runat="server" Text="Ghi nhận" CssClass="btn btn-primary" OnClick="btnSave_Click" />
            <asp:Button ID="btnCancel" runat="server" Text="Thoát" CssClass="btn btn-default" OnClick="btnCancel_Click" />
        </div>
    </div>
</asp:Content>

