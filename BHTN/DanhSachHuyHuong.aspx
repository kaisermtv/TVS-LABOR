﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="DanhSachHuyHuong.aspx.cs" Inherits="Labor_DanhSachHuyHuong" %>
<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="Server">
    <style>
        .DataListTable td {
            padding-top: 5px;
            padding-bottom: 5px;
        }
        .TrangThai {
            padding: 3px;
            padding-left: 8px;
            padding-right: 8px;
            background-color: #ff6a00;
            color: #fff;
            font-size: 12px;
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
                        <input type='text' class="form-control dateinput" id="txtDenNgay" runat="server" />
                        <span class="input-group-addon">
                            <span class="glyphicon glyphicon-calendar"></span>
                        </span>
                    </div>
                </td>
                <td style="width: 40px !important; text-align: center;">&nbsp;<asp:ImageButton ID="btnSearch" ImageUrl="../images/Search.png" runat="server" Style="margin-top: 5px;" OnClick="btnSearch_Click" />
                </td>
                <td >
                      <div style="float:right;width:165px;margin:10px;text-align:right;">
             <a href="/BHTN/"><input type="button" class="btn btn-default" value="Trở lại" /></a>
             </div>
                </td>

            </tr>
        </table>
        <asp:Button ID="btnExport" runat="server" Text="Xuất File Excel" 
        CssClass="btn btn-primary" onclick="btnExport_Click" Visible="False" />
        <asp:Repeater ID="dtlData" runat="server" onitemcommand="dtlData_ItemCommand">
            <HeaderTemplate>
                <table class="DataListTable" border="0" style="width: 100%; margin-top: 10px;">
                    <tr style="height: 40px;" class="DataListTableHeader">
                        <td class="DataListTableHeaderTdItemTT" style="width: 3%;">#</td>
                        <td class="DataListTableHeaderTdItemJustify">Người lao động</td>
                        <td class="DataListTableHeaderTdItemJustify" style="width: 13%;">Tình trạng</td>
                        <td class="DataListTableHeaderTdItemJustify" style="width: 10%;">Số CMND</td>
                        <td class="DataListTableHeaderTdItemJustify" style="width: 10%;">Số BHXH</td>
                        <td class="DataListTableHeaderTdItemJustify" style="width: 10%;">Ngày hẹn trả KQ</td>
                        <td class="DataListTableHeaderTdItemJustify" style="width: 10%;">Thông tin BH</td>
                        <td class="DataListTableHeaderTdItemJustify" style="width: 8%; text-align:left">Ngày ký </td> 
                        <td class="DataListTableHeaderTdItemJustify" style="width: 8%; text-align:left">Số văn bản</td> 
                        <td class="DataListTableHeaderTdItemJustify" style="width: 8%;">Hủy đề xuất</td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td class="DataListTableTdItemTT">
                        <input type="checkbox" id="ckbSelect<% =index++ %>" value="<%# Eval("IdNLDTCTN") %>" />
                    </td>
                    <td class="DataListTableTdItemJustify"><%# Eval("HoVaTen") %></td>
                    <td class="DataListTableTdItemJustify" style="color: red; text-align:left;"><%# Eval("TrangThai").ToString().Replace("Chuyển thẩm định","<span class = \"TrangThai\">Chuyển thẩm định</span>") %></td>
                    <td class="DataListTableTdItemJustify"><%# Eval("CMND") %></td>
                    <td class="DataListTableTdItemJustify"><%# Eval("BHXH") %></td>
                    <td class="DataListTableTdItemJustify">
                        <%# (Eval("NgayHenTraKQ").ToString() != "")?((DateTime)Eval("NgayHenTraKQ")).ToString("dd/MM/yyyy"):"" %><br />
                    </td>
                    <td class="DataListTableTdItemCenter">Đóng <%# Eval("SoThangDongBHXH").ToString() != ""? Eval("SoThangDongBHXH") :"0"%> tháng
                    </td>  
                       <td class="DataListTableTdItemJustify">
                        <%# (Eval("NgayKy").ToString() != "") ? ((DateTime)Eval("NgayKy")).ToString("dd/MM/yyyy") : ""%><br />
                    </td>                  
                    <td class="DataListTableTdItemJustify">
                        <%# Eval("SoVanBan")%><br />
                    </td>  
                    <td class="DataListTableTdItemCenter">
                      <asp:Button ID="btnHuyDeXuat" class="btn btn-primary" runat ="server" CommandName="HuyDeXuat" style="font-size:12px; padding:3px;"  CommandArgument='<%# Eval("IdNLDTCTN") %>' Text="Hủy đề xuất" />
                     </td>              
                </tr>
            </ItemTemplate>
            <FooterTemplate>
             <tr>
            <td colspan="8">
               <b>Tổng số hồ sơ:<%= dtlData.Items.Count.ToString()%></b></tr>
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
            <a class="btn btn-primary" style="float:right;"  onclick="ChuyenSelect('HuyHuongModal')">Hủy hưởng</a>         
            </div>
        <!-- Modal chuyen bo phan tra ket qua-->
        <div id="HuyHuongModal" class="modal fade" role="dialog">
            <div class="modal-dialog" style="display: table;">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title">Hủy hưởng</h4>
                    </div>
                    <div class="modal-body">
                        <table> 
                            <tr>
                                <td>Số hồ sơ được chọn:</td>
                                <td>
                                    <asp:TextBox ID="txtSoHoSoDuocChon" CssClass="form-control" runat="server" Style="width: 100%;"></asp:TextBox>
                                </td>
                            </tr> 
                                              
                        </table>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnHuyHuong" runat="server" CssClass="btn btn-primary" Text="Hủy hưởng" OnClick="btnHuyHuong_Click" />
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
                    $("#MainContent_txtSoHoSoDuocChon").val(index);
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
         
            var msg='<%=_msg%>';
            if(msg!="")
            {
                alert(msg);
            }            
        </script>
    </div>
    <asp:HiddenField ID="hdlstChuyen" runat="server" />
</asp:Content>

