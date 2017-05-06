using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Ward : System.Web.UI.Page
{
    #region declare objects
    private DataTable objTable = new DataTable();
    private Account objAccount = new Account();
    private District objDistrict = new District();
    private Provincer objProvincer = new Provincer();
    private Ward objWard = new Ward();
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
        if (!Page.IsPostBack)
        {
            this.ddlProvincer.DataSource = this.objProvincer.getDataCategoryToCombobox();
            this.ddlProvincer.DataTextField = "Name";
            this.ddlProvincer.DataValueField = "Id";
            this.ddlProvincer.DataBind();

            if (Session["CURR_PROVINVER"] != null)
            {
                this.ddlProvincer.SelectedValue = Session["CURR_PROVINVER"].ToString();
            }
            else
            {
                Session["CURR_PROVINVER"] = this.ddlProvincer.SelectedValue;
            }

            if (this.ddlProvincer.Items.Count > 0)
            {
                this.ddlDistrict.DataSource = this.objDistrict.getDataCategoryToCombobox(this.ddlProvincer.SelectedValue.ToString());
                this.ddlDistrict.DataTextField = "Name";
                this.ddlDistrict.DataValueField = "Id";
                this.ddlDistrict.DataBind();

                if (Session["CURR_DISTRICT"] != null)
                {
                    this.ddlDistrict.SelectedValue = Session["CURR_DISTRICT"].ToString();
                }
                else
                {
                    Session["CURR_DISTRICT"] = this.ddlDistrict.SelectedValue;
                }
            }
        }
        this.txtSearch.Text = this.objSearchConfig.getData(Session["ACCOUNT"].ToString(), "tblWard", "Name");
        this.getData();
    }
    #endregion

    #region method btnSearch_Click
    protected void btnSearch_Click(object sender, ImageClickEventArgs e)
    {
        this.getData();

        #region Luu gia tri tim kiem vao bang cau hinh
        this.objSearchConfig.setData(Session["ACCOUNT"].ToString(), "tblWard", "Name", this.txtSearch.Text.Trim());
        #endregion
    }
    #endregion

    #region method ddlProvincer_SelectedIndexChanged
    protected void ddlProvincer_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.ddlDistrict.DataSource = this.objDistrict.getDataCategoryToCombobox(this.ddlProvincer.SelectedValue.ToString());
        this.ddlDistrict.DataTextField = "Name";
        this.ddlDistrict.DataValueField = "Id";
        this.ddlDistrict.DataBind();

        Session["CURR_PROVINVER"] = this.ddlProvincer.SelectedValue;

        this.getData();
    } 
    #endregion

    #region getData()
    private void getData()
    {
        this.objTable = this.objWard.getData(int.Parse(this.ddlProvincer.SelectedValue.ToString()), int.Parse(this.ddlDistrict.SelectedValue.ToString()), this.txtSearch.Text);
        cpWard.MaxPages = 1000;
        cpWard.PageSize = 12;
        cpWard.DataSource = this.objTable.DefaultView;
        cpWard.BindToControl = dtlWard;
        dtlWard.DataSource = cpWard.DataSourcePaged;
        dtlWard.DataBind();
        if (this.objTable.Rows.Count < 12)
        {
            this.tblABC.Visible = false;
        }
        else
        {
            this.tblABC.Visible = true;
        }
    }
    #endregion

    #region method ddlDistrict_SelectedIndexChanged
    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["CURR_DISTRICT"] = this.ddlDistrict.SelectedValue;

        this.getData();
    } 
    #endregion
}