using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_HinhThucDangKyEdit : System.Web.UI.Page
{
    #region declare objects
    private int itemId = 0;
    private Account objAccount = new Account();
    private HinhThucDangKy objHinhThucDangKy = new HinhThucDangKy();
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
            this.objTable = this.objHinhThucDangKy.getDataById(this.itemId);
            if (this.objTable.Rows.Count > 0)
            {
                this.txtCodeHinhThucDangKy.Text = this.objTable.Rows[0]["CodeHinhThucDangKy"].ToString();
                this.txtNameHinhThucDangKy.Text = this.objTable.Rows[0]["NameHinhThucDangKy"].ToString();
                this.txtNote.Text = this.objTable.Rows[0]["Note"].ToString();
                this.ckbState.Checked = bool.Parse(this.objTable.Rows[0]["State"].ToString());
            }
        }
        this.txtCodeHinhThucDangKy.Focus();
    }
    #endregion

    #region method btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        this.lblMsg.Text = "";

        if (this.txtCodeHinhThucDangKy.Text.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập mã trình độ tin học";
            this.txtCodeHinhThucDangKy.Focus();
            return;
        }

        if (this.itemId == 0)
        {
            if (this.objHinhThucDangKy.checkCode(this.txtCodeHinhThucDangKy.Text.Trim()))
            {
                this.lblMsg.Text = "Mã \"" + this.txtCodeHinhThucDangKy.Text + "\" đã được sử dụng, vui lòng chọn mã khác.";
                this.txtCodeHinhThucDangKy.Focus();
                return;
            }
        }

        if (this.txtNameHinhThucDangKy.Text.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập tên trình độ tin học";
            this.txtNameHinhThucDangKy.Focus();
            return;
        }

        if (this.objHinhThucDangKy.setData(this.itemId, this.txtCodeHinhThucDangKy.Text, this.txtNameHinhThucDangKy.Text, this.txtNote.Text, this.ckbState.Checked) == 1)
        {
            Response.Redirect("HinhThucDangKy.aspx");
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
        Response.Redirect("HinhThucDangKy.aspx");
    }
    #endregion
}