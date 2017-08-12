using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Labor_DanhSachTinhHuong : System.Web.UI.Page
{
    #region declare
    private NguoiLaoDong objNguoiLaoDong = new NguoiLaoDong();
    public int index = 1;
    public string _msg = "";
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ACCOUNT"] == null)
        {
            Response.Redirect("../Login.aspx");
        }

        if (!Page.IsPostBack)
        {
            Load_TrangThai();
            Load_DanhSachHoSo();

        }

    }



    private void Load_DanhSachHoSo(string Ids = ",2,3,27,28,37,38,50,51,")
    {
        string str = txtSearch.Value.Trim();
        DateTime TuNgay=new DateTime(1900,1,1),DenNgay=new DateTime(9999,1,1);
        if(txtTuNgay.Value.Trim()!="")
        {
            TuNgay = Convert.ToDateTime(txtTuNgay.Value, new CultureInfo("vi-VN"));
        }
        if(txtDenNgay.Value.Trim()!="")
        {
            DenNgay = Convert.ToDateTime(txtDenNgay.Value, new CultureInfo("vi-VN"));
        }
        DataTable objData = new TinhHuong().getDanhSachHoSo(Ids,TuNgay,DenNgay,str);
        cpData.MaxPages = 1000;
        cpData.PageSize = 12;
        cpData.DataSource = objData.DefaultView;
        cpData.BindToControl = dtlData;
        dtlData.DataSource = cpData.DataSourcePaged;
        dtlData.DataBind();
    }
    private void Load_TrangThai()
    {
        DataTable tblTrangThai = new TrangThaiHoSo().GetByIds(",2,3,27,28,37,38,50,51,");
        DataRow row = tblTrangThai.NewRow();
        row["ID"] = 0;
        row["Name"] = "--Tất cả--";
        tblTrangThai.Rows.InsertAt(row, 0);
        ddlTrangThai.DataTextField = "Name";
        ddlTrangThai.DataValueField = "ID";
        ddlTrangThai.DataSource = tblTrangThai;
        ddlTrangThai.DataBind();
    }
    protected void btnChuyenHoSo_Click(object sender, EventArgs e)
    {
        TinhHuong objTinhHuong = new TinhHuong();
        //kiem tra truong hop chuyen 1 hay nhieu
        if (hdlstChuyen.Value != null && hdlstChuyen.Value.ToString().Trim() != "")
        {
            string[] lstIDTCTN = hdlstChuyen.Value.Split(',');
            for (int i = 0; i < lstIDTCTN.Length; i++)
            { 
                int ID = int.Parse(lstIDTCTN[i]);
                DataRow rowThatNghiep = new NLDTroCapThatNghiep().getItem(ID);
                int TrangThai = (int)rowThatNghiep["IdTrangThai"];
                if(TrangThai ==3)
                {
                    objTinhHuong.UpdateTrangThaiHS(ID, 6);
                }         
                if(TrangThai==28)
                {
                    objTinhHuong.UpdateTrangThaiHS(ID, 29);
                }
                if(TrangThai==38)
                {
                    objTinhHuong.UpdateTrangThaiHS(ID, 39);
                }
                if(TrangThai==51)
                {
                    objTinhHuong.UpdateTrangThaiHS(ID, 52);
                }
            }
        }
        else
        {
            if(hdlstChuyen.Value !=null && hdChuyen.Value.ToString().Trim()!="")
            {
                int ID = int.Parse(hdChuyen.Value);
                DataRow rowThatNghiep = new NLDTroCapThatNghiep().getItem(ID);
                int TrangThai = (int)rowThatNghiep["IdTrangThai"];
                if (TrangThai == 3)
                {
                    objTinhHuong.UpdateTrangThaiHS(ID, 6);
                }              
            }

        }
        Response.Redirect(Request.Url.ToString());

    }
    protected void ddlTrangThai_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTrangThai.SelectedValue != null && ddlTrangThai.SelectedValue.ToString().Trim() != "0")
        {
            Load_DanhSachHoSo("," + ddlTrangThai.SelectedValue + ",");
        }
        else
        {
            Load_DanhSachHoSo();
        }

    }
    public string SetLink(int IdNLDTCTN, int IdTrangThai)
    {
        string link = "";
        if (IdTrangThai == 2 || IdTrangThai == 3)
        {
            link = "tinhhuong?id=" + IdNLDTCTN;
        }
        if (IdTrangThai == 27 || IdTrangThai == 28)
        {
            link = "tinhhuongtamdung?id=" + IdNLDTCTN;
        }
        if(IdTrangThai==37 || IdTrangThai ==38)
        {
            link = "TinhHuongTiepTuc?id=" + IdNLDTCTN;
        }
        if (IdTrangThai == 50 || IdTrangThai == 51)
        {
            link = "TinhHuongChamDut?id=" + IdNLDTCTN;
        }
        return link;
    }
    protected void btnSearch_Click(object sender, ImageClickEventArgs e)
    {
        Load_DanhSachHoSo();
    }
}