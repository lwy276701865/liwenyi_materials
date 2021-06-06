namespace WIN10Login
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lblTopTime = new System.Windows.Forms.Label();
            this.lblBotTime = new System.Windows.Forms.Label();
            this.timerGetTime = new System.Windows.Forms.Timer(this.components);
            this.tbxPassword = new System.Windows.Forms.TextBox();
            this.picbEye = new System.Windows.Forms.PictureBox();
            this.lblPIN = new System.Windows.Forms.Label();
            this.timerTextIsNull = new System.Windows.Forms.Timer(this.components);
            this.picbHead = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblWrongText = new System.Windows.Forms.Label();
            this.btnSure = new System.Windows.Forms.Button();
            this.panPassword = new WIN10Login.Form1.NewPanel();
            this.picbWifi = new System.Windows.Forms.PictureBox();
            this.picbElectry = new System.Windows.Forms.PictureBox();
            this.picbPower = new System.Windows.Forms.PictureBox();
            this.panCloseRestart = new WIN10Login.Form1.NewPanel();
            this.lblRestart = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSleep = new System.Windows.Forms.Label();
            this.lblClose = new System.Windows.Forms.Label();
            this.picbSearch = new System.Windows.Forms.PictureBox();
            this.lblTip = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picbEye)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbHead)).BeginInit();
            this.panPassword.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbWifi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbElectry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbPower)).BeginInit();
            this.panCloseRestart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTopTime
            // 
            this.lblTopTime.AutoSize = true;
            this.lblTopTime.BackColor = System.Drawing.Color.Transparent;
            this.lblTopTime.Font = new System.Drawing.Font("微软雅黑", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTopTime.ForeColor = System.Drawing.Color.White;
            this.lblTopTime.Location = new System.Drawing.Point(69, 406);
            this.lblTopTime.Name = "lblTopTime";
            this.lblTopTime.Size = new System.Drawing.Size(147, 57);
            this.lblTopTime.TabIndex = 1;
            this.lblTopTime.Text = "label1";
            // 
            // lblBotTime
            // 
            this.lblBotTime.AutoSize = true;
            this.lblBotTime.BackColor = System.Drawing.Color.Transparent;
            this.lblBotTime.Font = new System.Drawing.Font("微软雅黑", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBotTime.ForeColor = System.Drawing.Color.White;
            this.lblBotTime.Location = new System.Drawing.Point(69, 467);
            this.lblBotTime.Name = "lblBotTime";
            this.lblBotTime.Size = new System.Drawing.Size(147, 57);
            this.lblBotTime.TabIndex = 2;
            this.lblBotTime.Text = "label2";
            // 
            // timerGetTime
            // 
            this.timerGetTime.Enabled = true;
            this.timerGetTime.Tick += new System.EventHandler(this.TimerGetTime_Tick);
            // 
            // tbxPassword
            // 
            this.tbxPassword.BackColor = System.Drawing.Color.White;
            this.tbxPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxPassword.Font = new System.Drawing.Font("微软雅黑", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxPassword.ForeColor = System.Drawing.Color.Black;
            this.tbxPassword.Location = new System.Drawing.Point(17, 25);
            this.tbxPassword.Name = "tbxPassword";
            this.tbxPassword.Size = new System.Drawing.Size(303, 36);
            this.tbxPassword.TabIndex = 0;
            this.tbxPassword.UseSystemPasswordChar = true;
            this.tbxPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbxPassword_KeyDown);
            this.tbxPassword.MouseEnter += new System.EventHandler(this.TbxPassword_MouseEnter);
            this.tbxPassword.MouseLeave += new System.EventHandler(this.TbxPassword_MouseLeave);
            // 
            // picbEye
            // 
            this.picbEye.BackColor = System.Drawing.Color.White;
            this.picbEye.BackgroundImage = global::WIN10Login.Properties.Resources.眼睛;
            this.picbEye.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picbEye.Location = new System.Drawing.Point(280, 25);
            this.picbEye.Name = "picbEye";
            this.picbEye.Size = new System.Drawing.Size(40, 36);
            this.picbEye.TabIndex = 4;
            this.picbEye.TabStop = false;
            this.picbEye.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PicbEye_MouseDown);
            this.picbEye.MouseEnter += new System.EventHandler(this.PicbEye_MouseEnter);
            this.picbEye.MouseLeave += new System.EventHandler(this.PicbEye_MouseLeave);
            this.picbEye.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PicbEye_MouseUp);
            // 
            // lblPIN
            // 
            this.lblPIN.BackColor = System.Drawing.Color.White;
            this.lblPIN.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPIN.ForeColor = System.Drawing.Color.Silver;
            this.lblPIN.Location = new System.Drawing.Point(23, 27);
            this.lblPIN.Name = "lblPIN";
            this.lblPIN.Size = new System.Drawing.Size(62, 30);
            this.lblPIN.TabIndex = 5;
            this.lblPIN.Text = "PIN";
            // 
            // timerTextIsNull
            // 
            this.timerTextIsNull.Enabled = true;
            this.timerTextIsNull.Tick += new System.EventHandler(this.TimerTextIsNull_Tick);
            // 
            // picbHead
            // 
            this.picbHead.BackColor = System.Drawing.Color.Transparent;
            this.picbHead.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picbHead.BackgroundImage")));
            this.picbHead.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picbHead.Location = new System.Drawing.Point(403, 49);
            this.picbHead.Name = "picbHead";
            this.picbHead.Size = new System.Drawing.Size(224, 137);
            this.picbHead.TabIndex = 4;
            this.picbHead.TabStop = false;
            this.picbHead.Visible = false;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(661, 147);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(197, 39);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "桌面应用开发";
            // 
            // lblWrongText
            // 
            this.lblWrongText.AutoSize = true;
            this.lblWrongText.BackColor = System.Drawing.Color.Transparent;
            this.lblWrongText.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWrongText.ForeColor = System.Drawing.Color.White;
            this.lblWrongText.Location = new System.Drawing.Point(457, 207);
            this.lblWrongText.Name = "lblWrongText";
            this.lblWrongText.Size = new System.Drawing.Size(74, 27);
            this.lblWrongText.TabIndex = 5;
            this.lblWrongText.Text = "wrong";
            // 
            // btnSure
            // 
            this.btnSure.BackColor = System.Drawing.Color.Silver;
            this.btnSure.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSure.ForeColor = System.Drawing.Color.White;
            this.btnSure.Location = new System.Drawing.Point(413, 362);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(214, 59);
            this.btnSure.TabIndex = 6;
            this.btnSure.Text = "确定";
            this.btnSure.UseVisualStyleBackColor = false;
            this.btnSure.Click += new System.EventHandler(this.BtnSure_Click);
            this.btnSure.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BtnSure_KeyDown);
            // 
            // panPassword
            // 
            this.panPassword.BackColor = System.Drawing.Color.Transparent;
            this.panPassword.Controls.Add(this.picbEye);
            this.panPassword.Controls.Add(this.lblPIN);
            this.panPassword.Controls.Add(this.tbxPassword);
            this.panPassword.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panPassword.Location = new System.Drawing.Point(374, 241);
            this.panPassword.Name = "panPassword";
            this.panPassword.Size = new System.Drawing.Size(352, 86);
            this.panPassword.TabIndex = 7;
            // 
            // picbWifi
            // 
            this.picbWifi.BackColor = System.Drawing.Color.Transparent;
            this.picbWifi.BackgroundImage = global::WIN10Login.Properties.Resources.WIFI_我fi;
            this.picbWifi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picbWifi.Enabled = false;
            this.picbWifi.Location = new System.Drawing.Point(722, 483);
            this.picbWifi.Name = "picbWifi";
            this.picbWifi.Size = new System.Drawing.Size(65, 34);
            this.picbWifi.TabIndex = 8;
            this.picbWifi.TabStop = false;
            this.picbWifi.MouseEnter += new System.EventHandler(this.PicbWifi_MouseEnter);
            this.picbWifi.MouseLeave += new System.EventHandler(this.PicbWifi_MouseLeave);
            // 
            // picbElectry
            // 
            this.picbElectry.BackColor = System.Drawing.Color.Transparent;
            this.picbElectry.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picbElectry.BackgroundImage")));
            this.picbElectry.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picbElectry.Enabled = false;
            this.picbElectry.Location = new System.Drawing.Point(835, 483);
            this.picbElectry.Name = "picbElectry";
            this.picbElectry.Size = new System.Drawing.Size(55, 34);
            this.picbElectry.TabIndex = 8;
            this.picbElectry.TabStop = false;
            this.picbElectry.MouseEnter += new System.EventHandler(this.PicbWifi_MouseEnter);
            this.picbElectry.MouseLeave += new System.EventHandler(this.PicbWifi_MouseLeave);
            // 
            // picbPower
            // 
            this.picbPower.BackColor = System.Drawing.Color.Transparent;
            this.picbPower.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picbPower.BackgroundImage")));
            this.picbPower.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picbPower.Location = new System.Drawing.Point(927, 483);
            this.picbPower.Name = "picbPower";
            this.picbPower.Size = new System.Drawing.Size(51, 31);
            this.picbPower.TabIndex = 8;
            this.picbPower.TabStop = false;
            this.picbPower.Click += new System.EventHandler(this.PicbPower_Click);
            this.picbPower.MouseEnter += new System.EventHandler(this.PicbWifi_MouseEnter);
            this.picbPower.MouseLeave += new System.EventHandler(this.PicbWifi_MouseLeave);
            // 
            // panCloseRestart
            // 
            this.panCloseRestart.BackColor = System.Drawing.Color.LightGray;
            this.panCloseRestart.Controls.Add(this.lblRestart);
            this.panCloseRestart.Controls.Add(this.label2);
            this.panCloseRestart.Controls.Add(this.lblSleep);
            this.panCloseRestart.Controls.Add(this.lblClose);
            this.panCloseRestart.Location = new System.Drawing.Point(895, 320);
            this.panCloseRestart.Name = "panCloseRestart";
            this.panCloseRestart.Size = new System.Drawing.Size(109, 113);
            this.panCloseRestart.TabIndex = 9;
            // 
            // lblRestart
            // 
            this.lblRestart.AutoSize = true;
            this.lblRestart.BackColor = System.Drawing.Color.Transparent;
            this.lblRestart.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRestart.ForeColor = System.Drawing.Color.White;
            this.lblRestart.Location = new System.Drawing.Point(26, 81);
            this.lblRestart.Name = "lblRestart";
            this.lblRestart.Size = new System.Drawing.Size(62, 31);
            this.lblRestart.TabIndex = 1;
            this.lblRestart.Text = "重启";
            this.lblRestart.Click += new System.EventHandler(this.LblRestart_Click);
            this.lblRestart.MouseEnter += new System.EventHandler(this.LblClose_MouseEnter);
            this.lblRestart.MouseLeave += new System.EventHandler(this.LblClose_MouseLeave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(106, -173);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 27);
            this.label2.TabIndex = 1;
            this.label2.Text = "关机";
            // 
            // lblSleep
            // 
            this.lblSleep.AutoSize = true;
            this.lblSleep.BackColor = System.Drawing.Color.Transparent;
            this.lblSleep.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSleep.ForeColor = System.Drawing.Color.White;
            this.lblSleep.Location = new System.Drawing.Point(26, 48);
            this.lblSleep.Name = "lblSleep";
            this.lblSleep.Size = new System.Drawing.Size(62, 31);
            this.lblSleep.TabIndex = 1;
            this.lblSleep.Text = "睡眠";
            this.lblSleep.Click += new System.EventHandler(this.LblSleep_Click);
            this.lblSleep.MouseEnter += new System.EventHandler(this.LblClose_MouseEnter);
            this.lblSleep.MouseLeave += new System.EventHandler(this.LblClose_MouseLeave);
            // 
            // lblClose
            // 
            this.lblClose.AutoSize = true;
            this.lblClose.BackColor = System.Drawing.Color.Transparent;
            this.lblClose.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblClose.ForeColor = System.Drawing.Color.White;
            this.lblClose.Location = new System.Drawing.Point(26, 5);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(62, 31);
            this.lblClose.TabIndex = 1;
            this.lblClose.Text = "关机";
            this.lblClose.Click += new System.EventHandler(this.LblClose_Click);
            this.lblClose.MouseEnter += new System.EventHandler(this.LblClose_MouseEnter);
            this.lblClose.MouseLeave += new System.EventHandler(this.LblClose_MouseLeave);
            // 
            // picbSearch
            // 
            this.picbSearch.BackColor = System.Drawing.Color.Transparent;
            this.picbSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picbSearch.BackgroundImage")));
            this.picbSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picbSearch.Location = new System.Drawing.Point(42, 49);
            this.picbSearch.Name = "picbSearch";
            this.picbSearch.Size = new System.Drawing.Size(51, 38);
            this.picbSearch.TabIndex = 10;
            this.picbSearch.TabStop = false;
            this.picbSearch.MouseEnter += new System.EventHandler(this.PicSearch_MouseEnter);
            this.picbSearch.MouseLeave += new System.EventHandler(this.PicSearch_MouseLeave);
            // 
            // lblTip
            // 
            this.lblTip.AutoSize = true;
            this.lblTip.BackColor = System.Drawing.Color.Transparent;
            this.lblTip.Font = new System.Drawing.Font("微软雅黑", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTip.ForeColor = System.Drawing.Color.White;
            this.lblTip.Location = new System.Drawing.Point(112, 49);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(323, 36);
            this.lblTip.TabIndex = 1;
            this.lblTip.Text = "十里寒塘路，烟花一半醒";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1027, 606);
            this.Controls.Add(this.picbSearch);
            this.Controls.Add(this.panCloseRestart);
            this.Controls.Add(this.picbPower);
            this.Controls.Add(this.picbElectry);
            this.Controls.Add(this.picbWifi);
            this.Controls.Add(this.btnSure);
            this.Controls.Add(this.lblWrongText);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.picbHead);
            this.Controls.Add(this.lblBotTime);
            this.Controls.Add(this.lblTip);
            this.Controls.Add(this.lblTopTime);
            this.Controls.Add(this.panPassword);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picbEye)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbHead)).EndInit();
            this.panPassword.ResumeLayout(false);
            this.panPassword.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbWifi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbElectry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbPower)).EndInit();
            this.panCloseRestart.ResumeLayout(false);
            this.panCloseRestart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTopTime;
        private System.Windows.Forms.Label lblBotTime;
        private System.Windows.Forms.Timer timerGetTime;
        private System.Windows.Forms.TextBox tbxPassword;
        private System.Windows.Forms.PictureBox picbEye;
        private System.Windows.Forms.Label lblPIN;
        private System.Windows.Forms.Timer timerTextIsNull;
        private System.Windows.Forms.PictureBox picbHead;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblWrongText;
        private System.Windows.Forms.Button btnSure;
        private NewPanel panPassword;
        private System.Windows.Forms.PictureBox picbWifi;
        private System.Windows.Forms.PictureBox picbElectry;
        private System.Windows.Forms.PictureBox picbPower;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.Label lblRestart;
        private System.Windows.Forms.Label lblSleep;
        private NewPanel panCloseRestart;
        private System.Windows.Forms.PictureBox picbSearch;
        private System.Windows.Forms.Label lblTip;
    }
}

