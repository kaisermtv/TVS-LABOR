using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
        this.lblMessage.Text = "Your Registration is done successfully. Our team will contact you shotly";
    }
}