using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_DoanhNghiepEdit : System.Web.UI.Page
{
    #region declare objects
    public int itemId = 0;
    private Account objAccount = new Account();
    private DoanhNghiep objDoanhNghiep = new DoanhNghiep();
    private LoaiHinh objLoaiHinh = new LoaiHinh();
    private Business objBusiness = new Business();
    private Provincer objProvincer = new Provincer();
    private District objDistrict = new District();
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
        Session["TITLE"] = "CẬP NHẬT HỒ SƠ DOANH NGHIỆP";
        ////if (!this.objAccount.checkForFunction(Session["ACCOUNT"].ToString(), 3, ref View, ref Add, ref Edit, ref Del, ref Orther))
        ////{
        ////    Response.Redirect("NoPermission.aspx");
        ////}
        try
        {
            this.itemId = int.Parse(Request["id"].ToString());
        }
        catch
        {
            this.itemId = 0;
        }
        this.txtIDDoanhNghiep.Value = this.itemId.ToString();

        try
        {
            lblMsg.Text = Session["lblMsg"].ToString();
            Session["lblMsg"] = null;
        }
        catch { }
        

        if (!Page.IsPostBack)
        {
            this.ddlIDNganhNghe.DataSource = this.objBusiness.getDataCategoryToCombobox();
            this.ddlIDNganhNghe.DataTextField = "Name";
            this.ddlIDNganhNghe.DataValueField = "Id";
            this.ddlIDNganhNghe.DataBind();

            this.ddlIdLoaiHinh.DataSource = this.objLoaiHinh.getDataCategoryToCombobox();
            this.ddlIdLoaiHinh.DataTextField = "NameLoaiHinh";
            this.ddlIdLoaiHinh.DataValueField = "IdLoaiHinh";
            this.ddlIdLoaiHinh.DataBind();

            this.ddlIDTinh.DataSource = this.objProvincer.getDataCategoryToCombobox();
            this.ddlIDTinh.DataTextField = "Name";
            this.ddlIDTinh.DataValueField = "Id";
            this.ddlIDTinh.DataBind();

            if (this.ddlIDTinh.Items.Count > 0)
            {
                this.ddlIDHuyen.DataSource = this.objDistrict.getDataCategoryToCombobox(this.ddlIDTinh.SelectedValue.ToString());
                this.ddlIDHuyen.DataTextField = "Name";
                this.ddlIDHuyen.DataValueField = "Id";
                this.ddlIDHuyen.DataBind();
            }
        }
        if (!Page.IsPostBack && this.itemId > 0)
        {
            this.objTable = this.objDoanhNghiep.getDataById(this.itemId);
            if (this.objTable.Rows.Count > 0)
            {
                this.txtMaDonVi.Text = this.objTable.Rows[0]["MaDonVi"].ToString();
                this.txtTenDonVi.Text = this.objTable.Rows[0]["TenDonVi"].ToString();
                this.ddlIDNganhNghe.SelectedValue = this.objTable.Rows[0]["IDNganhNghe"].ToString();
                this.ddlIdLoaiHinh.SelectedValue = this.objTable.Rows[0]["IdLoaiHinh"].ToString();
                this.txtQuyMo.Text = this.objTable.Rows[0]["QuyMo"].ToString();
                this.txtDiaChi.Text = this.objTable.Rows[0]["DiaChi"].ToString();

                this.txtDienThoai.Text = this.objTable.Rows[0]["DienThoai"].ToString();
                this.txtEmail.Text = this.objTable.Rows[0]["Email"].ToString();
                this.ddlIDTinh.SelectedValue = this.objTable.Rows[0]["IDTinh"].ToString();
                this.ddlIDHuyen.SelectedValue = this.objTable.Rows[0]["IDHuyen"].ToString();
                this.txtDienThoaiDonVi.Text = this.objTable.Rows[0]["DienThoaiDonVi"].ToString();
                
                this.txtEmailDonVi.Text = this.objTable.Rows[0]["EmailDonVi"].ToString();
                this.txtWebsite.Text = this.objTable.Rows[0]["Website"].ToString();
                this.txtNguoiDaiDien.Text = this.objTable.Rows[0]["NguoiDaiDien"].ToString();
                this.txtDienThoai.Text = this.objTable.Rows[0]["DienThoai"].ToString();
                this.txtEmail.Text = this.objTable.Rows[0]["Email"].ToString();

                this.txtChucVu.Text = this.objTable.Rows[0]["ChucVu"].ToString();
                this.txtNgayDangKy.Value = DateTime.Parse(this.objTable.Rows[0]["NgayDangKy"].ToString()).ToString("dd/MM/yyyy");
                this.ckbNuocNgoai.Checked = bool.Parse(this.objTable.Rows[0]["NuocNgoai"].ToString());
                this.ckbState.Checked = bool.Parse(this.objTable.Rows[0]["State"].ToString());
            }
        }
        this.txtMaDonVi.Focus();
    }
    #endregion

    #region method btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        this.lblMsg.Text = "";

        if (this.txtTenDonVi.Text.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập tên của đơn vị";
            this.txtTenDonVi.Focus();
            return;
        }

        if (this.ddlIDNganhNghe.SelectedValue.ToString() == "0")
        {
            this.lblMsg.Text = "Bạn chưa chọn ngành nghề kinh doanh";
            this.ddlIDNganhNghe.Focus();
            return;
        }

        if (this.txtDiaChi.Text.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập địa chỉ của doanh nghiệp";
            this.txtDiaChi.Focus();
            return;
        }

        if (this.txtNgayDangKy.Value.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập ngày đăng ký hồ sơ";
            this.txtNgayDangKy.Focus();
            return;
        }

        if (this.objDoanhNghiep.setData(ref this.itemId,this.txtMaDonVi.Text,this.txtTenDonVi.Text,int.Parse(this.ddlIDNganhNghe.SelectedValue.ToString()), int.Parse(this.ddlIdLoaiHinh.SelectedValue.ToString()), this.txtQuyMo.Text, this.txtDiaChi.Text,int.Parse(this.ddlIDHuyen.SelectedValue.ToString()),int.Parse(this.ddlIDTinh.SelectedValue.ToString()),this.txtDienThoaiDonVi.Text,this.txtEmailDonVi.Text,this.txtWebsite.Text,this.txtNguoiDaiDien.Text, this.txtDienThoai.Text, this.txtEmail.Text, this.txtChucVu.Text, TVSSystem.CVDate(this.txtNgayDangKy.Value.ToString()),this.ckbNuocNgoai.Checked,this.ckbState.Checked) == 1)
        {
            Session["lblMsg"] = "Cập nhật thông tin thành công!";


            Response.Redirect("DoanhNghiepEdit.aspx?id=" + this.itemId);
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
        Response.Redirect("DoanhNghiep.aspx");
    }
    #endregion

    #region method ddlProvincer_SelectedIndexChanged
    protected void ddlIDTinh_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.ddlIDHuyen.DataSource = this.objDistrict.getDataCategoryToCombobox(this.ddlIDTinh.SelectedValue.ToString());
        this.ddlIDHuyen.DataTextField = "Name";
        this.ddlIDHuyen.DataValueField = "Id";
        this.ddlIDHuyen.DataBind();
    }
    #endregion

    #region method btnRedirect_Click
    protected void btnRedirect_Click(object sender, EventArgs e)
    {
        Response.Redirect("TuyenDungEdit.aspx?did=" + itemId + "&n=" + HttpUtility.UrlEncode(this.txtTenDonVi.Text));
    } 
    #endregion
}