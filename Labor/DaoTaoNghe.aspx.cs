using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Labor_DaoTaoNghe : System.Web.UI.Page
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
        Session["TITLE"] = "HỌC NGOẠI NGỮ VÀ ĐÀO TẠO NGHỀ";
        if (!Page.IsPostBack)
        {
            this.getData();
        }
    } 
    #endregion

    #region getData()
    private void getData()
    {
        this.objTable = this.objNguoiLaoDong.getDataNldDaoTao(this.txtSearch.Value.ToString(), int.Parse(this.ddlState.SelectedValue.ToString()));
        cpTuVanXuatKhau.MaxPages = 1000;
        cpTuVanXuatKhau.PageSize = 15;
        cpTuVanXuatKhau.DataSource = this.objTable.DefaultView;
        cpTuVanXuatKhau.BindToControl = dtlTuVanXuatKhau;
        dtlTuVanXuatKhau.DataSource = cpTuVanXuatKhau.DataSourcePaged;
        dtlTuVanXuatKhau.DataBind();
     
    }
    #endregion

    #region method btnSearch_Click
    protected void btnSearch_Click(object sender, ImageClickEventArgs e)
    {
        this.getData();
    }
    #endregion
}