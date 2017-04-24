using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Category_TrinhDoNgoaiNgu : System.Web.UI.Page
{
    #region đeclare
    public int index = 0;
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ACCOUNT"] == null)
        {
            Response.Redirect("../Login.aspx");
        }
        Session["TITLE"] = "TRÌNH ĐỘ NGOẠI NGỮ";

        TrinhDoNgoaiNgu objTrinhDongoaiNgu = new TrinhDoNgoaiNgu();
        DataTable objData = objTrinhDongoaiNgu.getList();

        cpData.MaxPages = 1000;
        cpData.PageSize = 12;
        cpData.DataSource = objData.DefaultView;
        cpData.BindToControl = dtlData;
        dtlData.DataSource = cpData.DataSourcePaged;
        dtlData.DataBind();
    }
    #endregion
}