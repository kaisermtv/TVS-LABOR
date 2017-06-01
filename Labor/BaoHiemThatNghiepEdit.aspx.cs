using System;
using System.Collections.Generic;
using System.Data;
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

    private LoaiHinh objLoaiHinh = new LoaiHinh();
    private Business objBusiness = new Business();

    public int itemId = 0;
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
        }

        if (!Page.IsPostBack && itemId != 0)
        {
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

        } else if (!Page.IsPostBack)
        {
            txtNgayDangKyTN.Value = DateTime.Now.ToString("dd/MM/yyyy");
        }

     
    }
    #endregion

    #region Even btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if(txtHoVaTen.Text.Trim() == "")
        {
            this.lblMsg.InnerText = "Bạn cần nhập họ tên!";
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
            this.lblMsg.InnerText = "Lỗi xảy ra khi cập nhật thông tin.";
            return;
        }

        try
        {
            itemId = objNguoiLaoDong.setData(itemId, txtHoVaTen.Text, TVSSystem.CVDateNull(txtNgaySinh.Value), gioitinh, txtCMND.Text, TVSSystem.CVDateNull(txtNgayCap.Value), int.Parse(ddlNoiCap.SelectedValue), txtSoDienThoai.Text, txtNoiThuongTru.Text, txtSoTaiKhoan.Text, int.Parse(ddlNganHang.SelectedValue), txtMaSoThue.Text, txtEmail.Text, txtBHXH.Text, TVSSystem.CVDateNull(txtNgayCapBHXH.Value), int.Parse(ddlNoiCapBHXH.SelectedValue), int.Parse(ddlNoiKhamBenh.SelectedValue), int.Parse(ddlTDCM.SelectedValue), int.Parse(ddlLinhVucDT.SelectedValue), txtCongViecDaLam.Text, idDonVi);
        }
        catch 
        {
            this.lblMsg.InnerText = "Lỗi xảy ra khi cập nhật thông tin.";
            return;
        }

        if (itemId == 0)
        {
            this.lblMsg.InnerText = "Lỗi xảy ra khi cập nhật thông tin.";
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
        List<decimal> lstMucDong = new List<decimal>();
        TinhHuong objTinhHuong = new TinhHuong();       
        objTinhHuong.NgayTao = DateTime.Now;
        if (itemId <= 0)
        {
            _msg = "Người lao động chua được khởi tạo";
            return;
        }
        objTinhHuong.IDNguoiLaoDong = itemId;
        objTinhHuong.IDVungLuongToiThieu = 0;
        if ( ddlLuongToiThieu.SelectedValue !=null && ddlLuongToiThieu.SelectedValue.ToString()!="")
        {
            objTinhHuong.LuongToiThieuVung = decimal.Parse(ddlLuongToiThieu.SelectedValue.ToString());

        }
        if (txtThangThu6.Value.Trim() != "")
        {
            objTinhHuong.ThangDong6 = txtThangThu6.Value.Trim();
        }
        if (txtHeSoLuongThang6.Text.Trim() != "")
        {
            objTinhHuong.HeSoLuong6 = float.Parse(txtHeSoLuongThang6.Text);
        }
        if (txtPhuCapThang6.Text.Trim() != "")
        {
            objTinhHuong.HeSoPhuCap6 = float.Parse(txtPhuCapThang6.Text);
        }
        if ( txtLuongCoBanThang6.Text.Trim() != "")
        {
            objTinhHuong.LuongCoBan6 = decimal.Parse(txtLuongCoBanThang6.Text);
        }
        if (txtMucDongThang6.Text.Trim() == "")
        {
            _msg = "Bạn chưa nhập mức đóng tháng 6";
            return;
        }
        decimal MucDongThang6 = 0;
        decimal.TryParse(txtMucDongThang6.Text, out MucDongThang6);
        objTinhHuong.MucDong6 = MucDongThang6;

        if (txtThangThu5.Value.Trim() != "")
        {
            objTinhHuong.ThangDong5= txtThangThu5.Value.Trim();
        }
        if (txtHeSoLuongThang5.Text.Trim() != "")
        {
            objTinhHuong.HeSoLuong6 = float.Parse(txtHeSoLuongThang5.Text);
        }
        if (txtPhuCapThang5.Text.Trim() != "")
        {
            objTinhHuong.HeSoPhuCap5 = float.Parse(txtPhuCapThang5.Text);
        }
        if (txtLuongCoBanThang5.Text.Trim() != "")
        {
            objTinhHuong.LuongCoBan5 = decimal.Parse(txtLuongCoBanThang5.Text);
        }     

        if (txtMucDongThang5.Text.Trim() == "")
        {
            _msg = "Bạn chưa nhập mức đóng tháng 5";
            return;
        }
        decimal MucDongThang5 = 0;
        decimal.TryParse(txtMucDongThang5.Text, out MucDongThang5);
        objTinhHuong.MucDong5 = MucDongThang5;

        if (txtThangThu4.Value.Trim() != "")
        {
            objTinhHuong.ThangDong4 = txtThangThu4.Value.Trim();
        }
        if (txtHeSoLuongThang4.Text.Trim() != "")
        {
            objTinhHuong.HeSoLuong4 = float.Parse(txtHeSoLuongThang4.Text);
        }
        if (txtPhuCapThang4.Text.Trim() != "")
        {
            objTinhHuong.HeSoPhuCap4 = float.Parse(txtPhuCapThang4.Text);
        }
        if (txtLuongCoBanThang4.Text.Trim() != "")
        {
            objTinhHuong.LuongCoBan4 = decimal.Parse(txtLuongCoBanThang4.Text);
        } 

        if (txtMucDongThang4.Text.Trim() == "")
        {
            _msg = "Bạn chưa nhập mức đóng tháng 4";
            return;
        }
        decimal MucDongThang4 = 0;
        decimal.TryParse(txtMucDongThang4.Text, out MucDongThang4);
        objTinhHuong.MucDong4=MucDongThang4;

        if (txtThangThu3.Value.Trim() != "")
        {
            objTinhHuong.ThangDong3 = txtThangThu3.Value.Trim();
        }
        if (txtHeSoLuongThang3.Text.Trim() != "")
        {
            objTinhHuong.HeSoLuong3 = float.Parse(txtHeSoLuongThang3.Text);
        }
        if (txtPhuCapThang3.Text.Trim() != "")
        {
            objTinhHuong.HeSoPhuCap3 = float.Parse(txtPhuCapThang3.Text);
        }
        if (txtLuongCoBanThang3.Text.Trim() != "")
        {
            objTinhHuong.LuongCoBan3 = decimal.Parse(txtLuongCoBanThang3.Text);
        } 
        if ( txtMucDongthang3.Text.Trim() == "")
        {
            _msg = "Bạn chưa nhập mức đóng tháng 3";
            return;
        }
        decimal MucDongThang3 = 0;
        decimal.TryParse(txtMucDongthang3.Text, out MucDongThang3);
        objTinhHuong.MucDong3 = MucDongThang3;

        if (txtThangThu2.Value.Trim() != "")
        {
            objTinhHuong.ThangDong2 = txtThangThu2.Value.Trim();
        }
        if ( txtHeSoluongThang2.Text.Trim() != "")
        {
            objTinhHuong.HeSoLuong2 = float.Parse(txtHeSoluongThang2.Text);
        }
        if (txtPhuCapThang2.Text.Trim() != "")
        {
            objTinhHuong.HeSoPhuCap2 = float.Parse(txtPhuCapThang2.Text);
        }
        if (txtLuongCoBanThang2.Text.Trim() != "")
        {
            objTinhHuong.LuongCoBan2 = decimal.Parse(txtLuongCoBanThang2.Text);
        } 

        if (txtMucDongThang2.Text.Trim() == "")
        {
            _msg = "Bạn chưa nhập mức đóng tháng 2";
            return;
        }
        decimal MucDongThang2 = 0;
        decimal.TryParse(txtMucDongThang2.Text, out MucDongThang2);
        objTinhHuong.MucDong2 = MucDongThang2;

        if (txtThangThu1.Value.Trim() != "")
        {
            objTinhHuong.ThangDong1 = txtThangThu1.Value.Trim();
        }
        if ( txtHeSoLuongThang1.Text.Trim() != "")
        {
            objTinhHuong.HeSoLuong1 = float.Parse(txtHeSoLuongThang1.Text);
        }
        if (txtPhuCapThang1.Text.Trim() != "")
        {
            objTinhHuong.HeSoPhuCap1 = float.Parse(txtPhuCapThang1.Text);
        }
        if (txtLuongCoBanThang1.Text.Trim() != "")
        {
            objTinhHuong.LuongCoBan1 = decimal.Parse(txtLuongCoBanThang1.Text);
        } 

        if (txtMucDongThang1.Text.Trim() == "")
        {
            _msg = "Bạn chưa nhập mức đóng tháng 1";
            return;
        }
        decimal MucDongThang1 = 0;
        decimal.TryParse(txtMucDongThang1.Text, out MucDongThang1);
        objTinhHuong.MucDong1 = MucDongThang1;

        if (txtSoThangDongBHXH.Text.Trim() == "")
        {
            _msg = "Bạn chưa nhập số tháng đóng BHXH";
            return;
        }
        objTinhHuong.SoThangDongBHXH = int.Parse(txtSoThangDongBHXH.Text);
        if (txtSoThangHuong.Text.Trim() == "")
        {
            _msg = "Bạn chưa nhập số tháng hưởng BHXH";
            return;
        }
        objTinhHuong.SoThangHuongBHXH = int.Parse(txtSoThangHuong.Text);

        if(txtMucHuongToiDa.Text.Trim()=="")
        {
            _msg="Bạn chưa nhập mức hưởng tối đa";
            return;
        }
        objTinhHuong.MucHuongToiDa = decimal.Parse(txtMucHuongToiDa.Text);
        if (txtNgayDangKyTN.Value.ToString().Trim() == "")
        {
            _msg = "Bạn chưa nhập ngày đăng ký thất nghiệp";
            return;
            // lưu tại bang tro cap that nghiep
        }  
     
        objTinhHuong.LuongTrungBinh = (MucDongThang1 + MucDongThang2 + MucDongThang3 + MucDongThang4 + MucDongThang5 + MucDongThang6) / 6;
        objTinhHuong.LuongTrungBinh = Math.Round(objTinhHuong.LuongTrungBinh, 2);
        objTinhHuong.MucHuong = objTinhHuong.LuongTrungBinh * 60 / 100;
        objTinhHuong.MucHuong = Math.Round(objTinhHuong.MucHuong, 2);
        decimal MucHuongToiDa = 0;
        decimal.TryParse(txtMucHuongToiDa.Text, out MucHuongToiDa);
        if (objTinhHuong.MucHuong > MucHuongToiDa)
        {
            objTinhHuong.MucHuong = MucHuongToiDa;
        }
        txtLuongTrungBinh.Text = objTinhHuong.LuongTrungBinh.ToString();
        txtMucHuong.Text = objTinhHuong.MucHuong.ToString();
       // tinh Han hoan thien     
        DateTime HanHoanThien = TinhNgayNghiLe(ConvertDateimeUS(txtNgayDangKyTN.Value.ToString()), 15);
        DateTime NgayTraKetQua = TinhNgayNghiLe(ConvertDateimeUS(txtNgayDangKyTN.Value.ToString()), 20);
        // tinh huong tu ngay đến ngày
        if(txtSoThangHuong.Text.Trim()=="")
        {
            _msg="Bạn chưa nhập số tháng hưởng";
            return;
        }
        int SoThangHuong= int.Parse(txtSoThangHuong.Text);
        objTinhHuong.HuongTuNgay  = TinhNgayNghiLe(ConvertDateimeUS(txtNgayDangKyTN.Value.ToString()), 16);
        DateTime HuongDenNgay = objTinhHuong.HuongTuNgay;
        for(int i=0;i<SoThangHuong;i++)
        {
            HuongDenNgay = HuongDenNgay.AddMonths(1);   
        }
        txtHuongTuNgay.Value = ConvertDatetimeVn(objTinhHuong.HuongTuNgay);
        txtHuongDenNgay.Value = ConvertDatetimeVn(HuongDenNgay.AddDays(-1));  
        // insert vao du lieu
        objTinhHuong.setData(0, objTinhHuong.IDNguoiLaoDong, objTinhHuong.IDNLDTCTN, objTinhHuong.NgayTao, objTinhHuong.IDVungLuongToiThieu, objTinhHuong.LuongToiThieuVung
            , objTinhHuong.ThangDong1, objTinhHuong.HeSoLuong1, objTinhHuong.HeSoPhuCap1, objTinhHuong.LuongCoBan1, objTinhHuong.MucDong1
            , objTinhHuong.ThangDong2, objTinhHuong.HeSoLuong2, objTinhHuong.HeSoPhuCap2, objTinhHuong.LuongCoBan2, objTinhHuong.MucDong2
            , objTinhHuong.ThangDong3, objTinhHuong.HeSoLuong3, objTinhHuong.HeSoPhuCap3, objTinhHuong.LuongCoBan3, objTinhHuong.MucDong3
            , objTinhHuong.ThangDong4, objTinhHuong.HeSoLuong4, objTinhHuong.HeSoPhuCap4, objTinhHuong.LuongCoBan4, objTinhHuong.MucDong4
            , objTinhHuong.ThangDong5, objTinhHuong.HeSoLuong5, objTinhHuong.HeSoPhuCap5, objTinhHuong.LuongCoBan5, objTinhHuong.MucDong5
            , objTinhHuong.ThangDong6, objTinhHuong.HeSoLuong6, objTinhHuong.HeSoPhuCap6, objTinhHuong.LuongCoBan6, objTinhHuong.MucDong6
            , objTinhHuong.SoThangDongBHXH, objTinhHuong.SoThangHuongBHXH, objTinhHuong.MucHuongToiDa, objTinhHuong.LuongTrungBinh, objTinhHuong.MucHuong
            , objTinhHuong.HuongTuNgay, objTinhHuong.IDNguoiTinh);
        _msg = "Cập nhật thành công. " + objTinhHuong.Message;
 
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
}