<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="BaoHiemThatNghiep.aspx.cs" Inherits="Labor_BaoHiemThatNghiep" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
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
                        <td class="DataListTableHeaderTdItemCenter" style="width: 10%;">&nbsp;</td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate >
                <tr>
                    <td class="DataListTableTdItemTT">
                        <% if(IdDonVi != 0){ %>
                            <input type="checkbox" id ="ckb<% =index++ %>" value ="ckb<%# Eval("IDTuyenDung") %>" />
                        <% } else { %>
                            <%= index++ %>
                        <% } %>
                    </td>
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
                    <td class="DataListTableTdItemCenter">
                        <a href="#" onclick="XemTinTuyenDungLamViec('id=<%# Eval("IDTuyenDung") %>')"><img src="../Images/Print.png" /></a>
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
</asp:Content>

