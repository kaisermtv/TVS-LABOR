<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="BaoHiemThatNghiep.aspx.cs" Inherits="Labor_BaoHiemThatNghiep" %>
<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="Server">
    <style>
        .DataListTable td {
            padding-top: 5px;
            padding-bottom: 5px;
        }
    </style>
   <script src="../js/TvsScript.js"></script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

    <table style="margin-top:-10px; margin-right:-15px!important; width:100%!important;padding:0px!important;" border ="0">
        <tr>
            <td>
                <input type="text" id="txtSearch" placeholder="Nhập tên NLĐ, số CMND, số BHXH, số điện thoại để tìm kiếm" runat="server" class="form-control" />
            </td>
            <td style="width: 40px !important; text-align: center;">
                <asp:ImageButton ID="btnSearch" ImageUrl="../images/Search.png" runat="server" Style="margin-top:5px;" />
            </td>
            <td style="width: 90px !important; text-align: center;">
                <a href ="BaoHiemThatNghiepEdit.aspx"><input type ="button" class ="btn btn-primary" value ="Tạo hồ sơ" /></a>
            </td>
        </tr>
    </table>

    <asp:Repeater ID="dtlData" runat="server" EnableViewState="False">
            <HeaderTemplate>
                <table class="DataListTable" border="0" style="width: 100%; margin-top: 20px;">
                    <tr style="height: 40px;" class="DataListTableHeader">
                        <td class="DataListTableHeaderTdItemTT" style="width: 3%;">#</td>
                        <td class="DataListTableHeaderTdItemJustify" >Người lao động</td>
                        <td class="DataListTableHeaderTdItemJustify" style="width: 10%;" >Số CMND</td>
                        <td class="DataListTableHeaderTdItemJustify" style="width: 10%;" >Số BHXH</td>
                        <td class="DataListTableHeaderTdItemJustify" style="width: 10%;" >Ngày đăng</td>
                        <td class="DataListTableHeaderTdItemCenter" style="width: 5%;">&nbsp;</td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate >
                <tr>
                    <td class="DataListTableTdItemTT"><%= index++ %></td>
                    <td class="DataListTableTdItemJustify"><%# Eval("HoVaTen") %></td>
                    <td class="DataListTableTdItemJustify"><%# Eval("CMND") %></td>
                    <td class="DataListTableTdItemJustify"><%# Eval("BHXH") %></td>
                    <td class="DataListTableTdItemJustify"><%# Eval("BHXH") %></td>
                    <td class="DataListTableTdItemCenter">
                        <a href="BaoHiemThatNghiepEdit.aspx?id=<%# Eval("IDNguoiLaoDong") %>">
                            <img src="../Images/Edit.png" alt=""></a>
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
                    PageNumbersSeparator="&nbsp;">
                </cc1:CollectionPager>
            </td>
        </tr>
    </table>
</asp:Content>

