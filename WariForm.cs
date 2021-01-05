using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dentaku
{
    public partial class WariForm : Form
    {
        public WariForm()
        {
            InitializeComponent();
        }

        private string recv;
        public string Recv
        {
            set
            {
                recv = value;
                AmtMny.Text = recv;
            }
            get
            {
                return recv;
            }
        }

        private void AmtMny_TextChanged(object sender, EventArgs e)
        {

        }

        private void Om1cnt_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Om2cnt_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Om3cnt_ValueChanged(object sender, EventArgs e)
        {

        }

        private void stn1_Click(object sender, EventArgs e)
        {

        }

        private void CulcDo_Click(object sender, EventArgs e)
        {
            //stn1.Text = Convert.ToString(Om1cnt.Value + Om2cnt.Value + Om2cnt.Value);
            double rate1 = (double)OmR1.Value;
            double rate2 = (double)OmR2.Value;
            double rate3 = (double)OmR3.Value;

            try
            {
                double Amt = double.Parse(AmtMny.Text);
                DivCulc cul = new DivCulc();
                //人数設定
                cul.Cnt1 = (double)Om1cnt.Value;
                cul.Cnt2 = (double)Om2cnt.Value;
                cul.Cnt3 = (double)Om3cnt.Value;
                //合計金額設定
                cul.Amt = Amt;

                //比率設定
                cul.Rate1 = 1;
                cul.Rate2 = 2;
                cul.Rate3 = 3;
                stn1.Text = cul.RtrnRslt();

                cul.Rate1 = 2;
                cul.Rate2 = 3;
                cul.Rate3 = 4;
                stn2.Text = cul.RtrnRslt();

                if ((rate1 + rate2 + rate3) > 0)
                {
                    cul.Rate1 = rate1;
                    cul.Rate2 = rate2;
                    cul.Rate3 = rate3;
                    stn3.Text = cul.RtrnRslt();
                    groupBox4.Text = "③金額比率(任意設定) " + 
                                     Convert.ToString(rate1) + ":" + 
                                     Convert.ToString(rate2) + ":" + 
                                     Convert.ToString(rate3) + "=";
                }
                else
                {
                    stn3.Text = "任意比率設定なし";
                }

            }
            catch (FormatException ex)
            {
                AmtMny.Text = "金額を入力してください";
                //throw;
            }

        }

        private void stn2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }
    }

    public class DivCulc
    {
        private double rate1 = 0;
        private double rate2 = 0;
        private double rate3 = 0;

        public double Rate1
        {
            set
            {
                rate1 = value;
            }
            get
            {
                return rate1;
            }
        }
        public double Rate2
        {
            set
            {
                rate2 = value;
            }
            get
            {
                return rate2;
            }
        }
        public double Rate3
        {
            set
            {
                rate3 = value;
            }
            get
            {
                return rate3;
            }
        }

        private double cnt1 = 0;
        private double cnt2 = 0;
        private double cnt3 = 0;

        public double Cnt1
        {
            set
            {
                cnt1 = value;
            }
            get
            {
                return cnt1;
            }
        }
        public double Cnt2
        {
            set
            {
                cnt2 = value;
            }
            get
            {
                return cnt2;
            }
        }
        public double Cnt3
        {
            set
            {
                cnt3 = value;
            }
            get
            {
                return cnt3;
            }
        }

        private double amt = 0;
        public double Amt
        {
            set
            {
                amt = value;
            }
            get
            {
                return amt;
            }
        }

        public double Om1mny;
        public double Om2mny;
        public double Om3mny;
        public double NwAmt;
        public double Rem;


        public double Test()
        {
            double rslt;
            rslt = 5 * rate1;
            return rslt;
        }

        public void DivCulcDo()
        {
            //重み3の金額を基準とする
            double stnMny;
            stnMny = amt / ((rate1 / rate3) * cnt1 + (rate2 / rate3) * cnt2 + cnt3);

            //10の位で切り上げ
            Om1mny = Math.Ceiling(((rate1 / rate3) * stnMny) / 100) * 100;
            Om2mny = Math.Ceiling(((rate2 / rate3) * stnMny) / 100) * 100;
            Om3mny = Math.Ceiling(stnMny / 100) * 100;

            NwAmt = Om1mny * cnt1 + Om2mny * cnt2 + Om3mny * cnt3;
            Rem = NwAmt - amt;

        }

        public string RtrnRslt()
        {
            this.DivCulcDo();

            //返すメッセージを編集
            string Om1Msg = "優遇1：";
            string Om2Msg = "優遇2：";
            string Om3Msg = "優遇3：";
            string SumMsg = "合計：" + NwAmt.ToString("C");
            string RemMsg;

            if (Rem > 0)
            {
                RemMsg = "お釣り：" + Rem.ToString("C");
            }
            else
            {
                Rem = Math.Abs(Rem);
                RemMsg = "不足：" + Rem.ToString("C");
            }


            //優遇1
            if (1 > cnt1){ Om1mny = 0;}

            //優遇2
            if (1 > cnt2) { Om2mny = 0;}

            //優遇3
            if (1 > cnt3) { Om3mny = 0;}

            Om1Msg += Om1mny.ToString("C");
            Om2Msg += Om2mny.ToString("C");
            Om3Msg += Om3mny.ToString("C");

            //string rslt = Om1Msg + Om2Msg + Om3Msg;
            string rslt = Om1Msg + "  " + Om2Msg + "  " + Om3Msg + "\n" +
                          SumMsg + "  " + RemMsg;
            return rslt;
        }

    }
}
