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
using System.IO.Ports;

namespace MOBISDAS.Forms
{
    public partial class frmWorkDailyInspection : Form
    {
        private string slog = "";
        private string tBarCode = null;
        //SERIAL 변수
        private string Serial_Port = "";
        private string Serial_Set = "";
        private string serialPortRECEIVE_DATA = "";

        private bool First_data = false;
        private bool Scan_Flag = false;
        private string commStatus = "";
        private int tgdToolRecvCnt = 0;
        private string ToolType = "";

        public frmWorkDailyInspection()
        {            
            InitializeComponent();               
        }

        private void frmWorkDailyInspection_Shown(object sender, EventArgs e)
        {
            BindData();
            SerialPortOpen();
            dataGridView_InspSet(ref dataGridView_Insp);
            TagSet();
        }

        private void TagSet()
        {
            for (int i = 0; i < dataGridView_Insp.Rows.Count; i++)
            {
                if (dataGridView_Insp.Rows[i].Cells["@@WORK_TYPE"].Value.ToString().Contains("A"))
                {
                    DataSet ds = new DataSet();
                    Procedure.PPC_LOAD_TOOL_TYPE(EquipInfo.WORKCENTER, EquipInfo.ROUTE_NO, ref ds);

                    if (ds.Tables[0].Rows.Count > 0)
                        ToolType = ds.Tables[0].Rows[0]["TOOL_TYPE"].ToString();

                    if(ToolType == "ATOOL")
                        NetRemoting.TagSet(EquipInfo.WORKCENTER + "_" + EquipInfo.ROUTE_NO + "_ATOOL", "S");
                    if (ToolType == "ATOOL2")
                        NetRemoting.TagSet(EquipInfo.WORKCENTER + "_" + EquipInfo.ROUTE_NO + "_ATOOL2", "S");
                    Dabom.TagAdapter.Item.WorkDataUp datup = new Dabom.TagAdapter.Item.WorkDataUp(EquipInfo.WORKCENTER + "_" + EquipInfo.ROUTE_NO, true);
                    datup.Variables.Add("TOOL_VALUE", new VariableItem { VarID = "TOOL_VALUE", Value = "" });
                    datup.Variables.Add("TOOL_MAX", new VariableItem { VarID = "TOOL_MAX", Value = "50" });
                    datup.Variables.Add("TOOL_MIN", new VariableItem { VarID = "TOOL_MIN", Value = "1" });
                    datup.Variables.Add("TR_ID", new VariableItem { VarID = "TR_ID", Value = "" });
                    NetRemoting.Comm_IDSet(datup);

                    tmrToolCheck.Enabled = true;
                }
            }
        }

        private void ProcessToolCheck()
        {
            try
            {
                int ArryCount = 0;
                commStatus = NetRemoting.Comm_IDGet(EquipInfo.WORKCENTER + "_" + EquipInfo.ROUTE_NO);
                if (commStatus != null)
                {
                    Dictionary<string, Dabom.TagAdapter.Item.VariableItem> mVariableItems = (new Dabom.TagAdapter.StateParse(commStatus)).ToVariableItems();//DICTIONARY 넣기

                    string[] Tool_Value = mVariableItems["TOOL_VALUE"].Value.ToString().Split(':');

                    if (Tool_Value[0].Equals("") && Tool_Value.Length == 1)
                        ArryCount = 0;
                    else
                        ArryCount = Tool_Value.Length;

                    if (ArryCount != 0)
                    {
                        if (Tool_Value[ArryCount - 1].ToString().Split('_')[1].ToString() != "")
                        {
                            lblWorkType.Text = "A0001";
                            lblWorkValue.Text = Tool_Value[ArryCount - 1].ToString().Split('_')[1].ToString();

                            Dabom.TagAdapter.Item.WorkDataUp datup = new Dabom.TagAdapter.Item.WorkDataUp(EquipInfo.WORKCENTER + "_" + EquipInfo.ROUTE_NO, true);
                            datup.Variables.Add("TOOL_VALUE", new VariableItem { VarID = "TOOL_VALUE", Value = "" });
                            datup.Variables.Add("TOOL_MAX", new VariableItem { VarID = "TOOL_MAX", Value = "" });
                            datup.Variables.Add("TOOL_MIN", new VariableItem { VarID = "TOOL_MIN", Value = "" });
                            datup.Variables.Add("TR_ID", new VariableItem { VarID = "TR_ID", Value = "" });
                            NetRemoting.Comm_IDSet(datup);
                            tmrToolCheck.Enabled = false;
                                    
                        }
                    }                    
                }
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWorkDailyInspection] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }


