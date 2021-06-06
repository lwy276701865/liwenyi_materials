namespace 人事管理系统_GSJ
{
    partial class FrmLoad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLoad));
            this.txt_Pwd = new System.Windows.Forms.TextBox();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_Load = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_Pwd
            // 
            this.txt_Pwd.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txt_Pwd.Location = new System.Drawing.Point(136, 139);
            this.txt_Pwd.Name = "txt_Pwd";
            this.txt_Pwd.Size = new System.Drawing.Size(120, 21);
            this.txt_Pwd.TabIndex = 6;
            this.txt_Pwd.UseSystemPasswordChar = true;
            this.txt_Pwd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Pwd_KeyPress);
            // 
            // txt_Name
            // 
            this.txt_Name.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txt_Name.Location = new System.Drawing.Point(136, 97);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(120, 21);
            this.txt_Name.TabIndex = 5;
            this.txt_Name.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Name_KeyPress);
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.SystemColors.Control;
            this.btn_cancel.Location = new System.Drawing.Point(187, 187);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(56, 23);
            this.btn_cancel.TabIndex = 10;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.UseVisualStyleBackColor = false;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_Load
            // 
            this.btn_Load.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Load.Location = new System.Drawing.Point(82, 187);
            this.btn_Load.Name = "btn_Load";
            this.btn_Load.Size = new System.Drawing.Size(56, 23);
            this.btn_Load.TabIndex = 7;
            this.btn_Load.Text = "登录";
            this.btn_Load.UseVisualStyleBackColor = false;
            this.btn_Load.Click += new System.EventHandler(this.btn_Load_Click);
            // 
            // FrmLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::人事管理系统_GSJ.Properties.Resources.load1;
            this.ClientSize = new System.Drawing.Size(337, 238);
            this.Controls.Add(this.txt_Pwd);
            this.Controls.Add(this.txt_Name);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_Load);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmLoad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "欢迎使用企业人事管理系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmLoad_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Pwd;
        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_Load;
    }
}