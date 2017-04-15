using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TrinhDoTinHoc
/// </summary>
public class TrinhDoTinHoc : DataClass
{
    #region method getItem
    public DataRow getItem(int id)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "SELECT * FROM tblTrinhDoTinHoc WHERE ID = @ID";
            Cmd.Parameters.Add("ID", SqlDbType.Int).Value = id;

            DataRow ret = this.findFirst(Cmd);

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

    #region method getList
    public DataTable getList()
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "SELECT * FROM tblTrinhDoTinHoc";

            DataTable ret = this.findAll(Cmd);

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

    #region setData(int id, String name,bool state)
    public int setData(int id, String name,String note, bool state)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "IF NOT EXISTS (SELECT * FROM tblTrinhDoTinHoc WHERE ID = @ID)";
            Cmd.CommandText += "BEGIN INSERT INTO tblTrinhDoTinHoc(NameTrinhDo,Note,State) OUTPUT INSERTED.ID VALUES(@Name,@Note,@State) END ";
            Cmd.CommandText += "ELSE BEGIN UPDATE tblTrinhDoTinHoc SET [NameTrinhDo] = @Name,Note = @Note, [State] = @State OUTPUT INSERTED.ID WHERE ID = @ID END";
            Cmd.Parameters.Add("Id", SqlDbType.Int).Value = id;
            Cmd.Parameters.Add("Name", SqlDbType.NVarChar).Value = name;
            Cmd.Parameters.Add("Note", SqlDbType.NVarChar).Value = note;
            Cmd.Parameters.Add("State", SqlDbType.Bit).Value = state;

            int ret = (int)Cmd.ExecuteScalar();

            this.SQLClose();

            return ret;
        }
        catch (Exception ex)
        {
            this.Message = ex.Message;
            this.ErrorCode = ex.HResult;
            return 0;
        }

    }
    #endregion

    #region method delData
    public bool delData(int ID)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "DELETE tblTrinhDoTinHoc WHERE ID = @ID";
            Cmd.Parameters.Add("ID", SqlDbType.Int).Value = ID;

            Cmd.ExecuteNonQuery();

            this.SQLClose();

            return true;
        }
        catch (Exception ex)
        {
            this.Message = ex.Message;
            this.ErrorCode = ex.HResult;
            return false;
        }
    }
    #endregion

    #region method getDataCategoryToCombobox
    public DataTable getDataCategoryToCombobox(String kctxt = "Không chọn")
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();

            Cmd.CommandText = "SELECT ID, NameTrinhDo FROM tblTrinhDoTinHoc";

            DataTable ret = this.findAll(Cmd);

            this.SQLClose();

            if (kctxt != null && kctxt != "") ret.Rows.Add(0, kctxt);

            return ret;
        }
        catch
        {
            return new DataTable();
        }
    }
    #endregion
}