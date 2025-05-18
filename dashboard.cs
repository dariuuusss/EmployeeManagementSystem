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
    }
}
