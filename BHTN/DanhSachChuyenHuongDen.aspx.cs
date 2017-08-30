using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Labor_DanhSachChuyenHuongDen: System.Web.UI.Page
{
    #region declare
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
        if(!Page.IsPostBack)
        {        
            Load_CauHinh();            
            Load_TrangThai();
            Load_DanhSachHoSo();
        }
    
    }
    private void Load_DanhSachHoSo()
    {
        DateTime TuNgay = new DateTime(1900, 1, 1);
        DateTime DenNgay = new DateTime(9999, 1, 1);
        if(txtTuNgay.Value.ToString().Trim()!="")
        {
            TuNgay = Convert.ToDateTime(txtTuNgay.Value, new CultureInfo("vi-VN"));
        }
        if(txtDenNgay.Value.ToString().Trim()!="")
        {
            DenNgay=Convert.ToDateTime(txtDenNgay.Value,new CultureInfo("vi-VN"));
        }

        string str = txtSearch.Value.Trim();
        DataTable objData = new TinhHuong().getDanhSachHoSo("," + ddlTrangThai.SelectedValue + ",",TuNgay,DenNgay, str);
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
        txtNgayTrinhKy.Value = MyDate;
    }
   
    protected void dtlData_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "ChuyenHuong")
        {
            int ID = int.Parse(e.CommandArgument.ToString());        
            new TinhHuong().UpdateTrangThaiHS(ID, 27);
            Load_DanhSachHoSo();
        }
       
    }
    protected void dtlData_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
      
    }
    protected void btnChuyenHoSo_Click(object sender, EventArgs e)
    {
        string[] strID = hdlstChuyen.Value.Split(',');
        for (int i = 0; i < strID.Length; i++)
        {
            DataRow rowTCTN = new NLDTroCapThatNghiep().getItem(int.Parse(strID[i]));
            if ((int)rowTCTN["IdTrangThai"] == 11)
            {
                new TinhHuong().UpdateTrangThaiHS(int.Parse(strID[i]), 12);
            }
          
        }
        Load_DanhSachHoSo();

    }
    protected void btnSearch_Click(object sender, ImageClickEventArgs e)
    {
        Load_DanhSachHoSo();
    }
    private void Load_TrangThai()
    {
        DataTable tblTrangThai = new TrangThaiHoSo().GetByIds(",47,");
        ddlTrangThai.DataTextField = "Name";
        ddlTrangThai.DataValueField = "ID";
        ddlTrangThai.DataSource = tblTrangThai;
        ddlTrangThai.DataBind();
    }
    protected void ddlTrangThai_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(ddlTrangThai.SelectedValue !=null)
        {
            Load_DanhSachHoSo();      
        }     
       
    }
}