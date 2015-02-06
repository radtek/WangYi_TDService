using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using SpeechLib;
using System.Diagnostics;
using System.Threading;
using System.Net;
using ZGHT.DataAccess;
using BaseData;
using TDService.Data;

namespace TDService
{
    public delegate void SpeekTextCallBack(string text);
    public delegate string ThreadSpeekText(string strIP);
    public partial class mainForm : Form
    {
        public static Form mForm;
        public static string strSumAlarmText = string.Empty;
        public static System.Threading.Thread thread;
        public static OnlinleStat online = new OnlinleStat();
        public static Loading loading = new Loading();
        public static int j = 0;
        public static int WeightBangtimenum = 0;/////新的重车过磅数据背景色显示时间
        System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();//用代码实例化一个时钟控件
        //System.Windows.Forms.Timer timer2 = new System.Windows.Forms.Timer();
        //System.Windows.Forms.Timer timer3 = new System.Windows.Forms.Timer();
        /// <summary>
        /// 全局变量--磅房名
        /// </summary>
        private string strRoomName;

        //报警ID
        string strRecordID = "";

        string myip = "";
        public mainForm()
        {
            InitializeComponent();
        }
        #region 窗体加载
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainForm_Load(object sender, EventArgs e)
        {
            mForm = this;
            this.dgvAlarm.AutoGenerateColumns = false;
            //this.dgvAlarm.Visible = false;
            //groupBox5.AutoSize = false;
            //groupBox5.Height=0;
            //groupBox5.Width = 0;
            this.dgvWeightBang.AutoGenerateColumns = false;

            #region 窗体加载的时候绑定磅房信息
            try
            {

                this.skinEngine1.Active = true;
                this.skinEngine1.SkinFile = "Msn.ssk";

                TDService.Data.SqlHelper.ComboxBind(tscbRoom, "TT_Room", "RoomName", "RoomCode", "IsForbid='0'", "RoomCode", "所有磅房", "");

                myip = TDService.StaticForm.ini.IniReadValue("Server", "ServerName");//获取到服务器ip地址
                timer1.Interval = 1000;
                timer1.Tick += new EventHandler(timer1_Tick);
                timer1.Enabled = true;



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "连接异常，请重新设置数据库连接");
                (new DataBaseInitial()).Show();
                this.Hide();
            }
            #endregion
        } 
        #endregion

