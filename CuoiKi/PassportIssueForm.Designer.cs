namespace CuoiKi
{
    partial class PassportIssueForm
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
            this.dgvApprovedApps = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnIssue = new System.Windows.Forms.Button();
            this.txtPassportNumber = new System.Windows.Forms.TextBox();
            this.dtpIssueDate = new System.Windows.Forms.DateTimePicker();
            this.dtpExpiryDate = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApprovedApps)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvApprovedApps
            // 
            this.dgvApprovedApps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvApprovedApps.Location = new System.Drawing.Point(12, 32);
            this.dgvApprovedApps.Name = "dgvApprovedApps";
            this.dgvApprovedApps.RowHeadersWidth = 51;
            this.dgvApprovedApps.RowTemplate.Height = 24;
            this.dgvApprovedApps.Size = new System.Drawing.Size(776, 232);
            this.dgvApprovedApps.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 290);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Số hộ chiếu:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 324);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ngày cấp:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 359);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Ngày hết hạn:";
            // 
            // btnIssue
            // 
            this.btnIssue.Location = new System.Drawing.Point(12, 402);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(150, 36);
            this.btnIssue.TabIndex = 4;
            this.btnIssue.Text = "Cấp hộ chiếu";
            this.btnIssue.UseVisualStyleBackColor = true;
            // 
            // txtPassportNumber
            // 
            this.txtPassportNumber.Location = new System.Drawing.Point(126, 284);
            this.txtPassportNumber.Name = "txtPassportNumber";
            this.txtPassportNumber.Size = new System.Drawing.Size(236, 22);
            this.txtPassportNumber.TabIndex = 5;
            // 
            // dtpIssueDate
            // 
            this.dtpIssueDate.CustomFormat = "dd/mm/yyyy";
            this.dtpIssueDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpIssueDate.Location = new System.Drawing.Point(126, 319);
            this.dtpIssueDate.Name = "dtpIssueDate";
            this.dtpIssueDate.Size = new System.Drawing.Size(155, 22);
            this.dtpIssueDate.TabIndex = 6;
            // 
            // dtpExpiryDate
            // 
            this.dtpExpiryDate.CustomFormat = "dd/mm/yyyy";
            this.dtpExpiryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpExpiryDate.Location = new System.Drawing.Point(126, 353);
            this.dtpExpiryDate.Name = "dtpExpiryDate";
            this.dtpExpiryDate.Size = new System.Drawing.Size(155, 22);
            this.dtpExpiryDate.TabIndex = 7;
            // 
            // PassportIssueForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dtpExpiryDate);
            this.Controls.Add(this.dtpIssueDate);
            this.Controls.Add(this.txtPassportNumber);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvApprovedApps);
            this.Name = "PassportIssueForm";
            this.Text = "PassportIssueForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvApprovedApps)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvApprovedApps;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnIssue;
        private System.Windows.Forms.TextBox txtPassportNumber;
        private System.Windows.Forms.DateTimePicker dtpIssueDate;
        private System.Windows.Forms.DateTimePicker dtpExpiryDate;
    }
}