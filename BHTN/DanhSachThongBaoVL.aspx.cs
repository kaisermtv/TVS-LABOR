using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Labor_DanhSachThongBaoVL : System.Web.UI.Page
{
    #region declare
    public int index = 1;
    public string _msg = "";
    public DataRow _Permission;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ACCOUNT"] == null)
        {
            Response.Redirect("../Login.aspx");
        }
        else
        {
            DataTable tblPermission = (DataTable)Session["Permission"];
            _Permission = new Account().PermissionPage(tblPermission, System.IO.Path.GetFileName(Request.PhysicalPath));
             if (_Permission ==null || (bool)_Permission["View"] != true)
            {
                Response.Redirect("default.aspx");
            }
        }
        if(!Page.IsPostBack)
        {        
            Load_CauHinh();
            Load_DanhSachHoSo();
            Load_TrangThai();
        }             
    }
    private void Load_DanhSachHoSo(string Ids = ",12,25,35,45,47,")
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
        DataTable objData = new TinhHuong().getDanhSachHoSo(Ids, TuNgay,DenNgay, str);
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
   
    protected void dtlData_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "TaiQuyetDinh")
        {
           int ID = int.Parse(e.CommandArgument.ToString());
           new Common().TaiQuyetDinhTCTN(ID,"");
        }
        if(e.CommandName=="DeXuatTamDung")
        {
            //kiem tra co du dieu kien tam dung     
            int ID = int.Parse(e.CommandArgument.ToString());
            DataTable tblThongBaoViecLamHangThang = new ThongBaoViecLamHangThang().GetMax(ID);
            DataRow  tblTCTN = new NLDTroCapThatNghiep().getItem(ID);
            if (tblThongBaoViecLamHangThang.Rows[0]["TrangThaiThongBao"].ToString().Trim() == "15" || tblThongBaoViecLamHangThang.Rows[0]["IdTrangthai"].ToString().Trim()=="25")
            {
                new TinhHuong().UpdateTrangThaiHS(ID, 26);
                Load_DanhSachHoSo();
            }
            else
            {
                _msg = "Hồ sơ không quá hạn hoặc, không khai báo";
            }
        }
        if (e.CommandName == "DeXuatTiepTuc")
        {
            int ID = int.Parse(e.CommandArgument.ToString());
            DataTable tblThongBaoViecLamHangThang = new ThongBaoViecLamHangThang().GetMax(ID);
            if (tblThongBaoViecLamHangThang.Rows[0]["TrangThaiThongBao"].ToString() == "14")
            {
                new TinhHuong().UpdateTrangThaiHS(ID, 36);
                Load_DanhSachHoSo();
            }
            else
            {
                _msg = "Bạn phải cập nhật thông báo việc làm trước khi tiếp tục";
            }
        }
        if (e.CommandName == "ChamDutHuong")
        {
            int ID = int.Parse(e.CommandArgument.ToString());
            new TinhHuong().UpdateTrangThaiHS(ID,49);
            Load_DanhSachHoSo();
        }

    }
    protected void dtlData_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            #region hien thi so thang khai bao, chua khai bao , cho khai bao 
            string str = "";
            DataRowView newRow = (DataRowView)e.Item.DataItem;
            int IDTCTN = (int)newRow["IdNLDTCTN"];
            DataTable tblTinhHuong = new TinhHuong().getDataById(IDTCTN);
            if(tblTinhHuong.Rows.Count >0)
            {
                DataTable tblLichThongBao = new LichThongBao().GetDataByID((int)tblTinhHuong.Rows[0]["IDTinhHuong"]);
                if(tblLichThongBao.Rows.Count>0)
                {
                   
                    for(int i=1;i<=12;i++)
                    {
                        if (((DateTime)tblLichThongBao.Rows[0]["KhaiBaoThang" + i.ToString() + "TuNgay"]).ToString("yyyy") != "1900")
                        {
                           // kiem tra thang nang da khai bao chua
                            DateTime KhaiBaoTuNgay = (DateTime)tblLichThongBao.Rows[0]["KhaiBaoThang" + i.ToString() + "TuNgay"];
                            DateTime KhaiBaoDenNgay= (DateTime)tblLichThongBao.Rows[0]["KhaiBaoThang" + i.ToString() + "DenNgay"];                        

                            DataTable tblThongBaoHangThang = new ThongBaoViecLamHangThang().GetByID(IDTCTN, i);                          
                            if (tblThongBaoHangThang.Rows.Count>0 )
                            {                          
                                if (tblThongBaoHangThang.Rows[0]["TrangThaiThongBao"].ToString() == "14")
                                {
                                    str += "<span class='dakhaibao' alt='Đã khai báo' title ='Đã khai báo (" + KhaiBaoTuNgay.ToString("dd/MM/yyyy") + "->" + KhaiBaoDenNgay.ToString("dd/MM/yyyy") + ")'>" + i.ToString() + "</span>";
                                }
                                if (tblThongBaoHangThang.Rows[0]["TrangThaiThongBao"].ToString() == "15")
                                {
                                    str += "<span class='khongkhaibao' alt='Không khai báo' title ='Không khai báo (" + KhaiBaoTuNgay.ToString("dd/MM/yyyy") + "->" + KhaiBaoDenNgay.ToString("dd/MM/yyyy") + ")'>" + i.ToString() + "</span>";
                                }
                   
                            }
                            else
                            {                                
                                //Neu chua khai bao thi kiem tra cac thang cho khai bao cho thang nao qua han khong
                                if (KhaiBaoDenNgay.ToString("yyyy") != "1900")
                                {                                   
                                    //xoa thoi gian 
                                    DateTime NgayHienTai = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                                    DateTime NgayQuaHanThongBao = new DateTime(KhaiBaoDenNgay.Year,KhaiBaoDenNgay.Month,KhaiBaoDenNgay.Day);
                                    // kiem tra co qua han khong 
                                    if (DateTime.Compare(NgayHienTai, NgayQuaHanThongBao) > 0)
                                    {
                                        // cap nhat trang thai qua hạn
                                        str += "<span class='quahanthongbao' alt='Quá hạn' title ='Quá hạn (" + KhaiBaoTuNgay.ToString("dd/MM/yyyy") + "->" + KhaiBaoDenNgay.ToString("dd/MM/yyyy") + ")'>" + i.ToString() + "</span>";
                                        new TinhHuong().UpdateTrangThaiHS(IDTCTN, 25);
                                    }
                                    else
                                    {
                                        str += "<span class='chothongbao' alt='Chờ khai báo' title ='Chưa khai báo (" + KhaiBaoTuNgay.ToString("dd/MM/yyyy") + "->" + KhaiBaoDenNgay.ToString("dd/MM/yyyy") + ")'>" + i.ToString() + "</span>";
                                    }
                                }
                          
                            }                      
                    
                        }
            
                    }

                }           

            }
            Label lblThongBaoViecLam = (Label)e.Item.FindControl("lblKhaiBaoViecLam");
            lblThongBaoViecLam.Text = str;
            #endregion
            //Cap nhat trang thai qua han thong bao
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
        }
        Load_DanhSachHoSo();

    }
    protected void btnSearch_Click(object sender, ImageClickEventArgs e)
    {
        Load_DanhSachHoSo();
    }
    private void Load_TrangThai()
    {
        DataTable tblTrangThai = new TrangThaiHoSo().GetByIds(",12,25,35,45,47,");
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

    }
}