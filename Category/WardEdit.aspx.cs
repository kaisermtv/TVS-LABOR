using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_WardEdit : System.Web.UI.Page
{
    #region declare objects
    private int itemId = 0;
    private Account objAccount = new Account();
    private District objDistrict = new District();
    private Provincer objProvincer = new Provincer();
    private Ward objWard = new Ward();
    private DataTable objTable = new DataTable();
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
            this.itemId = int.Parse(Request["id"].ToString());
        }
        catch
        {
            this.itemId = 0;
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

            this.objTable = this.objWard.getDataById(this.itemId);
            if (this.objTable.Rows.Count > 0)
            {
                this.txtCode.Text = this.objTable.Rows[0]["Code"].ToString();
                this.txtName.Text = this.objTable.Rows[0]["Name"].ToString();
                this.ddlProvincer.SelectedValue = this.objTable.Rows[0]["ProvincerId"].ToString();

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

                this.ddlDistrict.SelectedValue = this.objTable.Rows[0]["DistrictId"].ToString();
                this.ckbState.Checked = bool.Parse(this.objTable.Rows[0]["State"].ToString());
            }
            else
            {
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
        }
        this.txtCode.Focus();
    }
    #endregion

    #region method btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        this.lblMsg.Text = "";

        if (this.txtCode.Text.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập mã phưỡng, xã";
            this.txtCode.Focus();
            return;
        }

        if (this.itemId == 0)
        {
            if (this.objWard.checkCode(this.txtCode.Text.Trim()))
            {
                this.lblMsg.Text = "Mã \"" + this.txtCode.Text + "\" đã được sử dụng, vui lòng chọn mã khác.";
                this.txtCode.Focus();
                return;
            }
        }

        if (this.txtName.Text.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập họ tên phưỡng, xã";
            this.txtName.Focus();
            return;
        }

        if (this.objWard.setData(this.itemId, this.txtCode.Text, this.txtName.Text, int.Parse(this.ddlProvincer.SelectedValue.ToString()), int.Parse(this.ddlDistrict.SelectedValue.ToString()), this.ckbState.Checked) == 1)
        {
            Response.Redirect("Ward.aspx");
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
        Response.Redirect("Ward.aspx");
    }
    #endregion

    #region method ddlProvincer_SelectedIndexChanged
    protected void ddlProvincer_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.ddlDistrict.DataSource = this.objDistrict.getDataCategoryToCombobox(this.ddlProvincer.SelectedValue.ToString());
        this.ddlDistrict.DataTextField = "Name";
        this.ddlDistrict.DataValueField = "Id";
        this.ddlDistrict.DataBind();
    }
    #endregion
}