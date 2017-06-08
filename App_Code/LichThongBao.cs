using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;

public class LichThongBao:DataClass
{
    #region Data Object
    public int IDLichThongBao { get; set; }
    public int IDNguoiLaoDong { get; set; }
    public int IDTinhHuong { get; set; }
    public DateTime KhaiBaoThang1TuNgay { get; set; }
    public DateTime KhaiBaoThang1DenNgay { get; set; }
    public DateTime KhaiBaoThang2TuNgay { get; set; }
    public DateTime KhaiBaoThang2DenNgay { get; set; }
    public DateTime KhaiBaoThang3TuNgay { get; set; }
    public DateTime KhaiBaoThang3DenNgay { get; set; }
    public DateTime KhaiBaoThang4TuNgay { get; set; }
    public DateTime KhaiBaoThang4DenNgay { get; set; }
    public DateTime KhaiBaoThang5TuNgay { get; set; }
    public DateTime KhaiBaoThang5DenNgay { get; set; }
    public DateTime KhaiBaoThang6TuNgay { get; set; }
    public DateTime KhaiBaoThang6DenNgay { get; set; }
    public DateTime KhaiBaoThang7TuNgay { get; set; }
    public DateTime KhaiBaoThang7DenNgay { get; set; }
    public DateTime KhaiBaoThang8TuNgay { get; set; }
    public DateTime KhaiBaoThang8DenNgay { get; set; }
    public DateTime KhaiBaoThang9TuNgay { get; set; }
    public DateTime KhaiBaoThang9DenNgay { get; set; }
    public DateTime KhaiBaoThang10TuNgay { get; set; }
    public DateTime KhaiBaoThang10DenNgay { get; set; }
    public DateTime KhaiBaoThang11TuNgay { get; set; }
    public DateTime KhaiBaoThang11DenNgay { get; set; }
    public DateTime KhaiBaoThang12TuNgay { get; set; }
    public DateTime KhaiBaoThang12DenNgay { get; set; }

