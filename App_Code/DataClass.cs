using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DataClass
/// </summary>
public class DataClass
{
    #region declare value
    protected SqlConnection sqlCon;

    public String Message = "";
    public int ErrorCode = 0;
    #endregion

    #region method SQLConnect
    protected SqlCommand getSQLConnect()
    {
        try
        {
            if (this.sqlCon == null)
            {
                this.sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
                sqlCon.Open();
            }
        }
        catch (Exception ex)
        {
            this.sqlCon = null;
            throw ex;
        }

        try
        {
            return this.sqlCon.CreateCommand();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void SQLClose()
    {
        if (this.sqlCon != null)
        {
            try
            {
                this.sqlCon.Close();
                this.sqlCon.Dispose();
                this.sqlCon = null;
            }
            catch (Exception ex)
            {
                this.sqlCon.Dispose();
                this.sqlCon = null;
                throw ex;
            }

        }
    }

    protected DataRow findFirst(SqlCommand Cmd)
    {
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = Cmd;
        DataSet ds = new DataSet();
        da.Fill(ds);

        if (ds.Tables[0].Rows.Count > 0)
        {
            return ds.Tables[0].Rows[0];
        }
        else
        {
            return null;
        }
    }

    protected DataTable findAll(SqlCommand Cmd)
    {
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = Cmd;
        DataSet ds = new DataSet();
        da.Fill(ds);

        return ds.Tables[0];

    }
    #endregion
}