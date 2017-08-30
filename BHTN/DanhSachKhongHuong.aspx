<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="DanhSachKhongHuong.aspx.cs" Inherits="Labor_DanhSachKhongHuong" %>
<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="Server">
    <style>
        .DataListTable td {
            padding-top: 5px;
            padding-bottom: 5px;
        }

        .TrangThai {
            padding: 3px;
            padding-left: 8px;
            padding-right: 8px;
            background-color: #ff6a00;
            color: #fff;
            font-size: 12px;
        }
        label {
            float: left;
            padding: 6px 12px;
        }
    </style>
    <script>
        function delmodal(id, name, idtrangthai) {
            $("#MainContent_idNLD").val(id);
            $("#myModal").modal("show");        
          
        }
    </script>
    <script src="../js/TvsScript.js"></script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div style="width: auto; min-height: 400px;">
        <table style="margin-top: -10px; margin-right: -15px!important; width: 100%!important; padding: 0px!important;" border="0">
            <tr>
                <td>
                    <input type="text" id="txtSearch" placeholder="Nhập tên NLĐ, số CMND, số BHXH, số điện thoại để tìm kiếm" runat="server" class="form-control" />
                </td>
                <td style="width: 250px;">
                    <label>Từ ngày</label>
                    <div class='input-group date' style="margin-left: 0px; width: 60% !important; float: left;">
                        <input type='text' class="form-control dateinput" id="txtTuNgay" runat="server" />
                        <span class="input-group-addon">
                            <span class="glyphicon glyphicon-calendar"></span>
                        </span>
                    </div>
                </td>
                <td style="width: 250px;">
                    <label>Đến ngày</label>
                    <div class='input-group date' style="margin-left: 0px; width: 60% !important; float: left;">
                        <input type='text' class="form-control dateinput" id="txtDenNgay" runat="server" />
                        <span class="input-group-addon">
                            <span class="glyphicon glyphicon-calendar"></span>
                        </span>
                    </div>
                </td>
                <td style="width: 40px !important; text-align: center;">
                    <asp:ImageButton ID="btnSearch" ImageUrl="../images/Search.png" runat="server" Style="margin-top: 5px;" />
                </td>
                <td style="width:250px;">
                <label>Trạng thái</label>
                 <asp:DropDownList ID="ddlTrangThai" CssClass="form-control" runat="server" Style="width:150px" AutoPostBack="True" OnSelectedIndexChanged="ddlTrangThai_SelectedIndexChanged">
                </asp:DropDownList>
                </td>
              <td>
                    <div style="float:right;width:165px;margin:10px;text-align:right;">
             <a href="/BHTN/"><input type="button" class="btn btn-default" value="Trở lại" /></a>
             </div>
              </td>
            </tr>           
        </table>
        <asp:Repeater ID="dtlData" runat="server" OnItemCommand="dtlData_ItemCommand" OnItemDataBound="dtlData_ItemDataBound">
            <HeaderTemplate>
                <table class="DataListTable" border="0" style="width: 100%; margin-top: 10px;">
                    <tr style="height: 40px;" class="DataListTableHeader">
                        <td class="DataListTableHeaderTdItemTT" style="width: 3%;">#</td>
                        <td class="DataListTableHeaderTdItemJustify">Người lao động</td>
                        <td class="DataListTableHeaderTdItemJustify" style="width: 13%;">Tình trạng</td>
                        <td class="DataListTableHeaderTdItemJustify" style="width: 10%;">Số CMND</td>
                        <td class="DataListTableHeaderTdItemJustify" style="width: 10%;">Số BHXH</td>
                        <td class="DataListTableHeaderTdItemJustify" style="width: 10%;">Ngày hoàn thiện</td>
                        <td class="DataListTableHeaderTdItemJustify" style="width: 10%;">Số QĐ</td>
                        <td class="DataListTableHeaderTdItemJustify" style="width: 10%;display:none">IDCapSo</td>
                        <td class="DataListTableHeaderTdItemCenter" style="width: 6%;">Tải QĐ</td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td class="DataListTableTdItemTT">
                        <input type="checkbox" id="ckbSelect<% =index++ %>" value="<%# Eval("IdNLDTCTN") %>" />
                    </td>
                    <td class="DataListTableTdItemJustify"><%# Eval("HoVaTen") %></td>
                    <td class="DataListTableTdItemJustify" style="color: red; text-align:left;"><%# Eval("TrangThai").ToString().Replace("Chuyển thẩm định","<span class = \"TrangThai\">Chuyển thẩm định</span>") %></td>
                    <td class="DataListTableTdItemJustify"><%# Eval("CMND") %></td>
                    <td class="DataListTableTdItemJustify"><%# Eval("BHXH") %></td>
                    <td class="DataListTableTdItemJustify">
                        <%# (Eval("NgayHoanThien").ToString() != "")?((DateTime)Eval("NgayNopHoSo")).ToString("dd/MM/yyyy"):"" %><br />
                    </td>
                    <td class="DataListTableTdItemCenter"><%# Eval("SoVanBan") %>
                    <td class="DataListTableTdItemCenter" style="display:none;">
                    <input type="text" id="lblCapSo<% =index2++ %>" value="<%# Eval("IDCapSo")%>" />                     
                    </td>
                    <td class="DataListTableTdItemCenter">
                     <asp:Button ID="btnTaiQD" class="btn btn-primary" runat ="server" CommandName="TaiQuyetDinh"  CommandArgument='<%# Eval("IdNLDTCTN") %>' Text="Tải QĐ" />
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
                        PageNumbersSeparator="&nbsp;" PagingMode="PostBack">
                    </cc1:CollectionPager>
                </td>
            </tr>
        </table>
        <div class="row col-sm-12">
            <a class="btn btn-danger" style="float: left; margin-right: 10px;" onclick="CheckAll()">Check All</a>
            <a class="btn btn-danger" style="float: left; margin-right: 10px;" onclick="UnCheckAll()">UnCheck All</a>
            <div class="warning">
                <asp:Label ID="lblMsg" runat="server" Text="" Font-Size="Larger" ForeColor="Red" />
            </div>
            <a class="btn btn-primary" style="float: right; display:none" onclick="ChuyenSelect('TraKetQuaDinhModal')">Chuyển Bộ phận Trả KQ</a>
            <a class="btn btn-primary" style="float: right; display:none; " onclick="TaiQuyetDinhSelect()">Tải quyết định</a>
            <a class="btn btn-primary" style="float: right; margin-right: 40px; display:none"  onclick="ChuyenSelect('TrinhKyModal')">Trình ký</a>
            <a class="btn btn-primary" style="float: right; margin-right: 40px; display:none" onclick="ChuyenSelect('myModal')">Đánh số</a>
            </div>
        <!-- Modal danh so -->
        <div id="myModal" class="modal fade" role="dialog">
            <div class="modal-dialog" style="display: table;">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title">Đánh số</h4>
                    </div>
                    <div class="modal-body">
                        <table>
                            <tr>
                                <td>Năm QĐ:</td>
                                <td>
                                    <asp:TextBox ID="txtNamQuyetDinh" CssClass="form-control" runat="server" Style="width: 100%;"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Loại quyết định:</td>
                                <td>
                                    <asp:DropDownList ID="ddlLoaiQuyetDinh" runat="server" CssClass="form-control" Style="width: 100%;"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>Số hồ sơ chọn đánh số:</td>
                                <td>
                                    <asp:TextBox ID="txtSoHoSoChonDanh" CssClass="form-control" runat="server" Style="width: 100%;"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Số bắt đầu:</td>
                                <td>
                                    <asp:TextBox ID="txtSoBatDau" CssClass="form-control" runat="server" Style="width: 100%;"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Số kết thúc:</td>
                                <td>
                                    <asp:TextBox ID="txtSoKetThuc" CssClass="form-control" runat="server" Style="width: 100%;"></asp:TextBox></td>
                            </tr>
                        </table>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnDanhSo" runat="server" CssClass="btn btn-primary" Text="Đánh số" OnClick="btnDanhSo_Click" />
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    </div>
                </div>
            </div>
        </div>

        <!-- Modal trinh ky -->
        <div id="TrinhKyModal" class="modal fade" role="dialog">
            <div class="modal-dialog" style="display: table;">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title">Đánh số</h4>
                    </div>
                    <div class="modal-body">
                        <table>
                            <tr>
                                <td>Năm QĐ:</td>
                                <td>
                                    <asp:TextBox ID="txtNamQD2" CssClass="form-control" runat="server" Style="width: 100%;"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Loại quyết định:</td>
                                <td>
                                    <asp:DropDownList ID="ddlLoaiQuyetDinh2" runat="server" CssClass="form-control" Style="width: 100%;"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>Số hồ sơ cần trình:</td>
                                <td>
                                    <asp:TextBox ID="txtSoHoSoCanTrinh" CssClass="form-control" runat="server" Style="width: 100%;"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Ngày trình ký:</td>
                                <td>
                                <div class='input-group date' style="margin-left: 0px; width: 100% !important; float: left;">
                                <input type='text' class="form-control dateinput" id="txtNgayTrinhKy" runat="server" />
                                <span class="input-group-addon">
                                    <span class="glyphicon glyphicon-calendar"></span>
                                </span>
                                </div>
                                </td>
                            </tr>
                            <tr>
                                <td>Người ký</td>
                                <td>
                                <asp:DropDownList ID="ddlNguoiKy" runat="server" CssClass="form-control" Style="width: 100%;"></asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnTrinhKy" runat="server" CssClass="btn btn-primary" Text="Trình ký" OnClick="btnTrinhKy_Click" />
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    </div>
                </div>
            </div>
        </div>

        <!-- Modal tai quyet dinh -->
        <div id="TaiQuyetDinhModal" class="modal fade" role="dialog">
            <div class="modal-dialog" style="display: table;">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title">Tải quyết định</h4>
                    </div>
                    <div class="modal-body">
                        <table> 
                            <tr>
                                <td>Số quyết định chọn tải:</td>
                                <td>
                                    <asp:TextBox ID="txtSoQuyetDinhChonTai" CssClass="form-control" runat="server" Style="width: 100%;"></asp:TextBox>
                                </td>
                            </tr>                        
                        </table>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnTaiQuyetDinh" runat="server" CssClass="btn btn-primary" Text="Tải quyết định" OnClick="btnTaiQuyetDinh_Click" />
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    </div>
                </div>
            </div>
        </div>

        <!-- Modal chuyen bo phan tra ket qua-->
        <div id="TraKetQuaDinhModal" class="modal fade" role="dialog">
            <div class="modal-dialog" style="display: table;">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title">Chuyển trả kết quả</h4>
                    </div>
                    <div class="modal-body">
                        <table> 
                            <tr>
                                <td>Số hồ sơ được chọn:</td>
                                <td>
                                    <asp:TextBox ID="txtSoHoSoDuocChon" CssClass="form-control" runat="server" Style="width: 100%;"></asp:TextBox>
                                </td>
                            </tr>                        
                        </table>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnChuyenHoSo" runat="server" CssClass="btn btn-primary" Text="Trả kết quả" OnClick="btnChuyenHoSo_Click" />
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    </div>
                </div>
            </div>
        </div>

        <script>
            $(function () {
                $('.date').datetimepicker({
                    format: 'DD/MM/YYYY'
                });

                $(".dateinput").mask("99/99/9999", { placeholder: "dd/MM/yyyy" });
            });

            function ChuyenSelect(NameModal)
            {              
                var txt = "";
                var lbl="";
                var index=0;
                var SoBatDau;
                for(i=1;i< <%= index %>;i++)
                {
                    var objchk = document.getElementById('ckbSelect' + i);
                    var lblCapSo = document.getElementById('lblCapSo' + i);                   
                    if(objchk != null && objchk.checked == true)
                    {
                        if(txt != "") 
                        {
                            txt += "," ; 
                            lbl +=",";
                        }
                        lbl += lblCapSo.value;  
                        txt += objchk.value;                    
                        index ++;
                     
                    }
                }

                if(txt != "")
                {   
                    $("#MainContent_hdlstChuyen").val(txt); 
                    $("#MainContent_hdlstIDCapSo").val(lbl); 
                    $("#MainContent_hdSoHoSoDaChon").val(index);
                    $("#MainContent_txtSoHoSoChonDanh").val(index);    
                    $("#MainContent_txtSoHoSoCanTrinh").val(index);
                    $("#MainContent_txtSoHoSoDuocChon").val(index);
                    GetAutoNumber();
                    $("#"+NameModal).modal("show");                
                }
            }

           
            function TaiQuyetDinhSelect()
            {              
                var txt = "";
                var index=0;
                var SoBatDau;
                for(i=1;i< <%= index %>;i++)
                {
                    var objchk = document.getElementById('ckbSelect' + i);
                    if(objchk != null && objchk.checked == true)
                    {
                        if(txt != "") txt += ","
                        txt += objchk.value;
                        index ++;
                    }
                }

                if(txt != "")
                {   
                    $("#MainContent_hdlstChuyen").val(txt);  
                    $("#MainContent_txtSoQuyetDinhChonTai").val(index);
                    $("#TaiQuyetDinhModal").modal("show"); 
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
         
            $("#MainContent_txtSoBatDau").blur(function(){
                DanhSoVanBan();
            });
            $("#MainContent_ddlLoaiQuyetDinh").change(function(){
                               
                GetAutoNumber();               
               
            });
            function DanhSoVanBan()
            {
                var SoBatDau=0,SoHoSoDaChon=0,SoKetThu=0;
                SoHoSoDaChon= $("#MainContent_hdSoHoSoDaChon").val();      
                SoBatDau=$("#MainContent_txtSoBatDau").val();
                SoKetThu= parseInt(SoBatDau) + parseInt(SoHoSoDaChon)-1;                 
                $("#MainContent_txtSoKetThuc").val(SoKetThu);
               
            }

            var msg='<%=_msg%>';
            if(msg!="")
            {              
                alert(msg);
            }      
           
        </script>
        <script type="text/javascript">
            function GetAutoNumber() {
                var IDLoaiVanBan=$("#MainContent_ddlLoaiQuyetDinh").val();             
                $.get("/ajax/DanhSoCongVan.aspx?id="+ IDLoaiVanBan, function (data, status) {         
                    //selectout.innerHTML = "";
                    if (status == "success")
                    { 
                        $("#MainContent_txtSoBatDau").val(data.toString());  
                        var SoBatDau=0,SoHoSoDaChon=0,SoKetThu=0;
                        SoHoSoDaChon= $("#MainContent_hdSoHoSoDaChon").val();      
                        SoBatDau=data;
                        SoKetThu= parseInt(SoBatDau) + parseInt(SoHoSoDaChon)-1;                 
                        $("#MainContent_txtSoKetThuc").val(SoKetThu);
                      
                    } else {
                        selectout.innerHTML = "";             
                        alert("Mất kết nôi! Xin thử lại.");
                    }      
                    //selectout.
                });
            }
        </script>       
    </div>
    <asp:HiddenField ID="hdlstChuyen" runat="server" />
    <asp:HiddenField ID="hdlstIDCapSo" runat="server" />
    <asp:HiddenField ID="hdChuyen" runat="server" />    
    <asp:HiddenField ID="hdSoHoSoDaChon" runat="server" />
</asp:Content>

