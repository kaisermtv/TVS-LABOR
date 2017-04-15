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
        //if (!this.objAccount.checkForFunction(Session["ACCOUNT"].ToString(), 3, ref View, ref Add, ref Edit, ref Del, ref Orther))
        //{
        //    Response.Redirect("NoPermission.aspx");
        //}
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
            this.ddlTrinhDoChuyenMon.DataSource = this.objTrinhDoChuyenMon.getDataCategoryToCombobox();
            this.ddlTrinhDoChuyenMon.DataTextField = "NameTrinhDoChuyenMon";
            this.ddlTrinhDoChuyenMon.DataValueField = "IDTrinhDoChuyenMon";
            this.ddlTrinhDoChuyenMon.DataBind();

            this.objTable = this.objNguoiLaoDong.getDataNldQuaTrinhDaoTaoById(this.IDNldQuaTrinhDaoTao);
            if (this.objTable.Rows.Count > 0)
            {
                this.txtDonVi.Text = this.objTable.Rows[0]["DonVi"].ToString();
                this.ddlTrinhDoChuyenMon.SelectedValue = this.objTable.Rows[0]["IDTrinhdochuyenmon"].ToString();
                this.txtNgayBatDau.Value = DateTime.Parse(this.objTable.Rows[0]["NgayBatDau"].ToString()).ToString("dd/MM/yyyy");
                this.txtNgayKetThuc.Value = DateTime.Parse(this.objTable.Rows[0]["NgayKetThuc"].ToString()).ToString("dd/MM/yyyy");
            }
            
            this.getData();

            this.txtDonVi.Focus();
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

            if (this.txtDonVi.Text == "")
            {
                this.lblMsg.Text = "Bạn chưa nhập tên đơn vị";
                this.txtDonVi.Focus();
                return;
            }

            if (this.txtNgayBatDau.Value.Trim() == "")
            {
                this.lblMsg.Text = "Bạn chưa nhập ngày bắt đầu đào tạo";
                this.txtNgayBatDau.Value = DateTime.Now.ToString();
                this.txtNgayBatDau.Focus();
                return;
            }

            if (this.txtNgayKetThuc.Value.Trim() == "")
            {
                this.lblMsg.Text = "Bạn chưa nhập ngày kết thúc đào tạo";
                this.txtNgayKetThuc.Value = DateTime.Now.ToString();
                this.txtNgayKetThuc.Focus();
                return;
            }

            if (this.objNguoiLaoDong.setDataNldQuaTrinhDaoTao(this.IDNldQuaTrinhDaoTao, this.IDNguoiLaoDong, this.txtDonVi.Text, int.Parse(this.ddlTrinhDoChuyenMon.SelectedValue.ToString()), TVSSystem.CVDate(this.txtNgayBatDau.Value.Trim()), TVSSystem.CVDate(this.txtNgayKetThuc.Value.Trim())) == 1)
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
}