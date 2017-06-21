using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for NLDTroCapThatNghiep
/// </summary>
public class NLDTroCapThatNghiep :DataAbstract
{
    #region method NLDTroCapThatNghiep
    public NLDTroCapThatNghiep()
    {
        keyTable = "IdNLDTCTN";
        nameTable = "TblNLDTroCapThatNghiep";
    }
    #endregion

    #region setData Atribute
    protected override SqlDbType? GetTypeAtribute(string name)
    {
        switch (name)
        {
            case "IdNLDTCTN":
            case "IDNguoiLaoDong":
            case "IdNguoiNhan":
            case "IdNoiNhan":
            case "IdLoaiHopDong":
            case "IdGiayTokemTheo":
            case "IdNoiNhanTCTN":
            case "IdNoiChotSoCuoi":
            case "IdHinhThucNhanTien":
            case "IdTrangThai":
            case "IdQuaTrinhCongTacGanNhat":
                return SqlDbType.Int;
            case "HoVaTen":
                return SqlDbType.NVarChar;
            case "NgayNopHoSo":
            case "NgayHoanThien":
            case "HanHoanThien":
            case "NgayNghiViec":
            case "EditDay":
            case "EditTrangThaiDate":
                return SqlDbType.DateTime;
            case "SoThangDongBHXH":
                return SqlDbType.Float;
            case "CongViecDaLam":
                return SqlDbType.NText;
            
        }

        return null;
    }
    #endregion


    #region method getItem
    public DataRow getItem(int id)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "SELECT * FROM [TblNLDTroCapThatNghiep] WHERE [IdNLDTCTN] = @IdNLDTCTN";
            Cmd.Parameters.Add("IdNLDTCTN", SqlDbType.Int).Value = id;

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


    #region Method CheckBHTN
    public int CheckBHTN(int IdNguoiLaoDong)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "SELECT IdNLDTCTN FROM TblNLDTroCapThatNghiep WHERE IDNguoiLaoDong = @IDNguoiLaoDong AND IdTrangThai != 10";
            Cmd.Parameters.Add("IDNguoiLaoDong", SqlDbType.Int).Value = IdNguoiLaoDong;

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

    #region addBHXH
    public int addBHXH(int IdNguoiLaoDong, int IDNldTuVan = 0)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "IF NOT EXISTS (SELECT * FROM TblNLDTroCapThatNghiep WHERE IDNguoiLaoDong = @IDNguoiLaoDong AND IdTrangThai != 10)";
            Cmd.CommandText += " BEGIN INSERT INTO TblNLDTroCapThatNghiep(IDNguoiLaoDong,IDNldTuVan) OUTPUT INSERTED.IdNLDTCTN VALUES (@IDNguoiLaoDong,@IDNldTuVan) END ";
            Cmd.CommandText += " ELSE BEGIN UPDATE TblNLDTroCapThatNghiep SET EditDay = GETDATE() OUTPUT INSERTED.IdNLDTCTN WHERE IDNguoiLaoDong = @IDNguoiLaoDong AND IdTrangThai != 6 END";
            Cmd.Parameters.Add("IDNguoiLaoDong", SqlDbType.Int).Value = IdNguoiLaoDong;
            Cmd.Parameters.Add("IDNldTuVan", SqlDbType.Int).Value = IDNldTuVan;

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