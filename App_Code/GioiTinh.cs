using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;

public class GioiTinh
{
    #region method GioiTinh
    public GioiTinh()
    {
    } 
    #endregion

    #region method getDataCategoryToCombobox
    public DataTable getDataCategoryToCombobox(String kc = "Không chọn")
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT IDGioiTinh, NameGioiTinh FROM TblGioiTinh";
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlCon.Close();
            sqlCon.Dispose();
            objTable = ds.Tables[0];

            if (kc != null && kc != "")
                objTable.Rows.Add(0, kc);
        }
        catch
        {

        }
        return objTable;
    }
    #endregion
}