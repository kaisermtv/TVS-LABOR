using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;

public class NgoaiNgu
{
	#region method NgoaiNgu
    public NgoaiNgu()
    {
    } 
    #endregion

    #region method setData
    public int setData(int IDNgoaiNgu, string CodeNgoaiNgu, string NameNgoaiNgu, string Note, bool State)
    {
        int tmpValue = 0;
        try
        {
            string sqlQuery = "";
            sqlQuery = "IF NOT EXISTS (SELECT * FROM TblNgoaiNgu WHERE IDNgoaiNgu = @IDNgoaiNgu) ";
            sqlQuery += "BEGIN INSERT INTO TblNgoaiNgu(CodeNgoaiNgu,NameNgoaiNgu,Note,State) VALUES(@CodeNgoaiNgu,@NameNgoaiNgu,@Note,@State) END ";
            sqlQuery += "ELSE BEGIN UPDATE TblNgoaiNgu SET CodeNgoaiNgu = @CodeNgoaiNgu, NameNgoaiNgu = @NameNgoaiNgu, Note = @Note, State = @State WHERE IDNgoaiNgu = @IDNgoaiNgu END";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("IDNgoaiNgu", SqlDbType.Int).Value = IDNgoaiNgu;
            Cmd.Parameters.Add("CodeNgoaiNgu", SqlDbType.NVarChar).Value = CodeNgoaiNgu;
            Cmd.Parameters.Add("NameNgoaiNgu", SqlDbType.NVarChar).Value = NameNgoaiNgu;
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
            sqlQuery += " AND UPPER(RTRIM(LTRIM(NameNgoaiNgu))) LIKE N'%'+UPPER(RTRIM(LTRIM(@SearchKey)))+'%'";
        }
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.Parameters.Add("SearchKey", SqlDbType.NVarChar).Value = searchKey;
            Cmd.CommandText = "SELECT 0 AS TT, *, REPLACE(REPLACE(CAST(State AS varchar),'1',N'Kích hoạt'),'0',N'Đóng') AS StateName FROM TblNgoaiNgu WHERE 1 = 1 " + sqlQuery;
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
    public DataTable getDataById(int IDNgoaiNgu)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.Parameters.Add("IDNgoaiNgu", SqlDbType.Int).Value = IDNgoaiNgu;
            Cmd.CommandText = "SELECT * FROM TblNgoaiNgu WHERE IDNgoaiNgu = @IDNgoaiNgu";
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
    public string getDataNameById(int IDNgoaiNgu)
    {
        string tmpName = "";
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.Parameters.Add("IDNgoaiNgu", SqlDbType.Int).Value = IDNgoaiNgu;
            Cmd.CommandText = "SELECT * FROM TblNgoaiNgu WHERE IDNgoaiNgu = @IDNgoaiNgu";
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlCon.Close();
            sqlCon.Dispose();
            objTable = ds.Tables[0];
            if(objTable.Rows.Count > 0)
            {
                tmpName = objTable.Rows[0]["NameNgoaiNgu"].ToString();
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
            Cmd.CommandText = "SELECT IDNgoaiNgu, NameNgoaiNgu FROM TblNgoaiNgu";
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
    public bool checkCode(string CodeNgoaiNgu)
    {
        bool tmpValue = false;
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT * FROM TblNgoaiNgu WHERE CodeNgoaiNgu = @CodeNgoaiNgu";
            Cmd.Parameters.Add("CodeNgoaiNgu", SqlDbType.NVarChar).Value = CodeNgoaiNgu;
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
    public void delData(int IDNgoaiNgu)
    {
        try
        {
            string sqlQuery = "";
            sqlQuery = "DELETE TblNgoaiNgu WHERE IDNgoaiNgu = @IDNgoaiNgu ";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("IDNgoaiNgu", SqlDbType.Int).Value = IDNgoaiNgu;
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