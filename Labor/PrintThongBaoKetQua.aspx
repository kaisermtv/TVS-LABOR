<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintThongBaoKetQua.aspx.cs" Inherits="Labor_PrintThongBaoKetQua" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>IN PHIẾU THÔNG BÁO KẾT QUẢ TƯ VẤN VIỆC LÀM</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel='stylesheet' type='text/css' />
    <!-- Custom CSS -->
    <link href="../css/ThongBaoKetQua.css" rel="stylesheet" />
</head>
<body style="margin: 0px !important; height: 500px !important;">
    <form id="form1" runat="server">
        <div class="KhungIn">
            <table>
                <tr>
                    <td class="txtcenter" style="width:45%">
                        <b><% Response.Write(this.DVTenDonVi.ToUpper()); %><br /></b>
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
                THÔNG BÁO KẾT QUẢ TUYỂN DỤNG LAO ĐỘNG
            </div>

            <div class="KinhGui">
                <b>Kính gửi:</b> Trung tâm Dịch vụ việc làm Nghệ An
            </div>

            <p>Đơn vị: <% Response.Write(this.DVTenDonVi.ToUpper()); %> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Thông báo:</p>
            <p>Ông/bà: <b><% Response.Write(this.NLDHoten); %></b>; Sinh ngày: <% Response.Write(this.NLDNgaySinh); %>; Giới tính: <% Response.Write(this.NLDGioiTinh); %></p>
            <p>Số CMND: <% Response.Write(this.NLDCMND); %>; Ngày cấp: <% Response.Write(this.NLDNgayCapCMND); %>; Nơi cấp: <% Response.Write(this.NLNoiCap); %></p>
            <p>Nơi thường trú: Long Thành, Yên Thành, Nghệ An</p>
            <p>Sau khi được trung tâm DVVL Nghệ An tư vấn các chế độ, chính sách về lao động việc làm, giới thiệu lao động đến liên hệ, dự tuyển vào vị trí: 
                <b><% Response.Write(this.NLDViTriCongViec); %></b></p>
            <p>Kết quả tuyển dụng cụ thể:</p>
            <br />
            <p><asp:CheckBox ID="ckbTrungTuyen" runat="server" /> Trúng tuyển</p>
            <p>Vị trí việc làm: <% Response.Write(this.NldKq_ViTriLamViec); %>...................................................................................................</p>
            <p>Ngày dự kiến nhận việc: <% Response.Write(this.NldKq_NgayDuKienNhanViec); %>....................................................................................</p>
            <p>Thời gian thử việc: <% Response.Write(this.NldKq_ThoiGianThuViec); %>.............................................................................................</p>
            <br />
            <p><asp:CheckBox ID="ckbKhongTrungTuyen" runat="server" /> Không trúng tuyển</p>
            <p>Lý do: <% Response.Write(this.NldKq_LyDoKhongTrungTuyen); %>........................................................................................................................</p>
            <p>....................................................................................................................................</p>

            <div class="LoiCamOn"><b>Cảm ơn sự quan tâm phối hợp của trung tâm dịch vụ và việc làm Nghệ An./.</b></div>

            <table>
                <tr>
                    <td></td>
                    <td class="txtcenter">
                        <b>ĐẠI DIỆN ĐƠN VỊ TUYỂN DỤNG</b><br />
                        ( Ký tên, đóng dấu )
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
