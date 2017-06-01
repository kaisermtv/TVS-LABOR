<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin.master" CodeFile="DanhMucDel.aspx.cs" Inherits="Category_DanhMucDel" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">XÓA MỤC <%=danhmuc.ToUpper() %></h3>
        </div>
        <br />
        <br />
        <div style="text-align: center; font-weight: bold;">
            Bạn có chắc chắn muốn xóa mục <%= objData["NameDanhMuc"] %> không?
                <br />
            &nbsp;
            <br />
            <br />
            <asp:Button CssClass="btn btn-danger" runat="server" Text="Đồng ý xóa" ID="btnSave" OnClick="btnSave_Click" />
            &nbsp;
            <a href="DanhMuc.aspx?id=<%=objData["DanhMucId"]  %>" class="btn btn-default">Bỏ qua</a>
            <br />
            <br />
            <br />
            <br />
        </div>
    </div>
</asp:Content>

