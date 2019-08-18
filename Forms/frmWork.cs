using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MOBISDAS.Database;
using MOBISDAS.Global;
using MOBISDAS.Common;
using System.IO.Ports;
using Dabom.TagAdapter;
using Dabom.TagAdapter.Item;
using System.Net;

namespace MOBISDAS.Forms
{
    public partial class frmWork : frmLoad
    {
        private frmMsg frmMsg = null;
        private frmSubWork_Config frmSubWork_Config = null; 
        private string slog = "";
        //SERIAL 변수
        private string Serial_Port = "";
        private string Serial_Set = "";
        private string serialPortRECEIVE_DATA = "";

        private bool Timer_Start = false;

        // 서브장 작업표준서관련 유민호 추가
        public static bool open = false;
        private frmWorkBoard frmWorkBoard = null;
        public delegate void WorkBoard(Form WorkBoard);

        public frmWork(mdiMain tMDI)
        {
            TopLevel = false;        
            _mdiMain = tMDI;
            InitializeComponent();
            Dock = DockStyle.Fill;
        }

        private void frmWork_Load(object sender, EventArgs e)
        {
            try
            {
                CheckForIllegalCrossThreadCalls = false;
                Initialize();
                SerialPortOpen();
                Bind();

                // 서브장 작업표준서 추가 - 유민호
                if (EquipInfo.WORKCENTER.Substring(0, 3) != "CPM" && EquipInfo.WORKCENTER.Substring(0, 3) != "FEM")
                {   
                    if (!open && EquipInfo.Msg_Off == true && EquipInfo.BoardFlag == false && EquipInfo.Auto_Flag == true)
                    {
                        open = true;
                        WorkBoardFormLoad();
                    }
                }
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWork] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }

