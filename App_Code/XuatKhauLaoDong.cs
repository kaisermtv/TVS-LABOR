using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class XuatKhauLaoDong
{
    #region method XuatKhauLaoDong
    public XuatKhauLaoDong()
    {
    } 
    #endregion

    #region method setData
    public int setData(ref int IDNldXuatKhau, int IDNldDangKy, int IDDonViTuyenDung, string NguoiDaiDienTVS, DateTime? NgayDangKyTuVan, string DiaDiem, int IDCanBo, int IDKetQuaTuVan, DateTime? NgayCocTien, float TienCoc, int IDDonVi, string NguoiXuLy,
        int IDDaoTaoMonHoc, string NoiDaoTao, DateTime? NgayBatDau, DateTime? NgayKetThuc, string KhoaHoc, DateTime? NgayXuatCanhDuKien, DateTime? NgayViSa, DateTime? NgayXuatCanh, DateTime? NgayVe, string NguoiGioiThieu, int IDKetQuaHoSo, string NoiDungKhac, int State)
    {
        int tmpValue = 0;

        try
        {
            string sqlQuery = "";

            sqlQuery = "IF NOT EXISTS (SELECT * FROM TblNldXuatKhau WHERE IDNldXuatKhau = @IDNldXuatKhau) ";
            sqlQuery += "BEGIN INSERT INTO TblNldXuatKhau(IDNldDangKy,IDDonViTuyenDung,NguoiDaiDienTVS,NgayDangKyTuVan,DiaDiem,IDCanBo,IDKetQuaTuVan,NgayCocTien,TienCoc,IDDonVi,NguoiXuLy,IDDaoTaoMonHoc,NoiDaoTao,NgayBatDau,NgayKetThuc,KhoaHoc,NgayXuatCanhDuKien,NgayViSa,NgayXuatCanh,NgayVe,NguoiGioiThieu,IDKetQuaHoSo,NoiDungKhac,State) ";
            sqlQuery += " VALUES(@IDNldDangKy,@IDDonViTuyenDung,@NguoiDaiDienTVS,@NgayDangKyTuVan,@DiaDiem,@IDCanBo,@IDKetQuaTuVan,@NgayCocTien,@TienCoc,@IDDonVi,@NguoiXuLy,@IDDaoTaoMonHoc,@NoiDaoTao,@NgayBatDau,@NgayKetThuc,@KhoaHoc,@NgayXuatCanhDuKien,@NgayViSa,@NgayXuatCanh,@NgayVe,@NguoiGioiThieu,@IDKetQuaHoSo,@NoiDungKhac,@State) END ";
            sqlQuery += "ELSE BEGIN UPDATE TblNldXuatKhau SET IDNldDangKy = @IDNldDangKy, IDDonViTuyenDung = @IDDonViTuyenDung, NguoiDaiDienTVS = @NguoiDaiDienTVS, NgayDangKyTuVan = @NgayDangKyTuVan, DiaDiem = @DiaDiem,IDCanBo = @IDCanBo,IDKetQuaTuVan = @IDKetQuaTuVan,NgayCocTien = @NgayCocTien,TienCoc = @TienCoc,IDDonVi = @IDDonVi,NguoiXuLy = @NguoiXuLy,IDDaoTaoMonHoc = @IDDaoTaoMonHoc,NoiDaoTao = @NoiDaoTao,NgayBatDau = @NgayBatDau,NgayKetThuc = @NgayKetThuc,KhoaHoc = @KhoaHoc,NgayXuatCanhDuKien = @NgayXuatCanhDuKien,NgayViSa = @NgayViSa,NgayXuatCanh = @NgayXuatCanh,NgayVe = @NgayVe,NguoiGioiThieu = @NguoiGioiThieu,IDKetQuaHoSo = @IDKetQuaHoSo,NoiDungKhac = @NoiDungKhac, State = @State WHERE IDNldXuatKhau = @IDNldXuatKhau END ";

            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();

            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;

            Cmd.Parameters.Add("IDNldXuatKhau", SqlDbType.Int).Value = IDNldXuatKhau;
            Cmd.Parameters.Add("NguoiDaiDienTVS", SqlDbType.NVarChar).Value = NguoiDaiDienTVS;
            Cmd.Parameters.Add("IDDonViTuyenDung", SqlDbType.Int).Value = IDDonViTuyenDung;
            Cmd.Parameters.Add("IDNldDangKy", SqlDbType.Int).Value = IDNldDangKy;
            Cmd.Parameters.Add("DiaDiem", SqlDbType.NVarChar).Value = DiaDiem;
            if (NgayDangKyTuVan != null)
            {
                Cmd.Parameters.Add("NgayDangKyTuVan", SqlDbType.DateTime).Value = NgayDangKyTuVan;
            }
            else
            {
                Cmd.Parameters.Add("NgayDangKyTuVan", SqlDbType.DateTime).Value = DBNull.Value;
            }

            Cmd.Parameters.Add("IDCanBo", SqlDbType.Int).Value = IDCanBo;
            Cmd.Parameters.Add("IDKetQuaTuVan", SqlDbType.Int).Value = IDKetQuaTuVan;
            if (NgayCocTien != null)
            {
                Cmd.Parameters.Add("NgayCocTien", SqlDbType.DateTime).Value = NgayCocTien;
            }
            else
            {
                Cmd.Parameters.Add("NgayCocTien", SqlDbType.DateTime).Value = DBNull.Value;
            }
            Cmd.Parameters.Add("TienCoc", SqlDbType.Float).Value = TienCoc;
            Cmd.Parameters.Add("IDDonVi", SqlDbType.Int).Value = IDDonVi;

            Cmd.Parameters.Add("NguoiXuLy", SqlDbType.NVarChar).Value = NguoiXuLy;
            Cmd.Parameters.Add("IDDaoTaoMonHoc", SqlDbType.Int).Value = IDDaoTaoMonHoc;
            Cmd.Parameters.Add("NoiDaoTao", SqlDbType.NVarChar).Value = NoiDaoTao;
            if (NgayBatDau != null)
            {
                Cmd.Parameters.Add("NgayBatDau", SqlDbType.DateTime).Value = NgayBatDau;
            }
            else
            {
                Cmd.Parameters.Add("NgayBatDau", SqlDbType.DateTime).Value = DBNull.Value;
            }
            if (NgayKetThuc != null)
            {
                Cmd.Parameters.Add("NgayKetThuc", SqlDbType.DateTime).Value = NgayKetThuc;
            }
            else
            {
                Cmd.Parameters.Add("NgayKetThuc", SqlDbType.DateTime).Value = DBNull.Value;
            }

            Cmd.Parameters.Add("KhoaHoc", SqlDbType.NVarChar).Value = KhoaHoc;
            if (NgayXuatCanhDuKien != null)
            {
                Cmd.Parameters.Add("NgayXuatCanhDuKien", SqlDbType.DateTime).Value = NgayXuatCanhDuKien;
            }
            else
            {
                Cmd.Parameters.Add("NgayXuatCanhDuKien", SqlDbType.DateTime).Value = DBNull.Value;
            }
            if (NgayViSa != null)
            {
                Cmd.Parameters.Add("NgayViSa", SqlDbType.DateTime).Value = NgayViSa;
            }
            else
            {
                Cmd.Parameters.Add("NgayViSa", SqlDbType.DateTime).Value = DBNull.Value;
            }
            if (NgayXuatCanh != null)
            {
                Cmd.Parameters.Add("NgayXuatCanh", SqlDbType.DateTime).Value = NgayXuatCanh;
            }
            else
            {
                Cmd.Parameters.Add("NgayXuatCanh", SqlDbType.DateTime).Value = DBNull.Value;
            }
            if (NgayVe != null)
            {
                Cmd.Parameters.Add("NgayVe", SqlDbType.DateTime).Value = NgayVe;
            }
            else
            {
                Cmd.Parameters.Add("NgayVe", SqlDbType.DateTime).Value = DBNull.Value;
            }

            Cmd.Parameters.Add("NguoiGioiThieu", SqlDbType.NVarChar).Value = NguoiGioiThieu;
            Cmd.Parameters.Add("IDKetQuaHoSo", SqlDbType.Int).Value = IDKetQuaHoSo;
            Cmd.Parameters.Add("NoiDungKhac", SqlDbType.NVarChar).Value = NoiDungKhac;
            Cmd.Parameters.Add("State", SqlDbType.Int).Value = State;

            Cmd.ExecuteNonQuery();

            if (IDNldXuatKhau == 0)
            {
                sqlQuery = "SELECT TOP 1 IDNldXuatKhau FROM TblNldXuatKhau WHERE IDNldDangKy = @IDNldDangKy ORDER BY IDNldXuatKhau DESC";
                Cmd.CommandText = sqlQuery;
                SqlDataReader Rd = Cmd.ExecuteReader();
                while (Rd.Read())
                {
                    IDNldXuatKhau = int.Parse(Rd["IDNldXuatKhau"].ToString());
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
    public int setData(int IDNldTuVan, int IDNldDangKy, bool DuHoc)
    {
        int tmpValue = 0;

        try
        {
            string sqlQuery = "";

            sqlQuery = "IF NOT EXISTS (SELECT * FROM TblNldXuatKhau WHERE IDNldTuVan = @IDNldTuVan) ";
            sqlQuery += "BEGIN INSERT INTO TblNldXuatKhau(IDNldTuVan,IDNldDangKy,DuHoc) VALUES(@IDNldTuVan,@IDNldDangKy,@DuHoc) END ";
            sqlQuery += "ELSE BEGIN UPDATE TblNldXuatKhau SET DuHoc = @DuHoc WHERE IDNldTuVan = @IDNldTuVan END";

            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();

            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;

            Cmd.Parameters.Add("IDNldTuVan", SqlDbType.Int).Value = IDNldTuVan;
            Cmd.Parameters.Add("IDNldDangKy", SqlDbType.Int).Value = IDNldDangKy;
            Cmd.Parameters.Add("DuHoc", SqlDbType.Bit).Value = DuHoc;
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

    #region method getDataTuVanXuatKhau
    public DataTable getDataTuVanXuatKhau(string searchKey, int State)
    {
        string sqlQuery = "", sqlQueryState = "";
        if (searchKey.Trim() != "")
        {
            sqlQuery += " AND UPPER(RTRIM(LTRIM(HoVaTen))) LIKE N'%'+UPPER(RTRIM(LTRIM(@SearchKey)))+'%'";
        }
        if (State != 3)
        {
            sqlQueryState = " AND ISNULL(TblNldXuatKhau.State,0) = " + State.ToString();
        }
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.Parameters.Add("SearchKey", SqlDbType.NVarChar).Value = searchKey;
            Cmd.CommandText = "SELECT 0 AS TT, *, (SELECT TenDonVi FROM TblDoanhNghiep WHERE IDDonVi = TblNldXuatKhau.IDDonViTuyenDung) AS TenDonVi, REPLACE(REPLACE(REPLACE(CAST(ISNULL(TblNldXuatKhau.State,0) AS nvarchar),'0',N'Chưa xử lý'),'1',N'Đang xử lý'),'2',N'Đã xử lý') AS NameState FROM TblNguoiLaoDong, TblNldXuatKhau WHERE TblNguoiLaoDong.IDNguoiLaoDong = TblNldXuatKhau.IDNldDangKy " + sqlQuery + sqlQueryState + " ORDER BY TblNldXuatKhau.IDNldXuatKhau DESC";
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
    public DataTable getDataById(int IDNldXuatKhau)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT TblNldXuatKhau.*, TblNguoiLaoDong.HoVaTen,TblNguoiLaoDong.NgaySinh, TblNguoiLaoDong.IDGioiTinh, TblNguoiLaoDong.DiaChi AS NLDDiaChi, TblNguoiLaoDong.CMND, TblNguoiLaoDong.DienThoai AS NLDDienThoai, TblDoanhNghiep.TenDonVi, TblDoanhNghiep.NguoiDaiDien, TblDoanhNghiep.ChucVu, TblDoanhNghiep.DiaChi, TblDoanhNghiep.DienThoai FROM TblNguoiLaoDong LEFT JOIN TblNldXuatKhau ON TblNldXuatKhau.IDNldDangKy = TblNguoiLaoDong.IDNguoiLaoDong LEFT JOIN TblDoanhNghiep ON TblNldXuatKhau.IDDonViTuyenDung = TblDoanhNghiep.IDDonVi WHERE TblNldXuatKhau.IDNldXuatKhau = @IDNldXuatKhau";
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
}