        #region 实时执行：水泥显示，报警显示，报警信息语音报警
        /// <summary>
        /// 执行时钟事件--该事件是用来实时判断磅房名称是否有变化，并且根据变化实时替换全局变量“磅房名称”；水泥实时显示；报警信息显示；语音报警
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void timer1_Tick(object sender, EventArgs e)
        {
            #region 实时判断磅房名称
            if (tscbRoom.ComboBox.Text == "所有磅房")
            {
                strRoomName = "";
            }
            else
            {
                strRoomName = tscbRoom.ComboBox.Text.Trim();
            }
            #endregion

            string stat = GetCmdPingResult(myip);//获取到网络状态
            if (stat == "1")
            {
                toolStripStatusLabel2.Text = "网络连接正常";
                toolStripStatusLabel3.Text = " ----- 服务器IP地址为:" + myip;

                #region 水泥实时显示
                try
                {
                    string sql = " select Top 10 RoomName,NavicertCode,MarkedCardCode,CoalKindName,CarNo,LoadWeight,NetWeight,EmptyWeight ,TaxAmount,WeightTime";
                    sql += " from VT_LoadWeight";
                    sql += " where RoomName like '%" + strRoomName + "%' and WeightTime>='" + Convert.ToDateTime(DateTime.Now).ToShortDateString() + " 00:00:00.000' and WeightTime<='" + Convert.ToDateTime(DateTime.Now).ToShortDateString() + " 23:59:59.999'";
                    sql += "order by WeightTime desc";
                    DataSet dstWeightBang = SqlHelper.ExecuteDataSet(SqlHelper.ConnectionStringLocalTransaction, sql);
                    dgvWeightBang.DataSource = dstWeightBang.Tables[0];
                    int i4 = 1;
                    foreach (DataGridViewRow dgvr in dgvWeightBang.Rows)
                    {
                        if (i4 % 2 == 0)
                        {
                            dgvr.DefaultCellStyle.BackColor = Color.Gainsboro;
                        }
                        ////////////ADD 20090319 START ZHANGZG 新的重磅过磅记录以不同的颜色显示
                        DateTime dt = Convert.ToDateTime(dgvr.Cells[9].Value);
                        string[] dateDiff = this.DateDiff(dt, Convert.ToDateTime(SqlHelper.Executegetsqltime(TDService.Data.SqlHelper.ConnectionStringLocalTransaction)));
                        if (dateDiff[0] == "0" && dateDiff[1] == "0" && dateDiff[2] == "0")
                        {
                            if (Convert.ToInt32(dateDiff[3]) <= 50)
                            {
                                dgvr.DefaultCellStyle.BackColor = Color.SkyBlue;
                            }
                        }
                        ////////////ADD 20090319 ZHANGZG END
                        i4++;
                    }

                    #region 下面统计显示信息
                    #region 所有信息统计
                    string strColumnsMT = " count(*) as 'MTWeightSUM' ,sum(NetWeight) as 'MTCarNetWeightSUM'";
                    string strTableNameMT = " TT_LoadWeight a inner join TT_Room b on a.RoomCode=b.RoomCode ";
                    string strWhereMT = " WeightTime>='" + Convert.ToDateTime(DateTime.Now).ToShortDateString() + " 00:00:00.000' and WeightTime<='" + Convert.ToDateTime(DateTime.Now).ToShortDateString() + " 23:59:59.999' and b.RoomName like '%" + strRoomName + "%'";
                    string strOrderByMT = " ";
                    DataSet dstWeightBangMT = GetNewSelectProcedure(strColumnsMT, strTableNameMT, strWhereMT, strOrderByMT);
                    this.lbWeightBangMTSUM.Text = dstWeightBangMT.Tables[0].Rows[0][0].ToString() + " 条";
                    this.lbCarNetWeightMTSUM.Text = dstWeightBangMT.Tables[0].Rows[0][1].ToString() + " 吨"; 
                    #endregion

                    #region 水泥信息统计
                    string strShuiNiTongJi = " count(*) as 'MTWeightSUM' ,sum(NetWeight) as 'MTCarNetWeightSUM'";
                    string strTableNameShuiNi = " TT_LoadWeight a inner join TT_Room b on a.RoomCode=b.RoomCode ";
                    string strWhereShuiNi = " WeightTime>='" + Convert.ToDateTime(DateTime.Now).ToShortDateString() + " 00:00:00.000' and WeightTime<='" + Convert.ToDateTime(DateTime.Now).ToShortDateString() + " 23:59:59.999' and b.RoomName like '%" + strRoomName + "%' and a.CoalKindName not in('石渣','0.5米石','熟料')";
                    string strOrderByShuiNi = " ";
                    DataSet dstWeightBangShuiNi = GetNewSelectProcedure(strShuiNiTongJi, strTableNameShuiNi, strWhereShuiNi, strOrderByShuiNi);
                    this.LabShuiNiSum.Text = dstWeightBangShuiNi.Tables[0].Rows[0][0].ToString() + " 条";
                    this.labShuiNiWeight.Text = dstWeightBangShuiNi.Tables[0].Rows[0][1].ToString() + " 吨";  
                    #endregion

                    #region 熟料信息统计
                    string strShuLiaoTongJi = " count(*) as 'MTWeightSUM' ,sum(NetWeight) as 'MTCarNetWeightSUM'";
                    string strTableNameShuLiao = " TT_LoadWeight a inner join TT_Room b on a.RoomCode=b.RoomCode ";
                    string strWhereShuLiao = " WeightTime>='" + Convert.ToDateTime(DateTime.Now).ToShortDateString() + " 00:00:00.000' and WeightTime<='" + Convert.ToDateTime(DateTime.Now).ToShortDateString() + " 23:59:59.999' and b.RoomName like '%" + strRoomName + "%' and a.CoalKindName in('熟料')";
                    string strOrderByShuLiao = " ";
                    DataSet dstWeightBangShuLiao = GetNewSelectProcedure(strShuLiaoTongJi, strTableNameShuLiao, strWhereShuLiao, strOrderByShuLiao);
                    this.lblShuLiaoSUM.Text = dstWeightBangShuLiao.Tables[0].Rows[0][0].ToString() + " 条";
                    this.lblShuLiaoWeight.Text = dstWeightBangShuLiao.Tables[0].Rows[0][1].ToString() + " 吨";
                    #endregion

                    #region 石渣信息统计
                    string strShiZhaTongJi = " count(*) as 'MTWeightSUM' ,sum(NetWeight) as 'MTCarNetWeightSUM',sum(TaxAmount) as 'TaxAmountSUM'";
                    string strTableNameShiZha = " TT_LoadWeight a inner join TT_Room b on a.RoomCode=b.RoomCode ";
                    string strWhereShiZha = " WeightTime>='" + Convert.ToDateTime(DateTime.Now).ToShortDateString() + " 00:00:00.000' and WeightTime<='" + Convert.ToDateTime(DateTime.Now).ToShortDateString() + " 23:59:59.999' and b.RoomName like '%" + strRoomName + "%' and a.CoalKindName in('石渣')";
                    string strOrderByShiZha = " ";
                    DataSet dstWeightBangShiZha = GetNewSelectProcedure(strShiZhaTongJi, strTableNameShiZha, strWhereShiZha, strOrderByShiZha);
                    this.lblShiZhaSUM.Text = dstWeightBangShiZha.Tables[0].Rows[0][0].ToString() + " 条";
                    this.lblShiZhaWeight.Text = dstWeightBangShiZha.Tables[0].Rows[0][1].ToString() + " 吨";
                    this.labelshizhashifei.Text = dstWeightBangShiZha.Tables[0].Rows[0][2].ToString() + " 元";//labelzongshuifei
                    this.labelzongshuifei.Text = dstWeightBangShiZha.Tables[0].Rows[0][2].ToString() + " 元";
                    #endregion

                    #region 0.5米石信息统计
                    //string strMiShiTongJi = " count(*) as 'MTWeightSUM' ,sum(NetWeight) as 'MTCarNetWeightSUM'";
                    //string strTableNameMiShi = " TT_LoadWeight a inner join TT_Room b on a.RoomCode=b.RoomCode ";
                    //string strWhereMiShi = " WeightTime>='" + Convert.ToDateTime(DateTime.Now).ToShortDateString() + " 00:00:00.000' and WeightTime<='" + Convert.ToDateTime(DateTime.Now).ToShortDateString() + " 23:59:59.999' and b.RoomName like '%" + strRoomName + "%' and a.CoalKindName in('0.5米石')";
                    //string strOrderByMiShi = " ";
                    //DataSet dstWeightBangMiShi = GetNewSelectProcedure(strMiShiTongJi, strTableNameMiShi, strWhereMiShi, strOrderByMiShi);
                    //this.lblMiShiSUM.Text = dstWeightBangMiShi.Tables[0].Rows[0][0].ToString() + " 条";
                    //this.lblMiShiWeight.Text = dstWeightBangMiShi.Tables[0].Rows[0][1].ToString() + " 吨";
                    #endregion

                    #endregion
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("煤炭实时显示： " + ex.Message);
                }
                #endregion

                #region 报警信息实时显示
                string sql2 = " Select top 10 RecordID,RoomName,Decript,BreakDate  ";
                sql2 += " from VT_BadRecord  ";
                //sql2 += " where RoomName like '%" + strRoomName + "%' and BreakDate>='" + Convert.ToDateTime(DateTime.Now).ToShortDateString() + " 00:00:00.000' and BreakDate<='" + Convert.ToDateTime(DateTime.Now).ToShortDateString() + " 23:59:59.999'";
                //sql2 += " where  BreakDate>='" + Convert.ToDateTime(DateTime.Now).ToShortDateString() + " 00:00:00.000' and BreakDate<='" + Convert.ToDateTime(DateTime.Now).ToShortDateString() + " 23:59:59.999'";//原有sql语句
                sql2 += " where  BreakDate>='" + Convert.ToDateTime(DateTime.Now).ToShortDateString() + " 00:00:00.000' and BreakDate<='" + Convert.ToDateTime(DateTime.Now).ToShortDateString() + " 23:59:59.999' and AlarmType!='冲关'";//根据王谦要求取消冲关数据显示
                sql2 += "order by BreakDate desc";

                DataSet dstAlarm = SqlHelper.ExecuteDataSet(SqlHelper.ConnectionStringLocalTransaction, sql2);
                //DataSet dstAlarm = GetNewAlarmData(SqlHelper.ConnectionStringLocalTransaction);
                dgvAlarm.DataSource = dstAlarm.Tables[0];
                #endregion

                #region 语音报警信息
                //语音报警
                try
                {
                    if (dstAlarm.Tables[0].Rows.Count > 0)
                    {
                        if (dstAlarm.Tables[0].Rows[0]["RecordID"].ToString() != strRecordID)//判断是不是上次已经报过
                        {
                            strRecordID = dstAlarm.Tables[0].Rows[0]["RecordID"].ToString();
                            Say(dstAlarm.Tables[0].Rows[0]["RoomName"].ToString() + dstAlarm.Tables[0].Rows[0]["Decript"].ToString());
                        }
                    }

                }
                catch
                { }
                #endregion

            }
            else
            {
                toolStripStatusLabel2.Text = "网络连接断开";
            }
        } 
        #endregion

