﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Labor_PrintTuyenDungTaiDoanhNghiep : System.Web.UI.Page
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

    private String nganhnghebuf = "0";
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ACCOUNT"] == null)
        {
            Response.Redirect("../Login.aspx");
        }
      //  Session["TITLE"] = "THÔNG TIN TUYỂN DỤNG";
        try
        {
            this.itemId = int.Parse(Request["did"].ToString());
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
            DoanhNghiep objDoanhNghiep = new DoanhNghiep();

            DataTable objdata = objDoanhNghiep.getDataById(this.IdDonVi);
            if (objdata.Rows.Count > 0)
            {
                this.txtTenDonVi.Text = objdata.Rows[0]["TenDonVi"].ToString();
                nganhnghebuf = objdata.Rows[0]["IDNganhNghe"].ToString();
            }
        }

        if (!Page.IsPostBack)
        {
            if (Session["TuyenDungMessage"] != null)
            {
                Session["TuyenDungMessage"] = null;
            }

            this.ddlNhomNganh.DataSource = this.objNhomNganh.getDataCategoryToCombobox();
            this.ddlNhomNganh.DataTextField = "NameNhomNganh";
            this.ddlNhomNganh.DataValueField = "IdNhomNganh";
            this.ddlNhomNganh.DataBind();
            this.ddlNhomNganh.SelectedValue = "0";

            ViTri objViTri = new ViTri();
            this.ddlIdVitri.DataSource = objViTri.getDataCategoryToCombobox();
            this.ddlIdVitri.DataTextField = "NameViTri";
            this.ddlIdVitri.DataValueField = "ID";
            this.ddlIdVitri.DataBind();
            this.ddlIdVitri.SelectedValue = "0";

            this.ddlIDChucVu.DataSource = this.objChucVu.getDataCategoryToCombobox();
            this.ddlIDChucVu.DataTextField = "NameChucVu";
            this.ddlIDChucVu.DataValueField = "IDChucVu";
            this.ddlIDChucVu.DataBind();
            this.ddlIDChucVu.SelectedValue = "0";

            this.ddlIDNganhNghe.DataSource = this.objBusiness.getDataCategoryToCombobox();
            this.ddlIDNganhNghe.DataTextField = "Name";
            this.ddlIDNganhNghe.DataValueField = "Id";
            this.ddlIDNganhNghe.DataBind();
            this.ddlIDNganhNghe.SelectedValue = nganhnghebuf;

            this.ddlIDDoTuoi.DataSource = this.objDoTuoi.getDataCategoryToCombobox();
            this.ddlIDDoTuoi.DataTextField = "NameDoTuoi";
            this.ddlIDDoTuoi.DataValueField = "IDDoTuoi";
            this.ddlIDDoTuoi.DataBind();
            this.ddlIDDoTuoi.SelectedValue = "0";

            this.ddlIDGioiTinh.DataSource = this.objGioiTinh.getDataCategoryToCombobox("Nam/nữ");
            this.ddlIDGioiTinh.DataTextField = "NameGioiTinh";
            this.ddlIDGioiTinh.DataValueField = "IDGioiTinh";
            this.ddlIDGioiTinh.DataBind();
            this.ddlIDGioiTinh.SelectedValue = "0";

            this.ddlIDTrinhDoChuyenMon.DataSource = this.objTrinhDoChuyenMon.getDataCategoryToCombobox();
            this.ddlIDTrinhDoChuyenMon.DataTextField = "NameTrinhDoChuyenMon";
            this.ddlIDTrinhDoChuyenMon.DataValueField = "IDTrinhDoChuyenMon";
            this.ddlIDTrinhDoChuyenMon.DataBind();
            this.ddlIDTrinhDoChuyenMon.SelectedValue = "0";

            this.ddlIDMucLuong.DataSource = this.objMucluong.getDataCategoryToCombobox();
            this.ddlIDMucLuong.DataTextField = "NameMucLuong";
            this.ddlIDMucLuong.DataValueField = "IDMucLuong";
            this.ddlIDMucLuong.DataBind();
            this.ddlIDMucLuong.SelectedValue = "0";

            NgoaiNgu objNgoaiNgu = new NgoaiNgu();
            this.ddlyeuCauNgoaiNgu.DataSource = objNgoaiNgu.getDataCategoryToCombobox();
            this.ddlyeuCauNgoaiNgu.DataTextField = "NameNgoaiNgu";
            this.ddlyeuCauNgoaiNgu.DataValueField = "IDNgoaiNgu";
            this.ddlyeuCauNgoaiNgu.DataBind();
            this.ddlyeuCauNgoaiNgu.SelectedValue = "0";

            TinHoc objTinHoc = new TinHoc();
            this.ddlyeuCauTinHoc.DataSource = objTinHoc.getDataCategoryToCombobox();
            this.ddlyeuCauTinHoc.DataTextField = "NameTinHoc";
            this.ddlyeuCauTinHoc.DataValueField = "IDTinHoc";
            this.ddlyeuCauTinHoc.DataBind();
            this.ddlyeuCauTinHoc.SelectedValue = "0";
        }
        if (!Page.IsPostBack )
        {
            getData();          /*------------------------------------*/
            this.objTable = this.objTuyenDung.getDataById(this.itemId);
            if (this.objTable.Rows.Count > 0)
            {
                this.txtTenDonVi.Text = this.objTable.Rows[0]["TenDonVi"].ToString().ToUpper();
                this.ddlNhomNganh.SelectedValue = this.objTable.Rows[0]["IDNhomNghanh"].ToString();
          
                this.ddlIDChucVu.SelectedValue = this.objTable.Rows[0]["IDChucVu"].ToString();
      
                this.ddlIdVitri.SelectedValue = this.objTable.Rows[0]["IdViTri"].ToString();

                this.ddlIDNganhNghe.SelectedValue = this.objTable.Rows[0]["IDNganhNghe"].ToString();
                this.lblIDNganhNghe.Text = this.ddlIDNganhNghe.SelectedItem.Text;

                this.ddlIDDoTuoi.SelectedValue = this.objTable.Rows[0]["IDDoTuoi"].ToString();
                this.ddlIDGioiTinh.SelectedValue = this.objTable.Rows[0]["IDGioiTinh"].ToString();

                this.ddlIDTrinhDoChuyenMon.SelectedValue = this.objTable.Rows[0]["IDTrinhDoChuyenMon"].ToString();
        
                this.ddlIDMucLuong.SelectedValue = this.objTable.Rows[0]["IDMucLuong"].ToString();
                this.lblIDMucLuong.Text = this.ddlIDMucLuong.SelectedItem.Text;

                this.txtQuyenLoi.Text = this.objTable.Rows[0]["QuyenLoi"].ToString();
           
                this.ddlyeuCauNgoaiNgu.SelectedValue = this.objTable.Rows[0]["YCNgoaiNgu"].ToString();
                this.ddlyeuCauTinHoc.SelectedValue = this.objTable.Rows[0]["YCTinHoc"].ToString();
                this.txtDiaDiem.Text = this.objTable.Rows[0]["DiaDiem"].ToString();
                this.ddlThoiGianLamViec.SelectedValue = this.objTable.Rows[0]["ThoiGianLamViec"].ToString();
            }
        }
     
    }
    #region getData()
    private void getData()
    {
        this.objTable = this.objTuyenDung.getList(" ", int.Parse(this.ddlIDChucVu.SelectedValue.ToString()), int.Parse(this.ddlIDMucLuong.SelectedValue.ToString()), this.tenDonVi);
        dtlTuyenDung.DataSource = objTable.DefaultView;
        dtlTuyenDung.DataBind();
    
    }
    #endregion
}