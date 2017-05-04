using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Labor_DtKhoaHocEdit : System.Web.UI.Page
{
    #region declare objects
    private int itemId = 0;
    #endregion

    #region Page_Load
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
        if (!Page.IsPostBack && this.itemId > 0)
        {
            DtKhoaHoc objDtKhoaHoc = new DtKhoaHoc();

            DataRow objData = objDtKhoaHoc.getItem(itemId);
            if (objData != null)
            {
                txtMaKhoaHoc.Text = objData["CodeKhoaHoc"].ToString();
                txtNameKhoaHoc.Text = objData["NameKhoaHoc"].ToString();
                txtThoiGianHoc.Text = objData["ThoiGianHoc"].ToString();
                txtMucHoTro.Text = objData["MucHoTro"].ToString();
                this.txtIDDonVi.Value = objData["IDDtDonvi"].ToString();
                this.txtTenDonVi.Text = objData["TenDonVi"].ToString();
                this.ddlLoaiKhoaHoc.SelectedValue = objData["LoaiKhoaHoc"].ToString(); 
                this.ckbState.Checked = (bool)objData["State"];
            }

        }
        this.txtMaKhoaHoc.Focus();
        Session["TITLE"] = "THÔNG TIN ĐÀO TẠO NGHỀ";
    }
    #endregion

    #region btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        this.lblMsg.Text = "";

        if (this.txtNameKhoaHoc.Text.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập tên khóa học";
            this.txtNameKhoaHoc.Focus();
            return;
        }

        float mht = 0;
        try{
            mht = float.Parse(txtMucHoTro.Text.Trim());
        } catch {
            this.lblMsg.Text = "Định dạng mức hỗ trợ chưa đúng";
            this.txtMucHoTro.Focus();
            return;
        }

        int iddonvi = 0;

        if (this.txtIDDonVi.Value == "" || this.txtIDDonVi.Value == "0")
        {
            this.lblMsg.Text = "Bạn chưa chọn đơn vị đào tạo";
            return;
        }

        try
        {
            iddonvi = int.Parse(this.txtIDDonVi.Value.ToString());
        }
        catch { }

        int loaikh = 0;
        try
        {
            loaikh = int.Parse(ddlLoaiKhoaHoc.SelectedValue);
        }
        catch { }

        DtKhoaHoc objDtKhoaHoc = new DtKhoaHoc();
        int ret = objDtKhoaHoc.setData(itemId, txtMaKhoaHoc.Text.Trim(), txtNameKhoaHoc.Text.Trim(), txtThoiGianHoc.Text.Trim(), mht, iddonvi, loaikh, ckbState.Checked);

        if (ret == 0)
        {
            this.lblMsg.Text = "Có lỗi xảy ra!";
        }
        else
        {
            Response.Redirect("DtKhoaHocList.aspx?id=" + ret);
        }
    }
    #endregion
}