        #region 获取报警信息列表--已经不用了（old）
        /// <summary>
        /// 获取报警信息列表--已经不用了（old）
        /// </summary>
        /// <param name="ConString">数据库连接字符串</param>
        /// <returns></returns>
        private DataSet GetNewAlarmData(string ConString)
        {
            string strAWhere = " bangRoom like '%" + strRoomName + "%' AND datediff(mi,AlarmTime,getdate()) < 60 ";

            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("@SelectWhere",SqlDbType.NVarChar),
            };
            parameter[0].Value = strAWhere;

            DataSet dst = new DataSet();
            try
            {
                //////////////先注释掉，生成时把注释去掉 20090319 
                dst = TDService.Data.SqlHelper.ExecuteDataSet(ConString
                                                                   , CommandType.StoredProcedure, "P_AlarmLogSel", parameter);

                string strSql = "Select TOP 10 * from TDY_Alarm where (AlarmState is null or AlarmState=0) and datediff(mi,AlarmTime,getdate()) < 30 order by AlarmTime desc";

                DataSet dstAlarm = new DataSet();
                try
                {
                    dstAlarm = TDService.Data.SqlHelper.ExecuteDataSet(ConString, CommandType.Text, strSql, null);
                }
                catch (Exception ex)
                {
                }
                if (dstAlarm.Tables.Count > 0)
                {
                    if (dstAlarm.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in dstAlarm.Tables[0].Rows)
                        {
                            string strAlarmCode = dr["AlarmCode"].ToString().Trim();
                            string strtemp = dr["AlarmState"].ToString();
                            if (strtemp != "1")
                            {
                                string strAlarmText = dr["BangRoom"].ToString() + "," + dr["Remark"].ToString();
                                Say(strAlarmText.Replace("磅房", ""));
                                strSumAlarmText = strAlarmText.Replace("磅房", "");
                                //string strInsertSql = "Insert into TDY_AlarmList(AlarmContent) Values('" + strSumAlarmText + "')";
                                //int iInsert = TDService.Data.SqlHelper.ExecuteNonQuery(TDService.Data.SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strInsertSql, null);
                                string strAlarmW = " AlarmState='1' where AlarmCode='" + strAlarmCode + "'";

                                SqlParameter[] AlarmParameter = new SqlParameter[]
                                {
                                    new SqlParameter("@SelectWhere",SqlDbType.NVarChar),
                                };
                                AlarmParameter[0].Value = strAlarmW;
                                DataSet dstAlarms = TDService.Data.SqlHelper.ExecuteDataSet(ConString, CommandType.StoredProcedure, "P_AlarmLogStat", AlarmParameter);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }

            return dst;
        } 
        #endregion

        #region 被调用--获取磅房选择后的重车过磅信息，统计
        /// <summary>
        /// 被调用--获取磅房选择后的重车过磅信息，统计
        /// </summary>
        /// <param name="strColumns">要查询的字段</param>
        /// <param name="strTableName">表明</param>
        /// <param name="strWhere">条件</param>
        /// <param name="strOrderBy">排序字段</param>
        /// <returns></returns>
        private DataSet GetNewSelectProcedure(string strColumns, string strTableName, string strWhere, string strOrderBy)
        {
            DataSet dst = new DataSet();
            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("@ColumnsName",SqlDbType.NVarChar),
                new SqlParameter("@TableName",SqlDbType.NVarChar),
                new SqlParameter("@QueryCondition",SqlDbType.NVarChar),
                new SqlParameter("@Taxis",SqlDbType.NVarChar),
            };
            parameter[0].Value = strColumns;
            parameter[1].Value = strTableName;
            parameter[2].Value = strWhere;
            parameter[3].Value = strOrderBy;
            try
            {
                dst = TDService.Data.SqlHelper.ExecuteDataSet(TDService.Data.SqlHelper.ConnectionStringLocalTransaction
                                                                   , CommandType.StoredProcedure, "P_CurrencyProcedure", parameter);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dst;
        } 
        #endregion

        #region 暂时不用了
        /// <summary>
        /// 查询坩土近10条记录
        /// </summary>
        /// <param name="strColumns"></param>
        /// <param name="strTableName"></param>
        /// <param name="strWhere"></param>
        /// <param name="strOrderBy"></param>
        /// <returns></returns>
        private DataSet GetNewSelectProcedureGT(string strColumns, string strTableName, string strWhere, string strOrderBy)
        {
            DataSet dst = new DataSet();
            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("@ColumnsName",SqlDbType.NVarChar),
                new SqlParameter("@TableName",SqlDbType.NVarChar),
                new SqlParameter("@QueryCondition",SqlDbType.NVarChar),
                new SqlParameter("@Taxis",SqlDbType.NVarChar),
            };
            parameter[0].Value = strColumns;
            parameter[1].Value = strTableName;
            parameter[2].Value = strWhere;
            parameter[3].Value = strOrderBy;
            try
            {
                dst = TDService.Data.SqlHelper.ExecuteDataSet(TDService.Data.SqlHelper.ConnectionStringGT
                                                                   , CommandType.StoredProcedure, "P_CurrencyProcedure", parameter);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dst;
        } 
        #endregion

        #region 被调用-返回时间间隔
        /// <summary>
        /// 被调用-返回时间间隔
        /// </summary>
        /// <param name="DateTime1"></param>
        /// <param name="DateTime2"></param>
        /// <returns></returns>
        private string[] DateDiff(DateTime DateTime1, DateTime DateTime2)
        {

            TimeSpan ts1 = new TimeSpan(DateTime1.Ticks);
            TimeSpan ts2 = new TimeSpan(DateTime2.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();
            string[] dateDiff = new string[] { ts.Days.ToString(), ts.Hours.ToString(), ts.Minutes.ToString(), ts.Seconds.ToString() };

            return dateDiff;
        } 
        #endregion

        #region 菜单事件--暂时不用了
        private void 连接客服机ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loading = null;

            loading = new Loading();

            loading.FormName = "onlinestat";

            loading.ShowDialog();

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            loading = null;

            loading = new Loading();

            loading.FormName = "onlinestat";

            loading.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            loading = null;

            loading = new Loading();

            loading.FormName = "alarmlog";

            loading.ShowDialog();
            //(new AlarmLog()).ShowDialog();
        }

        private void 退出系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 查看报警日志ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loading = null;

            loading = new Loading();

            loading.FormName = "alarmlog";

            loading.ShowDialog();
            //(new AlarmLog()).ShowDialog();
        }

        private void 查看过磅日志ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loading = null;

            loading = new Loading();

            loading.FormName = "banglog";

            loading.ShowDialog();
            //(new BangLog()).ShowDialog();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            loading = null;

            loading = new Loading();

            loading.FormName = "banglog";

            loading.ShowDialog();
            //(new BangLog()).ShowDialog();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            loading = null;

            loading = new Loading();

            loading.FormName = "database";

            loading.ShowDialog();
            //(new DataBaseInitial()).ShowDialog();
        }
        private void 退出系统ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("网络无法连接到服务器，请退出系统重新登陆！", "天大天科调运系统");

