using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;

public class ThongBaoViecLamHangThang:DataClass
{
    #region Data Object
    public int IDThongBaoViecLam { get; set; }
    public int IDNLDTCTN { get; set; }
    public int IDCanBoTiepNhan { get; set; }
    public int ThangThongBao { get; set; }
    public DateTime NgayThongBao { get; set; }
    public bool ThongBaoTrucTiep { get; set; }
    public int LyDo { get; set; }
    public string BanTiepNhan { get; set; }
    public string GhiChu { get; set; }
    public int TrangThaiThongBao { get; set; }

    #endregion 
    public int SetData(int IDNLDTCTN, int IDCanBoTiepNhan, int ThangThongBao, DateTime NgayThongBao, bool ThongBaoTrucTiep, int LyDo, string BanTiepNhan, string GhiChu, int TrangThaiThongBao)
    {
        int value = 0;
        try
        {
            string sql = "If Not Exists(Select * From TblThongBaoViecLamHangThang Where IDNLDTCTN=@IDNLDTCTN And ThangThongBao=@ThangThongBao)";
            sql += " Insert Into TblThongBaoViecLamHangThang (IDNLDTCTN,IDCanBoTiepNhan,ThangThongBao,NgayThongBao,ThongBaoTrucTiep,LyDo,BanTiepNhan,GhiChu,TrangThaiThongBao)";
            sql += " Values (@IDNLDTCTN,@IDCanBoTiepNhan,@ThangThongBao,@NgayThongBao,@ThongBaoTrucTiep,@LyDo,@BanTiepNhan,@GhiChu,@TrangThaiThongBao)";
            sql += " Update TblThongBaoViecLamHangThang Set IDNLDTCTN=@IDNLDTCTN,IDCanBoTiepNhan=@IDCanBoTiepNhan,ThangThongBao=@ThangThongBao,NgayThongBao=@NgayThongBao,ThongBaoTrucTiep=@ThongBaoTrucTiep,LyDo=@LyDo,BanTiepNhan=@BanTiepNhan,GhiChu=@GhiChu,TrangThaiThongBao=@TrangThaiThongBao";
            sql += " Where IDNLDTCTN=@IDNLDTCTN And ThangThongBao=@ThangThongBao";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sql;
            Cmd.Parameters.Add("IDNLDTCTN", SqlDbType.Int).Value = IDNLDTCTN;
            Cmd.Parameters.Add("IDCanBoTiepNhan", SqlDbType.Int).Value = IDCanBoTiepNhan;
            Cmd.Parameters.Add("ThangThongBao", SqlDbType.Int).Value = ThangThongBao;
            Cmd.Parameters.Add("NgayThongBao", SqlDbType.DateTime).Value = NgayThongBao;
            Cmd.Parameters.Add("ThongBaoTrucTiep", SqlDbType.Bit).Value = ThongBaoTrucTiep;
            Cmd.Parameters.Add("LyDo", SqlDbType.Int).Value = LyDo;
            Cmd.Parameters.Add("BanTiepNhan", SqlDbType.NVarChar).Value = BanTiepNhan;
            Cmd.Parameters.Add("GhiChu", SqlDbType.NVarChar).Value = GhiChu;
            Cmd.Parameters.Add("TrangThaiThongBao", SqlDbType.NVarChar).Value = TrangThaiThongBao;
            value = Cmd.ExecuteNonQuery();
            sqlCon.Close();
            sqlCon.Dispose();
        }
        catch (Exception ex)
        {
            this.Message = ex.Message;
            this.ErrorCode = ex.HResult;
           
        }
        return value;
    }
    public DataTable GetByID(int IDNLDTCTN, int ThangThongBao,int TrangThaiThongBao=0)
    {
        string sql = "Select * From TblThongBaoViecLamHangThang Where IDNLDTCTN=@IDNLDTCTN And (ThangThongBao=@ThangThongBao  Or @ThangThongBao=0) And (TrangThaiThongBao=@TrangThaiThongBao Or @TrangThaiThongBao=0)";
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
        sqlCon.Open();
        SqlCommand Cmd = sqlCon.CreateCommand();
        Cmd.CommandText = sql;
        Cmd.Parameters.Add("IDNLDTCTN", SqlDbType.Int).Value = IDNLDTCTN;
        Cmd.Parameters.Add("ThangThongBao", SqlDbType.Int).Value = ThangThongBao;
        Cmd.Parameters.Add("TrangThaiThongBao", SqlDbType.Int).Value = TrangThaiThongBao;
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(Cmd);
        da.Fill(ds);
        sqlCon.Close();
        sqlCon.Dispose();
        return ds.Tables[0];
       
    }
    public DataTable GetMax(int IDNLDTCTN)
    {
        string sql = "Select top 1 * From TblThongBaoViecLamHangThang Where IDNLDTCTN=@IDNLDTCTN Order By IDThongBaoViecLam Desc";
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
        sqlCon.Open();
        SqlCommand Cmd = sqlCon.CreateCommand();
        Cmd.CommandText = sql;
        Cmd.Parameters.Add("IDNLDTCTN", SqlDbType.Int).Value = IDNLDTCTN;
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(Cmd);
        da.Fill(ds);
        sqlCon.Close();
        sqlCon.Dispose();
        return ds.Tables[0];
    }
}