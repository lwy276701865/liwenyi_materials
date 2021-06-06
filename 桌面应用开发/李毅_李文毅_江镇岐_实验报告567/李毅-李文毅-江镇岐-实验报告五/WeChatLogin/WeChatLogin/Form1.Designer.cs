namespace WeChatLogin
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.picbSet = new System.Windows.Forms.PictureBox();
            this.picbClose = new System.Windows.Forms.PictureBox();
            this.picbHead = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblTip = new System.Windows.Forms.Label();
            this.lblChange = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picbSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbHead)).BeginInit();
            this.SuspendLayout();
            // 
            // picbSet
            // 
            this.picbSet.BackColor = System.Drawing.Color.Transparent;
            this.picbSet.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picbSet.BackgroundImage")));
            this.picbSet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picbSet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picbSet.Location = new System.Drawing.Point(197, 12);
            this.picbSet.Name = "picbSet";
            this.picbSet.Size = new System.Drawing.Size(24, 24);
            this.picbSet.TabIndex = 0;
            this.picbSet.TabStop = false;
            this.picbSet.MouseEnter += new System.EventHandler(this.PicbSet_MouseEnter);
            this.picbSet.MouseLeave += new System.EventHandler(this.PicbSet_MouseLeave);
            // 
            // picbClose
            // 
            this.picbClose.BackColor = System.Drawing.Color.Transparent;
            this.picbClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picbClose.BackgroundImage")));
            this.picbClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picbClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picbClose.Location = new System.Drawing.Point(227, 12);
            this.picbClose.Name = "picbClose";
            this.picbClose.Size = new System.Drawing.Size(24, 24);
            this.picbClose.TabIndex = 0;
            this.picbClose.TabStop = false;
            this.picbClose.Click += new System.EventHandler(this.PicbClose_Click);
            this.picbClose.MouseEnter += new System.EventHandler(this.PicbClose_MouseEnter);
            this.picbClose.MouseLeave += new System.EventHandler(this.PicbSet_MouseLeave);
            // 
            // picbHead
            // 
            this.picbHead.BackColor = System.Drawing.Color.Transparent;
            this.picbHead.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picbHead.BackgroundImage")));
            this.picbHead.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picbHead.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picbHead.Location = new System.Drawing.Point(81, 53);
            this.picbHead.Name = "picbHead";
            this.picbHead.Size = new System.Drawing.Size(96, 96);
            this.picbHead.TabIndex = 0;
            this.picbHead.TabStop = false;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblName.ForeColor = System.Drawing.Color.DimGray;
            this.lblName.Location = new System.Drawing.Point(85, 158);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(88, 25);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "微信小冰";
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(173)))), ((int)(((byte)(25)))));
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(57, 192);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(145, 67);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "登录";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            this.btnLogin.MouseEnter += new System.EventHandler(this.BtnLogin_MouseEnter);
            this.btnLogin.MouseLeave += new System.EventHandler(this.BtnLogin_MouseLeave);
            // 
            // lblTip
            // 
            this.lblTip.AutoSize = true;
            this.lblTip.BackColor = System.Drawing.Color.Transparent;
            this.lblTip.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTip.ForeColor = System.Drawing.Color.DimGray;
            this.lblTip.Location = new System.Drawing.Point(38, 213);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(183, 25);
            this.lblTip.TabIndex = 1;
            this.lblTip.Text = "请在手机上确认登录";
            this.lblTip.Visible = false;
            // 
            // lblChange
            // 
            this.lblChange.AutoSize = true;
            this.lblChange.BackColor = System.Drawing.Color.Transparent;
            this.lblChange.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblChange.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblChange.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(129)))), ((int)(((byte)(199)))));
            this.lblChange.Location = new System.Drawing.Point(85, 302);
            this.lblChange.Name = "lblChange";
            this.lblChange.Size = new System.Drawing.Size(88, 25);
            this.lblChange.TabIndex = 1;
            this.lblChange.Text = "切换账号";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 353);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lblChange);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.picbClose);
            this.Controls.Add(this.picbHead);
            this.Controls.Add(this.picbSet);
            this.Controls.Add(this.lblTip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "微信2019";
            ((System.ComponentModel.ISupportInitialize)(this.picbSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbHead)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picbSet;
        private System.Windows.Forms.PictureBox picbClose;
        private System.Windows.Forms.PictureBox picbHead;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblTip;
        private System.Windows.Forms.Label lblChange;
    }
}