        private void Initialize()
        {
            try
            {
                if (EquipInfo.WORKCENTER.Substring(0, 3) != "FEM" && EquipInfo.WORKCENTER.Substring(0, 3) != "CPM")
                {
                    timer1_RFMain.Enabled = false;
                }
                else
                {
                    timer1_RFMain.Enabled = true;
                    timer1_RFMain.Start();
                }
                pnl_Barcode.Enabled = false;
                pnl_Barcode.Visible = false;
                txt_ReciveData.Focus();
                dataGridView_AlcSet(ref dataGridView_Alc);
                EquipInfo.Rtn = "START";
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWork] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }
        //시리얼 포트연결
        public void SerialPortOpen()
        {
            try
            {
                SerialPortClose();
                DataSet ds = new DataSet();
                Procedure.PPC_LINE_INFO(EquipInfo.WORKCENTER, EquipInfo.ROUTE_NO, ref ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Serial_Port = ds.Tables[0].Rows[0]["PORT"].ToString().Trim();
                    Serial_Set = ds.Tables[0].Rows[0]["SETTING"].ToString().Trim();

                    SerialPortSetting(ref serialPort1, "COM" + Serial_Port, Serial_Set);
                    if (!serialPort1.IsOpen)
                    {
                        serialPort1.Open();
                    }
                }                
                ds.Dispose();
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWork] :      " + ex;
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
            else if (serialPortSet[1] == "n")
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
        //시리얼 데이터 받기
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                System.Threading.Thread.Sleep(200);
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
                slog = DateTime.Now + "[frmWork] :      " + ex;
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
                    slog = DateTime.Now + "[frmWork : SerialPortClose 시리얼 포트 끊기] : " + Serial_Port + ":" + Serial_Set;
                    Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                }
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWork] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }
        //MAIN라인 화면에 데이터를 뿌려준다.
        private void Bind()
        {
            DataSet ds;
            string LastWork = "";
            try
            {
                //라스트 TR
                ds = new DataSet();
                if (EquipInfo.Virtual == false)
                {
                    Procedure.PPC_MAIN_LASTWORK_TRID(EquipInfo.WORKCENTER, EquipInfo.ROUTE_NO, ref ds);
                }
                else
                {
                    Procedure.PPC_VIRTUAL_MAIN_LASTWORK_TRID(EquipInfo.WORKCENTER, EquipInfo.ROUTE_NO, ref ds);
                }
                if (ds.Tables[0].Rows.Count > 0)
                {
                    LastWork = ds.Tables[0].Rows[0]["TR_ID"].ToString();
                }

                if (LastWork != "")
                {
                    //작업지시 상단 두줄
                    ds = new DataSet();
                    if (EquipInfo.Virtual == false)
                    {
                        Procedure.PPC_MAIN_TOP_LIST(EquipInfo.WORKCENTER, EquipInfo.ROUTE_NO, LastWork, ref ds);
                    }
                    else
                    {
                        Procedure.PPC_VIRTUAL_MAIN_TOP_LIST(EquipInfo.WORKCENTER, EquipInfo.ROUTE_NO, LastWork, ref ds);
                    }
                    if (ds.Tables[0].Rows.Count >= 1)
                    {
                        lbl_OrderDate_2.Text = ds.Tables[0].Rows[0]["ORDER_DATE"].ToString().Substring(4, 2) + "/" + ds.Tables[0].Rows[0]["ORDER_DATE"].ToString().Substring(6, 2);
                        lbl_Cmt_2.Text = ds.Tables[0].Rows[0]["COMMIT_NO"].ToString();
                        lbl_Body_No_2.Text = ds.Tables[0].Rows[0]["BODY_NO"].ToString();
                        // 유민호 추가 부분
                        EquipInfo.H_CAR_CODE = lbl_Body_No_2.Text.Length > 2 ? lbl_Body_No_2.Text.Substring(0, 2) : "";
                    }
                    if (ds.Tables[0].Rows.Count >= 2)
                    {
                        lbl_OrderDate_1.Text = ds.Tables[0].Rows[1]["ORDER_DATE"].ToString().Substring(4, 2) + "/" + ds.Tables[0].Rows[1]["ORDER_DATE"].ToString().Substring(6, 2);
                        lbl_Cmt_1.Text = ds.Tables[0].Rows[1]["COMMIT_NO"].ToString();
                        lbl_Body_No_1.Text = ds.Tables[0].Rows[1]["BODY_NO"].ToString();
                    }
                    else
                    {
                        lbl_OrderDate_1.Text = "";
                        lbl_Cmt_1.Text = "";
                        lbl_Body_No_1.Text = "";
                    }
                }
                else
                {
                    lbl_OrderDate_2.Text = "";
                    lbl_Cmt_2.Text = "";
                    lbl_Body_No_2.Text = "";

                    lbl_OrderDate_1.Text = "";
                    lbl_Cmt_1.Text = "";
                    lbl_Body_No_1.Text = "";
                }
                //작업지시 하단 세줄
                ds = new DataSet();
                if (EquipInfo.Virtual == false)
                {
                    Procedure.PPC_MAIN_DOWN_LIST(EquipInfo.WORKCENTER, EquipInfo.ROUTE_NO, LastWork, "", ref ds);
                }
                else
                {
                    Procedure.PPC_VIRTUAL_MAIN_DOWN_LIST(EquipInfo.WORKCENTER, EquipInfo.ROUTE_NO, LastWork, "", ref ds);
                }
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count >= 1)
                    {                        
                        lbl_OrderDate_3.Text = ds.Tables[0].Rows[0]["ORDER_DATE"].ToString().Substring(4, 2) + "/" + ds.Tables[0].Rows[0]["ORDER_DATE"].ToString().Substring(6, 2);
                        lbl_Cmt_3.Text = ds.Tables[0].Rows[0]["COMMIT_NO"].ToString();
                        lbl_Body_No_3.Text = ds.Tables[0].Rows[0]["BODY_NO"].ToString();

                        //작업폼 ,툴 폼에서  쓰기위해서 글로벌 변수에 넣는다. 이후 작업폼 전까지 글로벌 변수를 사용한다.
                        EquipInfo.TR_ID = ds.Tables[0].Rows[0]["TR_ID"].ToString();
                        EquipInfo.ORDER_DATE = ds.Tables[0].Rows[0]["ORDER_DATE"].ToString();
                        EquipInfo.CMT = ds.Tables[0].Rows[0]["COMMIT_NO"].ToString();
                        EquipInfo.BODY_NO = ds.Tables[0].Rows[0]["BODY_NO"].ToString();
                        EquipInfo.CAR_CODE = ds.Tables[0].Rows[0]["CAR_CODE"].ToString();
                        //////////////////////////////////////////////////////////////////////////////////////////////                       
                    }

                    if (ds.Tables[0].Rows.Count >= 2)
                    {
                        lbl_OrderDate_4.Text = ds.Tables[0].Rows[1]["ORDER_DATE"].ToString().Substring(4, 2) + "/" + ds.Tables[0].Rows[1]["ORDER_DATE"].ToString().Substring(6, 2);
                        lbl_Cmt_4.Text = ds.Tables[0].Rows[1]["COMMIT_NO"].ToString();
                        lbl_Body_No_4.Text = ds.Tables[0].Rows[1]["BODY_NO"].ToString();
                    }
                    else
                    {
                        lbl_OrderDate_4.Text = "";
                        lbl_Cmt_4.Text = "";
                        lbl_Body_No_4.Text = "";
                    }

                    if (ds.Tables[0].Rows.Count >= 3)
                    {
                        lbl_OrderDate_5.Text = ds.Tables[0].Rows[2]["ORDER_DATE"].ToString().Substring(4, 2) + "/" + ds.Tables[0].Rows[2]["ORDER_DATE"].ToString().Substring(6, 2);
                        lbl_Cmt_5.Text = ds.Tables[0].Rows[2]["COMMIT_NO"].ToString();
                        lbl_Body_No_5.Text = ds.Tables[0].Rows[2]["BODY_NO"].ToString();

                        //서열이 세개가 차면 타이머 중지
                        if (Timer_Start == true)
                        {
                            Timer_Start = false;
                            timer_Re.Stop();
                            timer_Re.Enabled = false;
                        }
                    }
                    else
                    {
                        lbl_OrderDate_5.Text = "";
                        lbl_Cmt_5.Text = "";
                        lbl_Body_No_5.Text = "";
                    }

                    //작업리스트
                    ds = new DataSet();
                    if (EquipInfo.Virtual == false)
                    {
                        Procedure.PPC_MAINDETAIL_LIST(EquipInfo.WORKCENTER, EquipInfo.ROUTE_NO, EquipInfo.CAR_CODE, EquipInfo.TR_ID, "M", ref ds);
                    }
                    else
                    {
                        Procedure.PPC_VIRTUAL_MAINDETAIL_LIST(EquipInfo.WORKCENTER, EquipInfo.ROUTE_NO, EquipInfo.CAR_CODE, EquipInfo.TR_ID, "M", ref ds);
                    }
                    dataGridView_Alc.RowTemplate = null;
                    dataGridView_Alc.DataSource = ds.Tables[0];
                    BinddataGridView_AlcSet(ref dataGridView_Alc);
                }
                else
                {
                    if (Timer_Start == false)
                    {
                        Timer_Start = true;                        
                        timer_Re.Enabled = true;
                        timer_Re.Start();

                        slog = DateTime.Now + "[frmWork- 타이머 동작] :      ";
                        Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                    }

                    lbl_OrderDate_3.Text = "";
                    lbl_Cmt_3.Text = "";
                    lbl_Body_No_3.Text = "";

                    lbl_OrderDate_4.Text = "";
                    lbl_Cmt_4.Text = "";
                    lbl_Body_No_4.Text = "";

                    lbl_OrderDate_5.Text = "";
                    lbl_Cmt_5.Text = "";
                    lbl_Body_No_5.Text = "";

                    DataTable dt = new DataTable();
                    dt.Columns.Add("@@PART_ID");
                    dt.Columns.Add("작업명");
                    dt.Columns.Add("ALC");
                    dt.Columns.Add("@@ASSY_SEQ");

                    dataGridView_Alc.DataSource = dt;
                    BinddataGridView_AlcSet(ref dataGridView_Alc);
                }               
               
                ds.Dispose();
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWork] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);              
            }
        }
        //SUB, TROLLY에서 작업지시 조정한 작지를 화면에 데이터를 뿌려준다.
        private void ChangBind()
        {
            DataSet ds;
            try
            {
                //작업지시 상단 두줄
                ds = new DataSet();
                if (EquipInfo.Virtual == false)
                {
                    Procedure.PPC_SUB_CHANGE_TOP_LIST(EquipInfo.WORKCENTER, EquipInfo.ROUTE_NO, EquipInfo.R_TR_ID, ref ds);
                }
                else
                {
                    Procedure.PPC_VIRTUAL_SUB_CHANGE_TOP_LIST(EquipInfo.WORKCENTER, EquipInfo.ROUTE_NO, EquipInfo.R_TR_ID, ref ds);
                }
                if (ds.Tables[0].Rows.Count >= 1)
                {
                    lbl_OrderDate_2.Text = ds.Tables[0].Rows[0]["ORDER_DATE"].ToString().Substring(4, 2) + "/" + ds.Tables[0].Rows[0]["ORDER_DATE"].ToString().Substring(6, 2);
                    lbl_Cmt_2.Text = ds.Tables[0].Rows[0]["COMMIT_NO"].ToString();
                    lbl_Body_No_2.Text = ds.Tables[0].Rows[0]["BODY_NO"].ToString();
                }

                if (ds.Tables[0].Rows.Count >= 2)
                {
                    lbl_OrderDate_1.Text = ds.Tables[0].Rows[1]["ORDER_DATE"].ToString().Substring(4, 2) + "/" + ds.Tables[0].Rows[1]["ORDER_DATE"].ToString().Substring(6, 2);
                    lbl_Cmt_1.Text = ds.Tables[0].Rows[1]["COMMIT_NO"].ToString();
                    lbl_Body_No_1.Text = ds.Tables[0].Rows[1]["BODY_NO"].ToString();
                }
                else
                {
                    lbl_OrderDate_1.Text = "";
                    lbl_Cmt_1.Text = "";
                    lbl_Body_No_1.Text = "";
                }
                //작업지시 하단 세줄
                ds = new DataSet();
                if (EquipInfo.Virtual == false)
                {
                    Procedure.PPC_SUB_CHANGE_DOWN_LIST(EquipInfo.WORKCENTER, EquipInfo.ROUTE_NO, EquipInfo.R_TR_ID, ref ds);
                }
                else
                {
                    Procedure.PPC_VIRTUAL_SUB_CHANGE_DOWN_LIST(EquipInfo.WORKCENTER, EquipInfo.ROUTE_NO, EquipInfo.R_TR_ID, ref ds);
                }
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //현재 작업해야할 TR 정보를 넣는다.
                    if (ds.Tables[0].Rows.Count >= 1)
                    {
                        lbl_OrderDate_3.Text = ds.Tables[0].Rows[0]["ORDER_DATE"].ToString().Substring(4, 2) + "/" + ds.Tables[0].Rows[0]["ORDER_DATE"].ToString().Substring(6, 2);
                        lbl_Cmt_3.Text = ds.Tables[0].Rows[0]["COMMIT_NO"].ToString();
                        lbl_Body_No_3.Text = ds.Tables[0].Rows[0]["BODY_NO"].ToString();

                        //작업폼 ,툴 폼에서  쓰기위해서 글로벌 변수에 넣는다. 이후 작업폼 전까지 글로벌 변수를 사용한다.
                        EquipInfo.TR_ID = ds.Tables[0].Rows[0]["TR_ID"].ToString();
                        EquipInfo.ORDER_DATE = ds.Tables[0].Rows[0]["ORDER_DATE"].ToString();
                        EquipInfo.CMT = ds.Tables[0].Rows[0]["COMMIT_NO"].ToString();
                        EquipInfo.BODY_NO = ds.Tables[0].Rows[0]["BODY_NO"].ToString();
                        EquipInfo.CAR_CODE = ds.Tables[0].Rows[0]["CAR_CODE"].ToString();
                        //////////////////////////////////////////////////////////////////////////////////////////////
                    }

                    if (ds.Tables[0].Rows.Count >= 2)
                    {
                        lbl_OrderDate_4.Text = ds.Tables[0].Rows[1]["ORDER_DATE"].ToString().Substring(4, 2) + "/" + ds.Tables[0].Rows[1]["ORDER_DATE"].ToString().Substring(6, 2);
                        lbl_Cmt_4.Text = ds.Tables[0].Rows[1]["COMMIT_NO"].ToString();
                        lbl_Body_No_4.Text = ds.Tables[0].Rows[1]["BODY_NO"].ToString();
                    }
                    else
                    {
                        lbl_OrderDate_4.Text = "";
                        lbl_Cmt_4.Text = "";
                        lbl_Body_No_4.Text = "";
                    }

                    if (ds.Tables[0].Rows.Count >= 3)
                    {
                        lbl_OrderDate_5.Text = ds.Tables[0].Rows[2]["ORDER_DATE"].ToString().Substring(4, 2) + "/" + ds.Tables[0].Rows[2]["ORDER_DATE"].ToString().Substring(6, 2);
                        lbl_Cmt_5.Text = ds.Tables[0].Rows[2]["COMMIT_NO"].ToString();
                        lbl_Body_No_5.Text = ds.Tables[0].Rows[2]["BODY_NO"].ToString();
                    }
                    else
                    {
                        lbl_OrderDate_5.Text = "";
                        lbl_Cmt_5.Text = "";
                        lbl_Body_No_5.Text = "";
                    }

                    //작업리스트
                    ds = new DataSet();
                    if (EquipInfo.Virtual == false)
                    {
                        Procedure.PPC_MAINDETAIL_LIST(EquipInfo.WORKCENTER, EquipInfo.ROUTE_NO, EquipInfo.CAR_CODE, EquipInfo.TR_ID, "M", ref ds);
                    }
                    else
                    {
                        Procedure.PPC_VIRTUAL_MAINDETAIL_LIST(EquipInfo.WORKCENTER, EquipInfo.ROUTE_NO, EquipInfo.CAR_CODE, EquipInfo.TR_ID, "M", ref ds);
                    }
                    dataGridView_Alc.RowTemplate = null;
                    dataGridView_Alc.DataSource = ds.Tables[0];
                    BinddataGridView_AlcSet(ref dataGridView_Alc);
                }
                else
                {
                    lbl_OrderDate_3.Text = "";
                    lbl_Cmt_3.Text = "";
                    lbl_Body_No_3.Text = "";

                    lbl_OrderDate_4.Text = "";
                    lbl_Cmt_4.Text = "";
                    lbl_Body_No_4.Text = "";

                    lbl_OrderDate_5.Text = "";
                    lbl_Cmt_5.Text = "";
                    lbl_Body_No_5.Text = "";

                    DataTable dt = new DataTable();
                    dt.Columns.Add("@@PART_ID");
                    dt.Columns.Add("작업명");
                    dt.Columns.Add("ALC");
                    dt.Columns.Add("@@ASSY_SEQ");

                    dataGridView_Alc.DataSource = dt;
                    BinddataGridView_AlcSet(ref dataGridView_Alc);
                }               

                ds.Dispose();
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWork] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }
        //스캔 데이터에서 바디바코드나 뷰테이블에서 태그 아이디의 바디 넘버가 같으면 작업을 시작한다.
        private void ProcessJob(string Body_Barcode)
        {
            DataSet ds;
            string sINPUT_FLAG = "";
            string tmpRsBODY_NO = "";
            int Before_Cnt;

            try
            {
                EquipInfo.BARCODE = Body_Barcode;

                if (EquipInfo.WORKCENTER.Substring(0, 3) != "FEM" && EquipInfo.WORKCENTER.Substring(0, 3) != "CPM")
                {
                    ds = new DataSet();
                    if (EquipInfo.Virtual == false)
                    {
                        Procedure.PPC_BEFORE_ROUTE_CHECK(EquipInfo.WORKCENTER, EquipInfo.CAR_CODE, EquipInfo.ROUTE_NO, EquipInfo.BODY_NO + EquipInfo.ORDER_DATE + EquipInfo.CMT, ref ds);
                    }
                    else
                    {
                        Procedure.PPC_VIRTUAL_BEFORE_ROUTE_CHECK(EquipInfo.WORKCENTER, EquipInfo.CAR_CODE, EquipInfo.ROUTE_NO, EquipInfo.BODY_NO + EquipInfo.ORDER_DATE + EquipInfo.CMT, ref ds);
                    }
                    Before_Cnt = ds.Tables[0].Rows.Count;

                    if (Before_Cnt == 0)
                    {
                        //////
                        slog = DateTime.Now + "[frmWork-이전공정에서 작업 안함.] :      ";
                        Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                        //////
                        frmMessageClose();

                        // 2014 10 08 유민호 추가 부분
                        if (open)
                        {
                            open = false;
                            frmWorkBoadrClose();
                            EquipInfo.BoardFlag = false;
                        }
                        System.Threading.Thread.Sleep(200);
                       

                        MassageFormLoad("BEFORE_ROUTE_CHECK", lbl_Body_No_3.Text + "가 이전 공정에서\r\r작업한 이력이 없습니다.\r\r계속하시겠습니까? ");
                        if (EquipInfo.Rtn == "NO")
                        {                            
                            EquipInfo.Rtn = "START";
                            frmMessageClose();
                            timer1_RFMain.Start();
                            return;
                        }
                        else if (EquipInfo.Rtn == "OK")
                        {
                            //////
                            slog = DateTime.Now + "[frmWorkStart 폼으로] :      ";
                            Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                            //////
                            WorkFormLoad();
                        }
                    }

                    if (Body_Barcode.Contains("ACTION"))
                    {
                        // 20141006 서브 작업표준서 유민호 추가부분
                        // 20141117 유민호 수정 부분
                        if (open == true || EquipInfo.BoardFlag == true)
                        {
                            open = false;
                            frmWorkBoadrClose();
                            EquipInfo.BoardFlag = false;
                        }
                        WorkFormLoad();
                    }
                }
                else
                {
                    if (Body_Barcode.Length == 22)
                    {
                        //
                        slog = DateTime.Now + "   " + EquipInfo.WORKCENTER + "_" + EquipInfo.ROUTE_NO + "[MAIN 작업시작] :      " + Body_Barcode;
                        Global.EquipInfo.fhLog.TextFileWriteAppend(slog);

                        //스캔 바디 넘버, 수동으로 입력한 바디 넘버 와 3번째줄 바디 넘버와 비교
                        if (lbl_Body_No_3.Text != Body_Barcode.Substring(0, 10))
                        {
                            if (txt_Barcode.Text != "")
                            {
                                EquipInfo.BODY_NO = txt_Barcode.Text.Substring(0, 10);
                                EquipInfo.ORDER_DATE = txt_Barcode.Text.Substring(10, 8);
                                EquipInfo.CMT = txt_Barcode.Text.Substring(18, 4);
                                EquipInfo.CAR_CODE = txt_Barcode.Text.Substring(0, 2);
                            }
                            else
                            {
                                EquipInfo.BODY_NO = Body_Barcode.Substring(0, 10);
                                EquipInfo.ORDER_DATE = Body_Barcode.Substring(10, 8);
                                EquipInfo.CMT = Body_Barcode.Substring(18, 4);
                                EquipInfo.CAR_CODE = Body_Barcode.Substring(0, 2);
                            }

                            ds = new DataSet();
                            Procedure.PPC_VW_LINETRK(EquipInfo.WORKCENTER, EquipInfo.ROUTE_NO, ref ds);
                            //////
                            slog = DateTime.Now + "[frmWork-공정 스키드 체크 SP] :      " + EquipInfo.WORKCENTER + "/" + EquipInfo.ROUTE_NO;
                            Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                            //////

                            //2013.08.14 서동신대리의 요청으로 스키드가 없어도 작업화면 전환 할수 있게 함.//////
                            //if (ds.Tables[0].Rows[0]["TR_ID"].ToString() == "0")
                            //{
                            //    //////
                            //    slog = DateTime.Now + "[frmWork-스키드 없음 들어옴] :      ";
                            //    Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                            //    //////
                            //    frmMessageClose();
                            //    MassageFormLoad("INPUT_FLAG_CHECK", "현 공정에 스키드 정보가 없습니다.");
                            //    frmMessageClose();
                            //    EquipInfo.Rtn = "START";
                            //    frmMessageClose();
                            //    timer1_RFMain.Start();

                            //    return;
                            //}
                            ///////////////////////////////////////////////////////////////////////////////////


                            //수신한 계획이 있는지 확인
                            ds = new DataSet();
                            if (EquipInfo.Virtual == false)
                            {
                                Procedure.PPC_TRID(EquipInfo.WORKCENTER, Body_Barcode.Substring(10, 8), Body_Barcode.Substring(18, 4), Body_Barcode.Substring(0, 10), ref ds);
                            }
                            else
                            {
                                Procedure.PPC_VIRTUAL_TRID(EquipInfo.WORKCENTER, Body_Barcode.Substring(10, 8), Body_Barcode.Substring(18, 4), Body_Barcode.Substring(0, 10), ref ds);
                            }
                            //////
                            slog = DateTime.Now + "[frmWork-작업수신 확인 SP] :      " + EquipInfo.WORKCENTER + "/" + Body_Barcode.Substring(10, 8) + "/" + Body_Barcode.Substring(18, 4) + "/" + Body_Barcode.Substring(0, 10);
                            Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                            //////
                            if (ds.Tables[0].Rows.Count < 0)
                            {
                                //////
                                slog = DateTime.Now + "[frmWork-바코드 데이터 이상 들어옴] :      ";
                                Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                                //////

                                //수신한 계획이 없으면 없으면 바코드 이상으로 미들웨어 태그에 NG 보내고 메세지 뿌리고 나가기
                                NetRemoting.TagSet(EquipInfo.WORKCENTER + "_" + EquipInfo.ROUTE_NO + "_OKNG", "0001");
                                slog = DateTime.Now + "   [" + EquipInfo.ROUTE_NO + "-MAIN] :      " + Body_Barcode;
                                Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                                frmMessageClose();
                                MassageFormLoad("BARCODE ERROR", "바코드 데이터 이상");                               
                                EquipInfo.Rtn = "START";
                                frmMessageClose();
                                timer1_RFMain.Start();

                                return;
                            }
                            else
                            {
                                //////
                                slog = DateTime.Now + "[frmWork-작업서열 있음.] :      ";
                                Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                                //////

                                //수신한 계획이 있으면 재작업인지 확인
                                EquipInfo.TR_ID = ds.Tables[0].Rows[0]["TR_ID"].ToString();
                                //투입된 서열인지 체크 (메인만 체크한다.)
                                ds = new DataSet();
                                if (EquipInfo.Virtual == false)
                                {
                                    Procedure.PPC_INPUT_FLAG(EquipInfo.WORKCENTER, Body_Barcode.Substring(10, 8), Body_Barcode.Substring(18, 4), Body_Barcode.Substring(0, 10), ref ds);
                                }
                                else
                                {
                                    Procedure.PPC_VIRTUAL_INPUT_FLAG(EquipInfo.WORKCENTER, Body_Barcode.Substring(10, 8), Body_Barcode.Substring(18, 4), Body_Barcode.Substring(0, 10), ref ds);
                                }
                                sINPUT_FLAG = ds.Tables[0].Rows[0]["INPUT_FLAG"].ToString();
                                //////
                                slog = DateTime.Now + "[frmWork-투입서열 확인 SP] :      " + EquipInfo.WORKCENTER + "/" + Body_Barcode.Substring(10, 8) + "/" + Body_Barcode.Substring(18, 4) + "/" + Body_Barcode.Substring(0, 10) + "/" + sINPUT_FLAG;
                                Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                                //////
                                if (sINPUT_FLAG == "Y")
                                {
                                    //////
                                    slog = DateTime.Now + "[frmWork-투입된 서열임.] :      ";
                                    Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                                    //////

                                    //투입된 서열이라면 재작업인지 확인
                                    ds = new DataSet();
                                    if (EquipInfo.Virtual == false)
                                    {
                                        Procedure.PPC_REWORK_CHECK(EquipInfo.WORKCENTER, EquipInfo.ROUTE_NO, EquipInfo.TR_ID, ref ds);
                                    }
                                    else
                                    {
                                        Procedure.PPC_VIRTUAL_REWORK_CHECK(EquipInfo.WORKCENTER, EquipInfo.ROUTE_NO, EquipInfo.TR_ID, ref ds);
                                    }
                                    //////
                                    slog = DateTime.Now + "[frmWork-재작업 확인 SP] :      " + EquipInfo.WORKCENTER + "/" + EquipInfo.ROUTE_NO + "/" + EquipInfo.TR_ID;
                                    Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                                    //////
                                    if (ds.Tables[0].Rows.Count > 0)
                                    {
                                        //////
                                        slog = DateTime.Now + "[frmWork-재작업 서열임.] :      " + ds.Tables[0].Rows.Count;
                                        Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                                        //////
                                        //재작업한 이력이 있으면 메세지 뿌리기
                                        frmMessageClose();
                                        MassageFormLoad("REWORK", Body_Barcode.Substring(0, 10) + "이 현공정에서\r\r작업한 이력이 있습니다.");
                                        if (EquipInfo.Rtn == "NO")
                                        {
                                            EquipInfo.Rtn = "START";
                                            frmMessageClose();
                                            timer1_RFMain.Start();

                                            return;
                                        }
                                    }
                                }
                                else
                                {
                                    //투입된 서열 바디바코드가 아니면 메세지 뿌리기...
                                    //////
                                    slog = DateTime.Now + "[frmWork-투입된 서열이 아님] :      " + sINPUT_FLAG;
                                    Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                                    //////
                                    frmMessageClose();
                                    MassageFormLoad("INPUT_FLAG_CHECK", "투입된 서열이 아닙니다.");
                                    EquipInfo.Rtn = "START";
                                    frmMessageClose();
                                    timer1_RFMain.Start();

                                    return;
                                }
                            }
                        }
                        else
                        {
                            //뷰테이블에서 들어온 바디정보 순서가 맞더라도 해당 스키드 확인(바코드를 이용해 읽을 경우 다른 경우가 생길 수 있음)
                            ds = new DataSet();
                            Procedure.PPC_VW_LINETRK(EquipInfo.WORKCENTER, EquipInfo.ROUTE_NO, ref ds);
                            //////
                            slog = DateTime.Now + "[frmWork-뷰 테일블 확인 SP] :      " + EquipInfo.WORKCENTER + "/" + EquipInfo.ROUTE_NO;
                            Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                            //////
                            if (ds.Tables[0].Rows.Count != 0)
                            {
                                tmpRsBODY_NO = ds.Tables[0].Rows[0]["BODY_NO"].ToString();
                                if (tmpRsBODY_NO != Body_Barcode.Substring(0, 10))
                                {
                                    //////
                                    slog = DateTime.Now + "[frmWork-스키드 일치 하지 않음] :      " + "뷰" + tmpRsBODY_NO + "/" + "데이터" + Body_Barcode.Substring(0, 10);
                                    Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                                    //////
                                    frmMessageClose();
                                    MassageFormLoad("SKID", "현재 스키드 : " + tmpRsBODY_NO + "\r\r" + "서열 투입순서는 일치하지만 \r\r" + "스키드 정보와는 일치하지 않습니다.\r\r" + "계속하시겠습니까?");
                                    if (EquipInfo.Rtn == "NO")
                                    {
                                        EquipInfo.Rtn = "START";
                                        frmMessageClose();
                                        timer1_RFMain.Start();

                                        return;
                                    }
                                }
                            }
                            //스키드 정보와 일치 하지 않지만 작업을 하겠다 하면 이전공정 작업유무 확인 뷰테이블과 3번째줄이 같으면 글로벌 변수를 사용한다.
                            ds = new DataSet();
                            if (EquipInfo.Virtual == false)
                            {
                                Procedure.PPC_BEFORE_ROUTE_CHECK(EquipInfo.WORKCENTER, EquipInfo.BODY_NO.Substring(0, 2), EquipInfo.ROUTE_NO, Body_Barcode, ref ds);
                            }
                            else
                            {
                                Procedure.PPC_VIRTUAL_BEFORE_ROUTE_CHECK(EquipInfo.WORKCENTER, EquipInfo.BODY_NO.Substring(0, 2), EquipInfo.ROUTE_NO, Body_Barcode, ref ds);
                            }
                            //////
                            slog = DateTime.Now + "[frmWork-이전공정 체크 SP] :      " + EquipInfo.WORKCENTER + "/" + EquipInfo.BODY_NO.Substring(0, 2) + "/" + EquipInfo.ROUTE_NO + "/" + Body_Barcode;
                            Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                            //////
                            Before_Cnt = ds.Tables[0].Rows.Count;

                            //////
                            slog = DateTime.Now + "[frmWork-이전공정 체크 SP 결과 COUNT 수] :      " + Before_Cnt;
                            Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                            //////

                            if (Before_Cnt == 0)
                            {
                                //////
                                slog = DateTime.Now + "[frmWork-이전공정에서 작업 안함.] :      ";
                                Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                                //////
                                frmMessageClose();
                                MassageFormLoad("BEFORE_ROUTE_CHECK", Body_Barcode.Substring(0, 10) + "가 이전 공정에서\r\r작업한 이력이 없습니다.\r\r계속하시겠습니까? ");
                                if (EquipInfo.Rtn == "NO")
                                {
                                    EquipInfo.Rtn = "START";
                                    frmMessageClose();
                                    timer1_RFMain.Start();

                                    return;
                                }
                                else if (EquipInfo.Rtn == "OK")
                                {
                                    //////
                                    slog = DateTime.Now + "[frmWorkStart 폼으로] :      ";
                                    Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                                    //////

                                    WorkFormLoad();
                                }
                            }
                        }
                        if (EquipInfo.Rtn == "OK" || EquipInfo.Rtn == "START")
                        {
                            //////
                            slog = DateTime.Now + "[이전 공정에서 작업했고 frmWorkStart 폼으로] :      ";
                            Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                            //////

                             WorkFormLoad();
                        }
                    }
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
            if(frmMsg != null)
            {
                frmMsg.Close();
                frmMsg = null;
            }

        }
        // 작업화면으로 전환한다.
        private void WorkFormLoad()
        {
            try
            {
                while (serialPort1.IsOpen)
                {
                    System.Threading.Thread.Sleep(100);
                    SerialPortClose();
                }

                EquipInfo._Frm = "frmWorkStart";
                slog = DateTime.Now + "[frmWork - frmWorkStart 폼 로드] :      ";
                Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                //2017.09.08 폼로드(작업화면전환) 로그 남김 신도혁
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWork] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }
        private void MassageFormLoad(string Gubun,string Msg)
        {
            try
            {
                if (frmMsg == null)
                {
                    timer1_RFMain.Stop();
                    frmMsg = new frmMsg(Gubun, Msg);
                    frmMsg.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWork] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }
        //오른쪽 그리드 설정
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
                dataGridView.ColumnHeadersHeight = 57;
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

                dataGridView.DefaultCellStyle.Font = new System.Drawing.Font("HY견고딕", 58.00F, FontStyle.Bold);
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
                slog = DateTime.Now + "[frmWork] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }

        }
        //오른쪽 그리드에 데이터 처리
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
                dataGridView.Columns[1].Width = dataGridView.Width * 50 / 100;
                dataGridView.Columns[2].Width = dataGridView.Width * 50 / 100;
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

                for (int i = 0; i < dataGridView.Rows.Count - e_toolcount; i++)
                {
                    int iRowsHeight = (dataGridView.Height - iColumnHeaderHeight) / (dataGridView.Rows.Count - e_toolcount);
                    dataGridView.Rows[i].Height = iRowsHeight;
                    dataGridView.Rows[i].Cells["작업명"].Style.Font = new System.Drawing.Font("HY견고딕", 26.00F, FontStyle.Bold);
                    if (dataGridView.Rows.Count > 4)
                    {
                        dataGridView.Rows[i].Cells["ALC"].Style.Font = new System.Drawing.Font("HY견고딕", 50.00F, FontStyle.Bold);
                    }
                }
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWork] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }
        //수동으로 작업지시 번호를 입력 했을때..
        private void btn_Bar_OK_Click(object sender, EventArgs e)
        {
            try
            {
               
                //////
                slog = DateTime.Now + "[frmWork-수동입력] :      " + txt_Barcode.Text;
                Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                //////

                if (EquipInfo.WORKCENTER.Substring(0, 3) == "FEM" || EquipInfo.WORKCENTER.Substring(0, 3) == "CPM")
                {
                    //이벤트 메세지 확인
                    EventMessage(txt_Barcode.Text.Substring(0, 10));
                }

                ProcessJob(txt_Barcode.Text);
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWork] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }
        //수동 바코드 입력하는 TEXTBOX 보이기
        private void lbl_title1_Click(object sender, EventArgs e)
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

                //ds4eym
                //txt_Barcode.Text = lbl_Body_No_3.Text + "2016" + lbl_OrderDate_3.Text.Replace("/", "") + lbl_Cmt_3.Text;
            }
        }
        //VIEW 테이블에서 태그아이디에 바디 넘버로 비교해서 작업화면으로 전환한다.
        private void timer1_RFMain_Tick(object sender, EventArgs e)
        {
            string tmpRsBODY_NO = "";
            string tmpRsBODY_BARCODE = "";
            try
            {
                DataSet ds = new DataSet();
                Procedure.PPC_VW_LINETRK(EquipInfo.WORKCENTER, EquipInfo.ROUTE_NO, ref ds);
                if (ds.Tables[0].Rows[0]["TR_ID"].ToString() != "0")
                {
                    tmpRsBODY_NO= ds.Tables[0].Rows[0]["BODY_NO"].ToString();
                    tmpRsBODY_BARCODE = ds.Tables[0].Rows[0]["BODY_BARCODE"].ToString();

                    if (tmpRsBODY_NO != "" && tmpRsBODY_NO == lbl_Body_No_3.Text)
                    {
                        //////
                        slog = DateTime.Now + "[frmWork-뷰테이블 자동] :      " + tmpRsBODY_BARCODE;
                        Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                        //////

                        if (EquipInfo.WORKCENTER.Substring(0, 3) == "FEM" || EquipInfo.WORKCENTER.Substring(0, 3) == "CPM")
                        {
                            //이벤트 메세지 확인
                            EventMessage(tmpRsBODY_BARCODE.Substring(0, 10));
                        }

                        ProcessJob(tmpRsBODY_BARCODE);
                        
                        if (EquipInfo.Rtn == "NO")
                        {
                            frmMessageClose();
                        }
                    }
                }

                ds.Dispose();
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWork] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }
        //시리얼 포트(스캐너로 받는 데이터 처리)
        private void txt_ReciveData_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string RecieveData = "";
                if (txt_ReciveData.Text.IndexOf("\r\n") != -1)
                {
                    RecieveData = txt_ReciveData.Text.Replace("\r\n", "");
                    //////
                    slog = DateTime.Now + "[frmWork-스캐너리딩] :      " + RecieveData;
                    Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                    //////
                    
                    if (EquipInfo.WORKCENTER.Substring(0, 3) == "FEM" || EquipInfo.WORKCENTER.Substring(0, 3) == "CPM")
                    {
                        //이벤트 메세지 확인
                        EventMessage(RecieveData.Substring(0, 10));
                    }
                    ProcessJob(RecieveData);

                    txt_ReciveData.Text = "";                                       
                }
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWork] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }

        private void timer_Sub_Tick(object sender, EventArgs e)
        {
            timer_Sub.Stop();
            timer_Sub.Enabled = false; 

            Bind();
        }

        private void frmWork_ClientSizeChanged(object sender, EventArgs e)
        {
            BinddataGridView_AlcSet(ref dataGridView_Alc);
        }

        private void EventMessage(string BODY_NO)
        {
            try
            {
                DataSet ds = new DataSet();
                if (EquipInfo.Virtual == false)
                {
                    Procedure.PPC_EVENT_MESSAGE(EquipInfo.WORKCENTER, EquipInfo.ROUTE_NO, BODY_NO, ref ds);
                }
                else
                {
                    Procedure.PPC_VIRTUAL_EVENT_MESSAGE(EquipInfo.WORKCENTER, EquipInfo.ROUTE_NO, BODY_NO, ref ds);
                }
                if (ds.Tables[0].Rows.Count > 0)
                {
                    EquipInfo.Message_Timer_Interval = int.Parse(ds.Tables[0].Rows[0]["SHOW_TIME"].ToString()) * 1000;
                    frmMessageClose();
                    MassageFormLoad("EVENT_MESSAGE", ds.Tables[0].Rows[0]["MSG"].ToString());
                    frmMessageClose();
                }

            }
            catch (Exception ex)
            {
            }
        }

        private void timer_Re_Tick(object sender, EventArgs e)
        {
            Bind();
        }

        private void lbl_title2_Click(object sender, EventArgs e)
        {
            if (pnl_Virtual.Visible)
            {
                pnl_Virtual.Enabled = false;
                pnl_Virtual.Visible = false;
                bnt_Original.Enabled = false;
                bnt_Original.Visible = false;
                bnt_Virtual.Enabled = false;
                bnt_Virtual.Visible = false;
            }
            else
            {
                pnl_Virtual.Enabled = true;
                pnl_Virtual.Visible = true;
                bnt_Original.Enabled = true;
                bnt_Original.Visible = true;
                bnt_Virtual.Enabled = true;
                bnt_Virtual.Visible = true;
            }
        }

        private void bnt_Original_Click(object sender, EventArgs e)
        {
            EquipInfo.Virtual = false;
            Bind();
        }

        private void bnt_Virtual_Click(object sender, EventArgs e)
        {
            EquipInfo.Virtual = true;
            Bind();
        }

        private void lbl_Body_No_3_DoubleClick(object sender, EventArgs e)
        {
            if (EquipInfo.WORKCENTER.Substring(0, 3) != "CPM" && EquipInfo.WORKCENTER.Substring(0, 3) != "FEM")
            {
                frmSubWork_Config = new frmSubWork_Config(EquipInfo.ORDER_DATE);
                frmSubWork_Config.ShowDialog();
                if (EquipInfo.R_Rtn != "")
                {
                    ChangBind();
                    timer_Sub.Enabled = true;
                }
                else
                {
                    Bind();
                }               
            }
        }

        /// <summary>
        /// 작업표준서 폼 로드
        /// </summary>
        /// <param name="flag"></param>
        private void WorkBoardFormLoad()
        {
            try
            {
                if (frmWorkBoard == null)
                {
                    frmWorkBoard = new frmWorkBoard();
                    frmWorkBoard_Set(frmWorkBoard);
                }
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWorkBoard] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }

        /// <summary>
        /// 작업표준서 폼 셋
        /// </summary>
        /// <param name="_WorkBoard"></param>
        private void frmWorkBoard_Set(Form _WorkBoard)
        {
            try
            {
                if (this.InvokeRequired)
                    this.Invoke(new WorkBoard(frmWorkBoard_Set), new object[] { _WorkBoard });
                else
                    frmWorkBoard.ShowDialog();
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWorkBoard_SUB] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }

        /// <summary>
        /// 작업표준서 폼 클로즈
        /// </summary>
        private void frmWorkBoadrClose()
        {
            try
            {
                if (frmWorkBoard != null)
                {
                    frmWorkBoard.Close();
                    frmWorkBoard = null;
                }
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWorkBoadrClose_SUB] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }
    }
}