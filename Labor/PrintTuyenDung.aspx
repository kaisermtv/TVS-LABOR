<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintTuyenDung.aspx.cs" Inherits="Labor_PrintTuyenDung" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <style>
        body {
            background-color: #fff;
        }

        .KhungIn {
            width: 800px;
            height: 1200px !important;
            display: table;
            /*border:solid 5px #808080;*/
            padding: 5px;
            font-family: 'Times New Roman';
            font-size: 20px;
            text-align: justify;
        }

        .center{
            text-align:center;
        }

        h2{
            margin:0px;
            font-size: 22px;   
        }

        h3{
            margin:0px;
            font-size: 20px;   
        }

        h4{
            margin:0px;
            margin-top:10px;
            font-size: 20px;   
        }

        h1{
            margin:0px;
            font-size: 26px;
            max-width:70%
        }



        p{
            margin:0px;
            margin-top:5px;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server"  onkeypress="ESC_Press(event)">
        <center class="KhungIn">
            <center>
                <h2>SỞ LAO ĐỘNG - TB&XH NGHỆ AN</h2>
                <h2>TRUNG TÂM DỊCH VỤ VIỆC LÀM</h2>
                <br />
                <h3>Địa chỉ: Số 201, Đ.Phong Định Cảng, P.Trường Thi, TP.Vinh, Nghệ An</h3>
                <h3>Điện thoại: 0383 550 050 - Email: sanvieclamnghean@gmail.com</h3>
                <h3>Website: vieclamnghean.vn - vlngean.vieclamvietnam.gov.vn</h3>
                <br />
                <h1>TUYỂN DỤNG LÀM VIỆC TẠI CÔNG TY CP XÂY DỰNG NAM VIỆT ÚC</h1>
            </center>

            <h4>1. Lĩnh vực hoạt động:</h4> Sản xuất bột bả tường
            <h4>2. Vị trí - Điều kiện tuyển dụng:</h4>
            <p><b>- 04 Lao động phổ thông</b></p>
            <b>yêu cầu:</b>
            <p>- Nam, tuổi từ 18 - 40;</p>
            <p>- Sức khỏe tốt, chịu khó;</p>
            <p>- Tốt nghiệp THCS trở lên.</p>
            <h4>3. Quyền lợi:</h4>
            <p>+ Được tham gia đóng các loại BHXH, BHYT, BHTN theo quy định của nhà nước và luật lao động</p>
            <p>+ Lao động được bao ăn trưa</p>

            <b>- Tiền lương: 5,5 triệu đồng/tháng</b>

            <h4>4. Địa điểm làm việc:</h4>TP.Vinh, Nghệ An
            <b>Chi tiết liên hệ: Phòng thông tin TTLĐ - Trung tâm DVVL Nghệ An</b>
            <p>Điện thoại: <b>0383 550 050 - Email: sanvieclamnghean@gmail.com</b></p>
        </div>
    </form>
       <script src="../js/TvsProcessPage.js"></script>
</body>
</html>
