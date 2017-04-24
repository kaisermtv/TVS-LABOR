<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin.master" CodeFile="Vitri.aspx.cs" Inherits="Category_Vitri" %>

<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:Repeater ID="dtlData" runat="server" EnableViewState="False">
        <HeaderTemplate>
            <table class="DataListTable" style ="height:40px;">
                <tr class="DataListTableHeader">
                    <th class="DataListTableHeaderTdItemTT" style="width: 4%;">TT</th>
                    <th class="DataListTableHeaderTdItemJustify">Tên vị trí</th>
                    <th class="DataListTableHeaderTdItemJustify" style="width: 10%;">Trạng thái</th>
                    <th class="DataListTableHeaderTdItemCenter" style="width: 6%;">Sửa | Xóa</th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr style="height: 36px;">
                <td class="DataListTableTdItemTT"><%# this.index++ %></td>
                <td class="DataListTableTdItemJustify"><%# Eval("NameViTri") %></td>
                <%--<td class="DataListTableTdItemJustify"><%# Eval("ACCT_EMAIL") %></td>--%>
                <td class="DataListTableTdItemJustify"><%# Eval("State").ToString().Replace("True","Kích hoạt").Replace("False","-/-") %></td>
                <td class="DataListTableTdItemCenter">
                    <a href="ViTriEdit.aspx?id=<%# Eval("ID") %>">
                        <img src="/Images/Edit.png" alt=""></a>
                    &nbsp;
                    <a href="ViTriDel.aspx?id=<%# Eval("ID") %>">
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
    <a href="ViTriEdit.aspx" class="btn btn-primary">Thêm mới</a>
</asp:Content>
