using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TDService
{
    public partial class DataBaseInitial : Form
    {
        public DataBaseInitial()
        {
            InitializeComponent();
        }
        TDService.Code.INIClass ini = new TDService.Code.INIClass(".\\Config.ini");

        private void btnSave_Click(object sender, EventArgs e)
        {
            TDService.StaticForm.loginstat = 2;

            ini.IniWriteValue("Server","ServerName",this.txbRServer.Text);
            ini.IniWriteValue("Server", "ServerDataBase", this.txtDatabase.Text);
            ini.IniWriteValue("Server", "ServerLoginName", this.txbLoginName.Text);
            ini.IniWriteValue("Server", "ServerPwd", this.txbRPsd.Text);

            ini.IniWriteValue("GTServer", "GTServerName", this.txtGTServer.Text);
            ini.IniWriteValue("GTServer", "GTServerDataBase", this.txtGTDataBase.Text);
            ini.IniWriteValue("GTServer", "GTServerLoginName", this.txtGTLoginName.Text);
            ini.IniWriteValue("GTServer", "GTServerPwd", this.txtGTPsd.Text);
            MessageBox.Show("保存成功，请重新进入");
            mainForm.mForm.Close();
            this.Close();
        }

        private void DataBaseInitial_Load(object sender, EventArgs e)
        {
            if (TDService.StaticForm.loginstat == 2)
            {
                this.btnSave.Text = "保存设置";
                btnClose.Text = "关闭";
            }
            this.txbRServer.Text=ini.IniReadValue("Server", "ServerName");
            this.txtDatabase.Text = ini.IniReadValue("Server", "ServerDataBase");
            this.txbLoginName.Text=ini.IniReadValue("Server", "ServerLoginName");
            this.txbRPsd.Text=ini.IniReadValue("Server", "ServerPwd");

            this.txtGTServer.Text = ini.IniReadValue("GTServer", "GTServerName");
            this.txtGTDataBase.Text = ini.IniReadValue("GTServer", "GTServerDataBase");
            this.txtGTLoginName.Text = ini.IniReadValue("GTServer", "GTServerLoginName");
            this.txtGTPsd.Text = ini.IniReadValue("GTServer", "GTServerPwd");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (btnClose.Text == "退出")
            {
                Application.Exit();
            }
            else
            {
                this.Close();
            }
        }
    }
}