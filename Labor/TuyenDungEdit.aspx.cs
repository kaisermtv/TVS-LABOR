using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_TuyenDungEdit : System.Web.UI.Page
{
    #region declare objects
    public int itemId = 0, IdDonVi = 0;
    public string tenDonVi = "";
    private Account objAccount = new Account();
    private TuyenDung objTuyenDung = new TuyenDung();
    private NhomNganh objNhomNganh = new NhomNganh();
    private DoTuoi objDoTuoi = new DoTuoi();
    private Business objBusiness = new Business();
    private Provincer objProvincer = new Provincer();
    private GioiTinh objGioiTinh = new GioiTinh();
    private TrinhDoChuyenMon objTrinhDoChuyenMon = new TrinhDoChuyenMon();
    private ChucVu objChucVu = new ChucVu();
    private Mucluong objMucluong = new Mucluong();
    private DataTable objTable = new DataTable();
    private bool View = false, Add = false, Edit = false, Del = false, Orther = false;
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        

        if (Session["ACCOUNT"] == null)
        {
            Response.Redirect("../Login.aspx");
        }
        ////if (!this.objAccount.checkForFunction(Session["ACCOUNT"].ToString(), 3, ref View, ref Add, ref Edit, ref Del, ref Orther))
        ////{
        ////    Response.Redirect("NoPermission.aspx");
        ////}
        Session["TITLE"] = "THÔNG TIN TUYỂN DỤNG";
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
            this.IdDonVi = int.Parse(Request.QueryString["did"].ToString());
        }
        catch
        {
            this.IdDonVi = 0;
        }
        try
        {
            this.tenDonVi = Request.QueryString["n"].ToString();
        }
        catch
        {
            this.tenDonVi = "";
        }

        if (!Page.IsPostBack)
        {
            this.txtIDDonVi.Value = this.IdDonVi.ToString();
            this.txtTenDonVi.Text = this.tenDonVi;
        }
        this.txtIDTuyenDung.Value = this.itemId.ToString();

        if (!Page.IsPostBack)
        {
            this.ddlNhomNganh.DataSource = this.objNhomNganh.getDataCategoryToCombobox();
            this.ddlNhomNganh.DataTextField = "NameNhomNganh";
            this.ddlNhomNganh.DataValueField = "IdNhomNganh";
            this.ddlNhomNganh.DataBind();

            this.ddlIDTinh.DataSource = this.objProvincer.getDataCategoryToCombobox();
            this.ddlIDTinh.DataTextField = "Name";
            this.ddlIDTinh.DataValueField = "Id";
            this.ddlIDTinh.DataBind();

            this.ddlIDChucVu.DataSource = this.objChucVu.getDataCategoryToCombobox();
            this.ddlIDChucVu.DataTextField = "NameChucVu";
            this.ddlIDChucVu.DataValueField = "IDChucVu";
            this.ddlIDChucVu.DataBind();

            this.ddlIDNganhNghe.DataSource = this.objBusiness.getDataCategoryToCombobox();
            this.ddlIDNganhNghe.DataTextField = "Name";
            this.ddlIDNganhNghe.DataValueField = "Id";
            this.ddlIDNganhNghe.DataBind();

            this.ddlIDDoTuoi.DataSource = this.objDoTuoi.getDataCategoryToCombobox();
            this.ddlIDDoTuoi.DataTextField = "NameDoTuoi";
            this.ddlIDDoTuoi.DataValueField = "IDDoTuoi";
            this.ddlIDDoTuoi.DataBind();

            this.ddlIDGioiTinh.DataSource = this.objGioiTinh.getDataCategoryToCombobox();
            this.ddlIDGioiTinh.DataTextField = "NameGioiTinh";
            this.ddlIDGioiTinh.DataValueField = "IDGioiTinh";
            this.ddlIDGioiTinh.DataBind();

            this.ddlIDTrinhDoChuyenMon.DataSource = this.objTrinhDoChuyenMon.getDataCategoryToCombobox();
            this.ddlIDTrinhDoChuyenMon.DataTextField = "NameTrinhDoChuyenMon";
            this.ddlIDTrinhDoChuyenMon.DataValueField = "IDTrinhDoChuyenMon";
            this.ddlIDTrinhDoChuyenMon.DataBind();

            this.ddlIDMucLuong.DataSource = this.objMucluong.getDataCategoryToCombobox();
            this.ddlIDMucLuong.DataTextField = "NameMucLuong";
            this.ddlIDMucLuong.DataValueField = "IDMucLuong";
            this.ddlIDMucLuong.DataBind();

            NgoaiNgu objNgoaiNgu = new NgoaiNgu();
            this.ddlyeuCauNgoaiNgu.DataSource =objNgoaiNgu.getDataCategoryToCombobox();
            this.ddlyeuCauNgoaiNgu.DataTextField = "NameNgoaiNgu";
            this.ddlyeuCauNgoaiNgu.DataValueField = "IDNgoaiNgu";
            this.ddlyeuCauNgoaiNgu.DataBind();

            TinHoc objTinHoc = new TinHoc();
            this.ddlyeuCauTinHoc.DataSource = objTinHoc.getDataCategoryToCombobox();
            this.ddlyeuCauTinHoc.DataTextField = "NameTinHoc";
            this.ddlyeuCauTinHoc.DataValueField = "IDTinHoc";
            this.ddlyeuCauTinHoc.DataBind();
        }
        if (!Page.IsPostBack && this.itemId > 0)
        {
            this.objTable = this.objTuyenDung.getDataById(this.itemId);
            if (this.objTable.Rows.Count > 0)
            {
                this.txtMaTuyenDung.Text = this.objTable.Rows[0]["MaTuyenDung"].ToString();
                this.txtIDDonVi.Value = this.objTable.Rows[0]["IDDonVi"].ToString();
                this.txtTenDonVi.Text = this.objTable.Rows[0]["TenDonVi"].ToString();
                this.ddlNhomNganh.SelectedValue = this.objTable.Rows[0]["IDNhomNghanh"].ToString();
                this.ddlIDChucVu.SelectedValue = this.objTable.Rows[0]["IDChucVu"].ToString();

                this.txtSoLuongTuyenDung.Text = this.objTable.Rows[0]["SoLuongTuyenDung"].ToString();
                this.ddlIDNganhNghe.SelectedValue = this.objTable.Rows[0]["IDNganhNghe"].ToString();
                this.ddlIDDoTuoi.SelectedValue = this.objTable.Rows[0]["IDDoTuoi"].ToString();
                this.ddlIDGioiTinh.SelectedValue = this.objTable.Rows[0]["IDGioiTinh"].ToString();
                this.txtUuTien.Text = this.objTable.Rows[0]["UuTien"].ToString();
                
                this.ddlIDTrinhDoChuyenMon.SelectedValue = this.objTable.Rows[0]["IDTrinhDoChuyenMon"].ToString();
                this.txtNoiDungKhac.Text = this.objTable.Rows[0]["NoiDungKhac"].ToString();
                this.txtMoTa.Text = this.objTable.Rows[0]["MoTa"].ToString();
                this.txtDiaDiem.Text = this.objTable.Rows[0]["DiaDiem"].ToString();
                this.ddlIDMucLuong.SelectedValue = this.objTable.Rows[0]["IDMucLuong"].ToString();
                
                this.ckbNuocNgoai.Checked = bool.Parse(this.objTable.Rows[0]["NuocNgoai"].ToString());
                this.txtQuyenLoi.Text = this.objTable.Rows[0]["QuyenLoi"].ToString();
                this.txtNgayBatDau.Value = DateTime.Parse(this.objTable.Rows[0]["NgayBatDau"].ToString()).ToString("dd/MM/yyyy");
                this.txtNgayKetThuc.Value = DateTime.Parse(this.objTable.Rows[0]["NgayKetThuc"].ToString()).ToString("dd/MM/yyyy");
                this.ckbState.Checked = bool.Parse(this.objTable.Rows[0]["State"].ToString());


                this.ddlyeuCauNgoaiNgu.SelectedValue = this.objTable.Rows[0]["YCNgoaiNgu"].ToString();
                this.ddlyeuCauTinHoc.SelectedValue = this.objTable.Rows[0]["YCTinHoc"].ToString();
                this.txtNamKinhNghiem.Text = this.objTable.Rows[0]["NamKinhNghiem"].ToString();
                this.ddlThoiGianLamViec.SelectedValue = this.objTable.Rows[0]["ThoiGianLamViec"].ToString();
            }
        }
        
        this.txtMaTuyenDung.Focus();
    }
    #endregion

    #region method btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        this.lblMsg.Text = "";

        //if (this.txtMaTuyenDung.Text.Trim() == "")
        //{
        //    this.lblMsg.Text = "Bạn chưa nhập mã số tin tuyển dụng";
        //    this.txtMaTuyenDung.Focus();
        //    return;
        //}

        //if (this.itemId == 0)
        //{
        //    if (this.objTuyenDung.checkCode(this.txtMaTuyenDung.Text.Trim()))
        //    {
        //        this.lblMsg.Text = "Mã \"" + this.txtMaTuyenDung.Text + "\" đã được sử dụng, vui lòng chọn mã khác.";
        //        this.txtMaTuyenDung.Focus();
        //        return;
        //    }
        //}

        if (this.txtIDDonVi.Value.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập mã của đơn vị tuyển dụng";
            this.txtIDDonVi.Focus();
            return;
        }

        if (this.txtTenDonVi.Text.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập tên của đơn vị tuyển dụng";
            this.txtTenDonVi.Focus();
            return;
        }

        if (this.txtSoLuongTuyenDung.Text.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập số lượng nhân sự cần tuyển dụng";
            this.txtSoLuongTuyenDung.Focus();
            return;
        }

        if (this.txtMoTa.Text.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nội dung mô tả tuyển dụng";
            this.txtMoTa.Focus();
            return;
        }

        if (this.txtNgayBatDau.Value.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập ngày bắt đầu tuyển dụng";
            this.txtNgayBatDau.Focus();
            return;
        }

        if (this.txtNgayKetThuc.Value.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập ngày kết thúc tuyển dụng";
            this.txtNgayKetThuc.Focus();
            return;
        }

        //int.Parse(this.txtIDDonVi.Value.ToString());
        //int.Parse(this.ddlNhomNganh.SelectedValue.ToString());
        //int.Parse(this.ddlIDChucVu.SelectedValue.ToString());
        //int.Parse(this.ddlIDNganhNghe.SelectedValue.ToString());
        //int.Parse(this.txtSoLuongTuyenDung.Text);
        //int.Parse(this.ddlIDDoTuoi.SelectedValue.ToString());
        //int.Parse(this.ddlIDGioiTinh.SelectedValue.ToString());
        //int.Parse(ddlIDTrinhDoChuyenMon.SelectedValue.ToString());
        //int.Parse(this.ddlIDMucLuong.SelectedValue.ToString());
        //int.Parse(this.ddlIDTinh.SelectedValue.ToString());
        //TVSSystem.CVDate(this.txtNgayBatDau.Value.ToString());
        //TVSSystem.CVDate(this.txtNgayKetThuc.Value.ToString());
        //int.Parse(ddlyeuCauTinHoc.SelectedValue);
        //int.Parse(ddlyeuCauNgoaiNgu.SelectedValue);
        //int.Parse(ddlThoiGianLamViec.SelectedValue);

        try
        {
            if (this.objTuyenDung.setData(ref this.itemId, int.Parse(this.txtIDDonVi.Value.ToString()), int.Parse(this.ddlNhomNganh.SelectedValue.ToString()), int.Parse(this.ddlIDChucVu.SelectedValue.ToString()),
            int.Parse(this.ddlIDNganhNghe.SelectedValue.ToString()), int.Parse(this.txtSoLuongTuyenDung.Text), int.Parse(this.ddlIDDoTuoi.SelectedValue.ToString()), int.Parse(this.ddlIDGioiTinh.SelectedValue.ToString()),
            int.Parse(ddlIDTrinhDoChuyenMon.SelectedValue.ToString()), this.txtUuTien.Text, this.txtNoiDungKhac.Text, this.txtMoTa.Text, int.Parse(this.ddlIDMucLuong.SelectedValue.ToString()), this.txtDiaDiem.Text, int.Parse(this.ddlIDTinh.SelectedValue.ToString()), this.ckbNuocNgoai.Checked, this.txtQuyenLoi.Text,
            TVSSystem.CVDate(this.txtNgayBatDau.Value.ToString()), TVSSystem.CVDate(this.txtNgayKetThuc.Value.ToString()), this.ckbState.Checked, int.Parse(ddlyeuCauTinHoc.SelectedValue), int.Parse(ddlyeuCauNgoaiNgu.SelectedValue), txtNamKinhNghiem.Text, int.Parse(ddlThoiGianLamViec.SelectedValue)) == 1)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
                this.lblMessage.Text = "Bạn chưa nhập tên của đơn vị tuyển dụng";

                //Response.Redirect("TuyenDungEdit.aspx?id=" + this.itemId);
            }
            else
            {
                this.lblMsg.Text = "Lỗi xảy ra khi cập nhật thông tin.";
            }
        }catch (Exception ex){
            this.lblMsg.Text = "Lỗi xảy ra khi cập nhật thông tin.";
        }
        
    }
    #endregion

    #region method btnCancel_Click
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("TuyenDung.aspx");
    }
    #endregion

    #region method ddlProvincer_SelectedIndexChanged
    protected void ddlIDTinh_SelectedIndexChanged(object sender, EventArgs e)
    {
        //this.ddlIDHuyen.DataSource = this.objDistrict.getDataCategoryToCombobox(this.ddlIDTinh.SelectedValue.ToString());
        //this.ddlIDHuyen.DataTextField = "Name";
        //this.ddlIDHuyen.DataValueField = "Id";
        //this.ddlIDHuyen.DataBind();
    }
    #endregion

    #region method btnUuTien_Click
    protected void btnUuTien_Click(object sender, EventArgs e)
    {
        if (this.itemId > 0)
        {
            this.objTuyenDung.setThuTuUuTien(this.itemId);
        }
    } 
    #endregion
}