using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Labor_DanhSachHuyHuong : System.Web.UI.Page
{
    #region declare
    private NguoiLaoDong objNguoiLaoDong = new NguoiLaoDong();
    public int index = 1;
    public string _msg = "";


    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ACCOUNT"] == null)
        {
            Response.Redirect("../Login.aspx");
        }

        if (!Page.IsPostBack)
        {
            Load_CauHinh();
            Load_DanhSachHoSo();

        }

    }
    private void Load_DanhSachHoSo()
    {
        string str = txtSearch.Value.Trim();
        DataTable objData = new TinhHuong().getDanhSachHoSo(",13,", str);
        cpData.MaxPages = 1000;
        cpData.PageSize = 12;
        cpData.DataSource = objData.DefaultView;
        cpData.BindToControl = dtlData;
        dtlData.DataSource = cpData.DataSourcePaged;
        dtlData.DataBind();
    }
    private void Load_CauHinh()
    {
        DateTime myDatetime = DateTime.Now;
        string MyDate = myDatetime.Day.ToString() + "/" + myDatetime.Month.ToString() + "/" + myDatetime.Year.ToString();
    }
    protected void btnSearch_Click(object sender, ImageClickEventArgs e)
    {
        Load_DanhSachHoSo();
    }

    protected void btnHuyHuong_Click(object sender, EventArgs e)
    {
        string[] strID = hdlstChuyen.Value.Split(',');
        for (int i = 0; i < strID.Length; i++)
        {
            DataRow rowTCTN = new NLDTroCapThatNghiep().getItem(int.Parse(strID[i]));
            if ((int)rowTCTN["IdTrangThai"] == 13)
            {
                new TinhHuong().UpdateTrangThaiHS(int.Parse(strID[i]), 18);
            }

        }
        Load_DanhSachHoSo();
    }
}