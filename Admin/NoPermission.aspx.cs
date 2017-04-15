using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_NoPermission : System.Web.UI.Page
{
    #region declare objects
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    #endregion

    #region method btnCancel_Click
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        if (Request.UrlReferrer.ToString() != null)
        {
            Response.Redirect(Request.UrlReferrer.ToString());
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
    }
    #endregion
}