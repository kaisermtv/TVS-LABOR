using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_DelPermission : System.Web.UI.Page
{
    #region declare objects
    private Account objAccount = new Account();
    public int GroupId = 0, FunctionId = 0;
    private bool View = false, Add = false, Edit = false, Del = false, Orther = false;
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ACCOUNT"] == null)
        {
            Response.Redirect("../Login.aspx");
        }
        if (!this.objAccount.checkForFunction(Session["ACCOUNT"].ToString(), 4, ref View, ref Add, ref Edit, ref Del, ref Orther))
        {
            Response.Redirect("NoPermission.aspx");
        }
        try
        {
            this.GroupId = int.Parse(Request["Gid"].ToString());
        }
        catch
        {
            this.GroupId = 0;
        }

        try
        {
            this.FunctionId = int.Parse(Request["Fid"].ToString());
        }
        catch
        {
            this.FunctionId = 0;
        }
    }
    #endregion

    #region method btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        this.objAccount.delDataPermission(this.GroupId,this.FunctionId);
        Response.Redirect("EditGroupAccount.aspx?id=" + this.GroupId.ToString());
    }
    #endregion

    #region method btnCancel_Click
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("EditGroupAccount.aspx?id=" + this.GroupId.ToString());
    }
    #endregion
}