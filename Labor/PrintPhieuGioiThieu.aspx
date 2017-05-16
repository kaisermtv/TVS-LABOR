<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintPhieuGioiThieu.aspx.cs" Inherits="Labor_PrintPhieuGioiThieu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>IN PHIẾU GIỚI THIỆU VIỆC LÀM</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel='stylesheet' type='text/css' />
    <!-- Custom CSS -->
    <link href="../css/PhieuGioiThieu.css" rel="stylesheet" />
</head>
<body style="margin: 0px !important; height: 500px !important;">
    <form id="form1" runat="server">
        <div class="KhungIn">
            <table>
                <tr>
                    <td class="txtcenter" style="width:45%">
                        SỞ LAO ĐỘNG - TBXH NGHỆ AN<br />
                        <b>TRUN<b style="border-bottom:1px solid">G TÂM DỊCH VỤ VIỆ</b>C LÀM</b>
                    </td>
                    <td class="txtcenter" style="width:55%">
                        <b>CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM</b><br />
                        <b style="border-bottom:1px solid">Độc lập - Tự do - Hạnh phúc</b>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td class="txtcenter"><i><% Response.Write(this.DVNgayGioiThieu); %></i></td>
                </tr>
            </table>

            <div class="TieuDePhieu">
                PHIẾU GIỚI THIỆU VIỆC LÀM 
            </div>

            <table class="KinhGui">
                <tr>
                    <td style="width:15%"><b>Kính gửi:</b></td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <% Response.Write(this.DVTenDonVi.ToUpper()); %><br />
                        Địa chỉ: <% Response.Write(this.DVDiaChi); %><br />
                        Liên hệ: <%= DVDienThoai %>
                    </td>
                </tr>
            </table>

            <p>Căn cứ vào nhu cầu tìm kiếm việc làm của người lao động và nhu cầu tuyển dụng lao động của Quý đơn vị, Trung tâm dịch vụ việc làm Nghệ An giới thiệu:</p>
            <p>Ông/bà: <b><% Response.Write(this.NLDHoten); %></b></p>
            <p>Sinh ngày: <% Response.Write(this.NLDNgaySinh); %> Giới tính: <% Response.Write(this.NLDGioiTinh); %></p>
            <p>Số CMND: <% Response.Write(this.NLDCMND); %>; Ngày cấp: <% Response.Write(this.NLDNgayCapCMND); %>; Nơi cấp: <% Response.Write(this.NLNoiCap); %></p>
            <p>Số sổ BHXH: <% Response.Write(this.NLDBHXH); %>; Điện thoại: <% Response.Write(this.NLDDienThoai); %>; Email: <% Response.Write(this.NLDEmail); %></p>
            <p>Nơi thường trú: <% Response.Write(this.NLDNoiThuongTru); %></p>
            <p>Trình độ giáo dục phổ thông: <% Response.Write(this.NLDTrinhDoPhoThong); %> ; Trình độ CMKT/Tay nghề: <% Response.Write(this.NLDTrinhDoTayNghe); %></p>
            <p>Công việc trước khi thất nghiệp: <% Response.Write(this.CongViecTruocThatNghiep); %></p> 
            <p>Vị trí công việc dự tuyển: <% Response.Write(this.NLDViTriCongViec); %></p>
            <p>Phiếu có giá trị đến : <i><%= DVNgayHetHan %></i> </p>
            <p>Kính đề nghị Quý đơn vị phối hợp thông báo kết quả dự tuyển cho Trung tâm để tổng hợp theo dõi tình trạng việc làm của người lao động./.</p>

            <div class="LoiCamOn">Cảm ơn sự quan tâm phối hợp của Quý Công ty!</div>

            <table>
                <tr>
                    <td class="txtcenter">
                        <b>NGƯỜI LAO ĐỘNG</b>
                    </td>
                    <td class="txtcenter">
                        <b>CÁN BỘ TƯ VẤN - GTVL</b>
                    </td>
                </tr>
                <tr>
                    <td class="txtcenter">
                        <small>(Ký ghi rõ họ tên)</small>
                    </td>
                    <td class="txtcenter">
                        <small>(Ký ghi rõ họ tên)</small>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td class="txtcenter">
                        <br /><br /><br /><br />
                        <b></b>
                    </td>
                </tr>
            </table>

            <div class="LuuYNhom">
                <div class="LuuY">
                    <b><u>Ghi chú</u></b>
                </div>
                <b>
              
                      <small style="margin-left:40px; "><i> Cơ hội tìm kiếm việc làm miễn phí tại Sàn giao dịch việc làm Nghệ An được tổ chức vào ngày 10 và 25 hàng tháng .</i></small><br />
                    <small style="margin-left:40px;">- Địa chỉ liên hệ: Phòng thông tin TTLĐ - Trung tâm dịch vụ việc làm Nghệ An .</small><br />
                <small style="margin-left:40px;">- Điện thoại: 02383 550 050 , 0974232829 (A.Tuấn), 0972 975 999 (A.Ngọc) .</small>
                </b>
            </div>
        </div>
    </form>
</body>
</html>
