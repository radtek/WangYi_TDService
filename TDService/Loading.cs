using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CoalTraffic.Navicert;
using CoalTraffic;

namespace TDService
{
    public partial class Loading : Form
    {

        public Loading()
        {
            InitializeComponent();
        }

        Timer time2 = new Timer();

        string formName = "";

        public string FormName
        {
            set { formName = value; }
        }

        int mystat = 0;

        bool flag = true;

        delegate void PingLoadingCallback(int stat);

        private void Loading_Load(object sender, EventArgs e)
        {

            time2.Interval = 100;

            time2.Enabled = true;

            time2.Tick += new EventHandler(time2_Tick);
        }

        void PingLoading(int stat)
        {
            if (this.InvokeRequired)
            {
                PingLoadingCallback d = new PingLoadingCallback(PingLoading);
                this.Invoke(d, new object[] { stat });
            }
            else
            {
                progressBar1.Value = stat ;

                if (this.label1.Visible)
                {
                    this.label1.Visible = false;

                    this.label1.Text = "Loading.";
                    this.label1.Text = "Loading..";
                    this.label1.Text = "Loading...";
                    this.label1.Text = "Loading....";
                    this.label1.Text = "Loading.....";
                    this.label1.Text = "Loading......";
                }
                else
                {
                    this.label1.Visible = true;

                    this.label1.Text = "Loading.";
                    this.label1.Text = "Loading..";
                    this.label1.Text = "Loading...";
                    this.label1.Text = "Loading....";
                    this.label1.Text = "Loading.....";
                    this.label1.Text = "Loading......";
                }

                if (stat ==16)
                {
                    if (flag)
                    {
                        flag = false;

                        time2.Enabled = false;

                        if (formName == "onlinestat")
                        {
                            TDService.mainForm.online = new OnlinleStat();

                            TDService.mainForm.online.ShowDialog();
                        }

                        if (formName == "database")
                        {
                            (new DataBaseInitial()).ShowDialog();
                        }

                        if (formName == "alarmlog")
                        {
                            (new AlarmLog()).ShowDialog();
                        }

                        if (formName == "banglog")
                        {
                            (new BangLog()).ShowDialog();
                        }

                        if (formName == "EmptyBangSel")
                        {
                            (new EmptyBangSel()).ShowDialog();
                        }

                        if (formName == "FM_WeightBangSearch")
                        {
                            (new FM_WeightBangSearch()).ShowDialog();
                        }
                        if (formName == "SetIP")
                        {
                            (new SetIP()).ShowDialog();
                        }
                        this.Close();
                    }
                }
                
            }
           
        }

        void time2_Tick(object sender, EventArgs e)
        {
            if (mystat < 16)
            {
                mystat += 1;
            }

            PingLoading(mystat);
        }
    }
}