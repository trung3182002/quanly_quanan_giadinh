using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KetNoiSQL
    {
        SqlConnection con;
        string conStr, severName, dataBaseName, userName, password;
        DataSet ds;

        public DataSet Ds
        {
            get { return ds; }
            set { ds = value; }
        }
        public string ConStr
        {
            get { return conStr; }
            set { conStr = value; }
        }

        public string SeverName
        {
            get { return severName; }
            set { severName = value; }
        }

        public string DataBaseName
        {
            get { return dataBaseName; }
            set { dataBaseName = value; }
        }

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public SqlConnection Con
        {
            get { return con; }
            set { con = value; }
        }
        public KetNoiSQL()
        {
            SeverName = @"DESKTOP-PTQBDTF";
            DataBaseName = "QUANLYQUANAN";
            UserName = "sa";
            Password = "123";
            ConStr = @"Data Source =" + SeverName + "; Initial Catalog = " + DataBaseName;
            ConStr += ";User ID = " + UserName + "; Password =" + Password;
            Con = new SqlConnection(ConStr);
            Ds = new DataSet();
        }
        public KetNoiSQL(string severName, string dataBaseName, string userName, string password)
        {
            this.SeverName = severName;
            this.DataBaseName = dataBaseName;
            this.UserName = userName;
            this.Password = password;
            ConStr = @"Data Source =" + severName + "; Initial Catalog = " + dataBaseName;
            ConStr += ";User ID = " + userName + "; Password =" + password;
            Con = new SqlConnection(ConStr);
            Ds = new DataSet();
        }
        public void openConnection()
        {
            if (Con.State.ToString() == "Closed")
                Con.Open();
        }
        public void closeConnection()
        {
            if (Con.State.ToString() == "Open")
                Con.Close();
        }
        public DataTable getDataTable(string sql)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, Con);
            da.Fill(Ds);
            return Ds.Tables[0];
        }
        public DataTable getDataTable(string sql, string tableName)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, Con);
            da.Fill(Ds, tableName);
            return Ds.Tables[tableName];
        }

        public int executeNonQuery(string sql)
        {
            openConnection();
            SqlCommand cmd = new SqlCommand(sql, con);
            int result = cmd.ExecuteNonQuery();
            closeConnection();
            return result;
        }
        public int getResult_ExecuteScalar(string sql)
        {
            openConnection();
            SqlCommand cmd = new SqlCommand(sql, con);
            int result = (int)cmd.ExecuteScalar();
            closeConnection();
            return result;
        }
    
    }
}