using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
        Session["TITLE"] = "BẢO HIỂM THẤT NGHIỆP";

        if (!Page.IsPostBack)
        {
            //string filename = Path.GetFileName(Request.Path);
            //txtSearch.Value = filename;
            //DataTable objTrangthai = objNguoiLaoDong.getDataTrangThaiToCombobox();
            //ddlIDTrangThai.DataSource = objTrangthai.DefaultView;
            //ddlIDTrangThai.DataTextField = "name";
            //ddlIDTrangThai.DataValueField = "id";
            //ddlIDTrangThai.DataBind();
            ddlIDTrangThai.SelectedValue = "0";
            txtNgayHoanThanh.Value = DateTime.Now.ToString("dd/MM/yyyy");
            txtNgayHoanThanh1.Value = DateTime.Now.ToString("dd/MM/yyyy");

        }
        if (ddlIDTrangThai.SelectedValue == "-2")
        {
            //txtTuNgay.pa
               // txtDenNgay
        }
        else
        {

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
            #region log he thong
            Log item2 = new Log();
            item2.NgayTao = DateTime.Now;
            DataRow TCTN = new NLDTroCapThatNghiep().getItem(int.Parse(idNLD.Value));
            item2.NguoiLaoDongID = (int)TCTN["IDNguoiLaoDong"];
            item2.TroCapThatNghiepID = int.Parse(idNLD.Value);
            item2.UserID = (int)_Permission["Id"];
            item2.UserName = _Permission["UserName"].ToString();
            item2.Action = "Chuyển tính hưởng";
            item2.GhiChu = "";
            new Log().Insert(item2);
            #endregion
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
                #region log he thong
                Log item2 = new Log();
                item2.NgayTao = DateTime.Now;
                DataRow TCTN = new NLDTroCapThatNghiep().getItem(int.Parse(item));
                item2.NguoiLaoDongID = (int)TCTN["IDNguoiLaoDong"];
                item2.TroCapThatNghiepID = int.Parse(item);
                item2.UserID = (int)_Permission["Id"];
                item2.UserName = _Permission["UserName"].ToString();
                item2.Action = "Chuyển tính hưởng";
                item2.GhiChu = "";
                new Log().Insert(item2);
                #endregion
            }
            catch { }
        }
        Response.Redirect(Request.Url.ToString());
    }
    #endregion
    protected void btnSearch_Click(object sender, ImageClickEventArgs e)
    {

    }
}