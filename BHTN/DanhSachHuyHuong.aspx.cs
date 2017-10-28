using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class Labor_DanhSachHuyHuong : System.Web.UI.Page
{
    #region declare
    private NguoiLaoDong objNguoiLaoDong = new NguoiLaoDong();
    public int index = 1;
    public string _msg = "";
    public DataRow _Permission;

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ACCOUNT"] == null)
        {
            Response.Redirect("../Login.aspx");
        }
        else
        {
            DataTable tblPermission = (DataTable)Session["Permission"];
            _Permission = new Account().PermissionPage(tblPermission, System.IO.Path.GetFileName(Request.PhysicalPath));
             if (_Permission ==null || (bool)_Permission["View"] != true)
            {
                Response.Redirect("default.aspx");
            }
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
        DateTime TuNgay = new DateTime(1900, 1, 1),DenNgay=new DateTime(9999,1,1);
        if(txtTuNgay.Value.Trim()!="")
        {
            TuNgay = Convert.ToDateTime(txtTuNgay, new CultureInfo("vi-VN"));
        }
        if(txtDenNgay.Value.Trim()!="")
        {
            DenNgay = Convert.ToDateTime(txtDenNgay.Value, new CultureInfo("vi-VN"));

        }
        DataTable objData = new TinhHuong().getDanhSachHoSoAndQuyetDinh(",13,",str,TuNgay,DenNgay);
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
    protected void dtlData_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "HuyDeXuat")
        {
            int ID = int.Parse(e.CommandArgument.ToString());
            DataRow rowTroCapThatNghiep = new NLDTroCapThatNghiep().getItem(ID);
            // la quyet dinh TCTN
            if ((int)rowTroCapThatNghiep["IdTrangThai"] == 13)
            {
                new TinhHuong().UpdateTrangThaiHS(ID, 11,true);
                Load_DanhSachHoSo();
            }
        }
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=RepeaterExport.xls");
        Response.Charset = "Utf-8";
        Response.ContentType = "application/vnd.ms-excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        hw.WriteLine("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">");
        dtlData.RenderControl(hw);
        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.End();    
    }
}