using System;
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

        public string GetUserEmail(string username)
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                sql = "SELECT email FROM [user] WHERE email = @Username";
                command = new SqlCommand(sql, connect);
                command.Parameters.AddWithValue("@Username", username);

                object result = command.ExecuteScalar();
                return result != null ? result.ToString() : string.Empty;
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi lấy email người dùng: " + e.Message);
                return string.Empty;
            }
            finally
            {
                connect.Close();
            }
        }

        public string GetUserPassword(string username)
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                sql = "SELECT password FROM [user] WHERE email = @Username";
                command = new SqlCommand(sql, connect);
                command.Parameters.AddWithValue("@Username", username);

                object result = command.ExecuteScalar();
                return result != null ? result.ToString() : string.Empty;
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi lấy mật khẩu người dùng: " + e.Message);
                return string.Empty;
            }
            finally
            {
                connect.Close();
            }
        }

        public string GetUserID(string username)
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                sql = "SELECT ID FROM [user] WHERE email = @Username";
                command = new SqlCommand(sql, connect);
                command.Parameters.AddWithValue("@Username", username);

                object result = command.ExecuteScalar();
                return result != null ? result.ToString() : string.Empty;
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi lấy ID người dùng: " + e.Message);
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

        public DataTable getDiemLuQuet()
        {
            try
            {
                using (SqlConnection connector = new SqlConnection(databaseConnector))
                {
                    connector.Open();

                    string sql = "SELECT * FROM diemLuQuet";
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
                MessageBox.Show("Lỗi lấy điểm lũ quét: " + e.Message);
                return null;
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

        public DataTable getDiemTruotLo()
        {
            try
            {
                using (SqlConnection connector = new SqlConnection(databaseConnector))
                {
                    connector.Open();

                    string sql = "SELECT * FROM diemTruotLo";
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
                MessageBox.Show("Lỗi lấy điểm trượt lở: " + e.Message);
                return null;
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
                MessageBox.Show("Lỗi thêm chi cục thú y: " + e.Message);
                return false;
            }
        }

        public DataTable getChiCuc()
        {
            try
            {
                using (SqlConnection connector = new SqlConnection(databaseConnector))
                {
                    connector.Open();

                    string sql = "SELECT * FROM chiCucThuY";
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
                MessageBox.Show("Lỗi lấy chi cục thú y: " + e.Message);
                return null;
            }
        }

        public bool addDaiLyThuoc(string tenDaiLy, int idChiCuc, string diaChiDL, string soDienThoaiDL)
        {
            try
            {
                using (SqlConnection connector = new SqlConnection(databaseConnector))
                {
                    connector.Open();

                    string sql = "INSERT INTO daiLyThuoc (tenDaiLy, id_chiCuc, diaChiDL, soDienThoaiDL) VALUES (@Ten, @IDCC, @Diachi, @SDT)";
                    using (SqlCommand cmd = new SqlCommand(sql, connector))
                    {
                        cmd.Parameters.AddWithValue("@Ten", tenDaiLy);
                        cmd.Parameters.AddWithValue("@Diachi", diaChiDL);
                        cmd.Parameters.AddWithValue("@SDT", soDienThoaiDL);
                        cmd.Parameters.AddWithValue("@IDCC", idChiCuc);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi thêm đại lý bán thuốc: " + e.Message);
                return false;
            }
        }

        public DataTable getDaiLy()
        {
            try
            {
                using (SqlConnection connector = new SqlConnection(databaseConnector))
                {
                    connector.Open();

                    string sql = "SELECT * FROM daiLyThuoc";
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
                MessageBox.Show("Lỗi lấy đại lý thuốc: " + e.Message);
                return null;
            }
        }

        public bool addKhuTamGiu(string tenKhuTamGiu, int idChiCuc, string diaChiKTG, string soDienThoaiKTG)
        {
            try
            {
                using (SqlConnection connector = new SqlConnection(databaseConnector))
                {
                    connector.Open();

                    string sql = "INSERT INTO khuTamGiu (tenKhuTamGiu, id_chiCuc, diaChiKTG, soDienThoaiKTG) VALUES (@Ten, @IDCC, @Diachi, @SDT)";
                    using (SqlCommand cmd = new SqlCommand(sql, connector))
                    {
                        cmd.Parameters.AddWithValue("@Ten", tenKhuTamGiu);
                        cmd.Parameters.AddWithValue("@Diachi", diaChiKTG);
                        cmd.Parameters.AddWithValue("@SDT", soDienThoaiKTG);
                        cmd.Parameters.AddWithValue("@IDCC", idChiCuc);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi thêm khu tạm giữ: " + e.Message);
                return false;
            }
        }

        public DataTable getKhuTamGiu()
        {
            try
            {
                using (SqlConnection connector = new SqlConnection(databaseConnector))
                {
                    connector.Open();

                    string sql = "SELECT * FROM khuTamGiu";
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
                MessageBox.Show("Lỗi lấy khu tạm giữ: " + e.Message);
                return null;
            }
        }

        public bool addCoSoChanNuoi(string tenCoSoCN, int idChiCuc, string diaChiCSCN, string soDienThoaiCSCN)
        {
            try
            {
                using (SqlConnection connector = new SqlConnection(databaseConnector))
                {
                    connector.Open();

                    string sql = "INSERT INTO coSoChanNuoi (tenCoSo, id_chiCuc, diaChiCoSo, soDienThoaiCS) VALUES (@Ten, @IDCC, @Diachi, @SDT)";
                    using (SqlCommand cmd = new SqlCommand(sql, connector))
                    {
                        cmd.Parameters.AddWithValue("@Ten", tenCoSoCN);
                        cmd.Parameters.AddWithValue("@Diachi", diaChiCSCN);
                        cmd.Parameters.AddWithValue("@SDT", soDienThoaiCSCN);
                        cmd.Parameters.AddWithValue("@IDCC", idChiCuc);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi thêm cơ sở chăn nuôi: " + e.Message);
                return false;
            }
        }

        public DataTable getCoSoChanNuoi()
        {
            try
            {
                using (SqlConnection connector = new SqlConnection(databaseConnector))
                {
                    connector.Open();

                    string sql = "SELECT * FROM coSoChanNuoi";
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
                MessageBox.Show("Lỗi lấy cơ sở chăn nuôi: " + e.Message);
                return null;
            }
        }

        public bool addCoSoCheBien(string tenCoSoCB, List<int> listCoSoChanNuoiIds, string diaChiCSCB, string soDienThoaiCSCB)
        {
            try
            {
                using (SqlConnection connector = new SqlConnection(databaseConnector))
                {
                    connector.Open();

                    string sql = "INSERT INTO coSoCheBien (tenCSCB, diaChiCS, soDienThoaiCS) OUTPUT INSERTED.id_csCheBien VALUES (@tenCSCB, @diaChiCS, @soDienThoaiCS)";
                    using (SqlCommand cmd = new SqlCommand(sql, connector))
                    {
                        cmd.Parameters.AddWithValue("@tenCSCB", tenCoSoCB);
                        cmd.Parameters.AddWithValue("@diaChiCS", diaChiCSCB);
                        cmd.Parameters.AddWithValue("@soDienThoaiCS", diaChiCSCB);

                        int idCoSoCheBien = (int)cmd.ExecuteScalar();

                        foreach (var coSoChanNuoiId in listCoSoChanNuoiIds)
                        {
                            string insertTrieuChungQuery = "INSERT INTO coSoChanNuoi_CoSoCheBien (id_csChanNuoi, id_csCheBien) VALUES (@id_csChanNuoi, @id_csCheBien)";
                            using (SqlCommand insertCmd = new SqlCommand(insertTrieuChungQuery, connector))
                            {
                                insertCmd.Parameters.AddWithValue("@id_csCheBien", idCoSoCheBien);
                                insertCmd.Parameters.AddWithValue("@id_csChanNuoi", coSoChanNuoiId);
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
                MessageBox.Show("Lỗi thêm cơ sở chế biến: " + e.Message);
                return false;
            }
        }

        public DataTable getCoSoCheBien()
        {
            try
            {
                using (SqlConnection connector = new SqlConnection(databaseConnector))
                {
                    connector.Open();

                    string sql = "SELECT * FROM coSoCheBien";
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
                MessageBox.Show("Lỗi lấy cơ sở chế biến: " + e.Message);
                return null;
            }
        }

        public bool addCoSoGietMo(string tenCosoGM, int idChiCuc, string diaChiCSGM, string soDienThoaiCSGM)
        {
            try
            {
                using (SqlConnection connector = new SqlConnection(databaseConnector))
                {
                    connector.Open();

                    string sql = "INSERT INTO coSoGietMo (tenCosoGM, id_chiCuc, diaChiCSGM, soDienThoaiCSGM) VALUES (@Ten, @IDCC, @Diachi, @SDT)";
                    using (SqlCommand cmd = new SqlCommand(sql, connector))
                    {
                        cmd.Parameters.AddWithValue("@Ten", tenCosoGM);
                        cmd.Parameters.AddWithValue("@Diachi", diaChiCSGM);
                        cmd.Parameters.AddWithValue("@SDT", soDienThoaiCSGM);
                        cmd.Parameters.AddWithValue("@IDCC", idChiCuc);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi thêm cơ sở giết mổ: " + e.Message);
                return false;
            }
        }

        public DataTable getCoSoGietMo()
        {
            try
            {
                using (SqlConnection connector = new SqlConnection(databaseConnector))
                {
                    connector.Open();

                    string sql = "SELECT * FROM coSoGietMo";
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
                MessageBox.Show("Lỗi lấy cơ sở giết mổ: " + e.Message);
                return null;
            }
        }

        public bool addToChucChungNhan(string tenTC, string nguoiDaiDien, string email, string soDT)
        {
            try
            {
                using (SqlConnection connector = new SqlConnection(databaseConnector))
                {
                    connector.Open();

                    string sql = "INSERT INTO toChucChungNhan (tenTC, nguoiDaiDien, email, soDT) VALUES (@Ten, @NguoiDaiDien, @Email, @SDT)";
                    using (SqlCommand cmd = new SqlCommand(sql, connector))
                    {
                        cmd.Parameters.AddWithValue("@Ten", tenTC);
                        cmd.Parameters.AddWithValue("@NguoiDaiDien", nguoiDaiDien);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@SDT", soDT);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi thêm tổ chức chứng nhận: " + e.Message);
                return false;
            }
        }

        public DataTable getToChucChungNhan()
        {
            try
            {
                using (SqlConnection connector = new SqlConnection(databaseConnector))
                {
                    connector.Open();

                    string sql = "SELECT * FROM toChucChungNhan";
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
                MessageBox.Show("Lỗi lấy tổ chức chứng nhận: " + e.Message);
                return null;
            }
        }

        public bool addGiayChungNhan(string tenChungNhan, int idToChuc, List<int> listIdCoSoCN, string ngayChungNhan)
        {
            try
            {
                using (SqlConnection connector = new SqlConnection(databaseConnector))
                {
                    connector.Open();

                    string sql = "INSERT INTO giayChungNhan (tenCN, id_tochucCN, ngayCN) OUTPUT INSERTED.id_giayCN VALUES (@tenCN, @id_tochucCN, @ngayCN)";
                    using (SqlCommand cmd = new SqlCommand(sql, connector))
                    {
                        cmd.Parameters.AddWithValue("@tenCN", tenChungNhan);
                        cmd.Parameters.AddWithValue("@id_tochucCN", idToChuc);
                        cmd.Parameters.AddWithValue("@ngayCN", ngayChungNhan);

                        int idGiayChungNhan = (int)cmd.ExecuteScalar();

                        foreach (var coSoChanNuoiId in listIdCoSoCN)
                        {
                            string insertTrieuChungQuery = "INSERT INTO csChanNuoi_giayChungNhan (id_csChanNuoi, id_giayCN) VALUES (@id_csChanNuoi, @id_giayCN)";
                            using (SqlCommand insertCmd = new SqlCommand(insertTrieuChungQuery, connector))
                            {
                                insertCmd.Parameters.AddWithValue("@id_csCheBien", idGiayChungNhan);
                                insertCmd.Parameters.AddWithValue("@id_giayCN", coSoChanNuoiId);
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
                MessageBox.Show("Lỗi thêm giấy chứng nhận: " + e.Message);
                return false;
            }
        }

        public DataTable getGiayChungNhan()
        {
            try
            {
                using (SqlConnection connector = new SqlConnection(databaseConnector))
                {
                    connector.Open();

                    string sql = "SELECT * FROM giayChungNhan";
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
                MessageBox.Show("Lỗi lấy giấy chứng nhận: " + e.Message);
                return null;
            }
        }

        public bool addVungChanNuoi(string diaDiem, int idChiCuc, int trangThai)
        {
            try
            {
                using (SqlConnection connector = new SqlConnection(databaseConnector))
                {
                    connector.Open();

                    string sql = "INSERT INTO vungChanNuoi (diaDiem, trangThai, id_csChanNuoi) VALUES (@diaDiem, @trangThai, @id_csChanNuoi)";
                    using (SqlCommand cmd = new SqlCommand(sql, connector))
                    {
                        cmd.Parameters.AddWithValue("@diaDiem", diaDiem);
                        cmd.Parameters.AddWithValue("@trangThai", trangThai);
                        cmd.Parameters.AddWithValue("@id_csChanNuoi", idChiCuc);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi thêm vùng chăn nuôi: " + e.Message);
                return false;
            }
        }

        public DataTable getVungChanNuoi()
        {
            try
            {
                using (SqlConnection connector = new SqlConnection(databaseConnector))
                {
                    connector.Open();

                    string sql = "SELECT * FROM vungChanNuoi";
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
                MessageBox.Show("Lỗi lấy vùng chăn nuôi: " + e.Message);
                return null;
            }
        }

        public bool addHoChanNuoi(string name, int idVung, string nguoiDaiDien, string email, string soDienthoai)
        {
            try
            {
                using (SqlConnection connector = new SqlConnection(databaseConnector))
                {
                    connector.Open();

                    string sql = "INSERT INTO hoChanNuoi (id_vungChanNuoi, tenHo, nguoiDaiDien, email, soDT) VALUES (@id_vungChanNuoi, @tenHo, @nguoiDaiDien, @email, @SDT)";
                    using (SqlCommand cmd = new SqlCommand(sql, connector))
                    {
                        cmd.Parameters.AddWithValue("@id_vungChanNuoi", idVung);
                        cmd.Parameters.AddWithValue("@tenHo", name);
                        cmd.Parameters.AddWithValue("@nguoiDaiDien", nguoiDaiDien);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@SDT", soDienthoai);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi thêm hộ chăn nuôi: " + e.Message);
                return false;
            }
        }

        public DataTable getHoChanNuoi()
        {
            try
            {
                using (SqlConnection connector = new SqlConnection(databaseConnector))
                {
                    connector.Open();

                    string sql = "SELECT * FROM hoChanNuoi";
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
                MessageBox.Show("Lỗi lấy hộ chăn nuôi: " + e.Message);
                return null;
            }
        }

        public bool updateUser(string id, string email, int role, string fullname)
        {
            try
            {
                using (SqlConnection connector = new SqlConnection(databaseConnector))
                {
                    connector.Open();

                    string sql = "UPDATE [user] SET email = @Email, fullname = @Fullname, role = @Role WHERE id = @Id";
                    using (SqlCommand cmd = new SqlCommand(sql, connector))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Role", role);
                        cmd.Parameters.AddWithValue("@Fullname", fullname);
                        cmd.Parameters.AddWithValue("@Id", id);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi cập nhật thông tin người dùng: " + e.Message);
                return false;
            }
        }
    }
}
