using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Category_TrinhDoTinHocEdit : System.Web.UI.Page
{
    #region declare objects
    private int itemId = 0;
    #endregion

    #region Page_Load
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
            this.itemId = 0;
        }
        if (!Page.IsPostBack && this.itemId > 0)
        {
            TrinhDoTinHoc objTrinhDoTinHoc = new TrinhDoTinHoc();

            DataRow objData = objTrinhDoTinHoc.getItem(itemId);
            if (objData != null)
            {
                txtNameTrinhDo.Text = objData["NameTrinhDo"].ToString();
                txtNote.Text = objData["Note"].ToString();
                this.ckbState.Checked = (bool)objData["State"];
            }

        }
        this.txtNameTrinhDo.Focus();
    }
    #endregion

    #region btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        this.lblMsg.Text = "";

        if (this.txtNameTrinhDo.Text.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập tên trình độ tin học";
            this.txtNameTrinhDo.Focus();
            return;
        }

        TrinhDoTinHoc objTrinhDoTinHoc = new TrinhDoTinHoc();
        int ret = objTrinhDoTinHoc.setData(itemId, this.txtNameTrinhDo.Text.Trim(), txtNote.Text.Trim(), ckbState.Checked);

        if(ret == 0)
        {
            this.lblMsg.Text = "Có lỗi xảy ra!";
        } else {
            Response.Redirect("TrinhDoTinHoc.aspx?id=" + ret);
        }
    }
    #endregion
}