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

    #region setData
    public int setData(int IdNLDTCTN, int IDNguoiLaoDong, DateTime? NgayNopHoSo, int IdNguoiNhan, int idNoiNhan, int SoThangDongBH, int IdLoaiHopDong, int IdGiayTokemTheo, DateTime? HanHoanThien, int IdNoiNhanTCTN, int IdNoiChotSoCuoi, int IdHinhThucNhanTien, int IdQuaTrinhCongTacGanNhat)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "IF NOT EXISTS (SELECT * FROM TblNLDTroCapThatNghiep WHERE IdNLDTCTN = @IdNLDTCTN)";
            Cmd.CommandText += "BEGIN INSERT INTO TblNLDTroCapThatNghiep(IDNguoiLaoDong,NgayNopHoSo,IdNguoiNhan,IdNoiNhan,SoThangDongBHXH,IdLoaiHopDong,IdGiayTokemTheo,HanHoanThien,IdNoiNhanTCTN,IdNoiChotSoCuoi,IdHinhThucNhanTien,IdQuaTrinhCongTacGanNhat) OUTPUT INSERTED.IdNLDTCTN VALUES(@IDNguoiLaoDong,@NgayNopHoSo,@IdNguoiNhan,@IdNoiNhan,@SoThangDongBHXH,@IdLoaiHopDong,@IdGiayTokemTheo,@HanHoanThien,@IdNoiNhanTCTN,@IdNoiChotSoCuoi,@IdHinhThucNhanTien,@IdQuaTrinhCongTacGanNhat) END ";
            Cmd.CommandText += "ELSE BEGIN UPDATE TblNLDTroCapThatNghiep SET IDNguoiLaoDong = @IDNguoiLaoDong,NgayNopHoSo = @NgayNopHoSo,IdNguoiNhan = @IdNguoiNhan,IdNoiNhan = @IdNoiNhan,SoThangDongBHXH = @SoThangDongBHXH,IdLoaiHopDong = @IdLoaiHopDong,IdGiayTokemTheo = @IdGiayTokemTheo,HanHoanThien = @HanHoanThien,IdNoiNhanTCTN = @IdNoiNhanTCTN,IdNoiChotSoCuoi = @IdNoiChotSoCuoi,IdHinhThucNhanTien = @IdHinhThucNhanTien,IdQuaTrinhCongTacGanNhat = @IdQuaTrinhCongTacGanNhat OUTPUT INSERTED.IdNLDTCTN WHERE IdNLDTCTN = @IdNLDTCTN END";


            Cmd.Parameters.Add("IdNLDTCTN", SqlDbType.Int).Value = IdNLDTCTN;
            Cmd.Parameters.Add("IDNguoiLaoDong", SqlDbType.Int).Value = IDNguoiLaoDong;
            if (NgayNopHoSo != null)
            {
                Cmd.Parameters.Add("NgayNopHoSo", SqlDbType.DateTime).Value = NgayNopHoSo;
            }
            else
            {
                Cmd.Parameters.Add("NgayNopHoSo", SqlDbType.DateTime).Value = DBNull.Value;
            }

            Cmd.Parameters.Add("IdNguoiNhan", SqlDbType.Int).Value = IdNguoiNhan;
            Cmd.Parameters.Add("IdNoiNhan", SqlDbType.Int).Value = idNoiNhan;

            Cmd.Parameters.Add("SoThangDongBHXH", SqlDbType.Float).Value = SoThangDongBH;
            Cmd.Parameters.Add("IdLoaiHopDong", SqlDbType.Int).Value = IdLoaiHopDong;
            Cmd.Parameters.Add("IdGiayTokemTheo", SqlDbType.Int).Value = IdGiayTokemTheo;

            if (HanHoanThien != null)
            {
                Cmd.Parameters.Add("HanHoanThien", SqlDbType.DateTime).Value = HanHoanThien;
            }
            else
            {
                Cmd.Parameters.Add("HanHoanThien", SqlDbType.DateTime).Value = DBNull.Value;
            }

            Cmd.Parameters.Add("IdNoiNhanTCTN", SqlDbType.Int).Value = IdNoiNhanTCTN;
            Cmd.Parameters.Add("IdNoiChotSoCuoi", SqlDbType.Int).Value = IdNoiChotSoCuoi;
            Cmd.Parameters.Add("IdHinhThucNhanTien", SqlDbType.Int).Value = IdHinhThucNhanTien;
            Cmd.Parameters.Add("IdQuaTrinhCongTacGanNhat", SqlDbType.Int).Value = IdQuaTrinhCongTacGanNhat;
            

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
    // */
    #endregion

    #region addBHXH
    public int addBHXH(int IdNguoiLaoDong, int IDNldTuVan)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "IF NOT EXISTS (SELECT * FROM TblNLDTroCapThatNghiep WHERE IDNguoiLaoDong = @IDNguoiLaoDong AND IdTrangThai != 6)";
            Cmd.CommandText += " BEGIN INSERT INTO TblNLDTroCapThatNghiep(IDNguoiLaoDong,IDNldTuVan) OUTPUT INSERTED.IdNLDTCTN VALUES (@IDNguoiLaoDong,@IDNldTuVan) END ";
            Cmd.CommandText += " ELSE BEGIN SELECT IdNLDTCTN FROM TblNLDTroCapThatNghiep WHERE IDNguoiLaoDong = @IDNguoiLaoDong AND IdTrangThai != 6 END";
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