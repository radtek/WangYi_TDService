using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TDService
{
    public partial class DataBaseGTInitial : Form
    {
        public DataBaseGTInitial()
        {
            InitializeComponent();
        }
        TDService.Code.INIClass ini = new TDService.Code.INIClass(".\\Config.ini");

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void DataBaseGTInitial_Load(object sender, EventArgs e)
        {
            if (TDService.StaticForm.loginstat == 2)
            {
                this.button1.Text = "保存设置";
                button2.Text = "关闭";
            }
            this.txbGTServer.Text = ini.IniReadValue("GTServer", "GTServerName");
            this.txbGTDataBase.Text = ini.IniReadValue("GTServer", "GTServerDataBase");
            this.txbGTUserName.Text = ini.IniReadValue("GTServer", "GTServerLoginName");
            this.txbGTPwd.Text = ini.IniReadValue("GTServer", "GTServerPwd");
        }
    }
}