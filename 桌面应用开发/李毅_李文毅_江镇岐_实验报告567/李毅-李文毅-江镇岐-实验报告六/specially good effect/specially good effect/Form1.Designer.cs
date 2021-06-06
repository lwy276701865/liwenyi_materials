namespace specially_good_effect
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
            this.lblgo = new System.Windows.Forms.Label();
            this.lblrun = new System.Windows.Forms.Label();
            this.picbHuman = new System.Windows.Forms.PictureBox();
            this.timeGo = new System.Windows.Forms.Timer(this.components);
            this.timeHuman = new System.Windows.Forms.Timer(this.components);
            this.picbTip = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picbHuman)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbTip)).BeginInit();
            this.SuspendLayout();
            // 
            // lblgo
            // 
            this.lblgo.BackColor = System.Drawing.Color.Transparent;
            this.lblgo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblgo.Image = ((System.Drawing.Image)(resources.GetObject("lblgo.Image")));
            this.lblgo.Location = new System.Drawing.Point(150, 24);
            this.lblgo.Name = "lblgo";
            this.lblgo.Size = new System.Drawing.Size(400, 250);
            this.lblgo.TabIndex = 0;
            // 
            // lblrun
            // 
            this.lblrun.BackColor = System.Drawing.Color.Transparent;
            this.lblrun.Image = ((System.Drawing.Image)(resources.GetObject("lblrun.Image")));
            this.lblrun.Location = new System.Drawing.Point(441, 303);
            this.lblrun.Name = "lblrun";
            this.lblrun.Size = new System.Drawing.Size(400, 250);
            this.lblrun.TabIndex = 0;
            this.lblrun.Visible = false;
            // 
            // picbHuman
            // 
            this.picbHuman.BackColor = System.Drawing.Color.Transparent;
            this.picbHuman.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picbHuman.BackgroundImage")));
            this.picbHuman.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picbHuman.Location = new System.Drawing.Point(510, 190);
            this.picbHuman.Name = "picbHuman";
            this.picbHuman.Size = new System.Drawing.Size(50, 51);
            this.picbHuman.TabIndex = 1;
            this.picbHuman.TabStop = false;
            this.picbHuman.Visible = false;
            // 
            // timeGo
            // 
            this.timeGo.Enabled = true;
            this.timeGo.Tick += new System.EventHandler(this.TimeGo_Tick);
            // 
            // timeHuman
            // 
            this.timeHuman.Tick += new System.EventHandler(this.TimeHuman_Tick);
            // 
            // picbTip
            // 
            this.picbTip.BackColor = System.Drawing.Color.Transparent;
            this.picbTip.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picbTip.BackgroundImage")));
            this.picbTip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picbTip.Location = new System.Drawing.Point(30, 277);
            this.picbTip.Name = "picbTip";
            this.picbTip.Size = new System.Drawing.Size(520, 150);
            this.picbTip.TabIndex = 1;
            this.picbTip.TabStop = false;
            this.picbTip.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(883, 580);
            this.Controls.Add(this.picbTip);
            this.Controls.Add(this.picbHuman);
            this.Controls.Add(this.lblrun);
            this.Controls.Add(this.lblgo);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picbHuman)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbTip)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblgo;
        private System.Windows.Forms.Label lblrun;
        private System.Windows.Forms.PictureBox picbHuman;
        private System.Windows.Forms.Timer timeGo;
        private System.Windows.Forms.Timer timeHuman;
        private System.Windows.Forms.PictureBox picbTip;
        private System.Windows.Forms.Timer timer1;
    }
}

