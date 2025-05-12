namespace Employee_Management_System
{
    partial class dashboard
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.resultBox = new System.Windows.Forms.ListBox();
            this.LogOut = new System.Windows.Forms.Button();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.DGattendance = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.DGemployee = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.DGlogs = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGattendance)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGemployee)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGlogs)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(4, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(953, 450);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.resultBox);
            this.tabPage1.Controls.Add(this.LogOut);
            this.tabPage1.Controls.Add(this.searchBox);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(945, 421);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Home";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(196, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Search:";
            // 
            // resultBox
            // 
            this.resultBox.FormattingEnabled = true;
            this.resultBox.ItemHeight = 16;
            this.resultBox.Location = new System.Drawing.Point(259, 106);
            this.resultBox.Name = "resultBox";
            this.resultBox.Size = new System.Drawing.Size(376, 164);
            this.resultBox.TabIndex = 9;
            this.resultBox.SelectedIndexChanged += new System.EventHandler(this.resultBox_SelectedIndexChanged);
            // 
            // LogOut
            // 
            this.LogOut.Location = new System.Drawing.Point(854, 6);
            this.LogOut.Name = "LogOut";
            this.LogOut.Size = new System.Drawing.Size(85, 25);
            this.LogOut.TabIndex = 8;
            this.LogOut.Text = "Log Out";
            this.LogOut.UseVisualStyleBackColor = true;
            this.LogOut.Click += new System.EventHandler(this.LogOut_Click);
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(255, 71);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(381, 22);
            this.searchBox.TabIndex = 4;
            this.searchBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.searchBox_Enter);
            this.searchBox.TextChanged += new System.EventHandler(this.searchBox_TextChanged);
            this.searchBox.Enter += new System.EventHandler(this.searchBox_Enter);
            this.searchBox.Leave += new System.EventHandler(this.searchBox_Leave);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(402, 313);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(150, 40);
            this.button3.TabIndex = 3;
            this.button3.Text = "Update Employee";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(668, 313);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 40);
            this.button2.TabIndex = 2;
            this.button2.Text = "Remove Employee";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(170, 312);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 41);
            this.button1.TabIndex = 1;
            this.button1.Text = "Add Employee";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label1.Location = new System.Drawing.Point(242, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(498, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Employee Management System";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.DGattendance);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(945, 421);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Attendance";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // DGattendance
            // 
            this.DGattendance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGattendance.Location = new System.Drawing.Point(0, 30);
            this.DGattendance.Name = "DGattendance";
            this.DGattendance.RowHeadersWidth = 51;
            this.DGattendance.RowTemplate.Height = 24;
            this.DGattendance.Size = new System.Drawing.Size(945, 391);
            this.DGattendance.TabIndex = 1;
            this.DGattendance.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(392, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "attendance of employees";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.DGemployee);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(945, 421);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Employees";
            this.tabPage3.UseVisualStyleBackColor = true;
            this.tabPage3.Click += new System.EventHandler(this.tabPage3_Click);
            // 
            // DGemployee
            // 
            this.DGemployee.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DGemployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGemployee.Location = new System.Drawing.Point(4, 19);
            this.DGemployee.Name = "DGemployee";
            this.DGemployee.RowHeadersWidth = 51;
            this.DGemployee.RowTemplate.Height = 24;
            this.DGemployee.Size = new System.Drawing.Size(944, 390);
            this.DGemployee.TabIndex = 1;
            this.DGemployee.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGemployee_CellContentClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(425, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "list of employees";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.DGlogs);
            this.tabPage4.Controls.Add(this.label4);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(945, 421);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Logs";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // DGlogs
            // 
            this.DGlogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGlogs.Location = new System.Drawing.Point(2, 19);
            this.DGlogs.Name = "DGlogs";
            this.DGlogs.RowHeadersWidth = 51;
            this.DGlogs.RowTemplate.Height = 24;
            this.DGlogs.Size = new System.Drawing.Size(940, 405);
            this.DGlogs.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(434, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "logs of processes";
            // 
            // dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "dashboard";
            this.Text = "dashboard";
            this.Load += new System.EventHandler(this.dashboard_Load_1);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGattendance)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGemployee)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGlogs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView DGattendance;
        private System.Windows.Forms.DataGridView DGemployee;
        private System.Windows.Forms.DataGridView DGlogs;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Button LogOut;
        private System.Windows.Forms.ListBox resultBox;
        private System.Windows.Forms.Label label5;
    }
}