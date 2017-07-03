using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;

public class TrangThaiHoSo
{
    public DataTable GetByIds(string  Ids)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.Parameters.Add("ID", SqlDbType.NVarChar).Value = Ids;
            Cmd.CommandText = "SELECT * FROM TblTrangThaiHoSo WHERE ID In (Select distinct Item from dbo.Split(@ID))";
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

}