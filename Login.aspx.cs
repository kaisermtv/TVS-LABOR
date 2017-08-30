using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Login : System.Web.UI.Page
{
    #region Declare obects
    private Account objAccount = new Account();
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        this.txtUserName.Focus();
    } 
    #endregion

    #region method btnLogin_Click
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        this.lblMsg.Text = "";
        if (this.txtUserName.Value.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập tên tài khoản!";
            this.txtUserName.Focus();
            return;
        }
        if (this.txtPassWord.Value.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập mật khẩu của tài khoản!";
            this.txtPassWord.Focus();
            return;
        }
        string FullName = "";
        if (this.objAccount.checkForLogin(this.txtUserName.Value.Trim(), this.txtPassWord.Value.Trim(), ref FullName))
        {
            Session["ACCOUNT"] = this.txtUserName.Value.Trim();
            Session["FULLNAME"] = FullName;
            Session["Permission"] = new Account().getDataPermissonByUserName(txtUserName.Value.ToString().Trim());
            Response.Redirect("Admin");
        }
        else
        {
            this.lblMsg.Text = "Thông tin đăng nhập không hợp lệ!";
        }
    }
    #endregion
}