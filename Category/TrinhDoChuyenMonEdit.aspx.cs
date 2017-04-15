using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_TrinhDoChuyenMonEdit : System.Web.UI.Page
{
    #region declare objects
    private int itemId = 0;
    private Account objAccount = new Account();
    private TrinhDoChuyenMon objTrinhDoChuyenMon = new TrinhDoChuyenMon();
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
            this.objTable = this.objTrinhDoChuyenMon.getDataById(this.itemId);
            if (this.objTable.Rows.Count > 0)
            {
                this.txtCodeTrinhDoChuyenMon.Text = this.objTable.Rows[0]["CodeTrinhDoChuyenMon"].ToString();
                this.txtNameTrinhdoChuyenMon.Text = this.objTable.Rows[0]["NameTrinhdoChuyenMon"].ToString();
                this.txtNote.Text = this.objTable.Rows[0]["Note"].ToString();
                this.ckbState.Checked = bool.Parse(this.objTable.Rows[0]["State"].ToString());
            }
        }
        this.txtCodeTrinhDoChuyenMon.Focus();
    }
    #endregion

    #region method btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        this.lblMsg.Text = "";

        if (this.txtCodeTrinhDoChuyenMon.Text.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập mã trình độ chuyên môn";
            this.txtCodeTrinhDoChuyenMon.Focus();
            return;
        }

        if (this.itemId == 0)
        {
            if (this.objTrinhDoChuyenMon.checkCode(this.txtCodeTrinhDoChuyenMon.Text.Trim()))
            {
                this.lblMsg.Text = "Mã \"" + this.txtCodeTrinhDoChuyenMon.Text + "\" đã được sử dụng, vui lòng chọn mã khác.";
                this.txtCodeTrinhDoChuyenMon.Focus();
                return;
            }
        }

        if (this.txtNameTrinhdoChuyenMon.Text.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập tên trình độ chuyên môn";
            this.txtNameTrinhdoChuyenMon.Focus();
            return;
        }

        if (this.objTrinhDoChuyenMon.setData(this.itemId, this.txtCodeTrinhDoChuyenMon.Text, this.txtNameTrinhdoChuyenMon.Text, this.txtNote.Text, this.ckbState.Checked) == 1)
        {
            Response.Redirect("TrinhDoChuyenMon.aspx");
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
        Response.Redirect("TrinhDoChuyenMon.aspx");
    }
    #endregion
}