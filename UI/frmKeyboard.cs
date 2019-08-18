using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MOBISDAS.UI
{
    public partial class frmKeyboard : Form
    {
        public frmKeyboard(Label setLabel)
        {
            InitializeComponent();
            this.label2 = setLabel;
            this.label2.Text = setLabel.Text;
            this.label1.Text = this.label2.Text.ToString ();
        }

        private void frmKeyboard_Shown(object sender, EventArgs e)
        {
            textBoxKeyin.SendToBack();
            textBoxKeyin.Text = label1.Text;
            textBoxKeyin.Focus();
            textBoxKeyin.Select(textBoxKeyin.Text.Length, 0);
        }

        private void bntShift_Click(object sender, EventArgs e)
        {
            if (bntShift.Tag == null || bntShift.Tag.ToString () != "")
            {
                bntShift.BackColor = SystemColors.GradientActiveCaption;
                bntShift.Tag = "";
                Shift_On(false);
            }
            else
            {
                bntShift.BackColor = SystemColors.Control;
                bntShift.Tag ="Shift";
                Shift_On(true );
            }
            
        }

        private void Shift_On(bool shift)
        {
            foreach (Control Cont in this.Controls)
            {
               // string data = Cont.GetType().Name  =="Button"
                if (Cont.GetType().Name == "Button" | Cont.GetType().Name == "itCommandButton")
                {
                    switch (Cont.Text)
                    {
                        case "a":  case "A": Cont.Text = (shift ? "A" : "a");                            break;
                        case "b":  case "B": Cont.Text = (shift ? "B" : "b");                            break;
                        case "c":  case "C": Cont.Text = (shift ? "C" : "c");                            break;
                        case "d":  case "D": Cont.Text = (shift ? "D" : "d");                            break;
                        case "e":  case "E": Cont.Text = (shift ? "E" : "e");                            break;
                        case "f":  case "F": Cont.Text = (shift ? "F" : "f");                            break;
                        case "g":  case "G": Cont.Text = (shift ? "G" : "g");                            break;
                        case "h":  case "H": Cont.Text = (shift ? "H" : "h");                            break;
                        case "i":  case "I": Cont.Text = (shift ? "I" : "i");                            break;
                        case "j":  case "J": Cont.Text = (shift ? "J" : "j");                            break;
                        case "k":  case "K": Cont.Text = (shift ? "K" : "k");                            break;
                        case "l":  case "L": Cont.Text = (shift ? "L" : "l");                            break;
                        case "m":  case "M": Cont.Text = (shift ? "M" : "m");                            break;
                        case "n":  case "N": Cont.Text = (shift ? "N" : "n");                            break;
                        case "o":  case "O": Cont.Text = (shift ? "O" : "o");                            break;
                        case "p":  case "P": Cont.Text = (shift ? "P" : "p");                            break;
                        case "q":  case "Q": Cont.Text = (shift ? "Q" : "q");                            break;
                        case "r":  case "R": Cont.Text = (shift ? "R" : "r");                            break;
                        case "s":  case "S": Cont.Text = (shift ? "S" : "s");                            break;
                        case "t":  case "T": Cont.Text = (shift ? "T" : "t");                            break;
                        case "u":  case "U": Cont.Text = (shift ? "U" : "u");                            break;
                        case "v":  case "V": Cont.Text = (shift ? "V" : "v");                            break;
                        case "w":  case "W": Cont.Text = (shift ? "W" : "w");                            break;
                        case "x":  case "X": Cont.Text = (shift ? "X" : "x");                            break;
                        case "y":  case "Y": Cont.Text = (shift ? "Y" : "y");                            break;
                        case "z":  case "Z": Cont.Text = (shift ? "Z" : "z");                            break;
                        case "0":  case ")": Cont.Text = (shift ? "0" : ")");                            break;
                        case "1":  case "!": Cont.Text = (shift ? "1" : "!");                            break;
                        case "2":  case "@": Cont.Text = (shift ? "2" : "@");                            break;
                        case "3":  case "#": Cont.Text = (shift ? "3" : "#");                            break;
                        case "4":  case "$": Cont.Text = (shift ? "4" : "$");                            break;
                        case "5":  case "%": Cont.Text = (shift ? "5" : "%");                            break;
                        case "6":  case "^": Cont.Text = (shift ? "6" : "^");                            break;
                        case "7":  case "&&": Cont.Text = (shift ? "7" : "&&");                            break;
                        case "8":  case "*": Cont.Text = (shift ? "8" : "*");                            break;
                        case "9":  case "(": Cont.Text = (shift ? "9" : "(");                            break;
                        case "-":  case "_": Cont.Text = (shift ? "-" : "_");                            break;
                        case "=":  case "+": Cont.Text = (shift ? "=" : "+");                            break;
                        case "[":  case "{": Cont.Text = (shift ? "[" : "{");                            break;
                        case "]":  case "}": Cont.Text = (shift ? "]" : "}");                            break;
                        case ";":  case ":": Cont.Text = (shift ? ";" : ":");                            break;
                        //case "'":  case "\"": Cont.Text = (shift ? "'" : "\""); break;
                        case "'":  case "\\": Cont.Text = (shift ? "'" : "\\"); break;
                        case ",":
                        case "<": Cont.Text = (shift ? "," : "<"); break;
                        case ".":  case ">": Cont.Text = (shift ? "." : ">");                            break;
                        case "/":  case "?": Cont.Text = (shift ? "/" : "?");                            break;


                    }

                }
            }


        }

        private void bntClear_Click(object sender, EventArgs e)
        {
            label1.Text = "";
        }

        private void bntCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void bntOk_Click(object sender, EventArgs e)
        {
            label2.Text = label1.Text;
            this.Dispose();
            this.Close();
        }

        private void char_Click(object sender, EventArgs e)
        {
            label1.Text += ((Button)sender).Text;
            textBoxKeyin.Focus();
            textBoxKeyin.Select(textBoxKeyin.Text.Length, 0);
        }

        private void bntBackSpace_Click(object sender, EventArgs e)
        {
            if (label1.Text.Length != 0)
                label1.Text = label1.Text.Substring(0, label1.Text.Length - 1);
        }

        private void textBoxKeyin_Leave(object sender, EventArgs e)
        {
            textBoxKeyin.Focus();
            textBoxKeyin.Select(textBoxKeyin.Text.Length, 0);
        }

        private void textBoxKeyin_TextChanged(object sender, EventArgs e)
        {
            if(label1.Text != textBoxKeyin.Text)
            label1.Text = textBoxKeyin.Text;
        }

        private void label1_TextChanged(object sender, EventArgs e)
        {
            if(textBoxKeyin.Text != label1.Text)
            textBoxKeyin.Text = label1.Text;
        }

        private void textBoxKeyin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;

                bntOk_Click(sender, e);
            }
            else
            {
                return;
            }

        }
    }
}