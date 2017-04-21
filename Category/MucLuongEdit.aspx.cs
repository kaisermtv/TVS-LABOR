using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_MucLuongEdit : System.Web.UI.Page
{
    #region declare objects
    private int itemId = 0;
    private Account objAccount = new Account();
    private Mucluong objMucluong = new Mucluong();
    private DataTable objTable = new DataTable();
    private bool View = false, Add = false, Edit = false, Del = false, Orther = false;
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ACCOUNT"] == null)
        {
            Response.Redirect("../Login.aspx");
        }
        //if (!this.objAccount.checkForFunction(Session["ACCOUNT"].ToString(), 3, ref View, ref Add, ref Edit, ref Del, ref Orther))
        //{
        //    Response.Redirect("NoPermission.aspx");
        //}
        try
        {
            this.itemId = int.Parse(Request["id"].ToString());
        }
        catch
        {
            this.itemId = 0;
        }
        if (!Page.IsPostBack && this.itemId > 0)
        {
            this.objTable = this.objMucluong.getDataById(this.itemId);
            if (this.objTable.Rows.Count > 0)
            {
                this.txtCodeMucluong.Text = this.objTable.Rows[0]["CodeMucluong"].ToString();
                this.txtNameMucluong.Text = this.objTable.Rows[0]["NameMucluong"].ToString();
                this.txtMinValue.Text = this.objTable.Rows[0]["MinValue"].ToString();
                this.txtMaxValue.Text = this.objTable.Rows[0]["MaxValue"].ToString();
                this.txtNote.Text = this.objTable.Rows[0]["Note"].ToString();
                this.ckbState.Checked = bool.Parse(this.objTable.Rows[0]["State"].ToString());
            }
        }
        this.txtCodeMucluong.Focus();
    }
    #endregion

    #region method btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        this.lblMsg.Text = "";

        if (this.txtCodeMucluong.Text.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập mã mức lương";
            this.txtCodeMucluong.Focus();
            return;
        }

        if (this.itemId == 0)
        {
            if (this.objMucluong.checkCode(this.txtCodeMucluong.Text.Trim()))
            {
                this.lblMsg.Text = "Mã \"" + this.txtCodeMucluong.Text + "\" đã được sử dụng, vui lòng chọn mã khác.";
                this.txtCodeMucluong.Focus();
                return;
            }
        }

        if (this.txtNameMucluong.Text.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập tên mức lương";
            this.txtNameMucluong.Focus();
            return;
        }

        if (this.txtMinValue.Text.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập mức lương thấp nhất";
            this.txtMinValue.Focus();
            return;
        }

        double tmpMinValue = 0;
        try
        {
            tmpMinValue = double.Parse(this.txtMinValue.Text);
        }
        catch
        {
            this.lblMsg.Text = "Bạn chưa nhập mức lương thấp nhất";
            this.txtMinValue.Focus();
            return;
        }

        if (this.txtMaxValue.Text.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập mức lương cao nhất";
            this.txtMaxValue.Focus();
            return;
        }

        double tmpMaxValue = 0;
        try
        {
            tmpMaxValue = double.Parse(this.txtMaxValue.Text);
        }
        catch
        {
            this.lblMsg.Text = "Bạn chưa nhập mức lương cao nhất";
            this.txtMaxValue.Focus();
            return;
        }

        if (this.objMucluong.setData(this.itemId, this.txtCodeMucluong.Text, this.txtNameMucluong.Text, tmpMinValue, tmpMaxValue, this.txtNote.Text,this.ckbState.Checked) == 1)
        {
            Response.Redirect("Mucluong.aspx");
        }
        else
        {
            this.lblMsg.Text = "Lỗi xảy ra khi cập nhật thông tin.";
        }
    }
    #endregion

    #region method btnCancel_Click
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Mucluong.aspx");
    }
    #endregion
}