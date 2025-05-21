using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace Employee_Management_System
{
    public partial class dashboard : Form
    {
        private EMPdb db;
        public dashboard()
        {
            InitializeComponent();
            this.Load += dashboard_Load;
            searchBox.Enter += searchBox_Enter;
            searchBox.Leave += searchBox_Leave;
            db = new EMPdb();
            ReloadEmployeeData();
        }

        public void ReloadEmployeeData()
        {
            DGemployee.DataSource = db.GetAllEmployees();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dashboard_Load(object sender, EventArgs e)
        {
            
            DGattendance.DataSource = db.GetAllAttendance();
            DGemployee.DataSource = db.GetAllEmployees();
            DGlogs.DataSource = db.GetAllLogs();
            searchBox.Text = "Search employee...";
            searchBox.ForeColor = Color.Gray;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            add addEmp = new add();
            this.Hide();
            if (addEmp.ShowDialog() == DialogResult.OK)
            {
                this.Show();
                ReloadEmployeeData();
            }
        }
        private void searchBox_Enter(object sender, EventArgs e)
        {
            if (searchBox.Text == "Search employee...")
            {
                searchBox.Text = "";
                searchBox.ForeColor = Color.Black;
            }
        }

        private void searchBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(searchBox.Text))
            {
                searchBox.Text = "Search employee...";
                searchBox.ForeColor = Color.Gray;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            update updateEmp = new update();
            this.Hide();
            if (updateEmp.ShowDialog() == DialogResult.OK)
            {
                this.Show();
                ReloadEmployeeData();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            delete deleteEmp = new delete();
            this.Hide();
            if (deleteEmp.ShowDialog() == DialogResult.OK)
            {
                this.Show();
                ReloadEmployeeData();
            }
        }

        private void LogOut_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Logout",
                                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Hide();
                Form1 login = new Form1();
                login.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(searchBox.Text))
            {
                EMPdb db = new EMPdb();
                List<Employee> employees = db.SearchEmployeeByName(searchBox.Text);

                resultBox.Items.Clear();

                // Populate the ListBox with employee names only
                foreach (var employee in employees)
                {
                    resultBox.Items.Add(employee.Name);
                }
            }
            else
            {
                resultBox.Items.Clear();  // Clear the list when the search box is empty
            }
        }

        private void resultBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (resultBox.SelectedItem != null)
            {
                string selectedName = resultBox.SelectedItem.ToString();

                // Fetch the employee details based on the selected name
                EMPdb db = new EMPdb();
                List<Employee> employees = db.SearchEmployeeByName(selectedName);

                // Find the selected employee from the list
                Employee selectedEmployee = employees.FirstOrDefault(emp => emp.Name == selectedName);

                if (selectedEmployee != null)
                {
                    // Display employee details in a message box
                    string employeeDetails = $@"
                    Employee ID: {selectedEmployee.EmployeeID}
                    Name: {selectedEmployee.Name}
                    Department: {selectedEmployee.DepartmentName}
                    Address: {selectedEmployee.Address}
                    Age: {selectedEmployee.Age}
                    Birthday: {selectedEmployee.Birthday.ToShortDateString()}
                    Salary: {selectedEmployee.Salary:C}
                    Role: {selectedEmployee.Role}
                    Project: {selectedEmployee.ProjectName}";

                    MessageBox.Show(employeeDetails, "Employee Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void dashboard_Load_1(object sender, EventArgs e)
        {

        }

        private void DGemployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            attendanceMode attendanceMode = new attendanceMode();
            attendanceMode.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ExportToExcel(DataGridView dgv, string fileName)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = false;
                Workbook workbook = excel.Workbooks.Add();
                Worksheet worksheet = workbook.Worksheets[1];

                // Export headers
                for (int i = 1; i <= dgv.Columns.Count; i++)
                {
                    worksheet.Cells[1, i] = dgv.Columns[i - 1].HeaderText;
                }

                // Export data
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dgv.Rows[i].Cells[j].Value?.ToString() ?? "";
                    }
                }

                // Auto-fit columns
                worksheet.Columns.AutoFit();

                // Get the application's directory and the Exported Files folder
                string exportFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "EMS", "Exported Files");

                // Ensure the folder exists
                if (!Directory.Exists(exportFolder))
                {
                    Directory.CreateDirectory(exportFolder);
                }

                // Save the file in the Exported Files folder
                string savePath = Path.Combine(exportFolder, fileName);
                workbook.SaveAs(savePath);
                workbook.Close();
                excel.Quit();

                MessageBox.Show($"File exported successfully to: {savePath}", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting to Excel: {ex.Message}", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void attendanceExport_Click(object sender, EventArgs e)
        {
            ExportToExcel(DGattendance, "Attendance_Report.xlsx");
        }

        private void employeeExport_Click(object sender, EventArgs e)
        {
            ExportToExcel(DGemployee, "Employee_List.xlsx");
        }

        private void logsExport_Click(object sender, EventArgs e)
        {
            ExportToExcel(DGlogs, "System_Logs.xlsx");
        }
    }
}
