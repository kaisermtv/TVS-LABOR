using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Category_LoaiHinhDoanhNghiepEdit : System.Web.UI.Page
{
    #region declare objects
    private int itemId = 0;
    private Account objAccount = new Account();
    private LoaiHinh objLoaiHinh = new LoaiHinh();
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
            this.objTable = this.objLoaiHinh.getDataById(this.itemId);
            if (this.objTable.Rows.Count > 0)
            {
                this.txtCodeLoaiHinh.Text = this.objTable.Rows[0]["CodeLoaiHinh"].ToString();
                this.txtNameLoaiHinh.Text = this.objTable.Rows[0]["NameLoaiHinh"].ToString();
                this.txtNote.Text = this.objTable.Rows[0]["Note"].ToString();
                this.ckbState.Checked = bool.Parse(this.objTable.Rows[0]["State"].ToString());
            }
        }
        this.txtCodeLoaiHinh.Focus();
    }
    #endregion

    #region method btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        this.lblMsg.Text = "";

        if (this.txtCodeLoaiHinh.Text.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập mã loại hình";
            this.txtCodeLoaiHinh.Focus();
            return;
        }

        if (this.itemId == 0)
        {
            if (this.objLoaiHinh.checkCode(this.txtCodeLoaiHinh.Text.Trim()))
            {
                this.lblMsg.Text = "Mã \"" + this.txtCodeLoaiHinh.Text + "\" đã được sử dụng, vui lòng chọn mã khác.";
                this.txtCodeLoaiHinh.Focus();
                return;
            }
        }

        if (this.txtNameLoaiHinh.Text.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập tên loại hình";
            this.txtNameLoaiHinh.Focus();
            return;
        }

        if (this.objLoaiHinh.setData(this.itemId, this.txtCodeLoaiHinh.Text, this.txtNameLoaiHinh.Text, this.txtNote.Text, this.ckbState.Checked) == 1)
        {
            Response.Redirect("LoaiHinhDoanhNghiep.aspx");
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
        Response.Redirect("LoaiHinhDoanhNghiep.aspx");
    }
    #endregion
}