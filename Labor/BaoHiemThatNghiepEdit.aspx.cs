using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Labor_BaoHiemThatNghiepEdit : System.Web.UI.Page
{
    #region declare
    private NguoiLaoDong objNguoiLaoDong = new NguoiLaoDong();


    public int itemId = 0;
    #endregion

    #region Even Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ACCOUNT"] == null)
        {
            Response.Redirect("../Login.aspx");
        }

        try
        {
            this.itemId = int.Parse(Request["id"].ToString());
        }
        catch
        {
            this.itemId = 0;
        }
        if (!Page.IsPostBack && itemId != 0)
        {
            DataTable objData = objNguoiLaoDong.getDataById(itemId);
            if (objData.Rows.Count == 0) Response.Redirect("BaoHiemThatNghiepEdit.aspx");
            DataRow objDataRow = objData.Rows[0];

            txtHoVaTen.Text = objDataRow["HoVaTen"].ToString();
            try
            {
                txtNgaySinh.Value = ((DateTime)objDataRow["NgaySinh"]).ToString("dd/MM/yyyy");
            }
            catch { }

            int gioitinh = (int)objDataRow["IDGioiTinh"];
            if (gioitinh == 1) chkGioiTinhNam.Checked = true;
            else if (gioitinh == 2) chkGioiTinhNu.Checked = true;

            txtCMND.Text = objDataRow["CMND"].ToString();
            try
            {
                txtNgayCap.Value = ((DateTime)objDataRow["NgayCapCMND"]).ToString("dd/MM/yyyy");
            }
            catch { }
            ddlNoiCap.SelectedValue = objDataRow["NoiCap"].ToString();

            txtSoDienThoai.Text = objDataRow["DienThoai"].ToString();
            txtNoiThuongTru.Text = objDataRow["NoiThuongTru"].ToString();

            txtSoTaiKhoan.Text = objDataRow["TaiKhoan"].ToString();
            ddlNganHang.SelectedValue = objDataRow["IDNganHang"].ToString();
            txtMaSoThue.Text = objDataRow["MaSoThue"].ToString();
            txtEmail.Text = objDataRow["Email"].ToString();

            txtBHXH.Text = objDataRow["BHXH"].ToString();
            try
            {
                txtNgayCapBHXH.Value = ((DateTime)objDataRow["NgayCapBHXH"]).ToString("dd/MM/yyyy");
            }
            catch { }
            ddlNoiCapBHXH.SelectedValue = objDataRow["NoiCapBHXH"].ToString();

            ddlNoiKhamBenh.SelectedValue = objDataRow["NoiDangKyKhamBenh"].ToString();
            ddlTDCM.SelectedValue = objDataRow["TrinhDoChuyenMon"].ToString();
            ddlLinhVucDT.SelectedValue = objDataRow["LinhVucDaoTao"].ToString();

            txtCongViecDaLam.Text = objDataRow["CongViecDaLam"].ToString();

        } else if (!Page.IsPostBack)
        {
            txtNgayDangKyTN.Value = DateTime.Now.ToString("dd/MM/yyyy");
        }
    }
    #endregion

    #region Even btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if(txtHoVaTen.Text.Trim() == "")
        {
            this.lblMsg.InnerText = "Bạn cần nhập họ tên!";
            return;
        }

        

        int gioitinh = 0;
        if(chkGioiTinhNam.Checked){
            gioitinh = 1;
        } else if(chkGioiTinhNu.Checked) {
            gioitinh = 2;
        }

        try
        {
            int ret = objNguoiLaoDong.setData(itemId, txtHoVaTen.Text, TVSSystem.CVDateNull(txtNgaySinh.Value), gioitinh, txtCMND.Text, TVSSystem.CVDateNull(txtNgayCap.Value), int.Parse(ddlNoiCap.SelectedValue), txtSoDienThoai.Text, txtNoiThuongTru.Text, txtSoTaiKhoan.Text,int.Parse(ddlNganHang.SelectedValue),txtMaSoThue.Text, txtEmail.Text, txtBHXH.Text, TVSSystem.CVDateNull(txtNgayCapBHXH.Value), int.Parse(ddlNoiCapBHXH.SelectedValue), int.Parse(ddlNoiKhamBenh.SelectedValue), int.Parse(ddlTDCM.SelectedValue), int.Parse(ddlLinhVucDT.SelectedValue), txtCongViecDaLam.Text);

            if (ret != 0)
            {
                Response.Redirect("BaoHiemThatNghiepEdit.aspx?id=" + ret);
            }
            else
            {
                this.lblMsg.InnerText = "Lỗi xảy ra khi cập nhật thông tin.";
            }
        }
        catch 
        {
            this.lblMsg.InnerText = "Lỗi xảy ra khi cập nhật thông tin.";
        }
    }
    #endregion
}