using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_NguoiLaoDongEdit : System.Web.UI.Page
{
    #region declare objects
    private int itemId = 0;
    private Account objAccount = new Account();
    private NguoiLaoDong objNguoiLaoDong = new NguoiLaoDong();
    private GioiTinh objGioiTinh = new GioiTinh();
    private DanToc objDanToc = new DanToc();
    private TonGiao objTonGiao = new TonGiao();
    private NgoaiNgu objNgoaiNgu = new NgoaiNgu();
    private TrinhDoPhoThong objTrinhDoPhoThong = new TrinhDoPhoThong();
    private TinHoc objTinHoc = new TinHoc();

    private Provincer objProvincer = new Provincer();
    private District objDistrict = new District();
    private Ward objWard = new Ward();

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
        Session["TITLE"] = "CẬP NHẬT HỒ SƠ NGƯỜI LAO ĐỘNG";
        //if (!this.objAccount.checkForFunction(Session["ACCOUNT"].ToString(), 3, ref View, ref Add, ref Edit, ref Del, ref Orther))
        //{
        //    Response.Redirect("NoPermission.aspx");
        //}
        try
        {
            this.itemId = int.Parse(Request["id"].ToString());
        }
        catch
        {
            this.itemId = 0;
        }
        this.txtIDNguoiLaoDong.Value = this.itemId.ToString();

        if (this.itemId > 0)
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
            this.ddlGioiTinh.DataSource = this.objGioiTinh.getDataCategoryToCombobox();
            this.ddlGioiTinh.DataTextField = "NameGioiTinh";
            this.ddlGioiTinh.DataValueField = "IDGioiTinh";
            this.ddlGioiTinh.DataBind();

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
            
        }
        if (!Page.IsPostBack && this.itemId > 0)
        {
            this.objTable = this.objNguoiLaoDong.getDataById(this.itemId);
            if (this.objTable.Rows.Count > 0)
            {
                this.txtMa.Text = this.objTable.Rows[0]["Ma"].ToString();
                this.txtHoVaTen.Text = this.objTable.Rows[0]["HoVaTen"].ToString();
                this.txtNgaySinh.Value = DateTime.Parse(this.objTable.Rows[0]["NgaySinh"].ToString()).ToString();
                this.ddlGioiTinh.SelectedValue = this.objTable.Rows[0]["IdGioiTinh"].ToString();
                this.txtNoiSinh.Text = this.objTable.Rows[0]["NoiSinh"].ToString();
                this.txtQueQuan.Text = this.objTable.Rows[0]["QueQuan"].ToString();
                this.txtDienThoai.Text = this.objTable.Rows[0]["DienThoai"].ToString();
                this.txtEmail.Text = this.objTable.Rows[0]["Email"].ToString();

                this.ddlDanToc.SelectedValue = this.objTable.Rows[0]["IDDanToc"].ToString();
                this.ddlTonGiao.SelectedValue = this.objTable.Rows[0]["IDTonGiao"].ToString();

                this.txtTruongTHPT.Text = this.objTable.Rows[0]["TruongTHPT"].ToString();
                this.txtTruongDiaChi.Text = this.objTable.Rows[0]["TruongDiaChi"].ToString();
                this.txtNienKhoa.Text = this.objTable.Rows[0]["NienKhoa"].ToString();

                this.txtSucKhoe.Text = this.objTable.Rows[0]["SucKhoe"].ToString();
                this.txtChieuCao.Text = this.objTable.Rows[0]["ChieuCao"].ToString();
                this.txtCanNang.Text = this.objTable.Rows[0]["CanNang"].ToString();

                this.ddlNgoaiNgu.SelectedValue = this.objTable.Rows[0]["IDNgoaiNgu"].ToString();
                this.ddlTrinhDoPhoThong.SelectedValue = this.objTable.Rows[0]["IDTrinhDoPhoThong"].ToString();
                this.ddlTinHoc.SelectedValue = this.objTable.Rows[0]["IDTinHoc"].ToString();

                this.txtCMND.Text = this.objTable.Rows[0]["CMND"].ToString();
                this.txtNgayCapCMND.Value = DateTime.Parse(this.objTable.Rows[0]["NgayCapCMND"].ToString()).ToString();
                this.txtNoiCap.Text = this.objTable.Rows[0]["NoiCap"].ToString();
                this.txtBHXH.Text = this.objTable.Rows[0]["BHXH"].ToString();
                this.txtTaikhoan.Text = this.objTable.Rows[0]["Taikhoan"].ToString();
                // chọn trạng thái gia đình
                this.ckDocThan.Checked = (this.objTable.Rows[0]["StateLapGiaDinh"].ToString() == "0" ? true : false);
                this.ckKetHon.Checked = (this.objTable.Rows[0]["StateLapGiaDinh"].ToString() == "1" ? true : false);

                this.txtNoiDungKhac.Text = this.objTable.Rows[0]["NoiDungKhac"].ToString();
                this.ckbState.Checked = bool.Parse(this.objTable.Rows[0]["State"].ToString());
                this.txtXom_TT.Text = this.objTable.Rows[0]["Xom_TT"].ToString();
                this.txtXom_DC.Text = this.objTable.Rows[0]["Xom_DC"].ToString();

                // ****************** chọn tỉnh ******************
                for (int i = 0; i < this.ddlTinh_TT.Items.Count; i++)
                {
                    if (this.ddlTinh_TT.Items[i].Text == this.objTable.Rows[0]["Tinh_TT"].ToString())
                    {
                        this.ddlTinh_TT.SelectedIndex = i;
                        break;
                    }
                }

                for (int i = 0; i < this.ddlTinh_DC.Items.Count; i++)
                {
                    if (this.ddlTinh_DC.Items[i].Text == this.objTable.Rows[0]["Tinh_DC"].ToString())
                    {
                        this.ddlTinh_DC.SelectedIndex = i;
                        break;
                    }
                }

                //////////////////////////////////////////////////////

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
                    if (this.ddlHuyen_TT.Items[i].Text == this.objTable.Rows[0]["Huyen_TT"].ToString())
                    {
                        this.ddlHuyen_TT.SelectedIndex = i;
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
                //////////////////////////////////////////////////////


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
                    if (this.ddlXa_TT.Items[i].Text == this.objTable.Rows[0]["Xa_TT"].ToString())
                    {
                        this.ddlXa_TT.SelectedIndex = i;
                        break;
                    }
                }

                for (int i = 0; i < this.ddlXa_DC.Items.Count; i++)
                {
                    if (this.ddlXa_DC.Items[i].Text == this.objTable.Rows[0]["Xa_DC"].ToString())
                    {
                        this.ddlXa_DC.SelectedIndex = i;
                        break;
                    }
                }
                //////////////////////////////////////////////////////

            }
        }
        this.txtMa.Focus();
    }
    #endregion

    #region method btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        this.lblMsg.Text = "";

        if (this.txtMa.Text.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập mã số người lao động";
            this.txtMa.Focus();
            return;
        }

        if (this.itemId == 0)
        {
            if (this.objNguoiLaoDong.checkCode(this.txtMa.Text.Trim()))
            {
                this.lblMsg.Text = "Mã \"" + this.txtMa.Text + "\" đã được sử dụng, vui lòng chọn mã khác.";
                this.txtMa.Focus();
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
            this.lblMsg.Text = "Bạn chưa nhập chiều cao của người lao động";
            this.txtChieuCao.Text = "0";
            this.txtChieuCao.Focus();
            return;
        }

        if (this.txtCanNang.Text.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập cân nặng của người lao động";
            this.txtCanNang.Text = "0";
            this.txtCanNang.Focus();
            return;
        }

        if (this.txtNgayCapCMND.Value.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập ngày cấp số CMND của người lao động";
            this.txtNgayCapCMND.Value = DateTime.Now.ToString();
            this.txtNgayCapCMND.Focus();
            return;
        }

        int TTGiaDinh = -1;    // trạng thái ko xác định
        if (!(ckDocThan.Checked == false && ckKetHon.Checked == false))
        {
            TTGiaDinh = (ckDocThan.Checked ? 0 : 1); // 0 : độc thân , 1: Kết hôn
        }

        if (this.objNguoiLaoDong.setData(ref this.itemId, this.txtMa.Text, this.txtHoVaTen.Text, DateTime.Parse(this.txtNgaySinh.Value.ToString().Trim()),int.Parse(this.ddlGioiTinh.SelectedValue.ToString()),
            this.txtNoiSinh.Text,this.txtQueQuan.Text,this.txtDienThoai.Text,this.txtEmail.Text,int.Parse(this.ddlDanToc.SelectedValue.ToString()),
            int.Parse(this.ddlTonGiao.SelectedValue.ToString()),this.txtTruongTHPT.Text, this.txtTruongDiaChi.Text, this.txtNienKhoa.Text, this.txtSucKhoe.Text, double.Parse(this.txtChieuCao.Text), int.Parse(this.txtCanNang.Text),
            int.Parse(this.ddlTrinhDoPhoThong.SelectedValue.ToString()),int.Parse(this.ddlNgoaiNgu.SelectedValue.ToString()),int.Parse(this.ddlTinHoc.SelectedValue.ToString()),this.txtCMND.Text,
            DateTime.Parse(this.txtNgayCapCMND.Value.ToString().Trim()), this.txtNoiCap.Text, this.txtBHXH.Text, this.txtTaikhoan.Text, this.txtNoiDungKhac.Text, this.ckbState.Checked, this.ddlTinh_TT.SelectedItem.Text, this.ddlHuyen_TT.SelectedItem.Text, this.ddlXa_TT.SelectedItem.Text, this.txtXom_TT.Text, this.ddlTinh_DC.SelectedItem.Text, this.ddlHuyen_DC.SelectedItem.Text, this.ddlXa_DC.SelectedItem.Text, this.txtXom_DC.Text, TTGiaDinh) == 1)
        {
            Response.Redirect("NguoiLaoDongEdit.aspx?id="+this.itemId);
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
        Response.Redirect("NguoiLaoDong.aspx");
    }
    #endregion

    #region method ddlTinh_TT_SelectedIndexChanged
    protected void ddlTinh_TT_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.ddlHuyen_TT.DataSource = this.objDistrict.getDataCategoryToCombobox(this.ddlTinh_TT.SelectedValue.ToString());
        this.ddlHuyen_TT.DataTextField = "Name";
        this.ddlHuyen_TT.DataValueField = "Id";
        this.ddlHuyen_TT.DataBind();
    }
    #endregion

    #region method ddlHuyen_TT_SelectedIndexChanged
    protected void ddlHuyen_TT_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.ddlXa_TT.DataSource = this.objWard.getDataCategoryToCombobox(this.ddlTinh_TT.SelectedValue.ToString(), this.ddlHuyen_TT.SelectedValue.ToString());
        this.ddlXa_TT.DataTextField = "Name";
        this.ddlXa_TT.DataValueField = "Id";
        this.ddlXa_TT.DataBind();
    }
    #endregion

    #region method ddlTinh_DC_SelectedIndexChanged
    protected void ddlTinh_DC_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.ddlHuyen_DC.DataSource = this.objDistrict.getDataCategoryToCombobox(this.ddlTinh_DC.SelectedValue.ToString());
        this.ddlHuyen_DC.DataTextField = "Name";
        this.ddlHuyen_DC.DataValueField = "Id";
        this.ddlHuyen_DC.DataBind();
    }
    #endregion

    #region method ddlHuyen_DC_SelectedIndexChanged
    protected void ddlHuyen_DC_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.ddlXa_DC.DataSource = this.objWard.getDataCategoryToCombobox(this.ddlTinh_DC.SelectedValue.ToString(), this.ddlHuyen_DC.SelectedValue.ToString());
        this.ddlXa_DC.DataTextField = "Name";
        this.ddlXa_DC.DataValueField = "Id";
        this.ddlXa_DC.DataBind();
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