﻿using SiteUtils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using System.IO;
using System.Net;

public partial class Labor_TuVan : System.Web.UI.Page
{
    #region declare objects
    private DataTable objTable = new DataTable();
    private Account objAccount = new Account();
    private NguoiLaoDong objNguoiLaoDong = new NguoiLaoDong();
    private SearchConfig objSearchConfig = new SearchConfig();
    private string hoVaTen = "";
    private bool View = false, Add = false, Edit = false, Del = false, Orther = false;
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ACCOUNT"] == null)
        {
            Response.Redirect("../Login.aspx");
        }
        Session["TITLE"] = "HỒ SƠ TƯ VẤN";
        try
        {
            this.hoVaTen = Request.QueryString["n"].ToString();
        }
        catch
        {
            this.hoVaTen = "";
        }
        if (!Page.IsPostBack)
        {
            this.getData();
        }
        this.txtSearch.Focus();
    } 
    #endregion

    #region getData()
    private void getData()
    {
        this.objTable = this.objNguoiLaoDong.getDataTblNldTuVan1(this.txtSearch.Value.ToString(), this.hoVaTen);
        cpTuVanViecLam.MaxPages = 2000;
        cpTuVanViecLam.PageSize = 10;
        cpTuVanViecLam.DataSource = this.objTable.DefaultView;
        cpTuVanViecLam.BindToControl = dtlTuVanViecLam;
        dtlTuVanViecLam.DataSource = cpTuVanViecLam.DataSourcePaged;
        dtlTuVanViecLam.DataBind();
        if (this.objTable.Rows.Count < 10)
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
    }
    #endregion

    public void HtmlAnchor_Click(Object sender, EventArgs e)
    {
        HtmlAnchor objSender = (HtmlAnchor)sender;

        //object filename = Server.MapPath("temp/Temp1.doc");
        //Microsoft.Office.Interop.ApplicationClass mswordappcls = new Microsoft.Office.Interop.Word.ApplicationClass();
        //Microsoft.Office.Interop.Word.Document msworddoc = new Microsoft.Office.Interop.Word.Document();
        //object readOnly = false;
        //object isVisible = true;
        //object missing = System.Reflection.Missing.Value;
        //msworddoc = mswordappcls.Documents.Open(ref filename, ref missing, ref readOnly, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref isVisible);
        //string strContent = msworddoc.Content.Text;
        //mswordappcls.Documents.Close();

        string strBody = "<html>";
        strBody += "<body>";
        strBody += "<div>Your name is: <b>" + objSender.Name + "</b></div>";
        strBody += "<table width=\"100%\" style=\"background-color:#cfcfcf;\"><tr><td>1st Cell body data</td><td>2nd cell body data</td></tr></table>";
        strBody += "Ms Word document generated successfully.";
        strBody += "</body>";
        strBody += "</html>";

        string fileName = "MsWordSample.doc";
        Response.AppendHeader("Content-Type", "application/msword");
        Response.AppendHeader("Content-disposition", "inline; filename=" + fileName);
        Response.Write(strBody);

        HttpContext.Current.Response.End();
        HttpContext.Current.Response.Flush();
    }
}