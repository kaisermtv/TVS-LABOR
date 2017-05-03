<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintBanDangKyTuVanTimViecLam.aspx.cs" Inherits="Labor_PrintPhieuTuVan" %>

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
               <%-- <b>Mẫu số 01:</b> Ban hành kèm theo Thông tư số 28/2015/TT-BLĐTBXH ngày 31 tháng 7 năm 2015 của Bộ Lao động Thương binh và Xã hội--%>
            </div>
            <div class="HoNgu1">
                CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM
            </div>
            <div class="HoNgu2" >
                <b style="border-bottom:1px solid">Độc lập - Tự do - Hạnh phúc</b>
            </div>
            <br />
            <div class="HoNgu1" style="">
                <small style="float:right ;border:solid 1px black; margin-right:-20px; padding:7.5px;">Mã số (TTDVVL) : 27 | Mã số (TVL) : TD17- ..................</small>
            </div>
            <br />
            <div class="TieuDePhieu">
             BẢN ĐĂNG KÝ TƯ VẤN TÌM VIỆC LÀM
              <br />
                <i style="font-size:20px">(Dành cho người lao động)</i>
            </div>

            <br />
            <div class ="ChuBinhThuong">
                <table style="width: 100%;" border="0">
                    <tr>
                        <td class="HoVaTen " style="width:80%"> 1. Họ và tên: <b><% Response.Write(this.NLDHoten); %></b>
                        </td>
                            <td class="txtr">Giới tính: </td>
                         <td>
                            <%= NLDGioiTinh %>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="ChuBinhThuong">
                2. Ngày  , tháng , năm sinh: <% Response.Write(this.NLDNgaySinh); %>
             </div>

                
            <div class="ChuBinhThuong">
                <table style="width: 100%;" border="0">
                    <tr>
                        <td class="HoVaTen">3 .Dân tộc: <%Response.Write(this.NLDDanToc); %>
                        </td>
                        <td class="HoVaTen" style="width: 450px;">Tôn giáo: <%Response.Write(this.NLDTonGiao); %>
                        </td>
                    </tr>
                </table>
            </div>


            <div class="ChuBinhThuong">
               4. Số chứng minh nhân dân / Hộ chiếu : <% Response.Write(this.NLDCMND); %>
            </div>

            <div class="ChuBinhThuong">

                <table style="width: 100%;" border="0">
                    <tr><td> &nbsp;&nbsp; </td>
                        <td class="HoVaTen"> Ngày cấp: <% Response.Write(this.NLDNgayCapCMND); %> 
                        </td>
                        <td class="HoVaTen" style="width: 450px;">Nơi cấp: <% Response.Write(this.NLNoiCap); %>
                        </td>
                    </tr>
                </table>
            </div>
              <div class ="ChuBinhThuong">
                <table style="width: 100%;" border="0">
                    <tr>
                        <td class="HoVaTen " style="width:30%">5. Tình trạng hôn nhân :
                        </td>
                            <td>Độc thân </td>
                         <td style="float:left; align-items:center ">
                            <asp:CheckBox ID="CheckBox3" runat="server" />
                             &nbsp;&nbsp;&nbsp;&nbsp; 
                        </td>
                        <td  style="margin-left:20px">Kết hôn</td>
                         <td>
                            <asp:CheckBox ID="CheckBox4" runat="server" />
                        </td>
                        <td class="HoVaTen " style="width:40%">
                        </td>
                    </tr>
                </table>
            </div>

        <div class="ChuBinhThuong">
               6. Nơi đăng ký hộ khẩu thường trú : <%Response.Write(this.NLDNoiThuongTru); %>
            </div>
            <div class="ChuBinhThuong">
             7. Địa chỉ liên hệ : <%Response.Write(this.NLDDiaChi); %>
            </div>


             <div class="ChuBinhThuong">
                <table style="width: 100%;" border="0">
                    <tr>
                        <td class="HoVaTen">8. Điện thoại liên lạc : <% Response.Write(this.NLDDienThoai); %>
                        </td>
                    </tr>
                    <tr>
                        <td class="HoVaTen"> Email : <% Response.Write(this.NLDEmail); %>
                        </td>
                    </tr>
                </table>
            </div>
        
          <%--  <div class="ChuBinhThuong">
                Tình trạng sức khỏe : <%Response.Write(this.NLDSucKhoe); %>
            </div>--%>
          <%--  <div class="ChuBinhThuong">
                <table style="width: 100%;" border="0">
                    <tr>
                        <td class="HoVaTen">Chiều cao (cm): <%Response.Write(this.NLDChieuCao); %>  
                        </td>
                        <td class="HoVaTen" style="width: 450px;">Cân nặng(kg): <%Response.Write(this.NLDCanNang); %> 
                        </td>
                    </tr>
                </table>
            </div>--%>
              <div class ="ChuBinhThuong">
                 9. Thuộc đối tượng ưu tiên ( nếu có ) :

              </div>
            
              <div class ="ChuBinhThuong">
                <table style="width: 100%;" border="0">
                    <tr>
                        <td> &nbsp;</td>
                         <td style="width:10px">
                            <asp:CheckBox ID="CheckBox8" runat="server" />
                        </td>
                         <td class="txtr" style="width:160px">Người khuyết tật </td>
                         <td> &nbsp;&nbsp; </td>
                      
                           <td style="width:10px">
                            <asp:CheckBox ID="CheckBox9" runat="server" />
                        </td>
                         <td class="txtr pl20" style="width:220px">Người dân tộc thiễu số </td>
                          <td> &nbsp;</td>
                          <td style="width:10px">
                            <asp:CheckBox ID="CheckBox10" runat="server" />
                        </td>
                         <td class="txtr pl20" style="width:20px" >Khác</td>
                    </tr>
                </table>
            </div>

            <div class="ChuBinhThuong">
                10. Trình độ kỹ thuật cao nhất : <%Response.Write(this.NLDKhaNangNoiTroi); %>
            </div>
            <div class="ChuBinhThuong">
               11. Bậc trình độ kỹ năng nghề  <i>(nếu có)</i> : <%Response.Write(this.NLDTrinhDoKyNangNghe); %>
            </div>
            <div class="ChuBinhThuong">
                <table style="width: 100%;" border="0">
                    <tr>
                        <td class="HoVaTen"> 12. Ngoại ngữ: <%Response.Write(this.NLDNgoaiNgu); %>
                        </td>
                        <td class="HoVaTen" style="width: 450px;">Trình độ: <%= trinhDongoaiNgu %>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="ChuBinhThuong">
                <table style="width: 100%;" border="0">
                    <tr>
                        <td class="HoVaTen">Tin học: <%Response.Write(this.NLDTinHoc); %>
                        </td>
                        <td class="HoVaTen" style="width: 450px;">13. Trình độ: <%= trinhDoTinHoc %>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="ChuBinhThuong">
               14. Các chứng chỉ khác nếu có : <%Response.Write(this.NLDNoiDungKhac); %>
            </div>

             <div class="ChuBinhThuong">
               15. Khả năng, sở trường :  <% Response.Write(this.NLDKhaNangNoiTroi); %>
            </div>
             <div class="ChuBinhThuong">
              <i> ..................................................... ............................................................... </i> 
            </div>
             <div class="ChuBinhThuong">
                ........................................................ .............................................................
            </div>
             <div class="ChuBinhThuong">
                ........................................................ .............................................................
            </div>
             <div class="ChuBinhThuong">
                ....................................................... ..............................................................
            </div>
             <div class="ChuBinhThuong">
                ....................................................... ..............................................................
            </div>
            
             <div class="ChuBinhThuong">
                <b>16. Quá trình làm việc :</b>
            </div>

            <div class="ChuBinhThuong">
                <table style="width: 100%;" border="1">
                   <tr style ="height:40px;">
                        <td class="ChuBinhThuong" style="width: 45px; text-align: center;">
                            <b>Số TT</b>
                        </td>
                        <td class="ChuBinhThuong" style="text-align: center;width: 350px;"><b>Tên đơn vị đã làm việc</b>
                        </td>
                        <td class="ChuBinhThuong" style="width: 200px; text-align: center;"><b>Thời gian làm việc</b><br />(Từ tháng năm - đến tháng năm)
                        </td>
                         <td class="ChuBinhThuong" style="text-align: center; width:250px;"><b>Vị trí việc làm</b>
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

              
              <div class ="ChuBinhThuong">
                  17. Nội dung cần tư vấn
                <table style="width: 100%;" border="0">
                    <tr>
                        <td> &nbsp;&nbsp;&nbsp;</td>
                         <td style="width:10px">
                            <asp:CheckBox ID="CheckBox11" runat="server" />
                        </td>
                         <td style="width:100px"> &nbsp; Việc làm </td>

                        <td style="width:100px"></td>
                         <td style="width:10px">
                            <asp:CheckBox ID="CheckBox12" runat="server" />
                        </td>
                         <td style="width:110px"> &nbsp; Học nghề</td>
                          <td style="width:100px"></td>
                         <td>
                            <asp:CheckBox ID="CheckBox13" runat="server" />
                        </td>
                         <td class="">&nbsp; Chính sách , pháp luật lao động </td>
                    </tr>
                </table>
            </div>

            <div class="ChuBinhThuong">
                 Đã liên hệ tìm việc làm ở đơn vị nào (từ lần thất nghiệp gần nhất đến nay): <%Response.Write(this.NLDDNDaLienHe); %>
                 <div class="ChuBinhThuong">
                ....................................................... ..............................................................
            </div>
            </div>
 
         
            <div class="ChiMuc1">
                 <b>18. Công việc / vị trí việc làm đăng ký</b>
            </div>


                <div class="ChuBinhThuong">
                <table style="width: 100%;" border="1">
                   <tr style ="height:40px;">
                        <td class="ChuBinhThuong" style="width: 45px; text-align: center;">
                            <b>Số TT</b>
                        </td>
                        <td class="ChuBinhThuong" style="text-align: center;width: 350px;"><b>.\.</b>
                        </td>
                        <td class="ChuBinhThuong" style="width: 200px; text-align: center;"><b>Vị trí số 1</b>
                        </td>
                         <td class="ChuBinhThuong" style="text-align: center; width:250px;"><b>Vị trí số 2</b>
                        </td>
                    </tr>

                    <tr style ="height:60px;">
                        <td class="ChuBinhThuong" style="width: 45px; text-align: center;">
                            1
                        </td>
                        <td class="ChuBinhThuong" style ="padding-left:20px;">
                           Tên công việc/Vị trí việc làm
                        </td>
                        <td class="ChuBinhThuong" style="width: 300px; text-align:center;">
                           <%Response.Write(this.NLDViTriCongViec); %>
                        </td>
                         <td class="ChuBinhThuong" style="width: 300px; padding-left:20px;">
                            <%Response.Write(this.NLDViTriCongViec2); %>
                        </td>
                    </tr>

                    <tr style ="height:60px;">
                        <td class="ChuBinhThuong" style="width: 45px; text-align: center;">
                            2
                        </td>
                        <td class="ChuBinhThuong" style ="padding-left:20px;">
                           Địa điểm
                        </td>
                        <td class="ChuBinhThuong" style="width: 300px; text-align:center;">
                           <%Response.Write(this.NLDDiaDiemLamViec); %>
                        </td>
                         <td class="ChuBinhThuong" style="width: 200px; padding-left:20px;">
                           <%Response.Write(this.NLDDiaDiemLamViec2); %>
                        </td>
                    </tr>

                    <tr style ="height:60px;">
                        <td class="ChuBinhThuong" style="width: 45px; text-align: center;">
                            3
                        </td>
                        <td class="ChuBinhThuong" style ="padding-left:20px;">
                    Mức lương
                        </td>
                        <td class="ChuBinhThuong" style="wid    th: 300px; text-align:center;">
                           <%Response.Write(this.NLDMucLuongThapNhat); %>
                        </td>
                         <td class="ChuBinhThuong" style="width: 200px; padding-left:20px;">
                            <%Response.Write(this.NLDMucLuongThapNhat2); %>
                        </td>
                    </tr>
                    <tr style ="height:60px;">
                        <td class="ChuBinhThuong" style="width: 45px; text-align: center;">
                            3
                        </td>
                        <td class="ChuBinhThuong" style ="padding-left:20px;">
                   Yêu cầu khác
                        </td>
                        <td class="ChuBinhThuong" style="width: 300px; text-align:center;">
                           <%Response.Write(this.NLDNoiDungKhac); %>
                        </td>
                         <td class="ChuBinhThuong" style="width: 200px; padding-left:20px;">
                           <%Response.Write(this.NLDNoiDungKhac2); %>
                        </td>
                    </tr>

                </table>
            </div>
                


           
            
            <br />
            <div>
                <table style="width: 100%;" border="0">
                    <tr>
                        <td class="HoVaTen" style="width:50%">
                            
                        </td>
                        <td class="HoVaTen" style="width: 250px;text-align:center;">
                            <i><% Response.Write(this.NLDNgayTuVan); %></i>
                        </td>
                    </tr>
                    <tr>
                        <td class="HoVaTen">
                            
                        </td>
                        <td class="HoVaTen" style="width: 250px;text-align:center;">
                            <b>Người đăng ký</b>
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
          

        </div>

    </form>
</body>
</html>
