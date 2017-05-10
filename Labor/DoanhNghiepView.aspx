<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DoanhNghiepView.aspx.cs" Inherits="Labor_DoanhNghiepView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>XEM THÔNG TIN DOANH NGHIỆP</title>
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
</head>
<body style="padding: 10px; padding-left: 20px; padding-right: 20px; background-color: #fff!important; height: 100%!important; min-height: 100%!important; max-height: 100%!important;">
    <form id="form1" runat="server">
        <div class="container">
	<div class="row">
		<div class="span3">
            <table class="table table-striped table-condensed">
                  <thead>
                  <tr>
                      <th>THÔNG TIN DOANH NGHIỆP</th>
                  </tr>
              </thead>   
              <tbody style="font-size:15px;">
                <tr>
                    <td><b>Tên đơn vị: </b></td>
                    <td style="font-size:18px">   <span class="label label-success">  <asp:Label ID="txtTenDonVi" Enabled="false" runat="server"/></span>
                    </td>
                  </tr>
                  <tr>
                    <td>Điện thoại DN :</td>
                    <td>
                        <asp:Label ID="txtDienThoai" runat="server" Enabled="false"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Ngành nghề:</td>
                    <td>  <asp:Label ID="ddlIDNganhNghe" Enabled="false" runat="server"></asp:Label></td>                                       
                </tr>
                <tr>
                    <td>Quy mô:</td>
                    <td> <asp:Label ID="txtQuyMo" Enabled="false" runat="server"/></td>
                    <td><span class="label"> <asp:Label ID="ddlIdLoaiHinh" Enabled="false" runat="server"/></span></td>                                        
                </tr>
                <tr>
                    <td>Địa chỉ:</td>
                    <td> <asp:Label ID="txtDiaChi" runat="server" Enabled="false"></asp:Label> </td>                                       
                </tr>
                   <tr>
                    <td>Quận, huyện:</td>
                    <td><asp:Label ID="ddlIDHuyen" runat="server" Enabled="false"></asp:Label></td>                                        
                </tr>
                <tr>
                    <td>Tỉnh, thành phố:</td>
                 
                    <td><asp:Label ID="ddlIDTinh" runat="server" Enabled="false"/> </td>                                        
                </tr>   
                    <tr>
                    <td>Điện thoại DN :</td>
                    <td> <asp:Label ID="txtDienThoaiDonVi" runat="server" Enabled="false"></asp:Label></td>
                                                
                </tr>
                   <tr>
                    <td>Địa chỉ Email</td>
                    <td> <asp:Label ID="txtEmail" runat="server" Enabled="false"/></td>
                                                     
                </tr>   
                  <tr>
                      <td>Email Doanh Nghiệp</td>
                      <td><asp:Label ID="txtEmailDonVi" Enabled="false" runat="server"></asp:Label></td>
                  </tr>
                   <tr>
                    <td>Website</td>
                    <td>   <asp:Label ID="txtWebsite" Enabled="false" runat="server"></asp:Label>

                    </td>
                                                     
                </tr>   
                    <tr>
                    <td>Người đại diện:</td>
                  
                    <td>  <asp:Label ID="txtNguoiDaiDien" runat="server" Enabled="false"></asp:Label></td>                                        
                </tr>        
                    <tr>
                    <td>Ngày đăn ký</td>
                    <td> <asp:Label ID="txtNgayDangKy" runat="server" Enabled="false"/></td>
                </tr>        
                 <tr>
                    <td>Chức vụ: </td>
                    <td>   <asp:Label ID="txtChucVu" runat="server" Enabled="false"/></td>                                        
                 </tr> 
                  <tr>
                      <td>
                          Doanh nghiệp nước ngoài 
                      </td>
                      <td>
                             <asp:CheckBox ID="ckbNuocNgoai" runat="server" Enabled="false" Style="font-weight: normal; padding-top: 10px !important;" Text="&nbsp;&nbsp;<span style = 'font-weight:normal;'>Doanh nghiệp nước ngoài</span>" />
                 </td>
                  </tr>       
                                               
              </tbody>
            </table>
            </div>
	</div>
</div>

    
            <br /><br />
      
    </form>
</body>
</html>
