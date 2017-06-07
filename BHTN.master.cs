using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterBHTN : System.Web.UI.MasterPage
{
    #region declare objects
    public string strHtmlTitle = "";
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["TITLE"] == null)
        {
            Session["TITLE"] = "QUẢN LÝ NGUỒN LAO ĐỘNG";
        }
        this.strHtmlTitle = Session["TITLE"].ToString();
    }
    #endregion
}
