using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Labor_BieuDoThongKeTheoVeTinh : System.Web.UI.Page
{
    #region declare
    public int index = 1;
    public string _msg = "";
    DataRow _Permission;
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ACCOUNT"] == null)
        {
            Response.Redirect("../Login.aspx");
        }
        else
        {
            //DataTable tblPermission = (DataTable)Session["Permission"];
            //_Permission = new Account().PermissionPage(tblPermission, System.IO.Path.GetFileName(Request.PhysicalPath));
            //try
            //{
            //     if (_Permission ==null || (bool)_Permission["View"] != true)
            //    {
            //        Response.Redirect("default.aspx");
            //    }
            //}
            //catch
            //{
            //    Response.Redirect("default.aspx");
            //}
        }
        if (!Page.IsPostBack)
        {
            Load_CauHinh();
            Load_TrangThai();
        }             
    }
    private void Load_DanhSachHoSo(string Ids = ",26,")
    {
        string str = txtSearch.Value.Trim();
        DateTime TuNgay = DateTime.Now, DenNgay = DateTime.Now;
        if(txtTuNgay.Value.Trim()=="")
        {
            TuNgay = new DateTime(1900, 1, 1);
        }
        TuNgay = Convert.ToDateTime(txtTuNgay.Value, new CultureInfo("vi-VN"));
        if(txtDenNgay.Value.Trim()=="")
        {
            DenNgay = new DateTime(9999, 1, 1);
        }
        DenNgay = Convert.ToDateTime(txtDenNgay.Value, new CultureInfo("vi-VN"));
        List<BieuDoHinhCotBHTN> lstBieuDo = new List<BieuDoHinhCotBHTN>();
        DataTable tblNoiNhan = new DanhMuc().getList(13);
        for (int i = 0; i < tblNoiNhan.Rows.Count; i++)
        {
            BieuDoHinhCotBHTN item = new BieuDoHinhCotBHTN();
            DataTable tblBHTN = new BaoCao().BieuDoBHTNTTheoDonVi(TuNgay, DenNgay, (int)tblNoiNhan.Rows[i]["IdDanhMuc"]);
            if (tblBHTN.Rows.Count > 0)
            {
                item.Ngay = tblNoiNhan.Rows[i]["NameDanhMuc"].ToString().Trim();
                item.SoHoSo = tblBHTN.Rows.Count;
                lstBieuDo.Add(item);
            }
        }       
        // truong hop khong ho so khong ro dia chi nhan do can bo khong chon         
        Chart1.DataSource = lstBieuDo;
        Chart1.Series["Category"].XValueMember = "Ngay";
        Chart1.Series["Category"].YValueMembers = "SoHoSo";
        Chart1.DataBind();
        //name x,y
        //Chart1.ChartAreas["ChartArea1"].AxisX.Title = "Các ngày nộp hồ sơ";
        //Chart1.ChartAreas["ChartArea1"].AxisY.Title = "Số hồ sơ nộp";
    }
   
   
    private void Load_CauHinh()
    {
        DateTime myDatetime = DateTime.Now;
        string MyDate = myDatetime.Day.ToString() + "/" + myDatetime.Month.ToString() + "/" + myDatetime.Year.ToString();
        txtNgayTrinhKy.Value = MyDate;
    }    
    protected void btnSearch_Click(object sender, ImageClickEventArgs e)
    {
        Load_DanhSachHoSo();
    }
    private void Load_TrangThai()
    {
        DataTable tblTrangThai = new TrangThaiHoSo().GetByIds(",26,");
        DataRow row = tblTrangThai.NewRow();
        row["ID"] = 0;
        row["Name"] = "--Tất cả--";
        tblTrangThai.Rows.InsertAt(row, 0);
        ddlTrangThai.DataTextField = "Name";
        ddlTrangThai.DataValueField = "ID";
        ddlTrangThai.DataSource = tblTrangThai;
        ddlTrangThai.DataBind();
    }
    protected void ddlTrangThai_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(ddlTrangThai.SelectedValue !=null && ddlTrangThai.SelectedValue.ToString().Trim()!="0")
        {
            Load_DanhSachHoSo("," + ddlTrangThai.SelectedValue + ",");         
        }     
        else
        {
            Load_DanhSachHoSo();
        }
    }
    protected void btnXuatExcel_Click(object sender, EventArgs e)
    {
        
    }
    public string GetGoiTinh(int IDGioiTinh)
    {
        string value = "";
        if (IDGioiTinh == 1)
        {
            return "Nam";
        }
        if (IDGioiTinh == 2)
        {
            return "Nữ";
        }
        return value;
    }
    public string GetDiaChi(string Tinh,string Huyen,string Xa,string Xom)
    {
        string diachi="";
        if(Xom.Trim()!="")
        {
            Xom += ", ";
            diachi += Xom;
        }
        if(Xa.Trim()!="")
        {
            Xa += ", ";
            diachi += Xa;
        }
        if(Huyen.Trim()!="")
        {
            Huyen += ", ";
            diachi += Huyen;
        }
        diachi += Tinh;
        return diachi;
    }
}
