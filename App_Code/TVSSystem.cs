﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class TVSSystem
{
    #region method TVSSystem
    public TVSSystem()
    {
    } 
    #endregion

    #region method getCountOfObjects
    public int getCountOfObjects(string Table)
    {
        int tmpValue = 0;
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT COUNT(*) AS CountItem FROM "+Table;
            SqlDataAdapter da = new SqlDataAdapter();
            SqlDataReader Rd = Cmd.ExecuteReader();
            while(Rd.Read())
            {
                tmpValue = int.Parse(Rd["CountItem"].ToString());
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

    #region method CVDate()
    public static DateTime CVDate(String dt)
    {
        try
        {
            return new DateTime(int.Parse(dt.Substring(6, 4)), int.Parse(dt.Substring(3, 2)),int.Parse( dt.Substring(0, 2)));
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    #endregion

    #region method CVDateTime1()
    public static DateTime CVDateTime1(String dt)
    {
        try
        {
            return new DateTime(int.Parse(dt.Substring(6, 4)), int.Parse(dt.Substring(3, 2)), int.Parse(dt.Substring(0, 2)), 0,0,0);
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    #endregion

    #region method CVDateTime2()
    public static DateTime CVDateTime2(String dt)
    {
        try
        {
            return new DateTime(int.Parse(dt.Substring(6, 4)), int.Parse(dt.Substring(3, 2)), int.Parse(dt.Substring(0, 2)), 23,59, 59);
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    #endregion
}