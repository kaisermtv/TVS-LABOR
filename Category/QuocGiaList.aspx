<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin.master" CodeFile="QuocGiaList.aspx.cs" Inherits="Category_QuocGiaList" %>


<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="AdminHeaderItem">
        THÔNG TIN QUỐC GIA
    </div>
    <div style="width: 100%;">
        <table class="DataListTableHeader" border ="0">
            <tr style ="height:40px;">
                <td class="DataListTableHeaderTdItemTT" style="width: 3%;">#</td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 15%;">Mã số</td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 36%;">Tên quốc gia</td>
                 <td class="DataListTableHeaderTdItemJustify" style="width: 30%;">Khu vực</td>
                 <td class="DataListTableHeaderTdItemJustify" style="width: 10%;">Trạng thái</td>
                <td class="DataListTableHeaderTdItemCenter" style="width: 6%;"></td>
            </tr>
        </table>
    </div>

    <asp:DataList ID="dtlTinHoc" runat="server" RepeatDirection="Horizontal" RepeatColumns="1" Width="100%">
        <HeaderTemplate>
            <% tt = 1; %>
        </HeaderTemplate>
        <ItemTemplate>
            <table class="DataListTable" border="0">
                <tr style ="height:36px;">
                    <td class="DataListTableTdItemTT" style="width: 3%;">
                        <%# tt++ %>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 15%;">
                        <%# Eval("CodeQuocGia") %>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 36%;">
                        <%# Eval("NameQuocGia") %>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 30%;">
                        <%# Eval("Region") %>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 10%;">
                        <%# Eval("StateName") %>
                    </td>
                    <td class="DataListTableTdItemCenter" style="width: 3%;">
                        <a href="QuocGiaEdit.aspx?id=<%# Eval("IdQuocGia") %>">
                            <img src="../Images/Edit.png" alt=""></a>
                    </td>
                    <td class="DataListTableTdItemCenter" style="width: 3%;">
                        <a href="QuocGiaDel.aspx?id=<%# Eval("IdQuocGia") %>">
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
                <cc1:CollectionPager ID="cpTinHoc" runat="server" BackText="" FirstText="Đầu"
                    ControlCssClass="ProductPage" LabelText="" LastText="Cuối" NextText="" UseSlider="true"
                    ResultsFormat="" BackNextLinkSeparator="" ResultsLocation="None" BackNextLocation="None"
                    PageNumbersSeparator="&nbsp;">
                </cc1:CollectionPager>
            </td>
        </tr>
    </table>
    <br />
    <a href="QuocGiaEdit.aspx">
        <input type="text" value="Thêm mới" class="btn btn-primary" style="width: 90px !important;" /></a>

</asp:Content>
