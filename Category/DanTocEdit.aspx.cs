using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_DanTocEdit : System.Web.UI.Page
{
    #region declare objects
    private int itemId = 0;
    private Account objAccount = new Account();
    private DanToc objDanToc = new DanToc();
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
            this.objTable = this.objDanToc.getDataById(this.itemId);
            if (this.objTable.Rows.Count > 0)
            {
                this.txtCodeDanToc.Text = this.objTable.Rows[0]["CodeDanToc"].ToString();
                this.txtNameDanToc.Text = this.objTable.Rows[0]["NameDanToc"].ToString();
                this.txtNote.Text = this.objTable.Rows[0]["Note"].ToString();
                this.ckbState.Checked = bool.Parse(this.objTable.Rows[0]["State"].ToString());
            }
        }
        this.txtCodeDanToc.Focus();
    }
    #endregion

    #region method btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        this.lblMsg.Text = "";

        if (this.txtCodeDanToc.Text.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập mã trình độ tin học";
            this.txtCodeDanToc.Focus();
            return;
        }

        if (this.itemId == 0)
        {
            if (this.objDanToc.checkCode(this.txtCodeDanToc.Text.Trim()))
            {
                this.lblMsg.Text = "Mã \"" + this.txtCodeDanToc.Text + "\" đã được sử dụng, vui lòng chọn mã khác.";
                this.txtCodeDanToc.Focus();
                return;
            }
        }

        if (this.txtNameDanToc.Text.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập tên trình độ tin học";
            this.txtNameDanToc.Focus();
            return;
        }

        if (this.objDanToc.setData(this.itemId, this.txtCodeDanToc.Text, this.txtNameDanToc.Text, this.txtNote.Text, this.ckbState.Checked) == 1)
        {
            Response.Redirect("DanToc.aspx");
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
        Response.Redirect("DanToc.aspx");
    }
    #endregion
}