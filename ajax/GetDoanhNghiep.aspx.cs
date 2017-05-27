using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ajax_GetDoanhNghiep : System.Web.UI.Page
{
    #region declare 
    private DoanhNghiep objDoanhNghiep = new DoanhNghiep();
    private DataRow objDataRow;

    public int itemId = 0;
    public string data = "";
    #endregion

    #region Even Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            this.itemId = int.Parse(Request["id"].ToString());
        }
        catch
        {
            this.itemId = 0;
        }

        if(itemId != 0)
        {
            DataTable objData = objDoanhNghiep.getDataById(itemId);
            if(objData.Rows.Count > 0 )
            {
                objDataRow = objData.Rows[0];

                data = "{";
                addData("IDDonVi");
                addData("TenDonVi");
                addData("IDNganhNghe");
                addData("DiaChi");
                addData("DienThoaiDonVi");
                addData("IdLoaiHinh");
                addData("IDDonVi");
                addData("FaxDonVi");
                addData("SoDKKD");
                addData("IdLoaiHinh");
                addData("EmailDonVi");
                addData("Website");

                data += "}";

            }


        }
    }
    #endregion

    #region method addData(string key,string val)
    protected void addData(string key)
    {
        if (data != "{") data += ",";
        data += "\"" + key + "\" : \"" + objDataRow[key].ToString() + "\"";
    }
    #endregion
}