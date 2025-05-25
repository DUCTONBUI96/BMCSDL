namespace CuoiKi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminForm));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageQuanLi = new System.Windows.Forms.TabPage();
            this.btnResetPass = new System.Windows.Forms.Button();
            this.btnUnlock = new System.Windows.Forms.Button();
            this.btnLock = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.dgvUser = new System.Windows.Forms.DataGridView();
            this.tabPagePhanquyen = new System.Windows.Forms.TabPage();
            this.btnResetPassword = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgvRole = new System.Windows.Forms.DataGridView();
            this.tabCauhinh = new System.Windows.Forms.TabPage();
            this.txtConfigValue = new System.Windows.Forms.TextBox();
            this.txtConfigKey = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabBackup = new System.Windows.Forms.TabPage();
            this.btnRestore = new System.Windows.Forms.Button();
            this.btnBackup = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBackupPath = new System.Windows.Forms.TextBox();
            this.tabControl.SuspendLayout();
            this.tabPageQuanLi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).BeginInit();
            this.tabPagePhanquyen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRole)).BeginInit();
            this.tabCauhinh.SuspendLayout();
            this.tabBackup.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageQuanLi);
            this.tabControl.Controls.Add(this.tabPagePhanquyen);
            this.tabControl.Controls.Add(this.tabCauhinh);
            this.tabControl.Controls.Add(this.tabBackup);
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1003, 539);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageQuanLi
            // 
            this.tabPageQuanLi.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPageQuanLi.Controls.Add(this.btnResetPass);
            this.tabPageQuanLi.Controls.Add(this.btnUnlock);
            this.tabPageQuanLi.Controls.Add(this.btnLock);
            this.tabPageQuanLi.Controls.Add(this.btnCreate);
            this.tabPageQuanLi.Controls.Add(this.pictureBox1);
            this.tabPageQuanLi.Controls.Add(this.txtTimKiem);
            this.tabPageQuanLi.Controls.Add(this.dgvUser);
            this.tabPageQuanLi.Location = new System.Drawing.Point(4, 34);
            this.tabPageQuanLi.Name = "tabPageQuanLi";
            this.tabPageQuanLi.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageQuanLi.Size = new System.Drawing.Size(995, 501);
            this.tabPageQuanLi.TabIndex = 1;
            this.tabPageQuanLi.Text = "Quản lí người dùng";
            // 
            // btnResetPass
            // 
            this.btnResetPass.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnResetPass.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnResetPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetPass.Image = ((System.Drawing.Image)(resources.GetObject("btnResetPass.Image")));
            this.btnResetPass.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnResetPass.Location = new System.Drawing.Point(689, 20);
            this.btnResetPass.Name = "btnResetPass";
            this.btnResetPass.Size = new System.Drawing.Size(195, 39);
            this.btnResetPass.TabIndex = 45;
            this.btnResetPass.Text = "Đặt lại mật khẩu";
            this.btnResetPass.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnResetPass.UseVisualStyleBackColor = false;
            // 
            // btnUnlock
            // 
            this.btnUnlock.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnUnlock.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUnlock.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnlock.Image = ((System.Drawing.Image)(resources.GetObject("btnUnlock.Image")));
            this.btnUnlock.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUnlock.Location = new System.Drawing.Point(539, 20);
            this.btnUnlock.Name = "btnUnlock";
            this.btnUnlock.Size = new System.Drawing.Size(133, 39);
            this.btnUnlock.TabIndex = 44;
            this.btnUnlock.Text = "Mở khóa";
            this.btnUnlock.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUnlock.UseVisualStyleBackColor = false;
            // 
            // btnLock
            // 
            this.btnLock.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnLock.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLock.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLock.Image = ((System.Drawing.Image)(resources.GetObject("btnLock.Image")));
            this.btnLock.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLock.Location = new System.Drawing.Point(413, 20);
            this.btnLock.Name = "btnLock";
            this.btnLock.Size = new System.Drawing.Size(97, 39);
            this.btnLock.TabIndex = 43;
            this.btnLock.Text = "Khóa";
            this.btnLock.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLock.UseVisualStyleBackColor = false;
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.Image = ((System.Drawing.Image)(resources.GetObject("btnCreate.Image")));
            this.btnCreate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreate.Location = new System.Drawing.Point(254, 20);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(126, 39);
            this.btnCreate.TabIndex = 42;
            this.btnCreate.Text = "Tạo mới";
            this.btnCreate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCreate.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(16, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(33, 29);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 41;
            this.pictureBox1.TabStop = false;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiem.ForeColor = System.Drawing.Color.LightGray;
            this.txtTimKiem.Location = new System.Drawing.Point(48, 24);
            this.txtTimKiem.Multiline = true;
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(190, 29);
            this.txtTimKiem.TabIndex = 40;
            this.txtTimKiem.Text = "Tìm kiếm người dùng";
            this.txtTimKiem.Enter += new System.EventHandler(this.txtTimKiem_Enter);
            this.txtTimKiem.Leave += new System.EventHandler(this.txtTimKiem_Leave);
            // 
            // dgvUser
            // 
            this.dgvUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUser.Location = new System.Drawing.Point(15, 75);
            this.dgvUser.Name = "dgvUser";
            this.dgvUser.RowHeadersWidth = 51;
            this.dgvUser.RowTemplate.Height = 24;
            this.dgvUser.Size = new System.Drawing.Size(869, 150);
            this.dgvUser.TabIndex = 39;
            // 
            // tabPagePhanquyen
            // 
            this.tabPagePhanquyen.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPagePhanquyen.Controls.Add(this.btnResetPassword);
            this.tabPagePhanquyen.Controls.Add(this.pictureBox2);
            this.tabPagePhanquyen.Controls.Add(this.txtSearch);
            this.tabPagePhanquyen.Controls.Add(this.dgvRole);
            this.tabPagePhanquyen.Location = new System.Drawing.Point(4, 34);
            this.tabPagePhanquyen.Name = "tabPagePhanquyen";
            this.tabPagePhanquyen.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePhanquyen.Size = new System.Drawing.Size(995, 501);
            this.tabPagePhanquyen.TabIndex = 2;
            this.tabPagePhanquyen.Text = "Phân quyền và vai trò";
            // 
            // btnResetPassword
            // 
            this.btnResetPassword.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnResetPassword.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnResetPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetPassword.Image = ((System.Drawing.Image)(resources.GetObject("btnResetPassword.Image")));
            this.btnResetPassword.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnResetPassword.Location = new System.Drawing.Point(728, 13);
            this.btnResetPassword.Name = "btnResetPassword";
            this.btnResetPassword.Size = new System.Drawing.Size(156, 39);
            this.btnResetPassword.TabIndex = 42;
            this.btnResetPassword.Text = "Phân quyền";
            this.btnResetPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnResetPassword.UseVisualStyleBackColor = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(16, 21);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(33, 29);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 41;
            this.pictureBox2.TabStop = false;
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.Color.LightGray;
            this.txtSearch.Location = new System.Drawing.Point(48, 21);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(190, 29);
            this.txtSearch.TabIndex = 40;
            this.txtSearch.Text = "Tìm kiếm người dùng";
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            // 
            // dgvRole
            // 
            this.dgvRole.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRole.Location = new System.Drawing.Point(16, 70);
            this.dgvRole.Name = "dgvRole";
            this.dgvRole.RowHeadersWidth = 51;
            this.dgvRole.RowTemplate.Height = 24;
            this.dgvRole.Size = new System.Drawing.Size(869, 150);
            this.dgvRole.TabIndex = 39;
            // 
            // tabCauhinh
            // 
            this.tabCauhinh.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabCauhinh.Controls.Add(this.txtConfigValue);
            this.tabCauhinh.Controls.Add(this.txtConfigKey);
            this.tabCauhinh.Controls.Add(this.label2);
            this.tabCauhinh.Controls.Add(this.label1);
            this.tabCauhinh.Location = new System.Drawing.Point(4, 34);
            this.tabCauhinh.Name = "tabCauhinh";
            this.tabCauhinh.Padding = new System.Windows.Forms.Padding(3);
            this.tabCauhinh.Size = new System.Drawing.Size(995, 501);
            this.tabCauhinh.TabIndex = 3;
            this.tabCauhinh.Text = "Cấu hình hệ thống";
            // 
            // txtConfigValue
            // 
            this.txtConfigValue.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txtConfigValue.Location = new System.Drawing.Point(470, 66);
            this.txtConfigValue.Name = "txtConfigValue";
            this.txtConfigValue.Size = new System.Drawing.Size(320, 31);
            this.txtConfigValue.TabIndex = 3;
            this.txtConfigValue.Text = "Nhập giá trị cấu hình";
            this.txtConfigValue.Enter += new System.EventHandler(this.txtConfigValue_Enter);
            this.txtConfigValue.Leave += new System.EventHandler(this.txtConfigValue_Leave);
            // 
            // txtConfigKey
            // 
            this.txtConfigKey.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txtConfigKey.Location = new System.Drawing.Point(27, 66);
            this.txtConfigKey.Name = "txtConfigKey";
            this.txtConfigKey.Size = new System.Drawing.Size(330, 31);
            this.txtConfigKey.TabIndex = 2;
            this.txtConfigKey.Text = "Nhập cấu hình";
            this.txtConfigKey.Enter += new System.EventHandler(this.txtConfigKey_Enter);
            this.txtConfigKey.Leave += new System.EventHandler(this.txtConfigKey_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(465, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Giá trị cấu hình:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Khóa cấu hình:";
            // 
            // tabBackup
            // 
            this.tabBackup.BackColor = System.Drawing.SystemColors.Window;
            this.tabBackup.Controls.Add(this.btnRestore);
            this.tabBackup.Controls.Add(this.btnBackup);
            this.tabBackup.Controls.Add(this.label3);
            this.tabBackup.Controls.Add(this.txtBackupPath);
            this.tabBackup.Location = new System.Drawing.Point(4, 34);
            this.tabBackup.Name = "tabBackup";
            this.tabBackup.Padding = new System.Windows.Forms.Padding(3);
            this.tabBackup.Size = new System.Drawing.Size(995, 501);
            this.tabBackup.TabIndex = 4;
            this.tabBackup.Text = "Backup và Restore";
            // 
            // btnRestore
            // 
            this.btnRestore.BackColor = System.Drawing.SystemColors.MenuBar;
            this.btnRestore.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRestore.Image = ((System.Drawing.Image)(resources.GetObject("btnRestore.Image")));
            this.btnRestore.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRestore.Location = new System.Drawing.Point(350, 76);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(242, 37);
            this.btnRestore.TabIndex = 3;
            this.btnRestore.Text = "Phục hồi cơ sở dữ liệu";
            this.btnRestore.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRestore.UseVisualStyleBackColor = false;
            // 
            // btnBackup
            // 
            this.btnBackup.BackColor = System.Drawing.SystemColors.MenuBar;
            this.btnBackup.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBackup.Image = ((System.Drawing.Image)(resources.GetObject("btnBackup.Image")));
            this.btnBackup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBackup.Location = new System.Drawing.Point(20, 76);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(235, 37);
            this.btnBackup.TabIndex = 2;
            this.btnBackup.Text = "Sao lưu cơ sở dữ liệu";
            this.btnBackup.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBackup.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(228, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "Đường dẫn lưu file sao lưu:";
            // 
            // txtBackupPath
            // 
            this.txtBackupPath.Location = new System.Drawing.Point(255, 18);
            this.txtBackupPath.Name = "txtBackupPath";
            this.txtBackupPath.Size = new System.Drawing.Size(609, 31);
            this.txtBackupPath.TabIndex = 0;
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1033, 547);
            this.Controls.Add(this.tabControl);
            this.Name = "AdminForm";
            this.Text = "Quản trị hệ thống";
            this.Load += new System.EventHandler(this.AdminForm_Load);
            this.VisibleChanged += new System.EventHandler(this.AdminForm_Load);
            this.tabControl.ResumeLayout(false);
            this.tabPageQuanLi.ResumeLayout(false);
            this.tabPageQuanLi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).EndInit();
            this.tabPagePhanquyen.ResumeLayout(false);
            this.tabPagePhanquyen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRole)).EndInit();
            this.tabCauhinh.ResumeLayout(false);
            this.tabCauhinh.PerformLayout();
            this.tabBackup.ResumeLayout(false);
            this.tabBackup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageQuanLi;
        private System.Windows.Forms.TabPage tabPagePhanquyen;
        private System.Windows.Forms.TabPage tabCauhinh;
        private System.Windows.Forms.TabPage tabBackup;
        private System.Windows.Forms.Button btnResetPassword;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgvRole;
        private System.Windows.Forms.Button btnResetPass;
        private System.Windows.Forms.Button btnUnlock;
        private System.Windows.Forms.Button btnLock;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.DataGridView dgvUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtConfigValue;
        private System.Windows.Forms.TextBox txtConfigKey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBackupPath;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Button btnRestore;
    }
}