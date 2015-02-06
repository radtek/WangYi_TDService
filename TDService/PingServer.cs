using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace TDService
{
    public partial class PingServer : Form
    {
        public PingServer()
        {
            InitializeComponent();
        }

        private void PingServer_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        

        public class Ping
        {
            public UpdateList ul;

            public string ip;
            //定义一个变量，用以接收传送来的IP地址字符串
            public string HostName;
            //定义一个变量，用以向主进展传递对应IP地址是否在线数据
            public string BangName;
            public void scan()
            {
                IPAddress myIP = IPAddress.Parse(ip);
                try
                {
                    IPHostEntry myHost = Dns.GetHostByAddress(myIP);
                    HostName = myHost.HostName.ToString();
                }
                catch
                {
                    HostName = "";
                }
                if (HostName == "")
                    HostName = "主机没有响应";
                if (ul != null)
                    ul(ip, HostName, BangName);
            }
        }

        void myThread()
        {
            //创建一个Thread实例

            Ping HostPing = new Ping();
            //创建一个ping实例
            HostPing.ip = TDService.StaticForm.ini.IniReadValue("Server", "ServerName");
            //HostPing.BangName = Bangfangs[k];
            HostPing.ul = new UpdateList(UpdateMyList);
            //向这个ping实例中传递IP地址字符串
            Thread thread = new Thread(new ThreadStart(HostPing.scan));
            //初始化一个线程实例
            thread.Start();
            //启动线程

        }

        void UpdateMyList(string sIP, string sHostName, string bangName)
        {
            if (this.InvokeRequired)
            {
                UpdateList d = new UpdateList(UpdateMyList);
                this.Invoke(d, new object[] { sIP, sHostName, bangName });
            }
            else
            {
                lock (this)
                {
                    if (sHostName == "主机没有响应")
                    {
                        tssl_Online.Image = TDService.Properties.Resources.Off;
                        tssl_Online.Text = "断网";
                        tssl_Online.ToolTipText = "断网";
                        
                    }
                    else
                    {
                        tssl_Online.Image = TDService.Properties.Resources.On;
                        tssl_Online.Text = "联网";
                        tssl_Online.ToolTipText = "联网";

                    }

                    timer1.Enabled=true;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            myThread();
        }
    }
}