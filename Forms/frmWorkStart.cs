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
using System.IO.Ports;
using Dabom.TagAdapter.Item;
using System.IO;

namespace MOBISDAS.Forms
{
    public partial class frmWorkStart : frmLoad
    {
        private string FileName = null;
        private string tBarCode = "";
        private string tWorkType = "";
        //private int ComPleteCnt = 0;
        private string Tool_Type = "";

        private frmMsg frmMsg = null;
        private frmWorkTool frmWorkTool = null;
        private frmWorkElectricTool frmWorkElectricTool = null;
        private frmWorkInspection frmWorkInspection = null;

        public delegate void WorkInpection(Form WorkInspection);
        public delegate void LabelSet(string LabelText);
        public delegate void TextSet(string Text);
        public delegate void WorkToll(Form WorkToll);
        public delegate void WorkMsg(Form WorkMsg);

        private int gdTotalCnt = 0; //그리드 총 ROW 수량
        private string slog = "";
        //private string Assy_Msg = "";    

        //  Serial Port 변수
        private string Serial_Port = "";
        private string Serial_Set = "";
        private string serialPortRECEIVE_DATA = "";
        // 2014 09 15 유민호 추가 부분  
        private string Serial_Port2 = "";
        private string Serial_Set2 = "";

        private bool Scan_Flag = false;

        // Tag End 신호 전송 변수
        private string END = "";
        private bool MPIS_END = false;
        private bool IS_END = false;
        private bool DO_COMPLETE = false;

        public frmWorkStart(mdiMain tMDI)
        {
            TopLevel = false;
            _mdiMain = tMDI;
            InitializeComponent();
            Dock = DockStyle.Fill;
        }

        private void frmWorkStart_Load(object sender, EventArgs e)
        {
            Initialize();
            BindData();
            timer_mpis.Enabled = true;
        }

        private void Initialize()
        {
            Scan_Flag = true;

            dataGridView_AlcSet(ref dataGridView_Alc);

            pnl_Barcode.Enabled = false;
            pnl_Barcode.Visible = false;

            pnl_Main_Load.Enabled = false;
            pnl_Main_Load.Visible = false;
            bnt_main.Enabled = false;
            bnt_main.Visible = false;

            EquipInfo.gdCarrentCnt = 0;
        }

        public void SerialPortOpen()
        {
            try
            {
                SerialPortClose();
                if (Serial_Port != "" && Serial_Set != "")
                {
                    //if (serialPort1 == null)
                    //    serialPort1 = new SerialPort();

                    slog = DateTime.Now + "[frmWorkStart - SerialPortOpen, SerialPortSetting 실행 전] :  " + Serial_Port + ":" + Serial_Set; //시리얼 세팅 log 확인 20181026 김진성
                    Global.EquipInfo.fhLog.TextFileWriteAppend(slog);

                    SerialPortSetting(ref serialPort1, "COM" + Serial_Port, Serial_Set);

                    slog = DateTime.Now + "[frmWorkStart - SerialPortOpen, SerialPortSetting 실행 후] :  " + Serial_Port + ":" + Serial_Set; //시리얼 세팅 log 확인 20181026 김진성
                    Global.EquipInfo.fhLog.TextFileWriteAppend(slog);

                    //EquipInfo.SerialPortSetting(ref serialPort1, "COM" + Serial_Port, Serial_Set);
                    if (!serialPort1.IsOpen)
                    {
                        serialPort1.Open();
                        slog = DateTime.Now + "[frmWorkStart개발자 확인용 Serial1] :  " + Serial_Port + ":" + Serial_Set;
                        Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                    }
                }
               
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWorkStart] :   SerialPortOpen   " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }

        public void SerialPortOpen2()
        {
            try
            {

                SerialPortClose2();
                if (Serial_Port2 != "" && Serial_Set2 != "")
                {
                    slog = DateTime.Now + "[frmWorkStart - SerialPortOpen2, SerialPortSetting 실행 전] :  " + Serial_Port + ":" + Serial_Set; //시리얼 세팅 log 확인 20181026 김진성
                    Global.EquipInfo.fhLog.TextFileWriteAppend(slog);

                    SerialPortSetting(ref serialPort2, "COM" + Serial_Port2, Serial_Set2);

                    slog = DateTime.Now + "[frmWorkStart - SerialPortOpen2, SerialPortSetting 실행 후] :  " + Serial_Port + ":" + Serial_Set; //시리얼 세팅 log 확인 20181026 김진성
                    Global.EquipInfo.fhLog.TextFileWriteAppend(slog);

                    if (!serialPort2.IsOpen)
                    {
                        serialPort2.Open();
                        slog = DateTime.Now + "[frmWorkStart개발자 확인용  Serial2] : " + Serial_Port2 + ":" + Serial_Set2;
                        Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                    }
                }
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWorkStart] :   SerialPortOpen   " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }
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
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (tWorkType == "B")
                {
                    System.Threading.Thread.Sleep(200);
                    string buff = serialPort1.ReadExisting();

                    serialPortRECEIVE_DATA += buff;

                    if (buff.IndexOf("\r\n") > -1)
                    {
                        //txt_ReciveData.Focus();
                        tBarCode = serialPortRECEIVE_DATA.Replace("\r\n", "");
                        //slog = DateTime.Now + "[serialPort1_DataReceived-개발자확인] :      " + tBarCode;
                        //Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                        ProcessJob();
                        //txt_ReciveData.Text = serialPortRECEIVE_DATA;                   
                        serialPortRECEIVE_DATA = "";
                    }
                }
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWorkStart_SERIAL1] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }

        private void serialPort2_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                
               // slog = DateTime.Now + "[serialPort2_DataReceived-개발자확인1] :      " + "tBarCode:" + tBarCode + "//tWorkType:" + tWorkType;
                //Global.EquipInfo.fhLog.TextFileWriteAppend(slog);

