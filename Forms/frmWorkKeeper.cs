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
using System.Net;
using MOBISDAS.Forms;
using MOBISDAS.Common;
using System.IO.Ports;
using Dabom.TagAdapter;
using Dabom.TagAdapter.Item;

namespace MOBISDAS.Forms
{
    public partial class frmWorkKeeper : frmLoad
    {
        //private frmMsg frmMsg = null;
        private int Row_cnt = 56;
        //private DataSet ds = null;
        private string sBodyLSticker = "";
        private int dcol = 7;
        private DataSet ds_bIND;
        private string Tag_ID;

        private IniFile cFilehandle = new IniFile(Application.StartupPath + "\\INI\\db.ini");
        private string IniReadValue = "";
        private string IniEmp1 = "";
        private string IniEmp2 = "";

        private string slog = "";

        private bool End_Flag = true;


        private frmWorkKeeper_BadHist frmWorkKeeper_BadHist = null;
        public delegate void KeeperBadHist(Form frmWorkKeeper_BadHist);

        private frmWorkKeeper_Bad frmWorkKeeper_Bad = null;
        public delegate void KeeperBad(Form frmWorkKeeper_Bad);

        private frmMsg frmMsg = null;
        public delegate void WorkMsg(Form WorkMsg);

        public frmWorkKeeper(mdiMain tMDI)
        {
            TopLevel = false;
            _mdiMain = tMDI;
            InitializeComponent();
            Dock = DockStyle.Fill;

            LableLoad();
            FormLoad();
            timer_load.Enabled = true;
            timer_load.Start();                        
        }

        private void FormLoad()
        {            
            try
            {
                IniReadValue = cFilehandle.IniReadValue("LINE_INFO", "BODY_NO", ""); // ini 파일에 있는 마지막 BODY_NO
                
                //VIEW TABLE의 마지막 바디번호 정보를 가져온다.
                DataSet ds = new DataSet();
                Procedure.PPC_VW_LINETRK(EquipInfo.WORKCENTER, EquipInfo.ROUTE_NO, ref ds);
                sBodyLSticker = ds.Tables[0].Rows[0]["BODY_BARCODE"].ToString();                
                //          
                if (sBodyLSticker != "" && (sBodyLSticker != IniReadValue))
                {
                    //OEM 전송을 위한 TAG_ID
                    Tag_ID = ds.Tables[0].Rows[0]["F_TAG_ID"].ToString();  
                    BindData(sBodyLSticker);
                    End_Flag = true;
                    timer_complete_check.Enabled = true;
                    timer_complete_check.Start();
                }
                ds.Dispose();

                IniEmp1 = cFilehandle.IniReadValue("LINE_INFO", "EMP1", "");
                IniEmp2 = cFilehandle.IniReadValue("LINE_INFO", "EMP2", "");

                OptEmp1.Text = IniEmp1;
                OptEmp2.Text = IniEmp2;


            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWorkeeper] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }

        //동적으로 생성한다.
        private void LableLoad()
        {
            try
            {                             
                int sRow_cnt;
                sRow_cnt = Row_cnt / dcol;
                if (Row_cnt % dcol != 0)
                {
                    sRow_cnt = sRow_cnt + 1;
                }
                //if (sRow_cnt % dcol != 1)
                //{
                //    sRow_cnt = sRow_cnt + 1;
                //}

                tableLayoutPanel3.RowCount = sRow_cnt * 2;

                for (int j = 0; j < sRow_cnt; j++)
                {         
                    if (j != 0)
                    {
                        tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
                    }
                    tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
                    for (int k = 0; k < dcol; k++)
                    {
                        if (((j * dcol) + k) + 1 > Row_cnt )
                        {
                            j++;
                            break;
                        }
                        Label lbl = new Label();
                        Label lbl2 = new Label();

                            lbl.BackColor = System.Drawing.Color.LightSteelBlue;
                            lbl.Dock = System.Windows.Forms.DockStyle.Fill;
                            lbl.Location = new System.Drawing.Point(4, 1);
                            lbl.Name = "lbl_T_" + (((j * dcol) + k) + 1);
                            lbl.Size = new System.Drawing.Size(136, 243);
                            lbl.Text = "";
                            lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                            lbl.Margin = new System.Windows.Forms.Padding(0);
                            lbl.Font = new System.Drawing.Font("HY견고딕", 15.00F);

                            tableLayoutPanel3.Controls.Add(lbl, k , j*2);

                            lbl2.BackColor = System.Drawing.Color.White;
                            lbl2.Dock = System.Windows.Forms.DockStyle.Fill;
                            lbl2.Location = new System.Drawing.Point(4, 245);
                            lbl2.Name = "lbl_V_" + (((j * dcol) + k) + 1);
                            lbl2.Size = new System.Drawing.Size(136, 244);
                            lbl2.Text = "";
                            lbl2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                            lbl2.Click += new System.EventHandler(this.lbl_Click);
                            lbl2.Margin = new System.Windows.Forms.Padding(0);
                            lbl2.Font = new System.Drawing.Font("HY견고딕", 20.00F);

                            tableLayoutPanel3.Controls.Add(lbl2, k, (j *2)+1);                     
                    }
                }
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWorkeeper] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }

