﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="TrinhDoPhoThong.aspx.cs" Inherits="Admin_TrinhDoPhoThong" %>

<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div style="width: 100%; height: 35px; line-height: 35px; margin-bottom: 10px;">
        <div class="AdminLeftItem">
            TRÌNH ĐỘ PHỔ THÔNG
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtSearch" runat="server" CssClass ="form-control" Style="width: 35% !important; float:left;"></asp:TextBox>&nbsp;
            <asp:ImageButton ID="btnSearch" ImageUrl="../images/Search.png" runat="server" Style="margin-bottom: -8px;" OnClick="btnSearch_Click" />
        </div>
    </div>

    <div style="width: 100%;">
        <table class="DataListTableHeader" border ="0">
            <tr style ="height:40px;">
                <td class="DataListTableHeaderTdItemTT" style="width: 3%;">#
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 15%;">Mã số
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 36%;">Tên trình độ phổ thông
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

    <asp:DataList ID="dtlTrinhDoPhoThong" runat="server" RepeatDirection="Horizontal" RepeatColumns="1"
        Width="100%">
        <ItemTemplate>
            <table class="DataListTable" border="0">
                <tr style ="height:36px;">
                    <td class="DataListTableTdItemTT" style="width: 3%;">
                        <%# Eval("TT") %>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 15%;">
                        <%# Eval("CodeTrinhDoPhoThong") %>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 36%;">
                        <%# Eval("NameTrinhDoPhoThong") %>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 30%;">
                        <%# Eval("Note") %>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 10%;">
                        <%# Eval("StateName") %>
                    </td>
                    <td class="DataListTableTdItemCenter" style="width: 3%;">
                        <a href="TrinhDoPhoThongEdit.aspx?id=<%# Eval("IDTrinhDoPhoThong") %>">
                            <img src="../Images/Edit.png" alt=""></a>
                    </td>
                    <td class="DataListTableTdItemCenter" style="width: 3%;">
                        <a href="TrinhDoPhoThongDel.aspx?id=<%# Eval("IDTrinhDoPhoThong") %>">
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
                <cc1:CollectionPager ID="cpTrinhDoPhoThong" runat="server" BackText="" FirstText="Đầu"
                    ControlCssClass="ProductPage" LabelText="" LastText="Cuối" NextText="" UseSlider="true"
                    ResultsFormat="" BackNextLinkSeparator="" ResultsLocation="None" BackNextLocation="None"
                    PageNumbersSeparator="&nbsp;">
                </cc1:CollectionPager>
            </td>
        </tr>
    </table>
    <br />
    <a href="TrinhDoPhoThongEdit.aspx">
        <input type="text" value="Thêm mới" class="btn btn-primary" style="width: 90px !important;" /></a>

</asp:Content>

