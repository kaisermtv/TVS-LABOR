using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Labor_TuVanXuatKhauEdit : System.Web.UI.Page
{
    #region declare objects
    private int itemId = 0, IDNldPhuHuynh = 0;
    private Account objAccount = new Account();
    private XuatKhauLaoDong objXuatKhauLaoDong = new XuatKhauLaoDong();
    private NguoiLaoDong objNguoiLaoDong = new NguoiLaoDong();
    private KetQuaTuVan objKetQuaTuVan = new KetQuaTuVan();
    private KetQuaHoSo objKetQuaHoSo = new KetQuaHoSo();
    private NgoaiNgu objNgoaiNgu = new NgoaiNgu();
    private CanBo objCanBo = new CanBo();
    private DataTable objTable = new DataTable();
    private bool View = false, Add = false, Edit = false, Del = false, Orther = false, DuHoc = false;
    public string strHtmlDuHoc = "";
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ACCOUNT"] == null)
        {
            Response.Redirect("../Login.aspx");
        }
        Session["TITLE"] = "CẬP NHẬT HỒ SƠ TƯ VẤN XUẤT KHẨU";
        try
        {
            this.itemId = int.Parse(Request["id"].ToString());
        }
        catch
        {
            this.itemId = 0;
        }

        this.txtIDNldXuatKhau.Value = this.itemId.ToString();

        if (!Page.IsPostBack)
        {
            this.ddlIDCanbo.DataSource = this.objCanBo.getDataCategoryToCombobox();
            this.ddlIDCanbo.DataTextField = "NameCanBo";
            this.ddlIDCanbo.DataValueField = "IDCanBo";
            this.ddlIDCanbo.DataBind();

            this.ddlIDKetQuaTuVan.DataSource = this.objKetQuaTuVan.getDataCategoryToCombobox();
            this.ddlIDKetQuaTuVan.DataTextField = "NameKetQuaTuVan";
            this.ddlIDKetQuaTuVan.DataValueField = "IDKetQuaTuVan";
            this.ddlIDKetQuaTuVan.DataBind();

            this.ddlIDKetQuaHoSo.DataSource = this.objKetQuaHoSo.getDataCategoryToCombobox();
            this.ddlIDKetQuaHoSo.DataTextField = "NameKetQuaHoSo";
            this.ddlIDKetQuaHoSo.DataValueField = "IDKetQuaHoSo";
            this.ddlIDKetQuaHoSo.DataBind();

            this.ddlIDDaoTaoMonHoc.DataSource = this.objNgoaiNgu.getDataCategoryToCombobox();
            this.ddlIDDaoTaoMonHoc.DataTextField = "NameNgoaiNgu";
            this.ddlIDDaoTaoMonHoc.DataValueField = "IDNgoaiNgu";
            this.ddlIDDaoTaoMonHoc.DataBind();
        }

        if (!Page.IsPostBack && this.itemId > 0)
        {
            this.objTable = this.objXuatKhauLaoDong.getDataById(this.itemId);
            if (this.objTable.Rows.Count > 0)
            {
                #region Thong tin don vi
                this.txtIDDonViTuyenDung.Value = this.objTable.Rows[0]["IDDonViTuyenDung"].ToString();
                this.txtDonViTuyenDungName.Text = this.objTable.Rows[0]["TenDonVi"].ToString();
                this.txtNguoiDaiDien.Text = this.objTable.Rows[0]["NguoiDaiDien"].ToString();
                this.txtChucVu.Text = this.objTable.Rows[0]["ChucVu"].ToString();
                this.txtDiaChi.Text = this.objTable.Rows[0]["DiaChi"].ToString();
                this.txtDienThoai.Text = this.objTable.Rows[0]["DienThoai"].ToString();
                this.DuHoc = bool.Parse(this.objTable.Rows[0]["DuHoc"].ToString());
                if (this.DuHoc)
                {
                    this.strHtmlDuHoc = "Du học";
                    this.linkThongTinPhuHuynh.Disabled = false;
                    this.linkThongTinPhuHuynh.HRef = "#menu1";
                }
                else
                {
                    this.strHtmlDuHoc = "Xuất khẩu lao động";
                    this.linkThongTinPhuHuynh.Disabled = true;
                    this.linkThongTinPhuHuynh.HRef = "#";
                }
                #endregion

                #region Thong tin nguoi lao dong
                this.txtIDNldDangKy.Value = this.objTable.Rows[0]["IDNldDangKy"].ToString();
                this.txtNameNldDangKy.Text = this.objTable.Rows[0]["HoVaTen"].ToString();
                if (this.objTable.Rows[0]["NgaySinh"].ToString() != "")
                {
                    this.txtNgaySinh.Text = TVSSystem.CVDate(this.objTable.Rows[0]["NgaySinh"].ToString()).ToString("dd/MM/yyyy");
                }
                this.txtGioiTinh.Text = this.objTable.Rows[0]["IDGioiTinh"].ToString().Replace("1","Nam").Replace("2","Nữ");
                this.txtNLDDiaChi.Text = this.objTable.Rows[0]["NLDDiaChi"].ToString();
                this.txtCMND.Text = this.objTable.Rows[0]["CMND"].ToString();
                this.txtNLDDienThoai.Text = this.objTable.Rows[0]["NLDDienThoai"].ToString();
                //this.txtTrinhDoVanHoa.Text = this.objTable.Rows[0]["NameTrinhDoVanHoa"].ToString();
                #endregion

                #region Thong tin phu huynh hoc sinh
                DataTable objTmpTable = new DataTable();
                objTmpTable = this.objNguoiLaoDong.getDataNldPhuHuynhByIDNldXuatKhau(this.itemId);
                if (objTmpTable.Rows.Count > 0)
                {
                    this.txtHoTenBo.Text = objTmpTable.Rows[0]["HoTenBo"].ToString();
                    if (objTmpTable.Rows[0]["NgaySinhBo"].ToString().Trim() != "")
                    {
                        this.txtNgaySinhBo.Value = objTmpTable.Rows[0]["NgaySinhBo"].ToString();
                    }

                    this.txtDiaChiBo.Text = objTmpTable.Rows[0]["DiaChiBo"].ToString();
                    this.txtDienThoaiBo.Text = objTmpTable.Rows[0]["DienThoaiBo"].ToString();
                    this.txtDonViBo.Text = objTmpTable.Rows[0]["DonViBo"].ToString();
                    this.txtChucVuBo.Text = objTmpTable.Rows[0]["ChucVuBo"].ToString();
                    this.txtDiaChiDonViBo.Text = objTmpTable.Rows[0]["DiaChiDonViBo"].ToString();
                    this.txtThuNhapThangBo.Text = objTmpTable.Rows[0]["ThuNhapThangBo"].ToString();
                    this.txtSoTietKiemBo.Text = objTmpTable.Rows[0]["SoTietKiemBo"].ToString();

                    this.txtHoTenMe.Text = objTmpTable.Rows[0]["HoTenMe"].ToString();
                    if (objTmpTable.Rows[0]["NgaySinhMe"].ToString().Trim() != "")
                    {
                        this.txtNgaySinhMe.Value = objTmpTable.Rows[0]["NgaySinhMe"].ToString();
                    }

                    this.txtDiaChiMe.Text = objTmpTable.Rows[0]["DiaChiMe"].ToString();
                    this.txtDienThoaiMe.Text = objTmpTable.Rows[0]["DienThoaiMe"].ToString();
                    this.txtDonViMe.Text = objTmpTable.Rows[0]["DonViMe"].ToString();
                    this.txtChucVuMe.Text = objTmpTable.Rows[0]["ChucVuMe"].ToString();
                    this.txtDiaChiDonViMe.Text = objTmpTable.Rows[0]["DiaChiDonViMe"].ToString();
                    this.txtThuNhapThangMe.Text = objTmpTable.Rows[0]["ThuNhapThangMe"].ToString();
                    this.txtSoTietKiemMe.Text = objTmpTable.Rows[0]["SoTietKiemMe"].ToString();
                    
                }
                #endregion

                #region Thong tin tinh trang ho so

                if (this.objTable.Rows[0]["NgayDangKyTuVan"].ToString() != "")
                {
                    this.txtNgayDangKyTuVan.Value = TVSSystem.CVDate(this.objTable.Rows[0]["NgayDangKyTuVan"].ToString()).ToString();
                }

                this.txtDiaDiem.Text = this.objTable.Rows[0]["DiaDiem"].ToString();
                this.ddlIDCanbo.SelectedValue = this.objTable.Rows[0]["IDCanBo"].ToString();
                this.ddlIDKetQuaTuVan.SelectedValue = this.objTable.Rows[0]["IDKetQuaTuVan"].ToString();
                this.txtNguoiXuLy.Text = this.objTable.Rows[0]["NguoiXuLy"].ToString();
                if (this.objTable.Rows[0]["NgayCocTien"].ToString() != "")
                {
                    this.txtNgayCocTien.Value = TVSSystem.CVDate(this.objTable.Rows[0]["NgayCocTien"].ToString()).ToString();
                }
                this.ddlIDDaoTaoMonHoc.SelectedValue = this.objTable.Rows[0]["IDDaoTaoMonHoc"].ToString();
                this.txtNoiDaoTao.Text = this.objTable.Rows[0]["NoiDaoTao"].ToString();
                if (this.objTable.Rows[0]["NgayBatDau"].ToString() != "")
                {
                    this.txtNgayBatDau.Value = TVSSystem.CVDate(this.objTable.Rows[0]["NgayBatDau"].ToString()).ToString();
                }
                if (this.objTable.Rows[0]["NgayKetThuc"].ToString() != "")
                {
                    this.txtNgayKetThuc.Value = TVSSystem.CVDate(this.objTable.Rows[0]["NgayKetThuc"].ToString()).ToString();
                }
                if (this.objTable.Rows[0]["NgayXuatCanhDuKien"].ToString() != "")
                {
                    this.txtNgayXuatCanhDuKien.Value = TVSSystem.CVDate(this.objTable.Rows[0]["NgayXuatCanhDuKien"].ToString()).ToString();
                }
                if (this.objTable.Rows[0]["NgayViSa"].ToString() != "")
                {
                    this.txtNgayViSa.Value = TVSSystem.CVDate(this.objTable.Rows[0]["NgayViSa"].ToString()).ToString();
                }
                if (this.objTable.Rows[0]["NgayXuatCanh"].ToString() != "")
                {
                    this.txtNgayXuatCanh.Value = TVSSystem.CVDate(this.objTable.Rows[0]["NgayXuatCanh"].ToString()).ToString();
                }
                if (this.objTable.Rows[0]["NgayVe"].ToString() != "")
                {
                    this.txtNgayVe.Value = TVSSystem.CVDate(this.objTable.Rows[0]["NgayVe"].ToString()).ToString();
                }
                this.txtNoiDungKhac.Text = this.objTable.Rows[0]["NoiDungKhac"].ToString();
                this.txtNguoiGioiThieu.Text = this.objTable.Rows[0]["NguoiGioiThieu"].ToString();
                this.ddlIDKetQuaHoSo.SelectedValue = this.objTable.Rows[0]["IDKetQuaHoSo"].ToString();

                this.ddlState.SelectedValue = this.objTable.Rows[0]["State"].ToString();

                #endregion
            }
        }
        this.txtDonViTuyenDungName.Focus();

    } 
    #endregion

    #region method btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        this.lblMsg.Text = "";

        if (this.txtIDDonViTuyenDung.Value.ToString().Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa chọn đơn vị tuyển dụng";
            this.txtIDDonViTuyenDung.Focus();
            return;
        }

        if (this.txtIDNldDangKy.Value.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa chọn người lao động";
            this.txtIDNldDangKy.Focus();
            return;
        }

        if (this.txtNgayDangKyTuVan.Value.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập ngày đăng ký tư vấn";
            this.txtNgayDangKyTuVan.Focus();
            return;
        }

        DateTime? NgayDatCoc;
        try
        {
            NgayDatCoc = TVSSystem.CVDate(this.txtNgayCocTien.Value.Trim());
        }
        catch
        {
            NgayDatCoc = null;
        }

        DateTime? NgayBatDau;
        try
        {
            NgayBatDau = TVSSystem.CVDate(this.txtNgayBatDau.Value.Trim());
        }
        catch
        {
            NgayBatDau = null;
        }

        DateTime? NgayKetThuc;
        try
        {
            NgayKetThuc = TVSSystem.CVDate(this.txtNgayKetThuc.Value.Trim());
        }
        catch
        {
            NgayKetThuc = null;
        }

        DateTime? NgayXuatCanhDuKien;
        try
        {
            NgayXuatCanhDuKien = TVSSystem.CVDate(this.txtNgayXuatCanhDuKien.Value.Trim());
        }
        catch
        {
            NgayXuatCanhDuKien = null;
        }

        DateTime? NgayViSa;
        try
        {
            NgayViSa = TVSSystem.CVDate(this.txtNgayViSa.Value.Trim());
        }
        catch
        {
            NgayViSa = null;
        }

        DateTime? NgayXuatCanh;
        try
        {
            NgayXuatCanh = TVSSystem.CVDate(this.txtNgayXuatCanh.Value.Trim());
        }
        catch
        {
            NgayXuatCanh = null;
        }

        DateTime? NgayVe;
        try
        {
            NgayVe = TVSSystem.CVDate(this.txtNgayVe.Value.Trim());
        }
        catch
        {
            NgayVe = null;
        }

        if (this.objXuatKhauLaoDong.setData(ref this.itemId, int.Parse(this.txtIDNldDangKy.Value.Trim()), int.Parse(this.txtIDDonViTuyenDung.Value.Trim()), this.txtNguoiDaiDien.Text, TVSSystem.CVDate(this.txtNgayDangKyTuVan.Value.Trim()), this.txtDiaDiem.Text, int.Parse(this.ddlIDCanbo.SelectedValue.ToString()), int.Parse(this.ddlIDKetQuaTuVan.SelectedValue.ToString()), NgayDatCoc, 0, 0, this.txtNguoiXuLy.Text, int.Parse(this.ddlIDDaoTaoMonHoc.SelectedValue.ToString()), this.txtNoiDaoTao.Text, NgayBatDau, NgayKetThuc, "", NgayXuatCanhDuKien, NgayViSa, NgayXuatCanh, NgayVe, this.txtNguoiGioiThieu.Text, int.Parse(this.ddlIDKetQuaHoSo.SelectedValue.ToString()), this.txtNoiDungKhac.Text, int.Parse(this.ddlState.SelectedValue.ToString())) == 1)
        {
            this.objTable = this.objXuatKhauLaoDong.getDataById(this.itemId);
            if (this.objTable.Rows.Count > 0)
            {
                this.DuHoc = bool.Parse(this.objTable.Rows[0]["DuHoc"].ToString());
                if (this.DuHoc)
                {
                    this.strHtmlDuHoc = "Du học";
                }
                else
                {
                    this.strHtmlDuHoc = "Xuất khẩu lao động";
                }
            }
            if (this.itemId > 0 && int.Parse(this.txtIDNldDangKy.Value.Trim()) > 0 && this.DuHoc)
            {
                DateTime? NgaySinhBo;
                try
                {
                    NgaySinhBo = TVSSystem.CVDate(this.txtNgaySinhBo.Value.Trim());
                }
                catch
                {
                    NgaySinhBo = null;
                }

                DateTime? NgaySinhMe;
                try
                {
                    NgaySinhMe = TVSSystem.CVDate(this.txtNgaySinhMe.Value.Trim());
                }
                catch
                {
                    NgaySinhMe = null;
                }

                float tmpThuNhapCuaBo = 0;
                if (this.txtThuNhapThangBo.Text.Trim() != "")
                {
                    try
                    {
                        tmpThuNhapCuaBo = float.Parse(this.txtThuNhapThangBo.Text);
                    }
                    catch
                    {
                        tmpThuNhapCuaBo = 0;
                    }
                }
                else
                {
                    tmpThuNhapCuaBo = 0;
                }

                float tmpThuNhapCuaMe = 0;
                if (this.txtThuNhapThangMe.Text.Trim() != "")
                {
                    try
                    {
                        tmpThuNhapCuaMe = float.Parse(this.txtThuNhapThangMe.Text);
                    }
                    catch
                    {
                        tmpThuNhapCuaMe = 0;
                    }
                }
                else
                {
                    tmpThuNhapCuaMe = 0;
                }

                DataTable objTmpTable = new DataTable();
                objTmpTable = this.objNguoiLaoDong.getDataNldPhuHuynhByIDNldXuatKhau(this.itemId);
                    if (objTmpTable.Rows.Count > 0)
                    {
                        this.IDNldPhuHuynh = int.Parse(objTmpTable.Rows[0]["IDNldPhuHuynh"].ToString());
                        
                    }
                    else
                    {
                        this.IDNldPhuHuynh = 0;
                    }
                    this.objNguoiLaoDong.setDataNldPhuHuynh(ref this.IDNldPhuHuynh, this.itemId, int.Parse(this.txtIDNldDangKy.Value.Trim()),
                                this.txtHoTenBo.Text, NgaySinhBo, this.txtDiaChiBo.Text, this.txtDienThoaiBo.Text, this.txtDonViBo.Text, this.txtChucVuBo.Text, this.txtDiaChiDonViBo.Text, tmpThuNhapCuaBo, this.txtSoTietKiemBo.Text,
                                this.txtHoTenMe.Text, NgaySinhMe, this.txtDiaChiMe.Text, this.txtDienThoaiMe.Text, this.txtDonViMe.Text, this.txtChucVuMe.Text, this.txtDiaChiDonViMe.Text, tmpThuNhapCuaMe, this.txtSoTietKiemMe.Text);
            }

            Response.Redirect("TuVanXuatKhau.aspx?id=" + this.itemId);
        }
        else
        {
            this.lblMsg.Text = "Lỗi xảy ra khi cập nhật thông tin.";
        }
    }
    #endregion

    #region method btnCancel_Click
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("TuVanXuatKhau.aspx");
    }
    #endregion
}