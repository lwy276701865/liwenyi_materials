namespace 人事管理系统_GSJ
{
    partial class Frm_BeiFenHuanYuan
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_BeiFenHuanYuan));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btn_search = new System.Windows.Forms.Button();
            this.btn_calcel = new System.Windows.Forms.Button();
            this.txt_B_Path2 = new System.Windows.Forms.TextBox();
            this.txt_B_Path1 = new System.Windows.Forms.TextBox();
            this.rbtn_2 = new System.Windows.Forms.RadioButton();
            this.rbtn_1 = new System.Windows.Forms.RadioButton();
            this.btn_backup = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btn_search2 = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_restore = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_R_Path = new System.Windows.Forms.TextBox();
            this.ofd_restore = new System.Windows.Forms.OpenFileDialog();
            this.fbd_save = new System.Windows.Forms.FolderBrowserDialog();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(4, 7);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(286, 127);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btn_search);
            this.tabPage1.Controls.Add(this.btn_calcel);
            this.tabPage1.Controls.Add(this.txt_B_Path2);
            this.tabPage1.Controls.Add(this.txt_B_Path1);
            this.tabPage1.Controls.Add(this.rbtn_2);
            this.tabPage1.Controls.Add(this.rbtn_1);
            this.tabPage1.Controls.Add(this.btn_backup);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(278, 102);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "备份数据库";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btn_search
            // 
            this.btn_search.BackgroundImage = global::人事管理系统_GSJ.Properties.Resources.人事资料查询;
            this.btn_search.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_search.Enabled = false;
            this.btn_search.Location = new System.Drawing.Point(247, 36);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(28, 23);
            this.btn_search.TabIndex = 8;
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // btn_calcel
            // 
            this.btn_calcel.Location = new System.Drawing.Point(186, 73);
            this.btn_calcel.Name = "btn_calcel";
            this.btn_calcel.Size = new System.Drawing.Size(75, 23);
            this.btn_calcel.TabIndex = 7;
            this.btn_calcel.Text = "取消";
            this.btn_calcel.UseVisualStyleBackColor = true;
            this.btn_calcel.Click += new System.EventHandler(this.btn_calcel_Click);
            // 
            // txt_B_Path2
            // 
            this.txt_B_Path2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txt_B_Path2.Enabled = false;
            this.txt_B_Path2.Location = new System.Drawing.Point(94, 38);
            this.txt_B_Path2.Name = "txt_B_Path2";
            this.txt_B_Path2.Size = new System.Drawing.Size(147, 21);
            this.txt_B_Path2.TabIndex = 5;
            // 
            // txt_B_Path1
            // 
            this.txt_B_Path1.Enabled = false;
            this.txt_B_Path1.Location = new System.Drawing.Point(94, 12);
            this.txt_B_Path1.Name = "txt_B_Path1";
            this.txt_B_Path1.ReadOnly = true;
            this.txt_B_Path1.Size = new System.Drawing.Size(172, 21);
            this.txt_B_Path1.TabIndex = 4;
            // 
            // rbtn_2
            // 
            this.rbtn_2.AutoSize = true;
            this.rbtn_2.Location = new System.Drawing.Point(17, 40);
            this.rbtn_2.Name = "rbtn_2";
            this.rbtn_2.Size = new System.Drawing.Size(47, 16);
            this.rbtn_2.TabIndex = 3;
            this.rbtn_2.TabStop = true;
            this.rbtn_2.Text = "其它";
            this.rbtn_2.UseVisualStyleBackColor = true;
            this.rbtn_2.CheckedChanged += new System.EventHandler(this.rbtn_2_CheckedChanged);
            // 
            // rbtn_1
            // 
            this.rbtn_1.AutoSize = true;
            this.rbtn_1.Checked = true;
            this.rbtn_1.Location = new System.Drawing.Point(17, 14);
            this.rbtn_1.Name = "rbtn_1";
            this.rbtn_1.Size = new System.Drawing.Size(71, 16);
            this.rbtn_1.TabIndex = 2;
            this.rbtn_1.TabStop = true;
            this.rbtn_1.Text = "默认路径";
            this.rbtn_1.UseVisualStyleBackColor = true;
            // 
            // btn_backup
            // 
            this.btn_backup.Location = new System.Drawing.Point(105, 73);
            this.btn_backup.Name = "btn_backup";
            this.btn_backup.Size = new System.Drawing.Size(75, 23);
            this.btn_backup.TabIndex = 1;
            this.btn_backup.Text = "备份";
            this.btn_backup.UseVisualStyleBackColor = true;
            this.btn_backup.Click += new System.EventHandler(this.btn_backup_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btn_search2);
            this.tabPage2.Controls.Add(this.btn_cancel);
            this.tabPage2.Controls.Add(this.btn_restore);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.txt_R_Path);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(278, 102);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "还原数据库";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btn_search2
            // 
            this.btn_search2.BackgroundImage = global::人事管理系统_GSJ.Properties.Resources.人事资料查询;
            this.btn_search2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_search2.Location = new System.Drawing.Point(246, 24);
            this.btn_search2.Name = "btn_search2";
            this.btn_search2.Size = new System.Drawing.Size(28, 23);
            this.btn_search2.TabIndex = 9;
            this.btn_search2.UseVisualStyleBackColor = true;
            this.btn_search2.Click += new System.EventHandler(this.btn_search2_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(178, 64);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 4;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_restore
            // 
            this.btn_restore.Location = new System.Drawing.Point(86, 64);
            this.btn_restore.Name = "btn_restore";
            this.btn_restore.Size = new System.Drawing.Size(75, 23);
            this.btn_restore.TabIndex = 3;
            this.btn_restore.Text = "还原";
            this.btn_restore.UseVisualStyleBackColor = true;
            this.btn_restore.Click += new System.EventHandler(this.btn_restore_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "还原路径：";
            // 
            // txt_R_Path
            // 
            this.txt_R_Path.Location = new System.Drawing.Point(73, 26);
            this.txt_R_Path.Name = "txt_R_Path";
            this.txt_R_Path.Size = new System.Drawing.Size(169, 21);
            this.txt_R_Path.TabIndex = 0;
            // 
            // ofd_restore
            // 
            this.ofd_restore.FileName = "openFileDialog1";
            // 
            // Frm_BeiFenHuanYuan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 145);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Frm_BeiFenHuanYuan";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据库维护";
            this.Load += new System.EventHandler(this.Frm_BeiFenHuanYuan_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txt_B_Path2;
        private System.Windows.Forms.TextBox txt_B_Path1;
        private System.Windows.Forms.RadioButton rbtn_2;
        private System.Windows.Forms.RadioButton rbtn_1;
        private System.Windows.Forms.Button btn_backup;
        private System.Windows.Forms.Button btn_calcel;
        private System.Windows.Forms.OpenFileDialog ofd_restore;
        private System.Windows.Forms.FolderBrowserDialog fbd_save;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_restore;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_R_Path;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Button btn_search2;
    }
}