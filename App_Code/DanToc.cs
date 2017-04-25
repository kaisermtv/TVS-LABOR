using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;

public class DanToc
{
	#region method DanToc
    public DanToc()
    {
    } 
    #endregion

    #region method setData
    public int setData(int IDDanToc, string CodeDanToc, string NameDanToc, string Note, bool State)
    {
        int tmpValue = 0;
        try
        {
            string sqlQuery = "";
            sqlQuery = "IF NOT EXISTS (SELECT * FROM TblDanToc WHERE IDDanToc = @IDDanToc) ";
            sqlQuery += "BEGIN INSERT INTO TblDanToc(CodeDanToc,NameDanToc,Note,State) VALUES(@CodeDanToc,@NameDanToc,@Note,@State) END ";
            sqlQuery += "ELSE BEGIN UPDATE TblDanToc SET CodeDanToc = @CodeDanToc, NameDanToc = @NameDanToc, Note = @Note, State = @State WHERE IDDanToc = @IDDanToc END";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("IDDanToc", SqlDbType.Int).Value = IDDanToc;
            Cmd.Parameters.Add("CodeDanToc", SqlDbType.NVarChar).Value = CodeDanToc;
            Cmd.Parameters.Add("NameDanToc", SqlDbType.NVarChar).Value = NameDanToc;
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
            sqlQuery += " AND UPPER(RTRIM(LTRIM(NameDanToc))) LIKE N'%'+UPPER(RTRIM(LTRIM(@SearchKey)))+'%'";
        }
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.Parameters.Add("SearchKey", SqlDbType.NVarChar).Value = searchKey;
            Cmd.CommandText = "SELECT 0 AS TT, *, REPLACE(REPLACE(CAST(State AS varchar),'1',N'Kích hoạt'),'0',N'Đóng') AS StateName FROM TblDanToc WHERE 1 = 1 " + sqlQuery;
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
    public DataTable getDataById(int IDDanToc)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.Parameters.Add("IDDanToc", SqlDbType.Int).Value = IDDanToc;
            Cmd.CommandText = "SELECT * FROM TblDanToc WHERE IDDanToc = @IDDanToc";
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
    public string getDataNameById(int IDDanToc)
    {
        string tmpName = "";
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.Parameters.Add("IDDanToc", SqlDbType.Int).Value = IDDanToc;
            Cmd.CommandText = "SELECT * FROM TblDanToc WHERE IDDanToc = @IDDanToc";
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlCon.Close();
            sqlCon.Dispose();
            objTable = ds.Tables[0];
            if (objTable.Rows.Count > 0)
            {
                tmpName = objTable.Rows[0]["NameDanToc"].ToString();
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
            Cmd.CommandText = "SELECT IDDanToc, NameDanToc FROM TblDanToc";
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlCon.Close();
            sqlCon.Dispose();
            objTable = ds.Tables[0];
            
            objTable.Rows.Add(0, "Không Chọn");

        }
        catch
        {

        }
        return objTable;
    }
    #endregion

    #region method checkCode
    public bool checkCode(string CodeDanToc)
    {
        bool tmpValue = false;
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT * FROM TblDanToc WHERE CodeDanToc = @CodeDanToc";
            Cmd.Parameters.Add("CodeDanToc", SqlDbType.NVarChar).Value = CodeDanToc;
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
    public void delData(int IDDanToc)
    {
        try
        {
            string sqlQuery = "";
            sqlQuery = "DELETE TblDanToc WHERE IDDanToc = @IDDanToc ";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("IDDanToc", SqlDbType.Int).Value = IDDanToc;
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