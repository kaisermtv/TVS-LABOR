using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Category_NhomNganhEdit : System.Web.UI.Page
{
    #region declare objects
    private int itemId = 0;
    private Account objAccount = new Account();
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
            this.objTable = this.objNhomNganh.getDataById(this.itemId);
            if (this.objTable.Rows.Count > 0)
            {
                this.txtCodeNgoaiNgu.Text = this.objTable.Rows[0]["CodeNhomNganh"].ToString();
                this.txtNameNgoaiNgu.Text = this.objTable.Rows[0]["nameNhomNganh"].ToString();
                this.ckbState.Checked = bool.Parse(this.objTable.Rows[0]["State"].ToString());
            }
        }
        this.txtCodeNgoaiNgu.Focus();
    }
    #endregion

    #region method btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        this.lblMsg.Text = "";

        //if (this.txtCodeNgoaiNgu.Text.Trim() == "")
        //{
        //    this.lblMsg.Text = "Bạn chưa nhập mã nhóm ngành";
        //    this.txtCodeNgoaiNgu.Focus();
        //    return;
        //}

        if (this.itemId == 0)
        {
            if (this.objNhomNganh.checkCode(this.txtCodeNgoaiNgu.Text.Trim()))
            {
                this.lblMsg.Text = "Mã \"" + this.txtCodeNgoaiNgu.Text + "\" đã được sử dụng, vui lòng chọn mã khác.";
                this.txtCodeNgoaiNgu.Focus();
                return;
            }
        }

        if (this.txtNameNgoaiNgu.Text.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập tên nhóm ngành";
            this.txtNameNgoaiNgu.Focus();
            return;
        }

        if (this.objNhomNganh.setData(this.itemId, this.txtCodeNgoaiNgu.Text, this.txtNameNgoaiNgu.Text, this.ckbState.Checked) == 1)
        {
            Response.Redirect("NhomNganh.aspx");
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
        Response.Redirect("NhomNganh.aspx");
    }
    #endregion
}