using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_TuVanDel : System.Web.UI.Page
{
    #region declare objects
    private Account objAccount = new Account();
    private NguoiLaoDong objNguoiLaoDong = new NguoiLaoDong();
    private int itemId = 0;
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
            this.itemId = int.Parse(Request.QueryString["id"].ToString());
        }
        catch
        {
            this.itemId = 0;
        }

        Session["TITLE"] = "XÓA HỒ SƠ TƯ VẤN";

    } 
    #endregion

    #region method btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        this.objNguoiLaoDong.delDataNldTuVan(this.itemId);
        Response.Redirect("Tuvan.aspx");
    }
    #endregion

    #region method btnCancel_Click
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Tuvan.aspx");
    }
    #endregion
}