        private void BindData(string sBodyLSticker)
        {
            try
            {   
                int Index = 1;                                                  
                bool flag = false;     
                int maxRowCnt = 0;
                DataSet ds = new DataSet();
                if (EquipInfo.Virtual == false)
                {
                    Procedure.PPC_WORK_KEEPER(EquipInfo.WORKCENTER, sBodyLSticker, ref ds);
                }
                else
                {
                    Procedure.PPC_VIRTUAL_WORK_KEEPER(EquipInfo.WORKCENTER, sBodyLSticker, ref ds);
                }
                if (ds == null || ds_bIND == null)
                {
                    flag = true;
                }                
                else
                {
                    if (ds_bIND.Tables[0].Rows[0]["TR_ID"].ToString() != ds.Tables[0].Rows[0]["TR_ID"].ToString())
                    {
                        flag = true;
                    }
                    else
                    {
                        if (ds_bIND.Tables[0].Rows.Count != ds.Tables[0].Rows.Count)
                        {
                            flag = true;
                        }
                        else
                        {
                            maxRowCnt = ds_bIND.Tables[0].Rows.Count > ds.Tables[0].Rows.Count ? ds_bIND.Tables[0].Rows.Count : ds.Tables[0].Rows.Count;
                            for (int i = 0; i < maxRowCnt; i++)
                            {
                                if (ds_bIND.Tables[0].Rows[i]["OK_RESULT"].ToString() != ds.Tables[0].Rows[i]["OK_RESULT"].ToString())
                                {
                                    flag = true; ;
                                    break;
                                }
                            }
                        }
                    }
                }
                if (flag)
                {
                    tableLayoutPanel3.Visible = false;

                    tableLayoutPanel3.Controls.Clear();
                    LableLoad();

                    if (ds.Tables[0].Rows.Count > Row_cnt)
                    {
                        Row_cnt = ds.Tables[0].Rows.Count;
                        tableLayoutPanel3.Controls.Clear();
                        LableLoad();
                    }
                   
                    //상단 리스트
                    if (ds.Tables[0].Rows.Count > 0)
                    {                       
                        lbl_CarCode.Text = ds.Tables[0].Rows[0]["CAR_CODE"].ToString();
                        lbl_Region.Text = ds.Tables[0].Rows[0]["REGION"].ToString();
                        lbl_Drive.Text = ds.Tables[0].Rows[0]["DRIVE"].ToString();
                        lbl_Commit_No.Text = ds.Tables[0].Rows[0]["COMMIT_NO"].ToString();
                        lbl_Body_No.Text = ds.Tables[0].Rows[0]["BODY_NO"].ToString();
                        EquipInfo.ORDER_DATE = ds.Tables[0].Rows[0]["ORDER_DATE"].ToString();
                        EquipInfo.CMT = ds.Tables[0].Rows[0]["COMMIT_NO"].ToString();
                        EquipInfo.BODY_NO = ds.Tables[0].Rows[0]["BODY_NO"].ToString();
                        for (int row = 0; row < Row_cnt; row++)
                        {
                            for (int col = 1; col <= dcol; col++)
                            {
                                Index = (row * dcol + col);
                                if (Index > Row_cnt)
                                {
                                    row++;
                                    break;
                                }

                                if (Index > ds.Tables[0].Rows.Count)
                                {
                                    break;
                                }

                                Label lblT = ((Label)(tableLayoutPanel3.Controls["lbl_T_" + Index]));
                                Label lblV = ((Label)(tableLayoutPanel3.Controls["lbl_V_" + Index]));

                                if (ds.Tables[0].Rows[Index - 1]["PART_NAME"].ToString().Length >= 7)
                                {
                                    lblT.Font = new System.Drawing.Font("HY견고딕", 10.00F);
                                }
                                switch (ds.Tables[0].Rows[Index - 1]["OK_RESULT"].ToString())
                                {
                                    case "OK":
                                        lblV.BackColor = Color.SpringGreen;
                                        break;
                                    case "NG":
                                        lblV.BackColor = Color.Red;
                                        break;
                                    case "통과":
                                        lblV.BackColor = Color.Aqua;
                                        break;
                                    case "재작업":
                                        lblV.BackColor = Color.LightSeaGreen;
                                        break;
                                    case "MASTER":
                                        lblV.BackColor = Color.CornflowerBlue;
                                        break;
                                }
                                //((Label)(tableLayoutPanel3.Controls["lbl_T_" + (row * 7 + col)])).Text = ds.Tables[0].Rows[(row * 7 + col) - 1][0].ToString();
                                //((Label)(tableLayoutPanel3.Controls["lbl_V_" + (row * 7 + col)])).Text = ds.Tables[0].Rows[(row * 7 + col) - 1][1].ToString();
                                //((Label)(tableLayoutPanel3.Controls["lbl_V_" + (row * 7 + col)])).Tag = ds.Tables[0].Rows[(row * 7 + col) - 1];                                
                                
                                lblT.Text = ds.Tables[0].Rows[Index - 1]["PART_NAME"].ToString();
                                lblV.Text = ds.Tables[0].Rows[Index - 1]["ALC_CODE"].ToString();
                                lblV.Tag = ds.Tables[0].Rows[Index - 1];
                            }
                        }                        
                        ds_bIND = ds;
                        tableLayoutPanel3.Visible = true;
                    }
                }

                ds.Dispose();
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWorkeeper] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }

