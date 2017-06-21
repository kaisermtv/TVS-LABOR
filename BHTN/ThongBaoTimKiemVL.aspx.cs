using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Labor_TinhHuong : System.Web.UI.Page
{
    #region declare  
    public int itemId = 0;
    public string _msg="";
    public int _status = 0; // 0 trang thai tinh huong  3 trang thai xem chi tiet theo doi lich thong bao
    #endregion

    #region Even Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ACCOUNT"] == null)
        {
            Response.Redirect("../Login.aspx");
        }

        if (Request.QueryString["id"] != null && Request.QueryString["id"].ToString().Trim() != "")
        {
            itemId= int.Parse(Request["id"].ToString());
        }      
        if (!Page.IsPostBack)
        {          
     
        }
     
    }
    #endregion
    private void Load_CauHinh()
    {
        string MyDateTime = DateTime.Now.ToString("dd/MM/yyyy");       
      
    }
    protected void btnDaKhaiBao_Click(object sender, EventArgs e)
    {

    }
    protected void btnKhongKhaiBao_Click(object sender, EventArgs e)
    {

    }
}