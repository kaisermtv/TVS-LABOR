<%@ Page Title="THÔNG BÁO" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="NoPermission.aspx.cs" Inherits="Admin_NoPermission" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">THÔNG BÁO</h3>
        </div>
        <br />
        <br />
        <div style="text-align: center; font-weight: bold; color:red;">
            Bạn không có quyền thực hiện chức năng này?
                <br />
            &nbsp;
            <br />
            <br />
            <asp:Button CssClass="btn btn-default" runat="server" Text="Tiếp tục" ID="btnCancel" OnClick="btnCancel_Click" />
            <br />
            <br />
            <br />
            <br />
        </div>
    </div>
</asp:Content>

