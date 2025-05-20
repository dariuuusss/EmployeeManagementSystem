using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Employee_Management_System
{
    public partial class add : Form
    {
        public add()
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
                projectSelector.Items.Clear();  // Clear existing items
                projectSelector.Items.AddRange(projectNames.ToArray());  // Add new items
            }
            else
            {
                MessageBox.Show("No projects found in the database.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameAdd.Text) ||
                string.IsNullOrWhiteSpace(addressAdd.Text) ||
                string.IsNullOrWhiteSpace(ageAdd.Text) ||
                string.IsNullOrWhiteSpace(salaryAdd.Text) ||
                projectSelector.SelectedItem == null ||
                string.IsNullOrWhiteSpace(roleAdd.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Parse age and salary
            if (!int.TryParse(ageAdd.Text, out int age))
            {
                MessageBox.Show("Invalid age. Please enter a valid number.");
                return;
            }

            if (!int.TryParse(salaryAdd.Text, out int salary))
            {
                MessageBox.Show("Invalid salary. Please enter a valid number.");
                return;
            }

            DateTime birthday = birthdayPicker.Value;

            // Call stored procedure
            EMPdb db = new EMPdb();
            bool isSuccess = db.AddEmployee(
                nameAdd.Text,
                addressAdd.Text,
                age,
                birthday.ToString("yyyy-MM-dd"), // optional: format to string for SQL
                salary,
                projectSelector.SelectedItem.ToString(),
                roleAdd.Text
            );

            if (isSuccess)
            {
                MessageBox.Show("Employee added successfully.");
                this.DialogResult = DialogResult.OK;  // Set the dialog result to OK to indicate success
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void projectSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected project name from the ComboBox
            string selectedProject = projectSelector.SelectedItem.ToString();

            // Fetch the department name corresponding to the selected project from EMPdb.cs
            EMPdb empDb = new EMPdb();
            string departmentName = empDb.GetDepartmentByProjectName(selectedProject);

            // Update the label to show the department name
            departmentAdd.Text = string.IsNullOrEmpty(departmentName) ? "Department not found" : departmentName;
        }

        private void add_Load(object sender, EventArgs e)
        {

        }
    }
}
