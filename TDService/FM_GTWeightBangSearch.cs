using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using TDService.Data;

namespace TDService
{
    public partial class FM_GTWeightBangSearch : Form
    {
        public FM_GTWeightBangSearch()
        {
            InitializeComponent();
            loadComBox();
        }
        void loadComBox()
        {
            SqlHelper.ComboxBindGT(cmbRoomGT, "TDY_Room", "RoomName", "RoomCode", "IsForbid='0'", "RoomCode", "所有磅房", "");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.txbCarNoGT.Text = "";
            this.txtNavicertGT.Text = "";
            this.txtWeightCodeGT.Text = "";
            this.cmbRoomGT.SelectedValue = "";
            this.dtpBeginGT.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strWhere = " 1=1";
            if (this.txbCarNoGT.Text.Trim() != "")
            {
                strWhere += " and CarBrandNumber like '%" + this.txbCarNoGT.Text.Trim().Replace("'", "''") + "%'";
            }
            if (this.txtNavicertGT.Text.Trim() != "")
                strWhere += " and NavicertID like '%" + this.txtNavicertGT.Text.Trim().Replace("'", "''") + "%'";
            if (this.txtWeightCodeGT.Text.Trim() != "")
                strWhere += " and WeightBangCode like '%" + this.txtWeightCodeGT.Text.Trim().Replace("'", "''") + "%'";
            if (cmbRoomGT.SelectedValue.ToString().Trim() != "")
                strWhere += " and RoomCode = '" + this.cmbRoomGT.SelectedValue.ToString() + "'";
            if (this.dtpBeginGT.Text.Trim() != "")
            {
                strWhere += " and  BangTime >='" + Convert.ToDateTime(this.dtpBeginGT.Text).ToShortDateString() + " 00:00:00.000" + "'";
                strWhere += " and BangTime<='" + Convert.ToDateTime(this.dtpBeginGT.Text).ToShortDateString() + " 23:59:59.999" + "'";
            }
            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("@QueryCondition",SqlDbType.NVarChar),
            };
            parameter[0].Value = strWhere;
            DataSet dst = TDService.Data.SqlHelper.ExecuteDataSet(TDService.Data.SqlHelper.ConnectionStringGT
                                                               , CommandType.StoredProcedure, "P_WeightBing", parameter);
            this.DGVWeightBangGT.DataSource = dst.Tables[0];
        }
    }
}