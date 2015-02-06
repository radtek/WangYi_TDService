namespace TDService
{
    partial class DataBaseGTInitial
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
            this.txbGTPwd = new System.Windows.Forms.TextBox();
            this.txbGTUserName = new System.Windows.Forms.TextBox();
            this.txbGTDataBase = new System.Windows.Forms.TextBox();
            this.txbGTServer = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txbGTPwd);
            this.groupBox1.Controls.Add(this.txbGTUserName);
            this.groupBox1.Controls.Add(this.txbGTDataBase);
            this.groupBox1.Controls.Add(this.txbGTServer);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(7, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(217, 171);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "服务器";
            // 
            // txbGTPwd
            // 
            this.txbGTPwd.Location = new System.Drawing.Point(81, 136);
            this.txbGTPwd.Name = "txbGTPwd";
            this.txbGTPwd.Size = new System.Drawing.Size(119, 21);
            this.txbGTPwd.TabIndex = 7;
            // 
            // txbGTUserName
            // 
            this.txbGTUserName.Location = new System.Drawing.Point(81, 98);
            this.txbGTUserName.Name = "txbGTUserName";
            this.txbGTUserName.Size = new System.Drawing.Size(119, 21);
            this.txbGTUserName.TabIndex = 6;
            // 
            // txbGTDataBase
            // 
            this.txbGTDataBase.Location = new System.Drawing.Point(81, 61);
            this.txbGTDataBase.Name = "txbGTDataBase";
            this.txbGTDataBase.Size = new System.Drawing.Size(119, 21);
            this.txbGTDataBase.TabIndex = 5;
            // 
            // txbGTServer
            // 
            this.txbGTServer.Location = new System.Drawing.Point(81, 25);
            this.txbGTServer.Name = "txbGTServer";
            this.txbGTServer.Size = new System.Drawing.Size(119, 21);
            this.txbGTServer.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "登陆密码：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "登陆名称：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "数据库名：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "服务器名：";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(88, 187);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(66, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "保 存";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(164, 187);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(52, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "退 出";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // DataBaseGTInitial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(231, 220);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Name = "DataBaseGTInitial";
            this.Text = "坩土数据库设置";
            this.Load += new System.EventHandler(this.DataBaseGTInitial_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbGTPwd;
        private System.Windows.Forms.TextBox txbGTUserName;
        private System.Windows.Forms.TextBox txbGTDataBase;
        private System.Windows.Forms.TextBox txbGTServer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}