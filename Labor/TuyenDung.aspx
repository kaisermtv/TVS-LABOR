<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="TuyenDung.aspx.cs" Inherits="Admin_TuyenDung" %>

<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <table class="table" style="margin-top: -20px;">
        <tr>
            <td>
                <input type="text" id="txtSearch" placeholder="Nhập nội dung cần tìm kiếm" runat="server" class="form-control" />
            </td>
            <td style="width: 180px;">
                <asp:DropDownList ID="ddlIDChucVu" CssClass = "form-control" runat="server" Style="width: 100%;">
                </asp:DropDownList>
            </td>
            <td style="width: 180px;">
                <asp:DropDownList ID="ddlIDMucLuong" CssClass = "form-control" runat="server" Style="width: 100%;">
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
                <td class="DataListTableHeaderTdItemJustify" style="width: 15%;">Mã số
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 32%;">Tên doanh nghiệp
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 10%;">Vị trí
                </td>
                <td class="DataListTableHeaderTdItemCenter" style="width: 10%;">Số lượng
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 14%;">Mức lương
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 8%;">Trạng thái
                </td>
                <td class="DataListTableHeaderTdItemCenter" style="width: 6%;">&nbsp;
                </td>
            </tr>
        </table>
    </div>

    <asp:DataList ID="dtlTuyenDung" runat="server" RepeatDirection="Horizontal" RepeatColumns="1"
        Width="100%">
        <ItemTemplate>
            <table class="DataListTable" border="0">
                <tr style="height: 40px;">
                    <td class="DataListTableTdItemTT" style="width: 3%;">
                        <%# Eval("TT") %>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 15%;">
                        <%# Eval("MaTuyenDung") %> &nbsp;<a href = "#"><div onclick ="XemTinTuyenDung('<%# Eval("IdTuyenDung") %>')" class="badge"><%# Eval("CountItem") %></div></a>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 32%;">
                        <%# Eval("TenDonVi") %>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 10%;">
                        <%# Eval("NameChucVu") %>
                    </td>
                    <td class="DataListTableTdItemCenter" style="width: 10%;">
                        <%# Eval("SoLuongTuyenDung") %>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 14%;">
                        <%# Eval("NameMucLuong") %>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 8%;">
                        <%# Eval("StateName") %>
                    </td>
                    <td class="DataListTableTdItemCenter" style="width: 6%;">
                        <a href="TuyenDungEdit.aspx?id=<%# Eval("IDTuyenDung") %>">
                            <img src="../Images/Edit.png" alt=""></a>
                         <a href="TuyenDung.aspx?id=<%# Eval("IDTuyenDung") %>">
                            <img src="../Images/top.png" alt="" title ="Thiết lập ưu tiên nhất" style ="margin-left:5px; margin-right:5px;"></a>
                        <a href="TuyenDungDel.aspx?id=<%# Eval("IDTuyenDung") %>">
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
                <cc1:CollectionPager ID="cpTuyenDung" runat="server" BackText="" FirstText="Đầu"
                    ControlCssClass="ProductPage" LabelText="" LastText="Cuối" NextText="" UseSlider="true"
                    ResultsFormat="" BackNextLinkSeparator="" ResultsLocation="None" BackNextLocation="None"
                    PageNumbersSeparator="&nbsp;">
                </cc1:CollectionPager>
            </td>
        </tr>
    </table>
    <br />
    <a href="TuyenDungEdit.aspx?did=<%Response.Write(this.IdDonVi.ToString()); %>&n=<%Response.Write(this.tenDonVi.ToString()); %>">
        <input type="text" value="Thêm mới" class="btn btn-primary" style="width: 90px !important;" /></a>
    
    <script type="text/javascript">
    function XemTinTuyenDung(value) {

            var w = 1000;
            var h = 620;

            var dualScreenLeft = window.screenLeft != undefined ? window.screenLeft : screen.left;
            var dualScreenTop = window.screenTop != undefined ? window.screenTop : screen.top;

            var width = window.innerWidth ? window.innerWidth : document.documentElement.clientWidth ? document.documentElement.clientWidth : screen.width;
            var height = window.innerHeight ? window.innerHeight : document.documentElement.clientHeight ? document.documentElement.clientHeight : screen.height;

            var left = ((width / 2) - (w / 2)) + dualScreenLeft;
            var top = ((height / 2) - (h / 2)) + dualScreenTop;
            var newWindow = window.open("XemDangKyViecLam.aspx?id=" + value, "TIN TUYỂN DỤNG", 'scrollbars=yes, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);

            if (window.focus) {
                newWindow.focus();
            }
        }
    </script>
</asp:Content>

