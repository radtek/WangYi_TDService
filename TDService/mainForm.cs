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
        public static int WeightBangtimenum = 0;/////�µ��س��������ݱ���ɫ��ʾʱ��
        System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();//�ô���ʵ����һ��ʱ�ӿؼ�
        //System.Windows.Forms.Timer timer2 = new System.Windows.Forms.Timer();
        //System.Windows.Forms.Timer timer3 = new System.Windows.Forms.Timer();
        /// <summary>
        /// ȫ�ֱ���--������
        /// </summary>
        private string strRoomName;

        //����ID
        string strRecordID = "";

        string myip = "";
        public mainForm()
        {
            InitializeComponent();
        }
        #region �������
        /// <summary>
        /// �������
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

            #region ������ص�ʱ��󶨰�����Ϣ
            try
            {

                this.skinEngine1.Active = true;
                this.skinEngine1.SkinFile = "Msn.ssk";

                TDService.Data.SqlHelper.ComboxBind(tscbRoom, "TT_Room", "RoomName", "RoomCode", "IsForbid='0'", "RoomCode", "���а���", "");

                myip = TDService.StaticForm.ini.IniReadValue("Server", "ServerName");//��ȡ��������ip��ַ
                timer1.Interval = 1000;
                timer1.Tick += new EventHandler(timer1_Tick);
                timer1.Enabled = true;



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "�����쳣���������������ݿ�����");
                (new DataBaseInitial()).Show();
                this.Hide();
            }
            #endregion
        } 
        #endregion

        #region ʵʱִ�У�ˮ����ʾ��������ʾ��������Ϣ��������
        /// <summary>
        /// ִ��ʱ���¼�--���¼�������ʵʱ�жϰ��������Ƿ��б仯�����Ҹ��ݱ仯ʵʱ�滻ȫ�ֱ������������ơ���ˮ��ʵʱ��ʾ��������Ϣ��ʾ����������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void timer1_Tick(object sender, EventArgs e)
        {
            #region ʵʱ�жϰ�������
            if (tscbRoom.ComboBox.Text == "���а���")
            {
                strRoomName = "";
            }
            else
            {
                strRoomName = tscbRoom.ComboBox.Text.Trim();
            }
            #endregion

            string stat = GetCmdPingResult(myip);//��ȡ������״̬
            if (stat == "1")
            {
                toolStripStatusLabel2.Text = "������������";
                toolStripStatusLabel3.Text = " ----- ������IP��ַΪ:" + myip;

                #region ˮ��ʵʱ��ʾ
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
                        ////////////ADD 20090319 START ZHANGZG �µ��ذ�������¼�Բ�ͬ����ɫ��ʾ
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

                    #region ����ͳ����ʾ��Ϣ
                    #region ������Ϣͳ��
                    string strColumnsMT = " count(*) as 'MTWeightSUM' ,sum(NetWeight) as 'MTCarNetWeightSUM'";
                    string strTableNameMT = " TT_LoadWeight a inner join TT_Room b on a.RoomCode=b.RoomCode ";
                    string strWhereMT = " WeightTime>='" + Convert.ToDateTime(DateTime.Now).ToShortDateString() + " 00:00:00.000' and WeightTime<='" + Convert.ToDateTime(DateTime.Now).ToShortDateString() + " 23:59:59.999' and b.RoomName like '%" + strRoomName + "%'";
                    string strOrderByMT = " ";
                    DataSet dstWeightBangMT = GetNewSelectProcedure(strColumnsMT, strTableNameMT, strWhereMT, strOrderByMT);
                    this.lbWeightBangMTSUM.Text = dstWeightBangMT.Tables[0].Rows[0][0].ToString() + " ��";
                    this.lbCarNetWeightMTSUM.Text = dstWeightBangMT.Tables[0].Rows[0][1].ToString() + " ��"; 
                    #endregion

                    #region ˮ����Ϣͳ��
                    string strShuiNiTongJi = " count(*) as 'MTWeightSUM' ,sum(NetWeight) as 'MTCarNetWeightSUM'";
                    string strTableNameShuiNi = " TT_LoadWeight a inner join TT_Room b on a.RoomCode=b.RoomCode ";
                    string strWhereShuiNi = " WeightTime>='" + Convert.ToDateTime(DateTime.Now).ToShortDateString() + " 00:00:00.000' and WeightTime<='" + Convert.ToDateTime(DateTime.Now).ToShortDateString() + " 23:59:59.999' and b.RoomName like '%" + strRoomName + "%' and a.CoalKindName not in('ʯ��','0.5��ʯ','����')";
                    string strOrderByShuiNi = " ";
                    DataSet dstWeightBangShuiNi = GetNewSelectProcedure(strShuiNiTongJi, strTableNameShuiNi, strWhereShuiNi, strOrderByShuiNi);
                    this.LabShuiNiSum.Text = dstWeightBangShuiNi.Tables[0].Rows[0][0].ToString() + " ��";
                    this.labShuiNiWeight.Text = dstWeightBangShuiNi.Tables[0].Rows[0][1].ToString() + " ��";  
                    #endregion

                    #region ������Ϣͳ��
                    string strShuLiaoTongJi = " count(*) as 'MTWeightSUM' ,sum(NetWeight) as 'MTCarNetWeightSUM'";
                    string strTableNameShuLiao = " TT_LoadWeight a inner join TT_Room b on a.RoomCode=b.RoomCode ";
                    string strWhereShuLiao = " WeightTime>='" + Convert.ToDateTime(DateTime.Now).ToShortDateString() + " 00:00:00.000' and WeightTime<='" + Convert.ToDateTime(DateTime.Now).ToShortDateString() + " 23:59:59.999' and b.RoomName like '%" + strRoomName + "%' and a.CoalKindName in('����')";
                    string strOrderByShuLiao = " ";
                    DataSet dstWeightBangShuLiao = GetNewSelectProcedure(strShuLiaoTongJi, strTableNameShuLiao, strWhereShuLiao, strOrderByShuLiao);
                    this.lblShuLiaoSUM.Text = dstWeightBangShuLiao.Tables[0].Rows[0][0].ToString() + " ��";
                    this.lblShuLiaoWeight.Text = dstWeightBangShuLiao.Tables[0].Rows[0][1].ToString() + " ��";
                    #endregion

                    #region ʯ����Ϣͳ��
                    string strShiZhaTongJi = " count(*) as 'MTWeightSUM' ,sum(NetWeight) as 'MTCarNetWeightSUM',sum(TaxAmount) as 'TaxAmountSUM'";
                    string strTableNameShiZha = " TT_LoadWeight a inner join TT_Room b on a.RoomCode=b.RoomCode ";
                    string strWhereShiZha = " WeightTime>='" + Convert.ToDateTime(DateTime.Now).ToShortDateString() + " 00:00:00.000' and WeightTime<='" + Convert.ToDateTime(DateTime.Now).ToShortDateString() + " 23:59:59.999' and b.RoomName like '%" + strRoomName + "%' and a.CoalKindName in('ʯ��')";
                    string strOrderByShiZha = " ";
                    DataSet dstWeightBangShiZha = GetNewSelectProcedure(strShiZhaTongJi, strTableNameShiZha, strWhereShiZha, strOrderByShiZha);
                    this.lblShiZhaSUM.Text = dstWeightBangShiZha.Tables[0].Rows[0][0].ToString() + " ��";
                    this.lblShiZhaWeight.Text = dstWeightBangShiZha.Tables[0].Rows[0][1].ToString() + " ��";
                    this.labelshizhashifei.Text = dstWeightBangShiZha.Tables[0].Rows[0][2].ToString() + " Ԫ";//labelzongshuifei
                    this.labelzongshuifei.Text = dstWeightBangShiZha.Tables[0].Rows[0][2].ToString() + " Ԫ";
                    #endregion

                    #region 0.5��ʯ��Ϣͳ��
                    //string strMiShiTongJi = " count(*) as 'MTWeightSUM' ,sum(NetWeight) as 'MTCarNetWeightSUM'";
                    //string strTableNameMiShi = " TT_LoadWeight a inner join TT_Room b on a.RoomCode=b.RoomCode ";
                    //string strWhereMiShi = " WeightTime>='" + Convert.ToDateTime(DateTime.Now).ToShortDateString() + " 00:00:00.000' and WeightTime<='" + Convert.ToDateTime(DateTime.Now).ToShortDateString() + " 23:59:59.999' and b.RoomName like '%" + strRoomName + "%' and a.CoalKindName in('0.5��ʯ')";
                    //string strOrderByMiShi = " ";
                    //DataSet dstWeightBangMiShi = GetNewSelectProcedure(strMiShiTongJi, strTableNameMiShi, strWhereMiShi, strOrderByMiShi);
                    //this.lblMiShiSUM.Text = dstWeightBangMiShi.Tables[0].Rows[0][0].ToString() + " ��";
                    //this.lblMiShiWeight.Text = dstWeightBangMiShi.Tables[0].Rows[0][1].ToString() + " ��";
                    #endregion

                    #endregion
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("ú̿ʵʱ��ʾ�� " + ex.Message);
                }
                #endregion

                #region ������Ϣʵʱ��ʾ
                string sql2 = " Select top 10 RecordID,RoomName,Decript,BreakDate  ";
                sql2 += " from VT_BadRecord  ";
                //sql2 += " where RoomName like '%" + strRoomName + "%' and BreakDate>='" + Convert.ToDateTime(DateTime.Now).ToShortDateString() + " 00:00:00.000' and BreakDate<='" + Convert.ToDateTime(DateTime.Now).ToShortDateString() + " 23:59:59.999'";
                //sql2 += " where  BreakDate>='" + Convert.ToDateTime(DateTime.Now).ToShortDateString() + " 00:00:00.000' and BreakDate<='" + Convert.ToDateTime(DateTime.Now).ToShortDateString() + " 23:59:59.999'";//ԭ��sql���
                sql2 += " where  BreakDate>='" + Convert.ToDateTime(DateTime.Now).ToShortDateString() + " 00:00:00.000' and BreakDate<='" + Convert.ToDateTime(DateTime.Now).ToShortDateString() + " 23:59:59.999' and AlarmType!='���'";//������ǫҪ��ȡ�����������ʾ
                sql2 += "order by BreakDate desc";

                DataSet dstAlarm = SqlHelper.ExecuteDataSet(SqlHelper.ConnectionStringLocalTransaction, sql2);
                //DataSet dstAlarm = GetNewAlarmData(SqlHelper.ConnectionStringLocalTransaction);
                dgvAlarm.DataSource = dstAlarm.Tables[0];
                #endregion

                #region ����������Ϣ
                //��������
                try
                {
                    if (dstAlarm.Tables[0].Rows.Count > 0)
                    {
                        if (dstAlarm.Tables[0].Rows[0]["RecordID"].ToString() != strRecordID)//�ж��ǲ����ϴ��Ѿ�����
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
                toolStripStatusLabel2.Text = "�������ӶϿ�";
            }
        } 
        #endregion

        #region ��ȡ������Ϣ�б�--�Ѿ������ˣ�old��
        /// <summary>
        /// ��ȡ������Ϣ�б�--�Ѿ������ˣ�old��
        /// </summary>
        /// <param name="ConString">���ݿ������ַ���</param>
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
                //////////////��ע�͵�������ʱ��ע��ȥ�� 20090319 
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
                                Say(strAlarmText.Replace("����", ""));
                                strSumAlarmText = strAlarmText.Replace("����", "");
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

        #region ������--��ȡ����ѡ�����س�������Ϣ��ͳ��
        /// <summary>
        /// ������--��ȡ����ѡ�����س�������Ϣ��ͳ��
        /// </summary>
        /// <param name="strColumns">Ҫ��ѯ���ֶ�</param>
        /// <param name="strTableName">����</param>
        /// <param name="strWhere">����</param>
        /// <param name="strOrderBy">�����ֶ�</param>
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

        #region ��ʱ������
        /// <summary>
        /// ��ѯ������10����¼
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

        #region ������-����ʱ����
        /// <summary>
        /// ������-����ʱ����
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

        #region �˵��¼�--��ʱ������
        private void ���ӿͷ���ToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void �˳�ϵͳToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void �鿴������־ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loading = null;

            loading = new Loading();

            loading.FormName = "alarmlog";

            loading.ShowDialog();
            //(new AlarmLog()).ShowDialog();
        }

        private void �鿴������־ToolStripMenuItem_Click(object sender, EventArgs e)
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
        private void �˳�ϵͳToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("�����޷����ӵ������������˳�ϵͳ���µ�½��", "�����Ƶ���ϵͳ");

            Application.Exit();
        }
        private void ��ʾ������ToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void �ͷ���״̬ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loading = null;

            loading = new Loading();

            loading.FormName = "onlinestat";

            loading.ShowDialog();
        }

        private void ���ݿ�����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loading = null;

            loading = new Loading();

            loading.FormName = "database";

            loading.ShowDialog();
        }

        private void ������־ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loading = null;

            loading = new Loading();

            loading.FormName = "alarmlog";

            loading.ShowDialog();
        }

        private void ������־ToolStripMenuItem_Click(object sender, EventArgs e)
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
        /// ����ѡ������ʵʱ��ʾ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tscbRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            //timer2_Tick(sender, e);
            timer1_Tick(sender, e);
        }

        #region ��ʱ������
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
            string strTemp = stat;

            string strSql = "Update TDY_Room Set OnlineState='" + strTemp + "' where RoomName='" + bangname + "'";
            int intUpdate = TDService.Data.SqlHelper.ExecuteNonQuery(TDService.Data.SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql, null);
            if (intUpdate > 0)
            {
                string strT = "���³ɹ���";
            }
        } 

        #region ����IP�ж��Ƿ�ping��ͨ
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
            string strRst = p.StandardOutput.ReadToEnd();//��ȡ��ѯ�������ݽ���ַ���
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
        #endregion

        #region �����÷���--������ȡ����
        /// <summary>
        /// �����÷���--������ȡ����
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

        #region ���������ӳ��߳�
        /// <summary>
        /// ���������ӳ��߳�
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
                //����
                //Voice.Speak("�Բ�������ϵͳ��������", SpFlags);
                //MessageBox.Show(e.Message.ToString(),"��ʾ",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }

            thread.Join(5000);//�����߳�5��
        } 
        #endregion

        private void ���ֱ�����ϢToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        #region ��ʱ������
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


        #region ��ʱ������
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


        #region ˮ�౨����Ϣ��ѯ
        private void ú̿������Ϣ��ѯToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AlarmSelect("MM").ShowDialog();
        } 
        #endregion

        #region ��ʱ����
        private void ����������Ϣ��ѯToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AlarmSelect("GT").ShowDialog();
        } 
        #endregion

        private void �˳�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Close();
            Application.Exit();
        }


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
    /// <summary>
    /// ���������
    /// </summary>
    class PlaySpeek
    {
        public SpeekTextCallBack sp;
        public ThreadSpeekText ts;
        public string SpeekText = "";
        public string strPingIP = "";
        /// <summary>
        /// ping����
        /// </summary>
        public string PingThread()
        {
            string strTemp = ts(strPingIP);
            return strTemp;
        }

        /// <summary>
        /// ������ʾ
        /// </summary>
        public void DoThread()
        {
            sp(SpeekText);
        }

    }
}