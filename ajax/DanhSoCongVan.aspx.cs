using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DanhSoCongVan : System.Web.UI.Page
{
    int IDLoaiCongVan = 0;
    public int SoQuyetDinh = 0;
    public DateTime MyDateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null && Request.QueryString["id"].ToString().Trim() != "")
        {
            IDLoaiCongVan = int.Parse(Request.QueryString["id"].ToString());
            SoQuyetDinh = new CapSo().GetAutoNumber(MyDateTime, IDLoaiCongVan);
        }
    }
   
}
 