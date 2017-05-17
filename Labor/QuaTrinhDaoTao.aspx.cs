using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_QuaTrinhDaoTao : System.Web.UI.Page
{
    #region declare objects
    private DataTable objTable = new DataTable();
    private Account objAccount = new Account();
    private NguoiLaoDong objNguoiLaoDong = new NguoiLaoDong();
    private TrinhDoChuyenMon objTrinhDoChuyenMon = new TrinhDoChuyenMon();
    private NhomNganh objNhomNganh = new NhomNganh();
    private NganhNghe objNganhNghe = new NganhNghe();
    private SearchConfig objSearchConfig = new SearchConfig();
    private int IDNldQuaTrinhDaoTao = 0, IDNguoiLaoDong = 0;
    private bool View = false, Add = false, Edit = false, Del = false, Orther = false;
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ACCOUNT"] == null)
        {
            Response.Redirect("../Login.aspx");
        }
        
        try
        {
            this.IDNldQuaTrinhDaoTao = int.Parse(Request.QueryString["idDT"].ToString());
        }
        catch
        {
            this.IDNldQuaTrinhDaoTao = 0;
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
            this.ddlNhomNganh.DataSource = this.objNhomNganh.getDataCategoryToCombobox();
            this.ddlNhomNganh.DataTextField = "NameNhomNganh";
            this.ddlNhomNganh.DataValueField = "IdNhomNganh";
            this.ddlNhomNganh.DataBind();
            this.ddlNhomNganh.SelectedValue = "0";

            ddlNhomNganh_SelectedIndexChanged(null,null);
            //this.ddlNganhNghe.SelectedValue = "0";

            this.ddlTrinhDoChuyenMon.DataSource = this.objTrinhDoChuyenMon.getDataCategoryToCombobox();
            this.ddlTrinhDoChuyenMon.DataTextField = "NameTrinhDoChuyenMon";
            this.ddlTrinhDoChuyenMon.DataValueField = "IDTrinhDoChuyenMon";
            this.ddlTrinhDoChuyenMon.DataBind();

            this.objTable = this.objNguoiLaoDong.getDataNldQuaTrinhDaoTaoById(this.IDNldQuaTrinhDaoTao);
            if (this.objTable.Rows.Count > 0)
            {
                this.ddlNhomNganh.SelectedValue = this.objTable.Rows[0]["IdNhomNganh"].ToString();
                
                this.ddlNganhNghe.DataSource = this.objNganhNghe.getDataCategoryToCombobox(this.ddlNhomNganh.SelectedValue.ToString());
                this.ddlNganhNghe.DataTextField = "NameDTNganhNghe";
                this.ddlNganhNghe.DataValueField = "IDDTNganhNghe";
                this.ddlNganhNghe.DataBind();

                this.ddlNganhNghe.SelectedValue = this.objTable.Rows[0]["IDDTNganhNghe"].ToString();

                this.ddlTrinhDoChuyenMon.SelectedValue = this.objTable.Rows[0]["IDTrinhdochuyenmon"].ToString();
            }
            
            this.getData();
        }
    }
    #endregion

    #region getData()
    private void getData()
    {
        this.objTable = this.objNguoiLaoDong.getDataNldQuaTrinhDaoTao(this.IDNguoiLaoDong);
        cpNldQuaTrinhDaoTao.MaxPages = 1000;
        cpNldQuaTrinhDaoTao.PageSize = 15;
        cpNldQuaTrinhDaoTao.DataSource = this.objTable.DefaultView;
        cpNldQuaTrinhDaoTao.BindToControl = dtlNldQuaTrinhDaoTao;
        dtlNldQuaTrinhDaoTao.DataSource = cpNldQuaTrinhDaoTao.DataSourcePaged;
        dtlNldQuaTrinhDaoTao.DataBind();
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

            if (this.ddlNganhNghe.SelectedValue == "0")
            {
                this.lblMsg.Text = "Bạn chưa chọn ngành nghề cho người lao động!";
                return;
            }

            if (this.ddlNhomNganh.SelectedValue == "0" && this.ddlNganhNghe.SelectedValue != "0")
            {
                DataTable objData = objNganhNghe.getDataById(int.Parse(this.ddlNganhNghe.SelectedValue));
                if(objData.Rows.Count > 0)
                {
                    this.ddlNhomNganh.SelectedValue = objData.Rows[0]["IdNhomNganh"].ToString();
                }

            }

            if (this.objNguoiLaoDong.setDataNldQuaTrinhDaoTao(this.IDNldQuaTrinhDaoTao, this.IDNguoiLaoDong, "", int.Parse(this.ddlTrinhDoChuyenMon.SelectedValue.ToString()), int.Parse(this.ddlNhomNganh.SelectedValue.ToString()), int.Parse(this.ddlNganhNghe.SelectedValue.ToString())) == 1)
            {
                this.getData();
            }
            else{
                this.lblMsg.Text = "Lỗi xảy ra khi lưu thông tin";
            }
        }
    } 
    #endregion

    #region method btnAdd_Click
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("QuaTrinhDaoTao.aspx?id="+this.IDNguoiLaoDong.ToString()+"&idDT=0");
    } 
    #endregion

    #region method btnDel_Click
    protected void btnDel_Click(object sender, EventArgs e)
    {
        this.objNguoiLaoDong.delDataNldQuaTrinhDaoTao(this.IDNldQuaTrinhDaoTao);
        this.getData();
    } 
    #endregion

    #region method ddlNhomNganh_SelectedIndexChanged
    protected void ddlNhomNganh_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.ddlNganhNghe.DataSource = this.objNganhNghe.getDataCategoryToCombobox(this.ddlNhomNganh.SelectedValue.ToString());
        this.ddlNganhNghe.DataTextField = "NameDTNganhNghe";
        this.ddlNganhNghe.DataValueField = "IDDTNganhNghe";
        this.ddlNganhNghe.DataBind();

        //if (this.ddlNhomNganh.SelectedValue != "0")
        //{
            this.ddlNganhNghe.SelectedValue = "0";
        //}
        
    }
    #endregion
}