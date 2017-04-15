using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_TinHocEdit : System.Web.UI.Page
{
    #region declare objects
    private int itemId = 0;
    private Account objAccount = new Account();
    private TinHoc objTinHoc = new TinHoc();
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
            this.objTable = this.objTinHoc.getDataById(this.itemId);
            if (this.objTable.Rows.Count > 0)
            {
                this.txtCodeTinHoc.Text = this.objTable.Rows[0]["CodeTinHoc"].ToString();
                this.txtNameTinHoc.Text = this.objTable.Rows[0]["NameTinHoc"].ToString();
                this.txtNote.Text = this.objTable.Rows[0]["Note"].ToString();
                this.ckbState.Checked = bool.Parse(this.objTable.Rows[0]["State"].ToString());
            }
        }
        this.txtCodeTinHoc.Focus();
    }
    #endregion

    #region method btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        this.lblMsg.Text = "";

        if (this.txtCodeTinHoc.Text.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập mã trình độ tin học";
            this.txtCodeTinHoc.Focus();
            return;
        }

        if (this.itemId == 0)
        {
            if (this.objTinHoc.checkCode(this.txtCodeTinHoc.Text.Trim()))
            {
                this.lblMsg.Text = "Mã \"" + this.txtCodeTinHoc.Text + "\" đã được sử dụng, vui lòng chọn mã khác.";
                this.txtCodeTinHoc.Focus();
                return;
            }
        }

        if (this.txtNameTinHoc.Text.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập tên trình độ tin học";
            this.txtNameTinHoc.Focus();
            return;
        }

        if (this.objTinHoc.setData(this.itemId, this.txtCodeTinHoc.Text, this.txtNameTinHoc.Text, this.txtNote.Text, this.ckbState.Checked) == 1)
        {
            Response.Redirect("TinHoc.aspx");
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
        Response.Redirect("TinHoc.aspx");
    }
    #endregion
}