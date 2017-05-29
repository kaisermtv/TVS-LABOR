using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

public class NguoiLaoDong :DataClass
{
    #region method NguoiLaoDong
    public NguoiLaoDong()
    {
    } 
    #endregion

    #region method setData
    public int setData(ref int IDNguoiLaoDong, string Ma, string HoVaTen, DateTime NgaySinh, int IDGioiTinh, string NoiSinh, string QueQuan, string DienThoai, string Email, int IDDanToc, int IDTonGiao, string TruongTHPT, string TruongDiaChi, string NienKhoa, string SucKhoe,
        double ChieuCao, double CanNang, int IDTrinhDoPhoThong, int IDNgoaiNgu, int IDTinHoc, string CMND, DateTime NgayCapCMND, string NoiCap, string BHXH, string TaiKhoan, string NoiDungKhac, bool State,
        string Tinh_TT, string Huyen_TT, string Xa_TT, string Xom_TT, string Tinh_DC, string Huyen_DC, string Xa_DC, string Xom_DC, int StateLapGiaDinh )
    {
        int tmpValue = 0;

        try
        {
            string sqlQuery = "";

            sqlQuery = "IF NOT EXISTS (SELECT * FROM TblNguoiLaoDong WHERE IDNguoiLaoDong = @IDNguoiLaoDong) ";
            sqlQuery += "BEGIN INSERT INTO TblNguoiLaoDong(Ma,HoVaTen,NgaySinh,StateLapGiaDinh,IDGioiTinh,NoiSinh,QueQuan,DienThoai,Email,IDDanToc,IDTonGiao,TruongTHPT,TruongDiaChi,NienKhoa,SucKhoe,";
            sqlQuery += "ChieuCao,CanNang,IDTrinhDoPhoThong,IDNgoaiNgu,IDTinHoc,CMND,NgayCapCMND,NoiCap,BHXH,TaiKhoan,NoiDungKhac,State,Tinh_TT,Huyen_TT,Xa_TT,Xom_TT,Tinh_DC,Huyen_DC,Xa_DC,Xom_DC) ";
            sqlQuery += " VALUES(@Ma,@HoVaTen,@NgaySinh,@StateLapGiaDinh,@IDGioiTinh,@NoiSinh,@QueQuan,@DienThoai,@Email,@IDDanToc,@IDTonGiao,@TruongTHPT,@TruongDiaChi,@NienKhoa,@SucKhoe,";
            sqlQuery += "@ChieuCao,@CanNang,@IDTrinhDoPhoThong,@IDNgoaiNgu,@IDTinHoc,@CMND,@NgayCapCMND,@NoiCap,@BHXH,@TaiKhoan,@NoiDungKhac,@State,@Tinh_TT,@Huyen_TT,@Xa_TT,@Xom_TT,@Tinh_DC,@Huyen_DC,@Xa_DC,@Xom_DC) END ";
            sqlQuery += "ELSE BEGIN UPDATE TblNguoiLaoDong SET Ma = @Ma,HoVaTen = @HoVaTen,NgaySinh = @NgaySinh,IDGioiTinh = @IDGioiTinh,NoiSinh = @NoiSinh,QueQuan = @QueQuan,DienThoai = @DienThoai,Email = @Email,IDDanToc = @IDDanToc,IDTonGiao = @IDTonGiao,TruongTHPT = @TruongTHPT,TruongDiaChi = @TruongDiaChi,NienKhoa = @NienKhoa,SucKhoe = @SucKhoe,";
            sqlQuery += "ChieuCao = @ChieuCao,CanNang = @CanNang,IDTrinhDoPhoThong = @IDTrinhDoPhoThong,IDNgoaiNgu = @IDNgoaiNgu,IDTinHoc = @IDTinHoc,CMND = @CMND,NgayCapCMND = @NgayCapCMND, NoiCap = @NoiCap, BHXH = @BHXH,TaiKhoan = @TaiKhoan,NoiDungKhac = @NoiDungKhac, State = @State, Tinh_TT = @Tinh_TT,Huyen_TT = @Huyen_TT,Xa_TT = @Xa_TT,Xom_TT = @Xom_TT,Tinh_DC = @Tinh_DC,Huyen_DC = @Huyen_DC, Xa_DC = @Xa_DC,Xom_DC = @Xom_DC,StateLapGiaDinh= @StateLapGiaDinh WHERE IDNguoiLaoDong = @IDNguoiLaoDong END ";

            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();

            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;

            Cmd.Parameters.Add("IDNguoiLaoDong", SqlDbType.Int).Value = IDNguoiLaoDong;
            Cmd.Parameters.Add("Ma", SqlDbType.NVarChar).Value = Ma;
            Cmd.Parameters.Add("HoVaTen", SqlDbType.NVarChar).Value = HoVaTen;
            Cmd.Parameters.Add("NgaySinh", SqlDbType.DateTime).Value = NgaySinh;
            Cmd.Parameters.Add("IDGioiTinh", SqlDbType.Int).Value = IDGioiTinh;

            Cmd.Parameters.Add("NoiSinh", SqlDbType.NVarChar).Value = NoiSinh;
            Cmd.Parameters.Add("QueQuan", SqlDbType.NVarChar).Value = QueQuan;
            Cmd.Parameters.Add("DienThoai", SqlDbType.NVarChar).Value = DienThoai;

            Cmd.Parameters.Add("Email", SqlDbType.NVarChar).Value = Email;
            Cmd.Parameters.Add("IDDanToc", SqlDbType.Int).Value = IDDanToc;
            Cmd.Parameters.Add("IDTonGiao", SqlDbType.Int).Value = IDTonGiao;
            Cmd.Parameters.Add("TruongTHPT", SqlDbType.NVarChar).Value = TruongTHPT;
            Cmd.Parameters.Add("TruongDiaChi", SqlDbType.NVarChar).Value = TruongDiaChi;

            Cmd.Parameters.Add("NienKhoa", SqlDbType.NVarChar).Value = NienKhoa;
            Cmd.Parameters.Add("SucKhoe", SqlDbType.NVarChar).Value = SucKhoe;
            Cmd.Parameters.Add("ChieuCao", SqlDbType.Float).Value = ChieuCao;
            Cmd.Parameters.Add("CanNang", SqlDbType.Float).Value = CanNang;
            Cmd.Parameters.Add("IDTrinhDoPhoThong", SqlDbType.Int).Value = IDTrinhDoPhoThong;

            Cmd.Parameters.Add("IDNgoaiNgu", SqlDbType.Int).Value = IDNgoaiNgu;
            Cmd.Parameters.Add("IDTinHoc", SqlDbType.Int).Value = IDTinHoc;
            Cmd.Parameters.Add("CMND", SqlDbType.NVarChar).Value = CMND;
            Cmd.Parameters.Add("NgayCapCMND", SqlDbType.DateTime).Value = NgayCapCMND;
            Cmd.Parameters.Add("NoiCap", SqlDbType.NVarChar).Value = NoiCap;

            Cmd.Parameters.Add("BHXH", SqlDbType.NVarChar).Value = BHXH;
            Cmd.Parameters.Add("TaiKhoan", SqlDbType.NVarChar).Value = TaiKhoan;
            Cmd.Parameters.Add("NoiDungKhac", SqlDbType.NVarChar).Value = NoiDungKhac;
            Cmd.Parameters.Add("State", SqlDbType.Bit).Value = State;

            Cmd.Parameters.Add("Tinh_DC", SqlDbType.NVarChar).Value = Tinh_DC;
            Cmd.Parameters.Add("Huyen_DC", SqlDbType.NVarChar).Value = Huyen_DC;
            Cmd.Parameters.Add("Xa_DC", SqlDbType.NVarChar).Value = Xa_DC;
            Cmd.Parameters.Add("Xom_DC", SqlDbType.NVarChar).Value = Xom_DC;

            Cmd.Parameters.Add("Tinh_TT", SqlDbType.NVarChar).Value = Tinh_TT;
            Cmd.Parameters.Add("Huyen_TT", SqlDbType.NVarChar).Value = Huyen_TT;
            Cmd.Parameters.Add("Xa_TT", SqlDbType.NVarChar).Value = Xa_TT;
            Cmd.Parameters.Add("Xom_TT", SqlDbType.NVarChar).Value = Xom_TT;
            Cmd.Parameters.Add("StateLapGiaDinh", SqlDbType.Int).Value = StateLapGiaDinh;

            Cmd.ExecuteNonQuery();

            if (IDNguoiLaoDong == 0)
            {
                sqlQuery = "SELECT TOP 1 IDNguoiLaoDong FROM TblNguoiLaoDong WHERE HoVaTen = @HoVaTen ORDER BY IDNguoiLaoDong DESC";
                Cmd.CommandText = sqlQuery;
                SqlDataReader Rd = Cmd.ExecuteReader();
                while (Rd.Read())
                {
                    IDNguoiLaoDong = int.Parse(Rd["IDNguoiLaoDong"].ToString());
                }
                Rd.Close();
            }

            sqlCon.Close();
            sqlCon.Dispose();
            tmpValue = 1;
        }
        catch
        {
            tmpValue = 0;
        }
        return tmpValue;
    }
    #endregion

    #region method setData
    public int setData(ref int IDNguoiLaoDong, string HoVaTen, DateTime NgaySinh, string CMND, string NoiCap, DateTime NgayCapCMND, string BHXH, string DienThoai, string Email, int IDDanToc, int IDTonGiao, string SucKhoe, double ChieuCao, double CanNang, int IDTrinhDoPhoThong, int IDNgoaiNgu, int IDTinHoc, string TrinhDoDaoTao, string TrinhDoKyNangNghe, string KhaNangNoiTroi,
        string Tinh_TT, string Huyen_TT, string Xa_TT, string Xom_TT, string Tinh_DC, string Huyen_DC, string Xa_DC, string Xom_DC,int tdtinhoc,int tdngoaingu,int StateLapGiaDinh ,int GioiTinh = 0)
    {
        int tmpValue = 0;

        try
        {
            string sqlQuery = "";

            sqlQuery = "IF NOT EXISTS (SELECT * FROM TblNguoiLaoDong WHERE IDNguoiLaoDong = @IDNguoiLaoDong) ";
            sqlQuery += "BEGIN INSERT INTO TblNguoiLaoDong(Ma,HoVaTen,IDGioiTinh,NgaySinh,CMND,NoiCap,NgayCapCMND,BHXH,DienThoai,Email,IDDanToc,IDTonGiao,SucKhoe,ChieuCao,CanNang,IDTrinhDoPhoThong,IDNgoaiNgu,IDTinHoc,TrinhDoDaoTao,TrinhDoKyNangNghe,KhaNangNoiTroi,Tinh_TT,Huyen_TT,Xa_TT,Xom_TT,Tinh_DC,Huyen_DC,Xa_DC,Xom_DC,IdTrinhDoTinHoc,IdTrinhDoNgoaiNgu,StateLapGiaDinh) OUTPUT INSERTED.IDNguoiLaoDong ";
            sqlQuery += " VALUES(@Ma,@HoVaTen,@IDGioiTinh,@NgaySinh,@CMND,@NoiCap,@NgayCapCMND,@BHXH,@DienThoai,@Email,@IDDanToc,@IDTonGiao,@SucKhoe,@ChieuCao,@CanNang,@IDTrinhDoPhoThong,@IDNgoaiNgu,@IDTinHoc,@TrinhDoDaoTao,@TrinhDoKyNangNghe,@KhaNangNoiTroi,@Tinh_TT,@Huyen_TT,@Xa_TT,@Xom_TT,@Tinh_DC,@Huyen_DC,@Xa_DC,@Xom_DC,@IdTrinhDoTinHoc,@IdTrinhDoNgoaiNgu,@StateLapGiaDinh) END ";
            sqlQuery += @"ELSE BEGIN UPDATE TblNguoiLaoDong SET HoVaTen = @HoVaTen,IDGioiTinh = @IDGioiTinh,NgaySinh = @NgaySinh,CMND = @CMND,NoiCap = @NoiCap,NgayCapCMND = @NgayCapCMND,BHXH = @BHXH,DienThoai = @DienThoai,Email = @Email,IDDanToc = @IDDanToc,IDTonGiao = @IDTonGiao,SucKhoe = @SucKhoe,ChieuCao = @ChieuCao,CanNang = @CanNang,IDTrinhDoPhoThong = @IDTrinhDoPhoThong,IDNgoaiNgu = @IDNgoaiNgu,IDTinHoc = @IDTinHoc, TrinhDoDaoTao = @TrinhDoDaoTao,TrinhDoKyNangNghe = @TrinhDoKyNangNghe,KhaNangNoiTroi = @KhaNangNoiTroi, Tinh_TT = @Tinh_TT,Huyen_TT = @Huyen_TT,Xa_TT = @Xa_TT,Xom_TT = @Xom_TT,Tinh_DC = @Tinh_DC,Huyen_DC = @Huyen_DC, Xa_DC = @Xa_DC,Xom_DC = @Xom_DC,IdTrinhDoTinHoc = @IdTrinhDoTinHoc,IdTrinhDoNgoaiNgu = @IdTrinhDoNgoaiNgu , StateLapGiaDinh= @StateLapGiaDinh
                           OUTPUT INSERTED.IDNguoiLaoDong WHERE IDNguoiLaoDong = @IDNguoiLaoDong END ";

            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();

            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;

            string MaNLD = "";

            if (IDNguoiLaoDong == 0)
            {
                MaNLD = this.getNextMaNLD();
            }

            Cmd.Parameters.Add("Ma", SqlDbType.NVarChar).Value = MaNLD;
            Cmd.Parameters.Add("IDNguoiLaoDong", SqlDbType.Int).Value = IDNguoiLaoDong;
            Cmd.Parameters.Add("HoVaTen", SqlDbType.NVarChar).Value = HoVaTen;
            Cmd.Parameters.Add("IDGioiTinh", SqlDbType.Int).Value = GioiTinh;
            Cmd.Parameters.Add("NgaySinh", SqlDbType.DateTime).Value = NgaySinh;
            Cmd.Parameters.Add("DienThoai", SqlDbType.NVarChar).Value = DienThoai;
            
            Cmd.Parameters.Add("Email", SqlDbType.NVarChar).Value = Email;
            Cmd.Parameters.Add("IDDanToc", SqlDbType.Int).Value = IDDanToc;
            Cmd.Parameters.Add("IDTonGiao", SqlDbType.Int).Value = IDTonGiao;
            Cmd.Parameters.Add("SucKhoe", SqlDbType.NVarChar).Value = SucKhoe;
            Cmd.Parameters.Add("ChieuCao", SqlDbType.Float).Value = ChieuCao;
            
            Cmd.Parameters.Add("CanNang", SqlDbType.Float).Value = CanNang;
            Cmd.Parameters.Add("IDTrinhDoPhoThong", SqlDbType.Int).Value = IDTrinhDoPhoThong;
            Cmd.Parameters.Add("IDNgoaiNgu", SqlDbType.Int).Value = IDNgoaiNgu;
            Cmd.Parameters.Add("IDTinHoc", SqlDbType.Int).Value = IDTinHoc;
            Cmd.Parameters.Add("CMND", SqlDbType.NVarChar).Value = CMND;
            
            Cmd.Parameters.Add("NgayCapCMND", SqlDbType.DateTime).Value = NgayCapCMND;
            Cmd.Parameters.Add("NoiCap", SqlDbType.NVarChar).Value = NoiCap;
            Cmd.Parameters.Add("BHXH", SqlDbType.NVarChar).Value = BHXH;
            Cmd.Parameters.Add("TrinhDoDaoTao", SqlDbType.NVarChar).Value = TrinhDoDaoTao;
            Cmd.Parameters.Add("TrinhDoKyNangNghe", SqlDbType.NVarChar).Value = TrinhDoKyNangNghe;
            
            Cmd.Parameters.Add("KhaNangNoiTroi", SqlDbType.NVarChar).Value = KhaNangNoiTroi;

            Cmd.Parameters.Add("Tinh_DC", SqlDbType.NVarChar).Value = Tinh_DC;
            Cmd.Parameters.Add("Huyen_DC", SqlDbType.NVarChar).Value = Huyen_DC;
            Cmd.Parameters.Add("Xa_DC", SqlDbType.NVarChar).Value = Xa_DC;
            Cmd.Parameters.Add("Xom_DC", SqlDbType.NVarChar).Value = Xom_DC;

            Cmd.Parameters.Add("Tinh_TT", SqlDbType.NVarChar).Value = Tinh_TT;
            Cmd.Parameters.Add("Huyen_TT", SqlDbType.NVarChar).Value = Huyen_TT;
            Cmd.Parameters.Add("Xa_TT", SqlDbType.NVarChar).Value = Xa_TT;
            Cmd.Parameters.Add("Xom_TT", SqlDbType.NVarChar).Value = Xom_TT;

            Cmd.Parameters.Add("IdTrinhDoTinHoc", SqlDbType.Int).Value = tdtinhoc;
            Cmd.Parameters.Add("IdTrinhDoNgoaiNgu", SqlDbType.Int).Value = tdngoaingu;
            Cmd.Parameters.Add("StateLapGiaDinh", SqlDbType.Int).Value = StateLapGiaDinh;
           // Cmd.ExecuteNonQuery();

            IDNguoiLaoDong = (int)Cmd.ExecuteScalar();

            //if (IDNguoiLaoDong == 0)
            //{
            //    sqlQuery = "SELECT TOP 1 IDNguoiLaoDong FROM TblNguoiLaoDong WHERE HoVaTen = @HoVaTen ORDER BY IDNguoiLaoDong DESC";
            //    Cmd.CommandText = sqlQuery;
            //    SqlDataReader Rd = Cmd.ExecuteReader();
            //    while (Rd.Read())
            //    {
            //        IDNguoiLaoDong = int.Parse(Rd["IDNguoiLaoDong"].ToString());
            //    }
            //    Rd.Close();
            //}

            sqlCon.Close();
            sqlCon.Dispose();
            tmpValue = 1;
        }
        catch (Exception ex)
        {
            tmpValue = 0;
        }
        return tmpValue;
    }
    #endregion