    #endregion 
    public LichThongBao()
    {
    }
    #region method setData
    public int setData(int IDLichThongBao, int IDNguoiLaoDong, int IDTinhHuong, DateTime KhaiBaoThang1TuNgay, DateTime KhaiBaoThang1DenNgay
        , DateTime KhaiBaoThang2TuNgay, DateTime KhaiBaoThang2DenNgay, DateTime KhaiBaoThang3TuNgay, DateTime KhaiBaoThang3DenNgay
        , DateTime KhaiBaoThang4TuNgay, DateTime KhaiBaoThang4DenNgay, DateTime KhiBaoThang5TuNgay, DateTime KhaiBaoThang5DenNgay
        , DateTime KhaiBaoThang6TuNgay, DateTime KhaiBaoThang6DenNgay, DateTime KhiBaoThang7TuNgay, DateTime KhaiBaoThang7DenNgay
        , DateTime KhaiBaoThang8TuNgay, DateTime KhaiBaoThang8DenNgay, DateTime KhiBaoThang9TuNgay, DateTime KhaiBaoThang9DenNgay
        , DateTime KhaiBaoThang10TuNgay, DateTime KhaiBaoThang10DenNgay, DateTime KhiBaoThang11TuNgay, DateTime KhaiBaoThang11DenNgay
        , DateTime KhaiBaoThang12TuNgay, DateTime KhaiBaoThang12DenNgay)
    {
        int tmpValue = 0;
        try
        {
            string sqlQuery = "IF NOT EXISTS (SELECT * FROM TblLichThongBao WHERE IDTinhHuong= @IDTinhHuong) ";
            sqlQuery += "BEGIN INSERT INTO TblLichThongBao (IDNguoiLaoDong,IDTinhHuong";
            sqlQuery += ",KhaiBaoThang1TuNgay,KhaiBaoThang1DenNgay";
            sqlQuery += ",KhaiBaoThang2TuNgay,KhaiBaoThang2DenNgay";
            sqlQuery += ",KhaiBaoThang3TuNgay,KhaiBaoThang3DenNgay";
            sqlQuery += ",KhaiBaoThang4TuNgay,KhaiBaoThang4DenNgay";
            sqlQuery += ",KhaiBaoThang5TuNgay,KhaiBaoThang5DenNgay";
            sqlQuery += ",KhaiBaoThang6TuNgay,KhaiBaoThang6DenNgay";
            sqlQuery += ",KhaiBaoThang7TuNgay,KhaiBaoThang7DenNgay";
            sqlQuery += ",KhaiBaoThang8TuNgay,KhaiBaoThang8DenNgay";
            sqlQuery += ",KhaiBaoThang9TuNgay,KhaiBaoThang9DenNgay";
            sqlQuery += ",KhaiBaoThang10TuNgay,KhaiBaoThang10DenNgay";
            sqlQuery += ",KhaiBaoThang11TuNgay,KhaiBaoThang11DenNgay";
            sqlQuery += ",KhaiBaoThang12TuNgay,KhaiBaoThang12DenNgay";
            sqlQuery += " )";
            sqlQuery += " VALUES (@IDNguoiLaoDong,@IDTinhHuong";
            sqlQuery += ",@KhaiBaoThang1TuNgay,@KhaiBaoThang1DenNgay";
            sqlQuery += ",@KhaiBaoThang2TuNgay,@KhaiBaoThang2DenNgay";
            sqlQuery += ",@KhaiBaoThang3TuNgay,@KhaiBaoThang3DenNgay";
            sqlQuery += ",@KhaiBaoThang4TuNgay,@KhaiBaoThang4DenNgay";
            sqlQuery += ",@KhaiBaoThang5TuNgay,@KhaiBaoThang5DenNgay";
            sqlQuery += ",@KhaiBaoThang6TuNgay,@KhaiBaoThang6DenNgay";
            sqlQuery += ",@KhaiBaoThang7TuNgay,@KhaiBaoThang7DenNgay";
            sqlQuery += ",@KhaiBaoThang8TuNgay,@KhaiBaoThang8DenNgay";
            sqlQuery += ",@KhaiBaoThang9TuNgay,@KhaiBaoThang9DenNgay";
            sqlQuery += ",@KhaiBaoThang10TuNgay,@KhaiBaoThang10DenNgay";
            sqlQuery += ",@KhaiBaoThang11TuNgay,@KhaiBaoThang11DenNgay";
            sqlQuery += ",@KhaiBaoThang12TuNgay,@KhaiBaoThang12DenNgay";
            sqlQuery += ") END ";
            sqlQuery += "ELSE BEGIN UPDATE TblLichThongBao SET IDNguoiLaoDong=@IDNguoiLaoDong,IDTinhHuong=@IDTinhHuong";
            sqlQuery += ",KhaiBaoThang1TuNgay=@KhaiBaoThang1TuNgay,KhaiBaoThang1DenNgay=@KhaiBaoThang1DenNgay";
            sqlQuery += ",KhaiBaoThang2TuNgay=@KhaiBaoThang2TuNgay,KhaiBaoThang2DenNgay=@KhaiBaoThang2DenNgay";
            sqlQuery += ",KhaiBaoThang3TuNgay=@KhaiBaoThang3TuNgay,KhaiBaoThang3DenNgay=@KhaiBaoThang3DenNgay";
            sqlQuery += ",KhaiBaoThang4TuNgay=@KhaiBaoThang4TuNgay,KhaiBaoThang4DenNgay=@KhaiBaoThang4DenNgay";
            sqlQuery += ",KhaiBaoThang5TuNgay=@KhaiBaoThang5TuNgay,KhaiBaoThang5DenNgay=@KhaiBaoThang5DenNgay";
            sqlQuery += ",KhaiBaoThang6TuNgay=@KhaiBaoThang6TuNgay,KhaiBaoThang6DenNgay=@KhaiBaoThang6DenNgay";
            sqlQuery += ",KhaiBaoThang7TuNgay=@KhaiBaoThang7TuNgay,KhaiBaoThang7DenNgay=@KhaiBaoThang7DenNgay";
            sqlQuery += ",KhaiBaoThang8TuNgay=@KhaiBaoThang8TuNgay,KhaiBaoThang8DenNgay=@KhaiBaoThang8DenNgay";
            sqlQuery += ",KhaiBaoThang9TuNgay=@KhaiBaoThang9TuNgay,KhaiBaoThang9DenNgay=@KhaiBaoThang9DenNgay";
            sqlQuery += ",KhaiBaoThang10TuNgay=@KhaiBaoThang10TuNgay,KhaiBaoThang10DenNgay=@KhaiBaoThang10DenNgay";
            sqlQuery += ",KhaiBaoThang11TuNgay=@KhaiBaoThang11TuNgay,KhaiBaoThang11DenNgay=@KhaiBaoThang11DenNgay";
            sqlQuery += ",KhaiBaoThang12TuNgay=@KhaiBaoThang12TuNgay,KhaiBaoThang12DenNgay=@KhaiBaoThang12DenNgay";
            sqlQuery += " WHERE IDTinhHuong = @IDTinhHuong END";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand cmd = sqlCon.CreateCommand();
            cmd.CommandText = sqlQuery;
            cmd.Parameters.Add("IDNguoiLaoDong", SqlDbType.Int).Value = IDNguoiLaoDong;
            cmd.Parameters.Add("IDTinhHuong", SqlDbType.Int).Value = IDTinhHuong;
            cmd.Parameters.Add("KhaiBaoThang1TuNgay", SqlDbType.DateTime).Value = KhaiBaoThang1TuNgay;
            cmd.Parameters.Add("KhaiBaoThang1DenNgay", SqlDbType.DateTime).Value = KhaiBaoThang1DenNgay;
            cmd.Parameters.Add("KhaiBaoThang2TuNgay", SqlDbType.DateTime).Value = KhaiBaoThang2TuNgay;
            cmd.Parameters.Add("KhaiBaoThang2DenNgay", SqlDbType.DateTime).Value = KhaiBaoThang2DenNgay;
            cmd.Parameters.Add("KhaiBaoThang3TuNgay", SqlDbType.DateTime).Value = KhaiBaoThang3TuNgay;
            cmd.Parameters.Add("KhaiBaoThang3DenNgay", SqlDbType.DateTime).Value = KhaiBaoThang3DenNgay;
            cmd.Parameters.Add("KhaiBaoThang4TuNgay", SqlDbType.DateTime).Value = KhaiBaoThang4TuNgay;
            cmd.Parameters.Add("KhaiBaoThang4DenNgay", SqlDbType.DateTime).Value = KhaiBaoThang4DenNgay;
            cmd.Parameters.Add("KhaiBaoThang5TuNgay", SqlDbType.DateTime).Value = KhaiBaoThang5TuNgay;
            cmd.Parameters.Add("KhaiBaoThang5DenNgay", SqlDbType.DateTime).Value = KhaiBaoThang5DenNgay;
            cmd.Parameters.Add("KhaiBaoThang6TuNgay", SqlDbType.DateTime).Value = KhaiBaoThang6TuNgay;
            cmd.Parameters.Add("KhaiBaoThang6DenNgay", SqlDbType.DateTime).Value = KhaiBaoThang6DenNgay;
            cmd.Parameters.Add("KhaiBaoThang7TuNgay", SqlDbType.DateTime).Value = KhaiBaoThang7TuNgay;
            cmd.Parameters.Add("KhaiBaoThang7DenNgay", SqlDbType.DateTime).Value = KhaiBaoThang7DenNgay;
            cmd.Parameters.Add("KhaiBaoThang8TuNgay", SqlDbType.DateTime).Value = KhaiBaoThang8TuNgay;
            cmd.Parameters.Add("KhaiBaoThang8DenNgay", SqlDbType.DateTime).Value = KhaiBaoThang8DenNgay;
            cmd.Parameters.Add("KhaiBaoThang9TuNgay", SqlDbType.DateTime).Value = KhaiBaoThang9TuNgay;
            cmd.Parameters.Add("KhaiBaoThang9DenNgay", SqlDbType.DateTime).Value = KhaiBaoThang9DenNgay;
            cmd.Parameters.Add("KhaiBaoThang10TuNgay", SqlDbType.DateTime).Value = KhaiBaoThang10TuNgay;
            cmd.Parameters.Add("KhaiBaoThang10DenNgay", SqlDbType.DateTime).Value = KhaiBaoThang10DenNgay;
            cmd.Parameters.Add("KhaiBaoThang11TuNgay", SqlDbType.DateTime).Value = KhaiBaoThang11TuNgay;
            cmd.Parameters.Add("KhaiBaoThang11DenNgay", SqlDbType.DateTime).Value = KhaiBaoThang11DenNgay;
            cmd.Parameters.Add("KhaiBaoThang12TuNgay", SqlDbType.DateTime).Value = KhaiBaoThang12TuNgay;
            cmd.Parameters.Add("KhaiBaoThang12DenNgay", SqlDbType.DateTime).Value = KhaiBaoThang12DenNgay;
            cmd.ExecuteNonQuery();
            sqlCon.Close();
            sqlCon.Dispose();
            tmpValue = 1;
        }
        catch (Exception ex)
        {
            this.Message = ex.Message;
            this.ErrorCode = ex.HResult;
            tmpValue = 0;
        }
        return tmpValue;
    }

    #endregion
    #region GetDataByID
    public DataTable GetDataByID(int IDTinhHuong)
    {
        string sql = "Select * From TblLichThongBao Where IDTinhHuong=@IDTinhHuong";
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
        sqlCon.Open();
        SqlCommand cmd = sqlCon.CreateCommand();
        cmd.CommandText = sql;
        cmd.Parameters.Add("IDTinhHuong", SqlDbType.Int).Value = IDTinhHuong;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);       
        sqlCon.Close();
        sqlCon.Dispose();
        return ds.Tables[0];
    }

    #endregion 

}
public class TempThongBao
{
    public DateTime TuNgay = new DateTime(1900, 1, 1);
    public DateTime DenNgay = new DateTime(1900, 1, 1);
}