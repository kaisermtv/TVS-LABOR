<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin.master" CodeFile="DoanhNghiepDel.aspx.cs" Inherits="Labor_DoanhNghiepDel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="panel panel-default">
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
            <a href="DoanhNghiep.aspx" class="btn btn-default">Bỏ qua</a>
            <br />
            <br />
            <br />
            <br />
        </div>
    </div>
</asp:Content>

