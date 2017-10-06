using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;

public class Log:DataClass
{
    public int ID { get; set; }
    public string Action { get; set; }
    public int UserID { get; set; }
    public string UserName { get; set; }
    public string GhiChu { get; set; }
    public DateTime NgayTao { get; set; }
    public int NguoiLaoDongID { get; set; }
    public int TroCapThatNghiepID { get; set; }

    public int Insert(Log Item)
    {
        int index = 0;
        try
        {
            string sql = "Insert Into tblLog (Action,UserID,UserName,GhiChu,NgayTao,NguoiLaoDongID,TroCapThatNghiepID)";
            sql += " Values (@Action,@UserID,@UserName,@GhiChu,@NgayTao,@NguoiLaoDongID,@TroCapThatNghiepID)";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sql;
            Cmd.Parameters.Add("Action", SqlDbType.NVarChar).Value = Item.Action;
            Cmd.Parameters.Add("UserID", SqlDbType.Int).Value = Item.UserID;
            Cmd.Parameters.Add("UserName", SqlDbType.NVarChar).Value = Item.UserName;
            Cmd.Parameters.Add("GhiChu", SqlDbType.NVarChar).Value = Item.GhiChu;
            Cmd.Parameters.Add("NgayTao", SqlDbType.DateTime).Value = Item.NgayTao;
            Cmd.Parameters.Add("NguoiLaoDongID", SqlDbType.Int).Value = Item.NguoiLaoDongID;
            Cmd.Parameters.Add("TroCapThatNghiepID", SqlDbType.Int).Value = Item.TroCapThatNghiepID;
            index= Cmd.ExecuteNonQuery();
            sqlCon.Close();
            sqlCon.Dispose();         
        }
        catch (Exception ex)
        {
            this.Message = ex.Message;
            this.ErrorCode = ex.HResult;   
            index=0;
        }
        return index;
    }
    public DataTable GetByOptions(int IDTCTN, int NguoiLaoDongID=0,int UserID=0)
    {
        string sql = "Select * From tblLog Where TroCapThatNghiepID=@IDTCTN And (NguoiLaoDongID=@NguoiLaoDongID Or @NguoiLaoDongID=0) And (UserID=@UserID Or @UserID=0)";
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
        sqlCon.Open();
        SqlCommand Cmd = sqlCon.CreateCommand();
        Cmd.CommandText = sql;
        Cmd.Parameters.Add("IDTCTN", SqlDbType.Int).Value =IDTCTN;
        Cmd.Parameters.Add("NguoiLaoDongID", SqlDbType.Int).Value =NguoiLaoDongID;
        Cmd.Parameters.Add("UserID", SqlDbType.Int).Value = UserID;
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(Cmd);
        da.Fill(ds);
        sqlCon.Close();
        sqlCon.Dispose();
        return ds.Tables[0];

    }

    public int Update(Log Item)
    {
        string sql = " Update tblLog Set Action=@Action,UserID=@UserID,UserName=@UserName,GhiChu=@GhiChu";
        sql += " NgayTao=,@NgayTao,NguoiLaoDongID=@NguoiLaoDongID,TroCapThatNghiepID@TroCapThatNghiepID Where ID=@ID";
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
        sqlCon.Open();
        SqlCommand Cmd = sqlCon.CreateCommand();
        Cmd.CommandText = sql;
        Cmd.Parameters.Add("ID", SqlDbType.Int).Value = Item.ID;
        Cmd.Parameters.Add("Action", SqlDbType.NVarChar).Value = Item.Action;
        Cmd.Parameters.Add("UserID", SqlDbType.Int).Value = Item.UserID;
        Cmd.Parameters.Add("UserName", SqlDbType.NVarChar).Value = Item.UserName;
        Cmd.Parameters.Add("GhiChu", SqlDbType.NVarChar).Value = Item.GhiChu;
        Cmd.Parameters.Add("NgayTao", SqlDbType.DateTime).Value = Item.NgayTao;
        Cmd.Parameters.Add("NguoiLaoDongID", SqlDbType.Int).Value = Item.NguoiLaoDongID;
        Cmd.Parameters.Add("TroCapThatNghiepID", SqlDbType.Int).Value = Item.TroCapThatNghiepID;
        return Cmd.ExecuteNonQuery();
    }
    public int Delete(int ID)
    {
        string sql = "Delete From tblLog Where ID=@ID";
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
        sqlCon.Open();
        SqlCommand Cmd = sqlCon.CreateCommand();
        Cmd.CommandText = sql;
        Cmd.Parameters.Add("ID", SqlDbType.Int).Value = ID;
        return Cmd.ExecuteNonQuery();
    }
}