    #region Method setData()
    public int setData(int id, String HoVaTen, DateTime? NgaySinh, int IDGioiTinh, String CMND, DateTime? NgayCapCMND, int NoiCap, String DienThoai, String NoiThuongTru, String TaiKhoan, int IDNganHang, String MaSoThue, String Email, String BHXH, DateTime? NgayCapBHXH, int NoiCapBHXH, int NoiDangKyKhamBenh, int TrinhDoChuyenMon, int LinhVucDaoTao, String CongViecDaLam, int IdDoanhNghiep)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "IF NOT EXISTS (SELECT * FROM TblNguoiLaoDong WHERE IDNguoiLaoDong = @IDNguoiLaoDong) ";
            Cmd.CommandText += "BEGIN INSERT INTO TblNguoiLaoDong(Ma,HoVaTen,NgaySinh,IDGioiTinh,CMND,NgayCapCMND,NoiCap,DienThoai,NoiThuongTru,TaiKhoan,IDNganHang,MaSoThue,Email,BHXH,NgayCapBHXH,NoiCapBHXH,NoiDangKyKhamBenh,TrinhDoChuyenMon,LinhVucDaoTao,CongViecDaLam,IdDoanhNghiep) OUTPUT INSERTED.IDNguoiLaoDong VALUES(@Ma,@HoVaTen,@NgaySinh,@IDGioiTinh,@CMND,@NgayCapCMND,@NoiCap,@DienThoai,@NoiThuongTru,@TaiKhoan,@IDNganHang,@MaSoThue,@Email,@BHXH,@NgayCapBHXH,@NoiCapBHXH,@NoiDangKyKhamBenh,@TrinhDoChuyenMon,@LinhVucDaoTao,@CongViecDaLam,@IdDoanhNghiep) END ";
            Cmd.CommandText += "ELSE BEGIN UPDATE TblNguoiLaoDong SET HoVaTen = @HoVaTen,NgaySinh = @NgaySinh,IDGioiTinh = @IDGioiTinh,CMND = @CMND,NgayCapCMND = @NgayCapCMND,NoiCap = @NoiCap,DienThoai = @DienThoai,NoiThuongTru = @NoiThuongTru,TaiKhoan = @TaiKhoan,IDNganHang = @IDNganHang,MaSoThue = @MaSoThue,Email = @Email,BHXH = @BHXH,NgayCapBHXH = @NgayCapBHXH,NoiCapBHXH = @NoiCapBHXH,NoiDangKyKhamBenh = @NoiDangKyKhamBenh,TrinhDoChuyenMon = @TrinhDoChuyenMon,LinhVucDaoTao = @LinhVucDaoTao,CongViecDaLam = @CongViecDaLam,IdDoanhNghiep = @IdDoanhNghiep OUTPUT INSERTED.IDNguoiLaoDong WHERE IDNguoiLaoDong = @IDNguoiLaoDong END";

            Cmd.Parameters.Add("Ma", SqlDbType.NVarChar).Value = this.getNextMaNLD();
            Cmd.Parameters.Add("IDNguoiLaoDong", SqlDbType.Int).Value = id;
            Cmd.Parameters.Add("HoVaTen", SqlDbType.NVarChar).Value = HoVaTen.Trim();
            if (NgaySinh != null)
            {
                Cmd.Parameters.Add("NgaySinh", SqlDbType.DateTime).Value = NgaySinh;
            }
            else
            {
                Cmd.Parameters.Add("NgaySinh", SqlDbType.DateTime).Value = DBNull.Value;
            }
            Cmd.Parameters.Add("IDGioiTinh", SqlDbType.Int).Value = IDGioiTinh;
            Cmd.Parameters.Add("CMND", SqlDbType.NVarChar).Value = CMND.Trim();
            if (NgayCapCMND != null)
            {
                Cmd.Parameters.Add("NgayCapCMND", SqlDbType.DateTime).Value = NgayCapCMND;
            }
            else
            {
                Cmd.Parameters.Add("NgayCapCMND", SqlDbType.DateTime).Value = DBNull.Value;
            }
            Cmd.Parameters.Add("NoiCap", SqlDbType.Int).Value = NoiCap;
            Cmd.Parameters.Add("DienThoai", SqlDbType.NVarChar).Value = DienThoai.Trim();
            Cmd.Parameters.Add("NoiThuongTru", SqlDbType.NVarChar).Value = NoiThuongTru.Trim();
            Cmd.Parameters.Add("Email", SqlDbType.NVarChar).Value = Email.Trim();
            Cmd.Parameters.Add("TaiKhoan", SqlDbType.NVarChar).Value = TaiKhoan.Trim();
            Cmd.Parameters.Add("IDNganHang", SqlDbType.Int).Value = IDNganHang;
            Cmd.Parameters.Add("MaSoThue", SqlDbType.NVarChar).Value = MaSoThue.Trim();
            Cmd.Parameters.Add("BHXH", SqlDbType.NVarChar).Value = BHXH.Trim();
            if (NgayCapBHXH != null)
            {
                Cmd.Parameters.Add("NgayCapBHXH", SqlDbType.DateTime).Value = NgayCapBHXH;
            }
            else
            {
                Cmd.Parameters.Add("NgayCapBHXH", SqlDbType.DateTime).Value = DBNull.Value;
            }
            Cmd.Parameters.Add("NoiCapBHXH", SqlDbType.Int).Value = NoiCapBHXH;
            Cmd.Parameters.Add("NoiDangKyKhamBenh", SqlDbType.Int).Value = NoiDangKyKhamBenh;
            Cmd.Parameters.Add("TrinhDoChuyenMon", SqlDbType.Int).Value = TrinhDoChuyenMon;
            Cmd.Parameters.Add("LinhVucDaoTao", SqlDbType.Int).Value = LinhVucDaoTao;
            Cmd.Parameters.Add("CongViecDaLam", SqlDbType.NVarChar).Value = CongViecDaLam.Trim();

            Cmd.Parameters.Add("IdDoanhNghiep", SqlDbType.Int).Value = IdDoanhNghiep;

            int ret = (int)Cmd.ExecuteScalar();

            this.SQLClose();

