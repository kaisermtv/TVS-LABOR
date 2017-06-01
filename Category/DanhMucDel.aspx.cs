using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Category_DanhMucDel : System.Web.UI.Page
{
    #region declare
    public int itemId = 0;
    public string danhmuc = "";
    public DataRow objData;
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

        objData = objDanhMuc.getItem(itemId);
        if (objData == null) Response.Redirect("/Category/ListCategory.aspx");
        if ((int)objData["DanhMucId"] == 0) Response.Redirect("/Category/ListCategory.aspx");

        try
        {
            danhmuc = objDanhMuc.getDanhMuc((int)objData["DanhMucId"])["NameDanhMuc"].ToString();
        }
        catch { }
        
    }
    #endregion 

    #region Even btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        DanhMuc objDanhMuc = new DanhMuc();
        objDanhMuc.delData(itemId, (int)objData["DanhMucId"]);

        Response.Redirect("DanhMuc.aspx?id=" + objData["DanhMucId"].ToString());
    }
    #endregion
}