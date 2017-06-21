<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/BHTN.master" CodeFile="DaoTaoThatNghiep.aspx.cs" Inherits="BHTN_DaoTaoThatNghiep" %>

<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
   
    <asp:Repeater ID="dtlData" runat="server" EnableViewState="False">
        <HeaderTemplate>
            <div class="table-responsive">
            <table class="DataListTable" border="0" style="width: 100%; margin-top: 10px;">
                <tr style="height: 40px;" class="DataListTableHeader">
                    <td class="DataListTableHeaderTdItemTT" style="width: 3%;">#</td>
                    <td class="DataListTableHeaderTdItemJustify">Người lao động</td>
                    <td class="DataListTableHeaderTdItemJustify" style="width: 10%;">Số BHXH</td>
                    <td class="DataListTableHeaderTdItemJustify" style="width: 10%;">Môn học</td>
                    <td class="DataListTableHeaderTdItemJustify" style="width: 10%;">Khóa học</td>
                    <td class="DataListTableHeaderTdItemJustify" style="width: 10%;">Thời gian học</td>
                    <td class="DataListTableHeaderTdItemJustify" style="width: 10%;">Ngày bắt đầu</td>
                    <td class="DataListTableHeaderTdItemCenter" style="width: 6%;">&nbsp;</td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td class="DataListTableTdItemTT">
                    <input type="checkbox" id ="ckbSelect<%=index++ %>" value ="<%# Eval("IDNldDaoTao") %>" />
                </td>
                <td class="DataListTableTdItemJustify"><%# Eval("HoVaTen") %></td>
                <td class="DataListTableTdItemJustify"><%# Eval("BHXH") %></td>
                <td class="DataListTableTdItemJustify"><%# Eval("NameDTMonHoc") %></td>
                <td class="DataListTableTdItemJustify"><%# Eval("NameKhoaHoc") %></td>
                <td class="DataListTableTdItemJustify"><%# Eval("ThoiGianHoc") %></td>
                <td class="DataListTableTdItemJustify"><%# Eval("NgayBatDau") %></td>

                <td class="DataListTableTdItemCenter">
                    <a href="DaoTaoThatNghiepEdit.aspx?id=<%# Eval("IDNldDaoTao") %>"><img src="/Images/Edit.png" alt=""></a>
                    <%--<a href="DaoTaoThatNghiepDel.aspx?id=<%# Eval("IdNLDTCTN") %>"><img src="/Images/Edit.png" alt=""></a>--%>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
            </div>
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

</asp:Content>

