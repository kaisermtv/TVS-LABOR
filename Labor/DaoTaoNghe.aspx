<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="DaoTaoNghe.aspx.cs" Inherits="Labor_DaoTaoNghe" %>
<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="Server">
    <style>
        #tableview th{
            vertical-align:inherit;
        }
    </style>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <table class="table" style="margin-top: -20px;">
        <tr>
            <td>
                <input type="text" id="txtSearch" placeholder="Nhập mã hoặc tên doanh nghiệp để tìm kiếm" runat="server" class="form-control" />
            </td>
            <td style="width: 180px;">
                <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control">
                    <asp:ListItem Value="0" Selected = "True">Chưa xử lý</asp:ListItem>
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
    <div style="width: 100%; margin-top:-20px;">
        <table class="DataListTableHeader" border="0">
            <tr style="height: 40px;">
                <td class="DataListTableHeaderTdItemTT" style="width: 3%;">STT
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 15%;">Họ & Tên
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 34%;">Ngày sinh
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 21%;">Địa chỉ
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 10%;">Giới tính
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 12%;">SĐT
                </td>
                <td class="DataListTableHeaderTdItemCenter" style="width: 6%;">Nhu cầu của lao động
                  <table>
                      <tr>
                        <td>Học ngoại ngữ 
                            <tr>
                                Tiếng Hàn
                            </tr>
                            <td>
                                Tiếng Nhật
                            </td>
                        </td>
                        <td>
                            Học nghề TN
                        </td>
                    </tr>
                </td>
                </table>  
            </tr>
        </table>
    </div>
    <asp:DataList ID="dtlTuVanXuatKhau" runat="server" RepeatDirection="Horizontal" RepeatColumns="1"
        Width="100%">
        <ItemTemplate>
            <table class="DataListTable" border="0">
                <tr style ="height:40px;">
                    <td class="DataListTableTdItemTT" style="width: 3%;">
                        <%# Eval("TT") %>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 15%;">
                        <%# Eval("HoVaTen") %>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 34%;">
                        <%# Eval("TenDonVi") %>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 21%;">
                        <%# Eval("KhoaHoc") %>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 10%;">
                        <%# Eval("NgayBatDau","{0:dd/MM/yyyy}") %>
                    </td>
                     <td class="DataListTableTdItemJustify" style="width: 12%;">
                        <%# Eval("NameState") %>
                    </td>
                    <td class="DataListTableTdItemCenter" style="width: 3%;">
                        <a href="DaoTaoNgheEdit.aspx?id=<%# Eval("IDNldDaoTao") %>">
                            <img src="../Images/Edit.png" alt=""></a>
                    </td>
                    <td class="DataListTableTdItemCenter" style="width: 3%;">
                        <a href="DaoTaoNgheDel.aspx?id=<%# Eval("IDNldDaoTao") %>">
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
                <cc1:CollectionPager ID="cpTuVanXuatKhau" runat="server" BackText="" FirstText="Đầu"
                    ControlCssClass="ProductPage" LabelText="" LastText="Cuối" NextText="" UseSlider="true"
                    ResultsFormat="" BackNextLinkSeparator="" ResultsLocation="None" BackNextLocation="None"
                    PageNumbersSeparator="&nbsp;">
                </cc1:CollectionPager>
            </td>
        </tr>
    </table>
    <br />
    <a href="TuVanXuatKhauEdit.aspx">
        <input type="text" value="Thêm mới" class="btn btn-primary" style="width: 90px !important;" />

    </a>

    <div class="table-responsive2">
        <table id="tableview" class="table table-bordered table-striped tableheader">
            <thead>
                <tr>
                    <th style="width: 50px; vertical-align: central" rowspan="3">STT</th>
                    <th style="width: 250px;" rowspan="3">Họ Và Tên</th>
                    <th style="width: 250px;" rowspan="3">Địa chỉ</th>
                    <th style="width: 50px;" rowspan="3">Giới tính</th>
                    <th style="width: 120px;" rowspan="3">SĐT</th>
                    <th colspan="3">Nhu cầu lao động</th>
                    <th style="width: 250px;" rowspan="3">NGÀNH NGHỀ HỌC CHO LĐ TN</th>
                    <th style="width: 120px;" rowspan="3">THỜI GIAN HỌC</th>
                    <th style="width: 100px;" rowspan="3">MỨC HỖ TRỢ CHO LĐ TN</th>
                    <th style="width: 380px;" rowspan="3">TRƯỜNG HỌC</th>
                    <th style="width: 80px;" rowspan="3">KHÓA HỌC</th>
                    <th style="width: 380px;" rowspan="3">ĐỊA CHỈ HỌC</th>
                    <th style="width: 250px;" rowspan="3">SĐT LIÊN HỆ</th>
                </tr>
                <tr>
                    <th colspan="2">Học ngoại ngữ</th>
                    <th rowspan="2">Học nghề TN</th>
                </tr>
                <tr>
                    <th>Tiếng hàn</th>
                    <th>Tiếng nhật</th>
                </tr>
            </thead>
            <tbody>
                <tr style="background: #EAEAEA;">
                    <td style="width: 50px;">1</td>
                    <td style="width: 250px;">PHẠM VĂN HIẾU .....</td>
                    <td style="width: 250px;">DIỄN CHÂU NGHỆ AN</td>
                    <td style="width: 50px;">Nam</td>
                    <td style="width: 120px;">09 6735 6524</td>
                    <td style="width: 80px;">x</td>
                    <td style="width: 80px;">x</td>
                    <td style="width: 80px;">x</td>
                    <td style="width: 250px;">Lái xe B2</td>
                    <td style="width: 120px;">4 tháng</td>
                    <td style="width: 100px;">3.000.000 đ</td>
                    <td style="width: 380px;">Công ty CP Xe khách , CĐ nghề Việt Đức</td>
                    <td style="width: 80px;"></td>
                    <td style="width: 380px;">Khối 2 , P Vinh Tân , TP Vinh  </td>
                    <td style="width: 250px;">02383 847 901</td>
                </tr>
            </tbody>
        </table>
    </div>

    <style>
    .table-responsive2 {
width:100%;
margin-bottom:15px;
overflow-x:auto;
overflow-y:hidden;
-webkit-overflow-scrolling:touch;
-ms-overflow-style:-ms-autohiding-scrollbar;
border:1px solid #ddd
}
    .th{

    }

.table-responsive2 table {
    table-layout: fixed;
}
.tableheader {
    border:solid 1px black;
	width: 2549px;
	margin-bottom:0px;
	
}
.tablebody {
	height: 400px;
	overflow-y: auto;
	width: 2565px;
	margin-bottom:20px;
}

</style>

</asp:Content>

