<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/BHTN.master" CodeFile="Default.aspx.cs" Inherits="BHTN_Default" %>


<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="Server">
    <style>
        .menuitem{
            margin: 10px;
            text-align:center;
            float:left;
            width: 200px; 
            height: 100px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

    <div class = "DaoTao menuitem" style="background-color: #00a8ec;">
        <a href="DangKyHoSo.aspx">Đăng ký hồ sơ</a>
    </div>

    <div class = "Tuvan menuitem" style="background-color: #00a8ec;">
        <a href="DangKyHoSo.aspx">Tính hưởng</a>
    </div>

    <div class = "ViecLamTrongNuoc menuitem" style="background-color: #00a8ec;">
        <a href="DangKyHoSo.aspx">Thẩm định</a>
    </div>


</asp:Content>

