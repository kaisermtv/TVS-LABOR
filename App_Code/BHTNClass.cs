using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BHTNClass
/// </summary>
public class BHTNClass :DataClass
{
    #region Method getList
    public DataTable getListDangKY(int idtrangthai, string searchKey = "")
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "SELECT TN.[IdNLDTCTN],P.[HoVaTen],P.[CMND],P.[BHXH],TN.NgayNopHoSo,TN.NgayNghiViec,TN.SoThangDongBHXH,TT.name AS TrangThai,TN.IdTrangThai FROM TblNLDTroCapThatNghiep AS TN";
            Cmd.CommandText += " LEFT JOIN TblNguoiLaoDong AS P ON TN.IDNguoiLaoDong = P.IDNguoiLaoDong";
            Cmd.CommandText += " LEFT JOIN tblTrangThaiHoSo AS TT ON TN.IdTrangThai = TT.id";
            Cmd.CommandText += " WHERE 1=1";

            if (searchKey != "")
            {
                Cmd.CommandText += " AND UPPER(RTRIM(LTRIM(P.[HoVaTen]))) LIKE N'%'+UPPER(RTRIM(LTRIM(@SearchKey)))+'%'";
                Cmd.Parameters.Add("SearchKey", SqlDbType.NVarChar).Value = searchKey;
            }

            if (idtrangthai != 0)
            {
                Cmd.CommandText += " AND TN.IdTrangThai = @IDTrangThai";
                Cmd.Parameters.Add("IDTrangThai", SqlDbType.Int).Value = idtrangthai;
            }

            Cmd.CommandText += " ORDER BY TN.EditDay ASC";

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

    public void setBHXH(int IDNldTuVan, int IDNguoiLaoDong, bool ckbTuVanBHTN)
    {
        NLDTroCapThatNghiep objTroCapTN = new NLDTroCapThatNghiep();

        if (ckbTuVanBHTN)
        {
            int ret = objTroCapTN.addBHXH(IDNguoiLaoDong, IDNldTuVan);
        }
        else 
        { 
        
        }
    }
}