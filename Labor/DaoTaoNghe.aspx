<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="DaoTaoNghe.aspx.cs" Inherits="Labor_DaoTaoNghe" %>

<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="Server">

    <style>
        #tableview th {
            vertical-align: inherit;
            padding: 2px !important;
        }

        #tableview td {
            padding: 0px !important;
        }

        .table-responsive2 {
            width: 100%;
            margin-bottom: 5px;
            overflow-x: auto;
            overflow-y: hidden;
            -webkit-overflow-scrolling: touch;
            -ms-overflow-style: -ms-autohiding-scrollbar;
            border: 1px solid #ddd;
        }

        .th {
        }

        .table-responsive2 table {
            table-layout: fixed;
        }

        .tableheader {
            border: solid 1px black;
            width: 2549px;
            margin-bottom: 0px;
        }

        .tablebody {
            height: 400px;
            overflow-y: auto;
            width: 2565px;
            margin-bottom: 20px;
        }

        .headcol {
            position: absolute;
            width: 5em;
            left: 0;
            top: auto;
            border-top-width: 1px;
            /*only relevant for first row*/
            margin-top: -1px;
            /*compensate for top border*/
        }
    </style>
    <script src="../js/TvsScript.js"></script>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div style="min-height:600px;">
    <table class="table" style="margin-top: -20px;">
        <tr>
            <td>
                <input type="text" id="txtSearch" placeholder="Nhập tên người lao động để tìm kiếm" runat="server" class="form-control" />
            </td>
            <%--<td style="width: 180px;">
                <asp:DropDownList ID="dtlLoaiKhoaHoc" runat="server" CssClass="form-control">
                    <asp:ListItem Value="0">-- Loại khóa học --</asp:ListItem>
                    <asp:ListItem Value="1">Học việc</asp:ListItem>
                    <asp:ListItem Value="2">Học tiếng</asp:ListItem>
                </asp:DropDownList>
            </td>--%>
            <td style="width: 180px;">
                <div class='input-group date' id='datetimepicker1' style="margin-left: 0px; width: 100% !important; float: right;">
                                <input type='text' class="form-control" id="txtFromDate" runat="server" />
                                <span class="input-group-addon">
                                    <span class="glyphicon glyphicon-calendar"></span>
                                </span>
                            </div>

                            <script type="text/javascript">
                                $(function () {
                                    $('#datetimepicker1').datetimepicker({
                                        format: 'DD/MM/YYYY'
                                    });
                                });
                            </script>
            </td>
            <td style="width: 180px;">
                <div class='input-group date' id='datetimepicker2' style="margin-left: 0px; width: 100% !important; float: right;">
                                <input type='text' class="form-control" id="txtToDate" runat="server" />
                                <span class="input-group-addon">
                                    <span class="glyphicon glyphicon-calendar"></span>
                                </span>
                            </div>

                            <script type="text/javascript">
                                $(function () {
                                    $('#datetimepicker2').datetimepicker({
                                        format: 'DD/MM/YYYY'
                                    });
                                });
                            </script>
            </td>
            <td style="width: 300px;">
                <asp:DropDownList ID="ddlMonHoc" runat="server" CssClass="form-control">
                    <asp:ListItem Value="0">-- Môn học --</asp:ListItem>
                    <asp:ListItem Value="1">Học việc</asp:ListItem>
                    <asp:ListItem Value="2">Học tiếng</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="width: 180px;">
                <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control">
                    <asp:ListItem Value="0">Chưa xử lý</asp:ListItem>
                    <asp:ListItem Value="1">Đang xử lý</asp:ListItem>
                    <asp:ListItem Value="2">Đã xử lý</asp:ListItem>
                    <asp:ListItem Value="3" Selected="True">-- Trạng thái --</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="width: 40px !important; text-align: center;">
                <asp:ImageButton ID="btnSearch" ImageUrl="../images/Search.png" runat="server" Style="margin-bottom: -15px; margin-left: -15px;" OnClick="btnSearch_Click" />
            </td>
        </tr>
    </table>

    <asp:Repeater ID="dtlData" runat="server" EnableViewState="False">
        <HeaderTemplate><% this.index = 1; %>
            <table class="DataListTable" style="height: 40px;">
                <tr class="DataListTableHeader">
                    <th class="DataListTableHeaderTdItemTT" style="width: 4%;">STT</th>
                    <th class="DataListTableHeaderTdItemJustify">Họ Và Tên</th>
                    <th class="DataListTableHeaderTdItemJustify"  style="width: 10%;">CMND</th>
                    <th class="DataListTableHeaderTdItemJustify"  style="width: 10%;">Ngày sinh</th>
                    <th class="DataListTableHeaderTdItemJustify"  style="width: 10%;">Loại khóa học</th>
                    <th class="DataListTableHeaderTdItemJustify"  style="width: 20%;">Môn học</th>
                    <th class="DataListTableHeaderTdItemJustify"  style="width: 10%;">Ngày bắt đầu</th>
                    <th class="DataListTableHeaderTdItemJustify" style="width: 10%;">Trạng thái</th>
                    <th class="DataListTableHeaderTdItemCenter" style="width: 3%;">Sửa</th>
                    <th class="DataListTableHeaderTdItemCenter" style="width: 3%;">Xóa</th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr style="height: 36px;">
                <td class="DataListTableTdItemTT"><%# this.index++ %></td>
                <td class="DataListTableTdItemJustify"><%# Eval("HoVaTen") %></td>
                <td class="DataListTableTdItemJustify"><%# Eval("CMND") %></td>
                <td class="DataListTableTdItemJustify"><%# (Eval("NgaySinh").ToString() != "")? ((DateTime)Eval("NgaySinh")).ToString("dd/MM/yyyy"):"" %></td>
                <td class="DataListTableTdItemJustify"><%# Eval("LoaiKhoaHoc") %></td>
                <td class="DataListTableTdItemJustify"><%# Eval("NameKhoaHoc") %></td>
                <td class="DataListTableTdItemJustify"><%# (Eval("NgayBatDau").ToString() != "")? ((DateTime)Eval("NgayBatDau")).ToString("dd/MM/yyyy"):"" %></td>
                <%--<td class="DataListTableTdItemJustify"><%# Eval("ACCT_EMAIL") %></td>--%>
                <td class="DataListTableTdItemJustify"><%# Eval("State").ToString().Replace("0","Chưa xử lý").Replace("1","Đang xử lý").Replace("2","Đã xử lý") %></td>
                <td class="DataListTableTdItemCenter">
                    <a href="DaoTaoNgheEdit.aspx?id=<%# Eval("IDNldDaoTao") %>">
                        <img src="/Images/Edit.png" alt=""></a>
                </td>
                <td class="DataListTableTdItemCenter">
                    <a href="DaoTaoNgheDel.aspx?id=<%# Eval("IDNldDaoTao") %>">
                        <img src="/Images/delete.png" alt=""></a>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>


    <cc1:CollectionPager ID="cpTuVanXuatKhau" runat="server" BackText="" FirstText="Đầu"
        ControlCssClass="ProductPage" LabelText="" LastText="Cuối" NextText="" UseSlider="true"
        ResultsFormat="" BackNextLinkSeparator="" ResultsLocation="None" BackNextLocation="None"
        PageNumbersSeparator="&nbsp;">
    </cc1:CollectionPager>
    </div>

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

    <script>
        $(function () {
            /* QUICK SEARCH - Tìm nhanh */
            $('#tableview').searchable({
                searchField: '#MainContent_txtSearch',
                //  selector: 'td',
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

