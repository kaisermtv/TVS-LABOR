using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Category_TrinhDoTinHoc : System.Web.UI.Page
{
    #region declare
    public int index = 1;    
    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ACCOUNT"] == null)
        {
            Response.Redirect("../Login.aspx");
        }
        Session["TITLE"] = "TRÌNH ĐỘ TIN HỌC";

        TrinhDoTinHoc objTrinhDoTinHoc = new TrinhDoTinHoc();
        DataTable objData = objTrinhDoTinHoc.getList();

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