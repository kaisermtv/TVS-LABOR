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
    public int SoThangHuongBHXH { get; set; }
    public int SoThangBaoLuuBHXH { get; set; }
    public decimal MucHuongToiDa { get; set; }
    public decimal LuongTrungBinh { get; set; }
    public decimal MucHuong { get; set; }
    public DateTime HuongTuNgay { get; set; }
    public DateTime HuongDenNgay { get; set; }
    public int IDNguoiTinh { get; set; }
    public int SoThangDaHuongBHXH { get; set; }
    public int SoThangDuocHuongConLaiBHXH { get; set; }
    public DateTime DeXuatTamDung { get; set; }
    public DateTime DeXuatTiepTuc { get; set; }
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
        ,int SoThangHuongBHXH,int SoThangBaoLuuBHXH, decimal MucHuongToiDa,decimal LuongTrungBinh,decimal MucHuong,DateTime HuongTuNgay, DateTime HuongDenNgay, int IDNguoiTinh 
        ,int SoThangDaHuongBHXH=0,int SoThangDuocHuongConLaiBHXH=0)
    {
        int tmpValue = 0;
        try
        {
            string sqlQuery = "";
            sqlQuery = "IF NOT EXISTS (SELECT * FROM TblTinhHuong WHERE IDNLDTCTN= @IDNLDTCTN) ";
            sqlQuery += "BEGIN INSERT INTO TblTinhHuong(IDNguoiLaoDong,IDNLDTCTN,NgayTao,IDVungLuongToiThieu,LuongToiThieuVung";
            sqlQuery += ",ThangDong1,HeSoLuong1,HeSoPhuCap1,LuongCoBan1,MucDong1";
            sqlQuery += ",ThangDong2,HeSoLuong2,HeSoPhuCap2,LuongCoBan2,MucDong2";
            sqlQuery += ",ThangDong3,HeSoLuong3,HeSoPhuCap3,LuongCoBan3,MucDong3";
            sqlQuery += ",ThangDong4,HeSoLuong4,HeSoPhuCap4,LuongCoBan4,MucDong4";
            sqlQuery += ",ThangDong5,HeSoLuong5,HeSoPhuCap5,LuongCoBan5,MucDong5";
            sqlQuery += ",ThangDong6,HeSoLuong6,HeSoPhuCap6,LuongCoBan6,MucDong6";
            sqlQuery += ",SoThangHuongBHXH,SoThangBaoLuuBHXH,MucHuongToiDa,LuongTrungBinh,MucHuong,HuongTuNgay,HuongDenNgay,IDNguoiTinh,SoThangDaHuongBHXH,SoThangDuocHuongConLaiBHXH";
            sqlQuery += ")";
            sqlQuery += " VALUES(@IDNguoiLaoDong,@IDNLDTCTN,@NgayTao,@IDVungLuongToiThieu,@LuongToiThieuVung";
            sqlQuery += ",@ThangDong1,@HeSoLuong1,@HeSoPhuCap1,@LuongCoBan1,@MucDong1";
            sqlQuery += ",@ThangDong2,@HeSoLuong2,@HeSoPhuCap2,@LuongCoBan2,@MucDong2";
            sqlQuery += ",@ThangDong3,@HeSoLuong3,@HeSoPhuCap3,@LuongCoBan3,@MucDong3";
            sqlQuery += ",@ThangDong4,@HeSoLuong4,@HeSoPhuCap4,@LuongCoBan4,@MucDong4";
            sqlQuery += ",@ThangDong5,@HeSoLuong5,@HeSoPhuCap5,@LuongCoBan5,@MucDong5";
            sqlQuery += ",@ThangDong6,@HeSoLuong6,@HeSoPhuCap6,@LuongCoBan6,@MucDong6";
            sqlQuery += ",@SoThangHuongBHXH,@SoThangBaoLuuBHXH,@MucHuongToiDa,@LuongTrungBinh,@MucHuong,@HuongTuNgay,@HuongDenNgay,@IDNguoiTinh,@SoThangDaHuongBHXH,@SoThangDuocHuongConLaiBHXH";
            sqlQuery += ") END ";
            sqlQuery += "ELSE BEGIN UPDATE TblTinhHuong SET NgayTao=@NgayTao,IDVungLuongToiThieu=@IDVungLuongToiThieu,LuongToiThieuVung=@LuongToiThieuVung";
            sqlQuery += ",ThangDong1=@ThangDong1,HeSoLuong1=@HeSoLuong1,HeSoPhuCap1=@HeSoPhuCap1,LuongCoBan1=@LuongCoBan1,MucDong1=@MucDong1";
            sqlQuery += ",ThangDong2=@ThangDong2,HeSoLuong2=@HeSoLuong2,HeSoPhuCap2=@HeSoPhuCap2,LuongCoBan2=@LuongCoBan2,MucDong2=@MucDong2";
            sqlQuery += ",ThangDong3=@ThangDong3,HeSoLuong3=@HeSoLuong3,HeSoPhuCap3=@HeSoPhuCap3,LuongCoBan3=@LuongCoBan3,MucDong3=@MucDong3";
            sqlQuery += ",ThangDong4=@ThangDong4,HeSoLuong4=@HeSoLuong4,HeSoPhuCap4=@HeSoPhuCap4,LuongCoBan4=@LuongCoBan4,MucDong4=@MucDong4";
            sqlQuery += ",ThangDong5=@ThangDong5,HeSoLuong5=@HeSoLuong5,HeSoPhuCap5=@HeSoPhuCap5,LuongCoBan5=@LuongCoBan5,MucDong5=@MucDong5";
            sqlQuery += ",ThangDong6=@ThangDong6,HeSoLuong6=@HeSoLuong6,HeSoPhuCap6=@HeSoPhuCap6,LuongCoBan6=@LuongCoBan6,MucDong6=@MucDong6";
            sqlQuery += ",SoThangHuongBHXH=@SoThangHuongBHXH,SoThangBaoLuuBHXH=@SoThangBaoLuuBHXH,MucHuongToiDa=@MucHuongToiDa,LuongTrungBinh=@LuongTrungBinh";
            sqlQuery += ",MucHuong=@MucHuong,HuongTuNgay=@HuongTuNgay,HuongDenNgay=@HuongDenNgay,IDNguoiTinh=@IDNguoiTinh,SoThangDaHuongBHXH=@SoThangDaHuongBHXH,SoThangDuocHuongConLaiBHXH=@SoThangDuocHuongConLaiBHXH";
            sqlQuery += " WHERE IDNLDTCTN = @IDNLDTCTN END";
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
            Cmd.Parameters.Add("SoThangHuongBHXH", SqlDbType.Int).Value = SoThangHuongBHXH;
            Cmd.Parameters.Add("SoThangBaoLuuBHXH", SqlDbType.Int).Value = SoThangBaoLuuBHXH;
            Cmd.Parameters.Add("MucHuongToiDa", SqlDbType.Decimal).Value = MucHuongToiDa;
            Cmd.Parameters.Add("LuongTrungBinh", SqlDbType.Decimal).Value = LuongTrungBinh;
            Cmd.Parameters.Add("MucHuong", SqlDbType.Decimal).Value = MucHuong;
            Cmd.Parameters.Add("HuongTuNgay", SqlDbType.DateTime).Value = HuongTuNgay;
            Cmd.Parameters.Add("HuongDenNgay", SqlDbType.DateTime).Value = HuongDenNgay;
            Cmd.Parameters.Add("IDNguoiTinh", SqlDbType.Int).Value = IDNguoiTinh;
            Cmd.Parameters.Add("SoThangDaHuongBHXH", SqlDbType.Int).Value = SoThangDaHuongBHXH;
            Cmd.Parameters.Add("SoThangDuocHuongConLaiBHXH", SqlDbType.Int).Value = SoThangDuocHuongConLaiBHXH;
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
    public DataTable getDataById(int IDNLDTCTN)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);         
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.Parameters.Add("IDNLDTCTN", SqlDbType.Int).Value = IDNLDTCTN;
            Cmd.CommandText = "SELECT * FROM TblTinhHuong WHERE IDNLDTCTN = @IDNLDTCTN";
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
    #region kiem tra su thong tai cua bang tinh huong
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
    #endregion
    #region tinh ngay nghi le
    public DateTime TinhNgayNghiLe(DateTime NgayNop, int SoNgayThuLy)
    {
        for (int i = 0; i < SoNgayThuLy; i++)
        {          
            NgayNop = NgayNop.AddDays(1);                 
            if (NgayNop.DayOfWeek == DayOfWeek.Saturday)
            {  
               int dem=0;
               if(CheckNgayLe(NgayNop)==true)
               {
                   dem++;
               }
               dem++;
               NgayNop = NgayNop.AddDays(dem);
            }
            if (NgayNop.DayOfWeek == DayOfWeek.Sunday)
            {
                int dem = 0;
                if (CheckNgayLe(NgayNop) == true)
                {
                    dem++;
                }
                dem++;
                NgayNop = NgayNop.AddDays(dem);
            }
            NgayNop = KiemTraNgayNghi(NgayNop);  
        }
        // kiem tra lai sau khi da tru thu 7, cn co bi trung vao ngay nghi tiep khong
        //NgayNop = KiemTraNgayNghi(NgayNop);
        return NgayNop;
    }
    private DateTime KiemTraNgayNghi(DateTime Datetime)
    {
        DataTable tblNgayNghiLe = GetDanhSachNgayNghiLe(Datetime.Year.ToString().Trim());    
        if(tblNgayNghiLe ==null || tblNgayNghiLe.Rows.Count==0)
        {
            return Datetime;
        }
        for (int i = 0; i < tblNgayNghiLe.Rows.Count;i++ )
        {           
            if (Datetime.ToString("dd/MM/yyyy").Trim() == tblNgayNghiLe.Rows[i]["NameDanhMuc"].ToString().Trim() )
            {
                Datetime = Datetime.AddDays(1);
            }          
        }
        return Datetime;
    }
    private bool CheckNgayLe(DateTime Datetime)
    {
        DataTable tblNgayNghiLe = GetDanhSachNgayNghiLe(Datetime.Year.ToString().Trim());
        if (tblNgayNghiLe == null || tblNgayNghiLe.Rows.Count == 0)
        {
            return false;
        }
        for (int i = 0; i < tblNgayNghiLe.Rows.Count; i++)
        { 
            if (Datetime.ToString("dd/MM/yyyy").Trim() == tblNgayNghiLe.Rows[i]["NameDanhMuc"].ToString().Trim())
            {
                return true;
            }
        }
        return false;
    }
    #endregion
    #region DanhSachNgayNghiLe
    public DataTable GetDanhSachNgayNghiLe(string NamHienTai)
    {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd =  sqlCon.CreateCommand();  
            Cmd.CommandText = "select *  from tbldanhmuc Where DanhMucid=24 And right(NameDanhMUc,4)=@NamHienTai";
            Cmd.Parameters.Add("NamHienTai", SqlDbType.NVarChar).Value = NamHienTai;
            SqlDataAdapter da = new SqlDataAdapter(Cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlCon.Close();
            sqlCon.Dispose();
            return ds.Tables[0];
    }
    #endregion 
    #region Danh sách hồ sơ
    public DataTable getDanhSachHoSo(string IDTrangThais, DateTime? TuNgay,DateTime? DenNgay, string searchKey = "")
    {
        if(!TuNgay.HasValue)
        {
            TuNgay = new DateTime(1900, 1, 1);

        }
        if(!DenNgay.HasValue)
        {
            DenNgay = new DateTime(9999, 1, 1);
        }
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "SELECT TN.[IdNLDTCTN],P.[HoVaTen],P.[CMND],P.[BHXH],TN.NgayNopHoSo,TN.NgayHenTraKQ,TN.NgayNghiViec,TN.SoThangDongBHXH,TN.NgayHoanThien,TT.name AS TrangThai,TN.IdTrangThai FROM TblNLDTroCapThatNghiep AS TN";
            Cmd.CommandText += " LEFT JOIN TblNguoiLaoDong AS P ON TN.IDNguoiLaoDong = P.IDNguoiLaoDong";
            Cmd.CommandText += " LEFT JOIN tblTrangThaiHoSo AS TT ON TN.IdTrangThai = TT.id";     
            Cmd.CommandText += " WHERE TN.IdTrangThai In (Select distinct Item from dbo.Split(@IDTrangThais))";
            Cmd.CommandText += " And (HoVaTen=@str Or @str='') And (TN.NgayNopHoSo between @TuNgay And @DenNgay)";
            Cmd.Parameters.Add("IDTrangThais", SqlDbType.NVarChar).Value = IDTrangThais;      
            Cmd.Parameters.Add("str", SqlDbType.NVarChar).Value = searchKey;
            Cmd.Parameters.Add("TuNgay", SqlDbType.DateTime).Value = TuNgay;
            Cmd.Parameters.Add("DenNgay", SqlDbType.DateTime).Value = DenNgay;
            SqlDataAdapter da = new SqlDataAdapter(Cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            this.SQLClose();
            return ds.Tables[0];
        }
        catch (Exception ex)
        {
            this.Message = ex.Message;
            this.ErrorCode = ex.HResult;
            return null;
        }
    }
    public DataTable getDanhSachHoSoAndQuyetDinh(string IDTrangThais, string searchKey = "")
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "SELECT TN.[IdNLDTCTN],P.[HoVaTen],P.[CMND],P.[BHXH],TN.NgayNopHoSo,TN.NgayHenTraKQ,TN.NgayNghiViec,TN.SoThangDongBHXH,TN.NgayHoanThien,TT.name AS TrangThai,TN.IdTrangThai,CS.IDCapSo,CS.SoVanBan,CS.NgayKy FROM TblNLDTroCapThatNghiep AS TN";
            Cmd.CommandText += " LEFT JOIN TblNguoiLaoDong AS P ON TN.IDNguoiLaoDong = P.IDNguoiLaoDong";
            Cmd.CommandText += " LEFT JOIN tblTrangThaiHoSo AS TT ON TN.IdTrangThai = TT.id";
            Cmd.CommandText += " Left join TblCapSo cs on cs.IDNLDTCTN=tn.IdNLDTCTN";
            Cmd.CommandText += " WHERE TN.IdTrangThai In (Select distinct Item from dbo.Split(@IDTrangThais))";
            Cmd.CommandText += " And (HoVaTen=@str Or @str='')";
            Cmd.CommandText += " And  (IDCapSo in (select max(IDCapSo) from TblCapSo Where IDNLDTCTN=TN.IdNLDTCTN ) Or IDCapSo is null)";
            Cmd.Parameters.Add("IDTrangThais", SqlDbType.NVarChar).Value = IDTrangThais;
            Cmd.Parameters.Add("str", SqlDbType.NVarChar).Value = searchKey;
            SqlDataAdapter da = new SqlDataAdapter(Cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            this.SQLClose();
            return ds.Tables[0];
        }
        catch (Exception ex)
        {
            this.Message = ex.Message;
            this.ErrorCode = ex.HResult;
            return null;
        }
    }

    public DataTable getDanhSachChuyenHuong(DateTime TuNgay, DateTime DenNgay, int IDTrangThai, string searchKey = "")
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            string sql = "SELECT TN.[IdNLDTCTN],P.[HoVaTen],P.[CMND],P.[BHXH],TN.NgayNopHoSo,TN.NgayHenTraKQ,TN.NgayNghiViec,TN.SoThangDongBHXH,TN.NgayHoanThien";
            sql += " ,TT.name AS TrangThai,TN.IdTrangThai,CS.IDCapSo,CS.SoVanBan,CS.NgayKy FROM TblNLDTroCapThatNghiep AS TN";
            sql += " LEFT JOIN TblNguoiLaoDong AS P ON TN.IDNguoiLaoDong = P.IDNguoiLaoDong";
            sql += " LEFT JOIN tblTrangThaiHoSo AS TT ON TN.IdTrangThai = TT.id";
            sql += " Left join TblCapSo cs on cs.IDNLDTCTN=tn.IdNLDTCTN";
            sql += " Where (cs.IDLoaiVanBan=30  Or cs.IDLoaiVanBan is null) And (tn.NgayHenTraKQ between @TuNgay And @DenNgay) ";
            sql += " And (HoVaTen=@str Or CMND=@str Or BHXH=@str Or cast(cs.So as nvarchar)=@str Or SoVanBan=@str Or @str='')";
            sql += " And (TN.IdTrangThai=@IDTrangThai Or @IDTrangThai=0)";
            Cmd.CommandText = sql;
            Cmd.Parameters.Add("TuNgay", SqlDbType.DateTime).Value = TuNgay;
            Cmd.Parameters.Add("DenNgay", SqlDbType.DateTime).Value = DenNgay;
            Cmd.Parameters.Add("IDTrangThai", SqlDbType.NVarChar).Value = IDTrangThai;
            Cmd.Parameters.Add("str", SqlDbType.NVarChar).Value = searchKey;
            SqlDataAdapter da = new SqlDataAdapter(Cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            this.SQLClose();
            return ds.Tables[0];
        }
        catch (Exception ex)
        {
            this.Message = ex.Message;
            this.ErrorCode = ex.HResult;
            return null;
        }
    }

    #endregion 
    #region LuongToiThieu
    public DataTable GetLuongToiThieuByTienLuong(string TienLuong )
    {
        try
        {
            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "SELECT * FROM tblDanhMuc";
            Cmd.CommandText += " WHERE DanhMucId = @DanhMucId And cast(Note as nvarchar)=@TienLuong";
            Cmd.Parameters.Add("DanhMucId", SqlDbType.Int).Value = 19;
            Cmd.Parameters.Add("TienLuong", SqlDbType.NVarChar).Value = TienLuong;
            SqlDataAdapter da = new SqlDataAdapter(Cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            this.SQLClose();
            return ds.Tables[0];
        }
        catch (Exception ex)
        {
            this.Message = ex.Message;
            this.ErrorCode = ex.HResult;
            return null;
        }
    }
    #endregion
    #region Cap nhat trang thai ho so
    public int UpdateTrangThaiHS(int IDNLDTCTN, int IDTrangThaiHS)
    {
        int rows = 0;
        try
        {
            string sql = "Update TblNLDTroCapThatNghiep Set IdTrangThai=@TrangThaiHS Where IDNLDTCTN=@IDNLDTCTN";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sql;
            Cmd.Parameters.Add("IDNLDTCTN", SqlDbType.Int).Value = IDNLDTCTN;
            Cmd.Parameters.Add("TrangThaiHS", SqlDbType.Int).Value = IDTrangThaiHS;
            rows = Cmd.ExecuteNonQuery();        
            sqlCon.Close();
            sqlCon.Dispose();
        }
        catch (Exception ex)
        {
            this.Message = ex.Message;
            this.ErrorCode = ex.HResult;
            rows = 0;
        }
        return rows;
    }
    public int UpdateNguoiKy(int IDCapSo, DateTime NgayKyQD, int IDNguoiKy)
    {
        int rows = 0;
        try
        {
            string sql = "Update TblCapSo Set NgayKy=@NgayKy,IDNguoiKy=@IDNguoiKy Where IDCapSo=@IDCapSo";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sql;
            Cmd.Parameters.Add("IDCapSo", SqlDbType.Int).Value = IDCapSo;
            Cmd.Parameters.Add("NgayKy", SqlDbType.DateTime).Value = NgayKyQD;
            Cmd.Parameters.Add("IDNguoiKy", SqlDbType.Int).Value = IDNguoiKy;
            rows = Cmd.ExecuteNonQuery();
            sqlCon.Close();
            sqlCon.Dispose();
        }
        catch (Exception ex)
        {
            this.Message = ex.Message;
            this.ErrorCode = ex.HResult;
            rows = 0;
        }
        return rows;
    }
    
    #endregion     
    #region cap nhat so thang da huong
    public int UpdateSoThangDaHuong(int IDNLDTCTN,int SoThangDaHuongBHXH,DateTime? NgayDeXuatTamDung)
    {
        int rows = 0;
        if (!NgayDeXuatTamDung.HasValue)
        {
            NgayDeXuatTamDung=new DateTime(1900,1,1);
        }
        try
        {             
            string sql = "Update TblTinhHuong Set SoThangDaHuongBHXH=@SoThangDaHuongBHXH,NgayDeXuatTamDung=@NgayDeXuatTamDung Where IDNLDTCTN=@IDNLDTCTN";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sql;
            Cmd.Parameters.Add("IDNLDTCTN", SqlDbType.Int).Value = IDNLDTCTN;
            Cmd.Parameters.Add("SoThangDaHuongBHXH", SqlDbType.Int).Value = SoThangDaHuongBHXH;
            Cmd.Parameters.Add("NgayDeXuatTamDung", SqlDbType.DateTime).Value = NgayDeXuatTamDung;
            rows = Cmd.ExecuteNonQuery();
            sqlCon.Close();
            sqlCon.Dispose();
        }
        catch (Exception ex)
        {
            this.Message = ex.Message;
            this.ErrorCode = ex.HResult;
            rows = 0;
        }
        return rows;
       
    }
    public int UpdateSoThangDaHuong(int IDNLDTCTN, int SoThangDaHuongBHXH)
    {
        int rows = 0;    
        try
        {
            string sql = "Update TblTinhHuong Set SoThangDaHuongBHXH=@SoThangDaHuongBHXH Where IDNLDTCTN=@IDNLDTCTN";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sql;
            Cmd.Parameters.Add("IDNLDTCTN", SqlDbType.Int).Value = IDNLDTCTN;
            Cmd.Parameters.Add("SoThangDaHuongBHXH", SqlDbType.Int).Value = SoThangDaHuongBHXH;
            rows = Cmd.ExecuteNonQuery();
            sqlCon.Close();
            sqlCon.Dispose();
        }
        catch (Exception ex)
        {
            this.Message = ex.Message;
            this.ErrorCode = ex.HResult;
            rows = 0;
        }
        return rows;

    }
    public int UpdateSoThangDuocHuongConLai(int IDNLDTCTN, int SoThangDuocHuongConLaiBHXH)
    {
        int rows = 0;
        try
        {
            string sql = "Update TblTinhHuong Set SoThangDuocHuongConLaiBHXH=@SoThangDuocHuongConLaiBHXH Where IDNLDTCTN=@IDNLDTCTN";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sql;
            Cmd.Parameters.Add("IDNLDTCTN", SqlDbType.Int).Value = IDNLDTCTN;
            Cmd.Parameters.Add("SoThangDuocHuongConLaiBHXH", SqlDbType.Int).Value = SoThangDuocHuongConLaiBHXH;
            rows = Cmd.ExecuteNonQuery();
            sqlCon.Close();
            sqlCon.Dispose();
        }
        catch (Exception ex)
        {
            this.Message = ex.Message;
            this.ErrorCode = ex.HResult;
            rows = 0;
        }
        return rows;

    }
    public int UpdateSoThangDuocHuongConLai(int IDNLDTCTN, int SoThangDuocHuongConLaiBHXH, DateTime ? NgayDeXuatTiepTuc)
    {
        int rows = 0;
        if(!NgayDeXuatTiepTuc.HasValue)
        {
            NgayDeXuatTiepTuc = new DateTime(1900, 1, 1);
        }
        try
        {
            string sql = "Update TblTinhHuong Set SoThangDuocHuongConLaiBHXH=@SoThangDuocHuongConLaiBHXH, NgayDeXuatTiepTuc=@NgayDeXuatTiepTuc Where IDNLDTCTN=@IDNLDTCTN";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sql;
            Cmd.Parameters.Add("IDNLDTCTN", SqlDbType.Int).Value = IDNLDTCTN;
            Cmd.Parameters.Add("SoThangDuocHuongConLaiBHXH", SqlDbType.Int).Value = SoThangDuocHuongConLaiBHXH;
            Cmd.Parameters.Add("NgayDeXuatTiepTuc", SqlDbType.DateTime).Value = NgayDeXuatTiepTuc;
            rows = Cmd.ExecuteNonQuery();
            sqlCon.Close();
            sqlCon.Dispose();
        }
        catch (Exception ex)
        {
            this.Message = ex.Message;
            this.ErrorCode = ex.HResult;
            rows = 0;
        }
        return rows;

    }
    public int UpdateSoThangBaoLuuSauHuong(int IDNLDTCTN, int SoThangBaoLuuSauHuong, DateTime? NgayDeXuatChamDut)
    {
        int rows = 0;
        if (!NgayDeXuatChamDut.HasValue)
        {
            NgayDeXuatChamDut = new DateTime(1900, 1, 1);
        }
        try
        {
            string sql = "Update TblTinhHuong Set SoThangBaoLuuSauHuong=@SoThangBaoLuuSauHuong, NgayDeXuatChamDut=@NgayDeXuatChamDut Where IDNLDTCTN=@IDNLDTCTN";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sql;
            Cmd.Parameters.Add("IDNLDTCTN", SqlDbType.Int).Value = IDNLDTCTN;
            Cmd.Parameters.Add("SoThangBaoLuuSauHuong", SqlDbType.Int).Value = SoThangBaoLuuSauHuong;
            Cmd.Parameters.Add("NgayDeXuatChamDut", SqlDbType.DateTime).Value = NgayDeXuatChamDut;
            rows = Cmd.ExecuteNonQuery();
            sqlCon.Close();
            sqlCon.Dispose();
        }
        catch (Exception ex)
        {
            this.Message = ex.Message;
            this.ErrorCode = ex.HResult;
            rows = 0;
        }
        return rows;

    }
    #endregion
}