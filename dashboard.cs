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
    public partial class dashboard : Form
    {
        public dashboard()
        {
            InitializeComponent();
            this.Load += dashboard_Load;
            searchBox.Enter += searchBox_Enter;
            searchBox.Leave += searchBox_Leave;

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
            var dbManager = new EMPdb();
            DGattendance.DataSource = dbManager.GetAllAttendance();
            DGemployee.DataSource = dbManager.GetAllEmployees();
            DGlogs.DataSource = dbManager.GetAllLogs();
            searchBox.Text = "Search employee...";
            searchBox.ForeColor = Color.Gray;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            add addEmp = new add();
            addEmp.Show();
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
            updateEmp.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            delete deleteEmp = new delete();
            deleteEmp.Show();
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
    }
}
