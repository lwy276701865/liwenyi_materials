namespace Win10登录
{
    partial class formSecond
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formSecond));
            this.timeTextIsNull = new System.Windows.Forms.Timer(this.components);
            this.lblTimeTop = new System.Windows.Forms.Label();
            this.lblTimeBot = new System.Windows.Forms.Label();
            this.timeGetTime = new System.Windows.Forms.Timer(this.components);
            this.picbEye = new System.Windows.Forms.PictureBox();
            this.picbBorderColor = new System.Windows.Forms.PictureBox();
            this.lblPIN = new System.Windows.Forms.Label();
            this.lblWrong = new System.Windows.Forms.Label();
            this.tbxPassword = new System.Windows.Forms.TextBox();
            this.picbHead = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.btnSure = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picbEye)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbBorderColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbHead)).BeginInit();
            this.SuspendLayout();
            // 
            // timeTextIsNull
            // 
            this.timeTextIsNull.Enabled = true;
            this.timeTextIsNull.Tick += new System.EventHandler(this.TimeTextIsNull_Tick);
            // 
            // lblTimeTop
            // 
            this.lblTimeTop.AutoSize = true;
            this.lblTimeTop.BackColor = System.Drawing.Color.Transparent;
            this.lblTimeTop.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTimeTop.ForeColor = System.Drawing.Color.White;
            this.lblTimeTop.Location = new System.Drawing.Point(66, 372);
            this.lblTimeTop.Name = "lblTimeTop";
            this.lblTimeTop.Size = new System.Drawing.Size(54, 27);
            this.lblTimeTop.TabIndex = 11;
            this.lblTimeTop.Text = "time";
            // 
            // lblTimeBot
            // 
            this.lblTimeBot.AutoSize = true;
            this.lblTimeBot.BackColor = System.Drawing.Color.Transparent;
            this.lblTimeBot.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTimeBot.ForeColor = System.Drawing.Color.White;
            this.lblTimeBot.Location = new System.Drawing.Point(65, 429);
            this.lblTimeBot.Name = "lblTimeBot";
            this.lblTimeBot.Size = new System.Drawing.Size(68, 32);
            this.lblTimeBot.TabIndex = 12;
            this.lblTimeBot.Text = "time";
            // 
            // timeGetTime
            // 
            this.timeGetTime.Enabled = true;
            this.timeGetTime.Tick += new System.EventHandler(this.TimeGetTime_Tick);
            // 
            // picbEye
            // 
            this.picbEye.BackColor = System.Drawing.SystemColors.Control;
            this.picbEye.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picbEye.BackgroundImage")));
            this.picbEye.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picbEye.Location = new System.Drawing.Point(802, 272);
            this.picbEye.Name = "picbEye";
            this.picbEye.Size = new System.Drawing.Size(50, 23);
            this.picbEye.TabIndex = 26;
            this.picbEye.TabStop = false;
            this.picbEye.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PicbEye_MouseDown);
            this.picbEye.MouseEnter += new System.EventHandler(this.PicbEye_MouseEnter);
            this.picbEye.MouseLeave += new System.EventHandler(this.PicbEye_MouseLeave);
            // 
            // picbBorderColor
            // 
            this.picbBorderColor.BackColor = System.Drawing.Color.Transparent;
            this.picbBorderColor.Location = new System.Drawing.Point(87, 205);
            this.picbBorderColor.Name = "picbBorderColor";
            this.picbBorderColor.Size = new System.Drawing.Size(211, 23);
            this.picbBorderColor.TabIndex = 24;
            this.picbBorderColor.TabStop = false;
            this.picbBorderColor.Paint += new System.Windows.Forms.PaintEventHandler(this.PicbBorderColor_Paint);
            // 
            // lblPIN
            // 
            this.lblPIN.BackColor = System.Drawing.Color.White;
            this.lblPIN.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPIN.ForeColor = System.Drawing.Color.Silver;
            this.lblPIN.Location = new System.Drawing.Point(668, 272);
            this.lblPIN.Name = "lblPIN";
            this.lblPIN.Size = new System.Drawing.Size(51, 27);
            this.lblPIN.TabIndex = 27;
            this.lblPIN.Text = "PIN";
            // 
            // lblWrong
            // 
            this.lblWrong.AutoSize = true;
            this.lblWrong.BackColor = System.Drawing.Color.Transparent;
            this.lblWrong.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWrong.ForeColor = System.Drawing.Color.White;
            this.lblWrong.Location = new System.Drawing.Point(440, 251);
            this.lblWrong.Name = "lblWrong";
            this.lblWrong.Size = new System.Drawing.Size(117, 27);
            this.lblWrong.TabIndex = 23;
            this.lblWrong.Text = "WrongText";
            this.lblWrong.Visible = false;
            // 
            // tbxPassword
            // 
            this.tbxPassword.BackColor = System.Drawing.Color.White;
            this.tbxPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxPassword.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxPassword.Location = new System.Drawing.Point(629, 272);
            this.tbxPassword.Name = "tbxPassword";
            this.tbxPassword.Size = new System.Drawing.Size(256, 27);
            this.tbxPassword.TabIndex = 25;
            this.tbxPassword.UseSystemPasswordChar = true;
            this.tbxPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbxPassword_KeyDown);
            this.tbxPassword.MouseEnter += new System.EventHandler(this.TbxPassword_MouseEnter);
            this.tbxPassword.MouseLeave += new System.EventHandler(this.TbxPassword_MouseLeave);
            // 
            // picbHead
            // 
            this.picbHead.BackColor = System.Drawing.Color.Transparent;
            this.picbHead.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picbHead.BackgroundImage")));
            this.picbHead.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picbHead.Location = new System.Drawing.Point(470, 103);
            this.picbHead.Name = "picbHead";
            this.picbHead.Size = new System.Drawing.Size(115, 87);
            this.picbHead.TabIndex = 20;
            this.picbHead.TabStop = false;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(468, 231);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(89, 20);
            this.lblName.TabIndex = 21;
            this.lblName.Text = "测试名字";
            // 
            // btnSure
            // 
            this.btnSure.BackColor = System.Drawing.Color.Silver;
            this.btnSure.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSure.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSure.ForeColor = System.Drawing.Color.White;
            this.btnSure.Location = new System.Drawing.Point(488, 339);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(140, 60);
            this.btnSure.TabIndex = 22;
            this.btnSure.Text = "确定";
            this.btnSure.UseVisualStyleBackColor = false;
            this.btnSure.Visible = false;
            // 
            // formSecond
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1079, 558);
            this.Controls.Add(this.picbEye);
            this.Controls.Add(this.picbBorderColor);
            this.Controls.Add(this.lblPIN);
            this.Controls.Add(this.lblWrong);
            this.Controls.Add(this.tbxPassword);
            this.Controls.Add(this.picbHead);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnSure);
            this.Controls.Add(this.lblTimeBot);
            this.Controls.Add(this.lblTimeTop);
            this.DoubleBuffered = true;
            this.Name = "formSecond";
            this.Text = "formSecond";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormSecond_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormSecond_KeyPress);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FormSecond_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.picbEye)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbBorderColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbHead)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timeTextIsNull;
        private System.Windows.Forms.Label lblTimeTop;
        private System.Windows.Forms.Label lblTimeBot;
        private System.Windows.Forms.Timer timeGetTime;
        private System.Windows.Forms.PictureBox picbEye;
        private System.Windows.Forms.PictureBox picbBorderColor;
        private System.Windows.Forms.Label lblPIN;
        private System.Windows.Forms.Label lblWrong;
        private System.Windows.Forms.TextBox tbxPassword;
        private System.Windows.Forms.PictureBox picbHead;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnSure;
    }
}