            return ret;
        }
        catch (Exception ex)
        {
            this.Message = ex.Message;
            this.ErrorCode = ex.HResult;
            return 0;
        }

    }

    #endregion

    #region Method getListBaoHiemThatNghiep
    public DataTable getListBaoHiemThatNghiep()
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "SELECT P.[IDNguoiLaoDong],P.[HoVaTen],P.[CMND],P.[BHXH] FROM TblNldTuVan AS P";

            DataTable ret = this.findAll(Cmd);

            this.SQLClose();
            return ret;
        }
        catch (Exception ex)
        {
            this.Message = ex.Message;
            this.ErrorCode = ex.HResult;
            return null;
        }
    }
    #endregion 

    #region method getData
    public DataTable getData(string searchKey)
    {
        string sqlQuery = "";
        if (searchKey.Trim() != "")
        {
            sqlQuery += " AND UPPER(RTRIM(LTRIM(HoVaTen))) LIKE N'%'+UPPER(RTRIM(LTRIM(@SearchKey)))+'%'";
        }
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.Parameters.Add("SearchKey", SqlDbType.NVarChar).Value = searchKey;
            Cmd.CommandText = "SELECT 0 AS TT, *, REPLACE(REPLACE(CAST(State AS varchar),'1',N'Kích hoạt'),'0',N'Đóng') AS StateName, ((Xom_DC)+', '+(Xa_DC)+', '+(Huyen_DC)+', '+(Tinh_DC)) As DiaChi, ISNULL((SELECT Count(*) FROM TblNldTuVan WHERE IDNguoiLaoDong = TblNguoiLaoDong.IDNguoiLaoDong),'') AS CountItem FROM TblNguoiLaoDong WHERE 1 = 1 " + sqlQuery;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ds.Tables[0].Rows[i]["TT"] = (i + 1);
            }
            sqlCon.Close();
            sqlCon.Dispose();
            objTable = ds.Tables[0];
        }
        catch
        {

        }
        return objTable;
    }
    #endregion

    #region method getDataTuVanXuatKhau
    public DataTable getDataTuVanXuatKhau(string searchKey)
    {
        string sqlQuery = "";
        if (searchKey.Trim() != "")
        {
            sqlQuery += " AND UPPER(RTRIM(LTRIM(HoVaTen))) LIKE N'%'+UPPER(RTRIM(LTRIM(@SearchKey)))+'%'";
        }
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.Parameters.Add("SearchKey", SqlDbType.NVarChar).Value = searchKey;
            Cmd.CommandText = "SELECT 0 AS TT, *, REPLACE(REPLACE(CAST(TblNguoiLaoDong.State AS varchar),'1',N'Kích hoạt'),'0',N'Đóng') AS StateName FROM TblNguoiLaoDong, TblNldDangKy WHERE TblNguoiLaoDong.IDNguoiLaoDong = TblNldDangKy.IDNguoiLaoDong " + sqlQuery;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ds.Tables[0].Rows[i]["TT"] = (i + 1);
            }
            sqlCon.Close();
            sqlCon.Dispose();
            objTable = ds.Tables[0];
        }
        catch
        {

        }
        return objTable;
    }
    #endregion

    #region method getDataById
    public DataTable getDataById(int IDNguoiLaoDong)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT * FROM TblNguoiLaoDong WHERE IDNguoiLaoDong = @IDNguoiLaoDong";
            Cmd.Parameters.Add("IDNguoiLaoDong", SqlDbType.Int).Value = IDNguoiLaoDong;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlCon.Close();
            sqlCon.Dispose();
            objTable = ds.Tables[0];
        }
        catch
        {

        }
        return objTable;
    }
    #endregion

    #region method getDataByCode
    public DataTable getDataByCode(string Code)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT * FROM TblNguoiLaoDong WHERE (Ma = @Code) OR (CMND = @Code) OR (BHXH = @Code)";
            Cmd.Parameters.Add("Code", SqlDbType.NVarChar).Value = Code;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlCon.Close();
            sqlCon.Dispose();
            objTable = ds.Tables[0];
        }
        catch
        {

        }
        return objTable;
    }
    #endregion

    #region method delData
    public void delData(int IDNguoiLaoDong)
    {
        try
        {
            string sqlQuery = "";
            sqlQuery = "DELETE TblNguoiLaoDong WHERE IDNguoiLaoDong = @IDNguoiLaoDong ";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("IDNguoiLaoDong", SqlDbType.Int).Value = IDNguoiLaoDong;
            Cmd.ExecuteNonQuery();
            sqlCon.Close();
            sqlCon.Dispose();
        }
        catch
        {

        }
    }
    #endregion

    #region method checkCode
    public bool checkCode(string Ma)
    {
        bool tmpValue = false;
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT * FROM TblNguoiLaoDong WHERE Ma = @Ma";
            Cmd.Parameters.Add("Ma", SqlDbType.NVarChar).Value = Ma;
            SqlDataReader Rd = Cmd.ExecuteReader();
            while (Rd.Read())
            {
                tmpValue = true;
            }
            Rd.Close();
            sqlCon.Close();
            sqlCon.Dispose();
        }
        catch
        {

        }
        return tmpValue;
    }
    #endregion

    #region Qua trinh dao tao TblNldQuaTrinhDaoTao

    #region method setDataNldQuaTrinhDaoTao
    public int setDataNldQuaTrinhDaoTao(int IDNldQuaTrinhDaoTao, int IDNguoiLaoDong, string Donvi, int IDTrinhdochuyenmon, int IdNhomNganh, int IDDTNganhNghe)
    {
        int tmpValue = 0;

        try
        {
            string sqlQuery = "";

            sqlQuery = "IF NOT EXISTS (SELECT * FROM TblNldQuaTrinhDaoTao WHERE IDNldQuaTrinhDaoTao = @IDNldQuaTrinhDaoTao AND IDNguoiLaoDong = @IDNguoiLaoDong) ";
            sqlQuery += "BEGIN INSERT INTO TblNldQuaTrinhDaoTao(IDNguoiLaoDong,Donvi,IDTrinhdochuyenmon,IdNhomNganh,IDDTNganhNghe) VALUES(@IDNguoiLaoDong,@Donvi,@IDTrinhdochuyenmon,@IdNhomNganh,@IDDTNganhNghe) END ";
            sqlQuery += "ELSE BEGIN UPDATE TblNldQuaTrinhDaoTao SET Donvi = @Donvi, IDTrinhdochuyenmon = @IDTrinhdochuyenmon, IdNhomNganh = @IdNhomNganh, IDDTNganhNghe = @IDDTNganhNghe WHERE IDNldQuaTrinhDaoTao = @IDNldQuaTrinhDaoTao  AND IDNguoiLaoDong = @IDNguoiLaoDong END ";

            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();

            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;

            Cmd.Parameters.Add("IDNldQuaTrinhDaoTao", SqlDbType.Int).Value = IDNldQuaTrinhDaoTao;
            Cmd.Parameters.Add("IDNguoiLaoDong", SqlDbType.Int).Value = IDNguoiLaoDong;
            Cmd.Parameters.Add("Donvi", SqlDbType.NVarChar).Value = Donvi;
            Cmd.Parameters.Add("IDTrinhdochuyenmon", SqlDbType.Int).Value = IDTrinhdochuyenmon;
            Cmd.Parameters.Add("IdNhomNganh", SqlDbType.Int).Value = IdNhomNganh;
            Cmd.Parameters.Add("IDDTNganhNghe", SqlDbType.Int).Value = IDDTNganhNghe;

            Cmd.ExecuteNonQuery();

            sqlCon.Close();
            sqlCon.Dispose();
            tmpValue = 1;
        }
        catch
        {
            tmpValue = 0;
        }
        return tmpValue;
    }
    #endregion

    #region method getDataNldQuaTrinhDaoTao
    public DataTable getDataNldQuaTrinhDaoTao(int IDNguoiLaoDong)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.Parameters.Add("IDNguoiLaoDong", SqlDbType.Int).Value = IDNguoiLaoDong;
            Cmd.CommandText = "SELECT 0 AS TT, *, (SELECT NameTrinhdoChuyenMon FROM TblTrinhDoChuyenMon WHERE IDTrinhDoChuyenMon = A.IDTrinhdochuyenmon) AS NameTrinhdoChuyenMon, (SELECT NameDTNganhNghe FROM TblDTNganhNghe WHERE IDDTNganhNghe = A.IDDTNganhNghe) AS NameDTNganhNghe FROM TblNldQuaTrinhDaoTao A WHERE A.IDNguoiLaoDong = @IDNguoiLaoDong";
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ds.Tables[0].Rows[i]["TT"] = (i + 1);
            }
            sqlCon.Close();
            sqlCon.Dispose();
            objTable = ds.Tables[0];
        }
        catch
        {

        }
        return objTable;
    }
    #endregion

    #region method getDataNldQuaTrinhDaoTaoById
    public DataTable getDataNldQuaTrinhDaoTaoById(int IDNldQuaTrinhDaoTao)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT * FROM TblNldQuaTrinhDaoTao WHERE IDNldQuaTrinhDaoTao = @IDNldQuaTrinhDaoTao";
            Cmd.Parameters.Add("IDNldQuaTrinhDaoTao", SqlDbType.Int).Value = IDNldQuaTrinhDaoTao;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlCon.Close();
            sqlCon.Dispose();
            objTable = ds.Tables[0];
        }
        catch
        {

        }
        return objTable;
    }
    #endregion

    #region method delDataNldQuaTrinhDaoTao
    public void delDataNldQuaTrinhDaoTao(int IDNldQuaTrinhDaoTao)
    {
        try
        {
            string sqlQuery = "";
            sqlQuery = "DELETE TblNldQuaTrinhDaoTao WHERE IDNldQuaTrinhDaoTao = @IDNldQuaTrinhDaoTao ";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("IDNldQuaTrinhDaoTao", SqlDbType.Int).Value = IDNldQuaTrinhDaoTao;
            Cmd.ExecuteNonQuery();
            sqlCon.Close();
            sqlCon.Dispose();
        }
        catch
        {

        }
    }
    #endregion

    #endregion

    #region Qua trinh dao tao TblNldQuatrinhCongTac

    #region method setDataNldQuatrinhCongTac
    public int setDataNldQuatrinhCongTac(int IDNldQuaTrinhCongTac, int IDNguoiLaoDong, string DonVi, int IDLinhVuc, int IDChucVu, DateTime NgayBatDau, DateTime NgayKetThuc)
    {
        int tmpValue = 0;

        try
        {
            string sqlQuery = "";

            sqlQuery = "IF NOT EXISTS (SELECT * FROM TblNldQuatrinhCongTac WHERE IDNldQuaTrinhCongTac = @IDNldQuaTrinhCongTac AND IDNguoiLaoDong = @IDNguoiLaoDong) ";
            sqlQuery += "BEGIN INSERT INTO TblNldQuatrinhCongTac(IDNguoiLaoDong,Donvi,IDLinhVuc,IDChucVu,NgayBatDau,NgayKetThuc) VALUES(@IDNguoiLaoDong,@Donvi,@IDLinhVuc,@IDChucVu,@NgayBatDau,@NgayKetThuc) END ";
            sqlQuery += "ELSE BEGIN UPDATE TblNldQuatrinhCongTac SET DonVi = @DonVi,IDLinhVuc = @IDLinhVuc,IDChucVu = @IDChucVu,NgayBatDau = @NgayBatDau,NgayKetThuc = @NgayKetThuc WHERE IDNldQuaTrinhCongTac = @IDNldQuaTrinhCongTac AND IDNguoiLaoDong = @IDNguoiLaoDong END ";

            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();

            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;

            Cmd.Parameters.Add("IDNldQuaTrinhCongTac", SqlDbType.Int).Value = IDNldQuaTrinhCongTac;
            Cmd.Parameters.Add("IDNguoiLaoDong", SqlDbType.Int).Value = IDNguoiLaoDong;
            Cmd.Parameters.Add("DonVi", SqlDbType.NVarChar).Value = DonVi;
            Cmd.Parameters.Add("IDLinhVuc", SqlDbType.Int).Value = IDLinhVuc;
            Cmd.Parameters.Add("IDChucVu", SqlDbType.Int).Value = IDChucVu;
            Cmd.Parameters.Add("NgayBatDau", SqlDbType.DateTime).Value = NgayBatDau;
            Cmd.Parameters.Add("NgayKetThuc", SqlDbType.DateTime).Value = NgayKetThuc;

            Cmd.ExecuteNonQuery();

            sqlCon.Close();
            sqlCon.Dispose();
            tmpValue = 1;
        }
        catch
        {
            tmpValue = 0;
        }
        return tmpValue;
    }
    #endregion

    #region method getDataNldQuatrinhCongTac
    public DataTable getDataNldQuatrinhCongTac(int IDNguoiLaoDong)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.Parameters.Add("IDNguoiLaoDong", SqlDbType.Int).Value = IDNguoiLaoDong;
            Cmd.CommandText = "SELECT 0 AS TT, *, (SELECT NameChucVu FROM TblChucVu WHERE IDChucVu = TblNldQuatrinhCongTac.IDChucVu) AS NameChucVu, (SELECT NameLinhVuc FROM TblLinhVuc WHERE IDLinhVuc = TblNldQuatrinhCongTac.IDLinhVuc) AS NameLinhVuc FROM TblNldQuatrinhCongTac WHERE IDNguoiLaoDong = @IDNguoiLaoDong";
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ds.Tables[0].Rows[i]["TT"] = (i + 1);
            }
            sqlCon.Close();
            sqlCon.Dispose();
            objTable = ds.Tables[0];
        }
        catch
        {

        }
        return objTable;
    }
    #endregion

    #region method getDataNldQuatrinhCongTacById
    public DataTable getDataNldQuatrinhCongTacById(int IDNldQuaTrinhCongTac)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT * FROM TblNldQuatrinhCongTac WHERE IDNldQuaTrinhCongTac = @IDNldQuaTrinhCongTac";
            Cmd.Parameters.Add("IDNldQuaTrinhCongTac", SqlDbType.Int).Value = IDNldQuaTrinhCongTac;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlCon.Close();
            sqlCon.Dispose();
            objTable = ds.Tables[0];
        }
        catch
        {

        }
        return objTable;
    }
    #endregion

    #region method delDataNldQuaTrinhCongTac
    public void delDataNldQuaTrinhCongTac(int IDNldQuaTrinhCongTac)
    {
        try
        {
            string sqlQuery = "";
            sqlQuery = "DELETE TblNldQuatrinhCongTac WHERE IDNldQuaTrinhCongTac = @IDNldQuaTrinhCongTac ";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("IDNldQuaTrinhCongTac", SqlDbType.Int).Value = IDNldQuaTrinhCongTac;
            Cmd.ExecuteNonQuery();
            sqlCon.Close();
            sqlCon.Dispose();
        }
        catch
        {

        }
    }
    #endregion

    #endregion

    #region Kinh nghiem lam viec TblNlDKinhNghiem

    #region method setDataTblNlDKinhNghiem
    public int setDataTblNlDKinhNghiem(int IDNldKinhNghiem, int IDNguoiLaoDong, string DonVi, int IDLinhVuc, int IDChucVu, DateTime NgayBatDau, DateTime NgayKetThuc)
    {
        int tmpValue = 0;

        try
        {
            string sqlQuery = "";

            sqlQuery = "IF NOT EXISTS (SELECT * FROM TblNlDKinhNghiem WHERE IDNldKinhNghiem = @IDNldKinhNghiem AND IDNguoiLaoDong = @IDNguoiLaoDong) ";
            sqlQuery += "BEGIN INSERT INTO TblNlDKinhNghiem(IDNguoiLaoDong,Donvi,IDLinhVuc,IDChucVu,NgayBatDau,NgayKetThuc) VALUES(@IDNguoiLaoDong,@Donvi,@IDLinhVuc,@IDChucVu,@NgayBatDau,@NgayKetThuc) END ";
            sqlQuery += "ELSE BEGIN UPDATE TblNlDKinhNghiem SET DonVi = @DonVi,IDLinhVuc = @IDLinhVuc,IDChucVu = @IDChucVu,NgayBatDau = @NgayBatDau,NgayKetThuc = @NgayKetThuc WHERE IDNldKinhNghiem = @IDNldKinhNghiem AND IDNguoiLaoDong = @IDNguoiLaoDong END ";

            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();

            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;

            Cmd.Parameters.Add("IDNldKinhNghiem", SqlDbType.Int).Value = IDNldKinhNghiem;
            Cmd.Parameters.Add("IDNguoiLaoDong", SqlDbType.Int).Value = IDNguoiLaoDong;
            Cmd.Parameters.Add("DonVi", SqlDbType.NVarChar).Value = DonVi;
            Cmd.Parameters.Add("IDLinhVuc", SqlDbType.Int).Value = IDLinhVuc;
            Cmd.Parameters.Add("IDChucVu", SqlDbType.Int).Value = IDChucVu;
            Cmd.Parameters.Add("NgayBatDau", SqlDbType.DateTime).Value = NgayBatDau;
            Cmd.Parameters.Add("NgayKetThuc", SqlDbType.DateTime).Value = NgayKetThuc;

            Cmd.ExecuteNonQuery();

            sqlCon.Close();
            sqlCon.Dispose();
            tmpValue = 1;
        }
        catch
        {
            tmpValue = 0;
        }
        return tmpValue;
    }
    #endregion

    #region method getDataNlDKinhNghiem
    public DataTable getDataNlDKinhNghiem(int IDNguoiLaoDong)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.Parameters.Add("IDNguoiLaoDong", SqlDbType.Int).Value = IDNguoiLaoDong;
            Cmd.CommandText = "SELECT 0 AS TT, *, (SELECT NameChucVu FROM TblChucVu WHERE IDChucVu = TblNlDKinhNghiem.IDChucVu) AS NameChucVu, (SELECT NameLinhVuc FROM TblLinhVuc WHERE IDLinhVuc = TblNlDKinhNghiem.IDLinhVuc) AS NameLinhVuc FROM TblNlDKinhNghiem WHERE IDNguoiLaoDong = @IDNguoiLaoDong";
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ds.Tables[0].Rows[i]["TT"] = (i + 1);
            }
            sqlCon.Close();
            sqlCon.Dispose();
            objTable = ds.Tables[0];
        }
            catch
        {

        }
        return objTable;
    }
    #endregion

    #region method getDataNlDKinhNghiemById
    public DataTable getDataNlDKinhNghiemById(int IDNldKinhNghiem)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT * FROM TblNlDKinhNghiem WHERE IDNldKinhNghiem = @IDNldKinhNghiem";
            Cmd.Parameters.Add("IDNldKinhNghiem", SqlDbType.Int).Value = IDNldKinhNghiem;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlCon.Close();
            sqlCon.Dispose();
            objTable = ds.Tables[0];
        }
        catch
        {

        }
        return objTable;
    }
    #endregion

    #region method delDataNlDKinhNghiem
    public void delDataNlDKinhNghiem(int IDNldKinhNghiem)
    {
        try
        {
            string sqlQuery = "";
            sqlQuery = "DELETE TblNlDKinhNghiem WHERE IDNldKinhNghiem = @IDNldKinhNghiem ";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("IDNldKinhNghiem", SqlDbType.Int).Value = IDNldKinhNghiem;
            Cmd.ExecuteNonQuery();
            sqlCon.Close();
            sqlCon.Dispose();
        }
        catch
        {

        }
    }
    #endregion

    #endregion

    #region Noi dung tu van TblNldTuVan

    #region method setDataTblNldTuVan
    public int setDataTblNldTuVan(ref int IDNldTuVan, int IDNguoiLaoDong, int IDLoaiLaoDong, int IDTuVan, float MucLuongTN, string LyDoTN, string DnDaLienHe, bool TuVanPhapLuat, bool TuVanViecLam, bool TuVanDuHoc, bool TuVanHocNghe, bool TuVanXuatKhauLaoDong, bool TuVanBHTN, bool TuVanKhac, string Noidung, string ViTriCongViec, float MucLuongThapNhat, string DieuKienLamViec, string DiaDiemLamViec, string ViTriCongViec2, float MucLuongThapNhat2, string DieuKienLamViec2, string DiaDiemLamViec2, string NoiDungKhac, DateTime NgayTuVan, string NguoiTuVan, string CongViecTruocThatNghiep)
    {
        int tmpValue = 0;

        try
        {
            string sqlQuery = "";

            sqlQuery = "IF NOT EXISTS (SELECT * FROM TblNldTuVan WHERE IDNldTuVan = @IDNldTuVan) ";
            sqlQuery += "BEGIN INSERT INTO TblNldTuVan(IDNguoiLaoDong,IDLoaiLaoDong,IDTuVan,MucLuongTN,LyDoTN,DnDaLienHe,TuVanPhapLuat,TuVanViecLam,TuVanDuHoc,TuVanHocNghe,TuVanXuatKhauLaoDong,TuVanBHTN,TuVanKhac,Noidung,ViTriCongViec,MucLuongThapNhat,DieuKienLamViec,DiaDiemLamViec,ViTriCongViec2,MucLuongThapNhat2,DieuKienLamViec2,DiaDiemLamViec2,NoiDungKhac,NgayTuVan,NguoiTuVan,CongViecTruocThatNghiep) VALUES(@IDNguoiLaoDong,@IDLoaiLaoDong,@IDTuVan,@MucLuongTN,@LyDoTN,@DnDaLienHe,@TuVanPhapLuat,@TuVanViecLam,@TuVanDuHoc,@TuVanHocNghe,@TuVanXuatKhauLaoDong,@TuVanBHTN,@TuVanKhac,@Noidung,@ViTriCongViec,@MucLuongThapNhat,@DieuKienLamViec,@DiaDiemLamViec,@ViTriCongViec2,@MucLuongThapNhat2,@DieuKienLamViec2,@DiaDiemLamViec2,@NoiDungKhac,@NgayTuVan,@NguoiTuVan,@CongViecTruocThatNghiep) END ";
            sqlQuery += "ELSE BEGIN UPDATE TblNldTuVan SET IDLoaiLaoDong = @IDLoaiLaoDong, IDTuVan = @IDTuVan, MucLuongTN = @MucLuongTN, LyDoTN = @LyDoTN, DnDaLienHe = @DnDaLienHe, TuVanPhapLuat = @TuVanPhapLuat, TuVanViecLam = @TuVanViecLam, TuVanDuHoc = @TuVanDuHoc, TuVanHocNghe = @TuVanHocNghe, TuVanXuatKhauLaoDong = @TuVanXuatKhauLaoDong, TuVanBHTN = @TuVanBHTN, TuVanKhac = @TuVanKhac, Noidung = @Noidung, ViTriCongViec = @ViTriCongViec,MucLuongThapNhat = @MucLuongThapNhat,DieuKienLamViec = @DieuKienLamViec,DiaDiemLamViec = @DiaDiemLamViec, ViTriCongViec2 = @ViTriCongViec2,MucLuongThapNhat2 = @MucLuongThapNhat2,DieuKienLamViec2 = @DieuKienLamViec2,DiaDiemLamViec2 = @DiaDiemLamViec2, NoiDungKhac = @NoiDungKhac, NgayTuVan = @NgayTuVan, NguoiTuVan = @NguoiTuVan, CongViecTruocThatNghiep = @CongViecTruocThatNghiep WHERE IDNldTuVan = @IDNldTuVan END ";

            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();

            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;

            Cmd.Parameters.Add("IDNldTuVan", SqlDbType.Int).Value = IDNldTuVan;
            Cmd.Parameters.Add("IDNguoiLaoDong", SqlDbType.Int).Value = IDNguoiLaoDong;
            Cmd.Parameters.Add("IDLoaiLaoDong", SqlDbType.Int).Value = IDLoaiLaoDong;
            Cmd.Parameters.Add("Noidung", SqlDbType.NVarChar).Value = Noidung;
            Cmd.Parameters.Add("IDTuVan", SqlDbType.Int).Value = IDTuVan;

            Cmd.Parameters.Add("MucLuongTN", SqlDbType.Float).Value = MucLuongTN;
            Cmd.Parameters.Add("LyDoTN", SqlDbType.NVarChar).Value = LyDoTN;
            Cmd.Parameters.Add("DnDaLienHe", SqlDbType.NVarChar).Value = DnDaLienHe;
            Cmd.Parameters.Add("TuVanPhapLuat", SqlDbType.Bit).Value = TuVanPhapLuat;
            Cmd.Parameters.Add("TuVanViecLam", SqlDbType.Bit).Value = TuVanViecLam;
            
            Cmd.Parameters.Add("TuVanDuHoc", SqlDbType.Bit).Value = TuVanDuHoc;
            Cmd.Parameters.Add("TuVanHocNghe", SqlDbType.Bit).Value = TuVanHocNghe;
            Cmd.Parameters.Add("TuVanXuatKhauLaoDong", SqlDbType.Bit).Value = TuVanXuatKhauLaoDong;
            Cmd.Parameters.Add("TuVanBHTN", SqlDbType.Bit).Value = TuVanBHTN;
            Cmd.Parameters.Add("TuVanKhac", SqlDbType.Bit).Value = TuVanKhac;
            
            Cmd.Parameters.Add("ViTriCongViec", SqlDbType.NVarChar).Value = ViTriCongViec;
            Cmd.Parameters.Add("MucLuongThapNhat", SqlDbType.Float).Value = MucLuongThapNhat;
            Cmd.Parameters.Add("DieuKienLamViec", SqlDbType.NVarChar).Value = DieuKienLamViec;
            Cmd.Parameters.Add("DiaDiemLamViec", SqlDbType.NVarChar).Value = DiaDiemLamViec;

            Cmd.Parameters.Add("ViTriCongViec2", SqlDbType.NVarChar).Value = ViTriCongViec2;
            Cmd.Parameters.Add("MucLuongThapNhat2", SqlDbType.Float).Value = MucLuongThapNhat2;
            Cmd.Parameters.Add("DieuKienLamViec2", SqlDbType.NVarChar).Value = DieuKienLamViec2;
            Cmd.Parameters.Add("DiaDiemLamViec2", SqlDbType.NVarChar).Value = DiaDiemLamViec2;

            Cmd.Parameters.Add("NoiDungKhac", SqlDbType.NVarChar).Value = NoiDungKhac;
            
            Cmd.Parameters.Add("NgayTuVan", SqlDbType.DateTime).Value = NgayTuVan;
            Cmd.Parameters.Add("NguoiTuVan", SqlDbType.NVarChar).Value = NguoiTuVan;
            Cmd.Parameters.Add("CongViecTruocThatNghiep", SqlDbType.NVarChar).Value = CongViecTruocThatNghiep;
            Cmd.ExecuteNonQuery();

            if (IDNldTuVan == 0)
            {
                sqlQuery = "SELECT TOP 1 IDNldTuVan FROM TblNldTuVan ORDER BY IDNldTuVan DESC";
                Cmd.CommandText = sqlQuery;
                SqlDataReader Rd = Cmd.ExecuteReader();
                while (Rd.Read())
                {
                    IDNldTuVan = int.Parse(Rd["IDNldTuVan"].ToString());
                }
                Rd.Close();

                sqlQuery = "UPDATE TblNldTuVan SET LanTuVan = (ISNULL((SELECT COUNT(*) FROM TblNldTuVan WHERE IDNguoiLaoDong = @IDNguoiLaoDong AND IDNldTuVan < @IDNldTuVan1),0) + 1) WHERE IDNldTuVan = @IDNldTuVan1";
                Cmd.Parameters.Add("IDNldTuVan1", SqlDbType.Int).Value = IDNldTuVan;
                Cmd.CommandText = sqlQuery;
                Cmd.ExecuteNonQuery();
            }

            sqlCon.Close();
            sqlCon.Dispose();
            tmpValue = 1;
        }
        catch
        {
            tmpValue = 0;
        }
        return tmpValue;
    }
    #endregion

    #region method setDataTblNldTuVan
    public int setDataTblNldTuVan(ref int IDNldTuVan, int IDNguoiLaoDong, int IDTuVan, string Noidung, DateTime NgayTuVan, string NguoiTuVan)
    {
        int tmpValue = 0;

        try
        {
            string sqlQuery = "";

            sqlQuery = "IF NOT EXISTS (SELECT * FROM TblNldTuVan WHERE IDNldTuVan = @IDNldTuVan AND IDNguoiLaoDong = @IDNguoiLaoDong) ";
            sqlQuery += "BEGIN INSERT INTO TblNldTuVan(IDNguoiLaoDong,IDTuVan,Noidung,NgayTuVan,NguoiTuVan) VALUES(@IDNguoiLaoDong,@IDTuVan,@Noidung,@NgayTuVan,@NguoiTuVan) END ";
            sqlQuery += "ELSE BEGIN UPDATE TblNldTuVan SET IDTuVan = @IDTuVan,Noidung = @Noidung,NgayTuVan = @NgayTuVan,NguoiTuVan = @NguoiTuVan WHERE IDNldTuVan = @IDNldTuVan AND IDNguoiLaoDong = @IDNguoiLaoDong END ";

            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();

            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;

            Cmd.Parameters.Add("IDNldTuVan", SqlDbType.Int).Value = IDNldTuVan;
            Cmd.Parameters.Add("IDNguoiLaoDong", SqlDbType.Int).Value = IDNguoiLaoDong;
            Cmd.Parameters.Add("Noidung", SqlDbType.NVarChar).Value = Noidung;
            Cmd.Parameters.Add("IDTuVan", SqlDbType.Int).Value = IDTuVan;
            Cmd.Parameters.Add("NgayTuVan", SqlDbType.DateTime).Value = NgayTuVan;
            Cmd.Parameters.Add("NguoiTuVan", SqlDbType.NVarChar).Value = NguoiTuVan;

            Cmd.ExecuteNonQuery();

            if (IDNldTuVan == 0)
            {
                sqlQuery = "SELECT TOP 1 IDNldTuVan FROM TblNldTuVan ORDER BY IDNldTuVan DESC";
                Cmd.CommandText = sqlQuery;
                SqlDataReader Rd = Cmd.ExecuteReader();
                while (Rd.Read())
                {
                    IDNldTuVan = int.Parse(Rd["IDNldTuVan"].ToString());
                }
                Rd.Close();
            }

            sqlCon.Close();
            sqlCon.Dispose();
            tmpValue = 1;
        }
        catch
        {
            tmpValue = 0;
        }
        return tmpValue;
    }
    #endregion

    #region method getDataTblNldTuVan
    public DataTable getDataTblNldTuVan()
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT 0 AS TT, *, (SELECT HoVaTen FROM TblNguoiLaoDong WHERE IDNguoiLaoDong = TblNldTuVan.IDNguoiLaoDong) AS HoVaTen FROM TblNldTuVan, TblTuVan WHERE TblNldTuVan.IDTuVan = TblTuVan.IDTuVan ORDER BY NgayTuVan DESC";
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ds.Tables[0].Rows[i]["TT"] = (i + 1);
            }
            sqlCon.Close();
            sqlCon.Dispose();
            objTable = ds.Tables[0];
        }
        catch
        {

        }
        return objTable;
    }
    #endregion

    #region method getDataTblNldTuVan1
    public DataTable getDataTblNldTuVan1(string SearchKey, string HoVaTen)
    {
        string sqlQuery = "", sqlQueryHoVaTen = "";
        if (SearchKey.Trim() != "")
        {
            sqlQuery = " AND (UPPER(RTRIM(LTRIM(TblNguoiLaoDong.HoVaTen))) LIKE N'%'+UPPER(RTRIM(LTRIM(@SearchKey)))+'%' OR (DienThoai = @SearchKey) OR (CMND = @SearchKey) OR (BHXH = @SearchKey))";
        }
        if (HoVaTen.Trim() != "")
        {
            sqlQueryHoVaTen = " AND HoVaTen = @HoVaTen";
        }
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT TblNldTuVan.IDNguoiLaoDong, IDNldTuVan, HoVaTen, ((Xom_DC)+', '+(Xa_DC)+', '+(Huyen_DC)+', '+(Tinh_DC)) As DiaChi, BHXH, CMND, Email, DienThoai, NgayTuVan FROM dbo.TblNldTuVan, dbo.TblNguoiLaoDong WHERE dbo.TblNldTuVan.IdNguoiLaoDong = dbo.TblNguoiLaoDong.IdNguoiLaoDong " + sqlQuery + sqlQueryHoVaTen + " ORDER BY NgayTuVan DESC";
            Cmd.Parameters.Add("HoVaTen",SqlDbType.NVarChar).Value = HoVaTen;
            Cmd.Parameters.Add("SearchKey", SqlDbType.NVarChar).Value = SearchKey;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlCon.Close();
            sqlCon.Dispose();
            objTable = ds.Tables[0];
        }
        catch
        {

        }
        return objTable;
    }
    #endregion

    #region method getDataTblNldTuVan
    public DataTable getDataTblNldTuVan(int IDNguoiLaoDong)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.Parameters.Add("IDNguoiLaoDong", SqlDbType.Int).Value = IDNguoiLaoDong;
            Cmd.CommandText = "SELECT 0 AS TT, *, (SELECT NameTuVan FROM TblTuVan WHERE IDTuVan = TblNldTuVan.IDTuVan) AS NameTuVan FROM TblNldTuVan WHERE IDNguoiLaoDong = @IDNguoiLaoDong";
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ds.Tables[0].Rows[i]["TT"] = (i + 1);
            }
            sqlCon.Close();
            sqlCon.Dispose();
            objTable = ds.Tables[0];
        }
        catch
        {

        }
        return objTable;
    }
    #endregion

    #region method getDataTblNldTuVanById
    public DataTable getDataTblNldTuVanById(int IDNldTuVan)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT *, (SELECT HoVaTen FROM TblNguoiLaoDong WHERE IDNguoiLaoDong = TblNldTuVan.IDNguoiLaoDong) AS HoVaTen FROM TblNldTuVan WHERE IDNldTuVan = @IDNldTuVan";
            Cmd.Parameters.Add("IDNldTuVan", SqlDbType.Int).Value = IDNldTuVan;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlCon.Close();
            sqlCon.Dispose();
            objTable = ds.Tables[0];
        }
        catch
        {

        }
        return objTable;
    }
    #endregion

    #region method delDataNldTuVan
    public void delDataNldTuVan(int IDNldTuVan)
    {
        try
        {
            string sqlQuery = "";
            sqlQuery = "DELETE TblNldTuVan WHERE IDNldTuVan = @IDNldTuVan ";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("IDNldTuVan", SqlDbType.Int).Value = IDNldTuVan;
            Cmd.ExecuteNonQuery();

            sqlQuery = "DELETE TblNldDangKy WHERE IDNldTuVan = @IDNldTuVan";
            Cmd.CommandText = sqlQuery;
            Cmd.ExecuteNonQuery();

            sqlQuery = "DELETE TblNldDaoTao WHERE IDNldTuVan = @IDNldTuVan";
            Cmd.CommandText = sqlQuery;
            Cmd.ExecuteNonQuery();

            sqlQuery = "DELETE TblNldXuatKhau WHERE IDNldTuVan = @IDNldTuVan";
            Cmd.CommandText = sqlQuery;
            Cmd.ExecuteNonQuery();

            sqlCon.Close();
            sqlCon.Dispose();
        }
        catch
        {

        }
    }
    #endregion

    #endregion

    #region Noi dung dang ky TblNldDangKy

    #region method setDataNldDangKy
    public int setDataNldDangKy(ref int IDNldDangKy, int IDNguoiLaoDong, int IDNldTuVan, string TenCongViec, DateTime NgayDangKy, string NguoiDangKy)
    {
        int tmpValue = 0;

        try
        {
            string sqlQuery = "";

            sqlQuery = "IF NOT EXISTS (SELECT * FROM TblNldDangKy WHERE IDNldDangKy = @IDNldDangKy) ";
            sqlQuery += "BEGIN INSERT INTO TblNldDangKy(IDNguoiLaoDong,IDNldTuVan,TenCongViec,NgayDangKy,NguoiDangKy) VALUES(@IDNguoiLaoDong,@IDNldTuVan,@TenCongViec,@NgayDangKy,@NguoiDangKy) END ";
            sqlQuery += "ELSE BEGIN UPDATE TblNldDangKy SET IDNguoiLaoDong = @IDNguoiLaoDong,IDNldTuVan = @IDNldTuVan,TenCongViec = @TenCongViec,NgayDangKy = @NgayDangKy,NguoiDangKy = @NguoiDangKy WHERE IDNldDangKy = @IDNldDangKy END ";

            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();

            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;

            Cmd.Parameters.Add("IDNldDangKy", SqlDbType.Int).Value = IDNldDangKy;
            Cmd.Parameters.Add("IDNguoiLaoDong", SqlDbType.Int).Value = IDNguoiLaoDong;
            Cmd.Parameters.Add("IDNldTuVan", SqlDbType.Int).Value = IDNldTuVan;
            Cmd.Parameters.Add("TenCongViec", SqlDbType.NVarChar).Value = TenCongViec;
            Cmd.Parameters.Add("NgayDangKy", SqlDbType.DateTime).Value = NgayDangKy;
            Cmd.Parameters.Add("NguoiDangKy", SqlDbType.NVarChar).Value = NguoiDangKy;

            Cmd.ExecuteNonQuery();

            if (IDNldDangKy == 0)
            {
                sqlQuery = "SELECT TOP 1 IDNldDangKy FROM TblNldDangKy ORDER BY IDNldDangKy DESC";
                Cmd.CommandText = sqlQuery;
                SqlDataReader Rd = Cmd.ExecuteReader();
                while (Rd.Read())
                {
                    IDNldDangKy = int.Parse(Rd["IDNldDangKy"].ToString());
                }
                Rd.Close();
            }

            sqlCon.Close();
            sqlCon.Dispose();
            tmpValue = 1;
        }
        catch
        {
            tmpValue = 0;
        }
        return tmpValue;
    }
    #endregion

    #region method setDataNldDangKy
    public int setDataNldDangKy(ref int IDNldDangKy, int IDNguoiLaoDong, string TenCongViec, int IDChucVu, int IDHuyen, int IDTinh, int IDMucLuong, bool NuocNgoai, DateTime NgayDangKy, string NoiDungKhac, string NguoiDangKy, int State)
    {
        int tmpValue = 0;

        try
        {
            string sqlQuery = "";

            sqlQuery = "IF NOT EXISTS (SELECT * FROM TblNldDangKy WHERE IDNldDangKy = @IDNldDangKy AND IDNguoiLaoDong = @IDNguoiLaoDong) ";
            sqlQuery += "BEGIN INSERT INTO TblNldDangKy(IDNguoiLaoDong,TenCongViec,IDChucVu,IDHuyen,IDTinh,IDMucLuong,NuocNgoai,NgayDangKy,NoiDungKhac,NguoiDangKy,State) VALUES(@IDNguoiLaoDong,@TenCongViec,@IDChucVu,@IDHuyen,@IDTinh,@IDMucLuong,@NuocNgoai,@NgayDangKy,@NoiDungKhac,@NguoiDangKy,@State) END ";
            sqlQuery += "ELSE BEGIN UPDATE TblNldDangKy SET IDNguoiLaoDong = @IDNguoiLaoDong, TenCongViec = @TenCongViec, IDChucVu = @IDChucVu, IDHuyen = @IDHuyen,IDTinh = @IDTinh,IDMucLuong = @IDMucLuong,NuocNgoai = @NuocNgoai,NgayDangKy = @NgayDangKy,NoiDungKhac = @NoiDungKhac,NguoiDangKy = @NguoiDangKy, State = @State WHERE IDNldDangKy = @IDNldDangKy AND IDNguoiLaoDong = @IDNguoiLaoDong END ";

            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();

            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;

            Cmd.Parameters.Add("IDNldDangKy", SqlDbType.Int).Value = IDNldDangKy;
            Cmd.Parameters.Add("IDNguoiLaoDong", SqlDbType.Int).Value = IDNguoiLaoDong;
            Cmd.Parameters.Add("TenCongViec", SqlDbType.NVarChar).Value = TenCongViec;
            Cmd.Parameters.Add("IDChucVu", SqlDbType.Int).Value = IDChucVu;
            Cmd.Parameters.Add("IDHuyen", SqlDbType.Int).Value = IDHuyen;
            Cmd.Parameters.Add("IDTinh", SqlDbType.Int).Value = IDTinh;
            Cmd.Parameters.Add("IDMucLuong", SqlDbType.Int).Value = IDMucLuong;
            Cmd.Parameters.Add("NuocNgoai", SqlDbType.Bit).Value = NuocNgoai;
            Cmd.Parameters.Add("NgayDangKy", SqlDbType.DateTime).Value = NgayDangKy;
            Cmd.Parameters.Add("NoiDungKhac", SqlDbType.NVarChar).Value = NoiDungKhac;
            Cmd.Parameters.Add("NguoiDangKy", SqlDbType.NVarChar).Value = NguoiDangKy;
            Cmd.Parameters.Add("State", SqlDbType.Int).Value = State;

            Cmd.ExecuteNonQuery();

            if (IDNldDangKy == 0)
            {
                sqlQuery = "SELECT TOP 1 IDNldDangKy FROM TblNldDangKy ORDER BY IDNldDangKy DESC";
                Cmd.CommandText = sqlQuery;
                SqlDataReader Rd = Cmd.ExecuteReader();
                while (Rd.Read())
                {
                    IDNldDangKy = int.Parse(Rd["IDNldDangKy"].ToString());
                }
                Rd.Close();
            }

            sqlCon.Close();
            sqlCon.Dispose();
            tmpValue = 1;
        }
        catch
        {
            tmpValue = 0;
        }
        return tmpValue;
    }
    #endregion

    #region method getDataNldDangKy
    public DataTable getDataNldDangKyByState(int State, string NgayBatDau, string NgayKetThuc)
    {
        string sqlQuery = "";
        if (State != 3)
        {
            sqlQuery = " AND ISNULL(TblNldDangKy.State,0) = " + State.ToString();
        }
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();

            Cmd.Parameters.Add("objDate1", SqlDbType.DateTime).Value = TVSSystem.CVDateTime1(NgayBatDau);
            Cmd.Parameters.Add("objDate2", SqlDbType.DateTime).Value = TVSSystem.CVDateTime2(NgayKetThuc);

            //Cmd.CommandText = "SELECT 0 AS TT, *, (SELECT NameMucluong FROM TblMucLuong WHERE IDMucluong = TblNldDangKy.IDMucluong) AS NameMucluong, (SELECT NameChucVu FROM TblChucVu WHERE IDChucVu = TblNldDangKy.IDChucVu) AS NameChucVu, REPLACE(REPLACE(REPLACE(CAST(ISNULL(TblNldDangKy.State,0) AS nvarchar),'0',N'Chưa xử lý'),'1',N'Đang xử lý'),'2',N'Đã xử lý') AS NameState FROM TblNldDangKy, TblNguoiLaoDong WHERE TblNldDangKy.IDNguoiLaoDong = TblNguoiLaoDong.IdNguoiLaoDong " + sqlQuery + " AND NgayDangKy BETWEEN @objDate1 AND @objDate2 ORDER BY TblNldDangKy.NgayDangKy DESC";

            Cmd.CommandText = "SELECT 0 AS TT, *, (SELECT NameMucluong FROM TblMucLuong WHERE IDMucluong = TblNldDangKy.IDMucluong) AS NameMucluong, (SELECT NameChucVu FROM TblChucVu WHERE IDChucVu = TblNldDangKy.IDChucVu) AS NameChucVu, REPLACE(REPLACE(REPLACE(CAST(ISNULL(TblNldDangKy.State,0) AS nvarchar),'0',N'Chưa xử lý'),'1',N'Đang xử lý'),'2',N'Đã xử lý') AS NameState FROM TblNldDangKy INNER JOIN TblNguoiLaoDong ON TblNldDangKy.IDNguoiLaoDong = TblNguoiLaoDong.IdNguoiLaoDong LEFT JOIN TblNldTuVan ON TblNldTuVan.IDNldTuVan = TblNldDangKy.IDNldTuVan WHERE 1 = 1 " + sqlQuery + " AND NgayDangKy BETWEEN @objDate1 AND @objDate2 ORDER BY TblNldDangKy.NgayDangKy DESC";

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ds.Tables[0].Rows[i]["TT"] = (i + 1);
            }
            sqlCon.Close();
            sqlCon.Dispose();
            objTable = ds.Tables[0];
        }
        catch
        {

        }
        return objTable;
    }
    #endregion

    #region method getDataNldDangKy
    public DataTable getDataNldDangKy(int IDNguoiLaoDong)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.Parameters.Add("IDNguoiLaoDong", SqlDbType.Int).Value = IDNguoiLaoDong;
            Cmd.CommandText = "SELECT 0 AS TT, * FROM TblNldDangKy WHERE IDNguoiLaoDong = @IDNguoiLaoDong";
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ds.Tables[0].Rows[i]["TT"] = (i + 1);
            }
            sqlCon.Close();
            sqlCon.Dispose();
            objTable = ds.Tables[0];
        }
        catch
        {

        }
        return objTable;
    }
    #endregion

    #region method getDataNldDangKyById
    public DataTable getDataNldDangKyById(int IDNldDangKy)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT *, (SELECT HoVaTen FROM TblNguoiLaoDong WHERE IDNguoiLaoDong = TblNldDangKy.IDNguoiLaoDong) AS HoVaTen FROM TblNldDangKy LEFT JOIN TblNldTuVan ON TblNldTuVan.IDNldTuVan = TblNldDangKy.IDNldTuVan WHERE IDNldDangKy = @IDNldDangKy";
            Cmd.Parameters.Add("IDNldDangKy", SqlDbType.Int).Value = IDNldDangKy;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlCon.Close();
            sqlCon.Dispose();
            objTable = ds.Tables[0];
        }
        catch
        {

        }
        return objTable;
    }
    #endregion

    #region method getDataNldDangKyByIDNldTuVan
    public int getDataNldDangKyByIDNldTuVan(int IDNldTuVan)
    {
        int IDNldDangKy = 0;
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT IDNldDangKy FROM TblNldDangKy WHERE IDNldTuVan = @IDNldTuVan";
            Cmd.Parameters.Add("IDNldTuVan", SqlDbType.Int).Value = IDNldTuVan;
            SqlDataReader Rd = Cmd.ExecuteReader();
            while(Rd.Read())
            {
                IDNldDangKy = int.Parse(Rd["IDNldDangKy"].ToString());
            }
            Rd.Close();
            sqlCon.Close();
            sqlCon.Dispose();
        }
        catch
        {

        }
        return IDNldDangKy;
    }
    #endregion

    #region method delDataNldDangKy
    public void delDataNldDangKy(int IDNldDangKy)
    {
        try
        {
            string sqlQuery = "";
            sqlQuery = "DELETE TblNldDangKy WHERE IDNldDangKy = @IDNldDangKy ";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("IDNldDangKy", SqlDbType.Int).Value = IDNldDangKy;
            Cmd.ExecuteNonQuery();
            sqlCon.Close();
            sqlCon.Dispose();
        }
        catch
        {

        }
    }
    #endregion

    #endregion

    #region Gioi thieu viec lam TblNldGioiThieu

    #region method setDataNldGioiThieu
    public int setDataNldGioiThieu(ref int IDNldGioiThieu, int IDNldDangKy, int IDNguoiLaoDong, int IDDonVi, int IDChucVu, DateTime NgayGioiThieu, string NguoiGioiThieu)
    {
        int tmpValue = 0;

        try
        {
            string sqlQuery = "";

            sqlQuery = "IF NOT EXISTS (SELECT * FROM TblNldGioiThieu WHERE IDNldGioiThieu = @IDNldGioiThieu) ";
            sqlQuery += "BEGIN INSERT INTO TblNldGioiThieu(IDNldDangKy,IDNguoiLaoDong,IDDonVi,IDChucVu,NgayGioiThieu,NguoiGioiThieu) VALUES(@IDNldDangKy,@IDNguoiLaoDong,@IDDonVi,@IDChucVu,@NgayGioiThieu,@NguoiGioiThieu) END ";
            sqlQuery += "ELSE BEGIN UPDATE TblNldGioiThieu SET IDNldDangKy = @IDNldDangKy, IDDonVi = @IDDonVi, IDChucVu = @IDChucVu WHERE IDNldGioiThieu = @IDNldGioiThieu END ";

            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();

            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;

            Cmd.Parameters.Add("IDNldGioiThieu", SqlDbType.Int).Value = IDNldGioiThieu;
            Cmd.Parameters.Add("IDNldDangKy", SqlDbType.Int).Value = IDNldDangKy;
            Cmd.Parameters.Add("IDNguoiLaoDong", SqlDbType.Int).Value = IDNguoiLaoDong;
            Cmd.Parameters.Add("IDDonVi", SqlDbType.Int).Value = IDDonVi;
            Cmd.Parameters.Add("IDChucVu", SqlDbType.Int).Value = IDChucVu;
            Cmd.Parameters.Add("NgayGioiThieu", SqlDbType.DateTime).Value = NgayGioiThieu;
            Cmd.Parameters.Add("NguoiGioiThieu", SqlDbType.NVarChar).Value = NguoiGioiThieu;

            Cmd.ExecuteNonQuery();

            if (IDNldGioiThieu == 0)
            {
                sqlQuery = "SELECT TOP 1 IDNldGioiThieu FROM TblNldGioiThieu ORDER BY IDNldGioiThieu DESC";
                Cmd.CommandText = sqlQuery;
                SqlDataReader Rd = Cmd.ExecuteReader();
                while (Rd.Read())
                {
                    IDNldGioiThieu = int.Parse(Rd["IDNldGioiThieu"].ToString());
                }
                Rd.Close();
            }

            sqlCon.Close();
            sqlCon.Dispose();
            tmpValue = 1;
        }
        catch
        {
            tmpValue = 0;
        }
        return tmpValue;
    }
    #endregion

    #region method setDataNldGioiThieu
    public int setDataNldGioiThieu(int IDTuyenDung, int IDNldDangKy, int IDNguoiLaoDong, int IDDonVi, int IDChucVu, DateTime NgayGioiThieu, string NguoiGioiThieu, DateTime NgayHetHieuLuc)
    {
        int tmpValue = 0;

        try
        {
            string sqlQuery = "";

            sqlQuery = "IF NOT EXISTS (SELECT * FROM TblNldGioiThieu WHERE IDNldDangKy = @IDNldDangKy AND IDNguoiLaoDong = @IDNguoiLaoDong) ";
            sqlQuery += "BEGIN INSERT INTO TblNldGioiThieu(IDTuyenDung,IDNldDangKy,IDNguoiLaoDong,IDDonVi,IDChucVu,NgayGioiThieu,NguoiGioiThieu,NgayHetHieuLuc) VALUES(@IDTuyenDung,@IDNldDangKy,@IDNguoiLaoDong,@IDDonVi,@IDChucVu,@NgayGioiThieu,@NguoiGioiThieu,@NgayHetHieuLuc) END ";
            sqlQuery += "ELSE BEGIN UPDATE TblNldGioiThieu SET IDTuyenDung = @IDTuyenDung, IDNldDangKy = @IDNldDangKy, IDDonVi = @IDDonVi, IDChucVu = @IDChucVu , NgayHetHieuLuc=@NgayHetHieuLuc WHERE  IDNldDangKy = @IDNldDangKy AND IDNguoiLaoDong = @IDNguoiLaoDong  END ";

            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();

            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;

            Cmd.Parameters.Add("IDTuyenDung", SqlDbType.Int).Value = IDTuyenDung;
            Cmd.Parameters.Add("IDNldDangKy", SqlDbType.Int).Value = IDNldDangKy;
            Cmd.Parameters.Add("IDNguoiLaoDong", SqlDbType.Int).Value = IDNguoiLaoDong;
            Cmd.Parameters.Add("IDDonVi", SqlDbType.Int).Value = IDDonVi;
            Cmd.Parameters.Add("IDChucVu", SqlDbType.Int).Value = IDChucVu;
            Cmd.Parameters.Add("NgayGioiThieu", SqlDbType.DateTime).Value = NgayGioiThieu;
            Cmd.Parameters.Add("NguoiGioiThieu", SqlDbType.NVarChar).Value = NguoiGioiThieu;
            Cmd.Parameters.Add("NgayHetHieuLuc", SqlDbType.DateTime).Value = NgayHetHieuLuc;
            Cmd.ExecuteNonQuery();

            sqlCon.Close();
            sqlCon.Dispose();
            tmpValue = 1;
        }
        catch
        {
            tmpValue = 0;
        }
        return tmpValue;
    }
    #endregion

    #region method getDataNldGioiThieu
    public DataTable getDataNldGioiThieu()
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT 0 AS TT, *, (SELECT TOP 1 HoVaTen FROM TblNguoiLaoDong WHERE IDNguoiLaoDong = TblNldGioiThieu.IDNguoiLaoDong) AS HoVaTen, (SELECT TOP 1 NameChucVu FROM TblChucVu WHERE IDChucVu = TblNldGioiThieu.IDChucVu) AS NameChucVu, (SELECT TOP 1 NgayNhanViec FROM TblNldKetQua WHERE IDNldGioiThieu = TblNldGioiThieu.IDNldGioiThieu) AS NgayNhanViec FROM TblNldGioiThieu, TblDoanhNghiep WHERE TblNldGioiThieu.IDDonVi = TblDoanhNghiep.IDDonVi ORDER BY NgayGioiThieu DESC";
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ds.Tables[0].Rows[i]["TT"] = (i + 1);
            }
            sqlCon.Close();
            sqlCon.Dispose();
            objTable = ds.Tables[0];
        }
        catch
        {

        }
        return objTable;
    }
    #endregion

    #region method getDataNldGioiThieuByIDTuyenDung
    public DataTable getDataNldGioiThieuByIDTuyenDung(int IDTuyenDung)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT 0 AS TT, *, (SELECT TOP 1 HoVaTen FROM TblNguoiLaoDong WHERE IDNguoiLaoDong = TblNldGioiThieu.IDNguoiLaoDong) AS HoVaTen, (SELECT TOP 1 NameChucVu FROM TblChucVu WHERE IDChucVu = TblNldGioiThieu.IDChucVu) AS NameChucVu, (SELECT TOP 1 NgayNhanViec FROM TblNldKetQua WHERE IDNldGioiThieu = TblNldGioiThieu.IDNldGioiThieu) AS NgayNhanViec FROM TblNldGioiThieu, TblDoanhNghiep WHERE TblNldGioiThieu.IDDonVi = TblDoanhNghiep.IDDonVi AND TblNldGioiThieu.IDTuyenDung = @IDTuyenDung ORDER BY NgayGioiThieu DESC";
            Cmd.Parameters.Add("IDTuyenDung", SqlDbType.Int).Value = IDTuyenDung;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ds.Tables[0].Rows[i]["TT"] = (i + 1);
            }
            sqlCon.Close();
            sqlCon.Dispose();
            objTable = ds.Tables[0];
        }
        catch
        {

        }
        return objTable;
    }
    #endregion

    #region method getDataNldGioiThieuById
    public DataTable getDataNldGioiThieuById(int IDNldGioiThieu)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT TOP 1 *, (SELECT NameChucVu FROM TblChucVu WHERE IdChucVu = TblNldGioiThieu.IdChucVu) AS NameChucVu, (SELECT HoVaTen FROM TblNguoiLaoDong WHERE IDNguoiLaoDong = TblNldGioiThieu.IDNguoiLaoDong) AS HoVaTen FROM TblNldGioiThieu,TblDoanhNghiep WHERE TblNldGioiThieu.IDDonVi = TblDoanhNghiep.IDDonVi AND IDNldGioiThieu = @IDNldGioiThieu";
            Cmd.Parameters.Add("IDNldGioiThieu", SqlDbType.Int).Value = IDNldGioiThieu;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlCon.Close();
            sqlCon.Dispose();
            objTable = ds.Tables[0];
        }
        catch
        {

        }
        return objTable;
    }
    #endregion

    #region method getDataNldGioiThieuByNldDangKyId
    public DataTable getDataNldGioiThieuByNldDangKyId(int IDNldDangKy)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT TOP 1 *, (SELECT NameChucVu FROM TblChucVu WHERE IdChucVu = TblNldGioiThieu.IdChucVu) AS NameChucVu FROM TblNldGioiThieu INNER JOIN TblDoanhNghiep ON TblNldGioiThieu.IDDonVi = TblDoanhNghiep.IDDonVi LEFT JOIN TblViTri ON TblNldGioiThieu.IDChucVu = TblViTri.Id WHERE IDNldDangKy = @IDNldDangKy";
            Cmd.Parameters.Add("IDNldDangKy", SqlDbType.Int).Value = IDNldDangKy;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlCon.Close();
            sqlCon.Dispose();
            objTable = ds.Tables[0];
        }
        catch
        {

        }
        return objTable;
    }
    #endregion

    #region method delDataNldGioiThieu
    public void delDataNldGioiThieu(int IDNldGioiThieu)
    {
        try
        {
            string sqlQuery = "";
            sqlQuery = "DELETE TblNldGioiThieu WHERE IDNldGioiThieu = @IDNldGioiThieu ";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("IDNldGioiThieu", SqlDbType.Int).Value = IDNldGioiThieu;
            Cmd.ExecuteNonQuery();
            sqlCon.Close();
            sqlCon.Dispose();
        }
        catch
        {

        }
    }
    #endregion

    #endregion

    #region Ket qua gioi thieu viec lam TblNldKetQua

    #region method setDataNldKetQua
    public int setDataNldKetQua(ref int IDNldKetQua, int IDNldGioiThieu, int IDNguoiLaoDong, int IDDonVi, int IDChucVu, int IDLoaiHopDong, DateTime? NgayNhanViec, string ThoiGianThuViec, bool TrungTuyen, string LyDoKhongTrungTuyen)
    {
        int tmpValue = 0;

        try
        {
            string sqlQuery = "";

            sqlQuery = "IF NOT EXISTS (SELECT * FROM TblNldKetQua WHERE IDNldGioiThieu = @IDNldGioiThieu) ";
            sqlQuery += "BEGIN INSERT INTO TblNldKetQua(IDNldGioiThieu,IDNguoiLaoDong,IDDonVi,IDChucVu,IDLoaiHopDong,NgayNhanViec,ThoiGianThuViec,TrungTuyen,LyDoKhongTrungTuyen) VALUES(@IDNldGioiThieu,@IDNguoiLaoDong,@IDDonVi,@IDChucVu,@IDLoaiHopDong,@NgayNhanViec,@ThoiGianThuViec,@TrungTuyen,@LyDoKhongTrungTuyen) END ";
            sqlQuery += "ELSE BEGIN UPDATE TblNldKetQua SET IDNldGioiThieu = @IDNldGioiThieu, IDDonVi = @IDDonVi, IDChucVu = @IDChucVu, IDLoaiHopDong = @IDLoaiHopDong, NgayNhanViec = @NgayNhanViec, ThoiGianThuViec = @ThoiGianThuViec, TrungTuyen = @TrungTuyen, LyDoKhongTrungTuyen = @LyDoKhongTrungTuyen WHERE IDNldGioiThieu = @IDNldGioiThieu END ";

            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();

            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;

            Cmd.Parameters.Add("IDNldKetQua", SqlDbType.Int).Value = IDNldKetQua;
            Cmd.Parameters.Add("IDNguoiLaoDong", SqlDbType.Int).Value = IDNguoiLaoDong;
            Cmd.Parameters.Add("IDNldGioiThieu", SqlDbType.Int).Value = IDNldGioiThieu;
            Cmd.Parameters.Add("IDDonVi", SqlDbType.Int).Value = IDDonVi;
            Cmd.Parameters.Add("IDChucVu", SqlDbType.Int).Value = IDChucVu;
            Cmd.Parameters.Add("IDLoaiHopDong", SqlDbType.Int).Value = IDLoaiHopDong;

            if (NgayNhanViec != null)
            {
                Cmd.Parameters.Add("NgayNhanViec", SqlDbType.DateTime).Value = NgayNhanViec;
            }
            else
            {
                Cmd.Parameters.Add("NgayNhanViec", SqlDbType.DateTime).Value = DBNull.Value;
            }
            Cmd.Parameters.Add("ThoiGianThuViec", SqlDbType.NVarChar).Value = ThoiGianThuViec;
            Cmd.Parameters.Add("TrungTuyen", SqlDbType.Bit).Value = TrungTuyen;
            Cmd.Parameters.Add("LyDoKhongTrungTuyen", SqlDbType.NVarChar).Value = LyDoKhongTrungTuyen;

            Cmd.ExecuteNonQuery();

            if (IDNldKetQua == 0)
            {
                sqlQuery = "SELECT TOP 1 IDNldKetQua FROM TblNldKetQua ORDER BY IDNldKetQua DESC";
                Cmd.CommandText = sqlQuery;
                SqlDataReader Rd = Cmd.ExecuteReader();
                while (Rd.Read())
                {
                    IDNldKetQua = int.Parse(Rd["IDNldKetQua"].ToString());
                }
                Rd.Close();
            }

            sqlCon.Close();
            sqlCon.Dispose();
            tmpValue = 1;
        }
        catch
        {
            tmpValue = 0;
        }
        return tmpValue;
    }
    #endregion

    #region method getDataNldKetQuaByIDNldGioiThieuId
    public DataTable getDataNldKetQuaByIDNldGioiThieuId(int IDNldGioiThieu)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT TOP 1 * FROM TblNldKetQua,TblDoanhNghiep WHERE TblNldKetQua.IDDonVi = TblDoanhNghiep.IDDonVi AND IDNldGioiThieu = @IDNldGioiThieu";
            Cmd.Parameters.Add("IDNldGioiThieu", SqlDbType.Int).Value = IDNldGioiThieu;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlCon.Close();
            sqlCon.Dispose();
            objTable = ds.Tables[0];
        }
        catch
        {

        }
        return objTable;
    }
    #endregion

    #endregion

    #region Thong tin phu huynh

    #region method setDataNldPhuHuynh
    public int setDataNldPhuHuynh(ref int IDNldPhuHuynh, int IDNldXuatKhau, int IDNldDangKy, string HoTenBo, DateTime? NgaySinhBo, string DiaChiBo, string DienThoaiBo, string DonViBo, string ChucVuBo, string DiaChiDonViBo, float ThuNhapThangBo, string SoTietKiemBo, string HoTenMe, DateTime? NgaySinhMe, string DiaChiMe, string DienThoaiMe, string DonViMe, string ChucVuMe, string DiaChiDonViMe, float ThuNhapThangMe, string SoTietKiemMe)
    {
        int tmpValue = 0;

        try
        {
            string sqlQuery = "";

            sqlQuery = "IF NOT EXISTS (SELECT * FROM TblNldPhuHuynh WHERE IDNldPhuHuynh = @IDNldPhuHuynh) ";
            sqlQuery += "BEGIN INSERT INTO TblNldPhuHuynh(IDNldXuatKhau,IDNldDangKy,HoTenBo,NgaySinhBo,DiaChiBo,DienThoaiBo,DonViBo,ChucVuBo,DiaChiDonViBo,ThuNhapThangBo,SoTietKiemBo,HoTenMe,NgaySinhMe,DiaChiMe,DienThoaiMe,DonViMe,ChucVuMe,DiaChiDonViMe,ThuNhapThangMe,SoTietKiemMe) VALUES(@IDNldXuatKhau,@IDNldDangKy,@HoTenBo,@NgaySinhBo,@DiaChiBo,@DienThoaiBo,@DonViBo,@ChucVuBo,@DiaChiDonViBo,@ThuNhapThangBo,@SoTietKiemBo,@HoTenMe,@NgaySinhMe,@DiaChiMe,@DienThoaiMe,@DonViMe,@ChucVuMe,@DiaChiDonViMe,@ThuNhapThangMe,@SoTietKiemMe) END ";
            sqlQuery += "ELSE BEGIN UPDATE TblNldPhuHuynh SET IDNldXuatKhau = @IDNldXuatKhau, IDNldDangKy = @IDNldDangKy,HoTenBo = @HoTenBo,NgaySinhBo = @NgaySinhBo,DiaChiBo = @DiaChiBo,DienThoaiBo = @DienThoaiBo,DonViBo = @DonViBo,ChucVuBo = @ChucVuBo,DiaChiDonViBo = @DiaChiDonViBo,ThuNhapThangBo = @ThuNhapThangBo,SoTietKiemBo = @SoTietKiemBo,HoTenMe = @HoTenMe,NgaySinhMe = @NgaySinhMe,DiaChiMe = @DiaChiMe,DienThoaiMe = @DienThoaiMe,DonViMe = @DonViMe,ChucVuMe = @ChucVuMe,DiaChiDonViMe = @DiaChiDonViMe,ThuNhapThangMe = @ThuNhapThangMe,SoTietKiemMe = @SoTietKiemMe WHERE IDNldPhuHuynh = @IDNldPhuHuynh END ";

            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();

            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;

            Cmd.Parameters.Add("IDNldPhuHuynh", SqlDbType.Int).Value = IDNldPhuHuynh;
            Cmd.Parameters.Add("IDNldXuatKhau", SqlDbType.Int).Value = IDNldXuatKhau;
            Cmd.Parameters.Add("IDNldDangKy", SqlDbType.Int).Value = IDNldDangKy;
            Cmd.Parameters.Add("HoTenBo", SqlDbType.NVarChar).Value = HoTenBo;
            if (NgaySinhBo != null)
            {
                Cmd.Parameters.Add("NgaySinhBo", SqlDbType.DateTime).Value = NgaySinhBo;
            }
            else
            {
                Cmd.Parameters.Add("NgaySinhBo", SqlDbType.DateTime).Value = DBNull.Value;
            }

            Cmd.Parameters.Add("DiaChiBo", SqlDbType.NVarChar).Value = DiaChiBo;
            Cmd.Parameters.Add("DienThoaiBo", SqlDbType.NVarChar).Value = DienThoaiBo;
            Cmd.Parameters.Add("DonViBo", SqlDbType.NVarChar).Value = DonViBo;
            Cmd.Parameters.Add("ChucVuBo", SqlDbType.NVarChar).Value = ChucVuBo;
            Cmd.Parameters.Add("DiaChiDonViBo", SqlDbType.NVarChar).Value = DiaChiDonViBo;

            Cmd.Parameters.Add("ThuNhapThangBo", SqlDbType.Float).Value = ThuNhapThangBo;
            Cmd.Parameters.Add("SoTietKiemBo", SqlDbType.NVarChar).Value = SoTietKiemBo;
            Cmd.Parameters.Add("HoTenMe", SqlDbType.NVarChar).Value = HoTenMe;
            if (NgaySinhMe != null)
            {
                Cmd.Parameters.Add("NgaySinhMe", SqlDbType.DateTime).Value = NgaySinhMe;
            }
            else
            {
                Cmd.Parameters.Add("NgaySinhMe", SqlDbType.DateTime).Value = DBNull.Value;
            }
            Cmd.Parameters.Add("DiaChiMe", SqlDbType.NVarChar).Value = DiaChiMe;

            Cmd.Parameters.Add("DienThoaiMe", SqlDbType.NVarChar).Value = DienThoaiMe;
            Cmd.Parameters.Add("DonViMe", SqlDbType.NVarChar).Value = DonViMe;
            Cmd.Parameters.Add("ChucVuMe", SqlDbType.NVarChar).Value = ChucVuMe;
            Cmd.Parameters.Add("DiaChiDonViMe", SqlDbType.NVarChar).Value = DiaChiDonViMe;
            Cmd.Parameters.Add("ThuNhapThangMe", SqlDbType.Float).Value = ThuNhapThangMe;

            Cmd.Parameters.Add("SoTietKiemMe", SqlDbType.NVarChar).Value = SoTietKiemMe;

            Cmd.ExecuteNonQuery();

            if (IDNldPhuHuynh == 0)
            {
                sqlQuery = "SELECT TOP 1 IDNldPhuHuynh FROM TblNldPhuHuynh ORDER BY IDNldPhuHuynh DESC";
                Cmd.CommandText = sqlQuery;
                SqlDataReader Rd = Cmd.ExecuteReader();
                while (Rd.Read())
                {
                    IDNldPhuHuynh = int.Parse(Rd["IDNldPhuHuynh"].ToString());
                }
                Rd.Close();
            }

            sqlCon.Close();
            sqlCon.Dispose();
            tmpValue = 1;
        }
        catch
        {
            tmpValue = 0;
        }
        return tmpValue;
    }
    #endregion

    #region method getDataNldPhuHuynhById
    public DataTable getDataNldPhuHuynhById(int IDNldPhuHuynh)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT * FROM TblNldPhuHuynh WHERE IDNldPhuHuynh = @IDNldPhuHuynh";
            Cmd.Parameters.Add("IDNguoiLaoDong", SqlDbType.Int).Value = IDNldPhuHuynh;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlCon.Close();
            sqlCon.Dispose();
            objTable = ds.Tables[0];
        }
        catch
        {

        }
        return objTable;
    }
    #endregion

    #region method getDataNldPhuHuynhByIDNldXuatKhau
    public DataTable getDataNldPhuHuynhByIDNldXuatKhau(int IDNldXuatKhau)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT * FROM TblNldPhuHuynh WHERE IDNldXuatKhau = @IDNldXuatKhau";
            Cmd.Parameters.Add("IDNldXuatKhau", SqlDbType.Int).Value = IDNldXuatKhau;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlCon.Close();
            sqlCon.Dispose();
            objTable = ds.Tables[0];
        }
        catch
        {

        }
        return objTable;
    }
    #endregion

    #endregion

    #region Dao tao nghe
    
    #region method setNldDaoTaoData
    public int setNldDaoTaoData(int IDNldTuVan, int IDNldDangKy)
    {
        int tmpValue = 0;

        try
        {
            string sqlQuery = "";

            sqlQuery = "IF NOT EXISTS (SELECT * FROM TblNldDaoTao WHERE IDNldTuVan = @IDNldTuVan) ";
            sqlQuery += "BEGIN INSERT INTO TblNldDaoTao(IDNldTuVan,IDNguoiLaoDong) VALUES(@IDNldTuVan,@IDNguoiLaoDong) END ";

            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();

            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;

            Cmd.Parameters.Add("IDNldTuVan", SqlDbType.Int).Value = IDNldTuVan;
            Cmd.Parameters.Add("IDNguoiLaoDong", SqlDbType.Int).Value = IDNldDangKy;
            Cmd.ExecuteNonQuery();

            sqlCon.Close();
            sqlCon.Dispose();
            tmpValue = 1;
        }
        catch
        {
            tmpValue = 0;
        }
        return tmpValue;
    }
    #endregion

    #region method setNldDaoTaoData
    public int setNldDaoTaoData(int IDNldDaoTao, int IDNguoiLaoDong, int IdDtKhoaHoc, string TruongHoc, string DiaChiHoc, string KhoaHoc, string DTLienHe, DateTime NgayBatDau, DateTime NgayKetThuc, string SoQDHTN, string SoQDHN, int State)
    {
        int tmpValue = 0;

        try
        {
            string sqlQuery = "";

            sqlQuery = "IF NOT EXISTS (SELECT * FROM TblNldDaoTao WHERE IDNldDaoTao = @IDNldDaoTao)";
            sqlQuery += "BEGIN INSERT INTO TblNldDaoTao (IDNguoiLaoDong,IdDtKhoaHoc,TruongHoc,DiaChiHoc,DTLienHe,KhoaHoc,NgayBatDau,NgayKetThuc,SoQDHTN,SoQDHN,State) VALUES(@IDNguoiLaoDong,@IdDtKhoaHoc,@TruongHoc,@DiaChiHoc,@DTLienHe,@KhoaHoc,@NgayBatDau,@NgayKetThuc,@SoQDHTN,@SoQDHN,@State)  END ";
            sqlQuery += "ELSE BEGIN UPDATE TblNldDaoTao SET IDNguoiLaoDong = @IDNguoiLaoDong, IdDtKhoaHoc = @IdDtKhoaHoc, TruongHoc = @TruongHoc, DiaChiHoc = @DiaChiHoc, DTLienHe = @DTLienHe, KhoaHoc = @KhoaHoc, NgayBatDau = @NgayBatDau, NgayKetThuc = @NgayKetThuc, SoQDHTN = @SoQDHTN, SoQDHN = @SoQDHN, State = @State WHERE IDNldDaoTao = @IDNldDaoTao END";

            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();

            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;

            Cmd.Parameters.Add("IDNldDaoTao", SqlDbType.Int).Value = IDNldDaoTao;
            Cmd.Parameters.Add("IDNguoiLaoDong", SqlDbType.Int).Value = IDNguoiLaoDong;
            Cmd.Parameters.Add("IdDtKhoaHoc", SqlDbType.Int).Value = IdDtKhoaHoc;
            Cmd.Parameters.Add("TruongHoc", SqlDbType.NVarChar).Value = TruongHoc;
            Cmd.Parameters.Add("DiaChiHoc", SqlDbType.NVarChar).Value = DiaChiHoc;
            Cmd.Parameters.Add("DTLienHe", SqlDbType.NVarChar).Value = DTLienHe;
            Cmd.Parameters.Add("KhoaHoc", SqlDbType.NVarChar).Value = KhoaHoc;
            Cmd.Parameters.Add("NgayBatDau", SqlDbType.DateTime).Value = NgayBatDau;
            Cmd.Parameters.Add("NgayKetThuc", SqlDbType.DateTime).Value = NgayKetThuc;
            Cmd.Parameters.Add("SoQDHTN", SqlDbType.NVarChar).Value = SoQDHTN;
            Cmd.Parameters.Add("SoQDHN", SqlDbType.NVarChar).Value = SoQDHN;
            Cmd.Parameters.Add("State", SqlDbType.Int).Value = State;
            Cmd.ExecuteNonQuery();

            sqlCon.Close();
            sqlCon.Dispose();
            tmpValue = 1;
        }
        catch
        {
            tmpValue = 0;
        }
        return tmpValue;
    }
    #endregion

    #region method setNldDaoTaoData
    public int setNldDaoTaoData(int IDNldDaoTao, int IDNguoiLaoDong, int IdDtKhoaHoc, string TruongHoc, string DiaChiHoc, string KhoaHoc, string DTLienHe, int State)
    {
        int tmpValue = 0;

        try
        {
            string sqlQuery = "";

            sqlQuery = "IF NOT EXISTS (SELECT * FROM TblNldDaoTao WHERE IDNldDaoTao = @IDNldDaoTao)";
            sqlQuery += "BEGIN INSERT INTO TblNldDaoTao (IDNguoiLaoDong,IdDtKhoaHoc,TruongHoc,DiaChiHoc,DTLienHe,KhoaHoc,State) VALUES(@IDNguoiLaoDong,@IdDtKhoaHoc,@TruongHoc,@DiaChiHoc,@DTLienHe,@KhoaHoc,@State)  END ";
            sqlQuery += "ELSE BEGIN UPDATE TblNldDaoTao SET IDNguoiLaoDong = @IDNguoiLaoDong, IdDtKhoaHoc = @IdDtKhoaHoc, TruongHoc = @TruongHoc, DiaChiHoc = @DiaChiHoc, DTLienHe = @DTLienHe, KhoaHoc = @KhoaHoc, State = @State END";

            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();

            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;

            Cmd.Parameters.Add("IDNldDaoTao", SqlDbType.Int).Value = IDNldDaoTao;
            Cmd.Parameters.Add("IDNguoiLaoDong", SqlDbType.Int).Value = IDNguoiLaoDong;
            Cmd.Parameters.Add("IdDtKhoaHoc", SqlDbType.Int).Value = IdDtKhoaHoc;
            Cmd.Parameters.Add("TruongHoc", SqlDbType.NVarChar).Value = TruongHoc;
            Cmd.Parameters.Add("DiaChiHoc", SqlDbType.NVarChar).Value = DiaChiHoc;
            Cmd.Parameters.Add("DTLienHe", SqlDbType.NVarChar).Value = DTLienHe;
            Cmd.Parameters.Add("KhoaHoc", SqlDbType.NVarChar).Value = KhoaHoc;
            Cmd.Parameters.Add("State", SqlDbType.Int).Value = State;
            Cmd.ExecuteNonQuery();

            sqlCon.Close();
            sqlCon.Dispose();
            tmpValue = 1;
        }
        catch
        {
            tmpValue = 0;
        }
        return tmpValue;
    }
    #endregion

    #region method setNldDaoTaoData
    public int setNldDaoTaoData(int IDNldDaoTao, int IDDTMonHoc, int IDDTNganhNghe, string ThoiGian, float MucHoTro, int IDDonVi, string KhoaHoc, string DiaChiHoc, string DTLienHe, DateTime NgayBatDau, DateTime NgayKetThuc, string SoQDHTN, string SoQDHN, int State)
    {
        int tmpValue = 0;

        try
        {
            string sqlQuery = "";

            sqlQuery += "UPDATE TblNldDaoTao SET IDDTMonHoc = @IDDTMonHoc, IDDTNganhNghe = @IDDTNganhNghe, ThoiGian = @ThoiGian, MucHoTro = @MucHoTro, IDDonVi = @IDDonVi, KhoaHoc = @KhoaHoc, DiaChiHoc = @DiaChiHoc, DTLienHe = @DTLienHe, NgayBatDau = @NgayBatDau, NgayKetThuc = @NgayKetThuc, SoQDHTN = @SoQDHTN, SoQDHN = @SoQDHN, State = @State WHERE IDNldDaoTao = @IDNldDaoTao";

            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();

            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;

            Cmd.Parameters.Add("IDNldDaoTao", SqlDbType.Int).Value = IDNldDaoTao;
            Cmd.Parameters.Add("IDDTMonHoc", SqlDbType.Int).Value = IDDTMonHoc;
            Cmd.Parameters.Add("IDDTNganhNghe", SqlDbType.Int).Value = IDDTNganhNghe;
            Cmd.Parameters.Add("ThoiGian", SqlDbType.NVarChar).Value = ThoiGian;
            Cmd.Parameters.Add("IDNguoiLaoDong", SqlDbType.Int).Value = ThoiGian;
            Cmd.Parameters.Add("IDDonVi", SqlDbType.Int).Value = IDDonVi;
            Cmd.Parameters.Add("KhoaHoc", SqlDbType.NVarChar).Value = KhoaHoc;
            Cmd.Parameters.Add("MucHoTro", SqlDbType.Float).Value = MucHoTro;
            Cmd.Parameters.Add("DiaChiHoc", SqlDbType.NVarChar).Value = DiaChiHoc;
            Cmd.Parameters.Add("DTLienHe", SqlDbType.NVarChar).Value = DTLienHe;
            Cmd.Parameters.Add("NgayBatDau", SqlDbType.DateTime).Value = NgayBatDau;
            Cmd.Parameters.Add("NgayKetThuc", SqlDbType.DateTime).Value = NgayKetThuc;
            Cmd.Parameters.Add("SoQDHTN", SqlDbType.NVarChar).Value = SoQDHTN;
            Cmd.Parameters.Add("SoQDHN", SqlDbType.NVarChar).Value = SoQDHN;
            Cmd.Parameters.Add("State", SqlDbType.Int).Value = State;
            Cmd.ExecuteNonQuery();

            sqlCon.Close();
            sqlCon.Dispose();
            tmpValue = 1;
        }
        catch
        {
            tmpValue = 0;
        }
        return tmpValue;
    }
    #endregion

    #region method getDataNldDaoTao
    public DataTable getDataNldDaoTao(string searchKey, int State)
    {
        string sqlQuery = "", sqlQueryState = "";
        if (searchKey.Trim() != "")
        {
            sqlQuery += " AND UPPER(RTRIM(LTRIM(HoVaTen))) LIKE N'%'+UPPER(RTRIM(LTRIM(@SearchKey)))+'%'";
        }
        if (State != 3)
        {
            sqlQueryState = " AND ISNULL(TblNldDaoTao.State,0) = " + State.ToString();
        }

        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.Parameters.Add("SearchKey", SqlDbType.NVarChar).Value = searchKey;

            string sqlQueryFull = "SELECT 0 AS TT, *, (SELECT TenDonVi FROM TblDoanhNghiep WHERE IDDonVi = TblNldDaoTao.IDDonVi) AS TenDonVi, REPLACE(REPLACE(REPLACE(CAST(ISNULL(TblNldDaoTao.State,0) AS nvarchar),'0',N'Chưa xử lý'),'1',N'Đang xử lý'),'2',N'Đã xử lý') AS NameState ";
            sqlQueryFull += ",TblDtKhoaHoc.MucHoTro AS MucHoTro1, TblDtKhoaHoc.ThoiGianHoc AS ThoiGianHoc1, TblDtKhoaHoc.NameKhoaHoc FROM TblNguoiLaoDong INNER JOIN TblNgoaiNgu ON TblNguoiLaoDong.IDNgoaiNgu = TblNgoaiNgu.IDNgoaiNgu , TblNldDaoTao LEFT JOIN TblDtKhoaHoc ON TblNldDaoTao.IdDtKhoaHoc = TblDtKhoaHoc.IdDtKhoaHoc ";
            sqlQueryFull += " WHERE TblNguoiLaoDong.IDNguoiLaoDong = TblNldDaoTao.IDNguoiLaoDong " + sqlQuery + sqlQueryState + " ORDER BY TblNldDaoTao.IDNldDaoTao DESC";

            Cmd.CommandText = sqlQueryFull;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ds.Tables[0].Rows[i]["TT"] = (i + 1);
            }
            sqlCon.Close();
            sqlCon.Dispose();
            objTable = ds.Tables[0];
        }
        catch(Exception e)
        {
            Debug.WriteLine("[!!!] - getDataNldDaoTao  :" + e.GetBaseException());
        }
        return objTable;
    }
    #endregion

    #region method getDataNldDaoTaoById
    public DataTable getDataNldDaoTaoById(string IDNldDaoTao)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT TblNldDaoTao.*, dbo.TblNguoiLaoDong.HoVaTen, dbo.TblNguoiLaoDong.NgaySinh, TblNguoiLaoDong.IDGioiTinh, ((TblNguoiLaoDong.Xom_DC)+', '+(TblNguoiLaoDong.Xa_DC)+', '+(TblNguoiLaoDong.Huyen_DC)+', '+(TblNguoiLaoDong.Tinh_DC)) As DiaChi, TblNguoiLaoDong.DienThoai, TblDtKhoaHoc.NameKhoaHoc,TblDtKhoaHoc.ThoiGianHoc,TblDtKhoaHoc.MucHoTro AS MucHoTro1,TblDtKhoaHoc.LoaiKhoaHoc FROM TblNldDaoTao LEFT JOIN TblNguoiLaoDong ON TblNldDaoTao.IDNguoiLaoDong = TblNguoiLaoDong.IDNguoiLaoDong LEFT JOIN TblDtKhoaHoc ON TblNldDaoTao.IdDtKhoaHoc = TblDtKhoaHoc.IdDtKhoaHoc WHERE TblNldDaoTao.IDNldDaoTao = @IDNldDaoTao";
            Cmd.Parameters.Add("IDNldDaoTao", SqlDbType.Int).Value = IDNldDaoTao;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlCon.Close();
            sqlCon.Dispose();
            objTable = ds.Tables[0];
        }
        catch
        {

        }
        return objTable;
    }
    #endregion

    #region method getDataDTNganhNgheToCombobox
    public DataTable getDataDTNganhNgheToCombobox()
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT IDDTNganhNghe, NameDTNganhNghe FROM TblDTNganhNghe WHERE ISNULL(State,0) = 1";
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlCon.Close();
            sqlCon.Dispose();
            objTable = ds.Tables[0];
            objTable.Rows.Add(0, "Không chọn");
        }
        catch
        {

        }
        return objTable;
    }
    #endregion

    #region method getDataDTMonHocToCombobox
    public DataTable getDataDTMonHocToCombobox()
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT IDDTMonHoc, NameDTMonHoc FROM TblDTMonHoc WHERE ISNULL(State,0) = 1";
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlCon.Close();
            sqlCon.Dispose();
            objTable = ds.Tables[0];
            objTable.Rows.Add(0, "Không chọn");
        }
        catch
        {

        }
        return objTable;
    }
    #endregion

    #region method delNldDaoTaoData
    public void delNldDaoTaoData(int IDNldDaoTao)
    {
        try
        {
            string sqlQuery = "";
            sqlQuery = "DELETE TblNldDaoTao WHERE IDNldDaoTao = @IDNldDaoTao ";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("IDNldDaoTao", SqlDbType.Int).Value = IDNldDaoTao;
            Cmd.ExecuteNonQuery();
            sqlCon.Close();
            sqlCon.Dispose();
        }
        catch
        {

        }
    }
    #endregion

    #endregion

    #region method getNextMaNLD
    public string getNextMaNLD()
    {
        string tmpMaNLD = "";
        try
        {
            int tmpCount = 0;
            string sqlQuery = "";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            sqlQuery = "SELECT ISNULL(COUNT(*),0) AS CountItem FROM TblNguoiLaoDong WHERE ISNULL(Ma,'') <> '' and LEN(Ma) >=9";
            Cmd.CommandText = sqlQuery;
            SqlDataReader Rd = Cmd.ExecuteReader();
            while (Rd.Read())
            {
                tmpCount = int.Parse(Rd["CountItem"].ToString());
            }
            Rd.Close();

            if (tmpCount == 0)
            {
                tmpCount = 1;
            }
            else
            {
                SqlCommand Cmd1 = sqlCon.CreateCommand();
                sqlQuery = "SELECT TOP 1 CAST(SUBSTRING(Ma,10,(LEN(Ma)-9)) AS Int) AS MaxItem FROM dbo.TblNguoiLaoDong WHERE ISNULL(Ma,'') <> '' and LEN(Ma) >=9 ORDER BY CAST(SUBSTRING(Ma,10,(LEN(Ma)-9)) AS Int) DESC";
                Cmd1.CommandText = sqlQuery;
                SqlDataReader Rd1 = Cmd1.ExecuteReader();
                while (Rd1.Read())
                {
                    tmpCount = int.Parse(Rd1["MaxItem"].ToString());
                }
                Rd1.Close();
                tmpCount = tmpCount + 1;
            }
            sqlCon.Close();
            sqlCon.Dispose();
            tmpMaNLD = DateTime.Now.ToString("yyyyMMdd") + "-" + tmpCount.ToString("000");
        }
        catch 
        {
            
        }
        return tmpMaNLD;
    }
    #endregion

    #region Method checkCMND()
    public int checkCMND(String cmnd)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "SELECT IDNguoiLaoDong FROM TblNguoiLaoDong WHERE CMND = @CMND";
            Cmd.Parameters.Add("CMND", SqlDbType.Int).Value = cmnd;

            int ret = (int)Cmd.ExecuteScalar();

            this.SQLClose();
            return ret;
        }
        catch (Exception ex)
        {
            this.Message = ex.Message;
           // this.ErrorCode = ex.HResult;
            return 0;
        }
    }
    #endregion

    #region Method checkBHXH()
    public int checkBHXH(String BHXH)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "SELECT IDNguoiLaoDong FROM TblNguoiLaoDong WHERE BHXH = @BHXH";
            Cmd.Parameters.Add("BHXH", SqlDbType.Int).Value = BHXH;

            int ret = (int)Cmd.ExecuteScalar();

            this.SQLClose();
            return ret;
        }
        catch (Exception ex)
        {
            this.Message = ex.Message;
            this.ErrorCode = ex.HResult;
            return 0;
        }
    }
    #endregion
}