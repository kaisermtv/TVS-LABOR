using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ajax_PhuongXaOption : System.Web.UI.Page
{
    #region declare
    public int itemId = 0;

    private Ward objWard = new Ward();
    #endregion

    #region Even Page_Load
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

        if (itemId != 0)
        {
            DataTable objData = this.objWard.getDataCategoryToCombobox(itemId.ToString());
            dtlData.DataSource = objData.DefaultView;
            dtlData.DataBind();
        }

    }
    #endregion
}