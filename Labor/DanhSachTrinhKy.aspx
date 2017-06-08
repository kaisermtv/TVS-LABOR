﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="DanhSachTrinhKy.aspx.cs" Inherits="Labor_DanhSachTrinhKy" %>

<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="Server">
    <style>
        .DataListTable td {
            padding-top: 5px;
            padding-bottom: 5px;
        }

        .TrangThai
        {
            padding:3px;
            padding-left:8px;
            padding-right:8px;
            background-color:#ff6a00;
            color:#fff;
            font-size:12px;
        }
        label {
            float:left; padding:6px 12px;
        }
    </style>
    <script>
        function delmodal(id, name, idtrangthai) {
            $("#MainContent_idNLD").val(id);
            $("#TrinhKyModal").modal("show");        
          
        }
    </script>
    <script src="../js/TvsScript.js"></script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div style="width:auto; min-height:400px;">
    <table style="margin-top: -10px; margin-right: -15px!important; width: 100%!important; padding: 0px!important; " border="0">
        <tr>
            <td>
                <input type="text" id="txtSearch" placeholder="Nhập tên NLĐ, số CMND, số BHXH, số điện thoại để tìm kiếm" runat="server" class="form-control" />
            </td>
             <td style="width: 280px;">
                <label>Từ ngày</label>
                    <div class='input-group date' style="margin-left: 0px; width: 70% !important; float:left;">
                    <input type='text' class="form-control dateinput" id="txtNgaySinh" runat="server" />
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar" style="position:relative; z-index:9999;"></span>
                    </span>
                </div>          
             </td>
            <td style="width: 280px;">
           <label>Đến ngày</label>
                   <div class='input-group date' style="margin-left: 0px; width: 70% !important; float:left;">
                    <input type='text' class="form-control dateinput" id="Text1" runat="server" />
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>          
            </td>
            <td style="width: 40px !important; text-align: center;">
                <asp:ImageButton ID="btnSearch" ImageUrl="../images/Search.png" runat="server" Style="margin-top: 5px;" />
            </td>
            <td style="width: 90px !important; text-align: center;">
                &nbsp;</td>
        </tr>
    </table>
    <asp:Repeater ID="dtlData" runat="server" EnableViewState="False">
        <HeaderTemplate>
            <table class="DataListTable" border="0" style="width: 100%; margin-top: 10px;">
                <tr style="height: 40px;" class="DataListTableHeader">
                    <td class="DataListTableHeaderTdItemTT" style="width: 3%;">#</td>
                    <td class="DataListTableHeaderTdItemJustify">Người lao động</td>
                    <td class="DataListTableHeaderTdItemJustify" style="width: 13%;">Tình trạng</td>
                    <td class="DataListTableHeaderTdItemJustify" style="width: 10%;">Số CMND</td>
                    <td class="DataListTableHeaderTdItemJustify" style="width: 10%;">Số BHXH</td>
                    <td class="DataListTableHeaderTdItemJustify" style="width: 10%;">Ngày hoàn thiện</td>
                    <td class="DataListTableHeaderTdItemJustify" style="width: 10%;">Thông tin BH</td>
                    <td class="DataListTableHeaderTdItemCenter" style="width: 6%;">&nbsp;</td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td class="DataListTableTdItemTT"><%= index++ %></td>
                <td class="DataListTableTdItemJustify"><%# Eval("HoVaTen") %></td>
                <td class="DataListTableTdItemJustify" style="color: red;"><%# Eval("TrangThai").ToString().Replace("Chuyển thẩm định","<span class = \"TrangThai\">Chuyển thẩm định</span>") %></td>
                <td class="DataListTableTdItemJustify"><%# Eval("CMND") %></td>
                <td class="DataListTableTdItemJustify"><%# Eval("BHXH") %></td>
                <td class="DataListTableTdItemJustify">
                    <%# (Eval("NgayHoanThien").ToString() != "")?((DateTime)Eval("NgayHoanThien")).ToString("dd/MM/yyyy"):"" %><br />                 
                </td>
                <td class="DataListTableTdItemCenter">Đóng <%# Eval("SoThangBHTN").ToString() != ""? Eval("SoThangBHTN") :"0"%> tháng
                </td>
                <td class="DataListTableTdItemCenter">
                    <a href="ThamDinh.aspx?id=<%#Eval("IDNLDTCTN")%>">
                        <img src="/Images/Forward.png" alt="Thẩm định" title ="Thẩm định"></a>  
                     <a href="#TrinhKyModal" onclick="delmodal(<%# Eval("IDNguoiLaoDong") %>)"> <img src="/Images/Edit.png" alt="Trình ký - đánh số" title ="Trình ký - đánh số"></a>               
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


    <input id="idNLD" type="hidden" runat="server" />
    <!-- Modal -->
    <div id="TrinhKyModal" class="modal fade" role="dialog">
        <div class="modal-dialog" style="display:table;">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Trình ký - đánh số</h4>
                </div>
                <div class="modal-body">           
                    <label>Trình ký ngày: </label>
                    <div class='input-group date' style="margin-left: 0px; width: 70% !important; float:left;">
                    <input type='text' class="form-control dateinput" id="txtNgayTrinhKy" runat="server" />
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar" style="position:relative; z-index:9999;"></span>
                    </span>
                </div>         
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnTrinhKy" runat="server" CssClass="btn btn-primary" Text="Trình ký" OnClick="btnTrinhKy_Click" />
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
    </script>
 </div>
</asp:Content>