            Application.Exit();
        }
        private void 显示主界面ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowInTaskbar = true;
            this.Show();
        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //loading = null;

            //loading = new Loading();

            //loading.FormName = "database";

            //loading.ShowDialog();
            //(new DataBaseInitial()).ShowDialog();
            new DataBaseInitial().ShowDialog();
        }

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();

            Application.Exit();
        }

        private void 客服机状态ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loading = null;

            loading = new Loading();

            loading.FormName = "onlinestat";

            loading.ShowDialog();
        }

        private void 数据库设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loading = null;

            loading = new Loading();

            loading.FormName = "database";

            loading.ShowDialog();
        }

        private void 报警日志ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loading = null;

            loading = new Loading();

            loading.FormName = "alarmlog";

            loading.ShowDialog();
        }

        private void 过磅日志ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loading = null;

            loading = new Loading();

            loading.FormName = "banglog";

            loading.ShowDialog();
        }

        private void tsmiEmptyBangSel_Click(object sender, EventArgs e)
        {
            loading = null;

            loading = new Loading();

            loading.FormName = "EmptyBangSel";

            loading.ShowDialog();
        }

        private void tsmiWeightBangSel_Click(object sender, EventArgs e)
        {
            //loading = null;

            //loading = new Loading();

            //loading.FormName = "FM_WeightBangSearch";

            //loading.ShowDialog();
            new FM_WeightBangSearch().ShowDialog();
        }
        #endregion

        /// <summary>
        /// 磅房选择后调用实时显示代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tscbRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            //timer2_Tick(sender, e);
            timer1_Tick(sender, e);
        }

        #region 暂时不用了
        private void tscbRoomGT_SelectedIndexChanged(object sender, EventArgs e)
        {
            //timer3_Tick(sender, e);
            timer1_Tick(sender, e);
        } 
        #endregion

       
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
            string strTemp = stat;

            string strSql = "Update TDY_Room Set OnlineState='" + strTemp + "' where RoomName='" + bangname + "'";
            int intUpdate = TDService.Data.SqlHelper.ExecuteNonQuery(TDService.Data.SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql, null);
            if (intUpdate > 0)
            {
                string strT = "更新成功！";
            }
        } 

        #region 根据IP判断是否ping不通
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
            string strRst = p.StandardOutput.ReadToEnd();//获取查询到的数据结果字符串
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
        #endregion

        #region 被调用方法--语音读取文字
        /// <summary>
        /// 被调用方法--语音读取文字
        /// </summary>
        /// <param name="text"></param>
        public void Say(string text)
        {
            PlaySpeek speek = new PlaySpeek();

            speek.sp = new SpeekTextCallBack(SpeekText);
            speek.SpeekText = text;

            thread = new System.Threading.Thread(new System.Threading.ThreadStart(speek.DoThread));

            thread.Start();
        } 
        #endregion

        #region 语音报警延迟线程
        /// <summary>
        /// 语音报警延迟线程
        /// </summary>
        /// <param name="text"></param>
        void SpeekText(string text)
        {
            SpeechLib.SpeechVoiceSpeakFlags SpFlags =

            SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync;

            SpeechLib.SpVoice Voice = new SpeechLib.SpVoice();


            try
            {
                Voice.Speak(text, SpFlags);
            }
            catch (Exception)
            {
                //报警
                //Voice.Speak("对不起语音系统发生故障", SpFlags);
                //MessageBox.Show(e.Message.ToString(),"提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }

            thread.Join(5000);//阻塞线程5秒
        } 
        #endregion

        private void 文字报警信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        #region 暂时不用了
        private void banglock(string start, string roomname)
        {
            if (start == "1")
            {
                string sql = "update TDY_Room set roomstart='1' where roomname like '%" + roomname + "%'";
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, sql);
            }
            else
            {
                string sql = "update TDY_Room set roomstart='0' where roomname like '%" + roomname + "%'";
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, sql);
            }
        } 
        #endregion


        #region 暂时不用了
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new SetIP().ShowDialog();
        }

        private void tsmiUpBangData_Click(object sender, EventArgs e)
        {

        }

        private void tsmiWeightBangSelGT_Click(object sender, EventArgs e)
        {
            //loading = null;

            //loading = new Loading();

            //loading.FormName = "FM_GTWeightBangSearch";

            //loading.ShowDialog();

            new FM_GTWeightBangSearch().ShowDialog();

        } 
        #endregion


        #region 水泥报警信息查询
        private void 煤炭报警信息查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AlarmSelect("MM").ShowDialog();
        } 
        #endregion

        #region 暂时用了
        private void 坩土报警信息查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AlarmSelect("GT").ShowDialog();
        } 
        #endregion

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Close();
            Application.Exit();
        }


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
    /// <summary>
    /// 语音相关类
    /// </summary>
    class PlaySpeek
    {
        public SpeekTextCallBack sp;
        public ThreadSpeekText ts;
        public string SpeekText = "";
        public string strPingIP = "";
        /// <summary>
        /// ping网络
        /// </summary>
        public string PingThread()
        {
            string strTemp = ts(strPingIP);
            return strTemp;
        }

        /// <summary>
        /// 语音提示
        /// </summary>
        public void DoThread()
        {
            sp(SpeekText);
        }

    }
}