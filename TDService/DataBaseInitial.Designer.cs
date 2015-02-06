namespace TDService
{
    partial class DataBaseInitial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataBaseInitial));
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txbRPsd = new System.Windows.Forms.TextBox();
            this.txbLoginName = new System.Windows.Forms.TextBox();
            this.txbRServer = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtGTPsd = new System.Windows.Forms.TextBox();
            this.txtGTLoginName = new System.Windows.Forms.TextBox();
            this.txtGTDataBase = new System.Windows.Forms.TextBox();
            this.txtGTServer = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(219, 189);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(70, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "保 存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDatabase);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txbRPsd);
            this.groupBox1.Controls.Add(this.txbLoginName);
            this.groupBox1.Controls.Add(this.txbRServer);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(194, 180);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "煤炭服务器";
            // 
            // txtDatabase
            // 
            this.txtDatabase.Location = new System.Drawing.Point(71, 64);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(107, 21);
            this.txtDatabase.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "数据库名";
            // 
            // txbRPsd
            // 
            this.txbRPsd.Location = new System.Drawing.Point(72, 140);
            this.txbRPsd.Name = "txbRPsd";
            this.txbRPsd.Size = new System.Drawing.Size(106, 21);
            this.txbRPsd.TabIndex = 5;
            this.txbRPsd.UseSystemPasswordChar = true;
            // 
            // txbLoginName
            // 
            this.txbLoginName.Location = new System.Drawing.Point(71, 100);
            this.txbLoginName.Name = "txbLoginName";
            this.txbLoginName.Size = new System.Drawing.Size(107, 21);
            this.txbLoginName.TabIndex = 4;
            // 
            // txbRServer
            // 
            this.txbRServer.Location = new System.Drawing.Point(72, 29);
            this.txbRServer.Name = "txbRServer";
            this.txbRServer.Size = new System.Drawing.Size(106, 21);
            this.txbRServer.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "登录密码";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "登陆名称";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "服务器名";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(309, 189);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(70, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "退 出";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtGTPsd);
            this.groupBox2.Controls.Add(this.txtGTLoginName);
            this.groupBox2.Controls.Add(this.txtGTDataBase);
            this.groupBox2.Controls.Add(this.txtGTServer);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(204, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(186, 180);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "坩土服务器";
            // 
            // txtGTPsd
            // 
            this.txtGTPsd.Location = new System.Drawing.Point(68, 138);
            this.txtGTPsd.Name = "txtGTPsd";
            this.txtGTPsd.Size = new System.Drawing.Size(107, 21);
            this.txtGTPsd.TabIndex = 7;
            this.txtGTPsd.UseSystemPasswordChar = true;
            // 
            // txtGTLoginName
            // 
            this.txtGTLoginName.Location = new System.Drawing.Point(68, 100);
            this.txtGTLoginName.Name = "txtGTLoginName";
            this.txtGTLoginName.Size = new System.Drawing.Size(107, 21);
            this.txtGTLoginName.TabIndex = 6;
            // 
            // txtGTDataBase
            // 
            this.txtGTDataBase.Location = new System.Drawing.Point(68, 64);
            this.txtGTDataBase.Name = "txtGTDataBase";
            this.txtGTDataBase.Size = new System.Drawing.Size(107, 21);
            this.txtGTDataBase.TabIndex = 5;
            // 
            // txtGTServer
            // 
            this.txtGTServer.Location = new System.Drawing.Point(68, 30);
            this.txtGTServer.Name = "txtGTServer";
            this.txtGTServer.Size = new System.Drawing.Size(107, 21);
            this.txtGTServer.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 141);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 3;
            this.label8.Text = "登陆密码";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 2;
            this.label7.Text = "登陆名称";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "数据库名";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "服务器名";
            // 
            // DataBaseInitial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 220);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DataBaseInitial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据库设置";
            this.Load += new System.EventHandler(this.DataBaseInitial_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txbRPsd;
        private System.Windows.Forms.TextBox txbLoginName;
        private System.Windows.Forms.TextBox txbRServer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtGTPsd;
        private System.Windows.Forms.TextBox txtGTLoginName;
        private System.Windows.Forms.TextBox txtGTDataBase;
        private System.Windows.Forms.TextBox txtGTServer;
    }
}