        private void lbl_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow dataRows = (DataRow)(((Label)(sender)).Tag);
                if (dataRows != null)
                {
                    if (dataRows["WORK_TYPE"].ToString() == "B")
                    {
                        frmWorkKeeper_Sub_Barcode frmWorkKeeper_Sub_Barcode = new Forms.frmWorkKeeper_Sub_Barcode(dataRows);
                        frmWorkKeeper_Sub_Barcode.ShowDialog();
                        if (EquipInfo.Tool_Cancle_Rtn != "CANCLE")
                        {
                            BindData(sBodyLSticker);
                        }
                    }
                    else if (dataRows[11].ToString() == "T")
                    {
                        frmWorkKeeper_Sub_Tool frmWorkKeeper_Sub_Tool = new Forms.frmWorkKeeper_Sub_Tool(dataRows);
                        frmWorkKeeper_Sub_Tool.ShowDialog();
                        if (EquipInfo.Tool_Cancle_Rtn != "CANCLE")
                        {
                            BindData(sBodyLSticker);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWorkeeper] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }
        private void btn_Bar_OK_Click(object sender, EventArgs e)
        {
            sBodyLSticker = txt_Barcode.Text;
            BindData(sBodyLSticker);
        }

        private void lbl_CarCode_Click(object sender, EventArgs e)
        {
            if (pnl_Barcode.Visible)
            {
                pnl_Barcode.Enabled = false;
                pnl_Barcode.Visible = false;
            }
            else
            {
                pnl_Barcode.Enabled = true;
                pnl_Barcode.Visible = true;
                txt_Barcode.Focus();
            }
        }

        private void timer_complete_check_Tick(object sender, EventArgs e)
        {
            Complete_Check();                                     
        }
        private void Complete_Check()
        {
            DataSet ds;
            string sTR_ID = "";
            try
            {
                //IniReadValue = cFilehandle.IniReadValue("LINE_INFO", "BODY_NO", "");
                int Ok_Result_Cnt = 0;
                ds = new DataSet();
                if (EquipInfo.Virtual == false)
                {
                    Procedure.PPC_WORK_KEEPER(EquipInfo.WORKCENTER, sBodyLSticker, ref ds);
                }
                else
                {
                    Procedure.PPC_VIRTUAL_WORK_KEEPER(EquipInfo.WORKCENTER, sBodyLSticker, ref ds);
                }
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (ds.Tables[0].Rows[i]["OK_RESULT"].ToString() == "OK" || ds.Tables[0].Rows[i]["OK_RESULT"].ToString() == "통과"
                            || ds.Tables[0].Rows[i]["OK_RESULT"].ToString() == "재작업" || ds.Tables[0].Rows[i]["OK_RESULT"].ToString() == "MASTER")
                        {
                            Ok_Result_Cnt += 1;
                        }
                    }
                    if (sBodyLSticker == "" && IniReadValue == "")
                    {
                        lbl_Msg.Text = "BODY_NO 서열 정보 없음!";
                    }
                    else
                    {
                        if (End_Flag == true)
                        {
                            if ((ds.Tables[0].Rows.Count) == Ok_Result_Cnt)
                            {
                                //if (IniReadValue != sBodyLSticker)
                                //{
                                cFilehandle.IniWriteValue("LINE_INFO", "BODY_NO", sBodyLSticker);
                                //}
                                lbl_Msg.Text = "완성 검사 완료!";
                                //PARAM(RE_WR_VALUE)에 정보 넣기
                                //Comm_IDSet();

                                BindData(sBodyLSticker);

                                ds = new DataSet();
                                if (EquipInfo.Virtual == false)
                                {
                                    Procedure.PPC_TRID(EquipInfo.WORKCENTER, EquipInfo.ORDER_DATE, lbl_Commit_No.Text, lbl_Body_No.Text, ref ds);
                                }
                                else
                                {
                                    Procedure.PPC_VIRTUAL_TRID(EquipInfo.WORKCENTER, EquipInfo.ORDER_DATE, lbl_Commit_No.Text, lbl_Body_No.Text, ref ds);
                                }
                                sTR_ID = ds.Tables[0].Rows[0]["TR_ID"].ToString();
                                if (EquipInfo.Virtual == false)
                                {
                                    Procedure.PPC_WORK_COMPLETE(EquipInfo.WORKCENTER, EquipInfo.ROUTE_NO, sTR_ID, "K");
                                }
                                else
                                {
                                    Procedure.PPC_VIRTUAL_WORK_COMPLETE(EquipInfo.WORKCENTER, EquipInfo.ROUTE_NO, sTR_ID, "K");
                                }
                                //완료 TAG 넣기
                                NetRemoting.TagSet(EquipInfo.WORKCENTER + "_" + EquipInfo.ROUTE_NO + "_END", "0001");

                                End_Flag = false;
                                System.Threading.Thread.Sleep(500); 
                            }
                            else
                            {
                                lbl_Msg.Text = "완성 검사 체크...";
                            }
                        }
                    }
                }
                ds.Dispose();
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWorkeeper] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
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
                //메세지폼에서 TAG정보를 비교한다.
                //frmMsg = new frmMsg("TAG", "TAG에 BODY 정보를 기록 중 입니다.");
                //frmMsg.ShowDialog();
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWorkeeper] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }
        private void timer_load_Tick(object sender, EventArgs e)
        {
            if (chb_Timer.Checked != true)
            {
                FormLoad();
            }
        }

        private void btnBad_Click(object sender, EventArgs e)
        {
            if (EquipInfo.EMP != "")
            {
                frmWorkKeeper_BadFormLoad();
                frmWorkKeeper_Bad_Close();
            }
            else
            {
                MassageFormLoad("NG", "검사자를 선택하세요.");
            }

        }

        private void frmWorkKeeper_BadFormLoad()
        {
            try
            {
                if (frmWorkKeeper_Bad == null)
                {

                    frmWorkKeeper_Bad = new frmWorkKeeper_Bad();
                    frmWorkKeeper_Bad_Set(frmWorkKeeper_Bad);
                }
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWorkKeeper] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }

        private void frmWorkKeeper_BadHistFormLoad()
        {
            try
            {
                if (frmWorkKeeper_BadHist == null)
                {

                    frmWorkKeeper_BadHist = new frmWorkKeeper_BadHist();
                    frmWorkKeeper_BadHist_Set(frmWorkKeeper_BadHist);
                }
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWorkKeeper] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }

        private void frmWorkKeeper_Bad_Set(Form _KeeperBad)
        {
            try
            {
                if (this.InvokeRequired)
                    this.Invoke(new KeeperBad(frmWorkKeeper_Bad_Set), new object[] { _KeeperBad });
                else
                    frmWorkKeeper_Bad.ShowDialog();
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWorkStart] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }
        private void frmWorkKeeper_BadHist_Set(Form _KeeperBadHist)
        {
            try
            {
                if (this.InvokeRequired)
                    this.Invoke(new KeeperBadHist(frmWorkKeeper_BadHist_Set), new object[] { _KeeperBadHist });
                else
                    frmWorkKeeper_BadHist.ShowDialog();
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWorkStart] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }
        private void frmWorkKeeper_Bad_Close()
        {
            if (frmWorkKeeper_Bad != null)
            {
                frmWorkKeeper_Bad.Close();
                frmWorkKeeper_Bad = null;
            }
        }
        private void frmWorkKeeper_BadHist_Close()
        {
            if (frmWorkKeeper_BadHist != null)
            {
                frmWorkKeeper_BadHist.Close();
                frmWorkKeeper_BadHist = null;
            }
        }

        private void OptEmp1_CheckedChanged(object sender, EventArgs e)
        {
            EquipInfo.EMP = OptEmp1.Text;
        }

        private void OptEmp2_CheckedChanged(object sender, EventArgs e)
        {
            EquipInfo.EMP = OptEmp2.Text;
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
                slog = DateTime.Now + "[frmWork_Stark_FEM] :      " + ex;
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
                slog = DateTime.Now + "[frmWorkKeeper] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }

        private void btnHist_Click(object sender, EventArgs e)
        {
            frmWorkKeeper_BadHistFormLoad();
            frmWorkKeeper_BadHist_Close();
        }
    }
}
