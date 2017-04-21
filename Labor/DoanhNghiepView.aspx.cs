using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Labor_DoanhNghiepView : System.Web.UI.Page
{
    #region declare objects
    public int itemId = 0;
    private DoanhNghiep objDoanhNghiep = new DoanhNghiep();
    #endregion

    #region Method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            this.itemId = int.Parse(Request["id"].ToString());
        }
        catch
        {
            this.itemId = 0;
        }




    }
    #endregion
}