using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MOBISDAS.UI
{
    public partial class frmNumer : Form
    {
        bool _KeyFirst = false;
        public frmNumer(Label setLabel)
        {
            InitializeComponent();
            this.label2 = setLabel;
            this.label2.Text = setLabel.Text;
            this.label1.Text  = this.label2.Text;
        }

        private void KeyFirst()
        {
            _KeyFirst = true;
            label1.Text = "0";
        }

        private void frmNumer_Shown(object sender, EventArgs e)
        {
            textBoxKeyin.SendToBack();
            textBoxKeyin.Text = label1.Text;
            textBoxKeyin.Focus();
            //textBoxKeyin.Select(textBoxKeyin.Text.Length, 0);
        }

        private void bntClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bnt1_Click(object sender, EventArgs e)
        {
            if (!_KeyFirst) KeyFirst();
            label1.Text += "1";
        }

        private void bnt2_Click(object sender, EventArgs e)
        {
            if (!_KeyFirst) KeyFirst();
            label1.Text += "2";
        }

        private void bnt3_Click(object sender, EventArgs e)
        {
            if (!_KeyFirst) KeyFirst();
            label1.Text += "3";
        }

        private void bnt4_Click(object sender, EventArgs e)
        {
            if (!_KeyFirst) KeyFirst();
            label1.Text += "4";
        }

        private void bnt5_Click(object sender, EventArgs e)
        {
            if (!_KeyFirst) KeyFirst();
            label1.Text += "5";
        }

        private void bnt6_Click(object sender, EventArgs e)
        {
            if (!_KeyFirst) KeyFirst();
            label1.Text += "6";
        }

        private void bnt7_Click(object sender, EventArgs e)
        {
            if (!_KeyFirst) KeyFirst();
            label1.Text += "7";
        }

        private void bnt8_Click(object sender, EventArgs e)
        {
            if (!_KeyFirst) KeyFirst();
            label1.Text += "8";
        }

        private void bnt9_Click(object sender, EventArgs e)
        {
            if (!_KeyFirst) KeyFirst();
            label1.Text += "9";
        }

        private void bnt0_Click(object sender, EventArgs e)
        {
            if (!_KeyFirst) KeyFirst();
            label1.Text += "0";
        }

        private void bntdot_Click(object sender, EventArgs e)
        {
            if (label1.Text.IndexOf('.') == -1)
            {
                if (!_KeyFirst) KeyFirst();
                label1.Text += ".";
            }
        }

        
       
        private void bntBackSpace_Click(object sender, EventArgs e)
        {
            _KeyFirst = true;
            if (label1.Text.Length == 1)
            {
                label1.Text  = "";
            }
            else
            {
                if (label1.Text != "")
                {
                    label1.Text = label1.Text.Substring(0, label1.Text.Length - 1);
                    if (label1.Text != "" && label1.Text.Substring(label1.Text.Length - 1, 1) == ".") label1.Text = label1.Text.Substring(0, label1.Text.Length - 1);
                }
            }
        }

        private void bntOk_Click(object sender, EventArgs e)
        {
            label2.Text = label1.Text;
            /*
            if (label1.Text.Length == 3)
            {
                label2.Text = "0" + label1.Text;
            }
            else
            {
                label2.Text = label1.Text;
            }
            */
            this.Dispose();
            this.Close();
        }

        private void label1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (label1.Text.IndexOf('.') == -1 & label1.Text != "")
                    label1.Text = Convert.ToInt64(label1.Text).ToString();

                if (textBoxKeyin.Text != label1.Text)
                    textBoxKeyin.Text = label1.Text;
            }
            catch (Exception ex)
            {

            }
        }

        private void bntCLS_Click(object sender, EventArgs e)
        {
             label1.Text = "";
         }
        private void textBoxKeyin_Leave(object sender, EventArgs e)
        {
            textBoxKeyin.Focus();
            textBoxKeyin.Select(textBoxKeyin.Text.Length, 0);
        }

        private void textBoxKeyin_TextChanged(object sender, EventArgs e)
        {
            if (label1.Text != textBoxKeyin.Text)
                label1.Text = textBoxKeyin.Text;
        }

        private void textBoxKeyin_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBoxKeyin.Text == "0")
            {
                textBoxKeyin.Text = "";
            }
        }

    }
}