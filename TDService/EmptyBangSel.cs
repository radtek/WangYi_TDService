using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using TDService.Data;
using System.IO;
using System.Data.SqlClient;

namespace CoalTraffic.Navicert
{
    public partial class EmptyBangSel : Form
    {

        private static string strEmptyCode;

        public EmptyBangSel()
        {
            InitializeComponent();
            grdEmptyBang.AutoGenerateColumns = false;

            SqlHelper.ComboxBind(cbxRoomName, "TDY_Room", "RoomName", "RoomCode", "IsForbid='0'", "RoomCode", "所有磅房", "");
            EmptySelect();
            TDService.mainForm.loading.Close();
        }

        private void txtCarModelNumber_TextChanged(object sender, EventArgs e)
        {

        }
        private void EmptySelect()
        {
            try
            {
                string OrderFieldStr = "";
                string SearchString = strwhere();
                DataTable dt = new DataTable();
                SqlParameter[] parameter = new SqlParameter[]
                {
                    new SqlParameter("@SelectWhere",SqlDbType.NVarChar,1000),
                };
                parameter[0].Value = SearchString;
                DataSet dst = SqlHelper.ExecuteDataSet(TDService.Data.SqlHelper.ConnectionStringLocalTransaction,CommandType.StoredProcedure,"P_EmptySel", parameter);
                dt = dst.Tables[0];//_base.GetCurrentData("V_TDY_EmptyBang", SearchString, OrderFieldStr);
                grdEmptyBang.DataSource = dt;

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        private void btnSel_Click(object sender, EventArgs e)
        {
            EmptySelect();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.txtCarBrandNumber.Text = "";
            this.txtCarOwnerName.Text = "";
            this.txtEmptyCode.Text = "";
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private string strwhere()
        { 
            string strWhere = "1=1";
            //过磅编号
            if (txtEmptyCode.Text != string.Empty)
            {
                strWhere = strWhere + " And EmptyCode like '%" + txtEmptyCode.Text.Trim().Replace("'", "''") + "%'";
            }  
            //车 牌 号
            if (txtCarBrandNumber.Text.Trim() != string.Empty)
            {
                strWhere = strWhere + " And CarBrandNumber like '%" + txtCarBrandNumber.Text.Trim().Replace("'", "''") + "%'";
            }
            //车   主
            if (txtCarOwnerName.Text.Trim() != string.Empty)
            {
                strWhere = strWhere + " And CarOwnerName like '%" + txtCarOwnerName.Text.Trim().Replace("'", "''") + "%'";
            }

            // 榜房编号
            if (cbxRoomName.SelectedValue.ToString() != "")
            {
                strWhere = strWhere + " And RoomCode='" + cbxRoomName.Text.ToString().Replace("'", "''") + "'";
            }

            strWhere = strWhere + " and EmptyBangTime<='" + dtp_EndTime.Value.ToShortDateString() + " 23:59:59' and EmptyBangTime>='" + dtp_StartTime.Value.ToShortDateString() + " 00:00:00'";
            //过磅时间
            //if (cbxStartTime.SelectedValue.ToString () != string.Empty)
            //{
            //    strWhere = strWhere + " And EmptyBangTime >= '" + cbxStartTime.Text.Trim().Replace("'", "''") + "'";
            //}
            //过磅时间1
            //if (cbxEndTime.SelectedValue.ToString() != string.Empty)
            //{
            //    strWhere = strWhere + " And EmptyBangTime <= '" + cbxEndTime.Text.Trim().Replace("'", "''") + "'";
            //}
            return strWhere;
        }

        private void EmptyBangSel_Load(object sender, EventArgs e)
        {

        }

    }
}