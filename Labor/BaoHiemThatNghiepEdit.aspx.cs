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
    private DoanhNghiep objDoanhNghiep = new DoanhNghiep();
    private NLDTroCapThatNghiep objNLDTroCapThatNghiep = new NLDTroCapThatNghiep();

    private LoaiHinh objLoaiHinh = new LoaiHinh();
    private Business objBusiness = new Business();

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
        if (!Page.IsPostBack)
        {
            this.ddlIdNganhNgheDN.DataSource = this.objBusiness.getDataCategoryToCombobox();
            this.ddlIdNganhNgheDN.DataTextField = "Name";
            this.ddlIdNganhNgheDN.DataValueField = "Id";
            this.ddlIdNganhNgheDN.DataBind();
            ddlIdNganhNgheDN.SelectedValue = "0";

            this.ddlLoaiHinhDN.DataSource = this.objLoaiHinh.getDataCategoryToCombobox();
            this.ddlLoaiHinhDN.DataTextField = "NameLoaiHinh";
            this.ddlLoaiHinhDN.DataValueField = "IdLoaiHinh";
            this.ddlLoaiHinhDN.DataBind();

            ddlLoaiHinhDN.SelectedValue = "0";
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

            int idDonVi = 0;
            try
            {
                idDonVi = (int)objDataRow["IdDoanhNghiep"];
            }
            catch { }
            
            if(idDonVi != 0)
            {
                DataTable objDataDN = objDoanhNghiep.getDataById(idDonVi);
                if (objDataDN.Rows.Count > 0)
                {
                    DataRow objDataRowDN = objDataDN.Rows[0];

                    txtIDDonVi.Value = objDataRowDN["IDDonVi"].ToString();
                    txtTenDonVi.Text = objDataRowDN["TenDonVi"].ToString();
                    txtDiaChiDN.Text = objDataRowDN["DiaChi"].ToString();
                    txtPhoneDN.Text = objDataRowDN["DienThoaiDonVi"].ToString();
                    txtFaxDN.Text = objDataRowDN["FaxDonVi"].ToString();
                    txtSoDKKD.Text = objDataRowDN["SoDKKD"].ToString();
                    ddlLoaiHinhDN.SelectedValue = objDataRowDN["IdLoaiHinh"].ToString();
                    ddlIdNganhNgheDN.SelectedValue = objDataRowDN["IDNganhNghe"].ToString();
                    txtEmailDN.Text = objDataRowDN["EmailDonVi"].ToString();
                    txtWebsiteDN.Text = objDataRowDN["Website"].ToString();

                    btnXoaDonVi.Disabled = false;

                }
            }

            DataRow objDataTroCap = objNLDTroCapThatNghiep.getItemByNLD(itemId);
            if(objDataTroCap != null)
            {
                try
                {
                    txtNgayNghiViec.Value = ((DateTime)objDataTroCap["NgayNghiViec"]).ToString("dd/MM/yyyy");
                }catch {}
                txtSoThangDongBHXH.Text = objDataTroCap["SoThangBHTN"].ToString();

                chkTuVan.Checked = (bool)objDataTroCap["NhuCauTuVan"];
                chkGioiThieu.Checked = (bool)objDataTroCap["NhuCauGTVL"];
                chkHocNghe.Checked = (bool)objDataTroCap["NhuCauHocNghe"];
                try
                {
                    txtNgayDangKyTN.Value = ((DateTime)objDataTroCap["NgayDangKyTN"]).ToString("dd/MM/yyyy");
                }
                catch { }
                

                chkDangKyTre.Checked = (bool)objDataTroCap["DangKyTre"];

                ddlDangKyTre.SelectedValue = objDataTroCap["DangKyTreLyDo"].ToString();
                ddlNguoiTiepNhan.SelectedValue = objDataTroCap["NoiTiepNhan"].ToString();
                try
                {
                    txtNgayHoanThien.Value = ((DateTime)objDataTroCap["NgayHoanThien"]).ToString("dd/MM/yyyy");
                }
                catch { }
                

                ddlNoiNhanbaoHiem.SelectedValue = objDataTroCap["NoiNhanBaoHiem"].ToString();

                int htnt = (int)objDataTroCap["HinhThucNhanTien"];
                cbkATM.Checked = (htnt == 1);
                cbkTienMat.Checked = (htnt == 2);

                ddlNoiChotSoCuoi.SelectedValue = objDataTroCap["NoiChotSoCuoi"].ToString();

                chkXacNhanDangKy.Checked = (bool)objDataTroCap["DaXacNhanChuaDangKy"];
                ddlNoiDKXacNhan.SelectedValue = objDataTroCap["NoiXacNhanChuaDangKy"].ToString();
            }

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

        int idDonVi = 0;
        try
        {
            idDonVi = int.Parse(txtIDDonVi.Value.Trim());
        }
        catch { }

        idDonVi = objDoanhNghiep.setData(idDonVi, txtTenDonVi.Text, txtDiaChiDN.Text, txtPhoneDN.Text, txtFaxDN.Text, txtSoDKKD.Text, int.Parse(ddlLoaiHinhDN.SelectedValue), int.Parse(ddlIdNganhNgheDN.SelectedValue), txtEmailDN.Text, txtWebsiteDN.Text);

        if (idDonVi == 0)
        {
            this.lblMsg.InnerText = "Lỗi xảy ra khi cập nhật thông tin.";
            return;
        }

        try
        {
            itemId = objNguoiLaoDong.setData(itemId, txtHoVaTen.Text, TVSSystem.CVDateNull(txtNgaySinh.Value), gioitinh, txtCMND.Text, TVSSystem.CVDateNull(txtNgayCap.Value), int.Parse(ddlNoiCap.SelectedValue), txtSoDienThoai.Text, txtNoiThuongTru.Text, txtSoTaiKhoan.Text, int.Parse(ddlNganHang.SelectedValue), txtMaSoThue.Text, txtEmail.Text, txtBHXH.Text, TVSSystem.CVDateNull(txtNgayCapBHXH.Value), int.Parse(ddlNoiCapBHXH.SelectedValue), int.Parse(ddlNoiKhamBenh.SelectedValue), int.Parse(ddlTDCM.SelectedValue), int.Parse(ddlLinhVucDT.SelectedValue), txtCongViecDaLam.Text, idDonVi);
        }
        catch 
        {
            this.lblMsg.InnerText = "Lỗi xảy ra khi cập nhật thông tin.";
            return;
        }

        if (itemId == 0)
        {
            this.lblMsg.InnerText = "Lỗi xảy ra khi cập nhật thông tin.";
            return;
        }

        int HinhThucNhanTien = 0;
        if (cbkATM.Checked) HinhThucNhanTien = 1;
        else if (cbkTienMat.Checked) HinhThucNhanTien = 2;
        try
        {
            objNLDTroCapThatNghiep.setDataByNLD(itemId, TVSSystem.CVDateNull(txtNgayNghiViec.Value), float.Parse(txtSoThangDongBHXH.Text), chkTuVan.Checked, chkGioiThieu.Checked, chkHocNghe.Checked, TVSSystem.CVDateNull(txtNgayDangKyTN.Value), chkDangKyTre.Checked, int.Parse(ddlDangKyTre.SelectedValue), int.Parse(ddlNguoiTiepNhan.SelectedValue), TVSSystem.CVDateNull(txtNgayHoanThien.Value), int.Parse(ddlNoiNhanbaoHiem.SelectedValue), HinhThucNhanTien, int.Parse(ddlNoiChotSoCuoi.SelectedValue), chkXacNhanDangKy.Checked, int.Parse(ddlNoiDKXacNhan.SelectedValue));
        }
        catch { }


        Response.Redirect("BaoHiemThatNghiepEdit.aspx?id=" + itemId);
    }
    #endregion
}