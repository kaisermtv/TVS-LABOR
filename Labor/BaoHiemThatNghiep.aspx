<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="BaoHiemThatNghiep.aspx.cs" Inherits="Labor_BaoHiemThatNghiep" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

    <table style="margin-top:-10px; margin-right:-15px!important; width:100%!important;padding:0px!important;" border ="0">
        <tr>
            <td>
                <input type="text" id="txtSearch" placeholder="Nhập tên NLĐ, số CMND, số BHXH, số điện thoại để tìm kiếm" runat="server" class="form-control" />
            </td>
            <td style="width: 40px !important; text-align: center;">
                <asp:ImageButton ID="btnSearch" ImageUrl="../images/Search.png" runat="server" Style="margin-top:5px;" />
            </td>
            <td style="width: 90px !important; text-align: center;">
                <a href ="BaoHiemThatNghiepEdit.aspx"><input type ="button" class ="btn btn-primary" value ="Tạo hồ sơ" /></a>
            </td>
        </tr>
    </table>

</asp:Content>

