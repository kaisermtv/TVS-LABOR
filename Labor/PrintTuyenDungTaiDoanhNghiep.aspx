<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintTuyenDungTaiDoanhNghiep.aspx.cs" Inherits="Labor_PrintTuyenDungTaiDoanhNghiep" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TUYỂN DỤNG LÀM VIỆC TẠI DOANH NGHIỆP </title>
     <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel='stylesheet' type='text/css' />
    <!-- Custom CSS -->
    <link href="../css/PrintPhieuTuVan.css" rel="stylesheet" />
    <style>
        table, th, td {
    border: 1px solid black;
   
}
    </style>
</head>
<body>
    <form style="margin: 0px !important; height: 500px !important;" runat="server">
    <div>
     <div class="KhungIn">
            <div class="TieuDe1">
              <!---Phần tiêu đề của phiếu-->
            </div>
            <div class="HoNgu1">
           SỞ LAO ĐỘNG -TB&XH NGHỆ AN
            </div>
            <div class="HoNgu2" >
                <b style="border-bottom:1px solid; font-size:22px">TRUNG TÂM DỊCH VỤ VIỆC LÀM</b>
            </div>
            
            <div class="HoNgu2" style="float:left">
             <div style="width:60px;float:left; padding-left:1%"><img src="../Images/ttdichvuvieclamna.jpg" height="130" width="140"  style="height:130px; width:140px" /></div>   
              <div style="width:700px"><span style="margin-left:40px">Địa chỉ :</span> <small >Số 201, Đ Phong Định Cảng , P.Trường Thi,Tp. Vinh, Nghệ An</small>
               </div>
                 <div style="width:100%">
                 <span style="margin-left:90px" > <img src="../Images/phone.jpg" height="30" />Điện thoại : 02383 550 050 - Email: <i style="border-bottom:solid 1px black ">sanvieclamnghean@gmail.com </i>  </span>  
                    </div>
                 <div style="width:100%;">
                     <span style="margin-left:90px  ; border-bottom:double 1px black " > Website : <i>vieclamnghean.vn- vlnghean.vieclamvietnam.gov.vn </i> </span>  
                </div>
             </div>
            <div class="clearfix"></div>

         <!---Phần nội dung của phiếu --->
            <div class="TieuDePhieu" style="font-size:22px; width:60%;margin-left:20%;vertical-align:central">
                 TUYỂN DỤNG LÀM VIỆC TẠI  <asp:Label ID="txtTenDonVi" runat="server" ReadOnly="true"></asp:Label>
            </div>
            <br />

            <div class ="ChuBinhThuong">
              <b>1.</b>  <b style="border-bottom:solid 1px;"> Lĩnh vực hoạt động </b><b>:</b> 
                <asp:Label ID="lblIDNganhNghe" ReadOnly="true" runat="server" />
            </div>

            <div class="ChuBinhThuong">
              <b>2.</b>  <b style="border-bottom:solid 1px;"> Vị trí - Điều kiện tuyển dụng</b><b>:</b> <br />
             <!---Nội dung khác so với phiếu TuyendungtaiCtyAbc.aspx ---->
                
           <asp:Repeater ID="dtlTuyenDung" runat="server" EnableViewState="False">
            <HeaderTemplate>
                <table class="DataListTable">
                            <tr >
                            <th style="width: 300px; text-align: center" rowspan="1">Vị trí</th>
                            <th style="width: 30px;  text-align:center" rowspan="1">Số lượng (người)</th>
                             <th style="width: 450px;text-align:center" rowspan="1">Yêu cầu</th>
                         </tr>
                    </thead>
                    <tbody class="results">
            </HeaderTemplate>
            <ItemTemplate >
                <tr>
                    <td>
                           <span class="name"> <%# Eval("NameVitri") %>
                               </span>
                        </td>
                    <td style=" text-align: center;">
                        <%# Eval("SoLuongTuyenDung") %>
                    </td>
                    <td class="DataListTableTdItemJustify">
                        <%# Eval("NoiDungKhac") %>
                    </td> 
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                           </tbody>
                      </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>

             <!----/--->
          

          <div class ="ChuBinhThuong">
              <b>3.</b>  <b style="border-bottom:solid 1px;"> Quyền lợi,chế độ </b><b>:</b> 
              <div style="margin-left:10%">
                       <p> <asp:Label ID="txtQuyenLoi" runat="server"/> </p>
                       <p><b> -<asp:Label ID="lblIDMucLuong" runat="server"/> / tháng</b></p>
              </div>
          </div>
           <div class ="ChuBinhThuong">
              <b>4.</b>  <b style="border-bottom:solid 1px;"> Địa điểm làm việc </b><b>:</b> <asp:Label runat="server" ID="txtDiaDiem"/>
            </div>
        <!--- dòng lưu ý cuối--->
          <div class ="ChuBinhThuong">
            <b>&nbsp;</b>  <b style="border-bottom:solid 1px;">Chi tiết liên hệ</b><b>:</b> Phòng Thông tin TTLĐ — Trung tâm DVVL Nghệ An
              <div style="margin-left:30px">Điện thoại : 02383 550 050 — Email : <span style="border-bottom:solid 1px;">sanvieclamnghean@gmail.com</span> </div>
          </div>

        <!--- Các thẻ bị ẩn đi--->
          <asp:DropDownList ID="ddlIDNganhNghe" Enabled="false" runat="server" Style="width: 100%; border: none; background-color: #fff; visibility: hidden;"/>
         <asp:DropDownList ID="ddlIdVitri" runat="server" Enabled="false" Style="width: 100%; border: none; background-color: #fff; visibility: hidden;"/>
         <asp:DropDownList ID="ddlIDChucVu" runat="server" Enabled="false" Style="width: 100%; border: none; background-color: #fff; visibility: hidden;"/>
         <asp:DropDownList ID="ddlNhomNganh" runat="server" Enabled="false" Style="width: 100%; border: none; background-color: #fff; visibility: hidden;" />
         <asp:DropDownList ID="ddlIDGioiTinh" runat="server" Enabled="false" Style="width: 100%; border: none; background-color: #fff; visibility: hidden;"/>
         <asp:DropDownList ID="ddlIDDoTuoi" runat="server" Enabled="false" Style="width: 100%; border: none; background-color: #fff; visibility: hidden;"/>
         <asp:DropDownList ID="ddlIDTrinhDoChuyenMon" Enabled="false" runat="server" Style="width: 100%; border: none; background-color: #fff; visibility: hidden;"/>
         <asp:DropDownList ID="ddlyeuCauNgoaiNgu" Enabled="false" runat="server" Style="width: 100%; border: none; background-color: #fff; visibility: hidden;"/>
         <asp:DropDownList ID="ddlyeuCauTinHoc" Enabled="false" runat="server" Style="width: 100%; border: none; background-color: #fff; visibility: hidden;"/>
         <asp:DropDownList ID="ddlIDMucLuong" Enabled="false" runat="server" Style="width: 100%; border: none; background-color: #fff; visibility: hidden;"/>    
         <asp:DropDownList ID="ddlThoiGianLamViec" Enabled="false" runat="server" Style="width: 100%; border: none; background-color: #fff; visibility: hidden;">
                                    <asp:ListItem Value="5"> Thỏa thuận </asp:ListItem>
                                    <asp:ListItem Value="1"> Hành chính </asp:ListItem>
                                    <asp:ListItem Value="2"> Bán thời gian </asp:ListItem>
                                    <asp:ListItem Value="3"> Theo ca </asp:ListItem>
                                    <asp:ListItem Value="4"> Toàn thời gian </asp:ListItem>
         </asp:DropDownList>
         <!---Hết--->
        </div>
    </div>
    </form>
</body>
</html>
