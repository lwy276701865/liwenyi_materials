namespace qqMain
{
    partial class frmWeather
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWeather));
            this.picbSet = new System.Windows.Forms.PictureBox();
            this.picbWeather3 = new System.Windows.Forms.PictureBox();
            this.lblWind = new System.Windows.Forms.Label();
            this.lblHumidity = new System.Windows.Forms.Label();
            this.picbWeather2 = new System.Windows.Forms.PictureBox();
            this.lblSurvey3 = new System.Windows.Forms.Label();
            this.lblAfterDay = new System.Windows.Forms.Label();
            this.picbWeather1 = new System.Windows.Forms.PictureBox();
            this.lblSurvey2 = new System.Windows.Forms.Label();
            this.lblTomorrow = new System.Windows.Forms.Label();
            this.lblSurvey1 = new System.Windows.Forms.Label();
            this.lblToday = new System.Windows.Forms.Label();
            this.lblAir = new System.Windows.Forms.Label();
            this.lblWeather = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblTemperature = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picbSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbWeather3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbWeather2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbWeather1)).BeginInit();
            this.SuspendLayout();
            // 
            // picbSet
            // 
            this.picbSet.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picbSet.BackgroundImage")));
            this.picbSet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picbSet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picbSet.Location = new System.Drawing.Point(251, 13);
            this.picbSet.Name = "picbSet";
            this.picbSet.Size = new System.Drawing.Size(26, 25);
            this.picbSet.TabIndex = 18;
            this.picbSet.TabStop = false;
            this.picbSet.MouseEnter += new System.EventHandler(this.PicbSet_MouseEnter);
            this.picbSet.MouseLeave += new System.EventHandler(this.PicbSet_MouseLeave);
            // 
            // picbWeather3
            // 
            this.picbWeather3.BackColor = System.Drawing.Color.Transparent;
            this.picbWeather3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picbWeather3.Location = new System.Drawing.Point(207, 250);
            this.picbWeather3.Name = "picbWeather3";
            this.picbWeather3.Size = new System.Drawing.Size(70, 46);
            this.picbWeather3.TabIndex = 15;
            this.picbWeather3.TabStop = false;
            // 
            // lblWind
            // 
            this.lblWind.AutoSize = true;
            this.lblWind.BackColor = System.Drawing.Color.Transparent;
            this.lblWind.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWind.ForeColor = System.Drawing.Color.White;
            this.lblWind.Location = new System.Drawing.Point(119, 99);
            this.lblWind.Name = "lblWind";
            this.lblWind.Size = new System.Drawing.Size(52, 27);
            this.lblWind.TabIndex = 3;
            this.lblWind.Text = "风向";
            // 
            // lblHumidity
            // 
            this.lblHumidity.AutoSize = true;
            this.lblHumidity.BackColor = System.Drawing.Color.Transparent;
            this.lblHumidity.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblHumidity.ForeColor = System.Drawing.Color.White;
            this.lblHumidity.Location = new System.Drawing.Point(119, 133);
            this.lblHumidity.Name = "lblHumidity";
            this.lblHumidity.Size = new System.Drawing.Size(52, 27);
            this.lblHumidity.TabIndex = 4;
            this.lblHumidity.Text = "湿度";
            // 
            // picbWeather2
            // 
            this.picbWeather2.BackColor = System.Drawing.Color.Transparent;
            this.picbWeather2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picbWeather2.Location = new System.Drawing.Point(106, 250);
            this.picbWeather2.Name = "picbWeather2";
            this.picbWeather2.Size = new System.Drawing.Size(65, 46);
            this.picbWeather2.TabIndex = 16;
            this.picbWeather2.TabStop = false;
            // 
            // lblSurvey3
            // 
            this.lblSurvey3.AutoSize = true;
            this.lblSurvey3.BackColor = System.Drawing.Color.Transparent;
            this.lblSurvey3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSurvey3.ForeColor = System.Drawing.Color.White;
            this.lblSurvey3.Location = new System.Drawing.Point(189, 208);
            this.lblSurvey3.Name = "lblSurvey3";
            this.lblSurvey3.Size = new System.Drawing.Size(39, 20);
            this.lblSurvey3.TabIndex = 5;
            this.lblSurvey3.Text = "后天";
            // 
            // lblAfterDay
            // 
            this.lblAfterDay.AutoSize = true;
            this.lblAfterDay.BackColor = System.Drawing.Color.Transparent;
            this.lblAfterDay.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAfterDay.ForeColor = System.Drawing.Color.White;
            this.lblAfterDay.Location = new System.Drawing.Point(203, 181);
            this.lblAfterDay.Name = "lblAfterDay";
            this.lblAfterDay.Size = new System.Drawing.Size(39, 20);
            this.lblAfterDay.TabIndex = 6;
            this.lblAfterDay.Text = "后天";
            // 
            // picbWeather1
            // 
            this.picbWeather1.BackColor = System.Drawing.Color.Transparent;
            this.picbWeather1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picbWeather1.Location = new System.Drawing.Point(7, 250);
            this.picbWeather1.Name = "picbWeather1";
            this.picbWeather1.Size = new System.Drawing.Size(65, 46);
            this.picbWeather1.TabIndex = 17;
            this.picbWeather1.TabStop = false;
            // 
            // lblSurvey2
            // 
            this.lblSurvey2.AutoSize = true;
            this.lblSurvey2.BackColor = System.Drawing.Color.Transparent;
            this.lblSurvey2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSurvey2.ForeColor = System.Drawing.Color.White;
            this.lblSurvey2.Location = new System.Drawing.Point(101, 208);
            this.lblSurvey2.Name = "lblSurvey2";
            this.lblSurvey2.Size = new System.Drawing.Size(39, 20);
            this.lblSurvey2.TabIndex = 7;
            this.lblSurvey2.Text = "明天";
            // 
            // lblTomorrow
            // 
            this.lblTomorrow.AutoSize = true;
            this.lblTomorrow.BackColor = System.Drawing.Color.Transparent;
            this.lblTomorrow.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTomorrow.ForeColor = System.Drawing.Color.White;
            this.lblTomorrow.Location = new System.Drawing.Point(120, 181);
            this.lblTomorrow.Name = "lblTomorrow";
            this.lblTomorrow.Size = new System.Drawing.Size(39, 20);
            this.lblTomorrow.TabIndex = 8;
            this.lblTomorrow.Text = "明天";
            // 
            // lblSurvey1
            // 
            this.lblSurvey1.AutoSize = true;
            this.lblSurvey1.BackColor = System.Drawing.Color.Transparent;
            this.lblSurvey1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSurvey1.ForeColor = System.Drawing.Color.White;
            this.lblSurvey1.Location = new System.Drawing.Point(2, 208);
            this.lblSurvey1.Name = "lblSurvey1";
            this.lblSurvey1.Size = new System.Drawing.Size(39, 20);
            this.lblSurvey1.TabIndex = 9;
            this.lblSurvey1.Text = "今天";
            // 
            // lblToday
            // 
            this.lblToday.AutoSize = true;
            this.lblToday.BackColor = System.Drawing.Color.Transparent;
            this.lblToday.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblToday.ForeColor = System.Drawing.Color.White;
            this.lblToday.Location = new System.Drawing.Point(15, 181);
            this.lblToday.Name = "lblToday";
            this.lblToday.Size = new System.Drawing.Size(39, 20);
            this.lblToday.TabIndex = 10;
            this.lblToday.Text = "今天";
            // 
            // lblAir
            // 
            this.lblAir.AutoSize = true;
            this.lblAir.BackColor = System.Drawing.Color.Transparent;
            this.lblAir.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAir.ForeColor = System.Drawing.Color.White;
            this.lblAir.Location = new System.Drawing.Point(2, 133);
            this.lblAir.Name = "lblAir";
            this.lblAir.Size = new System.Drawing.Size(92, 27);
            this.lblAir.TabIndex = 11;
            this.lblAir.Text = "空气质量";
            // 
            // lblWeather
            // 
            this.lblWeather.AutoSize = true;
            this.lblWeather.BackColor = System.Drawing.Color.Transparent;
            this.lblWeather.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWeather.ForeColor = System.Drawing.Color.White;
            this.lblWeather.Location = new System.Drawing.Point(2, 99);
            this.lblWeather.Name = "lblWeather";
            this.lblWeather.Size = new System.Drawing.Size(52, 27);
            this.lblWeather.TabIndex = 12;
            this.lblWeather.Text = "天气";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.BackColor = System.Drawing.Color.Transparent;
            this.lblLocation.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLocation.ForeColor = System.Drawing.Color.White;
            this.lblLocation.Location = new System.Drawing.Point(2, 68);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(132, 27);
            this.lblLocation.TabIndex = 13;
            this.lblLocation.Text = "成都（当地）";
            // 
            // lblTemperature
            // 
            this.lblTemperature.AutoSize = true;
            this.lblTemperature.BackColor = System.Drawing.Color.Transparent;
            this.lblTemperature.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTemperature.ForeColor = System.Drawing.Color.White;
            this.lblTemperature.Location = new System.Drawing.Point(11, 24);
            this.lblTemperature.Name = "lblTemperature";
            this.lblTemperature.Size = new System.Drawing.Size(65, 32);
            this.lblTemperature.TabIndex = 14;
            this.lblTemperature.Text = "温度";
            // 
            // frmWeather
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(279, 309);
            this.Controls.Add(this.picbSet);
            this.Controls.Add(this.picbWeather3);
            this.Controls.Add(this.lblWind);
            this.Controls.Add(this.lblHumidity);
            this.Controls.Add(this.picbWeather2);
            this.Controls.Add(this.lblSurvey3);
            this.Controls.Add(this.lblAfterDay);
            this.Controls.Add(this.picbWeather1);
            this.Controls.Add(this.lblSurvey2);
            this.Controls.Add(this.lblTomorrow);
            this.Controls.Add(this.lblSurvey1);
            this.Controls.Add(this.lblToday);
            this.Controls.Add(this.lblAir);
            this.Controls.Add(this.lblWeather);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.lblTemperature);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmWeather";
            this.Text = "frmWeather";
            this.Load += new System.EventHandler(this.FrmWeather_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmWeather_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.picbSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbWeather3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbWeather2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbWeather1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picbSet;
        private System.Windows.Forms.PictureBox picbWeather3;
        private System.Windows.Forms.Label lblWind;
        private System.Windows.Forms.Label lblHumidity;
        private System.Windows.Forms.PictureBox picbWeather2;
        private System.Windows.Forms.Label lblSurvey3;
        private System.Windows.Forms.Label lblAfterDay;
        private System.Windows.Forms.PictureBox picbWeather1;
        private System.Windows.Forms.Label lblSurvey2;
        private System.Windows.Forms.Label lblTomorrow;
        private System.Windows.Forms.Label lblSurvey1;
        private System.Windows.Forms.Label lblToday;
        private System.Windows.Forms.Label lblAir;
        private System.Windows.Forms.Label lblWeather;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblTemperature;
    }
}