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
    public partial class delete : Form
    {
        public delete()
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
        private Employee selectedEmployee;
        EMPdb db = new EMPdb();
        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;  // Set the dialog result to OK to indicate success
            this.Close();
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = searchDelete.Text.Trim();
            if (string.IsNullOrEmpty(searchTerm)) return;

            List<Employee> results = db.SearchEmployeeByName(searchTerm);

            if (results.Count > 0)
            {
                selectedEmployee = results[0]; // Assume first match (you can extend this with list selection if needed)

                nameDelete.Text = selectedEmployee.Name;
                addressDelete.Text = selectedEmployee.Address;
                ageDelete.Text = selectedEmployee.Age.ToString();
                if (selectedEmployee.Birthday < birthdayPickerDelete.MinDate)
                {
                    birthdayPickerDelete.Value = birthdayPickerDelete.MinDate;
                }
                else
                {
                    birthdayPickerDelete.Value = selectedEmployee.Birthday;
                }

                salaryDelete.Text = selectedEmployee.Salary.ToString();
                roleDelete.Text = selectedEmployee.Role;
                projectSelectorUpdate.SelectedItem = selectedEmployee.ProjectName;

                // Update department field based on project
                departmentDelete.Text = db.GetDepartmentByProjectName(selectedEmployee.ProjectName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (selectedEmployee == null)
            {
                MessageBox.Show("No employee selected.");
                return;
            }

            // Collect updated values
            string name = nameDelete.Text;

            // Call your update method
            bool success = db.DeleteEmployee(name);

            if (success)
            {
                MessageBox.Show("Employee deleted successfully.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to deleted employee.");
            }
            this.DialogResult = DialogResult.OK;  // Set the dialog result to OK to indicate success
            this.Close();
        }
    }
}
