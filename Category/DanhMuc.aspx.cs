using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Category_DanhMuc : System.Web.UI.Page
{
    #region declare
    public int index = 1;

    public int itemId = 0;
    #endregion

    #region Even Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ACCOUNT"] == null)
        {
            Response.Redirect("../Login.aspx");
        }

        try
        {
            this.itemId = int.Parse(Request["id"].ToString());
        }
        catch
        {
            Response.Redirect("/Category/ListCategory.aspx");
        }

        DanhMuc objDanhMuc = new DanhMuc();

        DataRow danhuc = objDanhMuc.getDanhMuc(itemId);
        if (danhuc == null) Response.Redirect("/Category/ListCategory.aspx");

        Session["TITLE"] = danhuc["NameDanhMuc"].ToString().ToUpper();


        DataTable objData = objDanhMuc.getList(itemId);

        //dtlAccount.DataSource = objData.DefaultView;
        //dtlAccount.DataBind();

        cpData.MaxPages = 1000;
        cpData.PageSize = 15;
        cpData.DataSource = objData.DefaultView;
        cpData.BindToControl = dtlData;
        dtlData.DataSource = cpData.DataSourcePaged;
        dtlData.DataBind();

        index = 1;
    }
    #endregion
}