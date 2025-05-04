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
        {
            string username = textUsername.Text;
            string password = textPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter username and password.");
                return;
            }

            EMPdb db = new EMPdb();
            string role = db.ValidateLogin(username, password);

            if (role != null)
            {
                MessageBox.Show("Login successful!");

                // Example: Redirect to Dashboard or Main Menu
                this.Hide();
                dashboard dashboard = new dashboard();
                dashboard.Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }

        private void textUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            signUp signUp = new signUp();
            signUp.Show();
            this.Hide();
        }

        private void ForgetPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgotPassword ForgotPassword = new ForgotPassword();
            ForgotPassword.Show();
            this.Hide();
        }
    }
}
