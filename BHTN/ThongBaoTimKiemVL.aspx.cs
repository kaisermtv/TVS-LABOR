using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Labor_TinhHuong : System.Web.UI.Page
{
    #region declare  
    public int itemId = 0;
    public int _index = 1;
    public string _msg="";
    public int _tg = 0;
    public int _status = 0; // 0 trang thai tinh huong  3 trang thai xem chi tiet theo doi lich thong bao
    #endregion

    #region Even Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ACCOUNT"] == null)
        {
            Response.Redirect("../Login.aspx");
        }
        if (Request.QueryString["id"] != null && Request.QueryString["id"].ToString().Trim() != "")
        {
            itemId= int.Parse(Request["id"].ToString());
        }
        if (Request.QueryString["tg"] != null && Request.QueryString["tg"].ToString().Trim() != "")
        {
            _tg = int.Parse(Request["tg"].ToString());
        }  
        if (!Page.IsPostBack)
        {
            Load_SoThangThongBao();
            // lay thong tin nguoi dung
           DataRow  rowTCTN=new NLDTroCapThatNghiep().getItem(itemId);
            int id = (int)rowTCTN["IDNguoiLaoDong"];
            DataTable tblNguoiLaoDong = new NguoiLaoDong().getDataById(id);
            if(tblNguoiLaoDong !=null && tblNguoiLaoDong.Rows.Count!=0)
            {
                lblHoTen.Text = tblNguoiLaoDong.Rows[0]["HoVaTen"].ToString();
                lblCMND.Text = tblNguoiLaoDong.Rows[0]["CMND"].ToString();
                lblSoBHXH.Text = tblNguoiLaoDong.Rows[0]["BHXH"].ToString();
            }
        }     
    }
    #endregion
    private void Load_CauHinh()
    {
        string MyDateTime = DateTime.Now.ToString("dd/MM/yyyy");       
      
    }
    List<ThongBaoViecLamHangThang> lstThongBaoViecLam = new List<ThongBaoViecLamHangThang>();
    private void Load_SoThangThongBao()
    {
        DataTable tblTinhHuong = new TinhHuong().getDataById(itemId);
        DataTable tblLichThongBao = new LichThongBao().GetDataByID(int.Parse(tblTinhHuong.Rows[0]["IDTinhHuong"].ToString()));
        for (int i = 1; i <= 12; i++)
        {
            string str = "Tháng ";
            if (((DateTime)tblLichThongBao.Rows[0]["KhaiBaoThang" + i.ToString() + "TuNgay"]).ToString("yyyy") != "1900")
            {
                str += i.ToString();
                str += " (" + (((DateTime)tblLichThongBao.Rows[0]["KhaiBaoThang" + i.ToString() + "TuNgay"]).ToString("dd/MM/yyyy"));
                if (i == 0)
                {
                    str += " )";
                }
                else
                {
                    if (((DateTime)tblLichThongBao.Rows[0]["KhaiBaoThang" + i.ToString() + "DenNgay"]).ToString("yyyy") != "1900")
                    {
                        str += " -> " + (((DateTime)tblLichThongBao.Rows[0]["KhaiBaoThang" + i.ToString() + "DenNgay"]).ToString("dd/MM/yyyy")) + ")";
                    }
                }
                ThongBaoViecLamHangThang item = new ThongBaoViecLamHangThang();
                item.ThangThongBao = str;
                lstThongBaoViecLam.Add(item);                
            }
        }
        rptLichThongBao.DataSource = lstThongBaoViecLam;
        rptLichThongBao.DataBind();
    }
    protected void btnDaKhaiBao_Click(object sender, EventArgs e)
    {

    }
    protected void btnKhongKhaiBao_Click(object sender, EventArgs e)
    {

    }
}