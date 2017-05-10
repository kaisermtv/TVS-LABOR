<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TuyenDungView.aspx.cs" Inherits="Labor_TuyenDungView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>THÔNG TIN CHI TIẾT VỀ TIN TUYỂN DỤNG</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="../css/TVSStyle.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="../css/Adminstyle.css" />
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel='stylesheet' type='text/css' />
    <!-- Custom CSS -->
    <link href="../css/style.css" rel='stylesheet' type='text/css' />
    <!-- Graph CSS -->
    <link href="../css/font-awesome.css" rel="stylesheet" />
    <!-- jQuery -->
    <!-- lined-icons -->
    <link rel="stylesheet" href="../css/icon-font.min.css" type='text/css' />

    <style>
        .DataListTable td {
            padding-top: 5px;
            padding-bottom: 5px;
        }
    </style>
</head>
<body style="padding: 10px; padding-left: 20px; padding-right: 20px; background-color: #fff!important; height: 100%!important; min-height: 100%!important; max-height: 100%!important;">
    <form id="form1" runat="server">

        <div class="container">
	            <div class="row">
                <div class="span5">
                    <table class="table table-striped table-condensed">
                        <thead>
                            <tr>
                                <th>THÔNG TIN CHI TIẾT VỀ TIN TUYỂN DỤNG</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td><b>Mã tuyển dụng:</b></td>
                                <td><span class="label label-success" style="font-size:17px">
                                    <asp:Label ID="txtMaTuyenDung" runat="server" ReadOnly="true" Font-Size="16"></asp:Label></span></td>
                            </tr>
                            <tr>
                                <td><b>Tên đơn vị:</b></td>
                                <td>
                                    <input type="hidden" name="txtIDDonVi" id="txtIDDonVi" runat="server" />
                                    <asp:Label ID="txtTenDonVi" ReadOnly="true" runat="server" Font-Size="15"  ></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td><b>Ngành nghề:</b></td>
                                <td>
                                    <asp:Label ID="lblIDNganhNghe" ReadOnly="true" runat="server" />
                                    <asp:DropDownList ID="ddlIDNganhNghe" Enabled="false" runat="server" Style="width: 100%; border: none; background-color: #fff; visibility: hidden;" />
                                </td>
                            </tr>
                            <tr><td><b>II. THÔNG TIN TUYỂN DỤNG</b></td></tr>
                            <tr>
                                <td><b>Vị trí:</b></td>
                                <td>
                                    <asp:Label ID="lblIdVitri" ReadOnly="true" runat="server"  />
                                    <asp:DropDownList ID="ddlIdVitri" runat="server" Enabled="false" Style="width: 100%; border: none; background-color: #fff; visibility: hidden;" />
                                </td>
                                
                            </tr>
                            <tr>
                                <td><b>Chức vụ:</b></td>
                                <td>
                                    <asp:Label ID="lblIDChucVu" ReadOnly="true" runat="server"  />
                                    <asp:DropDownList ID="ddlIDChucVu" runat="server" Enabled="false" Style="width: 100%; border: none; background-color: #fff; visibility: hidden;" />
                                </td>
                            
                                <td>
                             Số lượng:   <b> <asp:Label ID="txtSoLuongTuyenDung" runat="server" ReadOnly="true"></asp:Label></b>
                                </td>
                            </tr>
                            <tr>
                            </tr>

                              <tr>
                                <td><b>Nhóm ngành:</b></td>
                                <td>
                                   <asp:Label ID="lblNhomNganh" ReadOnly="true" runat="server" ></asp:Label>
                                    <asp:DropDownList ID="ddlNhomNganh" runat="server" Enabled="false" Style="width: 100%; border: none; background-color: #fff; visibility: hidden;">
                                        <asp:ListItem Value="0"> Không chọn </asp:ListItem>
                                    </asp:DropDownList>

                                </td>
                            </tr>
                             <tr>
              <td> <b>Giới tính:</b> </td>
                <td>
                    <b><asp:Label ID="lblIDGioiTinh" ReadOnly="true" runat="server" ></asp:Label></b>
                    <asp:DropDownList ID="ddlIDGioiTinh" runat="server" Enabled="false" Style="width: 100%; border: none; background-color: #fff; visibility: hidden;">
                    </asp:DropDownList>
                </td>
               
               <td>
              Độ tuổi:      <b> <asp:Label ID="lblIDDoTuoi" ReadOnly="true" runat="server" /></b>
                    <asp:DropDownList ID="ddlIDDoTuoi" runat="server" Enabled="false" Style="width: 100%; border: none; background-color: #fff; visibility: hidden;">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
               <b> TĐ Chuyên môn: </b>   <asp:Label ID="lblIDTrinhDoChuyenMon" ReadOnly="true" runat="server" Style="width: 100% !important; float: left; margin-bottom: -25px;"></asp:Label>
                    <asp:DropDownList ID="ddlIDTrinhDoChuyenMon" Enabled="false" runat="server" Style="width: 100%; border: none; background-color: #fff; visibility: hidden;">
                    </asp:DropDownList>
                </td>
                
                <td style="width:40% ;">
             <table class="table table-striped table-condensed">
                        <tr>
                            <td>     
                            Ngoại ngữ: <b style=" font-size:15px"> <asp:Label ID="lblyeuCauNgoaiNgu" ReadOnly="true" runat="server" /></b>
                                <asp:DropDownList ID="ddlyeuCauNgoaiNgu" Enabled="false" runat="server" Style="width: 100%; border: none; background-color: #fff; visibility: hidden;">
                                </asp:DropDownList>
                            </td>
                            <td>
                            Tin Học:   <b style=" font-size:15px"><asp:Label ID="lblyeuCauTinHoc" ReadOnly="true" runat="server" /></b>
                                <asp:DropDownList ID="ddlyeuCauTinHoc" Enabled="false" runat="server" Style="width: 100%; border: none; background-color: #fff; visibility: hidden;">
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </td>
             
                <td>
                 Kinh nghiệm: <b> <asp:Label ID="txtNamKinhNghiem" runat="server" ReadOnly="true"></asp:Label></b>
                </td>

            </tr>

            <tr>
                <td>Nội dung:</td>
                <td style="width: 90%;" colspan="5">
                    <asp:Label ID="lblNoiDungKhac" runat="server"></asp:Label>
                </td>
            </tr>

            <tr>
                <td >Mô tả:</td>
                <td style="width: 90%;" colspan="5">
                    <asp:Label ID="txtMoTa" runat="server"></asp:Label>
                </td>
            </tr>


            <tr>
                <td >Ưu tiên:</td>
                <td colspan="5">
                    <asp:Label ID="txtUuTien" runat="server"></asp:Label>
                </td>
            </tr>

            <tr>
                <td>Quyền lợi:</td>
                <td style="width: 90%;" colspan="5">
                    <asp:Label ID="txtQuyenLoi" runat="server"></asp:Label>
                </td>
            </tr>

            <tr>
                <td>Địa điểm:</td>
                <td >
                    <asp:Label ID="txtDiaDiem" runat="server"></asp:Label>
                </td>
            </tr>

            <tr>
               <%-- <td>Tỉnh, thành phố:</td>
                <td>
                    <asp:DropDownList ID="ddlIDTinh" runat="server" Style="width: 100%;" CssClass="form-control">
                </asp:DropDownList>
                </td>--%>
                <td>Mức lương </td>
              
                            <td>
                             <asp:Label ID="lblIDMucLuong" ReadOnly="true" runat="server"></asp:Label>
                                <asp:DropDownList ID="ddlIDMucLuong" Enabled="false" runat="server" Style="width: 100%; border: none; background-color: #fff; visibility: hidden;">
                                </asp:DropDownList>
                            </td>
                            
                            <td>
                    <asp:Label ID="lblThoiGianLamViec" ReadOnly="true" runat="server" Style="width: 100% !important; float: left; margin-bottom: -25px;"></asp:Label>
                                <asp:DropDownList ID="ddlThoiGianLamViec" Enabled="false" runat="server" Style="width: 100%; border: none; background-color: #fff; visibility: hidden;">
                                    <asp:ListItem Value="5"> Thỏa thuận </asp:ListItem>
                                    <asp:ListItem Value="1"> Hành chính </asp:ListItem>
                                    <asp:ListItem Value="2"> Bán thời gian </asp:ListItem>
                                    <asp:ListItem Value="3"> Theo ca </asp:ListItem>
                                    <asp:ListItem Value="4"> Toàn thời gian </asp:ListItem>
                                </asp:DropDownList>
                            </td>
                       <td>
                    <asp:CheckBox ID="ckbNuocNgoai" runat="server" Style="font-weight: normal;" Enabled="false" />&nbsp;&nbsp;Làm việc ở nước ngoài
                </td>
            </tr>
              <tr class="info alert-info">
               
                <td >
                    <div class='input-group date' id='datetimepicker1'>
                Ngày bắt đầu:      <b> <input type='text' id="txtNgayBatDau" runat="server" style="border: none;" /></b> 
                    </div>

                    <script type="text/javascript">
                        $(function () {
                            $('#datetimepicker1').datetimepicker();
                        });
                    </script>
                </td>
              
                <td >
                    <div class='input-group date' id='datetimepicker2'>
         Kết thúc:      <b> <input type='text' id="txtNgayKetThuc" runat="server" style="border: none;" /></b> 
                    </div>

                    <script type="text/javascript">
                        $(function () {
                            $('#datetimepicker2').datetimepicker();
                        });
                    </script>

                </td>
            
                <td>
                      <b >Trạng thái:</b>  <asp:CheckBox ID="ckbState" Checked="true" runat="server" Style="font-weight: normal;" Enabled="false" />&nbsp;&nbsp;Kích hoạt
                </td>
            </tr>


                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
