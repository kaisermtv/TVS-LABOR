using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Labor_BaoHiemThatNghiepEdit : System.Web.UI.Page
{
    #region declare
    private NguoiLaoDong objNguoiLaoDong = new NguoiLaoDong();
    private DoanhNghiep objDoanhNghiep = new DoanhNghiep();
    private NLDTroCapThatNghiep objNLDTroCapThatNghiep = new NLDTroCapThatNghiep();
    private TonGiao objTonGiao = new TonGiao();
    private DanToc objDanToc = new DanToc();
    private TrinhDoPhoThong objTrinhDoPhoThong = new TrinhDoPhoThong();
    private DanhMuc objDanhMuc = new DanhMuc();

    private LoaiHinh objLoaiHinh = new LoaiHinh();
    private Business objBusiness = new Business();

    public int itemId = 0;
    public int type = 0;
    public string _msg="";   
    #endregion

    #region Even Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ACCOUNT"] == null)
        {
            Response.Redirect("../Login.aspx");
        }

        try
        {
            this.itemId = int.Parse(Request["id"].ToString());
        }
        catch
        {
            this.itemId = 0;
        }

        try
        {
            this.type = int.Parse(Request["type"].ToString());
        }
        catch
        {
            this.type = 0;
        }




        if(type == 1)
        {
            if (itemId == 0)
            {
                Response.Redirect("/Labor/BaoHiemThatNghiep.aspx");
                    return;
            }

            btnSave.Text = "Tính hưởng";
        }


        #region Khởi tạo select
        if (!Page.IsPostBack)
        {
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

            ddlDangKyTre.DataSource = objDanhMuc.getDataCategoryToCombobox("--Chọn lý do đăng ký trễ--", TVSSystem.LyDoDangKytre);
            ddlDangKyTre.DataTextField = "NameDanhMuc";
            ddlDangKyTre.DataValueField = "IdDanhMuc";
            ddlDangKyTre.DataBind();
            ddlDangKyTre.SelectedValue = "0";

            ddlNoiCap.DataSource = objDanhMuc.getDataCategoryToCombobox("--Nơi cấp CMND--", TVSSystem.NoiCapCMND);
            ddlNoiCap.DataTextField = "NameDanhMuc";
            ddlNoiCap.DataValueField = "IdDanhMuc";
            ddlNoiCap.DataBind();
            ddlNoiCap.SelectedValue = "0";

            ddlNoiChotSoCuoi.DataSource = objDanhMuc.getDataCategoryToCombobox("--Nơi chốt sổ cuối--", TVSSystem.NoiChotSoCuoi);
            ddlNoiChotSoCuoi.DataTextField = "NameDanhMuc";
            ddlNoiChotSoCuoi.DataValueField = "IdDanhMuc";
            ddlNoiChotSoCuoi.DataBind();
            ddlNoiChotSoCuoi.SelectedValue = "0";

            ddlNoiCapBHXH.DataSource = objDanhMuc.getDataCategoryToCombobox("--Nơi Cấp BHXH--", TVSSystem.NoiChotSoCuoi);
            ddlNoiCapBHXH.DataTextField = "NameDanhMuc";
            ddlNoiCapBHXH.DataValueField = "IdDanhMuc";
            ddlNoiCapBHXH.DataBind();
            ddlNoiCapBHXH.SelectedValue = "0";

            ddlNoiKhamBenh.DataSource = objDanhMuc.getDataCategoryToCombobox("--Nơi ĐK khám bệnh--", TVSSystem.NoiDangKyKhamBenh);
            ddlNoiKhamBenh.DataTextField = "NameDanhMuc";
            ddlNoiKhamBenh.DataValueField = "IdDanhMuc";
            ddlNoiKhamBenh.DataBind();
            ddlNoiKhamBenh.SelectedValue = "0";

            ddlNoiNhanbaoHiem.DataSource = objDanhMuc.getDataCategoryToCombobox("--Nơi ĐK khám bệnh--", TVSSystem.NoiNhanBaoHiem);
            ddlNoiNhanbaoHiem.DataTextField = "NameDanhMuc";
            ddlNoiNhanbaoHiem.DataValueField = "IdDanhMuc";
            ddlNoiNhanbaoHiem.DataBind();
            ddlNoiNhanbaoHiem.SelectedValue = "0";

        }
        #endregion

        if (!Page.IsPostBack && itemId != 0)
        {
            #region thông tin NLD
            DataTable objData = objNguoiLaoDong.getDataById(itemId);
            if (objData.Rows.Count == 0) Response.Redirect("BaoHiemThatNghiepEdit.aspx");
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
            txtNoiThuongTru.Text = objDataRow["NoiThuongTru"].ToString();

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
            ddlTDCM.SelectedValue = objDataRow["TrinhDoChuyenMon"].ToString();
            ddlLinhVucDT.SelectedValue = objDataRow["LinhVucDaoTao"].ToString();
            txtCongViecDaLam.Text = objDataRow["CongViecDaLam"].ToString();
            #endregion

            #region tải thông tin doanh nghiệp
            int idDonVi = 0;
            try
            {
                idDonVi = (int)objDataRow["IdDoanhNghiep"];
            }
            catch { }
            
            if(idDonVi != 0)
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
            #endregion

            #region tải dữ liệu bảng rợ cấp
            DataRow objDataTroCap = objNLDTroCapThatNghiep.getItemByNLD(itemId);
            if(objDataTroCap != null)
            {
               

                try
                {
                    txtNgayNghiViec.Value = ((DateTime)objDataTroCap["NgayNghiViec"]).ToString("dd/MM/yyyy");
                }catch {}
                txtSoThangDongBHXH.Text = objDataTroCap["SoThangBHTN"].ToString();

                chkTuVan.Checked = (bool)objDataTroCap["NhuCauTuVan"];
                chkGioiThieu.Checked = (bool)objDataTroCap["NhuCauGTVL"];
                chkHocNghe.Checked = (bool)objDataTroCap["NhuCauHocNghe"];
                try
                {
                    txtNgayDangKyTN.Value = ((DateTime)objDataTroCap["NgayDangKyTN"]).ToString("dd/MM/yyyy");
                }
                catch { }
                

                chkDangKyTre.Checked = (bool)objDataTroCap["DangKyTre"];

                ddlDangKyTre.SelectedValue = objDataTroCap["DangKyTreLyDo"].ToString();
                ddlNguoiTiepNhan.SelectedValue = objDataTroCap["NoiTiepNhan"].ToString();
                try
                {
                    txtNgayHoanThien.Value = ((DateTime)objDataTroCap["NgayHoanThien"]).ToString("dd/MM/yyyy");
                }
                catch { }
                

                ddlNoiNhanbaoHiem.SelectedValue = objDataTroCap["NoiNhanBaoHiem"].ToString();

                int htnt = (int)objDataTroCap["HinhThucNhanTien"];
                cbkATM.Checked = (htnt == 1);
                cbkTienMat.Checked = (htnt == 2);

                ddlNoiChotSoCuoi.SelectedValue = objDataTroCap["NoiChotSoCuoi"].ToString();

                chkXacNhanDangKy.Checked = (bool)objDataTroCap["DaXacNhanChuaDangKy"];
                ddlNoiDKXacNhan.SelectedValue = objDataTroCap["NoiXacNhanChuaDangKy"].ToString();

            }
            #endregion 

            #region code The Linh Load thong tin tinh huong
            DataTable TblTinhHuong = new TinhHuong().getDataById(itemId);
            if (TblTinhHuong.Rows.Count > 0)
            {
                ddlLuongToiThieu.SelectedValue = TblTinhHuong.Rows[0]["LuongToiThieuVung"].ToString();
                txtThangThu1.Value = TblTinhHuong.Rows[0]["ThangDong1"].ToString();
                txtHeSoLuongThang1.Text = TblTinhHuong.Rows[0]["HeSoLuong1"].ToString();
                txtPhuCapThang1.Text = TblTinhHuong.Rows[0]["HeSoPhuCap1"].ToString();
                txtLuongCoBanThang1.Text = TblTinhHuong.Rows[0]["LuongCoBan1"].ToString();
                txtMucDongThang1.Text = TblTinhHuong.Rows[0]["MucDong1"].ToString();

                txtThangThu2.Value = TblTinhHuong.Rows[0]["ThangDong2"].ToString();
                txtHeSoluongThang2.Text = TblTinhHuong.Rows[0]["HeSoLuong2"].ToString();
                txtPhuCapThang2.Text = TblTinhHuong.Rows[0]["HeSoPhuCap2"].ToString();
                txtLuongCoBanThang2.Text = TblTinhHuong.Rows[0]["LuongCoBan2"].ToString();
                txtMucDongThang2.Text = TblTinhHuong.Rows[0]["MucDong2"].ToString();

                txtThangThu3.Value = TblTinhHuong.Rows[0]["ThangDong3"].ToString();
                txtHeSoLuongThang3.Text = TblTinhHuong.Rows[0]["HeSoLuong3"].ToString();
                txtPhuCapThang3.Text = TblTinhHuong.Rows[0]["HeSoPhuCap3"].ToString();
                txtLuongCoBanThang3.Text = TblTinhHuong.Rows[0]["LuongCoBan3"].ToString();
                txtMucDongthang3.Text = TblTinhHuong.Rows[0]["MucDong3"].ToString();

                txtThangThu4.Value = TblTinhHuong.Rows[0]["ThangDong4"].ToString();
                txtHeSoLuongThang4.Text = TblTinhHuong.Rows[0]["HeSoLuong4"].ToString();
                txtPhuCapThang4.Text = TblTinhHuong.Rows[0]["HeSoPhuCap4"].ToString();
                txtLuongCoBanThang4.Text = TblTinhHuong.Rows[0]["LuongCoBan4"].ToString();
                txtMucDongThang4.Text = TblTinhHuong.Rows[0]["MucDong4"].ToString();

                txtThangThu5.Value = TblTinhHuong.Rows[0]["ThangDong5"].ToString();
                txtHeSoLuongThang5.Text = TblTinhHuong.Rows[0]["HeSoLuong5"].ToString();
                txtPhuCapThang5.Text = TblTinhHuong.Rows[0]["HeSoPhuCap5"].ToString();
                txtLuongCoBanThang5.Text = TblTinhHuong.Rows[0]["LuongCoBan5"].ToString();
                txtMucDongThang5.Text = TblTinhHuong.Rows[0]["MucDong5"].ToString();

                txtThangThu6.Value = TblTinhHuong.Rows[0]["ThangDong6"].ToString();
                txtHeSoLuongThang6.Text = TblTinhHuong.Rows[0]["HeSoLuong6"].ToString();
                txtPhuCapThang6.Text = TblTinhHuong.Rows[0]["HeSoPhuCap6"].ToString();
                txtLuongCoBanThang6.Text = TblTinhHuong.Rows[0]["LuongCoBan6"].ToString();
                txtMucDongThang6.Text = TblTinhHuong.Rows[0]["MucDong6"].ToString();

                txtSoThangDongBHXH.Text = TblTinhHuong.Rows[0]["SoThangDongBHXH"].ToString();
                int SoThangHuong = (int)TblTinhHuong.Rows[0]["SoThangHuongBHXH"];
                txtSoThangHuong.Text = SoThangHuong.ToString();
                txtMucHuongToiDa.Text = TblTinhHuong.Rows[0]["MucHuongToiDa"].ToString();
                txtLuongTrungBinh.Text = TblTinhHuong.Rows[0]["LuongTrungBinh"].ToString();
                txtMucHuong.Text = TblTinhHuong.Rows[0]["MucHuong"].ToString();
                DateTime HuongTuNgay = ((DateTime)TblTinhHuong.Rows[0]["HuongTuNgay"]);
                DateTime HuongDenNgay = HuongTuNgay;
                for (int i = 0; i < SoThangHuong; i++)
                {
                    HuongDenNgay = HuongDenNgay.AddMonths(1);
                }
                txtHuongTuNgay.Value = ConvertDatetimeVn(HuongTuNgay);
                txtHuongDenNgay.Value = ConvertDatetimeVn(HuongDenNgay.AddDays(-1));


            }
            #endregion

        } else if (!Page.IsPostBack)
        {
            txtNgayDangKyTN.Value = DateTime.Now.ToString("dd/MM/yyyy");
        }

     
    }
    #endregion

    #region Even btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if(type == 1)
        {
            btnTinhHuong_Click(sender,e);
            return;
        }

        if(txtHoVaTen.Text.Trim() == "")
        {
            this.lblMsg.Text = "Bạn cần nhập họ tên!";
            return;
        }

        int gioitinh = 0;
        if(chkGioiTinhNam.Checked){
            gioitinh = 1;
        } else if(chkGioiTinhNu.Checked) {
            gioitinh = 2;
        }

        int idDonVi = 0;
        try
        {
            idDonVi = int.Parse(txtIDDonVi.Value.Trim());
        }
        catch { }

        idDonVi = objDoanhNghiep.setData(idDonVi, txtTenDonVi.Text, txtDiaChiDN.Text, txtPhoneDN.Text, txtFaxDN.Text, txtSoDKKD.Text, int.Parse(ddlLoaiHinhDN.SelectedValue), int.Parse(ddlIdNganhNgheDN.SelectedValue), txtEmailDN.Text, txtWebsiteDN.Text);

        if (idDonVi == 0)
        {
            this.lblMsg.Text = "Lỗi xảy ra khi cập nhật thông tin.";
            return;
        }

        try
        {
            itemId = objNguoiLaoDong.setData(itemId, txtHoVaTen.Text, TVSSystem.CVDateNull(txtNgaySinh.Value), gioitinh, txtCMND.Text, TVSSystem.CVDateNull(txtNgayCap.Value), int.Parse(ddlNoiCap.SelectedValue), txtSoDienThoai.Text, txtNoiThuongTru.Text, txtSoTaiKhoan.Text, int.Parse(ddlNganHang.SelectedValue), txtMaSoThue.Text, txtEmail.Text, txtBHXH.Text, TVSSystem.CVDateNull(txtNgayCapBHXH.Value), int.Parse(ddlNoiCapBHXH.SelectedValue), int.Parse(ddlNoiKhamBenh.SelectedValue), int.Parse(ddlTDCM.SelectedValue), int.Parse(ddlLinhVucDT.SelectedValue), txtCongViecDaLam.Text, idDonVi);
        }
        catch 
        {
            this.lblMsg.Text = "Lỗi xảy ra khi cập nhật thông tin.";
            return;
        }

        if (itemId == 0)
        {
            this.lblMsg.Text = "Lỗi xảy ra khi cập nhật thông tin.";
            return;
        }

        int HinhThucNhanTien = 0;
        if (cbkATM.Checked) HinhThucNhanTien = 1;
        else if (cbkTienMat.Checked) HinhThucNhanTien = 2;
        try
        {
            objNLDTroCapThatNghiep.setDataByNLD(itemId, TVSSystem.CVDateNull(txtNgayNghiViec.Value), float.Parse(txtSoThangDongBHXH.Text), chkTuVan.Checked, chkGioiThieu.Checked, chkHocNghe.Checked, TVSSystem.CVDateNull(txtNgayDangKyTN.Value), chkDangKyTre.Checked, int.Parse(ddlDangKyTre.SelectedValue), int.Parse(ddlNguoiTiepNhan.SelectedValue), TVSSystem.CVDateNull(txtNgayHoanThien.Value), int.Parse(ddlNoiNhanbaoHiem.SelectedValue), HinhThucNhanTien, int.Parse(ddlNoiChotSoCuoi.SelectedValue), chkXacNhanDangKy.Checked, int.Parse(ddlNoiDKXacNhan.SelectedValue));
        }
        catch { }


        Response.Redirect("BaoHiemThatNghiepEdit.aspx?id=" + itemId);
    }
    #endregion

    #region Tinh huong
    protected void btnTinhHuong_Click(object sender, EventArgs e)
    {   
        
 
    }
    private DateTime TinhNgayNghiLe(DateTime NgayNop, int SoNgayThuLy)
    {        
        for (int i = 0; i < SoNgayThuLy; i++)
        {
            NgayNop = NgayNop.AddDays(1);
            if (NgayNop.DayOfWeek == DayOfWeek.Saturday)
            {
                NgayNop = NgayNop.AddDays(1);
            }
            if (NgayNop.DayOfWeek == DayOfWeek.Sunday)
            {
                NgayNop = NgayNop.AddDays(1);
            }         
        }
        return NgayNop;
    }
    private DateTime ConvertDateimeUS(string DateVN)
    {
        string[] str = DateVN.Split('/');
        return new DateTime(int.Parse(str[2]), int.Parse(str[1]), int.Parse(str[0]));
    }
    private string ConvertDatetimeVn(DateTime DateUS)
    {
        return DateUS.Day.ToString() + "/" + DateUS.Month.ToString() + "/" + DateUS.Year.ToString();
    }
    private DateTime KiemTraNgayNghi(DateTime Datetime, List<DateTime> lstNgayLe)
    {
        for (int i = 0; i < lstNgayLe.Count;i++ )
        {
            if(Datetime==lstNgayLe[i])
            {
                Datetime.AddDays(i);
            }
        }
        return Datetime;
    }
    #endregion

    #region Even DeNghiHuong_Click
    public void DeNghiHuong_Click(Object sender, EventArgs e)
    {
        if(itemId != 0)
        {
            List<string> lstInput = new List<string>();
            List<string> lstOutput = new List<string>();

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
                lstOutput.Add(objTrinhDoPhoThong.getDataNameById((int) objDataRow["IDTrinhDoPhoThong"]));
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
                idDonVi = (int)objDataRow["IdDoanhNghiep"];
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
            DataRow objDataTroCap = objNLDTroCapThatNghiep.getItemByNLD(itemId);
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
                lstOutput.Add("");

                lstInput.Add("[SoThangDongBHTN]");
                lstOutput.Add(objDataTroCap["SoThangBHTN"].ToString());

                lstInput.Add("[NoiNhanTCTN]");
                lstOutput.Add("");

                lstInput.Add("[Giaytokemtheo]");
                lstOutput.Add("");

                try
                {
                    lstOutput.Add(((DateTime)objDataTroCap["NgayHoanThien"]).ToString("dd/MM/yyyy"));
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
            DataRow objDataTroCap = objNLDTroCapThatNghiep.getItemByNLD(itemId);
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

    #region Even Phieu tinh huong
    protected void Unnamed_ServerClick(object sender, EventArgs e)
    {
        if (itemId != 0)
        {
            DataTable TblTinhHuong = new TinhHuong().getDataById(itemId);
            DataTable TblNguoiLaoDong=new NguoiLaoDong().getDataById(itemId);
            if(TblNguoiLaoDong==null || TblNguoiLaoDong.Rows.Count ==0)
            {
                _msg="Người lao động chưa được khởi tạo";
                return;
            }
            if (TblTinhHuong == null || TblTinhHuong.Rows.Count == 0)
            {
                _msg = "Chưa có bẳng tỉnh nào được cập nhật";
                return;
            }
         
            List<string> lstInput = new List<string>();
            List<string> lstOutput = new List<string>();
            lstInput.Add("[TenNLD]");
            lstOutput.Add(TblNguoiLaoDong.Rows[0]["HoVaTen"].ToString());
            lstInput.Add("[NgaySinh]");
            lstOutput.Add(((DateTime)TblNguoiLaoDong.Rows[0]["NgaySinh"]).ToString("dd/MM/yyyy"));
            lstInput.Add("[SoBHXH]");
            lstOutput.Add(TblNguoiLaoDong.Rows[0]["BHXH"].ToString());
            lstInput.Add("[SoThangDong] ");
            lstOutput.Add(TblTinhHuong.Rows[0]["SoThangDongBHXH"].ToString());
            lstInput.Add("[DongTuThang]");
            lstOutput.Add("../../....");
            lstInput.Add("[DongDenThang]");
            lstOutput.Add("../../....");
            for (int i = 1; i <=6; i++)
            {
                lstInput.Add("[Thang" + i.ToString() + "]");
                lstOutput.Add(i.ToString());
                lstInput.Add("[TienThang" + i.ToString() + "]");
                lstOutput.Add(TblTinhHuong.Rows[0]["MucDong"+i.ToString()].ToString());
            }

            lstInput.Add("[MucDongTB]");
            lstOutput.Add(TblTinhHuong.Rows[0]["LuongTrungBinh"].ToString());
            lstInput.Add("[MucHuong]");
            lstOutput.Add(TblTinhHuong.Rows[0]["MucHuong"].ToString());        
            lstInput.Add("[SoThangHuong]");
            lstOutput.Add(TblTinhHuong.Rows[0]["SoThangHuongBHXH"].ToString());
            lstInput.Add("[TongTienHuong]");
            decimal MucHuong=0,SoThangHuong=0,TongTienHuong=0;
            MucHuong = decimal.Parse( TblTinhHuong.Rows[0]["MucHuong"].ToString());
            SoThangHuong = decimal.Parse( TblTinhHuong.Rows[0]["SoThangHuongBHXH"].ToString());
            TongTienHuong=MucHuong *SoThangHuong;
            lstOutput.Add(TongTienHuong.ToString());          
            lstInput.Add("[NgayTinhHuong]");
            lstOutput.Add(((DateTime)TblTinhHuong.Rows[0]["HuongTuNgay"]).ToString("dd/MM/yyyy"));
            ExportToWord objExportToWord = new ExportToWord();
            byte[] temp = objExportToWord.Export(Server.MapPath("../WordForm/PhieuTinhHuong.docx"), lstInput, lstOutput);

            Response.AppendHeader("Content-Type", "application/msword");
            Response.AppendHeader("Content-disposition", "inline; filename=PhieuTinhHuong.docx");
            Response.BinaryWrite(temp);
            HttpContext.Current.Response.End();
            HttpContext.Current.Response.Flush();
        }
    }
    #endregion
    #region Quyet dinh huong tro cap that nghiep
    protected void InQuyetDinhHuongTroCap_ServerClick(object sender, EventArgs e)
    {
        if (itemId != 0)
        {
            DataTable TblTinhHuong = new TinhHuong().getDataById(itemId);
            DataTable TblNguoiLaoDong = new NguoiLaoDong().getDataById(itemId);
            DataRow RowTroCapThatNghiep=new NLDTroCapThatNghiep().getItemByNLD(itemId);

            if (TblNguoiLaoDong == null || TblNguoiLaoDong.Rows.Count == 0)
            {
                _msg = "Người lao động chưa được khởi tạo";
                return;
            }
            if (TblTinhHuong == null || TblTinhHuong.Rows.Count == 0)
            {
                _msg = "Chưa có bẳng tỉnh nào được cập nhật";
                return;
            }
            List<string> lstInput = new List<string>();
            List<string> lstOutput = new List<string>();
            lstInput.Add("[NgayKy]");           
            try
            {
                 DateTime NgayDangKy = (DateTime)RowTroCapThatNghiep["NgayDangKyTN"];
                 DateTime NgayQuyetDinh = new DateTime();
                 NgayQuyetDinh=TinhNgayNghiLe(NgayDangKy,20);
                 lstOutput.Add(NgayQuyetDinh.ToString("dd/MM/yyyy"));
            }
            catch
            {
                lstOutput.Add(".../.../.....");
            }
            lstInput.Add("[TenLD]");
            lstOutput.Add(TblNguoiLaoDong.Rows[0]["HoVaTen"].ToString());
            lstInput.Add("[NgaySinh]");
            lstOutput.Add(((DateTime)TblNguoiLaoDong.Rows[0]["NgaySinh"]).ToString("dd/MM/yyyy"));
            lstInput.Add("[CMTND]");
            lstOutput.Add(TblNguoiLaoDong.Rows[0]["CMND"].ToString());
            lstInput.Add("[NgayCapCMTND]");
            lstOutput.Add(((DateTime)TblNguoiLaoDong.Rows[0]["NgayCapCMND"]).ToString("dd/MM/yyyy"));
            lstInput.Add("[NoiCapCMTND]");
            lstOutput.Add(TblNguoiLaoDong.Rows[0]["NoiCap"].ToString());
            lstInput.Add("[SoBHXH]");
            lstOutput.Add(TblNguoiLaoDong.Rows[0]["BHXH"].ToString());
            lstInput.Add("[DiaChiThuongTru]");
            lstOutput.Add(TblNguoiLaoDong.Rows[0]["NoiThuongTru"].ToString());
            lstInput.Add("[DiaChiHienTai]");
            lstOutput.Add(TblNguoiLaoDong.Rows[0]["DiaChi"].ToString());
            lstInput.Add("[SoThangDong]");
            lstOutput.Add(TblTinhHuong.Rows[0]["SoThangDongBHXH"].ToString());
            lstInput.Add("[MucHuong]");
            lstOutput.Add(TblTinhHuong.Rows[0]["MucHuong"].ToString());
            lstInput.Add("[SoThangHuong]");
            int SoThangHuong = (int)TblTinhHuong.Rows[0]["SoThangHuongBHXH"];
            lstOutput.Add(SoThangHuong.ToString());
            lstInput.Add("[HuongTuNgay]");
            DateTime HuongTuNgay = (DateTime)TblTinhHuong.Rows[0]["HuongTuNgay"];
            DateTime HuongDenNgay = TinhNgayNghiLe(HuongTuNgay, 16);
            for (int i = 0; i < SoThangHuong; i++)
            {
                HuongDenNgay = HuongDenNgay.AddMonths(1);
            }
            lstOutput.Add(HuongTuNgay.ToString("dd/MM/yyyy"));
            lstInput.Add("[HuongDenNgay]");
            lstOutput.Add(HuongDenNgay.ToString("dd/MM/yyyy"));

            ExportToWord objExportToWord = new ExportToWord();
            byte[] temp = objExportToWord.Export(Server.MapPath("../WordForm/QuyetDinhHuongTCTN.docx"), lstInput, lstOutput);
            Response.AppendHeader("Content-Type", "application/msword");
            Response.AppendHeader("Content-disposition", "inline; filename=QuyetDinhHuongTCTN.docx");
            Response.BinaryWrite(temp);
            HttpContext.Current.Response.End();
            HttpContext.Current.Response.Flush();
        }
    }
    #endregion
   
}