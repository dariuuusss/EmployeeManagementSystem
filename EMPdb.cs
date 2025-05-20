using MySql.Data.MySqlClient;
using Mysqlx.Datatypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Employee_Management_System
{
    internal class EMPdb
    {
        private readonly string connectionString = "server=localhost; database=ems; uid=root; pwd=''; Allow Zero Datetime=True; Convert Zero Datetime=True;";


        public bool InsertUser(string username, string password, string email,
                       string role, string securityQuestion, string securityAnswer)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("register_user", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_username", username);
                    cmd.Parameters.AddWithValue("@p_email", email);
                    cmd.Parameters.AddWithValue("@p_password", password); // Hashing in SQL
                    cmd.Parameters.AddWithValue("@p_role", role);
                    cmd.Parameters.AddWithValue("@p_sec_question", securityQuestion);
                    cmd.Parameters.AddWithValue("@p_sec_answer", securityAnswer);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        return true; // success
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                        return false; // failed
                    }
                }
            }
        }

        public string ValidateLogin(string username, string password)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("validate_login", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_username", username);
                    cmd.Parameters.AddWithValue("@p_password", password);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string role = reader["role"].ToString();
                            return role; // return user role or "success"
                        }
                        else
                        {
                            return null; // login failed
                        }
                    }
                }
            }
        }

        public bool ResetPassword(string username, string answer, string newPassword)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("update_password_by_username", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_username", username);
                    cmd.Parameters.AddWithValue("@p_answer", answer);
                    cmd.Parameters.AddWithValue("@p_new_password", newPassword);

                    var successParam = new MySqlParameter("@p_success", MySqlDbType.Bit);
                    successParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(successParam);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        return Convert.ToBoolean(successParam.Value);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                        return false;
                    }
                }
            }
        }


        public string GetSecurityQuestion(string username)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT security_question FROM users WHERE username = @username", conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    var result = cmd.ExecuteScalar();
                    return result?.ToString();
                }
            }
        }

        public bool AddEmployee(string name, string address, int age,
                       string birthday, int salary, string project, string role)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("AddNewEmployee", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@emp_name", name);
                    cmd.Parameters.AddWithValue("@emp_address", address);
                    cmd.Parameters.AddWithValue("@emp_age", age);
                    cmd.Parameters.AddWithValue("@emp_role", role);
                    cmd.Parameters.AddWithValue("@proj_name", project);
                    cmd.Parameters.AddWithValue("@emp_salary", salary);
                    DateTime parsedBirthday = DateTime.ParseExact(birthday, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    cmd.Parameters.Add("@emp_birthday", MySqlDbType.Date).Value = parsedBirthday;


                    try
                    {
                        cmd.ExecuteNonQuery();
                        return true; // success
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                        return false; // failed
                    }
                }
            }
        }
        public List<string> GetProjectNames()
        {
            List<string> projectNames = new List<string>();

            using (MySqlConnection connection = new MySqlConnection(connectionString)) // Use MySqlConnection
            {
                connection.Open();
                string query = "SELECT project_name FROM project"; // Assuming table and column names are correct

                MySqlCommand command = new MySqlCommand(query, connection); // Use MySqlCommand
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    projectNames.Add(reader["project_name"].ToString());
                }

                reader.Close();
            }

            return projectNames;
        }
        public string GetDepartmentByProjectName(string projectName)
        {
            string departmentName = string.Empty;

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = @"
                SELECT d.department_name 
                FROM project p
                JOIN department d ON p.department_id = d.department_id
                WHERE p.project_name = @projectName";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@projectName", projectName);

                var result = command.ExecuteScalar();
                departmentName = result?.ToString();  // Get the department name, or null if not found
            }

            return departmentName;
        }
        public List<Employee> SearchEmployeeByName(string searchTerm)
        {
            List<Employee> employeeList = new List<Employee>();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
            SELECT e.employee_id AS 'Employee ID', 
                   e.name AS 'Name', 
                   d.department_name AS 'Department Name', 
                   e.address AS 'Address', 
                   e.age AS 'Age', 
                   e.birthday AS 'Birthday', 
                   s.amount AS 'Salary', 
                   ep.role AS 'Role', 
                   p.project_name AS 'Project Name'
            FROM employee e
            LEFT JOIN department d ON e.department_id = d.department_id
            LEFT JOIN salary s ON e.employee_id = s.employee_id
            LEFT JOIN employee_project ep ON e.employee_id = ep.employee_id
            LEFT JOIN project p ON ep.project_id = p.project_id
            WHERE e.name LIKE @searchTerm";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Employee employee = new Employee
                                {
                                    // Handle NULL values using DBNull.Value
                                    EmployeeID = reader["Employee ID"] != DBNull.Value ? Convert.ToInt32(reader["Employee ID"]) : 0,
                                    Name = reader["Name"].ToString(),
                                    DepartmentName = reader["Department Name"] != DBNull.Value ? reader["Department Name"].ToString() : "N/A",
                                    Address = reader["Address"] != DBNull.Value ? reader["Address"].ToString() : "N/A",
                                    Age = reader["Age"] != DBNull.Value ? Convert.ToInt32(reader["Age"]) : 0,
                                    Birthday = reader["Birthday"] != DBNull.Value ? Convert.ToDateTime(reader["Birthday"]) : DateTime.MinValue,
                                    Salary = reader["Salary"] != DBNull.Value ? Convert.ToDecimal(reader["Salary"]) : 0.00m,
                                    Role = reader["Role"] != DBNull.Value ? reader["Role"].ToString() : "N/A",
                                    ProjectName = reader["Project Name"] != DBNull.Value ? reader["Project Name"].ToString() : "N/A"
                                };

                                employeeList.Add(employee);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching employee details: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return employeeList;
        }




        public bool UpdateEmployeeDetails(int employeeId, string name, string address, int age, string birthday, int salary, string project, string role)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string updateQuery = @"
                UPDATE employee SET name = @name, address = @address, age = @age, birthday = @birthday 
                WHERE employee_id = @employeeId;

                UPDATE salary SET amount = @salary WHERE employee_id = @employeeId;

                UPDATE employee_project ep
                JOIN project p ON ep.project_id = p.project_id
                SET ep.role = @role, ep.project_id = p.project_id
                WHERE ep.employee_id = @employeeId AND p.project_name = @project;";

                    MySqlCommand cmd = new MySqlCommand(updateQuery, conn);
                    cmd.Parameters.AddWithValue("@employeeId", employeeId);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@address", address);
                    cmd.Parameters.AddWithValue("@age", age);
                    cmd.Parameters.AddWithValue("@birthday", DateTime.ParseExact(birthday, "yyyy-MM-dd", CultureInfo.InvariantCulture));
                    cmd.Parameters.AddWithValue("@salary", salary);
                    cmd.Parameters.AddWithValue("@project", project);
                    cmd.Parameters.AddWithValue("@role", role);

                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update Error: " + ex.Message);
                return false;
            }
        }

        public bool DeleteEmployee(string name)
        {
            
            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    var query = "DELETE FROM employee WHERE name = @name";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete Error: " + ex.Message);
                return false;
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
                status AS 'Status',
                punch_time AS 'Time'
            FROM attendance
            ORDER BY date DESC, punch_time DESC";

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
                string query = "SELECT * FROM employee_details";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                adapter.Fill(dt);
                return dt;
            }
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
                                Password = reader["Pass"].ToString(),
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
            public string Password { get; set; }
            public string Email { get; set; }
        }

        public bool DoesEmployeeExist(string employeeId)
        {
            // Query the database to check if the employee exists

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM employee WHERE employee_id = @employeeId";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@employeeId", employeeId);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
                    
            }
        }

        public string GetAttendanceStatus(string employeeId, DateTime date)
        {
            string status = null;
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT status 
                    FROM attendance 
                    WHERE employee_id = @employeeId 
                    AND DATE(date) = DATE(@date)
                    ORDER BY punch_time DESC
                    LIMIT 1";
                
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@employeeId", employeeId);
                    cmd.Parameters.AddWithValue("@date", date);
                    var result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        status = result.ToString();
                    }
                    return status;
                }
            }
        }

        public void RecordAttendance(string employeeId, string status)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                DateTime now = DateTime.Now;

                // Check if the last status is the same as the current status
                string lastStatus = GetAttendanceStatus(employeeId, now);
                if (lastStatus == status)
                {
                    MessageBox.Show($"You have already recorded {status} for today.", "Warning", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // If trying to record OUT without IN
                else if (status == "OUT" && (lastStatus == null || lastStatus != "IN"))
                {
                    MessageBox.Show("You need to record IN first before recording OUT.", "Warning", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    string query = @"
                    INSERT INTO attendance (employee_id, date, status, punch_time) 
                    VALUES (@employeeId, @date, @status, @punchTime)";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@employeeId", employeeId);
                        cmd.Parameters.AddWithValue("@date", now.Date);
                        cmd.Parameters.AddWithValue("@status", status);
                        cmd.Parameters.AddWithValue("@punchTime", now.TimeOfDay);
                        cmd.ExecuteNonQuery();
                    }
                    if(status == "OUT"){
                        MessageBox.Show("Time OUT recorded successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Time IN recorded successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                        return;
                }
            }
        }

    }
}
