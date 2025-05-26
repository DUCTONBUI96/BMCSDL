namespace CuoiKi
{
    partial class NotificationForm
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
            this.lblSendStatus = new System.Windows.Forms.Label();
            this.chkCaHai = new System.Windows.Forms.CheckBox();
            this.chkSMS = new System.Windows.Forms.CheckBox();
            this.chkEmail = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboStatusFilter = new System.Windows.Forms.ComboBox();
            this.dgvResidentsOrApps = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSendNotification = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResidentsOrApps)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSendStatus
            // 
            this.lblSendStatus.AutoSize = true;
            this.lblSendStatus.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSendStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.lblSendStatus.Location = new System.Drawing.Point(30, 550);
            this.lblSendStatus.Name = "lblSendStatus";
            this.lblSendStatus.Size = new System.Drawing.Size(169, 25);
            this.lblSendStatus.TabIndex = 31;
            this.lblSendStatus.Text = "📊 Trạng thái gửi:";
            // 
            // chkCaHai
            // 
            this.chkCaHai.AutoSize = true;
            this.chkCaHai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkCaHai.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCaHai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.chkCaHai.Location = new System.Drawing.Point(650, 110);
            this.chkCaHai.Name = "chkCaHai";
            this.chkCaHai.Size = new System.Drawing.Size(127, 27);
            this.chkCaHai.TabIndex = 30;
            this.chkCaHai.Text = "📧📱 Cả hai";
            this.chkCaHai.UseVisualStyleBackColor = true;
            this.chkCaHai.CheckedChanged += new System.EventHandler(this.chkCaHai_CheckedChanged_1);
            // 
            // chkSMS
            // 
            this.chkSMS.AutoSize = true;
            this.chkSMS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkSMS.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSMS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.chkSMS.Location = new System.Drawing.Point(520, 110);
            this.chkSMS.Name = "chkSMS";
            this.chkSMS.Size = new System.Drawing.Size(89, 27);
            this.chkSMS.TabIndex = 29;
            this.chkSMS.Text = "📱 SMS";
            this.chkSMS.UseVisualStyleBackColor = true;
            this.chkSMS.CheckedChanged += new System.EventHandler(this.chkSMS_CheckedChanged_1);
            // 
            // chkEmail
            // 
            this.chkEmail.AutoSize = true;
            this.chkEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkEmail.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.chkEmail.Location = new System.Drawing.Point(400, 110);
            this.chkEmail.Name = "chkEmail";
            this.chkEmail.Size = new System.Drawing.Size(97, 27);
            this.chkEmail.TabIndex = 28;
            this.chkEmail.Text = "📧 Email";
            this.chkEmail.UseVisualStyleBackColor = true;
            this.chkEmail.CheckedChanged += new System.EventHandler(this.chkEmail_CheckedChanged_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.label2.Location = new System.Drawing.Point(30, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(196, 25);
            this.label2.TabIndex = 27;
            this.label2.Text = "📬 Phương thức gửi:";
            // 
            // cboStatusFilter
            // 
            this.cboStatusFilter.BackColor = System.Drawing.Color.White;
            this.cboStatusFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboStatusFilter.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboStatusFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.cboStatusFilter.FormattingEnabled = true;
            this.cboStatusFilter.Location = new System.Drawing.Point(30, 80);
            this.cboStatusFilter.Name = "cboStatusFilter";
            this.cboStatusFilter.Size = new System.Drawing.Size(200, 31);
            this.cboStatusFilter.TabIndex = 26;
            this.cboStatusFilter.SelectedIndexChanged += new System.EventHandler(this.cboStatusFilter_SelectedIndexChanged);
            // 
            // dgvResidentsOrApps
            // 
            this.dgvResidentsOrApps.AllowUserToAddRows = false;
            this.dgvResidentsOrApps.AllowUserToDeleteRows = false;
            this.dgvResidentsOrApps.BackgroundColor = System.Drawing.Color.White;
            this.dgvResidentsOrApps.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvResidentsOrApps.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvResidentsOrApps.ColumnHeadersHeight = 40;
            this.dgvResidentsOrApps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvResidentsOrApps.EnableHeadersVisualStyles = false;
            this.dgvResidentsOrApps.Location = new System.Drawing.Point(30, 150);
            this.dgvResidentsOrApps.MultiSelect = false;
            this.dgvResidentsOrApps.Name = "dgvResidentsOrApps";
            this.dgvResidentsOrApps.ReadOnly = true;
            this.dgvResidentsOrApps.RowHeadersWidth = 51;
            this.dgvResidentsOrApps.RowTemplate.Height = 35;
            this.dgvResidentsOrApps.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResidentsOrApps.Size = new System.Drawing.Size(920, 220);
            this.dgvResidentsOrApps.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.label1.Location = new System.Drawing.Point(30, 390);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 25);
            this.label1.TabIndex = 24;
            this.label1.Text = "📝 Nội dung thông báo:";
            // 
            // btnSendNotification
            // 
            this.btnSendNotification.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnSendNotification.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSendNotification.FlatAppearance.BorderSize = 0;
            this.btnSendNotification.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendNotification.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendNotification.ForeColor = System.Drawing.Color.White;
            this.btnSendNotification.Location = new System.Drawing.Point(30, 500);
            this.btnSendNotification.Name = "btnSendNotification";
            this.btnSendNotification.Size = new System.Drawing.Size(180, 40);
            this.btnSendNotification.TabIndex = 23;
            this.btnSendNotification.Text = "📤 Gửi thông báo";
            this.btnSendNotification.UseVisualStyleBackColor = false;
            this.btnSendNotification.Click += new System.EventHandler(this.btnSendNotification_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.BackColor = System.Drawing.Color.White;
            this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMessage.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.txtMessage.Location = new System.Drawing.Point(30, 420);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(920, 70);
            this.txtMessage.TabIndex = 22;
            this.txtMessage.Text = "💬 Nhập nội dung thông báo tại đây...";
            // 
            // NotificationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(957, 650);
            this.Controls.Add(this.lblSendStatus);
            this.Controls.Add(this.chkCaHai);
            this.Controls.Add(this.chkSMS);
            this.Controls.Add(this.chkEmail);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboStatusFilter);
            this.Controls.Add(this.dgvResidentsOrApps);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSendNotification);
            this.Controls.Add(this.txtMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "NotificationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "📢 Quản lý Thông báo";
            this.Load += new System.EventHandler(this.NotificationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResidentsOrApps)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSendStatus;
        private System.Windows.Forms.CheckBox chkCaHai;
        private System.Windows.Forms.CheckBox chkSMS;
        private System.Windows.Forms.CheckBox chkEmail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboStatusFilter;
        private System.Windows.Forms.DataGridView dgvResidentsOrApps;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSendNotification;
        private System.Windows.Forms.RichTextBox txtMessage;
    }
}