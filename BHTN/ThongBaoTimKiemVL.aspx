<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin.master" CodeFile="ThongBaoTimKiemVL.aspx.cs" Inherits="Labor_TinhHuong" %>
<%@ Register src="uctLichThongBao.ascx" tagname="uctLichThongBao" tagprefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="../css/thongbaovieclam.css" rel="stylesheet" />
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
    input[type="radio"], input[type="checkbox"] {width:30px; height:30px; }
    </style>
    <script>
        $(function () {
            $('.date').datetimepicker({
                format: 'DD/MM/YYYY'
            });

            $(".dateinput").mask("99/99/9999", { placeholder: "dd/MM/yyyy" });
        });
        $(function () {
            $('.date1').datetimepicker({
                format: 'MM/YYYY'
            });

            $(".dateinput1").mask("99/9999", { placeholder: "MM/yyyy" });
        });
       
    </script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div style="width: 83%; float: left; margin-top:-15px!important;">
        <div class="row headlabel" style="padding:3px; padding-left: 15px; background-color: #00ffff; margin-right:6px!important;">
         <b>Khai báo thông tin việc làm</b>
        </div>
        <div  class="content-left">
            <asp:Repeater ID="rptLichThongBao" runat="server">
                <HeaderTemplate>
                 <ul>               
                </HeaderTemplate>
                <ItemTemplate>
                <li><a href="ThongBaoTimKiemVL.aspx?id=<%=itemId%>&tg=<%=_index++%>"><%# Eval("ThangThongBao") %></a></li>
                </ItemTemplate>
                <FooterTemplate>
                 </ul>
                 </FooterTemplate>
            </asp:Repeater>          
        </div>
        <div class="content-top">
            <h4>Bạn đang khai báo việc làm tháng: <%= (_tg.ToString()=="0")?"":_tg.ToString()%></h4>
        </div>
        <div class="content-center">
        <div class="row line" style="margin-left:0 !important;">
         <table>
             <tr>
                <th>Ngày khai báo:</th>
                <td>
                    <div class='input-group date' style="margin-left: 0px; width: 100% !important; float: left;">
                        <input type='text' class="form-control dateinput" id="txtTuNgay" runat="server" />
                        <span class="input-group-addon">
                            <span class="glyphicon glyphicon-calendar"></span>
                        </span>
                    </div>
                </td>
                <th>Không KB trực tiếp:</th>
                <td>
                    <asp:CheckBox ID="chkKhaiBaoTrucTiep" runat="server" style="width:30px; height:30px;"/>
                </td>
             </tr>
             <tr id="LyDo" style="display:none">
                 <th>Ly do:</th>
                 <td>
                     <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control" Style="width: 100%;">
                    </asp:DropDownList>

                 </td>
                 <th></th>
                 <td></td>
             </tr>
              <tr>
                <th>Người tiếp nhận:</th>
                <td>
                    <asp:DropDownList ID="ddlLuongToiThieu0" runat="server" CssClass="form-control" Style="width: 100%;">
                    </asp:DropDownList>
                </td>
                <th>Tình trạng việc làm:</th>
                <td>
                  
                    <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server" Style="width: 100%;">
                </asp:DropDownList>
                  
                  </td>
             </tr>
              <tr>
                <th>Số quầy KB:</th>
                <td>
                <asp:TextBox ID="txtLuongTrungBinh" runat="server" CssClass="form-control money"></asp:TextBox>
                </td>
                <th>Ghi chú:</th>
                <td>
                <asp:TextBox ID="txtGhiChu" runat="server" CssClass="form-control money"></asp:TextBox>
                </td>
             </tr>
         </table>
        </div>
        </div>
    </div>
     <!-- Modal -->
    <div id="lichthongbao" class="modal fade" role="dialog">
        <div class="modal-dialog" style="width:80%;">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Lịch thông báo</h4>
                </div>
                <div class="modal-body">
                <uc1:uctLichThongBao ID="LichThongBao1" runat="server" />
                </div>
                <div class="modal-footer">                 
                </div>
            </div>

        </div>
    </div> 
    <div style="width: 16%; float: right; margin-top:-5px;">
        <div style ="height:28px; background-color:red; line-height:28px; color:#fff; text-align:center; font-size:12PX; font-weight:bold;">Thông tin đóng hưởng</div>
        <div class="panel-body1" style ="padding-top:10px; margin-top:2px;">
            <div class="row">
                Họ tên: <asp:Label ID="lblHoTen" runat="server" Text="" style="color:red;float: right;"></asp:Label>
                <br />
                Số CMND: <asp:Label ID="lblCMND" runat="server" Text="" style="color:red;float: right;"></asp:Label>
                <br />
                Số sổ BHXH: <asp:Label ID="lblSoBHXH" runat="server" Text="" style="color:red;float: right;"></asp:Label>
                <br /> 
                <br />
                <div class="list-group list-group-alternate">
                    <a href="#" class="list-group-item" data-toggle="modal" data-target="#lichthongbao" runat="server"><span class="badge1" style ="left:140px;">></span>Lịch thông báo</a>
                </div>               
               <asp:Button ID="btnDaKhaiBao" runat="server" Text="Đã khai báo" Style="width: 100% !important;margin-top:10px;" CssClass="btn btn-primary" OnClick="btnDaKhaiBao_Click" />
               <asp:Button ID="btnKhongKhaiBao" runat="server" Text="Không khai báo" Style="width: 100% !important;margin-top:10px;" CssClass="btn btn-primary" OnClick="btnKhongKhaiBao_Click" />
            
            </div>
        </div>
    </div>


    <footer style="z-index: 100; height: 43px !important; margin-bottom: 0px; margin-left: -14px; width: 100%; text-align: justify; background-color: #f0f0f0; padding-top: 4px">
        <div class="warning">
            <asp:Label ID="lblMsg" runat="server" Text="" Font-Size="Larger" ForeColor="Red" />
        </div>
    </footer>
    <asp:HiddenField ID="hdIDNguoiLaoDong" runat="server" />
    <script>      
        $("#MainContent_chkKhaiBaoTrucTiep").change(function () {
            var check = $(this).is(":checked") ? 1 : 0;
            if(check==1)
            {
                $("#LyDo").css("display","");
            }
            else
            {
                $("#LyDo").css("display", "none");
            }
          
           
        });
    </script>
</asp:Content>
