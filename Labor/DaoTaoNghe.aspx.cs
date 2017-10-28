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


    public int index = 0;
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

            ddlMonHoc.DataSource = new DtKhoaHoc().getDataCategoryToCombobox();
            ddlMonHoc.DataValueField = "IdDtKhoaHoc";
            ddlMonHoc.DataTextField = "NameKhoaHoc";
            ddlMonHoc.DataBind();
            ddlMonHoc.SelectedValue = "0";

            this.getData();
        }
    } 
    #endregion

    #region getData()
    private void getData()
    {
        DateTime? formDate = null;
        DateTime? toDate = null;

        try
        {
            formDate = DateTime.Parse(txtFromDate.Value);
        }
        catch { }

        try
        {
            toDate = DateTime.Parse(txtToDate.Value);
        }
        catch { }



        this.objTable = this.objNguoiLaoDong.getDataNldDaoTao(this.txtSearch.Value, int.Parse(this.ddlState.SelectedValue),int.Parse(ddlMonHoc.SelectedValue), formDate,toDate);
        cpTuVanXuatKhau.MaxPages = 1000;
        cpTuVanXuatKhau.PageSize = 15;
        cpTuVanXuatKhau.DataSource = this.objTable.DefaultView;
        cpTuVanXuatKhau.BindToControl = dtlData;
        dtlData.DataSource = cpTuVanXuatKhau.DataSourcePaged;
        dtlData.DataBind();
     
    }
    #endregion

    #region method btnSearch_Click
    protected void btnSearch_Click(object sender, ImageClickEventArgs e)
    {
        this.getData();
    }
    #endregion
}