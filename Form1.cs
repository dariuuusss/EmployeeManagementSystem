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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {/*
            var dbManager = new EMPdb();
            bool isAuthenticated = dbManager.AuthenticateUser(textUsername.Text, textPassword.Text);

            if (isAuthenticated)
            {
                MessageBox.Show("Login Successful. Click OK to view Application's Dashboard", "Sucess!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                dashboard dashboard = new dashboard();
                dashboard.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Login Failed. Please check your username and password.", "Invalid Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            */
            dashboard dashboard = new dashboard();
            dashboard.Show();
            this.Hide();
        }

        private void textUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
