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
        /// <param name="SystemState">如果是MM即是煤炭，GT是坩土</param>
        public AlarmSelect(string SystemState)
        {
            InitializeComponent();
            strSystrm = SystemState;
        }

        private void AlarmSelect_Load(object sender, EventArgs e)
        {
            if (strSystrm == "MM")
            {
                this.Text = "报警信息查询";
                strCon = SqlHelper.ConnectionStringLocalTransaction;
                SqlHelper.ComboxBind(cmbRoom, "TT_Room", "RoomName", "RoomName", "IsForbid='0'", "RoomCode", "所有磅房", "");
            }
            else if (strSystrm == "GT")
            {
                this.Text = "坩土报警信息查询";
                strCon = SqlHelper.ConnectionStringGT;
                SqlHelper.ComboxBindGT(cmbRoom, "TDY_Room", "RoomName", "RoomName", "IsForbid='0'", "RoomCode", "所有磅房", "");
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            string strSql = "Select RoomName,Decript,BreakDate from VT_BadRecord where BreakDate>='" + dtpBegin.Text.Replace("年", "-").Replace("月", "-").Replace("日", " ") + "' and BreakDate<='" + dtpEnd.Text.Replace("年", "-").Replace("月", "-").Replace("日", " 23:59:59.999") + "' ";
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