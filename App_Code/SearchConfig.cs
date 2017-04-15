using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class SearchConfig
{
    #region method SearchConfig
    public SearchConfig()
    {
    } 
    #endregion

    #region method setData
    public int setData(string UserName, string TableName, string ColumnName, string CurrentValue)
    {
        int tmpValue = 0;
        try
        {
            string sqlQuery = "IF NOT EXISTS (SELECT * FROM tblSearchConfig WHERE UserName = @UserName AND TableName = @TableName) ";
            sqlQuery += "BEGIN INSERT INTO tblSearchConfig(UserName,TableName,ColumnName,CurrentValue) VALUES(@UserName,@TableName,@ColumnName,@CurrentValue) END ";
            sqlQuery += "ELSE BEGIN UPDATE tblSearchConfig SET ColumnName = @ColumnName, CurrentValue = @CurrentValue WHERE UserName = @UserName AND TableName = @TableName END";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("UserName", SqlDbType.NVarChar).Value = UserName;
            Cmd.Parameters.Add("TableName", SqlDbType.NVarChar).Value = TableName;
            Cmd.Parameters.Add("ColumnName", SqlDbType.NVarChar).Value = ColumnName;
             Cmd.Parameters.Add("CurrentValue", SqlDbType.NVarChar).Value = CurrentValue;
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
    public string getData(string UserName, string TableName, string ColumnName)
    {
        string tmpValue = "";
        try
        {
            string sqlQuery = "SELECT CurrentValue FROM tblSearchConfig WHERE UserName = @UserName AND TableName = @TableName AND ColumnName = @ColumnName";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("UserName", SqlDbType.NVarChar).Value = UserName;
            Cmd.Parameters.Add("TableName", SqlDbType.NVarChar).Value = TableName;
            Cmd.Parameters.Add("ColumnName", SqlDbType.NVarChar).Value = ColumnName;
            SqlDataReader Rd = Cmd.ExecuteReader();
            while(Rd.Read())
            {
                tmpValue = Rd["CurrentValue"].ToString();
            }
            Rd.Close();
            sqlCon.Close();
            sqlCon.Dispose();
        }
        catch
        {
            tmpValue = "";
        }
        return tmpValue;
    }
    #endregion
}