using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class Account
{
    #region method Account
    public Account()
    {
    } 
    #endregion

    #region method setData
    public int setData(int Id, string UserName, string FullName, string Email, string PassWord, int GroupId, int TypeId, bool State)
    {
        int tmpValue = 0;
        try
        {
            string sqlQuery = "";
            sqlQuery = "IF NOT EXISTS (SELECT * FROM tblAccount WHERE Id = @Id) ";
            sqlQuery += "BEGIN INSERT INTO tblAccount(UserName,FullName,Email,PassWord,GroupId,TypeId,State) VALUES(@UserName,@FullName,@Email,@PassWord,@GroupId,@TypeId,@State) END ";
            sqlQuery += "ELSE BEGIN UPDATE tblAccount SET FullName = @FullName, Email = @Email, GroupId = @GroupId, TypeId = @TypeId, State = @State  WHERE Id = @Id END ";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("Id", SqlDbType.Int).Value = Id;
            Cmd.Parameters.Add("UserName", SqlDbType.NVarChar).Value = UserName;
            Cmd.Parameters.Add("FullName", SqlDbType.NVarChar).Value = FullName;
            Cmd.Parameters.Add("Email", SqlDbType.NVarChar).Value = Email;
            Cmd.Parameters.Add("PassWord", SqlDbType.NVarChar).Value = this.CryptographyMD5(PassWord);
            Cmd.Parameters.Add("GroupId", SqlDbType.Int).Value = GroupId;
            Cmd.Parameters.Add("TypeId", SqlDbType.Int).Value = TypeId;
            Cmd.Parameters.Add("State", SqlDbType.Bit).Value = State;
            Cmd.ExecuteNonQuery();
            sqlCon.Close();
            sqlCon.Dispose();
            tmpValue = 1;
        }
        catch
        {
            tmpValue = 0;
        }
        return tmpValue;
    }
    #endregion

    #region method setData
    public int setData(string UserName, string FullName, string Email, string PassWord)
    {
        int tmpValue = 0;
        try
        {
            string sqlQuery = "";
            sqlQuery = "UPDATE tblAccount SET FullName = @FullName, Email = @Email WHERE UserName = @UserName";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("UserName", SqlDbType.NVarChar).Value = UserName;
            Cmd.Parameters.Add("FullName", SqlDbType.NVarChar).Value = FullName;
            Cmd.Parameters.Add("Email", SqlDbType.NVarChar).Value = Email;
            Cmd.ExecuteNonQuery();

            if (PassWord.Trim() != "")
            {
                Cmd.Parameters.Add("PassWord", SqlDbType.NVarChar).Value = this.CryptographyMD5(PassWord);
                sqlQuery = "UPDATE tblAccount SET PassWord = @PassWord WHERE UserName = @UserName";
                Cmd.CommandText = sqlQuery;
                Cmd.ExecuteNonQuery();
            }

            sqlCon.Close();
            sqlCon.Dispose();
            tmpValue = 1;
        }
        catch
        {
            tmpValue = 0;
        }
        return tmpValue;
    }
    #endregion

    #region method getData
    public DataTable getData(string searchKey)
    {
        string sqlQuery = "";
        if (searchKey.Trim() != "")
        {
            sqlQuery += " AND UPPER(RTRIM(LTRIM(FullName))) LIKE N'%'+UPPER(RTRIM(LTRIM(@SearchKey)))+'%'";
        }
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.Parameters.Add("SearchKey",SqlDbType.NVarChar).Value = searchKey;
            Cmd.CommandText = "SELECT 0 AS TT, *, (SELECT Name FROM tblAccountGroup WHERE Id = GroupId) AS GroupName, REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(CAST(TypeId AS varchar),'1',N'Quản lý công ty'),'0',N'Quản lý hệ thống'),'2',N'<a href = \"AccountProvincer.aspx?acc='+UserName+N'\"><img src = \"../images/69.png\"></a>&nbsp;&nbsp;Quản lý chi nhánh'),'3',N'<a href = \"AccountDistrict.aspx?acc='+UserName+N'\"><img src = \"../images/35.png\"></a>&nbsp;&nbsp;Quản lý nhóm'),'4',N'Người dùng (AM)') AS TypeName, REPLACE(REPLACE(CAST(State AS varchar),'1',N'Kích hoạt'),'0',N'Đóng') AS StateName FROM tblAccount WHERE 1 = 1 " + sqlQuery;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ds.Tables[0].Rows[i]["TT"] = (i + 1);
            }
            sqlCon.Close();
            sqlCon.Dispose();
            objTable = ds.Tables[0];           
        }
        catch
        {

        }
        return objTable;
    }
    #endregion
    public DataTable GetUserByGroupID(int GroupID)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT * FROM tblAccount WHERE GroupID = @IGroupID";
            Cmd.Parameters.Add("IGroupID", SqlDbType.Int).Value = GroupID;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlCon.Close();
            sqlCon.Dispose();
            objTable = ds.Tables[0];
        }
        catch
        {

        }
        return objTable;
    }
    #region method getDataById
    public DataTable getDataById(int Id)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT * FROM tblAccount WHERE Id = @Id";
            Cmd.Parameters.Add("Id", SqlDbType.Int).Value = Id;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlCon.Close();
            sqlCon.Dispose();
            objTable = ds.Tables[0];
        }
        catch
        {

        }
        return objTable;
    }
    #endregion

    #region method getDataByUserName
    public DataTable getDataByUserName(string UserName)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT * FROM tblAccount WHERE UserName = @UserName";
            Cmd.Parameters.Add("UserName", SqlDbType.NVarChar).Value = UserName;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlCon.Close();
            sqlCon.Dispose();
            objTable = ds.Tables[0];
        }
        catch
        {

        }
        return objTable;
    }
    #endregion

    #region method checkUserName
    public bool checkUserName(string UserName)
    {
        bool tmpValue = false;
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT * FROM tblAccount WHERE UserName = @UserName";
            Cmd.Parameters.Add("UserName", SqlDbType.NVarChar).Value = UserName;
            SqlDataReader Rd = Cmd.ExecuteReader();
            while(Rd.Read())
            {
                tmpValue = true;
            }
            Rd.Close();
            sqlCon.Close();
            sqlCon.Dispose();
        }
        catch
        {

        }
        return tmpValue;
    }
    #endregion

    #region method delData
    public void delData(int Id)
    {
        try
        {
            string sqlQuery = "";
            sqlQuery = "DELETE tblAccount WHERE Id = @Id ";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("Id", SqlDbType.Int).Value = Id;
            Cmd.ExecuteNonQuery();
            sqlCon.Close();
            sqlCon.Dispose();
        }
        catch
        {

        }
    }
    #endregion

    #region method getDataGroupToCombobox
    public DataTable getDataGroupToCombobox()
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT Id, Name FROM tblAccountGroup WHERE State = 1";
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlCon.Close();
            sqlCon.Dispose();
            objTable = ds.Tables[0];
        }
        catch
        {

        }
        return objTable;
    }
    #endregion

    #region method getDataCategoryToCombobox
    public DataTable getDataCategoryToCombobox()
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT Id, FullName FROM TblAccount WHERE State = 1";
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlCon.Close();
            sqlCon.Dispose();
            objTable = ds.Tables[0];
            objTable.Rows.Add(0, "Không chọn");
        }
        catch
        {

        }
        return objTable;
    }
    #endregion

    #region Method CryptographyMD5
    public string CryptographyMD5(string source)
    {
        System.Security.Cryptography.MD5CryptoServiceProvider objMD5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
        byte[] buffer = System.Text.Encoding.UTF8.GetBytes(source);
        byte[] bytHash = objMD5.ComputeHash(buffer);
        string result = "";
        foreach (byte a in bytHash)
        {
            result += int.Parse(a.ToString(), System.Globalization.NumberStyles.HexNumber).ToString();
        }
        return result;
    }
    #endregion

    #region method checkForLogin
    public bool checkForLogin(string UserName, string Password, ref string FullName)
    {
        bool tmpValue = false;
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT * FROM tblAccount WHERE UserName = @UserName ";
            Cmd.Parameters.Add("UserName", SqlDbType.NVarChar).Value = UserName;

            SqlDataReader Rd = Cmd.ExecuteReader();
            while (Rd.Read())
            {
                if (Rd["Password"].ToString() == this.CryptographyMD5(Password))
                {
                    tmpValue = true;
                }
                FullName = Rd["FullName"].ToString();
            }
            Rd.Close();

            sqlCon.Close();
            sqlCon.Dispose();
        }
        catch
        {

        }
        return tmpValue;
    }
    #endregion

    #region method checkForFunction
    public bool checkForFunction(string UserName, int FunctionId, ref bool View, ref bool Add, ref bool Edit, ref bool Del, ref bool Orther)
    {
        bool tmpValue = false;
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT * FROM [dbo].[tblAccountGroupPer] WHERE [GroupId] = (SELECT GroupId FROM tblAccount WHERE UserName = @UserName) AND FunctionId = @FunctionId";
            Cmd.Parameters.Add("UserName", SqlDbType.NVarChar).Value = UserName;
            Cmd.Parameters.Add("FunctionId", SqlDbType.Int).Value = FunctionId;
            SqlDataReader Rd = Cmd.ExecuteReader();
            while (Rd.Read())
            {
                tmpValue = true;
                View = bool.Parse(Rd["View"].ToString());
                Add = bool.Parse(Rd["Add"].ToString());
                Edit = bool.Parse(Rd["Edit"].ToString());
                Del = bool.Parse(Rd["Del"].ToString());
                Orther = bool.Parse(Rd["Orther"].ToString());
            }
            Rd.Close();
            sqlCon.Close();
            sqlCon.Dispose();
        }
        catch
        {

        }
        return tmpValue;
    }
    #endregion

    #region AccounttGroup
    
    #region method setDataGroupAccount
    public int setDataGroupAccount(int Id, string Name, bool State)
    {
        int tmpValue = 0;
        try
        {
            string sqlQuery = "";
            sqlQuery = "IF NOT EXISTS (SELECT * FROM tblAccountGroup WHERE Id = @Id) ";
            sqlQuery += "BEGIN INSERT INTO tblAccountGroup(Name,State) VALUES(@Name,@State) END ";
            sqlQuery += "ELSE BEGIN UPDATE tblAccountGroup SET Name = @Name, State = @State WHERE Id = @Id END ";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("Id", SqlDbType.Int).Value = Id;
            Cmd.Parameters.Add("Name", SqlDbType.NVarChar).Value = Name;
            Cmd.Parameters.Add("State", SqlDbType.Bit).Value = State;
            Cmd.ExecuteNonQuery();
            sqlCon.Close();
            sqlCon.Dispose();
            tmpValue = 1;
        }
        catch
        {
            tmpValue = 0;
        }
        return tmpValue;
    }
    #endregion

    #region method getDataGroupAccount
    public DataTable getDataGroupAccount()
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT 0 AS TT, * FROM tblAccountGroup";
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ds.Tables[0].Rows[i]["TT"] = (i + 1);
            }
            sqlCon.Close();
            sqlCon.Dispose();
            objTable = ds.Tables[0];
        }
        catch
        {

        }
        return objTable;
    }
    #endregion

    #region method getDataGroupAccountById
    public DataTable getDataGroupAccountById(int Id)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT * FROM tblAccountGroup WHERE Id = @Id";
            Cmd.Parameters.Add("Id",SqlDbType.Int).Value = Id;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlCon.Close();
            sqlCon.Dispose();
            objTable = ds.Tables[0];
        }
        catch
        {

        }
        return objTable;
    }
    #endregion

    #region method delDataGroupAccount
    public void delDataGroupAccount(int Id)
    {
        try
        {
            string sqlQuery = "";
            sqlQuery = "DELETE tblAccountGroup WHERE Id = @Id ";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("Id", SqlDbType.Int).Value = Id;
            Cmd.ExecuteNonQuery();
            sqlCon.Close();
            sqlCon.Dispose();
        }
        catch
        {

        }
    }
    #endregion

    #endregion

    #region Permission

    #region method getDataPermissionToCombobox
    public DataTable getDataPermissionToCombobox()
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT Id, Name FROM tblFunction";
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlCon.Close();
            sqlCon.Dispose();
            objTable = ds.Tables[0];
        }
        catch
        {

        }
        return objTable;
    }
    #endregion

    #region method getDataPermission
    public DataTable getDataPermission(int GroupId)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT 0 AS TT, *, ISNULL((SELECT [Name] FROM tblFunction WHERE Id = FunctionId),'') AS FunctionName, REPLACE(REPLACE(CAST([View] AS nvarchar),'1',N'Xem'),'0','--') AS Xem, REPLACE(REPLACE(CAST([Add] AS nvarchar),'1',N'Thêm'),'0','--') AS Them, REPLACE(REPLACE(CAST([Edit] AS nvarchar),'1',N'Sửa'),'0','--') AS Sua, REPLACE(REPLACE(CAST([Del] AS nvarchar),'1',N'Xóa'),'0','--') AS Xoa, REPLACE(REPLACE(CAST([Orther] AS nvarchar),'1',N'Khác'),'0','--') AS Khac FROM tblAccountGroupPer WHERE GroupId = @GroupId"; 
            Cmd.Parameters.Add("GroupId", SqlDbType.Int).Value = GroupId;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ds.Tables[0].Rows[i]["TT"] = (i + 1);
            }
            sqlCon.Close();
            sqlCon.Dispose();
            objTable = ds.Tables[0];
        }
        catch
        {

        }
        return objTable;
    }
    #endregion

    #region method getDataPermission
    public DataTable getDataPermission(int GroupId, int FunctionId)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT * FROM tblAccountGroupPer WHERE GroupId = @GroupId AND FunctionId = @FunctionId";
            Cmd.Parameters.Add("GroupId", SqlDbType.Int).Value = GroupId;
            Cmd.Parameters.Add("FunctionId", SqlDbType.Int).Value = FunctionId;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlCon.Close();
            sqlCon.Dispose();
            objTable = ds.Tables[0];
        }
        catch
        {

        }
        return objTable;
    }
    #endregion

    #region method getDataPermission
    public DataTable getDataPermission(string UserName, int FunctionId)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT * FROM tblAccountGroupPer WHERE GroupId = (SELECT TOP 1 GroupId FROM TblAccount WHERE UserName = @UserName) AND FunctionId = @FunctionId";
            Cmd.Parameters.Add("UserName", SqlDbType.NVarChar).Value = UserName;
            Cmd.Parameters.Add("FunctionId", SqlDbType.Int).Value = FunctionId;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlCon.Close();
            sqlCon.Dispose();
            objTable = ds.Tables[0];
        }
        catch
        {

        }
        return objTable;
    }
    #endregion

    #region method setDataPermission
    public int setDataPermission(int GroupId, int FunctionId, bool View, bool Add, bool Edit, bool Del, bool Orther)
    {
        int tmpValue = 0;
        try
        {
            string sqlQuery = "";
            sqlQuery = "IF NOT EXISTS (SELECT * FROM tblAccountGroupPer WHERE GroupId = @GroupId AND FunctionId = @FunctionId) ";
            sqlQuery += "BEGIN INSERT INTO tblAccountGroupPer(GroupId,FunctionId,[View],[Add],[Edit],[Del],[Orther]) VALUES(@GroupId,@FunctionId,@View,@Add,@Edit,@Del,@Orther) END ";
            sqlQuery += "ELSE BEGIN UPDATE tblAccountGroupPer SET [View] = @View, [Add] = @Add, [Edit] = @Edit, [Del] = @Del, [Orther] = @Orther WHERE GroupId = @GroupId AND FunctionId = @FunctionId END ";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("GroupId", SqlDbType.Int).Value = GroupId;
            Cmd.Parameters.Add("FunctionId", SqlDbType.Int).Value = FunctionId;
            Cmd.Parameters.Add("View", SqlDbType.Bit).Value = View;
            Cmd.Parameters.Add("Add", SqlDbType.Bit).Value = Add;
            Cmd.Parameters.Add("Edit", SqlDbType.Bit).Value = Edit;
            Cmd.Parameters.Add("Del", SqlDbType.Bit).Value = Del;
            Cmd.Parameters.Add("Orther", SqlDbType.Bit).Value = Orther;
            Cmd.ExecuteNonQuery();
            sqlCon.Close();
            sqlCon.Dispose();
            tmpValue = 1;
        }
        catch
        {
            tmpValue = 0;
        }
        return tmpValue;
    }
    #endregion

    #region method delDataPermission
    public void delDataPermission(int GroupId, int FunctionId)
    {
        try
        {
            string sqlQuery = "";
            sqlQuery = "DELETE tblAccountGroupPer WHERE GroupId = @GroupId AND FunctionId = @FunctionId";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("GroupId", SqlDbType.Int).Value = GroupId;
            Cmd.Parameters.Add("FunctionId", SqlDbType.Int).Value = FunctionId;
            Cmd.ExecuteNonQuery();
            sqlCon.Close();
            sqlCon.Dispose();
        }
        catch
        {

        }
    }
    #endregion

    #endregion

    #region Category

    #region method getDataCategoryToCombobox
    public DataTable getDataCategoryToCombobox(int ParentId)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT Id, Name FROM tblCategory WHERE ParentId = @ParentId";
            Cmd.Parameters.Add("ParentId", SqlDbType.Int).Value = ParentId;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlCon.Close();
            sqlCon.Dispose();
            objTable = ds.Tables[0];
            objTable.Rows.Add(0, "Nhóm sản phẩm");
        }
        catch
        {

        }
        return objTable;
    }
    #endregion

    #region method getDataCategoryToCombobox1
    public DataTable getDataCategoryToCombobox1(int ParentId)
    {
        DataTable objTable = new DataTable();
        try
        {
            if (ParentId > 0)
            {
                SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
                sqlCon.Open();
                SqlCommand Cmd = sqlCon.CreateCommand();
                Cmd.CommandText = "SELECT Id, Name FROM tblCategory WHERE ParentId = @ParentId";
                Cmd.Parameters.Add("ParentId", SqlDbType.Int).Value = ParentId;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = Cmd;
                DataSet ds = new DataSet();
                da.Fill(ds);
                sqlCon.Close();
                sqlCon.Dispose();
                objTable = ds.Tables[0];
            }
            objTable.Rows.Add(0, "Nhóm sản phẩm");
        }
        catch
        {

        }
        return objTable;
    }
    #endregion

    #region method getDataCategoryToCombobox1
    public DataTable getDataCategoryToCombobox1(int ParentId, string UserName)
    {
        DataTable objTable = new DataTable();
        try
        {
            if (ParentId > 0)
            {
                SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
                sqlCon.Open();
                SqlCommand Cmd = sqlCon.CreateCommand();
                Cmd.CommandText = "SELECT Id, Name FROM tblCategory WHERE ParentId = @ParentId AND Id IN (SELECT CategoryId FROM tblAccountCategory WHERE UserName = @UserName)";
                Cmd.Parameters.Add("ParentId", SqlDbType.Int).Value = ParentId;
                Cmd.Parameters.Add("UserName", SqlDbType.NVarChar).Value = UserName;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = Cmd;
                DataSet ds = new DataSet();
                da.Fill(ds);
                sqlCon.Close();
                sqlCon.Dispose();
                objTable = ds.Tables[0];
            }
            objTable.Rows.Add(0, "Nhóm sản phẩm");
        }
        catch
        {

        }
        return objTable;
    }
    #endregion

    #region method getDataCategory
    public DataTable getDataCategory(string UserName, int itemId)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT 0 AS TT, " + itemId + " AS ItemId, tblAccountCategory.Id, Name FROM tblAccountCategory, tblCategory WHERE tblAccountCategory.CategoryId = tblCategory.Id AND tblAccountCategory.UserName = @UserName";
            Cmd.Parameters.Add("UserName", SqlDbType.NVarChar).Value = UserName;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ds.Tables[0].Rows[i]["TT"] = (i + 1);
            }
            sqlCon.Close();
            sqlCon.Dispose();
            objTable = ds.Tables[0];
        }
        catch
        {

        }
        return objTable;
    }
    #endregion

    #region method setDataCategory
    public int setDataCategory(string UserName, int CategoryId)
    {
        int tmpValue = 0;
        try
        {
            string sqlQuery = "";
            sqlQuery = "IF NOT EXISTS (SELECT * FROM tblAccountCategory WHERE UserName = @UserName AND CategoryId = @CategoryId) ";
            sqlQuery += "BEGIN INSERT INTO tblAccountCategory(UserName,CategoryId) VALUES(@UserName,@CategoryId) END ";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("UserName", SqlDbType.NVarChar).Value = UserName;
            Cmd.Parameters.Add("CategoryId", SqlDbType.Int).Value = CategoryId;
            Cmd.ExecuteNonQuery();
            sqlCon.Close();
            sqlCon.Dispose();
            tmpValue = 1;
        }
        catch
        {
            tmpValue = 0;
        }
        return tmpValue;
    }
    #endregion

    #region method delDataCategory
    public void delDataCategory(string UserName, int CategoryId)
    {
        try
        {
            string sqlQuery = "";
            sqlQuery = "DELETE tblAccountCategory WHERE UserName = @UserName AND CategoryId = @CategoryId";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("UserName", SqlDbType.NVarChar).Value = UserName;
            Cmd.Parameters.Add("CategoryId", SqlDbType.Int).Value = CategoryId;
            Cmd.ExecuteNonQuery();
            sqlCon.Close();
            sqlCon.Dispose();
        }
        catch
        {

        }
    }
    #endregion

    #endregion

    #region AccountLocation

    #region method setDataAccountLocation
    public int setDataAccountLocation(string UserName, int LevelProvincerId, int LevelDistrictId, int LevelWardId)
    {
        int tmpValue = 0;
        try
        {
            string sqlQuery = "";
            sqlQuery = "IF NOT EXISTS (SELECT * FROM tblAccountLocation WHERE UserName = @UserName AND LevelProvincerId = @LevelProvincerId AND LevelDistrictId = @LevelDistrictId AND LevelWardId = @LevelWardId) ";
            sqlQuery += "BEGIN INSERT INTO tblAccountLocation(UserName,LevelProvincerId,LevelDistrictId,LevelWardId) VALUES(@UserName,@LevelProvincerId,@LevelDistrictId,@LevelWardId) END ";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("UserName", SqlDbType.NVarChar).Value = UserName;
            Cmd.Parameters.Add("LevelProvincerId", SqlDbType.NVarChar).Value = LevelProvincerId;
            Cmd.Parameters.Add("LevelDistrictId", SqlDbType.NVarChar).Value = LevelDistrictId;
            Cmd.Parameters.Add("LevelWardId", SqlDbType.Int).Value = LevelWardId;
            Cmd.ExecuteNonQuery();
            sqlCon.Close();
            sqlCon.Dispose();
            tmpValue = 1;
        }
        catch
        {
            tmpValue = 0;
        }
        return tmpValue;
    }
    #endregion

    #endregion
}