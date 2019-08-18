using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MOBISDAS.Global;
using MOBISDAS.Database;
using MOBISDAS.Forms;
using MOBISDAS.Common;
using Dabom.TagAdapter;
using Dabom.TagAdapter.Item;
using MOBISDAS.UI;
using System.IO;

namespace MOBISDAS.Forms
{
    public partial class frmWorkKeeper_Bad : Form
    {

        private int sIndex = 0;
        private int lIndex = 0;

        private frmMsg frmMsg = null;
        public delegate void WorkMsg(Form WorkMsg);
        private string slog = "";
        
        public frmWorkKeeper_Bad()
        {            
            InitializeComponent();               
        }

        private void frmWorkTool_Shown(object sender, EventArgs e)
        {
            lbl_OrderDate.Text = EquipInfo.ORDER_DATE;
            lbl_Commit.Text = EquipInfo.CMT;
            lbl_BodyNo.Text = EquipInfo.BODY_NO;
            lbl_EMP.Text = EquipInfo.EMP;
            sIndex = 0;
            LoadPart();
            InitBadCode();
            Opt_EventAdd();
        }

        private void Opt_EventAdd()
        {
            //BAD_GROUP
            for (int i = 1; i <= 10; i++)
            {
                foreach (Control ctrl in tableLayoutPanel13.Controls)
                {
                    if (ctrl.GetType() == typeof(RadioButton) && ctrl.Name == "OptPart" + i.ToString("0#"))
                    {
                        ((RadioButton)ctrl).CheckedChanged += new System.EventHandler(this.OptPart_CheckedChanged);
                    }
                }
            }
            //BAD_GROUP
            for (int i = 1; i <= 4; i++)
            {
                foreach (Control ctrl in tableLayoutPanel6.Controls)
                {
                    if (ctrl.GetType() == typeof(RadioButton) && ctrl.Name == "OptBadGroup" + i.ToString("0#"))
                    {
                        ((RadioButton)ctrl).CheckedChanged += new System.EventHandler(this.OptBadGroup_CheckedChanged);
                    }
                }
            }

            //BAD_CODE
            for (int i = 1; i <= 28; i++)
            {
                foreach (Control ctrl in tableLayoutPanel8.Controls)
                {
                    if (ctrl.GetType() == typeof(RadioButton) && ctrl.Name == "OptBad" + i.ToString("0#"))
                    {
                        ((RadioButton)ctrl).CheckedChanged += new System.EventHandler(this.OptBad_CheckedChanged);
                    
                    }
                }
            }
        }

        private void InitBadCode()
        {
            for (int i = 1; i <= 28; i++)
            {
                foreach (Control ctrl in tableLayoutPanel8.Controls)
                {
                    if (ctrl.GetType() == typeof(RadioButton) && ctrl.Name == "OptBad" + i.ToString("0#"))
                    {
                        ((RadioButton)ctrl).Visible = false;
                        ((RadioButton)ctrl).Text = "";
                        ((RadioButton)ctrl).Tag = "";
                    }
                }
            }
        }

        private void LoadPart()
        {
            DataSet ds = new DataSet();
            Procedure.PPC_LOAD_PART(EquipInfo.WORKCENTER, EquipInfo.BODY_NO.Substring(0, 2), ref ds);

            lIndex = ds.Tables[0].Rows.Count;

            int j = 1;
            for(int i=sIndex;i< (sIndex + 10 > lIndex?lIndex:sIndex+10);i++)
            {
                foreach (Control ctrl in tableLayoutPanel13.Controls)
                {
                    if (ctrl.GetType() == typeof(RadioButton) && ctrl.Name == "OptPart" + j.ToString("0#"))
                    {
                        ((RadioButton)ctrl).Text = ds.Tables[0].Rows[i]["PART_NAME"].ToString();
                        ((RadioButton)ctrl).Tag = ds.Tables[0].Rows[i]["PART_ID"].ToString();
                    }
                }
                j++;
            }

            if (sIndex == 0)
                btnUp.Enabled = false;
            else
                btnUp.Enabled = true;

            if (sIndex + 10 >= lIndex)
                btnDown.Enabled = false;
            else
                btnDown.Enabled = true;
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (lblMinute.Text == "0")
                lblMinute.Text = "1";
            else
                lblMinute.Text += "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (lblMinute.Text == "0")
                lblMinute.Text = "2";
            else
                lblMinute.Text += "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (lblMinute.Text == "0")
                lblMinute.Text = "3";
            else
                lblMinute.Text += "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (lblMinute.Text == "0")
                lblMinute.Text = "4";
            else
                lblMinute.Text += "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            if (lblMinute.Text == "0")
                lblMinute.Text = "5";
            else
                lblMinute.Text += "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            if (lblMinute.Text == "0")
                lblMinute.Text = "6";
            else
                lblMinute.Text += "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            if (lblMinute.Text == "0")
                lblMinute.Text = "7";
            else
                lblMinute.Text += "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            if (lblMinute.Text == "0")
                lblMinute.Text = "8";
            else
                lblMinute.Text += "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            if (lblMinute.Text == "0")
                lblMinute.Text = "9";
            else
                lblMinute.Text += "9";
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            if (lblMinute.Text == "0")
                lblMinute.Text = "0";
            else
                lblMinute.Text += "0";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            sIndex--;
            LoadPart();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            sIndex++;
            LoadPart();
        }

