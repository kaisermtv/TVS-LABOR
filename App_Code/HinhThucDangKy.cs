using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;

public class HinhThucDangKy
{
	#region method HinhThucDangKy
    public HinhThucDangKy()
    {
    } 
    #endregion

    #region method setData
    public int setData(int IDHinhThucDangKy, string CodeHinhThucDangKy, string NameHinhThucDangKy, string Note, bool State)
    {
        int tmpValue = 0;
        try
        {
            string sqlQuery = "";
            sqlQuery = "IF NOT EXISTS (SELECT * FROM TblHinhThucDangKy WHERE IDHinhThucDangKy = @IDHinhThucDangKy) ";
            sqlQuery += "BEGIN INSERT INTO TblHinhThucDangKy(CodeHinhThucDangKy,NameHinhThucDangKy,Note,State) VALUES(@CodeHinhThucDangKy,@NameHinhThucDangKy,@Note,@State) END ";
            sqlQuery += "ELSE BEGIN UPDATE TblHinhThucDangKy SET CodeHinhThucDangKy = @CodeHinhThucDangKy, NameHinhThucDangKy = @NameHinhThucDangKy, Note = @Note, State = @State WHERE IDHinhThucDangKy = @IDHinhThucDangKy END";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("IDHinhThucDangKy", SqlDbType.Int).Value = IDHinhThucDangKy;
            Cmd.Parameters.Add("CodeHinhThucDangKy", SqlDbType.NVarChar).Value = CodeHinhThucDangKy;
            Cmd.Parameters.Add("NameHinhThucDangKy", SqlDbType.NVarChar).Value = NameHinhThucDangKy;
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
            sqlQuery += " AND UPPER(RTRIM(LTRIM(NameHinhThucDangKy))) LIKE N'%'+UPPER(RTRIM(LTRIM(@SearchKey)))+'%'";
        }
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.Parameters.Add("SearchKey", SqlDbType.NVarChar).Value = searchKey;
            Cmd.CommandText = "SELECT 0 AS TT, *, REPLACE(REPLACE(CAST(State AS varchar),'1',N'Kích hoạt'),'0',N'Đóng') AS StateName FROM TblHinhThucDangKy WHERE 1 = 1 " + sqlQuery;
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
    public DataTable getDataById(int IDHinhThucDangKy)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.Parameters.Add("IDHinhThucDangKy", SqlDbType.Int).Value = IDHinhThucDangKy;
            Cmd.CommandText = "SELECT * FROM TblHinhThucDangKy WHERE IDHinhThucDangKy = @IDHinhThucDangKy";
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
            Cmd.CommandText = "SELECT IDHinhThucDangKy, NameHinhThucDangKy FROM TblHinhThucDangKy";
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
    public bool checkCode(string CodeHinhThucDangKy)
    {
        bool tmpValue = false;
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT * FROM TblHinhThucDangKy WHERE CodeHinhThucDangKy = @CodeHinhThucDangKy";
            Cmd.Parameters.Add("CodeHinhThucDangKy", SqlDbType.NVarChar).Value = CodeHinhThucDangKy;
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
    public void delData(int IDHinhThucDangKy)
    {
        try
        {
            string sqlQuery = "";
            sqlQuery = "DELETE TblHinhThucDangKy WHERE IDHinhThucDangKy = @IDHinhThucDangKy ";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("IDHinhThucDangKy", SqlDbType.Int).Value = IDHinhThucDangKy;
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