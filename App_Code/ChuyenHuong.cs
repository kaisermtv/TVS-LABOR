using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;

public class ChuyenHuong: DataClass
{
    #region object
    public int IDChuyenHuong { get; set; }
    public int IDNLDTCTN { get; set; }
    public string LyDoChuyen { get; set; }
    public int IDNoiChuyen { get; set; }
    public DateTime NgayDeNghi { get; set; }
    public string SoGiayGioiThieu { get; set; }
    public string SoGuiBHXH { get; set; }
    public int StatusID { get; set; }
    #endregion

    public int  SetData(int IDNLDTCTN,int LyDoChuyen,int IDNoiChuyen, DateTime NgayDeNghi,string SoGiayGioiThieu, int SoGuiBHXH,int StatusID=0 )
    {
        int tmpValue = 0;
        try
        {
            string sqlQuery = "";
            sqlQuery = "IF NOT EXISTS (SELECT Top 1 * FROM TblChuyenHuong Where IDNLDTCTN=@IDNLDTCTN Order By IDChuyenHuong DESC) ";
            sqlQuery += "BEGIN INSERT INTO TblChuyenHuong(IDNLDTCTN,LyDoChuyen,IDNoiChuyen,NgayDeNghi,SoGiayGioiThieu,SoGuiBHXH,StatusID)";
            sqlQuery += " VALUES(@IDNLDTCTN,@LyDoChuyen,@IDNoiChuyen,@NgayDeNghi,@SoGiayGioiThieu,@SoGuiBHXH,@StatusID) END ";
            sqlQuery += "ELSE BEGIN UPDATE TblChuyenHuong SET IDNLDTCTN=@IDNLDTCTN,LyDoChuyen=@LyDoChuyen,IDNoiChuyen=@IDNoiChuyen,NgayDeNghi=@NgayDeNghi,SoGiayGioiThieu=@SoGiayGioiThieu,SoGuiBHXH=@SoGuiBHXH,StatusID=@StatusID";
            sqlQuery += " WHERE IDNLDTCTN = @IDNLDTCTN END";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("IDNLDTCTN", SqlDbType.Int).Value = IDNLDTCTN;
            Cmd.Parameters.Add("LyDoChuyen", SqlDbType.NVarChar).Value = LyDoChuyen;
            Cmd.Parameters.Add("IDNoiChuyen", SqlDbType.Int).Value = IDNoiChuyen;
            Cmd.Parameters.Add("NgayDeNghi", SqlDbType.DateTime).Value = NgayDeNghi;
            Cmd.Parameters.Add("SoGiayGoiThieu", SqlDbType.NVarChar).Value = SoGiayGioiThieu;
            Cmd.Parameters.Add("SoGuiBHXH", SqlDbType.NVarChar).Value = SoGuiBHXH;
            Cmd.Parameters.Add("StatusID", SqlDbType.Int).Value = StatusID;  
            Cmd.ExecuteNonQuery();
            sqlCon.Close();
            sqlCon.Dispose();
            tmpValue = 1;
        }
        catch (Exception ex)
        {
            this.Message = ex.Message;
            this.ErrorCode = ex.HResult;
            tmpValue = 0;
        }
        return tmpValue;
    }
    public int  InsertChuyenHuong(int IDNLDTCTN,string LyDoChuyen,int IDNoiChuyen, DateTime NgayDeNghi,string SoGiayGioiThieu, string SoGuiBHXH,int StatusID=0 )
    {
        int value = 0;
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
        sqlCon.Open();
        string sql = "Insert Into TblChuyenHuong(IDNLDTCTN,LyDoChuyen,IDNoiChuyen,NgayDeNghi,SoGiayGioiThieu,SoGuiBHXH,StatusID)";
        sql += " Values (@IDNLDTCTN,@LyDoChuyen,@IDNoiChuyen,@NgayDeNghi,@SoGiayGioiThieu,@SoGuiBHXH,@StatusID)";
        sql += " Select Max(IDChuyenHuong) From TblChuyenHuong Where IDNLDTCTN=@IDNLDTCTN";       
        SqlCommand Cmd = sqlCon.CreateCommand();
        Cmd.CommandText = sql;
        Cmd.Parameters.Add("IDNLDTCTN", SqlDbType.Int).Value = IDNLDTCTN;
        Cmd.Parameters.Add("LyDoChuyen", SqlDbType.NVarChar).Value = LyDoChuyen;
        Cmd.Parameters.Add("IDNoiChuyen", SqlDbType.Int).Value = IDNoiChuyen;
        Cmd.Parameters.Add("NgayDeNghi", SqlDbType.DateTime).Value = NgayDeNghi;
        Cmd.Parameters.Add("SoGiayGioiThieu", SqlDbType.NVarChar).Value = SoGiayGioiThieu;
        Cmd.Parameters.Add("SoGuiBHXH", SqlDbType.NVarChar).Value = SoGuiBHXH;
        Cmd.Parameters.Add("StatusID", SqlDbType.Int).Value = StatusID;
        value=(int)Cmd.ExecuteScalar();
        sqlCon.Close();
        sqlCon.Dispose();
        return value;
    }
    public DataTable GetByMaxIDNLDTCTN(int IDNLDTCTN)
    {
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
        sqlCon.Open();
        string sql = "Select Top 1 * From TblChuyenHuong Where IDNLDTCTN=@IDNLDTCTN Order By IDChuyenHuong Desc";  
        SqlCommand Cmd = sqlCon.CreateCommand();
        Cmd.CommandText = sql;
        Cmd.Parameters.Add("IDNLDTCTN", SqlDbType.Int).Value = IDNLDTCTN;
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(Cmd);
        da.Fill(ds);
        return ds.Tables[0];
    }
    public int UpdateChuyenHuong(int IDChuyenHuong, int IDNLDTCTN, string LyDoChuyen, int IDNoiChuyen, DateTime NgayDeNghi, string SoGiayGioiThieu, string SoGuiBHXH, int StatusID = 0)
    {
        int value = 0;
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
        sqlCon.Open();
        string sql = "Update  TblChuyenHuong Set  IDNLDTCTN=@IDNLDTCTN,LyDoChuyen=@LyDoChuyen,IDNoiChuyen=@IDNoiChuyen,NgayDeNghi=@NgayDeNghi,SoGiayGioiThieu=@SoGiayGioiThieu,SoGuiBHXH=@SoGuiBHXH,StatusID=@StatusID";
        sql += " Where IDChuyenHuong=@IDChuyenHuong";
        sql += " Select @IDChuyenHuong";
        SqlCommand Cmd = sqlCon.CreateCommand();
        Cmd.CommandText = sql;
        Cmd.Parameters.Add("IDChuyenHuong", SqlDbType.Int).Value = IDChuyenHuong;
        Cmd.Parameters.Add("IDNLDTCTN", SqlDbType.Int).Value = IDNLDTCTN;
        Cmd.Parameters.Add("LyDoChuyen", SqlDbType.NVarChar).Value = LyDoChuyen;
        Cmd.Parameters.Add("IDNoiChuyen", SqlDbType.Int).Value = IDNoiChuyen;
        Cmd.Parameters.Add("NgayDeNghi", SqlDbType.DateTime).Value = NgayDeNghi;
        Cmd.Parameters.Add("SoGiayGioiThieu", SqlDbType.NVarChar).Value = SoGiayGioiThieu;
        Cmd.Parameters.Add("SoGuiBHXH", SqlDbType.NVarChar).Value = SoGuiBHXH;
        Cmd.Parameters.Add("StatusID", SqlDbType.Int).Value = StatusID;
        value = (int)Cmd.ExecuteScalar();
        sqlCon.Close();
        sqlCon.Dispose();
        return value;
    }

}