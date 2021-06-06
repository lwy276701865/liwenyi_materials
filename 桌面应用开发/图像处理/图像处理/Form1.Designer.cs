namespace 图像处理
{
    partial class btnOpen
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
            this.button1 = new System.Windows.Forms.Button();
            this.picOriginal = new System.Windows.Forms.PictureBox();
            this.btnGray = new System.Windows.Forms.Button();
            this.picAfter = new System.Windows.Forms.PictureBox();
            this.btnReverse = new System.Windows.Forms.Button();
            this.btnFog = new System.Windows.Forms.Button();
            this.btnRelief = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAfter)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(46, 396);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "打开";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // picOriginal
            // 
            this.picOriginal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picOriginal.Location = new System.Drawing.Point(31, 12);
            this.picOriginal.Name = "picOriginal";
            this.picOriginal.Size = new System.Drawing.Size(330, 337);
            this.picOriginal.TabIndex = 1;
            this.picOriginal.TabStop = false;
            // 
            // btnGray
            // 
            this.btnGray.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGray.Location = new System.Drawing.Point(156, 396);
            this.btnGray.Name = "btnGray";
            this.btnGray.Size = new System.Drawing.Size(104, 23);
            this.btnGray.TabIndex = 0;
            this.btnGray.Text = "灰度化";
            this.btnGray.UseVisualStyleBackColor = true;
            this.btnGray.Click += new System.EventHandler(this.BtnGray_Click);
            // 
            // picAfter
            // 
            this.picAfter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picAfter.Location = new System.Drawing.Point(425, 12);
            this.picAfter.Name = "picAfter";
            this.picAfter.Size = new System.Drawing.Size(330, 337);
            this.picAfter.TabIndex = 1;
            this.picAfter.TabStop = false;
            // 
            // btnReverse
            // 
            this.btnReverse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReverse.Location = new System.Drawing.Point(266, 396);
            this.btnReverse.Name = "btnReverse";
            this.btnReverse.Size = new System.Drawing.Size(104, 23);
            this.btnReverse.TabIndex = 0;
            this.btnReverse.Text = "取反";
            this.btnReverse.UseVisualStyleBackColor = true;
            this.btnReverse.Click += new System.EventHandler(this.BtnReverse_Click);
            // 
            // btnFog
            // 
            this.btnFog.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFog.Location = new System.Drawing.Point(376, 396);
            this.btnFog.Name = "btnFog";
            this.btnFog.Size = new System.Drawing.Size(104, 23);
            this.btnFog.TabIndex = 0;
            this.btnFog.Text = "雾化";
            this.btnFog.UseVisualStyleBackColor = true;
            this.btnFog.Click += new System.EventHandler(this.BtnFog_Click);
            // 
            // btnRelief
            // 
            this.btnRelief.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRelief.Location = new System.Drawing.Point(507, 396);
            this.btnRelief.Name = "btnRelief";
            this.btnRelief.Size = new System.Drawing.Size(104, 23);
            this.btnRelief.TabIndex = 0;
            this.btnRelief.Text = "浮雕";
            this.btnRelief.UseVisualStyleBackColor = true;
            this.btnRelief.Click += new System.EventHandler(this.BtnRelief_Click);
            // 
            // btnOpen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.picAfter);
            this.Controls.Add(this.picOriginal);
            this.Controls.Add(this.btnRelief);
            this.Controls.Add(this.btnFog);
            this.Controls.Add(this.btnReverse);
            this.Controls.Add(this.btnGray);
            this.Controls.Add(this.button1);
            this.Name = "btnOpen";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAfter)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox picOriginal;
        private System.Windows.Forms.Button btnGray;
        private System.Windows.Forms.PictureBox picAfter;
        private System.Windows.Forms.Button btnReverse;
        private System.Windows.Forms.Button btnFog;
        private System.Windows.Forms.Button btnRelief;
    }
}