        private void BindData()
        {
            SerialPortClose();
            DataSet ds = new DataSet();
            Procedure.PPC_LINE_INFO2(EquipInfo.WORKCENTER, EquipInfo.ROUTE_NO, ref ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lbl_OrderDate.Text = ds.Tables[0].Rows[0]["@@TODY"].ToString();
                lbl_WC_NAME.Text = ds.Tables[0].Rows[0]["@@WC_NAME"].ToString();
                lbl_RouteNo.Text = ds.Tables[0].Rows[0]["@@ROUTE_NO"].ToString();

                Serial_Port = ds.Tables[0].Rows[0]["@@PORT"].ToString().Trim();
                Serial_Set = ds.Tables[0].Rows[0]["@@SETTING"].ToString().Trim();

                //시리얼 세팅 로그 추가 20181026 김진성
                slog = DateTime.Now + "[frmWorkDailyInspection - BindData] :  " + Serial_Port + ":" + Serial_Set; 
                Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                //로그 추가 END

                dataGridView_Insp.RowTemplate = null;
                dataGridView_Insp.DataSource = ds.Tables[0];
                BinddataGridView_InspSet(ref dataGridView_Insp);
            }
            else
            {
                this.Close();
            }

        }
        //시리얼 포트연결
        public void SerialPortOpen()
        {
            try
            {
                //시리얼 세팅 로그 추가 20181026 김진성
                slog = DateTime.Now + "[frmWorkDailyInspection - SerialPortOpen, SerialPortSetting 실행 전] :  " + Serial_Port + ":" + Serial_Set;
                Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                //로그 추가 END

                SerialPortSetting(ref serialPort1, "COM" + Serial_Port, Serial_Set);

                //시리얼 세팅 로그 추가 20181026 김진성
                slog = DateTime.Now + "[frmWorkDailyInspection - SerialPortOpen, SerialPortSetting 실행 후] :  " + Serial_Port + ":" + Serial_Set;
                Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                //로그 추가 END

                if (!serialPort1.IsOpen)
                {
                    serialPort1.Open();
                    //시리얼 세팅 로그 추가 20181026 김진성
                    slog = DateTime.Now + "[frmWorkDailyInspection - SerialPortOpen, serialPort1.Open() 완료] :  " + Serial_Port + ":" + Serial_Set;
                    Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                    //로그 추가 END
                }


            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWorkDailyInspection - SerialPortOpen] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }

        //시리얼 포트 끊기
        public void SerialPortClose()
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                    System.Threading.Thread.Sleep(500); //시리얼포트의 연결 끊기 딜레이 추가(0.5s) 20181019 김진성

