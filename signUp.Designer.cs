﻿namespace Employee_Management_System
{
    partial class signUp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.usernameSignUp = new System.Windows.Forms.TextBox();
            this.passwordSignUp = new System.Windows.Forms.TextBox();
            this.confirmpasswordSignUp = new System.Windows.Forms.TextBox();
            this.roleSignUp = new System.Windows.Forms.TextBox();
            this.emailSignUp = new System.Windows.Forms.TextBox();
            this.securityquestionSignUp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.answerSignUp = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // usernameSignUp
            // 
            this.usernameSignUp.Location = new System.Drawing.Point(216, 89);
            this.usernameSignUp.Name = "usernameSignUp";
            this.usernameSignUp.Size = new System.Drawing.Size(196, 22);
            this.usernameSignUp.TabIndex = 0;
            // 
            // passwordSignUp
            // 
            this.passwordSignUp.Location = new System.Drawing.Point(216, 135);
            this.passwordSignUp.Name = "passwordSignUp";
            this.passwordSignUp.PasswordChar = '*';
            this.passwordSignUp.Size = new System.Drawing.Size(196, 22);
            this.passwordSignUp.TabIndex = 1;
            // 
            // confirmpasswordSignUp
            // 
            this.confirmpasswordSignUp.Location = new System.Drawing.Point(216, 180);
            this.confirmpasswordSignUp.Name = "confirmpasswordSignUp";
            this.confirmpasswordSignUp.PasswordChar = '*';
            this.confirmpasswordSignUp.Size = new System.Drawing.Size(196, 22);
            this.confirmpasswordSignUp.TabIndex = 2;
            // 
            // roleSignUp
            // 
            this.roleSignUp.Location = new System.Drawing.Point(216, 220);
            this.roleSignUp.Name = "roleSignUp";
            this.roleSignUp.Size = new System.Drawing.Size(196, 22);
            this.roleSignUp.TabIndex = 3;
            // 
            // emailSignUp
            // 
            this.emailSignUp.Location = new System.Drawing.Point(216, 259);
            this.emailSignUp.Name = "emailSignUp";
            this.emailSignUp.Size = new System.Drawing.Size(196, 22);
            this.emailSignUp.TabIndex = 4;
            // 
            // securityquestionSignUp
            // 
            this.securityquestionSignUp.Location = new System.Drawing.Point(216, 299);
            this.securityquestionSignUp.Name = "securityquestionSignUp";
            this.securityquestionSignUp.Size = new System.Drawing.Size(196, 22);
            this.securityquestionSignUp.TabIndex = 5;
            this.securityquestionSignUp.TextChanged += new System.EventHandler(this.securityquestionSignUp_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(118, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Username:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(121, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Password:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(73, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Confirm Password:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(152, 226);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Role:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(87, 299);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Security Question:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(147, 333);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "Answer:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(279, 374);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 36);
            this.button1.TabIndex = 12;
            this.button1.Text = "Sign Up";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(147, 262);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 16);
            this.label7.TabIndex = 13;
            this.label7.Text = "Email:";
            // 
            // answerSignUp
            // 
            this.answerSignUp.Location = new System.Drawing.Point(216, 333);
            this.answerSignUp.Name = "answerSignUp";
            this.answerSignUp.PasswordChar = '*';
            this.answerSignUp.Size = new System.Drawing.Size(196, 22);
            this.answerSignUp.TabIndex = 14;
            this.answerSignUp.TextChanged += new System.EventHandler(this.textBox7_TextChanged);
            // 
            // signUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.answerSignUp);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.securityquestionSignUp);
            this.Controls.Add(this.emailSignUp);
            this.Controls.Add(this.roleSignUp);
            this.Controls.Add(this.confirmpasswordSignUp);
            this.Controls.Add(this.passwordSignUp);
            this.Controls.Add(this.usernameSignUp);
            this.Name = "signUp";
            this.Text = "signUp";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox usernameSignUp;
        private System.Windows.Forms.TextBox passwordSignUp;
        private System.Windows.Forms.TextBox confirmpasswordSignUp;
        private System.Windows.Forms.TextBox roleSignUp;
        private System.Windows.Forms.TextBox emailSignUp;
        private System.Windows.Forms.TextBox securityquestionSignUp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox answerSignUp;
    }
}