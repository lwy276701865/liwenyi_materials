﻿namespace IOS12TestDistance
{
    partial class FrmDistanceMeasure
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
            this.SuspendLayout();
            // 
            // FrmDistanceMeasure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 780);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FrmDistanceMeasure";
            this.Text = "测距仪";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmDistanceMeasure_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmDistanceMeasure_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FrmDistanceMeasure_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FrmDistanceMeasure_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

