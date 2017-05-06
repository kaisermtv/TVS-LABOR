﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Labor_DtKhoaHocDel : System.Web.UI.Page
{
    #region declare
    public int itemId = 0;
    #endregion

    #region Method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ACCOUNT"] == null)
        {
            Response.Redirect("../Login.aspx");
        }

        try
        {
            this.itemId = int.Parse(Request.QueryString["id"].ToString());
        }
        catch
        {
            this.itemId = 0;
        }
    }
    #endregion

    #region Method btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        DtKhoaHoc objDtKhoaHoc = new DtKhoaHoc();
        objDtKhoaHoc.delData(itemId);

        Response.Redirect("DtKhoaHocList.aspx");
    }
    #endregion
}