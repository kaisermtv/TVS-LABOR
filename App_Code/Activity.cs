using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;

public class Activity
{
    #region method Activity
    public Activity()
    {
    } 
    #endregion

    #region method setData
    public int setData(string ActivityContent, string UserName, string FullName)
    {
        int tmpValue = 0;
        try
        {
            string sqlQuery = "";
            sqlQuery += "INSERT INTO tblActivity(ActivityContent,UserName,FullName) VALUES(@ActivityContent,@UserName,@FullName)";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("ActivityContent", SqlDbType.NVarChar).Value = ActivityContent;
            Cmd.Parameters.Add("UserName", SqlDbType.NVarChar).Value = UserName;
            Cmd.Parameters.Add("FullName", SqlDbType.NVarChar).Value = FullName;
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
    public DataTable getData()
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT  *  FROM tblActivity";
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
}