using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;

public class TrinhDoPhoThong
{
	#region method TrinhDoPhoThong
    public TrinhDoPhoThong()
    {
    } 
    #endregion

    #region method setData
    public int setData(int IDTrinhDoPhoThong, string CodeTrinhDoPhoThong, string NameTrinhDoPhoThong, string Note, bool State)
    {
        int tmpValue = 0;
        try
        {
            string sqlQuery = "";
            sqlQuery = "IF NOT EXISTS (SELECT * FROM TblTrinhDoPhoThong WHERE IDTrinhDoPhoThong = @IDTrinhDoPhoThong) ";
            sqlQuery += "BEGIN INSERT INTO TblTrinhDoPhoThong(CodeTrinhDoPhoThong,NameTrinhDoPhoThong,Note,State) VALUES(@CodeTrinhDoPhoThong,@NameTrinhDoPhoThong,@Note,@State) END ";
            sqlQuery += "ELSE BEGIN UPDATE TblTrinhDoPhoThong SET CodeTrinhDoPhoThong = @CodeTrinhDoPhoThong, NameTrinhDoPhoThong = @NameTrinhDoPhoThong, Note = @Note, State = @State WHERE IDTrinhDoPhoThong = @IDTrinhDoPhoThong END";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("IDTrinhDoPhoThong", SqlDbType.Int).Value = IDTrinhDoPhoThong;
            Cmd.Parameters.Add("CodeTrinhDoPhoThong", SqlDbType.NVarChar).Value = CodeTrinhDoPhoThong;
            Cmd.Parameters.Add("NameTrinhDoPhoThong", SqlDbType.NVarChar).Value = NameTrinhDoPhoThong;
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
            sqlQuery += " AND UPPER(RTRIM(LTRIM(NameTrinhDoPhoThong))) LIKE N'%'+UPPER(RTRIM(LTRIM(@SearchKey)))+'%'";
        }
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.Parameters.Add("SearchKey", SqlDbType.NVarChar).Value = searchKey;
            Cmd.CommandText = "SELECT 0 AS TT, *, REPLACE(REPLACE(CAST(State AS varchar),'1',N'Kích hoạt'),'0',N'Đóng') AS StateName FROM TblTrinhDoPhoThong WHERE 1 = 1 " + sqlQuery;
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
    public DataTable getDataById(int IDTrinhDoPhoThong)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.Parameters.Add("IDTrinhDoPhoThong", SqlDbType.Int).Value = IDTrinhDoPhoThong;
            Cmd.CommandText = "SELECT * FROM TblTrinhDoPhoThong WHERE IDTrinhDoPhoThong = @IDTrinhDoPhoThong";
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

    #region method getDataNameById
    public string getDataNameById(int IDTrinhDoPhoThong)
    {
        string tmpName = "";
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.Parameters.Add("IDTrinhDoPhoThong", SqlDbType.Int).Value = IDTrinhDoPhoThong;
            Cmd.CommandText = "SELECT * FROM TblTrinhDoPhoThong WHERE IDTrinhDoPhoThong = @IDTrinhDoPhoThong";
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlCon.Close();
            sqlCon.Dispose();
            objTable = ds.Tables[0];
            if (objTable.Rows.Count > 0)
            {
                tmpName = objTable.Rows[0]["NameTrinhDoPhoThong"].ToString();
            }
        }
        catch
        {

        }
        return tmpName;
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
            Cmd.CommandText = "SELECT IDTrinhDoPhoThong, NameTrinhDoPhoThong FROM TblTrinhDoPhoThong";
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
    public bool checkCode(string CodeTrinhDoPhoThong)
    {
        bool tmpValue = false;
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT * FROM TblTrinhDoPhoThong WHERE CodeTrinhDoPhoThong = @CodeTrinhDoPhoThong";
            Cmd.Parameters.Add("CodeTrinhDoPhoThong", SqlDbType.NVarChar).Value = CodeTrinhDoPhoThong;
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
    public void delData(int IDTrinhDoPhoThong)
    {
        try
        {
            string sqlQuery = "";
            sqlQuery = "DELETE TblTrinhDoPhoThong WHERE IDTrinhDoPhoThong = @IDTrinhDoPhoThong ";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("IDTrinhDoPhoThong", SqlDbType.Int).Value = IDTrinhDoPhoThong;
            Cmd.ExecuteNonQuery();
            sqlCon.Close();
            sqlCon.Dispose();
        }
        catch
        {

        }
    }
    #endregion
}