using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;

public class TinhHuong:DataClass
{
    #region Data Object
    public int IDTinhHuong { get; set; }
    public int IDNguoiLaoDong { get; set; }
    public int IDNLDTCTN { get; set; }
    public DateTime NgayTao { get; set; }
    public int IDVungLuongToiThieu { get; set; }
    public decimal LuongToiThieuVung { get; set; }   
    public string ThangDong1 { get; set; }
    public float HeSoLuong1 { get; set; }
    public float HeSoPhuCap1 { get; set; }
    public decimal LuongCoBan1 { get; set; }
    public decimal MucDong1 { get; set; }
    public string ThangDong2 { get; set; }
    public float HeSoLuong2 { get; set; }
    public float HeSoPhuCap2 { get; set; }
    public decimal LuongCoBan2 { get; set; }
    public decimal MucDong2 { get; set; }
    public string ThangDong3 { get; set; }
    public float HeSoLuong3 { get; set; }
    public float HeSoPhuCap3 { get; set; }
    public decimal LuongCoBan3 { get; set; }
    public decimal MucDong3 { get; set; }
    public string ThangDong4 { get; set; }
    public float HeSoLuong4 { get; set; }
    public float HeSoPhuCap4 { get; set; }
    public decimal LuongCoBan4 { get; set; }
    public decimal MucDong4 { get; set; }
    public string ThangDong5 { get; set; }
    public float HeSoLuong5 { get; set; }
    public float HeSoPhuCap5 { get; set; }
    public decimal LuongCoBan5 { get; set; }
    public decimal MucDong5 { get; set; }
    public string ThangDong6 { get; set; }
    public float HeSoLuong6 { get; set; }
    public float HeSoPhuCap6 { get; set; }
    public decimal LuongCoBan6 { get; set; }
    public decimal MucDong6 { get; set; }
    public int SoThangDongBHXH { get; set; }
    public int SoThangHuongBHXH { get; set; }
    public decimal MucHuongToiDa { get; set; }
    public decimal LuongTrungBinh { get; set; }
    public decimal MucHuong { get; set; }
    public DateTime HuongTuNgay { get; set; }
    public int IDNguoiTinh { get; set; }
    #endregion 
    public TinhHuong()
    {
    } 
    #region method Setdata
    public int setData(int IDTinhHuong, int IDNguoiLaoDong, int IDNLDTCTN, DateTime NgayTao, int IDVungLuongToiThieu,decimal LuongToiThieuVung
        , string ThangDong1, float HeSoLuong1, float HeSoPhuCap1, decimal LuongCoBan1, decimal MucDong1
        , string ThangDong2, float HeSoLuong2, float HeSoPhuCap2, decimal LuongCoBan2, decimal MucDong2
        , string ThangDong3, float HeSoLuong3, float HeSoPhuCap3, decimal LuongCoBan3, decimal MucDong3
        , string ThangDong4, float HeSoLuong4, float HeSoPhuCap4, decimal LuongCoBan4, decimal MucDong4
        , string ThangDong5, float HeSoLuong5, float HeSoPhuCap5, decimal LuongCoBan5, decimal MucDong5
        , string ThangDong6, float HeSoLuong6, float HeSoPhuCap6, decimal LuongCoBan6, decimal MucDong6
        , int SoThangDongBHXH,int SoThangHuongBHXH, decimal MucHuongToiDa,decimal LuongTrungBinh,decimal MucHuong,DateTime HuongTuNgay,int IDNguoiTinh 
     )
    {
        int tmpValue = 0;
        try
        {
            string sqlQuery = "";
            sqlQuery = "IF NOT EXISTS (SELECT * FROM TblTinhHuong WHERE IDNguoiLaoDong= @IDNguoiLaoDong) ";
            sqlQuery += "BEGIN INSERT INTO TblTinhHuong(IDNguoiLaoDong,IDNLDTCTN,NgayTao,IDVungLuongToiThieu,LuongToiThieuVung";
            sqlQuery += ",ThangDong1,HeSoLuong1,HeSoPhuCap1,LuongCoBan1,MucDong1";
            sqlQuery += ",ThangDong2,HeSoLuong2,HeSoPhuCap2,LuongCoBan2,MucDong2";
            sqlQuery += ",ThangDong3,HeSoLuong3,HeSoPhuCap3,LuongCoBan3,MucDong3";
            sqlQuery += ",ThangDong4,HeSoLuong4,HeSoPhuCap4,LuongCoBan4,MucDong4";
            sqlQuery += ",ThangDong5,HeSoLuong5,HeSoPhuCap5,LuongCoBan5,MucDong5";
            sqlQuery += ",ThangDong6,HeSoLuong6,HeSoPhuCap6,LuongCoBan6,MucDong6";
            sqlQuery += ",SoThangDongBHXH,SoThangHuongBHXH,MucHuongToiDa,LuongTrungBinh,MucHuong,HuongTuNgay,IDNguoiTinh";
            sqlQuery += ")";
            sqlQuery += " VALUES(@IDNguoiLaoDong,@IDNLDTCTN,@NgayTao,@IDVungLuongToiThieu,@LuongToiThieuVung";
            sqlQuery += ",@ThangDong1,@HeSoLuong1,@HeSoPhuCap1,@LuongCoBan1,@MucDong1";
            sqlQuery += ",@ThangDong2,@HeSoLuong2,@HeSoPhuCap2,@LuongCoBan2,@MucDong2";
            sqlQuery += ",@ThangDong3,@HeSoLuong3,@HeSoPhuCap3,@LuongCoBan3,@MucDong3";
            sqlQuery += ",@ThangDong4,@HeSoLuong4,@HeSoPhuCap4,@LuongCoBan4,@MucDong4";
            sqlQuery += ",@ThangDong5,@HeSoLuong5,@HeSoPhuCap5,@LuongCoBan5,@MucDong5";
            sqlQuery += ",@ThangDong6,@HeSoLuong6,@HeSoPhuCap6,@LuongCoBan6,@MucDong6";
            sqlQuery += ",@SoThangDongBHXH,@SoThangHuongBHXH,@MucHuongToiDa,@LuongTrungBinh,@MucHuong,@HuongTuNgay,@IDNguoiTinh";
            sqlQuery += ") END ";
            sqlQuery += "ELSE BEGIN UPDATE TblTinhHuong SET NgayTao=@NgayTao,IDVungLuongToiThieu=@IDVungLuongToiThieu,LuongToiThieuVung=@LuongToiThieuVung";
            sqlQuery += ",ThangDong1=@ThangDong1,HeSoLuong1=@HeSoLuong1,HeSoPhuCap1=@HeSoPhuCap1,LuongCoBan1=@LuongCoBan1,MucDong1=@MucDong1";
            sqlQuery += ",ThangDong2=@ThangDong2,HeSoLuong2=@HeSoLuong2,HeSoPhuCap2=@HeSoPhuCap2,LuongCoBan2=@LuongCoBan2,MucDong2=@MucDong2";
            sqlQuery += ",ThangDong3=@ThangDong3,HeSoLuong3=@HeSoLuong3,HeSoPhuCap3=@HeSoPhuCap3,LuongCoBan3=@LuongCoBan3,MucDong3=@MucDong3";
            sqlQuery += ",ThangDong4=@ThangDong4,HeSoLuong4=@HeSoLuong4,HeSoPhuCap4=@HeSoPhuCap4,LuongCoBan4=@LuongCoBan4,MucDong4=@MucDong4";
            sqlQuery += ",ThangDong5=@ThangDong5,HeSoLuong5=@HeSoLuong5,HeSoPhuCap5=@HeSoPhuCap5,LuongCoBan5=@LuongCoBan5,MucDong5=@MucDong5";
            sqlQuery += ",ThangDong6=@ThangDong6,HeSoLuong6=@HeSoLuong6,HeSoPhuCap6=@HeSoPhuCap6,LuongCoBan6=@LuongCoBan6,MucDong6=@MucDong6";
            sqlQuery += ",SoThangDongBHXH=@SoThangDongBHXH,SoThangHuongBHXH=@SoThangHuongBHXH,MucHuongToiDa=@MucHuongToiDa,LuongTrungBinh=@LuongTrungBinh,MucHuong=@MucHuong,HuongTuNgay=@HuongTuNgay,IDNguoiTinh=@IDNguoiTinh";
            sqlQuery += " WHERE IDNguoiLaoDong = @IDNguoiLaoDong END";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd =  sqlCon.CreateCommand();  
            Cmd.CommandText = sqlQuery;          
            Cmd.Parameters.Add("IDNguoiLaoDong", SqlDbType.Int).Value = IDNguoiLaoDong;
            Cmd.Parameters.Add("IDNLDTCTN", SqlDbType.Int).Value = IDNLDTCTN;
            Cmd.Parameters.Add("NgayTao", SqlDbType.DateTime).Value = NgayTao;
            Cmd.Parameters.Add("IDVungLuongToiThieu", SqlDbType.Int).Value = IDVungLuongToiThieu;
            Cmd.Parameters.Add("LuongToiThieuVung", SqlDbType.Decimal).Value = LuongToiThieuVung;
            Cmd.Parameters.Add("ThangDong1", SqlDbType.NVarChar).Value = ThangDong1;
            Cmd.Parameters.Add("HeSoLuong1", SqlDbType.Float).Value = HeSoLuong1;
            Cmd.Parameters.Add("HeSophuCap1", SqlDbType.Float).Value = HeSoPhuCap1;
            Cmd.Parameters.Add("LuongCoBan1", SqlDbType.Decimal).Value = LuongCoBan1;
            Cmd.Parameters.Add("MucDong1", SqlDbType.Decimal).Value = MucDong1;
            Cmd.Parameters.Add("ThangDong2", SqlDbType.NVarChar).Value = ThangDong2;
            Cmd.Parameters.Add("HeSoLuong2", SqlDbType.Float).Value = HeSoLuong2;
            Cmd.Parameters.Add("HeSophuCap2", SqlDbType.Float).Value = HeSoPhuCap2;
            Cmd.Parameters.Add("LuongCoBan2", SqlDbType.Decimal).Value = LuongCoBan2;
            Cmd.Parameters.Add("MucDong2", SqlDbType.Decimal).Value = MucDong2;
            Cmd.Parameters.Add("ThangDong3", SqlDbType.NVarChar).Value = ThangDong3;
            Cmd.Parameters.Add("HeSoLuong3", SqlDbType.Float).Value = HeSoLuong3;
            Cmd.Parameters.Add("HeSophuCap3", SqlDbType.Float).Value = HeSoPhuCap3;
            Cmd.Parameters.Add("LuongCoBan3", SqlDbType.Decimal).Value = LuongCoBan3;
            Cmd.Parameters.Add("MucDong3", SqlDbType.Decimal).Value = MucDong3;
            Cmd.Parameters.Add("ThangDong4", SqlDbType.NVarChar).Value = ThangDong4;
            Cmd.Parameters.Add("HeSoLuong4", SqlDbType.Float).Value = HeSoLuong4;
            Cmd.Parameters.Add("HeSophuCap4", SqlDbType.Float).Value = HeSoPhuCap4;
            Cmd.Parameters.Add("LuongCoBan4", SqlDbType.Decimal).Value = LuongCoBan4;
            Cmd.Parameters.Add("MucDong4", SqlDbType.Decimal).Value = MucDong4;
            Cmd.Parameters.Add("ThangDong5", SqlDbType.NVarChar).Value = ThangDong1;
            Cmd.Parameters.Add("HeSoLuong5", SqlDbType.Float).Value = HeSoLuong5;
            Cmd.Parameters.Add("HeSophuCap5", SqlDbType.Float).Value = HeSoPhuCap5;
            Cmd.Parameters.Add("LuongCoBan5", SqlDbType.Decimal).Value = LuongCoBan5;
            Cmd.Parameters.Add("MucDong5", SqlDbType.Decimal).Value = MucDong5;
            Cmd.Parameters.Add("ThangDong6", SqlDbType.NVarChar).Value = ThangDong6;
            Cmd.Parameters.Add("HeSoLuong6", SqlDbType.Float).Value = HeSoLuong6;
            Cmd.Parameters.Add("HeSophuCap6", SqlDbType.Float).Value = HeSoPhuCap6;
            Cmd.Parameters.Add("LuongCoBan6", SqlDbType.Decimal).Value = LuongCoBan6;
            Cmd.Parameters.Add("MucDong6", SqlDbType.Decimal).Value = MucDong6;
            Cmd.Parameters.Add("SoThangDongBHXH", SqlDbType.Int).Value = SoThangDongBHXH;
            Cmd.Parameters.Add("SoThangHuongBHXH", SqlDbType.Int).Value = SoThangHuongBHXH;
            Cmd.Parameters.Add("MucHuongToiDa", SqlDbType.Decimal).Value = MucHuongToiDa;
            Cmd.Parameters.Add("LuongTrungBinh", SqlDbType.Decimal).Value = LuongTrungBinh;
            Cmd.Parameters.Add("MucHuong", SqlDbType.Decimal).Value = MucHuong;
            Cmd.Parameters.Add("HuongTuNgay", SqlDbType.DateTime).Value = HuongTuNgay;
            Cmd.Parameters.Add("IDNguoiTinh", SqlDbType.Int).Value = IDNguoiTinh;
            Cmd.ExecuteNonQuery();
            sqlCon.Close();
            sqlCon.Dispose();
            tmpValue = 1;
        }
        catch ( Exception ex )
        {
            this.Message = ex.Message;
            this.ErrorCode = ex.HResult;
            tmpValue = 0;
        }
        return tmpValue;
    }
    #endregion
    #region method getDataById
    public DataTable getDataById(int IDNguoiLaoDong)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);         
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.Parameters.Add("IDNguoiLaoDong", SqlDbType.Int).Value = IDNguoiLaoDong;
            Cmd.CommandText = "SELECT * FROM TblTinhHuong WHERE IDNguoiLaoDong = @IDNguoiLaoDong";
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlCon.Close();
            sqlCon.Dispose();
            objTable = ds.Tables[0];
        }
        catch
        {

        }
        return objTable;
    }
    #endregion

    public bool CheckExists(int IDNguoiLaoDong, int IDNLDTCTN)
    {
        bool Status=false;
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
        sqlCon.Open();
        SqlCommand Cmd = sqlCon.CreateCommand();
        Cmd.CommandText = "SELECT * FROM TblTinhHuong WHERE IDTinhHuong = @IDTinhHuong And IDNLDTCTN=@IDNLDTCTN";
        Cmd.Parameters.Add("IDNguoiLaoDong", SqlDbType.Int).Value = IDNguoiLaoDong;
        Cmd.Parameters.Add("IDNLDTCTN", SqlDbType.Int).Value = IDNLDTCTN;
        SqlDataAdapter da = new SqlDataAdapter(Cmd);      
        DataSet ds = new DataSet();
        da.Fill(ds);
        sqlCon.Close();
        sqlCon.Dispose();
        if(ds.Tables[0].Rows.Count>0)
        {
            Status = true;
        }
        return Status;  
    }

}