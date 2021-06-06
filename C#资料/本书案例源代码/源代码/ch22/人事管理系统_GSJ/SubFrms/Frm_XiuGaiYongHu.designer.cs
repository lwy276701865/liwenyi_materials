namespace 人事管理系统_GSJ
{
    partial class Frm_XiuGaiYongHu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_XiuGaiYongHu));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv_userInfo = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tool_UserAdd = new System.Windows.Forms.ToolStripButton();
            this.tool_UserUpdate = new System.Windows.Forms.ToolStripButton();
            this.tool_UserDelete = new System.Windows.Forms.ToolStripButton();
            this.tool_UserPop = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tool_Close = new System.Windows.Forms.ToolStripButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_userInfo)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv_userInfo);
            this.groupBox1.Location = new System.Drawing.Point(9, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(337, 296);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "用户信息表";
            // 
            // dgv_userInfo
            // 
            this.dgv_userInfo.AllowUserToAddRows = false;
            this.dgv_userInfo.AllowUserToDeleteRows = false;
            this.dgv_userInfo.AllowUserToResizeColumns = false;
            this.dgv_userInfo.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv_userInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_userInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dgv_userInfo.Location = new System.Drawing.Point(44, 20);
            this.dgv_userInfo.MultiSelect = false;
            this.dgv_userInfo.Name = "dgv_userInfo";
            this.dgv_userInfo.ReadOnly = true;
            this.dgv_userInfo.RowTemplate.Height = 23;
            this.dgv_userInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_userInfo.Size = new System.Drawing.Size(248, 255);
            this.dgv_userInfo.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Uid";
            this.Column1.HeaderText = "用户名";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 200;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Pwd";
            this.Column2.HeaderText = "密码";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 5;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tool_UserAdd,
            this.tool_UserUpdate,
            this.tool_UserDelete,
            this.tool_UserPop,
            this.toolStripSeparator1,
            this.tool_Close});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(358, 32);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tool_UserAdd
            // 
            this.tool_UserAdd.Image = global::人事管理系统_GSJ.Properties.Resources.添加;
            this.tool_UserAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_UserAdd.Name = "tool_UserAdd";
            this.tool_UserAdd.Size = new System.Drawing.Size(61, 29);
            this.tool_UserAdd.Text = "添加";
            this.tool_UserAdd.Click += new System.EventHandler(this.tool_UserAdd_Click);
            // 
            // tool_UserUpdate
            // 
            this.tool_UserUpdate.Image = global::人事管理系统_GSJ.Properties.Resources.修改;
            this.tool_UserUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_UserUpdate.Name = "tool_UserUpdate";
            this.tool_UserUpdate.Size = new System.Drawing.Size(61, 29);
            this.tool_UserUpdate.Text = "修改";
            this.tool_UserUpdate.Click += new System.EventHandler(this.tool_UserUpdate_Click);
            // 
            // tool_UserDelete
            // 
            this.tool_UserDelete.Image = global::人事管理系统_GSJ.Properties.Resources.删除;
            this.tool_UserDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_UserDelete.Name = "tool_UserDelete";
            this.tool_UserDelete.Size = new System.Drawing.Size(61, 29);
            this.tool_UserDelete.Text = "删除";
            this.tool_UserDelete.Click += new System.EventHandler(this.tool_UserDelete_Click);
            // 
            // tool_UserPop
            // 
            this.tool_UserPop.Image = global::人事管理系统_GSJ.Properties.Resources.取消;
            this.tool_UserPop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_UserPop.Name = "tool_UserPop";
            this.tool_UserPop.Size = new System.Drawing.Size(61, 29);
            this.tool_UserPop.Text = "权限";
            this.tool_UserPop.Click += new System.EventHandler(this.tool_UserPop_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 32);
            // 
            // tool_Close
            // 
            this.tool_Close.Image = global::人事管理系统_GSJ.Properties.Resources.退出;
            this.tool_Close.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_Close.Name = "tool_Close";
            this.tool_Close.Size = new System.Drawing.Size(61, 29);
            this.tool_Close.Text = "关闭";
            this.tool_Close.Click += new System.EventHandler(this.tool_Close_Click);
            // 
            // Frm_XiuGaiYongHu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 341);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Frm_XiuGaiYongHu";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "修改用户";
            this.Load += new System.EventHandler(this.Frm_XiuGaiYongHu_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_userInfo)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tool_UserAdd;
        private System.Windows.Forms.ToolStripButton tool_UserUpdate;
        private System.Windows.Forms.ToolStripButton tool_UserDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tool_UserPop;
        private System.Windows.Forms.ToolStripButton tool_Close;
        private System.Windows.Forms.DataGridView dgv_userInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}