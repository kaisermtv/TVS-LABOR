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
    private Account objAccount = new Account();
    private TuyenDung objTuyenDung = new TuyenDung();
    private NhomNganh objNhomNganh = new NhomNganh();
    private DoTuoi objDoTuoi = new DoTuoi();
    private Business objBusiness = new Business();
    private Provincer objProvincer = new Provincer();
    private GioiTinh objGioiTinh = new GioiTinh();
    private TrinhDoChuyenMon objTrinhDoChuyenMon = new TrinhDoChuyenMon();
    private ChucVu objChucVu = new ChucVu();
    private DataTable objTable = new DataTable();
    private ViTri objViTri = new ViTri();

    public int itemId = 0, IdDonVi = 0,counti = 0;
    public int[] arrayItem;
    public DataTable objData;
    public String nameDoanhNghiep = "";
    public String nameNganhNghe = "";
    public String nameViTri = "";
    public String nameMucLuong = "";
    public String mota = "";
    public String quyenLoi = "";
    public String diaDiem = "";
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
            string[] abc = Request["id"].ToString().Split(',');


            counti = abc.Length;
            arrayItem = new int[counti];

            for (int i = 0; i < counti; i++)
            {
                arrayItem[i] = int.Parse(abc[i]);
            }
        }
        catch
        {
            counti = 0;
        }

        if (!Page.IsPostBack && counti != 0)
        {
            objData = objTuyenDung.getDataView(arrayItem);
            if (objData.Rows.Count > 0)
            {
                DoanhNghiep objDoanhNghiep = new DoanhNghiep();
                DataTable objDataDN = objDoanhNghiep.getDataViewById((int)objData.Rows[0]["IDDonVi"]);
                if (objDataDN.Rows.Count > 0)
                {
                    nameDoanhNghiep = objDataDN.Rows[0]["TenDonVi"].ToString().ToUpper();
                    nameNganhNghe = objDataDN.Rows[0]["NganhNgheName"].ToString();
                }

                Mucluong objMucLuong = new Mucluong();
                nameMucLuong = objMucLuong.getNameMucLuongById((int)objData.Rows[0]["IDMucLuong"]);

                diaDiem = objData.Rows[0]["DiaDiem"].ToString();

                dtlTuyenDung.DataSource = objData.DefaultView;
                dtlTuyenDung.DataBind();

                //nameViTri = objData.Rows[0]["SoLuongTuyenDung"].ToString() + " ";
                //try
                //{
                //    nameViTri = objViTri.getNameViTriById((int)objData.Rows[0]["IdViTri"]);
                //}
                //catch
                //{
                //    nameViTri = " nhân viên";
                //}

                

                //mota = objData.Rows[0]["MoTa"].ToString();
                quyenLoi = objData.Rows[0]["QuyenLoi"].ToString();
                
            }







        }

    }
}