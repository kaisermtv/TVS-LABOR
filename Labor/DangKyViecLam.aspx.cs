using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_DangKyViecLam : System.Web.UI.Page
{
    #region declare objects
    private DataTable objTable = new DataTable();
    private Account objAccount = new Account();
    private NguoiLaoDong objNguoiLaoDong = new NguoiLaoDong();
    private SearchConfig objSearchConfig = new SearchConfig();
    private int currPage = 0;
    private bool View = false, Add = false, Edit = false, Del = false, Orther = false;
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ACCOUNT"] == null)
        {
            Response.Redirect("../Login.aspx");
        }

        Session["TITLE"] = "HỒ SƠ ĐĂNG KÝ VIỆC LÀM";
       
        if (!Page.IsPostBack)
        {
            this.txtNgayBatDau.Value = DateTime.Now.AddMonths(-1).ToString("dd/MM/yyyy");
            this.txtNgayKetThuc.Value = DateTime.Now.ToString("dd/MM/yyyy");
            this.txtSearch.Value = this.objSearchConfig.getData(Session["ACCOUNT"].ToString(), "TblNguoiLaoDong", "HoVaTen");
            this.getData();
        }
        this.txtSearch.Focus();
    }
    #endregion

    #region getData()
    private void getData()
    {
        if (this.txtNgayBatDau.Value.Trim() == "")
        {
            this.txtNgayBatDau.Value = DateTime.Now.AddMonths(-1).ToString("dd/MM/yyyy");
        }

        if (this.txtNgayKetThuc.Value.Trim() == "")
        {
            this.txtNgayKetThuc.Value = DateTime.Now.ToString("dd/MM/yyyy");
        }

        this.objTable = this.objNguoiLaoDong.getDataNldDangKyByState(int.Parse(this.ddlState.SelectedValue.ToString()), this.txtNgayBatDau.Value, this.txtNgayKetThuc.Value);
        cpDangKyViecLam.MaxPages = 1000;
        cpDangKyViecLam.PageSize = 15;
        cpDangKyViecLam.DataSource = this.objTable.DefaultView;
        cpDangKyViecLam.BindToControl = dtlDangKyViecLam;
        dtlDangKyViecLam.DataSource = cpDangKyViecLam.DataSourcePaged;
        dtlDangKyViecLam.DataBind();
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

    #region method btnSearch_Click
    protected void btnSearch_Click(object sender, ImageClickEventArgs e)
    {
        this.getData();

        #region Luu gia tri tim kiem vao bang cau hinh
        this.objSearchConfig.setData(Session["ACCOUNT"].ToString(), "TblNguoiLaoDong", "HoVaTen", this.txtSearch.Value.Trim());
        #endregion
    }
    #endregion
}