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
                        <b>TRUNG TÂM DỊCH VỤ VIỆC LÀM</b>
                    </td>
                    <td class="txtcenter" style="width:55%">
                        <b>CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM</b><br />
                        <b>Độc lập - Tự do - Hạnh phúc</b>
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
                    <td><b>Kính gửi:</b></td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <% Response.Write(this.DVTenDonVi.ToUpper()); %><br />
                        Địa chỉ: <% Response.Write(this.DVDiaChi); %><br />
                        Liên hệ: <% Response.Write(this.DVDienThoai); %>
                    </td>
                </tr>
            </table>

            <p>Căn cứ vào nhu cầu tìm kiếm việc làm của người lao động và nhu cầu tuyển dụng lao động của Quý đơn vị, Trung tâm dịch vụ việc làm Nghệ An giới thiệu:</p>
            <p>Ông/bà: <b><% Response.Write(this.NLDHoten); %></b></p>
            <p>Sinh ngày: <% Response.Write(this.NLDNgaySinh); %> Giới tính: <% Response.Write(this.NLDGioiTinh); %></p>
            <p>Số CMND: <% Response.Write(this.NLDCMND); %>; Ngày cấp: <% Response.Write(this.NLDNgayCapCMND); %>; Nơi cấp: <% Response.Write(this.NLNoiCap); %></p>
            <p>Số sổ BHXH: <% Response.Write(this.NLDBHXH); %>; Điện thoại: <% Response.Write(this.NLDDienThoai); %>; Email: <% Response.Write(this.NLDEmail); %></p>
            <p>Nơi thường trú: <% Response.Write(this.NLDNoiThuongTru); %></p>
            <p>Trình độ giáo dục phổ thông: <% Response.Write(this.NLDTrinhDoPhoThong); %>; Trình độ CMKT/Tay nghề: <% Response.Write(this.NLDTrinhDoPhoThong); %></p>
            <p>Công việc trước khi thất nghiệp: Lái xe; Kinh nghiệm làm việc: 3 năm</p>
            <p>Vị trí công việc dự tuyển: <% Response.Write(this.NLDViTriCongViec); %></p>
            <p>Phiếu có giá trị đến ngày: 23/03/2017</p>
            <p>Kính đề nghị Quý đơn vị phối hợp thông báo kết quả dự tuyển cho Trung tâm để tổng hợp theo dõi tình trạng việc làm của người lao động.</p>

            <div class="LoiCamOn"><b>Cảm ơn sự quan tâm phối hợp của Quý Công ty./.</b></div>

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
                    <b><u>Lưu ý:</u></b>
                </div>
                <b>
                <small style="margin-left:40px;">- Theo nghị định số 28/2015/NĐ-CP ngày 12/03/2015 của chính phủ quy định tại điểm đ - Khoản 1 - Điều 21 - Mục 3 - Chương IV "Sau 02 lần người lao động từ chối việc làm do trung tâm dịch vụ việc làm nơi đang hưởng trợ cấp thất nghiệp giới thiệu mà không có lý do chính đáng <u>thì sẽ bị chấm dứt hưởng trợ cấp thất nghiệp</u>".</small><br />
                <small style="margin-left:200px;">- Địa chỉ liên hệ: Phòng thông tin TTLĐ - Trung tâm dịch vụ việc làm Nghệ An</small><br />
                <small style="margin-left:200px;">- Điện thoại: 0383 550 050, 0974232829 (A.Tuấn)</small>
                </b>
            </div>
        </div>
    </form>
</body>
</html>
