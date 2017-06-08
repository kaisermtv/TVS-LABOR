<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/BHTN.master" CodeFile="DangKyHoSo.aspx.cs" Inherits="BHTN_DangKyHoSo" %>


<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="Server">
    <style>
        .DataListTable td {
            padding-top: 5px;
            padding-bottom: 5px;
        }

        .TrangThai
        {
            padding:3px;
            padding-left:8px;
            padding-right:8px;
            background-color:#ff6a00;
            color:#fff;
            font-size:12px;
        }

        .modal-dialog{
            display:table;
        }

        .warning {
            color: red;
            float:left;
        }
    </style>
    <script src="../js/TvsScript.js"></script>
    <script>
        function delmodal(id, name, idtrangthai) {
            $("#MainContent_idNLD").val(id);

            $("#htnld").html(name);

            $("#HoanThienModal").modal("show");
        }
    </script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

    <table style="margin-top: -10px; margin-right: -15px!important; width: 100%!important; padding: 0px!important;" border="0">
        <tr>
            <td>
                <input type="text" id="txtSearch" placeholder="Nhập tên NLĐ, số CMND, số BHXH, số điện thoại để tìm kiếm" runat="server" class="form-control" />
            </td>
            <td style="width: 180px;">
                <asp:DropDownList ID="ddlIDTrangThai" AutoPostBack="true" CssClass="form-control" runat="server" Style="width: 100%;">
                </asp:DropDownList>
            </td>
            <td style="width: 40px !important; text-align: center;">
                <asp:ImageButton ID="btnSearch" ImageUrl="../images/Search.png" runat="server" Style="margin-top: 5px;" />
            </td>
            <%--<td style="width: 90px !important; text-align: center;">
                <a href="NhapThongTinHoSo.aspx">
                    <input type="button" class="btn btn-primary" value="Tạo hồ sơ" /></a>
            </td>--%>
            <td style="width: 90px !important; text-align: center;">
                <a href="/BHTN/">
                    <input type="button" class="btn btn-default" value="Trở lại" /></a>
            </td>
        </tr>
    </table>

    <asp:Repeater ID="dtlData" runat="server" EnableViewState="False">
        <HeaderTemplate>
            <div class="table-responsive">
            <table class="DataListTable" border="0" style="width: 100%; margin-top: 10px;">
                <tr style="height: 40px;" class="DataListTableHeader">
                    <td class="DataListTableHeaderTdItemTT" style="width: 3%;">#</td>
                    <td class="DataListTableHeaderTdItemJustify">Người lao động</td>
                    <td class="DataListTableHeaderTdItemJustify" style="width: 10%;">Tình trạng</td>
                    <td class="DataListTableHeaderTdItemJustify" style="width: 10%;">Số CMND</td>
                    <td class="DataListTableHeaderTdItemJustify" style="width: 10%;">Số BHXH</td>
                    <td class="DataListTableHeaderTdItemJustify" style="width: 10%;">Ngày đăng ký</td>
                    <td class="DataListTableHeaderTdItemJustify" style="width: 10%;">Thông tin BH</td>
                    <td class="DataListTableHeaderTdItemCenter" style="width: 6%;">&nbsp;</td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td class="DataListTableTdItemTT">
                    <input type="checkbox" id ="ckbSelect<% =index++ %>" value ="<%# Eval("IdNLDTCTN") %>" />
                </td>
                <td class="DataListTableTdItemJustify"><%# Eval("HoVaTen") %></td>
                <td class="DataListTableTdItemJustify" style="color: red;"><%# Eval("TrangThai").ToString().Replace("Hoàn thiện","<span class = \"TrangThai\">Hoàn thiện</span>") %></td>
                <td class="DataListTableTdItemJustify"><%# Eval("CMND") %></td>
                <td class="DataListTableTdItemJustify"><%# Eval("BHXH") %></td>
                <td class="DataListTableTdItemJustify">
                    <%# (Eval("NgayNopHoSo").ToString() != "")?((DateTime)Eval("NgayNopHoSo")).ToString("dd/MM/yyyy"):"" %><br />
                    <%# (Eval("NgayNghiViec").ToString() != "")?((DateTime)Eval("NgayNghiViec")).ToString("dd/MM/yyyy"):"" %>
                </td>
                <td class="DataListTableTdItemCenter">
                    <%# Eval("SoThangDongBHXH").ToString() != ""? "Đóng " + Eval("SoThangDongBHXH") + " tháng" :""%>
                </td>
                <td class="DataListTableTdItemCenter">
                    <a href="#myModal" onclick="delmodal(<%# Eval("IdNLDTCTN") %>,'<%# Eval("HoVaTen") %>')">
                        <img src="/Images/Forward.png" alt="Chuyển hồ sơ" title ="Chuyển hồ sơ">
                    </a>
                    <a href="NhapThongTinHoSo.aspx?id=<%# Eval("IdNLDTCTN") %><%# Eval("IdTrangThai").ToString() == "2" ? "&type=1":"" %>">
                        <img src="/Images/Edit.png" alt="Sửa hồ sơ" title ="Sửa hồ sơ"></a>
                    <%--<a href="BaoHiemThatNghiepEdit.aspx?id=<%# Eval("IdNLDTCTN") %>"><img src="/Images/Edit.png" alt=""></a>
                        <a href="BaoHiemThatNghiepEdit.aspx?id=<%# Eval("IdNLDTCTN") %>"><img src="/Images/Edit.png" alt=""></a>--%>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
            </div>
        </FooterTemplate>
    </asp:Repeater>
    <table width="100%" cellpadding="0" cellspacing="0" border="0" style="margin-top: 10px; height: 26px;"
        id="tblABC" runat="server">
        <tr>
            <td style="padding-left: 6px;">
                <cc1:CollectionPager ID="cpData" runat="server" BackText="" FirstText="Đầu"
                    ControlCssClass="ProductPage" LabelText="" LastText="Cuối" NextText="" UseSlider="true"
                    ResultsFormat="" BackNextLinkSeparator="" ResultsLocation="None" BackNextLocation="None"
                    PageNumbersSeparator="&nbsp;" PagingMode="PostBack">
                </cc1:CollectionPager>
            </td>
        </tr>
    </table>

    <div class="row col-sm-12">
        <a class="btn btn-danger" style="float:left;margin-right:10px;" onclick="CheckAll()">Check All</a>
        <a class="btn btn-danger" style="float:left;margin-right:10px;" onclick="UnCheckAll()">UnCheck All</a>
        <div class="warning">
            <asp:Label ID="lblMsg" runat="server" Text="" Font-Size="Larger" ForeColor="Red" />
        </div>
        
        <a class="btn btn-primary" style="float:right" onclick="ChuyenSelect()">Chuyển</a>
    </div>

    <script>
        $(function () {
            $('.date').datetimepicker({
                format: 'DD/MM/YYYY'
            });

            $(".dateinput").mask("99/99/9999", { placeholder: "dd/MM/yyyy" });
        });

        function ChuyenSelect()
        {
            var txt = "";
            for(i=1;i< <%= index %>;i++)
            {
                var objchk = document.getElementById('ckbSelect' + i);
                if(objchk != null && objchk.checked == true)
                {
                    if(txt != "") txt += ","
                    txt += objchk.value;
                }
            }

            if(txt != "")
            {
                $("#MainContent_idNLDList").val(txt);

                $("#ListHoanThienModal").modal("show");
            }
        }

        function CheckAll()
        {
            for(i=1;i< <%= index %>;i++)
            {
                var objchk = document.getElementById('ckbSelect' + i);
                if(objchk != null)
                {
                    objchk.checked = true;
                }
            }
        }

        function UnCheckAll()
        {
            for(i=1;i< <%= index %>;i++)
            {
                var objchk = document.getElementById('ckbSelect' + i);
                if(objchk != null)
                {
                    objchk.checked = false;
                }
            }
        }
    </script>


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
                    <div style="width: 60%; float: left">
                        <div class='input-group date' style="margin-left: 0px; width: 100% !important; float: right;">
                            <input type='text' class="form-control dateinput" id="txtNgayHoanThanh" runat="server" />
                            <span class="input-group-addon">
                                <span class="glyphicon glyphicon-calendar"></span>
                            </span>
                        </div>
                    </div>

                    <asp:Button ID="btnHoanThienHoSo" runat="server" CssClass="btn btn-primary" Text="Xác nhận" OnClick="btnHoanThienHoSo_Click" />
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>

        </div>
    </div>

    <input id="idNLDList" type="hidden" runat="server" />
    <!-- Modal -->
    <div id="ListHoanThienModal" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Xác nhận hoàn thiện hồ sơ</h4>
                </div>
                <div class="modal-body">
                    <p>Xác nhận hoàn thiện hồ sơ cho các mục đã chọn</p>
                </div>
                <div class="modal-footer">
                    <div style="width: 60%; float: left">
                        <div class='input-group date' style="margin-left: 0px; width: 100% !important; float: right;">
                            <input type='text' class="form-control dateinput" id="txtNgayHoanThanh1" runat="server" />
                            <span class="input-group-addon">
                                <span class="glyphicon glyphicon-calendar"></span>
                            </span>
                        </div>
                    </div>

                    <asp:Button ID="btnListHoanThienHoSo" runat="server" CssClass="btn btn-primary" Text="Xác nhận" OnClick="btnListHoanThienHoSo_Click" />
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>

        </div>
    </div>
</asp:Content>

