using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Default : System.Web.UI.Page
{
    #region declare objects
    private DataTable objTable = new DataTable();
    private Account objAccount = new Account();
    private TVSSystem objTVSSystem = new TVSSystem();
    private int currPage = 0;
    private bool View = false, Add = false, Edit = false, Del = false, Orther = false;
    public string strCountHoSoTuVan = "", strCountViecLamTrongNuoc = "", strCountXuatKhauLaoDong = "", strCountDaoTaoNghe = "", strCountTinTuyenDung = "";
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ACCOUNT"] == null)
        {
            Response.Redirect("../Login.aspx");
        }

        int tmpValue = 0;
        tmpValue = this.objTVSSystem.getCountOfObjects("TblNldTuVan");
        if (tmpValue > 0)
        {
            this.strCountHoSoTuVan = " ( " + tmpValue.ToString() + " )";
        }

        tmpValue = this.objTVSSystem.getCountOfObjects("TblNldDangKy");
        if (tmpValue > 0)
        {
            this.strCountViecLamTrongNuoc = " ( " + tmpValue.ToString() + " )";
        }

        tmpValue = this.objTVSSystem.getCountOfObjects("TblNldXuatKhau");
        if (tmpValue > 0)
        {
            this.strCountXuatKhauLaoDong = " ( " + tmpValue.ToString() + " )";
        }

        tmpValue = this.objTVSSystem.getCountOfObjects("TblTuyenDung");
        if (tmpValue > 0)
        {
            this.strCountTinTuyenDung = " ( " + tmpValue.ToString() + " )";
        }

        tmpValue = this.objTVSSystem.getCountOfObjects("TblNldDaoTao");
        if (tmpValue > 0)
        {
            this.strCountDaoTaoNghe = " ( " + tmpValue.ToString() + " )";
        }
        
        //if (!this.objAccount.checkForFunction(Session["ACCOUNT"].ToString(), 3, ref View, ref Add, ref Edit, ref Del, ref Orther))
        //{
        //    Response.Redirect("NoPermission.aspx");
        //}
        
    }
    #endregion
}