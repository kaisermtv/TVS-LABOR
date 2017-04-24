<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="TuVan.aspx.cs" Inherits="Labor_TuVan" %>

<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

    <script src="../js/TvsScript.js"></script>
    <table class="table" style="margin-top: -20px;">
        <tr>
            <td>
                <input type="text" id="txtSearch" placeholder="Nhập tên, số CMND, số BHXH, số điện thoại để tìm kiếm" runat="server" class="form-control" />
            </td>
            <td style="width: 40px !important; text-align: center;">
                <asp:ImageButton ID="btnSearch" ImageUrl="../images/Search.png" runat="server" Style="margin-bottom: -15px; margin-left: -15px;" OnClick="btnSearch_Click" />
            </td>
        </tr>
    </table>

    <div style="width: 100%; margin-top: -20px;">
        <table class="DataListTableHeader" border="0">
            <tr style="height: 40px;">
                <td class="DataListTableHeaderTdItemJustify" style="width: 18%;">Người lao động
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 10%;">Số BHXH
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 10%;">Số CMND
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 12%;">Email
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 10%;">Điện thoại
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 27%;">Địa chỉ
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 8%;">Ngày tư vấn
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 6%;">&nbsp;
                </td>
            </tr>
        </table>
    </div>
    <asp:DataList ID="dtlTuVanViecLam" runat="server" RepeatDirection="Horizontal" RepeatColumns="1"
        Width="100%">
        <ItemTemplate>
            <table class="DataListTable" border="0">
                <tr style="height: 40px;">
                    <td class="DataListTableTdItemJustify" style="width: 18%;">
                        <span class="name"><%# Eval("HoVaTen") %></span>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 10%;">
                        <%# Eval("BHXH") %>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 10%;">
                        <%# Eval("CMND") %>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 12%;">
                        <%# Eval("Email") %>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 10%;">
                        <%# Eval("DienThoai") %>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 27%;">
                        <%# Eval("DiaChi") %>
                    </td>
                    <td class="DataListTableTdItemCenter" style="width: 8%;">
                        <%# Eval("NgayTuVan","{0:dd/MM/yyyy}") %>
                    </td>
                    <td class="DataListTableTdItemCenter" style="width: 3%;">
                        <a href="TuVanEdit.aspx?id=<%# Eval("IDNldTuVan") %>&idNld=<%# Eval("IDNguoiLaoDong") %>">
                            <img src="../Images/Edit.png" alt=""></a>
                    </td>
                    <td class="DataListTableTdItemCenter" style="width: 3%; padding-right: 8px;">
                        <a href="TuVanDel.aspx?id=<%# Eval("IDNldTuVan") %>">
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
                <cc1:CollectionPager ID="cpTuVanViecLam" runat="server" BackText="" FirstText="Đầu"
                    ControlCssClass="ProductPage" LabelText="" LastText="Cuối" NextText="" UseSlider="true"
                    ResultsFormat="" BackNextLinkSeparator="" ResultsLocation="None" BackNextLocation="None"
                    PageNumbersSeparator="&nbsp;">
                </cc1:CollectionPager>
            </td>
        </tr>
    </table>
    <br />
    <a href="TuVanEdit.aspx">
        <input type="text" value="Thêm mới" class="btn btn-primary" style="width: 90px !important;" /></a>

    <script>
        $(function () {
            /* QUICK SEARCH - Tìm nhanh */

            $('#MainContent_dtlTuVanViecLam').searchable({
                searchField: '#MainContent_txtSearch',
                selector: 'tr',
                childSelector: 'td',
                show: function (elem) {
                    elem.slideDown(100);
                },
                hide: function (elem) {
                    elem.slideUp(100);
                }
            })
        });
    </script>

</asp:Content>

