using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;

public class ThongBaoViecLamHangThang:DataClass
{
    #region Data Object
    public int IDThongBaoViecLam { get; set; }
    public int IDNLDTCTN { get; set; }
    public int IDCanBoTiepNhan { get; set; }
    public string ThangThongBao { get; set; }
    public DateTime NgayThongBao { get; set; }
    public string LoaiHinhThongBao { get; set; }
    public string LyDo { get; set; }
    public string BanTiepNhan { get; set; }
    #endregion 
    public int SetData()
    {
        int value = 0;
        string sql = "If Not Exists(Select * From TblThongBaoViecLamHangThang)";
        return value;
    }
}