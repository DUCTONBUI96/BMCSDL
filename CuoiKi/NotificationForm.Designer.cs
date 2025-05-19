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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotificationForm));
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
            this.lblSendStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSendStatus.Location = new System.Drawing.Point(12, 409);
            this.lblSendStatus.Name = "lblSendStatus";
            this.lblSendStatus.Size = new System.Drawing.Size(169, 22);
            this.lblSendStatus.TabIndex = 31;
            this.lblSendStatus.Text = "Hiển thị kết quả gửi:";
            // 
            // chkCaHai
            // 
            this.chkCaHai.AutoSize = true;
            this.chkCaHai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkCaHai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCaHai.Location = new System.Drawing.Point(628, 28);
            this.chkCaHai.Name = "chkCaHai";
            this.chkCaHai.Size = new System.Drawing.Size(62, 24);
            this.chkCaHai.TabIndex = 30;
            this.chkCaHai.Text = "Cả 2";
            this.chkCaHai.UseVisualStyleBackColor = true;
            this.chkCaHai.CheckedChanged += new System.EventHandler(this.chkCaHai_CheckedChanged_1);
            // 
            // chkSMS
            // 
            this.chkSMS.AutoSize = true;
            this.chkSMS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkSMS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSMS.Location = new System.Drawing.Point(523, 28);
            this.chkSMS.Name = "chkSMS";
            this.chkSMS.Size = new System.Drawing.Size(63, 24);
            this.chkSMS.TabIndex = 29;
            this.chkSMS.Text = "SMS";
            this.chkSMS.UseVisualStyleBackColor = true;
            this.chkSMS.CheckedChanged += new System.EventHandler(this.chkSMS_CheckedChanged_1);
            // 
            // chkEmail
            // 
            this.chkEmail.AutoSize = true;
            this.chkEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEmail.Location = new System.Drawing.Point(429, 26);
            this.chkEmail.Name = "chkEmail";
            this.chkEmail.Size = new System.Drawing.Size(69, 24);
            this.chkEmail.TabIndex = 28;
            this.chkEmail.Text = "Email";
            this.chkEmail.UseVisualStyleBackColor = true;
            this.chkEmail.CheckedChanged += new System.EventHandler(this.chkEmail_CheckedChanged_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(273, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 22);
            this.label2.TabIndex = 27;
            this.label2.Text = "Phương thức gửi: ";
            // 
            // cboStatusFilter
            // 
            this.cboStatusFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboStatusFilter.FormattingEnabled = true;
            this.cboStatusFilter.Location = new System.Drawing.Point(12, 20);
            this.cboStatusFilter.Name = "cboStatusFilter";
            this.cboStatusFilter.Size = new System.Drawing.Size(169, 30);
            this.cboStatusFilter.TabIndex = 26;
            // 
            // dgvResidentsOrApps
            // 
            this.dgvResidentsOrApps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResidentsOrApps.Location = new System.Drawing.Point(12, 56);
            this.dgvResidentsOrApps.Name = "dgvResidentsOrApps";
            this.dgvResidentsOrApps.RowHeadersWidth = 51;
            this.dgvResidentsOrApps.RowTemplate.Height = 24;
            this.dgvResidentsOrApps.Size = new System.Drawing.Size(776, 171);
            this.dgvResidentsOrApps.TabIndex = 25;
            this.dgvResidentsOrApps.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResidentsOrApps_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 230);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 22);
            this.label1.TabIndex = 24;
            this.label1.Text = "Nội dung thông báo";
            // 
            // btnSendNotification
            // 
            this.btnSendNotification.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnSendNotification.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSendNotification.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendNotification.Image = ((System.Drawing.Image)(resources.GetObject("btnSendNotification.Image")));
            this.btnSendNotification.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSendNotification.Location = new System.Drawing.Point(12, 341);
            this.btnSendNotification.Name = "btnSendNotification";
            this.btnSendNotification.Size = new System.Drawing.Size(173, 35);
            this.btnSendNotification.TabIndex = 23;
            this.btnSendNotification.Text = "Gửi thông báo";
            this.btnSendNotification.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSendNotification.UseVisualStyleBackColor = false;
            this.btnSendNotification.Click += new System.EventHandler(this.btnSendNotification_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessage.Location = new System.Drawing.Point(12, 255);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(776, 71);
            this.txtMessage.TabIndex = 22;
            this.txtMessage.Text = "Nhập nội dung thông báo...\n";
            this.txtMessage.WordWrap = false;
            // 
            // NotificationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
            this.Name = "NotificationForm";
            this.Text = "NotificationForm";
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