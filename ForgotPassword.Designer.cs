namespace Employee_Management_System
{
    partial class ForgotPassword
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
            this.label1 = new System.Windows.Forms.Label();
            this.usernameReset = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.QuestionDisplay = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.answerReset = new System.Windows.Forms.TextBox();
            this.passwordReset = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.confirmpasswordReset = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(105, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username:";
            // 
            // usernameReset
            // 
            this.usernameReset.Location = new System.Drawing.Point(182, 102);
            this.usernameReset.Name = "usernameReset";
            this.usernameReset.Size = new System.Drawing.Size(295, 22);
            this.usernameReset.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(500, 103);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 21);
            this.button1.TabIndex = 2;
            this.button1.Text = "Get Question";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(111, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Question:";
            // 
            // QuestionDisplay
            // 
            this.QuestionDisplay.AutoSize = true;
            this.QuestionDisplay.Location = new System.Drawing.Point(180, 150);
            this.QuestionDisplay.Name = "QuestionDisplay";
            this.QuestionDisplay.Size = new System.Drawing.Size(0, 16);
            this.QuestionDisplay.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(99, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Answer:";
            // 
            // answerReset
            // 
            this.answerReset.Location = new System.Drawing.Point(183, 186);
            this.answerReset.Name = "answerReset";
            this.answerReset.PasswordChar = '*';
            this.answerReset.Size = new System.Drawing.Size(259, 22);
            this.answerReset.TabIndex = 6;
            // 
            // passwordReset
            // 
            this.passwordReset.Location = new System.Drawing.Point(267, 268);
            this.passwordReset.Name = "passwordReset";
            this.passwordReset.PasswordChar = '*';
            this.passwordReset.Size = new System.Drawing.Size(259, 22);
            this.passwordReset.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(161, 271);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "New Password:";
            // 
            // confirmpasswordReset
            // 
            this.confirmpasswordReset.Location = new System.Drawing.Point(267, 296);
            this.confirmpasswordReset.Name = "confirmpasswordReset";
            this.confirmpasswordReset.PasswordChar = '*';
            this.confirmpasswordReset.Size = new System.Drawing.Size(259, 22);
            this.confirmpasswordReset.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(113, 299);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(148, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "Confirm New Password:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(320, 353);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(157, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Reset Password";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ForgotPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.confirmpasswordReset);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.passwordReset);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.answerReset);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.QuestionDisplay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.usernameReset);
            this.Controls.Add(this.label1);
            this.Name = "ForgotPassword";
            this.Text = "ForgotPassword";
            this.Load += new System.EventHandler(this.ForgotPassword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox usernameReset;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label QuestionDisplay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox answerReset;
        private System.Windows.Forms.TextBox passwordReset;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox confirmpasswordReset;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button2;
    }
}