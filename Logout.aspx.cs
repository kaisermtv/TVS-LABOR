using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["ACCOUNT"] = null;
        Session["FULLNAME"] = null;
        Response.Redirect("Login.aspx");
    }
}