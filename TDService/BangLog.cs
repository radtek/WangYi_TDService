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
    public partial class BangLog : Form
    {
        public BangLog()
        {
            InitializeComponent();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            string strWhere = " 1=1";

            if (this.txbNavicert.Text != "")
                strWhere += " and CardCode like '%" + this.txbNavicert.Text.Trim().Replace("'", "''") + "%'";

            if (this.dtpBegin.Text != "")
                strWhere += " and  LogTime >='" + Convert.ToDateTime(this.dtpBegin.Text).ToShortDateString() + " 00:00:00" + "'";
            if (this.dtpEnd.Text != "")
                strWhere += " and LogTime<='" + Convert.ToDateTime(this.dtpEnd.Text).ToShortDateString() + " 23:59:59" + "'";
            //SqlParameter[] parameter = new SqlParameter[]
            //{
            //    new SqlParameter("@SelectWhere",SqlDbType.NVarChar),
            //};
            //parameter[0].Value = strWhere;
            strWhere = "select *from TDY_LogManualBang where " + strWhere;

            //ZGHT.DataAccess.IDataAccess objDa = _base.getObj;

            //DataSet ds = objDa.ExecuteDataset(strWhere);

            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    this.dgvWeightBang.DataSource = ds.Tables[0];
            //}
            DataSet dst = TDService.Data.SqlHelper.ExecuteDataSet(TDService.Data.SqlHelper.ConnectionStringLocalTransaction
                                                             , CommandType.Text, strWhere, null);
         
            //DataSet dst = BaseLogic.BaseConnection.RunProcedure("P_BangLogSel", parameter, "BangLogSel");
            this.dgvWeightBang.DataSource = dst.Tables[0];
            //this.dgvWeightBang.DataSource = bas.ExecCurrencyProcedure("P_CurrencyProcedure", strTempColumn, "VDY_WeightBang", strWhere, "");
            //this.dgvWeightBang.DataSource = bas.getDataTable("select  from VDY_WeightBang  where " + strWhere);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txbNavicert.Text = "";
            this.dtpBegin.Value = Convert.ToDateTime(System.DateTime.Now.ToShortDateString() + " 00:00:00");
            this.dtpEnd.Value = Convert.ToDateTime(System.DateTime.Now.ToShortDateString() + " 23:59:59");

        }

   
    }
}