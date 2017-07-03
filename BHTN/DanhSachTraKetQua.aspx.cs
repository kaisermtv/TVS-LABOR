using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Labor_DanhSachTraKetQua : System.Web.UI.Page
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
         
        if(!Page.IsPostBack)
        {
            Load_CauHinh();
            DeXuatHuyHuongHoSo();  
            Load_DanhSachHoSo();
            Load_TrangThai();
             
        }
             
    }
    private void DeXuatHuyHuongHoSo()
    {
        DataTable objData = new TinhHuong().getDanhSachHoSo(",11,");
        DateTime NgayQuaHan = new TinhHuong().TinhNgayNghiLe(DateTime.Now, 2);
        NgayQuaHan = new DateTime(NgayQuaHan.Year, NgayQuaHan.Month, NgayQuaHan.Day);
     
        for (int i = 0; i < objData.Rows.Count; i++)
        {
            DateTime NgayHenTraKQ = (DateTime)objData.Rows[i]["NgayHenTraKQ"];
            NgayHenTraKQ = new DateTime(NgayHenTraKQ.Year, NgayHenTraKQ.Month, NgayHenTraKQ.Day);
            if (DateTime.Compare(NgayHenTraKQ, NgayQuaHan) > 0)
            {
                // neu  qua 2 ngay hen tra thì chuyen sang muc danh de de nghi huy
                int IDNLDTCTN=(int)objData.Rows[i]["IDNLDTCTN"];
                new TinhHuong().UpdateTrangThaiHS(IDNLDTCTN, 13);
            }
        }
    }
    private void Load_TrangThai()
    {
        DataTable tblTrangThai = new TrangThaiHoSo().GetByIds(",11,12,23,24,13,");
        DataRow row = tblTrangThai.NewRow();
        row["ID"] = 0;
        row["Name"] = "--Tất cả--";
        tblTrangThai.Rows.InsertAt(row, 0);
        ddlTrangThai.DataTextField = "Name";
        ddlTrangThai.DataValueField = "ID";
        ddlTrangThai.DataSource = tblTrangThai;
        ddlTrangThai.DataBind();
    }
    private void Load_DanhSachHoSo(string Ids=",11,12,23,24,13,")
    {
        string str = txtSearch.Value.Trim();
        DataTable objData = new TinhHuong().getDanhSachHoSo(Ids,str);
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
     protected void btnTaiQuyetDinh_Click(object sender, EventArgs e)
    {
        if (hdlstChuyen.Value == null || hdlstChuyen.Value.ToString().Trim() == "")
        {
            _msg = "Bạn chưa chọn quyết định cần tải";
            return;
        }
        string[] strID = hdlstChuyen.Value.Split(',');
        for (int i = 0; i < strID.Length; i++)
        {
            DataRow rowTCTN = new NLDTroCapThatNghiep().getItem(int.Parse(strID[i]));
            if ((int)rowTCTN["IdTrangThai"] == 10)
            {
                TaiQuyetDinhTCTN(int.Parse(strID[i]), i.ToString());
            }
        }

        Load_DanhSachHoSo();
    
    }

 
    #region Quyet dinh huong tro cap that nghiep
    private void TaiQuyetDinhTCTN(int IDNLDTCTN,string FileName)
    {
        _msg = new Common().TaiQuyetDinhTCTN(IDNLDTCTN, FileName);     
    }
    #endregion  
     
    protected void dtlData_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "TaiQuyetDinh")
        {
            int ID = int.Parse(e.CommandArgument.ToString());
            DataRow rowTroCapThatNghiep = new NLDTroCapThatNghiep().getItem(ID);
            // la quyet dinh TCTN
            if ((int)rowTroCapThatNghiep["IdTrangThai"] == 11)
            {
                new Common().TaiQuyetDinhTCTN(ID, "");
            }
            if((int)rowTroCapThatNghiep["IdTrangThai"] == 23)
            {
                new Common().TaiQuyetDinhHuyHuong(ID, "");
            }
        }

    }

    protected void dtlData_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
       
            DataRowView newRow = (DataRowView)e.Item.DataItem;
            if((int)newRow["IdTrangThai"]==13)
            {
                Button newButtom = (Button)e.Item.FindControl("btnTaiQD");
                newButtom.Visible = false;
            }

        }
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
            if((int)rowTCTN["IdTrangThai"] == 23)
            {
                new TinhHuong().UpdateTrangThaiHS(int.Parse(strID[i]), 24);
            }
          
        }
        Load_DanhSachHoSo();

    }
    protected void btnSearch_Click(object sender, ImageClickEventArgs e)
    {
        Load_DanhSachHoSo();
    }
    protected void ddlTrangThai_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTrangThai.SelectedValue.ToString() != null && ddlTrangThai.SelectedValue.ToString() == "0")
        {
            Load_DanhSachHoSo();
        }
        else
        {
            Load_DanhSachHoSo("," + ddlTrangThai.SelectedValue.ToString() + ",");
        }
    }
}