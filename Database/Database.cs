using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows;
using System.Xml.Linq;


namespace ET3260_Project.Database
{
    public class Database
    {
        private string databaseConnector = "Data Source=Stoner;Initial Catalog=quanlydichbenh;Integrated Security=True";
        private SqlConnection connect;
        private string sql;
        private DataTable table;
        private SqlCommand command;

        public Database()
        {
            connect = new SqlConnection(databaseConnector);
            try
            {
                connect.Open();
            }
            catch(Exception e)
            {
                MessageBox.Show("Connection failed: " + e.Message);
            }
        }

        public bool addUser(string gmail, string password, int role, string fullname)
        {
            try
            {
                using (SqlConnection connector = new SqlConnection(databaseConnector))
                {
                    connector.Open();

                    string sql = "INSERT INTO user (gmail, password, role, fullname) VALUES (@Gmail, @Password, @Role, @Fullname)";
                    using (SqlCommand cmd = new SqlCommand(sql, connector))
                    {
                        cmd.Parameters.AddWithValue("@Gmail", gmail);
                        cmd.Parameters.AddWithValue("@Password", password);
                        cmd.Parameters.AddWithValue("@Role", role);
                        cmd.Parameters.AddWithValue("@Fullname", fullname);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error adding user: " + e.Message);
                return false;
            }
        }
    }
}