                if (tWorkType == "B")
                {
                    System.Threading.Thread.Sleep(200);
                    string buff = serialPort2.ReadExisting();

                    serialPortRECEIVE_DATA += buff;
                    //slog = DateTime.Now + "[serialPort2_DataReceived-개발자확인2] :      " + serialPortRECEIVE_DATA; 
                    //Global.EquipInfo.fhLog.TextFileWriteAppend(slog);

                    if (buff.IndexOf("\r\n") > -1)
                    {
                        //txt_ReciveData.Focus();
                        tBarCode = serialPortRECEIVE_DATA.Replace("\r\n", "");
                        //slog = DateTime.Now + "[serialPort2_DataReceived-개발자확인3] :      " + tBarCode;
                        //Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                        ProcessJob();
                        //slog = DateTime.Now + "[serialPort2_DataReceived-개발자확인4] :      " + tBarCode;
                        //Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                        
                        //txt_ReciveData.Text = serialPortRECEIVE_DATA;                   
                        serialPortRECEIVE_DATA = "";
                    }
                }
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWorkStart_SERIAL2] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }

        public void SerialPortClose()
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                    System.Threading.Thread.Sleep(500); //시리얼포트의 연결 끊기 딜레이 추가(0.5s) 20181019 김진성

                    //시리얼포트 연결끊기 로그 추가 20181019 김진성
                    slog = DateTime.Now + "[frmWorkStart : SerialPortClose 시리얼 포트 끊기] : " + Serial_Port + ":" + Serial_Set;
                    Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                }
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWorkStart] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }
        public void SerialPortClose2()
        {
            try
            {
                //slog = DateTime.Now + "[frmWorkStart개발자 확인용  Serial2_CLOSE] : " + Serial_Port2 + ":" + Serial_Set2;
                //Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                if (serialPort2.IsOpen)
                {
                    serialPort2.Close();
                    System.Threading.Thread.Sleep(500); //시리얼포트의 연결 끊기 딜레이 추가(0.5s) 20181019 김진성

                    //시리얼포트 연결끊기 로그 추가 20181019 김진성
                    slog = DateTime.Now + "[frmWorkStart : SerialPortClose2 시리얼 포트 끊기] : " + Serial_Port2 + ":" + Serial_Set2 ;
                    Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                }
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWorkStart2] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }
        private void BindData()
        {
            DataSet ds;
            int ds_Count = 0;
            try
            {
                // TR_ID가 변경이 될 가능성이 있어 다시 한번 더 TR_ID를 조회한다.
                //ds = new DataSet();
                //Procedure.PPC_TRID(EquipInfo.WORKCENTER, EquipInfo.ORDER_DATE, EquipInfo.CMT, EquipInfo.BODY_NO, ref ds);
                //if (ds.Tables[0].Rows.Count > 0)
                //{
                //    EquipInfo.TR_ID = ds.Tables[0].Rows[0]["TR_ID"].ToString();
                //}

                // 유민호 추가 
                EquipInfo.H_CAR_CODE = EquipInfo.CAR_CODE;

                if (EquipInfo.W_TR_ID != "" && (EquipInfo.W_TR_ID != EquipInfo.TR_ID))
                {
                    EquipInfo.TR_ID = EquipInfo.W_TR_ID;
                }

                //상단에 표시
                lbl_OrderDate.Text = EquipInfo.ORDER_DATE;
                lbl_Commit.Text = EquipInfo.CMT;
                lbl_BodyNo.Text = EquipInfo.BODY_NO;

                //작업리스트
                ds = new DataSet();
                if (EquipInfo.Virtual == false)
                {
                    Procedure.PPC_MAINDETAIL_LIST(EquipInfo.WORKCENTER, EquipInfo.ROUTE_NO, EquipInfo.CAR_CODE, EquipInfo.TR_ID, "W", ref ds);
                }
                else
                {
                    Procedure.PPC_VIRTUAL_MAINDETAIL_LIST(EquipInfo.WORKCENTER, EquipInfo.ROUTE_NO, EquipInfo.CAR_CODE, EquipInfo.TR_ID, "W", ref ds);
                }
                //////
                slog = DateTime.Now + "[frmWorkStart 작업표시 SP] :      " + EquipInfo.WORKCENTER + "/" + EquipInfo.ROUTE_NO + "/" + EquipInfo.CAR_CODE + "/" + EquipInfo.TR_ID + "/" + "W";
                Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                //////                                      

                ds_Count = ds.Tables[0].Rows.Count;

                if (ds_Count > 0)
                {
                    dataGridView_Alc.RowTemplate = null;
                    dataGridView_Alc.DataSource = ds.Tables[0];

                    EquipInfo.ASSY_SEQ = ds.Tables[0].Rows[0]["@@ASSY_SEQ"].ToString();
                    EquipInfo.PART_ID = ds.Tables[0].Rows[0]["@@PART_ID"].ToString();
                    EquipInfo.ALC = ds.Tables[0].Rows[0]["ALC"].ToString();

                    //////
                    slog = DateTime.Now + "[frmWorkStart 첫번째 ALC] :      " + EquipInfo.ASSY_SEQ + "/" + EquipInfo.PART_ID + "/" + EquipInfo.ALC;
                    Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                    ////// 

                    Picture_Load();

                    gdTotalCnt = ds.Tables[0].Rows.Count;

                    //if (gdTotalCnt > 0)
                    //{
                    // 상단 ALC 표시
                    Label_Text_Set(EquipInfo.ALC);
                    //lbl_Alc.Text = EquipInfo.ALC;
                    //
                    BinddataGridView_AlcSet(ref dataGridView_Alc);
                    dataGridView_Alc.Rows[0].DefaultCellStyle.BackColor = Color.Gold;
                    //첫번째 로우가 '-' 면 다음으로 통과 밑에 PROCESSJOB에서 걸러줌                                               

                    if (dataGridView_Alc.Rows[EquipInfo.gdCarrentCnt].Cells["OK"].Value.ToString() != "")
                    {
                        tBarCode = dataGridView_Alc.Rows[EquipInfo.gdCarrentCnt].Cells["OK"].Value.ToString();
                    }
                    //첫번쩨 ROW가 토크 체결이면 체결 화면으로 넘어 감.
                    if (dataGridView_Alc.Rows[EquipInfo.gdCarrentCnt].Cells["@@WORK_TYPE"].Value.ToString() == "T" && EquipInfo.Tool_Cancle_Rtn != "CANCLE")
                    {
                        tWorkType = "T";
                        //tBarCode = "TOOL";
                    }
                    else
                    {
                        tWorkType = "B";
                    }

                    //위에 둘다 아니면 멈춤.
                    //PORT OPEN
                    Serial_Port = ds.Tables[0].Rows[0]["@@PORT"].ToString().Trim();
                    Serial_Set = ds.Tables[0].Rows[0]["@@SETTING"].ToString().Trim();

                    //작업리스트에서 불러오는 시리얼 세팅값 확인 20181026 김진성
                    slog = DateTime.Now + "[frmWorkStart 시리얼 세팅값] :      " + Serial_Port + ":" + Serial_Set;
                    Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                    //확인 구문 END

                    string temp_port = Serial_Port;


                    // 2014 09 15 유민호 추가 부분
                    // serialPort2 추가 부분
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (ds.Tables[0].Rows[i]["@@PORT"].ToString().Trim() != "" && ds.Tables[0].Rows[i]["@@PORT"].ToString().Trim() != temp_port)
                        {
                            Serial_Port2 = ds.Tables[0].Rows[i]["@@PORT"].ToString().Trim();
                            Serial_Set2 = ds.Tables[0].Rows[i]["@@SETTING"].ToString().Trim();

                            //작업리스트에서 불러오는 시리얼 세팅값 확인 20181026 김진성
                            slog = DateTime.Now + "[frmWorkStart 시리얼(serialPort2) 세팅값] :      " + Serial_Port2 + ":" + Serial_Set2;
                            Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                            //확인 구문 END
                            break;
                        }            
                    }

                    SerialPortOpen();
                    SerialPortOpen2();
                    ProcessJob();
                }
                else
                {
                    //작업지시 폼으로       
                    if (EquipInfo.Virtual == false)
                    {
                        Procedure.PPC_WORK_COMPLETE(EquipInfo.WORKCENTER, EquipInfo.ROUTE_NO, EquipInfo.TR_ID, "");
                    }
                    else
                    {
                        Procedure.PPC_VIRTUAL_WORK_COMPLETE(EquipInfo.WORKCENTER, EquipInfo.ROUTE_NO, EquipInfo.TR_ID, "");
                    }
                    //////
                    slog = DateTime.Now + "[frmWorkStart 작업이 없어 완성됨 작업지시 폼으로] :      " + EquipInfo.WORKCENTER + "/" + EquipInfo.ROUTE_NO + "/" + EquipInfo.TR_ID;
                    Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                    ////// 

                    NetRemoting.TagSet(EquipInfo.WORKCENTER + "_" + EquipInfo.ROUTE_NO + "TR_ID", "0");
                    NetRemoting.TagSet(EquipInfo.WORKCENTER + "_" + EquipInfo.ROUTE_NO + "_END", "0001");

                    pictureBox1.Image = MOBISDAS.Properties.Resources.MOBIS;
                    //완료 메세지
                    MassageFormLoad("WORK_COMPLETE", "작업이 완료 되었습니다!.");
                    frmMessageClose();

                    //작업지시 폼으로
                    SerialPortClose();
                    SerialPortClose2();
                    //dataGridView_Alc.Refresh();
                    //System.Threading.Thread.Sleep(500);
                    EquipInfo.Initialization();
                    pictureBox1.Dispose();
                    frmMessageClose();

                    if (EquipInfo.ROUTE_GB == "S")
                    {
                        if (EquipInfo.WORKCENTER.Substring(0, 3) == "FEM")
                        {
                            EquipInfo._Frm = "frmWork_Start_FEM";
                        }
                        else if (EquipInfo.WORKCENTER.Substring(0, 3) == "CPM")
                        {
                            EquipInfo._Frm = "frmWork_Start_CPM";
                        }
                    }
                    else
                    {
                        EquipInfo._Frm = "frmWork";
                    }
                }
                ds.Dispose();
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWorkStart] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }

        public void ProcessJob()
        {
            DataSet ds;
            string pAlc_Code = "";
            string Work_Type = "";
            string Grid_OK = "";

            try
            {
                if (tWorkType != "")
                {

                    string _judge_test = "";
                    
                    //2016.09.28 YJ.DONG 바코드 스캔 특수 문자 오류 
                    if (tWorkType == "B")
                    {
                        if (tBarCode.Contains("?") == true || tBarCode.Contains("!") == true || tBarCode.Contains("?") == true || tBarCode.Contains("↑") == true || tBarCode.Contains("↓") == true
                            || tBarCode.Contains("◀") == true || tBarCode.Contains("¶") == true || tBarCode.Contains("♪") == true || tBarCode.Contains("♀") == true || tBarCode.Contains("|") == true
                            || tBarCode.Contains("=") == true
                           ) 
                        {
                            //MessageBox.Show("바코드 스캔 데이터 오류, 다시 스캔해 주세요.");
                            //return;

                            ////// 2019.04.18 바코드 특수기호 검출 측정
                            _judge_test = tBarCode.Contains("?") == true ? "NG" : "OK";
                            slog = DateTime.Now + "[frmWorkStart ProcessJob() 특수기호 판정값] : " + _judge_test + " / " + tBarCode;
                            Global.EquipInfo.fhLog.TextFileWriteAppend(slog);

                            MassageFormLoad("DATA ERROR", "바코드 스캔 데이터 오류, 다시 스캔해 주세요.");
                            frmMessageClose();
                            return;
                        }


                        ////// 2019.04.18 바코드 특수기호 검출 측정
                        _judge_test = tBarCode.Contains("?") == true ? "NG" : "OK";
                        slog = DateTime.Now + "[frmWorkStart ProcessJob() 특수기호 판정값] : " + _judge_test + " / " + tBarCode;
                        Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                        //////


                    }

                    //바코드 작업일때..
                    #region OK바코드 처리
                    if (tWorkType == "B" && tBarCode.Length >= 2)
                    {
                        #region OK 바코드 저장하고 다음으로 넘김
                        if (tBarCode.Substring(0, 2) == "OK" || tBarCode.Substring(0, 2) == "ok")
                        {
                            ds = new DataSet();
                            Procedure.PPC_PROCESSJOB_ALC(tBarCode, EquipInfo.WORKCENTER, EquipInfo.ROUTE_NO, EquipInfo.BODY_NO.Substring(0, 2), EquipInfo.PART_ID, EquipInfo.ALC, tBarCode, EquipInfo.TR_ID, "", ref ds);
                            NetRemoting.TagSet(EquipInfo.WORKCENTER + "_" + EquipInfo.ROUTE_NO + "_OKNG", "0000");

                            //////
                            slog = DateTime.Now + "[frmWorkStart OK 들어옴] :      " + tBarCode + "/" + EquipInfo.WORKCENTER + "/" + EquipInfo.ROUTE_NO + "/" + EquipInfo.PART_ID + "/" + EquipInfo.ALC + "/" + "빈값" + "/" + EquipInfo.TR_ID + "/" + "빈값";
                            Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                            ////// 

                            dataGridView_Alc.Rows[EquipInfo.gdCarrentCnt].Cells["OK"].Value = "OK";
                            dataGridView_Alc.Rows[EquipInfo.gdCarrentCnt].DefaultCellStyle.ForeColor = Color.DarkGray;
                            dataGridView_Alc.Rows[EquipInfo.gdCarrentCnt].Cells["OK"].Style.ForeColor = Color.Blue;
                            dataGridView_Alc.Rows[EquipInfo.gdCarrentCnt].DefaultCellStyle.BackColor = Color.White;
                            dataGridView_Alc.Rows[EquipInfo.gdCarrentCnt].DefaultCellStyle.SelectionBackColor = Color.White;
                            dataGridView_Alc.Rows[EquipInfo.gdCarrentCnt].DefaultCellStyle.SelectionForeColor = Color.DarkGray;
                            EquipInfo.gdCarrentCnt += 1;

                            //////
                            slog = DateTime.Now + "[frmWorkStart 작업순서] :      " + EquipInfo.gdCarrentCnt;
                            Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                            ////// 

                            //시리얼 포트 관련 변수 OK 판정나면 초기화
                            if (serialPortRECEIVE_DATA != "")
                            {
                                serialPortRECEIVE_DATA = "";
                            }
                            //다음 ROW CHECK
                            if (gdTotalCnt >= EquipInfo.gdCarrentCnt)
                            {
                                ProcessJobAfter();
                            }
                        }
                        #endregion
                    }
                    #endregion

                    int Row_Cnt = dataGridView_Alc.RowCount;

                    //////
                    slog = DateTime.Now + "[frmWorkStart 그리드의 총 로우 카운드] :      " + Row_Cnt;
                    Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                    ////// 

                    if (Row_Cnt > EquipInfo.gdCarrentCnt)
                    {
                        Work_Type = dataGridView_Alc.Rows[EquipInfo.gdCarrentCnt].Cells["@@WORK_TYPE"].Value.ToString();

                        //////
                        slog = DateTime.Now + "[frmWorkStart BC/TOOL 작업 확인] :      " + Work_Type;
                        Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                        //////                             
                        #region 바코드 작업
                        //BC 작업
                        if (Work_Type == "B")
                        {
                            if (tBarCode != "")
                            {
                                Scan_Flag = true;
                                Grid_OK = dataGridView_Alc.Rows[EquipInfo.gdCarrentCnt].Cells["OK"].Value.ToString().Trim();
                                #region "-" 아닌거처리 정상 로직
                                if (Grid_OK != "-" || Grid_OK == "")
                                {
                                    //2016.09.26~28 YJ.DONG
                                    //---------------------------------------------------------------------------------------
                                    //이종작업비교 - 프로시저 작업(TB_WORK_HISTORY)에 작업 기록이 있는 지 없는 지 확인

                                    //Barcode 작업시 해당 WC_ID,ROUTE_NO,PART_ID, READ_BARCODE가 예외처리 TABLE에 존재하는지 체크

                                    DataSet ds_exp = new DataSet();
                                    Procedure.SP_PPC_STATION_EXP(EquipInfo.WORKCENTER, EquipInfo.ROUTE_NO, EquipInfo.PART_ID, tBarCode, ref ds_exp);

                                    //////
                                    slog = DateTime.Now + "[frmWorkStart 이종작업비교 체크 SP] :      " + EquipInfo.WORKCENTER + "/" + EquipInfo.ROUTE_NO + "/" + EquipInfo.PART_ID + "/" + tBarCode;
                                    Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                                    //////

                                    if (ds_exp.Tables[0].Rows.Count > 0)
                                    {
                                        if (ds_exp.Tables[0].Rows[0]["CHECK"].ToString() == "N")
                                        {
                                            //////
                                            slog = DateTime.Now + "[frmWorkStart 이종작업비교 체크 SP] : 이종정보발생 => " + EquipInfo.WORKCENTER + "/" + EquipInfo.ROUTE_NO + "/" + EquipInfo.PART_ID + "/" + tBarCode;
                                            Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                                            //////

                                            //MassageFormLoad("BARCODE ERROR[이종이력 발생]", EquipInfo.PART_ID + Environment.NewLine + tBarCode + "의  이전 작업이력이 있습니다.");
                                            //frmMessageClose();
                                            //return;

                                            //PART_ID, BARCODE 값의 이종 이력을 보여 줌
                                            //MessageBox.Show("BARCODE ERROR[이종이력 발생]" + Environment.NewLine + EquipInfo.PART_ID + Environment.NewLine + tBarCode + "의  이전 작업이력이 있습니다.");
                                            //return;

                                            //MassageFormLoad("DUPLICATE", "BARCODE ERROR[이종이력 발생]" + Environment.NewLine + EquipInfo.PART_ID + Environment.NewLine + tBarCode + "의  이전 작업이력이 있습니다.");
                                            //jh_kim 2016.11.11 문구 변경
                                            MassageFormLoad("DUPLICATE", "● 항목 > "  + EquipInfo.PART_ID + Environment.NewLine +
                                                                         "● 바코드 >" + tBarCode + Environment.NewLine + 
                                                                         "이전 작업이력이 있는 제품입니다.");
                                            frmMessageClose();
                                            return;
                                        }
                                    }

                                    //---------------------------------------------------------------------------------------
                                    
                                    
                                    //Barcode 작업시 해당 PART_ID가 예외처리 TABLE에 존재하는지 체크
                                    ds = new DataSet();
                                    Procedure.PPC_ALC_EXP(EquipInfo.WORKCENTER, EquipInfo.BODY_NO.Substring(0, 2), EquipInfo.PART_ID, EquipInfo.ALC, ref ds);

                                    //////
                                    slog = DateTime.Now + "[frmWorkStart BARCODE_INFO 체크 SP] :      " + EquipInfo.WORKCENTER + "/" + EquipInfo.BODY_NO.Substring(0, 2) + "/" + EquipInfo.PART_ID + "/" + EquipInfo.ALC;
                                    Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                                    //////

                                    if (ds.Tables[0].Rows.Count > 0)
                                    {
                                        pAlc_Code = ds.Tables[0].Rows[0]["BARCODE_INFO"].ToString().Trim();
                                    }
                                    else
                                    {
                                        pAlc_Code = "";
                                    }

                                    if (pAlc_Code != "")
                                    {
                                        //////
                                        slog = DateTime.Now + "[frmWorkStart BARCODE_INFO] :      " + pAlc_Code;
                                        Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                                        //////

                                        //바코드 입력시 ALC CEHCK 및 이력을 넣는다.
                                        ds = new DataSet();
                                        Procedure.PPC_PROCESSJOB_ALC(tBarCode, EquipInfo.WORKCENTER, EquipInfo.ROUTE_NO, EquipInfo.BODY_NO.Substring(0, 2), EquipInfo.PART_ID, EquipInfo.ALC, pAlc_Code, EquipInfo.TR_ID, "", ref ds);

                                        //////
                                        slog = DateTime.Now + "[frmWorkStart BARCODE_INFO OK/NG 판정,이력 SP] :      " + tBarCode + "/" + EquipInfo.WORKCENTER + "/" + EquipInfo.ROUTE_NO + "/" + EquipInfo.PART_ID + "/" + EquipInfo.ALC + "/" + pAlc_Code + "/" + EquipInfo.TR_ID;
                                        Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                                        //////

                                        if (ds.Tables[0].Rows.Count > 0)
                                        {
                                            if (ds.Tables[0].Rows[0]["OK_NG"].ToString() == "OK")
                                            {
                                                //////
                                                slog = DateTime.Now + "[frmWorkStart BARCODE_INFO] :      " + "OK 판정 남.";
                                                Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                                                //////

                                                NetRemoting.TagSet(EquipInfo.WORKCENTER + "_" + EquipInfo.ROUTE_NO + "_OKNG", "0000");

                                                dataGridView_Alc.Rows[EquipInfo.gdCarrentCnt].Cells["OK"].Value = "OK";
                                                dataGridView_Alc.Rows[EquipInfo.gdCarrentCnt].DefaultCellStyle.ForeColor = Color.DarkGray;
                                                dataGridView_Alc.Rows[EquipInfo.gdCarrentCnt].Cells["OK"].Style.ForeColor = Color.Blue;
                                                dataGridView_Alc.Rows[EquipInfo.gdCarrentCnt].DefaultCellStyle.BackColor = Color.White;
                                                dataGridView_Alc.Rows[EquipInfo.gdCarrentCnt].DefaultCellStyle.SelectionBackColor = Color.White;
                                                dataGridView_Alc.Rows[EquipInfo.gdCarrentCnt].DefaultCellStyle.SelectionForeColor = Color.DarkGray;
                                                EquipInfo.gdCarrentCnt += 1;

                                                //////
                                                slog = DateTime.Now + "[frmWorkStart 작업순서] :      " + EquipInfo.gdCarrentCnt;
                                                Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                                                ////// 

                                                //시리얼 포트 관련 변수 OK 판정나면 초기화
                                                if (serialPortRECEIVE_DATA != "")
                                                {
                                                    serialPortRECEIVE_DATA = "";
                                                }
                                            }
                                            else if (ds.Tables[0].Rows[0]["OK_NG"].ToString() == "NG")
                                            {
                                                //////
                                                slog = DateTime.Now + "[frmWorkStart BARCODE_INFO] :      " + "NG 판정 남.";
                                                Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                                                //////

                                                NetRemoting.TagSet(EquipInfo.WORKCENTER + "_" + EquipInfo.ROUTE_NO + "_OKNG", "0001");

                                                dataGridView_Alc.Rows[EquipInfo.gdCarrentCnt].Cells["OK"].Value = "NG";
                                                dataGridView_Alc.Rows[EquipInfo.gdCarrentCnt].Cells["OK"].Style.ForeColor = Color.Red;
                                                tBarCode = "";

                                                //시리얼 포트 관련 변수 NG 판정나면 초기화
                                                if (serialPortRECEIVE_DATA != "")
                                                {
                                                    serialPortRECEIVE_DATA = "";
                                                }
                                                return;
                                            }
                                        }
                                    }

                                    else
                                    {
                                        //////
                                        slog = DateTime.Now + "[frmWorkStart BARCODE_INFO] :      " + "BARCODE_INFO 없음.";
                                        Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                                        //////

                                        MassageFormLoad("BARCODE ERROR", EquipInfo.ALC + " 를(을) 등록해 주세요.");
                                        frmMessageClose();
                                        return;
                                    }
                                }

                                #endregion
                                else
                                {
                                    dataGridView_Alc.Rows[EquipInfo.gdCarrentCnt].DefaultCellStyle.BackColor = Color.White;
                                    dataGridView_Alc.Rows[EquipInfo.gdCarrentCnt].DefaultCellStyle.ForeColor = Color.DarkGray;
                                    dataGridView_Alc.Rows[EquipInfo.gdCarrentCnt].DefaultCellStyle.SelectionBackColor = Color.White;
                                    dataGridView_Alc.Rows[EquipInfo.gdCarrentCnt].DefaultCellStyle.SelectionForeColor = Color.DarkGray;
                                    EquipInfo.gdCarrentCnt += 1;

                                    //////
                                    slog = DateTime.Now + "[frmWorkStart '-'로 들어옴 다음 작업순서] :      " + EquipInfo.gdCarrentCnt;
                                    Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                                    ////// 
                                }

                                //다음 ROW CHECK
                                if (gdTotalCnt >= EquipInfo.gdCarrentCnt)
                                {
                                    ProcessJobAfter();
                                }
                            }
                        }
                        #endregion
                        //TOOL 작업
                        else if (Work_Type == "T")
                        {
                            Grid_OK = dataGridView_Alc.Rows[EquipInfo.gdCarrentCnt].Cells["OK"].Value.ToString().Trim();

                            if (Grid_OK != "-" || Grid_OK == "")
                            {
                                Tool_Type = dataGridView_Alc.Rows[EquipInfo.gdCarrentCnt].Cells["@@TOOL_TYPE"].Value.ToString().Trim();

                                Scan_Flag = false;
                                //////
                                slog = DateTime.Now + "[frmWorkStart TOOL 작업] :      " + dataGridView_Alc.Rows[EquipInfo.gdCarrentCnt].Cells["@@WORK_TYPE"].Value.ToString();
                                Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                                ////// 

                                //TOOL 작업시 아트라스 장비는 스타트 정보를 보낸다.                                
                                if (Tool_Type == "ATOOL")
                                {
                                    NetRemoting.TagSet(EquipInfo.WORKCENTER + "_" + EquipInfo.ROUTE_NO + "_ATOOL", "S");

                                    //////
                                    slog = DateTime.Now + "[frmWorkStart ATOOL-아트라스 장비] :      " + "S 보냄";
                                    Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                                    ////// 

                                }
                                else if (Tool_Type == "ATOOL2")
                                {
                                    NetRemoting.TagSet(EquipInfo.WORKCENTER + "_" + EquipInfo.ROUTE_NO + "_ATOOL2", "S");

                                    //////
                                    slog = DateTime.Now + "[frmWorkStart ATOOL2-아트라스 장비] :      " + "S 보냄";
                                    Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                                    ////// 

                                }

                                //첫개발시 여기에서 Param절보를 Reset 해었음.

                                // PARM 정보를 Reset 한다.
                                TagReSet();

                                //토크 작업 팦업 불러오기   
                                ToolFormLoad();
                                frmToolClose();
                                //txt_ReciveData.Enabled = true;
                                if (EquipInfo.Tool_Cancle_Rtn != "CANCLE")
                                {
                                    Scan_Flag = true;

                                    //TOOL 작업이 끝났으니 END 정보를 날린다.

                                    //토크 작업 끝나고 OK 표시
                                    dataGridView_Alc.Rows[EquipInfo.gdCarrentCnt].Cells["OK"].Value = "OK";
                                    dataGridView_Alc.Rows[EquipInfo.gdCarrentCnt].DefaultCellStyle.ForeColor = Color.DarkGray;
                                    dataGridView_Alc.Rows[EquipInfo.gdCarrentCnt].Cells["OK"].Style.ForeColor = Color.Blue;
                                    dataGridView_Alc.Rows[EquipInfo.gdCarrentCnt].DefaultCellStyle.BackColor = Color.White;
                                    dataGridView_Alc.Rows[EquipInfo.gdCarrentCnt].DefaultCellStyle.SelectionBackColor = Color.White;

                                    if (Tool_Type == "ATOOL")
                                    {
                                        NetRemoting.TagSet(EquipInfo.WORKCENTER + "_" + EquipInfo.ROUTE_NO + "_ATOOL", "E");
                                        //////
                                        slog = DateTime.Now + "[frmWorkStart ATOOL-아트라스 장비] :      " + " TOOL 작업 끝 E 보냄";
                                        Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                                        ////// 
                                    }
                                    else if (Tool_Type == "ATOOL2")
                                    {
                                        NetRemoting.TagSet(EquipInfo.WORKCENTER + "_" + EquipInfo.ROUTE_NO + "_ATOOL2", "E");
                                        //////
                                        slog = DateTime.Now + "[frmWorkStart ATOOL2-아트라스 장비] :      " + " TOOL 작업 끝 E 보냄";
                                        Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                                        ////// 
                                    }

                                    EquipInfo.gdCarrentCnt += 1;

                                    //////
                                    slog = DateTime.Now + "[frmWorkStart 작업순서] :      " + EquipInfo.gdCarrentCnt;
                                    Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                                    ////// 
                                }
                                else
                                {
                                    frmWorkTool = null;
                                    dataGridView_Alc.DefaultCellStyle.SelectionForeColor = Color.Black;
                                    dataGridView_Alc.DefaultCellStyle.SelectionBackColor = Color.Gold;
                                    if (Tool_Type == "ATOOL")
                                    {
                                        NetRemoting.TagSet(EquipInfo.WORKCENTER + "_" + EquipInfo.ROUTE_NO + "_ATOOL", "E");
                                        //////
                                        slog = DateTime.Now + "[frmWorkStart ATOOL-아트라스 장비] :      " + " TOOL 작업 끝 E 보냄";
                                        Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                                        ////// 
                                    }
                                    else if (Tool_Type == "ATOOL2")
                                    {
                                        NetRemoting.TagSet(EquipInfo.WORKCENTER + "_" + EquipInfo.ROUTE_NO + "_ATOOL2", "E");
                                        //////
                                        slog = DateTime.Now + "[frmWorkStart ATOOL2-아트라스 장비] :      " + " TOOL 작업 끝 E 보냄";
                                        Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                                        ////// 
                                    }
                                    return;
                                }
                            }
                            else
                            {
                                dataGridView_Alc.Rows[EquipInfo.gdCarrentCnt].DefaultCellStyle.BackColor = Color.White;
                                dataGridView_Alc.Rows[EquipInfo.gdCarrentCnt].DefaultCellStyle.ForeColor = Color.DarkGray;
                                dataGridView_Alc.Rows[EquipInfo.gdCarrentCnt].DefaultCellStyle.SelectionBackColor = Color.White;
                                dataGridView_Alc.Rows[EquipInfo.gdCarrentCnt].DefaultCellStyle.SelectionForeColor = Color.DarkGray;
                                EquipInfo.gdCarrentCnt += 1;

                                //////
                                slog = DateTime.Now + "[frmWorkStart 작업순서] :      " + EquipInfo.gdCarrentCnt;
                                Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                                ////// 
                            }

                            if (gdTotalCnt >= EquipInfo.gdCarrentCnt)
                            {
                                ProcessJobAfter();
                            }
                        }

                        // 전동 툴 작업
                        else if (Work_Type == "E")
                        {
                            Grid_OK = dataGridView_Alc.Rows[EquipInfo.gdCarrentCnt].Cells["OK"].Value.ToString().Trim();

                            if (Grid_OK != "-" || Grid_OK == "")
                            {
                                Tool_Type = dataGridView_Alc.Rows[EquipInfo.gdCarrentCnt].Cells["@@TOOL_TYPE"].Value.ToString().Trim();

                                Scan_Flag = false;
                                //////
                                slog = DateTime.Now + "[frmWorkStart 전동TOOL 작업] :      " + dataGridView_Alc.Rows[EquipInfo.gdCarrentCnt].Cells["@@WORK_TYPE"].Value.ToString();
                                Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                                ////// 

                                /* 2016.03.06 주석
                                //TOOL 작업시 아트라스 장비는 스타트 정보를 보낸다.                                
                                if (Tool_Type == "ATOOL")
                                {
                                    NetRemoting.TagSet(EquipInfo.WORKCENTER + "_" + EquipInfo.ROUTE_NO + "_ATOOL", "S");

                                    //////
                                    slog = DateTime.Now + "[frmWorkStart ATOOL-아트라스 장비] :      " + "S 보냄";
                                    Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                                    ////// 

                                }
                                else if (Tool_Type == "ATOOL2")
                                {
                                    NetRemoting.TagSet(EquipInfo.WORKCENTER + "_" + EquipInfo.ROUTE_NO + "_ATOOL2", "S");

                                    //////
                                    slog = DateTime.Now + "[frmWorkStart ATOOL2-아트라스 장비] :      " + "S 보냄";
                                    Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                                    ////// 

                                }
                                

                                //첫개발시 여기에서 Param절보를 Reset 해었음.

                                // PARM 정보를 Reset 한다.
                                
                                */
                                TagReSet();

                                //토크 작업 팦업 불러오기   
                                ElectricToolFormLoad(dataGridView_Alc.Rows[EquipInfo.gdCarrentCnt].Cells["작업명"].Value.ToString().Trim());
                                frmElectricToolClose();
                                //txt_ReciveData.Enabled = true;
                                if (EquipInfo.Tool_Cancle_Rtn != "CANCLE")
                                {
                                    Scan_Flag = true;

                                    //TOOL 작업이 끝났으니 END 정보를 날린다.

                                    //토크 작업 끝나고 OK 표시
                                    dataGridView_Alc.Rows[EquipInfo.gdCarrentCnt].Cells["OK"].Value = "OK";
                                    dataGridView_Alc.Rows[EquipInfo.gdCarrentCnt].DefaultCellStyle.ForeColor = Color.DarkGray;
                                    dataGridView_Alc.Rows[EquipInfo.gdCarrentCnt].Cells["OK"].Style.ForeColor = Color.Blue;
                                    dataGridView_Alc.Rows[EquipInfo.gdCarrentCnt].DefaultCellStyle.BackColor = Color.White;
                                    dataGridView_Alc.Rows[EquipInfo.gdCarrentCnt].DefaultCellStyle.SelectionBackColor = Color.White;

                                     /* 2016.03.06 주석
                                    if (Tool_Type == "ATOOL")
                                    {
                                        NetRemoting.TagSet(EquipInfo.WORKCENTER + "_" + EquipInfo.ROUTE_NO + "_ATOOL", "E");
                                        //////
                                        slog = DateTime.Now + "[frmWorkStart ATOOL-아트라스 장비] :      " + " TOOL 작업 끝 E 보냄";
                                        Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                                        ////// 
                                    }
                                    else if (Tool_Type == "ATOOL2")
                                    {
                                        NetRemoting.TagSet(EquipInfo.WORKCENTER + "_" + EquipInfo.ROUTE_NO + "_ATOOL2", "E");
                                        //////
                                        slog = DateTime.Now + "[frmWorkStart ATOOL2-아트라스 장비] :      " + " TOOL 작업 끝 E 보냄";
                                        Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                                        ////// 
                                    }
                                    */

                                    EquipInfo.gdCarrentCnt += 1;

                                    //////
                                    slog = DateTime.Now + "[frmWorkStart 작업순서] :      " + EquipInfo.gdCarrentCnt;
                                    Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                                    ////// 
                                }
                                else
                                {
                                    frmWorkElectricTool = null;
                                    dataGridView_Alc.DefaultCellStyle.SelectionForeColor = Color.Black;
                                    dataGridView_Alc.DefaultCellStyle.SelectionBackColor = Color.Gold;
                                    /* 2016.03.06 주석
                                    if (Tool_Type == "ATOOL")
                                    {
                                        NetRemoting.TagSet(EquipInfo.WORKCENTER + "_" + EquipInfo.ROUTE_NO + "_ATOOL", "E");
                                        //////
                                        slog = DateTime.Now + "[frmWorkStart ATOOL-아트라스 장비] :      " + " TOOL 작업 끝 E 보냄";
                                        Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                                        ////// 
                                    }
                                    else if (Tool_Type == "ATOOL2")
                                    {
                                        NetRemoting.TagSet(EquipInfo.WORKCENTER + "_" + EquipInfo.ROUTE_NO + "_ATOOL2", "E");
                                        //////
                                        slog = DateTime.Now + "[frmWorkStart ATOOL2-아트라스 장비] :      " + " TOOL 작업 끝 E 보냄";
                                        Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                                        ////// 
                                    }
                                     */
                                    return;
                                }
                            }
                            else
                            {
                                dataGridView_Alc.Rows[EquipInfo.gdCarrentCnt].DefaultCellStyle.BackColor = Color.White;
                                dataGridView_Alc.Rows[EquipInfo.gdCarrentCnt].DefaultCellStyle.ForeColor = Color.DarkGray;
                                dataGridView_Alc.Rows[EquipInfo.gdCarrentCnt].DefaultCellStyle.SelectionBackColor = Color.White;
                                dataGridView_Alc.Rows[EquipInfo.gdCarrentCnt].DefaultCellStyle.SelectionForeColor = Color.DarkGray;
                                EquipInfo.gdCarrentCnt += 1;

                                //////
                                slog = DateTime.Now + "[frmWorkStart 작업순서] :      " + EquipInfo.gdCarrentCnt;
                                Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                                ////// 
                            }

                            if (gdTotalCnt >= EquipInfo.gdCarrentCnt)
                            {
                                ProcessJobAfter();
                            }
                        }
                    }
                }

                else
                {
                    //Grid_OK = dataGridView_Alc.Rows[EquipInfo.gdCarrentCnt].Cells["OK"].Value.ToString().Trim();

                    //if (Grid_OK != "-" || Grid_OK == "")
                    //{
                    //    Assy_Msg = dataGridView_Alc.Rows[EquipInfo.gdCarrentCnt].Cells["@@ASSY_MSG"].Value.ToString().Trim();
                    //    if (Assy_Msg != "")
                    //    {
                    //        frmMessageClose();
                    //        AssyMassageFormLoad("ASSY_MSG", Assy_Msg);
                    //    }
                    //}                    
                }
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWorkStart] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }

        private void AssyMassageFormLoad(string Gubun, string Msg)
        {
            try
            {
                if (frmMsg == null)
                {
                    frmMsg = new frmMsg(Gubun, Msg);
                    AssyfrmWork_Set(frmMsg);
                }
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWorkStart] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }

        private void ToolFormLoad()
        {
            try
            {
                if (frmWorkTool == null)
                {
                    //txt_ReciveData.Enabled = false;
                    frmWorkTool = new frmWorkTool();
                    frmWorkTool_Set(frmWorkTool);
                }
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWorkStart] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }

        private void ElectricToolFormLoad(string str_title)
        {
            try
            {
                if (frmWorkElectricTool == null)
                {
                    frmWorkElectricTool = new frmWorkElectricTool();
                    frmWorkElectricTool.lbl_title1.Text = "[작업 위치 - " + str_title + "]";
                    frmWorkElectricTool_Set(frmWorkElectricTool);
                }
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWorkStart] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }

        private void AssyfrmWork_Set(Form _Work)
        {
            try
            {
                if (this.InvokeRequired)
                    this.Invoke(new WorkMsg(AssyfrmWork_Set), new object[] { _Work });
                else
                    frmMsg.Show();
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWorkStart] :      " + ex;
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
                slog = DateTime.Now + "[frmWork_Stark_CPM] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }

        private void frmWorkTool_Set(Form _WorkTool)
        {
            try
            {
                if (this.InvokeRequired)
                    this.Invoke(new WorkToll(frmWorkTool_Set), new object[] { _WorkTool });
                else
                    frmWorkTool.ShowDialog();
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWorkStart] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }

        private void frmWorkElectricTool_Set(Form _WorkElectricTool)
        {
            try
            {
                if (this.InvokeRequired)
                    this.Invoke(new WorkToll(frmWorkElectricTool_Set), new object[] { _WorkElectricTool });
                else
                    frmWorkElectricTool.ShowDialog();
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWorkStart] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }


        private void frmToolClose()
        {
            if (frmWorkTool != null)
            {
                frmWorkTool.Close();
                frmWorkTool = null;
            }
        }

        private void frmElectricToolClose()
        {
            if (frmWorkElectricTool != null)
            {
                frmWorkElectricTool.Close();
                frmWorkElectricTool = null;
            }
        }

        private void MassageFormLoad(string Gubun, string Msg)
        {
            try
            {
                if (frmMsg == null)
                {
                    frmMsg = new frmMsg(Gubun, Msg);
                    frmWork_Set(frmMsg);
                }
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWork] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }

        private void frmMessageClose()
        {
            if (frmMsg != null)
            {
                frmMsg.Close();
                frmMsg = null;
            }
        }

        private void Label_Text_Set(string LabelText)
        {
            try
            {
                if (lbl_Alc.InvokeRequired)
                    lbl_Alc.Invoke(new LabelSet(Label_Text_Set), new object[] { LabelText });
                else
                    lbl_Alc.Text = LabelText;
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWorkStart] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }

        //private void Text_Set(string Text)
        //{
        //    try
        //    {
        //        if (txt_ReciveData.InvokeRequired)
        //            txt_ReciveData.Invoke(new TextSet(Text_Set), new object[] { Text });
        //        else
        //            lbl_Alc.Text = Text;
        //    }
        //    catch (Exception ex)
        //    {
        //        slog = DateTime.Now + "[frmWorkStart] :      " + ex;
        //        Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
        //    }
        //}       

        private void ProcessJobAfter()
        {
            try
            {
                if (gdTotalCnt > EquipInfo.gdCarrentCnt)
                {
                    EquipInfo.ALC = dataGridView_Alc.Rows[EquipInfo.gdCarrentCnt].Cells["ALC"].Value.ToString();
                    EquipInfo.PART_ID = dataGridView_Alc.Rows[EquipInfo.gdCarrentCnt].Cells["@@PART_ID"].Value.ToString();
                    EquipInfo.ASSY_SEQ = dataGridView_Alc.Rows[EquipInfo.gdCarrentCnt].Cells["@@ASSY_SEQ"].Value.ToString();

                    Serial_Port = dataGridView_Alc.Rows[EquipInfo.gdCarrentCnt].Cells["@@PORT"].Value.ToString().Trim();
                    Serial_Set = dataGridView_Alc.Rows[EquipInfo.gdCarrentCnt].Cells["@@SETTING"].Value.ToString().Trim();
                    //시리얼 OPEN
                    //SerialPortOpen();
                    //다음 PART_ID 이미지를 보여준다./////////////
                    //Picture_Down();
                    if (dataGridView_Alc.Rows[EquipInfo.gdCarrentCnt].Cells["OK"].Value.ToString() != "-")
                    {
                        Picture_Load();
                    }
                    ////////////////////////////////////////////
                    Label_Text_Set(EquipInfo.ALC);

                    dataGridView_Alc.Rows[EquipInfo.gdCarrentCnt].DefaultCellStyle.BackColor = Color.Gold;

                    if (dataGridView_Alc.Rows[EquipInfo.gdCarrentCnt].Cells["OK"].Value.ToString() == "")
                    {
                        if (dataGridView_Alc.Rows[EquipInfo.gdCarrentCnt].Cells["@@WORK_TYPE"].Value.ToString() == "B")
                        {
                            tWorkType = "B";
                            tBarCode = "";
                        }
                        else if (dataGridView_Alc.Rows[EquipInfo.gdCarrentCnt].Cells["@@WORK_TYPE"].Value.ToString() == "T")
                        {
                            tWorkType = "T";
                            tBarCode = "";
                        }
                        else if (dataGridView_Alc.Rows[EquipInfo.gdCarrentCnt].Cells["@@WORK_TYPE"].Value.ToString() == "E")
                        {
                            tWorkType = "E";
                            tBarCode = "";
                        }
                    }
                    else
                    {
                        if (dataGridView_Alc.Rows[EquipInfo.gdCarrentCnt].Cells["@@WORK_TYPE"].Value.ToString() == "B")
                        {
                            tWorkType = "B";
                            tBarCode = dataGridView_Alc.Rows[EquipInfo.gdCarrentCnt].Cells["OK"].Value.ToString();
                        }
                        else if (dataGridView_Alc.Rows[EquipInfo.gdCarrentCnt].Cells["@@WORK_TYPE"].Value.ToString() == "T")
                        {
                            tWorkType = "T";
                            tBarCode = dataGridView_Alc.Rows[EquipInfo.gdCarrentCnt].Cells["OK"].Value.ToString();
                        }
                        else if (dataGridView_Alc.Rows[EquipInfo.gdCarrentCnt].Cells["@@WORK_TYPE"].Value.ToString() == "E")
                        {
                            tWorkType = "E";
                            tBarCode = dataGridView_Alc.Rows[EquipInfo.gdCarrentCnt].Cells["OK"].Value.ToString();
                        }
                    }
                    //ASSY별 메세지 추가
                    //Assy_Msg = dataGridView_Alc.Rows[EquipInfo.gdCarrentCnt].Cells["@@ASSY_MSG"].Value.ToString().Trim();
                    //if (Assy_Msg != "")
                    //{
                    //    frmMessageClose();
                    //    AssyMassageFormLoad("ASSY_MSG", Assy_Msg);
                    //}
                }

                //작업이 다 끝나면 WORK화면으로 돌아가는 로직 추가//////////// WORK_COMPLETE 부분 작업 끝
                if (EquipInfo.gdCarrentCnt == gdTotalCnt)
                {
                    ProcessComPlete();
                    return;
                }
                /////////////////////////////////////////////////////////////  
                ProcessJob();
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWorkStart] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }
        private void InspectionFormLoad()
        {
            try
            {
                if (frmWorkInspection == null)
                {
                    txt_ReciveData.Enabled = false;
                    frmWorkInspection = new frmWorkInspection();
                    frmWorkInspection_Set(frmWorkInspection);
                }
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWorkStart] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }

        private void frmWorkInspection_Set(Form _WorkInspection)
        {
            try
            {
                if (this.InvokeRequired)
                    this.Invoke(new WorkInpection(frmWorkInspection_Set), new object[] { _WorkInspection });
                else
                    frmWorkInspection.ShowDialog();
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWorkStart] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }

        private void frmInspClose()
        {
            if (frmWorkInspection != null)
            {
                frmWorkInspection.Close();
                frmWorkInspection = null;
            }
        }

        private bool CheckInsp()
        {
            DataSet ds = new DataSet();
            Procedure.PPC_INSP_LOAD(EquipInfo.WORKCENTER, EquipInfo.ROUTE_NO, EquipInfo.CAR_CODE, EquipInfo.TR_ID, ref ds);

            if (ds.Tables[0].Rows.Count > 0)
                return true;
            else
                return false;
        }

        private void ProcessComPlete()
        {
            try
            {

                if (CheckInsp() == true)
                {
                    InspectionFormLoad();
                    frmInspClose();
                }

                IS_END = true;
                DO_COMPLETE = true;
                //if (ComPleteCnt == 1)
                //{
                //작업완료시 이력관리///////////////////////////////////
                if (MPIS_END == false)
                {
                    slog = DateTime.Now + "[frmWorkStart MPIS 완료 대기]";
                    Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                    DO_COMPLETE = false;
                    return;
                }
                if (EquipInfo.Virtual == false)
                {
                    Procedure.PPC_WORK_COMPLETE(EquipInfo.WORKCENTER, EquipInfo.ROUTE_NO, EquipInfo.TR_ID, "");
                }
                else
                {
                    Procedure.PPC_VIRTUAL_WORK_COMPLETE(EquipInfo.WORKCENTER, EquipInfo.ROUTE_NO, EquipInfo.TR_ID, "");
                }
                //////
                slog = DateTime.Now + "[frmWorkStart 모든 작업완료] :      " + EquipInfo.WORKCENTER + "/" + EquipInfo.ROUTE_NO + "/" + EquipInfo.TR_ID;
                Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                ////// 

                //////////////////////////////////////////////////////
                NetRemoting.TagSet(EquipInfo.WORKCENTER + "_" + EquipInfo.ROUTE_NO + "_END", "0001");

                //////
                slog = DateTime.Now + "[frmWorkStart END 신호 보냄] :      " + EquipInfo.WORKCENTER + "_" + EquipInfo.ROUTE_NO + "_END" + " / 0001";
                Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                ////// 

                pictureBox1.Image = MOBISDAS.Properties.Resources.MOBIS;
                //완료 메세지
                frmMessageClose();
                MassageFormLoad("WORK_COMPLETE", "작업이 완료 되었습니다!.");
                frmMessageClose();
                //작업지시 폼으로
                while (serialPort1.IsOpen)
                {
                    System.Threading.Thread.Sleep(100);
                    SerialPortClose();
                }

                while (serialPort2.IsOpen)
                {
                    System.Threading.Thread.Sleep(100);
                    SerialPortClose2();
                }
                EquipInfo.Initialization();
                pictureBox1.Dispose();
                frmMessageClose();

                if (EquipInfo.ROUTE_GB == "S")
                {
                    if (EquipInfo.WORKCENTER.Substring(0, 3) == "FEM")
                    {
                        EquipInfo._Frm = "frmWork_Start_FEM";
                    }
                    else if (EquipInfo.WORKCENTER.Substring(0, 3) == "CPM")
                    {
                        EquipInfo._Frm = "frmWork_Start_CPM";
                    }
                }
                else
                {
                    EquipInfo._Frm = "frmWork";
                }
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWorkStart] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }

        private void BinddataGridView_AlcSet(ref DataGridView dataGridView)
        {
            int e_toolcount = 0;
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
                dataGridView.Columns[1].Width = dataGridView.Width * 40 / 100;
                dataGridView.Columns[2].Width = dataGridView.Width * 30 / 100;
                dataGridView.Columns[3].Width = dataGridView.Width * 30 / 100;
                //행 높이
                int iColumnHeaderHeight = 0;
                if (dataGridView.ColumnHeadersVisible == true)
                {
                    iColumnHeaderHeight = dataGridView.ColumnHeadersHeight;
                }

                //전동툴 로우 안보이게
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    if (dataGridView.Rows[i].Cells["@@WORK_TYPE"].Value.ToString() == "E")
                    {
                        dataGridView.Rows[i].Visible = false;
                        ++e_toolcount;
                    }
                }

                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    if (dataGridView.Rows[i].Cells["@@WORK_TYPE"].Value.ToString() == "E")
                    {
                        if (dataGridView.Rows[i].Cells["@@IS_WORK"].Value.ToString() == "N")
                        {
                            dataGridView.Rows[i].Cells["OK"].Value = "-";
                        }
                    }
                }

                for (int i = 0; i < dataGridView.Rows.Count - e_toolcount; i++)
                {
                    int iRowsHeight = (dataGridView.Height - iColumnHeaderHeight) / (dataGridView.Rows.Count - e_toolcount);
                    dataGridView.Rows[i].Height = iRowsHeight;
                    dataGridView.Rows[i].Cells["작업명"].Style.Font = new System.Drawing.Font("HY견고딕", 22.00F, FontStyle.Bold);

                    if (dataGridView.Rows[0].Cells["OK"].Value.ToString() == "")
                    {
                        dataGridView.Rows[0].DefaultCellStyle.BackColor = Color.Gold;
                        dataGridView.Rows[0].DefaultCellStyle.SelectionBackColor = Color.Gold;
                    }
                    if (dataGridView.Rows.Count > 4)
                    {
                        dataGridView.Rows[i].Cells["ALC"].Style.Font = new System.Drawing.Font("HY견고딕", 36.00F, FontStyle.Bold);
                    }
                    else
                    {
                        if (dataGridView.Rows[i].Cells["ALC"].Value.ToString().Length >= 4)
                        {
                            dataGridView.Rows[i].Cells["ALC"].Style.Font = new System.Drawing.Font("HY견고딕", 36.00F, FontStyle.Bold);
                        }
                    }
                    if (dataGridView.Rows[i].Cells["@@WORK_TYPE"].Value.ToString() == "B")
                    {
                        if (dataGridView.Rows[i].Cells["@@IS_WORK"].Value.ToString() == "N" || dataGridView.Rows[i].Cells["@@BAR_INFO"].Value.ToString() == "X"
                           || dataGridView.Rows[i].Cells["@@BAR_INFO"].Value.ToString() == "x" || dataGridView.Rows[i].Cells["ALC"].Value.ToString() == "X" || dataGridView.Rows[i].Cells["ALC"].Value.ToString() == "")
                        {
                            dataGridView.Rows[i].Cells["OK"].Value = "-";
                        }
                    }
                    else if (dataGridView.Rows[i].Cells["@@WORK_TYPE"].Value.ToString() == "T")
                    {
                        if (dataGridView.Rows[i].Cells["@@IS_WORK"].Value.ToString() == "N")
                        {
                            dataGridView.Rows[i].Cells["OK"].Value = "-";
                        }
                    }
                   
                }  
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWorkStart] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }

        private void dataGridView_AlcSet(ref DataGridView dataGridView)
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
                dataGridView.DefaultCellStyle.SelectionBackColor = dataGridView.DefaultCellStyle.BackColor;
                dataGridView.DefaultCellStyle.SelectionForeColor = dataGridView.DefaultCellStyle.ForeColor;

                dataGridView.BorderStyle = BorderStyle.Fixed3D;
                dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWorkStart] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }

        }

        private void lbl_OrderDate_Click(object sender, EventArgs e)
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

        private void btn_Bar_OK_Click(object sender, EventArgs e)
        {
            string slog = null;

            try
            {
                tBarCode = txt_Barcode.Text;

                //////
                slog = DateTime.Now + "[frmWorkStart 수동 입력] :      " + tBarCode;
                Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                ////// 

                ProcessJob();
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWorkStart] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }

        private void dataGridView_Alc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (frmWorkTool == null)
                {
                    if (e.RowIndex == EquipInfo.gdCarrentCnt)
                    {
                        if (dataGridView_Alc.Rows[e.RowIndex].Cells["@@WORK_TYPE"].Value.ToString() == "T")
                        {
                            dataGridView_Alc.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Gold;
                            ProcessJob();
                        }
                    }
                    else
                    {
                        dataGridView_Alc.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.White;
                    }
                }
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWorkStart] :      " + ex;
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
                    slog = DateTime.Now + "[frmWorkStart 스캔 바코드] :      " + tBarCode;
                    Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                    ////// 

                    if (Scan_Flag == true)
                    {
                        ProcessJob();
                    }
                    txt_ReciveData.Text = "";
                }
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWorkStart] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }

        private void bnt_main_Click(object sender, EventArgs e)
        {
            string sTAG_ID = "";
            try
            {
                while (serialPort1.IsOpen == true)
                {
                    System.Threading.Thread.Sleep(100);
                    SerialPortClose();
                }
                while (serialPort2.IsOpen == true)
                {
                    System.Threading.Thread.Sleep(100);
                    SerialPortClose2();
                }
                if (EquipInfo.ROUTE_GB == "S")
                {
                    DataSet ds = new DataSet();
                    Procedure.PPC_ROUTE_TRK_INFO(EquipInfo.WORKCENTER, EquipInfo.ROUTE_NO, ref ds);
                    ////////////
                    slog = DateTime.Now + "[frmWorkStart 메인가기위해서 TR_ID 조회 SP] :      " + EquipInfo.WORKCENTER + "/" + EquipInfo.ROUTE_NO;
                    Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                    /////////////////////////                                        

                    sTAG_ID = ds.Tables[0].Rows[0]["TAG_ID"].ToString().Trim();
                    ////////////
                    slog = DateTime.Now + "[frmWorkStart 메인가기위해서 TR_ID 조회 완료] :      " + sTAG_ID;
                    Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                    /////////////////////////    


                    //스키드 리셋
                    ds = new DataSet();
                    if (EquipInfo.Virtual == false)
                    {
                        Procedure.PPC_TRAN_CANCLE(EquipInfo.WORKCENTER, sTAG_ID, EquipInfo.BARCODE);
                    }
                    else
                    {
                        Procedure.PPC_VIRTUAL_TRAN_CANCLE(EquipInfo.WORKCENTER, sTAG_ID, EquipInfo.BARCODE);
                    }
                    ////////////
                    slog = DateTime.Now + "[frmWorkStar 매핑 취소 SP] :      " + EquipInfo.WORKCENTER + "/" + sTAG_ID + "/" + EquipInfo.BARCODE;
                    Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                    ///////////////////////// 
                    ds.Dispose();
                }
                NetRemoting.TagSet(EquipInfo.WORKCENTER + "_" + EquipInfo.ROUTE_NO + "TR_ID", "0");
                EquipInfo.Initialization();
                frmMessageClose();
                if (EquipInfo.ROUTE_GB == "S")
                {
                    if (EquipInfo.WORKCENTER.Substring(0, 3) == "FEM")
                    {
                        EquipInfo._Frm = "frmWork_Start_FEM";
                    }
                    else if (EquipInfo.WORKCENTER.Substring(0, 3) == "CPM")
                    {
                        EquipInfo._Frm = "frmWork_Start_CPM";
                    }
                }
                else
                {
                    EquipInfo._Frm = "frmWork";
                }
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWorkStart] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }

        private void lbl_BodyNo_Click(object sender, EventArgs e)
        {
            if (pnl_Main_Load.Visible)
            {
                pnl_Main_Load.Enabled = false;
                pnl_Main_Load.Visible = false;
                bnt_main.Enabled = false;
                bnt_main.Visible = false;
            }
            else
            {
                pnl_Main_Load.Enabled = true;
                pnl_Main_Load.Visible = true;
                bnt_main.Enabled = true;
                bnt_main.Visible = true;
            }
        }

        private void Picture_Load()
        {
            try
            {
                //////
                FileName = Application.StartupPath + "\\IMG\\" + EquipInfo.WORKCENTER + "_" + EquipInfo.BODY_NO.Substring(0, 2) + "_" + EquipInfo.PART_ID + "_" + EquipInfo.ALC + ".JPG";
                //DFileName = Application.StartupPath + "\\IMG\\MOBIS.JPG";


                if (!CheckSameFile(FileName))
                {
                    FileName = Application.StartupPath + "\\IMG\\" + EquipInfo.WORKCENTER + "_" + EquipInfo.BODY_NO.Substring(0, 2) + "_" + EquipInfo.PART_ID + ".JPG";                    

                    if (!CheckSameFile(FileName))
                    {
                        pictureBox1.Refresh();
                    }
                    else
                    {
                        //pictureBox1.Load(FileName);

                        //이미지 사이즈 변경 추가 20181024 김진성
                        Bitmap reSizeImg = ResizeImage(FileName);
                        pictureBox1.Image = reSizeImg;
                    }
                    //picBox.Load(DFileName);
                }
                else
                {
                    //pictureBox1.Load(FileName);

                    //이미지 사이즈 변경 추가 20181024 김진성
                    Bitmap reSizeImg = ResizeImage(FileName);
                    pictureBox1.Image = reSizeImg;
                    //추가 구문 END
                    //pictureBox1.Refresh();
                }
                //////
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWorkStart] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }

        private Bitmap ResizeImage(string fileName) //이미지를 현재 picturebox 사이즈에 맞도록 수정 20181024 김진성
        {
            try
            {
                //image size 변환 추가 20181024 김진성
                int x = pictureBox1.Width;
                int y = pictureBox1.Height;

                Size resize = new Size(x, y);

                Bitmap newImage = new Bitmap(fileName);

                Bitmap resizeImage = new Bitmap(newImage, resize);

                newImage.Dispose();

                return resizeImage;
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWorkStart ResizeImage] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
                return null;
            }
        }

        private bool CheckSameFile(string FileName)
        {
            if (System.IO.File.Exists(FileName))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void frmWorkStart_ClientSizeChanged(object sender, EventArgs e)
        {
            BinddataGridView_AlcSet(ref dataGridView_Alc);
        }

        private void TagReSet()
        {
            try
            {
                Dabom.TagAdapter.Item.WorkDataUp datup = new Dabom.TagAdapter.Item.WorkDataUp(EquipInfo.WORKCENTER + "_" + EquipInfo.ROUTE_NO, true);

                datup.Variables.Add("TOOL_ASSY_POINT", new VariableItem { VarID = "TOOL_ASSY_POINT", Value = "1" });
                datup.Variables.Add("TOOL_VALUE", new VariableItem { VarID = "TOOL_VALUE", Value = "" });
                datup.Variables.Add("TOOL_PART_ID", new VariableItem { VarID = "TOOL_PART_ID", Value = EquipInfo.PART_ID });
                datup.Variables.Add("TR_ID", new VariableItem { VarID = "TR_ID", Value = EquipInfo.TR_ID });
                NetRemoting.Comm_IDSet_Etool(datup);

                //////
                slog = DateTime.Now + "[frmWorkStart TAG보냄] :      " + "1" + "/" + "TOOL_VALUE 초기화" + "/" + EquipInfo.PART_ID + "/" + EquipInfo.TR_ID;
                Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                //////  
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWorkTool] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }

        private void timer_mpis_Tick(object sender, EventArgs e)
        {
            try
            {
                timer_mpis.Enabled = false;
                if (MPIS_END == false)
                {
                    DataSet ds = new DataSet();
                    Procedure.PPC_MPIS(EquipInfo.WORKCENTER, EquipInfo.ROUTE_NO, ref ds);

                    //MPIS INTER LOCK 사용 여부
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        // 사양 존재 여부
                        ds.Dispose();
                        ds = new DataSet();
                        Procedure.PPC_MPIS_DTL_INFO(EquipInfo.WORKCENTER, EquipInfo.ROUTE_NO, EquipInfo.TR_ID, ref ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            //MPIS 이력 존재 여부
                            ds.Dispose();
                            ds = new DataSet();
                            Procedure.PPC_MPIS_LOAD_HIST(EquipInfo.WORKCENTER, EquipInfo.ROUTE_NO, EquipInfo.TR_ID, ref ds);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                slog = DateTime.Now + "[frmWorkStart MPIS 완료(작업완료)]";
                                Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                                ds.Dispose();
                                MPIS_END = true;
                            }
                        }
                        //사양 없음
                        else
                        {
                            slog = DateTime.Now + "[frmWorkStart MPIS 완료(사양없음)]";
                            Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                            ds.Dispose();
                            MPIS_END = true;
                        }
                    }
                    //인터락 사용 안함
                    else
                    {
                        slog = DateTime.Now + "[frmWorkStart MPIS 완료(INTERLOCK 사용안함)]";
                        Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                        ds.Dispose();
                        MPIS_END = true;
                    }
                }
                else
                {
                    if (IS_END == true && MPIS_END == true && DO_COMPLETE == false)
                    {
                        ProcessComPlete();
                        return;
                    }
                }

                timer_mpis.Enabled = true;
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWorkStart] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
                timer_mpis.Enabled = true;
            }

        }

        private void frmWorkStart_FormClosing(object sender, FormClosingEventArgs e)
        {
            //메모리 해제 구문 추가 20181023 김진성
            try
            {
                GC.Collect();
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWorkStart_FormClosing] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
            //구문 추가 END
        }
    }
}