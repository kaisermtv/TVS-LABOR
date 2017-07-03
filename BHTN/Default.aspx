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

     <div class="row">
        <div class = "DaoTao menuitem" style="background-color: #00a8ec;">
            <a href="DangKyHoSo.aspx">Đăng ký hồ sơ</a>
        </div>

        <div class = "Tuvan menuitem" style="background-color: #00a8ec;">
            <a href="Danhsachtinhhuong.aspx">Tính hưởng</a>
        </div>

        <div class = "ViecLamTrongNuoc menuitem" style="background-color: #00a8ec;">
            <a href="DanhSachThamDinh.aspx">Thẩm định</a>
        </div>
    
          <div class = "ViecLamTrongNuoc menuitem" style="background-color: #00a8ec;">
            <a href="Danhsachtrinhky.aspx">Trình ký - lấy số</a>
        </div>
        <div class = "ViecLamTrongNuoc menuitem" style="background-color: #00a8ec;">
          <a href="DanhSachTraKetQua.aspx">Trả kêt quả</a>
        </div>
    </div>
    

    <div class="row">
        <div class = "DaoTao menuitem" style="background-color: #00a8ec;">
            <a href="DaoTaoThatNghiep.aspx">Đào tạo</a>
        </div>  
         <div class = "ViecLamTrongNuoc menuitem" style="background-color: #00a8ec;">
            <a href="DanhSachHuyHuong.aspx">Hồ sơ đề xuất hủy hưởng</a>
        </div>     
          <div class = "ViecLamTrongNuoc menuitem" style="background-color: #00a8ec;">
        <a href="DanhSachThongBaoVL.aspx">Thông báo tìm kiếm việc làm</a>
        </div>         
    </div>
    <div class="row">
          <div class = "ViecLamTrongNuoc menuitem" style="background-color: #00a8ec;">
        <a href="DanhSachDeXuatTamDung.aspx">Hồ sơ đề xuất tạm dưng</a>
        </div>         
    </div>






</asp:Content>

