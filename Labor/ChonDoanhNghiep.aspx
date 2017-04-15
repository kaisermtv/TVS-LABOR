<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChonDoanhNghiep.aspx.cs" Inherits="Labor_ChonDoanhNghiep" %>

<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CHỌN DOANH NGHIỆP</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="../css/TVSStyle.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="../css/Adminstyle.css" />
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel='stylesheet' type='text/css' />
    <!-- Custom CSS -->
    <link href="../css/style.css" rel='stylesheet' type='text/css' />
    <!-- Graph CSS -->
    <link href="../css/font-awesome.css" rel="stylesheet" />
    <!-- jQuery -->
    <!-- lined-icons -->
    <link rel="stylesheet" href="../css/icon-font.min.css" type='text/css' />
</head>
<body style="margin: 0px !important; height: 600px !important;">
    <form id="form1" runat="server">
         <table class ="table">
            <tr>
                <td>
                    <input type ="text" id = "txtSearch" placeholder ="Nhập mã hoặc tên doanh nghiệp để tìm kiếm" runat ="server" class ="form-control" />
                </td>
                <td style ="width:40px !important; text-align:center;">
                    <asp:ImageButton ID="btnSearch" ImageUrl="../images/Search.png" runat="server" Style="margin-bottom: -15px; margin-left:-15px;" OnClick="btnSearch_Click" />
                </td>
            </tr>
        </table>
       
        <div style ="margin-top:-20px;">
            <div style="width: 100%;">
                <table class="DataListTableHeader" border="0">
                    <tr style="height: 40px;">
                        <td class="DataListTableHeaderTdItemTT" style="width: 3%;">#
                        </td>
                        <td class="DataListTableHeaderTdItemJustify" style="width: 52%;">Tên doanh nghiệp
                        </td>
                        <td class="DataListTableHeaderTdItemJustify" style="width: 32%;">Địa chỉ
                        </td>
                        <td class="DataListTableHeaderTdItemCenter" style="width: 13%;">Trạng thái
                        </td>
                    </tr>
                </table>
            </div>

            <asp:DataList ID="dtlDoanhNghiep" runat="server" RepeatDirection="Horizontal" RepeatColumns="1"
                Width="100%">
                <ItemTemplate>
                    <table class="DataListTable" border="0">
                        <tr style="height: 40px;">
                            <td class="DataListTableTdItemTT" style="width: 3%;">
                                <%# Eval("TT") %>
                            </td>
                            <td class="DataListTableTdItemJustify" style="width: 52%;">
                                <a href="#" onclick="return SetName('<%# Eval("IDDonVi") %>','<%# Eval("TenDonVi") %>');"><%# Eval("TenDonVi") %></a>
                            </td>
                            <td class="DataListTableTdItemJustify" style="width: 32%;">
                                <%# Eval("DiaChi") %>
                            </td>
                            <td class="DataListTableTdItemCenter" style="width: 13%;">
                                <%# Eval("StateName") %>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
            <table width="100%" cellpadding="0" cellspacing="0" border="0" style="margin-top: 5px; background-color: #fbf4f4; height: 26px;"
                id="tblABC" runat="server">
                <tr>
                    <td style="padding-left: 6px;">
                        <cc1:CollectionPager ID="cpDoanhNghiep" runat="server" BackText="" FirstText="Đầu"
                            ControlCssClass="ProductPage" LabelText="" LastText="Cuối" NextText="" UseSlider="true"
                            ResultsFormat="" BackNextLinkSeparator="" ResultsLocation="None" BackNextLocation="None"
                            PageNumbersSeparator="&nbsp;">
                        </cc1:CollectionPager>
                    </td>
                </tr>
            </table>

        </div>
        <script type="text/javascript">
            function SetName(value1, value2) {
                if (window.opener != null && !window.opener.closed) {
                    var txtNameId = window.opener.document.getElementById("MainContent_txtIDDonVi");
                    txtNameId.value = value1;

                    var txtName = window.opener.document.getElementById("MainContent_txtTenDonVi");
                    txtName.value = value2;
                }
                window.close();
            }
        </script>
    </form>
</body>
</html>
