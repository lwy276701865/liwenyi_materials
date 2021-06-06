namespace 人事管理系统_GSJ
{
    partial class Frm_CreateWord
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_CreateWord));
            this.rbn_all = new System.Windows.Forms.RadioButton();
            this.rbn_one = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_create = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rbn_all
            // 
            this.rbn_all.AutoSize = true;
            this.rbn_all.Location = new System.Drawing.Point(36, 78);
            this.rbn_all.Name = "rbn_all";
            this.rbn_all.Size = new System.Drawing.Size(119, 16);
            this.rbn_all.TabIndex = 0;
            this.rbn_all.Text = "导出全部员工信息";
            this.rbn_all.UseVisualStyleBackColor = true;
            // 
            // rbn_one
            // 
            this.rbn_one.AutoSize = true;
            this.rbn_one.Checked = true;
            this.rbn_one.Location = new System.Drawing.Point(36, 113);
            this.rbn_one.Name = "rbn_one";
            this.rbn_one.Size = new System.Drawing.Size(119, 16);
            this.rbn_one.TabIndex = 1;
            this.rbn_one.TabStop = true;
            this.rbn_one.Text = "导出选中员工信息";
            this.rbn_one.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "请选择：";
            // 
            // btn_create
            // 
            this.btn_create.Location = new System.Drawing.Point(45, 180);
            this.btn_create.Name = "btn_create";
            this.btn_create.Size = new System.Drawing.Size(75, 23);
            this.btn_create.TabIndex = 3;
            this.btn_create.Text = "开始导出";
            this.btn_create.UseVisualStyleBackColor = true;
            this.btn_create.Click += new System.EventHandler(this.btn_create_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(146, 180);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(75, 23);
            this.btn_exit.TabIndex = 4;
            this.btn_exit.Text = "取消";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // Frm_CreateWord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 241);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_create);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rbn_one);
            this.Controls.Add(this.rbn_all);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Frm_CreateWord";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "导出Word";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbn_all;
        private System.Windows.Forms.RadioButton rbn_one;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_create;
        private System.Windows.Forms.Button btn_exit;
    }
}