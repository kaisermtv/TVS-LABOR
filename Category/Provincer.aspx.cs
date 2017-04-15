﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Provincer : System.Web.UI.Page
{
    #region declare objects
    private DataTable objTable = new DataTable();
    private Account objAccount = new Account();
    private Provincer objProvincer = new Provincer();
    private SearchConfig objSearchConfig = new SearchConfig();
    private int currPage = 0;
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
        if (!Page.IsPostBack)
        {
            this.txtSearch.Text = this.objSearchConfig.getData(Session["ACCOUNT"].ToString(), "tblProvincer", "Name");
            this.getData();
        }
    } 
    #endregion

    #region getData()
    private void getData()
    {
        this.objTable = this.objProvincer.getData(this.txtSearch.Text);
        cpProvincer.MaxPages = 1000;
        cpProvincer.PageSize = 15;
        cpProvincer.DataSource = this.objTable.DefaultView;
        cpProvincer.BindToControl = dtlProvincer;
        dtlProvincer.DataSource = cpProvincer.DataSourcePaged;
        dtlProvincer.DataBind();
        if (this.objTable.Rows.Count < 9)
        {
            this.tblABC.Visible = false;
        }
        else
        {
            this.tblABC.Visible = true;
        }
    }
    #endregion

    #region method btnSearch_Click
    protected void btnSearch_Click(object sender, ImageClickEventArgs e)
    {
        this.getData();

        #region Luu gia tri tim kiem vao bang cau hinh
        this.objSearchConfig.setData(Session["ACCOUNT"].ToString(), "tblProvincer", "Name", this.txtSearch.Text.Trim());
        #endregion
    }
    #endregion
}