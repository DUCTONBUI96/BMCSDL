namespace CuoiKi
{
    partial class WelcomeScreen
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
            this.components = new System.ComponentModel.Container();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSubmitForm = new System.Windows.Forms.Button();
            this.btnSearchStatus = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLogin = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(9, 9);
            this.lblWelcome.Margin = new System.Windows.Forms.Padding(0);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Padding = new System.Windows.Forms.Padding(15);
            this.lblWelcome.Size = new System.Drawing.Size(782, 73);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Chào mừng đến Hệ thống Quản lý Cấp Hộ chiếu";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblTime
            // 
            this.lblTime.Location = new System.Drawing.Point(302, 70);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(292, 25);
            this.lblTime.TabIndex = 2;
            this.lblTime.Text = "Time";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.Controls.Add(this.btnSubmitForm);
            this.flowLayoutPanel1.Controls.Add(this.btnSearchStatus);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 140);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(388, 298);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(347, 103);
            this.panel2.TabIndex = 1;
            // 
            // btnSubmitForm
            // 
            this.btnSubmitForm.AutoSize = true;
            this.btnSubmitForm.BackColor = System.Drawing.Color.White;
            this.btnSubmitForm.FlatAppearance.BorderSize = 0;
            this.btnSubmitForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmitForm.Location = new System.Drawing.Point(0, 109);
            this.btnSubmitForm.Margin = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.btnSubmitForm.Name = "btnSubmitForm";
            this.btnSubmitForm.Size = new System.Drawing.Size(197, 50);
            this.btnSubmitForm.TabIndex = 0;
            this.btnSubmitForm.Text = "Nộp đơn xét duyệt";
            this.btnSubmitForm.UseVisualStyleBackColor = false;
            this.btnSubmitForm.Click += new System.EventHandler(this.btnSubmitForm_Click);
            // 
            // btnSearchStatus
            // 
            this.btnSearchStatus.BackColor = System.Drawing.Color.White;
            this.btnSearchStatus.FlatAppearance.BorderSize = 0;
            this.btnSearchStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchStatus.Location = new System.Drawing.Point(0, 179);
            this.btnSearchStatus.Margin = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.btnSearchStatus.Name = "btnSearchStatus";
            this.btnSearchStatus.Size = new System.Drawing.Size(197, 50);
            this.btnSearchStatus.TabIndex = 5;
            this.btnSearchStatus.Text = "Tra cứu đơn xét duyệt\r\n";
            this.btnSearchStatus.UseVisualStyleBackColor = false;
            this.btnSearchStatus.Click += new System.EventHandler(this.btnSearchStatus_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.panel1);
            this.flowLayoutPanel2.Controls.Add(this.btnLogin);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(397, 140);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(394, 298);
            this.flowLayoutPanel2.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(385, 100);
            this.panel1.TabIndex = 0;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.White;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Location = new System.Drawing.Point(0, 106);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(197, 50);
            this.btnLogin.TabIndex = 1;
            this.btnLogin.Text = "Nếu là nhân viên";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // WelcomeScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblWelcome);
            this.Name = "WelcomeScreen";
            this.Text = "WelcomeScreen";
            this.Load += new System.EventHandler(this.WelcomeScreen_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSubmitForm;
        private System.Windows.Forms.Button btnSearchStatus;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Timer timer1;
    }
}