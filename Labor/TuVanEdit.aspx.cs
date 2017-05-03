using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_TuVanEdit : System.Web.UI.Page
{
    #region declare objects
    private int IDNldTuVan = 0, IDNguoiLaoDong = 0, IDNldDangKy = 0;
    private Account objAccount = new Account();
    private NguoiLaoDong objNguoiLaoDong = new NguoiLaoDong();
    private XuatKhauLaoDong objXuatKhauLaoDong = new XuatKhauLaoDong();
    private GioiTinh objGioiTinh = new GioiTinh();
    private DanToc objDanToc = new DanToc();
    private TonGiao objTonGiao = new TonGiao();
    private NgoaiNgu objNgoaiNgu = new NgoaiNgu();
    private TuyenDung objTuyenDung = new TuyenDung();
    private TrinhDoPhoThong objTrinhDoPhoThong = new TrinhDoPhoThong();
    private TinHoc objTinHoc = new TinHoc();

    
    private Provincer objProvincer = new Provincer();
    private District objDistrict = new District();
    private Ward objWard = new Ward();

    private DataTable objTable = new DataTable();
    private DataTable objTableNldTuVan = new DataTable();
    private bool View = false, Add = false, Edit = false, Del = false, Orther = false;
    public string strBtnViecLamTrongNuoc = "", strBtnViecLamNgoai = "";

    public List<string> lv_Vitri = new List<string>();
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ACCOUNT"] == null)
        {
            Response.Redirect("../Login.aspx");
        }
        Session["TITLE"] = "TƯ VẤN NGƯỜI LAO ĐỘNG";

        try
        {
           foreach(DataRow row in new ViTri().getList().Rows)
           {
               lv_Vitri.Add(row["NameVitri"].ToString());
           }
        }
        catch
        {
        }

        try
        {
            this.IDNldTuVan = int.Parse(Request["id"].ToString());
        }
        catch
        {
            this.IDNldTuVan = 0;
        }
        try
        {
            this.IDNguoiLaoDong = int.Parse(Request["idNld"].ToString());
        }
        catch
        {
            this.IDNguoiLaoDong = 0;
        }
        try
        {
            this.IDNldDangKy = int.Parse(Request["idNldDK"].ToString());
        }
        catch
        {
            this.IDNldDangKy = 0;
        }
        #region Lay thong tin so luong tin tuyen dung
        this.strBtnViecLamTrongNuoc = "Việc trong nước [ "+this.objTuyenDung.getDataCount(false)+" ]";
        this.strBtnViecLamNgoai = "Việc ngoài nước [ " + this.objTuyenDung.getDataCount(true) + " ]";
        #endregion

        this.txtIDNldTuVan.Value = this.IDNldTuVan.ToString();
        this.txtIDNguoiLaoDong.Value = this.IDNguoiLaoDong.ToString();

        if (this.IDNldTuVan > 0)
        {
            this.btnQuaTrinhDaoTao.Disabled = false;
            this.btnQuaTrinhCongTac.Disabled = false;
        }
        else
        {
            this.btnQuaTrinhDaoTao.Disabled = true;
            this.btnQuaTrinhCongTac.Disabled = true;
        }
        if (!Page.IsPostBack)
        {
            this.ddlTinh_TT.DataSource = this.objProvincer.getDataCategoryToCombobox();
            this.ddlTinh_TT.DataTextField = "Name";
            this.ddlTinh_TT.DataValueField = "Id";
            this.ddlTinh_TT.DataBind();

            if (this.ddlTinh_TT.Items.Count > 0)
            {
                this.ddlTinh_TT.SelectedValue = "2";
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
                this.ddlXa_TT.DataBind();
            }

            this.ddlTinh_DC.DataSource = this.objProvincer.getDataCategoryToCombobox();
            this.ddlTinh_DC.DataTextField = "Name";
            this.ddlTinh_DC.DataValueField = "Id";
            this.ddlTinh_DC.DataBind();

            if (this.ddlTinh_DC.Items.Count > 0)
            {
                this.ddlTinh_DC.SelectedValue = "2";
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
                this.ddlXa_DC.DataBind();
            }

            this.ddlDanToc.DataSource = this.objDanToc.getDataCategoryToCombobox();
            this.ddlDanToc.DataTextField = "NameDanToc";
            this.ddlDanToc.DataValueField = "IDDanToc";
            this.ddlDanToc.DataBind();

            this.ddlTonGiao.DataSource = this.objTonGiao.getDataCategoryToCombobox();
            this.ddlTonGiao.DataTextField = "NameTonGiao";
            this.ddlTonGiao.DataValueField = "IDTonGiao";
            this.ddlTonGiao.DataBind();

            this.ddlNgoaiNgu.DataSource = this.objNgoaiNgu.getDataCategoryToCombobox();
            this.ddlNgoaiNgu.DataTextField = "NameNgoaiNgu";
            this.ddlNgoaiNgu.DataValueField = "IDNgoaiNgu";
            this.ddlNgoaiNgu.DataBind();

            this.ddlTrinhDoPhoThong.DataSource = this.objTrinhDoPhoThong.getDataCategoryToCombobox();
            this.ddlTrinhDoPhoThong.DataTextField = "NameTrinhDoPhoThong";
            this.ddlTrinhDoPhoThong.DataValueField = "IDTrinhDoPhoThong";
            this.ddlTrinhDoPhoThong.DataBind();

            this.ddlTinHoc.DataSource = this.objTinHoc.getDataCategoryToCombobox();
            this.ddlTinHoc.DataTextField = "NameTinHoc";
            this.ddlTinHoc.DataValueField = "IDTinHoc";
            this.ddlTinHoc.DataBind();

            TrinhDoTinHoc objTrinhDoTinHoc = new TrinhDoTinHoc();
            this.ddlTrinhDoTinHoc.DataSource = objTrinhDoTinHoc.getDataCategoryToCombobox();
            this.ddlTrinhDoTinHoc.DataTextField = "NameTrinhDo";
            this.ddlTrinhDoTinHoc.DataValueField = "ID";
            this.ddlTrinhDoTinHoc.DataBind();
            this.ddlTrinhDoTinHoc.SelectedValue = "0";

            TrinhDoNgoaiNgu objTrinhDoNgoaiNgu = new TrinhDoNgoaiNgu();
            this.ddlTrinhDoNgoaiNgu.DataSource = objTrinhDoNgoaiNgu.getDataCategoryToCombobox();
            this.ddlTrinhDoNgoaiNgu.DataTextField = "NameTrinhDo";
            this.ddlTrinhDoNgoaiNgu.DataValueField = "ID";
            this.ddlTrinhDoNgoaiNgu.DataBind();
            this.ddlTrinhDoNgoaiNgu.SelectedValue = "0";

        }
        if (!Page.IsPostBack && this.IDNldTuVan > 0)
        {
            this.objTableNldTuVan = this.objNguoiLaoDong.getDataTblNldTuVanById(this.IDNldTuVan);
            if (this.objTableNldTuVan.Rows.Count > 0)
            {
                this.IDNguoiLaoDong = int.Parse(this.objTableNldTuVan.Rows[0]["IDNguoiLaoDong"].ToString());
                this.IDNldDangKy = this.objNguoiLaoDong.getDataNldDangKyByIDNldTuVan(this.IDNldTuVan);

                if (this.objTableNldTuVan.Rows[0]["MucLuongTN"].ToString() != "0") this.txtMucLuongTN.Text = this.objTableNldTuVan.Rows[0]["MucLuongTN"].ToString();
                this.txtLyDoTN.Text = this.objTableNldTuVan.Rows[0]["LyDoTN"].ToString();
                this.txtDnDaLienHe.Text = this.objTableNldTuVan.Rows[0]["DnDaLienHe"].ToString();

                this.ckbTuVanPhapLuat.Checked = bool.Parse(this.objTableNldTuVan.Rows[0]["TuVanPhapLuat"].ToString());
                this.ckbTuVanViecLam.Checked = bool.Parse(this.objTableNldTuVan.Rows[0]["TuVanViecLam"].ToString());
                this.ckbTuVanXuatKhauLaoDong.Checked = bool.Parse(this.objTableNldTuVan.Rows[0]["TuVanXuatKhauLaoDong"].ToString());
                this.ckbTuVanDuHoc.Checked = bool.Parse(this.objTableNldTuVan.Rows[0]["TuVanDuHoc"].ToString());
                this.ckbTuVanBHTN.Checked = bool.Parse(this.objTableNldTuVan.Rows[0]["TuVanBHTN"].ToString());
                this.ckbTuVanHocNghe.Checked = bool.Parse(this.objTableNldTuVan.Rows[0]["TuVanHocNghe"].ToString());
                this.ckbTuVanKhac.Checked = bool.Parse(this.objTableNldTuVan.Rows[0]["TuVanKhac"].ToString());


                this.txtViTriCongViec.Text = this.objTableNldTuVan.Rows[0]["ViTriCongViec"].ToString();
               
                if(this.objTableNldTuVan.Rows[0]["MucLuongThapNhat"].ToString() != "0") this.txtMucLuongThapNhat.Text = this.objTableNldTuVan.Rows[0]["MucLuongThapNhat"].ToString();
                this.txtDieuKienLamViec.Text = this.objTableNldTuVan.Rows[0]["DieuKienLamViec"].ToString();
                this.txtDiaDiemLamViec.Text = this.objTableNldTuVan.Rows[0]["DiaDiemLamViec"].ToString();

                this.txtViTriCongViec2.Text = this.objTableNldTuVan.Rows[0]["ViTriCongViec2"].ToString();
                if (this.objTableNldTuVan.Rows[0]["MucLuongThapNhat2"].ToString() != "0") this.txtMucLuongThapNhat2.Text = this.objTableNldTuVan.Rows[0]["MucLuongThapNhat2"].ToString();
                this.txtDieuKienLamViec2.Text = this.objTableNldTuVan.Rows[0]["DieuKienLamViec2"].ToString();
                this.txtDiaDiemLamViec2.Text = this.objTableNldTuVan.Rows[0]["DiaDiemLamViec2"].ToString();


                // nội dung khác của vị trí 2 sẻ ko hoạt động
                this.txtNoiDungKhac.Text = this.objTableNldTuVan.Rows[0]["NoiDungKhac"].ToString();

                this.ddlIdLoaiLaoDong.SelectedValue = this.objTableNldTuVan.Rows[0]["IDLoaiLaoDong"].ToString();

                /* Load defaut selected mode */
                try
                {
                    string selectedValue = "$('#ddlQickSelect').val([";
                    foreach (string s in this.objTableNldTuVan.Rows[0]["ViTriCongViec"].ToString().Split(';'))
                    {
                        selectedValue += "'" + s + "'" + ',';
                    }
                    selectedValue = selectedValue.Substring(0, selectedValue.Length - 1);
                    selectedValue += "]).trigger('change');";
                    Page.ClientScript.RegisterStartupScript(GetType(), "haha", selectedValue, true);
                    // 
                    try
                    {
                        string selectedValue2 = "$('#ddlQickSelect2').val([";
                        foreach (string s2 in this.objTableNldTuVan.Rows[0]["ViTriCongViec2"].ToString().Split(';'))
                        {
                            selectedValue2 += "'" + s2 + "'" + ',';
                        }
                        selectedValue2 = selectedValue2.Substring(0, selectedValue2.Length - 1);
                        selectedValue2 += "]).trigger('change');";
                        Page.ClientScript.RegisterStartupScript(GetType(), "hehe", selectedValue2, true);
                    }
                    catch { }
                }
                catch { }

            }

            this.objTable = this.objNguoiLaoDong.getDataById(this.IDNguoiLaoDong);
            if (this.objTable.Rows.Count > 0)
            {
                //this.txtMa.Text = this.objTable.Rows[0]["Ma"].ToString();
                this.txtHoVaTen.Text = this.objTable.Rows[0]["HoVaTen"].ToString();
                this.txtNgaySinh.Value = DateTime.Parse(this.objTable.Rows[0]["NgaySinh"].ToString()).ToString("dd/MM/yyyy");

                this.ddlGioiTinh.SelectedValue = this.objTable.Rows[0]["IDGioiTinh"].ToString();

                this.txtDienThoai.Text = this.objTable.Rows[0]["DienThoai"].ToString();
                this.txtEmail.Text = this.objTable.Rows[0]["Email"].ToString();
                this.ddlDanToc.SelectedValue = this.objTable.Rows[0]["IDDanToc"].ToString();
                this.ddlTonGiao.SelectedValue = this.objTable.Rows[0]["IDTonGiao"].ToString();
                this.txtSucKhoe.Text = this.objTable.Rows[0]["SucKhoe"].ToString();

                this.txtChieuCao.Text = this.objTable.Rows[0]["ChieuCao"].ToString();
                this.txtCanNang.Text = this.objTable.Rows[0]["CanNang"].ToString();
                this.ddlNgoaiNgu.SelectedValue = this.objTable.Rows[0]["IDNgoaiNgu"].ToString();
                this.ddlTrinhDoPhoThong.SelectedValue = this.objTable.Rows[0]["IDTrinhDoPhoThong"].ToString();
                this.ddlTinHoc.SelectedValue = this.objTable.Rows[0]["IDTinHoc"].ToString();

                this.txtCMND.Text = this.objTable.Rows[0]["CMND"].ToString();
                this.txtNgayCapCMND.Value = DateTime.Parse(this.objTable.Rows[0]["NgayCapCMND"].ToString()).ToString("dd/MM/yyyy");
                this.txtNoiCap.Text = this.objTable.Rows[0]["NoiCap"].ToString();
                this.txtBHXH.Text = this.objTable.Rows[0]["BHXH"].ToString();
                this.txtTrinhDoDaoTao.Text = this.objTable.Rows[0]["TrinhDoDaoTao"].ToString();

                this.txtTrinhDoKyNangNghe.Text = this.objTable.Rows[0]["TrinhDoKyNangNghe"].ToString();
                this.txtKhaNangNoiTroi.Text = this.objTable.Rows[0]["KhaNangNoiTroi"].ToString();
                this.txtXom_TT.Text = this.objTable.Rows[0]["Xom_TT"].ToString();
                this.txtXom_DC.Text = this.objTable.Rows[0]["Xom_DC"].ToString();

                this.ddlTrinhDoTinHoc.SelectedValue = this.objTable.Rows[0]["IdTrinhDoTinHoc"].ToString();
                this.ddlTrinhDoNgoaiNgu.SelectedValue = this.objTable.Rows[0]["IdTrinhDoNgoaiNgu"].ToString();

                for (int i = 0; i < this.ddlHuyen_TT.Items.Count; i++)
                {
                    if (this.ddlHuyen_TT.Items[i].Text == this.objTable.Rows[0]["Huyen_TT"].ToString())
                    {
                        this.ddlHuyen_TT.SelectedIndex = i;
                        break;
                    }
                }

                if (this.ddlHuyen_TT.Items.Count > 0)
                {
                    this.ddlXa_TT.DataSource = this.objWard.getDataCategoryToCombobox(this.ddlTinh_TT.SelectedValue.ToString(), this.ddlHuyen_TT.SelectedValue.ToString());
                    this.ddlXa_TT.DataTextField = "Name";
                    this.ddlXa_TT.DataValueField = "Id";
                    this.ddlXa_TT.DataBind();
                }

                for (int i = 0; i < this.ddlXa_TT.Items.Count; i++)
                {
                    if (this.ddlXa_TT.Items[i].Text == this.objTable.Rows[0]["Xa_TT"].ToString())
                    {
                        this.ddlXa_TT.SelectedIndex = i;
                        break;
                    }
                }

                for (int i = 0; i < this.ddlHuyen_DC.Items.Count; i++)
                {
                    if (this.ddlHuyen_DC.Items[i].Text == this.objTable.Rows[0]["Huyen_DC"].ToString())
                    {
                        this.ddlHuyen_DC.SelectedIndex = i;
                        break;
                    }
                }

                if (this.ddlHuyen_DC.Items.Count > 0)
                {
                    this.ddlXa_DC.DataSource = this.objWard.getDataCategoryToCombobox(this.ddlTinh_DC.SelectedValue.ToString(), this.ddlHuyen_DC.SelectedValue.ToString());
                    this.ddlXa_DC.DataTextField = "Name";
                    this.ddlXa_DC.DataValueField = "Id";
                    this.ddlXa_DC.DataBind();
                }

                for (int i = 0; i < this.ddlXa_DC.Items.Count; i++)
                {
                    if (this.ddlXa_DC.Items[i].Text == this.objTable.Rows[0]["Xa_DC"].ToString())
                    {
                        this.ddlXa_DC.SelectedIndex = i;
                        break;
                    }
                }

            }
        }
        this.txtMa.Focus();
    }
    #endregion

    #region method btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        this.lblMsg.Text = "";


        if (this.txtCMND.Text.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập số CMND của người lao động";
            this.txtCMND.Focus();
            return;
        }

        if (this.txtCMND.Text.Trim().Length != 9)
        {
            this.lblMsg.Text = "Bạn nhập số CMND không chính xác";
            this.txtCMND.Focus();
            return;
        }

        int ret = objNguoiLaoDong.checkCMND(this.txtCMND.Text.Trim());
        if(ret != 0)
        {
            this.txtMa.Text = this.txtCMND.Text.Trim();
            this.btnGetInformation_Click(sender, e);

            this.lblMsg.Text = "Người lao động đã tồn tại";
            return;
        }

        if (txtBHXH.Text.Trim() != "" && txtBHXH.Text.Trim().Length != 10)
        {
            this.lblMsg.Text = "Bạn nhập số BHXH không chính xác";
            this.txtDienThoai.Focus();
            return;
        }

        if(txtBHXH.Text.Trim() != "")
        {
            ret = objNguoiLaoDong.checkBHXH(this.txtBHXH.Text.Trim());
            if (ret != 0)
            {
                this.txtMa.Text = this.txtBHXH.Text.Trim();
                this.btnGetInformation_Click(sender, e);

                this.lblMsg.Text = "Mã BHXH đã tồn tại";
                return;
            }
        }


        if (this.txtHoVaTen.Text.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập tên của người lao động";
            this.txtHoVaTen.Focus();
            return;
        }

        if (this.txtNgaySinh.Value.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập ngày sinh của người lao động";
            this.txtNgaySinh.Focus();
            return;
        }

        if (this.txtDienThoai.Text.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập số điện thoại của người lao động";
            this.txtDienThoai.Focus();
            return;
        }

        

        if (this.txtChieuCao.Text.Trim() == "")
        {
            this.txtChieuCao.Text = "0";
        }

        if (this.txtCanNang.Text.Trim() == "")
        {
            this.txtCanNang.Text = "0";
        }

        if (this.txtNgayCapCMND.Value.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập ngày cấp số CMND của người lao động";
            this.txtNgayCapCMND.Value = DateTime.Now.ToString("dd/MM/yyyy");
            this.txtNgayCapCMND.Focus();
            return;
        }

        if (this.txtMucLuongTN.Text.Trim() == "")
        {
            this.txtMucLuongTN.Text = "0";
        }

        float tmpMucLuongTN = 0;
        try
        {
            tmpMucLuongTN = float.Parse(this.txtMucLuongTN.Text);
        }
        catch
        {
        }

        if (this.txtMucLuongThapNhat.Text.Trim() == "")
        {
            this.txtMucLuongThapNhat.Text = "0";
        }

        float tmpMucLuongThapNhat = 0;
        try
        {
            tmpMucLuongThapNhat = float.Parse(this.txtMucLuongThapNhat.Text);
        }
        catch
        {
        }
        
        int GioiTinhb = 0;
        try
        {
            GioiTinhb = int.Parse(ddlGioiTinh.SelectedValue);
        }
        catch
        {
        }

        float tmpMucLuongThapNhat2 = 0;
        try
        {
            tmpMucLuongThapNhat2 = float.Parse(this.txtMucLuongThapNhat2.Text);
        }
        catch
        {
        }

        if (this.objNguoiLaoDong.setData(ref this.IDNguoiLaoDong, this.txtHoVaTen.Text, TVSSystem.CVDate(this.txtNgaySinh.Value.ToString().Trim()), this.txtCMND.Text, this.txtNoiCap.Text, TVSSystem.CVDate(this.txtNgayCapCMND.Value.ToString().Trim()),
            this.txtBHXH.Text, this.txtDienThoai.Text, this.txtEmail.Text, int.Parse(this.ddlDanToc.SelectedValue.ToString()), int.Parse(this.ddlTonGiao.SelectedValue.ToString()), this.txtSucKhoe.Text, double.Parse(this.txtChieuCao.Text), int.Parse(this.txtCanNang.Text),
            int.Parse(this.ddlTrinhDoPhoThong.SelectedValue.ToString()), int.Parse(this.ddlNgoaiNgu.SelectedValue.ToString()), int.Parse(this.ddlTinHoc.SelectedValue.ToString()), this.txtTrinhDoDaoTao.Text, this.txtTrinhDoKyNangNghe.Text, this.txtKhaNangNoiTroi.Text,
            this.ddlTinh_TT.SelectedItem.Text, this.ddlHuyen_TT.SelectedItem.Text, this.ddlXa_TT.SelectedItem.Text, this.txtXom_TT.Text, this.ddlTinh_DC.SelectedItem.Text, this.ddlHuyen_DC.SelectedItem.Text, this.ddlXa_DC.SelectedItem.Text, this.txtXom_DC.Text, int.Parse(ddlTrinhDoTinHoc.SelectedValue), int.Parse(ddlTrinhDoNgoaiNgu.SelectedValue), GioiTinhb) == 1)
        {
            #region Luu thong tin vao phieu tu van
            this.objNguoiLaoDong.setDataTblNldTuVan(ref this.IDNldTuVan, IDNguoiLaoDong, int.Parse(this.ddlIdLoaiLaoDong.SelectedValue.ToString()), 0, tmpMucLuongTN, this.txtLyDoTN.Text, this.txtDnDaLienHe.Text, this.ckbTuVanPhapLuat.Checked, this.ckbTuVanViecLam.Checked, this.ckbTuVanDuHoc.Checked, this.ckbTuVanHocNghe.Checked, this.ckbTuVanXuatKhauLaoDong.Checked, this.ckbTuVanBHTN.Checked, this.ckbTuVanKhac.Checked, "", this.txtViTriCongViec.Text.ToString().Replace('×', ';').Substring(1, this.txtViTriCongViec.Text.ToString().Length - 1), tmpMucLuongThapNhat, this.txtDieuKienLamViec.Text, this.txtDiaDiemLamViec.Text, this.txtViTriCongViec2.Text.ToString().Replace('×', ';').Substring(1, this.txtViTriCongViec2.Text.ToString().Length - 1), tmpMucLuongThapNhat2, this.txtDieuKienLamViec2.Text, this.txtDiaDiemLamViec2.Text, this.txtNoiDungKhac.Text, DateTime.Now, Session["ACCOUNT"].ToString());

            #endregion

            #region Luu thong tin vao phieu dang ky viec lam
            if (this.ckbTuVanViecLam.Checked)
            {
                if (this.IDNldDangKy == 0)
                {
                    this.IDNldDangKy = this.objNguoiLaoDong.getDataNldDangKyByIDNldTuVan(this.IDNldTuVan);
                }
                this.objNguoiLaoDong.setDataNldDangKy(ref this.IDNldDangKy, this.IDNguoiLaoDong, this.IDNldTuVan, this.txtViTriCongViec.Text, DateTime.Now, Session["ACCOUNT"].ToString());
            }
            #endregion

            #region Luu thong tin xuat khau lao dong - Du hoc
            if (this.ckbTuVanXuatKhauLaoDong.Checked || this.ckbTuVanDuHoc.Checked)
            {
                this.objXuatKhauLaoDong.setData(this.IDNldTuVan, this.IDNguoiLaoDong, this.ckbTuVanDuHoc.Checked);
            }
            #endregion

            #region Luu thong tin phieu tu van hoc nghe
            if (this.ckbTuVanHocNghe.Checked)
            {
                this.objNguoiLaoDong.setNldDaoTaoData(this.IDNldTuVan, this.IDNguoiLaoDong);
            }
            #endregion

            Response.Redirect("TuVanEdit.aspx?id=" + this.IDNldTuVan + "&idNld=" + this.IDNguoiLaoDong.ToString() + "&idNldDK="+this.IDNldDangKy.ToString());
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
        Response.Redirect("TuVan.aspx");
    }
    #endregion

    #region method btnGetInformation_Click
    protected void btnGetInformation_Click(object sender, EventArgs e)
    {
        DataTable objTableNldThongTin = new DataTable();
        if (this.txtMa.Text .Trim() != "")
        {
            objTableNldThongTin = this.objNguoiLaoDong.getDataByCode(this.txtMa.Text.Trim());
            if (objTableNldThongTin.Rows.Count > 0)
            {
                this.IDNguoiLaoDong = int.Parse(objTableNldThongTin.Rows[0]["IDNguoiLaoDong"].ToString());

                this.txtMa.Text = objTableNldThongTin.Rows[0]["Ma"].ToString();
                this.txtHoVaTen.Text = objTableNldThongTin.Rows[0]["HoVaTen"].ToString();
                this.txtNgaySinh.Value = DateTime.Parse(objTableNldThongTin.Rows[0]["NgaySinh"].ToString()).ToString("dd/MM/yyyy");

                this.txtDienThoai.Text = objTableNldThongTin.Rows[0]["DienThoai"].ToString();
                this.txtEmail.Text = objTableNldThongTin.Rows[0]["Email"].ToString();
                this.ddlDanToc.SelectedValue = objTableNldThongTin.Rows[0]["IDDanToc"].ToString();
                this.ddlTonGiao.SelectedValue = objTableNldThongTin.Rows[0]["IDTonGiao"].ToString();
                this.txtSucKhoe.Text = objTableNldThongTin.Rows[0]["SucKhoe"].ToString();

                this.txtChieuCao.Text = objTableNldThongTin.Rows[0]["ChieuCao"].ToString();
                this.txtCanNang.Text = objTableNldThongTin.Rows[0]["CanNang"].ToString();
                this.ddlNgoaiNgu.SelectedValue = objTableNldThongTin.Rows[0]["IDNgoaiNgu"].ToString();
                this.ddlTrinhDoPhoThong.SelectedValue = objTableNldThongTin.Rows[0]["IDTrinhDoPhoThong"].ToString();
                this.ddlTinHoc.SelectedValue = objTableNldThongTin.Rows[0]["IDTinHoc"].ToString();

                this.txtCMND.Text = objTableNldThongTin.Rows[0]["CMND"].ToString();
                this.txtNgayCapCMND.Value = DateTime.Parse(objTableNldThongTin.Rows[0]["NgayCapCMND"].ToString()).ToString("dd/MM/yyyy");
                this.txtNoiCap.Text = objTableNldThongTin.Rows[0]["NoiCap"].ToString();
                this.txtBHXH.Text = objTableNldThongTin.Rows[0]["BHXH"].ToString();
            }
        }
    }
    #endregion

    #region method ddlTinh_TT_SelectedIndexChanged
    protected void ddlTinh_TT_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.ddlHuyen_TT.DataSource = this.objDistrict.getDataCategoryToCombobox(this.ddlTinh_TT.SelectedValue.ToString());
        this.ddlHuyen_TT.DataTextField = "Name";
        this.ddlHuyen_TT.DataValueField = "Id";
        this.ddlHuyen_TT.DataBind();

        ddlHuyen_TT.Focus();
    }
    #endregion

    #region method ddlHuyen_TT_SelectedIndexChanged
    protected void ddlHuyen_TT_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.ddlXa_TT.DataSource = this.objWard.getDataCategoryToCombobox(this.ddlTinh_TT.SelectedValue.ToString(), this.ddlHuyen_TT.SelectedValue.ToString());
        this.ddlXa_TT.DataTextField = "Name";
        this.ddlXa_TT.DataValueField = "Id";
        this.ddlXa_TT.DataBind();

        ddlXa_TT.Focus();
    } 
    #endregion

    #region method ddlTinh_DC_SelectedIndexChanged
    protected void ddlTinh_DC_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.ddlHuyen_DC.DataSource = this.objDistrict.getDataCategoryToCombobox(this.ddlTinh_DC.SelectedValue.ToString());
        this.ddlHuyen_DC.DataTextField = "Name";
        this.ddlHuyen_DC.DataValueField = "Id";
        this.ddlHuyen_DC.DataBind();

        ddlHuyen_DC.Focus();
    } 
    #endregion

    #region method ddlHuyen_DC_SelectedIndexChanged
    protected void ddlHuyen_DC_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.ddlXa_DC.DataSource = this.objWard.getDataCategoryToCombobox(this.ddlTinh_DC.SelectedValue.ToString(), this.ddlHuyen_DC.SelectedValue.ToString());
        this.ddlXa_DC.DataTextField = "Name";
        this.ddlXa_DC.DataValueField = "Id";
        this.ddlXa_DC.DataBind();

        ddlXa_DC.Focus();
    } 
    #endregion

    #region method btnCopy_Click
    protected void btnCopy_Click(object sender, EventArgs e)
    {
        ddlTinh_DC.SelectedValue = ddlTinh_TT.SelectedValue;

        this.ddlHuyen_DC.DataSource = this.objDistrict.getDataCategoryToCombobox(this.ddlTinh_DC.SelectedValue.ToString());
        this.ddlHuyen_DC.DataTextField = "Name";
        this.ddlHuyen_DC.DataValueField = "Id";
        this.ddlHuyen_DC.DataBind();

        ddlHuyen_DC.SelectedValue = ddlHuyen_TT.SelectedValue;
        this.ddlXa_DC.DataSource = this.objWard.getDataCategoryToCombobox(this.ddlTinh_DC.SelectedValue.ToString(), this.ddlHuyen_DC.SelectedValue.ToString());
        this.ddlXa_DC.DataTextField = "Name";
        this.ddlXa_DC.DataValueField = "Id";
        this.ddlXa_DC.DataBind();

        ddlXa_DC.SelectedValue = ddlXa_TT.SelectedValue;
        txtXom_DC.Text = txtXom_TT.Text;

        txtSucKhoe.Focus();
    } 
    #endregion
}
