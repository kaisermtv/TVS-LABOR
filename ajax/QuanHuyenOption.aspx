<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QuanHuyenOption.aspx.cs" Inherits="ajax_QuanHuyenOption" %>

<asp:repeater id="dtlData" runat="server" enableviewstate="False">
    <ItemTemplate>
        <option value="<%# Eval("Id") %>"><%# Eval("Name") %></option>
    </ItemTemplate>
</asp:repeater>