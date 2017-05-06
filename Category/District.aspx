<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="District.aspx.cs" Inherits="Admin_District" %>

<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <script src="../js/TvsScript.js"></script><!--chứa qick search-->
   <div style="width: 100%; height: 35px; line-height: 35px; margin-bottom: 10px;">
        <div class="AdminLeftItem">
            QUẬN, HUYỆN
        </div>
        <div class="AdminRightItem">
            <asp:DropDownList ID="ddlProvincer" runat="server" CssClass ="form-control" Style="width: 29.5%; float:left; margin-right:10px;" OnSelectedIndexChanged="ddlProvincer_SelectedIndexChanged"></asp:DropDownList>
            <asp:TextBox ID="txtSearch" runat="server" CssClass ="form-control" Style="width: 35% !important; float:left;"></asp:TextBox>&nbsp;
            <asp:ImageButton ID="btnSearch" ImageUrl="../images/Search.png" runat="server" Style="margin-bottom: -8px;" OnClick="btnSearch_Click" />
        </div>
    </div>

    <div style="width: 100%;">
        <table class="DataListTableHeader" border="0">
            <tr style="height: 40px;">
                <td class="DataListTableHeaderTdItemTT" style="width: 3%;">#
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 15%;">Mã huyện
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 56%;">Tên huyện
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 10%;">Số xã
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 10%;">Trạng thái
                </td>
                <td class="DataListTableHeaderTdItemCenter" style="width: 6%;">&nbsp;
                </td>
            </tr>
        </table>
    </div>

    <asp:DataList ID="dtlDistrict" runat="server" RepeatDirection="Horizontal" RepeatColumns="1"
        Width="100%">
        <ItemTemplate>
            <table class="DataListTable" border="0">
                <tr style="height: 36px;">
                    <td class="DataListTableTdItemTT" style="width: 3%;">
                        <%# Eval("TT") %>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 15%;">
                        <%# Eval("Code") %>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 56%;">
                 <span class="name">       <%# Eval("Name") %></span>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 10%;">
                        <%# Eval("CountItem") %>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 10%;">
                        <%# Eval("StateName") %>
                    </td>
                    <td class="DataListTableTdItemCenter" style="width: 3%;">
                        <a href="DistrictEdit.aspx?id=<%# Eval("Id") %>">
                            <img src="../Images/Edit.png" alt=""></a>
                    </td>
                    <td class="DataListTableTdItemCenter" style="width: 3%;">
                        <a href="DistrictDel.aspx?id=<%# Eval("Id") %>">
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
                <cc1:CollectionPager ID="cpDistrict" runat="server" BackText="" FirstText="Đầu"
                    ControlCssClass="ProductPage" LabelText="" LastText="Cuối" NextText="" UseSlider="true"
                    ResultsFormat="" BackNextLinkSeparator="" ResultsLocation="None" BackNextLocation="None"
                    PageNumbersSeparator="&nbsp;" PagingMode="PostBack">
                </cc1:CollectionPager>
            </td>
        </tr>
    </table>
    <br />
    <a href="DistrictEdit.aspx?tt=<%= ddlProvincer.SelectedValue %>">
        <input type="text" value="Thêm mới" class="btn btn-primary" style="width: 90px !important;" /></a>

       <script>
           $(function () {
               /* QUICK SEARCH - Tìm nhanh */
               $('#MainContent_dtlDistrict').searchable({       // lấy thẻ chứa ngoài cùng
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

