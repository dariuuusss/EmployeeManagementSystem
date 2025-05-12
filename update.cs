using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employee_Management_System
{
    public partial class update : Form
    {
        public update()
        {
            InitializeComponent();
            LoadProjectNames();
        }
        private void LoadProjectNames()
        {
            EMPdb db = new EMPdb();
            List<string> projectNames = db.GetProjectNames();

            if (projectNames.Count > 0)
            {
                projectSelectorUpdate.Items.Clear();  // Clear existing items
                projectSelectorUpdate.Items.AddRange(projectNames.ToArray());  // Add new items
            }
            else
            {
                MessageBox.Show("No projects found in the database.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private Employee selectedEmployee;
        EMPdb db = new EMPdb();
        private void button1_Click(object sender, EventArgs e)
        {
            if (selectedEmployee == null)
            {
                MessageBox.Show("No employee selected.");
                return;
            }

            // Collect updated values
            string name = nameUpdate.Text;
            string address = addressUpdate.Text;
            int age = int.Parse(ageUpdate.Text);
            string birthday = birthdayPickerUpdate.Value.ToString("yyyy-MM-dd");
            decimal salary = decimal.Parse(salaryUpdate.Text);
            string role = roleUpdate.Text;
            string project = projectSelectorUpdate.SelectedItem.ToString();

            // Call your update method
            bool success = db.UpdateEmployeeDetails(selectedEmployee.EmployeeID, name, address, age, birthday, (int)salary, project, role);

            if (success)
            {
                MessageBox.Show("Employee details updated successfully.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to update employee details.");
            }
            this.DialogResult = DialogResult.OK;  // Set the dialog result to OK to indicate success
            this.Close();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;  // Set the dialog result to OK to indicate success
            this.Close();
        }

        private void searchUpdate_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = searchUpdate.Text.Trim();
            if (string.IsNullOrEmpty(searchTerm)) return;

            List<Employee> results = db.SearchEmployeeByName(searchTerm);

            if (results.Count > 0)
            {
                selectedEmployee = results[0]; // Assume first match (you can extend this with list selection if needed)

                nameUpdate.Text = selectedEmployee.Name;
                addressUpdate.Text = selectedEmployee.Address;
                ageUpdate.Text = selectedEmployee.Age.ToString();
                if (selectedEmployee.Birthday < birthdayPickerUpdate.MinDate)
                {
                    birthdayPickerUpdate.Value = birthdayPickerUpdate.MinDate;
                }
                else
                {
                    birthdayPickerUpdate.Value = selectedEmployee.Birthday;
                }

                salaryUpdate.Text = selectedEmployee.Salary.ToString();
                roleUpdate.Text = selectedEmployee.Role;
                projectSelectorUpdate.SelectedItem = selectedEmployee.ProjectName;

                // Update department field based on project
                departmentUpdate.Text = db.GetDepartmentByProjectName(selectedEmployee.ProjectName);
            }
        }

        private void projectSelectorUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected project name from the ComboBox
            string selectedProject = projectSelectorUpdate.SelectedItem.ToString();

            // Fetch the department name corresponding to the selected project from EMPdb.cs
            EMPdb empDb = new EMPdb();
            string departmentName = empDb.GetDepartmentByProjectName(selectedProject);
        }
    }
}
