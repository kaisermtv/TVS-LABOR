﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="NganhNghe.aspx.cs" Inherits="Admin_NganhNghe" %>

<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">


    <table class="table" border ="0" style ="margin-top:-20px;">
        <tr>
            <td>
                <input type="text" id="txtSearch" placeholder="Nhập mã hoặc tên ngành nghề để tìm kiếm" runat="server" class="form-control" />
            </td>
            <td style="width: 40px !important; text-align: center;">
                <asp:ImageButton ID="btnSearch" ImageUrl="../images/Search.png" runat="server" Style="margin-bottom: -15px; margin-left: -15px;" OnClick="btnSearch_Click" />
            </td>
        </tr>
    </table>

    <div style="width: 100%; margin-top:-20px;">
        <table class="DataListTableHeader" border ="0">
            <tr style ="height:40px;">
                <td class="DataListTableHeaderTdItemTT" style="width: 3%;">#
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 15%;">Mã số
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 36%;">Tên ngành nghề
                </td>
                 <td class="DataListTableHeaderTdItemJustify" style="width: 30%;">Ghi chú
                </td>
                 <td class="DataListTableHeaderTdItemJustify" style="width: 10%;">Trạng thái
                </td>
                <td class="DataListTableHeaderTdItemCenter" style="width: 6%;">&nbsp;
                </td>
            </tr>
        </table>
    </div>

    <asp:DataList ID="dtlNganhNghe" runat="server" RepeatDirection="Horizontal" RepeatColumns="1"
        Width="100%">
        <ItemTemplate>
            <table class="DataListTable" border="0">
                <tr style ="height:36px;">
                    <td class="DataListTableTdItemTT" style="width: 3%;">
                        <%# Eval("TT") %>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 15%;">
                        <%# Eval("CodeDTNganhNghe") %>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 36%;">
                        <%# Eval("NameDTNganhNghe") %>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 30%;">
                        <%# Eval("Note") %>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 10%;">
                        <%# Eval("StateName") %>
                    </td>
                    <td class="DataListTableTdItemCenter" style="width: 3%;">
                        <a href="NganhNgheEdit.aspx?id=<%# Eval("IDDTNganhNghe") %>">
                            <img src="../Images/Edit.png" alt=""></a>
                    </td>
                    <td class="DataListTableTdItemCenter" style="width: 3%;">
                        <a href="NganhNgheDel.aspx?id=<%# Eval("IDDTNganhNghe") %>">
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
                <cc1:CollectionPager ID="cpNganhNghe" runat="server" BackText="" FirstText="Đầu"
                    ControlCssClass="ProductPage" LabelText="" LastText="Cuối" NextText="" UseSlider="true"
                    ResultsFormat="" BackNextLinkSeparator="" ResultsLocation="None" BackNextLocation="None"
                    PageNumbersSeparator="&nbsp;">
                </cc1:CollectionPager>
            </td>
        </tr>
    </table>
    <br />
    <a href="NganhNgheEdit.aspx">
        <input type="text" value="Thêm mới" class="btn btn-primary" style="width: 90px !important;" /></a>
    <a href="ListCategory.aspx">
        <input type="text" value="Thoát" class="btn btn-default" style="width: 90px !important;" /></a>



     <script src="../js/TvsScript.js"></script>         <!--chứa qick search-->
     <script>
         $(function () {
             /* QUICK SEARCH - Tìm nhanh , tìm mọi thứ  */
             $('#MainContent_dtlNganhNghe').searchable({       // lấy thẻ chứa ngoài cùng
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
    </script>
</asp:Content>