        private void OptPart_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 1; i <= 10; i++)
            {
                foreach (Control ctrl in tableLayoutPanel13.Controls)
                {
                    if (ctrl.GetType() == typeof(RadioButton) && ctrl.Name == "OptPart" + i.ToString("0#"))
                    {
                        if (ctrl != (Control)sender)
                            ((RadioButton)ctrl).BackColor = Color.Plum;
                        else
                            ((RadioButton)ctrl).BackColor = Color.Violet;
                    }
                }

            }
        }

       

        private void OptBadGroup_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 1; i <= 4; i++)
            {
                foreach (Control ctrl in tableLayoutPanel6.Controls)
                {
                    if (ctrl.GetType() == typeof(RadioButton) && ctrl.Name == "OptBadGroup" + i.ToString("0#"))
                    {
                        if (ctrl != (Control)sender)
                            ((RadioButton)ctrl).BackColor = Color.MistyRose;
                        else
                            ((RadioButton)ctrl).BackColor = Color.Salmon;
                    }
                }
                
            }
            if (((RadioButton)sender).Checked == true)
                LoadBad(((RadioButton)sender).Tag.ToString());
        }

        private void OptBad_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 1; i <= 28; i++)
            {
                foreach (Control ctrl in tableLayoutPanel8.Controls)
                {
                    if (ctrl.GetType() == typeof(RadioButton) && ctrl.Name == "OptBad" + i.ToString("0#"))
                    {
                        if(ctrl != (Control)sender)
                            ((RadioButton)ctrl).BackColor = Color.Khaki;
                        else
                            ((RadioButton)ctrl).BackColor = Color.LemonChiffon;
                    }
                }
            }
            lblMinute.Text = "0";
        }

        private void LoadBad(string BadGroup)
        {
            InitBadCode();
            DataSet ds = new DataSet();
            Procedure.PPC_LOAD_BAD(BadGroup, ref ds);

            for (int i = 1; i <= ds.Tables[0].Rows.Count; i++)
            {
                foreach (Control ctrl in tableLayoutPanel8.Controls)
                {
                    if (ctrl.GetType() == typeof(RadioButton) && ctrl.Name == "OptBad" + i.ToString("0#"))
                    {
                        ((RadioButton)ctrl).Visible = true; ;
                        ((RadioButton)ctrl).Text = ds.Tables[0].Rows[i-1]["BAD_NAME"].ToString();
                        ((RadioButton)ctrl).Tag = ds.Tables[0].Rows[i-1]["BAD_CODE"].ToString();
                    }
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                string tr_Id = "";
                DataSet ds = new DataSet();
                Procedure.PPC_TRID(EquipInfo.WORKCENTER, lbl_OrderDate.Text, lbl_Commit.Text, lbl_BodyNo.Text, ref ds);

                if (ds.Tables[0].Rows.Count > 0)
                    tr_Id = ds.Tables[0].Rows[0]["TR_ID"].ToString();
                else
                    tr_Id = "";


                string PART_ID = "";
                for (int i = 1; i <= 10; i++)
                {
                    foreach (Control ctrl in tableLayoutPanel13.Controls)
                    {
                        if (ctrl.GetType() == typeof(RadioButton) && ctrl.Name == "OptPart" + i.ToString("0#"))
                        {
                            if (((RadioButton)ctrl).Checked)
                                PART_ID = ctrl.Tag.ToString();
                        }
                    }
                }

                string BAD_GROUP = "";
                for (int i = 1; i <= 4; i++)
                {
                    foreach (Control ctrl in tableLayoutPanel6.Controls)
                    {
                        if (ctrl.GetType() == typeof(RadioButton) && ctrl.Name == "OptBadGroup" + i.ToString("0#"))
                        {
                            if (((RadioButton)ctrl).Checked)
                                BAD_GROUP = ctrl.Tag.ToString();
                        }
                    }
                }

                string BAD_CODE = "";

                for (int i = 1; i <= 28; i++)
                {
                    foreach (Control ctrl in tableLayoutPanel8.Controls)
                    {
                        if (ctrl.GetType() == typeof(RadioButton) && ctrl.Name == "OptBad" + i.ToString("0#"))
                        {
                            if (((RadioButton)ctrl).Checked)
                                BAD_CODE = ctrl.Tag.ToString();
                        }
                    }
                }
                ds.Dispose();
                if (tr_Id == "")
                {
                    MassageFormLoad("NG", "BODY를 확인해 주세요");
                    return;
                }

                if (PART_ID == "")
                {
                    MassageFormLoad("NG", "품번을 선택해 주세요.");
                    return;
                }

                if (BAD_GROUP == "")
                {
                    MassageFormLoad("NG", "불량구분을 선택해 주세요.");
                    return;
                }
                if (BAD_CODE == "")
                {
                    MassageFormLoad("NG", "상세내역을 선택해 주세요.");
                    return;
                }

                if (lblMinute.Text == "0")
                {
                    MassageFormLoad("NG", "처리시간을 입력해 주세요.");
                    return;
                }
                ds = new DataSet();
                Procedure.PPC_SAVE_BAD(EquipInfo.WORKCENTER, EquipInfo.ROUTE_NO, tr_Id, PART_ID, BAD_GROUP, BAD_CODE, lblMinute.Text, lbl_EMP.Text, ref ds);

                if (ds.Tables[0].Rows[0][0].ToString() == "NG")
                {
                    MassageFormLoad("NG", "이미 등록된 불량 내역입니다.");
                }
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWorkKeeper_Bad] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }

        private void MassageFormLoad(string Gubun, string Msg)
        {
            try
            {
                frmMsg = null;
                frmMsg = new frmMsg(Gubun, Msg);
                frmWork_Set(frmMsg);
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWorkKeeper_Bad] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }

        private void frmWork_Set(Form _Work)
        {
            try
            {
                if (this.InvokeRequired)
                    this.Invoke(new WorkMsg(frmWork_Set), new object[] { _Work });
                else
                    frmMsg.ShowDialog();
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWorkKeeper_Bad] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            string tr_Id = "";
            DataSet ds = new DataSet();
            Procedure.PPC_TRID(EquipInfo.WORKCENTER, lbl_OrderDate.Text, lbl_Commit.Text, lbl_BodyNo.Text, ref ds);

            if (ds.Tables[0].Rows.Count > 0)
                tr_Id = ds.Tables[0].Rows[0]["TR_ID"].ToString();
            else
                tr_Id = "";

            ds.Dispose();

            ds = new DataSet();
            if(tr_Id != "")
            {
                Procedure.PPC_LOAD_PREV_ORDER(EquipInfo.WORKCENTER, tr_Id, ref ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lbl_BodyNo.Text = ds.Tables[0].Rows[0]["BODY_NO"].ToString();
                    lbl_Commit.Text = ds.Tables[0].Rows[0]["COMMIT_NO"].ToString();
                    lbl_OrderDate.Text = ds.Tables[0].Rows[0]["ORDER_DATE"].ToString();
                }
                else
                {
                    MassageFormLoad("NG", "이전 작업지시가 없습니다.");
                }
            }

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            string tr_Id = "";
            DataSet ds = new DataSet();
            Procedure.PPC_TRID(EquipInfo.WORKCENTER, lbl_OrderDate.Text, lbl_Commit.Text, lbl_BodyNo.Text, ref ds);

            if (ds.Tables[0].Rows.Count > 0)
                tr_Id = ds.Tables[0].Rows[0]["TR_ID"].ToString();
            else
                tr_Id = "";

            ds.Dispose();

            ds = new DataSet();
            if (tr_Id != "")
            {
                Procedure.PPC_LOAD_NEXT_ORDER(EquipInfo.WORKCENTER, tr_Id, ref ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lbl_BodyNo.Text = ds.Tables[0].Rows[0]["BODY_NO"].ToString();
                    lbl_Commit.Text = ds.Tables[0].Rows[0]["COMMIT_NO"].ToString();
                    lbl_OrderDate.Text = ds.Tables[0].Rows[0]["ORDER_DATE"].ToString();
                }
                else
                {
                    MassageFormLoad("NG", "다음 작업지시가 없습니다.");
                }
            }
        }
    }
}