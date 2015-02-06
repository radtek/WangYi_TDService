//namespace CoalTraffic
namespace TDService
{
    partial class FM_WeightBangSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FM_WeightBangSearch));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.cmbRoom = new System.Windows.Forms.ComboBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.dtpBegin = new System.Windows.Forms.DateTimePicker();
            this.btnQuery = new System.Windows.Forms.Button();
            this.txbCarNo = new System.Windows.Forms.TextBox();
            this.txbNavicert = new System.Windows.Forms.TextBox();
            this.txbWeightBangCode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gr = new System.Windows.Forms.GroupBox();
            this.dgvWeightBang = new System.Windows.Forms.DataGridView();
            this.WeightBangCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NavicertID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmptyWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CoalKind = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.车牌号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.车型 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.车主 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.煤矿名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.gr.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWeightBang)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.cmbRoom);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.dtpBegin);
            this.groupBox1.Controls.Add(this.btnQuery);
            this.groupBox1.Controls.Add(this.txbCarNo);
            this.groupBox1.Controls.Add(this.txbNavicert);
            this.groupBox1.Controls.Add(this.txbWeightBangCode);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 10.5F);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(901, 104);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(761, 61);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "退 出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // cmbRoom
            // 
            this.cmbRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoom.FormattingEnabled = true;
            this.cmbRoom.Location = new System.Drawing.Point(106, 24);
            this.cmbRoom.Name = "cmbRoom";
            this.cmbRoom.Size = new System.Drawing.Size(150, 22);
            this.cmbRoom.TabIndex = 16;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(680, 61);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "复 位";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // dtpBegin
            // 
            this.dtpBegin.Location = new System.Drawing.Point(106, 61);
            this.dtpBegin.MinDate = new System.DateTime(2009, 1, 1, 0, 0, 0, 0);
            this.dtpBegin.Name = "dtpBegin";
            this.dtpBegin.Size = new System.Drawing.Size(150, 23);
            this.dtpBegin.TabIndex = 14;
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(599, 61);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 0;
            this.btnQuery.Text = "查 询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // txbCarNo
            // 
            this.txbCarNo.Location = new System.Drawing.Point(385, 62);
            this.txbCarNo.Name = "txbCarNo";
            this.txbCarNo.Size = new System.Drawing.Size(150, 23);
            this.txbCarNo.TabIndex = 11;
            // 
            // txbNavicert
            // 
            this.txbNavicert.Location = new System.Drawing.Point(683, 22);
            this.txbNavicert.Name = "txbNavicert";
            this.txbNavicert.Size = new System.Drawing.Size(150, 23);
            this.txbNavicert.TabIndex = 10;
            // 
            // txbWeightBangCode
            // 
            this.txbWeightBangCode.Location = new System.Drawing.Point(385, 23);
            this.txbWeightBangCode.Name = "txbWeightBangCode";
            this.txbWeightBangCode.Size = new System.Drawing.Size(150, 23);
            this.txbWeightBangCode.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label7.Location = new System.Drawing.Point(39, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 14);
            this.label7.TabIndex = 6;
            this.label7.Text = "时间范围";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label5.Location = new System.Drawing.Point(318, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 14);
            this.label5.TabIndex = 4;
            this.label5.Text = "车 牌 号";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label4.Location = new System.Drawing.Point(318, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 3;
            this.label4.Text = "过磅编号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label2.Location = new System.Drawing.Point(615, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "准运卡号";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label1.Location = new System.Drawing.Point(39, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "磅房名称";
            // 
            // gr
            // 
            this.gr.Controls.Add(this.dgvWeightBang);
            this.gr.Font = new System.Drawing.Font("宋体", 10.5F);
            this.gr.Location = new System.Drawing.Point(12, 122);
            this.gr.Name = "gr";
            this.gr.Size = new System.Drawing.Size(901, 342);
            this.gr.TabIndex = 0;
            this.gr.TabStop = false;
            this.gr.Text = "重车过磅列表";
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
            this.Column2,
            this.Column3,
            this.EmptyWeight,
            this.Column4,
            this.Column5,
            this.CoalKind,
            this.Column6,
            this.车牌号,
            this.车型,
            this.车主,
            this.煤矿名称,
            this.Column7,
            this.Column8});
            this.dgvWeightBang.Location = new System.Drawing.Point(3, 19);
            this.dgvWeightBang.Name = "dgvWeightBang";
            this.dgvWeightBang.ReadOnly = true;
            this.dgvWeightBang.RowHeadersWidth = 20;
            this.dgvWeightBang.RowTemplate.Height = 23;
            this.dgvWeightBang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvWeightBang.Size = new System.Drawing.Size(892, 320);
            this.dgvWeightBang.TabIndex = 2;
            // 
            // WeightBangCode
            // 
            this.WeightBangCode.DataPropertyName = "WeightCode";
            this.WeightBangCode.HeaderText = "重磅编号";
            this.WeightBangCode.Name = "WeightBangCode";
            this.WeightBangCode.ReadOnly = true;
            // 
            // NavicertID
            // 
            this.NavicertID.DataPropertyName = "NavicertCode";
            this.NavicertID.HeaderText = "准运卡号";
            this.NavicertID.Name = "NavicertID";
            this.NavicertID.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "MarkedCardCode";
            this.Column2.HeaderText = "标识卡号";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "LoadWeight";
            this.Column3.HeaderText = "车辆总重";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // EmptyWeight
            // 
            this.EmptyWeight.DataPropertyName = "EmptyWeight";
            this.EmptyWeight.HeaderText = "车辆皮重";
            this.EmptyWeight.Name = "EmptyWeight";
            this.EmptyWeight.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "NetWeight";
            this.Column4.HeaderText = "车辆净重";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "TaxAmount";
            this.Column5.HeaderText = "规费金额";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // CoalKind
            // 
            this.CoalKind.DataPropertyName = "CoalKindName";
            this.CoalKind.HeaderText = "煤种";
            this.CoalKind.Name = "CoalKind";
            this.CoalKind.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "RoomName";
            this.Column6.HeaderText = "磅房名称";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // 车牌号
            // 
            this.车牌号.DataPropertyName = "CarNo";
            this.车牌号.HeaderText = "车牌号";
            this.车牌号.Name = "车牌号";
            this.车牌号.ReadOnly = true;
            // 
            // 车型
            // 
            this.车型.DataPropertyName = "CarType";
            this.车型.HeaderText = "车型";
            this.车型.Name = "车型";
            this.车型.ReadOnly = true;
            // 
            // 车主
            // 
            this.车主.DataPropertyName = "CarOwnerName";
            this.车主.HeaderText = "车主";
            this.车主.Name = "车主";
            this.车主.ReadOnly = true;
            // 
            // 煤矿名称
            // 
            this.煤矿名称.DataPropertyName = "CollName";
            this.煤矿名称.HeaderText = "煤矿名称";
            this.煤矿名称.Name = "煤矿名称";
            this.煤矿名称.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "BangType";
            this.Column7.HeaderText = "过磅类型";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "WeightTime";
            this.Column8.HeaderText = "过磅时间";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 150;
            // 
            // FM_WeightBangSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 476);
            this.Controls.Add(this.gr);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FM_WeightBangSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "重车过磅查询";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gr.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWeightBang)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpBegin;
        private System.Windows.Forms.TextBox txbCarNo;
        private System.Windows.Forms.TextBox txbNavicert;
        private System.Windows.Forms.TextBox txbWeightBangCode;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnQuery;


        private string _type = "";
        private System.Windows.Forms.ComboBox cmbRoom;
        private System.Windows.Forms.GroupBox gr;
        private System.Windows.Forms.DataGridView dgvWeightBang;
        private System.Windows.Forms.DataGridViewTextBoxColumn WeightBangCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn NavicertID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmptyWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn CoalKind;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn 车牌号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 车型;
        private System.Windows.Forms.DataGridViewTextBoxColumn 车主;
        private System.Windows.Forms.DataGridViewTextBoxColumn 煤矿名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
    }
}