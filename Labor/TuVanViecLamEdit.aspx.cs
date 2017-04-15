using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_TuVanViecLamEdit : System.Web.UI.Page
{
    #region declare objects
    private int itemId = 0;
    private Account objAccount = new Account();
    private NguoiLaoDong objNguoiLaoDong = new NguoiLaoDong();
    private TuVan objTuVan = new TuVan();
    private DataTable objTable = new DataTable();
    private bool View = false, Add = false, Edit = false, Del = false, Orther = false;
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ACCOUNT"] == null)
        {
            Response.Redirect("../Login.aspx");
        }
        Session["TITLE"] = "HỒ SƠ TƯ VẤN VIỆC LÀM";
        //if (!this.objAccount.checkForFunction(Session["ACCOUNT"].ToString(), 3, ref View, ref Add, ref Edit, ref Del, ref Orther))
        //{
        //    Response.Redirect("NoPermission.aspx");
        //}
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
            this.ddlIDTuVan.DataSource = this.objTuVan.getDataCategoryToCombobox();
            this.ddlIDTuVan.DataTextField = "NameTuVan";
            this.ddlIDTuVan.DataValueField = "IDTuVan";
            this.ddlIDTuVan.DataBind();
        }
        if (!Page.IsPostBack && this.itemId > 0)
        {
            this.objTable = this.objNguoiLaoDong.getDataTblNldTuVanById(this.itemId);
            if (this.objTable.Rows.Count > 0)
            {
                this.txtIDNguoiLaoDong.Value = this.objTable.Rows[0]["IDNguoiLaoDong"].ToString();
                this.txtTenNguoiLaoDong.Text = this.objTable.Rows[0]["HoVaTen"].ToString();
                this.txtNoidung.Text = this.objTable.Rows[0]["Noidung"].ToString();
                this.txtNgayTuVan.Value = DateTime.Parse(this.objTable.Rows[0]["NgayTuVan"].ToString()).ToString();
                this.ddlIDTuVan.SelectedValue = this.objTable.Rows[0]["IDTuVan"].ToString();
            }
        }

        this.txtTenNguoiLaoDong.Focus();
    }
    #endregion

    #region method btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        this.lblMsg.Text = "";

        if (this.txtIDNguoiLaoDong.Value.ToString().Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa chọn người lao động cần tư vấn";
            this.txtIDNguoiLaoDong.Focus();
            return;
        }

        if (this.txtNoidung.Text.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập nội dung tư vấn";
            this.txtNoidung.Focus();
            return;
        }

        if (this.txtNgayTuVan.Value.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập ngày tư vấn";
            this.txtNgayTuVan.Focus();
            return;
        }

        if (this.objNguoiLaoDong.setDataTblNldTuVan(ref this.itemId, int.Parse(this.txtIDNguoiLaoDong.Value.ToString()), int.Parse(this.ddlIDTuVan.SelectedValue.ToString()), this.txtNoidung.Text, DateTime.Parse(this.txtNgayTuVan.Value.ToString()), Session["ACCOUNT"].ToString()) == 1)
        {
            Response.Redirect("TuVanViecLamEdit.aspx?id=" + this.itemId);
        }
        else
        {
            this.lblMsg.Text = "Lỗi xảy ra khi cập nhật thông tin.";
        }
    }
    #endregion

    #region method btnCancel_Click
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("TuVanViecLam.aspx");
    }
    #endregion
}