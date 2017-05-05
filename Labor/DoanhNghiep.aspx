﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="DoanhNghiep.aspx.cs" Inherits="Admin_DoanhNghiep" %>

<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
       <script src="../js/TvsScript.js"></script>
    <table class="table" border="0" style="margin-top: -20px;">
        <tr>
            <td>
                <input type="text" id="txtSearch" placeholder="Nhập mã hoặc tên doanh nghiệp để tìm kiếm" runat="server" class="form-control" />
            </td>
            <td style="width: 40px !important; text-align: center;">
                <asp:ImageButton ID="btnSearch" ImageUrl="../images/Search.png" runat="server" Style="margin-bottom: -15px; margin-left: -15px;" OnClick="btnSearch_Click" />
            </td>
        </tr>
    </table>

    <div style="width: 100%; margin-top: -20px">
        <table class="DataListTableHeader" border="0">
            <tr style="height: 40px;">
                <td class="DataListTableHeaderTdItemTT" style="width: 3%;">#
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 15%;">Mã số
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 36%;">Tên doanh nghiệp
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 30%;">Địa chỉ
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 10%;">Trạng thái
                </td>
                <td class="DataListTableHeaderTdItemCenter" style="width: 6%;">&nbsp;
                </td>
            </tr>
        </table>
    </div>

    <asp:DataList ID="dtlDoanhNghiep" runat="server" RepeatDirection="Horizontal" RepeatColumns="1"
        Width="100%">
        <ItemTemplate>
            <table class="DataListTable" border="0">
                <tr style="height: 40px;">
                    <td class="DataListTableTdItemTT" style="width: 3%;">
                        <%# Eval("TT") %>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 15%;">
                        <%# Eval("MaDonVi") %>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 36%;">
                  <span class="name">      <%# Eval("TenDonVi") %>&nbsp;
                        <div class="badge">
                            <a href="TuyenDung.aspx?did=<%# Eval("IDDonVi") %>&n=<%# Eval("TenDonVi") %>"><%# Eval("CountItem") %></a></div>
                   </span>
                       </td>
                    <td class="DataListTableTdItemJustify" style="width: 30%;">
                        <%# Eval("Diachi") %>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 6%;">
                        <%# Eval("StateName") %>
                    </td>
                    <td class="DataListTableTdItemCenter" style="width: 12%;">
                         <a href="#" onclick="XemTinTuyenDungTaiDoanhNghiep(<%# Eval("IDDonVi") %> ,'<%# Eval("TenDonVi") %>')">
                                <img src="../Images/Print.png" />
                          </a>
                        <a href="DoanhNghiepEdit.aspx?id=<%# Eval("IDDonVi") %>">
                            <img src="../Images/Edit.png" alt="" ></a>
                        <a href="DoanhNghiepDel.aspx?id=<%# Eval("IDDonVi") %>">
                            <img src="../Images/delete.png" alt=""></a>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
    <table width="100%" cellpadding="0" cellspacing="0" border="0" style="margin-top: 10px; height: 26px;"
        id="tblABC" runat="server">
        <tr>
            <td style="padding-left: 6px;">
                <cc1:CollectionPager ID="cpDoanhNghiep" runat="server" BackText="" FirstText="Đầu"
                    ControlCssClass="ProductPage" LabelText="" LastText="Cuối" NextText="" UseSlider="true"
                    ResultsFormat="" BackNextLinkSeparator="" ResultsLocation="None" BackNextLocation="None"
                    PageNumbersSeparator="&nbsp;">
                </cc1:CollectionPager>
            </td>
        </tr>
    </table>
    <br />
    <a href="DoanhNghiepEdit.aspx">
        <input type="text" value="Thêm mới" class="btn btn-primary" style="width: 90px !important;" /></a>

     <script>
         $(function () {
             /* QUICK SEARCH - Tìm nhanh */

             $('#MainContent_dtlDoanhNghiep').searchable({       // lấy thẻ chứa ngoài cùng
                 searchField: '#MainContent_txtSearch',        // lấy sự kiện tại txtSearch
                 selector: 'tr',                               // từng dòng là các thẻ <tr>
                 childSelector: 'td',                          // tìm tất cả các thẻ td
                 show: function (elem) {
                     elem.slideDown(100);                     // 100ms
                 },
                 hide: function (elem) {
                     elem.slideUp(100);                       // cuộn lên     
                 }
             })
         });
         function XemTinTuyenDungTaiDoanhNghiep(value_did,value_n) {
             var w = 1000;
             var h = 620;

             var dualScreenLeft = window.screenLeft != undefined ? window.screenLeft : screen.left;
             var dualScreenTop = window.screenTop != undefined ? window.screenTop : screen.top;

             var width = window.innerWidth ? window.innerWidth : document.documentElement.clientWidth ? document.documentElement.clientWidth : screen.width;
             var height = window.innerHeight ? window.innerHeight : document.documentElement.clientHeight ? document.documentElement.clientHeight : screen.height;

             var left = ((width / 2) - (w / 2)) + dualScreenLeft;
             var top = ((height / 2) - (h / 2)) + dualScreenTop;

             var newWindow = window.open("PrintTuyenDungTaiDoanhNghiep.aspx?did=" + value_did + "&n=" + value_n, "Doanh nghiệp tuyển dụng", 'scrollbars=yes, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);

             if (window.focus) {
                 newWindow.focus();
             }

         }
    </script>

</asp:Content>

