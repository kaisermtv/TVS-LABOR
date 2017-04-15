using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Profile : System.Web.UI.Page
{
    #region declare objects
    private int itemId = 0;
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
            this.objTable = this.objAccount.getDataByUserName(Session["ACCOUNT"].ToString());
            if (this.objTable.Rows.Count > 0)
            {
                this.txtUserName.Text = this.objTable.Rows[0]["UserName"].ToString();
                this.txtFullName.Text = this.objTable.Rows[0]["FullName"].ToString();
                this.txtEmail.Text = this.objTable.Rows[0]["Email"].ToString();
                this.txtUserName.ReadOnly = true;
            }

            this.objTable = this.objAccount.getDataCategory(this.txtUserName.Text, this.itemId);
            cpAccounrCategory.MaxPages = 1000;
            cpAccounrCategory.PageSize = 15;
            cpAccounrCategory.DataSource = this.objTable.DefaultView;
            cpAccounrCategory.BindToControl = dtlAccountCategory;
            dtlAccountCategory.DataSource = cpAccounrCategory.DataSourcePaged;
            dtlAccountCategory.DataBind();
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

        if (this.txtUserName.Text.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập tên tài khoản.";
            this.txtUserName.Focus();
            return;
        }

        if (this.txtFullName.Text.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập họ tên tài khoản.";
            this.txtFullName.Focus();
            return;
        }

        if (this.objAccount.setData(this.txtUserName.Text, this.txtFullName.Text, this.txtEmail.Text, this.txtPassWord.Text) == 1)
        {
            this.lblMsg.Text = "<span style = \"color:blue;\">Thông tin đã được cập nhật thành công</span>";
        }
        else
        {
            this.lblMsg.Text = "Lỗi xảy ra khi cập nhật thông tin.";
        }
    }
    #endregion
}