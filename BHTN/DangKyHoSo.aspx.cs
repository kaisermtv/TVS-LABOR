using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BHTN_DangKyHoSo : System.Web.UI.Page
{
    #region declare
    private NguoiLaoDong objNguoiLaoDong = new NguoiLaoDong();
    private BHTNClass objBHXH = new BHTNClass();
    public int index = 1;

    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ACCOUNT"] == null)
        {
            Response.Redirect("../Login.aspx");
        }

        Session["TITLE"] = "BẢO HIỂM THẤT NGHIỆP";

        if (!Page.IsPostBack)
        {
            //DataTable objTrangthai = objNguoiLaoDong.getDataTrangThaiToCombobox();
            //ddlIDTrangThai.DataSource = objTrangthai.DefaultView;
            //ddlIDTrangThai.DataTextField = "name";
            //ddlIDTrangThai.DataValueField = "id";
            //ddlIDTrangThai.DataBind();
            ddlIDTrangThai.SelectedValue = "0";

            txtNgayHoanThanh.Value = DateTime.Now.ToString("dd/MM/yyyy");
            txtNgayHoanThanh1.Value = DateTime.Now.ToString("dd/MM/yyyy");

        }

        DataTable objData = objBHXH.getListDangKY(int.Parse(ddlIDTrangThai.SelectedValue), txtSearch.Value, TVSSystem.CVDateNull(txtTuNgay.Value),TVSSystem.CVDateNull(txtDenNgay.Value));
        //if (objData.Rows.Count > 0)
        //{
        cpData.MaxPages = 1000;
        cpData.PageSize = 12;
        cpData.DataSource = objData.DefaultView;
        cpData.BindToControl = dtlData;
        dtlData.DataSource = cpData.DataSourcePaged;
        dtlData.DataBind();
        index = 1;
        //}
    }
    #region Even btnHoanThienHoSo_Click
    protected void btnHoanThienHoSo_Click(object sender, EventArgs e)
    {
        try
        {
            objBHXH.setHoanThien(int.Parse(idNLD.Value), txtNgayHoanThanh.Value);
            Response.Redirect(Request.Url.ToString());
        }
        catch
        {
            lblMsg.Text = "Có lỗi xảy ra!";
        }
    }
    #endregion

    #region Even btnListHoanThienHoSo_Click
    protected void btnListHoanThienHoSo_Click(object sender, EventArgs e)
    {
        string[] listid = idNLDList.Value.Split(',');
        foreach (string item in listid)
        {
            try
            {
                objBHXH.setHoanThien(int.Parse(item), txtNgayHoanThanh1.Value);
            }
            catch { }
        }
        Response.Redirect(Request.Url.ToString());
    }
    #endregion
}