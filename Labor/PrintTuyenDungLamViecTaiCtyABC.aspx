<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintTuyenDungLamViecTaiCtyABC.aspx.cs" Inherits="Labor_PrintTuyenDungLamViecTaiCtyABC" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TUYỂN DỤNG LÀM VIỆC TẠI CÔNG TY </title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel='stylesheet' type='text/css' />
    <!-- Custom CSS -->
    <link href="../css/PrintPhieuTuVan.css" rel="stylesheet" />
</head>
<body>
    <form style="margin: 0px !important;" runat="server">
        <div class="KhungIn">
            <div class="TieuDe1">
                <!---Phần tiêu đề của phiếu-->
            </div>
            <div class="HoNgu1">
                SỞ LAO ĐỘNG -TB&XH NGHỆ AN
            </div>
            <div class="HoNgu2">
                <b style="border-bottom: 1px solid; font-size: 22px">TRUNG TÂM DỊCH VỤ VIỆC LÀM</b>
            </div>

            <div>
                <div style="float: left; width: 100px">
                    <img src="../Images/ttdichvuvieclamna.jpg" style="width: 100%" />
                </div>
                <div style="float: right; width: 100%; margin-left: -156px; text-align: center">
                    Địa chỉ: Số 201, Đ Phong Định Cảng , P.Trường Thi,Tp. Vinh, Nghệ An<br />
                    <img src="../Images/phone.jpg" height="30" />Điện thoại : 02383 550 050 - Email: <i style="border-bottom: solid 1px black">sanvieclamnghean@gmail.com </i>
                    <br />
                    Website : <i>vieclamnghean.vn- vlnghean.vieclamvietnam.gov.vn </i>
                </div>
            </div>

            <div class="clearfix"></div>

            <!---Phần nội dung của phiếu --->
            <div class="TieuDePhieu" style="font-size: 22px; width: 60%; margin-left: 20%; vertical-align: central">
                TUYỂN DỤNG LÀM VIỆC TẠI <%= nameDoanhNghiep %>
            </div>
            <br />

            <div class="ChuBinhThuong">
                <b>1.</b>  <b style="border-bottom: solid 1px;">Lĩnh vực hoạt động</b><b>:</b> <%=nameNganhNghe %>
            </div>

            <div class="ChuBinhThuong">
                <b>2.</b>  <b style="border-bottom: solid 1px;">Vị trí - Điều kiện tuyển dụng</b><b>:</b>
                <br />
                <b style="font-size: 17px">- <%= objData["SoLuongTuyenDung"].ToString() + " " + nameViTri %>
                </b>
                <br />
                <b style="font-size: 16px">Yêu cầu :</b>
                <div style="margin-left: 10%">
                    <%= objData["MoTa"].ToString() %>
                </div>
            </div>

            <div class="ChuBinhThuong">
                <b>3.</b>  <b style="border-bottom: solid 1px;">Quyền lợi </b><b>:</b>
                <div style="margin-left: 10%">
                    <p>
                        <%= objData["QuyenLoi"].ToString() %>
                    </p>
                    <p>
                        <b>- <%= nameMucLuong %> / tháng</b>
                    </p>
                </div>
            </div>
            <div class="ChuBinhThuong">
                <b>4.</b>  <b style="border-bottom: solid 1px;">Địa điểm làm việc </b><b>:</b> <%= objData["DiaDiem"] %>
            </div>
            <!--- dòng lưu ý cuối--->
            <div class="ChuBinhThuong">
                <b>&nbsp;</b>  <b style="border-bottom: solid 1px;">Chi tiết liên hệ</b><b>:</b> Phòng Thông tin TTLĐ — Trung tâm DVVL Nghệ An
              <div style="margin-left: 30px">Điện thoại : 02383 550 050 — Email : <span style="border-bottom: solid 1px;">sanvieclamnghean@gmail.com</span> </div>
            </div>
        </div>
    </form>
</body>
</html>

<%--objData["IDMucLuong"].ToString().Replace("1","Hành chính").Replace("2","Bán thời gian").Replace("3","Theo ca").Replace("4","Toàn thời gian").Replace("5","Thỏa thuận")--%>
