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

        string[] Bangfangs ={ "虎神沟磅房", "水帘洞1号磅房", "水帘洞2号磅房", "下沟空车磅房", "下沟洗精煤1号磅房", "下沟洗精煤2号磅房", "下沟原煤1号磅房", "下沟原煤2号磅房", "火石咀空车磅房", "火石咀重车1号磅房", "火石咀重车2号磅房", "拜家河磅房", "陈家坪1号磅房", "陈家坪2号磅房", "陈家坪3号磅房", "陈家坪4号磅房" };

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
                    ul(ip, HostName,BangName);
            }
        }

        void myThread()
        {
            int Min = 1;
            int Max = Bangfangs.Length;

            //判断输入的IP地址区间是否合法
            int _ThreadNum = Max - Min + 1;
            Thread[] mythread = new Thread[_ThreadNum];
            //创建一个多个Thread实例
            progressBar1.Minimum = Min;
            progressBar1.Maximum = Max+1;
            progressBar1.Value = Min;
            int i;
            for (i = Min; i <= Max; i++)
            {
                int k = Max - i;
                Ping HostPing = new Ping();
                //创建一个ping实例
                HostPing.ip = TDService.StaticForm.ini.IniReadValue(Bangfangs[k], "IP");
                HostPing.BangName = Bangfangs[k];
                HostPing.ul = new UpdateList(UpdateMyList);
                //向这个ping实例中传递IP地址字符串
                mythread[k] = new Thread(new ThreadStart(HostPing.scan));
                //初始化一个线程实例
                mythread[k].Start();
                //启动线程
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
                    if (sHostName == "主机没有响应")
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
                case "虎神沟磅房":
                    {

                       // pictureBox1.Visible = true;

                        if (stat != "1")
                        {
                            pictureBox1.Image = Properties.Resources.Off;
                        }

                        progressBar1.Value++;

                        break;
                    }
                case "水帘洞1号磅房":
                    {

                       // pictureBox2.Visible = true;


                        if (stat != "1")
                        {
                            pictureBox2.Image = Properties.Resources.Off;
                        }

                        progressBar1.Value++;

                        break;
                    }
                case "水帘洞2号磅房":
                    {

                       // pictureBox3.Visible = true;

                        if (stat != "1")
                        {
                            pictureBox16.Image = Properties.Resources.Off;
                        }

                        progressBar1.Value++;

                        break;
                    }
                case "下沟空车磅房":
                    {

                       // pictureBox13.Visible = true;

                        if (stat != "1")
                        {
                            pictureBox3.Image = Properties.Resources.Off;
                        }

                        progressBar1.Value++;

                        break;
                    }
                case "下沟洗精煤1号磅房":
                    {

                        //pictureBox5.Visible = true;

                        if (stat != "1")
                        {
                            pictureBox13.Image = Properties.Resources.Off;
                        }

                        progressBar1.Value++;

                        break;
                    }
                case "下沟洗精煤2号磅房":
                    {

                       // pictureBox6.Visible = true;

                        if (stat != "1")
                        {
                            pictureBox5.Image = Properties.Resources.Off;
                        }

                        progressBar1.Value++;

                        break;
                    }
                case "下沟原煤1号磅房":
                    {

                        // pictureBox6.Visible = true;

                        if (stat != "1")
                        {
                            pictureBox8.Image = Properties.Resources.Off;
                        }

                        progressBar1.Value++;

                        break;
                    }
                case "下沟原煤2号磅房":
                    {

                        // pictureBox6.Visible = true;

                        if (stat != "1")
                        {
                            pictureBox6.Image = Properties.Resources.Off;
                        }

                        progressBar1.Value++;

                        break;
                    }
                case "火石咀空车磅房":
                    {

                        // pictureBox6.Visible = true;

                        if (stat != "1")
                        {
                            pictureBox14.Image = Properties.Resources.Off;
                        }

                        progressBar1.Value++;

                        break;
                    }
                case "火石咀重车1号磅房":
                    {

                        // pictureBox6.Visible = true;

                        if (stat != "1")
                        {
                            pictureBox9.Image = Properties.Resources.Off;
                        }

                        progressBar1.Value++;

                        break;
                    }
                case "火石咀重车2号磅房":
                    {

                        // pictureBox6.Visible = true;

                        if (stat != "1")
                        {
                            pictureBox4.Image = Properties.Resources.Off;
                        }

                        progressBar1.Value++;

                        break;
                    }
                case "拜家河磅房":
                    {

                        // pictureBox6.Visible = true;

                        if (stat != "1")
                        {
                            pictureBox7.Image = Properties.Resources.Off;
                        }

                        progressBar1.Value++;

                        break;
                    }
                case "陈家坪1号磅房":
                    {

                        // pictureBox6.Visible = true;

                        if (stat != "1")
                        {
                            pictureBox15.Image = Properties.Resources.Off;
                        }

                        progressBar1.Value++;

                        break;
                    }
                case "陈家坪2号磅房":
                    {

                        // pictureBox6.Visible = true;

                        if (stat != "1")
                        {
                            pictureBox10.Image = Properties.Resources.Off;
                        }

                        progressBar1.Value++;

                        break;
                    }
                case "陈家坪3号磅房":
                    {

                        // pictureBox6.Visible = true;

                        if (stat != "1")
                        {
                            pictureBox11.Image = Properties.Resources.Off;
                        }

                        progressBar1.Value++;

                        break;
                    }
                case "陈家坪4号磅房":
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
        /// 根据IP判断是否ping不通 
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
            if (strRst.IndexOf("(0% loss)") != -1 || strRst.IndexOf("(0% 丢失)") != -1)
                pingrst = "1";  //连接
            else if (strRst.IndexOf("Destination host unreachable.") != -1)
                pingrst = "0";  //无法到达目的主机
            else if (strRst.IndexOf("Request timed out.") != -1)
                pingrst = "0";  //超时
            else if (strRst.IndexOf("Unknown host") != -1)
                pingrst = "0";  //无法解析主机
            else
                pingrst = strRst;
            p.Close();

            return pingrst;
        }

        
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //TDService.SetIP.NewSetIP("虎神沟磅房");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //TDService.SetIP.NewSetIP("水帘洞1号磅房");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //TDService.SetIP.NewSetIP("下沟空车磅房");
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            //TDService.SetIP.NewSetIP("下沟洗精煤1号磅房");
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            //TDService.SetIP.NewSetIP("下沟洗精煤2号磅房");
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            //TDService.SetIP.NewSetIP("下沟原煤2号磅房");
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
            //TDService.SetIP.NewSetIP("下沟原煤1号磅房");
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            //TDService.SetIP.NewSetIP("水帘洞2号磅房");
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            //TDService.SetIP.NewSetIP("火石咀空车磅房");
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            //TDService.SetIP.NewSetIP("火石咀重车1号磅房");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            //TDService.SetIP.NewSetIP("火石咀重车2号磅房");
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            //TDService.SetIP.NewSetIP("拜家河磅房");
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            //TDService.SetIP.NewSetIP("陈家坪1号磅房");
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            //TDService.SetIP.NewSetIP("陈家坪2号磅房");
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            //TDService.SetIP.NewSetIP("陈家坪3号磅房");
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            //TDService.SetIP.NewSetIP("陈家坪4号磅房");
        }

    }
}