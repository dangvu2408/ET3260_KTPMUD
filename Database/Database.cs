﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows;
using System.Xml.Linq;
using ET3260_Project.Views;
using static System.Runtime.InteropServices.JavaScript.JSType;


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
                MessageBox.Show("Lỗi thêm người dùng mới: " + e.Message);
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
                MessageBox.Show("Lỗi xác thực: " + e.Message);
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
                MessageBox.Show("Lỗi lấy quyền người dùng: " + e.Message);
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
                MessageBox.Show("Lỗi lấy tên người dùng: " + e.Message);
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
                MessageBox.Show("Lỗi lấy thông tin người dùng: " + e.Message);
                return null;
            }
        }

        public bool addDiemLuQuet(string tenDiem, string diaDiem, string date)
        {
            try
            {
                using (SqlConnection connector = new SqlConnection(databaseConnector))
                {
                    connector.Open();

                    string sql = "INSERT INTO diemLuQuet (tenDiemLQ, diaDiemLQ, ngayLuQuet) VALUES (@Name, @Address, @Date)";
                    using (SqlCommand cmd = new SqlCommand(sql, connector))
                    {
                        cmd.Parameters.AddWithValue("@Name", tenDiem);
                        cmd.Parameters.AddWithValue("@Address", diaDiem);
                        cmd.Parameters.AddWithValue("@Date", date);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi thêm điểm lũ quét: " + e.Message);
                return false;
            }
        }

        public bool addDiemTruotLo(string tenDiem, string diaDiem, string date)
        {
            try
            {
                using (SqlConnection connector = new SqlConnection(databaseConnector))
                {
                    connector.Open();

                    string sql = "INSERT INTO diemTruotLo (tenDiemTL, diaDiemTL, ngayTruotLo) VALUES (@Name, @Address, @Date)";
                    using (SqlCommand cmd = new SqlCommand(sql, connector))
                    {
                        cmd.Parameters.AddWithValue("@Name", tenDiem);
                        cmd.Parameters.AddWithValue("@Address", diaDiem);
                        cmd.Parameters.AddWithValue("@Date", date);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi thêm điểm lũ quét: " + e.Message);
                return false;
            }
        }

        public bool addTrieuChung(string tenTrieuChung, string mota)
        {
            try
            {
                using (SqlConnection connector = new SqlConnection(databaseConnector))
                {
                    connector.Open();

                    string sql = "INSERT INTO trieuChung (tenTrieuChung, moTa) VALUES (@Name, @Describe)";
                    using (SqlCommand cmd = new SqlCommand(sql, connector))
                    {
                        cmd.Parameters.AddWithValue("@Name", tenTrieuChung);
                        cmd.Parameters.AddWithValue("@Describe", mota);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi thêm triệu chứng lâm sàng: " + e.Message);
                return false;
            }
        }

        public DataTable getTrieuChung()
        {
            try
            {
                using (SqlConnection connector = new SqlConnection(databaseConnector))
                {
                    connector.Open();

                    string sql = "SELECT * FROM trieuChung";
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
                MessageBox.Show("Lỗi lấy triệu chứng: " + e.Message);
                return null;
            }
        }

        public bool addLoaiDichBenh(string tenLoaiDich, string moTa, List<int> listTrieuChungIds)
        {
            try
            {
                using (SqlConnection connector = new SqlConnection(databaseConnector))
                {
                    connector.Open();

                    string sql = "INSERT INTO loaiDichBenh (tenLoaiDich, moTa) OUTPUT INSERTED.id_loaiDich VALUES (@tenLoaiDich, @moTa)";
                    using (SqlCommand cmd = new SqlCommand(sql, connector))
                    {
                        cmd.Parameters.AddWithValue("@tenLoaiDich", tenLoaiDich);
                        cmd.Parameters.AddWithValue("@moTa", moTa);

                        int idLoaiDich = (int)cmd.ExecuteScalar();

                        foreach (var trieuChungId in listTrieuChungIds)
                        {
                            string insertTrieuChungQuery = "INSERT INTO loaiDichBenh_trieuChung (id_loaiDich, id_trieuChung) VALUES (@idLoaiDich, @idTrieuChung)";
                            using (SqlCommand insertCmd = new SqlCommand(insertTrieuChungQuery, connector))
                            {
                                insertCmd.Parameters.AddWithValue("@idLoaiDich", idLoaiDich);
                                insertCmd.Parameters.AddWithValue("@idTrieuChung", trieuChungId);
                                insertCmd.ExecuteNonQuery();
                            }
                        }

                        int rowsAffected = cmd.ExecuteNonQuery();

                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi thêm loại dịch bệnh: " + e.Message);
                return false;
            }
        }

        public DataTable getLoaiDich()
        {
            try
            {
                using (SqlConnection connector = new SqlConnection(databaseConnector))
                {
                    connector.Open();

                    string sql = "SELECT * FROM loaiDichBenh";
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
                MessageBox.Show("Lỗi lấy loại dịch bệnh: " + e.Message);
                return null;
            }
        }

        public bool addODich(string tenODich, List<int> listLoaiDichIds, string dayODich, int statusOD)
        {
            try
            {
                using (SqlConnection connector = new SqlConnection(databaseConnector))
                {
                    connector.Open();

                    string sql = "INSERT INTO ODich (tenODich, ngayPhatHien, trangThai) OUTPUT INSERTED.id_ODich VALUES (@tenODich, @ngayPhatHien, @trangThai)";
                    using (SqlCommand cmd = new SqlCommand(sql, connector))
                    {
                        cmd.Parameters.AddWithValue("@tenODich", tenODich);
                        cmd.Parameters.AddWithValue("@ngayPhatHien", dayODich);
                        cmd.Parameters.AddWithValue("@trangThai", statusOD);

                        int idODich = (int)cmd.ExecuteScalar();

                        foreach (var loaiDichId in listLoaiDichIds)
                        {
                            string insertQuery = "INSERT INTO ODich_LoaiDich (id_ODich, id_loaiDich) VALUES (@idODich, @idLoaiDich)";
                            using (SqlCommand insertCmd = new SqlCommand(insertQuery, connector))
                            {
                                insertCmd.Parameters.AddWithValue("@idODich", idODich);
                                insertCmd.Parameters.AddWithValue("@idLoaiDich", loaiDichId);
                                insertCmd.ExecuteNonQuery();
                            }
                        }

                        int rowsAffected = cmd.ExecuteNonQuery();

                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi thêm ổ dịch bệnh: " + e.Message);
                return false;
            }
        }

        public DataTable getODich()
        {
            try
            {
                using (SqlConnection connector = new SqlConnection(databaseConnector))
                {
                    connector.Open();

                    string sql = "SELECT * FROM ODich";
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
                MessageBox.Show("Lỗi lấy ổ dịch: " + e.Message);
                return null;
            }
        }

        public bool addLichTiemPhong(string tenVaccine, int ODichID, string ngayTiem, int soLuong) 
        {
            try
            {
                using (SqlConnection connector = new SqlConnection(databaseConnector))
                {
                    connector.Open();

                    string sql = "INSERT INTO Vaccine (tenVaccine) OUTPUT INSERTED.id_Vaccine VALUES (@tenVaccine)";
                    using (SqlCommand cmd = new SqlCommand(sql, connector))
                    {
                        cmd.Parameters.AddWithValue("@tenVaccine", tenVaccine);

                        int idVaccine = (int)cmd.ExecuteScalar();

                        string insertQuery = "INSERT INTO Vaccine_ODich (id_Vaccine, id_ODich, ngayTiem, soLuongTiem) VALUES (@id_Vaccine, @id_ODich, @NgayTiem, @SoLuong)";
                        using (SqlCommand insertCmd = new SqlCommand(insertQuery, connector))
                        {
                            insertCmd.Parameters.AddWithValue("@id_Vaccine", idVaccine);
                            insertCmd.Parameters.AddWithValue("@id_ODich", ODichID);
                            insertCmd.Parameters.AddWithValue("@NgayTiem", ngayTiem);
                            insertCmd.Parameters.AddWithValue("@SoLuong", soLuong);
                            insertCmd.ExecuteNonQuery();
                        }

                        int rowsAffected = cmd.ExecuteNonQuery();

                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi thêm lịch vaccine: " + e.Message);
                return false;
            }
        }

        public DataTable getLichTiem()
        {
            // nothing to think...
            return null;
        }

        public bool addChiCucThuY(string tenChiCuc, string diaChiCC, string soDienThoaiCC)
        {
            try
            {
                using (SqlConnection connector = new SqlConnection(databaseConnector))
                {
                    connector.Open();

                    string sql = "INSERT INTO chiCucThuY (tenChiCuc, diaChiCC, soDienThoaiCC) VALUES (@Ten, @Diachi, @SDT)";
                    using (SqlCommand cmd = new SqlCommand(sql, connector))
                    {
                        cmd.Parameters.AddWithValue("@Ten", tenChiCuc);
                        cmd.Parameters.AddWithValue("@Diachi", diaChiCC);
                        cmd.Parameters.AddWithValue("@SDT", soDienThoaiCC);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi thêm người dùng mới: " + e.Message);
                return false;
            }
        }
    }
}
