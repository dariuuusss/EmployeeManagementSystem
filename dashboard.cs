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
        }
    }
}
