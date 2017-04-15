using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_DoTuoiEdit : System.Web.UI.Page
{
    #region declare objects
    private int itemId = 0;
    private Account objAccount = new Account();
    private DoTuoi objDoTuoi = new DoTuoi();
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
            this.objTable = this.objDoTuoi.getDataById(this.itemId);
            if (this.objTable.Rows.Count > 0)
            {
                this.txtCodeDoTuoi.Text = this.objTable.Rows[0]["CodeDoTuoi"].ToString();
                this.txtNameDoTuoi.Text = this.objTable.Rows[0]["NameDoTuoi"].ToString();
                this.txtNote.Text = this.objTable.Rows[0]["Note"].ToString();
                this.ckbState.Checked = bool.Parse(this.objTable.Rows[0]["State"].ToString());
            }
        }
        this.txtCodeDoTuoi.Focus();
    }
    #endregion

    #region method btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        this.lblMsg.Text = "";

        if (this.txtCodeDoTuoi.Text.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập mã độ tuổi";
            this.txtCodeDoTuoi.Focus();
            return;
        }

        if (this.itemId == 0)
        {
            if (this.objDoTuoi.checkCode(this.txtCodeDoTuoi.Text.Trim()))
            {
                this.lblMsg.Text = "Mã \"" + this.txtCodeDoTuoi.Text + "\" đã được sử dụng, vui lòng chọn mã khác.";
                this.txtCodeDoTuoi.Focus();
                return;
            }
        }

        if (this.txtNameDoTuoi.Text.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập tên độ tuổi";
            this.txtNameDoTuoi.Focus();
            return;
        }

        if (this.objDoTuoi.setData(this.itemId, this.txtCodeDoTuoi.Text, this.txtNameDoTuoi.Text, this.txtNote.Text, this.ckbState.Checked) == 1)
        {
            Response.Redirect("DoTuoi.aspx");
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
        Response.Redirect("DoTuoi.aspx");
    }
    #endregion
}