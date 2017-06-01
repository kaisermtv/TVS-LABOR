using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DanhMuc
/// </summary>
public class DanhMuc : DataClass
{
    #region getNameById
    public String getNameById(int id,int danhmucid = 0)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "SELECT NameDanhMuc FROM tblDanhMuc WHERE IdDanhMuc = @ID";
            Cmd.Parameters.Add("ID", SqlDbType.Int).Value = id;

            if(danhmucid != 0)
            {
                Cmd.CommandText += " AND DanhMucId = @DanhMucId";
                Cmd.Parameters.Add("DanhMucId", SqlDbType.Int).Value = danhmucid;
            }

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

    #region method getItem
    public DataRow getItem(int id, int danhmucid = 0)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "SELECT * FROM tblDanhMuc WHERE IdDanhMuc = @ID";
            Cmd.Parameters.Add("ID", SqlDbType.Int).Value = id;

            if (danhmucid != 0)
            {
                Cmd.CommandText += " AND DanhMucId = @DanhMucId";
                Cmd.Parameters.Add("DanhMucId", SqlDbType.Int).Value = danhmucid;
            }

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
    public DataTable getList(int danhmucid = 0)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "SELECT * FROM tblDanhMuc";

            if (danhmucid != 0)
            {
                Cmd.CommandText += " WHERE DanhMucId = @DanhMucId";
                Cmd.Parameters.Add("DanhMucId", SqlDbType.Int).Value = danhmucid;
            }

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

    #region setData
    public int setData(int id, int danhmucid, String name, String note, bool state = true)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "IF NOT EXISTS (SELECT * FROM tblDanhMuc WHERE IdDanhMuc = @ID)";
            Cmd.CommandText += "BEGIN INSERT INTO tblDanhMuc(DanhMucId,NameDanhMuc,Note,State) OUTPUT INSERTED.IdDanhMuc VALUES(@DanhMucId,@Name,@Note,@State) END ";
            Cmd.CommandText += "ELSE BEGIN UPDATE tblDanhMuc SET [NameDanhMuc] = @Name,Note = @Note, [State] = @State OUTPUT INSERTED.IdDanhMuc WHERE IdDanhMuc = @ID AND DanhMucId = @DanhMucId END";
            Cmd.Parameters.Add("ID", SqlDbType.Int).Value = id;
            Cmd.Parameters.Add("DanhMucId", SqlDbType.Int).Value = danhmucid;
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
    public bool delData(int ID, int danhmucid = 0)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "DELETE tblDanhMuc WHERE DanhMucId = @ID";
            Cmd.Parameters.Add("ID", SqlDbType.Int).Value = ID;

            if (danhmucid != 0)
            {
                Cmd.CommandText += " AND DanhMucId = @DanhMucId";
                Cmd.Parameters.Add("DanhMucId", SqlDbType.Int).Value = danhmucid;
            }

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
    public DataTable getDataCategoryToCombobox(String kctxt = "Không chọn", int danhmucid = 0)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();

            Cmd.CommandText = "SELECT IdDanhMuc, NameDanhMuc FROM tblDanhMuc";

            if (danhmucid != 0)
            {
                Cmd.CommandText += " WHERE DanhMucId = @DanhMucId";
                Cmd.Parameters.Add("DanhMucId", SqlDbType.Int).Value = danhmucid;
            }

            DataTable ret = this.findAll(Cmd);

            this.SQLClose();

            if (kctxt != null && kctxt != "") ret.Rows.Add(0, kctxt);

            return ret;
        }
        catch(Exception ex)
        {
            this.Message = ex.Message;
            this.ErrorCode = ex.HResult;
            return new DataTable();
        }
    }
    #endregion

    #region Method getDanhMuc
    public DataRow getDanhMuc(int id)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "SELECT * FROM tblDanhMuc WHERE IdDanhMuc = @ID AND DanhMucId = 0";
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

    #region method getListDanhMuc
    public DataTable getListDanhMuc()
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "SELECT * FROM tblDanhMuc WHERE DanhMucId = 0";

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

    #region getIdByName
    public int getIdDanhMucByName(string name)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "SELECT TOP 1 IdDanhMuc FROM tblDanhMuc WHERE NameDanhMuc = @Name  AND DanhMucId = 0";
            Cmd.Parameters.Add("Name", SqlDbType.NVarChar).Value = name;

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
}