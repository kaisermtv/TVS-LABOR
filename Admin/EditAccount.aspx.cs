using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_EditAccount : System.Web.UI.Page
{
    #region declare objects
    private int itemId = 0, cid = 0;
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
        if (!this.objAccount.checkForFunction(Session["ACCOUNT"].ToString(), 3, ref View, ref Add, ref Edit, ref Del, ref Orther))
        {
            Response.Redirect("NoPermission.aspx");
        }
        if (!Page.IsPostBack)
        {
            this.ddlGroupId.DataSource = this.objAccount.getDataGroupToCombobox();
            this.ddlGroupId.DataTextField = "Name";
            this.ddlGroupId.DataValueField = "Id";
            this.ddlGroupId.DataBind();
        }
        try
        {
            this.itemId = int.Parse(Request["id"].ToString());
        }
        catch
        {
            this.itemId = 0;
        }
        try
        {
            this.cid = int.Parse(Request["cid"].ToString());
        }
        catch
        {
            this.cid = 0;
        }
        
        if (!Page.IsPostBack && this.itemId > 0)
        {
            this.objTable = this.objAccount.getDataById(this.itemId);
            if (this.objTable.Rows.Count > 0)
            {
                this.txtUserName.Text = this.objTable.Rows[0]["UserName"].ToString();
                this.txtFullName.Text = this.objTable.Rows[0]["FullName"].ToString();
                this.txtEmail.Text = this.objTable.Rows[0]["Email"].ToString();
                this.ddlGroupId.SelectedValue = this.objTable.Rows[0]["GroupId"].ToString();
                this.ddlTypeId.SelectedValue = this.objTable.Rows[0]["TypeId"].ToString();
                this.ckbState.Checked = bool.Parse(this.objTable.Rows[0]["State"].ToString());
            }

            if (this.itemId > 0 && this.cid > 0)
            {
                this.objAccount.delDataCategory(this.txtUserName.Text, this.cid);
            }
        }

        Session["TITLE"] = "THÔNG TIN TÀI KHOẢN";
    }
    #endregion

    #region method btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        this.lblMsg.Text = "";

        if (this.txtUserName.Text.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập tên tài khoản.";
            this.txtUserName.Focus();
            return;
        }

        if (this.itemId == 0)
        {
            if (this.objAccount.checkUserName(this.txtUserName.Text.Trim()))
            {
                this.lblMsg.Text = "Tài khoản \""+this.txtUserName.Text+"\" đã được sử dụng, vui lòng chọn tài khoản khác.";
                this.txtUserName.Focus();
                return;
            }
        }

        if (this.txtFullName.Text.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập họ tên tài khoản.";
            this.txtFullName.Focus();
            return;
        }

        if (this.objAccount.setData(this.itemId, this.txtUserName.Text, this.txtFullName.Text, this.txtEmail.Text,this.txtPassWord.Text, int.Parse(this.ddlGroupId.SelectedValue.ToString()), int.Parse(this.ddlTypeId.SelectedValue.ToString()), this.ckbState.Checked) == 1)
        {
            Response.Redirect("Account.aspx");
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
        Response.Redirect("Account.aspx");
    }
    #endregion
}