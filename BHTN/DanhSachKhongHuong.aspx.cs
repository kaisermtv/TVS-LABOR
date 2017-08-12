using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Labor_DanhSachKhongHuong : System.Web.UI.Page
{
    #region declare
    private NguoiLaoDong objNguoiLaoDong = new NguoiLaoDong();
    public int index = 1, index2=1;   
    public string _msg = "";
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ACCOUNT"] == null)
        {
            Response.Redirect("../Login.aspx");
        }
         
        if(!Page.IsPostBack)
        {
            Load_DanhSachHoSo();
            Load_CauHinh();
            Load_DanhSachNguoiKy();
            Load_TrangThai();
        }
             
    }
    public void Load_CauHinh()
    {
        txtNamQuyetDinh.Text = DateTime.Now.Year.ToString();
        txtNamQD2.Text = DateTime.Now.Year.ToString();
        txtNgayTrinhKy.Value = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
        DataTable tblLoaiQuyetDinh = new DanhMuc().getList(29);       
        ddlLoaiQuyetDinh.DataTextField = "NameDanhMuc";
        ddlLoaiQuyetDinh.DataValueField = "IdDanhMuc";
        ddlLoaiQuyetDinh.DataSource = tblLoaiQuyetDinh;
        ddlLoaiQuyetDinh.DataBind();
        ddlLoaiQuyetDinh2.DataTextField = "NameDanhMuc";
        ddlLoaiQuyetDinh2.DataValueField = "IdDanhMuc";
        ddlLoaiQuyetDinh2.DataSource = tblLoaiQuyetDinh;
        ddlLoaiQuyetDinh2.DataBind();
    }
    public void Load_DanhSachNguoiKy()
    {
        ddlNguoiKy.DataValueField = "IDCanBo";
        ddlNguoiKy.DataTextField = "NameCanBo";
        ddlNguoiKy.DataSource = new CanBo().getDataByChucVuID(1);
        ddlNguoiKy.DataBind();
    }
    private void Load_DanhSachHoSo(string Ids=",48,")
    {
        string str=txtSearch.Value.Trim();
        DateTime TuNgay = new DateTime(1900, 1, 1), DenNgay = new DateTime(9999, 1, 1);
        if(txtTuNgay.Value.Trim()!="")
        {
            TuNgay = Convert.ToDateTime(txtTuNgay.Value,new CultureInfo("vi-VN"));
        }
        if(txtDenNgay.Value.Trim()!="")
        {
            DenNgay = Convert.ToDateTime(txtDenNgay.Value, new CultureInfo("vi-VN"));

        }
        DataTable objData = new TinhHuong().getDanhSachHoSoAndQuyetDinh(Ids,str);
        cpData.MaxPages = 1000;
        cpData.PageSize = 12;
        cpData.DataSource = objData.DefaultView;
        cpData.BindToControl = dtlData;
        dtlData.DataSource = cpData.DataSourcePaged;
        dtlData.DataBind();
    } 
    private void Load_TrangThai()
    {
        DataTable tblTrangThai = new TrangThaiHoSo().GetByIds(",48,");
        DataRow row = tblTrangThai.NewRow();
        row["ID"] = 0;
        row["Name"] = "--Tất cả--";
        tblTrangThai.Rows.InsertAt(row, 0);
        ddlTrangThai.DataTextField = "Name";
        ddlTrangThai.DataValueField = "ID";
        ddlTrangThai.DataSource = tblTrangThai;
        ddlTrangThai.DataBind();
    }
    protected void btnDanhSo_Click(object sender, EventArgs e)
    {      
        if(txtNamQuyetDinh.Text.Trim()=="")
        {
            _msg = "Bạn chưa nhập năm quyết định";
            return;
        }      
        if(txtSoHoSoChonDanh.Text.Trim()=="")
        {
            _msg = "Bạn chưa chọn hồ sơ để cấp số";
            return;
        }
        if (txtSoBatDau.Text.Trim() == "")
        {
            _msg = "Bạn chưa chọn số banwts đầu";
            return;
        }
        if(txtSoKetThuc.Text.Trim()=="")
        {
            _msg = "Bạn chưa chọn số kết thúc";
            return;
        }

        if(hdlstChuyen.Value ==null || hdlstChuyen.Value.ToString().Trim()=="")
        {
            _msg = "Bạn chưa chọn hồ sơ để đánh số";
            return;
        }       
        string[] strID = hdlstChuyen.Value.Split(',');
        if (ddlLoaiQuyetDinh.SelectedValue == null || ddlLoaiQuyetDinh.SelectedValue.ToString().Trim() == "")
        {
            _msg = "Bạn chưa chọn loại quyết định";
            return;
        }
        int IDLoaivanBan = int.Parse(ddlLoaiQuyetDinh.SelectedValue.ToString());
        DateTime NgayCap = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        DataRow RowLoaiVanBan = new DanhMuc().getItem(IDLoaivanBan);
        if(RowLoaiVanBan ==null)
        {
            _msg = "Bạn cần phải tạo loại văn bản ";
            return;
        }
        int So= int.Parse(txtSoBatDau.Text);
        for (int i = 0; i < strID.Length; i++)
        {
            string SoVanBan = So.ToString() + RowLoaiVanBan["Note"].ToString().Trim();
            DataRow rowTCTN = new NLDTroCapThatNghiep().getItem(int.Parse(strID[i]));    
            // trương hợp quyết định hưởng trợ cấp thất nghiệp
            if (new CapSo().CheckAutoNumber(NgayCap, IDLoaivanBan, So) == false && (int)rowTCTN["IdTrangThai"]==8 &&  IDLoaivanBan==30)
            {
                new CapSo().SetData(So, NgayCap, SoVanBan, int.Parse(strID[i]), IDLoaivanBan, txtNamQuyetDinh.Text.Trim());
                new TinhHuong().UpdateTrangThaiHS(int.Parse(strID[i]), 9);
            }
            // trương hợp quyết định hủy hưởng trợ cấp thất nghiệp
            if (new CapSo().CheckAutoNumber(NgayCap, IDLoaivanBan, So) == false && (int)rowTCTN["IdTrangThai"] == 20 && IDLoaivanBan==49)
            {
                new CapSo().SetData(So, NgayCap, SoVanBan, int.Parse(strID[i]), IDLoaivanBan, txtNamQuyetDinh.Text.Trim());
                new TinhHuong().UpdateTrangThaiHS(int.Parse(strID[i]), 21);
            }
            // trương hợp quyết định tạm dừng TCTN
            if (new CapSo().CheckAutoNumber(NgayCap, IDLoaivanBan, So) == false && (int)rowTCTN["IdTrangThai"] == 31 && IDLoaivanBan == 50)
            {
                new CapSo().SetData(So, NgayCap, SoVanBan, int.Parse(strID[i]), IDLoaivanBan, txtNamQuyetDinh.Text.Trim());
                new TinhHuong().UpdateTrangThaiHS(int.Parse(strID[i]), 32);
            }
            // Truong hop quyet dinh tiep tuc
            if (new CapSo().CheckAutoNumber(NgayCap, IDLoaivanBan, So) == false && (int)rowTCTN["IdTrangThai"] == 41 && IDLoaivanBan == 51)
            {
                new CapSo().SetData(So, NgayCap, SoVanBan, int.Parse(strID[i]), IDLoaivanBan, txtNamQuyetDinh.Text.Trim());
                new TinhHuong().UpdateTrangThaiHS(int.Parse(strID[i]), 42);
            }
            So++;
        }
        Load_DanhSachHoSo();
    }
    protected void btnTrinhKy_Click(object sender, EventArgs e)
    {
        if(txtNamQD2.Text.Trim()=="")
        {
            _msg = "Bạn chưa nhập năm quyết định";
            return;
        }
        if(ddlLoaiQuyetDinh2.SelectedValue ==null && ddlLoaiQuyetDinh2.SelectedValue.ToString().Trim()=="")
        {
            _msg = "Bạn chưa chọn loại quyết định";
            return;
        }
        if(txtSoHoSoCanTrinh.Text.Trim()=="")
        {
            _msg = "Bạn chưa chọn hồ sơ trình ký";
            return;
        }
        if (txtNgayTrinhKy.Value.Trim() == "")
        {
            _msg = "Bạn chưa chọn ngày trình ký";
            return;
        }
        if(ddlNguoiKy.SelectedValue ==null || ddlNguoiKy.SelectedValue.ToString().Trim()=="")
        {
            _msg = "Bạn chưa chọn người ký";
            return;
        }
        string[] strID = hdlstChuyen.Value.Split(',');
        string[] strIDCapSo = hdlstIDCapSo.Value.Split(',');   
        for (int i = 0; i < strID.Length; i++)
        {
            DataRow rowTCTN = new NLDTroCapThatNghiep().getItem(int.Parse(strID[i]));
            // ky quyet dinh huong tro cap that nghiep
            if ((int)rowTCTN["IdTrangThai"] == 9)
            {
                new TinhHuong().UpdateTrangThaiHS(int.Parse(strID[i]), 10);
                new TinhHuong().UpdateNguoiKy(int.Parse(strIDCapSo[i]), Convert.ToDateTime(txtNgayTrinhKy.Value, new CultureInfo("vi-VN")), int.Parse(ddlNguoiKy.SelectedValue));
            }
            // ky quyet dinh huy huong
            if ((int)rowTCTN["IdTrangThai"] == 21)
            {
                new TinhHuong().UpdateTrangThaiHS(int.Parse(strID[i]), 22);
                new TinhHuong().UpdateNguoiKy(int.Parse(strIDCapSo[i]), Convert.ToDateTime(txtNgayTrinhKy.Value, new CultureInfo("vi-VN")), int.Parse(ddlNguoiKy.SelectedValue));
            }
            // ky quyet dinh tam dung
            if ((int)rowTCTN["IdTrangThai"] == 32)
            {
                new TinhHuong().UpdateTrangThaiHS(int.Parse(strID[i]), 33);
                new TinhHuong().UpdateNguoiKy(int.Parse(strIDCapSo[i]), Convert.ToDateTime(txtNgayTrinhKy.Value, new CultureInfo("vi-VN")), int.Parse(ddlNguoiKy.SelectedValue));
            }
            // ky quyet dinh tiep tuc
            if ((int)rowTCTN["IdTrangThai"] == 42)
            {
                new TinhHuong().UpdateTrangThaiHS(int.Parse(strID[i]), 43);
                new TinhHuong().UpdateNguoiKy(int.Parse(strIDCapSo[i]), Convert.ToDateTime(txtNgayTrinhKy.Value, new CultureInfo("vi-VN")), int.Parse(ddlNguoiKy.SelectedValue));
            }
        
        }
        Load_DanhSachHoSo();

    }

    protected void btnTaiQuyetDinh_Click(object sender, EventArgs e)
    {
        if (hdlstChuyen.Value == null || hdlstChuyen.Value.ToString().Trim() == "")
        {
            _msg = "Bạn chưa chọn quyết định cần tải";
            return;
        }
        string[] strID = hdlstChuyen.Value.Split(',');
        for (int i = 0; i < strID.Length; i++)
        {
            DataRow rowTCTN = new NLDTroCapThatNghiep().getItem(int.Parse(strID[i]));
            if ((int)rowTCTN["IdTrangThai"] == 10)
            {
                TaiQuyetDinhTCTN(int.Parse(strID[i]), i.ToString());
            }
        }

        Load_DanhSachHoSo();
    
    }

 
    #region Quyet dinh huong tro cap that nghiep
    private void TaiQuyetDinhTCTN(int IDNLDTCTN,string FileName)
    {
        new Common().TaiQuyetDinhTCTN(IDNLDTCTN, FileName);     
    }
    #endregion  
     
    protected void dtlData_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "TaiQuyetDinh")
        {
            int ID = int.Parse(e.CommandArgument.ToString());
            DataRow Row = new NLDTroCapThatNghiep().getItem(ID);
            // la quyet dinh TCTN           
            if ((int)Row["IdTrangThai"] == 48)
            {
                new Common().ThongBaoKhongHuong(ID, "");
            }
        }

    }

    protected void dtlData_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
       
            DataRowView newRow = (DataRowView)e.Item.DataItem;
            Button newButtom = (Button)e.Item.FindControl("btnTaiQD");
            newButtom.Enabled = false;
            if (newRow["IdTrangThai"].ToString().Trim() == "48")
            {
                newButtom.Enabled = true;
            }

        }
    }
    protected void btnChuyenHoSo_Click(object sender, EventArgs e)
    {
        string[] strID = hdlstChuyen.Value.Split(',');
        for (int i = 0; i < strID.Length; i++)
        {
            DataRow rowTCTN = new NLDTroCapThatNghiep().getItem(int.Parse(strID[i]));
            // trả kết quả QĐ Hưởng TCTN
            if ((int)rowTCTN["IdTrangThai"] == 10)
            {
                new TinhHuong().UpdateTrangThaiHS(int.Parse(strID[i]), 11);
            }
            // Trả kết quả QĐ hủy hưởng TCTN
            if ((int)rowTCTN["IdTrangThai"] == 22)
            {
                new TinhHuong().UpdateTrangThaiHS(int.Parse(strID[i]), 23);
            }
            // Trả kết quả QĐ tạm dừng hưởng
            if ((int)rowTCTN["IdTrangThai"] == 33)
            {
                new TinhHuong().UpdateTrangThaiHS(int.Parse(strID[i]), 34);
            }
            // Trả kết quả QĐ tạm dừng hưởng
            if ((int)rowTCTN["IdTrangThai"] == 43)
            {
                new TinhHuong().UpdateTrangThaiHS(int.Parse(strID[i]), 44);
            }

         
        }
        Load_DanhSachHoSo();

    }
    protected void ddlTrangThai_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(ddlTrangThai.SelectedValue.ToString()!=null && ddlTrangThai.SelectedValue.ToString()=="0")
        {
            Load_DanhSachHoSo();
        }
        else
        {
            Load_DanhSachHoSo("," + ddlTrangThai.SelectedValue.ToString() + ",");
        }
    }
}