using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AboutUs : System.Web.UI.Page
{
    #region Declare objects
    private AboutUs objAboutUs = new AboutUs();
    private DataTable objTable = new DataTable();
    private Account objAccount = new Account();
    private bool View = false, Add = false, Edit = false, Del = false, Orther = false;
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ACCOUNT"] == null)
        {
            Response.Redirect("../Login.aspx");
        }
        if (!this.objAccount.checkForFunction(Session["ACCOUNT"].ToString(), 1, ref View, ref Add, ref Edit, ref Del, ref Orther))
        {
            Response.Redirect("NoPermission.aspx");
        }
        if (!Page.IsPostBack)
        {
            this.objTable = this.objAboutUs.getData();
            if (this.objTable.Rows.Count > 0)
            {
                this.txtName.Text = this.objTable.Rows[0]["Name"].ToString();
                this.txtAddress.Text = this.objTable.Rows[0]["Address"].ToString();
                this.txtPhone.Text = this.objTable.Rows[0]["Phone"].ToString();
                this.txtEmail.Text = this.objTable.Rows[0]["Email"].ToString();
                this.txtHotline.Text = this.objTable.Rows[0]["Hotline"].ToString();
                this.txtGreeting.Text = this.objTable.Rows[0]["Greeting"].ToString();
                this.txtGreeting1.Text = this.objTable.Rows[0]["Greeting1"].ToString();
            }
        }
    } 
    #endregion

    #region method btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (this.txtName.Text == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập tên đơn vị";
            this.txtName.Focus();
            return;
        }
        this.objAboutUs.setData(1,this.txtName.Text, this.txtAddress.Text, this.txtPhone.Text, this.txtEmail.Text, this.txtHotline.Text, this.txtGreeting.Text, this.txtGreeting1.Text);
    }
    #endregion

    #region method btnCancel_Click
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
    #endregion
}