<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="BaoHiemThatNghiep.aspx.cs" Inherits="Labor_BaoHiemThatNghiep" %>
<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="Server">
    <style>
        .DataListTable td {
            padding-top: 5px;
            padding-bottom: 5px;
        }
    </style>
   <script src="../js/TvsScript.js"></script>
    <script>
        function delmodal(id, name, idtrangthai) {
            $("#MainContent_idNLD").val(id);

            if (idtrangthai == 0)
            {
                $("#dknld").html(name);

                $("#DangKyModal").modal("show");
            } else if (idtrangthai == 1)
            {
                $("#htnld").html(name);

                $("#HoanThienModal").modal("show");
            } else
            {

            }


             
         }
    </script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

    <table style="margin-top:-10px; margin-right:-15px!important; width:100%!important;padding:0px!important;" border ="0">
        <tr>
            <td>
                <input type="text" id="txtSearch" placeholder="Nhập tên NLĐ, số CMND, số BHXH, số điện thoại để tìm kiếm" runat="server" class="form-control" />
            </td>
            <td style="width: 180px;">
                    <asp:DropDownList ID="ddlIDTrangThai" AutoPostBack="true" CssClass="form-control" runat="server" Style="width: 100%;">
                    </asp:DropDownList>
            </td>
            <td style="width: 40px !important; text-align: center;">
                <asp:ImageButton ID="btnSearch" ImageUrl="../images/Search.png" runat="server" Style="margin-top:5px;" />
            </td>
            <td style="width: 90px !important; text-align: center;">
                <a href ="BaoHiemThatNghiepEdit.aspx"><input type ="button" class ="btn btn-primary" value ="Tạo hồ sơ" /></a>
            </td>
        </tr>
    </table>

    <asp:Repeater ID="dtlData" runat="server" EnableViewState="False">
            <HeaderTemplate>
                <table class="DataListTable" border="0" style="width: 100%; margin-top: 20px;">
                    <tr style="height: 40px;" class="DataListTableHeader">
                        <td class="DataListTableHeaderTdItemTT" style="width: 3%;">#</td>
                        <td class="DataListTableHeaderTdItemJustify" >Người lao động</td>
                        <td class="DataListTableHeaderTdItemJustify" style="width: 10%;">Tình trạng</td>
                        <td class="DataListTableHeaderTdItemJustify" style="width: 10%;" >Số CMND</td>
                        <td class="DataListTableHeaderTdItemJustify" style="width: 10%;" >Số BHXH</td>
                        <td class="DataListTableHeaderTdItemJustify" style="width: 10%;" >Ngày đăng</td>
                        <td class="DataListTableHeaderTdItemJustify" style="width: 10%;" >Thông tin BH</td>
                        <td class="DataListTableHeaderTdItemCenter" style="width: 10%;">&nbsp;</td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate >
                <tr>
                    <td class="DataListTableTdItemTT"><%= index++ %></td>
                    <td class="DataListTableTdItemJustify"><%# Eval("HoVaTen") %></td>
                    <td class="DataListTableTdItemJustify" style="color:red;"><%# Eval("TrangThai") %></td>
                    <td class="DataListTableTdItemJustify"><%# Eval("CMND") %></td>
                    <td class="DataListTableTdItemJustify"><%# Eval("BHXH") %></td>
                    <td class="DataListTableTdItemJustify">
                        <%# (Eval("NgayDangKyTN").ToString() != "")?((DateTime)Eval("NgayDangKyTN")).ToString("dd/MM/yyyy"):"" %><br />
                        <%# (Eval("NgayNghiViec").ToString() != "")?((DateTime)Eval("NgayNghiViec")).ToString("dd/MM/yyyy"):"" %>
                    </td>
                    <td class="DataListTableTdItemJustify">
                        <%# Eval("SoThangBHTN").ToString() != ""? "Đóng " + Eval("SoThangBHTN").ToString() + " tháng" :""%>
                    </td>
                    <td class="DataListTableTdItemCenter">
                        <a href="#myModal" onclick="delmodal(<%# Eval("IDNguoiLaoDong") %>,'<%# Eval("HoVaTen") %>',<%# Eval("TrangThaiHS").ToString() == ""?"0":Eval("TrangThaiHS") %>)"><img src="/Images/Edit.png" alt="Chuyển hồ sơ"></a>
                        <a href="BaoHiemThatNghiepEdit.aspx?id=<%# Eval("IDNguoiLaoDong") %><%# Eval("TrangThaiHS").ToString() == "2" ? "&type=1":"" %>"><img src="/Images/Edit.png" alt=""></a>
                        <%--<a href="BaoHiemThatNghiepEdit.aspx?id=<%# Eval("IDNguoiLaoDong") %>"><img src="/Images/Edit.png" alt=""></a>
                        <a href="BaoHiemThatNghiepEdit.aspx?id=<%# Eval("IDNguoiLaoDong") %>"><img src="/Images/Edit.png" alt=""></a>--%>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    <table width="100%" cellpadding="0" cellspacing="0" border="0" style="margin-top: 10px; height: 26px;"
        id="tblABC" runat="server">
        <tr>
            <td style="padding-left: 6px;">
                <cc1:CollectionPager ID="cpData" runat="server" BackText="" FirstText="Đầu"
                    ControlCssClass="ProductPage" LabelText="" LastText="Cuối" NextText="" UseSlider="true"
                    ResultsFormat="" BackNextLinkSeparator="" ResultsLocation="None" BackNextLocation="None"
                    PageNumbersSeparator="&nbsp;" PagingMode="PostBack" >
                </cc1:CollectionPager>
            </td>
        </tr>
    </table>

    
    <input id="idNLD" type="hidden" runat="server" />
    <!-- Modal -->
    <div id="HoanThienModal" class="modal fade" role="dialog">
      <div class="modal-dialog">
        <!-- Modal content-->
        <div class="modal-content">
          <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal">&times;</button>
            <h4 class="modal-title">Xác nhận hoàn thiện hồ sơ</h4>
          </div>
          <div class="modal-body">
            <p>Bạn xác nhận hoàn thiện hồ sơ đối với người lao động <b id="htnld"></b></p>
          </div>
          <div class="modal-footer">
            <asp:Button ID="btnHoanThienHoSo" runat ="server" CssClass="btn btn-primary" Text="Xác nhận" OnClick="btnHoanThienHoSo_Click" />
            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
          </div>
        </div>

      </div>
    </div>

    <!-- Modal -->
    <div id="DangKyModal" class="modal fade" role="dialog">
      <div class="modal-dialog">
        <!-- Modal content-->
        <div class="modal-content">
          <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal">&times;</button>
            <h4 class="modal-title">Xác nhận đăng ký</h4>
          </div>
          <div class="modal-body">
            <p>Xác nhận đăng ký hồ sơ cho người lao động <b id="dknld"></b></p>
          </div>
          <div class="modal-footer">
            <asp:Button ID="btnDangKyHoSo" runat ="server" CssClass="btn btn-primary" Text="Xác nhận" OnClick="btnDangKyHoSo_Click" />
            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
          </div>
        </div>

      </div>
    </div>
</asp:Content>

