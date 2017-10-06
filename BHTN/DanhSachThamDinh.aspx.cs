using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Labor_DanhSachThamDinh : System.Web.UI.Page
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
        if(!Page.IsPostBack)
        {
            Load_TrangThai();
            Load_DanhSachHoSo();
                      
        }
             
    }
    private void Load_DanhSachHoSo(string Ids = ",6,7,18,19,29,30,39,40,52,53,")
    {
        string str = txtSearch.Value.Trim();
        DateTime TuNgay = new DateTime(1900, 1, 1), DenNgay = new DateTime(9999, 1, 1);
        if(txtTuNgay.Value.Trim()!="")
        {
            TuNgay = Convert.ToDateTime(txtTuNgay.Value, new CultureInfo("vi-VN"));
        }
        if(txtDenNgay.Value.Trim()!="")
        {
            DenNgay = Convert.ToDateTime(txtDenNgay.Value, new CultureInfo("vi-VN"));
        }
        DataTable objData = new TinhHuong().getDanhSachHoSo(Ids, TuNgay, DenNgay, str);

        cpData.MaxPages = 1000;
        cpData.PageSize = 12;
        cpData.DataSource = objData.DefaultView;
        cpData.BindToControl = dtlData;
        dtlData.DataSource = cpData.DataSourcePaged;
        dtlData.DataBind();
    }
    private void Load_TrangThai()
    {
        DataTable tblTrangThai = new TrangThaiHoSo().GetByIds(",6,7,18,19,29,30,39,40,52,53,");
        DataRow row = tblTrangThai.NewRow();
        row["ID"] = 0;
        row["Name"] = "--Tất cả--";
        tblTrangThai.Rows.InsertAt(row, 0);
        ddlTrangThai.DataTextField = "Name";
        ddlTrangThai.DataValueField = "ID";
        ddlTrangThai.DataSource = tblTrangThai;
        ddlTrangThai.DataBind();
    }
    protected void btnTrinhKy_Click(object sender, EventArgs e)
    {
        TinhHuong objTinhHuong = new TinhHuong();
        //kiem tra truong hop chuyen 1 hay nhieu
        if (hdlstChuyen.Value != null && hdlstChuyen.Value.ToString().Trim() != "")
        {
            string[] lstIDTCTN = hdlstChuyen.Value.Split(',');
            int dem = 0;
            for (int i = 0; i < lstIDTCTN.Length; i++)
            {
                int ID = int.Parse(lstIDTCTN[i]);
                DataRow rowThatNghiep = new NLDTroCapThatNghiep().getItem(ID);
                int TrangThai = (int)rowThatNghiep["IdTrangThai"];
                if (TrangThai == 7)
                {
                    objTinhHuong.UpdateTrangThaiHS(ID, 8);
                    #region log he thong
                    Log item = new Log();
                    item.NgayTao = DateTime.Now;
                    DataRow TCTN = new NLDTroCapThatNghiep().getItem(ID);
                    item.NguoiLaoDongID = (int)TCTN["IDNguoiLaoDong"];
                    item.TroCapThatNghiepID = ID;
                    item.UserID = (int)_Permission["Id"];
                    item.UserName = _Permission["UserName"].ToString();
                    item.Action = "Đánh số - Trình ký (TCTN)";
                    item.GhiChu = "";
                    new Log().Insert(item);
                    #endregion
                    dem++;
                }
                if(TrangThai==19)
                {
                    objTinhHuong.UpdateTrangThaiHS(ID, 20);
                    dem++;
                }
                if(TrangThai==30)
                {
                    objTinhHuong.UpdateTrangThaiHS(ID, 31);
                    dem++;
                }
                if(TrangThai==40)
                {
                    objTinhHuong.UpdateTrangThaiHS(ID, 41);
                    dem++;
                }
                if(TrangThai==53)
                {
                    objTinhHuong.UpdateTrangThaiHS(ID, 54);
                    dem++;
                }
               
            }
            if (dem == 0)
            {
                _msg = "Có hồ sơ chưa được thẩm định";
                return;
            }
            Load_DanhSachHoSo();
        }
     
    }
    public string SetLink(int IdNLDTCTN, int IdTrangThai)
    {
        string link = "";
        if (IdTrangThai == 6 || IdTrangThai == 7)
        {
            link = "thamdinh?id=" + IdNLDTCTN;
        }
        if (IdTrangThai == 18 || IdTrangThai == 19)
        {
            link = "ThamDinhHuyHuong?id=" + IdNLDTCTN;
        }
        if (IdTrangThai == 29 || IdTrangThai == 30)
        {
            link = "thamdinhtamdung?id=" + IdNLDTCTN;
        }
        if (IdTrangThai == 39 || IdTrangThai == 40)
        {
            link = "thamdinhtieptuc?id=" + IdNLDTCTN;
        }
        if (IdTrangThai == 52 || IdTrangThai == 53)
        {
            link = "thamdinhchamdut?id=" + IdNLDTCTN;
        }
        return link;
    }
    protected void ddlTrangThai_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTrangThai.SelectedValue != null && ddlTrangThai.SelectedValue.ToString().Trim() != "0")
        {
            Load_DanhSachHoSo("," + ddlTrangThai.SelectedValue + ",");
        }
        else
        {
            Load_DanhSachHoSo();
        }
    }
}