using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_QuaTrinhCongTac : System.Web.UI.Page
{
    #region declare objects
    private DataTable objTable = new DataTable();
    private Account objAccount = new Account();
    private NguoiLaoDong objNguoiLaoDong = new NguoiLaoDong();
    private ChucVu objChucVu = new ChucVu();
    private LinhVuc objLinhVuc = new LinhVuc();
    private SearchConfig objSearchConfig = new SearchConfig();
    private int IDNldQuaTrinhCongTac = 0, IDNguoiLaoDong = 0;
    private bool View = false, Add = false, Edit = false, Del = false, Orther = false;
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ACCOUNT"] == null)
        {
            Response.Redirect("../Login.aspx");
        }
        //if (!this.objAccount.checkForFunction(Session["ACCOUNT"].ToString(), 3, ref View, ref Add, ref Edit, ref Del, ref Orther))
        //{
        //    Response.Redirect("NoPermission.aspx");
        //}
        try
        {
            this.IDNldQuaTrinhCongTac = int.Parse(Request.QueryString["idCT"].ToString());
        }
        catch
        {
            this.IDNldQuaTrinhCongTac = 0;
        }
        try
        {
            this.IDNguoiLaoDong = int.Parse(Request.QueryString["id"].ToString());
        }
        catch
        {
            this.IDNguoiLaoDong = 0;
        }
        if (!Page.IsPostBack)
        {
            this.ddlChucVu.DataSource = this.objChucVu.getDataCategoryToCombobox();
            this.ddlChucVu.DataTextField = "NameChucVu";
            this.ddlChucVu.DataValueField = "IDChucVu";
            this.ddlChucVu.DataBind();

            this.ddlIDLinhVuc.DataSource = this.objLinhVuc.getDataCategoryToCombobox();
            this.ddlIDLinhVuc.DataTextField = "NameLinhVuc";
            this.ddlIDLinhVuc.DataValueField = "IDLinhVuc";
            this.ddlIDLinhVuc.DataBind();

            this.objTable = this.objNguoiLaoDong.getDataNldQuatrinhCongTacById(this.IDNldQuaTrinhCongTac);
            if (this.objTable.Rows.Count > 0)
            {
                this.txtDonVi.Text = this.objTable.Rows[0]["DonVi"].ToString();
                this.ddlChucVu.SelectedValue = this.objTable.Rows[0]["IDChucVu"].ToString();
                this.ddlIDLinhVuc.SelectedValue = this.objTable.Rows[0]["IDLinhVuc"].ToString();
                this.txtNgayBatDau.Value = DateTime.Parse(this.objTable.Rows[0]["NgayBatDau"].ToString()).ToString("MM/yyyy");
                this.txtNgayKetThuc.Value = DateTime.Parse(this.objTable.Rows[0]["NgayKetThuc"].ToString()).ToString("MM/yyyy");
            }

            this.getData();

            this.txtDonVi.Focus();
        }
    }
    #endregion

    #region getData()
    private void getData()
    {
        this.objTable = this.objNguoiLaoDong.getDataNldQuatrinhCongTac(this.IDNguoiLaoDong);
        cpNldQuatrinhCongTac.MaxPages = 1000;
        cpNldQuatrinhCongTac.PageSize = 15;
        cpNldQuatrinhCongTac.DataSource = this.objTable.DefaultView;
        cpNldQuatrinhCongTac.BindToControl = dtlNldQuatrinhCongTac;
        dtlNldQuatrinhCongTac.DataSource = cpNldQuatrinhCongTac.DataSourcePaged;
        dtlNldQuatrinhCongTac.DataBind();
        if (this.objTable.Rows.Count < 9)
        {
            this.tblABC.Visible = false;
        }
        else
        {
            this.tblABC.Visible = true;
        }
    }
    #endregion

    #region method btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (this.IDNguoiLaoDong > 0)
        {
            this.lblMsg.Text = "";

            if (this.txtDonVi.Text == "")
            {
                this.lblMsg.Text = "Bạn chưa nhập tên đơn vị";
                this.txtDonVi.Focus();
                return;
            }

            if (this.txtNgayBatDau.Value.Trim() == "")
            {
                this.lblMsg.Text = "Bạn chưa nhập ngày bắt đầu công tác";
                this.txtNgayBatDau.Value = DateTime.Now.ToString();
                this.txtNgayBatDau.Focus();
                return;
            }

            if (this.txtNgayKetThuc.Value.Trim() == "")
            {
                this.lblMsg.Text = "Bạn chưa nhập ngày kết thúc công tác";
                this.txtNgayKetThuc.Value = DateTime.Now.ToString();
                this.txtNgayKetThuc.Focus();
                return;
            }

            if (this.objNguoiLaoDong.setDataNldQuatrinhCongTac(this.IDNldQuaTrinhCongTac, this.IDNguoiLaoDong, this.txtDonVi.Text, int.Parse(this.ddlIDLinhVuc.SelectedValue.ToString()), int.Parse(this.ddlChucVu.SelectedValue.ToString()), TVSSystem.CVDate("01/" + this.txtNgayBatDau.Value.Trim()), TVSSystem.CVDate("01/" + this.txtNgayKetThuc.Value.Trim())) == 1)
            {
                this.getData();
            }
            else
            {
                this.lblMsg.Text = "Lỗi xảy ra khi lưu thông tin";
            }
        }
    }
    #endregion

    #region method btnAdd_Click
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("QuaTrinhCongTac.aspx?id=" + this.IDNguoiLaoDong.ToString() + "&idDT=0");
    }
    #endregion

    #region method btnDel_Click
    protected void btnDel_Click(object sender, EventArgs e)
    {
        this.objNguoiLaoDong.delDataNldQuaTrinhCongTac(this.IDNldQuaTrinhCongTac);
        this.getData();
    }
    #endregion
}