namespace QQ
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.picbSetup = new System.Windows.Forms.PictureBox();
            this.picbMin = new System.Windows.Forms.PictureBox();
            this.picbClose = new System.Windows.Forms.PictureBox();
            this.picbPenguin = new System.Windows.Forms.PictureBox();
            this.picbArrow = new System.Windows.Forms.PictureBox();
            this.picbLock = new System.Windows.Forms.PictureBox();
            this.picbKeyboard = new System.Windows.Forms.PictureBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.chebAutolog = new System.Windows.Forms.CheckBox();
            this.chebRempw = new System.Windows.Forms.CheckBox();
            this.panelDown = new System.Windows.Forms.Panel();
            this.panelUp = new System.Windows.Forms.Panel();
            this.textBoxDown = new System.Windows.Forms.TextBox();
            this.textBoxUp = new System.Windows.Forms.TextBox();
            this.lblFindpw = new System.Windows.Forms.Label();
            this.picbQr_code = new System.Windows.Forms.PictureBox();
            this.lblRegist = new System.Windows.Forms.Label();
            this.picbHead = new System.Windows.Forms.PictureBox();
            this.picbAdd = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbSetup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbPenguin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbArrow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbLock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbKeyboard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbQr_code)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbHead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbAdd)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(41, 40);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(49, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "QQ";
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.label1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            // 
            // picbSetup
            // 
            this.picbSetup.BackColor = System.Drawing.Color.Transparent;
            this.picbSetup.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picbSetup.BackgroundImage")));
            this.picbSetup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picbSetup.Location = new System.Drawing.Point(433, 12);
            this.picbSetup.Name = "picbSetup";
            this.picbSetup.Size = new System.Drawing.Size(24, 25);
            this.picbSetup.TabIndex = 0;
            this.picbSetup.TabStop = false;
            this.picbSetup.MouseEnter += new System.EventHandler(this.PicbSetup_MouseEnter);
            this.picbSetup.MouseLeave += new System.EventHandler(this.PicbSetup_MouseLeave);
            // 
            // picbMin
            // 
            this.picbMin.BackColor = System.Drawing.Color.Transparent;
            this.picbMin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picbMin.BackgroundImage")));
            this.picbMin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picbMin.Location = new System.Drawing.Point(473, 12);
            this.picbMin.Name = "picbMin";
            this.picbMin.Size = new System.Drawing.Size(24, 25);
            this.picbMin.TabIndex = 0;
            this.picbMin.TabStop = false;
            this.picbMin.Click += new System.EventHandler(this.PicbMin_Click);
            this.picbMin.MouseEnter += new System.EventHandler(this.PicbSetup_MouseEnter);
            this.picbMin.MouseLeave += new System.EventHandler(this.PicbSetup_MouseLeave);
            // 
            // picbClose
            // 
            this.picbClose.BackColor = System.Drawing.Color.Transparent;
            this.picbClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picbClose.BackgroundImage")));
            this.picbClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picbClose.Location = new System.Drawing.Point(503, 12);
            this.picbClose.Name = "picbClose";
            this.picbClose.Size = new System.Drawing.Size(27, 25);
            this.picbClose.TabIndex = 0;
            this.picbClose.TabStop = false;
            this.picbClose.Click += new System.EventHandler(this.PicbClose_Click);
            this.picbClose.MouseEnter += new System.EventHandler(this.PicbClose_MouseEnter);
            this.picbClose.MouseLeave += new System.EventHandler(this.PicbSetup_MouseLeave);
            // 
            // picbPenguin
            // 
            this.picbPenguin.BackColor = System.Drawing.Color.Transparent;
            this.picbPenguin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picbPenguin.BackgroundImage")));
            this.picbPenguin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picbPenguin.Location = new System.Drawing.Point(121, 216);
            this.picbPenguin.Name = "picbPenguin";
            this.picbPenguin.Size = new System.Drawing.Size(24, 25);
            this.picbPenguin.TabIndex = 0;
            this.picbPenguin.TabStop = false;
            // 
            // picbArrow
            // 
            this.picbArrow.BackColor = System.Drawing.Color.Transparent;
            this.picbArrow.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picbArrow.BackgroundImage")));
            this.picbArrow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picbArrow.ErrorImage = ((System.Drawing.Image)(resources.GetObject("picbArrow.ErrorImage")));
            this.picbArrow.Location = new System.Drawing.Point(401, 216);
            this.picbArrow.Name = "picbArrow";
            this.picbArrow.Size = new System.Drawing.Size(24, 25);
            this.picbArrow.TabIndex = 0;
            this.picbArrow.TabStop = false;
            this.picbArrow.MouseEnter += new System.EventHandler(this.PicbArrow_MouseEnter);
            this.picbArrow.MouseLeave += new System.EventHandler(this.PicbArrow_MouseLeave);
            // 
            // picbLock
            // 
            this.picbLock.BackColor = System.Drawing.Color.Transparent;
            this.picbLock.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picbLock.BackgroundImage")));
            this.picbLock.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picbLock.Location = new System.Drawing.Point(121, 272);
            this.picbLock.Name = "picbLock";
            this.picbLock.Size = new System.Drawing.Size(24, 25);
            this.picbLock.TabIndex = 0;
            this.picbLock.TabStop = false;
            // 
            // picbKeyboard
            // 
            this.picbKeyboard.BackColor = System.Drawing.Color.Transparent;
            this.picbKeyboard.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picbKeyboard.BackgroundImage")));
            this.picbKeyboard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picbKeyboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picbKeyboard.ErrorImage = ((System.Drawing.Image)(resources.GetObject("picbKeyboard.ErrorImage")));
            this.picbKeyboard.Location = new System.Drawing.Point(401, 272);
            this.picbKeyboard.Name = "picbKeyboard";
            this.picbKeyboard.Size = new System.Drawing.Size(24, 25);
            this.picbKeyboard.TabIndex = 0;
            this.picbKeyboard.TabStop = false;
            this.picbKeyboard.Click += new System.EventHandler(this.PicbKeyboard_Click);
            this.picbKeyboard.MouseEnter += new System.EventHandler(this.PicbKeyboard_MouseEnter);
            this.picbKeyboard.MouseLeave += new System.EventHandler(this.PicbKeyboard_MouseLeave);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(189)))), ((int)(((byte)(253)))));
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(121, 335);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(304, 43);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "登录";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // chebAutolog
            // 
            this.chebAutolog.AutoSize = true;
            this.chebAutolog.BackColor = System.Drawing.Color.Transparent;
            this.chebAutolog.ForeColor = System.Drawing.Color.DarkGray;
            this.chebAutolog.Location = new System.Drawing.Point(121, 310);
            this.chebAutolog.Name = "chebAutolog";
            this.chebAutolog.Size = new System.Drawing.Size(89, 19);
            this.chebAutolog.TabIndex = 3;
            this.chebAutolog.Text = "自动登录";
            this.chebAutolog.UseVisualStyleBackColor = false;
            // 
            // chebRempw
            // 
            this.chebRempw.AutoSize = true;
            this.chebRempw.BackColor = System.Drawing.Color.Transparent;
            this.chebRempw.ForeColor = System.Drawing.Color.DarkGray;
            this.chebRempw.Location = new System.Drawing.Point(239, 309);
            this.chebRempw.Name = "chebRempw";
            this.chebRempw.Size = new System.Drawing.Size(89, 19);
            this.chebRempw.TabIndex = 4;
            this.chebRempw.Text = "记住密码";
            this.chebRempw.UseVisualStyleBackColor = false;
            // 
            // panelDown
            // 
            this.panelDown.BackColor = System.Drawing.Color.LightGray;
            this.panelDown.Location = new System.Drawing.Point(121, 303);
            this.panelDown.Name = "panelDown";
            this.panelDown.Size = new System.Drawing.Size(304, 1);
            this.panelDown.TabIndex = 6;
            // 
            // panelUp
            // 
            this.panelUp.BackColor = System.Drawing.Color.LightGray;
            this.panelUp.Location = new System.Drawing.Point(121, 256);
            this.panelUp.Name = "panelUp";
            this.panelUp.Size = new System.Drawing.Size(304, 1);
            this.panelUp.TabIndex = 7;
            // 
            // textBoxDown
            // 
            this.textBoxDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxDown.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxDown.ForeColor = System.Drawing.Color.Gray;
            this.textBoxDown.Location = new System.Drawing.Point(152, 272);
            this.textBoxDown.Name = "textBoxDown";
            this.textBoxDown.Size = new System.Drawing.Size(243, 21);
            this.textBoxDown.TabIndex = 8;
            this.textBoxDown.Text = "密码";
            this.textBoxDown.Leave += new System.EventHandler(this.TextBoxDown_Leave);
            this.textBoxDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TextBoxDown_MouseDown);
            this.textBoxDown.MouseEnter += new System.EventHandler(this.TextBoxDown_MouseEnter);
            this.textBoxDown.MouseLeave += new System.EventHandler(this.TextBoxDown_MouseLeave);
            // 
            // textBoxUp
            // 
            this.textBoxUp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxUp.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxUp.ForeColor = System.Drawing.Color.Gray;
            this.textBoxUp.Location = new System.Drawing.Point(152, 216);
            this.textBoxUp.Name = "textBoxUp";
            this.textBoxUp.Size = new System.Drawing.Size(243, 21);
            this.textBoxUp.TabIndex = 8;
            this.textBoxUp.Text = "QQ号码/手机/邮箱";
            this.textBoxUp.Leave += new System.EventHandler(this.TextBoxUp_Leave);
            this.textBoxUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TextBoxUp_MouseDown);
            this.textBoxUp.MouseEnter += new System.EventHandler(this.TextBoxUp_MouseEnter);
            this.textBoxUp.MouseLeave += new System.EventHandler(this.TextBoxUp_MouseLeave);
            // 
            // lblFindpw
            // 
            this.lblFindpw.AutoSize = true;
            this.lblFindpw.BackColor = System.Drawing.Color.Transparent;
            this.lblFindpw.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblFindpw.ForeColor = System.Drawing.Color.DarkGray;
            this.lblFindpw.Location = new System.Drawing.Point(358, 310);
            this.lblFindpw.Name = "lblFindpw";
            this.lblFindpw.Size = new System.Drawing.Size(67, 15);
            this.lblFindpw.TabIndex = 9;
            this.lblFindpw.Text = "找回密码";
            this.lblFindpw.MouseEnter += new System.EventHandler(this.LblFindpw_MouseEnter);
            this.lblFindpw.MouseLeave += new System.EventHandler(this.LblFindpw_MouseLeave);
            // 
            // picbQr_code
            // 
            this.picbQr_code.BackColor = System.Drawing.Color.Transparent;
            this.picbQr_code.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picbQr_code.BackgroundImage")));
            this.picbQr_code.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picbQr_code.Location = new System.Drawing.Point(479, 353);
            this.picbQr_code.Name = "picbQr_code";
            this.picbQr_code.Size = new System.Drawing.Size(41, 40);
            this.picbQr_code.TabIndex = 0;
            this.picbQr_code.TabStop = false;
            this.picbQr_code.MouseEnter += new System.EventHandler(this.PicbQr_code_MouseEnter);
            this.picbQr_code.MouseLeave += new System.EventHandler(this.PicbQr_code_MouseLeave);
            // 
            // lblRegist
            // 
            this.lblRegist.AutoSize = true;
            this.lblRegist.BackColor = System.Drawing.Color.Transparent;
            this.lblRegist.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblRegist.ForeColor = System.Drawing.Color.DarkGray;
            this.lblRegist.Location = new System.Drawing.Point(12, 378);
            this.lblRegist.Name = "lblRegist";
            this.lblRegist.Size = new System.Drawing.Size(67, 15);
            this.lblRegist.TabIndex = 9;
            this.lblRegist.Text = "注册账号";
            this.lblRegist.MouseEnter += new System.EventHandler(this.LblFindpw_MouseEnter);
            this.lblRegist.MouseLeave += new System.EventHandler(this.LblFindpw_MouseLeave);
            // 
            // picbHead
            // 
            this.picbHead.BackColor = System.Drawing.Color.Transparent;
            this.picbHead.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picbHead.BackgroundImage")));
            this.picbHead.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picbHead.Location = new System.Drawing.Point(223, 108);
            this.picbHead.Name = "picbHead";
            this.picbHead.Size = new System.Drawing.Size(105, 88);
            this.picbHead.TabIndex = 0;
            this.picbHead.TabStop = false;
            this.picbHead.MouseEnter += new System.EventHandler(this.PicbHead_MouseEnter);
            this.picbHead.MouseLeave += new System.EventHandler(this.PicbHead_MouseLeave);
            // 
            // picbAdd
            // 
            this.picbAdd.BackColor = System.Drawing.Color.Transparent;
            this.picbAdd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picbAdd.BackgroundImage")));
            this.picbAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picbAdd.Location = new System.Drawing.Point(223, 108);
            this.picbAdd.Name = "picbAdd";
            this.picbAdd.Size = new System.Drawing.Size(105, 88);
            this.picbAdd.TabIndex = 0;
            this.picbAdd.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(532, 405);
            this.Controls.Add(this.lblRegist);
            this.Controls.Add(this.lblFindpw);
            this.Controls.Add(this.textBoxUp);
            this.Controls.Add(this.textBoxDown);
            this.Controls.Add(this.panelUp);
            this.Controls.Add(this.panelDown);
            this.Controls.Add(this.chebRempw);
            this.Controls.Add(this.chebAutolog);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picbClose);
            this.Controls.Add(this.picbMin);
            this.Controls.Add(this.picbLock);
            this.Controls.Add(this.picbArrow);
            this.Controls.Add(this.picbPenguin);
            this.Controls.Add(this.picbKeyboard);
            this.Controls.Add(this.picbSetup);
            this.Controls.Add(this.picbQr_code);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.picbHead);
            this.Controls.Add(this.picbAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbSetup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbPenguin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbArrow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbLock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbKeyboard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbQr_code)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbHead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbAdd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picbSetup;
        private System.Windows.Forms.PictureBox picbMin;
        private System.Windows.Forms.PictureBox picbClose;
        private System.Windows.Forms.PictureBox picbPenguin;
        private System.Windows.Forms.PictureBox picbArrow;
        private System.Windows.Forms.PictureBox picbLock;
        private System.Windows.Forms.PictureBox picbKeyboard;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.CheckBox chebAutolog;
        private System.Windows.Forms.CheckBox chebRempw;
        private System.Windows.Forms.Panel panelDown;
        private System.Windows.Forms.Panel panelUp;
        private System.Windows.Forms.TextBox textBoxDown;
        private System.Windows.Forms.TextBox textBoxUp;
        private System.Windows.Forms.Label lblFindpw;
        private System.Windows.Forms.PictureBox picbQr_code;
        private System.Windows.Forms.Label lblRegist;
        private System.Windows.Forms.PictureBox picbHead;
        private System.Windows.Forms.PictureBox picbAdd;
        private System.Windows.Forms.Timer timer1;
    }
}

