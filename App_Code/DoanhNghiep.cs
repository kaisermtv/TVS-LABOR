using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class DoanhNghiep
{
    #region method DoanhNghiep
    public DoanhNghiep()
    {
    } 
    #endregion

    #region method setData
    public int setData(ref int IDDonVi, string MaDonVi, string TenDonVi, int IDNganhnghe, int IdLoaiHinh, string QuyMo, string Diachi, int IDHuyen, int IDTinh, string DienThoaiDonVi, string EmailDonVi, string Website, string NguoiDaiDien, string DienThoai, string Email, string ChucVu, DateTime NgayDangKy, bool NuocNgoai, bool State)
    {
        int tmpValue = 0;

        try
        {
            string sqlQuery = "";

            sqlQuery = "IF NOT EXISTS (SELECT * FROM TblDoanhNghiep WHERE IDDonVi = @IDDonVi) ";
            sqlQuery += "BEGIN INSERT INTO TblDoanhNghiep(MaDonVi,TenDonVi,IDNganhnghe,IdLoaiHinh,QuyMo,Diachi,IDHuyen,IDTinh,DienThoaiDonVi,EmailDonVi,Website,NguoiDaiDien,DienThoai,Email,ChucVu,NgayDangKy,State) VALUES(@MaDonVi,@TenDonVi,@IDNganhnghe,@IdLoaiHinh,@QuyMo,@Diachi,@IDHuyen,@IDTinh,@DienThoaiDonVi,@EmailDonVi,@Website,@NguoiDaiDien,@DienThoai,@Email,@ChucVu,@NgayDangKy,@State) END ";
            sqlQuery += "ELSE BEGIN UPDATE TblDoanhNghiep SET MaDonVi = @MaDonVi,TenDonVi = @TenDonVi,IDNganhnghe = @IDNganhnghe, IdLoaiHinh = @IdLoaiHinh, QuyMo = @QuyMo, Diachi = @Diachi,IDHuyen = @IDHuyen,IDTinh = @IDTinh,DienThoaiDonVi = @DienThoaiDonVi,EmailDonVi = @EmailDonVi,Website = @Website, NguoiDaiDien = @NguoiDaiDien,DienThoai = @DienThoai,Email = @Email, ChucVu = @ChucVu, NgayDangKy = @NgayDangKy,State = @State WHERE IDDonVi = @IDDonVi END ";
            
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;

            if (IDDonVi == 0)
            {
                MaDonVi = this.getNextMaDN();
            }

            Cmd.Parameters.Add("IDDonVi", SqlDbType.Int).Value = IDDonVi;
            Cmd.Parameters.Add("MaDonVi", SqlDbType.NVarChar).Value = MaDonVi;
            Cmd.Parameters.Add("TenDonVi", SqlDbType.NVarChar).Value = TenDonVi;
            Cmd.Parameters.Add("IDNganhnghe", SqlDbType.Int).Value = IDNganhnghe;
            Cmd.Parameters.Add("IdLoaiHinh", SqlDbType.Int).Value = IdLoaiHinh;
            Cmd.Parameters.Add("QuyMo", SqlDbType.NVarChar).Value = QuyMo;

            Cmd.Parameters.Add("Diachi", SqlDbType.NVarChar).Value = Diachi;
            Cmd.Parameters.Add("IDHuyen", SqlDbType.Int).Value = IDHuyen;
            Cmd.Parameters.Add("IDTinh", SqlDbType.Int).Value = IDTinh;
            Cmd.Parameters.Add("DienThoaiDonVi", SqlDbType.NVarChar).Value = DienThoaiDonVi;
            Cmd.Parameters.Add("EmailDonVi", SqlDbType.NVarChar).Value = EmailDonVi;

            Cmd.Parameters.Add("Website", SqlDbType.NVarChar).Value = Website;
            Cmd.Parameters.Add("NguoiDaiDien", SqlDbType.NVarChar).Value = NguoiDaiDien;
            Cmd.Parameters.Add("DienThoai", SqlDbType.NVarChar).Value = DienThoai;
            Cmd.Parameters.Add("Email", SqlDbType.NVarChar).Value = Email;
            Cmd.Parameters.Add("ChucVu", SqlDbType.NVarChar).Value = ChucVu;
            
            Cmd.Parameters.Add("NgayDangKy", SqlDbType.DateTime).Value = NgayDangKy;
            Cmd.Parameters.Add("NuocNgoai", SqlDbType.Bit).Value = NuocNgoai;
            Cmd.Parameters.Add("State", SqlDbType.Bit).Value = State;

            Cmd.ExecuteNonQuery();

            if (IDDonVi == 0)
            {
                sqlQuery = "SELECT TOP 1 IDDonVi FROM TblDoanhNghiep WHERE TenDonVi = @TenDonVi ORDER BY IDDonVi DESC";
                Cmd.CommandText = sqlQuery;
                SqlDataReader Rd = Cmd.ExecuteReader();
                while(Rd.Read())
                {
                    IDDonVi = int.Parse(Rd["IDDonVi"].ToString());
                }
                Rd.Close();
            }

            sqlCon.Close();
            sqlCon.Dispose();
            tmpValue = 1;
        }
        catch
        {
            tmpValue = 0;
        }
        return tmpValue;
    }
    #endregion

    #region method getData
    public DataTable getData(string searchKey)
    {
        string sqlQuery = "";
        if (searchKey.Trim() != "")
        {
            sqlQuery += " AND UPPER(RTRIM(LTRIM(TenDonVi))) LIKE N'%'+UPPER(RTRIM(LTRIM(@SearchKey)))+'%'";
        }
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.Parameters.Add("SearchKey", SqlDbType.NVarChar).Value = searchKey;
            Cmd.CommandText = "SELECT 0 AS TT, *, REPLACE(REPLACE(CAST(State AS varchar),'1',N'Kích hoạt'),'0',N'Đóng') AS StateName, ISNULL((SELECT Count(*) FROM TblTuyenDung WHERE IdDonVi = TblDoanhNghiep.IdDonVi),'') AS CountItem FROM TblDoanhNghiep WHERE 1 = 1 " + sqlQuery;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ds.Tables[0].Rows[i]["TT"] = (i + 1);
            }
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

    #region method getDataById
    public DataTable getDataById(int IDDoanhNghiep)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT * FROM TblDoanhNghiep WHERE IDDonVi = @IDDonVi";
            Cmd.Parameters.Add("IDDonVi", SqlDbType.Int).Value = IDDoanhNghiep;
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

    #region method getDataViewById
    public DataTable getDataViewById(int IDDoanhNghiep)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT P.*,B.Name AS NganhNgheName,L.NameLoaiHinh FROM TblDoanhNghiep AS P ";
            Cmd.CommandText += " LEFT JOIN TblBusiness AS B ON P.IDNganhNghe = B.Id";
            Cmd.CommandText += " LEFT JOIN TblLoaiHinh AS L ON P.IdLoaiHinh = L.IdLoaiHinh";
            Cmd.CommandText += " LEFT JOIN TblDistrict AS D ON P.IDHuyen = L.Id";
            Cmd.CommandText += " LEFT JOIN TblLoaiHinh AS L ON P.IDTinh = L.IdLoaiHinh";

            Cmd.CommandText += " WHERE P.IDDonVi = @IDDonVi";
            Cmd.Parameters.Add("IDDonVi", SqlDbType.Int).Value = IDDoanhNghiep;
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

    #region method delData
    public void delData(int IDDonVi)
    {
        try
        {
            string sqlQuery = "";
            sqlQuery = "DELETE TblDoanhNghiep WHERE IDDonVi = @IDDonVi ";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("IDDonVi", SqlDbType.Int).Value = IDDonVi;
            Cmd.ExecuteNonQuery();
            sqlCon.Close();
            sqlCon.Dispose();
        }
        catch
        {

        }
    }
    #endregion

    #region method checkCode
    public bool checkCode(string MaDonVi)
    {
        bool tmpValue = false;
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT * FROM TblDoanhNghiep WHERE MaDonVi = @MaDonVi";
            Cmd.Parameters.Add("MaDonVi", SqlDbType.NVarChar).Value = MaDonVi;
            SqlDataReader Rd = Cmd.ExecuteReader();
            while (Rd.Read())
            {
                tmpValue = true;
            }
            Rd.Close();
            sqlCon.Close();
            sqlCon.Dispose();
        }
        catch
        {

        }
        return tmpValue;
    }
    #endregion

    #region method getNextMaDN
    public string getNextMaDN()
    {
        string tmpMaNLD = "";
        try
        {
            int tmpCount = 0;
            string sqlQuery = "";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            sqlQuery = "SELECT ISNULL(COUNT(*),0) AS CountItem FROM TblDoanhNghiep WHERE ISNULL(MaDonVi,'') <> '' and LEN(MaDonVi) >=9";
            Cmd.CommandText = sqlQuery;
            SqlDataReader Rd = Cmd.ExecuteReader();
            while (Rd.Read())
            {
                tmpCount = int.Parse(Rd["CountItem"].ToString());
            }
            Rd.Close();

            if (tmpCount == 0)
            {
                tmpCount = 1;
            }
            else
            {
                SqlCommand Cmd1 = sqlCon.CreateCommand();
                sqlQuery = "SELECT TOP 1 CAST(SUBSTRING(MaDonVi,10,(LEN(MaDonVi)-9)) AS Int) AS MaxItem FROM dbo.TblDoanhNghiep WHERE ISNULL(MaDonVi,'') <> '' and LEN(MaDonVi) >=9 ORDER BY CAST(SUBSTRING(MaDonVi,10,(LEN(MaDonVi)-9)) AS Int) DESC";
                Cmd1.CommandText = sqlQuery;
                SqlDataReader Rd1 = Cmd1.ExecuteReader();
                while (Rd1.Read())
                {
                    tmpCount = int.Parse(Rd1["MaxItem"].ToString());
                }
                Rd1.Close();
                tmpCount = tmpCount + 1;
            }
            sqlCon.Close();
            sqlCon.Dispose();
            tmpMaNLD = "DN"+DateTime.Now.ToString("yyMMdd") + "-" + tmpCount.ToString("000");
        }
        catch
        {

        }
        return tmpMaNLD;
    }
    #endregion
}