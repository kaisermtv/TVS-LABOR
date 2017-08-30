using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BHTN_NhapThongTinHoSo : System.Web.UI.Page
{
    #region declare
    private NguoiLaoDong objNguoiLaoDong = new NguoiLaoDong();
    private DoanhNghiep objDoanhNghiep = new DoanhNghiep();
    private NLDTroCapThatNghiep objNLDTroCapThatNghiep = new NLDTroCapThatNghiep();
    private TonGiao objTonGiao = new TonGiao();
    private DanToc objDanToc = new DanToc();
    private TrinhDoPhoThong objTrinhDoPhoThong = new TrinhDoPhoThong();
    private DanhMuc objDanhMuc = new DanhMuc();
    private Account objAccount = new Account();

    private Provincer objProvincer = new Provincer();
    private District objDistrict = new District();
    private Ward objWard = new Ward();

    private LoaiHinh objLoaiHinh = new LoaiHinh();
    private Business objBusiness = new Business();

    public int itemId = 0;
    public string _msg = "";
    private DataRow objDataTroCap;
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
        Session["TITLE"] = "Đăng ký hồ sơ".ToUpper();

        try
        {
            this.itemId = int.Parse(Request["id"].ToString());
        }
        catch
        {
            this.itemId = 0;
            //Response.Redirect("DangKyHoSo.aspx");
        }

        if (itemId != 0)
        {
            objDataTroCap = objNLDTroCapThatNghiep.getItem(itemId);

            if (objDataTroCap == null) Response.Redirect("DangKyHoSo.aspx");
            int tt = 0;
            try
            {
                tt = (int)objDataTroCap["IdTrangThai"];
            }
            catch { }
            if (tt != 0 && tt != 1) Response.Redirect("DangKyHoSo.aspx");
        }

        #region Khởi tạo select
        if (!Page.IsPostBack)
        {
            txtNgayHoanThanh.Value = DateTime.Now.ToString("dd/MM/yyyy");

            ddlNguoiNhan.DataSource = objAccount.getDataCategoryToCombobox();
            ddlNguoiNhan.DataTextField = "FullName";
            ddlNguoiNhan.DataValueField = "Id";
            ddlNguoiNhan.DataBind();
            ddlNguoiNhan.SelectedValue = "0";

            this.ddlIdNganhNgheDN.DataSource = this.objBusiness.getDataCategoryToCombobox();
            this.ddlIdNganhNgheDN.DataTextField = "Name";
            this.ddlIdNganhNgheDN.DataValueField = "Id";
            this.ddlIdNganhNgheDN.DataBind();
            ddlIdNganhNgheDN.SelectedValue = "0";

            this.ddlLoaiHinhDN.DataSource = this.objLoaiHinh.getDataCategoryToCombobox();
            this.ddlLoaiHinhDN.DataTextField = "NameLoaiHinh";
            this.ddlLoaiHinhDN.DataValueField = "IdLoaiHinh";
            this.ddlLoaiHinhDN.DataBind();

            ddlLoaiHinhDN.SelectedValue = "0";


            ddlNoiCap.DataSource = objDanhMuc.getDataCategoryToCombobox("--Nơi cấp CMND--", TVSSystem.NoiCapCMND);
            ddlNoiCap.DataTextField = "NameDanhMuc";
            ddlNoiCap.DataValueField = "IdDanhMuc";
            ddlNoiCap.DataBind();
            ddlNoiCap.SelectedValue = "0";

           // ddlNoiChotSoCuoi.DataSource = objDanhMuc.getDataCategoryToCombobox("--Nơi chốt sổ cuối--", TVSSystem.NoiChotSoCuoi);
            //code The linh sua loi 31/7/2017
            ddlNoiChotSoCuoi.DataSource = objDanhMuc.getDataCategoryToCombobox("--Nơi chốt sổ cuối--",72);
            ddlNoiChotSoCuoi.DataTextField = "NameDanhMuc";
            ddlNoiChotSoCuoi.DataValueField = "IdDanhMuc";
            ddlNoiChotSoCuoi.DataBind();
            ddlNoiChotSoCuoi.SelectedValue = "0";

            //ddlNoiCapBHXH.DataSource = objDanhMuc.getDataCategoryToCombobox("--Nơi Cấp BHXH--", TVSSystem.NoiChotSoCuoi);
            // code The Linh sua loi 31/7/2017
            ddlNoiCapBHXH.DataSource = objDanhMuc.getDataCategoryToCombobox("--Nơi Cấp BHXH--", 11);
            ddlNoiCapBHXH.DataTextField = "NameDanhMuc";
            ddlNoiCapBHXH.DataValueField = "IdDanhMuc";
            ddlNoiCapBHXH.DataBind();
            ddlNoiCapBHXH.SelectedValue = "0";

            //ddlNoiKhamBenh.DataSource = objDanhMuc.getDataCategoryToCombobox("--Nơi ĐK khám bệnh--", TVSSystem.NoiDangKyKhamBenh);
            //code The linh sua loi 31/7/2017
            ddlNoiKhamBenh.DataSource = objDanhMuc.getDataCategoryToCombobox("--Nơi ĐK khám bệnh--",15);
            ddlNoiKhamBenh.DataTextField = "NameDanhMuc";
            ddlNoiKhamBenh.DataValueField = "IdDanhMuc";
            ddlNoiKhamBenh.DataBind();
            ddlNoiKhamBenh.SelectedValue = "0";

            //ddlNoiNhanTCTN.DataSource = objDanhMuc.getDataCategoryToCombobox("--Nơi nhận TCTN--", TVSSystem.NoiDangKyKhamBenh);
            //code The linh sua loi 31/7/2017
            ddlNoiNhanTCTN.DataSource = objDanhMuc.getDataCategoryToCombobox("--Nơi nhận TCTN--", 71);
            ddlNoiNhanTCTN.DataTextField = "NameDanhMuc";
            ddlNoiNhanTCTN.DataValueField = "IdDanhMuc";
            ddlNoiNhanTCTN.DataBind();
            ddlNoiNhanTCTN.SelectedValue = "0";

            //ddlGiayToKemtheo.DataSource = objDanhMuc.getDataCategoryToCombobox("--Giấy tờ kèm theo--", TVSSystem.NoiDangKyKhamBenh);
            //code The linh sua loi 31/7/2017
            ddlGiayToKemtheo.DataSource = objDanhMuc.getDataCategoryToCombobox("--Giấy tờ kèm theo--",70);
            ddlGiayToKemtheo.DataTextField = "NameDanhMuc";
            ddlGiayToKemtheo.DataValueField = "IdDanhMuc";
            ddlGiayToKemtheo.DataBind();
            ddlGiayToKemtheo.SelectedValue = "0";
            //code The linh sua loi 9/8/2017
            ddlNganHang.DataSource = objDanhMuc.getDataCategoryToCombobox("--Ngân hàng--",82);
            ddlNganHang.DataTextField = "NameDanhMuc";
            ddlNganHang.DataValueField = "IdDanhMuc";
            ddlNganHang.DataBind();
            ddlNganHang.SelectedValue = "0";
            //code The linh sua loi 11/8/2017 bổ sung nới nhận BHXH           
            ddlNoiNhan.DataSource = objDanhMuc.getDataCategoryToCombobox("--Nơi nhận--", 13);
            ddlNoiNhan.DataTextField = "NameDanhMuc";
            ddlNoiNhan.DataValueField = "IdDanhMuc";
            ddlNoiNhan.DataBind();
            ddlNoiNhan.SelectedValue = "0";

            //ddlLoaiHopDong.DataSource = objDanhMuc.getDataCategoryToCombobox("--Chọn loại hợp đồng--", TVSSystem.NoiDangKyKhamBenh);
            //code The linh sua loi 31/7/2017
            DataTable tblLoaiHopDong = new LoaiHopDong().getData("");
            DataRow row = tblLoaiHopDong.NewRow();
            row["NameLoaiHopDong"] = "--Loại hợp đồng--";
            row["IdLoaiHopDong"] = 0;
            tblLoaiHopDong.Rows.InsertAt(row, 0);
            ddlLoaiHopDong.DataTextField = "NameLoaiHopDong";
            ddlLoaiHopDong.DataValueField = "IdLoaiHopDong";
            ddlLoaiHopDong.DataSource = tblLoaiHopDong;
            ddlLoaiHopDong.DataBind();     

            this.ddlDanToc.DataSource = this.objDanToc.getDataCategoryToCombobox();
            this.ddlDanToc.DataTextField = "NameDanToc";
            this.ddlDanToc.DataValueField = "IDDanToc";
            this.ddlDanToc.SelectedIndex = 0;
            this.ddlDanToc.DataBind();

            this.ddlTonGiao.DataSource = this.objTonGiao.getDataCategoryToCombobox();
            this.ddlTonGiao.DataTextField = "NameTonGiao";
            this.ddlTonGiao.DataValueField = "IDTonGiao";
            this.ddlTonGiao.DataBind();
            ddlTonGiao.SelectedValue = "0";



            #region Tinh thành
            // ******************* Tỉnh thành ****************************

            DataTable objTinhThanhData = this.objProvincer.getDataCategoryToCombobox();
            this.ddlTinh_TT.DataSource = objTinhThanhData.DefaultView;
            this.ddlTinh_TT.DataTextField = "Name";
            this.ddlTinh_TT.DataValueField = "Id";
            this.ddlTinh_TT.SelectedValue = "40";
            this.ddlTinh_TT.DataBind();

            this.ddlTinh_DC.DataSource = objTinhThanhData.DefaultView;
            this.ddlTinh_DC.DataTextField = "Name";
            this.ddlTinh_DC.DataValueField = "Id";
            this.ddlTinh_DC.SelectedValue = "40";
            this.ddlTinh_DC.DataBind();

            // ############################################################
            //ddlTinh_TT_SelectedIndexChanged(null,null);

            #endregion

        }
        #endregion


        if (!Page.IsPostBack)
        {
            if (objDataTroCap != null)
            {
                #region tải dữ liệu bảng rợ cấp
                try
                {
                    txtNgayNghiViec.Value = ((DateTime)objDataTroCap["NgayNghiViec"]).ToString("dd/MM/yyyy");
                }
                catch { }
                txtSoThangDongBHXH.Text = objDataTroCap["SoThangDongBHXH"].ToString();

                try
                {
                    txtNgayNopHS.Value = ((DateTime)objDataTroCap["NgayNopHoSo"]).ToString("dd/MM/yyyy");
                }
                catch { }

                try
                {
                    txtHanHoanThien.Value = ((DateTime)objDataTroCap["HanHoanThien"]).ToString("dd/MM/yyyy");
                }
                catch { }


                //ddlNoiNhanbaoHiem.SelectedValue = objDataTroCap["NoiNhanBaoHiem"].ToString();

                int htnt = (int)objDataTroCap["IdHinhThucNhanTien"];
                cbkATM.Checked = (htnt == 1);
                cbkTienMat.Checked = (htnt == 2);

                ddlNoiChotSoCuoi.SelectedValue = objDataTroCap["IdNoiChotSoCuoi"].ToString();

                ddlNguoiNhan.SelectedValue = objDataTroCap["IdNguoiNhan"].ToString();
                #endregion
                LoadDataNLD((int)objDataTroCap["IDNguoiLaoDong"]);
                #region thông tin NLD
                /*
                DataTable objData = objNguoiLaoDong.getDataById((int)objDataTroCap["IDNguoiLaoDong"]);
                if (objData.Rows.Count > 0)
                {
                    DataRow objDataRow = objData.Rows[0];
                    txtHoVaTen.Text = objDataRow["HoVaTen"].ToString();
                    try
                    {
                        txtNgaySinh.Value = ((DateTime)objDataRow["NgaySinh"]).ToString("dd/MM/yyyy");
                    }
                    catch { }

                    int gioitinh = (int)objDataRow["IDGioiTinh"];
                    if (gioitinh == 1) chkGioiTinhNam.Checked = true;
                    else if (gioitinh == 2) chkGioiTinhNu.Checked = true;

                    txtCMND.Text = objDataRow["CMND"].ToString();
                    try
                    {
                        txtNgayCap.Value = ((DateTime)objDataRow["NgayCapCMND"]).ToString("dd/MM/yyyy");
                    }
                    catch { }
                    ddlNoiCap.SelectedValue = objDataRow["NoiCap"].ToString();

                    txtSoDienThoai.Text = objDataRow["DienThoai"].ToString();
                    //txtNoiThuongTru.Text = objDataRow["NoiThuongTru"].ToString();

                    txtSoTaiKhoan.Text = objDataRow["TaiKhoan"].ToString();
                    ddlNganHang.SelectedValue = objDataRow["IDNganHang"].ToString();
                    txtMaSoThue.Text = objDataRow["MaSoThue"].ToString();
                    txtEmail.Text = objDataRow["Email"].ToString();

                    txtBHXH.Text = objDataRow["BHXH"].ToString();
                    try
                    {
                        txtNgayCapBHXH.Value = ((DateTime)objDataRow["NgayCapBHXH"]).ToString("dd/MM/yyyy");
                    }
                    catch { }
                    ddlNoiCapBHXH.SelectedValue = objDataRow["NoiCapBHXH"].ToString();

                    ddlNoiKhamBenh.SelectedValue = objDataRow["NoiDangKyKhamBenh"].ToString();
                    //ddlTDCM.SelectedValue = objDataRow["TrinhDoChuyenMon"].ToString();
                    //ddlLinhVucDT.SelectedValue = objDataRow["LinhVucDaoTao"].ToString();
                    txtCongViecDaLam.Text = objDataRow["CongViecDaLam"].ToString();

                    #region noi cu tru
                    this.txtXom_TT.Text = objDataRow["Xom_TT"].ToString();
                    this.txtXom_DC.Text = objDataRow["Xom_DC"].ToString();
                    // ****************** chọn tỉnh ******************
                    for (int i = 0; i < this.ddlTinh_TT.Items.Count; i++)
                    {
                        if (this.ddlTinh_TT.Items[i].Text == objDataRow["Tinh_TT"].ToString())
                        {
                            this.ddlTinh_TT.SelectedIndex = i;
                            break;
                        }
                    }

                    for (int i = 0; i < this.ddlTinh_DC.Items.Count; i++)
                    {
                        if (this.ddlTinh_DC.Items[i].Text == objDataRow["Tinh_DC"].ToString())
                        {
                            this.ddlTinh_DC.SelectedIndex = i;
                            break;
                        }
                    }

                    // ****************** chọn huyện ******************
                    if (this.ddlTinh_TT.Items.Count > 0)
                    {
                        this.ddlHuyen_TT.DataSource = this.objDistrict.getDataCategoryToCombobox(this.ddlTinh_TT.SelectedValue.ToString());
                        this.ddlHuyen_TT.DataTextField = "Name";
                        this.ddlHuyen_TT.DataValueField = "Id";
                        this.ddlHuyen_TT.DataBind();
                    }

                    if (this.ddlTinh_DC.Items.Count > 0)
                    {
                        this.ddlHuyen_DC.DataSource = this.objDistrict.getDataCategoryToCombobox(this.ddlTinh_DC.SelectedValue.ToString());
                        this.ddlHuyen_DC.DataTextField = "Name";
                        this.ddlHuyen_DC.DataValueField = "Id";
                        this.ddlHuyen_DC.DataBind();
                    }


                    for (int i = 0; i < this.ddlHuyen_TT.Items.Count; i++)
                    {
                        if (this.ddlHuyen_TT.Items[i].Text == objDataRow["Huyen_TT"].ToString())
                        {
                            this.ddlHuyen_TT.SelectedIndex = i;
                            break;
                        }
                    }

                    for (int i = 0; i < this.ddlHuyen_DC.Items.Count; i++)
                    {
                        if (this.ddlHuyen_DC.Items[i].Text == objDataRow["Huyen_DC"].ToString())
                        {
                            this.ddlHuyen_DC.SelectedIndex = i;
                            break;
                        }
                    }

                    // ****************** chọn xã ******************
                    if (this.ddlHuyen_TT.Items.Count > 0)
                    {
                        this.ddlXa_TT.DataSource = this.objWard.getDataCategoryToCombobox(this.ddlTinh_TT.SelectedValue.ToString(), this.ddlHuyen_TT.SelectedValue.ToString());
                        this.ddlXa_TT.DataTextField = "Name";
                        this.ddlXa_TT.DataValueField = "Id";
                        this.ddlXa_TT.DataBind();
                    }

                    if (this.ddlHuyen_DC.Items.Count > 0)
                    {
                        this.ddlXa_DC.DataSource = this.objWard.getDataCategoryToCombobox(this.ddlTinh_DC.SelectedValue.ToString(), this.ddlHuyen_DC.SelectedValue.ToString());
                        this.ddlXa_DC.DataTextField = "Name";
                        this.ddlXa_DC.DataValueField = "Id";
                        this.ddlXa_DC.DataBind();
                    }

                    for (int i = 0; i < this.ddlXa_TT.Items.Count; i++)
                    {
                        if (this.ddlXa_TT.Items[i].Text == objDataRow["Xa_TT"].ToString())
                        {
                            this.ddlXa_TT.SelectedIndex = i;
                            break;
                        }
                    }

                    for (int i = 0; i < this.ddlXa_DC.Items.Count; i++)
                    {
                        if (this.ddlXa_DC.Items[i].Text == objDataRow["Xa_DC"].ToString())
                        {
                            this.ddlXa_DC.SelectedIndex = i;
                            break;
                        }
                    }
                    //////////////////////////////////////////////////////
                    #endregion


                }
                // */
                #endregion
                LoadDataTCTN(itemId);
                #region tải thông tin doanh nghiệp
                //*
                int idDonVi = 0;
                try
                {
                    idDonVi = (int)objDataTroCap["IdQuaTrinhCongTacGanNhat"];
                }
                catch { }

                if (idDonVi != 0)
                {
                    DataTable objDataDN = objDoanhNghiep.getDataById(idDonVi);
                    if (objDataDN.Rows.Count > 0)
                    {
                        DataRow objDataRowDN = objDataDN.Rows[0];
                        txtIDDonVi.Value = objDataRowDN["IDDonVi"].ToString();
                        txtTenDonVi.Text = objDataRowDN["TenDonVi"].ToString();
                        txtDiaChiDN.Text = objDataRowDN["DiaChi"].ToString();
                        txtPhoneDN.Text = objDataRowDN["DienThoaiDonVi"].ToString();
                        txtFaxDN.Text = objDataRowDN["FaxDonVi"].ToString();
                        txtSoDKKD.Text = objDataRowDN["SoDKKD"].ToString();
                        ddlLoaiHinhDN.SelectedValue = objDataRowDN["IdLoaiHinh"].ToString();
                        ddlIdNganhNgheDN.SelectedValue = objDataRowDN["IDNganhNghe"].ToString();
                        txtEmailDN.Text = objDataRowDN["EmailDonVi"].ToString();
                        txtWebsiteDN.Text = objDataRowDN["Website"].ToString();
                        btnXoaDonVi.Disabled = false;

                    }
                }
                // */
                #endregion

               
            }
            else
            {
                txtNgayNopHS.Value = DateTime.Now.ToString("dd/MM/yyyy");
                #region quan Huyen
                if (this.ddlTinh_TT.Items.Count > 0)
                {
                    this.ddlHuyen_TT.DataSource = this.objDistrict.getDataCategoryToCombobox(this.ddlTinh_TT.SelectedValue.ToString());
                    this.ddlHuyen_TT.DataTextField = "Name";
                    this.ddlHuyen_TT.DataValueField = "Id";
                    this.ddlHuyen_TT.DataBind();
                }

                if (this.ddlHuyen_TT.Items.Count > 0)
                {
                    this.ddlXa_TT.DataSource = this.objWard.getDataCategoryToCombobox(this.ddlTinh_TT.SelectedValue.ToString(), this.ddlHuyen_TT.SelectedValue.ToString());
                    this.ddlXa_TT.DataTextField = "Name";
                    this.ddlXa_TT.DataValueField = "Id";
                    ddlXa_TT.SelectedValue = "0";
                    this.ddlXa_TT.DataBind();
                }

                //ddlTinh_DC_SelectedIndexChanged(null,null);

                if (this.ddlTinh_DC.Items.Count > 0)
                {
                    this.ddlHuyen_DC.DataSource = this.objDistrict.getDataCategoryToCombobox(this.ddlTinh_DC.SelectedValue.ToString());
                    this.ddlHuyen_DC.DataTextField = "Name";
                    this.ddlHuyen_DC.DataValueField = "Id";
                    this.ddlHuyen_DC.DataBind();
                }

                if (this.ddlHuyen_DC.Items.Count > 0)
                {
                    this.ddlXa_DC.DataSource = this.objWard.getDataCategoryToCombobox(this.ddlTinh_DC.SelectedValue.ToString(), this.ddlHuyen_DC.SelectedValue.ToString());
                    this.ddlXa_DC.DataTextField = "Name";
                    this.ddlXa_DC.DataValueField = "Id";
                    ddlXa_DC.SelectedValue = "0";
                    this.ddlXa_DC.DataBind();
                }
                #endregion
            }

        }
    }
    #endregion

    #region Method LoadDataNLD
    private void LoadDataNLD(int idNguoiLaoDong)
    {
        #region thông tin NLD
        DataTable objData = objNguoiLaoDong.getDataById(idNguoiLaoDong);
        if (objData.Rows.Count > 0)
        {
            DataRow objDataRow = objData.Rows[0];
            txtHoVaTen.Text = objDataRow["HoVaTen"].ToString();
            try
            {
                txtNgaySinh.Value = ((DateTime)objDataRow["NgaySinh"]).ToString("dd/MM/yyyy");
            }
            catch { }

            int gioitinh = (int)objDataRow["IDGioiTinh"];
            if (gioitinh == 1) chkGioiTinhNam.Checked = true;
            else if (gioitinh == 2) chkGioiTinhNu.Checked = true;

            txtCMND.Text = objDataRow["CMND"].ToString();
            if (txtCMND.Text != "")
            {
                txtCMND.ReadOnly = true;
            }
            else
            {
                txtCMND.ReadOnly = false;
            }
            try
            {
                txtNgayCap.Value = ((DateTime)objDataRow["NgayCapCMND"]).ToString("dd/MM/yyyy");
            }
            catch { }
            ddlNoiCap.SelectedValue = objDataRow["NoiCap"].ToString();

            txtSoDienThoai.Text = objDataRow["DienThoai"].ToString();
            //txtNoiThuongTru.Text = objDataRow["NoiThuongTru"].ToString();

            txtSoTaiKhoan.Text = objDataRow["TaiKhoan"].ToString();
            ddlNganHang.SelectedValue = objDataRow["IDNganHang"].ToString();
            txtMaSoThue.Text = objDataRow["MaSoThue"].ToString();
            txtEmail.Text = objDataRow["Email"].ToString();

            txtBHXH.Text = objDataRow["BHXH"].ToString();
            if (txtBHXH.Text != "")
            {
                txtBHXH.ReadOnly = true;
            }
            else
            {
                txtBHXH.ReadOnly = false;
            }
            try
            {
                txtNgayCapBHXH.Value = ((DateTime)objDataRow["NgayCapBHXH"]).ToString("dd/MM/yyyy");
            }
            catch { }
            ddlNoiCapBHXH.SelectedValue = objDataRow["NoiCapBHXH"].ToString();
            ddlNoiKhamBenh.SelectedValue = objDataRow["NoiDangKyKhamBenh"].ToString();
            //ddlTDCM.SelectedValue = objDataRow["TrinhDoChuyenMon"].ToString();
            //ddlLinhVucDT.SelectedValue = objDataRow["LinhVucDaoTao"].ToString();
            txtCongViecDaLam.Text = objDataRow["CongViecDaLam"].ToString();   
            #region noi cu tru
            this.txtXom_TT.Text = objDataRow["Xom_TT"].ToString();
            this.txtXom_DC.Text = objDataRow["Xom_DC"].ToString();
            // ****************** chọn tỉnh ******************
            for (int i = 0; i < this.ddlTinh_TT.Items.Count; i++)
            {
                if (this.ddlTinh_TT.Items[i].Text == objDataRow["Tinh_TT"].ToString())
                {
                    this.ddlTinh_TT.SelectedIndex = i;
                    break;
                }
            }

            for (int i = 0; i < this.ddlTinh_DC.Items.Count; i++)
            {
                if (this.ddlTinh_DC.Items[i].Text == objDataRow["Tinh_DC"].ToString())
                {
                    this.ddlTinh_DC.SelectedIndex = i;
                    break;
                }
            }

            // ****************** chọn huyện ******************
            if (this.ddlTinh_TT.Items.Count > 0)
            {
                this.ddlHuyen_TT.DataSource = this.objDistrict.getDataCategoryToCombobox(this.ddlTinh_TT.SelectedValue.ToString());
                this.ddlHuyen_TT.DataTextField = "Name";
                this.ddlHuyen_TT.DataValueField = "Id";
                this.ddlHuyen_TT.DataBind();
            }

            if (this.ddlTinh_DC.Items.Count > 0)
            {
                this.ddlHuyen_DC.DataSource = this.objDistrict.getDataCategoryToCombobox(this.ddlTinh_DC.SelectedValue.ToString());
                this.ddlHuyen_DC.DataTextField = "Name";
                this.ddlHuyen_DC.DataValueField = "Id";
                this.ddlHuyen_DC.DataBind();
            }


            for (int i = 0; i < this.ddlHuyen_TT.Items.Count; i++)
            {
                if (this.ddlHuyen_TT.Items[i].Text == objDataRow["Huyen_TT"].ToString())
                {
                    this.ddlHuyen_TT.SelectedIndex = i;
                    break;
                }
            }

            for (int i = 0; i < this.ddlHuyen_DC.Items.Count; i++)
            {
                if (this.ddlHuyen_DC.Items[i].Text == objDataRow["Huyen_DC"].ToString())
                {
                    this.ddlHuyen_DC.SelectedIndex = i;
                    break;
                }
            }

            // ****************** chọn xã ******************
            if (this.ddlHuyen_TT.Items.Count > 0)
            {
                this.ddlXa_TT.DataSource = this.objWard.getDataCategoryToCombobox(this.ddlTinh_TT.SelectedValue.ToString(), this.ddlHuyen_TT.SelectedValue.ToString());
                this.ddlXa_TT.DataTextField = "Name";
                this.ddlXa_TT.DataValueField = "Id";
                this.ddlXa_TT.DataBind();
            }

            if (this.ddlHuyen_DC.Items.Count > 0)
            {
                this.ddlXa_DC.DataSource = this.objWard.getDataCategoryToCombobox(this.ddlTinh_DC.SelectedValue.ToString(), this.ddlHuyen_DC.SelectedValue.ToString());
                this.ddlXa_DC.DataTextField = "Name";
                this.ddlXa_DC.DataValueField = "Id";
                this.ddlXa_DC.DataBind();
            }

            for (int i = 0; i < this.ddlXa_TT.Items.Count; i++)
            {
                if (this.ddlXa_TT.Items[i].Text == objDataRow["Xa_TT"].ToString())
                {
                    this.ddlXa_TT.SelectedIndex = i;
                    break;
                }
            }

            for (int i = 0; i < this.ddlXa_DC.Items.Count; i++)
            {
                if (this.ddlXa_DC.Items[i].Text == objDataRow["Xa_DC"].ToString())
                {
                    this.ddlXa_DC.SelectedIndex = i;
                    break;
                }
            }
            //////////////////////////////////////////////////////
            #endregion

        }
        #endregion
    }

    private void LoadDataTCTN(int IDTCTN)
    {
        DataRow row = new NLDTroCapThatNghiep().getItem(IDTCTN);
        if (row != null)
        {
            ddlLoaiHopDong.SelectedValue = row["IDLoaiHopDong"].ToString();
            ddlGiayToKemtheo.SelectedValue = row["idGiayToKemTheo"].ToString();
            ddlNoiNhanTCTN.SelectedValue = row["IDNoiNhanTCTN"].ToString();
            ddlNoiChotSoCuoi.SelectedValue = row["IDNoiChotSoCuoi"].ToString();
        }
    }
    #endregion

    #region Even btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Save Người lao động
        int idNguoiLaoDong = 0;
        if(objDataTroCap != null)
        {
            idNguoiLaoDong = (int)objDataTroCap["IDNguoiLaoDong"];
        }
        else
        {
            try
            {
                idNguoiLaoDong = int.Parse(IdNLD.Value);
            }
            catch { }
        }

        #region kiểm tra người lao động
        if (this.txtCMND.Text.Trim() != "")
        {
            if (this.txtCMND.Text.Trim().Length < 9 || this.txtCMND.Text.Trim().Length>10)
            {
                this.lblMsg.Text = "Bạn nhập số CMND không chính xác";
                this.txtCMND.Focus();
                return;
            }


            int retCMND = objNguoiLaoDong.checkCMND(this.txtCMND.Text.Trim(), idNguoiLaoDong);
            if (retCMND != 0)
            {
                if (idNguoiLaoDong != 0)
                {
                    this.lblMsg.Text = "Số CMND đã tồn tại!";
                    return;
                }
                LoadDataNLD(retCMND);
                IdNLD.Value = retCMND.ToString();

                this.lblMsg.Text = "Người lao động đã tồn tại";
                return;
            }
        }


        if (txtBHXH.Text.Trim() != "")
        {
            if (txtBHXH.Text.Trim().Length != 10)
            {
                this.lblMsg.Text = "Bạn nhập số BHXH không chính xác";
                this.txtBHXH.Focus();
                return;
            }

            int retBHXH = objNguoiLaoDong.checkBHXH(this.txtBHXH.Text.Trim(), idNguoiLaoDong);
            if (retBHXH != 0)
            {
                if (idNguoiLaoDong != 0)
                {
                    this.lblMsg.Text = "Số BHXH đã tồn tại!";
                    return;
                }

                LoadDataNLD(retBHXH);
                IdNLD.Value = retBHXH.ToString();

                this.lblMsg.Text = "Mã BHXH đã tồn tại";
                return;
            }
        }

        if (itemId == 0)
        {
            int nld = objNLDTroCapThatNghiep.CheckBHTN(idNguoiLaoDong);
            if(nld != 0)
            {
                this.lblMsg.Text = "Người lao động đã ở trong danh sách đăng ký hoặc trong quá trình hưởng TN";
                return;
            }
        }
        #endregion

        #region Lưu thông tin người lao động
        
        int gioitinh = 0;
        if(chkGioiTinhNam.Checked == true) gioitinh = 1;
        else if(chkGioiTinhNu.Checked == true) gioitinh = 2;


        
        string ddlHuyen_TT_Name = objDistrict.getNameById(int.Parse(Request.Form["ctl00$MainContent$ddlHuyen_TT"]));
        string ddlHuyen_DC_Name = objDistrict.getNameById(int.Parse(Request.Form["ctl00$MainContent$ddlHuyen_DC"]));

        string ddlXa_TT_Name = objWard.getNameById(int.Parse(Request.Form["ctl00$MainContent$ddlXa_TT"]));
        string ddlXa_DC_Name = objWard.getNameById(int.Parse(Request.Form["ctl00$MainContent$ddlXa_DC"]));
        try{
            if (idNguoiLaoDong != 0) objNguoiLaoDong["IDNguoiLaoDong"] = idNguoiLaoDong;
            else objNguoiLaoDong["Ma"] = objNguoiLaoDong.getNextMaNLD();
            
            objNguoiLaoDong["HoVaTen"] = txtHoVaTen.Text;
            objNguoiLaoDong["NgaySinh"] = TVSSystem.CVDateDbNull(txtNgaySinh.Value);
            objNguoiLaoDong["IDGioiTinh"] = gioitinh;
            objNguoiLaoDong["CMND"] = txtCMND.Text;
            objNguoiLaoDong["NgayCapCMND"] = TVSSystem.CVDateDbNull(txtNgayCap.Value);
            objNguoiLaoDong["NoiCap"] = ddlNoiCap.SelectedItem.Text;
            objNguoiLaoDong["DienThoai"] = txtSoDienThoai.Text;
            objNguoiLaoDong["IDDanToc"] = int.Parse(ddlDanToc.SelectedValue);
            objNguoiLaoDong["IDTonGiao"] = int.Parse(ddlTonGiao.SelectedValue);
            objNguoiLaoDong["BHXH"] = txtBHXH.Text;
            objNguoiLaoDong["NgayCapBHXH"] = TVSSystem.CVDateDbNull(txtNgayCapBHXH.Value);
            objNguoiLaoDong["NoiCapBHXH"] = int.Parse(ddlNoiCapBHXH.SelectedValue);
            objNguoiLaoDong["TaiKhoan"] = txtSoTaiKhoan.Text;
            objNguoiLaoDong["IDNganHang"] = int.Parse(ddlNganHang.SelectedValue);
            objNguoiLaoDong["MaSoThue"] = txtMaSoThue.Text;
            objNguoiLaoDong["Email"] = txtEmail.Text;
            
            objNguoiLaoDong["Tinh_TT"] = this.ddlTinh_TT.SelectedItem.Text;
            objNguoiLaoDong["Huyen_TT"] = ddlHuyen_TT_Name;
            objNguoiLaoDong["Xa_TT"] = ddlXa_TT_Name;
            objNguoiLaoDong["Xom_TT"] = this.txtXom_TT.Text;
            
            objNguoiLaoDong["Tinh_DC"] = this.ddlTinh_DC.SelectedItem.Text;
            objNguoiLaoDong["Huyen_DC"] = ddlHuyen_DC_Name;
            objNguoiLaoDong["Xa_DC"] = ddlXa_DC_Name;
            objNguoiLaoDong["Xom_DC"] = this.txtXom_DC.Text;
            
            objNguoiLaoDong["NoiDangKyKhamBenh"] = int.Parse(ddlNoiKhamBenh.SelectedValue);
            objNguoiLaoDong["TrinhDoKyNangNghe"] = txtCMKT.Text;
            objNguoiLaoDong["TrinhDoDaoTao"] = txtLinhVucDaotao.Text;

            idNguoiLaoDong = (int)objNguoiLaoDong.setData();
            IdNLD.Value = idNguoiLaoDong.ToString();
        }catch{
            idNguoiLaoDong = 0;
        }

        #endregion 

        if(idNguoiLaoDong == 0)
        {
            lblMsg.Text = "Có lỗi xảy ra!" + objNguoiLaoDong.Message;
            return;
        }
        #endregion

        #region Save Doanh nghiệp
        int idDoanhNghiep = 0;
        try {
            idDoanhNghiep = int.Parse(txtIDDonVi.Value);
        }
        catch { }
        if (txtTenDonVi.Text.Trim() != "")
        { 
            try
            {
                if (idDoanhNghiep != 0) objDoanhNghiep["IDDonVi"] = idDoanhNghiep;
                else objDoanhNghiep["MaDonVi"] = objDoanhNghiep.getNextMaDN();

                objDoanhNghiep["TenDonVi"] = txtTenDonVi.Text;
                objDoanhNghiep["DiaChi"] = txtDiaChiDN.Text;
                objDoanhNghiep["DienThoaiDonVi"] = txtPhoneDN.Text;
                objDoanhNghiep["FaxDonVi"] = txtFaxDN.Text;
                objDoanhNghiep["EmailDonVi"] = txtEmailDN.Text;
                objDoanhNghiep["SoDKKD"] = txtSoDKKD.Text;
                objDoanhNghiep["IdLoaiHinh"] = int.Parse(ddlLoaiHinhDN.SelectedValue);
                objDoanhNghiep["IDNganhNghe"] = int.Parse(ddlIdNganhNgheDN.SelectedValue);
                objDoanhNghiep["Website"] = txtWebsiteDN.Text;

                idDoanhNghiep = (int)objDoanhNghiep.setData();
            }
            catch {
                idDoanhNghiep = 0;
            }

            if (idDoanhNghiep == 0)
            {
                lblMsg.Text = "Có lỗi xảy ra!" + objDoanhNghiep.Message;
                return;
            }
        }
        #endregion

        #region Save BHXH
        int ret = 0;
        try
        {
            if (itemId != 0) objNLDTroCapThatNghiep["IdNLDTCTN"] = itemId;
            objNLDTroCapThatNghiep["IDNguoiLaoDong"] = idNguoiLaoDong;
            objNLDTroCapThatNghiep["NgayNopHoSo"] = TVSSystem.CVDateDbNull(txtNgayNopHS.Value);
            objNLDTroCapThatNghiep["IdNguoiNhan"] = int.Parse(ddlNguoiNhan.SelectedValue);
            if (ddlNoiNhan.SelectedValue == null || ddlNoiNhan.SelectedValue.ToString().Trim() == "")
            {
                lblMsg.Text = "Bạn chưa chọn nơi nhận";
                ddlNoiNhan.Focus();
                return;
            }
            objNLDTroCapThatNghiep["IdNoiNhan"] = int.Parse(ddlNoiNhan.SelectedValue);        
         
            if (txtSoThangDongBHXH.Text != "")
            {
                objNLDTroCapThatNghiep["SoThangDongBHXH"] = int.Parse(txtSoThangDongBHXH.Text);
            }
            else
            {
                objNLDTroCapThatNghiep["SoThangDongBHXH"] = DBNull.Value;
                this.lblMsg.Text = "Bạn chưa nhập số tháng đóng BHXH";
                // Code The Linh 31/7/2017 sua kiem tra dau vao
                return;
            }

            objNLDTroCapThatNghiep["IdLoaiHopDong"] = int.Parse(ddlLoaiHopDong.SelectedValue);
            objNLDTroCapThatNghiep["IdGiayTokemTheo"] = int.Parse(ddlGiayToKemtheo.SelectedValue);
            //objNLDTroCapThatNghiep["HanHoanThien"] = TVSSystem.CVDateDbNull(txtHanHoanThien.Value);
            // Code the linh Sửa lỗi 31/7/2017
            objNLDTroCapThatNghiep["HanHoanThien"] = TVSSystem.CVDateDbNull(txtNgayNopHS.Value);
           objNLDTroCapThatNghiep["IdNoiNhanTCTN"] = int.Parse(ddlNoiNhanTCTN.SelectedValue);
            objNLDTroCapThatNghiep["IdNoiChotSoCuoi"] = int.Parse(ddlNoiChotSoCuoi.SelectedValue);
            objNLDTroCapThatNghiep["NgayNghiViec"] = TVSSystem.CVDateDbNull(txtNgayNghiViec.Value);
            // Code the linh Sửa lỗi 31/7/2017
            if(txtNgayNopHS.Value.Trim()!="" && txtNgayNghiViec.Value.Trim()!="")
            {
                DateTime NgayNopHoSo = Convert.ToDateTime(txtNgayNopHS.Value, new CultureInfo("vi-VN"));
                DateTime NgayNghiViec = Convert.ToDateTime(txtNgayNghiViec.Value, new CultureInfo("vi-VN"));
                NgayNghiViec = NgayNghiViec.AddMonths(3);
               if(DateTime.Compare(NgayNghiViec,NgayNopHoSo)<0)
               {
                   lblMsg.Text = "Thời gian nộp hồ sơ của bạn đã quá 3 tháng tính từ khi nghỉ việc";
                   return;
               }

            }
            objNLDTroCapThatNghiep["CongViecDaLam"] = txtCongViecDaLam.Text;
            objNLDTroCapThatNghiep["IdQuaTrinhCongTacGanNhat"] = idDoanhNghiep;
            objNLDTroCapThatNghiep["IdTrangThai"] = 1;
            objNLDTroCapThatNghiep["EditDay"] = DateTime.Now;
            objNLDTroCapThatNghiep["NgayHenTraKQ"] = new TinhHuong().TinhNgayNghiLe(Convert.ToDateTime(txtNgayNopHS.Value, new CultureInfo("vi-VN")), 20);

            int htnt = 0;
            if (cbkATM.Checked) htnt = 1;
            else if (cbkTienMat.Checked) htnt = 2;

            objNLDTroCapThatNghiep["IdHinhThucNhanTien"] = htnt;

            ret = (int)objNLDTroCapThatNghiep.setData();
            #region log he thong
            Log item = new Log();
            item.NgayTao = DateTime.Now;
            item.NguoiLaoDongID = idNguoiLaoDong;
            item.TroCapThatNghiepID = ret;
            item.UserID = (int)_Permission["Id"];
            item.UserName = _Permission["UserName"].ToString();
            item.Action = "Cập nhật hồ sơ hưởng TCTN";
            item.GhiChu = "";
            new Log().Insert(item);
            #endregion
            Response.Redirect("NhapThongTinHoSo.aspx?id=" + ret);
           //x ret = objNLDTroCapThatNghiep.setData(itemId, idNguoiLaoDong,);
        }
        catch
        {
            ret = 0;
        }

        if (ret == 0)
        {
            lblMsg.Text = "Có lỗi xảy ra!" + objNLDTroCapThatNghiep.Message;
            return;
        }

        #endregion 
    }
    #endregion

    #region Even DeNghiHuong_Click
    public void DeNghiHuong_Click(Object sender, EventArgs e)
    {
        if (objDataTroCap != null)
        {
            List<string> lstInput = new List<string>();
            List<string> lstOutput = new List<string>();

            #region thông tin người lao động
            DataTable objData = objNguoiLaoDong.getDataById((int)this.objDataTroCap["IDNguoiLaoDong"]);
            if (objData.Rows.Count == 0) return;
            DataRow objDataRow = objData.Rows[0];

            lstInput.Add("[TenLD]");
            lstOutput.Add(objDataRow["HoVaTen"].ToString());


            try
            {
                lstOutput.Add(((DateTime)objDataRow["NgaySinh"]).ToString("dd/MM/yyyy"));
                lstInput.Add("[NgaySinh]");
            }
            catch { }


            int gioitinh = (int)objDataRow["IDGioiTinh"];
            if (gioitinh == 1)
            {
                lstInput.Add("[Nam/Nu]");
                lstOutput.Add("Nam");
            }
            else if (gioitinh == 2)
            {
                lstInput.Add("[Nam/Nu]");
                lstOutput.Add("Nữ");
            }

            lstInput.Add("[CMTND]");
            lstOutput.Add(objDataRow["CMND"].ToString());

            try
            {
                lstOutput.Add(((DateTime)objDataRow["NgayCapCMND"]).ToString("dd/MM/yyyy"));
                lstInput.Add("[NgayCapCMTND]");
            }
            catch { }

            lstInput.Add("[NoiCapCMTND]");
            lstOutput.Add(objDataRow["NoiCap"].ToString());

            lstInput.Add("[SoBHXH]");
            lstOutput.Add(objDataRow["BHXH"].ToString());

            lstInput.Add("[DienThoai]");
            lstOutput.Add(objDataRow["DienThoai"].ToString());

            lstInput.Add("[Email]");
            lstOutput.Add(objDataRow["Email"].ToString());

            lstInput.Add("[DanToc]");
            lstOutput.Add(objDanToc.getDataNameById((int)objDataRow["IDDanToc"]));

            lstInput.Add("[TonGiao]");
            lstOutput.Add(objTonGiao.getDataNameById((int)objDataRow["IDTonGiao"]));

            lstInput.Add("[SoTaiKhoan]");
            lstOutput.Add(objDataRow["TaiKhoan"].ToString());

            lstInput.Add("[NganHang]");
            lstOutput.Add("");//IDNganHang

            lstInput.Add("[TrinhDoDaoTao]");
            if (objDataRow["TrinhDoDaoTao"].ToString() != "")
            {
                lstOutput.Add(objDataRow["TrinhDoDaoTao"].ToString());
            }
            else
            {
                lstOutput.Add(objTrinhDoPhoThong.getDataNameById((int)objDataRow["IDTrinhDoPhoThong"]));
            }


            lstInput.Add("[NganhNgheDaoTao]");
            lstOutput.Add(objDataRow["TrinhDoKyNangNghe"].ToString());

            lstInput.Add("[DiaChiThuongTru]");
            lstOutput.Add(objDataRow["NoiThuongTru"].ToString());

            lstInput.Add("[DiaChiHienTai]");
            lstOutput.Add(objDataRow["NoiThuongTru"].ToString());

            #endregion

            #region Doanh nghiệp
            int idDonVi = 0;
            try
            {
                idDonVi = (int)this.objDataTroCap["IdQuaTrinhCongTacGanNhat"];
            }
            catch { }

            if (idDonVi != 0)
            {
                DataTable objDataDN = objDoanhNghiep.getDataById(idDonVi);
                if (objDataDN.Rows.Count > 0)
                {
                    DataRow objDataRowDN = objDataDN.Rows[0];

                    lstInput.Add("[TenDN]");
                    lstOutput.Add(objDataRowDN["TenDonVi"].ToString());

                    lstInput.Add("[DiaChiDoanhNghiep]");
                    lstOutput.Add(objDataRowDN["DiaChi"].ToString());

                }
            }
            #endregion

            #region Thông tin bổ sung

            //objDataTroCap = objNLDTroCapThatNghiep.getItem(itemId);
            if (objDataTroCap != null)
            {
                try
                {
                    lstOutput.Add(((DateTime)objDataTroCap["NgayNghiViec"]).ToString("dd/MM/yyyy"));
                    lstInput.Add("[NgayNghiViec]");
                }
                catch { }

                lstInput.Add("[LyDoChamDutHD]");
                lstOutput.Add("");

                lstInput.Add("[LoaiHopDong]");
                lstOutput.Add(objDanhMuc.getNameById((int)objDataTroCap["IdLoaiHopDong"]));

                lstInput.Add("[SoThangDongBHTN]");
                lstOutput.Add(objDataTroCap["SoThangDongBHXH"].ToString());

                lstInput.Add("[NoiNhanTCTN]");
                lstOutput.Add(objDanhMuc.getNameById((int)objDataTroCap["IdNoiNhanTCTN"]));

                lstInput.Add("[Giaytokemtheo]");
                lstOutput.Add(objDanhMuc.getNameById((int)objDataTroCap["IdGiayTokemTheo"]));

                try
                {
                    lstOutput.Add(((DateTime)objDataTroCap["NgayNopHoSo"]).ToString("dd/MM/yyyy"));
                    lstInput.Add("[NgayNopHS]");
                }
                catch { }


            }
            #endregion

            ExportToWord objExportToWord = new ExportToWord();
            byte[] temp = objExportToWord.Export(Server.MapPath("../WordForm/PhieuDeNghiHuongTCTN.docx"), lstInput, lstOutput);


            Response.AppendHeader("Content-Type", "application/msword");
            Response.AppendHeader("Content-disposition", "inline; filename=PhieuDeNghiHuong.docx");
            Response.BinaryWrite(temp);
            HttpContext.Current.Response.End();
            HttpContext.Current.Response.Flush();
        }
    }
    #endregion

    #region Even GiayBienNhan_Click
    public void GiayBienNhan_Click(Object sender, EventArgs e)
    {
        if (itemId != 0)
        {
            List<string> lstInput = new List<string>();
            List<string> lstOutput = new List<string>();

            #region Thông tin trung tâm
            AboutUs objAboutUs = new AboutUs();
            DataTable objabout = objAboutUs.getData();
            if (objabout.Rows.Count > 0)
            {
                lstInput.Add("[SDTTrungTam]");
                lstOutput.Add(objabout.Rows[0]["Phone"].ToString());
            }
            #endregion

            #region ngày hiện tại
            DateTime bufDate = DateTime.Now;
            lstInput.Add("[ngay]");
            lstOutput.Add(bufDate.Day.ToString());
            lstInput.Add("[thang]");
            lstOutput.Add(bufDate.Month.ToString());
            lstInput.Add("[nam]");
            lstOutput.Add(bufDate.Year.ToString());
            #endregion

            #region thông tin người lao động
            DataTable objData = objNguoiLaoDong.getDataById(itemId);
            if (objData.Rows.Count == 0) return;
            DataRow objDataRow = objData.Rows[0];

            lstInput.Add("[TenLD]");
            lstOutput.Add(objDataRow["HoVaTen"].ToString());


            try
            {
                lstOutput.Add(((DateTime)objDataRow["NgaySinh"]).ToString("dd/MM/yyyy"));
                lstInput.Add("[NgaySinh]");
            }
            catch { }

            lstInput.Add("[CMTND]");
            lstOutput.Add(objDataRow["CMND"].ToString());

            lstInput.Add("[SoBHXH]");
            lstOutput.Add(objDataRow["BHXH"].ToString());

            #endregion

            #region Thông tin bổ sung
            DataRow objDataTroCap = objNLDTroCapThatNghiep.getItem(itemId);
            if (objDataTroCap != null)
            {
                try
                {
                    lstOutput.Add(((DateTime)objDataTroCap["NgayNghiViec"]).ToString("dd/MM/yyyy"));
                    lstInput.Add("[NgayNghiViec]");
                }
                catch { }


                try
                {
                    lstOutput.Add(((DateTime)objDataTroCap["NgayHoanThien"]).ToString("dd/MM/yyyy"));
                    lstInput.Add("[NgayNopHoSo]");
                }
                catch { }

                lstInput.Add("[NguoiTiepNhan]");
                lstOutput.Add("");
            }
            #endregion

            ExportToWord objExportToWord = new ExportToWord();
            byte[] temp = objExportToWord.Export(Server.MapPath("../WordForm/PhieuHenTraKetQua.docx"), lstInput, lstOutput);


            Response.AppendHeader("Content-Type", "application/msword");
            Response.AppendHeader("Content-disposition", "inline; filename=PhieuHenTraKetQua.docx");
            Response.BinaryWrite(temp);
            HttpContext.Current.Response.End();
            HttpContext.Current.Response.Flush();
        }
    }
    #endregion

    #region Even btnHoanThienHoSo_Click
    protected void btnHoanThienHoSo_Click(object sender, EventArgs e)
    {
        try
        {
            BHTNClass objBHXH = new BHTNClass();
            objBHXH.setHoanThien(itemId, txtNgayHoanThanh.Value);           
            #region log he thong
            Log item = new Log();
            item.NgayTao = DateTime.Now;
            DataRow TCTN=new NLDTroCapThatNghiep().getItem(itemId);
            item.NguoiLaoDongID = (int)TCTN["IDNguoiLaoDong"];
            item.TroCapThatNghiepID = itemId;
            item.UserID = (int)_Permission["Id"];
            item.UserName = _Permission["UserName"].ToString();
            item.Action = "Chuyển tính hưởng";
            item.GhiChu = "";
            new Log().Insert(item);
            #endregion
            Response.Redirect("/BHTN/DangKyHoSo.aspx");
        }
        catch
        {
            lblMsg.Text = "Có lỗi xảy ra!";
        }
    }
    #endregion
    protected void PhieuHenTraKQ_ServerClick(object sender, EventArgs e)
    {
        new Common().TaiPhieuHenTraKQ(itemId, "");      
    }
   
}