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
            case"NgayHenTraKQ":
                return SqlDbType.DateTime;
            case "SoThangDongBHXH":
                return SqlDbType.Float;
            case "CongViecDaLam":
                return SqlDbType.NText;
            
        }

        return null;
    }
    #endregion

    public int Insert(int IDNguoiLaoDong, DateTime NgayNopHoSo, int SoThangDongBHXH)
    {
        int value = 0;
        string sql = " Insert Into TblNLDTroCapThatNghiep (IDNguoiLaoDong,NgayNopHoSo,SoThangDongBHXH) Values (@IDNguoiLaoDong,@NgayNopHoSo,@SoThangDongBHXH)";
        sql += " Select Max(IDNLDTCTN) From TblNLDTroCapThatNghiep Where IDNguoiLaoDong=@IDNguoiLaoDong";
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
        sqlCon.Open();
        SqlCommand Cmd = sqlCon.CreateCommand();
        Cmd.CommandText = sql;
        Cmd.Parameters.Add("IDNguoiLaoDong", SqlDbType.Int).Value = IDNguoiLaoDong;
        Cmd.Parameters.Add("NgayNopHoSo", SqlDbType.DateTime).Value = NgayNopHoSo;
        Cmd.Parameters.Add("SoThangDongBHXH", SqlDbType.Int).Value = SoThangDongBHXH;
        value = (int)Cmd.ExecuteScalar();
        sqlCon.Close();
        sqlCon.Dispose();
        return value;    
    }

    public int Update(int IDNLDTCTN, int IDNguoiLaoDong, DateTime NgayNopHoSo, int SoThangDongBHXH)
    {
        int value = 0;
        string sql = " Update TblNLDTroCapThatNghiep Set IDNguoiLaoDong= @IDNguoiLaoDong,NgayNopHoSo=@NgayNopHoSo,SoThangDongBHXH=@SoThangDongBHXH)";
        sql += " Where IDNLDTCTN=@IDNLDTCTN";
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
        sqlCon.Open();
        SqlCommand Cmd = sqlCon.CreateCommand();
        Cmd.CommandText = sql;
        Cmd.Parameters.Add("IDNLDTCTN", SqlDbType.Int).Value = IDNLDTCTN;
        Cmd.Parameters.Add("IDNguoiLaoDong", SqlDbType.Int).Value = IDNguoiLaoDong;
        Cmd.Parameters.Add("NgayNopHoSo", SqlDbType.DateTime).Value = NgayNopHoSo;
        Cmd.Parameters.Add("SoThangDongBHXH", SqlDbType.Int).Value = SoThangDongBHXH;
        value = (int)Cmd.ExecuteScalar();
        sqlCon.Close();
        sqlCon.Dispose();
        return value;
    }
    public int UpdateKhongHuong(int IDNLDTCTN, DateTime NgayDeXuat, string LyDo)
    {
        int value = 0;
        string sql = " Update TblNLDTroCapThatNghiep Set NgayDeXuatKhongHuong=@NgayDeXuatKhongHuong, LyDoKhongHuong=@LyDoKhongHuong";
        sql += " Where IDNLDTCTN=@IDNLDTCTN";
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
        sqlCon.Open();
        SqlCommand Cmd = sqlCon.CreateCommand();
        Cmd.CommandText = sql;
        Cmd.Parameters.Add("IDNLDTCTN", SqlDbType.Int).Value = IDNLDTCTN;
        Cmd.Parameters.Add("NgayDeXuatKhongHuong", SqlDbType.DateTime).Value = NgayDeXuat;
        Cmd.Parameters.Add("LyDoKhongHuong", SqlDbType.NVarChar).Value = LyDo;
        value = Cmd.ExecuteNonQuery();
        sqlCon.Close();
        sqlCon.Dispose();
        return value;
    }
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