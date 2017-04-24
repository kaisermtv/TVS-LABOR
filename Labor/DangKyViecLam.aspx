<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="DangKyViecLam.aspx.cs" Inherits="Admin_DangKyViecLam" %>

<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <script type="text/javascript">
        $(function () {
            $('#datetimepicker1').datetimepicker({
                format: 'DD/MM/YYYY'
            });
        });

        $(function () {
            $('#datetimepicker2').datetimepicker({
                format: 'DD/MM/YYYY'
            });
        });

    </script>
    <table class="table" style="margin-top: -20px;">
        <tr>
            <td>
                <input type="text" id="txtSearch" placeholder="Nhập mã hoặc tên doanh nghiệp để tìm kiếm" runat="server" class="form-control" />
            </td>
            <td style="width: 180px;">
                <div class='input-group date' id='datetimepicker1' style="margin-left: 0px; width: 100% !important; float: right;">
                    <input type='text' class="form-control" id="txtNgayBatDau" runat="server" />
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>

                <script type="text/javascript">
                    $(function () {
                        $('#datetimepicker1').datetimepicker();
                    });
                </script>
            </td>
            <td style="width: 180px;">
                <div class='input-group date' id='datetimepicker2' style="margin-left: 0px; width: 100% !important; float: right;">
                    <input type='text' class="form-control" id="txtNgayKetThuc" runat="server" />
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>

                <script type="text/javascript">
                    $(function () {
                        $('#datetimepicker2').datetimepicker();
                    });
                </script>
            </td>
            <td style="width: 180px;">
                <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control">
                    <asp:ListItem Value="0" Selected="True">Chưa xử lý</asp:ListItem>
                    <asp:ListItem Value="1">Đang xử lý</asp:ListItem>
                    <asp:ListItem Value="2">Đã xử lý</asp:ListItem>
                    <asp:ListItem Value="3">Trạng thái</asp:ListItem>
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
                <td class="DataListTableHeaderTdItemJustify" style="width: 19%;">Tên công việc
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 15%;">Vị trí
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 15%;">Mức lương
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 15%;">Ngày đăng ký
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 12%;">Trạng thái
                </td>
                <td class="DataListTableHeaderTdItemCenter" style="width: 7%;">&nbsp;
                </td>
            </tr>
        </table>
    </div>

    <asp:DataList ID="dtlDangKyViecLam" runat="server" RepeatDirection="Horizontal" RepeatColumns="1"
        Width="100%">
        <ItemTemplate>
            <table class="DataListTable" border="0">
                <tr style="height: 40px;">
                    <td class="DataListTableTdItemTT" style="width: 3%;">
                        <%# Eval("TT") %>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 15%;">
                        <%# Eval("HoVaTen") %>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 19%;">
                        <%# Eval("TenCongViec") %>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 15%;">
                        <%# Eval("NameChucVu") %>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 15%;">
                        <%# Eval("NameMucLuong") %>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 15%;">
                        <%# Eval("NgayDangKy","{0:dd/MM/yyyy}") %>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 12%;">
                        <%# Eval("NameState") %>
                    </td>
                    <td class="DataListTableTdItemCenter" style="width: 7%;">
                        <a href="DangKyViecLamEdit.aspx?id=<%# Eval("IDNldDangKy") %>">
                            <img src="../Images/Edit.png" alt=""></a>&nbsp;
                        <a href="DangKyViecLamDel.aspx?id=<%# Eval("IDNldDangKy") %>">
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
                <cc1:CollectionPager ID="cpDangKyViecLam" runat="server" BackText="" FirstText="Đầu"
                    ControlCssClass="ProductPage" LabelText="" LastText="Cuối" NextText="" UseSlider="true"
                    ResultsFormat="" BackNextLinkSeparator="" ResultsLocation="None" BackNextLocation="None"
                    PageNumbersSeparator="&nbsp;">
                </cc1:CollectionPager>
            </td>
        </tr>
    </table>
    <br />
    <a href="DangKyViecLamEdit.aspx">
        <input type="text" value="Thêm mới" class="btn btn-primary" style="width: 90px !important;" /></a>

      <script src="../js/TvsScript.js"></script>         <!--chứa qick search-->
     <script>
         $(function () {
             /* QUICK SEARCH - Tìm nhanh , tìm mọi thứ  */
             $('#MainContent_dtlDangKyViecLam').searchable({       // lấy thẻ chứa ngoài cùng
                 searchField: '#MainContent_txtSearch',        // lấy sự kiện tại txtSearch
                 selector: 'tr',                               // từng dòng là các thẻ <tr>
                 childSelector: 'td',                          // tìm tất cả các thẻ td
                 show: function (elem) {
                     elem.slideDown(100);                     // 100ms
                 },
                 hide: function (elem) {
                     elem.slideUp(100);                       // cuộn lên     
                 }
             })
         });
    </script>
</asp:Content>

