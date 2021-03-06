﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="MucLuongEdit.aspx.cs" Inherits="Admin_MucLuongEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="AdminHeaderItem">
        THÔNG TIN VỀ MỨC LƯƠNG
    </div>
    <div class="AdminItem">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;Mã mức lương:
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtCodeMucluong" runat="server" class="AdminTextControl"></asp:TextBox>
        </div>
    </div>
    <div class="AdminItem">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;Tên mức lương:
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtNameMucluong" runat="server" class="AdminTextControl"></asp:TextBox>
        </div>
    </div>
     <div class="AdminItem">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;Mức lương 1:
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtMinValue" runat="server" class="AdminTextControl"></asp:TextBox>
        </div>
    </div>
     <div class="AdminItem">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;Mức lương 2
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtMaxValue" runat="server" class="AdminTextControl"></asp:TextBox>
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

