using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;

public class Ward :DataClass
{
	#region method Ward
    public Ward()
    {
    } 
    #endregion

    #region method setData
    public int setData(int Id, string Code, string Name, int ProvincerId, int DistrictId, bool State)
    {
        int tmpValue = 0;
        try
        {
            string sqlQuery = "";
            sqlQuery = "IF NOT EXISTS (SELECT * FROM tblWard WHERE Code = @Code) ";
            sqlQuery += "BEGIN INSERT INTO tblWard(Code,Name,ProvincerId, DistrictId, State) VALUES(@Code,@Name,@ProvincerId, @DistrictId, @State) END ";
            sqlQuery += "ELSE BEGIN UPDATE tblWard SET Code = @Code, Name = @Name, ProvincerId = @ProvincerId, DistrictId = @DistrictId, State = @State WHERE Id = @Id END";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("Id", SqlDbType.Int).Value = Id;
            Cmd.Parameters.Add("Code", SqlDbType.NVarChar).Value = Code;
            Cmd.Parameters.Add("Name", SqlDbType.NVarChar).Value = Name;
            Cmd.Parameters.Add("ProvincerId", SqlDbType.Int).Value = ProvincerId;
            Cmd.Parameters.Add("DistrictId", SqlDbType.Int).Value = DistrictId;
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
    public DataTable getData(int ProvincerId, int DistrictId, string searchKey)
    {
        string sqlQuery = "", sqlQueryProvincer = "", sqlQueryDistrict = "";
        if (searchKey.Trim() != "")
        {
            sqlQuery += " AND UPPER(RTRIM(LTRIM(Name))) LIKE N'%'+UPPER(RTRIM(LTRIM(@SearchKey)))+'%'";
        }
        if (ProvincerId > 0)
        {
            sqlQueryProvincer = " AND ProvincerId = @ProvincerId";
        }
        if (DistrictId > 0)
        {
            sqlQueryDistrict = " AND DistrictId = @DistrictId";
        }
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.Parameters.Add("SearchKey", SqlDbType.NVarChar).Value = searchKey;
            Cmd.CommandText = "SELECT 0 AS TT, *, REPLACE(REPLACE(CAST(State AS varchar),'1',N'Kích hoạt'),'0',N'Đóng') AS StateName, ISNULL((SELECT Name FROM tblProvincer WHERE Id = tblWard.ProvincerId),'') AS ProvincerName, ISNULL((SELECT Name FROM tblDistrict WHERE Id = tblWard.DistrictId),'') AS DistrictName FROM tblWard WHERE 1 = 1 " + sqlQueryProvincer + sqlQueryDistrict + sqlQuery;
            Cmd.Parameters.Add("ProvincerId", SqlDbType.Int).Value = ProvincerId;
            Cmd.Parameters.Add("DistrictId", SqlDbType.Int).Value = DistrictId;
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

    #region getNameById
    public String getNameById(int id)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "SELECT Name FROM tblWard WHERE Id = @Id";
            Cmd.Parameters.Add("Id", SqlDbType.Int).Value = id;

            String ret = (String)Cmd.ExecuteScalar();

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

    #region method getDataById
    public DataTable getDataById(int Id)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.Parameters.Add("Id", SqlDbType.Int).Value = Id;
            Cmd.CommandText = "SELECT * FROM tblWard WHERE Id = @Id";
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
    public DataTable getDataCategoryToCombobox(string ProvincerId, string DistrictId)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT Id, Name FROM tblWard WHERE ProvincerId = @ProvincerId AND DistrictId = @DistrictId";
            Cmd.Parameters.Add("ProvincerId", SqlDbType.Int).Value = ProvincerId;
            Cmd.Parameters.Add("DistrictId", SqlDbType.Int).Value = DistrictId;
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

    public DataTable getDataCategoryToCombobox(string DistrictId)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT Id, Name FROM tblWard WHERE DistrictId = @DistrictId";
            Cmd.Parameters.Add("DistrictId", SqlDbType.Int).Value = DistrictId;
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
    public bool checkCode(string Code)
    {
        bool tmpValue = false;
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT * FROM tblWard WHERE Code = @Code";
            Cmd.Parameters.Add("Code", SqlDbType.NVarChar).Value = Code;
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
    public void delData(int Id)
    {
        try
        {
            string sqlQuery = "";
            sqlQuery = "DELETE tblWard WHERE Id = @Id ";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("Id", SqlDbType.Int).Value = Id;
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