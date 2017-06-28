using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Labor_DanhSachThamDinh : System.Web.UI.Page
{
    #region declare
    private NguoiLaoDong objNguoiLaoDong = new NguoiLaoDong();
    public int index = 1;

    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ACCOUNT"] == null)
        {
            Response.Redirect("../Login.aspx");
        }
  
        if(!Page.IsPostBack)
        {
            DataTable objData = new TinhHuong().getDanhSachHoSo(",6,7,");
            if (objData != null && objData.Rows.Count > 0)
            {
                cpData.MaxPages = 1000;
                cpData.PageSize = 12;
                cpData.DataSource = objData.DefaultView;
                cpData.BindToControl = dtlData;
                dtlData.DataSource = cpData.DataSourcePaged;
                dtlData.DataBind();
            }
                      
        }
             
    }
    protected void btnTrinhKy_Click(object sender, EventArgs e)
    {
        TinhHuong objTinhHuong = new TinhHuong();
        //kiem tra truong hop chuyen 1 hay nhieu
        if (hdlstChuyen.Value != null && hdlstChuyen.Value.ToString().Trim() != "")
        {
            string[] lstIDTCTN = hdlstChuyen.Value.Split(',');
            for (int i = 0; i < lstIDTCTN.Length; i++)
            {
                int ID = int.Parse(lstIDTCTN[i]);
                DataRow rowThatNghiep = new NLDTroCapThatNghiep().getItem(ID);
                int TrangThai = (int)rowThatNghiep["IdTrangThai"];
                if (TrangThai == 7)
                {
                    objTinhHuong.UpdateTrangThaiHS(ID, 8);
                }
            }
        }
        else
        {
            if (hdlstChuyen.Value != null && hdChuyen.Value.ToString().Trim() != "")
            {
                int ID = int.Parse(hdChuyen.Value);
                DataRow rowThatNghiep = new NLDTroCapThatNghiep().getItem(ID);
                int TrangThai = (int)rowThatNghiep["IdTrangThai"];
                if (TrangThai == 7)
                {
                    objTinhHuong.UpdateTrangThaiHS(ID, 8);
                }
            }

        }
        Response.Redirect(Request.Url.ToString());

    }
}