using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Labor_ThongBaoTimKiemVL : System.Web.UI.Page
{
    #region declare  
    public int itemId = 0;
    public int _index = 1;
    public string _msg="";
    public int _tg = 0;
    public int _status = 0;//= 0 trang  thai them 3 trang thai da khai bao
    public DataRow _Permission;
    #endregion
    #region Even Page_Load
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
        if (Request.QueryString["id"] != null && Request.QueryString["id"].ToString().Trim() != "")
        {
            itemId= int.Parse(Request["id"].ToString());           
        }
        else
        {
            Response.Redirect("DanhSachThongBaoVL.aspx");
        }
        if (Request.QueryString["tg"] != null && Request.QueryString["tg"].ToString().Trim() != "")
        {
            _tg = int.Parse(Request["tg"].ToString());          
        }  
        else
        {
            Response.Redirect("DanhSachThongBaoVL.aspx");
        }
        DataTable tblThongBaoVL = new ThongBaoViecLamHangThang().GetByID(itemId, _tg);
        if (tblThongBaoVL.Rows.Count != 0 )
        {
            if (tblThongBaoVL.Rows[0]["TrangThaiThongBao"].ToString() == "14")
            {
                lblThongBao.Text = "Đã khai báo tháng: " + _tg.ToString();
                _status = 3;
                Load_CauHinhDaThongBao(false);
            }
            if (tblThongBaoVL.Rows[0]["TrangThaiThongBao"].ToString() == "15")
            {
                lblThongBao.Text = "Không khai báo tháng: " + _tg.ToString();
                _status = 3;
                Load_CauHinhDaThongBao(false);
            }           
        }
        else
        {
            lblThongBao.Text = "Bạn chưa khai báo tháng: " + _tg.ToString();
            _status = 0;
            Load_CauHinhDaThongBao(true);
        }
        if (!Page.IsPostBack)
        {          
            Load_CauHinh();
            Load_DanhMuc();
            // lay thong tin nguoi dung
            DataRow  rowTCTN=new NLDTroCapThatNghiep().getItem(itemId);
            int id = (int)rowTCTN["IDNguoiLaoDong"];
            DataTable tblNguoiLaoDong = new NguoiLaoDong().getDataById(id);
            if(tblNguoiLaoDong !=null && tblNguoiLaoDong.Rows.Count!=0)
            {
                lblHoTen.Text = tblNguoiLaoDong.Rows[0]["HoVaTen"].ToString();
                lblCMND.Text = tblNguoiLaoDong.Rows[0]["CMND"].ToString();
                lblSoBHXH.Text = tblNguoiLaoDong.Rows[0]["BHXH"].ToString();
            }          
           
        }     
    }
    #endregion
    private void Load_DanhMuc()
    {
        Load_SoThangThongBao();
        Load_DanhSachCanBoTiepNhan();
        Load_LyDo();
        Load_TinhTrangViecLam();
    }
    private void Load_CauHinhDaThongBao(bool status)
    {
        btnDaKhaiBao.Enabled = status;
        btnKhongKhaiBao.Enabled = status;
    }
    private void Load_CauHinh()
    {
        string MyDateTime = DateTime.Now.ToString("dd/MM/yyyy");
        txtNgayKhaiBao.Value = MyDateTime.ToString();
      
    }
    private void Load_DanhSachCanBoTiepNhan()
    {
        ddlNguoiTiepNhan.DataValueField = "ID";
        ddlNguoiTiepNhan.DataTextField = "FullName";
        ddlNguoiTiepNhan.DataSource = new Account().GetUserByGroupID(2);
        ddlNguoiTiepNhan.DataBind();
    }
    private void Load_LyDo()
    {
        ddlLyDo.DataValueField = "IdDanhMuc";
        ddlLyDo.DataTextField = "NameDanhMuc";
        ddlLyDo.DataSource = new DanhMuc().getList(33);
        ddlLyDo.DataBind();
    }
    private void Load_TinhTrangViecLam()
    {
        DataTable tblTrangThaiViecLam = new DanhMuc().getList(38);
        DataRow row = tblTrangThaiViecLam.NewRow();
        row["IdDanhMuc"] = 0;
        row["NameDanhMuc"] = "--Chọn tình trạng việc làm--";
        tblTrangThaiViecLam.Rows.InsertAt(row, 0);
        ddlTinhTrangViecLam.DataValueField = "IdDanhMuc";
        ddlTinhTrangViecLam.DataTextField = "NameDanhMuc";
        ddlTinhTrangViecLam.DataSource = tblTrangThaiViecLam;
        ddlTinhTrangViecLam.DataBind();
    }
    List<ThongBaoViecLamHangThang> lstThongBaoViecLam = new List<ThongBaoViecLamHangThang>();
    private void Load_SoThangThongBao()
    {
        DataTable tblTinhHuong = new TinhHuong().getDataById(itemId);
        DataTable tblLichThongBao = new LichThongBao().GetDataByID(int.Parse(tblTinhHuong.Rows[0]["IDTinhHuong"].ToString()));
        for (int i = 1; i <= 12; i++)
        {
            string str = "Tháng ";
            if (((DateTime)tblLichThongBao.Rows[0]["KhaiBaoThang" + i.ToString() + "TuNgay"]).ToString("yyyy") != "1900")
            {
                str += i.ToString();
                str += " (" + (((DateTime)tblLichThongBao.Rows[0]["KhaiBaoThang" + i.ToString() + "TuNgay"]).ToString("dd/MM/yyyy"));
                if (i == 0)
                {
                    str += " )";
                }
                else
                {
                    if (((DateTime)tblLichThongBao.Rows[0]["KhaiBaoThang" + i.ToString() + "DenNgay"]).ToString("yyyy") != "1900")
                    {
                        str += " -> " + (((DateTime)tblLichThongBao.Rows[0]["KhaiBaoThang" + i.ToString() + "DenNgay"]).ToString("dd/MM/yyyy")) + ")";
                    }
                }         
                ThongBaoViecLamHangThang item = new ThongBaoViecLamHangThang();
                DataTable tblThongBaoVL = new ThongBaoViecLamHangThang().GetByID(itemId, i);
                if(tblThongBaoVL.Rows.Count!=0 && tblThongBaoVL.Rows[0]["TrangThaiThongBao"].ToString()=="14")
                {
                    item.TrangThaiThongBao = 14;
                }
                if (tblThongBaoVL.Rows.Count != 0 && tblThongBaoVL.Rows[0]["TrangThaiThongBao"].ToString() == "15")
                {
                    item.TrangThaiThongBao = 14;
                }
                item.GhiChu = str;
                lstThongBaoViecLam.Add(item);                
            }
        }
        rptLichThongBao.DataSource = lstThongBaoViecLam;
        rptLichThongBao.DataBind();
    }
    protected void btnDaKhaiBao_Click(object sender, EventArgs e)
    {
        ThongBaoViecLamHangThang objThongBaoVl = new ThongBaoViecLamHangThang();
        if (_tg == 0)
        {
            _msg = "Bạn chưa chọn tháng thông báo";
            return;
        }
        objThongBaoVl.IDNLDTCTN = itemId;
        objThongBaoVl.ThangThongBao = _tg;
        if (txtNgayKhaiBao.Value.Trim() == "")
        {
            _msg = "Bạn chưa chọn ngày khai báo";
            return;
        }
        objThongBaoVl.NgayThongBao = Convert.ToDateTime(txtNgayKhaiBao.Value, new CultureInfo("vi-VN"));
        if(ddlNguoiTiepNhan.SelectedValue ==null ||  ddlNguoiTiepNhan.SelectedValue.ToString().Trim()=="")
        {
            _msg = "Bạn chưa chọn người tiếp nhận";
            return;
        }
        objThongBaoVl.IDCanBoTiepNhan = int.Parse(ddlNguoiTiepNhan.SelectedValue.ToString());
        if (ddlTinhTrangViecLam.SelectedValue == null || ddlTinhTrangViecLam.SelectedValue.ToString() == "" || ddlTinhTrangViecLam.SelectedValue.ToString() == "0")
        {
            _msg = "Bạn chưa chọn tình trạng việc làm";
            return;
        }
      
        objThongBaoVl.IDThongBaoViecLam = int.Parse(ddlTinhTrangViecLam.SelectedValue.ToString());
        objThongBaoVl.BanTiepNhan = txtSoQuay.Text.Trim();
        objThongBaoVl.GhiChu = txtGhiChu.Text;
        if(chkKhaiBaoTrucTiep.Checked==true)
        {
            objThongBaoVl.LyDo = int.Parse(ddlLyDo.SelectedValue.ToString());
        }
        objThongBaoVl.TrangThaiThongBao = 14;
        new ThongBaoViecLamHangThang().SetData(objThongBaoVl.IDNLDTCTN, objThongBaoVl.IDCanBoTiepNhan, objThongBaoVl.ThangThongBao, objThongBaoVl.NgayThongBao, objThongBaoVl.ThongBaoTrucTiep, objThongBaoVl.LyDo, objThongBaoVl.BanTiepNhan, objThongBaoVl.GhiChu, objThongBaoVl.TrangThaiThongBao);
        //cap nhat so thang da huong
        DataTable tblSoThangDaHuongBHXH = new ThongBaoViecLamHangThang().GetByID(itemId, 0, 14);
        DataTable tblSoThangKhongHuong = new ThongBaoViecLamHangThang().GetByID(itemId, 0, 15);
        int SoThangDaHuong = tblSoThangDaHuongBHXH.Rows.Count;
        int SoThangKhongHuong = tblSoThangKhongHuong.Rows.Count;       
        new TinhHuong().UpdateSoThangDaHuong(itemId, tblSoThangDaHuongBHXH.Rows.Count);
        // cap nhat so thang con lai       
        DataTable tblTinhHuong = new TinhHuong().getDataById(itemId);
        int SoThangDuocHuongConLai = (int)tblTinhHuong.Rows[0]["SoThangHuongBHXH"] - (SoThangDaHuong + SoThangKhongHuong);
        new TinhHuong().UpdateSoThangDuocHuongConLai(itemId, SoThangDuocHuongConLai);
        _msg = "Cập nhật thành công";    
    }
    protected void btnKhongKhaiBao_Click(object sender, EventArgs e)
    {
        ThongBaoViecLamHangThang objThongBaoVl = new ThongBaoViecLamHangThang();
        if (_tg == 0)
        {
            _msg = "Bạn chưa chọn tháng thông báo";
            return;
        }
        objThongBaoVl.IDNLDTCTN = itemId;
        objThongBaoVl.ThangThongBao = _tg;
        if (txtNgayKhaiBao.Value.Trim() == "")
        {
            _msg = "Bạn chưa chọn ngày khai báo";
            return;
        }
        objThongBaoVl.NgayThongBao = Convert.ToDateTime(txtNgayKhaiBao.Value, new CultureInfo("vi-VN"));
        if (ddlNguoiTiepNhan.SelectedValue == null || ddlNguoiTiepNhan.SelectedValue.ToString().Trim() == "")
        {
            _msg = "Bạn chưa chọn người tiếp nhận";
            return;
        }
        objThongBaoVl.IDCanBoTiepNhan = int.Parse(ddlNguoiTiepNhan.SelectedValue.ToString());
        objThongBaoVl.IDThongBaoViecLam = int.Parse(ddlTinhTrangViecLam.SelectedValue.ToString());
        objThongBaoVl.BanTiepNhan = txtSoQuay.Text.Trim();
        objThongBaoVl.GhiChu = txtGhiChu.Text;
        if (chkKhaiBaoTrucTiep.Checked == true)
        {
            objThongBaoVl.LyDo = int.Parse(ddlLyDo.SelectedValue.ToString());
        }
        objThongBaoVl.TrangThaiThongBao = 15;
        new ThongBaoViecLamHangThang().SetData(objThongBaoVl.IDNLDTCTN, objThongBaoVl.IDCanBoTiepNhan, objThongBaoVl.ThangThongBao, objThongBaoVl.NgayThongBao, objThongBaoVl.ThongBaoTrucTiep, objThongBaoVl.LyDo, objThongBaoVl.BanTiepNhan, objThongBaoVl.GhiChu, objThongBaoVl.TrangThaiThongBao);
        //cap nhat so thang da huong
        DataTable tblSoThangDaHuongBHXH = new ThongBaoViecLamHangThang().GetByID(itemId, 0, 14);
        DataTable tblSoThangKhongHuong = new ThongBaoViecLamHangThang().GetByID(itemId, 0, 15);
        int SoThangDaHuong = tblSoThangDaHuongBHXH.Rows.Count;
        int SoThangKhongHuong = tblSoThangKhongHuong.Rows.Count;
        new TinhHuong().UpdateSoThangDaHuong(itemId, tblSoThangDaHuongBHXH.Rows.Count);
        // cap nhat so thang con lai       
        DataTable tblTinhHuong = new TinhHuong().getDataById(itemId);
        int SoThangDuocHuongConLai = (int)tblTinhHuong.Rows[0]["SoThangHuongBHXH"] - (SoThangDaHuong + SoThangKhongHuong);
        new TinhHuong().UpdateSoThangDuocHuongConLai(itemId, SoThangDuocHuongConLai);
        _msg = "Cập nhật thành công";    
    }

    protected void btnThoat_Click(object sender, EventArgs e)
    {
        Response.Redirect("DanhSachThongBaoVL.aspx");
    }
}