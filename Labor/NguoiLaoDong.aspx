<%@ Page Title="NGƯỜI LAO ĐỘNG" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="NguoiLaoDong.aspx.cs" Inherits="Admin_NguoiLaoDong" %>

<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <table class="table" border ="0" style ="margin-top:-20px;">
        <tr>
            <td>
                <input type="text" id="txtSearch" placeholder="Nhập mã hoặc tên người lao động để tìm kiếm" runat="server" class="form-control" />
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
                <td class="DataListTableHeaderTdItemJustify" style="width: 10%;">Mã số
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 16%;">Họ và tên
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 9%;">Số CMND
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 11%;">Điện thoại
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 35%;">Ghi chú
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 10%;">Trạng thái
                </td>
                <td class="DataListTableHeaderTdItemCenter" style="width: 6%;">&nbsp;
                </td>
            </tr>
        </table>
    </div>

    <asp:DataList ID="dtlNguoiLaoDong" runat="server" RepeatDirection="Horizontal" RepeatColumns="1"
        Width="100%">
        <ItemTemplate>
            <table class="DataListTable" border="0">
                <tr style="height: 40px;">
                    <td class="DataListTableTdItemTT" style="width: 3%;">
                        <%# Eval("TT") %>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 10%;">
                        <%# Eval("Ma") %>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 16%;">
                        <%# Eval("HoVaTen") %> &nbsp;<div class="badge"><a href ="TuVan.aspx?n=<%# Eval("HoVaTen") %>"><%# Eval("CountItem") %></a></div>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 9%;">
                        <%# Eval("CMND") %>
                    </td>
                     <td class="DataListTableTdItemJustify" style="width: 11%;">
                        <%# Eval("DienThoai") %>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 35%;">
                        <%# Eval("DiaChi") %>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 10%;">
                        <%# Eval("StateName") %>
                    </td>
                    <td class="DataListTableTdItemCenter" style="width: 6%;">
                        <a href="NguoiLaoDongEdit.aspx?id=<%# Eval("IDNguoiLaoDong") %>">
                            <img src="../Images/Edit.png" alt=""></a>&nbsp;
                        <a href="NguoiLaoDongDel.aspx?id=<%# Eval("IDNguoiLaoDong") %>">
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
                <cc1:CollectionPager ID="cpNguoiLaoDong" runat="server" BackText="" FirstText="Đầu"
                    ControlCssClass="ProductPage" LabelText="" LastText="Cuối" NextText="" UseSlider="true"
                    ResultsFormat="" BackNextLinkSeparator="" ResultsLocation="None" BackNextLocation="None"
                    PageNumbersSeparator="&nbsp;">
                </cc1:CollectionPager>
            </td>
        </tr>
    </table>
    <br />
    <a href="NguoiLaoDongEdit.aspx">
        <input type="text" value="Thêm mới" class="btn btn-primary" style="width: 90px !important;" /></a>

</asp:Content>

