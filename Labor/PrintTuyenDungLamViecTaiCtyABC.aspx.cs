using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Labor_PrintTuyenDungLamViecTaiCtyABC : System.Web.UI.Page
{

    #region declare objects
    public int itemId = 0, IdDonVi = 0;
    public string tenDonVi = "";
    private Account objAccount = new Account();
    private TuyenDung objTuyenDung = new TuyenDung();
    private NhomNganh objNhomNganh = new NhomNganh();
    private DoTuoi objDoTuoi = new DoTuoi();
    private Business objBusiness = new Business();
    private Provincer objProvincer = new Provincer();
    private GioiTinh objGioiTinh = new GioiTinh();
    private TrinhDoChuyenMon objTrinhDoChuyenMon = new TrinhDoChuyenMon();
    private ChucVu objChucVu = new ChucVu();
    private Mucluong objMucluong = new Mucluong();
    private DataTable objTable = new DataTable();

    public DataRow objData;
    public String nameDoanhNghiep;
    public String nameNganhNghe;
    public String nameViTri;
    public String nameMucLuong;
    #endregion


    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["ACCOUNT"] == null)
        {
            Response.Redirect("../Login.aspx");
        }

        Session["TITLE"] = "THÔNG TIN TUYỂN DỤNG";
        try
        {
            this.itemId = int.Parse(Request["id"].ToString());
        }
        catch
        {
            this.itemId = 0;
        }

        if (!Page.IsPostBack && itemId != 0)
        {
            objData = objTuyenDung.getDataView(itemId);
            if(objData != null)
            {
                DoanhNghiep objDoanhNghiep = new DoanhNghiep();
                DataTable objDataDN = objDoanhNghiep.getDataViewById((int)objData["IDDonVi"]);
                if (objDataDN.Rows.Count > 0)
                {
                    nameDoanhNghiep = objDataDN.Rows[0]["TenDonVi"].ToString().ToUpper();
                    nameNganhNghe = objDataDN.Rows[0]["NganhNgheName"].ToString();
                }

                ViTri objViTri = new ViTri();
                nameViTri = objViTri.getNameViTriById((int)objData["IdViTri"]);

                Mucluong objMucLuong = new Mucluong();
                nameMucLuong = objMucluong.getNameMucLuongById((int)objData["IDMucLuong"]);
            }







        }

    }
}