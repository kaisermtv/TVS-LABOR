<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="KetQuaHoSoDel.aspx.cs" Inherits="Admin_KetQuaHoSoDel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">XÓA KẾT QUẢ HỒ SƠ</h3>
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
            <asp:Button CssClass="btn btn-primary" runat="server" Text="Bỏ qua" ID="btnCancel" OnClick="btnCancel_Click" />
            <br />
            <br />
            <br />
            <br />
        </div>
    </div>
</asp:Content>

