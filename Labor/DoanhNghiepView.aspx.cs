using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Labor_DoanhNghiepView : System.Web.UI.Page
{
    #region declare objects
    public int itemId = 0;
    private DoanhNghiep objDoanhNghiep = new DoanhNghiep();
    #endregion

    #region Method Page_Load
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
            Response.Redirect("DoanhNghiep.aspx");
        }

        DataTable objdata = objDoanhNghiep.getDataViewById(itemId);
        if (objdata.Rows.Count > 0)
        {
            this.txtTenDonVi.Text = objdata.Rows[0]["TenDonVi"].ToString();
            this.ddlIDNganhNghe.Text = objdata.Rows[0]["NganhNgheName"].ToString();
            this.ddlIdLoaiHinh.Text = objdata.Rows[0]["NameLoaiHinh"].ToString();
            this.txtQuyMo.Text = objdata.Rows[0]["QuyMo"].ToString();
            this.txtDiaChi.Text = objdata.Rows[0]["DiaChi"].ToString();

            this.txtDienThoai.Text = objdata.Rows[0]["DienThoai"].ToString();
            this.txtEmail.Text = objdata.Rows[0]["Email"].ToString();
            this.ddlIDTinh.Text = objdata.Rows[0]["NameTinh"].ToString();
            this.ddlIDHuyen.Text = objdata.Rows[0]["NameHuyen"].ToString();
            this.txtDienThoaiDonVi.Text = objdata.Rows[0]["DienThoaiDonVi"].ToString();

            this.txtEmailDonVi.Text = objdata.Rows[0]["EmailDonVi"].ToString();
            this.txtWebsite.Text = objdata.Rows[0]["Website"].ToString();
            this.txtNguoiDaiDien.Text = objdata.Rows[0]["NguoiDaiDien"].ToString();
            this.txtDienThoai.Text = objdata.Rows[0]["DienThoai"].ToString();
            this.txtEmail.Text = objdata.Rows[0]["Email"].ToString();

            this.txtChucVu.Text = objdata.Rows[0]["ChucVu"].ToString();
            this.txtNgayDangKy.Text = DateTime.Parse(objdata.Rows[0]["NgayDangKy"].ToString()).ToString("dd/MM/yyyy");
            this.ckbNuocNgoai.Checked = bool.Parse(objdata.Rows[0]["NuocNgoai"].ToString());
            //this.ckbState.Checked = bool.Parse(objdata.Rows[0]["State"].ToString());
        }

    }
    #endregion
}