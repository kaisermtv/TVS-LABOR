<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ThongBaoKetQua.aspx.cs" Inherits="Labor_ThongBaoKetQua" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>IN PHIẾU GIỚI THIỆU VIỆC LÀM</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel='stylesheet' type='text/css' />
    <!-- Custom CSS -->
    <link href="../css/MauBieu2.css" rel="stylesheet" />
</head>
<body style="margin: 0px !important; height: 500px !important;">
    <form id="form1" runat="server">
        <div class="KhungIn">
            <table>
                <tr>
                    <td class="txtcenter" style="width:45%">
                        <b>CÔNG TY SƠN HƯNG</b>
                    </td>
                    <td class="txtcenter" style="width:55%">
                        <b>CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM</b><br />
                        <b>Độc lập - Tự do - Hạnh phúc</b>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td class="txtcenter">Nghệ An, <i>ngày 20 tháng 03 năm 2017</i></td>
                </tr>
            </table>

            <div class="TieuDePhieu">
                THÔNG BÁO KẾT QUẢ TUYỂN DỤNG LAO ĐỘNG
            </div>

            <div class="KinhGui">
                <b>Kính gửi:</b> Trung tâm Dịch vụ việc làm Nghệ An
            </div>

            <p>Đơn vị: CÔNG TY SƠN HƯNG &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Thông báo:</p>
            <p>Ông/bà: <b>Nguyễn Văn Thiết</b>; Sinh ngày: 22/01/1988; Giới tính: Nam</p>
            <p>Số CMND: 186642805; Ngày cấp: 26/10/2011; Nơi cấp: CA Nghệ An</p>
            <p>Nơi thường trú: Long Thành, Yên Thành, Nghệ An</p>
            <p>Sau khi được trung tâm DVVL Nghệ An tư vấn các chế độ, chính sách về lao động việc làm, giới thiệu lao động đến liên hệ, dự tuyển vào vị trí: <b>NV Lái xe</b></p>
            <p>Kết quả tuyển dụng cụ thể:</p>
            <br />
            <p><asp:CheckBox ID="ckbTrungTuyen" runat="server" /> Trúng tuyển</p>
            <p>Vị trí việc làm: ..........................................................................................................</p>
            <p>Ngày dự kiến nhận việc: ...........................................................................................</p>
            <p>Thời gian thử việc: ....................................................................................................</p>
            <br />
            <p><asp:CheckBox ID="ckbKhongTrungTuyen" runat="server" /> Không trúng tuyển</p>
            <p>Lý do: ........................................................................................................................</p>
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
