namespace TDService
{
    partial class AlarmSelect
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbRoom = new System.Windows.Forms.ComboBox();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpBegin = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvAlarm = new System.Windows.Forms.DataGridView();
            this.磅房名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.报警类型 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.报警内容 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.报警时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlarm)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbRoom);
            this.groupBox1.Controls.Add(this.dtpEnd);
            this.groupBox1.Controls.Add(this.dtpBegin);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnSelect);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(13, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(421, 78);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // cmbRoom
            // 
            this.cmbRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoom.FormattingEnabled = true;
            this.cmbRoom.Location = new System.Drawing.Point(97, 16);
            this.cmbRoom.Name = "cmbRoom";
            this.cmbRoom.Size = new System.Drawing.Size(150, 20);
            this.cmbRoom.TabIndex = 20;
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(261, 46);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(122, 21);
            this.dtpEnd.TabIndex = 19;
            // 
            // dtpBegin
            // 
            this.dtpBegin.Location = new System.Drawing.Point(99, 46);
            this.dtpBegin.Name = "dtpBegin";
            this.dtpBegin.Size = new System.Drawing.Size(122, 21);
            this.dtpBegin.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label7.Location = new System.Drawing.Point(24, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 14);
            this.label7.TabIndex = 18;
            this.label7.Text = "时间范围";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label1.Location = new System.Drawing.Point(26, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 17;
            this.label1.Text = "磅房名称";
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(308, 15);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 0;
            this.btnSelect.Text = "查询";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label2.Location = new System.Drawing.Point(229, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 14);
            this.label2.TabIndex = 18;
            this.label2.Text = "至";
            // 
            // dgvAlarm
            // 
            this.dgvAlarm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlarm.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.磅房名称,
            this.报警类型,
            this.报警内容,
            this.报警时间});
            this.dgvAlarm.Location = new System.Drawing.Point(13, 88);
            this.dgvAlarm.Name = "dgvAlarm";
            this.dgvAlarm.RowTemplate.Height = 23;
            this.dgvAlarm.Size = new System.Drawing.Size(421, 249);
            this.dgvAlarm.TabIndex = 1;
            // 
            // 磅房名称
            // 
            this.磅房名称.DataPropertyName = "RoomName";
            this.磅房名称.HeaderText = "磅房名称";
            this.磅房名称.Name = "磅房名称";
            this.磅房名称.ReadOnly = true;
            this.磅房名称.Width = 130;
            // 
            // 报警类型
            // 
            this.报警类型.HeaderText = "报警类型";
            this.报警类型.Name = "报警类型";
            this.报警类型.ReadOnly = true;
            this.报警类型.Visible = false;
            this.报警类型.Width = 105;
            // 
            // 报警内容
            // 
            this.报警内容.DataPropertyName = "Decript";
            this.报警内容.HeaderText = "报警内容";
            this.报警内容.Name = "报警内容";
            this.报警内容.ReadOnly = true;
            this.报警内容.Width = 105;
            // 
            // 报警时间
            // 
            this.报警时间.DataPropertyName = "BreakDate";
            this.报警时间.HeaderText = "报警时间";
            this.报警时间.Name = "报警时间";
            this.报警时间.ReadOnly = true;
            this.报警时间.Width = 120;
            // 
            // AlarmSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 346);
            this.Controls.Add(this.dgvAlarm);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AlarmSelect";
            this.Text = "报警查询";
            this.Load += new System.EventHandler(this.AlarmSelect_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlarm)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvAlarm;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.ComboBox cmbRoom;
        private System.Windows.Forms.DateTimePicker dtpBegin;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn 磅房名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 报警类型;
        private System.Windows.Forms.DataGridViewTextBoxColumn 报警内容;
        private System.Windows.Forms.DataGridViewTextBoxColumn 报警时间;
    }
}