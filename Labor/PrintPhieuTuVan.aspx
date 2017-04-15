<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintPhieuTuVan.aspx.cs" Inherits="Labor_PrintPhieuTuVan" %>

<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>IN PHIẾU TƯ VẤN</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel='stylesheet' type='text/css' />
    <!-- Custom CSS -->
    <link href="../css/PrintPhieuTuVan.css" rel="stylesheet" />
</head>
<body style="margin: 0px !important; height: 500px !important;">
    <form id="form1" runat="server">

        <div class="KhungIn">

            <div class="TieuDe1">
                <b>Mẫu số 01:</b> Ban hành kèm theo Thông tư số 28/2015/TT-BLĐTBXH ngày 31 tháng 7 năm 2015 của Bộ Lao động Thương binh và Xã hội
            </div>
            
            <div class="HoNgu1">
                CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM
            </div>

            <div class="HoNgu2">
                Độc lập - Tự do - Hạnh phúc
            </div>

            <div class="TieuDePhieu">
                PHIẾU TƯ VẤN, GIỚI THIỆU VIỆC LÀM 
            </div>

            <div class="KinhGui">
                Kính gửi: <b>Trung tâm Dịch vụ việc làm Nghệ An</b>
            </div>

            <div class ="ChuBinhThuong">
                <table style="width: 100%;" border="0">
                    <tr>
                        <td class="HoVaTen">Họ và tên: <b><% Response.Write(this.NLDHoten); %></b>
                        </td>
                        <td class="HoVaTen" style="width: 198px;">Sinh ngày: <% Response.Write(this.NLDNgaySinh); %>
                        </td>
                    </tr>
                </table>
            </div>

            <div class="ChuBinhThuong">
                Số chứng minh nhân dân: <% Response.Write(this.NLDCMND); %>
            </div>

            <div class="ChuBinhThuong">
                <table style="width: 100%;" border="0">
                    <tr>
                        <td class="HoVaTen">Ngày cấp: <% Response.Write(this.NLDNgayCapCMND); %> 
                        </td>
                        <td class="HoVaTen" style="width: 450px;">Nơi cấp: <% Response.Write(this.NLNoiCap); %>
                        </td>
                    </tr>
                </table>
            </div>

            <div class="ChuBinhThuong">
                Số sổ BHXH: <% Response.Write(this.NLDBHXH); %>
            </div>

            <div class="ChuBinhThuong">
                <table style="width: 100%;" border="0">
                    <tr>
                        <td class="HoVaTen">Số điện thoại: <% Response.Write(this.NLDDienThoai); %>
                        </td>
                        <td class="HoVaTen" style="width: 450px;">Địa chỉ email (nếu có): <%Response.Write(this.NLDEmail); %>
                        </td>
                    </tr>
                </table>
            </div>

            <div class="ChuBinhThuong">
                <table style="width: 100%;" border="0">
                    <tr>
                        <td class="HoVaTen">Dân tộc: <%Response.Write(this.NLDDanToc); %>
                        </td>
                        <td class="HoVaTen" style="width: 450px;">Tôn giáo: <%Response.Write(this.NLDTonGiao); %>
                        </td>
                    </tr>
                </table>
            </div>

           <div class="ChuBinhThuong">
                Nơi thường trú: <%Response.Write(this.NLDNoiThuongTru); %>
            </div>

            <div class="ChuBinhThuong">
                Chỗ ở hiện nay (1): <%Response.Write(this.NLDDiaChi); %>
            </div>

            <div class="ChuBinhThuong">
                Tình trạng sức khỏe : <%Response.Write(this.NLDSucKhoe); %>
            </div>

            <div class="ChuBinhThuong">
                <table style="width: 100%;" border="0">
                    <tr>
                        <td class="HoVaTen">Chiều cao (cm): <%Response.Write(this.NLDChieuCao); %>  
                        </td>
                        <td class="HoVaTen" style="width: 450px;">Cân nặng(kg): <%Response.Write(this.NLDCanNang); %> 
                        </td>
                    </tr>
                </table>
            </div>

            <div class="ChuBinhThuong">
                Trình độ giáo dục phổ thông: <%Response.Write(this.NLDTrinhDoPhoThong); %>
            </div>

            <div class="ChuBinhThuong">
                <table style="width: 100%;" border="0">
                    <tr>
                        <td class="HoVaTen">Ngoại ngữ: <%Response.Write(this.NLDNgoaiNgu); %>
                        </td>
                        <td class="HoVaTen" style="width: 450px;">Trình độ: 
                        </td>
                    </tr>
                </table>
            </div>

            <div class="ChuBinhThuong">
                <table style="width: 100%;" border="0">
                    <tr>
                        <td class="HoVaTen">Tin học: <%Response.Write(this.NLDTinHoc); %>
                        </td>
                        <td class="HoVaTen" style="width: 450px;">Trình độ: 
                        </td>
                    </tr>
                </table>
            </div>

            <div class="ChuBinhThuong">
                Trình độ đào tạo: 
            </div>

            <div class="ChuBinhThuong">
                <table style="width: 100%;" border="1">
                    <tr style ="height:40px;">
                        <td class="ChuBinhThuong" style="width: 45px; text-align: center;">
                            <b>Số TT</b>
                        </td>
                        <td class="ChuBinhThuong" style="text-align: center;"><b>Chuyên ngành đào tạo</b>
                        </td>
                        <td class="ChuBinhThuong" style="width: 400px; text-align: center;"><b>Trình độ đào tạo (2)</b>
                        </td>
                    </tr>

                     <tr style ="height:60px;">
                        <td class="ChuBinhThuong" style="width: 45px; text-align: center;">
                            1
                        </td>
                        <td class="ChuBinhThuong" style ="padding-left:20px;">
                            <% Response.Write(this.NLDQuaTrinhDaoTao_CN1); %>
                        </td>
                        <td class="ChuBinhThuong" style="width: 400px; padding-left:20px;">
                            <% Response.Write(this.NLDQuaTrinhDaoTao_CM1); %>
                        </td>
                    </tr>

                    <tr style ="height:60px;">
                        <td class="ChuBinhThuong" style="width: 45px; text-align: center;">
                            2
                        </td>
                        <td class="ChuBinhThuong" style ="padding-left:20px;">
                            <% Response.Write(this.NLDQuaTrinhDaoTao_CN2); %>
                        </td>
                        <td class="ChuBinhThuong" style="width: 400px; padding-left:20px;">
                            <% Response.Write(this.NLDQuaTrinhDaoTao_CM2); %>
                        </td>
                    </tr>

                    <tr style ="height:60px;">
                        <td class="ChuBinhThuong" style="width: 45px; text-align: center;">
                            3
                        </td>
                       <td class="ChuBinhThuong" style ="padding-left:20px;">
                            <% Response.Write(this.NLDQuaTrinhDaoTao_CN3); %>
                        </td>
                        <td class="ChuBinhThuong" style="width: 400px; padding-left:20px;">
                            <% Response.Write(this.NLDQuaTrinhDaoTao_CM3); %>
                        </td>
                    </tr>

                </table>
            </div>

            <div class="ChuBinhThuong">
                Trình độ kỹ năng nghề <i>(nếu có)</i>: <% Response.Write(this.NLDTrinhDoKyNangNghe); %>
            </div>

            <div class="ChuBinhThuong">
                Khả năng nổi trội của bản thân
            </div>

            <div class="ChuBinhThuong">
                <% Response.Write(this.NLDKhaNangNoiTroi); %>
            </div>

            <div class="ChuBinhThuong">
                .......................................
            </div>

            <div class="ChuBinhThuong">
                .......................................
            </div>

            <div class="ChuBinhThuong">
                .......................................
            </div>
  
            <div class="ChiMuc">
                <b>I. THÔNG TIN VỀ  QUÁ TRÌNH LÀM VIỆC</b>
            </div>

            <div class="ChuBinhThuong">
                <table style="width: 100%;" border="1">
                   <tr style ="height:40px;">
                        <td class="ChuBinhThuong" style="width: 45px; text-align: center;">
                            <b>Số TT</b>
                        </td>
                        <td class="ChuBinhThuong" style="text-align: center;"><b>Tên đơn vị đã làm việc</b>
                        </td>
                        <td class="ChuBinhThuong" style="width: 300px; text-align: center;"><b>Thời gian làm việc</b><br />(Từ ngày…/…/….đến ngày. ../…/…)
                        </td>
                         <td class="ChuBinhThuong" style="text-align: center; width:250px;"><b>Vị trí công việc đã làm</b>
                        </td>
                    </tr>

                    <tr style ="height:60px;">
                        <td class="ChuBinhThuong" style="width: 45px; text-align: center;">
                            1
                        </td>
                        <td class="ChuBinhThuong" style ="padding-left:20px;">
                            <% Response.Write(this.NLDQuaTrinhCongTac_DV1); %>
                        </td>
                        <td class="ChuBinhThuong" style="width: 300px; text-align:center;">
                            <% Response.Write(this.NLDQuaTrinhCongTac_TG1); %>
                        </td>
                         <td class="ChuBinhThuong" style="width: 200px; padding-left:20px;">
                             <% Response.Write(this.NLDQuaTrinhCongTac_VT1); %>
                        </td>
                    </tr>

                    <tr style ="height:60px;">
                        <td class="ChuBinhThuong" style="width: 45px; text-align: center;">
                            2
                        </td>
                        <td class="ChuBinhThuong" style ="padding-left:20px;">
                            <% Response.Write(this.NLDQuaTrinhCongTac_DV2); %>
                        </td>
                        <td class="ChuBinhThuong" style="width: 300px; text-align:center;">
                            <% Response.Write(this.NLDQuaTrinhCongTac_TG2); %>
                        </td>
                         <td class="ChuBinhThuong" style="width: 200px; padding-left:20px;">
                             <% Response.Write(this.NLDQuaTrinhCongTac_VT2); %>
                        </td>
                    </tr>

                    <tr style ="height:60px;">
                        <td class="ChuBinhThuong" style="width: 45px; text-align: center;">
                            3
                        </td>
                        <td class="ChuBinhThuong" style ="padding-left:20px;">
                            <% Response.Write(this.NLDQuaTrinhCongTac_DV3); %>
                        </td>
                        <td class="ChuBinhThuong" style="wid    th: 300px; text-align:center;">
                            <% Response.Write(this.NLDQuaTrinhCongTac_TG3); %>
                        </td>
                         <td class="ChuBinhThuong" style="width: 200px; padding-left:20px;">
                             <% Response.Write(this.NLDQuaTrinhCongTac_VT3); %>
                        </td>
                    </tr>

                </table>
            </div>

             <div class="ChuBinhThuong">
                Mức lương (trước lần thất nghiệp gần nhất): <% Response.Write(this.NLDMucLuongTN); %>
            </div>

            <div class="ChuBinhThuong">
                Lý do thất nghiệp gần nhất: <% Response.Write(this.NLDLyDoTN); %>
            </div>

            <div class="ChiMuc">
                <b>II. TÌNH TRẠNG TÌM KIẾM VIỆC LÀM HIỆN NAY</b>
            </div>

            <div class="ChuBinhThuong">
                 Đã liên hệ tìm việc làm ở đơn vị nào (từ lần thất nghiệp gần nhất đến nay): <%Response.Write(this.NLDDNDaLienHe); %>
            </div>
 
            <div class="ChiMuc">
                <b>III. NHU CẦU TƯ VẤN, GIƠI THIỆU VIỆC LÀM</b>
            </div>

            <div class="ChiMuc1">
                 <b>1. Tư vấn</b>
            </div>

            <div class="ChuBinhThuong">
                <table class="table1">
                    <tr style ="height:30px;">
                        <td class="txtr">Chính sách, pháp luật về lao động việc làm </td>
                        <td>
                            <asp:CheckBox ID="ckbTuVanPhapLuat" runat="server" />
                        </td>
                        <td class="txtr pl20">Việc làm </td>
                        <td>
                            <asp:CheckBox ID="ckbTuVanViecLam" runat="server" />
                        </td>
                    </tr>
                     <tr style ="height:30px;">
                        <td class="txtr">Bảo hiểm thất nghiệp </td>
                         <td>
                            <asp:CheckBox ID="ckbTuVanBHTN" runat="server" />
                        </td>
                        <td class="txtr pl20">Khác </td>
                         <td>
                            <asp:CheckBox ID="ckbTuVanKhac" runat="server" />
                        </td>
                    </tr>
                </table>
            </div>

            <div class="ChiMuc1">
                 <b>2. Giới thiệu việc làm</b>
            </div>

            <div class="ChuBinhThuong">
                 Vị trí công việc: <%Response.Write(this.NLDViTriCongViec); %>
            </div>

            <div class="ChuBinhThuong">
                 Mức lương thấp nhất: <%Response.Write(this.NLDMucLuongThapNhat); %>
            </div>

            <div class="ChuBinhThuong">
                 Điều kiện làm việc: <%Response.Write(this.NLDDieuKienLamViec); %>
            </div>

            <div class="ChuBinhThuong">
                 Địa điểm làm việc: <%Response.Write(this.NLDDiaDiemLamViec); %>
            </div>

            <div class="ChuBinhThuong">
                 Khác: <%Response.Write(this.NLDNoiDungKhac); %>
            </div>

            <div class="ChuBinhThuong">
                 Loại hình đơn vị: Nhà nước <asp:CheckBox ID="CheckBox5" runat="server" />; Ngoài nhà nước <asp:CheckBox ID="CheckBox6" runat="server" />;Có vốn đầu tư nước ngoài <asp:CheckBox ID="CheckBox7" runat="server" />
            </div>
            <br />
            <div>
                <table style="width: 100%;" border="0">
                    <tr>
                        <td class="HoVaTen">
                            
                        </td>
                        <td class="HoVaTen" style="width: 250px;text-align:center;">
                            <i><% Response.Write(this.NLDNgayTuVan); %></i>
                        </td>
                    </tr>
                    <tr>
                        <td class="HoVaTen">
                            
                        </td>
                        <td class="HoVaTen" style="width: 250px;text-align:center;">
                            <b>Người đề nghị</b>
                        </td>
                    </tr>
                    <tr>
                        <td class="HoVaTen">
                            
                        </td>
                        <td class="HoVaTen" style="width: 250px;text-align:center;">
                            <i>(Ký, ghi rõ họ tên)</i>
                        </td>
                    </tr>
                </table>
            </div>
            <br /><br /><br />
            <div class="ChuBinhThuong">
                 <b>Ghi chú:</b>
            </div>

            <div class="ChuBinhThuong">
                 <i>(1) Ghi rõ số nhà, đường phố, tổ, thôn, xóm, làng, ấp, bản, buôn, phum, sóc.</i>
            </div>

            <div class="ChuBinhThuong">
                 <i>(2) Công nhân kỹ thuật không có chứng chỉ nghề, chứng chỉ nghề ngắn hạn dưới 03 tháng, sơ cấp từ 03 tháng đến dưới 12 tháng, trung cấp, cao đẳng, đại học trở lên.</i>
            </div>

        </div>

    </form>
</body>
</html>
