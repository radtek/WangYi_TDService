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
        //    //����һ�����������Խ��մ�������IP��ַ�ַ���
        //    public string HostName;
        //    //����һ������������������չ���ݶ�ӦIP��ַ�Ƿ���������

            

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
        //            HostName = " ����û����Ӧ��";
        //        if (ul != null)
        //            ul(ip, HostName);
        //    }
        //    //����һ�����̣�Ҳ���Կ���Ϊ�������������жϴ�������IP��ַ��Ӧ������Ƿ�����
        //}

        //private System.DateTime StartTime;

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    listBox1.Items.Clear();
        //    //���ɨ������ʾ����
        //    StartTime = DateTime.Now;
        //    //��ȡ��ǰʱ��
        //    string mask = numericUpDown1.Value.ToString() + "." + numericUpDown2.Value.ToString() +
        //   "." + numericUpDown3.Value.ToString() + ".";
        //    int Min = (int)numericUpDown4.Value;
        //    int Max = (int)numericUpDown5.Value;
        //    if (Min > Max)
        //    {
        //        MessageBox.Show("�����IP��ַ���䲻�Ϸ������飡", "����");
        //        return;
        //    }
        //    //�ж������IP��ַ�����Ƿ�Ϸ�
        //    int _ThreadNum = Max - Min + 1;
        //    Thread[] mythread = new Thread[_ThreadNum];
        //    //����һ�����Threadʵ��
        //    progressBar1.Minimum = Min;
        //    progressBar1.Maximum = Max + 1;
        //    progressBar1.Value = Min;
        //    int i;
        //    for (i = Min; i <= Max; i++)
        //    {
        //        int k = Max - i;
        //        Ping HostPing = new Ping();
        //        //����һ��pingʵ��
        //        HostPing.ip = mask + i.ToString();
        //        HostPing.ul = new UpdateList(UpdateMyList);
        //        //�����pingʵ���д���IP��ַ�ַ���
        //        mythread[k] = new Thread(new ThreadStart(HostPing.scan));
        //        //��ʼ��һ���߳�ʵ��
        //        mythread[k].Start();
        //        //�����߳�
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
        //                //MessageBox.Show("�ɹ���ɼ�⣡", "��ʾ");
        //                DateTime EndTime = DateTime.Now;
        //                TimeSpan ts = EndTime - StartTime;
        //                label4.Text = ts.Seconds.ToString() + "��";
        //                //��ʾɨ����������Ҫ��ʱ��
        //                progressBar1.Value = progressBar1.Minimum;
        //            }
        //        }
        //    }
        //}
    }
}