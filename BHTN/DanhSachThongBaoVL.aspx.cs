using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Labor_DanhSachThongBaoVL : System.Web.UI.Page
{
    #region declare
    private NguoiLaoDong objNguoiLaoDong = new NguoiLaoDong();
    public int index = 1;
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
            Load_CauHinh();
            Load_DanhSachHoSo();
   
        }
             
    }
    private void Load_DanhSachHoSo()
    {
        string str = txtSearch.Value.Trim();
        DataTable objData = new TinhHuong().getDanhSachHoSo(12,0,0,str);
        cpData.MaxPages = 1000;
        cpData.PageSize = 12;
        cpData.DataSource = objData.DefaultView;
        cpData.BindToControl = dtlData;
        dtlData.DataSource = cpData.DataSourcePaged;
        dtlData.DataBind();
    }
    private void Load_CauHinh()
    {
        DateTime myDatetime = DateTime.Now;
        string MyDate = myDatetime.Day.ToString() + "/" + myDatetime.Month.ToString() + "/" + myDatetime.Year.ToString();
        txtNgayTrinhKy.Value = MyDate;
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
        TinhHuong objTinhHuong = new TinhHuong();
        DataTable tblTinhHuong = new TinhHuong().getDataById(IDNLDTCTN);
        DataRow RowTroCapThatNghiep = new NLDTroCapThatNghiep().getItem(IDNLDTCTN);
        DataTable TblNguoiLaoDong = new NguoiLaoDong().getDataById((int)RowTroCapThatNghiep["IDNguoiLaoDong"]);
        DataTable tblQuyetDinh = new CapSo().GetDataByIDTCTN(IDNLDTCTN);
        DataTable tblLichThongBao=new LichThongBao().GetDataByID((int)tblTinhHuong.Rows[0]["IDTinhHuong"]);
        if (TblNguoiLaoDong == null || TblNguoiLaoDong.Rows.Count == 0)
        {
            _msg = "Người lao động chưa được khởi tạo";
            return;
        }
        if (tblTinhHuong == null || tblTinhHuong.Rows.Count == 0)
        {
            _msg = "Chưa có bẳng tỉnh nào được cập nhật";
            return;
        }
        List<string> lstInput = new List<string>();
        List<string> lstOutput = new List<string>();
        lstInput.Add("[NgayKy]");
        try
        {
            lstOutput.Add(".../.../.....");
            //DateTime NgayDangKy = (DateTime)RowTroCapThatNghiep["NgayNopHoSo"];
            //DateTime NgayQuyetDinh = new DateTime();
            //NgayQuyetDinh = objTinhHuong.TinhNgayNghiLe(NgayDangKy, 20);
            //lstOutput.Add(NgayQuyetDinh.ToString("dd/MM/yyyy"));
        }
        catch
        {
            lstOutput.Add(".../.../.....");
        }
        lstInput.Add("[SoQD]");
        if(tblQuyetDinh.Rows.Count==0)
        {
            lstOutput.Add("......................");
        }
        else
        {
            lstOutput.Add(tblQuyetDinh.Rows[0]["SoVanBan"].ToString());
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
        lstOutput.Add(RowTroCapThatNghiep["SoThangDongBHXH"].ToString());
        lstInput.Add("[MucHuong]");
        lstOutput.Add(tblTinhHuong.Rows[0]["MucHuong"].ToString());
        lstInput.Add("[SoThangHuong]");
        int SoThangHuong = (int)tblTinhHuong.Rows[0]["SoThangHuongBHXH"];
        lstOutput.Add(SoThangHuong.ToString());
        lstInput.Add("[SoThangBaoLuu]");
        lstOutput.Add(tblTinhHuong.Rows[0]["SoThangBaoLuuBHXH"].ToString());
        lstInput.Add("[HuongTuNgay]");
        lstOutput.Add(((DateTime)tblTinhHuong.Rows[0]["HuongTuNgay"]).ToString("dd/MM/yyyy"));
        lstInput.Add("[HuongDenNgay]");
        lstOutput.Add(((DateTime)tblTinhHuong.Rows[0]["HuongDenNgay"]).ToString("dd/MM/yyyy"));
        //----- chen phan lich thong bao viec lam
        if(tblLichThongBao.Rows.Count==0)
        {
            _msg = "Hồ sơ chưa có lịch thông báo";
            return;
        }
        lstInput.Add("[Thang1]");
        lstOutput.Add(((DateTime)tblLichThongBao.Rows[0]["KhaiBaoThang1TuNgay"]).ToString("dd/MM/yyyy"));
        for (int i = 2; i <= 12; i++)
        {
            lstInput.Add("[Thang"+i.ToString()+"Tu]");
            if (((DateTime)tblLichThongBao.Rows[0]["KhaiBaoThang"+i.ToString()+"TuNgay"]).ToString("yyyy") != "1900")
            {
                lstOutput.Add(((DateTime)tblLichThongBao.Rows[0]["KhaiBaoThang" + i.ToString() + "TuNgay"]).ToString("dd/MM/yyyy"));          
            }
            else
            {
                lstOutput.Add("../../....");
            }
            lstInput.Add("[Thang" + i.ToString() + "Den]");
            if (((DateTime)tblLichThongBao.Rows[0]["KhaiBaoThang" + i.ToString() + "DenNgay"]).ToString("yyyy") != "1900")
            {
                lstOutput.Add(((DateTime)tblLichThongBao.Rows[0]["KhaiBaoThang" + i.ToString() + "DenNgay"]).ToString("dd/MM/yyyy"));
        
            } 
            else
            {
                lstOutput.Add("../../....");
            }
        }
 
        ExportToWord objExportToWord = new ExportToWord();
        byte[] temp = objExportToWord.Export(Server.MapPath("../WordForm/QuyetDinhHuongTCTN.docx"), lstInput, lstOutput);
        Response.AppendHeader("Content-Type", "application/msword");
        Response.AppendHeader("Content-disposition", "inline; filename=QuyetDinhHuongTCTN" + FileName + ".docx");
        Response.BinaryWrite(temp);
        HttpContext.Current.Response.End();
        HttpContext.Current.Response.Flush();
     
    }
    #endregion  
     
    protected void dtlData_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "TaiQuyetDinh")
        {
            int ID = int.Parse(e.CommandArgument.ToString());
            TaiQuyetDinhTCTN(ID,"");
        }

    }

    protected void dtlData_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
       
            DataRowView newRow = (DataRowView)e.Item.DataItem;
            if((int)newRow["IdTrangThai"]<=10)
            {
                Button newButtom = (Button)e.Item.FindControl("btnTaiQD");
                newButtom.Visible = true;
            }

        }
    }
    protected void btnChuyenHoSo_Click(object sender, EventArgs e)
    {
        string[] strID = hdlstChuyen.Value.Split(',');
        for (int i = 0; i < strID.Length; i++)
        {
            DataRow rowTCTN = new NLDTroCapThatNghiep().getItem(int.Parse(strID[i]));
            if ((int)rowTCTN["IdTrangThai"] == 11)
            {
                new TinhHuong().UpdateTrangThaiHS(int.Parse(strID[i]), 12);
            }
          
        }
        Load_DanhSachHoSo();

    }
    protected void btnSearch_Click(object sender, ImageClickEventArgs e)
    {
        Load_DanhSachHoSo();
    }
}