using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;

public class Mucluong :DataClass
{
	#region method Mucluong
    public Mucluong()
    {
    } 
    #endregion

    #region method setData
    public int setData(int IDMucluong, string CodeMucluong, string NameMucluong, double MinValue, double MaxValue, string Note, bool State)
    {
        int tmpValue = 0;
        try
        {
            string sqlQuery = "";
            sqlQuery = "IF NOT EXISTS (SELECT * FROM TblMucluong WHERE IDMucluong = @IDMucluong) ";
            sqlQuery += "BEGIN INSERT INTO TblMucluong(CodeMucluong,NameMucluong,MinValue,MaxValue,Note,State) VALUES(@CodeMucluong,@NameMucluong,@MinValue,@MaxValue,@Note,@State) END ";
            sqlQuery += "ELSE BEGIN UPDATE TblMucluong SET CodeMucluong = @CodeMucluong, NameMucluong = @NameMucluong, MinValue = @MinValue, MaxValue = @MaxValue, Note = @Note, State = @State WHERE IDMucluong = @IDMucluong END";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("IDMucluong", SqlDbType.Int).Value = IDMucluong;
            Cmd.Parameters.Add("CodeMucluong", SqlDbType.NVarChar).Value = CodeMucluong;
            Cmd.Parameters.Add("NameMucluong", SqlDbType.NVarChar).Value = NameMucluong;
            Cmd.Parameters.Add("MinValue", SqlDbType.Float).Value = MinValue;
            Cmd.Parameters.Add("MaxValue", SqlDbType.Float).Value = MaxValue;
            Cmd.Parameters.Add("Note", SqlDbType.NVarChar).Value = Note;
            Cmd.Parameters.Add("State", SqlDbType.Bit).Value = State;
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

    #region method getData
    public DataTable getData(string searchKey)
    {
        string sqlQuery = "";
        if (searchKey.Trim() != "")
        {
            sqlQuery += " AND UPPER(RTRIM(LTRIM(NameMucLuong))) LIKE N'%'+UPPER(RTRIM(LTRIM(@SearchKey)))+'%'";
        }
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.Parameters.Add("SearchKey", SqlDbType.NVarChar).Value = searchKey;
            Cmd.CommandText = "SELECT 0 AS TT, *, REPLACE(REPLACE(CAST(State AS varchar),'1',N'Kích hoạt'),'0',N'Đóng') AS StateName FROM TblMucluong WHERE 1 = 1 " + sqlQuery;
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
    public DataTable getDataById(int IDMucluong)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.Parameters.Add("IDMucluong", SqlDbType.Int).Value = IDMucluong;
            Cmd.CommandText = "SELECT * FROM TblMucluong WHERE IDMucluong = @IDMucluong";
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

    #region method getDataCategoryToCombobox
    public DataTable getDataCategoryToCombobox()
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT IDMucluong, NameMucluong FROM TblMucluong";
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

    #region method checkCode
    public bool checkCode(string CodeMucluong)
    {
        bool tmpValue = false;
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT * FROM TblMucluong WHERE CodeMucluong = @CodeMucluong";
            Cmd.Parameters.Add("CodeMucluong", SqlDbType.NVarChar).Value = CodeMucluong;
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

    #region method delData
    public void delData(int IDMucluong)
    {
        try
        {
            string sqlQuery = "";
            sqlQuery = "DELETE TblMucluong WHERE IDMucluong = @IDMucluong ";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("IDMucluong", SqlDbType.Int).Value = IDMucluong;
            Cmd.ExecuteNonQuery();
            sqlCon.Close();
            sqlCon.Dispose();
        }
        catch
        {

        }
    }
    #endregion

    #region Method getNameMucLuongById
    public string getNameMucLuongById(int id)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "SELECT NameMucluong FROM TblMucluong WHERE IDMucluong = @ID";
            Cmd.Parameters.Add("ID", SqlDbType.Int).Value = id;

            string ret = (string)Cmd.ExecuteScalar();

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
}