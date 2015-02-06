namespace TDService
{
    partial class PingServer
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
            this.components = new System.ComponentModel.Container();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssl_OnlineLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssl_Online = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("宋体", 10.5F);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssl_OnlineLabel,
            this.tssl_Online});
            this.statusStrip1.Location = new System.Drawing.Point(0, 243);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.ShowItemToolTips = true;
            this.statusStrip1.Size = new System.Drawing.Size(292, 23);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssl_OnlineLabel
            // 
            this.tssl_OnlineLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.tssl_OnlineLabel.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedOuter;
            this.tssl_OnlineLabel.Name = "tssl_OnlineLabel";
            this.tssl_OnlineLabel.Size = new System.Drawing.Size(67, 18);
            this.tssl_OnlineLabel.Text = "网络状态";
            // 
            // tssl_Online
            // 
            this.tssl_Online.Image = global::TDService.Properties.Resources.On;
            this.tssl_Online.Name = "tssl_Online";
            this.tssl_Online.Size = new System.Drawing.Size(16, 18);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // PingServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.statusStrip1);
            this.Name = "PingServer";
            this.Text = "PingServer";
            this.Load += new System.EventHandler(this.PingServer_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssl_OnlineLabel;
        private System.Windows.Forms.ToolStripStatusLabel tssl_Online;
        private System.Windows.Forms.Timer timer1;

    }
}