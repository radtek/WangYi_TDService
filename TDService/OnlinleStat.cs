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
    public partial class OnlinleStat : Form
    {

       
        public OnlinleStat()
        {
            InitializeComponent();
        }

       // delegate void StartPingCallback(string ip, string bangname);

        string[] Bangfangs ={ "���񹵰���", "ˮ����1�Ű���", "ˮ����2�Ű���", "�¹��ճ�����", "�¹�ϴ��ú1�Ű���", "�¹�ϴ��ú2�Ű���", "�¹�ԭú1�Ű���", "�¹�ԭú2�Ű���", "��ʯ�׿ճ�����", "��ʯ���س�1�Ű���", "��ʯ���س�2�Ű���", "�ݼҺӰ���", "�¼�ƺ1�Ű���", "�¼�ƺ2�Ű���", "�¼�ƺ3�Ű���", "�¼�ƺ4�Ű���" };

        int[] stats ={ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 };

        int mystat = 0;

        //TDService.Code.INIClass ini = new TDService.Code.INIClass(".\\Config.ini");

        private void OnlinleStat_Load(object sender, EventArgs e)
        {

            //timer1.Interval = 100;

            //timer1.Enabled = true;
            myThread();

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
                    ul(ip, HostName,BangName);
            }
        }

        void myThread()
        {
            int Min = 1;
            int Max = Bangfangs.Length;

            //�ж������IP��ַ�����Ƿ�Ϸ�
            int _ThreadNum = Max - Min + 1;
            Thread[] mythread = new Thread[_ThreadNum];
            //����һ�����Threadʵ��
            progressBar1.Minimum = Min;
            progressBar1.Maximum = Max+1;
            progressBar1.Value = Min;
            int i;
            for (i = Min; i <= Max; i++)
            {
                int k = Max - i;
                Ping HostPing = new Ping();
                //����һ��pingʵ��
                HostPing.ip = TDService.StaticForm.ini.IniReadValue(Bangfangs[k], "IP");
                HostPing.BangName = Bangfangs[k];
                HostPing.ul = new UpdateList(UpdateMyList);
                //�����pingʵ���д���IP��ַ�ַ���
                mythread[k] = new Thread(new ThreadStart(HostPing.scan));
                //��ʼ��һ���߳�ʵ��
                mythread[k].Start();
                //�����߳�
            }

        }

        void UpdateMyList(string sIP, string sHostName,string bangName)
        {
            if (progressBar1.InvokeRequired)
            {
                UpdateList d = new UpdateList(UpdateMyList);
                progressBar1.Invoke(d, new object[] { sIP, sHostName,bangName });
            }
            else
            {
                lock (progressBar1)
                {
                    if (sHostName == "����û����Ӧ")
                    {
                        StartPing(bangName, "0");
                    }
                    else
                    {
                        StartPing(bangName, "1");
                    }
                }
            }
        }


        void StartPing(string bangname, string stat)
        {
            switch (bangname)
            {
                case "���񹵰���":
                    {

                       // pictureBox1.Visible = true;

                        if (stat != "1")
                        {
                            pictureBox1.Image = Properties.Resources.Off;
                        }

                        progressBar1.Value++;

                        break;
                    }
                case "ˮ����1�Ű���":
                    {

                       // pictureBox2.Visible = true;


                        if (stat != "1")
                        {
                            pictureBox2.Image = Properties.Resources.Off;
                        }

                        progressBar1.Value++;

                        break;
                    }
                case "ˮ����2�Ű���":
                    {

                       // pictureBox3.Visible = true;

                        if (stat != "1")
                        {
                            pictureBox16.Image = Properties.Resources.Off;
                        }

                        progressBar1.Value++;

                        break;
                    }
                case "�¹��ճ�����":
                    {

                       // pictureBox13.Visible = true;

                        if (stat != "1")
                        {
                            pictureBox3.Image = Properties.Resources.Off;
                        }

                        progressBar1.Value++;

                        break;
                    }
                case "�¹�ϴ��ú1�Ű���":
                    {

                        //pictureBox5.Visible = true;

                        if (stat != "1")
                        {
                            pictureBox13.Image = Properties.Resources.Off;
                        }

                        progressBar1.Value++;

                        break;
                    }
                case "�¹�ϴ��ú2�Ű���":
                    {

                       // pictureBox6.Visible = true;

                        if (stat != "1")
                        {
                            pictureBox5.Image = Properties.Resources.Off;
                        }

                        progressBar1.Value++;

                        break;
                    }
                case "�¹�ԭú1�Ű���":
                    {

                        // pictureBox6.Visible = true;

                        if (stat != "1")
                        {
                            pictureBox8.Image = Properties.Resources.Off;
                        }

                        progressBar1.Value++;

                        break;
                    }
                case "�¹�ԭú2�Ű���":
                    {

                        // pictureBox6.Visible = true;

                        if (stat != "1")
                        {
                            pictureBox6.Image = Properties.Resources.Off;
                        }

                        progressBar1.Value++;

                        break;
                    }
                case "��ʯ�׿ճ�����":
                    {

                        // pictureBox6.Visible = true;

                        if (stat != "1")
                        {
                            pictureBox14.Image = Properties.Resources.Off;
                        }

                        progressBar1.Value++;

                        break;
                    }
                case "��ʯ���س�1�Ű���":
                    {

                        // pictureBox6.Visible = true;

                        if (stat != "1")
                        {
                            pictureBox9.Image = Properties.Resources.Off;
                        }

                        progressBar1.Value++;

                        break;
                    }
                case "��ʯ���س�2�Ű���":
                    {

                        // pictureBox6.Visible = true;

                        if (stat != "1")
                        {
                            pictureBox4.Image = Properties.Resources.Off;
                        }

                        progressBar1.Value++;

                        break;
                    }
                case "�ݼҺӰ���":
                    {

                        // pictureBox6.Visible = true;

                        if (stat != "1")
                        {
                            pictureBox7.Image = Properties.Resources.Off;
                        }

                        progressBar1.Value++;

                        break;
                    }
                case "�¼�ƺ1�Ű���":
                    {

                        // pictureBox6.Visible = true;

                        if (stat != "1")
                        {
                            pictureBox15.Image = Properties.Resources.Off;
                        }

                        progressBar1.Value++;

                        break;
                    }
                case "�¼�ƺ2�Ű���":
                    {

                        // pictureBox6.Visible = true;

                        if (stat != "1")
                        {
                            pictureBox10.Image = Properties.Resources.Off;
                        }

                        progressBar1.Value++;

                        break;
                    }
                case "�¼�ƺ3�Ű���":
                    {

                        // pictureBox6.Visible = true;

                        if (stat != "1")
                        {
                            pictureBox11.Image = Properties.Resources.Off;
                        }

                        progressBar1.Value++;

                        break;
                    }
                case "�¼�ƺ4�Ű���":
                    {

                        // pictureBox6.Visible = true;

                        if (stat == "1")
                        {
                            pictureBox12.Image = Properties.Resources.On;
                        }
                        else
                        {
                            pictureBox12.Image = Properties.Resources.Off;
                        }

                        progressBar1.Value++;

                        break;
                    }
            }

        }

        /// <summary>
        /// ����IP�ж��Ƿ�ping��ͨ 
        /// </summary>
        /// <param name="strIp"></param>
        /// <returns></returns>
        public string GetCmdPingResult(string strIp)
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            string pingrst;
            p.Start();
            p.StandardInput.WriteLine("ping -n 1 " + strIp);
            p.StandardInput.WriteLine("exit");
            string strRst = p.StandardOutput.ReadToEnd();
            if (strRst.IndexOf("(0% loss)") != -1 || strRst.IndexOf("(0% ��ʧ)") != -1)
                pingrst = "1";  //����
            else if (strRst.IndexOf("Destination host unreachable.") != -1)
                pingrst = "0";  //�޷�����Ŀ������
            else if (strRst.IndexOf("Request timed out.") != -1)
                pingrst = "0";  //��ʱ
            else if (strRst.IndexOf("Unknown host") != -1)
                pingrst = "0";  //�޷���������
            else
                pingrst = strRst;
            p.Close();

            return pingrst;
        }

        
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //TDService.SetIP.NewSetIP("���񹵰���");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //TDService.SetIP.NewSetIP("ˮ����1�Ű���");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //TDService.SetIP.NewSetIP("�¹��ճ�����");
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            //TDService.SetIP.NewSetIP("�¹�ϴ��ú1�Ű���");
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            //TDService.SetIP.NewSetIP("�¹�ϴ��ú2�Ű���");
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            //TDService.SetIP.NewSetIP("�¹�ԭú2�Ű���");
        }

        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    timer1.Enabled = false;

        //    string strIP = TDService.StaticForm.ini.IniReadValue(Bangfangs[mystat], "IP");

        //    StartPing(strIP, Bangfangs[mystat]);

        //    if (getPingStat())
        //    {
        //        timer1.Enabled = false;
        //    }
        //}

        //bool getPingStat()
        //{
        //    for (int i = 0; i < stats.Length; i++)
        //    {
        //        if (stats[i] == 0)
        //        {
        //            return false;
        //        }
        //    }

        //    return true;
        //}

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            //TDService.SetIP.NewSetIP("�¹�ԭú1�Ű���");
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            //TDService.SetIP.NewSetIP("ˮ����2�Ű���");
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            //TDService.SetIP.NewSetIP("��ʯ�׿ճ�����");
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            //TDService.SetIP.NewSetIP("��ʯ���س�1�Ű���");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            //TDService.SetIP.NewSetIP("��ʯ���س�2�Ű���");
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            //TDService.SetIP.NewSetIP("�ݼҺӰ���");
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            //TDService.SetIP.NewSetIP("�¼�ƺ1�Ű���");
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            //TDService.SetIP.NewSetIP("�¼�ƺ2�Ű���");
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            //TDService.SetIP.NewSetIP("�¼�ƺ3�Ű���");
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            //TDService.SetIP.NewSetIP("�¼�ƺ4�Ű���");
        }

    }
}