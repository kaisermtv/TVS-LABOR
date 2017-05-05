<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="TuyenDung.aspx.cs" Inherits="Admin_TuyenDung" %>

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
    <table class="table" style="margin-top: -20px;">
        <tr>
            <td>
                <input type="text" id="txtSearch" placeholder="Nhập từ khóa bất kỳ ... " runat="server" class="form-control" />
            </td>
            <td style="width: 180px;">
                <asp:DropDownList ID="ddlIDChucVu" CssClass="form-control" runat="server" Style="width: 100%;">
                </asp:DropDownList>
            </td>
            <td style="width: 180px;">
                <asp:DropDownList ID="ddlIDMucLuong" CssClass="form-control" runat="server" Style="width: 100%;">
                </asp:DropDownList>
            </td>
            <td style="width: 40px !important; text-align: center;">
                <asp:ImageButton ID="btnSearch" ImageUrl="../images/Search.png" runat="server" Style="margin-bottom: -15px; margin-left: -15px;" OnClick="btnSearch_Click" />
            </td>
        </tr>
    </table>

    <div id="MainContent_dtlTuyenDung" style="width: 100%; margin-top: -20px;">     <!--Đặt id cho thẻ div để tìm kiếm trong trang-->
        <asp:Repeater ID="dtlTuyenDung" runat="server" EnableViewState="False">
            <HeaderTemplate>
                <table class="DataListTable" border="0">
                    <tr style="height: 40px;" class="DataListTableHeader">
                        <td class="DataListTableHeaderTdItemTT" style="width: 3%;">#</td>
                        <td class="DataListTableHeaderTdItemJustify" style="width: 10%;">Ngày bắt đầu</td>
                        <td class="DataListTableHeaderTdItemJustify" style="width: 20%;">Tên doanh nghiệp</td>
                        <td class="DataListTableHeaderTdItemJustify" style="width: 12%;">Vị trí tuyển</td>
                        <td class="DataListTableHeaderTdItemCenter" style="width: 8%;">Số lượng</td>
                        <td class="DataListTableHeaderTdItemJustify" style="width: 15%;">Mức lương</td>
                        <td class="DataListTableHeaderTdItemJustify">Địa điểm làm việc</td>
                        <td class="DataListTableHeaderTdItemJustify" style="width: 8%;">Trạng thái</td>
                        <td class="DataListTableHeaderTdItemCenter" style="width: 9%;">&nbsp;</td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate >
                <tr>
                    <td class="DataListTableTdItemTT"><%# this.index++ %></td>
                    <td class="DataListTableTdItemJustify"><%# ((DateTime)Eval("NgayBatDau")).ToString("dd/MM/yyyy") %></td>
                    <td class="DataListTableTdItemJustify">
                        <%# Eval("TenDonVi") %>
                    </td>
                    <td class="DataListTableTdItemJustify  ">
                           <span class="name"> <%# Eval("NameVitri") %>
                               </span>
                        </td>
                    <td class="DataListTableTdItemRight">
                        <%# Eval("SoLuongTuyenDung") %>
                        &nbsp;<a href="#"><div onclick="XemTinTuyenDung('<%# Eval("IdTuyenDung") %>','<%# Eval("CountItem") %>')" class="badge"><%# Eval("CountItem") %></div>
                        </a>
                    </td>
                    <td class="DataListTableTdItemJustify">
                        <%# Eval("NameMucLuong") %>
                    </td>
                    <td class="DataListTableTdItemJustify"><%# Eval("DiaDiem") %></td>
                    <td class="DataListTableTdItemJustify"><%# Eval("State").ToString().Replace("True","Kích hoạt").Replace("False","-/-") %></td>
                    <td class="DataListTableTdItemCenter" style="width: 12%;">
                         <a href="#" onclick="XemTinTuyenDungLamViec(<%# Eval("IDTuyenDung") %>)">
                                <img src="../Images/Print.png" />
                          </a>
                        <a href="TuyenDungEdit.aspx?id=<%# Eval("IDTuyenDung") %>">
                            <img src="../Images/Edit.png" alt=""></a>
                        <a href="TuyenDung.aspx?id=<%# Eval("IDTuyenDung") %>">
                            <img src="../Images/top.png" alt="" title="Thiết lập ưu tiên nhất" style="margin-left: 5px; margin-right: 5px;"></a>
                        <a href="TuyenDungDel.aspx?id=<%# Eval("IDTuyenDung") %>">
                            <img src="../Images/delete.png" alt=""></a>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    <table width="100%" cellpadding="0" cellspacing="0" border="0" style="margin-top: 10px; height: 26px;"
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
        function XemTinTuyenDung(value, count) {

            if (count == 0) {
                return;
            }
            else {
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
        }

        function XemTinTuyenDungLamViec(value) {
            var w = 1000;
            var h = 620;

            var dualScreenLeft = window.screenLeft != undefined ? window.screenLeft : screen.left;
            var dualScreenTop = window.screenTop != undefined ? window.screenTop : screen.top;

            var width = window.innerWidth ? window.innerWidth : document.documentElement.clientWidth ? document.documentElement.clientWidth : screen.width;
            var height = window.innerHeight ? window.innerHeight : document.documentElement.clientHeight ? document.documentElement.clientHeight : screen.height;

            var left = ((width / 2) - (w / 2)) + dualScreenLeft;
            var top = ((height / 2) - (h / 2)) + dualScreenTop;

            var newWindow = window.open("PrintTuyenDungLamViecTaiCtyABC.aspx?id=" + value, "TIN TUYỂN DỤNG", 'scrollbars=yes, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);

                if (window.focus) {
                    newWindow.focus();
                }
            
        }

    </script>
    <script>
          $(function () {
              /* QUICK SEARCH - Tìm nhanh */
              $('#MainContent_dtlTuyenDung').searchable({       // lấy thẻ chứa ngoài cùng
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

