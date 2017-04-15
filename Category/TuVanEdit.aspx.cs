using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_TuVanEdit : System.Web.UI.Page
{
    #region declare objects
    private int itemId = 0;
    private Account objAccount = new Account();
    private TuVan objTuVan = new TuVan();
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
            this.objTable = this.objTuVan.getDataById(this.itemId);
            if (this.objTable.Rows.Count > 0)
            {
                this.txtCodeTuVan.Text = this.objTable.Rows[0]["CodeTuVan"].ToString();
                this.txtNameTuVan.Text = this.objTable.Rows[0]["NameTuVan"].ToString();
                this.txtNote.Text = this.objTable.Rows[0]["Note"].ToString();
                this.ckbState.Checked = bool.Parse(this.objTable.Rows[0]["State"].ToString());
            }
        }
        this.txtCodeTuVan.Focus();
    }
    #endregion

    #region method btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        this.lblMsg.Text = "";

        if (this.txtCodeTuVan.Text.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập mã hình thức tư vấn";
            this.txtCodeTuVan.Focus();
            return;
        }

        if (this.itemId == 0)
        {
            if (this.objTuVan.checkCode(this.txtCodeTuVan.Text.Trim()))
            {
                this.lblMsg.Text = "Mã \"" + this.txtCodeTuVan.Text + "\" đã được sử dụng, vui lòng chọn mã khác.";
                this.txtCodeTuVan.Focus();
                return;
            }
        }

        if (this.txtNameTuVan.Text.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập tên hình thức tư vấn";
            this.txtNameTuVan.Focus();
            return;
        }

        if (this.objTuVan.setData(this.itemId, this.txtCodeTuVan.Text, this.txtNameTuVan.Text, this.txtNote.Text, this.ckbState.Checked) == 1)
        {
            Response.Redirect("TuVan.aspx");
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
        Response.Redirect("TuVan.aspx");
    }
    #endregion
}