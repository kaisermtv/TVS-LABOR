<%@ Page Title="TÀI KHOẢN" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="EditAccount.aspx.cs" Inherits="Admin_EditAccount" %>
<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="AdminHeaderItem">
        THÔNG TIN TÀI KHOẢN
    </div>
    <div class="AdminItem">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;Tài khoản:
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtUserName" runat="server" class="AdminTextControl"></asp:TextBox>
        </div>
    </div>
    
    <div class="AdminItem">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;Họ tên:
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtFullName" runat="server" class="AdminTextControl"></asp:TextBox>
        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;Địa chỉ email:
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtEmail" runat="server" class="AdminTextControl"></asp:TextBox>
        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;Mật khẩu:
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtPassWord" runat="server" class="AdminTextControl"></asp:TextBox>
        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;Nhóm tài khoản:
        </div>
        <div class="AdminRightItem">
            <asp:DropDownList ID="ddlGroupId" runat="server" Style="width: 100%; height: 26px; line-height: 26px; margin-top: 3px;"></asp:DropDownList>
        </div>
    </div>

    <div class="AdminItem" style ="display:table;">
        <div class="AdminLeftItem" style ="display:table;">
            &nbsp;&nbsp;Vai trò quản lý:
        </div>
        <div class="AdminRightItem" style ="display:table;">
           <asp:DropDownList ID="ddlTypeId" runat="server" Style="width: 100%; height: 26px; line-height: 26px; margin-top: 3px;">
               <asp:ListItem Value ="0">Quản lý hệ thống</asp:ListItem>
               <asp:ListItem Value ="1">Quản lý công ty</asp:ListItem>
               <asp:ListItem Value ="2">Quản lý chi nhánh</asp:ListItem>
               <asp:ListItem Value ="3">Quản lý nhóm</asp:ListItem>
               <asp:ListItem Value ="4">Người dùng (AM)</asp:ListItem>
           </asp:DropDownList>
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
            <asp:Label ID="lblMsg" runat="server" Text="" ForeColor = "Red"></asp:Label>
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

