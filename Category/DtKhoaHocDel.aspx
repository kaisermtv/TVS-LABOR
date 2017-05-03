<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin.master" CodeFile="DtKhoaHocDel.aspx.cs" Inherits="Category_DtKhoaHocDel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">XÓA KHÓA HỌC</h3>
        </div>
        <br />
        <br />
        <div style="text-align: center; font-weight: bold;">
            Bạn có chắc chắn muốn xóa mục được chọn không?
                <br />
            &nbsp;
            <br />
            <br />
            <asp:Button CssClass="btn btn-danger" runat="server" Text="Đồng ý xóa" ID="btnSave" OnClick="btnSave_Click" />
            &nbsp;
            <a href="DtKhoaHocList.aspx" class="btn btn-default">Bỏ qua</a>
            <br />
            <br />
            <br />
            <br />
        </div>
    </div>
</asp:Content>

