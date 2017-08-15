using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
public class BieuDoHinhCotBHTN
{
    public string Ngay { get; set; }
    public int SoHoSo { get; set; }
}
public class BaoCao
{
    string _msg = "";
    public DataTable DanhSachLaoDongHuongTCTN(DateTime TuNgay, DateTime DenNgay)
    {
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
        sqlCon.Open();
        string sql = "Select * from dbo.TblNguoiLaoDong NLD";
        sql += " Inner join dbo.TblNLDTroCapThatNghiep TCTN on NLD.IDNguoiLaoDong=TCTN.IDNguoiLaoDong";
        sql += " Inner join dbo.TblCapSo CS on CS.IDNLDTCTN=TCTN.IdNLDTCTN";
        sql += " Where IDLoaiVanBan=30 And (CS.NgayKy between @TuNgay And @DenNgay)";
        SqlCommand Cmd = sqlCon.CreateCommand();
        Cmd.Parameters.Add("TuNgay", SqlDbType.DateTime).Value = TuNgay;
        Cmd.Parameters.Add("DenNgay", SqlDbType.DateTime).Value = DenNgay;
        Cmd.CommandText = sql;
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(Cmd);
        da.Fill(ds);
        sqlCon.Close();
        sqlCon.Dispose();
        return ds.Tables[0];

    }
    public DataTable BieuDoDKBHTN(DateTime TuNgay, DateTime DenNgay)
    {
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
        sqlCon.Open();
        string sql = "Select * from dbo.TblNguoiLaoDong NLD";
        sql += " Inner join dbo.TblNLDTroCapThatNghiep TCTN on NLD.IDNguoiLaoDong=TCTN.IDNguoiLaoDong";
         sql += " Where TCTN.NgayNopHoSo between @TuNgay And @DenNgay";
        SqlCommand Cmd = sqlCon.CreateCommand();
        Cmd.Parameters.Add("TuNgay", SqlDbType.DateTime).Value = TuNgay;
        Cmd.Parameters.Add("DenNgay", SqlDbType.DateTime).Value = DenNgay;
        Cmd.CommandText = sql;
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(Cmd);
        da.Fill(ds);
        sqlCon.Close();
        sqlCon.Dispose();
        return ds.Tables[0];

    }
    public DataTable BieuDoBHTNTheoDoTuoi(DateTime TuNgay, DateTime DenNgay, int TuTuoi, int DenTuoi)
    {
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
        sqlCon.Open();
        string sql = " Select * From (Select NLD.*,TCTN.NgayNopHoSo,(CAST( YEAR(GETDATE()) as int ) - CAST(YEAR(ngaySinh)as int )) as Tuoi  from dbo.TblNguoiLaoDong NLD";
        sql += " Inner join dbo.TblNLDTroCapThatNghiep TCTN on NLD.IDNguoiLaoDong=TCTN.IDNguoiLaoDong) TEMP";
        sql += " WHERE (NgayNopHoSo between @TuNgay And @DenNgay) And (Cast(Tuoi as int) Between @TuTuoi And @DenTuoi)";
        SqlCommand Cmd = sqlCon.CreateCommand();
        Cmd.Parameters.Add("TuNgay", SqlDbType.DateTime).Value = TuNgay;
        Cmd.Parameters.Add("DenNgay", SqlDbType.DateTime).Value = DenNgay;
        Cmd.Parameters.Add("TuTuoi", SqlDbType.Int).Value = TuTuoi;
        Cmd.Parameters.Add("DenTuoi", SqlDbType.Int).Value = DenTuoi;
        Cmd.CommandText = sql;
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(Cmd);
        da.Fill(ds);
        sqlCon.Close();
        sqlCon.Dispose();
        return ds.Tables[0];
    }
}