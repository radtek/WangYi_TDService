using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace TDService
{
    public delegate void UpdateList(string sIP, string sHostName,string bangName);

    public partial class PingIP : Form
    {
        public PingIP()
        {
            InitializeComponent();
        }

        private void PingIP_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        //public class Ping
        //{
        //    public UpdateList ul;

        //    public string ip;
        //    //定义一个变量，用以接收传送来的IP地址字符串
        //    public string HostName;
        //    //定义一个变量，用以向主进展传递对应IP地址是否在线数据

            

        //    public void scan()
        //    {
        //        IPAddress myIP = IPAddress.Parse(ip);
        //        try
        //        {
        //            IPHostEntry myHost = Dns.GetHostByAddress(myIP);
        //            HostName = myHost.HostName.ToString();
        //        }
        //        catch
        //        {
        //            HostName = "";
        //        }
        //        if (HostName == "")
        //            HostName = " 主机没有响应！";
        //        if (ul != null)
        //            ul(ip, HostName);
        //    }
        //    //定义一个过程（也可以看出为方法），用以判断传送来的IP地址对应计算机是否在线
        //}

        //private System.DateTime StartTime;

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    listBox1.Items.Clear();
        //    //清楚扫描结果显示区域
        //    StartTime = DateTime.Now;
        //    //获取当前时间
        //    string mask = numericUpDown1.Value.ToString() + "." + numericUpDown2.Value.ToString() +
        //   "." + numericUpDown3.Value.ToString() + ".";
        //    int Min = (int)numericUpDown4.Value;
        //    int Max = (int)numericUpDown5.Value;
        //    if (Min > Max)
        //    {
        //        MessageBox.Show("输入的IP地址区间不合法，请检查！", "错误！");
        //        return;
        //    }
        //    //判断输入的IP地址区间是否合法
        //    int _ThreadNum = Max - Min + 1;
        //    Thread[] mythread = new Thread[_ThreadNum];
        //    //创建一个多个Thread实例
        //    progressBar1.Minimum = Min;
        //    progressBar1.Maximum = Max + 1;
        //    progressBar1.Value = Min;
        //    int i;
        //    for (i = Min; i <= Max; i++)
        //    {
        //        int k = Max - i;
        //        Ping HostPing = new Ping();
        //        //创建一个ping实例
        //        HostPing.ip = mask + i.ToString();
        //        HostPing.ul = new UpdateList(UpdateMyList);
        //        //向这个ping实例中传递IP地址字符串
        //        mythread[k] = new Thread(new ThreadStart(HostPing.scan));
        //        //初始化一个线程实例
        //        mythread[k].Start();
        //        //启动线程
        //    } 

        //}

        //void UpdateMyList(string sIP, string sHostName)
        //{
        //    if (listBox1.InvokeRequired)
        //    {
        //        UpdateList d = new UpdateList(UpdateMyList);
        //        listBox1.Invoke(d, new object[] { sIP, sHostName });
        //    }
        //    else
        //    {
        //        lock (listBox1)
        //        {
        //            listBox1.Items.Add(sIP + " " + sHostName);
        //            if (progressBar1.Value != progressBar1.Maximum)
        //            {
        //                progressBar1.Value++;
        //            }
        //            if (progressBar1.Value == progressBar1.Maximum)
        //            {
        //                //MessageBox.Show("成功完成检测！", "提示");
        //                DateTime EndTime = DateTime.Now;
        //                TimeSpan ts = EndTime - StartTime;
        //                label4.Text = ts.Seconds.ToString() + "秒";
        //                //显示扫描计算机所需要的时间
        //                progressBar1.Value = progressBar1.Minimum;
        //            }
        //        }
        //    }
        //}
    }
}