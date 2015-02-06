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
            //����һ�����������Խ��մ�������IP��ַ�ַ���
            public string HostName;
            //����һ������������������չ���ݶ�ӦIP��ַ�Ƿ���������
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
                    HostName = "����û����Ӧ";
                if (ul != null)
                    ul(ip, HostName, BangName);
            }
        }

        void myThread()
        {
            //����һ��Threadʵ��

            Ping HostPing = new Ping();
            //����һ��pingʵ��
            HostPing.ip = TDService.StaticForm.ini.IniReadValue("Server", "ServerName");
            //HostPing.BangName = Bangfangs[k];
            HostPing.ul = new UpdateList(UpdateMyList);
            //�����pingʵ���д���IP��ַ�ַ���
            Thread thread = new Thread(new ThreadStart(HostPing.scan));
            //��ʼ��һ���߳�ʵ��
            thread.Start();
            //�����߳�

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
                    if (sHostName == "����û����Ӧ")
                    {
                        tssl_Online.Image = TDService.Properties.Resources.Off;
                        tssl_Online.Text = "����";
                        tssl_Online.ToolTipText = "����";
                        
                    }
                    else
                    {
                        tssl_Online.Image = TDService.Properties.Resources.On;
                        tssl_Online.Text = "����";
                        tssl_Online.ToolTipText = "����";

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