                    //시리얼포트 연결끊기 로그 추가 20181019 김진성
                    slog = DateTime.Now + "[frmWorkDailyInspection : SerialPortClose 시리얼 포트 끊기] : " + Serial_Port + ":" + Serial_Set;
                    Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                }
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWorkDailyInspection - SerialPortClose] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }

        /// <summary>SerialPort Setting</summary>
        private static void SerialPortSetting(ref SerialPort serialPort, string SERIAL_PORT, string SERIAL_SET)
        {
            serialPort.PortName = SERIAL_PORT;
            string[] serialPortSet = SERIAL_SET.Split(',');
            serialPort.BaudRate = Convert.ToInt32(serialPortSet[0]);
            if (serialPortSet[1] == "e")
                serialPort.Parity = Parity.None;
            else if (serialPortSet[1] == "m")
                serialPort.Parity = Parity.Mark;
            else if (serialPortSet[1] == "n" || serialPortSet[1] == "N")
                serialPort.Parity = Parity.None;
            else if (serialPortSet[1] == "o")
                serialPort.Parity = Parity.Odd;
            else if (serialPortSet[1] == "s")
                serialPort.Parity = Parity.Space;

            serialPort.DataBits = Convert.ToInt32(serialPortSet[2]);

            if (serialPortSet[3] == "0")
                serialPort.StopBits = StopBits.None;
            else if (serialPortSet[3] == "1")
                serialPort.StopBits = StopBits.One;
            else if (serialPortSet[3] == "1.5")
                serialPort.StopBits = StopBits.OnePointFive;
            else if (serialPortSet[3] == "2")
                serialPort.StopBits = StopBits.Two;
        }

        private void dataGridView_InspSet(ref DataGridView dataGridView)
        {
            try
            {
                //  그리드 Header 설정
                dataGridView.EnableHeadersVisualStyles = false;
                dataGridView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("HY견고딕", 32.00F, FontStyle.Bold);
                dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.CornflowerBlue;
                dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                dataGridView.ColumnHeadersHeight = 60;
                //  GRID BASE SETTING
                dataGridView.AllowUserToAddRows = false;
                dataGridView.AllowUserToDeleteRows = false;
                dataGridView.AllowUserToResizeRows = false;
                dataGridView.ColumnHeadersVisible = true;
                dataGridView.RowHeadersVisible = false;
                dataGridView.AllowUserToResizeColumns = false;
                dataGridView.ReadOnly = true;
                dataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGridView.BorderStyle = BorderStyle.FixedSingle;
                dataGridView.Margin = new Padding(0, 0, 0, 0);
                dataGridView.ScrollBars = ScrollBars.None;
                dataGridView.ShowCellToolTips = false;

                dataGridView.DefaultCellStyle.Font = new System.Drawing.Font("HY견고딕", 45.00F, FontStyle.Bold);
                dataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //  DefaultCellStyle SETTING
                dataGridView.DefaultCellStyle.BackColor = Color.White;
                dataGridView.DefaultCellStyle.ForeColor = Color.Black;
                //dataGridView.DefaultCellStyle.SelectionBackColor = dataGridView.DefaultCellStyle.BackColor;
                //dataGridView.DefaultCellStyle.SelectionForeColor = dataGridView.DefaultCellStyle.ForeColor;

                dataGridView.BorderStyle = BorderStyle.Fixed3D;
                dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWorkDailyInspection] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }

        }

        private void BinddataGridView_InspSet(ref DataGridView dataGridView)
        {
            try
            {
                if (dataGridView.Columns.Count == 0)
                    return;
                for (int i = 0; i < dataGridView.Columns.Count; i++)
                {
                    dataGridView.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                    if (dataGridView.Columns[i].HeaderText.Substring(0, 2) == "@@")
                    {
                        dataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                        dataGridView.Columns[i].Visible = false;
                        dataGridView.Columns[i].Width = 0;
                    }
                }
                dataGridView.Columns[4].Width = dataGridView.Width * 30 / 100;
                dataGridView.Columns[5].Width = dataGridView.Width * 25 / 100;
                dataGridView.Columns[6].Width = dataGridView.Width * 25 / 100;
                dataGridView.Columns[7].Width = dataGridView.Width * 10 / 100;
                // 20141002 유민호 추가부분
                dataGridView.Columns[8].Width = dataGridView.Width * 10 / 100;
                //행 높이
                int iColumnHeaderHeight = 0;
                if (dataGridView.ColumnHeadersVisible == true)
                {
                    iColumnHeaderHeight = dataGridView.ColumnHeadersHeight;
                }
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    int iRowsHeight = (dataGridView.Height - iColumnHeaderHeight) / dataGridView.Rows.Count;
                    dataGridView.Rows[i].Height = iRowsHeight;
                    dataGridView.Rows[i].Cells["점검방법"].Style.Font = new System.Drawing.Font("HY견고딕", 22.00F, FontStyle.Bold);
                    dataGridView.Rows[i].Cells["검사명"].Style.Font = new System.Drawing.Font("HY견고딕", 22.00F, FontStyle.Bold);
                    dataGridView.Rows[i].Cells["검사값"].Style.Font = new System.Drawing.Font("HY견고딕", 22.00F, FontStyle.Bold);
                    dataGridView.Rows[i].Cells["OK"].Style.Font = new System.Drawing.Font("HY견고딕", 22.00F, FontStyle.Bold);
                    // 20141002 유민호 추가부분
                    dataGridView.Rows[i].Cells["NG"].Style.Font = new System.Drawing.Font("HY견고딕", 22.00F, FontStyle.Bold);
                    dataGridView.Rows[i].Cells["OK"].Style.BackColor = Color.Blue;
                    dataGridView.Rows[i].Cells["OK"].Style.ForeColor = Color.White;
                    dataGridView.Rows[i].Cells["NG"].Style.BackColor = Color.Red;
                    dataGridView.Rows[i].Cells["NG"].Style.ForeColor = Color.White;

                }
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWorkDailyInspection] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }

      


        private void dataGridView_Insp_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == 7 || e.ColumnIndex == 8)
                return;
            if (dataGridView_Insp.Rows[e.RowIndex].Cells["@@WORK_TYPE"].Value.ToString().Contains("B"))
            {
                pnl_Barcode.Visible = true;
            }

            else
            {
                lblWorkType.Text = dataGridView_Insp.Rows[e.RowIndex].Cells["@@WORK_TYPE"].Value.ToString();
                frmNumer frmNumer = new frmNumer(lblWorkValue);
                frmNumer.ShowDialog();
            }
        }

        private void frmWorkDailyInspection_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                //메모리 해제 구문 추가 20181023 김진성
                GC.Collect();
                //구문 추가 END

                SerialPortClose();
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWorkDailyInspection_FormClosing] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SerialPortClose();
            this.Close();
        }

        private void btn_Bar_OK_Click(object sender, EventArgs e)
        {
            tBarCode = txt_Barcode.Text;
            pnl_Barcode.Visible = false;
            ProcessJob();
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string buff = serialPort1.ReadExisting();

                serialPortRECEIVE_DATA += buff;

                if (buff.IndexOf("\r\n") > -1)
                {
                    txt_ReciveData.Focus();
                    txt_ReciveData.Text = serialPortRECEIVE_DATA;
                    serialPortRECEIVE_DATA = "";
                }
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWorkDailyInspection] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }

        private void txt_ReciveData_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txt_ReciveData.Text.IndexOf("\r\n") != -1)
                {
                    tBarCode = txt_ReciveData.Text.Replace("\r\n", "");

                    //////
                    slog = DateTime.Now + "[frmWorkDailyInspection 스캔 바코드] :      " + tBarCode;
                    Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                    ////// 

                    ProcessJob();
                    
                    txt_ReciveData.Text = "";
                }
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWorkStart] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }


        private void ProcessJob()
        {
            
            if (tBarCode != "" && tBarCode != null)
            {
                for (int i = 0; i < dataGridView_Insp.Rows.Count; i++)
                {
                    if (dataGridView_Insp.Rows[i].Cells["@@WORK_TYPE"].Value.ToString().Contains("B"))
                    {
                        if (tBarCode != "TEST")
                        {
                            dataGridView_Insp.Rows[i].Cells["검사값"].Value = tBarCode;
                            dataGridView_Insp.Rows[i].Cells["OK"].Value = "";
                            dataGridView_Insp.Rows[i].Cells["NG"].Value = "NG";

                            Procedure.PPC_DAILY_INSP_SAVE(lbl_OrderDate.Text,
                            EquipInfo.WORKCENTER,
                            EquipInfo.ROUTE_NO,
                            dataGridView_Insp.Rows[i].Cells["@@WORK_TYPE"].Value.ToString(),
                            dataGridView_Insp.Rows[i].Cells["검사값"].Value.ToString());
                            // 20141006 유민호 추가 부분
                            dataGridView_Insp.Rows[i].Cells["검사값"].Style.ForeColor = Color.Red;
                            tBarCode = "";
                        }
                        else
                        {
                            dataGridView_Insp.Rows[i].Cells["검사값"].Value = tBarCode;
                            dataGridView_Insp.Rows[i].Cells["OK"].Value = "OK";
                            dataGridView_Insp.Rows[i].Cells["NG"].Value = "";

                            Procedure.PPC_DAILY_INSP_SAVE(lbl_OrderDate.Text,
                            EquipInfo.WORKCENTER,
                            EquipInfo.ROUTE_NO,
                            dataGridView_Insp.Rows[i].Cells["@@WORK_TYPE"].Value.ToString(),
                            dataGridView_Insp.Rows[i].Cells["검사값"].Value.ToString());

                            // 20141006 유민호 추가 부분
                            dataGridView_Insp.Rows[i].Cells["검사값"].Style.ForeColor = Color.Blue;

                            tBarCode = "";
                        }
                    }
                }

            }

            if (lblWorkValue.Text != "" && lblWorkType.Text != "")
            {
                for (int i = 0; i < dataGridView_Insp.Rows.Count; i++)
                {
                    if (dataGridView_Insp.Rows[i].Cells["@@WORK_TYPE"].Value.ToString() == lblWorkType.Text)
                    {
                        dataGridView_Insp.Rows[i].Cells["검사값"].Value = lblWorkValue.Text;
                        if (lblWorkValue.Text.Contains("OK"))
                        {
                            dataGridView_Insp.Rows[i].Cells["OK"].Value = "OK";
                            dataGridView_Insp.Rows[i].Cells["NG"].Value = "";
                            // 20141006 유민호 추가 부분
                            dataGridView_Insp.Rows[i].Cells["검사값"].Style.ForeColor = Color.Blue;
                            
                            dataGridView_Insp.EndEdit();
                        }
                        else if (lblWorkValue.Text.Contains("NG"))
                        {
                            dataGridView_Insp.Rows[i].Cells["OK"].Value = "";
                            dataGridView_Insp.Rows[i].Cells["NG"].Value = "NG";
                            // 20141006 유민호 추가 부분
                            dataGridView_Insp.Rows[i].Cells["검사값"].Style.ForeColor = Color.Red;
                            dataGridView_Insp.EndEdit();
                        }
                        else if (lblWorkType.Text.Contains("A") || lblWorkType.Text.Contains("T"))
                        {
                            DataSet ds = new DataSet();
                            Procedure.PPC_Daily_Spect_Check(EquipInfo.WORKCENTER,lblWorkType.Text.Trim(), ref ds);
                            if (ds != null && ds.Tables[0].Rows.Count > 0)
                            {
                                if (ds.Tables[0].Rows[0]["상한값"].ToString() == "0" && ds.Tables[0].Rows[0]["하한값"].ToString() == "0")
                                {
                                    dataGridView_Insp.Rows[i].Cells["OK"].Value = "OK";
                                    dataGridView_Insp.Rows[i].Cells["NG"].Value = "";
                                    // 20141006 유민호 추가 부분
                                    dataGridView_Insp.Rows[i].Cells["검사값"].Style.ForeColor = Color.Blue;
                                    dataGridView_Insp.EndEdit();
                                }
                                else
                                {
                                    if (Convert.ToDouble(lblWorkValue.Text) <= Convert.ToDouble(ds.Tables[0].Rows[0]["상한값"].ToString())
                                        && Convert.ToDouble(lblWorkValue.Text) >= Convert.ToDouble(ds.Tables[0].Rows[0]["하한값"].ToString()))
                                    {
                                        dataGridView_Insp.Rows[i].Cells["OK"].Value = "OK";
                                        dataGridView_Insp.Rows[i].Cells["NG"].Value = "";
                                        // 20141006 유민호 추가 부분
                                        dataGridView_Insp.Rows[i].Cells["검사값"].Style.ForeColor = Color.Blue;
                                        dataGridView_Insp.EndEdit();
                                    }
                                    else
                                    {
                                        dataGridView_Insp.Rows[i].Cells["OK"].Value = "";
                                        dataGridView_Insp.Rows[i].Cells["NG"].Value = "NG";
                                        // 20141006 유민호 추가 부분
                                        dataGridView_Insp.Rows[i].Cells["검사값"].Style.ForeColor = Color.Red;
                                        dataGridView_Insp.EndEdit();
                                    }

                                }
                            }


                        }
                        

                        Procedure.PPC_DAILY_INSP_SAVE(lbl_OrderDate.Text,
                        EquipInfo.WORKCENTER,
                        EquipInfo.ROUTE_NO,
                        dataGridView_Insp.Rows[i].Cells["@@WORK_TYPE"].Value.ToString(),
                        dataGridView_Insp.Rows[i].Cells["검사값"].Value.ToString());

                        //if (lblWorkType.Text == "T")
                        if (lblWorkType.Text == "A0001")
                        {
                            if (ToolType == "ATOOL")
                                NetRemoting.TagSet(EquipInfo.WORKCENTER + "_" + EquipInfo.ROUTE_NO + "_ATOOL", "E");
                            if (ToolType == "ATOOL2")
                                NetRemoting.TagSet(EquipInfo.WORKCENTER + "_" + EquipInfo.ROUTE_NO + "_ATOOL2", "E");
                        }

                        lblWorkType.Text = "";
                        lblWorkValue.Text = "";
                    }
                }
            }
            // 2014-02-12  유민호 추가 부분
            int Ok_Cnt = 0;
            for (int i = 0; i < dataGridView_Insp.Rows.Count; i++)
            {
                if (dataGridView_Insp.Rows[i].Cells["OK"].Value.ToString() == "OK")
                {
                    Ok_Cnt++;
                }
            }
            if (dataGridView_Insp.Rows.Count == Ok_Cnt)
            {
                SerialPortClose();
                this.Close();
            }
        }

        private void lblWorkValue_TextChanged(object sender, EventArgs e)
        {
            ProcessJob();
        }

        private void tmrToolCheck_Tick(object sender, EventArgs e)
        {
            ProcessToolCheck();
        }

        private void dataGridView_Insp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView_Insp.Rows[e.RowIndex].Cells["점검방법"].Value.ToString() == "육안"
                  || dataGridView_Insp.Rows[e.RowIndex].Cells["점검방법"].Value.ToString() == "작동"
                    || dataGridView_Insp.Rows[e.RowIndex].Cells["점검방법"].Value.ToString() == "압력계"
                        || dataGridView_Insp.Rows[e.RowIndex].Cells["점검방법"].Value.ToString() == "온도계")
            {

                lblWorkType.Text = dataGridView_Insp.Rows[e.RowIndex].Cells["@@WORK_TYPE"].Value.ToString();
                // 20141002 유민호 추가부분
                if (e.ColumnIndex == 8 && dataGridView_Insp.Rows[e.RowIndex].Cells["점검방법"].Value.ToString() != "압력계" && dataGridView_Insp.Rows[e.RowIndex].Cells["점검방법"].Value.ToString() != "온도계")
                {
                    lblWorkValue.Text = "NG";
                    dataGridView_Insp.Rows[e.RowIndex].Cells["검사값"].Value = "NG";
                    dataGridView_Insp.Rows[e.RowIndex].Cells["NG"].Value = "NG";
                    dataGridView_Insp.Rows[e.RowIndex].Cells["OK"].Value = "";
                }
                else if (e.ColumnIndex == 7 && dataGridView_Insp.Rows[e.RowIndex].Cells["점검방법"].Value.ToString() != "압력계" && dataGridView_Insp.Rows[e.RowIndex].Cells["점검방법"].Value.ToString() != "온도계")
                {
                    lblWorkValue.Text = "OK";
                    dataGridView_Insp.Rows[e.RowIndex].Cells["검사값"].Value = "OK";
                    dataGridView_Insp.Rows[e.RowIndex].Cells["OK"].Value = "OK";
                    dataGridView_Insp.Rows[e.RowIndex].Cells["NG"].Value = "";
                }
                else if (e.ColumnIndex == 8 && dataGridView_Insp.Rows[e.RowIndex].Cells["점검방법"].Value.ToString() == "압력계" || dataGridView_Insp.Rows[e.RowIndex].Cells["점검방법"].Value.ToString() == "온도계")
                {
                    lblWorkValue.Text = "NG";
                    dataGridView_Insp.Rows[e.RowIndex].Cells["검사값"].Value = "NG";
                    dataGridView_Insp.Rows[e.RowIndex].Cells["NG"].Value = "NG";
                    dataGridView_Insp.Rows[e.RowIndex].Cells["OK"].Value = "";
                }
                ProcessJob();
            }

            dataGridView_Insp.ClearSelection();

        }
        
    }
}
