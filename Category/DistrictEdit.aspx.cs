using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_DistrictEdit : System.Web.UI.Page
{
    #region declare objects
    private int itemId = 0;
    private Account objAccount = new Account();
    private District objDistrict = new District();
    private Provincer objProvincer = new Provincer();
    private DataTable objTable = new DataTable();
    private bool View = false, Add = false, Edit = false, Del = false, Orther = false;

    private int tinhThanh = 0;
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
            this.itemId = int.Parse(Request["id"].ToString());
        }
        catch
        {
            this.itemId = 0;
        }

        try
        {
            this.tinhThanh = int.Parse(Request["tt"].ToString());
        }
        catch
        {
            this.tinhThanh = 0;
        }

        if(!Page.IsPostBack)
        {
            this.ddlProvincer.DataSource = this.objProvincer.getDataCategoryToCombobox();
            this.ddlProvincer.DataTextField = "Name";
            this.ddlProvincer.DataValueField = "Id";
            this.ddlProvincer.DataBind();

            ddlProvincer.SelectedValue = tinhThanh.ToString();
        }

        if (!Page.IsPostBack && this.itemId > 0)
        {
            

            this.objTable = this.objDistrict.getDataById(this.itemId);
            if (this.objTable.Rows.Count > 0)
            {
                this.txtCode.Text = this.objTable.Rows[0]["Code"].ToString();
                this.txtName.Text = this.objTable.Rows[0]["Name"].ToString();
                this.ddlProvincer.SelectedValue = this.objTable.Rows[0]["ProvincerId"].ToString();
                this.ckbState.Checked = bool.Parse(this.objTable.Rows[0]["State"].ToString());
            }
        }
    }
    #endregion

    #region method btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        this.lblMsg.Text = "";

        if (this.txtCode.Text.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập mã tỉnh, thành phố";
            this.txtCode.Focus();
            return;
        }

        if (this.itemId == 0)
        {
            if (this.objDistrict.checkCode(this.txtCode.Text.Trim()))
            {
                this.lblMsg.Text = "Mã \"" + this.txtCode.Text + "\" đã được sử dụng, vui lòng chọn mã khác.";
                this.txtCode.Focus();
                return;
            }
        }

        if (this.txtName.Text.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập họ tên tỉnh, thành";
            this.txtName.Focus();
            return;
        }

        if (this.objDistrict.setData(this.itemId,this.txtCode.Text, this.txtName.Text, int.Parse(this.ddlProvincer.SelectedValue.ToString()), this.ckbState.Checked) == 1)
        {
            Response.Redirect("District.aspx");
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
        Response.Redirect("District.aspx");
    }
    #endregion
}