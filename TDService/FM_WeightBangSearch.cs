using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using TDService.Data;

//namespace CoalTraffic
namespace TDService
{
    public partial class FM_WeightBangSearch : Form
    {
        public FM_WeightBangSearch()
        {
            InitializeComponent();
            loadComBox();
        }

        void loadComBox()
        {
            SqlHelper.ComboxBind(cmbRoom, "TT_Room", "RoomName", "RoomCode", "IsForbid='0'", "RoomCode", "所有磅房", "");
            this.dgvWeightBang.AutoGenerateColumns = false;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            string strWhere = "   select *from VT_LoadWeight where 1=1";
            if (this.txbCarNo.Text.Trim() != "")
            {
                strWhere += " and CarNo like '%" + this.txbCarNo.Text.Trim().Replace("'", "''") + "%'";
            }
            if (this.txbNavicert.Text.Trim() != "")
                strWhere += " and NavicertCode like '%" + this.txbNavicert.Text.Trim().Replace("'", "''") + "%'";
            if (this.txbWeightBangCode.Text.Trim() != "")
                strWhere += " and WeightCode like '%" + this.txbWeightBangCode.Text.Trim().Replace("'", "''") + "%'";
            if (cmbRoom.SelectedValue.ToString().Trim() != "")
                strWhere += " and RoomCode = '" + this.cmbRoom.SelectedValue.ToString() + "'";
            if (this.dtpBegin.Text.Trim() != "")
            {
                strWhere += " and  WeightTime >='" + Convert.ToDateTime(this.dtpBegin.Text).ToShortDateString() + " 00:00:00.000" + "'";
                strWhere += " and WeightTime<='" + Convert.ToDateTime(this.dtpBegin.Text).ToShortDateString() + " 23:59:59.999" + "'";
            }
            DataSet dst = SqlHelper.ExecuteDataSet(SqlHelper.ConnectionStringLocalTransaction, strWhere);
                   
            this.dgvWeightBang.DataSource = dst.Tables[0];
            //this.dgvWeightBang.DataSource = bas.ExecCurrencyProcedure("P_CurrencyProcedure", strTempColumn, "VDY_WeightBang", strWhere, "");
            //this.dgvWeightBang.DataSource = bas.getDataTable("select  from VDY_WeightBang  where " + strWhere);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txbCarNo.Text = "";
            this.txbNavicert.Text = "";
            this.txbWeightBangCode.Text = "";
            this.dtpBegin.Text = "";
            this.cmbRoom.SelectedValue = "";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}