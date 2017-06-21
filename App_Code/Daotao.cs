using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Daotao
/// </summary>
public class Daotao:DataAbstract
{
    #region Even Daotao
	public Daotao()
	{
        keyTable = "IDNldDaoTao";
        nameTable = "TblNldDaoTao";
	}
    #endregion

    #region setData Atribute
    protected override SqlDbType? GetTypeAtribute(string name)
    {
        switch (name)
        {
            case "IDNldDaoTao":
            case "IDNldTuVan":
            case "IDNguoiLaoDong":
            case "IDDTMonHoc":
            case "IDDTNganhNghe":
            case "IdDtKhoaHoc":
            case "IDDonVi":
            case "State":
                return SqlDbType.Int;
            case "ThoiGian":
            case "KhoaHoc":
            case "DiaChiHoc":
            case "DTLienHe":
            case "TruongHoc":
                return SqlDbType.NVarChar;
            case "MucHoTro":
                return SqlDbType.Float;
            case "NgayBatDau":
            case "NgayKetThuc":
            case "SoQDHTN":
            case "SoQDHN":
                return SqlDbType.DateTime;
            
        }

        return null;
    }
    #endregion

    #region Method getList()
    public DataTable getList()
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "SELECT P.IDNldDaoTao,L.HoVaTen,L.BHXH,M.NameDTMonHoc,K.NameKhoaHoc,K.ThoiGianHoc,P.NgayBatDau FROM TblNldDaoTao AS P";
            Cmd.CommandText += " INNER JOIN TblNguoiLaoDong AS L ON P.IDNguoiLaoDong = L.IDNguoiLaoDong";
            Cmd.CommandText += " LEFT JOIN TblDTMonHoc AS M ON P.IDDTMonHoc = M.IDDTMonHoc";
            Cmd.CommandText += " LEFT JOIN TblDtKhoaHoc AS K ON P.IdDtKhoaHoc = K.IdDtKhoaHoc";

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

}