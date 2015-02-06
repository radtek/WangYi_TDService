using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TDService
{
    public partial class AlarmLog : Form
    {
        public AlarmLog()
        {
            InitializeComponent();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            string strWhere = " 1=1";

            if (this.dtpBegin.Text != "")
                strWhere += " and  AlarmTime >='" + Convert.ToDateTime(this.dtpBegin.Text).ToShortDateString() + " 00:00:00" + "'";
            if (this.dtpEnd.Text != "")
                strWhere += " and AlarmTime<='" + Convert.ToDateTime(this.dtpEnd.Text).ToShortDateString() + " 23:59:59" + "'";
            if (cbColl.SelectedValue != "")
            {
                strWhere += " and BangRoom='" + cbColl.Text + "'";
            }
            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("@SelectWhere",SqlDbType.NVarChar),
            };
            parameter[0].Value = strWhere;
            //DataSet dst = BaseLogic.BaseConnection.RunProcedure("P_AlarmLogSel", parameter, "AlarmLogSel");

            DataSet dst = TDService.Data.SqlHelper.ExecuteDataSet(TDService.Data.SqlHelper.ConnectionStringLocalTransaction
                                                               , CommandType.StoredProcedure, "P_AlarmLogSel1", parameter);
            //this.dgvWeightBang.DataSource = dst.Tables["AlarmLogSel"];

            //strWhere = "select *from TDY_Alarm where " + strWhere;

            //ZGHT.DataAccess.IDataAccess objDa = _base.getObj;

            //DataSet ds = objDa.ExecuteDataset(strWhere);


            this.dataGridView1.DataSource = dst.Tables[0];

            lblCount.Text = "查询到的总记录条数是：" + dataGridView1.Rows.Count.ToString() + " 条";
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.dtpBegin.Value = Convert.ToDateTime(System.DateTime.Now.ToShortDateString() + " 00:00:00");
            this.dtpEnd.Value = Convert.ToDateTime(System.DateTime.Now.ToShortDateString() + " 23:59:59");
        }

        private void AlarmLog_Load(object sender, EventArgs e)
        {
            TDService.Data.SqlHelper.ComboxBind(cbColl, "TDY_Room", "RoomName", "RoomCode", "IsForbid='0'", "RoomCode", "所有磅房", "");
        }
    }
}