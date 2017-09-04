using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class uctLog : System.Web.UI.UserControl
{
    int _IDNLDTCTN = 0;
    public int Index = 1;
    public string _msg = "";
    public DataRow _Permission = null;
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
            if (_Permission == null || (bool)_Permission["Orther"] != true)
            {
                lblMessage.Text = "Bạn không có quyền xem mục này";
                return;
            }
            else
            {
                lblMessage.Visible = false;
            }
        }

        if (Request.QueryString["ID"] != null && Request.QueryString["ID"].ToString().Trim() != "")
        {
            _IDNLDTCTN = int.Parse(Request.QueryString["ID"].ToString());
        }
       if(!Page.IsPostBack)
       {
           if (_IDNLDTCTN >0)
           {
               DataTable objData = new Log().GetByOptions(_IDNLDTCTN);
               cpData.MaxPages = 1000;
               cpData.PageSize = 12;
               cpData.DataSource = objData.DefaultView;
               cpData.BindToControl = dtlData;
               dtlData.DataSource = cpData.DataSourcePaged;
               dtlData.DataBind();
           }

        
          
       }
    }    
  }