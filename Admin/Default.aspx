<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Admin_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

    <table class="table" border="0" style="padding: 8px; width: 1000px;">
        <tr>
            <td rowspan="2" style="width: 350px; height: 100%;" class = "Background">
                <img src ="../images/Background.jpg" alt = "" style ="width:350px!important;"/>
            </td>
            <td>
                <div class = "Tuvan" style="width: 200px; height: 100px; background-color: #00a8ec;">
                    <a href="../Labor/TuVan.aspx">Hồ sơ tư vấn <%Response.Write(this.strCountHoSoTuVan); %></a>
                </div>
            </td>
            <td>
                <div class = "DaoTao" style="width: 200px; height: 100px; background-color: #f58d00;">
                    <a href="../Labor/DaoTaoNghe.aspx">Đào tạo nghề <%Response.Write(this.strCountDaoTaoNghe); %></a>
                </div>
            </td>
            <td>
                <div class = "ViecLamTrongNuoc" style="width: 200px; height: 100px; background-color: #ffce35;">
                    <a href="../labor/DangKyViecLam.aspx">Việc làm trong nước <%Response.Write(this.strCountViecLamTrongNuoc); %></a>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <div class ="ViecLam" style="width: 200px; height: 100px; background-color: #640f6c;">
                    <a href="../Labor/TuVanXuatKhau.aspx">Xuất khẩu lao động <%Response.Write(this.strCountXuatKhauLaoDong); %></a>
                </div>
            </td>
            <td colspan="2">
                <div class ="BaoHiemThatNghiep" style="width: 100%; height: 100px; background-color: #f874a4;">
                    <a href="#">Bảo hiểm thất nghiệp</a>
                </div>
            </td>
        </tr>
        <tr>
            <td style ="text-align:center;">
                <div class = "HomePage1">
                    TRANG CHỦ
                </div>
            </td>
            <td style ="width:200px;">
                 <div class ="ThongTinThiTruong" style="width: 200px; height: 100px; background-color: #d32c2c;">
                    <a href="../Labor/TuyenDung.aspx">Thông tin thị trường <%Response.Write(this.strCountTinTuyenDung); %></a> 
                </div>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <%--<div class="panel-footer" style="bottom:1px">
   <marquee><p style="font-family: Impact; font-size: 14pt">.</p></marquee>
    </div>--%>
</asp:Content>

