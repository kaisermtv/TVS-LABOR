﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="TuVanViecLamEdit.aspx.cs" Inherits="Admin_TuVanViecLamEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <script type="text/javascript">
        $(function () {
            $('#datetimepicker1').datetimepicker({
                format: 'DD/MM/YYYY'
            });
        });

        $(function () {
            $('#datetimepicker2').datetimepicker({
                format: 'DD/MM/YYYY'
            });
        });

    </script>

    <table border="0" style = "width:100%;">

        <tr style="height: 40px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">Người lao động:</td>
            <td style="width: 90%;" colspan="2">
                <input type = "hidden" id = "txtIDNguoiLaoDong" name = "txtIDNguoiLaoDong" runat = "server" />
                <asp:TextBox ID="txtTenNguoiLaoDong" runat="server" class="AdminTextControl" Style ="Width:94% !important;"></asp:TextBox>
                <button class="btn btn-primary" type="button" onclick="SelectName()" style="height: 30px !important; line-height: 14px !important; margin-top: -2px !important;">Chọn</button>
            </td>
        </tr>

        <tr style="height: 40px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">Nội dung tư vấn:</td>
            <td style="width: 90%;" colspan="2">
                <asp:TextBox ID="txtNoidung" runat="server" class="AdminTextControl"></asp:TextBox>
            </td>
        </tr>

        <tr style="height: 40px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">Kiểu tư vấn:</td>
            <td style = "width:20%;">
                <asp:DropDownList ID="ddlIDTuVan" AutoPostBack="true" runat="server" Style="width: 100%; height: 28px; line-height: 28px;">
                </asp:DropDownList>
            </td>
            <td>
                <table border="0" style="width: 100%;">
                    <tr>
                        <td style="text-align: right; padding-right: 5px; width: 12%;">Ngày tư vấn:
                        </td>
                        <td style="width: 60%;">
                            <div class='input-group date' id='datetimepicker2' style="margin-left: 0px; width: 160px !important;">
                                <input type='text' class="form-control" id="txtNgayTuVan" runat="server" />
                                <span class="input-group-addon">
                                    <span class="glyphicon glyphicon-calendar"></span>
                                </span>
                            </div>

                            <script type="text/javascript">
                                $(function () {
                                    $('#datetimepicker2').datetimepicker();
                                });
                            </script>
                        </td>
                        <td style="text-align: right; padding-right: 5px; width: 10%;">&nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>

        <tr style="height: 40px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">&nbsp;</td>
            <td style="width: 90%;" colspan="2">
                <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
            </td>
        </tr>

        <tr style="height: 40px;">
            <td style="width: 10%; text-align: right; padding-right: 5px;">&nbsp;</td>
            <td style="width: 90%;" colspan="2">
                <asp:Button ID="btnSave" runat="server" Text="Ghi nhận" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Thoát" CssClass="btn btn-default" OnClick="btnCancel_Click" />
            </td>
        </tr>

    </table>

    <script type="text/javascript">
        function SelectName() {

            var w = 1000;
            var h = 600;

            var dualScreenLeft = window.screenLeft != undefined ? window.screenLeft : screen.left;
            var dualScreenTop = window.screenTop != undefined ? window.screenTop : screen.top;

            var width = window.innerWidth ? window.innerWidth : document.documentElement.clientWidth ? document.documentElement.clientWidth : screen.width;
            var height = window.innerHeight ? window.innerHeight : document.documentElement.clientHeight ? document.documentElement.clientHeight : screen.height;

            var left = ((width / 2) - (w / 2)) + dualScreenLeft;
            var top = ((height / 2) - (h / 2)) + dualScreenTop;
            var newWindow = window.open("ChonNguoiLaoDong.aspx", "CHỌN NGƯỜI LAO ĐỘNG", 'scrollbars=yes, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);

            if (window.focus) {
                newWindow.focus();
            }
        }
    </script>

</asp:Content>

