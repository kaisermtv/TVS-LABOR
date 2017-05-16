<%@ Page Language="C#" AutoEventWireup="true" CodeFile="XemTinTuyenDung.aspx.cs" Inherits="Labor_XemTinTuyenDung" %>

<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>XEM TIN TUYỂN DỤNG</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="../css/TVSStyle.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="../css/Adminstyle.css" />
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel='stylesheet' type='text/css' />
    <!-- Custom CSS -->
    <link href="../css/style.css" rel='stylesheet' type='text/css' />
    <!-- Graph CSS -->
    <link href="../css/font-awesome.css" rel="stylesheet" />
   
    <link href="../css/jquery-ui.css" rel="stylesheet" />
    <!-- jQuery -->
    <!-- lined-icons -->
    <link rel="stylesheet" href="../css/icon-font.min.css" type='text/css' />
   <script src="../js/jquery-1.10.2.min.js"></script>      <!---Sử dụng jqerry để lấy tìm kiếm ---->
    
    <script src="../js/jquery-ui.js"></script>
    <style>
        .DataListTable td {
            padding-top: 5px;
            padding-bottom: 5px;
        }
    </style>

    <script>
        $(document).keydown(function (e) {
            if (e.keyCode == 27) {
                window.close();
            }
        });

        window.onload = maxWindow;
        function maxWindow() {
            window.moveTo(0, 0);
            if (document.all) {
                top.window.resizeTo(screen.availWidth, screen.availHeight);
            }
            else if (document.layers || document.getElementById) {
                if (top.window.outerHeight < screen.availHeight || top.window.outerWidth < screen.availWidth) {
                    top.window.outerHeight = screen.availHeight;
                    top.window.outerWidth = screen.availWidth;
                }
            }
        }

    </script>

    
