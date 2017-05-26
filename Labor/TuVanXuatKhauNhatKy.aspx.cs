using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Labor_TuVanXuatKhauNhatKy : System.Web.UI.Page
{
    #region declare objects
    private DataTable objTable = new DataTable();
    private Account objAccount = new Account();
    private XuatKhauLaoDong objXuatKhauLaoDong = new XuatKhauLaoDong();
    private ChucVu objChucVu = new ChucVu();
    private LinhVuc objLinhVuc = new LinhVuc();
    private SearchConfig objSearchConfig = new SearchConfig();
    private int IDNldXuatKhau = 0, IDNldXuatKhauNhatKy = 0;
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
            this.IDNldXuatKhau = int.Parse(Request.QueryString["idXK"].ToString());
        }
        catch
        {
            this.IDNldXuatKhau = 0;
        }
        try
        {
            this.IDNldXuatKhauNhatKy = int.Parse(Request.QueryString["id"].ToString());
        }
        catch
        {
            this.IDNldXuatKhauNhatKy = 0;
        }
        if (!Page.IsPostBack)
        {

            this.objTable = this.objXuatKhauLaoDong.getDataNldXuatKhauNhatKyById(this.IDNldXuatKhauNhatKy);
            if (this.objTable.Rows.Count > 0)
            {
                this.txtNote.Text = this.objTable.Rows[0]["Note"].ToString();
                this.txtNgayNhatKy.Value = DateTime.Parse(this.objTable.Rows[0]["NgayNhatKy"].ToString()).ToString("dd/MM/yyyy");
            }

            this.getData();

            this.txtNote.Focus();
        }
    }
    #endregion

    #region getData()
    private void getData()
    {
        this.objTable = this.objXuatKhauLaoDong.getDataNldXuatKhauNhatKy(this.IDNldXuatKhau);
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
        if (this.IDNldXuatKhau > 0)
        {
            this.lblMsg.Text = "";

            if (this.txtNote.Text == "")
            {
                this.lblMsg.Text = "Bạn chưa nhập nội dung công việc";
                this.txtNote.Focus();
                return;
            }

            if (this.txtNgayNhatKy.Value.Trim() == "")
            {
                this.lblMsg.Text = "Bạn chưa nhập ngày công việc";
                this.txtNgayNhatKy.Value = DateTime.Now.ToString();
                this.txtNgayNhatKy.Focus();
                return;
            }

            DateTime objNgayNhatKy = TVSSystem.CVDate(this.txtNgayNhatKy.Value);

            if (this.objXuatKhauLaoDong.setDataNldXuatKhauNhatKy(this.IDNldXuatKhauNhatKy, this.IDNldXuatKhau, objNgayNhatKy, this.txtNote.Text) == 1)
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
        Response.Redirect("TuVanXuatKhauNhatKy.aspx?id=" + this.IDNldXuatKhau.ToString() + "&idDT=0");
    }
    #endregion

    #region method btnDel_Click
    protected void btnDel_Click(object sender, EventArgs e)
    {
        this.objXuatKhauLaoDong.delDataNldXuatKhauNhatKy(this.IDNldXuatKhauNhatKy);
        this.txtNgayNhatKy.Value = "";
        this.txtNote.Text = "";
        this.getData();
    }
    #endregion
}