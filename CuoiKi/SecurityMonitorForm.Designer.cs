namespace CuoiKi
{
    partial class SecurityMonitorForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SecurityMonitorForm));
            this.dgvAlerts = new System.Windows.Forms.DataGridView();
            this.chartAccessStats = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.cboAlertType = new System.Windows.Forms.ComboBox();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlerts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartAccessStats)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAlerts
            // 
            this.dgvAlerts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlerts.Location = new System.Drawing.Point(17, 385);
            this.dgvAlerts.Name = "dgvAlerts";
            this.dgvAlerts.RowHeadersWidth = 51;
            this.dgvAlerts.RowTemplate.Height = 24;
            this.dgvAlerts.Size = new System.Drawing.Size(771, 150);
            this.dgvAlerts.TabIndex = 0;
            // 
            // chartAccessStats
            // 
            chartArea1.Name = "ChartArea1";
            this.chartAccessStats.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartAccessStats.Legends.Add(legend1);
            this.chartAccessStats.Location = new System.Drawing.Point(17, 147);
            this.chartAccessStats.Name = "chartAccessStats";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartAccessStats.Series.Add(series1);
            this.chartAccessStats.Size = new System.Drawing.Size(212, 232);
            this.chartAccessStats.TabIndex = 1;
            this.chartAccessStats.Text = "Thống kê theo thời gian";
            this.chartAccessStats.Click += new System.EventHandler(this.chartAccessStats_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "Loại cảnh báo";
            // 
            // cboAlertType
            // 
            this.cboAlertType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAlertType.FormattingEnabled = true;
            this.cboAlertType.Location = new System.Drawing.Point(142, 13);
            this.cboAlertType.Name = "cboAlertType";
            this.cboAlertType.Size = new System.Drawing.Size(236, 30);
            this.cboAlertType.TabIndex = 3;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFrom.Location = new System.Drawing.Point(495, 16);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(200, 28);
            this.dtpFrom.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(408, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 22);
            this.label2.TabIndex = 5;
            this.label2.Text = "Từ ngày:";
            // 
            // dtpTo
            // 
            this.dtpTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTo.Location = new System.Drawing.Point(506, 73);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(200, 28);
            this.dtpTo.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(408, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 22);
            this.label3.TabIndex = 7;
            this.label3.Text = "Đến ngày:";
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnGenerateReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGenerateReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateReport.Image = ((System.Drawing.Image)(resources.GetObject("btnGenerateReport.Image")));
            this.btnGenerateReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerateReport.Location = new System.Drawing.Point(17, 65);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(256, 39);
            this.btnGenerateReport.TabIndex = 8;
            this.btnGenerateReport.Text = "Xuất cảnh báo bảo mật";
            this.btnGenerateReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGenerateReport.UseVisualStyleBackColor = false;
            // 
            // SecurityMonitorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 559);
            this.Controls.Add(this.btnGenerateReport);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.cboAlertType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chartAccessStats);
            this.Controls.Add(this.dgvAlerts);
            this.Name = "SecurityMonitorForm";
            this.Text = "SecurityMonitorForm";
            this.Load += new System.EventHandler(this.SecurityMonitorForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlerts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartAccessStats)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAlerts;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartAccessStats;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboAlertType;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGenerateReport;
    }
}