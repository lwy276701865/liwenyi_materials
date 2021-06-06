namespace TSRWatermarkImage
{
    partial class frmWaterMarking
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
            this.btnLoadOriginal = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnBatch = new System.Windows.Forms.Button();
            this.picDisplay = new System.Windows.Forms.PictureBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.lblTrackBar = new System.Windows.Forms.Label();
            this.btnLoadWatermark = new System.Windows.Forms.Button();
            this.lblInstruction1 = new System.Windows.Forms.Label();
            this.lblShow1 = new System.Windows.Forms.Label();
            this.lblInstruction2 = new System.Windows.Forms.Label();
            this.lblShow2 = new System.Windows.Forms.Label();
            this.lblInstruction3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoadOriginal
            // 
            this.btnLoadOriginal.BackColor = System.Drawing.Color.Transparent;
            this.btnLoadOriginal.BackgroundImage = global::TSRWatermarkImage.Properties.Resources.圆角矩形;
            this.btnLoadOriginal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLoadOriginal.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnLoadOriginal.FlatAppearance.BorderSize = 0;
            this.btnLoadOriginal.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnLoadOriginal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnLoadOriginal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadOriginal.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLoadOriginal.ForeColor = System.Drawing.Color.White;
            this.btnLoadOriginal.Location = new System.Drawing.Point(645, 13);
            this.btnLoadOriginal.Name = "btnLoadOriginal";
            this.btnLoadOriginal.Size = new System.Drawing.Size(150, 65);
            this.btnLoadOriginal.TabIndex = 0;
            this.btnLoadOriginal.TabStop = false;
            this.btnLoadOriginal.Text = "载入原始图片";
            this.btnLoadOriginal.UseVisualStyleBackColor = false;
            this.btnLoadOriginal.Click += new System.EventHandler(this.btnLoadOriginal_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSave.BackgroundImage = global::TSRWatermarkImage.Properties.Resources.圆角矩形;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(645, 349);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(150, 65);
            this.btnSave.TabIndex = 0;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "保存图片";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnBatch
            // 
            this.btnBatch.BackColor = System.Drawing.Color.Transparent;
            this.btnBatch.BackgroundImage = global::TSRWatermarkImage.Properties.Resources.圆角矩形;
            this.btnBatch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBatch.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnBatch.FlatAppearance.BorderSize = 0;
            this.btnBatch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnBatch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnBatch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBatch.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnBatch.ForeColor = System.Drawing.Color.White;
            this.btnBatch.Location = new System.Drawing.Point(645, 441);
            this.btnBatch.Name = "btnBatch";
            this.btnBatch.Size = new System.Drawing.Size(150, 65);
            this.btnBatch.TabIndex = 0;
            this.btnBatch.TabStop = false;
            this.btnBatch.Text = "批量加水印";
            this.btnBatch.UseVisualStyleBackColor = false;
            this.btnBatch.Click += new System.EventHandler(this.btnBatch_Click);
            // 
            // picDisplay
            // 
            this.picDisplay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picDisplay.Location = new System.Drawing.Point(8, 8);
            this.picDisplay.Name = "picDisplay";
            this.picDisplay.Size = new System.Drawing.Size(591, 420);
            this.picDisplay.TabIndex = 1;
            this.picDisplay.TabStop = false;
            this.picDisplay.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picDisplay_MouseDown);
            this.picDisplay.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picDisplay_MouseMove);
            this.picDisplay.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picDisplay_MouseUp);
            // 
            // trackBar1
            // 
            this.trackBar1.AutoSize = false;
            this.trackBar1.Location = new System.Drawing.Point(617, 289);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(194, 33);
            this.trackBar1.TabIndex = 5;
            this.trackBar1.TickFrequency = 9;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // lblTrackBar
            // 
            this.lblTrackBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(114)))), ((int)(((byte)(196)))));
            this.lblTrackBar.Font = new System.Drawing.Font("微软雅黑", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTrackBar.ForeColor = System.Drawing.Color.White;
            this.lblTrackBar.Location = new System.Drawing.Point(645, 197);
            this.lblTrackBar.Name = "lblTrackBar";
            this.lblTrackBar.Size = new System.Drawing.Size(150, 65);
            this.lblTrackBar.TabIndex = 6;
            this.lblTrackBar.Text = "0";
            this.lblTrackBar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTrackBar.Paint += new System.Windows.Forms.PaintEventHandler(this.lblTrackBar_Paint);
            // 
            // btnLoadWatermark
            // 
            this.btnLoadWatermark.BackColor = System.Drawing.Color.Transparent;
            this.btnLoadWatermark.BackgroundImage = global::TSRWatermarkImage.Properties.Resources.圆角矩形;
            this.btnLoadWatermark.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLoadWatermark.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnLoadWatermark.FlatAppearance.BorderSize = 0;
            this.btnLoadWatermark.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnLoadWatermark.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnLoadWatermark.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadWatermark.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLoadWatermark.ForeColor = System.Drawing.Color.White;
            this.btnLoadWatermark.Location = new System.Drawing.Point(645, 105);
            this.btnLoadWatermark.Name = "btnLoadWatermark";
            this.btnLoadWatermark.Size = new System.Drawing.Size(150, 65);
            this.btnLoadWatermark.TabIndex = 0;
            this.btnLoadWatermark.TabStop = false;
            this.btnLoadWatermark.Text = "载入水印图片";
            this.btnLoadWatermark.UseVisualStyleBackColor = false;
            this.btnLoadWatermark.Click += new System.EventHandler(this.btnLoadWatermark_Click);
            // 
            // lblInstruction1
            // 
            this.lblInstruction1.AutoSize = true;
            this.lblInstruction1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblInstruction1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInstruction1.Location = new System.Drawing.Point(82, 435);
            this.lblInstruction1.Name = "lblInstruction1";
            this.lblInstruction1.Size = new System.Drawing.Size(502, 20);
            this.lblInstruction1.TabIndex = 7;
            this.lblInstruction1.Text = "单张图片加水印操作时：1、载入原始图片  2、载入水印图片  3、保存图片";
            // 
            // lblShow1
            // 
            this.lblShow1.AutoSize = true;
            this.lblShow1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblShow1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblShow1.Location = new System.Drawing.Point(2, 435);
            this.lblShow1.Name = "lblShow1";
            this.lblShow1.Size = new System.Drawing.Size(73, 20);
            this.lblShow1.TabIndex = 8;
            this.lblShow1.Text = "使用说明:";
            // 
            // lblInstruction2
            // 
            this.lblInstruction2.AutoSize = true;
            this.lblInstruction2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblInstruction2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInstruction2.Location = new System.Drawing.Point(82, 464);
            this.lblInstruction2.Name = "lblInstruction2";
            this.lblInstruction2.Size = new System.Drawing.Size(517, 20);
            this.lblInstruction2.TabIndex = 7;
            this.lblInstruction2.Text = "多张图片加水印操作时：1、载入水印图片  2、批量加水印  3、批量保存图片";
            // 
            // lblShow2
            // 
            this.lblShow2.AutoSize = true;
            this.lblShow2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblShow2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblShow2.Location = new System.Drawing.Point(2, 493);
            this.lblShow2.Name = "lblShow2";
            this.lblShow2.Size = new System.Drawing.Size(73, 20);
            this.lblShow2.TabIndex = 8;
            this.lblShow2.Text = "注意事项:";
            // 
            // lblInstruction3
            // 
            this.lblInstruction3.AutoSize = true;
            this.lblInstruction3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblInstruction3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInstruction3.Location = new System.Drawing.Point(82, 493);
            this.lblInstruction3.Name = "lblInstruction3";
            this.lblInstruction3.Size = new System.Drawing.Size(446, 20);
            this.lblInstruction3.TabIndex = 7;
            this.lblInstruction3.Text = "载入水印的图片像素大小为64×16左右时，水印操作后的图片最宜";
            // 
            // frmWaterMarking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(823, 522);
            this.Controls.Add(this.lblShow2);
            this.Controls.Add(this.lblShow1);
            this.Controls.Add(this.lblInstruction3);
            this.Controls.Add(this.lblInstruction2);
            this.Controls.Add(this.lblInstruction1);
            this.Controls.Add(this.lblTrackBar);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.picDisplay);
            this.Controls.Add(this.btnBatch);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnLoadWatermark);
            this.Controls.Add(this.btnLoadOriginal);
            this.DoubleBuffered = true;
            this.Name = "frmWaterMarking";
            this.Text = "WaterMarking";
            this.Load += new System.EventHandler(this.frmWaterMarking_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadOriginal;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnBatch;
        private System.Windows.Forms.PictureBox picDisplay;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label lblTrackBar;
        private System.Windows.Forms.Button btnLoadWatermark;
        private System.Windows.Forms.Label lblInstruction1;
        private System.Windows.Forms.Label lblShow1;
        private System.Windows.Forms.Label lblInstruction2;
        private System.Windows.Forms.Label lblShow2;
        private System.Windows.Forms.Label lblInstruction3;
    }
}

