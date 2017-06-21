using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;

public class CapSo:DataClass
{
    #region Data Object
    public int IDCapSo { get; set; }
    public int So { get; set; }
    public DateTime NgayCap { get; set; }
    public string SoVanBan { get; set; }
    public int IDNLDTCTN { get; set; }
    public int IDLoaiVanBan { get; set; }
    public string Nam { get; set; }
    #endregion 
    public CapSo()
    {
    }

    public int GetAutoNumber(DateTime NgayCap,int IDLoaiVanBan)
    {
        int Index = 0;
        try
        {
            string sql = "If exists (select * from TblCapSo Where  IDLoaiVanBan=@IDLoaivanBan And NgayCap=@NgayCap)";
            sql += " select  MAX(so)+1 from TblCapSo Where  IDLoaiVanBan=@IDLoaivanBan  And NgayCap=@NgayCap";
            sql += " else select 1";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sql;
            Cmd.Parameters.Add("IDLoaivanBan", SqlDbType.Int).Value = IDLoaiVanBan;
            Cmd.Parameters.Add("NgayCap", SqlDbType.DateTime).Value = NgayCap;
            Index = (int)Cmd.ExecuteScalar();
            sqlCon.Close();
            sqlCon.Dispose();
        }
        catch (Exception ex)
        {
            Message = ex.Message;
            ErrorCode = ex.HResult;
        }
        return Index;
     
    }
    public bool CheckAutoNumber(DateTime NgayCap, int IDLoaiVanBan, int So)
    {
        bool Status = false;
        int Index = 0;
        try
        {
            string sql = "Select * from  Where So=@So And IDLoaiVanBan=@IDLoaivanBan And NgayCap=@NgayCap ";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sql;
            Cmd.Parameters.Add("IDLoaivanBan", SqlDbType.Int).Value = IDLoaiVanBan;
            Cmd.Parameters.Add("NgayCap", SqlDbType.DateTime).Value = NgayCap;
            Cmd.Parameters.Add("So", SqlDbType.Int).Value = So;
            Index = (int)Cmd.ExecuteNonQuery();
            sqlCon.Close();
            sqlCon.Dispose();
        }
        catch (Exception ex)
        {
            Message = ex.Message;
            ErrorCode = ex.HResult;
        }
        if(Index>0)
        {
            return true;
        }
        return Status;
     
    }
    public int SetData(int So, DateTime NgayCap, string SoVanBan, int IDNLDTCTN, int IDLoaiVanBan, string Nam)
    {
        int value = 0;
        string sql = "If not exists(Select * From TblCapSo Where NgayCap=@NgayCap And So=@So And IDLoaiVanBan=@IDLoaiVanBan)";
        sql += " Insert Into TblCapSo(So,NgayCap,SoVanBan,IDNLDTCTN,IDLoaiVanBan,Nam) Values (@So,@NgayCap,@SoVanBan,@IDNLDTCTN,@IDLoaiVanBan,@Nam)";
        sql += " Else Update TblCapSo Set So=@So,SoVanBan=@SoVanBan Where NgayCap=@NgayCap And IDNLDTCTN=@IDNLDTCTN And IDLoaiVanBan=@IDLoaiVanBan And So=@So";
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sql;
            Cmd.Parameters.Add("So", SqlDbType.Int).Value = So;
            Cmd.Parameters.Add("NgayCap", SqlDbType.DateTime).Value = NgayCap;
            Cmd.Parameters.Add("SoVanBan", SqlDbType.NVarChar).Value = SoVanBan;
            Cmd.Parameters.Add("IDNLDTCTN", SqlDbType.Int).Value = IDNLDTCTN;
            Cmd.Parameters.Add("IDLoaiVanBan", SqlDbType.Int).Value = IDLoaiVanBan;
            Cmd.Parameters.Add("Nam", SqlDbType.NVarChar).Value = Nam;
            value = Cmd.ExecuteNonQuery();
        }
        catch(Exception ex)
        {
            Message = ex.Message;
            ErrorCode = ex.HResult;
        }
        return value;
    }
    public DataTable GetDataByIDTCTN(int IDNLDTCTN)
    {        
        string sql = "Select * From TblCapSo Where IDNLDTCTN=@IDNLDTCTN";
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
        sqlCon.Open();
        SqlCommand Cmd = sqlCon.CreateCommand();
        Cmd.CommandText = sql;
        Cmd.Parameters.Add("IDNLDTCTN", SqlDbType.Int).Value = IDNLDTCTN;
        SqlDataAdapter da = new SqlDataAdapter(Cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);       
        sqlCon.Close();
        sqlCon.Dispose();
        return ds.Tables[0];
    }
}