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
    public partial class attendanceMode : Form
    {
        public attendanceMode()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 Form1 = new Form1();
            Form1.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string employeeId = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(employeeId))
            {
                MessageBox.Show("Please enter a valid Employee ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                EMPdb empDb = new EMPdb();

                // Check if the employee exists
                if (!empDb.DoesEmployeeExist(employeeId))
                {
                    MessageBox.Show("Employee does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Record time in
                empDb.RecordAttendance(employeeId, "IN");
                MessageBox.Show("Time IN recorded successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Clear(); // Clear the input after successful recording
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string employeeId = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(employeeId))
            {
                MessageBox.Show("Please enter a valid Employee ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                EMPdb empDb = new EMPdb();

                // Check if the employee exists
                if (!empDb.DoesEmployeeExist(employeeId))
                {
                    MessageBox.Show("Employee does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Record time out
                empDb.RecordAttendance(employeeId, "OUT");
                MessageBox.Show("Time OUT recorded successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Clear(); // Clear the input after successful recording
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
