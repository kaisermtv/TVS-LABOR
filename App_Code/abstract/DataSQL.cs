using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DataSQL
/// </summary>
public class DataSQL
{
    #region declare
    private TableInfo tableInfo;

    #endregion

    #region Even DataSQL
    public DataSQL(string tableName, string ConnectKey = "TVSConn")
	{
        this.ConnectKey = ConnectKey;

        if (!ListTable.ContainsKey(tableName))
        {
            tableInfo = getTableInfo(tableName);
            try
            {
                ListTable.Add(tableName, tableInfo);
            }
            catch { }
        } else
        {
            tableInfo = (TableInfo)ListTable[tableName];
        }
	}
    #endregion

    #region
    private Hashtable DataCollections = new Hashtable();

    #region declare this
    public object this[string index]
    {
        get
        {
            try
            {
                return DataCollections[index];
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        set
        {
            if(!tableInfo.ListColums.ContainsKey(index))
            {
                throw new IndexOutOfRangeException("Cột '" + index + "' không tồn tại!");
            }

            DataCollections[index] = value;
        }
    }
    #endregion

    #region Method setData
    public object setData()
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();

            String sql = "";
            if (tableInfo.PrimaryKey != "")
            {
                if (DataCollections.ContainsKey(tableInfo.PrimaryKey))
                {
                    foreach (DictionaryEntry s in DataCollections)
                    {
                        string key = s.Key.ToString();
                        if (key == tableInfo.PrimaryKey) continue;

                        if (sql == "")
                        {
                            sql += "UPDATE " + tableInfo.TableName + " SET " + key + " = @" + key;
                        }
                        else
                        {
                            sql += "," + key + " = @" + key;
                        }

                        Cmd.Parameters.Add(key, ((ColumInfo)tableInfo.ListColums[key]).SqlType).Value = (s.Value != null) ? s.Value : DBNull.Value;
                    }

                    sql += " OUTPUT INSERTED." + tableInfo.PrimaryKey + " WHERE " + tableInfo.PrimaryKey + " = @" + tableInfo.PrimaryKey;
                    Cmd.Parameters.Add(tableInfo.PrimaryKey, ((ColumInfo)tableInfo.ListColums[tableInfo.PrimaryKey]).SqlType).Value = DataCollections[tableInfo.PrimaryKey];

                    Cmd.CommandText = sql;
                }
                else
                {
                    string sqlvl = "";
                    foreach (DictionaryEntry s in DataCollections)
                    {
                        string key = s.Key.ToString();
                        if (key == tableInfo.PrimaryKey) continue;

                        if (sql == "")
                        {
                            sql += "INSERT INTO " + tableInfo.TableName + "(" + key;
                            sqlvl += ") OUTPUT INSERTED." + tableInfo.PrimaryKey + " VALUES(@" + key;
                        }
                        else
                        {
                            sql += "," + key;
                            sqlvl += ",@" + key;
                        }

                        Cmd.Parameters.Add(key, ((ColumInfo)tableInfo.ListColums[key]).SqlType).Value = (s.Value != null) ? s.Value : DBNull.Value;
                    }

                    Cmd.CommandText = sql + sqlvl + ")";
                }
            }
            else
            {
                string sqlvl = "";
                foreach (DictionaryEntry s in DataCollections)
                {
                    string key = s.Key.ToString();
                    if (key == tableInfo.PrimaryKey) continue;

                    if (sql == "")
                    {
                        sql += "INSERT INTO " + tableInfo.TableName + "(" + key;
                        sqlvl += ") OUTPUT TRUE VALUES(@" + key;
                    }
                    else
                    {
                        sql += "," + key;
                        sqlvl += ",@" + key;
                    }

                    Cmd.Parameters.Add(key, ((ColumInfo)tableInfo.ListColums[key]).SqlType).Value = (s.Value != null) ? s.Value : DBNull.Value;
                }

                Cmd.CommandText = sql + sqlvl + ")";
            }

            //this.Message = Cmd.CommandText;
            object ret = Cmd.ExecuteScalar();

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

    #endregion

    #region Method GetItem
    public DataRow GetItem(int id)
    {
        if (tableInfo.PrimaryKey == null || tableInfo.PrimaryKey == "")
        {
            throw new Exception("Bảng không có khóa chính");
        }

        if (((ColumInfo)tableInfo.ListColums[tableInfo.PrimaryKey]).ColumType != "int")
        {
            throw new Exception("Kiểu dữ liệu khóa chính không đúng");
        }


        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "SELECT * FROM " + tableInfo.TableName + " WHERE " + tableInfo.PrimaryKey + " = @" + tableInfo.PrimaryKey;
            Cmd.Parameters.Add(tableInfo.PrimaryKey, SqlDbType.Int).Value = id;

            DataRow ret = this.findFirst(Cmd);

            this.SQLClose();
            return ret;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataRow GetItem(string id)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "SELECT * FROM " + tableInfo.TableName + " WHERE " + tableInfo.PrimaryKey + " = @" + tableInfo.PrimaryKey;
            Cmd.Parameters.Add(tableInfo.PrimaryKey, ((ColumInfo)tableInfo.ListColums[tableInfo.PrimaryKey]).SqlType).Value = id;

            DataRow ret = this.findFirst(Cmd);

            this.SQLClose();
            return ret;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion

    #region Method GetList
    public DataTable GetList()
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "SELECT * FROM " + tableInfo.TableName;

            DataTable ret = this.findAll(Cmd);

            this.SQLClose();
            return ret;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion


    #region get table info
    private static Hashtable ListTable = new Hashtable();

    #region class ColumInfo
    private class ColumInfo
    {
        public bool isPrimaryKy = false;

        public string ColumName;
        public string ColumType;
        public int ColumLeng;

        public string ColumDefault;

        private SqlDbType? _type = null;
        public SqlDbType SqlType
        {
            get
            {
                if (_type == null)
                {
                    switch (ColumType)
                    {
                        case "int":
                            _type = SqlDbType.Int;
                            break;
                        case "nvarchar":
                            _type = SqlDbType.NVarChar;
                            break;
                        case "varchar":
                            _type = SqlDbType.VarChar;
                            break;
                        case "ntext":
                            _type = SqlDbType.NText;
                            break;
                        case "bit":
                            _type = SqlDbType.Bit;
                            break;
                        case "datetime":
                            _type = SqlDbType.DateTime;
                            break;
                        case "float":
                            _type = SqlDbType.Float;
                            break;
                        case "decimal":
                            _type = SqlDbType.Decimal;
                            break;
                        case "nchar":
                            _type = SqlDbType.NChar;
                            break;
                        case "char":
                            _type = SqlDbType.Char;
                            break;
                        default:
                            throw new Exception("Khai báo thiếu trường SqlDbType");
                    }
                }
                return (SqlDbType)_type;
            }
        }
    }
    #endregion

    #region class TableInfo
    private class TableInfo
    {

        public string TableName;
        public string PrimaryKey;

        public Hashtable ListColums = new Hashtable();
        public bool isNull;

    }
    #endregion

    #region Method getTableInfo
    private TableInfo getTableInfo(string tableName)
    {
        TableInfo tableInfo = new TableInfo();
        tableInfo.TableName = tableName;

        try
        {
            SqlCommand Cmd = this.getSQLConnect();

            Cmd.CommandText = "SELECT COLUMN_NAME,COLUMN_DEFAULT,IS_NULLABLE,DATA_TYPE,CHARACTER_MAXIMUM_LENGTH FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = @TABLE_NAME ";
            Cmd.Parameters.Add("TABLE_NAME", SqlDbType.NVarChar).Value = tableName;

            DataTable objTable = findAll(Cmd);

            SQLClose();

            foreach (DataRow objRow in objTable.Rows)
            {
                ColumInfo objColum = new ColumInfo();

                objColum.ColumName = objRow["COLUMN_NAME"].ToString();
                objColum.ColumType = objRow["DATA_TYPE"].ToString().ToLower();

                objColum.ColumDefault = objRow["COLUMN_DEFAULT"].ToString();

                try
                {
                    objColum.ColumLeng = (int)objRow["CHARACTER_MAXIMUM_LENGTH"];
                }
                catch { }

                tableInfo.ListColums.Add(objColum.ColumName, objColum);
            }


            Cmd = this.getSQLConnect();
            Cmd.CommandText = "SELECT TOP 1 COLUMN_NAME FROM INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE WHERE TABLE_NAME = @TABLE_NAME AND CONSTRAINT_NAME LIKE 'PK%' ";
            Cmd.Parameters.Add("TABLE_NAME", SqlDbType.NVarChar).Value = tableName;

            try
            {
                tableInfo.PrimaryKey = Cmd.ExecuteScalar().ToString();

                ((ColumInfo)tableInfo.ListColums[tableInfo.PrimaryKey]).isPrimaryKy = true;
            }
            catch { }
            

            SQLClose();
        }
        catch (Exception ex)
        {
            throw ex;
        }


        return tableInfo;
    }
    #endregion

    #endregion

    #region method SQLConnect

    #region declare value
    protected SqlConnection sqlCon;

    public String Message = "";
    public int ErrorCode = 0;
    #endregion

    #region method getSQLConnect

    //public string ConnectString = "TVSConnect";
    public string ConnectKey = "TVSConn";

    protected SqlCommand getSQLConnect()
    {
        try
        {
            if (this.sqlCon == null)
            {
                this.sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[ConnectKey].ConnectionString);
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
    #endregion

    #region method SQLClose
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
    #endregion

    #region method findFirst
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
    #endregion

    #region method findAll
    protected DataTable findAll(SqlCommand Cmd)
    {
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = Cmd;
        DataSet ds = new DataSet();
        da.Fill(ds);

        return ds.Tables[0];
    }
    #endregion

    #endregion
}