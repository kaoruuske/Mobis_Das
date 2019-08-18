using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MOBISDAS.Global;
using Dabom.TagAdapter;
using Dabom.TagAdapter.Item;
using MOBISDAS.Common;

namespace MOBISDAS.Forms
{
    public delegate void LabelSet(string LabelText);
    public delegate void TextSet(string Text);

    public partial class frmMsg : Form
    {
        public string sMode = "";
        public string sMsg = "";

        public frmMsg(string Mode, string Msg)
        {
            try
            {
                InitializeComponent();
                sMode = Mode;
                sMsg = Msg;
                timer.Enabled = false;
            }
            catch (Exception ex)
            {
            }
        }

        private void btn_Cancle_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
            EquipInfo.Rtn = "NO";
        }

        private void frmMsg_Load(object sender, EventArgs e)
        {            
            try
            {
                EquipInfo.Msg_Off = false;
                if (sMode == "SKID")
                {
                    Text_Set("스키드 확인");
                    //lbl_Title.Text = "스키드 확인";
                    Label_Text_Set(sMsg);
                    //lbl_Msg.Text = sMsg;
                }
                else if (sMode == "ERROR")
                {
                    btn_OK.Enabled = false;
                    btn_OK.Visible = false;
                    btn_Cancle.Enabled = false;
                    btn_Cancle.Visible = false;
                    //btn_Cancle.Text = "닫기";
                    Text_Set("확인!");
                    //lbl_Title.Text = "확인!";
                    Label_Text_Set(sMsg);
                    //lbl_Msg.Text = sMsg;
                    timer.Interval = 2000;
                    timer.Enabled = true;
                }
                else if (sMode == "BARCODE ERROR")
                {
                    Text_Set("NEW ALC CODE");
                    Label_Text_Set(sMsg);
                    btn_OK.Enabled = false;
                    btn_OK.Visible = false;
                    btn_Cancle.Text = "확인";
                }
                else if (sMode == "BEFORE_ROUTE_CHECK")
                {
                    Text_Set("이전공정 확인");
                    //lbl_Title.Text = "이전공정 확인";
                    Label_Text_Set(sMsg);
                    //lbl_Msg.Text = sMsg;
                }
                else if (sMode == "INPUT_FLAG_CHECK")
                {
                    Text_Set("투입 서열 확인!");
                    //lbl_Title.Text = "투입 서열 확인!";
                    Label_Text_Set(sMsg);
                    //lbl_Msg.Text = sMsg;
                    btn_OK.Enabled = false;
                    btn_OK.Visible = false;
                    btn_Cancle.Enabled = false;
                    btn_Cancle.Visible = false;
                    timer.Interval = 2000;
                    timer.Enabled = true;
                }
                else if (sMode == "TOOL CLOSE")
                {
                    Text_Set("확인");
                    //lbl_Title.Text = "확인";
                    Label_Text_Set(sMsg);
                    //lbl_Msg.Text = sMsg;
                }
                else if (sMode == "REWORK")
                {
                    Text_Set("재작업 확인");
                    //lbl_Title.Text = "재작업 확인";
                    Label_Text_Set(sMsg);
                    //lbl_Msg.Text = sMsg;
                }
                else if (sMode == "NG")
                {
                    Text_Set("NG");
                    //lbl_Title.Text = "NG";
                    Label_Text_Set(sMsg);
                    //lbl_Msg.Text = sMsg;
                    btn_OK.Enabled = false;
                    btn_OK.Visible = false;
                    btn_Cancle.Enabled = false;
                    btn_Cancle.Visible = false;
                    timer.Interval = 3000;
                    timer.Enabled = true;
                }
                else if (sMode == "ERASED_BODY")
                {
                    Text_Set("!! 중복 바디(말소된 서열) !!");
                    //lbl_Title.Text = "!! 중복 바디(말소된 서열) !!";
                    Label_Text_Set(sMsg);
                    //lbl_Msg.Text = sMsg;
                }
                else if (sMode == "DUPLICATION_BODY")
                {
                    Text_Set("!! 중복 바디 !!");
                    //lbl_Title.Text = "!! 중복 바디 !!";
                    Label_Text_Set(sMsg);
                    //lbl_Msg.Text = sMsg;
                }
                else if (sMode == "OK")
                {
                    Text_Set("OK");
                    //lbl_Title.Text = "OK";
                    Label_Text_Set(sMsg);
                    //lbl_Msg.Text = sMsg;                    
                    btn_OK.Enabled = false;
                    btn_OK.Visible = false;
                    btn_Cancle.Enabled = false;
                    btn_Cancle.Visible = false;
                    this.BackColor = Color.Black;
                    this.pnl_Msg.BackColor = Color.Navy;
                    timer.Enabled = true;
                }
                else if (sMode == "TAG")
                {
                    Text_Set("TAG 매칭");
                    //lbl_Title.Text = "TAG 매칭";
                    Label_Text_Set(sMsg);
                    //lbl_Msg.Text = sMsg;
                    //timer_Tag_Check.Enabled = true;                    
                }
                else if (sMode == "WORK_COMPLETE")
                {
                    Text_Set("작업 완료!");
                    //lbl_Title.Text = "작업 완료!";
                    Label_Text_Set(sMsg);
                    //lbl_Msg.Text = sMsg;                    
                    btn_OK.Enabled = false;
                    btn_OK.Visible = false;
                    btn_Cancle.Enabled = false;
                    btn_Cancle.Visible = false;
                    this.BackColor = Color.Black;
                    this.pnl_Msg.BackColor = Color.Navy;
                    timer.Enabled = true;
                }
                else if (sMode == "EVENT_MESSAGE")
                {
                    Text_Set("EVENT 차량 알림");
                    //lbl_Title.Text = "EVENT 차량 알림";
                    Label_Text_Set(sMsg);
                    //lbl_Msg.Text = sMsg;
                    btn_OK.Enabled = false;
                    btn_OK.Visible = false;
                    btn_Cancle.Enabled = false;
                    btn_Cancle.Visible = false;
                    timer.Interval = EquipInfo.Message_Timer_Interval;
                    timer.Enabled = true;
                    pnl_Msg.BackColor = Color.Purple;
                }
                else if (sMode == "ASSY_MSG")
                {
                    Text_Set("메세지 확인!");
                    Label_Text_Set(sMsg);
                    btn_OK.Enabled = false;
                    btn_OK.Visible = false;
                    btn_Cancle.Enabled = false;
                    btn_Cancle.Visible = false;
                    timer.Interval = 2000;
                    timer.Enabled = true;
                    this.Location = new Point(110, 150);
                }
                else if (sMode == "DATA ERROR")
                {
                    Text_Set("바코드 스캔 데이터 오류");
                    //lbl_Title.Text = "NG";
                    Label_Text_Set(sMsg);
                    //lbl_Msg.Text = sMsg;
                    btn_OK.Enabled = false;
                    btn_OK.Visible = false;
                    btn_Cancle.Enabled = false;
                    btn_Cancle.Visible = false;
                    timer.Interval = 3000;
                    timer.Enabled = true;
                }
                else if (sMode == "DUPLICATE")
                {
                    //Text_Set("이종발생");
                    Text_Set("          중복작업 이력확인"); //jh_kim 16.11.11
                    //lbl_Title.Text = "NG";
                    Label_Text_Set(sMsg);
                    //lbl_Msg.Text = sMsg;
                    btn_OK.Enabled = false;
                    btn_OK.Visible = false;
                    btn_Cancle.Enabled = false;
                    btn_Cancle.Visible = false;
                    timer.Interval = 3000;
                    timer.Enabled = true;
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void Label_Text_Set(string LabelText)
        {
            try
            {
                if (lbl_Msg.InvokeRequired)
                    lbl_Msg.Invoke(new LabelSet(Label_Text_Set), new object[] { LabelText });
                else
                    lbl_Msg.Text = LabelText;
            }
            catch (Exception ex)
            {
            }
        }

        private void Text_Set(string Text)
        {
            try
            {
                if (lbl_Title.InvokeRequired)
                    lbl_Title.Invoke(new TextSet(Text_Set), new object[] { Text });
                else
                    lbl_Title.Text = Text;
            }
            catch (Exception ex)
            {
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            EquipInfo.Rtn = "OK";
            this.Close();
        }

        private void timer_Tag_Check_Tick(object sender, EventArgs e)
        {
            string pValue = "";
            string tRf_Value = "";
            try
            {
                string commStatus = NetRemoting.Comm_IDGet(EquipInfo.WORKCENTER + "_" + EquipInfo.ROUTE_NO);
                if (commStatus != null)
                {
                    Dictionary<string, Dabom.TagAdapter.Item.VariableItem> mVariableItems = (new Dabom.TagAdapter.StateParse(commStatus)).ToVariableItems();//DICTIONARY 넣기

                    pValue = mVariableItems["RF_WR_VALUE"].Value.ToString();
                }

                tRf_Value = NetRemoting.TagGet(EquipInfo.WORKCENTER + "_" + EquipInfo.ROUTE_NO + "_RF_VALUE");

                if (tRf_Value == pValue)
                {
                    this.Close();
                }
                else
                {
                    lbl_Title.Text = "TAG MATCHING";
                    lbl_Msg.Text = "TAG에 BODY 정보를 재기록 중입니다....";
                    Comm_IDSet();

                }

            }
            catch (Exception ex)
            {
            }
        }
        private void Comm_IDSet()
        {
            string Hex_Data = "";
            try
            {
                byte[] ASCIIBytes = System.Text.Encoding.Default.GetBytes(EquipInfo.BODY_NO + EquipInfo.ORDER_DATE + EquipInfo.CMT);

                for (int i = 0; i < ASCIIBytes.Length; i++)
                {
                    Hex_Data = Hex_Data + ASCIIBytes[i].ToString();
                }
                Dabom.TagAdapter.Item.WorkDataUp datup = new Dabom.TagAdapter.Item.WorkDataUp(EquipInfo.WORKCENTER + "_" + EquipInfo.ROUTE_NO, true);

                datup.Variables.Add("TOOL_MAX", new VariableItem { VarID = "RF_WR_VALUE", Value = Hex_Data });
                System.Threading.Thread.Sleep(1000);
            }
            catch (Exception ex)
            {

            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            EquipInfo.Message_Timer_Interval = 0;
            this.Close();
        }

        private void frmMsg_FormClosing(object sender, FormClosingEventArgs e)
        {
            EquipInfo.Msg_Off = true;
        }
    }
}