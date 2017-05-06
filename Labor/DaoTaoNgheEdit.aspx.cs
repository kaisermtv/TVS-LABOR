﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Labor_DaoTaoNgheEdit : System.Web.UI.Page
{
    #region declare objects
    private int IDNldDaoTao = 0, IDNguoiLaoDong = 0;
    private Account objAccount = new Account();
    private NguoiLaoDong objNguoiLaoDong = new NguoiLaoDong();

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
        Session["TITLE"] = "CẬP NHẬT HỒ SƠ ĐÀO TẠO NGHỀ";

        try
        {
            this.IDNldDaoTao = int.Parse(Request["id"].ToString());
        }
        catch
        {
            this.IDNldDaoTao = 0;
        }

        if (!Page.IsPostBack)
        {
            this.objTable = this.objNguoiLaoDong.getDataNldDaoTaoById(this.IDNldDaoTao.ToString());
            if (this.objTable.Rows.Count > 0)
            {
                this.IDNguoiLaoDong = int.Parse(this.objTable.Rows[0]["IDNguoiLaoDong"].ToString());

                this.txtIDNguoiLaoDong.Value = this.IDNguoiLaoDong.ToString();

                this.txtHoTen.Text = this.objTable.Rows[0]["HoVaTen"].ToString();
                if (this.objTable.Rows[0]["NgaySinh"].ToString() != "")
                {
                    this.txtNgaySinh.Text = DateTime.Parse(this.objTable.Rows[0]["NgaySinh"].ToString()).ToString("dd/MM/yyyy");
                }
                if (this.objTable.Rows[0]["IDGioiTinh"].ToString() != "1")
                {
                    this.txtGioiTinh.Text = "Nam";
                }
                else
                {
                    this.txtGioiTinh.Text = "Nữ";
                }
                this.txtDiaChi.Text = this.objTable.Rows[0]["DiaChi"].ToString();
                this.txtSoDienThoai.Text = this.objTable.Rows[0]["DienThoai"].ToString();

                this.txtThoiGian.Text = this.objTable.Rows[0]["ThoiGian"].ToString();
                this.txtTruongHoc.Text = this.objTable.Rows[0]["TruongHoc"].ToString();
                this.txtDiaChiHoc.Text = this.objTable.Rows[0]["DiaChiHoc"].ToString();
                this.txtKhoaHoc.Text = this.objTable.Rows[0]["KhoaHoc"].ToString();
                this.txtDTLienHe.Text = this.objTable.Rows[0]["DTLienHe"].ToString();
                this.txtIdDtKhoaHoc.Value = this.objTable.Rows[0]["IdDtKhoaHoc"].ToString();
                this.txtLoaiKhoaHoc.Value = this.objTable.Rows[0]["LoaiKhoaHoc"].ToString();
                if (this.objTable.Rows[0]["LoaiKhoaHoc"].ToString() == "1")
                {
                    this.txtTenLoaiKhoaHoc.Text = "Học Nghề";
                }
                else
                {
                    this.txtTenLoaiKhoaHoc.Text = "Học Tiếng";
                }
                this.txtNameKhoaHoc.Text = this.objTable.Rows[0]["NameKhoaHoc"].ToString();

                this.txtThoiGian.Text = this.objTable.Rows[0]["ThoiGianHoc"].ToString();
                this.txtMucHoTro.Text = this.objTable.Rows[0]["MucHoTro1"].ToString();

                this.txtSoQDHTN.Text = this.objTable.Rows[0]["SoQDHTN"].ToString();

                this.txtSoQDHN.Text = this.objTable.Rows[0]["SoQDHN"].ToString();

                if (this.objTable.Rows[0]["NgayBatDau"].ToString() != "")
                {
                    this.txtNgayBatDau.Value = DateTime.Parse(this.objTable.Rows[0]["NgayBatDau"].ToString()).ToString("dd/MM/yyyy");
                }
                if (this.objTable.Rows[0]["NgayBatDau"].ToString() != "")
                {
                    this.txtNgayKetThuc.Value = DateTime.Parse(this.objTable.Rows[0]["NgayKetThuc"].ToString()).ToString("dd/MM/yyyy");
                }

                this.ddlState.SelectedValue = this.objTable.Rows[0]["State"].ToString();
            }
        }
    } 
    #endregion

    #region method btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        this.lblMsg.Text = "";

        if (this.txtMucHoTro.Text == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập mức hỗ trợ";
            this.txtMucHoTro.Focus();
            return;
        }
        float tmpMucHoTro = 0;
        try
        {
            tmpMucHoTro = float.Parse(this.txtMucHoTro.Text);
        }
        catch
        {
            this.lblMsg.Text = "Bạn chưa nhập mức hỗ trợ";
            this.txtMucHoTro.Focus();
            return;
        }

        if (this.txtNgayBatDau.Value == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập ngày bắt đầu khóa học";
            this.txtNgayBatDau.Focus();
            return;
        }
        DateTime tmpNgayBatDau;
        try
        {
            tmpNgayBatDau = TVSSystem.CVDate(this.txtNgayBatDau.Value);
        }
        catch
        {
            this.lblMsg.Text = "Bạn chưa nhập ngày bắt đầu khóa học";
            this.txtNgayBatDau.Focus();
            return;
        }

        if (this.txtNgayKetThuc.Value == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập ngày kết thúc khóa học";
            this.txtNgayKetThuc.Focus();
            return;
        }

        DateTime tmpNgayKetThuc;
        try
        {
            tmpNgayKetThuc = TVSSystem.CVDate(this.txtNgayKetThuc.Value);
        }
        catch
        {
            this.lblMsg.Text = "Bạn chưa nhập ngày kết thúc khóa học";
            this.txtNgayKetThuc.Focus();
            return;
        }

        if (this.objNguoiLaoDong.setNldDaoTaoData(this.IDNldDaoTao, int.Parse(this.txtIDNguoiLaoDong.Value), int.Parse(this.txtIdDtKhoaHoc.Value), this.txtTruongHoc.Text, this.txtDiaChiHoc.Text,this.txtKhoaHoc.Text, this.txtDTLienHe.Text,tmpNgayBatDau,tmpNgayKetThuc,this.txtSoQDHTN.Text, this.txtSoQDHN.Text, int.Parse(this.ddlState.SelectedValue.ToString())) == 1)
        {
            this.lblMsg.Text = "<span style = \"color:blue;\">Lưu dữ liệu thành công !</span>";
        }
    }
    #endregion

    #region method btnCancel_Click
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("DaoTaoNghe.aspx");
    }
    #endregion
}