namespace TDService
{
    partial class BangLog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BangLog));
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpBegin = new System.Windows.Forms.DateTimePicker();
            this.txbNavicert = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.gr = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvWeightBang = new System.Windows.Forms.DataGridView();
            this.WeightBangCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NavicertID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CoalKind = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.煤矿名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.车主 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.磅房 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.机柜 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.gr.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWeightBang)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(333, 63);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(150, 23);
            this.dtpEnd.TabIndex = 15;
            // 
            // dtpBegin
            // 
            this.dtpBegin.Location = new System.Drawing.Point(144, 63);
            this.dtpBegin.Name = "dtpBegin";
            this.dtpBegin.Size = new System.Drawing.Size(150, 23);
            this.dtpBegin.TabIndex = 14;
            // 
            // txbNavicert
            // 
            this.txbNavicert.Location = new System.Drawing.Point(144, 30);
            this.txbNavicert.Name = "txbNavicert";
            this.txbNavicert.Size = new System.Drawing.Size(150, 23);
            this.txbNavicert.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label8.Location = new System.Drawing.Point(306, 67);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(21, 14);
            this.label8.TabIndex = 7;
            this.label8.Text = "到";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label7.Location = new System.Drawing.Point(77, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 14);
            this.label7.TabIndex = 6;
            this.label7.Text = "时间范围";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.gr);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btnExit);
            this.splitContainer2.Panel2.Controls.Add(this.btnClear);
            this.splitContainer2.Panel2.Controls.Add(this.btnQuery);
            this.splitContainer2.Size = new System.Drawing.Size(779, 380);
            this.splitContainer2.SplitterDistance = 307;
            this.splitContainer2.TabIndex = 0;
            // 
            // gr
            // 
            this.gr.Controls.Add(this.dgvWeightBang);
            this.gr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gr.Font = new System.Drawing.Font("宋体", 10.5F);
            this.gr.Location = new System.Drawing.Point(0, 0);
            this.gr.Name = "gr";
            this.gr.Size = new System.Drawing.Size(779, 307);
            this.gr.TabIndex = 0;
            this.gr.TabStop = false;
            this.gr.Text = "过磅日志列表";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(477, 24);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(84, 23);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(312, 24);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(84, 23);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "复位";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(138, 24);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(84, 23);
            this.btnQuery.TabIndex = 0;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label2.Location = new System.Drawing.Point(77, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "准运卡号";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(779, 504);
            this.splitContainer1.SplitterDistance = 120;
            this.splitContainer1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpEnd);
            this.groupBox1.Controls.Add(this.dtpBegin);
            this.groupBox1.Controls.Add(this.txbNavicert);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 10.5F);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(770, 114);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // dgvWeightBang
            // 
            this.dgvWeightBang.AllowUserToAddRows = false;
            this.dgvWeightBang.AllowUserToDeleteRows = false;
            this.dgvWeightBang.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvWeightBang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWeightBang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WeightBangCode,
            this.NavicertID,
            this.CoalKind,
            this.煤矿名称,
            this.车主,
            this.磅房,
            this.机柜});
            this.dgvWeightBang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvWeightBang.Location = new System.Drawing.Point(3, 19);
            this.dgvWeightBang.Name = "dgvWeightBang";
            this.dgvWeightBang.ReadOnly = true;
            this.dgvWeightBang.RowHeadersWidth = 20;
            this.dgvWeightBang.RowTemplate.Height = 23;
            this.dgvWeightBang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvWeightBang.Size = new System.Drawing.Size(773, 285);
            this.dgvWeightBang.TabIndex = 5;
            // 
            // WeightBangCode
            // 
            this.WeightBangCode.DataPropertyName = "BangLogCode";
            this.WeightBangCode.HeaderText = "过磅日志编号";
            this.WeightBangCode.Name = "WeightBangCode";
            this.WeightBangCode.ReadOnly = true;
            this.WeightBangCode.Width = 150;
            // 
            // NavicertID
            // 
            this.NavicertID.DataPropertyName = "CardCode";
            this.NavicertID.HeaderText = "准运卡号";
            this.NavicertID.Name = "NavicertID";
            this.NavicertID.ReadOnly = true;
            // 
            // CoalKind
            // 
            this.CoalKind.DataPropertyName = "LogContent";
            this.CoalKind.HeaderText = "过磅信息";
            this.CoalKind.Name = "CoalKind";
            this.CoalKind.ReadOnly = true;
            this.CoalKind.Width = 300;
            // 
            // 煤矿名称
            // 
            this.煤矿名称.DataPropertyName = "PonderationType";
            this.煤矿名称.HeaderText = "过磅类型";
            this.煤矿名称.Name = "煤矿名称";
            this.煤矿名称.ReadOnly = true;
            // 
            // 车主
            // 
            this.车主.DataPropertyName = "LogTime";
            this.车主.HeaderText = "过磅时间";
            this.车主.Name = "车主";
            this.车主.ReadOnly = true;
            // 
            // 磅房
            // 
            this.磅房.DataPropertyName = "BangRoom";
            this.磅房.HeaderText = "磅房";
            this.磅房.Name = "磅房";
            this.磅房.ReadOnly = true;
            // 
            // 机柜
            // 
            this.机柜.DataPropertyName = "cupboardNO";
            this.机柜.HeaderText = "机柜";
            this.机柜.Name = "机柜";
            this.机柜.ReadOnly = true;
            // 
            // BangLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 504);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BangLog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "过磅日志查询";
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.gr.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWeightBang)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpBegin;
        private System.Windows.Forms.TextBox txbNavicert;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox gr;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvWeightBang;
        private System.Windows.Forms.DataGridViewTextBoxColumn WeightBangCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn NavicertID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CoalKind;
        private System.Windows.Forms.DataGridViewTextBoxColumn 煤矿名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 车主;
        private System.Windows.Forms.DataGridViewTextBoxColumn 磅房;
        private System.Windows.Forms.DataGridViewTextBoxColumn 机柜;
    }
}