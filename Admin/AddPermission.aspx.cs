using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AddPermission : System.Web.UI.Page
{
    #region Declare object
    public int GroupId = 0, FunctionId = 0;
    private Account objAccount = new Account();
    private DataTable objTable = new DataTable();
    private DataTable objTableDetail = new DataTable();
    //private bool View = false, Add = false, Edit = false, Del = false, Orther = false;
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ACCOUNT"] == null)
        {
            Response.Redirect("../Login.aspx");
        }
        //if (!this.objAccount.checkForFunction(Session["ACCOUNT"].ToString(), 4, ref View, ref Add, ref Edit, ref Del, ref Orther))
        //{
        //    Response.Redirect("NoPermission.aspx");
        //}
        try
        {
            this.GroupId = int.Parse(Request["Gid"].ToString());
        }
        catch
        {
            this.GroupId = 0;
        }

         try
        {
            this.FunctionId = int.Parse(Request["Fid"].ToString());
        }
        catch
        {
            this.FunctionId = 0;
        }
        if (!Page.IsPostBack)
        {
            this.ddlFunctionId.DataSource = this.objAccount.getDataPermissionToCombobox();
            this.ddlFunctionId.DataTextField = "Name";
            this.ddlFunctionId.DataValueField = "Id";
            this.ddlFunctionId.DataBind();
            this.ddlFunctionId.SelectedValue = this.FunctionId.ToString();

            this.objTable = this.objAccount.getDataGroupAccountById(this.GroupId);
            if (this.objTable.Rows.Count > 0)
            {
                this.txtName.Text = this.objTable.Rows[0]["Name"].ToString();
                this.ddlFunctionId.SelectedValue = this.FunctionId.ToString();
            }

            this.objTableDetail = this.objAccount.getDataPermission(this.GroupId, this.FunctionId);
            if (this.objTableDetail.Rows.Count > 0)
            {
                if (this.objTableDetail.Rows[0]["View"].ToString().ToUpper() == "TRUE")
                {
                    this.ckbView.Checked = true;
                }
                else
                {
                    this.ckbView.Checked = false;
                }

                if (this.objTableDetail.Rows[0]["Add"].ToString().ToUpper() == "TRUE")
                {
                    this.ckbAdd.Checked = true;
                }
                else
                {
                    this.ckbAdd.Checked = false;
                }

                if (this.objTableDetail.Rows[0]["Edit"].ToString().ToUpper() == "TRUE")
                {
                    this.ckbEdit.Checked = true;
                }
                else
                {
                    this.ckbEdit.Checked = false;
                }

                if (this.objTableDetail.Rows[0]["Del"].ToString().ToUpper() == "TRUE")
                {
                    this.ckbDel.Checked = true;
                }
                else
                {
                    this.ckbDel.Checked = false;
                }

                if (this.objTableDetail.Rows[0]["Orther"].ToString().ToUpper() == "TRUE")
                {
                    this.ckbOther.Checked = true;
                }
                else
                {
                    this.ckbOther.Checked = false;
                }
            }
        }

        Session["TITLE"] = "CẬP NHẬT QUYỀN CỦA NHÓM";
    }
    #endregion
    #region method btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (this.GroupId > 0 && this.ddlFunctionId.Items.Count > 0)
        {
            if (this.objAccount.setDataPermission(this.GroupId, int.Parse(this.ddlFunctionId.SelectedValue.ToString()), this.ckbView.Checked, this.ckbAdd.Checked, this.ckbEdit.Checked, this.ckbDel.Checked, this.ckbOther.Checked) == 1)
            {
                Response.Redirect("EditGroupAccount.aspx?id="+this.GroupId.ToString());
            }
            else
            {
                this.lblMsg.Text = "Lỗi xảy ra khi cập nhật thông tin";
            }
        }
    } 
    #endregion
}