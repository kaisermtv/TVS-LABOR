using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Labor_BaoHiemThatNghiepEdit : System.Web.UI.Page
{
    #region declare
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
            this.itemId = 0;
        }

        if (!Page.IsPostBack)
        {
            txtNgayDangKyTN.Value = DateTime.Now.ToString("dd/MM/yyyy");
        }
    }
    #endregion

    #region Even btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {

    }
    #endregion
}