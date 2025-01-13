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
        private string databaseConnector = "Server=LAPTOP-DRS5765Q\\LOCALHOST;Database=quanlydichbenh;Trusted_Connection=True;";

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

        public bool addUser(string email, string password, int role, string fullname)
        {
            try
            {
                using (SqlConnection connector = new SqlConnection(databaseConnector))
                {
                    connector.Open();

                    string sql = "INSERT INTO [user] (email, password, fullname, role) VALUES (@Email, @Password, @Fullname, @Role)";
                    using (SqlCommand cmd = new SqlCommand(sql, connector))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
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

        public bool authenticateUser(string email, string password)
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                sql = "SELECT COUNT(*) FROM [user] WHERE email = @Email AND password = @Password";
                command = new SqlCommand(sql, connect);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", password);

                int count = (int)command.ExecuteScalar();

                return count > 0;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error authenticate user: " + e.Message);
                return false;
            }
            finally
            {
                connect.Close();
            }
        }

        public string getUserRole(string username)
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                sql = "SELECT role FROM [user] WHERE email = @Username";
                command = new SqlCommand(sql, connect);
                command.Parameters.AddWithValue("@Username", username);

                object result = command.ExecuteScalar();
                return result != null ? result.ToString() : string.Empty;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error getting user role: " + e.Message);
                return string.Empty;
            }
            finally
            {
                connect.Close();
            }
        }

        public string GetUserFullName(string username)
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                sql = "SELECT fullname FROM [user] WHERE email = @Username";
                command = new SqlCommand(sql, connect);
                command.Parameters.AddWithValue("@Username", username);

                object result = command.ExecuteScalar();
                return result != null ? result.ToString() : string.Empty;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error getting user fullname: " + e.Message);
                return string.Empty;
            }
            finally
            {
                connect.Close();
            }
        }

        public DataTable getUser()
        {
            try
            {
                using (SqlConnection connector = new SqlConnection(databaseConnector))
                {
                    connector.Open();

                    string sql = "SELECT * FROM [user]";
                    using (SqlCommand command = new SqlCommand(sql, connector))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            return dataTable;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error getting user data: " + e.Message);
                return null;
            }
        }
    }
}
