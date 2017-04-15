using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;

public class TrinhDoChuyenMon
{
	#region method TrinhDoChuyenMon
    public TrinhDoChuyenMon()
    {
    } 
    #endregion

    #region method setData
    public int setData(int IDTrinhDoChuyenMon, string CodeTrinhDoChuyenmon, string NameTrinhDoChuyenmon, string Note, bool State)
    {
        int tmpValue = 0;
        try
        {
            string sqlQuery = "";
            sqlQuery = "IF NOT EXISTS (SELECT * FROM TblTrinhDoChuyenMon WHERE IDTrinhDoChuyenMon = @IDTrinhDoChuyenMon) ";
            sqlQuery += "BEGIN INSERT INTO TblTrinhDoChuyenMon(CodeTrinhDoChuyenmon,NameTrinhDoChuyenmon,Note,State) VALUES(@CodeTrinhDoChuyenmon,@NameTrinhDoChuyenmon,@Note,@State) END ";
            sqlQuery += "ELSE BEGIN UPDATE TblTrinhDoChuyenMon SET CodeTrinhDoChuyenmon = @CodeTrinhDoChuyenmon, NameTrinhDoChuyenmon = @NameTrinhDoChuyenmon, Note = @Note, State = @State WHERE IDTrinhDoChuyenMon = @IDTrinhDoChuyenMon END";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("IDTrinhDoChuyenMon", SqlDbType.Int).Value = IDTrinhDoChuyenMon;
            Cmd.Parameters.Add("CodeTrinhDoChuyenmon", SqlDbType.NVarChar).Value = CodeTrinhDoChuyenmon;
            Cmd.Parameters.Add("NameTrinhDoChuyenmon", SqlDbType.NVarChar).Value = NameTrinhDoChuyenmon;
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
            sqlQuery += " AND UPPER(RTRIM(LTRIM(NameTrinhdoChuyenMon))) LIKE N'%'+UPPER(RTRIM(LTRIM(@SearchKey)))+'%'";
        }
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.Parameters.Add("SearchKey", SqlDbType.NVarChar).Value = searchKey;
            Cmd.CommandText = "SELECT 0 AS TT, *, REPLACE(REPLACE(CAST(State AS varchar),'1',N'Kích hoạt'),'0',N'Đóng') AS StateName FROM TblTrinhDoChuyenMon WHERE 1 = 1 " + sqlQuery;
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
    public DataTable getDataById(int IDTrinhDoChuyenMon)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.Parameters.Add("IDTrinhDoChuyenMon", SqlDbType.Int).Value = IDTrinhDoChuyenMon;
            Cmd.CommandText = "SELECT * FROM TblTrinhDoChuyenMon WHERE IDTrinhDoChuyenMon = @IDTrinhDoChuyenMon";
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
            Cmd.CommandText = "SELECT IDTrinhDoChuyenMon, NameTrinhDoChuyenMon FROM TblTrinhDoChuyenMon";
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
    public bool checkCode(string CodeTrinhDoChuyenMon)
    {
        bool tmpValue = false;
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT * FROM TblTrinhDoChuyenMon WHERE CodeTrinhDoChuyenMon = @CodeTrinhDoChuyenMon";
            Cmd.Parameters.Add("CodeTrinhDoChuyenMon", SqlDbType.NVarChar).Value = CodeTrinhDoChuyenMon;
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
    public void delData(int IDTrinhDoChuyenMon)
    {
        try
        {
            string sqlQuery = "";
            sqlQuery = "DELETE TblTrinhDoChuyenMon WHERE IDTrinhDoChuyenMon = @IDTrinhDoChuyenMon ";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("IDTrinhDoChuyenMon", SqlDbType.Int).Value = IDTrinhDoChuyenMon;
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