using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for NLDTroCapThatNghiep
/// </summary>
public class NLDTroCapThatNghiep :DataClass
{
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

    #region setData()
    public int setDataByNLD(int IDNguoiLaoDong, DateTime? NgayNghiViec, float SoThangBHTN, bool NhuCauTuVan, bool NhuCauGTVL, bool NhuCauHocNghe, DateTime? NgayDangKyTN, bool DangKyTre, int DangKyTreLyDo, int NoiTiepNhan, DateTime? NgayHoanThien, int NoiNhanBaoHiem, int HinhThucNhanTien, int NoiChotSoCuoi, bool DaXacNhanChuaDangKy, int NoiXacNhanChuaDangKy)
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "IF NOT EXISTS (SELECT * FROM TblNLDTroCapThatNghiep WHERE IDNguoiLaoDong = @IDNguoiLaoDong)";
            Cmd.CommandText += "BEGIN INSERT INTO TblNLDTroCapThatNghiep(IDNguoiLaoDong,NgayNghiViec,SoThangBHTN,NhuCauTuVan,NhuCauGTVL,NhuCauHocNghe,NgayDangKyTN,DangKyTre,DangKyTreLyDo,NoiTiepNhan,NgayHoanThien,NoiNhanBaoHiem,HinhThucNhanTien,NoiChotSoCuoi,DaXacNhanChuaDangKy,NoiXacNhanChuaDangKy) OUTPUT INSERTED.IdNLDTCTN VALUES(@IDNguoiLaoDong,@NgayNghiViec,@SoThangBHTN,@NhuCauTuVan,@NhuCauGTVL,@NhuCauHocNghe,@NgayDangKyTN,@DangKyTre,@DangKyTreLyDo,@NoiTiepNhan,@NgayHoanThien,@NoiNhanBaoHiem,@HinhThucNhanTien,@NoiChotSoCuoi,@DaXacNhanChuaDangKy,@NoiXacNhanChuaDangKy) END ";
            Cmd.CommandText += "ELSE BEGIN UPDATE TblNLDTroCapThatNghiep SET NgayNghiViec = @NgayNghiViec,SoThangBHTN = @SoThangBHTN,NhuCauTuVan = @NhuCauTuVan,NhuCauGTVL = @NhuCauGTVL,NhuCauHocNghe = @NhuCauHocNghe,NgayDangKyTN = @NgayDangKyTN,DangKyTre = @DangKyTre,DangKyTreLyDo = @DangKyTreLyDo,NoiTiepNhan = @NoiTiepNhan,NgayHoanThien = @NgayHoanThien,NoiNhanBaoHiem = @NoiNhanBaoHiem,HinhThucNhanTien = @HinhThucNhanTien,NoiChotSoCuoi = @NoiChotSoCuoi,DaXacNhanChuaDangKy = @DaXacNhanChuaDangKy,NoiXacNhanChuaDangKy = @NoiXacNhanChuaDangKy OUTPUT INSERTED.IdNLDTCTN WHERE IDNguoiLaoDong = @IDNguoiLaoDong END";

            Cmd.Parameters.Add("IDNguoiLaoDong", SqlDbType.Int).Value = IDNguoiLaoDong;
            if (NgayNghiViec != null)
            {
                Cmd.Parameters.Add("NgayNghiViec", SqlDbType.DateTime).Value = NgayNghiViec;
            }
            else
            {
                Cmd.Parameters.Add("NgayNghiViec", SqlDbType.DateTime).Value = DBNull.Value;
            }
            //Cmd.Parameters.Add("NgayNghiViec", SqlDbType.DateTime).Value = NgayNghiViec;
            Cmd.Parameters.Add("SoThangBHTN", SqlDbType.Float).Value = SoThangBHTN;
            Cmd.Parameters.Add("NhuCauTuVan", SqlDbType.Bit).Value = NhuCauTuVan;
            Cmd.Parameters.Add("NhuCauGTVL", SqlDbType.Bit).Value = NhuCauGTVL;
            Cmd.Parameters.Add("NhuCauHocNghe", SqlDbType.Bit).Value = NhuCauHocNghe;
            if (NgayDangKyTN != null)
            {
                Cmd.Parameters.Add("NgayDangKyTN", SqlDbType.DateTime).Value = NgayDangKyTN;
            }
            else
            {
                Cmd.Parameters.Add("NgayDangKyTN", SqlDbType.DateTime).Value = DBNull.Value;
            }
            //Cmd.Parameters.Add("NgayDangKyTN", SqlDbType.DateTime).Value = NgayDangKyTN;
            Cmd.Parameters.Add("DangKyTre", SqlDbType.Bit).Value = DangKyTre;
            Cmd.Parameters.Add("DangKyTreLyDo", SqlDbType.Int).Value = DangKyTreLyDo;
            Cmd.Parameters.Add("NoiTiepNhan", SqlDbType.Int).Value = NoiTiepNhan;
            if (NgayHoanThien != null)
            {
                Cmd.Parameters.Add("NgayHoanThien", SqlDbType.DateTime).Value = NgayHoanThien;
            }
            else
            {
                Cmd.Parameters.Add("NgayHoanThien", SqlDbType.DateTime).Value = DBNull.Value;
            }
            //Cmd.Parameters.Add("NgayHoanThien", SqlDbType.DateTime).Value = NgayHoanThien;
            Cmd.Parameters.Add("NoiNhanBaoHiem", SqlDbType.Int).Value = NoiNhanBaoHiem;
            Cmd.Parameters.Add("HinhThucNhanTien", SqlDbType.Int).Value = HinhThucNhanTien;
            Cmd.Parameters.Add("NoiChotSoCuoi", SqlDbType.Int).Value = NoiChotSoCuoi;
            Cmd.Parameters.Add("DaXacNhanChuaDangKy", SqlDbType.Bit).Value = DaXacNhanChuaDangKy;
            Cmd.Parameters.Add("NoiXacNhanChuaDangKy", SqlDbType.Int).Value = NoiXacNhanChuaDangKy;

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