using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class AboutUs
{
    #region method AboutUs
    public AboutUs()
    {
    } 
    #endregion

    #region setData
    public int setData(int Id, string Name, string Address, string Phone, string Email, string Hotline, string Greeting, string Greeting1)
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            string sqlQuery = "";
            sqlQuery = "IF NOT EXISTS (SELECT * FROM tblAboutUs WHERE Id = @Id)";
            sqlQuery += "BEGIN INSERT INTO tblAboutUs(Id,[Name],Address,Phone,Email,Hotline,Greeting,Greeting1) VALUES(@Id,@Name,@Address,@Phone,@Email,@Hotline,@Greeting,@Greeting1) END ";
            sqlQuery += "ELSE BEGIN UPDATE tblAboutUs SET Name = @Name, Address = @Address, Phone = @Phone, Email = @Email, Hotline = @Hotline, Greeting = @Greeting, Greeting1 = @Greeting1 WHERE Id = @Id END";
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("Id", SqlDbType.Int).Value = Id;
            Cmd.Parameters.Add("Name", SqlDbType.NVarChar).Value = Name;
            Cmd.Parameters.Add("Address", SqlDbType.NVarChar).Value = Address;
            Cmd.Parameters.Add("Phone", SqlDbType.NVarChar).Value = Phone;
            Cmd.Parameters.Add("Email", SqlDbType.NVarChar).Value = Email;
            Cmd.Parameters.Add("Hotline", SqlDbType.NVarChar).Value = Hotline;
            Cmd.Parameters.Add("Greeting", SqlDbType.NVarChar).Value = Greeting;
            Cmd.Parameters.Add("Greeting1", SqlDbType.NVarChar).Value = Greeting1;
            Cmd.ExecuteNonQuery();
            sqlCon.Close();
            sqlCon.Dispose();
            return 1;
        }
        catch
        {
            return 0;
        }
    }
    #endregion

    #region method getData
    public DataTable getData()
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT * FROM tblAboutUs WHERE Id = 1 ";
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            objTable = ds.Tables[0];
            sqlCon.Close();
            sqlCon.Dispose();
        }
        catch
        {
        }
        return objTable;
    }
    #endregion
}