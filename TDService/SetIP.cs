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
    public partial class SetIP : Form
    {
     
        public SetIP()
        {
            InitializeComponent();
        }

        private void SetIP_Load(object sender, EventArgs e)
        {
            SqlHelper.ComboxBind(comboBox1, "TT_Room", "RoomName", "RoomCode", "IsForbid='0'", "RoomCode", "���а���", "");
        }
 
        private void button1_Click(object sender, EventArgs e)
        {
            String YiBiao_State;
            YiBiao_State = "1";
            if (radioButton1.Checked == true)
            {
                YiBiao_State = "1";
            }
            if (radioButton2.Checked == true)
            {
                YiBiao_State = "0";
            }
            if (radioButton3.Checked == true)
            {
                YiBiao_State = "2";
            }

            string strSql;
            string strSelect = "Select IP from TT_Room where RoomCode='" + comboBox1.SelectedValue + "'";
            DataSet dst = TDService.Data.SqlHelper.ExecuteDataSet(TDService.Data.SqlHelper.ConnectionStringLocalTransaction
                                                             , CommandType.Text, strSelect, null);
            strSql = "Update TT_Room set  YiBiao_State='" + YiBiao_State + "'  where RoomCode='" + comboBox1.SelectedValue + "'";
            
             
            int strUpdateStat = TDService.Data.SqlHelper.ExecuteNonQuery(TDService.Data.SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql, null);


            if (strUpdateStat > 0)
            {
                MessageBox.Show( "���óɹ�", "�����Ƶ���ϵͳ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(  "����ʧ�ܣ������ȷѡ�����", "�����Ƶ���ϵͳ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
             
            this.DialogResult = DialogResult.OK;
            
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //if (checkStat > 0)
            //{
            //    try
            //    {
            //        string strConn = "Data Source=" + TDService.StaticForm.ini.IniReadValue(bangfang, "IP") + ";Initial Catalog=MTTraffic;User ID=sa;Password=tdtkadmin";
            //        if (checkBox1.Checked)
            //        {
            //            string strSql = "Update TDY_Room set OMStat='0' where IP='" + TDService.StaticForm.ini.IniReadValue(bangfang, "IP") + "'";
            //            int strUpdateStat = TDService.Data.SqlHelper.ExecuteNonQuery(TDService.Data.SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql, null);
            //            int strClientUpdateStat = TDService.Data.SqlHelper.ExecuteNonQuery(strConn, CommandType.Text, strSql, null);

            //            if (strUpdateStat > 0 && strClientUpdateStat > 0)
            //            {
            //                TDService.StaticForm.ini.IniWriteValue(bangfang, "BiaoStatus", "1");

            //                MessageBox.Show(bangfang + "�Ǳ��Ѿ��ɹ��ر�", "�����Ƶ���ϵͳ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            }
            //            else
            //            {
            //                MessageBox.Show(bangfang + "�Ǳ��Ѿ��ر�ʧ�ܣ�����IP��ַ�Ƿ���ȷ", "�����Ƶ���ϵͳ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //            }
            //        }
            //        else
            //        {
            //            string strSql = "Update TDY_Room set OMStat='1' where IP='" + TDService.StaticForm.ini.IniReadValue(bangfang, "IP") + "'";

            //            int strUpdateStat = TDService.Data.SqlHelper.ExecuteNonQuery(TDService.Data.SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql, null);
            //            int strClientUpdateStat = TDService.Data.SqlHelper.ExecuteNonQuery(strConn, CommandType.Text, strSql, null);


            //            if (strUpdateStat > 0 && strClientUpdateStat > 0)
            //            {
            //                TDService.StaticForm.ini.IniWriteValue(bangfang, "BiaoStatus", "0");

            //                MessageBox.Show(bangfang + "�Ǳ��Ѿ��ɹ���", "�����Ƶ���ϵͳ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            }
            //            else
            //            {
            //                MessageBox.Show(bangfang + "�Ǳ��Ѿ���ʧ�ܣ�����IP��ַ�Ƿ���ȷ", "�����Ƶ���ϵͳ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //            }
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("�������������Ƿ�����");
            //    }
            //}
            //else
            //{
            //    checkStat++;
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
             
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
        }
    }
}