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

    <table class="table" border="0" style ="margin-top:-20px;">
        <tr style="height: 30px;">
            <th style="width: 3%;padding-top: 5px!important; padding-bottom: 5px!important;">#
            </th>
            <th style="width: 15%;padding-top: 5px!important; padding-bottom: 5px!important;">Người lao động
            </th>
            <th style ="padding-top: 5px!important; padding-bottom: 5px!important;">Công việc đăng ký
            </th>
            <th style="width: 130px;padding-top: 5px!important; padding-bottom: 5px!important;">Lương thấp nhất
            </th>
            <th style="width: 105px;padding-top: 5px!important; padding-bottom: 5px!important;">Ngày đăng ký
            </th>
            <th style="width: 90px;padding-top: 5px!important; padding-bottom: 5px!important;">Trạng thái
            </th>
            <th style="width: 82px;padding-top: 5px!important; padding-bottom: 5px!important;">&nbsp;
            </th>
        </tr>

        <asp:Repeater ID="dtlDangKyViecLam" runat="server">
            <ItemTemplate>
                <tbody>
                    <tr>
                        <td style="padding-top: 5px!important; padding-bottom: 5px!important;">
                            <%# Eval("TT") %>
                        </td>
                        <td style="padding-top: 5px!important; padding-bottom: 0px!important;">
                            <%# Eval("HoVaTen") %>
                        </td>
                        <td style="padding-top: 5px!important; padding-bottom: 0px!important;">
                            <%# Eval("ViTriCongViec") %>
                        </td>
                        <td style="padding-top: 5px!important; padding-bottom: 0px!important; text-align: right;">
                            <%# Eval("MucLuongThapNhat","{0:0,0}") %>
                        </td>
                        <td style="padding-top: 5px!important; padding-bottom: 0px!important;">
                            <%# Eval("NgayDangKy","{0:dd/MM/yyyy}") %>
                        </td>
                        <td style="padding-top: 5px!important; padding-bottom: 0px!important;">
                            <%# Eval("NameState") %>
                        </td>
                        <td style="padding-top: 2px!important; padding-bottom: 0px!important; text-align:right; padding-right:0px!important;">
                            <a href="DangKyViecLamEdit.aspx?id=<%# Eval("IDNldDangKy") %>">
                                <img src="../Images/Edit.png" alt=""></a>
                            <a href="DangKyViecLamDel.aspx?id=<%# Eval("IDNldDangKy") %>">
                                <img src="../Images/delete.png" alt=""></a>
                        </td>
                    </tr>
                </tbody>
            </ItemTemplate>
        </asp:Repeater>

    </table>

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

     <footer style="height: 43px !important; margin-bottom: 0px; margin-left: -30px; width: 100%; text-align: justify; background-color: #f0f0f0;">
        <table border="0" style="width: 95%; margin-top: -8px;">
            <tr>
                <td style="width: 800px; padding-left: 15px;">
                    &nbsp
                </td>
                <td style ="text-align:right;">
                    <a href="../Admin/Default.aspx"><input type="text" value="Thoát" class="btn btn-default" style="width: 90px !important;" /></a>
                </td>
            </tr>
        </table>
    </footer>

    <script src="../js/TvsScript.js"></script>
    <!--chứa qick search-->
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

