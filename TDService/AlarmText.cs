using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TDService.Data;

namespace TDService
{
    public partial class AlarmText : Form
    {
        //private string strText;
        public AlarmText()
        {
            InitializeComponent();
        }
        private static int i;
        private void AlarmText_Load(object sender, EventArgs e)
        {
            //this.BackColor = Color.Black;
            this.TopMost = true;
            this.SetDesktopLocation(400, 0);
            label1.ForeColor = Color.Red;
            this.timer1.Enabled = true;
            i = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string strSql = "Select TOP 1 * from TDY_Alarm order by AlarmTime desc";

            DataSet dst = new DataSet();
            try
            {
                dst = TDService.Data.SqlHelper.ExecuteDataSet(TDService.Data.SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql, null);
            }
            catch (Exception ex)
            {
                timer1.Enabled = false;
                return;
            }
            //if (dst.Tables.Count == 0)
            //{
            //    if (i > 150)
            //    {
            //        label1.Text = "旬邑税费征收管理网络中心欢迎领导莅临检查";
            //        i = 0;
            //    }
            //}
            //else if (dst.Tables[0].Rows.Count == 0)
            //{
               // if (i > 150)
               //{
               //     label1.Text = "旬邑税费征收管理网络中心欢迎领导莅临检查";
               //     i = 0;
               //}
            //}
            foreach (DataRow dr in dst.Tables[0].Rows)
            {
                string[] dt = this.DateDiff(Convert.ToDateTime(dr["AlarmTime"].ToString()),Convert.ToDateTime(SqlHelper.Executegetsqltime(TDService.Data.SqlHelper.ConnectionStringLocalTransaction)));
                if (dt[0].ToString() != "0" || dt[1].ToString() != "0")
                {
                    label1.Text = "旬邑税费征收管理网络中心欢迎领导莅临检查";
                    i = 0;
                }
                if (dt[0].ToString() == "0" && dt[1].ToString() == "0" && Convert.ToInt32(dt[2].ToString()) >= 1)
                {
                    label1.Text = "旬邑税费征收管理网络中心欢迎领导莅临检查";
                    i = 0;
                }
                else if (dt[0].ToString() == "0" && dt[1].ToString() == "0" && Convert.ToInt32(dt[2].ToString()) <= 60)
                {
                    label1.Text = dr["BangRoom"].ToString() + "," + dr["Remark"].ToString();
                    i = 0;
                }
                //string strDeleteSql = "Delete  TDY_AlarmList where AlarmCode=" + dr["AlarmCode"].ToString();
                //int iDelete = TDService.Data.SqlHelper.ExecuteNonQuery(TDService.Data.SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strDeleteSql, null);

            }
            label1.ForeColor = Color.Red;
            i++;
        }
        private string[] DateDiff(DateTime DateTime1, DateTime DateTime2)
        {

            TimeSpan ts1 = new TimeSpan(DateTime1.Ticks);
            TimeSpan ts2 = new TimeSpan(DateTime2.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();
            string[] dateDiff = new string[] { ts.Days.ToString(), ts.Hours.ToString(), ts.Minutes.ToString(), ts.Seconds.ToString() };

            return dateDiff;
        }
    }
}