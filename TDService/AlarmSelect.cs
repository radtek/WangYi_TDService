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
    public partial class AlarmSelect : Form
    {
        static string strSystrm = "";
        static string strCon = "";
        public AlarmSelect()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="SystemState">�����MM����ú̿��GT������</param>
        public AlarmSelect(string SystemState)
        {
            InitializeComponent();
            strSystrm = SystemState;
        }

        private void AlarmSelect_Load(object sender, EventArgs e)
        {
            if (strSystrm == "MM")
            {
                this.Text = "������Ϣ��ѯ";
                strCon = SqlHelper.ConnectionStringLocalTransaction;
                SqlHelper.ComboxBind(cmbRoom, "TT_Room", "RoomName", "RoomName", "IsForbid='0'", "RoomCode", "���а���", "");
            }
            else if (strSystrm == "GT")
            {
                this.Text = "����������Ϣ��ѯ";
                strCon = SqlHelper.ConnectionStringGT;
                SqlHelper.ComboxBindGT(cmbRoom, "TDY_Room", "RoomName", "RoomName", "IsForbid='0'", "RoomCode", "���а���", "");
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            string strSql = "Select RoomName,Decript,BreakDate from VT_BadRecord where BreakDate>='" + dtpBegin.Text.Replace("��", "-").Replace("��", "-").Replace("��", " ") + "' and BreakDate<='" + dtpEnd.Text.Replace("��", "-").Replace("��", "-").Replace("��", " 23:59:59.999") + "' ";
            if (cmbRoom.SelectedValue.ToString() != "")
            {
                strSql += " and RoomName = '" + cmbRoom.SelectedValue.ToString() + "' ";
            }
            DataSet dst = SqlHelper.ExecuteDataSet(SqlHelper.ConnectionStringLocalTransaction, strSql);
            //DataSet ds = SqlHelper.ExecuteDataSet(strCon, strSql);
            dgvAlarm.DataSource = dst.Tables[0];
        }
    }
}