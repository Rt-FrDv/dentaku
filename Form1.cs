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
    public partial class Form1 : Form
    {
        double In_val = 0;
        double In_valR = 0;
        string ope = "";
        bool Numin = true;
        double rslt = 0;


        public Form1()
        {
            InitializeComponent();

        
        }

         public void NumInChk(string ope)
        {
            if (Numin == false)
            {
                if (ope != "")
                {
                    In_val = double.Parse(textBox1.Text);
                }
                textBox1.Text = "";
                Numin = true;
            }
            
        }

        public void OpeInChk(string ope)
        {
            if (ope != "")
            {
                In_valR = double.Parse(textBox1.Text);
                Culc cul = new Culc(ope, In_val, In_valR);
                textBox1.Text = Convert.ToString(cul.DoCulc());
            }
            Numin = false;
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NumInChk(ope);
            textBox1.Text += button1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NumInChk(ope);
            textBox1.Text += button2.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NumInChk(ope);
            textBox1.Text += button3.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            NumInChk(ope);
            textBox1.Text += button4.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            NumInChk(ope);
            textBox1.Text += button5.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            NumInChk(ope);
            textBox1.Text += button6.Text;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            NumInChk(ope);
            textBox1.Text += button7.Text;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            NumInChk(ope);
            textBox1.Text += button8.Text;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            NumInChk(ope);
            textBox1.Text += button9.Text;
        }

        private void button0_Click(object sender, EventArgs e)
        {
            NumInChk(ope);
            textBox1.Text += button0.Text;
        }
        private void shosu_Click(object sender, EventArgs e)
        {
            NumInChk(ope);
            textBox1.Text += shosu.Text;
        }

        private void plus_Click(object sender, EventArgs e)
        {
            OpeInChk(ope);
            ope = plus.Text;
            In_val = double.Parse(textBox1.Text);
        }

        private void minus_Click(object sender, EventArgs e)
        {
            OpeInChk(ope);
            ope = minus.Text;
            In_val = double.Parse(textBox1.Text);
        }

        private void div_Click(object sender, EventArgs e)
        {
            OpeInChk(ope);
            ope = div.Text;
            In_val = double.Parse(textBox1.Text);
        }

        private void mul_Click(object sender, EventArgs e)
        {
            OpeInChk(ope);
            ope = mul.Text;
            In_val = double.Parse(textBox1.Text);
        }

        private void equal_Click(object sender, EventArgs e)
        {
            In_valR = double.Parse(textBox1.Text);
            Culc cul = new Culc(ope, In_val, In_valR);
            textBox1.Text = Convert.ToString(cul.DoCulc());
            ope = "";
            Numin = false;

        }

        private void clr_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            ope = "";
            In_val = 0;
            In_valR = 0;
            Numin = true;
        }

        private void Wari_Click(object sender, EventArgs e)
        {
            WariForm wari = new WariForm();
            wari.Recv = textBox1.Text;
            wari.Show();
        }
    }


    public class Culc
    {
        public string ope;
        public double In_val;
        public double In_valR;
        public double rslt;

        public Culc(string ope,double In_val,double In_valR)
        {
            this.ope = ope;
            this.In_val = In_val;
            this.In_valR = In_valR;
        }

        public double DoCulc()
        {
            if (ope == "+")
            {
                rslt = In_val + In_valR;
            }
            else if (ope == "-")
            {
                rslt = In_val - In_valR;
            }
            else if (ope == "×")
            {
                rslt = In_val * In_valR;
            }
            else if (ope == "÷")
            {
                rslt = In_val / In_valR;
            }
            return rslt;
        }

    }
}
