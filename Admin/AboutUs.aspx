<%@ Page Title="ĐƠN VỊ SỬ DỤNG" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="AboutUs.aspx.cs" Inherits="Admin_AboutUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="AdminHeaderItem">
        THÔNG TIN ĐƠN VỊ
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            Tên đơn vị:
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtName" runat="server" class="AdminTextControl"></asp:TextBox>
        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            Địa chỉ:
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtAddress" runat="server" class="AdminTextControl"></asp:TextBox>
        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            Điện thoại:
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtPhone" runat="server" class="AdminTextControl"></asp:TextBox>
        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            Địa chỉ Email:
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtEmail" runat="server" Text="" class="AdminTextControl"></asp:TextBox>
        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            Hotline:
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtHotline" runat="server" Text="" class="AdminTextControl"></asp:TextBox>
        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            Lời chào:
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtGreeting" runat="server" Text="" class="AdminTextControl"></asp:TextBox>
        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            Câu hướng dẫn:
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtGreeting1" runat="server" Text="" class="AdminTextControl"></asp:TextBox>
        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;
        </div>
        <div class="AdminRightItem">
            <asp:Label ID="lblMsg" runat="server" Text="" CssClass="AdminMsg"></asp:Label>
        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;
        </div>
        <div class="AdminRightItem">
            <asp:Button ID="btnSave" runat="server" Text="Ghi nhận" CssClass="btn btn-primary" OnClick="btnSave_Click" />
            <asp:Button ID="btnCancel" runat="server" Text="Bỏ qua" CssClass="btn btn-default" OnClick="btnCancel_Click" />
        </div>
    </div>

</asp:Content>

