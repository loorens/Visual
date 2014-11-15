using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace DatabaseTestConnectedLayer 
{
    public class DatabaseConnDAL
    {
        private SqlConnection sqlCn = new SqlConnection();

        public void OpenConnection(string connecttionString)
        {
            sqlCn.ConnectionString = connecttionString;
            sqlCn.Open();
        }
        public void CloseConnection()
        {
            sqlCn.Close();
        }
        public void InsertUser(int id, string name, string date, string email, string password, int logins)
        {
            string sql = string.Format("Insert Into Users" +
            "(usr_id, usr_name, usr_date, usr_email, usr_pass, usr_logins) Values"+
            "('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", id, name, date, email, password, logins);
            
            using(SqlCommand cmd = new SqlCommand(sql, this.sqlCn))
            { 
                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteUser(int id)
        {
            string sql = string.Format("Delete from Users where usr_id = '{0}'", id);
            using (SqlCommand cmd = new SqlCommand(sql,this.sqlCn))
            {
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException)
                {
                    Exception err = new Exception("No user, error");
                    throw err;
                }
            }
        }
        public void UpdateUser(int id, string name)
        {
            string sql = string.Format("Update Users Set usr_name = '{0}' where usr_id = '{1}'",name,id);

            using (SqlCommand cmd = new SqlCommand(sql, this.sqlCn))
            {
                cmd.ExecuteNonQuery();
            }
        }
        public DataTable GetAllUsers()
        {
            DataTable all = new DataTable("Users");
            string sql = "Select * from Users";
            using (SqlCommand cmd = new SqlCommand(sql, this.sqlCn))
            {
                SqlDataReader dr = cmd.ExecuteReader();
                all.Load(dr);
                dr.Close();
            }   
            return all;
        }
    }
}
