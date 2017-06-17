using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TaiQuyetDinh : System.Web.UI.Page
{
    int IDNLDTCTN = 0;
    public int SoQuyetDinh = 0;
    public DateTime MyDateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
    public string _msg = "";
    public int Index = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null && Request.QueryString["id"].ToString().Trim() != "")
        {
            IDNLDTCTN = int.Parse(Request.QueryString["id"].ToString());           
        }
        if (Request.QueryString["index"] != null && Request.QueryString["index"].ToString().Trim() != "")
        {
            Index = int.Parse(Request.QueryString["index"].ToString());
        }
        TaiQuyetDinhTCTN(IDNLDTCTN, Index.ToString());
    }
    private void TaiQuyetDinhTCTN(int IDNLDTCTN, string FileName)
    {
        TinhHuong objTinhHuong = new TinhHuong();
        DataTable tblTinhHuong = new TinhHuong().getDataById(IDNLDTCTN);
        DataRow RowTroCapThatNghiep = new NLDTroCapThatNghiep().getItem(IDNLDTCTN);
        DataTable TblNguoiLaoDong = new NguoiLaoDong().getDataById((int)RowTroCapThatNghiep["IDNguoiLaoDong"]);
        DataTable tblQuyetDinh = new CapSo().GetDataByIDTCTN(IDNLDTCTN);
        DataTable tblLichThongBao = new LichThongBao().GetDataByID((int)tblTinhHuong.Rows[0]["IDTinhHuong"]);
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
        if (tblQuyetDinh.Rows.Count == 0)
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
        if (tblLichThongBao.Rows.Count == 0)
        {
            _msg = "Hồ sơ chưa có lịch thông báo";
            return;
        }
        lstInput.Add("[Thang1]");
        lstOutput.Add(((DateTime)tblLichThongBao.Rows[0]["KhaiBaoThang1TuNgay"]).ToString("dd/MM/yyyy"));
        for (int i = 2; i <= 12; i++)
        {
            lstInput.Add("[Thang" + i.ToString() + "Tu]");
            if (((DateTime)tblLichThongBao.Rows[0]["KhaiBaoThang" + i.ToString() + "TuNgay"]).ToString("yyyy") != "1900")
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
   
}
 