using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Category_DanhMucEdit : System.Web.UI.Page
{
    #region declare 
    public int itemId = 0;
    public int group = 0;
    public DataRow objData;

    private DanhMuc objDanhMuc = new DanhMuc();
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
            itemId = 0;
        }

        try
        {
            this.group = int.Parse(Request["dm"].ToString());
        }
        catch
        {
            group = 0;
        }

        if (itemId == 0 && group == 0) Response.Redirect("/Category/ListCategory.aspx");

        if (itemId != 0)
        {
            objData = objDanhMuc.getItem(itemId);
            if (objData == null) Response.Redirect("/Category/ListCategory.aspx");
            if ((int)objData["DanhMucId"] == 0) Response.Redirect("/Category/ListCategory.aspx");
            group = (int)objData["DanhMucId"];

            if(!Page.IsPostBack)
            {
                txtNameDanhMuc.Text = objData["NameDanhMuc"].ToString();
                txtNote.Text = objData["Note"].ToString();
                ckbState.Checked = (bool)objData["State"];
            }


        }
        else if (!Page.IsPostBack)
        {
            ckbState.Checked = true;
        }

        DataRow danhuc = objDanhMuc.getDanhMuc(group);
        if (danhuc == null) Response.Redirect("/Category/ListCategory.aspx");

        Session["TITLE"] = danhuc["NameDanhMuc"].ToString().ToUpper();



    }
    #endregion

    #region Even btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        int ret = objDanhMuc.setData(itemId, group, txtNameDanhMuc.Text, txtNote.Text, ckbState.Checked);

        if(ret != 0)
        {
            Response.Redirect("DanhMucEdit.aspx?id="+ ret);
        }
        else
        {
            lblMsg.Text = "Có lỗi xảy ra!";
        }
    }
    #endregion
}