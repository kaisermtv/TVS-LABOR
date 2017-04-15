using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_EditGroupAccount : System.Web.UI.Page
{
    #region declare objects
    public int itemId = 0;
    private Account objAccount = new Account();
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
        if (!this.objAccount.checkForFunction(Session["ACCOUNT"].ToString(), 2, ref View, ref Add, ref Edit, ref Del, ref Orther))
        {
            Response.Redirect("NoPermission.aspx");
        }
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
            this.objTable = this.objAccount.getDataGroupAccountById(this.itemId);


            if (this.objTable.Rows.Count > 0)
            {
                this.txtName.Text = this.objTable.Rows[0]["Name"].ToString();
                this.ckbState.Checked = bool.Parse(this.objTable.Rows[0]["State"].ToString());
            }

            this.objTable = this.objAccount.getDataPermission(this.itemId);
            cpGroupPermission.MaxPages = 1000;
            cpGroupPermission.PageSize = 15;
            cpGroupPermission.DataSource = this.objTable.DefaultView;
            cpGroupPermission.BindToControl = dtlGroupPermission;
            dtlGroupPermission.DataSource = cpGroupPermission.DataSourcePaged;
            dtlGroupPermission.DataBind();
            if (this.objTable.Rows.Count < 15)
            {
                this.tblABC.Visible = false;
            }
            else
            {
                this.tblABC.Visible = true;
            }
        }
    }
    #endregion

    #region method btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        this.lblMsg.Text = "";

        if (this.txtName.Text.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập tên nhóm tài khoản.";
            this.txtName.Focus();
            return;
        }

        if (this.objAccount.setDataGroupAccount(this.itemId, this.txtName.Text, this.ckbState.Checked) == 1)
        {
            Response.Redirect("GroupAccount.aspx");
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
        Response.Redirect("GroupAccount.aspx");
    }
    #endregion
}