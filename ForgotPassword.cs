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
    public partial class ForgotPassword : Form
    {
        public ForgotPassword()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EMPdb db = new EMPdb();
            string question = db.GetSecurityQuestion(usernameReset.Text.Trim());

            if (!string.IsNullOrEmpty(question))
            {
                QuestionDisplay.Text = question;
            }
            else
            {
                MessageBox.Show("Username not found.");
            }
        }

        private void ForgotPassword_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string username = usernameReset.Text.Trim();
            string answer = answerReset.Text.Trim();
            string newPassword = passwordReset.Text;
            string confirmPassword = confirmpasswordReset.Text;

            if (string.IsNullOrEmpty(newPassword) || newPassword != confirmPassword)
            {
                MessageBox.Show("Passwords do not match or are empty.");
                return;
            }

            EMPdb db = new EMPdb();
            bool success = db.ResetPassword(username, answer, newPassword);

            if (success)
            {
                MessageBox.Show("Password has been reset. You can now log in.");
                this.Hide();
                Form1 login = new Form1();
                login.Show();
            }
            else
            {
                MessageBox.Show("Incorrect answer or failed to reset password.");
            }
        }
    }
}
