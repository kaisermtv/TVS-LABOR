<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin.master" CodeFile="DtKhoaHocEdit.aspx.cs" Inherits="Labor_DtKhoaHocEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="AdminItem">
        <div class="AdminLeftItem">
            Mã khóa học:
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtMaKhoaHoc" runat="server" class="form-control"></asp:TextBox>
        </div>
    </div>

    <div class="AdminItem" style="margin-top: 10px;">
        <div class="AdminLeftItem">
            Tên khóa học:
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtNameKhoaHoc" runat="server" class="form-control"></asp:TextBox>
        </div>
    </div>

    <div class="AdminItem" style="margin-top: 10px;">
        <div class="AdminLeftItem">
            Loại khóa học:
        </div>
        <div class="AdminRightItem">
            <asp:DropDownList ID="ddlLoaiKhoaHoc" runat="server" class="form-control">
                <asp:ListItem Value ="1" Text ="Học nghề"></asp:ListItem>
                <asp:ListItem Value ="2" Text ="Học tiếng"></asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>

    <div class="AdminItem" style="margin-top: 10px;">
        <div class="AdminLeftItem">
            Mức hỗ trợ:
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtMucHoTro" type="number" runat="server" class="form-control"></asp:TextBox>
        </div>
    </div>

    <div class="AdminItem" style="margin-top: 10px;">
        <div class="AdminLeftItem">
            Thời gian học:
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtThoiGianHoc" runat="server" class="form-control"></asp:TextBox>
        </div>
    </div>

    <div class="AdminItem" style="margin-top: 10px;">
        <div class="AdminLeftItem">
            Đơn vị:
        </div>
        <div class="AdminRightItem">
            <input type="hidden" name="txtIDDonVi" id="txtIDDonVi" runat="server" />
            <asp:TextBox ID="txtTenDonVi" ReadOnly="true" runat="server" CssClass="form-control" Style="width: 93.5% !important; float: left;"></asp:TextBox>
            <button class="btn btn-primary" type="button" onclick="SelectName()" style="height: 34px !important; margin-left: 10px; line-height: 14px !important;">Chọn</button>
        </div>
    </div>

    <div style="width: 100%; height: 35px; line-height: 35px; margin-top: 10px;">
        <div class="AdminLeftItem">
            Trạng thái: 
        </div>
        <div class="AdminRightItem">
            <asp:CheckBox ID="ckbState" Text="&nbsp;&nbsp;Kích hoạt" runat="server" Style="font-weight: normal;" />
        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;
        </div>
        <div class="AdminRightItem">
            <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;
        </div>
        <div class="AdminRightItem">
            <asp:Button ID="btnSave" runat="server" Text="Ghi nhận" CssClass="btn btn-primary" OnClick="btnSave_Click" />
            <a href="DtKhoaHocList.aspx" class="btn btn-default">Thoát</a>
        </div>
    </div>

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
             var newWindow = window.open("ChonDoanhNghiep1.aspx", "CHỌN DOANH NGHIỆP", 'scrollbars=yes, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);

             if (window.focus) {
                 newWindow.focus();
             }
         }
    </script>

</asp:Content>

