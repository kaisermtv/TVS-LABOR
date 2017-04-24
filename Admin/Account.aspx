<%@ Page Title="TÀI KHOẢN" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="Account.aspx.cs" Inherits="Admin_Account" %>

<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div style="width: 100%; height: 35px; line-height: 35px; margin-bottom: 10px;">
        <div class="AdminLeftItem">
            TÀI KHOẢN
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtSearch" runat="server" Style="width: 35% !important; height: 28px; line-height: 28px;"></asp:TextBox>
            <asp:ImageButton ID="btnSearch" ImageUrl="../images/Search.png" runat="server" Style="margin-bottom: -8px;" OnClick="btnSearch_Click" />
        </div>
    </div>
    <div style="width: 100%;">
        <table class="DataListTableHeader" border ="0">
            <tr style ="height:40px;">
                <td class="DataListTableHeaderTdItemTT" style="width: 3%;">#
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 15%;">Nhóm tài khoản
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 25%;">Tài khoản
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 26%;">Tên tài khoản
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 15%;">Vai trò quản lý
                </td>
                 <td class="DataListTableHeaderTdItemJustify" style="width: 10%;">Trạng thái
                </td>
                <td class="DataListTableHeaderTdItemCenter" style="width: 6%;">&nbsp;
                </td>
            </tr>
        </table>
    </div>
    <asp:DataList ID="dtlAccount" runat="server" RepeatDirection="Horizontal" RepeatColumns="1"
        Width="100%">
        <ItemTemplate>
            <table class="DataListTable" border="0">
                <tr style ="height:40px;">
                    <td class="DataListTableTdItemTT" style="width: 3%;">
                        <%# Eval("TT") %>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 15%;">
                        <%# Eval("GroupName") %>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 25%;">
                        <%# Eval("UserName") %>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 26%;">
                        <%# Eval("FullName") %>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 15%;">
                        <%# Eval("TypeName") %>
                    </td>
                     <td class="DataListTableTdItemJustify" style="width: 10%;">
                        <%# Eval("StateName") %>
                    </td>
                    <td class="DataListTableTdItemCenter" style="width: 3%;">
                        <a href="EditAccount.aspx?id=<%# Eval("Id") %>">
                            <img src="../Images/Edit.png" alt=""></a>
                    </td>
                    <td class="DataListTableTdItemCenter" style="width: 3%;">
                        <a href="DelAccount.aspx?id=<%# Eval("Id") %>">
                            <img src="../Images/delete.png" alt=""></a>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
    <table width="100%" cellpadding="0" cellspacing="0" border="0" style="margin-top: 5px; background-color: #fbf4f4; height: 26px;"
        id="tblABC" runat="server">
        <tr>
            <td style="padding-left: 6px;">
                <cc1:CollectionPager ID="cpAccount" runat="server" BackText="" FirstText="Đầu"
                    ControlCssClass="ProductPage" LabelText="" LastText="Cuối" NextText="" UseSlider="true"
                    ResultsFormat="" BackNextLinkSeparator="" ResultsLocation="None" BackNextLocation="None"
                    PageNumbersSeparator="&nbsp;">
                </cc1:CollectionPager>
            </td>
        </tr>
    </table>
    <br />
    <a href="EditAccount.aspx">
        <input type="text" value="Thêm mới" class="btn btn-primary" style="width: 90px !important;" /></a>

     <script src="../js/TvsScript.js"></script>         <!--chứa qick search-->
     <script>
         $(function () {
             /* QUICK SEARCH - Tìm nhanh , tìm mọi thứ  */
             $('#MainContent_dtlAccount').searchable({       // lấy thẻ chứa ngoài cùng
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

