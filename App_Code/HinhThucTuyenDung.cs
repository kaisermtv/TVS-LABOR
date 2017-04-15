using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;

public class HinhThucTuyenDung
{
	#region method HinhThucTuyenDung
    public HinhThucTuyenDung()
    {
    } 
    #endregion

    #region method setData
    public int setData(int IDHinhThucTuyenDung, string CodeHinhThucTuyenDung, string NameHinhThucTuyenDung, string Note, bool State)
    {
        int tmpValue = 0;
        try
        {
            string sqlQuery = "";
            sqlQuery = "IF NOT EXISTS (SELECT * FROM TblHinhThucTuyenDung WHERE IDHinhThucTuyenDung = @IDHinhThucTuyenDung) ";
            sqlQuery += "BEGIN INSERT INTO TblHinhThucTuyenDung(CodeHinhThucTuyenDung,NameHinhThucTuyenDung,Note,State) VALUES(@CodeHinhThucTuyenDung,@NameHinhThucTuyenDung,@Note,@State) END ";
            sqlQuery += "ELSE BEGIN UPDATE TblHinhThucTuyenDung SET CodeHinhThucTuyenDung = @CodeHinhThucTuyenDung, NameHinhThucTuyenDung = @NameHinhThucTuyenDung, Note = @Note, State = @State WHERE IDHinhThucTuyenDung = @IDHinhThucTuyenDung END";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("IDHinhThucTuyenDung", SqlDbType.Int).Value = IDHinhThucTuyenDung;
            Cmd.Parameters.Add("CodeHinhThucTuyenDung", SqlDbType.NVarChar).Value = CodeHinhThucTuyenDung;
            Cmd.Parameters.Add("NameHinhThucTuyenDung", SqlDbType.NVarChar).Value = NameHinhThucTuyenDung;
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
            sqlQuery += " AND UPPER(RTRIM(LTRIM(NameHinhThucTuyenDung))) LIKE N'%'+UPPER(RTRIM(LTRIM(@SearchKey)))+'%'";
        }
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.Parameters.Add("SearchKey", SqlDbType.NVarChar).Value = searchKey;
            Cmd.CommandText = "SELECT 0 AS TT, *, REPLACE(REPLACE(CAST(State AS varchar),'1',N'Kích hoạt'),'0',N'Đóng') AS StateName FROM TblHinhThucTuyenDung WHERE 1 = 1 " + sqlQuery;
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
    public DataTable getDataById(int IDHinhThucTuyenDung)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.Parameters.Add("IDHinhThucTuyenDung", SqlDbType.Int).Value = IDHinhThucTuyenDung;
            Cmd.CommandText = "SELECT * FROM TblHinhThucTuyenDung WHERE IDHinhThucTuyenDung = @IDHinhThucTuyenDung";
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
            Cmd.CommandText = "SELECT IDHinhThucTuyenDung, NameHinhThucTuyenDung FROM TblHinhThucTuyenDung";
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
    public bool checkCode(string CodeHinhThucTuyenDung)
    {
        bool tmpValue = false;
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT * FROM TblHinhThucTuyenDung WHERE CodeHinhThucTuyenDung = @CodeHinhThucTuyenDung";
            Cmd.Parameters.Add("CodeHinhThucTuyenDung", SqlDbType.NVarChar).Value = CodeHinhThucTuyenDung;
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
    public void delData(int IDHinhThucTuyenDung)
    {
        try
        {
            string sqlQuery = "";
            sqlQuery = "DELETE TblHinhThucTuyenDung WHERE IDHinhThucTuyenDung = @IDHinhThucTuyenDung ";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("IDHinhThucTuyenDung", SqlDbType.Int).Value = IDHinhThucTuyenDung;
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