<%@ Page Title="NHÓM TÀI KHOẢN" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="EditGroupAccount.aspx.cs" Inherits="Admin_EditGroupAccount" %>

<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="AdminHeaderItem">
        THÔNG TIN NHÓM TÀI KHOẢN
    </div>
    <div class="AdminItem">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;Tên nhóm:
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtName" runat="server" class="AdminTextControl"></asp:TextBox>
        </div>
    </div>

    <div class="AdminItem" style ="display:table;">
        <div class="AdminLeftItem" style ="display:table;">
            &nbsp;&nbsp;Chức năng
        </div>
        <div class="AdminRightItem" style ="display:table;">
            <asp:DataList ID="dtlGroupPermission" runat="server" RepeatDirection="Horizontal" RepeatColumns="1"
                Width="100%">
                <ItemTemplate>
                    <table class="DataListTable" border="0">
                        <tr>
                            <td class="DataListTableTdItemTT" style="width: 4%;">
                                <%# Eval("TT") %>
                            </td>
                            <td class="DataListTableTdItemJustify" style="width: 55%;">
                                <%# Eval("FunctionName") %>
                            </td>
                            <td class="DataListTableTdItemCenter" style="width: 5%;">
                                <%# Eval("Xem") %>
                            </td>
                            <td class="DataListTableTdItemCenter" style="width: 5%;">
                                <%# Eval("Them") %>
                            </td>
                            <td class="DataListTableTdItemCenter" style="width: 5%;">
                                <%# Eval("Sua") %>
                            </td>
                            <td class="DataListTableTdItemCenter" style="width: 5%;">
                                <%# Eval("Xoa") %>
                            </td>
                            <td class="DataListTableTdItemCenter" style="width: 5%;">
                                <%# Eval("Khac") %>
                            </td>
                            <td class="DataListTableTdItemCenter" style="width: 8%;">
                                <a href="AddPermission?Fid=<%# Eval("FunctionId") %>&Gid=<%# Eval("GroupId") %>"><B>Cập nhật</B></a>
                            </td>
                            <td class="DataListTableTdItemCenter" style="width: 8%;">
                                <a href="DelPermission?Fid=<%# Eval("FunctionId") %>&Gid=<%# Eval("GroupId") %>"><B>Xóa quyền</B></a>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
            <table width="100%" cellpadding="0" cellspacing="0" border="0" style="margin-top: 5px; background-color: #fbf4f4; height: 26px;"
                id="tblABC" runat="server">
                <tr>
                    <td style="padding-left: 6px;">
                        <cc1:CollectionPager ID="cpGroupPermission" runat="server" BackText="" FirstText="Đầu"
                            ControlCssClass="ProductPage" LabelText="" LastText="Cuối" NextText="" UseSlider="true"
                            ResultsFormat="" BackNextLinkSeparator="" ResultsLocation="None" BackNextLocation="None"
                            PageNumbersSeparator="&nbsp;">
                        </cc1:CollectionPager>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div style="width: 100%; height: 35px; line-height: 35px; margin-top: 10px;">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;
        </div>
        <div class="AdminRightItem">
            <asp:CheckBox ID="ckbState" Text="&nbsp;&nbsp;Kích hoạt" runat="server" Style="font-weight: normal;" />&nbsp;&nbsp;<asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;
        </div>
        <div class="AdminRightItem">
            <asp:Button ID="btnSave" runat="server" Text="Ghi nhận" CssClass="btn btn-primary" OnClick="btnSave_Click" />
            &nbsp;
            <a href="AddPermission.aspx?Gid=<%Response.Write(this.itemId.ToString()); %>">
                <input type="button" class="btn btn-primary" value="Thêm quyền" style="width: 110px !important;" /></a>
            &nbsp;
            <asp:Button ID="btnCancel" runat="server" Text="Thoát" CssClass="btn btn-default" OnClick="btnCancel_Click" />
        </div>
    </div>

</asp:Content>

