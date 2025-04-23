using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Management_System
{
    internal class EMPdb
    {
        private readonly string connectionString = "server=localhost; database=ems; uid=root; pwd='';";

        public bool AuthenticateUser(string username, string password)
        {
            using (var conn = new MySqlConnection(connectionString))

            {
                conn.Open();
                var query = $"SELECT COUNT(1) FROM manager WHERE manager_name=@Username AND password=@Password";
                using (var cmd = new MySqlCommand(query, conn))

                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);
                    var count = Convert.ToInt32(cmd.ExecuteScalar());
                    conn.Close();
                    return count == 1;

                }

            }

        }
        public void InsertUser(string username, string password, string email)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var query = "INSERT INTO Accounts (Username, Pass, Email) VALUES (@Username, @Pass, @Email)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Pass", password);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
        public void UpdateUser(string username, string password, string email)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var query = "UPDATE Accounts SET Pass = @Password, Email = @Email WHERE username = @username";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                //cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
        public void DeleteUser(string username)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var query = "DELETE FROM accounts WHERE username = @username";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public DataTable GetAllAttendance()
        {
            DataTable dt = new DataTable();
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
            SELECT 
                attendance_id AS 'Attendance ID', 
                employee_id AS 'Employee ID', 
                date AS 'Date', 
                status AS 'Status'
            FROM attendance";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }

            return dt;

        }

        public DataTable GetAllEmployees()
        {
            DataTable dt = new DataTable();
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
            SELECT 
                employee_id AS 'Employee ID', 
                name AS 'Name', 
                department_id AS 'Department ID'
            FROM employee";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }

            return dt;

        }

        public DataTable GetAllLogs()
        {
            DataTable dt = new DataTable();
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
            SELECT 
                log_id AS 'Log ID', 
                table_name AS 'Table', 
                action AS 'Action', 
                record_id AS 'Record ID',
                log_date AS 'Date',
                description AS 'Description'
            FROM logs";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }

            return dt;

        }
        public User SearchUserByUsername(string username)
        {
            User user = null;
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var query = "SELECT Username, Pass, Email FROM Accounts WHERE Username = @Username";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new User()
                            {
                                //UserId = reader.GetInt32("UserId"),
                                Username = reader["Username"].ToString(),
                                password = reader["Pass"].ToString(),
                                Email = reader["Email"].ToString()
                            };
                        }
                    }
                    conn.Close();
                }
            }
            return user;
        }
        public class User
        {
            public int UserId { get; set; }
            public string Username { get; set; }
            public string password { get; set; }
            public string Email { get; set; }
        }
    }
}
