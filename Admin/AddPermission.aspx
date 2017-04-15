<%@ Page Title="CẬP NHẬT QUYỀN" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="AddPermission.aspx.cs" Inherits="Admin_AddPermission" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="AdminHeaderItem">
        CẬP NHẬT QUYỀN CỦA NHÓM
    </div>
    <div class="AdminItem">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;Tên nhóm:
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtName" runat="server" ReadOnly="true" class="AdminTextControl"></asp:TextBox>
        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;Chức năng:
        </div>
        <div class="AdminRightItem">
            <asp:DropDownList ID="ddlFunctionId" runat="server" Style="width: 100%; height: 26px; line-height: 26px; margin-top: 3px;"></asp:DropDownList>
        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;Quyền hạn:
        </div>
        <div class="AdminRightItem">
            <asp:CheckBox ID="ckbView" Text ="&nbsp;&nbsp;Xem" runat="server" />&nbsp;&nbsp;
            <asp:CheckBox ID="ckbAdd" Text ="&nbsp;&nbsp;Thêm" runat="server" />&nbsp;&nbsp;
            <asp:CheckBox ID="ckbEdit" Text ="&nbsp;&nbsp;Sửa" runat="server" />&nbsp;&nbsp;
            <asp:CheckBox ID="ckbDel" Text ="&nbsp;&nbsp;Xóa" runat="server" />&nbsp;&nbsp;
            <asp:CheckBox ID="ckbOther" Text ="&nbsp;&nbsp;Khác" runat="server" />
        </div>
    </div>

    <div style="width: 100%; height: 35px; line-height: 35px; margin-top: 10px;">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;
        </div>
        <div class="AdminRightItem">
            <asp:Label ID="lblMsg" runat="server" Text="" ForeColor = "Red"></asp:Label>
        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;
        </div>
        <div class="AdminRightItem">
            <asp:Button ID="btnSave" runat="server" Text="Ghi nhận" CssClass="btn btn-primary" OnClick="btnSave_Click"/>
            &nbsp;
            <a href = "EditGroupAccount.aspx?id=<%Response.Write(this.GroupId.ToString()); %>"><input type ="button" class ="btn btn-default" value ="Bỏ qua" /></a>
        </div>
    </div>

</asp:Content>

