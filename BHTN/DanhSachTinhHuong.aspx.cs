using System;
using System.Collections.Generic;
using System.Data;
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



    private void Load_DanhSachHoSo(string Ids = ",2,3,27,28,")
    {
        string str = txtSearch.Value.Trim();
        DataTable objData = new TinhHuong().getDanhSachHoSo(Ids, str);
        cpData.MaxPages = 1000;
        cpData.PageSize = 12;
        cpData.DataSource = objData.DefaultView;
        cpData.BindToControl = dtlData;
        dtlData.DataSource = cpData.DataSourcePaged;
        dtlData.DataBind();
    }
    private void Load_TrangThai()
    {
        DataTable tblTrangThai = new TrangThaiHoSo().GetByIds(",2,3,27,28,");
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
        return link;
    }
}