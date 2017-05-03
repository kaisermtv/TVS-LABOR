<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin.master" CodeFile="DtKhoaHocEdit.aspx.cs" Inherits="Category_DtKhoaHocEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="AdminHeaderItem">
        THÔNG TIN KHÓA HỌC
    </div>
    <div class="AdminItem">
        <div class="AdminLeftItem">
            Mã khóa học:
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtMaKhoaHoc" runat="server" class="AdminTextControl"></asp:TextBox>
        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            Tên khóa học:
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtNameKhoaHoc" runat="server" class="AdminTextControl"></asp:TextBox>
        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            Loại khóa học:
        </div>
        <div class="AdminRightItem">
            <asp:DropDownList ID="ddlLoaiKhoaHoc" runat="server" class="AdminTextControl"></asp:DropDownList>
        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            Mức hỗ trợ:
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtMucHoTro" type="number" runat="server" class="AdminTextControl"></asp:TextBox>
        </div>
    </div>

     <div class="AdminItem">
        <div class="AdminLeftItem">
            Thời gian học:
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtThoiGianHoc" runat="server" class="AdminTextControl"></asp:TextBox>
        </div>
    </div>

    <div style="width: 100%; height: 35px; line-height: 35px; margin-top: 10px;">
        <div class="AdminLeftItem">
            Trạng thái: 
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
            <a href="DtKhoaHocList.aspx" class="btn btn-default">Thoát</a>
        </div>
    </div>
</asp:Content>

