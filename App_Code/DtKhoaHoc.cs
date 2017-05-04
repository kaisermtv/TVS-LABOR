using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class DtKhoaHoc : DataClass
{
    #region getNameById
    public String getNameById(int id)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "SELECT NameKhoaHoc FROM TblDtKhoaHoc WHERE IdDtKhoaHoc = @ID";
            Cmd.Parameters.Add("ID", SqlDbType.Int).Value = id;

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
    public DataRow getItem(int id)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "SELECT *, ISNULL((SELECT TenDonVi FROM TblDoanhNghiep WHERE IDDonVi = A.IDDtDonvi),'') AS TenDonVi FROM TblDtKhoaHoc A WHERE A.IdDtKhoaHoc = @ID";
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
            Cmd.CommandText = "SELECT * FROM TblDtKhoaHoc";
            
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

    #region method getData
    public DataTable getData()
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "SELECT * FROM TblDtKhoaHoc WHERE ISNULL(State,0) = 1";
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
    public int setData(int id, String code, String NameKhoaHoc, String ThoiGianHoc, float MucHoTro, int IDDtDonvi, int LoaiKhoaHoc, bool state)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "IF NOT EXISTS (SELECT * FROM TblDtKhoaHoc WHERE IdDtKhoaHoc = @ID)";
            Cmd.CommandText += "BEGIN INSERT INTO TblDtKhoaHoc(CodeKhoaHoc,NameKhoaHoc,ThoiGianHoc,MucHoTro,IDDtDonvi,LoaiKhoaHoc,State) OUTPUT INSERTED.IdDtKhoaHoc VALUES(@CodeKhoaHoc,@NameKhoaHoc,@ThoiGianHoc,@MucHoTro,@IDDtDonvi,@LoaiKhoaHoc,@State) END ";
            Cmd.CommandText += "ELSE BEGIN UPDATE TblDtKhoaHoc SET CodeKhoaHoc = @CodeKhoaHoc,NameKhoaHoc = @NameKhoaHoc,ThoiGianHoc = @ThoiGianHoc,MucHoTro = @MucHoTro,IDDtDonvi = @IDDtDonvi,LoaiKhoaHoc = @LoaiKhoaHoc , [State] = @State OUTPUT INSERTED.IdDtKhoaHoc WHERE IdDtKhoaHoc = @ID END";
            Cmd.Parameters.Add("ID", SqlDbType.Int).Value = id;
            Cmd.Parameters.Add("CodeKhoaHoc", SqlDbType.NVarChar).Value = code;
            Cmd.Parameters.Add("NameKhoaHoc", SqlDbType.NVarChar).Value = NameKhoaHoc;
            Cmd.Parameters.Add("ThoiGianHoc", SqlDbType.NVarChar).Value = ThoiGianHoc;
            Cmd.Parameters.Add("MucHoTro", SqlDbType.Float).Value = MucHoTro;
            Cmd.Parameters.Add("IDDtDonvi", SqlDbType.Int).Value = IDDtDonvi;
            Cmd.Parameters.Add("LoaiKhoaHoc", SqlDbType.Int).Value = LoaiKhoaHoc;
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
            Cmd.CommandText = "DELETE TblDtKhoaHoc WHERE IdDtKhoaHoc = @ID";
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

            Cmd.CommandText = "SELECT IdDtKhoaHoc, NameKhoaHoc FROM TblDtKhoaHoc";

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