</head>
<body style="margin: 0px !important;">
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server">
        </asp:ScriptManager>
        <table class="table" border="0">
            <tr>
                <td>
                    <input type="text" id="txtSearch" placeholder="Tên công việc cần tìm kiếm" runat="server" class="form-control" />
                </td>
                <td style="width: 200px; padding-right: 0px;">
                    <asp:DropDownList ID="ddlIDChucVu" runat="server" CssClass="form-control" Style="width: 100%;" AutoPostBack="true" OnSelectedIndexChanged="ddl_SelectedIndexChanged">
                    </asp:DropDownList></td>
                <td style="width: 250px; padding-right: 0px;">
                    <asp:DropDownList ID="ddlMucLuong" runat="server" CssClass="form-control" Style="width: 100%;" AutoPostBack="true" OnSelectedIndexChanged="ddl_SelectedIndexChanged" >
                    </asp:DropDownList></td>
                <td style="width: 40px !important; text-align: center;">
                    <asp:ImageButton ID="btnSearch" ImageUrl="../images/Search.png" runat="server" Style="margin-bottom: -15px; margin-left: -15px;" OnClick="btnSearch_Click" />
                </td>
            </tr>
        </table>

        <div id="MainContent_dtlTuyenDung" style="margin-top: -30px;min-height:600px">
            <div style="width: 100%; padding: 15px;">
                <asp:Repeater ID="dtlTuyenDung" runat="server" EnableViewState="False">
                    <HeaderTemplate>
                        <table class="DataListTable" border="0">
                            <tr style="height: 40px;" class="DataListTableHeader">
                                <td class="DataListTableHeaderTdItemTT" style="width: 3%;">#</td>
                                <td class="DataListTableHeaderTdItemJustify" style="width: 10%;">Ngày bắt đầu</td>
                                <td class="DataListTableHeaderTdItemJustify" style="width: 28%;">Tên doanh nghiệp</td>
                                <td class="DataListTableHeaderTdItemJustify" style="width: 15%;">Vị trí tuyển</td>
                                <td class="DataListTableHeaderTdItemCenter" style="width: 8%;">Số lượng</td>
                                <td class="DataListTableHeaderTdItemJustify" style="width: 17%;">Mức lương</td>
                                <td class="DataListTableHeaderTdItemJustify">Địa điểm làm việc</td>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td class="DataListTableTdItemTT"><%# this.index++ %></td>
                            <td class="DataListTableTdItemJustify"><%# ((DateTime)Eval("NgayBatDau")).ToString("dd/MM/yyyy") %></td>
                            <td class="DataListTableTdItemJustify">
                                <a href="#" onclick="return ItemSelect('<%# Eval("IDTuyenDung") %>','<%# Eval("IDDonVi") %>','<%# Eval("IdViTri") %>','<%# Eval("TenDonVi") %>','<%# Eval("NameVitri") %>');"><%# Eval("TenDonVi") %></a>
                                &nbsp;<a href="#"><img onclick="XemDoanhNghiep('<%# Eval("IDDonVi") %>')" src="../Images/View.png" alt="Xem chi tiết" style="margin-top: -3px;"></a>
                            </td>
                            <td class="DataListTableTdItemJustify"><%# Eval("NameVitri") %>&nbsp;<a href="#"><img onclick="XemThongTinTuyenDung('<%# Eval("IdTuyenDung") %>')" src="../Images/View.png" alt="Xem chi tiết" style="margin-top: -3px;"></a></td>
                            <td class="DataListTableTdItemRight" style ="padding-right:15px!important;">
                                <%# Eval("SoLuongTuyenDung") %>
                                &nbsp;<a href="#"><div onclick="XemTinTuyenDung('<%# Eval("IdTuyenDung") %>','<%# Eval("CountItem") %>')" class="badge"><%# Eval("CountItem") %></div>
                                </a>
                            </td>
                            <td class="DataListTableTdItemJustify"><%# Eval("NameMucLuong") %></td>
                            <td class="DataListTableTdItemJustify"><%# Eval("DiaDiem") %></td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>

            <div style="width: 100%; padding: 10px; margin-top: -20px;">
                <table width="100%" cellpadding="0" cellspacing="0" border="0" style="margin-top: 5px; height: 26px;"
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
            </div>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Click chuột vào tên doanh nghiệp để chọn nhu cầu tuyển dụng của doanh nghiệp đó cho người lao động 
            
            <br />
            
        </div>
        <footer style="height: 105px !important; margin-bottom: 0px; width: 100%; text-align: justify; background-color: #f0f0f0;">
           
                <input type="hidden" id="txtIDTuyenDung" class="form-control" runat="server" />
                <input type="text" id="txtTenDonVi" class="form-control" runat="server" style="width: 40%; float: left; margin-left: 15px; margin-right: 10px;" />
                <input type="text" id="txtNameChucVu" class="form-control" runat="server" style="width: 24%; margin-left: 10px!important; margin-right: 0px;" />
                 <input type="text" id="txtNgayHetHan" placeholder="Ngày hết hiệu lực" class="form-control" runat="server" style="width:24%;float:right; margin-top:-32px" />
                 
                    <script>
                        $(function () {
                            $("#txtNgayHetHan").datepicker();
                        });
                 </script>         
                <hr />
                <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Button ID="btnSave" runat="server" Text="Lưu thông tin" CssClass="btn btn-primary" Style="margin-left: 25px; margin-top: -15px; margin-bottom:10px;" OnClick="btnSave_Click" OnClientClick="javascript:window.close();" />&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <input type="hidden" id="txtIDDonVi" runat="server" />
                <input type="hidden" id="txtIDChucVu" runat="server" />

            </footer>
       
        <script  src="../js/TvsScript.js"></script>         <!--chứa qick search-->
          <script>
              $(function () {
                  /* QUICK SEARCH - Tìm nhanh , tìm mọi thứ  */
                  $('#MainContent_dtlTuyenDung').searchable({       // lấy thẻ chứa ngoài cùng
                      searchField: '#txtSearch1',        // lấy sự kiện tại txtSearch
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
    
          <script type="text/javascript">
            function ItemSelect(IDTuyenDung, IDDonVi, IDChucVu, TenDonVi, NameChucVu) {

                var txtIDTuyenDung = document.getElementById("txtIDTuyenDung");
                txtIDTuyenDung.value = IDTuyenDung;

                var txtIDDonVi = document.getElementById("txtIDDonVi");
                txtIDDonVi.value = IDDonVi;

                var txtIDChucVu = document.getElementById("txtIDChucVu");
                txtIDChucVu.value = IDChucVu;

                var txtTenDonVi = document.getElementById("txtTenDonVi");
                txtTenDonVi.value = TenDonVi;

                var txtNameChucVu = document.getElementById("txtNameChucVu");
                txtNameChucVu.value = NameChucVu;
            }

            function XemTinTuyenDung(value, count) {

                if (count == 0) {
                    return;
                }
                else {
                    var w = screen.availWidth;
                    var h = screen.availHeight;

                    var dualScreenLeft = window.screenLeft != undefined ? window.screenLeft : screen.left;
                    var dualScreenTop = window.screenTop != undefined ? window.screenTop : screen.top;

                    var width = window.innerWidth ? window.innerWidth : document.documentElement.clientWidth ? document.documentElement.clientWidth : screen.width;
                    var height = window.innerHeight ? window.innerHeight : document.documentElement.clientHeight ? document.documentElement.clientHeight : screen.height;

                    var left = 1;//((width / 2) - (w / 2)) + dualScreenLeft;
                    var top = 1;//((height / 2) - (h / 2)) + dualScreenTop;
                    var newWindow = window.open("XemDangKyViecLam.aspx?id=" + value, "TIN TUYỂN DỤNG", 'scrollbars=yes, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left+',screenX=1,screenY=1');

                    if (window.focus) {
                        newWindow.focus();
                    }
                }
            }

            function XemDoanhNghiep(value) {
                var w = screen.width;
                var h = screen.height;

                var dualScreenLeft = window.screenLeft != undefined ? window.screenLeft : screen.left;
                var dualScreenTop = window.screenTop != undefined ? window.screenTop : screen.top;

                var width = window.innerWidth ? window.innerWidth : document.documentElement.clientWidth ? document.documentElement.clientWidth : screen.width;
                var height = window.innerHeight ? window.innerHeight : document.documentElement.clientHeight ? document.documentElement.clientHeight : screen.height;

                var left = ((width / 2) - (w / 2)) + dualScreenLeft;
                var top = ((height / 2) - (h / 2)) + dualScreenTop;
                var newWindow = window.open("DoanhNghiepView.aspx?id=" + value, "THÔNG TIN DOANH NGHIỆP", 'scrollbars=yes, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);

                if (window.focus) {
                    newWindow.focus();
                }
            }

            function XemThongTinTuyenDung(value) {
                var w = screen.width;
                var h = screen.height;

                var dualScreenLeft = window.screenLeft != undefined ? window.screenLeft : screen.left;
                var dualScreenTop = window.screenTop != undefined ? window.screenTop : screen.top;

                var width = window.innerWidth ? window.innerWidth : document.documentElement.clientWidth ? document.documentElement.clientWidth : screen.width;
                var height = window.innerHeight ? window.innerHeight : document.documentElement.clientHeight ? document.documentElement.clientHeight : screen.height;

                var left = ((width / 2) - (w / 2)) + dualScreenLeft;
                var top = ((height / 2) - (h / 2)) + dualScreenTop;
                var newWindow = window.open("TuyenDungView.aspx?id=" + value, "THÔNG TIN TUYỂN DỤNG", 'scrollbars=yes, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left + ',toolbar=0,location=0, directories=0, status=0,location=no,menubar=0');

                if (window.focus) {
                    newWindow.focus();
                }
            }
        </script>

    </form>
</body>
</html>
