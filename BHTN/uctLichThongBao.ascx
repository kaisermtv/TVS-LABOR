<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctLichThongBao.ascx.cs" Inherits="uctLichThongBao" %>
<style>
    th {
        width:20%;
        font-weight:normal;
        padding:5px;
    }
    td {
        width:30%;
        padding:3px;
    }
</style>
<div class="row line"> 
    t<table style="border: 0px solid; width: 100%">
       <tr>
           <th>Họ tên:</th>
           <td>
               <asp:TextBox ID="txtHoTen" runat="server" CssClass="form-control"></asp:TextBox>
           </td>
           <th>Hưởng:</th>
           <td>
               <asp:TextBox ID="txtSoThangHuong" runat="server" CssClass="form-control"></asp:TextBox>
           </td>
       </tr>
       <tr>
           <th>Hưởng từ ngày:</th>
           <td>
               <asp:TextBox ID="txtHuongTuNgay" runat="server" CssClass="form-control"></asp:TextBox>
           </td>
           <th>Hưởng đến ngày:</th>
           <td>
               <asp:TextBox ID="txtHuongDenNgay" runat="server" CssClass="form-control"></asp:TextBox>
           </td>
       </tr>
       <tr>
           <th>Khai báo lần thứ nhất:</th>
           <td>
              <div class='input-group date' style="margin-left: 0px; width: 100% !important; float: right;">
                    <input type='text' class="form-control dateinput" id="txtKhaiBaoThangThuNhat" runat="server" />
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>        

           </td>
           <th></th>
           <td>
           </td>
       </tr>
       <tr>
           <th>Khai báo tháng thứ 2 từ ngày:</th>
           <td>
              <div class='input-group date' style="margin-left: 0px; width: 100% !important; float: right;">
                    <input type='text' class="form-control dateinput" id="txtKhaiBaoThang2TuNgay" runat="server" />
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>        

           </td>
           <th>
               Đến ngày:
           </th>
           <td
         
              <div class='input-group date' style="margin-left: 0px; width: 100% !important; float: right;">
                    <input type='text' class="form-control dateinput" id="txtKhaiBaoThang2DenNgay" runat="server" />
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>      
           </td>
       </tr>
        <tr>
           <th>Khai báo tháng thứ 3 từ ngày:</th>
           <td>
              <div class='input-group date' style="margin-left: 0px; width: 100% !important; float: right;">
                    <input type='text' class="form-control dateinput" id="txtKhaiBaoThang3TuNgay" runat="server" />
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>        

           </td>
           <th>
               Đến ngày:
           </th>
           <td>
           
              <div class='input-group date' style="margin-left: 0px; width: 100% !important; float: right;">
                    <input type='text' class="form-control dateinput" id="txtKhaiBaoThang3Denngay" runat="server" />
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>      
           </td>
       </tr>
        <tr>
           <th>Khai báo tháng thứ 4 từ ngày:</th>
           <td>
              <div class='input-group date' style="margin-left: 0px; width: 100% !important; float: right;">
                    <input type='text' class="form-control dateinput" id="txtKhaiBaoThang4TuNgay" runat="server" />
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>        

           </td>
           <th>
               Đến ngày:
           </th>
           <td>
      
              <div class='input-group date' style="margin-left: 0px; width: 100% !important; float: right;">
                    <input type='text' class="form-control dateinput" id="txtKhaiBaoThang4DenNgay" runat="server" />
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>      
           </td>
       </tr>
        <tr>
           <th>Khai báo tháng thứ 5 từ ngày:</th>
           <td>
              <div class='input-group date' style="margin-left: 0px; width: 100% !important; float: right;">
                    <input type='text' class="form-control dateinput" id="txtKhaiBaoThang5TuNgay" runat="server" />
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>        

           </td>
           <th>
               Đến ngày:
           </th>
           <td>
         
              <div class='input-group date' style="margin-left: 0px; width: 100% !important; float: right;">
                    <input type='text' class="form-control dateinput" id="txtKhaiBaoThang5DenNgay" runat="server" />
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>      
           </td>
       </tr>
        <tr>
           <th>Khai báo tháng thứ 6 từ ngày:</th>
           <td>
              <div class='input-group date' style="margin-left: 0px; width: 100% !important; float: right;">
                    <input type='text' class="form-control dateinput" id="txtKhaiBaoThang6TuNgay" runat="server" />
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>        

           </td>
           <th>
               Đến ngày:
           </th>
           <td>
           
              <div class='input-group date' style="margin-left: 0px; width: 100% !important; float: right;">
                    <input type='text' class="form-control dateinput" id="txtKhaiBaoThang6DenNgay" runat="server" />
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>      
           </td>
       </tr>
        <tr>
           <th>Khai báo tháng thứ 7 từ ngày:</th>
           <td>
              <div class='input-group date' style="margin-left: 0px; width: 100% !important; float: right;">
                    <input type='text' class="form-control dateinput" id="txtKhaiBaoThang7TuNgay" runat="server" />
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>        

           </td>
           <th>
               Đến ngày:
           </th>
           <td>
     
              <div class='input-group date' style="margin-left: 0px; width: 100% !important; float: right;">
                    <input type='text' class="form-control dateinput" id="txtKhaiBaoThang7DenNgay" runat="server" />
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>      
           </td>
       </tr>
        <tr>
           <th>Khai báo tháng thứ 8 từ ngày:</th>
              <td>
              <div class='input-group date' style="margin-left: 0px; width: 100% !important; float: right;">
                    <input type='text' class="form-control dateinput" id="txtKhaiBaoThang8TuNgay" runat="server" />
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>        

           </td>
           <th>
               Đến ngày:
           </th>
           <td>
        
              <div class='input-group date' style="margin-left: 0px; width: 100% !important; float: right;">
                    <input type='text' class="form-control dateinput" id="txtKhaiBaoThang8DenNgay" runat="server" />
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>      
           </td>
       </tr>
        <tr>
           <th>Khai báo tháng thứ 9 từ ngày:</th>
           <td>
              <div class='input-group date' style="margin-left: 0px; width: 100% !important; float: right;">
                    <input type='text' class="form-control dateinput" id="txtKhaiBaoThang9TuNgay" runat="server" />
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>        

           </td>
           <th>
               Đến ngày:
           </th>
           <td>
         
              <div class='input-group date' style="margin-left: 0px; width: 100% !important; float: right;">
                    <input type='text' class="form-control dateinput" id="txtKhaiBaoThang9DenNgay" runat="server" />
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>      
           </td>
       </tr>
        <tr>
           <th>Khai báo tháng thứ 10 từ ngày:</th>
           <td>
              <div class='input-group date' style="margin-left: 0px; width: 100% !important; float: right;">
                    <input type='text' class="form-control dateinput" id="txtKhaiBaoThang10TuNgay" runat="server" />
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>        

           </td>
           <th>
               Đến ngày:
           </th>
           <td>
      
              <div class='input-group date' style="margin-left: 0px; width: 100% !important; float: right;">
                    <input type='text' class="form-control dateinput" id="txtKhaiBaoThang10DenNgay" runat="server" />
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>      
           </td>
       </tr>
        <tr>
           <th>Khai báo tháng thứ 11 từ ngày:</th>
           <td>
              <div class='input-group date' style="margin-left: 0px; width: 100% !important; float: right;">
                    <input type='text' class="form-control dateinput" id="txtKhaiBaoThang11TuNgay" runat="server" />
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>        

           </td>
           <th>
               Đến ngày:
           </th>
           <td>
           
              <div class='input-group date' style="margin-left: 0px; width: 100% !important; float: right;">
                    <input type='text' class="form-control dateinput" id="txtKhaiBaoThang11DenNgay" runat="server" />
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>      
           </td>
       </tr>
        <tr>
           <th>Khai báo tháng thứ 12 từ ngày:</th>
           <td>
              <div class='input-group date' style="margin-left: 0px; width: 100% !important; float: right;">
                    <input type='text' class="form-control dateinput" id="txtKhaiBaoThang12TuNgay" runat="server" />
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>        

           </td>
           <th>
               Đến ngày:
           </th>
           <td>
         
              <div class='input-group date' style="margin-left: 0px; width: 100% !important; float: right;">
                    <input type='text' class="form-control dateinput" id="txtKhaiBaoThang12DenNgay" runat="server" />
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>      
           </td>
       </tr>
        <tr>
           <th></th>
           <td>
              <br />
              <br />
               <asp:Button ID="btnCapNhat" runat="server" CssClass="btn btn-primary" Text="Cập nhật" OnClick="btnCapNhat_Click" />
           </td>
           <th>
           </th>
           <td>
         
           </td>
       </tr>
   </table>
</div>
<asp:HiddenField ID="hdIDTinhHuong"  runat="server"/>
<asp:HiddenField ID="hdIDNguoiLaoDong" runat="server"/>
<script>
    var _msg = '<%=_msg%>';
    if (_msg != '') {
        alert(_msg);
    }
</script>
