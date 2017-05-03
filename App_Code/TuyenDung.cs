using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class TuyenDung :DataClass
{
    #region method TuyenDung
    public TuyenDung()
    {
    } 
    #endregion

    #region method setData
    public int setData(ref int IDTuyenDung, int IDDonVi, int IDNhomNghanh, int IDViTri, int IDChucVu, int IDNganhNghe, int SoLuongTuyenDung, int IDDoTuoi, int IDGioiTinh, int IDTrinhDoChuyenMon, string UuTien, string NoiDungKhac, string MoTa, int IDMucLuong, string DiaDiem, int IDTinh, bool NuocNgoai, string QuyenLoi, DateTime NgayBatDau, DateTime NgayKetThuc, bool State, int YCTinHoc, int YCNgoaiNgu, String NamKinhNghiem, int ThoiGianLamviec, int IdTrinhDoTinHoc, int IdTrinhDoNgoaiNgu)
    {
        int tmpValue = 0;

        try
        {
            string sqlQuery = "";

            sqlQuery = "IF NOT EXISTS (SELECT * FROM TblTuyenDung WHERE IDTuyenDung = @IDTuyenDung) ";
            sqlQuery += "BEGIN INSERT INTO TblTuyenDung(MaTuyenDung,IDDonVi,IDNhomNghanh,IdViTri,IDChucVu,IDNganhNghe,SoLuongTuyenDung,IDDoTuoi,IDGioiTinh,IDTrinhDoChuyenMon,UuTien,NoiDungKhac,MoTa,IDMucLuong,DiaDiem,IDTinh,NuocNgoai,QuyenLoi,NgayBatDau,NgayKetThuc,State,YCNgoaiNgu,YCTinHoc,NamKinhNghiem,ThoiGianLamViec,IdTrinhDoTinHoc,IdTrinhDoNgoaiNgu) OUTPUT INSERTED.IDTuyenDung VALUES(@MaTuyenDung,@IDDonVi,@IDNhomNghanh,@IdViTri,@IDChucVu,@IDNganhNghe,@SoLuongTuyenDung,@IDDoTuoi,@IDGioiTinh,@IDTrinhDoChuyenMon,@UuTien,@NoiDungKhac,@MoTa,@IDMucLuong,@DiaDiem,@IDTinh,@NuocNgoai,@QuyenLoi,@NgayBatDau,@NgayKetThuc,@State,@YCNgoaiNgu,@YCTinHoc,@NamKinhNghiem,@ThoiGianLamViec,@IdTrinhDoTinHoc,@IdTrinhDoNgoaiNgu) END ";
            sqlQuery += "ELSE BEGIN UPDATE TblTuyenDung SET IDDonVi = @IDDonVi, IDNhomNghanh = @IDNhomNghanh,IdViTri = @IdViTri, IDChucVu = @IDChucVu,IDNganhNghe = @IDNganhNghe,SoLuongTuyenDung = @SoLuongTuyenDung,IDDoTuoi = @IDDoTuoi,IDGioiTinh = @IDGioiTinh,IDTrinhDoChuyenMon = @IDTrinhDoChuyenMon,UuTien = @UuTien,NoiDungKhac = @NoiDungKhac,MoTa = @MoTa,IDMucLuong = @IDMucLuong,DiaDiem = @DiaDiem, IDTinh = @IDTinh, NuocNgoai = @NuocNgoai,QuyenLoi = @QuyenLoi,NgayBatDau = @NgayBatDau,NgayKetThuc = @NgayKetThuc,State = @State,YCNgoaiNgu = @YCNgoaiNgu,YCTinHoc = @YCTinHoc,NamKinhNghiem = @NamKinhNghiem,ThoiGianLamViec = @ThoiGianLamViec, IdTrinhDoTinHoc = @IdTrinhDoTinHoc, IdTrinhDoNgoaiNgu = @IdTrinhDoNgoaiNgu OUTPUT INSERTED.IDTuyenDung WHERE IDTuyenDung = @IDTuyenDung END ";
            
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;
            
            string MaTuyenDung = "";

            if (IDTuyenDung == 0)
            {
                MaTuyenDung = this.getNextMaTuyenDung();
            }

            Cmd.Parameters.Add("IDTuyenDung", SqlDbType.Int).Value = IDTuyenDung;
            Cmd.Parameters.Add("MaTuyenDung", SqlDbType.NVarChar).Value = MaTuyenDung;
            Cmd.Parameters.Add("IDDonVi", SqlDbType.Int).Value = IDDonVi;
            Cmd.Parameters.Add("IDNhomNghanh", SqlDbType.Int).Value = IDNhomNghanh;
            Cmd.Parameters.Add("IDChucVu", SqlDbType.Int).Value = IDChucVu;
            Cmd.Parameters.Add("IdViTri", SqlDbType.Int).Value = IDViTri;

            Cmd.Parameters.Add("IDNganhNghe", SqlDbType.Int).Value = IDNganhNghe;
            Cmd.Parameters.Add("SoLuongTuyenDung", SqlDbType.Int).Value = SoLuongTuyenDung;
            Cmd.Parameters.Add("IDDoTuoi", SqlDbType.Int).Value = IDDoTuoi;
            Cmd.Parameters.Add("IDGioiTinh", SqlDbType.Int).Value = IDGioiTinh;
            Cmd.Parameters.Add("IDTrinhDoChuyenMon", SqlDbType.Int).Value = IDTrinhDoChuyenMon;
            
            Cmd.Parameters.Add("UuTien", SqlDbType.NVarChar).Value = UuTien;
            Cmd.Parameters.Add("NoiDungKhac", SqlDbType.NVarChar).Value = NoiDungKhac;
            Cmd.Parameters.Add("MoTa", SqlDbType.NVarChar).Value = MoTa;
            Cmd.Parameters.Add("IDMucLuong", SqlDbType.Int).Value = IDMucLuong;
            Cmd.Parameters.Add("DiaDiem", SqlDbType.NVarChar).Value = DiaDiem;
            
            Cmd.Parameters.Add("IDTinh", SqlDbType.NVarChar).Value = IDTinh;
            Cmd.Parameters.Add("NuocNgoai", SqlDbType.Bit).Value = NuocNgoai;
            Cmd.Parameters.Add("QuyenLoi", SqlDbType.NVarChar).Value = QuyenLoi;
            Cmd.Parameters.Add("NgayBatDau", SqlDbType.DateTime).Value = NgayBatDau;
            Cmd.Parameters.Add("NgayKetThuc", SqlDbType.DateTime).Value = NgayKetThuc;

            Cmd.Parameters.Add("YCNgoaiNgu", SqlDbType.Int).Value = YCNgoaiNgu;
            Cmd.Parameters.Add("YCTinHoc", SqlDbType.Int).Value = YCTinHoc;
            Cmd.Parameters.Add("NamKinhNghiem", SqlDbType.NVarChar).Value = NamKinhNghiem;
            Cmd.Parameters.Add("ThoiGianLamViec", SqlDbType.Int).Value = ThoiGianLamviec;

            Cmd.Parameters.Add("IdTrinhDoTinHoc", SqlDbType.Int).Value = IdTrinhDoTinHoc;
            Cmd.Parameters.Add("IdTrinhDoNgoaiNgu", SqlDbType.Int).Value = IdTrinhDoNgoaiNgu;

            Cmd.Parameters.Add("State", SqlDbType.Bit).Value = State;

            IDTuyenDung = (int)Cmd.ExecuteScalar();

            //if (IDTuyenDung == 0)
            //{
            //    sqlQuery = "SELECT TOP 1 IDTuyenDung FROM TblTuyenDung WHERE IDDonVi = @IDDonVi ORDER BY IDTuyenDung DESC";
            //    Cmd.CommandText = sqlQuery;
            //    SqlDataReader Rd = Cmd.ExecuteReader();
            //    while(Rd.Read())
            //    {
            //        IDTuyenDung = int.Parse(Rd["IDTuyenDung"].ToString());
            //    }
            //    Rd.Close();
            //}

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

    #region method setThuTuUuTien
    public void setThuTuUuTien(int IDTuyenDung)
    {
        try
        {
            string sqlQuery = "";
            sqlQuery = "UPDATE TblTuyenDung SET ThuTuUuTien = (SELECT MAX(ISNULL(ThuTuUuTien,0)) FROM TblTuyenDung WHERE IDTuyenDung <> @IDTuyenDung) + 1 WHERE IDTuyenDung = @IDTuyenDung";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("IDTuyenDung", SqlDbType.Int).Value = IDTuyenDung;
            Cmd.ExecuteNonQuery();
            sqlCon.Close();
            sqlCon.Dispose();
        }
        catch
        {
        }
    }
    #endregion

    #region Method getList
    public DataTable getList(string searchKey = "", int IdViTri = 0, int IdMucLuong = 0, string TenDonVi = "", string sVitri = "", string sMucLuong = "", string sDiaDiem = "", string NuocNgoai = "")
    {
        try
        {
            string sqlQueryViTri = "", sqlQueryMucLuong = "", sqlQueryDiaDiem = "", sqlQueryNuocNgoai = "";
            
            if (sVitri != "")
            {
                string[] strVitri = sVitri.Split(';');
                if (strVitri.Length > 0)
                {
                    for (int i = 0; i < strVitri.Length; i++)
                    {
                        if (strVitri[i].Trim() != ";")
                        {
                            if (i == 0)
                            {
                                sqlQueryViTri = " AND (A.IdViTri IN (SELECT Id FROM tblViTri WHERE UPPER(NameVitri) LIKE N'%" + strVitri[i].ToUpper() + "%')";
                            }
                            else
                            {
                                sqlQueryViTri += " OR (A.IdViTri IN (SELECT Id FROM tblViTri WHERE UPPER(NameVitri) LIKE N'%" + strVitri[i].ToUpper() + "%'))";
                            }
                            if (i == strVitri.Length-1)
                            {
                                sqlQueryViTri += ")";
                            }
                        }
                    }
                }
            }

            if (sMucLuong != "")
            {
                double tmpMucLuong = 0;
                try
                {
                    tmpMucLuong = double.Parse(sMucLuong);
                }
                catch
                {
                    tmpMucLuong = 0;
                }
                sqlQueryMucLuong = " AND A.IDMucLuong IN (SELECT IDMucluong FROM TblMucLuong WHERE " + tmpMucLuong + " BETWEEN MinValue AND MaxValue)";
            }

            if (sDiaDiem.Trim() != "")
            {
                sqlQueryDiaDiem = " AND UPPER(A.DiaDiem) LIKE N'%"+sDiaDiem.ToUpper()+"%'";
            }

            if (NuocNgoai != "")//"" Tat ca, 1 Nuoc ngoai, 0 Trong nuoc
            {
                if (NuocNgoai == "1")
                {
                    sqlQueryNuocNgoai = " AND ISNULL(A.NuocNgoai,0) = 1";
                }
                else if (NuocNgoai == "0")
                {
                    sqlQueryNuocNgoai = " AND ISNULL(A.NuocNgoai,0) = 0";
                }
            }

            SqlCommand Cmd = this.getSQLConnect();
            Cmd.CommandText = "SELECT A.IDTuyenDung,B.IDDonVi,A.IdViTri,A.NgayBatDau,B.TenDonVi,V.NameVitri,A.SoLuongTuyenDung,L.NameMucLuong,A.DiaDiem,A.State,ISNULL((SELECT Count(*) FROM TblNldGioiThieu WHERE IDTuyenDung = A.IDTuyenDung),'') AS CountItem FROM TblTuyenDung AS A";
            Cmd.CommandText += " INNER JOIN TblDoanhNghiep AS B ON A.IDDonVi = B.IDDonVi";
            Cmd.CommandText += " LEFT JOIN tblViTri AS V ON A.IDChucVu = V.ID";
            Cmd.CommandText += " LEFT JOIN TblMucLuong AS L ON A.IDMucLuong = L.IDMucLuong";
            Cmd.CommandText += " WHERE ISNULL(A.State,0) = 1";

            if(searchKey != null && searchKey != "")
            {
                Cmd.CommandText += " AND UPPER(RTRIM(LTRIM(A.MoTa))) LIKE N'%'+UPPER(RTRIM(LTRIM(@SearchKey)))+'%'";
                Cmd.Parameters.Add("SearchKey", SqlDbType.NVarChar).Value = searchKey;
            }

            if (IdViTri > 0)
            {
                Cmd.CommandText += "  AND A.IdViTri = @IdViTri";
                Cmd.Parameters.Add("IdViTri", SqlDbType.Int).Value = IdViTri;
            }

            if (IdMucLuong > 0)
            {
                Cmd.CommandText += "  AND A.IDMucLuong = @IDMucLuong";
                Cmd.Parameters.Add("IDMucLuong", SqlDbType.Int).Value = IdMucLuong;
            }

            if (TenDonVi != null && TenDonVi != "")
            {
                Cmd.CommandText += "  AND B.TenDonVi = @TenDonVi";
                Cmd.Parameters.Add("TenDonVi", SqlDbType.NVarChar).Value = TenDonVi;
            }

            Cmd.CommandText += sqlQueryViTri;

            Cmd.CommandText += sqlQueryMucLuong;

            Cmd.CommandText += sqlQueryDiaDiem;

            Cmd.CommandText += sqlQueryNuocNgoai;

            Cmd.CommandText += " ORDER BY A.ThuTuUuTien DESC, A.IDTuyenDung DESC";

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

    #region method getData
    public DataTable getData(string searchKey, int IdChucVu, int IdMucLuong, string TenDonVi)
    {
        string sqlQuery = "", sqlQueryChucVu = "", sqlQueryMucLuong = "", sqlQueryTenDonVi = "";
        if (searchKey.Trim() != "")
        {
            sqlQuery += " AND UPPER(RTRIM(LTRIM(A.MoTa))) LIKE N'%'+UPPER(RTRIM(LTRIM(@SearchKey)))+'%'";
        }
        if (IdChucVu > 0)
        {
            sqlQueryChucVu = " AND A.IdChucVu = " + IdChucVu;
        }
        if (IdMucLuong > 0)
        {
            sqlQueryMucLuong = " AND A.IdMucLuong = " + IdMucLuong;
        }
        if (TenDonVi.Trim() != "")
        {
            sqlQueryTenDonVi = " AND B.TenDonVi = @TenDonVi";
        }
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.Parameters.Add("SearchKey", SqlDbType.NVarChar).Value = searchKey;
            Cmd.CommandText = "SELECT 0 AS TT, A.IDTuyenDung, A.MaTuyenDung, A.SoLuongTuyenDung, B.TenDonVi, A.Mota, A.IDDonVi, A.IDChucVu, REPLACE(REPLACE(CAST(A.State AS varchar),'1',N'Kích hoạt'),'0',N'Đóng') AS StateName,  (SELECT NameChucVu FROM TblChucVu WHERE IDChucVu = A.IDChucVu) AS NameChucVu,  (SELECT NameMucLuong FROM TblMucLuong WHERE IDMucLuong = A.IDMucLuong) AS NameMucLuong, REPLACE(REPLACE(CAST(A.NuocNgoai AS varchar),'1',N'Nước ngoài'),'0',N'Trong nước') AS NuocNgoaiName, ISNULL((SELECT Count(*) FROM TblNldGioiThieu WHERE IDTuyenDung = A.IDTuyenDung),'') AS CountItem FROM TblTuyenDung A, TblDoanhNghiep B WHERE A.IDDonVi = B.IDDonVi " + sqlQuery + sqlQueryChucVu + sqlQueryMucLuong + sqlQueryTenDonVi + " AND ISNULL(A.State,0) = 1 ORDER BY A.ThuTuUuTien DESC, A.IDTuyenDung DESC";
            Cmd.Parameters.Add("TenDonVi", SqlDbType.NVarChar).Value = TenDonVi;
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

    #region method getDataCount
    public int getDataCount(bool NuocNgoai)
    {
        int tmpCount = 0;
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.Parameters.Add("NuocNgoai", SqlDbType.Bit).Value = NuocNgoai;
            Cmd.CommandText = "SELECT COUNT(*) AS CountItem FROM TblTuyenDung WHERE NuocNgoai = @NuocNgoai";
            SqlDataReader Rd = Cmd.ExecuteReader();
            while(Rd.Read())
            {
                tmpCount = int.Parse(Rd["CountItem"].ToString());
            }
            Rd.Close();
            sqlCon.Close();
            sqlCon.Dispose();
        }
        catch
        {

        }
        return tmpCount;
    }
    #endregion

    #region method getDataTuVanXuatKhau
    public DataTable getDataTuVanXuatKhau(string searchKey)
    {
        string sqlQuery = "";
        if (searchKey.Trim() != "")
        {
            sqlQuery += " AND UPPER(RTRIM(LTRIM(MoTa))) LIKE N'%'+UPPER(RTRIM(LTRIM(@SearchKey)))+'%'";
        }
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.Parameters.Add("SearchKey", SqlDbType.NVarChar).Value = searchKey;
            Cmd.CommandText = "SELECT 0 AS TT, *, REPLACE(REPLACE(CAST(TblTuyenDung.State AS varchar),'1',N'Kích hoạt'),'0',N'Đóng') AS StateName, (SELECT NameChucVu FROM TblChucVu WHERE IDChucVu = TblTuyenDung.IDChucVu) AS NameChucVu FROM TblTuyenDung, TblDoanhNghiep WHERE TblTuyenDung.IDDonVi = TblDoanhNghiep.IDDonVi AND TblTuyenDung.State = 1 " + sqlQuery + " ORDER ThuTuUuTien DESC";
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
    public DataTable getDataById(int IDTuyenDung)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT *, (SELECT TenDonVi FROM TblDoanhNghiep WHERE IDDonVi = TblTuyenDung.IDDonVi) AS TenDonVi FROM TblTuyenDung WHERE IDTuyenDung = @IDTuyenDung";
            Cmd.Parameters.Add("IDTuyenDung", SqlDbType.Int).Value = IDTuyenDung;
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
    public void delData(int IDTuyenDung)
    {
        try
        {
            string sqlQuery = "";
            sqlQuery = "DELETE TblTuyenDung WHERE IDTuyenDung = @IDTuyenDung ";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("IDTuyenDung", SqlDbType.Int).Value = IDTuyenDung;
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
    public bool checkCode(string MaTuyenDung)
    {
        bool tmpValue = false;
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT * FROM TblTuyenDung WHERE MaTuyenDung = @MaTuyenDung";
            Cmd.Parameters.Add("MaTuyenDung", SqlDbType.NVarChar).Value = MaTuyenDung;
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

    #region method getNextMaTuyenDung
    public string getNextMaTuyenDung()
    {
        string tmpMaTuyenDung = "";
        try
        {
            int tmpCount = 0;
            string sqlQuery = "";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            sqlQuery = "SELECT ISNULL(COUNT(*),0) AS CountItem FROM TblTuyenDung WHERE ISNULL(MaTuyenDung,'') <> '' and LEN(MaTuyenDung) >=9";
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
                sqlQuery = "SELECT TOP 1 CAST(SUBSTRING(MaTuyenDung,10,(LEN(MaTuyenDung)-9)) AS Int) AS MaxItem FROM dbo.TblTuyenDung WHERE ISNULL(MaTuyenDung,'') <> '' and LEN(MaTuyenDung) >=9 ORDER BY CAST(SUBSTRING(MaTuyenDung,10,(LEN(MaTuyenDung)-9)) AS Int) DESC";
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
            tmpMaTuyenDung = "TD"+DateTime.Now.ToString("yyMMdd") + "-" + tmpCount.ToString("000");
        }
        catch
        {

        }
        return tmpMaTuyenDung;
    }
    #endregion
}