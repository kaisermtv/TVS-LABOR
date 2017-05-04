<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="DaoTaoNghe.aspx.cs" Inherits="Labor_DaoTaoNghe" %>
<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="Server">
    <style>
        #tableview th {
            vertical-align: inherit;
            padding: 2px !important;
        }
        #tableview td {
            padding:0px !important;
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
       
    <asp:Repeater ID="dtlTuVanXuatKhau" runat="server" EnableViewState="False">
        <HeaderTemplate>
            <div class="table-responsive2">
                <table id="tableview" class="table table-bordered table-striped tableheader">
                    <thead>
                        <tr>
                            <th style="width: 40px; vertical-align: central" rowspan="3">STT</th>
                            <th style="width: 200px;" rowspan="3">Họ Và Tên</th>
                             <th style="width: 150px;" rowspan="3">Ngày Sinh</th>
                            <th style="width: 250px;" rowspan="3">Địa chỉ</th>
                            <th style="width: 50px;" rowspan="3">Giới tính</th>
                            <th style="width: 120px;" rowspan="3">SĐT</th>
                          <th style="width:320px; border:solid 1px black;" colspan="3">
                              NHU CẦU CỦA LAO ĐỘNG
                           </th>
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
                    <tbody class="results">
            </HeaderTemplate>
      
           <ItemTemplate >
            <tr class="tableview" style="font-size:14px;" >
                <td class="DataListTableTdItemTT">
                  <span class="name">  <%# Eval("TT") %></span>
                </td>
                <td class="  " >
                    <%# Eval("HoVaTen") %>
                </td>
                <td>  <%# Eval("NgaySinh") %></td>
                <td>  <%# Eval("DiaChi") %></td>
                <td>  <%# Eval("IdGioiTinh") %></td>
                <td>  <%# Eval("DienThoai") %></td>
                <td>  <%# Eval("NameNgoaiNgu").ToString().ToUpper().Contains("HÀN") ? "x":"" %></td>
                <td>  <%# Eval("NameNgoaiNgu").ToString().ToUpper().Contains("NHẬT") ? "x":"" %></td>
                <td> x                  </td>
                <td>  lái xe b2             </td>
                <td> 4 tháng                    </td>
                <td> 3.000.000 đ            </td>
                <td> TTDVVL NA              </td>
                <td>                        </td>
                <td> Khối 2 , P Vinh Tân , Tp Vinh </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>

            </tbody>
                
                </table>
          <br />
            </div>
        </FooterTemplate>
    </asp:Repeater>
         
    <cc1:CollectionPager ID="cpTuVanXuatKhau" runat="server" BackText="" FirstText="Đầu"
        ControlCssClass="ProductPage" LabelText="" LastText="Cuối" NextText="" UseSlider="true"
        ResultsFormat="" BackNextLinkSeparator="" ResultsLocation="None" BackNextLocation="None"
        PageNumbersSeparator="&nbsp;">
    </cc1:CollectionPager>


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

