using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Labor_BaoCaoTongHop: System.Web.UI.Page
{
    #region declare
    public int index = 1;
    public string _msg = "";

    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ACCOUNT"] == null)
        {
            Response.Redirect("../Login.aspx");
        }         
        if(!Page.IsPostBack)
        {        
            Load_CauHinh();            
            Load_TrangThai();
            Load_DanhSachHoSo();
        }             
    }
    private void Load_DanhSachHoSo(string Ids = ",26,")
    {
        string str = txtSearch.Value.Trim();
        DateTime TuNgay = new DateTime(1900, 1, 1), DenNgay = new DateTime(9999, 1, 1);
        if(txtTuNgay.Value.Trim()!="")
        {
            TuNgay = Convert.ToDateTime(txtTuNgay.Value, new CultureInfo("vi-VN"));
        }
        if(txtDenNgay.Value.Trim()!="")
        {
            DenNgay = Convert.ToDateTime(txtDenNgay.Value, new CultureInfo("vi-VN"));
        }
        DataTable objData = new BaoCao().DanhSachLaoDongHuongTCTN(TuNgay, DenNgay);
        cpData.MaxPages = 1000;
        cpData.PageSize = 12;
        cpData.DataSource = objData.DefaultView;
        cpData.BindToControl = dtlData;
        dtlData.DataSource = cpData.DataSourcePaged;
        dtlData.DataBind();
    }
   
    private void Load_CauHinh()
    {
        DateTime myDatetime = DateTime.Now;
        string MyDate = myDatetime.Day.ToString() + "/" + myDatetime.Month.ToString() + "/" + myDatetime.Year.ToString();
        txtNgayTrinhKy.Value = MyDate;
    }
    protected void btnChuyenHoSo_Click(object sender, EventArgs e)
    {
        string[] strID = hdlstChuyen.Value.Split(',');
        for (int i = 0; i < strID.Length; i++)
        {
            DataRow rowTCTN = new NLDTroCapThatNghiep().getItem(int.Parse(strID[i]));
            if ((int)rowTCTN["IdTrangThai"] == 11)
            {
                new TinhHuong().UpdateTrangThaiHS(int.Parse(strID[i]), 12);
            }
          
        }
        Load_DanhSachHoSo();

    }
    protected void btnSearch_Click(object sender, ImageClickEventArgs e)
    {
        Load_DanhSachHoSo();
    }
    private void Load_TrangThai()
    {
        DataTable tblTrangThai = new TrangThaiHoSo().GetByIds(",26,");
        DataRow row = tblTrangThai.NewRow();
        row["ID"] = 0;
        row["Name"] = "--Tất cả--";
        tblTrangThai.Rows.InsertAt(row, 0);
        ddlTrangThai.DataTextField = "Name";
        ddlTrangThai.DataValueField = "ID";
        ddlTrangThai.DataSource = tblTrangThai;
        ddlTrangThai.DataBind();
    }
    protected void ddlTrangThai_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(ddlTrangThai.SelectedValue !=null && ddlTrangThai.SelectedValue.ToString().Trim()!="0")
        {
            Load_DanhSachHoSo("," + ddlTrangThai.SelectedValue + ",");         
        }     
        else
        {
            Load_DanhSachHoSo();
        }
    }
    protected void btnXuatExcel_Click(object sender, EventArgs e)
    {
        string str = txtSearch.Value.Trim();
        DateTime TuNgay = new DateTime(1900, 1, 1), DenNgay = new DateTime(9999, 1, 1);
        if (txtTuNgay.Value.Trim() != "")
        {
            TuNgay = Convert.ToDateTime(txtTuNgay.Value, new CultureInfo("vi-VN"));
        }
        if (txtDenNgay.Value.Trim() != "")
        {
            DenNgay = Convert.ToDateTime(txtDenNgay.Value, new CultureInfo("vi-VN"));
        }
        DataTable MyTB = new BaoCao().DanhSachLaoDongHuongTCTN(TuNgay, DenNgay);
        string data = "<table cellpadding='0' cellspacing='0'>";
        data += "<tr><td colspan='4'><div align='center' style='font-size:14px; font-family:Times New Roman'>SỞ LAO ĐỘNG TB&XH NGHỆ AN<br />";
        data += "<strong>TRUNG TÂM DỊCH VỤ VIỆC LÀM</strong> </div></td>";
        data += "<td colspan='4'><div align='center' style='font-size:14px; font-family:Times New Roman'>CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM<strong><br />";
        data += "Độc lập - Tự do - Hạnh phúc</strong></div></td></tr>";
        data += "<tr><td style='text-align:center;font-family:tahoma;font-weight:bold;font-size:14px;padding:10pt;' colspan='8'>DANH SÁCH LAO ĐỘNG HOÀN THÀNH HỒ SƠ HƯỞNG CHẾ ĐỘ BHTN</td></tr>";
        data += "<tr><td style='text-align:center;font-family:tahoma;font-weight:bold;font-size:14px;padding:10pt;' colspan='8'>";
        if (txtTuNgay.Value != "" && txtDenNgay.Value != "")
        {
            data += "Từ ngày: " + txtTuNgay.Value + "     " + "Đến ngày: " + txtDenNgay.Value;
        }
        data += "</td></tr>";
        data += "<tr><td style='text-align:center;font-family:tahoma;font-weight:bold;font-size:12px;padding:10pt;border-bottom-width:thin;border-bottom-color:Black;border-bottom-style:solid;border-right-width:thin;border-right-color:Black;border-right-style:solid;border-top-width:thin;border-top-color:Black;border-top-style:solid;'>STT</td>";
        data += "<td style='text-align:center;font-family:tahoma;font-weight:bold;font-size:12px;padding:10pt;border-bottom-width:thin;border-bottom-color:Black;border-bottom-style:solid;border-right-width:thin;border-right-color:Black;border-right-style:solid;border-top-width:thin;border-top-color:Black;border-top-style:solid;'>Số BHXH</td>";
        data += "<td style='text-align:center;font-family:tahoma;font-weight:bold;font-size:12px;padding:10pt;border-bottom-width:thin;border-bottom-color:Black;border-bottom-style:solid;border-right-width:thin;border-right-color:Black;border-right-style:solid;border-top-width:thin;border-top-color:Black;border-top-style:solid;'>Họ tên</td>";
        data += "<td style='text-align:center;font-family:tahoma;font-weight:bold;font-size:12px;padding:10pt;border-bottom-width:thin;border-bottom-color:Black;border-bottom-style:solid;border-right-width:thin;border-right-color:Black;border-right-style:solid;border-top-width:thin;border-top-color:Black;border-top-style:solid;'>Ngày sinh</td>";
        data += "<td style='text-align:center;font-family:tahoma;font-weight:bold;font-size:12px;padding:10pt;border-bottom-width:thin;border-bottom-color:Black;border-bottom-style:solid;border-right-width:thin;border-right-color:Black;border-right-style:solid;border-top-width:thin;border-top-color:Black;border-top-style:solid;'>Giới tính</td>";
        data += "<td style='text-align:center;font-family:tahoma;font-weight:bold;font-size:12px;padding:10pt;border-bottom-width:thin;border-bottom-color:Black;border-bottom-style:solid;border-right-width:thin;border-right-color:Black;border-right-style:solid;border-top-width:thin;border-top-color:Black;border-top-style:solid;'>Địa chỉ</td>";
        data += "<td style='text-align:center;font-family:tahoma;font-weight:bold;font-size:12px;padding:10pt;border-bottom-width:thin;border-bottom-color:Black;border-bottom-style:solid;border-right-width:thin;border-right-color:Black;border-right-style:solid;border-top-width:thin;border-top-color:Black;border-top-style:solid;'>CMND</td>";
        data += "<td style='text-align:center;font-family:tahoma;font-weight:bold;font-size:12px;padding:10pt;border-bottom-width:thin;border-bottom-color:Black;border-bottom-style:solid;border-right-width:thin;border-right-color:Black;border-right-style:solid;border-top-width:thin;border-top-color:Black;border-top-style:solid;'>Tình trạng việc làm mới</td></tr>";
        for (int i = 0; i < MyTB.Rows.Count; i++)
        {
            data += "<tr><td style='text-align:left;font-family:tahoma;font-weight:normal;font-size:12px;padding:10pt;border-bottom-width:thin;border-bottom-color:Black;border-bottom-style:solid;border-right-width:thin;border-right-color:Black;border-right-style:solid;border-top-width:thin;border-top-color:Black;border-top-style:solid;'>" + (i + 1).ToString();
            data += "</td><td style='text-align:left;font-family:tahoma;font-weight:normal;font-size:12px;padding:10pt;border-bottom-width:thin;border-bottom-color:Black;border-bottom-style:solid;border-right-width:thin;border-right-color:Black;border-right-style:solid;border-top-width:thin;border-top-color:Black;border-top-style:solid;'>" + MyTB.Rows[i]["BHXH"].ToString();
            data += "</td><td style='text-align:center;font-family:tahoma;font-weight:normal;font-size:12px;padding:10pt;border-bottom-width:thin;border-bottom-color:Black;border-bottom-style:solid;border-right-width:thin;border-right-color:Black;border-right-style:solid;border-top-width:thin;border-top-color:Black;border-top-style:solid;'>" + MyTB.Rows[i]["HoVaTen"].ToString();
            data += "</td><td style='text-align:center;font-family:tahoma;font-weight:normal;font-size:12px;padding:10pt;border-bottom-width:thin;border-bottom-color:Black;border-bottom-style:solid;border-right-width:thin;border-right-color:Black;border-right-style:solid;border-top-width:thin;border-top-color:Black;border-top-style:solid;'>" + ((DateTime)MyTB.Rows[i]["NgaySinh"]).ToString("dd/MM/yyyy");
            data += "</td><td style='text-align:center;font-family:tahoma;font-weight:normal;font-size:12px;padding:10pt;border-bottom-width:thin;border-bottom-color:Black;border-bottom-style:solid;border-right-width:thin;border-right-color:Black;border-right-style:solid;border-top-width:thin;border-top-color:Black;border-top-style:solid;'>" + GetGoiTinh((int)MyTB.Rows[i]["IDGioiTinh"]);
            data += "</td><td style='text-align:center;font-family:tahoma;font-weight:normal;font-size:12px;padding:10pt;border-bottom-width:thin;border-bottom-color:Black;border-bottom-style:solid;border-right-width:thin;border-right-color:Black;border-right-style:solid;border-top-width:thin;border-top-color:Black;border-top-style:solid;'>" + GetDiaChi(MyTB.Rows[i]["Tinh_DC"].ToString(), MyTB.Rows[i]["Huyen_DC"].ToString(), MyTB.Rows[i]["Xa_DC"].ToString(), MyTB.Rows[i]["Xom_DC"].ToString());
            data += "</td><td style='text-align:center;font-family:tahoma;font-weight:normal;font-size:12px;padding:10pt;border-bottom-width:thin;border-bottom-color:Black;border-bottom-style:solid;border-right-width:thin;border-right-color:Black;border-right-style:solid;border-top-width:thin;border-top-color:Black;border-top-style:solid;'>" + MyTB.Rows[i]["CMND"].ToString();
            data += "</td><td style='text-align:center;font-family:tahoma;font-weight:normal;font-size:12px;padding:10pt;border-bottom-width:thin;border-bottom-color:Black;border-bottom-style:solid;border-right-width:thin;border-right-color:Black;border-right-style:solid;border-top-width:thin;border-top-color:Black;border-top-style:solid;'>";
            data += "</td></tr>";
        }
        data += "</table>";
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("content-disposition", "attachment;filename=Bao-cao-BHTN.xls");
        Response.ContentEncoding = System.Text.Encoding.UTF8;
        Response.Charset = "Utf-8";
        EnableViewState = false;
        Response.Write(data);
        Response.End();
    }
    public string GetGoiTinh(int IDGioiTinh)
    {
        string value = "";
        if (IDGioiTinh == 1)
        {
            return "Nam";
        }
        if (IDGioiTinh == 2)
        {
            return "Nữ";
        }
        return value;
    }
    public string GetDiaChi(string Tinh,string Huyen,string Xa,string Xom)
    {
        string diachi="";
        if(Xom.Trim()!="")
        {
            Xom += ", ";
            diachi += Xom;
        }
        if(Xa.Trim()!="")
        {
            Xa += ", ";
            diachi += Xa;
        }
        if(Huyen.Trim()!="")
        {
            Huyen += ", ";
            diachi += Huyen;
        }
        diachi += Tinh;
        return diachi;
    }
}