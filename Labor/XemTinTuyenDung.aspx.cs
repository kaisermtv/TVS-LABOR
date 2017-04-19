using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Labor_XemTinTuyenDung : System.Web.UI.Page
{
    #region declare objects
    private DataTable objTable = new DataTable();
    private Account objAccount = new Account();
    private ChucVu objChucVu = new ChucVu();
    private NguoiLaoDong objNguoiLaoDong = new NguoiLaoDong();
    private Mucluong objMucluong = new Mucluong();
    private TuyenDung objTuyenDung = new TuyenDung();
    private SearchConfig objSearchConfig = new SearchConfig();
    private int IDNldTuVan = 0;
    private bool View = false, Add = false, Edit = false, Del = false, Orther = false;

    public int index = 1;
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
            this.IDNldTuVan = int.Parse(Request.QueryString["IDNldTuVan"].ToString());
        }
        catch
        {
            this.IDNldTuVan = 0;
        }
        if (!Page.IsPostBack)
        {
            this.ddlIDChucVu.DataSource = this.objChucVu.getDataCategoryToCombobox();
            this.ddlIDChucVu.DataTextField = "NameChucVu";
            this.ddlIDChucVu.DataValueField = "IDChucVu";
            this.ddlIDChucVu.DataBind();

            this.ddlIDChucVu.SelectedValue = "0";

            this.ddlMucLuong.DataSource = this.objMucluong.getDataCategoryToCombobox();
            this.ddlMucLuong.DataTextField = "NameMucLuong";
            this.ddlMucLuong.DataValueField = "IdMucLuong";
            this.ddlMucLuong.DataBind();

            this.ddlMucLuong.SelectedValue = "0";

            this.txtSearch.Value = this.objSearchConfig.getData(Session["ACCOUNT"].ToString(), "TblDoanhNghiep", "TenDonVi");
            this.getData();
        }
    }
    #endregion

    #region getData()
    private void getData()
    {
        this.objTable = this.objTuyenDung.getList(this.txtSearch.Value, int.Parse(this.ddlIDChucVu.SelectedValue.ToString()), int.Parse(this.ddlMucLuong.SelectedValue.ToString()),"");
        cpTuyenDung.MaxPages = 1000;
        cpTuyenDung.PageSize = 10;
        cpTuyenDung.DataSource = this.objTable.DefaultView;
        cpTuyenDung.BindToControl = dtlTuyenDung;
        dtlTuyenDung.DataSource = cpTuyenDung.DataSourcePaged;
        dtlTuyenDung.DataBind();
        if (this.objTable.Rows.Count < 10)
        {
            this.tblABC.Visible = false;
        }
        else
        {
            this.tblABC.Visible = true;
        }

        index = 1;
    }
    #endregion

    #region method btnSearch_Click
    protected void btnSearch_Click(object sender, ImageClickEventArgs e)
    {
        this.getData();

        #region Luu gia tri tim kiem vao bang cau hinh
        this.objSearchConfig.setData(Session["ACCOUNT"].ToString(), "TblDoanhNghiep", "TenDonVi", this.txtSearch.Value.Trim());
        #endregion
    }
    #endregion

    #region method btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        this.lblMsg.Text = "";
        if (this.txtIDChucVu.Value.Trim() == "" || this.txtIDDonVi.Value.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa chọn thông tin đầy đủ khi ghi nhận";
            return;
        }
        int IDTuyenDung = 0;
        if (this.txtIDTuyenDung.Value.Trim() != "")
        {
            try
            {
                IDTuyenDung = int.Parse(this.txtIDTuyenDung.Value.Trim());
            }
            catch
            {
                IDTuyenDung = 0;
            }
        }
        int IDNldDangKy = this.objNguoiLaoDong.getDataNldDangKyByIDNldTuVan(this.IDNldTuVan);
        DataTable objTmpNguoiLaoDong = this.objNguoiLaoDong.getDataNldDangKyById(IDNldDangKy);
        int IDNguoiLaoDong = 0;
        if (objTmpNguoiLaoDong.Rows.Count > 0)
        {
            IDNguoiLaoDong = int.Parse(objTmpNguoiLaoDong.Rows[0]["IDNguoiLaoDong"].ToString());
        }
        this.objNguoiLaoDong.setDataNldGioiThieu(IDTuyenDung, IDNldDangKy, IDNguoiLaoDong, int.Parse(this.txtIDDonVi.Value), int.Parse(this.txtIDChucVu.Value), DateTime.Now, Session["ACCOUNT"].ToString());
        this.lblMsg.Text = "<span style = \"color:blue;\">Lưu dữ liệu thành công !</span>";
    } 
    #endregion
}