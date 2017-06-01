<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin.master" CodeFile="DanhMuc.aspx.cs" Inherits="Category_DanhMuc" %>

<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>

<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:Repeater ID="dtlData" runat="server" EnableViewState="False">
        <HeaderTemplate>
            <table class="DataListTable" style="height: 40px;">
                <tr class="DataListTableHeader">
                    <th class="DataListTableHeaderTdItemTT" style="width: 4%;">TT</th>
                    <th class="DataListTableHeaderTdItemJustify">Tên danh mục</th>
                    <th class="DataListTableHeaderTdItemJustify" style="width: 10%;">Trạng thái</th>
                    <th class="DataListTableHeaderTdItemCenter" style="width: 3%;">Sửa</th>
                    <th class="DataListTableHeaderTdItemCenter" style="width: 3%;">Xóa</th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr style="height: 36px;">
                <td class="DataListTableTdItemTT"><%# this.index++ %></td>
                <td class="DataListTableTdItemJustify"><%# Eval("NameDanhMuc") %></td>
                <%--<td class="DataListTableTdItemJustify"><%# Eval("ACCT_EMAIL") %></td>--%>
                <td class="DataListTableTdItemJustify"><%# Eval("State").ToString().Replace("True","Kích hoạt").Replace("False","-/-") %></td>
                <td class="DataListTableTdItemCenter">
                    <a href="DanhMucEdit.aspx?id=<%# Eval("IdDanhMuc") %>">
                        <img src="/Images/Edit.png" alt=""></a>
                </td>
                <td class="DataListTableTdItemCenter">
                    <a href="DanhMucDel.aspx?id=<%# Eval("IdDanhMuc") %>">
                        <img src="/Images/delete.png" alt=""></a>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <cc1:CollectionPager ID="cpData" runat="server" BackText="" FirstText="Đầu"
        ControlCssClass="ProductPage" LabelText="" LastText="Cuối" NextText="" UseSlider="true"
        ResultsFormat="" BackNextLinkSeparator="" ResultsLocation="None" BackNextLocation="None"
        PageNumbersSeparator="&nbsp;">
    </cc1:CollectionPager>

    <br />
    <a href="DanhMucEdit.aspx?dm=<%=itemId %>" class="btn btn-primary">Thêm mới</a>
</asp:Content>
