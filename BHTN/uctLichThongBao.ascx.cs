using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class uctLichThongBao : System.Web.UI.UserControl
{
    int _IDNLDTCTN = 0;
    public string _msg = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["ID"] != null && Request.QueryString["ID"].ToString().Trim() != "")
        {
            _IDNLDTCTN = int.Parse(Request.QueryString["ID"].ToString());
        }
       if(!Page.IsPostBack)
       {
           if (_IDNLDTCTN <= 0)
           {
               _msg = "Bạn chưa tính hưởng";
               return;
           }
           DataTable  TblTinhHuong = new TinhHuong().getDataById(_IDNLDTCTN);
           if (TblTinhHuong == null || TblTinhHuong.Rows.Count == 0)
           {              
               return;
           }
           DataTable TblNguoiLaoDong = new NguoiLaoDong().getDataById(int.Parse(TblTinhHuong.Rows[0]["IDNguoiLaoDong"].ToString()));
          if(TblNguoiLaoDong !=null && TblNguoiLaoDong.Rows.Count>0)
          {
              txtHoTen.Text = TblNguoiLaoDong.Rows[0]["HoVaTen"].ToString();
              txtSoThangHuong.Text = TblTinhHuong.Rows[0]["SoThangHuongBHXH"].ToString();
              txtHuongTuNgay.Text = ((DateTime)TblTinhHuong.Rows[0]["HuongTuNgay"]).ToString("dd/MM/yyyy");
              txtHuongDenNgay.Text = ((DateTime)TblTinhHuong.Rows[0]["HuongDenNgay"]).ToString("dd/MM/yyyy");
          }
          hdIDTinhHuong.Value = TblTinhHuong.Rows[0]["IDTinhHuong"].ToString();
          hdIDNguoiLaoDong.Value = TblTinhHuong.Rows[0]["IDNguoiLaoDong"].ToString();
          DataTable TblLichThongBao = new LichThongBao().GetDataByID((int)TblTinhHuong.Rows[0]["IDTinhHuong"]);
          if (TblLichThongBao != null && TblLichThongBao.Rows.Count > 0)
          {
              if (((DateTime)TblLichThongBao.Rows[0]["KhaiBaoThang1TuNgay"]).ToString("yyyy") != "1900")
              {
                  txtKhaiBaoThangThuNhat.Value = ((DateTime)TblLichThongBao.Rows[0]["KhaiBaoThang1TuNgay"]).ToString("dd/MM/yyyy");
              }
              if (((DateTime)TblLichThongBao.Rows[0]["KhaiBaoThang2TuNgay"]).ToString("yyyy") != "1900")
              {
                  txtKhaiBaoThang2TuNgay.Value = ((DateTime)TblLichThongBao.Rows[0]["KhaiBaoThang2TuNgay"]).ToString("dd/MM/yyyy");

              }
              if (((DateTime)TblLichThongBao.Rows[0]["KhaiBaoThang2DenNgay"]).ToString("yyyy") != "1900")
              {
                  txtKhaiBaoThang2DenNgay.Value = ((DateTime)TblLichThongBao.Rows[0]["KhaiBaoThang2DenNgay"]).ToString("dd/MM/yyyy");

              }
              if (((DateTime)TblLichThongBao.Rows[0]["KhaiBaoThang3TuNgay"]).ToString("dd/MM/yyyy") != "01/01/1900")
              {
                  txtKhaiBaoThang3TuNgay.Value = ((DateTime)TblLichThongBao.Rows[0]["KhaiBaoThang3TuNgay"]).ToString("dd/MM/yyyy");

              }
              if (((DateTime)TblLichThongBao.Rows[0]["KhaiBaoThang3DenNgay"]).ToString("yyyy") != "1900")
              {
                  txtKhaiBaoThang3Denngay.Value = ((DateTime)TblLichThongBao.Rows[0]["KhaiBaoThang3DenNgay"]).ToString("dd/MM/yyyy");

              }
              if (((DateTime)TblLichThongBao.Rows[0]["KhaiBaoThang4TuNgay"]).ToString("yyyy") != "1900")
              {
                  txtKhaiBaoThang4TuNgay.Value = ((DateTime)TblLichThongBao.Rows[0]["KhaiBaoThang4TuNgay"]).ToString("dd/MM/yyyy");

              }
              if (((DateTime)TblLichThongBao.Rows[0]["KhaiBaoThang4DenNgay"]).ToString("yyyy") != "1900")
              {
                  txtKhaiBaoThang4DenNgay.Value = ((DateTime)TblLichThongBao.Rows[0]["KhaiBaoThang4DenNgay"]).ToString("dd/MM/yyyy");

              }
              if (((DateTime)TblLichThongBao.Rows[0]["KhaiBaoThang5TuNgay"]).ToString("yyyy") != "1900")
              {
                  txtKhaiBaoThang5TuNgay.Value = ((DateTime)TblLichThongBao.Rows[0]["KhaiBaoThang5TuNgay"]).ToString("dd/MM/yyyy");

              }
              if (((DateTime)TblLichThongBao.Rows[0]["KhaiBaoThang5DenNgay"]).ToString("yyyy") != "1900")
              {
                  txtKhaiBaoThang5DenNgay.Value = ((DateTime)TblLichThongBao.Rows[0]["KhaiBaoThang5DenNgay"]).ToString("dd/MM/yyyy");

              }
              if (((DateTime)TblLichThongBao.Rows[0]["KhaiBaoThang6TuNgay"]).ToString("yyyy") != "1900")
              {
                  txtKhaiBaoThang6TuNgay.Value = ((DateTime)TblLichThongBao.Rows[0]["KhaiBaoThang6TuNgay"]).ToString("dd/MM/yyyy");

              }
              if (((DateTime)TblLichThongBao.Rows[0]["KhaiBaoThang6DenNgay"]).ToString("yyyy") != "1900")
              {
                  txtKhaiBaoThang6DenNgay.Value = ((DateTime)TblLichThongBao.Rows[0]["KhaiBaoThang6DenNgay"]).ToString("dd/MM/yyyy");

              }
              if (((DateTime)TblLichThongBao.Rows[0]["KhaiBaoThang7TuNgay"]).ToString("yyyy") != "1900")
              {
                  txtKhaiBaoThang7TuNgay.Value = ((DateTime)TblLichThongBao.Rows[0]["KhaiBaoThang7TuNgay"]).ToString("dd/MM/yyyy");

              }
              if (((DateTime)TblLichThongBao.Rows[0]["KhaiBaoThang7DenNgay"]).ToString("yyyy") != "1900")
              {
                  txtKhaiBaoThang7DenNgay.Value = ((DateTime)TblLichThongBao.Rows[0]["KhaiBaoThang7DenNgay"]).ToString("dd/MM/yyyy");

              }
              if (((DateTime)TblLichThongBao.Rows[0]["KhaiBaoThang8TuNgay"]).ToString("yyyy") != "1900")
              {
                  txtKhaiBaoThang8TuNgay.Value = ((DateTime)TblLichThongBao.Rows[0]["KhaiBaoThang8TuNgay"]).ToString("dd/MM/yyyy");

              }
              if (((DateTime)TblLichThongBao.Rows[0]["KhaiBaoThang8DenNgay"]).ToString("yyyy") != "1900")
              {
                  txtKhaiBaoThang8DenNgay.Value = ((DateTime)TblLichThongBao.Rows[0]["KhaiBaoThang8DenNgay"]).ToString("dd/MM/yyyy");

              }
              if (((DateTime)TblLichThongBao.Rows[0]["KhaiBaoThang9TuNgay"]).ToString("yyyy") != "1900")
              {
                  txtKhaiBaoThang9TuNgay.Value = ((DateTime)TblLichThongBao.Rows[0]["KhaiBaoThang9TuNgay"]).ToString("dd/MM/yyyy");
              }
              if (((DateTime)TblLichThongBao.Rows[0]["KhaiBaoThang9DenNgay"]).ToString("yyyy") != "1900")
              {
                  txtKhaiBaoThang9DenNgay.Value = ((DateTime)TblLichThongBao.Rows[0]["KhaiBaoThang9DenNgay"]).ToString("dd/MM/yyyy");
              }
              if (((DateTime)TblLichThongBao.Rows[0]["KhaiBaoThang10TuNgay"]).ToString("yyyy") != "1900")
              {
                  txtKhaiBaoThang10TuNgay.Value = ((DateTime)TblLichThongBao.Rows[0]["KhaiBaoThang10TuNgay"]).ToString("dd/MM/yyyy");

              }
              if (((DateTime)TblLichThongBao.Rows[0]["KhaiBaoThang10DenNgay"]).ToString("yyyy") != "1900")
              {
                  txtKhaiBaoThang10DenNgay.Value = ((DateTime)TblLichThongBao.Rows[0]["KhaiBaoThang10DenNgay"]).ToString("dd/MM/yyyy");

              }
              if (((DateTime)TblLichThongBao.Rows[0]["KhaiBaoThang11TuNgay"]).ToString("yyyy") != "1900")
              {
                  txtKhaiBaoThang11TuNgay.Value = ((DateTime)TblLichThongBao.Rows[0]["KhaiBaoThang11TuNgay"]).ToString("dd/MM/yyyy");

              }
              if (((DateTime)TblLichThongBao.Rows[0]["KhaiBaoThang11DenNgay"]).ToString("yyyy") != "1900")
              {
                  txtKhaiBaoThang11DenNgay.Value = ((DateTime)TblLichThongBao.Rows[0]["KhaiBaoThang11DenNgay"]).ToString("dd/MM/yyyy");

              }
              if (((DateTime)TblLichThongBao.Rows[0]["KhaiBaoThang12TuNgay"]).ToString("yyyy") != "1900")
              {
                  txtKhaiBaoThang12TuNgay.Value = ((DateTime)TblLichThongBao.Rows[0]["KhaiBaoThang12TuNgay"]).ToString("dd/MM/yyyy");
              }
              if (((DateTime)TblLichThongBao.Rows[0]["KhaiBaoThang12TuNgay"]).ToString("yyyy") != "1900")
              {
                  txtKhaiBaoThang12DenNgay.Value = ((DateTime)TblLichThongBao.Rows[0]["KhaiBaoThang12DenNgay"]).ToString("dd/MM/yyyy");

              }
          }
       }
    }    
    protected void btnCapNhat_Click(object sender, EventArgs e)
    {
        LichThongBao objLichThongBao = new LichThongBao();
        objLichThongBao.IDTinhHuong = int.Parse(hdIDTinhHuong.Value);
        objLichThongBao.IDNguoiLaoDong = int.Parse(hdIDNguoiLaoDong.Value);
        objLichThongBao.KhaiBaoThang1TuNgay = ConvertDateimeUS(txtKhaiBaoThangThuNhat.Value);
        objLichThongBao.KhaiBaoThang1DenNgay = ConvertDateimeUS(txtKhaiBaoThangThuNhat.Value);
        objLichThongBao.KhaiBaoThang2TuNgay = ConvertDateimeUS(txtKhaiBaoThang2TuNgay.Value);
        objLichThongBao.KhaiBaoThang2DenNgay = ConvertDateimeUS(txtKhaiBaoThang2DenNgay.Value);
        objLichThongBao.KhaiBaoThang3TuNgay = ConvertDateimeUS(txtKhaiBaoThang3TuNgay.Value);
        objLichThongBao.KhaiBaoThang3DenNgay = ConvertDateimeUS(txtKhaiBaoThang3Denngay.Value);
        objLichThongBao.KhaiBaoThang4TuNgay = ConvertDateimeUS(txtKhaiBaoThang4TuNgay.Value);
        objLichThongBao.KhaiBaoThang4DenNgay = ConvertDateimeUS(txtKhaiBaoThang4DenNgay.Value);
        objLichThongBao.KhaiBaoThang5TuNgay = ConvertDateimeUS(txtKhaiBaoThang5TuNgay.Value);
        objLichThongBao.KhaiBaoThang5DenNgay = ConvertDateimeUS(txtKhaiBaoThang5DenNgay.Value);
        objLichThongBao.KhaiBaoThang6TuNgay = ConvertDateimeUS(txtKhaiBaoThang6TuNgay.Value);
        objLichThongBao.KhaiBaoThang6DenNgay = ConvertDateimeUS(txtKhaiBaoThang6DenNgay.Value);
        objLichThongBao.KhaiBaoThang7TuNgay = ConvertDateimeUS(txtKhaiBaoThang7TuNgay.Value);
        objLichThongBao.KhaiBaoThang7DenNgay = ConvertDateimeUS(txtKhaiBaoThang7DenNgay.Value);
        objLichThongBao.KhaiBaoThang8TuNgay = ConvertDateimeUS(txtKhaiBaoThang8TuNgay.Value);
        objLichThongBao.KhaiBaoThang8DenNgay = ConvertDateimeUS(txtKhaiBaoThang4DenNgay.Value);
        objLichThongBao.KhaiBaoThang9TuNgay = ConvertDateimeUS(txtKhaiBaoThang9TuNgay.Value);
        objLichThongBao.KhaiBaoThang9DenNgay = ConvertDateimeUS(txtKhaiBaoThang9DenNgay.Value);
        objLichThongBao.KhaiBaoThang10TuNgay = ConvertDateimeUS(txtKhaiBaoThang10TuNgay.Value);
        objLichThongBao.KhaiBaoThang10DenNgay = ConvertDateimeUS(txtKhaiBaoThang10DenNgay.Value);
        objLichThongBao.KhaiBaoThang11TuNgay = ConvertDateimeUS(txtKhaiBaoThang11TuNgay.Value);
        objLichThongBao.KhaiBaoThang11DenNgay = ConvertDateimeUS(txtKhaiBaoThang11DenNgay.Value);
        objLichThongBao.KhaiBaoThang12TuNgay = ConvertDateimeUS(txtKhaiBaoThang12TuNgay.Value);
        objLichThongBao.KhaiBaoThang12DenNgay = ConvertDateimeUS(txtKhaiBaoThang12DenNgay.Value);
        objLichThongBao.setData(objLichThongBao.IDLichThongBao, objLichThongBao.IDNguoiLaoDong, objLichThongBao.IDTinhHuong
         , objLichThongBao.KhaiBaoThang1TuNgay, objLichThongBao.KhaiBaoThang1DenNgay
         , objLichThongBao.KhaiBaoThang2TuNgay, objLichThongBao.KhaiBaoThang2DenNgay
         , objLichThongBao.KhaiBaoThang3TuNgay, objLichThongBao.KhaiBaoThang3DenNgay
         , objLichThongBao.KhaiBaoThang4TuNgay, objLichThongBao.KhaiBaoThang4DenNgay
         , objLichThongBao.KhaiBaoThang5TuNgay, objLichThongBao.KhaiBaoThang5DenNgay
         , objLichThongBao.KhaiBaoThang6TuNgay, objLichThongBao.KhaiBaoThang6DenNgay
         , objLichThongBao.KhaiBaoThang7TuNgay, objLichThongBao.KhaiBaoThang7DenNgay
         , objLichThongBao.KhaiBaoThang8TuNgay, objLichThongBao.KhaiBaoThang8DenNgay
         , objLichThongBao.KhaiBaoThang9TuNgay, objLichThongBao.KhaiBaoThang9DenNgay
         , objLichThongBao.KhaiBaoThang10TuNgay, objLichThongBao.KhaiBaoThang10DenNgay
         , objLichThongBao.KhaiBaoThang11TuNgay, objLichThongBao.KhaiBaoThang11DenNgay
         , objLichThongBao.KhaiBaoThang12TuNgay, objLichThongBao.KhaiBaoThang12DenNgay);
        _msg = "Cập nhật thành công";
   
   
   
   
    }
    private DateTime ConvertDateimeUS(string DateVN)
    {
        DateTime Date = new DateTime(1900, 1, 1);
        try
        {
            string[] str = DateVN.Split('/');
            Date =new  DateTime(int.Parse(str[2]), int.Parse(str[1]), int.Parse(str[0]));
        }
        catch(Exception ex)
        {
                 Date =new DateTime(1900,1,1);
        }
        return Date;
    }
    private string ConvertDatetimeVn(DateTime DateUS)
    {
        return DateUS.Day.ToString() + "/" + DateUS.Month.ToString() + "/" + DateUS.Year.ToString();
    }
}