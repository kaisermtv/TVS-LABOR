using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Labor_BaoHiemThatNghiep : System.Web.UI.Page
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

        Session["TITLE"] = "BẢO HIỂM THẤT NGHIỆP";

        if(!Page.IsPostBack)
        {
            DataTable objTrangthai = objNguoiLaoDong.getDataTrangThaiToCombobox();
            ddlIDTrangThai.DataSource = objTrangthai.DefaultView;
            ddlIDTrangThai.DataTextField = "name";
            ddlIDTrangThai.DataValueField = "id";
            ddlIDTrangThai.DataBind();
            ddlIDTrangThai.SelectedValue = "0";
            
        }

        DataTable objData = objNguoiLaoDong.getListBaoHiemThatNghiep(int.Parse(ddlIDTrangThai.SelectedValue), txtSearch.Value);
        if (objData !=null &&  objData.Rows.Count > 0)
        {
            cpData.MaxPages = 1000;
            cpData.PageSize = 12;
            cpData.DataSource = objData.DefaultView;
            cpData.BindToControl = dtlData;
            dtlData.DataSource = cpData.DataSourcePaged;
            dtlData.DataBind();
        }
    }
    protected void btnHoanThienHoSo_Click(object sender, EventArgs e)
    {
        objNguoiLaoDong.chuyenTrangThai(int.Parse(idNLD.Value), 2);
        Response.Redirect(Request.Url.ToString());
    }
    protected void btnDangKyHoSo_Click(object sender, EventArgs e)
    {
        bool ret = objNguoiLaoDong.chuyenTrangThai(int.Parse(idNLD.Value), 1);
        Response.Redirect(Request.Url.ToString());
    }
}