<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctLog.ascx.cs" Inherits="uctLog" %>
<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
   <link href="../css/Adminstyle.css" rel="stylesheet" type="text/css" />
   <style>
        .DataListTable td {
            padding-top: 5px;
            padding-bottom: 5px;
        }
        .khongkhaibao {
            padding: 3px;
            padding-left: 8px;
            padding-right: 8px;
            background-color: #ff6a00;
            color: #fff;
            font-size: 12px;
            margin-left:10px;
        }
        .dakhaibao {
            padding: 3px;
            padding-left: 8px;
            padding-right: 8px;
            background-color: #79CD53;
            color: #fff;
            font-size: 12px;
            margin-left:10px;
        }
        .chothongbao {
            padding: 3px;
            padding-left: 8px;
            padding-right: 8px;
            background-color: #c0c0c0;
            color: #fff;
            font-size: 12px;
            margin-left:10px;
        }
         .quahanthongbao {
            padding: 3px;
            padding-left: 8px;
            padding-right: 8px;
            background-color: #000;
            color: #fff;
            font-size: 12px;
            margin-left:10px;
        }

        label {
            padding: 6px 12px;
        }
    </style>
<asp:Label ID="lblMessage" runat="server" Text="Label"></asp:Label>
<div class="row line"> 
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
      <asp:Repeater ID="dtlData" runat="server">
            <HeaderTemplate>
                <table class="DataListTable" border="0" style="width: 95%; margin-top: 10px; position:absolute">
                    <tr style="height: 40px;" class="DataListTableHeader">  
                        <td class="DataListTableHeaderTdItemJustify" style="text-align:center; width:5%">STT</td>                  
                        <td class="DataListTableHeaderTdItemJustify" style="text-align:left; width:20%">Hành động</td>
                        <td class="DataListTableHeaderTdItemJustify" style="text-align:left;">Lý do</td>
                        <td class="DataListTableHeaderTdItemJustify" style="text-align:center; width:10%">Người TH</td>                    
                        <td class="DataListTableHeaderTdItemJustify" style="text-align:center; width:10%">Ngày</td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>  
                    <td class="DataListTableTdItemJustify" style="text-align:center; width:5%"><%#  Container.ItemIndex +1 %></td>                   
                    <td class="DataListTableTdItemJustify"><%# Eval("Action")%></td>    
                     <td class="DataListTableTdItemJustify"><%# Eval("GhiChu")%></td>                  
                    <td class="DataListTableTdItemJustify" style="text-align:center; width:20%"><%# Eval("UserName")%></td>
                    <td class="DataListTableTdItemJustify" style="text-align:center; width:20%"><%# ((DateTime)Eval("NgayTao")).ToString("dd/MM/yyyy")%></td>       
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
                        PageNumbersSeparator="&nbsp;" PagingMode="PostBack" ShowPageNumbers="True">
                    </cc1:CollectionPager>
                </td>
            </tr>
        </table>
    </ContentTemplate>
    </asp:UpdatePanel>


</div>
<script>
    var _msg = '<%=_msg%>';
    if (_msg != '') {
        alert(_msg);
    }
</script>
