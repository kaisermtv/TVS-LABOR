<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="TuVanXuatKhau.aspx.cs" Inherits="Labor_TuVanXuatKhau" %>

<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <table class="table" style="margin-top: -20px;">
        <tr>
            <td>
                <input type="text" id="txtSearch" placeholder="Nhập tên người lao động để tìm kiếm" runat="server" class="form-control" />
            </td>
            <td style="width: 180px;">
                <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control">
                    <asp:ListItem Value="0">Chưa xử lý</asp:ListItem>
                    <asp:ListItem Value="1">Đang xử lý</asp:ListItem>
                    <asp:ListItem Value="2">Đã xử lý</asp:ListItem>
                    <asp:ListItem Value="3" Selected="True">Trạng thái</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="width: 40px !important; text-align: center;">
                <asp:ImageButton ID="btnSearch" ImageUrl="../images/Search.png" runat="server" Style="margin-bottom: -15px; margin-left: -15px;" OnClick="btnSearch_Click" />
            </td>
        </tr>
    </table>
    <div style="width: 100%; margin-top: -20px;">
        <table class="DataListTableHeader" border="0">
            <tr style="height: 40px;">
                <td class="DataListTableHeaderTdItemTT" style="width: 3%;">#
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 15%;">Người lao động
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 34%;">Đơn vị tuyển dụng
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 21%;">Người xử lý
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 10%;">Ngày tư vấn
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 12%;">Trạng thái
                </td>
                <td class="DataListTableHeaderTdItemCenter" style="width: 6%;">&nbsp;
                </td>
            </tr>
        </table>
    </div>
    <asp:DataList ID="dtlTuVanXuatKhau" runat="server" RepeatDirection="Horizontal" RepeatColumns="1"
        Width="100%">
        <ItemTemplate>
            <table class="DataListTable" border="0">
                <tr style="height: 40px;">
                    <td class="DataListTableTdItemTT" style="width: 3%;">
                        <%# Eval("TT") %>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 15%;">
                        <a href="TuVanXuatKhauEdit.aspx?id=<%# Eval("IDNldXuatKhau") %>"><%# Eval("HoVaTen") %></a>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 34%;">
                        <%# Eval("TenDonVi") %>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 21%;">
                        <%# Eval("NguoiXuLy") %>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 10%;">
                        <%# Eval("NgayDangKyTuVan","{0:dd/MM/yyyy}") %>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 12%;">
                        <%# Eval("NameState") %>
                    </td>
                    <td class="DataListTableTdItemCenter" style="width: 3%;">
                        <a href="TuVanXuatKhauEdit.aspx?id=<%# Eval("IDNldXuatKhau") %>">
                            <img src="../Images/Edit.png" alt=""></a>
                    </td>
                    <td class="DataListTableTdItemCenter" style="width: 3%;">
                        <a href="TuVanXuatKhauDel.aspx?id=<%# Eval("IDNldXuatKhau") %>">
                            <img src="../Images/delete.png" alt="" style="margin-right: 8px;"></a>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
    <table width="100%" cellpadding="0" cellspacing="0" border="0" style="margin-top: 5px; background-color: #fbf4f4; height: 26px;"
        id="tblABC" runat="server">
        <tr>
            <td style="padding-left: 6px;">
                <cc1:CollectionPager ID="cpTuVanXuatKhau" runat="server" BackText="" FirstText="Đầu"
                    ControlCssClass="ProductPage" LabelText="" LastText="Cuối" NextText="" UseSlider="true"
                    ResultsFormat="" BackNextLinkSeparator="" ResultsLocation="None" BackNextLocation="None"
                    PageNumbersSeparator="&nbsp;">
                </cc1:CollectionPager>
            </td>
        </tr>
    </table>

    <footer style="height: 43px !important; margin-bottom: 0px; margin-left: -30px; width: 100%; text-align: justify; background-color: #f0f0f0;">
        <table border="0" style="width: 95%; margin-top: -8px;">
            <tr>
                <td style="width: 800px; padding-left: 15px;">
                    <a href="TuVanXuatKhauEdit.aspx">
                        <input type="text" value="Thêm mới" class="btn btn-primary" style="width: 90px !important;" /></a>
                </td>
                 <td style ="text-align:right;">
                    <a href="../Admin/Default.aspx"><input type="text" value="Thoát" class="btn btn-default" style="width: 90px !important;" /></a>
                </td>
            </tr>
        </table>
    </footer>

</asp:Content>

