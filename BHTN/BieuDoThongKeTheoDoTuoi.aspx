<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="BieuDoThongKeTheoDoTuoi.aspx.cs" Inherits="Labor_BieuDoThongKeTheoDoTuoi" %>
<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="Server">
    <style>
        .DataListTable td {
            padding-top: 5px;
            padding-bottom: 5px;
        }

        .khongkhaibao {
            padding: 3px;
            padding-left: 8px;
            padding-right: 8px;
            background-color: #ff6a00;
            color: #fff;
            font-size: 12px;
            margin-left:10px;
        }
        .dakhaibao {
            padding: 3px;
            padding-left: 8px;
            padding-right: 8px;
            background-color: #79CD53;
            color: #fff;
            font-size: 12px;
            margin-left:10px;
        }
        .chothongbao {
            padding: 3px;
            padding-left: 8px;
            padding-right: 8px;
            background-color: #c0c0c0;
            color: #fff;
            font-size: 12px;
            margin-left:10px;
        }
         .quahanthongbao {
            padding: 3px;
            padding-left: 8px;
            padding-right: 8px;
            background-color: #000;
            color: #fff;
            font-size: 12px;
            margin-left:10px;
        }

         label {
            float:left;
            padding: 6px 12px;
        }
    </style>
    <script>
        function delmodal(id, name, idtrangthai) {
            $("#MainContent_idNLD").val(id);
            $("#myModal").modal("show");        
          
        }
    </script>
    <script src="../js/TvsScript.js"></script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div style="width: auto; min-height: 400px;">
        <table style="margin-top: -10px; margin-right: -15px!important; width: 100%!important; padding: 0px!important;" border="0">
            <tr>
                <td>
                    <input type="text" id="txtSearch" placeholder="Nhập tên NLĐ, số CMND, số BHXH, số điện thoại để tìm kiếm" runat="server" class="form-control" />
                </td>
                <td style="width: 280px;">
                    <label>Từ ngày</label>
                    <div class='input-group date' style="margin-left: 0px; width: 70% !important; float: left;">
                        <input type='text' class="form-control dateinput" id="txtTuNgay" runat="server" />
                        <span class="input-group-addon">
                            <span class="glyphicon glyphicon-calendar"></span>
                        </span>
                    </div>
                </td>
                <td style="width: 280px;">
                    <label>Đến ngày</label>
                    <div class='input-group date' style="margin-left: 0px; width: 70% !important; float: left;">
                        <input type='text' class="form-control dateinput" id="txtDenNgay" runat="server" />
                        <span class="input-group-addon">
                            <span class="glyphicon glyphicon-calendar"></span>
                        </span>
                    </div>
                </td>
                <td style="width: 40px !important; text-align: center;">
                    <asp:ImageButton ID="btnSearch" ImageUrl="../images/Search.png" runat="server" Style="margin-top: 5px; height: 19px;" OnClick="btnSearch_Click" />
                </td>
                <td style="width:250px;">
                <label>Trạng thái</label>
                 <asp:DropDownList ID="ddlTrangThai" CssClass="form-control" runat="server" Style="width:150px" AutoPostBack="True" OnSelectedIndexChanged="ddlTrangThai_SelectedIndexChanged">
                </asp:DropDownList>
                </td>
              <td>
                      <div style="float:right;width:165px;margin:10px;text-align:right;">
             <a href="/BHTN/"><input type="button" class="btn btn-default" value="Trở lại" /></a>
             </div>
              </td>
            </tr>
        </table>
        <div>
            <asp:Button ID="btnXuatExcel" CssClass="btn btn-primary" runat="server" 
                Text="Xuất Excel" OnClick="btnXuatExcel_Click" Visible="False" />
        </div>
        <table width="100%" cellpadding="0" cellspacing="0" border="0" style="margin-top: 10px; height: 26px;"
            id="tblABC" runat="server">
            <tr>
                <td style="padding-left: 6px;" align="center">
                <br />
                <asp:Chart ID="Chart1" runat="server" Width="1000px" Height="400px" Palette="SeaGreen">
                    <Series>
                        <asp:Series Name="Category" ChartArea="ChartArea1" YValuesPerPoint="2">
                        </asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1">
                        </asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
            </td>            
            </tr>
        </table>
        <div class="row col-sm-12" style="display:none">
            <a class="btn btn-danger" style="float: left; margin-right: 10px;" onclick="CheckAll()">Check All</a>
            <a class="btn btn-danger" style="float: left; margin-right: 10px;" onclick="UnCheckAll()">UnCheck All</a>
            <div class="warning">
                <asp:Label ID="lblMsg" runat="server" Text="" Font-Size="Larger" ForeColor="Red" />
            </div>
            <a class="btn btn-primary" style="float: right;" onclick="ChuyenSelect('TraKetQuaDinhModal')">Trả quyết định hưởng TCTN</a>         
            </div>
        <!-- Modal chuyen bo phan tra ket qua-->
        <div id="TraKetQuaDinhModal" class="modal fade" role="dialog">
            <div class="modal-dialog" style="display: table;">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title">Trả quyết định hưởng TCTN</h4>
                    </div>
                    <div class="modal-body">
                        <table> 
                            <tr>
                                <td>Số hồ sơ được chọn:</td>
                                <td>
                                    <asp:TextBox ID="txtSoHoSoDuocChon" CssClass="form-control" runat="server" Style="width: 100%;"></asp:TextBox>
                                </td>
                            </tr> 
                             <tr>
                                 <td>
                                     Ngày trả kết quả:
                                 </td>
                                 <td>
                                <div class='input-group date' style="margin-left: 0px; width: 100% !important; float: left;">
                                <input type='text' class="form-control dateinput" id="txtNgayTrinhKy" runat="server" />
                                <span class="input-group-addon">
                                    <span class="glyphicon glyphicon-calendar"></span>
                                </span>
                                </div>
                                 </td>
                             </tr>                       
                        </table>
                    </div>
                    <div class="modal-footer">                      
                    </div>
                </div>
            </div>
        </div>

        <script>
            $(function () {
                $('.date').datetimepicker({
                    format: 'DD/MM/YYYY'
                });

                $(".dateinput").mask("99/99/9999", { placeholder: "dd/MM/yyyy" });
            });

            function ChuyenSelect(NameModal)
            {              
                var txt = "";
                var index=0;
                var SoBatDau;
                for(i=1;i< <%= index %>;i++)
                {
                    var objchk = document.getElementById('ckbSelect' + i);
                    if(objchk != null && objchk.checked == true)
                    {
                        if(txt != "") txt += ","
                        txt += objchk.value;
                        index ++;
                    }
                }

                if(txt != "")
                {   
                    $("#MainContent_hdlstChuyen").val(txt); 
                    $("#MainContent_hdSoHoSoDaChon").val(index);
                    $("#MainContent_txtSoHoSoChonDanh").val(index);    
                    $("#MainContent_txtSoHoSoCanTrinh").val(index);
                    $("#MainContent_txtSoHoSoDuocChon").val(index);
                    GetAutoNumber();
                    $("#"+NameModal).modal("show");                
                }
            }        
       
       function CheckAll()
        {
            for(i=1;i< <%= index %>;i++)
            {
                var objchk = document.getElementById('ckbSelect' + i);
                if(objchk != null)
                {
                    objchk.checked = true;
                }
            }
        }

        function UnCheckAll()
        {
            for(i=1;i< <%= index %>;i++)
            {
                var objchk = document.getElementById('ckbSelect' + i);
                if(objchk != null)
                {
                    objchk.checked = false;
                }
            }
        }    
         
            $("#MainContent_txtSoBatDau").blur(function(){
                DanhSoVanBan();
            });
            $("#MainContent_ddlLoaiQuyetDinh").change(function(){
                GetAutoNumber();
            });
            function DanhSoVanBan()
            {
                var SoBatDau=0,SoHoSoDaChon=0,SoKetThu=0;
                SoHoSoDaChon= $("#MainContent_hdSoHoSoDaChon").val();      
                SoBatDau=$("#MainContent_txtSoBatDau").val();
                SoKetThu= parseInt(SoBatDau) + parseInt(SoHoSoDaChon)-1;                 
                $("#MainContent_txtSoKetThuc").val(SoKetThu);
            }

            var msg='<%=_msg%>';
            if(msg!="")
            {
                alert(msg);
            }
        </script>
        <script type="text/javascript">
            function GetAutoNumber() {
                var IDLoaiVanBan=$("#MainContent_ddlLoaiQuyetDinh").val();
                $.get("/ajax/DanhSoCongVan.aspx?id="+ IDLoaiVanBan, function (data, status) {         
                    //selectout.innerHTML = "";
                    if (status == "success")
                    { 
                        $("#MainContent_txtSoBatDau").val(data.toString());  
                        var SoBatDau=0,SoHoSoDaChon=0,SoKetThu=0;
                        SoHoSoDaChon= $("#MainContent_hdSoHoSoDaChon").val();      
                        SoBatDau=data;
                        SoKetThu= parseInt(SoBatDau) + parseInt(SoHoSoDaChon)-1;                 
                        $("#MainContent_txtSoKetThuc").val(SoKetThu);
                      
                    } else {
                        selectout.innerHTML = "";             
                        alert("Mất kết nôi! Xin thử lại.");
                    }      
                    //selectout.
                });
            }
        </script>       
    </div>
    </asp:Content>

