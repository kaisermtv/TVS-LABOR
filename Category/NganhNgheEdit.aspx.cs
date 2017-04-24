using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_NganhNgheEdit : System.Web.UI.Page
{
    #region declare objects
    private int itemId = 0;
    private Account objAccount = new Account();
    private NganhNghe objNganhNghe = new NganhNghe();
    private NhomNganh objNhomNganh = new NhomNganh();
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
        if (!Page.IsPostBack && this.itemId > 0)
        {
            this.ddlNhomNganh.DataSource = this.objNhomNganh.getDataCategoryToCombobox();
            this.ddlNhomNganh.DataTextField = "NameNhomNganh";
            this.ddlNhomNganh.DataValueField = "IDNhomNganh";
            this.ddlNhomNganh.DataBind();

            this.objTable = this.objNganhNghe.getDataById(this.itemId);
            if (this.objTable.Rows.Count > 0)
            {
                this.ddlNhomNganh.SelectedValue = this.objTable.Rows[0]["IdNhomNganh"].ToString();
                this.txtCodeDTNganhNghe.Text = this.objTable.Rows[0]["CodeDTNganhNghe"].ToString();
                this.txtNameDTNganhNghe.Text = this.objTable.Rows[0]["NameDTNganhNghe"].ToString();
                this.txtNote.Text = this.objTable.Rows[0]["Note"].ToString();
                this.ckbState.Checked = bool.Parse(this.objTable.Rows[0]["State"].ToString());
            }
        }

        Session["TITLE"] = "THÔNG TIN NGÀNH NGHỀ";

        this.txtCodeDTNganhNghe.Focus();
    }
    #endregion

    #region method btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        this.lblMsg.Text = "";

        if (this.itemId == 0)
        {
            if (this.objNganhNghe.checkCode(this.txtCodeDTNganhNghe.Text.Trim()))
            {
                this.lblMsg.Text = "Mã \"" + this.txtCodeDTNganhNghe.Text + "\" đã được sử dụng, vui lòng chọn mã khác.";
                this.txtCodeDTNganhNghe.Focus();
                return;
            }
        }

        if (this.txtNameDTNganhNghe.Text.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập tên ngàng nghề";
            this.txtNameDTNganhNghe.Focus();
            return;
        }

        if (this.objNganhNghe.setData(this.itemId, int.Parse(this.ddlNhomNganh.SelectedValue.ToString()), this.txtCodeDTNganhNghe.Text, this.txtNameDTNganhNghe.Text, this.txtNote.Text, this.ckbState.Checked) == 1)
        {
            Response.Redirect("NganhNghe.aspx");
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
        Response.Redirect("NganhNghe.aspx");
    }
    #endregion
}