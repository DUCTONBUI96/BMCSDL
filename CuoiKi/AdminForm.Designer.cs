﻿namespace CuoiKi
{
    partial class AdminForm
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageQuanLi = new System.Windows.Forms.TabPage();
            this.tabPagePhanquyen = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageQuanLi);
            this.tabControl.Controls.Add(this.tabPagePhanquyen);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Controls.Add(this.tabPage4);
            this.tabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(776, 100);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageQuanLi
            // 
            this.tabPageQuanLi.Location = new System.Drawing.Point(4, 31);
            this.tabPageQuanLi.Name = "tabPageQuanLi";
            this.tabPageQuanLi.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageQuanLi.Size = new System.Drawing.Size(768, 65);
            this.tabPageQuanLi.TabIndex = 1;
            this.tabPageQuanLi.Text = "Quản lí người dùng";
            this.tabPageQuanLi.UseVisualStyleBackColor = true;
            // 
            // tabPagePhanquyen
            // 
            this.tabPagePhanquyen.Location = new System.Drawing.Point(4, 31);
            this.tabPagePhanquyen.Name = "tabPagePhanquyen";
            this.tabPagePhanquyen.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePhanquyen.Size = new System.Drawing.Size(768, 65);
            this.tabPagePhanquyen.TabIndex = 2;
            this.tabPagePhanquyen.Text = "Phân quyền và vai trò";
            this.tabPagePhanquyen.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 31);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(768, 65);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "Cấu hình hệ thống";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 31);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(768, 65);
            this.tabPage4.TabIndex = 4;
            this.tabPage4.Text = "Backup và Restore";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 450);
            this.Controls.Add(this.tabControl);
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            this.Load += new System.EventHandler(this.AdminForm_Load);
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageQuanLi;
        private System.Windows.Forms.TabPage tabPagePhanquyen;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
    }
}