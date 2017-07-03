<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="DanhSachDeXuatTamDung.aspx.cs" Inherits="Labor_DanhSachDeXuatTamDung" %>
<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
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
            float: left;
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
                        <input type='text' class="form-control dateinput" id="Text1" runat="server" />
                        <span class="input-group-addon">
                            <span class="glyphicon glyphicon-calendar"></span>
                        </span>
                    </div>
                </td>
                <td style="width: 40px !important; text-align: center;">
                    <asp:ImageButton ID="btnSearch" ImageUrl="../images/Search.png" runat="server" Style="margin-top: 5px;" OnClick="btnSearch_Click" />
                </td>
                <td style="width:250px;">
                <label>Trạng thái</label>
                 <asp:DropDownList ID="ddlTrangThai" CssClass="form-control" runat="server" Style="width:150px" AutoPostBack="True" OnSelectedIndexChanged="ddlTrangThai_SelectedIndexChanged">
                </asp:DropDownList>
                </td>
            </tr>
        </table>
        <asp:Repeater ID="dtlData" runat="server" OnItemCommand="dtlData_ItemCommand" OnItemDataBound="dtlData_ItemDataBound">
            <HeaderTemplate>
                <table class="DataListTable" border="0" style="width: 100%; margin-top: 10px;">
                    <tr style="height: 40px;" class="DataListTableHeader">
                        <td class="DataListTableHeaderTdItemTT" style="width: 3%;">#</td>
                        <td class="DataListTableHeaderTdItemJustify">Người lao động</td>
                        <td class="DataListTableHeaderTdItemJustify">Thông báo việc làm hàng tháng</td>                    
                        <td class="DataListTableHeaderTdItemJustify" style="width: 10%;">Số CMND</td>                        
                        <td class="DataListTableHeaderTdItemJustify" style="width: 10%; text-align:left">Ngày hẹn trả KQ</td>
                        <td class="DataListTableHeaderTdItemCenter" style="width: 13%;">&nbsp;</td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td class="DataListTableTdItemTT">
                        <input type="checkbox" id="ckbSelect<% =index++ %>" value="<%# Eval("IdNLDTCTN") %>" />
                    </td>
                    <td class="DataListTableTdItemJustify"><%# Eval("HoVaTen")%></td>
                    <td class="DataListTableTdItemJustify">
                        <asp:Label ID="lblKhaiBaoViecLam" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="DataListTableTdItemJustify"><%# Eval("CMND") %></td>
                    <td class="DataListTableTdItemJustify">
                        <%# (Eval("NgayHenTraKQ").ToString() != "")?((DateTime)Eval("NgayHenTraKQ")).ToString("dd/MM/yyyy"):"" %><br />
                    </td>                   
                    <td class="DataListTableTdItemCenter">                              
                      <asp:Button ID="btnChuyenTinhHuong"  CssClass ="btn btn-primary" style="font-size:12px; padding:3px;" runat="server" Text="Chuyển TH"  CommandName="ChuyenTinhHuong" CommandArgument='<%#Eval("IdNLDTCTN") %>' />                  
                     <asp:Button ID="btnXoaDeXuat"  CssClass ="btn btn-primary" style="font-size:12px; padding:3px;" runat="server" Text="Xóa đề xuất" CommandName="XoaDeXuat" CommandArgument='<%#Eval("IdNLDTCTN") %>' />                  
              
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        <table width="100%" cellpadding="0" cellspacing="0" border="0" style="margin-top: 10px; height: 26px;"
            id="tblABC" runat="server">
            <tr>
                <td style="padding-left: 6px;">
                    <cc1:CollectionPager ID="cpData" runat="server" BackText="" FirstText="Đầu"
                        ControlCssClass="ProductPage" LabelText="" LastText="Cuối" NextText="" UseSlider="true"
                        ResultsFormat="" BackNextLinkSeparator="" ResultsLocation="None" BackNextLocation="None"
                        PageNumbersSeparator="&nbsp;" PagingMode="PostBack">
                    </cc1:CollectionPager>
                </td>
            </tr>
        </table>
        <div class="row col-sm-12">
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
                        <asp:Button ID="btnChuyenHoSo" runat="server" CssClass="btn btn-primary" Text="Trả kết quả" OnClick="btnChuyenHoSo_Click" />
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
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
    <asp:HiddenField ID="hdlstChuyen" runat="server" />
    <asp:HiddenField ID="hdChuyen" runat="server" />    
    <asp:HiddenField ID="hdSoHoSoDaChon" runat="server" />
</asp:Content>

