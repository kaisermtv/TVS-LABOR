using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Labor_ThongTinChuyenHuongDen : System.Web.UI.Page
{
    #region declare  
    public int itemId = 0;
    public string _msg="";
    private Provincer objProvincer = new Provincer();
    private Ward objWard = new Ward();
    private District objDistrict = new District();
    public DataRow  _Permission;
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
        if (Request.QueryString["ID"] != null && Request.QueryString["ID"].ToString().Trim() != "")
        {
            itemId = int.Parse(Request.QueryString["ID"].ToString());   
        }
                
        if (!Page.IsPostBack)
        {    
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
            if (itemId > 0)
            {
                DataRow rowNLDTroCapThatNghiep = new NLDTroCapThatNghiep().getItem(itemId);
                DataTable tblNguoiLaoDong = new NguoiLaoDong().getDataById(int.Parse(rowNLDTroCapThatNghiep["IDNguoiLaoDong"].ToString()));
                DataTable tblTinhHuong = new TinhHuong().getDataById((int)rowNLDTroCapThatNghiep["IdNLDTCTN"]);
              
                if(tblNguoiLaoDong.Rows.Count>0)
                {
                    //thong tin nguoi lao dong
                    txtHoVaTen.Text = tblNguoiLaoDong.Rows[0]["HoVaTen"].ToString();
                    txtNgaySinh.Value = ((DateTime)tblNguoiLaoDong.Rows[0]["NgaySinh"]).ToString("dd/MM/yyyy");
                    txtCMND.Text = tblNguoiLaoDong.Rows[0]["CMND"].ToString();
                    txtNgayCap.Value = ((DateTime)tblNguoiLaoDong.Rows[0]["NgayCapCMND"]).ToString("dd/MM/yyyy");
                    txtNoiCap.Text = tblNguoiLaoDong.Rows[0]["NoiCap"].ToString();
                    int GioiTinh = 0;
                    GioiTinh = (int)tblNguoiLaoDong.Rows[0]["IDGioiTinh"];
                    if(GioiTinh==1)
                    { chkGioiTinhNam.Checked = true; }
                    if(GioiTinh==2)
                    { chkGioiTinhNu.Checked = true; }
                    txtSoBHXH.Text = tblNguoiLaoDong.Rows[0]["BHXH"].ToString();
                    txtTaiKhoan.Text = tblNguoiLaoDong.Rows[0]["TaiKhoan"].ToString();
                    if (tblNguoiLaoDong.Rows[0]["IDNganHang"] != null && tblNguoiLaoDong.Rows[0]["IDNganHang"].ToString()!="0")
                    {
                        ddlNganHang.SelectedValue = tblNguoiLaoDong.Rows[0]["IDNganHang"].ToString();
                    }
                    ddlTinh_TT.SelectedValue = tblNguoiLaoDong.Rows[0]["Tinh_TT"].ToString();
                    ddlHuyen_TT.SelectedValue = tblNguoiLaoDong.Rows[0]["Huyen_TT"].ToString();
                    ddlXa_TT.SelectedValue = tblNguoiLaoDong.Rows[0]["Xa_TT"].ToString();
                    txtXom_TT.Text = tblNguoiLaoDong.Rows[0]["Xom_TT"].ToString();

                    ddlTinh_DC.SelectedValue = tblNguoiLaoDong.Rows[0]["Tinh_DC"].ToString();
                    ddlHuyen_DC.SelectedValue = tblNguoiLaoDong.Rows[0]["Huyen_DC"].ToString();
                    ddlXa_DC.SelectedValue = tblNguoiLaoDong.Rows[0]["Xa_DC"].ToString();
                    txtXom_DC.Text = tblNguoiLaoDong.Rows[0]["Xom_DC"].ToString(); 
                    // thong tin tro cap that nghiep
                    txtSoThangDongBHXH.Text = rowNLDTroCapThatNghiep["SoThangDongBHXH"].ToString();
                    txtNgayTiepNhan.Value = ((DateTime)rowNLDTroCapThatNghiep["NgayNopHoSo"]).ToString("dd/MM/yyyy");
                    // thong tin tinh huong
                    txtHuongTuNgay.Value = ((DateTime)tblTinhHuong.Rows[0]["HuongTuNgay"]).ToString("dd/MM/yyyy");
                    txtHuongDenNgay.Value = ((DateTime)tblTinhHuong.Rows[0]["HuongDenNgay"]).ToString("dd/MM/yyyy");
                    txtThangThu1.Value = tblTinhHuong.Rows[0]["ThangDong1"].ToString();
                    txtThangThu2.Value = tblTinhHuong.Rows[0]["ThangDong2"].ToString();
                    txtThangThu3.Value = tblTinhHuong.Rows[0]["ThangDong3"].ToString();
                    txtThangThu4.Value = tblTinhHuong.Rows[0]["ThangDong4"].ToString();
                    txtThangThu5.Value = tblTinhHuong.Rows[0]["ThangDong5"].ToString();
                    txtThangThu6.Value = tblTinhHuong.Rows[0]["ThangDong6"].ToString();

                    txtMucDongThang1.Text = Math.Round((decimal)tblTinhHuong.Rows[0]["MucDong1"], 0).ToString();
                    txtMucDongThang2.Text = Math.Round((decimal)tblTinhHuong.Rows[0]["MucDong2"], 0).ToString();
                    txtMucDongthang3.Text = Math.Round((decimal)tblTinhHuong.Rows[0]["MucDong3"], 0).ToString();
                    txtMucDongThang4.Text = Math.Round((decimal)tblTinhHuong.Rows[0]["MucDong4"], 0).ToString();
                    txtMucDongThang5.Text = Math.Round((decimal)tblTinhHuong.Rows[0]["MucDong5"], 0).ToString();
                    txtMucDongThang6.Text = Math.Round((decimal)tblTinhHuong.Rows[0]["MucDong6"], 0).ToString();

                    txtLuongTrungBinh.Text = Math.Round((decimal)tblTinhHuong.Rows[0]["LuongTrungBinh"], 0).ToString();
                    txtMucHuong.Text = Math.Round((decimal)tblTinhHuong.Rows[0]["MucHuong"], 0).ToString();
                    txtSoThangHuong.Text = tblTinhHuong.Rows[0]["SoThangHuongBHXH"].ToString();
                    txtSoThangDaHuong.Text = tblTinhHuong.Rows[0]["SoThangDaHuongBHXH"].ToString();
                    txtSoThangConLai.Text = tblTinhHuong.Rows[0]["SoThangDuocHuongConLaiBHXH"].ToString();
                    txtSoThangBaoLuu.Text = tblTinhHuong.Rows[0]["SothangBaoLuuBHXH"].ToString();          
                    // cap so
                    DataTable tblCapSo = new CapSo().GetByID(itemId, 62);
                    if(tblCapSo.Rows.Count>0)
                    {
                        txtSoGiayGioiThieu.Text = tblCapSo.Rows[0]["SoVanBan"].ToString();
                    }
                    //so quyet dinh
                    DataTable tblSoQuyetDinh = new CapSo().GetByID(itemId, 30);
                    if(tblSoQuyetDinh.Rows.Count>0)
                    {
                        txtSoQuyetDinh.Text = tblSoQuyetDinh.Rows[0]["SoVanBan"].ToString();
                        txtNgayKy.Value = ((DateTime)tblSoQuyetDinh.Rows[0]["NgayKy"]).ToString("dd/MM/yyyy");
                    }
                    
                }
            }
           
        }
     
    }
 
    private void Load_ChuyenHuong(int IDNLDTCTN)
    {
        DataRow tblTroCapThatNghiep = new NLDTroCapThatNghiep().getItem(IDNLDTCTN);
        DataTable tblNguoiLaoDong = new NguoiLaoDong().getDataById((int)tblTroCapThatNghiep["IDNguoiLaoDong"]);
        DataTable tblTinhHuong = new TinhHuong().getDataById(IDNLDTCTN);  

    }
    #endregion
    protected void btnDuyet_Click(object sender, EventArgs e)
    {
      
    }
    protected void btnTraTiepNhan_Click(object sender, EventArgs e)
    {
       
    }
    protected void btnLuu_Click(object sender, EventArgs e)
    {
        #region thong tin nguoi lao dong
        if (txtHoVaTen.Text.Trim() == "")
        {
            _msg = "Bạn chưa nhập họ tên";
            return;
        }
        string HoTen = txtHoVaTen.Text.Trim();
        if (txtNgaySinh.Value.Trim() == "")
        {
            _msg = "Bạn chưa nhập ngày sinh";
            return;
        }
        DateTime NgaySinh = Convert.ToDateTime(txtNgaySinh.Value, new CultureInfo("vi-VN"));
        int GioiTinh = 0;
        if (chkGioiTinhNam.Checked == true)
        {
            GioiTinh = 1;
        }
        else
        {
            if (chkGioiTinhNu.Checked == true)
            {
                GioiTinh = 2;
            }
            else
            {
                _msg = "Bạn chưa chọn giới tính";
                return;
            }
        }
        string Tinh_TT = ddlTinh_TT.SelectedItem.Text.Trim();
        string Huyen_TT = ddlHuyen_TT.SelectedItem.Text.Trim();
        string Xa_TT = ddlXa_TT.SelectedItem.Text.Trim();
        string Xom_TT = txtXom_TT.Text.Trim();
        string Tinh_DC = ddlTinh_DC.SelectedItem.Text.Trim();
        string Huyen_DC = ddlHuyen_DC.SelectedItem.Text.Trim();
        string Xa_DC = ddlXa_DC.SelectedItem.Text.Trim();
        string Xom_DC = txtXom_DC.Text.Trim();
        if (txtCMND.Text.Trim() == "")
        {
            _msg = "Bạn chưa nhập số CMND";
            return;
        }
        string CMND = txtCMND.Text.Trim();
        if (txtNgayCap.Value.Trim() == "")
        {
            _msg = "Bạn chưa chọn ngày cấp";
            return;
        }
        DateTime NgayCap = Convert.ToDateTime(txtNgayCap.Value, new CultureInfo("vi-VN"));
        if (txtNoiCap.Text.Trim() == "")
        {
            _msg = "Bạn chưa chọn nơi cấp";
        }
        string NoiCap = txtNoiCap.Text.Trim();
        if (txtSoBHXH.Text.Trim() == "")
        {
            _msg = "Bạn chưa nhập số sổ BHXH";
            return;
        }
        string SoSoBHXH = txtSoBHXH.Text.Trim();
        int IDNganHang = 0;
        string SoTaiKhoan = txtTaiKhoan.Text;
        if (ddlNganHang.SelectedValue != null && ddlNganHang.SelectedValue.ToString().Trim() != "")
        {
            IDNganHang = int.Parse(ddlNganHang.SelectedValue.ToString());
        }
        #endregion
        if (txtNgayKy.Value.Trim() == "")
        {
            _msg = "Bạn chưa nhập ngày ký";
            return;
        }
        #region thong tin bao hiem that nghiep
        int IDNguoiLaoDong = 0;
        IDNguoiLaoDong = int.Parse(hdIDNguoiLaoDong.Value);
        if (txtNgayTiepNhan.Value.Trim() == "")
        {
            _msg = "Bạn chưa nhập ngày tiếp nhận";
            return;
        }
        DateTime NgayNop = Convert.ToDateTime(txtNgayTiepNhan.Value, new CultureInfo("vi-VN"));
        if (txtSoThangDongBHXH.Text.Trim() == "")
        {
            _msg = "Bạn chưa nhập số tháng đóng BHXH";
            return;
        }
        int SoThangDongBHXH = int.Parse(txtSoThangDongBHXH.Text);
        #endregion

        #region tinh huong
        TinhHuong objTinhHuong = new TinhHuong();
        objTinhHuong.IDNguoiLaoDong = IDNguoiLaoDong;
        objTinhHuong.IDNLDTCTN = int.Parse(hdIDNLDTCTN.Value);

        objTinhHuong.NgayTao = DateTime.Now;
        if (txtThangThu1.Value.Trim() == "")
        {
            _msg = "Bạn chưa khai báo tháng 1";
            return;
        }
        objTinhHuong.ThangDong1 = txtThangThu1.Value;
        if (txtMucDongThang1.Text.Trim() == "")
        {
            _msg = "Bạn chưa nhập mức đóng tháng 1";
            return;
        }
        objTinhHuong.MucDong1 = decimal.Parse(txtMucDongThang1.Text, new CultureInfo("vi-VN"));
        if (txtThangThu2.Value.Trim() == "")
        {
            _msg = "Bạn chưa khai báo tháng thứ 2";
            return;
        }
        objTinhHuong.ThangDong2 = txtThangThu2.Value;
        if (txtMucDongThang2.Text.Trim() == "")
        {
            _msg = "Bạn chưa nhập mức đóng tháng 2";
            return;
        }
        objTinhHuong.MucDong2 = decimal.Parse(txtMucDongThang2.Text, new CultureInfo("vi-VN"));
        if (txtThangThu3.Value.Trim() == "")
        {
            _msg = "Bạn chưa khai báo tháng thứ 3";
            return;
        }
        objTinhHuong.ThangDong3 = txtThangThu3.Value;
        if (txtMucDongthang3.Text.Trim() == "")
        {
            _msg = "Bạn chưa khai báo mức đóng tháng 3";
            return;
        }
        objTinhHuong.MucDong3 = decimal.Parse(txtMucDongthang3.Text, new CultureInfo("vi-VN"));
        if (txtThangThu4.Value.Trim() == "")
        {
            _msg = "Bạn chưa khai báo tháng thứ 4";
            return;
        }
        objTinhHuong.ThangDong4 = txtThangThu4.Value;
        if (txtMucDongThang4.Text.Trim() == "")
        {
            _msg = "Bạn chưa khai báo mức đóng tháng 4";
            return;
        }
        objTinhHuong.MucDong4 = decimal.Parse(txtMucDongThang4.Text, new CultureInfo("vi-VN"));
        if (txtThangThu5.Value.Trim() == "")
        {
            _msg = "Bạn chưa khai báo tháng thứ 5";
            return;
        }
        objTinhHuong.ThangDong5 = txtThangThu5.Value;
        if (txtMucDongThang5.Text.Trim() == "")
        {
            _msg = "Bạn chưa khai báo mức đóng tháng 5";
            return;
        }
        objTinhHuong.MucDong5 = decimal.Parse(txtMucDongThang5.Text, new CultureInfo("vi-VN"));
        if (txtThangThu6.Value.Trim() == "")
        {
            _msg = "Bạn chưa khai báo tháng thứ 6";
            return;
        }
        objTinhHuong.ThangDong6 = txtThangThu6.Value;
        if (txtMucDongThang6.Text.Trim() == "")
        {
            _msg = "Bạn chưa khai báo mức đóng tháng 6";
            return;
        }
        objTinhHuong.MucDong6 = decimal.Parse(txtMucDongThang6.Text, new CultureInfo("vi-VN"));
        if (txtLuongTrungBinh.Text.Trim() == "")
        {
            _msg = "Bạn chưa nhập lương trung bình";
            return;
        }
        objTinhHuong.LuongTrungBinh = decimal.Parse(txtLuongTrungBinh.Text, new CultureInfo("vi-VN"));
        if (txtMucHuong.Text.Trim() == "")
        {
            _msg = "Bạn chưa nhập mức hưởng";
            return;
        }
        objTinhHuong.MucHuong = decimal.Parse(txtMucHuong.Text, new CultureInfo("vi-VN"));
        if (txtSoThangHuong.Text.Trim() == "")
        {
            _msg = "Bạn chưa nhập số tháng hưởng";
            return;
        }
        objTinhHuong.SoThangHuongBHXH = int.Parse(txtSoThangHuong.Text);
        if (txtSoThangDaHuong.Text.Trim() == "")
        {
            _msg = "Bạn nhập số tháng đã hưởng";
            return;
        }
        objTinhHuong.SoThangDaHuongBHXH = int.Parse(txtSoThangDaHuong.Text);
        if (txtSoThangConLai.Text.Trim() == "")
        {
            _msg = "Bạn chưa nhập số tháng được hưởng còn lại ";
            return;
        }
        objTinhHuong.SoThangDuocHuongConLaiBHXH = int.Parse(txtSoThangConLai.Text);
        if (txtSoThangBaoLuu.Text.Trim() == "")
        {
            _msg = "Bạn chưa nhập số tháng bảo lưu";
            return;
        }
        objTinhHuong.SoThangBaoLuuBHXH = int.Parse(txtSoThangBaoLuu.Text);
        if (txtHuongTuNgay.Value.Trim() == "")
        {
            _msg = "Bạn chưa khai báo hưởng từ ngày";
            return;
        }
        objTinhHuong.HuongTuNgay = Convert.ToDateTime(txtHuongTuNgay.Value, new CultureInfo("vi-VN"));
        if (txtHuongDenNgay.Value.Trim() == "")
        {
            _msg = "Bạn chưa khai báo hưởng đến ngày";
            return;
        }
        objTinhHuong.HuongDenNgay = Convert.ToDateTime(txtHuongDenNgay.Value, new CultureInfo("vi-VN"));

        #endregion
        if (hdIDNLDTCTN.Value != null && hdIDNLDTCTN.Value.Trim() != "")
        {
            //insert nguoi lao dong 
            DataSQL objSQL = new DataSQL("TblNguoiLaoDong");
            NguoiLaoDong objNLD = new NguoiLaoDong();
            if (itemId > 0)
            {
                DataRow TCTN = new NLDTroCapThatNghiep().getItem(itemId);
                objSQL["IDNguoiLaoDong"] = (int)TCTN["IdNguoiLaoDong"];
            }
            objSQL["Ma"] = objNLD.getNextMaNLD();
            objSQL["HoVaTen"] = HoTen;
            objSQL["NgaySinh"] = NgaySinh;
            objSQL["IDGioiTinh"] = GioiTinh;
            objSQL["CMND"] = CMND;
            objSQL["NgayCapCMND"] = NgayCap;
            objSQL["NoiCap"] = NoiCap;
            objSQL["BHXH"] = SoSoBHXH;
            objSQL["TaiKhoan"] = SoTaiKhoan;
            objSQL["IDNganHang"] = IDNganHang;
            objSQL["Tinh_TT"] = Tinh_TT;
            objSQL["Huyen_TT"] = Huyen_TT;
            objSQL["Xa_TT"] = Xa_TT;
            objSQL["Xom_TT"] = Xom_TT;
            objSQL["Tinh_DC"] = Tinh_DC;
            objSQL["Huyen_DC"] = Huyen_DC;
            objSQL["Xa_DC"] = Xa_DC;
            objSQL["Xom_DC"] = Xom_DC;
            hdIDNguoiLaoDong.Value = objSQL.setData().ToString();
            //insert tro cap that nghiep 
            if (itemId > 0)
            {
                hdIDNLDTCTN.Value = itemId.ToString();
                new NLDTroCapThatNghiep().Update(itemId,int.Parse(hdIDNguoiLaoDong.Value), NgayNop, SoThangDongBHXH).ToString();
            }
            else
            {
                hdIDNLDTCTN.Value = new NLDTroCapThatNghiep().Insert(int.Parse(hdIDNguoiLaoDong.Value), NgayNop, SoThangDongBHXH).ToString();
            }
                // tinh huong
            objTinhHuong.setData(0, int.Parse(hdIDNguoiLaoDong.Value), int.Parse(hdIDNLDTCTN.Value), objTinhHuong.NgayTao, objTinhHuong.IDVungLuongToiThieu, objTinhHuong.LuongToiThieuVung
            , objTinhHuong.ThangDong1, objTinhHuong.HeSoLuong1, objTinhHuong.HeSoPhuCap1, objTinhHuong.LuongCoBan1, objTinhHuong.MucDong1
            , objTinhHuong.ThangDong2, objTinhHuong.HeSoLuong2, objTinhHuong.HeSoPhuCap2, objTinhHuong.LuongCoBan2, objTinhHuong.MucDong2
            , objTinhHuong.ThangDong3, objTinhHuong.HeSoLuong3, objTinhHuong.HeSoPhuCap3, objTinhHuong.LuongCoBan3, objTinhHuong.MucDong3
            , objTinhHuong.ThangDong4, objTinhHuong.HeSoLuong4, objTinhHuong.HeSoPhuCap4, objTinhHuong.LuongCoBan4, objTinhHuong.MucDong4
            , objTinhHuong.ThangDong5, objTinhHuong.HeSoLuong5, objTinhHuong.HeSoPhuCap5, objTinhHuong.LuongCoBan5, objTinhHuong.MucDong5
            , objTinhHuong.ThangDong6, objTinhHuong.HeSoLuong6, objTinhHuong.HeSoPhuCap6, objTinhHuong.LuongCoBan6, objTinhHuong.MucDong6
            , objTinhHuong.SoThangHuongBHXH, objTinhHuong.SoThangBaoLuuBHXH, objTinhHuong.MucHuong, objTinhHuong.LuongTrungBinh
            , objTinhHuong.MucHuong, objTinhHuong.HuongTuNgay, objTinhHuong.HuongDenNgay, objTinhHuong.IDNguoiTinh, objTinhHuong.SoThangDaHuongBHXH, objTinhHuong.SoThangDuocHuongConLaiBHXH);
            // lich thong bao
            //cap nhat trang thai da tinh huong
            // insert du lieu thong bao viec lam
            LichThongBao objLichThongBao = new LichThongBao();
            List<TempThongBao> lstTemp = new List<TempThongBao>();
            // khoi tao 12 bien thoi gian
            for (int i = 0; i < 12; i++)
            {
                TempThongBao objtemp = new TempThongBao();
                lstTemp.Add(objtemp);
            }
            lstTemp[0].TuNgay = objTinhHuong.HuongTuNgay;
            lstTemp[0].DenNgay = objTinhHuong.HuongDenNgay;
            //Tinh khoang thoi gian huong tung thang
            for (int i = 1; i < objTinhHuong.SoThangHuongBHXH; i++)
            {
                TempThongBao temp = new TempThongBao();
                temp.TuNgay = lstTemp[i - 1].DenNgay.AddDays(1);
                temp.DenNgay = temp.TuNgay.AddMonths(1).AddDays(-1);
                lstTemp[i] = temp;
            }
            // gan gia tri
            DateTime NgayTraKetQua = objTinhHuong.TinhNgayNghiLe(objTinhHuong.HuongTuNgay, 4);
            objLichThongBao.IDNguoiLaoDong = int.Parse(hdIDNguoiLaoDong.Value);
            // lay ma tinh huong sau khi insert
            DataTable tblTinhHuong = new TinhHuong().getDataById(int.Parse(hdIDNLDTCTN.Value));
            objLichThongBao.IDTinhHuong = (int)tblTinhHuong.Rows[0]["IDTinhHuong"];
            objLichThongBao.KhaiBaoThang1TuNgay = NgayTraKetQua;
            objLichThongBao.KhaiBaoThang1DenNgay = NgayTraKetQua;
            objLichThongBao.KhaiBaoThang2TuNgay = objTinhHuong.TinhNgayNghiLe(lstTemp[1].TuNgay, 1);
            objLichThongBao.KhaiBaoThang2DenNgay = objTinhHuong.TinhNgayNghiLe(objLichThongBao.KhaiBaoThang2TuNgay, 2);
            objLichThongBao.KhaiBaoThang3TuNgay = objTinhHuong.TinhNgayNghiLe(lstTemp[2].TuNgay, 1);
            objLichThongBao.KhaiBaoThang3DenNgay = objTinhHuong.TinhNgayNghiLe(objLichThongBao.KhaiBaoThang3TuNgay, 2);
            objLichThongBao.KhaiBaoThang4TuNgay = objTinhHuong.TinhNgayNghiLe(lstTemp[3].TuNgay, 1);
            objLichThongBao.KhaiBaoThang4DenNgay = objTinhHuong.TinhNgayNghiLe(objLichThongBao.KhaiBaoThang4TuNgay, 2);
            objLichThongBao.KhaiBaoThang5TuNgay = objTinhHuong.TinhNgayNghiLe(lstTemp[4].TuNgay, 1);
            objLichThongBao.KhaiBaoThang5DenNgay = objTinhHuong.TinhNgayNghiLe(objLichThongBao.KhaiBaoThang5TuNgay, 2);
            objLichThongBao.KhaiBaoThang6TuNgay = objTinhHuong.TinhNgayNghiLe(lstTemp[5].TuNgay, 1);
            objLichThongBao.KhaiBaoThang6DenNgay = objTinhHuong.TinhNgayNghiLe(objLichThongBao.KhaiBaoThang6TuNgay, 2);
            objLichThongBao.KhaiBaoThang7TuNgay = objTinhHuong.TinhNgayNghiLe(lstTemp[6].TuNgay, 1);
            objLichThongBao.KhaiBaoThang7DenNgay = objTinhHuong.TinhNgayNghiLe(objLichThongBao.KhaiBaoThang7TuNgay, 2);
            objLichThongBao.KhaiBaoThang8TuNgay = objTinhHuong.TinhNgayNghiLe(lstTemp[7].TuNgay, 1);
            objLichThongBao.KhaiBaoThang8DenNgay = objTinhHuong.TinhNgayNghiLe(objLichThongBao.KhaiBaoThang8TuNgay, 2);
            objLichThongBao.KhaiBaoThang9TuNgay = objTinhHuong.TinhNgayNghiLe(lstTemp[8].TuNgay, 1);
            objLichThongBao.KhaiBaoThang9DenNgay = objTinhHuong.TinhNgayNghiLe(objLichThongBao.KhaiBaoThang8TuNgay, 2);
            objLichThongBao.KhaiBaoThang10TuNgay = objTinhHuong.TinhNgayNghiLe(lstTemp[9].TuNgay, 1);
            objLichThongBao.KhaiBaoThang10DenNgay = objTinhHuong.TinhNgayNghiLe(objLichThongBao.KhaiBaoThang10TuNgay, 2);
            objLichThongBao.KhaiBaoThang11TuNgay = objTinhHuong.TinhNgayNghiLe(lstTemp[10].TuNgay, 1);
            objLichThongBao.KhaiBaoThang11DenNgay = objTinhHuong.TinhNgayNghiLe(objLichThongBao.KhaiBaoThang11TuNgay, 2);
            objLichThongBao.KhaiBaoThang12TuNgay = objTinhHuong.TinhNgayNghiLe(lstTemp[11].TuNgay, 1);
            objLichThongBao.KhaiBaoThang12DenNgay = objTinhHuong.TinhNgayNghiLe(objLichThongBao.KhaiBaoThang12TuNgay, 2);

            objLichThongBao.setData(objLichThongBao.IDLichThongBao, objLichThongBao.IDNguoiLaoDong, objLichThongBao.IDTinhHuong
           , objLichThongBao.KhaiBaoThang1TuNgay, objLichThongBao.KhaiBaoThang1DenNgay
           , objLichThongBao.KhaiBaoThang2TuNgay, objLichThongBao.KhaiBaoThang2DenNgay
           , objLichThongBao.KhaiBaoThang3TuNgay, objLichThongBao.KhaiBaoThang3DenNgay
           , objLichThongBao.KhaiBaoThang4TuNgay, objLichThongBao.KhaiBaoThang4DenNgay
           , objLichThongBao.KhaiBaoThang5TuNgay, objLichThongBao.KhaiBaoThang5DenNgay
           , objLichThongBao.KhaiBaoThang6TuNgay, objLichThongBao.KhaiBaoThang6DenNgay
           , objLichThongBao.KhaiBaoThang7TuNgay, objLichThongBao.KhaiBaoThang7DenNgay
           , objLichThongBao.KhaiBaoThang8TuNgay, objLichThongBao.KhaiBaoThang8DenNgay
           , objLichThongBao.KhaiBaoThang9TuNgay, objLichThongBao.KhaiBaoThang9DenNgay
           , objLichThongBao.KhaiBaoThang10TuNgay, objLichThongBao.KhaiBaoThang10DenNgay
           , objLichThongBao.KhaiBaoThang11TuNgay, objLichThongBao.KhaiBaoThang11DenNgay
           , objLichThongBao.KhaiBaoThang12TuNgay, objLichThongBao.KhaiBaoThang12DenNgay);
            objTinhHuong.UpdateTrangThaiHS(int.Parse(hdIDNLDTCTN.Value), 47);
            // Insert Giay gioi thieu
            if (txtSoGiayGioiThieu.Text.Trim() == "")
            {
                _msg = "Bạn chưa nhập số giấy giới thiệu";
                return;
            }
            CapSo objCapSo = new CapSo();
            objCapSo.IDLoaiVanBan = 62;
            objCapSo.NgayCap = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            objCapSo.SoVanBan = txtSoGiayGioiThieu.Text.Trim();
            objCapSo.So = 0;
            objCapSo.Nam = DateTime.Now.Year.ToString();
            objCapSo.IDNLDTCTN = int.Parse(hdIDNLDTCTN.Value);
            if (new CapSo().CheckAutoNumber(objCapSo.NgayCap, 62, objCapSo.SoVanBan) == true)
            {
                _msg = "Số giấy giới thiệu đã có";
                return;
            }
            objCapSo.SetData(objCapSo.NgayCap, objCapSo.SoVanBan, objCapSo.IDNLDTCTN, objCapSo.IDLoaiVanBan, objCapSo.Nam, DateTime.Now, 0);
            // Insert quyet dinh huong
            CapSo objQuyetDinhTCTN = new CapSo();
            objQuyetDinhTCTN.IDLoaiVanBan = 30;
            objQuyetDinhTCTN.NgayCap = Convert.ToDateTime(txtNgayKy.Value, new CultureInfo("vi-VN"));
            objQuyetDinhTCTN.SoVanBan = txtSoQuyetDinh.Text.Trim();
            objQuyetDinhTCTN.So = 0;
            objQuyetDinhTCTN.Nam = DateTime.Now.Year.ToString();
            objQuyetDinhTCTN.IDNLDTCTN = int.Parse(hdIDNLDTCTN.Value);
            DateTime NgayKy = Convert.ToDateTime(txtNgayKy.Value, new CultureInfo("vi-VN"));
            if (new CapSo().CheckAutoNumber(objQuyetDinhTCTN.NgayCap, 30, objQuyetDinhTCTN.SoVanBan) == true)
            {
                _msg = "Số quyết định đã tồn tại";
                return;
            }
            objQuyetDinhTCTN.SetData(objQuyetDinhTCTN.NgayCap, objQuyetDinhTCTN.SoVanBan, objQuyetDinhTCTN.IDNLDTCTN, objQuyetDinhTCTN.IDLoaiVanBan, objQuyetDinhTCTN.Nam, NgayKy, 0);
            Response.Redirect("DanhSachChuyenHuongDen.aspx");
        }
    }
    protected void btnInGiayGioiThieu_ServerClick(object sender, EventArgs e)
    {
  

    }
}