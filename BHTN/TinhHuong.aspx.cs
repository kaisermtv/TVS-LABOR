using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Labor_TinhHuong : System.Web.UI.Page
{
    #region declare  
    public int itemId = 0;
    public string _msg="";
    public int _status = 0; // 0 trang thai tinh huong  3 trang thai xem chi tiet theo doi lich thong bao
    #endregion

    #region Even Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ACCOUNT"] == null)
        {
            Response.Redirect("../Login.aspx");
        }
        if (Request.QueryString["id"] != null && Request.QueryString["id"].ToString().Trim() != "")
        {
            itemId= int.Parse(Request["id"].ToString());
        }
        if (Request.QueryString["status"] != null && Request.QueryString["status"].ToString().Trim() != "")
        {
            _status = int.Parse(Request["status"].ToString());
        }
        if (!Page.IsPostBack)
        {
            if(_status==3)
            {
                 Load_CauHinhTinhHuong(false);
                 Load_CauHinhTraKetQua(true);
            }
            if(_status==0)
            {
                Load_CauHinhTinhHuong(true);
                Load_CauHinhTraKetQua(false);
            }

            LuongToiThieuVung();
            if(itemId>0)
            {              
                DataRow rowTroCapThatNghiep = new NLDTroCapThatNghiep().getItem(itemId);
                DataTable tblNguoiLaoDong = new NguoiLaoDong().getDataById((int)rowTroCapThatNghiep["IDNguoiLaoDong"]);
                if(tblNguoiLaoDong.Rows.Count>0)
                {
                   txtHoVaTen.Text = tblNguoiLaoDong.Rows[0]["HoVaTen"].ToString();
                   hdIDNguoiLaoDong.Value = tblNguoiLaoDong.Rows[0]["IDNguoiLaoDong"].ToString();
                    txtNgaySinh.Value = ((DateTime)tblNguoiLaoDong.Rows[0]["NgaySinh"]).ToString("dd/MM/yyyy");
                    if(tblNguoiLaoDong.Rows[0]["IdGioiTinh"].ToString().Trim()=="0")
                    {
                        chkGioiTinhNu.Checked = true;
                        chkGioiTinhNam.Checked=false;
                    }
                    else {
                        chkGioiTinhNam.Checked = true;
                        chkGioiTinhNu.Checked = false;
                    }
                    txtCMND.Text = tblNguoiLaoDong.Rows[0]["CMND"].ToString();
                    // Noi Cap CMND   
                    txtNoiCap.Text = tblNguoiLaoDong.Rows[0]["NoiCap"].ToString();

                    if (tblNguoiLaoDong.Rows[0]["NgayCapCMND"].ToString().Trim()!="" && ((DateTime)tblNguoiLaoDong.Rows[0]["NgayCapCMND"]).ToString("yyyy") != "1900")
                    {
                        txtNgayCap.Value = ((DateTime)tblNguoiLaoDong.Rows[0]["NgayCapCMND"]).ToString("dd/MM/yyyy");
                    }
                    txtSoBHXH.Text = tblNguoiLaoDong.Rows[0]["BHXH"].ToString();
                    txtSoDienThoai.Text = tblNguoiLaoDong.Rows[0]["DienThoai"].ToString();
                    // noi truong tru
                    string thuongtru = "";
                    thuongtru += tblNguoiLaoDong.Rows[0]["Xom_TT"].ToString() + ", ";
                    thuongtru += tblNguoiLaoDong.Rows[0]["Xa_TT"].ToString() + ", ";
                    thuongtru += tblNguoiLaoDong.Rows[0]["Huyen_TT"].ToString() + ", ";
                    thuongtru += tblNguoiLaoDong.Rows[0]["Tinh_TT"].ToString();
                    txtNoiThuongTru.Text = thuongtru;
                    string choohientai = "";
                    choohientai += tblNguoiLaoDong.Rows[0]["Xom_DC"].ToString() + ", ";
                    choohientai += tblNguoiLaoDong.Rows[0]["Xa_DC"].ToString() + ", ";
                    choohientai += tblNguoiLaoDong.Rows[0]["Huyen_DC"].ToString() + ", ";
                    choohientai += tblNguoiLaoDong.Rows[0]["Tinh_DC"].ToString();
                    txtChoOHienTai.Text = choohientai;
                    txtSoThangDongBHXH.Text = rowTroCapThatNghiep["SoThangDongBHXH"].ToString();
                    if (rowTroCapThatNghiep["NgayNghiViec"] != null && rowTroCapThatNghiep["NgayNghiViec"].ToString()!="")
                    {
                        txtNgayNghiViec.Value = ((DateTime)rowTroCapThatNghiep["NgayNghiViec"]).ToString("dd/MM/yyyy");
                    }
                    if (rowTroCapThatNghiep["NgayNopHoSo"] != null && rowTroCapThatNghiep["NgayNopHoSo"].ToString() != "")
                    {
                        DateTime NgayNopHoSo = (DateTime)rowTroCapThatNghiep["NgayNopHoSo"];
                        txtNgayNopHoSo.Value = NgayNopHoSo.ToString("dd/MM/yyyy");
                        lblNgayDangKy.Text = ((DateTime)rowTroCapThatNghiep["NgayNopHoSo"]).ToString("dd/MM/yyyy");               
                    }
                }
                DataTable tblTinhHuong = new TinhHuong().getDataById(itemId);
                if(tblTinhHuong.Rows.Count>0)
                {
                    ddlLuongToiThieu.SelectedValue = Math.Round((decimal)tblTinhHuong.Rows[0]["LuongToiThieuVung"], 0).ToString();
                    txtThangThu1.Value = tblTinhHuong.Rows[0]["ThangDong1"].ToString();
                    txtMucDongThang1.Text = Math.Round((decimal)tblTinhHuong.Rows[0]["MucDong1"],0).ToString();                  
                    txtThangThu2.Value = tblTinhHuong.Rows[0]["ThangDong2"].ToString();
                    txtMucDongThang2.Text = Math.Round((decimal)tblTinhHuong.Rows[0]["MucDong2"], 0).ToString();
                    txtThangThu3.Value = tblTinhHuong.Rows[0]["ThangDong3"].ToString();
                    txtMucDongthang3.Text = Math.Round((decimal)tblTinhHuong.Rows[0]["MucDong3"], 0).ToString();
                    txtThangThu4.Value = tblTinhHuong.Rows[0]["ThangDong4"].ToString();
                    txtMucDongThang4.Text = Math.Round((decimal)tblTinhHuong.Rows[0]["MucDong4"], 0).ToString();
                    txtThangThu5.Value = tblTinhHuong.Rows[0]["ThangDong5"].ToString();
                    txtMucDongThang5.Text = Math.Round((decimal)tblTinhHuong.Rows[0]["MucDong5"], 0).ToString();
                    txtThangThu6.Value = tblTinhHuong.Rows[0]["ThangDong6"].ToString();
                    txtMucDongThang6.Text = Math.Round((decimal)tblTinhHuong.Rows[0]["MucDong6"], 0).ToString();            
                    int SoThangHuong = (int)tblTinhHuong.Rows[0]["SoThangHuongBHXH"];
                    txtSoThangHuong.Text = SoThangHuong.ToString();
                    txtMucHuongToiDa.Text = Math.Round((decimal)tblTinhHuong.Rows[0]["MucHuongToiDa"], 0).ToString();
                    txtLuongTrungBinh.Text = Math.Round((decimal)tblTinhHuong.Rows[0]["LuongTrungBinh"], 0).ToString();
                    txtMucHuong.Text = Math.Round((decimal)tblTinhHuong.Rows[0]["MucHuong"], 0).ToString();
                    txtSoThangBaoLuu.Text = tblTinhHuong.Rows[0]["SoThangBaoLuuBHXH"].ToString();
                    txtHuongTuNgay.Value=  ((DateTime)tblTinhHuong.Rows[0]["HuongTuNgay"]).ToString("dd/MM/yyyy");
                    txtHuongDenNgay.Value = ((DateTime)tblTinhHuong.Rows[0]["HuongDenNgay"]).ToString("dd/MM/yyyy");
                    //
                }

            }         
 
        }
     
    }
    #endregion
    #region Load luong toi thieu vung
    private void LuongToiThieuVung()
    {
        DataTable tblLuongToiThieu = new DanhMuc().getList(19);
        if (tblLuongToiThieu != null && tblLuongToiThieu.Rows.Count > 0)
        {
            DataRow Row = tblLuongToiThieu.NewRow();
            Row["Note"] = "0";
            Row["NameDanhMuc"] = "Chọn vùng lương tối thiểu";
            tblLuongToiThieu.Rows.InsertAt(Row, 0);
            ddlLuongToiThieu.DataValueField = "Note";
            ddlLuongToiThieu.DataTextField = "NameDanhMuc";
            ddlLuongToiThieu.DataSource = tblLuongToiThieu;
            ddlLuongToiThieu.DataBind();
        }
    }

    #endregion 
    #region Tinh huong
    protected void btnTinhHuong_Click(object sender, EventArgs e)
    {
        TinhHuong objTinhHuong = new TinhHuong();
        objTinhHuong.NgayTao = DateTime.Now;
        if (itemId <= 0)
        {
            _msg = "Hồ sơ trợ cấp thất nghiệp chưa được tạo";
            return;
        }
        objTinhHuong.IDNLDTCTN = itemId;
        if (hdIDNguoiLaoDong.Value.ToString().Trim() == "")
        {
            _msg = "Hồ sơ người lao động chưa được khởi tạo";
            return;
        }
        objTinhHuong.IDNguoiLaoDong = int.Parse(hdIDNguoiLaoDong.Value);
        // lay ID luong toi thieu
        if (ddlLuongToiThieu.SelectedValue == null || ddlLuongToiThieu.SelectedValue.ToString().Trim() == "0")
        {
            _msg = "Bạn chưa chọn lương tối thiểu vùng";
            return;
        }
        DataTable tblLuongToiThieu = objTinhHuong.GetLuongToiThieuByTienLuong(ddlLuongToiThieu.SelectedValue.ToString().Trim());
        if (tblLuongToiThieu == null || tblLuongToiThieu.Rows.Count == 0)
        {
            _msg = "Bạn chưa chọn lương tối thiểu vùng";
            return;
        }
        objTinhHuong.IDVungLuongToiThieu = (int)tblLuongToiThieu.Rows[0]["idDanhMuc"];
        objTinhHuong.LuongToiThieuVung = decimal.Parse(tblLuongToiThieu.Rows[0]["Note"].ToString());

        if (txtThangThu6.Value.Trim() != "")
        {
            objTinhHuong.ThangDong6 = txtThangThu6.Value.Trim();
        }
        if (txtMucDongThang6.Text.Trim() == "")
        {
            _msg = "Bạn chưa nhập mức đóng tháng 6";
            return;
        }
        objTinhHuong.MucDong6 = decimal.Parse(txtMucDongThang6.Text, new CultureInfo("vi-VN"));

        if (txtThangThu5.Value.Trim() != "")
        {
            objTinhHuong.ThangDong5 = txtThangThu5.Value.Trim();
        }

        if (txtMucDongThang5.Text.Trim() == "")
        {
            _msg = "Bạn chưa nhập mức đóng tháng 5";
            return;
        }

        objTinhHuong.MucDong5 = decimal.Parse(txtMucDongThang5.Text, new CultureInfo("vi-VN"));

        if (txtThangThu4.Value.Trim() != "")
        {
            objTinhHuong.ThangDong4 = txtThangThu4.Value.Trim();
        }

        if (txtMucDongThang4.Text.Trim() == "")
        {
            _msg = "Bạn chưa nhập mức đóng tháng 4";
            return;
        }

        objTinhHuong.MucDong4 = decimal.Parse(txtMucDongThang4.Text, new CultureInfo("vi-VN"));

        if (txtThangThu3.Value.Trim() != "")
        {
            objTinhHuong.ThangDong3 = txtThangThu3.Value.Trim();
        }
        if (txtMucDongthang3.Text.Trim() == "")
        {
            _msg = "Bạn chưa nhập mức đóng tháng 3";
            return;
        }

        objTinhHuong.MucDong3 = decimal.Parse(txtMucDongthang3.Text, new CultureInfo("vi-VN"));

        if (txtThangThu2.Value.Trim() != "")
        {
            objTinhHuong.ThangDong2 = txtThangThu2.Value.Trim();
        }

        if (txtMucDongThang2.Text.Trim() == "")
        {
            _msg = "Bạn chưa nhập mức đóng tháng 2";
            return;
        }
        objTinhHuong.MucDong2 = decimal.Parse(txtMucDongThang2.Text, new CultureInfo("vi-VN"));

        if (txtThangThu1.Value.Trim() != "")
        {
            objTinhHuong.ThangDong1 = txtThangThu1.Value.Trim();
        }

        if (txtMucDongThang1.Text.Trim() == "")
        {
            _msg = "Bạn chưa nhập mức đóng tháng 1";
            return;
        }
        objTinhHuong.MucDong1 = decimal.Parse(txtMucDongThang1.Text, new CultureInfo("vi-VN"));
        if (txtSoThangDongBHXH.Text.Trim() == "")
        {
            _msg = "Chưa có số tháng đóng BHXH";
            return;
        }

        if (txtSoThangHuong.Text.Trim() == "")
        {
            _msg = "Bạn chưa nhập số tháng hưởng BHXH";
            return;
        }
        objTinhHuong.SoThangHuongBHXH = int.Parse(txtSoThangHuong.Text);
        if (txtSoThangBaoLuu.Text.Trim() != "")
        {
            objTinhHuong.SoThangBaoLuuBHXH = int.Parse(txtSoThangBaoLuu.Text);
        }

        if (txtMucHuongToiDa.Text.Trim() == "")
        {
            _msg = "Bạn chưa nhập mức hưởng tối đa";
            return;
        }
        objTinhHuong.MucHuongToiDa = decimal.Parse(txtMucHuongToiDa.Text, new CultureInfo("vi-VN"));
        if ( txtNgayNopHoSo.Value.ToString().Trim() == "")
        {
            _msg = "Ngày nộp hồ sơ không hợp lệ";
            return;
            // lưu tại bang tro cap that nghiep
        }
        objTinhHuong.LuongTrungBinh = (objTinhHuong.MucDong1 + objTinhHuong.MucDong2 + objTinhHuong.MucDong3 + objTinhHuong.MucDong4 + objTinhHuong.MucDong5 + objTinhHuong.MucDong6) / 6;
        objTinhHuong.LuongTrungBinh = Math.Round(objTinhHuong.LuongTrungBinh, 2);
        objTinhHuong.MucHuong = objTinhHuong.LuongTrungBinh * 60 / 100;
        objTinhHuong.MucHuong = Math.Round(objTinhHuong.MucHuong, 2);
        objTinhHuong.MucHuongToiDa = decimal.Parse(txtMucHuongToiDa.Text, new CultureInfo("vi-VN"));
        if (objTinhHuong.MucHuong > objTinhHuong.MucHuongToiDa)
        {
            objTinhHuong.MucHuong = objTinhHuong.MucHuongToiDa;
        }
        txtLuongTrungBinh.Text = objTinhHuong.LuongTrungBinh.ToString();
        txtMucHuong.Text = objTinhHuong.MucHuong.ToString();
        // tinh Han hoan thien     
        DateTime HanHoanThien = objTinhHuong.TinhNgayNghiLe(ConvertDateimeUS(txtNgayNopHoSo.Value.ToString()), 15);
        //_HanHoanThien = HanHoanThien.ToString("dd/MM/yyyy");
        DateTime NgayTraKetQua = objTinhHuong.TinhNgayNghiLe(ConvertDateimeUS(txtNgayNopHoSo.Value.ToString()), 20);
        // _NgayTraQuyetDinh = NgayTraKetQua.ToString("dd/MM/yyyy");
        // tinh huong tu ngay đến ngày
        if (txtSoThangHuong.Text.Trim() == "")
        {
            _msg = "Bạn chưa nhập số tháng hưởng";
            return;
        }
        int SoThangHuong = int.Parse(txtSoThangHuong.Text);
        objTinhHuong.HuongTuNgay = objTinhHuong.TinhNgayNghiLe(ConvertDateimeUS(txtNgayNopHoSo.Value.ToString()), 16);
        objTinhHuong.HuongDenNgay = objTinhHuong.HuongTuNgay;
        for (int i = 0; i < SoThangHuong; i++)
        {
            objTinhHuong.HuongDenNgay = objTinhHuong.HuongDenNgay.AddMonths(1);
        }
        objTinhHuong.HuongDenNgay = objTinhHuong.HuongDenNgay.AddDays(-1);
        txtHuongTuNgay.Value = ConvertDatetimeVn(objTinhHuong.HuongTuNgay);
        txtHuongDenNgay.Value = ConvertDatetimeVn(objTinhHuong.HuongDenNgay);
        //insert vao du lieu vao bang tinh huong
        objTinhHuong.setData(0, objTinhHuong.IDNguoiLaoDong, objTinhHuong.IDNLDTCTN, objTinhHuong.NgayTao, objTinhHuong.IDVungLuongToiThieu, objTinhHuong.LuongToiThieuVung
            , objTinhHuong.ThangDong1, objTinhHuong.HeSoLuong1, objTinhHuong.HeSoPhuCap1, objTinhHuong.LuongCoBan1, objTinhHuong.MucDong1
            , objTinhHuong.ThangDong2, objTinhHuong.HeSoLuong2, objTinhHuong.HeSoPhuCap2, objTinhHuong.LuongCoBan2, objTinhHuong.MucDong2
            , objTinhHuong.ThangDong3, objTinhHuong.HeSoLuong3, objTinhHuong.HeSoPhuCap3, objTinhHuong.LuongCoBan3, objTinhHuong.MucDong3
            , objTinhHuong.ThangDong4, objTinhHuong.HeSoLuong4, objTinhHuong.HeSoPhuCap4, objTinhHuong.LuongCoBan4, objTinhHuong.MucDong4
            , objTinhHuong.ThangDong5, objTinhHuong.HeSoLuong5, objTinhHuong.HeSoPhuCap5, objTinhHuong.LuongCoBan5, objTinhHuong.MucDong5
            , objTinhHuong.ThangDong6, objTinhHuong.HeSoLuong6, objTinhHuong.HeSoPhuCap6, objTinhHuong.LuongCoBan6, objTinhHuong.MucDong6
           , objTinhHuong.SoThangHuongBHXH, objTinhHuong.SoThangBaoLuuBHXH, objTinhHuong.MucHuongToiDa, objTinhHuong.LuongTrungBinh, objTinhHuong.MucHuong
            , objTinhHuong.HuongTuNgay, objTinhHuong.HuongDenNgay, objTinhHuong.IDNguoiTinh);
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
        lstTemp[0].DenNgay = lstTemp[0].TuNgay.AddMonths(1).AddDays(-1); 
        //Tinh khoang thoi gian huong tung thang
        for (int i = 1; i < SoThangHuong; i++)
        {
            TempThongBao temp = new TempThongBao();
            temp.TuNgay = lstTemp[i - 1].DenNgay.AddDays(1);
            temp.DenNgay = temp.TuNgay.AddMonths(1).AddDays(-1);
            lstTemp[i] = temp;
        }
        // gan gia tri
        objLichThongBao.IDNguoiLaoDong = int.Parse(hdIDNguoiLaoDong.Value);
        // lay ma tinh huong sau khi insert
        DataTable tblTinhHuong = new TinhHuong().getDataById(itemId);
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
        objTinhHuong.UpdateTrangThaiHS(itemId, 3);
        Response.Redirect(Page.Request.Url.ToString(), true);
        _msg = "Cập nhật thành công. " + objTinhHuong.Message;


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
   
    #endregion    
    #region Even Phieu tinh huong
    protected void Unnamed_ServerClick(object sender, EventArgs e)
    {
        if (itemId != 0)
        {
            DataTable tblTinhHuong = new TinhHuong().getDataById(itemId);
            DataTable TblNguoiLaoDong = new NguoiLaoDong().getDataById(int.Parse(hdIDNguoiLaoDong.Value));
            DataRow rowTroCapThatNghiep = new NLDTroCapThatNghiep().getItem(itemId);
            if(TblNguoiLaoDong==null || TblNguoiLaoDong.Rows.Count ==0)
            {
                _msg="Người lao động chưa được khởi tạo";
                return;
            }
            if (tblTinhHuong == null || tblTinhHuong.Rows.Count == 0)
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
            lstInput.Add("[SoThangDong]");
            lstOutput.Add(rowTroCapThatNghiep["SoThangDongBHXH"].ToString());
            lstInput.Add("[DongTuThang]");
            lstOutput.Add(tblTinhHuong.Rows[0]["HuongTungay"].ToString());
            lstInput.Add("[DongDenThang]");
            lstOutput.Add(tblTinhHuong.Rows[0]["HuongDenNgay"].ToString());
            for (int i = 1; i <=6; i++)
            {
                lstInput.Add("[Thang" + i.ToString() + "]");
                lstOutput.Add(i.ToString());
                lstInput.Add("[TienThang" + i.ToString() + "]");
                lstOutput.Add(tblTinhHuong.Rows[0]["MucDong"+i.ToString()].ToString());
            }

            lstInput.Add("[MucDongTB]");
            lstOutput.Add(tblTinhHuong.Rows[0]["LuongTrungBinh"].ToString());
            lstInput.Add("[MucHuong]");
            lstOutput.Add(tblTinhHuong.Rows[0]["MucHuong"].ToString());        
            lstInput.Add("[SoThangHuong]");
            lstOutput.Add(tblTinhHuong.Rows[0]["SoThangHuongBHXH"].ToString());
            lstInput.Add("[TongTienHuong]");
            decimal MucHuong=0,SoThangHuong=0,TongTienHuong=0;
            MucHuong = decimal.Parse( tblTinhHuong.Rows[0]["MucHuong"].ToString());
            SoThangHuong = decimal.Parse( tblTinhHuong.Rows[0]["SoThangHuongBHXH"].ToString());
            TongTienHuong=MucHuong *SoThangHuong;
            lstOutput.Add(TongTienHuong.ToString());
            lstInput.Add("[SoThangBaoLuu]");
            lstOutput.Add(tblTinhHuong.Rows[0]["SoThangBaoLuuBHXH"].ToString());
            lstInput.Add("[NgayTinhHuong]");
            lstOutput.Add(((DateTime)tblTinhHuong.Rows[0]["HuongTuNgay"]).ToString("dd/MM/yyyy"));
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
      
    }
    #endregion

    protected void btnChuyenThamDinh_Click(object sender, EventArgs e)
    {   
        // kiem tra xem da luu Id tinh huong chua
        TinhHuong objTinhHuong = new TinhHuong();
        DataTable tblTinhHuong = new DataTable();
        tblTinhHuong = objTinhHuong.getDataById(itemId);
        if(tblTinhHuong.Rows.Count==0 )
        {
            _msg = "Bạn chưa lưu thông tin tính hưởng";
            return;        
        }
      
        objTinhHuong.UpdateTrangThaiHS(itemId, 6);
        Response.Redirect("DanhSachTinhHuong.aspx");
    }
 
    protected void btnChuyenTraHoSo_Click(object sender, EventArgs e)
    {
        TinhHuong objTinhHuong = new TinhHuong();
        objTinhHuong.UpdateTrangThaiHS(itemId, 1);
        Response.Redirect("DanhSachTinhHuong.aspx");
    }
    private void Load_CauHinhTinhHuong(bool status)
    {
        btnTinhHuong.Visible = status;
        btnChuyenThamDinh.Visible = status;
        btnChuyenTraHoSo.Visible = status;
    }
    private void Load_CauHinhTraKetQua(bool status)
    {
        btnTraQuyetDinh.Visible = status;    
    }
    protected void btnTraQuyetDinh_Click(object sender, EventArgs e)
    {
       if(_status==3)
       {
           DataRow tblTCTN = new NLDTroCapThatNghiep().getItem(itemId);
           if((int)tblTCTN["idTrangThai"]==11)
           {
               new TinhHuong().UpdateTrangThaiHS(itemId, 12);
           }
           else
           {
               _msg = "Lỗi trong quá trình trả kết quả";
               return;
           }
           Response.Redirect("DanhSachTraKetQua.aspx");
       }
    }
    protected void btnHuyHuong_Click(object sender, EventArgs e)
    {
        if (_status == 3)
        {
            DataRow tblTCTN = new NLDTroCapThatNghiep().getItem(itemId);
            if ((int)tblTCTN["idTrangThai"] == 11)
            {
                new TinhHuong().UpdateTrangThaiHS(itemId, 13);
            }
            else
            {
                _msg = "Lỗi trong quá trình hủy hưởng";
                return;
            }
            Response.Redirect("DanhSachTraKetQua.aspx");
        }
    }
}