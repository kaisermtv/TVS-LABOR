<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PhuongXaOption.aspx.cs" Inherits="ajax_PhuongXaOption" %>

<asp:repeater id="dtlData" runat="server" enableviewstate="False">
    <ItemTemplate>
        <option value="<%# Eval("Id") %>"><%# Eval("Name") %></option>
    </ItemTemplate>
</asp:repeater>