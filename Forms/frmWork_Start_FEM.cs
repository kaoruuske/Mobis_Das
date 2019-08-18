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

namespace MOBISDAS.Forms
{
    public partial class frmWork_Stark_FEM : frmLoad
    {
        private frmMsg frmMsg = null;
        private string slog = "";
        //SERIAL 변수
        private string Serial_Port = "";
        private string Serial_Set = "";
        private string serialPortRECEIVE_DATA = "";

        private bool First_data = false;
        private bool Scan_Flag = false;
        private bool Skid_Flag = false;

        public delegate void WorkMsg(Form WorkMsg);

        public frmWork_Stark_FEM(mdiMain tMDI)
        {

            //-- TEST 끊김 현상 확인
            slog = DateTime.Now + "[frmWork_Start_FEM : mdiMain tMDI] :  Phase 1 - Enter"; 
            Global.EquipInfo.fhLog.TextFileWriteAppend(slog);

            TopLevel = false;        
            _mdiMain = tMDI;
            InitializeComponent();
            Dock = DockStyle.Fill;

            //-- TEST 끊김 현상 확인
            slog = DateTime.Now + "[frmWork_Start_FEM : mdiMain tMDI] :  Phase 2 - DockStyle.Fill";
            Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
        }
        private void frmWork_Stark_FEM_Shown(object sender, EventArgs e)
        {
            try
            {

                //-- TEST 끊김 현상 확인
                slog = DateTime.Now + "[frmWork_Stark_FEM_Shown ] :  Phase 3 - Enter";
                Global.EquipInfo.fhLog.TextFileWriteAppend(slog);

                Initialize();
                SerialPortOpen();

                //-- TEST 끊김 현상 확인
                slog = DateTime.Now + "[frmWork_Stark_FEM_Shown ] :  Phase 4 - SerialPortOpen END";
                Global.EquipInfo.fhLog.TextFileWriteAppend(slog);

                Bind();

                //-- TEST 끊김 현상 확인
                slog = DateTime.Now + "[frmWork_Stark_FEM_Shown ] :  Phase 5 - Bind() END";
                Global.EquipInfo.fhLog.TextFileWriteAppend(slog);


            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWork_Stark_FEM] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }
        private void Initialize()
        {
            try
            {
                First_data = true;
                Scan_Flag = true;

                timer_Re.Enabled = true;
                timer_Re.Start();                

                pnl_Barcode.Enabled = false;
                pnl_Barcode.Visible = false;
                txt_ReciveData.Focus();
                dataGridView_AlcSet(ref dataGridView_Alc);
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWork_Stark_FEM] :      " + ex;
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
                slog = DateTime.Now + "[frmWork_Stark_FEM] :      " + ex;
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
        //시리얼 데이터 받기
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                System.Threading.Thread.Sleep(500);
                string buff = serialPort1.ReadExisting();
                if (buff.IndexOf("\r") > 0)
                {
                    serialPortRECEIVE_DATA += buff;                 
                    txt_ReciveData.Text = serialPortRECEIVE_DATA;
                    serialPortRECEIVE_DATA = "";
                }
                else
                {
                    serialPortRECEIVE_DATA += buff;
                }
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWork_Stark_FEM] :      " + ex;
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
                    slog = DateTime.Now + "[frmWork_Start_FEM : SerialPortClose 시리얼 포트 끊기] : " + Serial_Port + ":" + Serial_Set;
                    Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                }
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWork_Stark_FEM] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }
        //화면에 데이터를 뿌려준다.
        private void Bind()
        {
            DataSet ds;
            string Skid = "";

            try
            {
                //작업지시 상단 두줄
                ds = new DataSet();
                if (EquipInfo.Virtual == false)
                {
                    Procedure.PPC_MAIN_START_TOP_LIST(EquipInfo.WORKCENTER, ref ds);
                }
                else
                {
                    Procedure.PPC_VIRTUAL_MAIN_START_TOP_LIST(EquipInfo.WORKCENTER, ref ds);
                }
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lbl_Skid_2.Text = ds.Tables[0].Rows[0]["TAG_ID"].ToString().Substring(11, 5);
                    lbl_OrderDate_2.Text = ds.Tables[0].Rows[0]["ORDER_DATE"].ToString().Substring(4, 2) + "/" + ds.Tables[0].Rows[0]["ORDER_DATE"].ToString().Substring(6, 2);
                    lbl_Cmt_2.Text = ds.Tables[0].Rows[0]["COMMIT_NO"].ToString();
                    lbl_Body_No_2.Text = ds.Tables[0].Rows[0]["BODY_NO"].ToString();
                    lbl_Drive_2.Text = ds.Tables[0].Rows[0]["DRIVE"].ToString();
                    // 유민호 추가 부분
                    EquipInfo.H_CAR_CODE = lbl_Body_No_2.Text.Length > 2 ? lbl_Body_No_2.Text.Substring(0, 2) : "";

                    lbl_Skid_1.Text = ds.Tables[0].Rows[1]["TAG_ID"].ToString().Substring(11, 5);
                    lbl_OrderDate_1.Text = ds.Tables[0].Rows[1]["ORDER_DATE"].ToString().Substring(4, 2) + "/" + ds.Tables[0].Rows[1]["ORDER_DATE"].ToString().Substring(6, 2);
                    lbl_Cmt_1.Text = ds.Tables[0].Rows[1]["COMMIT_NO"].ToString();
                    lbl_Body_No_1.Text = ds.Tables[0].Rows[1]["BODY_NO"].ToString();
                    lbl_Drive_1.Text = ds.Tables[0].Rows[1]["DRIVE"].ToString();
                }
                else
                {
                    lbl_Skid_2.Text = "";
                    lbl_OrderDate_2.Text = "";
                    lbl_Cmt_2.Text = "";
                    lbl_Body_No_2.Text = "";
                    lbl_Drive_2.Text = "";

                    lbl_Skid_1.Text = "";
                    lbl_OrderDate_1.Text = "";
                    lbl_Cmt_1.Text = "";
                    lbl_Body_No_1.Text = "";
                    lbl_Drive_1.Text = "";
                }
                //작업지시 하단 세줄
                ds = new DataSet();
                if (EquipInfo.Virtual == false)
                {
                    Procedure.PPC_MAIN_START_DOWN_LIST(EquipInfo.WORKCENTER, ref ds);
                }
                else
                {
                    Procedure.PPC_VIRTUAL_MAIN_START_DOWN_LIST(EquipInfo.WORKCENTER, ref ds);
                }
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count >= 1)
                    {                       
                        DataSet ds_skid = new DataSet();
                        Procedure.PPC_VW_LINETRK_SKID(EquipInfo.WORKCENTER, EquipInfo.ROUTE_NO, ref ds_skid);

                        if (ds_skid.Tables[0].Rows.Count > 0)
                        {
                            Skid = ds_skid.Tables[0].Rows[0]["TAG_ID"].ToString();

                            if (Skid != "")
                            {
                                /////////////////////////////////////////////////////////////
                                lbl_Skid_3.BackColor = Color.Lime;
                                lbl_OrderDate_3.BackColor = Color.Lime;
                                lbl_Cmt_3.BackColor = Color.Lime;
                                lbl_Body_No_3.BackColor = Color.Lime;
                                lbl_Drive_3.BackColor = Color.Lime;
                                ////////////////////////////////////////////////////////////

                                lbl_Skid_3.Text = Skid;
                            }
                        }
                        else
                        {
                            /////////////////////////////////////////////////////////////
                            lbl_Skid_3.BackColor = Color.Gold;
                            lbl_OrderDate_3.BackColor = Color.Gold;
                            lbl_Cmt_3.BackColor = Color.Gold;
                            lbl_Body_No_3.BackColor = Color.Gold;
                            lbl_Drive_3.BackColor = Color.Gold;
                            ////////////////////////////////////////////////////////////

                            lbl_Skid_3.Text = ds.Tables[0].Rows[0]["TAG_ID"].ToString().Substring(11, 5);
                        }
                        lbl_OrderDate_3.Text = ds.Tables[0].Rows[0]["ORDER_DATE"].ToString().Substring(4, 2) + "/" + ds.Tables[0].Rows[0]["ORDER_DATE"].ToString().Substring(6, 2);
                        lbl_Cmt_3.Text = ds.Tables[0].Rows[0]["COMMIT_NO"].ToString();
                        lbl_Body_No_3.Text = ds.Tables[0].Rows[0]["BODY_NO"].ToString();
                        lbl_Drive_3.Text = ds.Tables[0].Rows[0]["DRIVE"].ToString();

                        //작업폼 ,툴 폼에서  쓰기위해서 글로벌 변수에 넣는다. 이후 작업폼 전까지 글로벌 변수를 사용한다.       
                        if (First_data == true)
                        {
                            EquipInfo.TR_ID = ds.Tables[0].Rows[0]["TR_ID"].ToString();
                            EquipInfo.ORDER_DATE = ds.Tables[0].Rows[0]["ORDER_DATE"].ToString();
                            EquipInfo.CMT = ds.Tables[0].Rows[0]["COMMIT_NO"].ToString();
                            EquipInfo.BODY_NO = ds.Tables[0].Rows[0]["BODY_NO"].ToString();
                            EquipInfo.CAR_CODE = ds.Tables[0].Rows[0]["CAR_CODE"].ToString();
                        }
                        //////////////////////////////////////////////////////////////////////////////////////////////
                    }
                    if (ds.Tables[0].Rows.Count >= 2)
                    {
                        lbl_Skid_4.Text = ds.Tables[0].Rows[1]["TAG_ID"].ToString().Substring(11, 5);
                        lbl_OrderDate_4.Text = ds.Tables[0].Rows[1]["ORDER_DATE"].ToString().Substring(4, 2) + "/" + ds.Tables[0].Rows[1]["ORDER_DATE"].ToString().Substring(6, 2);
                        lbl_Cmt_4.Text = ds.Tables[0].Rows[1]["COMMIT_NO"].ToString();
                        lbl_Body_No_4.Text = ds.Tables[0].Rows[1]["BODY_NO"].ToString();
                        lbl_Drive_4.Text = ds.Tables[0].Rows[1]["DRIVE"].ToString();
                    }
                    else
                    {
                        lbl_Skid_4.Text = "";
                        lbl_OrderDate_4.Text = "";
                        lbl_Cmt_4.Text = "";
                        lbl_Body_No_4.Text = "";
                        lbl_Drive_4.Text = "";
                    }

                    if (ds.Tables[0].Rows.Count >= 3)
                    {
                        lbl_Skid_5.Text = ds.Tables[0].Rows[2]["TAG_ID"].ToString().Substring(11, 5);
                        lbl_OrderDate_5.Text = ds.Tables[0].Rows[2]["ORDER_DATE"].ToString().Substring(4, 2) + "/" + ds.Tables[0].Rows[2]["ORDER_DATE"].ToString().Substring(6, 2);
                        lbl_Cmt_5.Text = ds.Tables[0].Rows[2]["COMMIT_NO"].ToString();
                        lbl_Body_No_5.Text = ds.Tables[0].Rows[2]["BODY_NO"].ToString();
                        lbl_Drive_5.Text = ds.Tables[0].Rows[2]["DRIVE"].ToString();
                    }
                    else
                    {
                        lbl_Skid_5.Text = "";
                        lbl_OrderDate_5.Text = "";
                        lbl_Cmt_5.Text = "";
                        lbl_Body_No_5.Text = "";
                        lbl_Drive_5.Text = "";
                    }

                    //작업리스트
                    ds = new DataSet();
                    if (EquipInfo.Virtual == false)
                    {
                        Procedure.PPC_MAINDETAIL_LIST(EquipInfo.WORKCENTER, EquipInfo.ROUTE_NO, EquipInfo.BODY_NO.Substring(0, 2), EquipInfo.TR_ID, "M", ref ds);
                    }
                    else
                    {
                        Procedure.PPC_VIRTUAL_MAINDETAIL_LIST(EquipInfo.WORKCENTER, EquipInfo.ROUTE_NO, EquipInfo.BODY_NO.Substring(0, 2), EquipInfo.TR_ID, "M", ref ds);
                    }
                    dataGridView_Alc.RowTemplate = null;
                    dataGridView_Alc.DataSource = ds.Tables[0];
                    BinddataGridView_AlcSet(ref dataGridView_Alc);
                }
                else
                {
                    lbl_Skid_3.Text = "";
                    lbl_OrderDate_3.Text = "";
                    lbl_Cmt_3.Text = "";
                    lbl_Body_No_3.Text = "";
                    lbl_Drive_3.Text = "";

                    lbl_Skid_4.Text = "";
                    lbl_OrderDate_4.Text = "";
                    lbl_Cmt_4.Text = "";
                    lbl_Body_No_4.Text = "";
                    lbl_Drive_4.Text = "";

                    lbl_Skid_5.Text = "";
                    lbl_OrderDate_5.Text = "";
                    lbl_Cmt_5.Text = "";
                    lbl_Body_No_5.Text = "";
                    lbl_Drive_5.Text = "";

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
                slog = DateTime.Now + "[frmWork_Stark_FEM] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }
        //스캔 데이터에서 바디바코드나 뷰테이블에서 태그 아이디의 바디 넘버가 같으면 작업을 시작한다.
        private void ProcessJob(string Body_Barcode)
        {
            DataSet ds;
            string sTAG_ID;
            string sINPUT_FLAG = "";
            string sCar_code = "";
            try
            {
                Scan_Flag = false;

                if (Body_Barcode.Length == 22)
                {
                    //메인으로 돌아가기 위해
                    EquipInfo.BARCODE = Body_Barcode;

                    //LOG파일 남기기
                    slog = DateTime.Now + "   " + EquipInfo.WORKCENTER + "_" + EquipInfo.ROUTE_NO + "[MAIN] :      " + Body_Barcode;
                    Global.EquipInfo.fhLog.TextFileWriteAppend(slog);

                    //투입된 서열인지 체크하고
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
                    slog = DateTime.Now + "[frmWork_Start_FEM-투입서열 확인 SP / 결과] :      " + EquipInfo.WORKCENTER + "/" + Body_Barcode.Substring(10, 8) + "/" + Body_Barcode.Substring(18, 4) + "/" + Body_Barcode.Substring(0, 10) + "/" + sINPUT_FLAG;
                    Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                    //////

                    if (sINPUT_FLAG == "N")
                    {
                        ds = new DataSet();
                        Procedure.PPC_ROUTE_TRK_INFO(EquipInfo.WORKCENTER, EquipInfo.ROUTE_NO, ref ds);
                        sTAG_ID = ds.Tables[0].Rows[0]["TAG_ID"].ToString();

                        //////
                        slog = DateTime.Now + "[frmWork_Start_FEM-투입서열 아님/스키드 확인 SP/스키드] :      " + EquipInfo.WORKCENTER + "/" + EquipInfo.ROUTE_NO + "/" + sTAG_ID;
                        Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                        //////

                        if (sTAG_ID != "")
                        {
                            //REAL TAG인지 확인
                            ds = new DataSet();
                            Procedure.PPC_REAL_TAG_CHECK(EquipInfo.WORKCENTER, sTAG_ID, ref ds);
                            //////
                            slog = DateTime.Now + "[frmWork_Start_CPM-REAL TAG CHECK SP] :      " + EquipInfo.WORKCENTER + "/" + Body_Barcode.Substring(10, 8) + "/" + Body_Barcode.Substring(18, 4) + "/" + Body_Barcode.Substring(0, 10);
                            Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                            //////
                            if (ds.Tables[0].Rows.Count == 0)
                            {
                                //////
                                slog = DateTime.Now + "[frmWork_Start_CPM-투입된 스키드 임.] :      ";
                                Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                                //////

                                MassageFormLoad("TAG", "등록되지 않은 스키드입니다..");

                                return;
                            }
                            //TagMaster에 투입중인 TAG_ID 있는지 조회.
                            ds = new DataSet();
                            Procedure.PPC_SELECT_TRK_SKID(EquipInfo.WORKCENTER, Body_Barcode.Substring(10, 8), Body_Barcode.Substring(18, 4), Body_Barcode.Substring(0, 10), ref ds);

                            //////
                            slog = DateTime.Now + "[frmWork_Start_FEM-스키드 있음/ 투입된 스키드인지 확인 SP] :      " + EquipInfo.WORKCENTER + "/" + Body_Barcode.Substring(10, 8) + "/" + Body_Barcode.Substring(18, 4) + "/" + Body_Barcode.Substring(0, 10);
                            Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                            //////

                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                //////
                                slog = DateTime.Now + "[frmWork_Start_FEM-투입된 스키드 임.] :      ";
                                Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                                //////

                                MassageFormLoad("NG", "이미 투입된 SKID작업.");

                                return;
                            }
                            else if (ds.Tables[0].Rows.Count == 0)
                            {
                                // 증복 바디 체크 및 매칭 작업               
                                if (InputMatch(Body_Barcode) == false)
                                {
                                    //////
                                    slog = DateTime.Now + "[frmWork_Start_FEM-매칭 작업 및 중복 바디 체크 걸림] :      ";
                                    Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                                    //////

                                    Scan_Flag = true;
                                    return;
                                }
                            }
                        }
                        else
                        {
                            //////
                            slog = DateTime.Now + "[frmWork_Start_FEM-투입 공정에 스키드 없음] :      ";
                            Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                            //////

                            MassageFormLoad("NG", "투입공정에 SKID 없습니다.");

                            return;
                        }
                    }
                    //투입된 BODY_NO가 아니면............
                    else
                    {
                        //////
                        slog = DateTime.Now + "[frmWork_Start_FEM-투입된 서열임] :      " + sINPUT_FLAG;
                        Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                        //////

                        MassageFormLoad("INPUT_FLAG_CHECK", "이미 투입된 서열입니다.");

                        return;
                    }                                       

                    ds.Dispose();

                    First_data = false;
                    //매칭 SP       
                    if (EquipInfo.WORKCENTER == "FEM1")
                    {
                        if (EquipInfo.Virtual == false)
                        {
                            Procedure.PPC_INPUT_TRAN_FEM1(EquipInfo.WORKCENTER, EquipInfo.TR_ID, Body_Barcode);
                        }
                        else
                        {
                            Procedure.PPC_VIRTUAL_INPUT_TRAN_FEM1(EquipInfo.WORKCENTER, EquipInfo.TR_ID, Body_Barcode);
                        }
                    }
                    else
                    {
                        if (EquipInfo.Virtual == false)
                        {
                            Procedure.PPC_INPUT_TRAN_FEM2(EquipInfo.WORKCENTER, EquipInfo.TR_ID, Body_Barcode);
                        }
                        else
                        {
                            Procedure.PPC_VIRTUAL_INPUT_TRAN_FEM2(EquipInfo.WORKCENTER, EquipInfo.TR_ID, Body_Barcode);
                        }
                    }

                    //////
                    slog = DateTime.Now + "[frmWork_Start_FEM-스키드 매칭 SP] :      " + EquipInfo.WORKCENTER + "/" + EquipInfo.TR_ID + "/" + Body_Barcode;
                    Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                    //////                    

                    //매칭 후 TR_ID를 다른 변수에 저장....작업폼에서 TR_ID 체크 하기 위해서
                    EquipInfo.W_TR_ID = EquipInfo.TR_ID;
                    /////////////

                    ds = new DataSet();
                    Procedure.PPC_INPUT_CAR(EquipInfo.WORKCENTER, EquipInfo.ROUTE_NO, ref ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        sCar_code = ds.Tables[0].Rows[0][0].ToString();
                        NetRemoting.TagSet(EquipInfo.WORKCENTER + "_" + EquipInfo.ROUTE_NO + "_CAR", sCar_code);
                        NetRemoting.TagSet(EquipInfo.WORKCENTER + "_" + EquipInfo.ROUTE_NO + "RF_VALUE", EquipInfo.BARCODE);
                    }

                    //////
                    slog = DateTime.Now + "[frmWork_Start_FEM - TAG 전송 CAR,RF_VALUE] :      " + ds.Tables[0].Rows[0][0].ToString() + "/" + EquipInfo.BARCODE;
                    Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                    //////

                    MassageFormLoad("OK", "서열정보와 스키드 매칭 성공...");
                    //스키드 매칭 후 작업화면 보이기
                    WorkFormLoad();
                }
                else
                {
                    First_data = true;
                    Scan_Flag = true;
                }
            }            
            catch (Exception ex)
            {
                Scan_Flag = true;
                First_data = true;
                slog = DateTime.Now + "[frmWork_Stark_FEM] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }
        private bool InputMatch(string Barcode)
        {
            DataSet ds;
            string sTAG_ID;
            string sScanBodyNo;
            string sScanOrderDate;
            string sScanCommitNo;

            try
            {
                sScanBodyNo = Barcode.Substring(0, 10).ToString();
                sScanOrderDate = Barcode.Substring(10, 8).ToString();
                sScanCommitNo = Barcode.Substring(18, 4).ToString();
                string Input_Msg = "";
                //중복 BODY 체크 변수
                string dOrder_Date = "";
                string dCommit_NO = "";
                string dBody_NO = "";
                string dKia_Plant = "";
                string dInput_Flag = "";
                string dDel_Flag = "";

                ds = new DataSet();
                Procedure.PPC_ROUTE_TRK_INFO(EquipInfo.WORKCENTER, EquipInfo.ROUTE_NO, ref ds);
                sTAG_ID = ds.Tables[0].Rows[0]["TAG_ID"].ToString().Trim();

                // 00번공정에 스키드 있는지 확인
                if (sTAG_ID == "")
                {
                    //Procedure.PPC_TRAN_NG(EquipInfo.WORKCENTER, EquipInfo.ROUTE_NO);
                    NetRemoting.TagSet(EquipInfo.WORKCENTER + "_" + EquipInfo.ROUTE_NO + "_OKNG", "0001");
                    
                    //////
                    slog = DateTime.Now + "[frmWork_Start_FEM - TAG NG 보냄] :      ";
                    Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                    //////

                    MassageFormLoad("NG", "스키드 매칭이상...\r\r(해당공정에 TAG정보 없음)");

                    //////
                    slog = DateTime.Now + "[frmWork_Start_FEM - 해당공정에 TAG정보 없음] :      ";
                    Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                    //////

                    return false;
                }
                // 00번 공정에 스키드가 매치되었는지 확인
                if (ds.Tables[0].Rows[0]["BODY_NO"].ToString().Trim() == sScanBodyNo && ds.Tables[0].Rows[0]["ORDER_DATE"].ToString().Trim() == sScanOrderDate
                    && ds.Tables[0].Rows[0]["COMMIT_NO"].ToString().Trim() == sScanCommitNo)
                {
                }
                else if (ds.Tables[0].Rows[0]["BODY_NO"].ToString().Trim() != "")
                {
                    //Procedure.PPC_TRAN_NG(EquipInfo.WORKCENTER, EquipInfo.ROUTE_NO);
                    NetRemoting.TagSet(EquipInfo.WORKCENTER + "_" + EquipInfo.ROUTE_NO + "_OKNG", "0001");

                    //////
                    slog = DateTime.Now + "[frmWork_Start_FEM - TAG NG 보냄] :      ";
                    Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                    //////

                    //////
                    slog = DateTime.Now + "[frmWork_Start_FEM - 이미 매칭된 스키드] :      ";
                    Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                    //////

                    MassageFormLoad("SKID", "이미 매칭된 스키드 입니다 \r\r" + "ORDER_DATE : " + ds.Tables[0].Rows[0]["ORDER_DATE"].ToString().Trim() + "\r" +
                                                                              "COMMIT_NO : " + ds.Tables[0].Rows[0]["COMMIT_NO"].ToString().Trim() + "\r" +
                                                                              "BODY_NO : " + ds.Tables[0].Rows[0]["BODY_NO"].ToString().Trim() + "\r\r" +
                                                                              "계속 진행하시겠습니까?");
                    if (EquipInfo.Rtn == "NO")
                    {
                        return false;
                    }      
                }
                // 대기 작업지시 확인 (서열순서확인)
                ds = new DataSet();
                if (EquipInfo.Virtual == false)
                {
                    Procedure.PPC_SELECT_WAIT_ORDER_CNT(EquipInfo.WORKCENTER, ref ds);
                }
                else
                {
                    Procedure.PPC_VIRTUAL_SELECT_WAIT_ORDER_CNT(EquipInfo.WORKCENTER, ref ds);
                }
                if (ds.Tables[0].Rows.Count > 1)
                {
                    //Procedure.PPC_TRAN_NG(EquipInfo.WORKCENTER, EquipInfo.ROUTE_NO);
                    NetRemoting.TagSet(EquipInfo.WORKCENTER + "_" + EquipInfo.ROUTE_NO + "_OKNG", "0001");

                    //////
                    slog = DateTime.Now + "[frmWork_Start_FEM - TAG NG 보냄] :      ";
                    Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                    //////

                    MassageFormLoad("NG", "스키드 매칭 이상.\r\r대기 작업지시를 확인 바랍니다.");

                    //////
                    slog = DateTime.Now + "[frmWork_Start_FEM - 대기 작업지시 확인 (서열순서 확인)] :      ";
                    Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                    //////

                    return false;
                }
                // 스캔 바코드 매칭 체크
                if (ds.Tables[0].Rows[0]["BODY_NO"].ToString().Trim() == sScanBodyNo && ds.Tables[0].Rows[0]["ORDER_DATE"].ToString().Trim() == sScanOrderDate
                    && ds.Tables[0].Rows[0]["COMMIT_NO"].ToString().Trim() == sScanCommitNo)
                {
                }
                else
                {
                    //Procedure.PPC_TRAN_NG(EquipInfo.WORKCENTER, EquipInfo.ROUTE_NO);
                    NetRemoting.TagSet(EquipInfo.WORKCENTER + "_" + EquipInfo.ROUTE_NO + "_OKNG", "0001");

                    //////
                    slog = DateTime.Now + "[frmWork_Start_FEM - TAG NG 보냄] :      ";
                    Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                    //////

                    MassageFormLoad("NG", "스캔한 BODY와 작업할 대기BODY 불일치.");

                    //////
                    slog = DateTime.Now + "[frmWork_Start_FEM - 스캔한 BODY와 작업할 대기BODY 불일치] :      ";
                    Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                    //////

                    return false;
                }
                //중복 바디 작업이 있었는지 조회 후 메세지만 뿌려주고 투입작업은 진행한다.
                ds = new DataSet();
                if (EquipInfo.Virtual == false)
                {
                    Procedure.PPC_SELECT_DUPORDER(EquipInfo.WORKCENTER, Barcode.Substring(0, 10), ref ds);
                }
                else
                {
                    Procedure.PPC_VIRTUAL_SELECT_DUPORDER(EquipInfo.WORKCENTER, Barcode.Substring(0, 10), ref ds);
                }

                if (Barcode.Substring(10, 8) == ds.Tables[0].Rows[0]["ORDER_DATE"].ToString().Trim() && Barcode.Substring(18, 4) == ds.Tables[0].Rows[0]["COMMIT_NO"].ToString().Trim()
                    && Barcode.Substring(0, 10) == ds.Tables[0].Rows[0]["BODY_NO"].ToString().Trim())
                {
                }
                else
                {
                    dOrder_Date = ds.Tables[0].Rows[0]["ORDER_DATE"].ToString().Trim();
                    dCommit_NO = ds.Tables[0].Rows[0]["COMMIT_NO"].ToString().Trim();
                    dBody_NO = ds.Tables[0].Rows[0]["BODY_NO"].ToString().Trim();
                    dKia_Plant = ds.Tables[0].Rows[0]["KIA_PLANT"].ToString().Trim();
                    dInput_Flag = ds.Tables[0].Rows[0]["INPUT_FLAG"].ToString().Trim();
                    dDel_Flag = ds.Tables[0].Rows[0]["DEL_FLAG"].ToString().Trim();
                }
                if (ds.Tables[0].Rows.Count > 0 && dOrder_Date != "" && dCommit_NO != "")
                {
                    if (dInput_Flag == "Y" && dDel_Flag == "Y")
                    {
                        Input_Msg = "말소된 바디";
                    }
                    else if (dInput_Flag == "Y")
                    {
                        Input_Msg = "투입된 바디";
                    }
                    else if (dInput_Flag == "N")
                    {
                        Input_Msg = "대기중인 바디";
                    }
                    else if (dDel_Flag == "Y")
                    {
                        Input_Msg = "말소된 바디";
                    }
                    if (dDel_Flag == "Y")
                    {
                        NetRemoting.TagSet(EquipInfo.WORKCENTER + "_" + EquipInfo.ROUTE_NO + "_OKNG", "0001");

                        //////
                        slog = DateTime.Now + "[frmWork_Start_FEM - TAG NG 보냄] :      ";
                        Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                        //////

                        MassageFormLoad("ERASED_BODY", "[!-- 말소된 바디 서열정보 : --!]\r일자/커밋" + ds.Tables[0].Rows[0]["ORDER_DATE"].ToString().Trim() + " " + ds.Tables[0].Rows[0]["COMMIT_NO"].ToString().Trim() + "\r" +
                                            "BODY NO :" + ds.Tables[0].Rows[0]["BODY_NO"].ToString().Trim() + "     " + "<" + Input_Msg + ">" + "\r" +
                                            "[!-- 스캔한 바디 서열정보 : --!]\r일자/커밋" + Barcode.Substring(10, 8) + " " + Barcode.Substring(18, 4) + "\r" +
                                            "BODY NO :" + Barcode.Substring(0, 10) + "\r" + "투입하시겠습니까?");
                        if (EquipInfo.Rtn != "OK")
                        {
                            return false;
                        }
                    }
                    else
                    {
                        NetRemoting.TagSet(EquipInfo.WORKCENTER + "_" + EquipInfo.ROUTE_NO + "_OKNG", "0001");

                        //////
                        slog = DateTime.Now + "[frmWork_Start_FEM - TAG NG 보냄] :      ";
                        Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                        //////

                        MassageFormLoad("DUPLICATION_BODY", "[!-- 중복되는 바디 서열정보 : --!]\r일자/커밋" + ds.Tables[0].Rows[0]["ORDER_DATE"].ToString().Trim() + " " + ds.Tables[0].Rows[0]["COMMIT_NO"].ToString().Trim() + "\r" +
                                               "BODY NO :" + ds.Tables[0].Rows[0]["BODY_NO"].ToString().Trim() + "     " + "<" + Input_Msg + ">" + "\r" +
                                               "[!-- 스캔한 바디 서열정보 : --!]\r일자/커밋" + Barcode.Substring(10, 8) + " " + Barcode.Substring(18, 4) + "\r" +
                                               "BODY NO :" + Barcode.Substring(0, 10) + "\r" + "투입하시겠습니까?");
                        if (EquipInfo.Rtn != "OK")
                        {
                            return false;
                        }

                    }
                }
                ds.Dispose();
                //LOG파일 남기기
                NetRemoting.TagSet(EquipInfo.WORKCENTER + "_" + EquipInfo.ROUTE_NO + "_OKNG", "0000");

                slog = "[투입]  서열 : " + Barcode.Substring(10, 8) + " / " + Barcode.Substring(18, 4) + " / " + Barcode.Substring(0, 10);
                Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                return true;
            }
            catch (Exception ex)
            {
                First_data = true;
                Scan_Flag = true;
                return false;
                slog = DateTime.Now + "[frmWork] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }
        // 작업화면으로 전환한다.
        private void WorkFormLoad()
        {
            try
            {
                EquipInfo._Frm = "frmWorkStart";
                while (serialPort1.IsOpen)
                {
                    System.Threading.Thread.Sleep(100);
                    SerialPortClose();
                }
                slog = DateTime.Now + "[frmWork_Start_FEM - frmWorkStart 폼 로드] :      ";
                Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                // 2017.09.08 폼로드(작업화면전환) 로그 남김 신도혁
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWork_Stark_FEM] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }
        private void MassageFormLoad(string Gubun,string Msg)
        {
            try
            {
                if (Gubun != "OK")
                {
                    Scan_Flag = true;
                }
                
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
                slog = DateTime.Now + "[frmWork_Stark_CPM] :      " + ex;
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
                slog = DateTime.Now + "[frmWork_Stark_FEM] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }

        }
        //오른쪽 그리드에 데이터 처리
        private void BinddataGridView_AlcSet(ref DataGridView dataGridView)
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
                dataGridView.Columns[1].Width = dataGridView.Width * 50 / 100;
                dataGridView.Columns[2].Width = dataGridView.Width * 50 / 100;
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
                    dataGridView.Rows[i].Cells["작업명"].Style.Font = new System.Drawing.Font("HY견고딕", 26.00F, FontStyle.Bold);
                    if (dataGridView.Rows.Count > 4)
                    {
                        dataGridView.Rows[i].Cells["ALC"].Style.Font = new System.Drawing.Font("HY견고딕", 50.00F, FontStyle.Bold);
                    }
                }
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWork_Stark_FEM] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }
        //수동으로 작업지시 번호를 입력 했을때..
        private void btn_Bar_OK_Click(object sender, EventArgs e)
        {
            try
            {
                //수동으로 바디바코드를 넣었을때           

                EquipInfo.BODY_NO = txt_Barcode.Text.Substring(0, 10);
                EquipInfo.ORDER_DATE = txt_Barcode.Text.Substring(10, 8);
                EquipInfo.CMT = txt_Barcode.Text.Substring(18, 4);

                //////
                slog = DateTime.Now + "[frmWork_Start_FEM-수동입력] :      " + txt_Barcode.Text;
                Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                //////

                EventMessage(txt_Barcode.Text.Substring(0, 10));

                ProcessJob(txt_Barcode.Text);
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWork_Stark_FEM] :      " + ex;
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
                    EquipInfo.BARCODE = RecieveData;
                    
                    //////
                    slog = DateTime.Now + "[frmWork_Start_FEM-스캐너리딩] :      " + RecieveData;
                    Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                    //////

                    if (Scan_Flag == true)
                    {
                        EventMessage(RecieveData.Substring(0, 10));

                        ProcessJob(RecieveData);
                    }
                    txt_ReciveData.Text = "";
                }
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWork_Stark_FEM] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
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

        private void frmMessageClose()
        {
            if (frmMsg != null)
            {
                frmMsg.Close();
                frmMsg = null;
            }

        }

        private void lbl_Skid_3_Click(object sender, EventArgs e)
        {
            try
            {

                //라벨 상태 변환
                //lbl_Skid_3.BackColor = Color.Lime;
                //lbl_OrderDate_3.BackColor = Color.Lime;
                //lbl_Cmt_3.BackColor = Color.Lime;
                //lbl_Body_No_3.BackColor = Color.Lime;

                // 라벨에 담길 데이터
                //EquipInfo.TR_ID = ds.Tables[0].Rows[0]["TR_ID"].ToString();
                //EquipInfo.ORDER_DATE = ds.Tables[0].Rows[0]["ORDER_DATE"].ToString();
                //EquipInfo.CMT = ds.Tables[0].Rows[0]["COMMIT_NO"].ToString();
                //EquipInfo.BODY_NO = ds.Tables[0].Rows[0]["BODY_NO"].ToString();
                //EquipInfo.CAR_CODE = ds.Tables[0].Rows[0]["CAR_CODE"].ToString();

                //일반 로그
                ///////
                //slog = DateTime.Now + "[frmWork_Start_CPM - 해당공정에 TAG정보 없음] :      ";
                //Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                //////

                //MessageBox.Show(EquipInfo.BODY_NO + EquipInfo.ORDER_DATE + EquipInfo.CMT);
                //return;

                if (lbl_Skid_3.Text.Length != 0 && lbl_Skid_3.BackColor == Color.Lime)
                {
                    DialogResult result = MessageBox.Show("SKID 수동 매칭을 진행하시겠습니까?", "수동 입력 확인", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                    if (DialogResult.Cancel == result)
                    {
                        slog = DateTime.Now + "[frmWork_Start_FEM - SKID 수동 매칭] : CANCEL(취소) ";
                        Global.EquipInfo.fhLog.TextFileWriteAppend(slog);

                        return;
                    }
                    else
                    {
                        //바코드 수동 생성
                        string BAR_MANUAL = "";

                        BAR_MANUAL = EquipInfo.BODY_NO + EquipInfo.ORDER_DATE + EquipInfo.CMT;

                        if (BAR_MANUAL.Length != 22)
                        {
                            //메시지 출력
                            MassageFormLoad("NG", "수동 바코드 생성 오류...\r\r(바코드 정보 오류.)");

                            //로그 insert
                            slog = DateTime.Now + "[frmWork_Stark_CPM - 수동입력 SKID CLICK] :      " + "수동 바코드 생성 오류...\r\r(바코드 정보 오류.)";
                            Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);

                            return;
                        }

                        ///
                        slog = DateTime.Now + "[frmWork_Start_CPM - SKID 수동 바코드 생성 완료] :  " + BAR_MANUAL;
                        Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                        ///

                        //작업 진행
                        ProcessJob(BAR_MANUAL);

                        Skid_Flag = false;
                    }


                    //if (pnl_skid.Visible == false)
                    //{
                    //    pnl_skid.Visible = true;
                    //    pnl_skid.Dock = DockStyle.Fill;
                    //}

                    //if (Skid_Flag == false)
                    //{
                    //    slog = DateTime.Now + "[frmWork_Start_FEM - SKID 수동 매칭] : CANCEL(취소) ";
                    //    Global.EquipInfo.fhLog.TextFileWriteAppend(slog);

                    //    return;
                    //}

                    //if (Skid_Flag == true)
                    //{
                    //    //바코드 수동 생성
                    //    string BAR_MANUAL = "";

                    //    BAR_MANUAL = EquipInfo.BODY_NO + EquipInfo.ORDER_DATE + EquipInfo.CMT;

                    //    if (BAR_MANUAL.Length != 22)
                    //    {
                    //        //메시지 출력
                    //        MassageFormLoad("NG", "수동 바코드 생성 오류...\r\r(바코드 정보 오류.)");

                    //        //로그 insert
                    //        slog = DateTime.Now + "[frmWork_Stark_CPM - 수동입력 SKID CLICK] :      " + "수동 바코드 생성 오류...\r\r(바코드 정보 오류.)";
                    //        Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);

                    //        return;
                    //    }

                    //    ///
                    //    slog = DateTime.Now + "[frmWork_Start_CPM - SKID 수동 바코드 생성 완료] :  " + BAR_MANUAL;
                    //    Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                    //    ///

                    //    //작업 진행
                    //    ProcessJob(BAR_MANUAL);

                    //    Skid_Flag = false;
                    //}
                }
                else
                {
                    //메시지 출력
                    MassageFormLoad("NG", "스키드 매칭오류...\r\r(스키드 정보가 존재하지 않습니다.)");

                    //로그 insert
                    slog = DateTime.Now + "[frmWork_Stark_CPM - 수동입력 SKID CLICK] :      " + "스키드 매칭오류...\r\r(스키드 정보가 존재하지 않습니다.)";
                    Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);

                    return;
                }
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWork_Stark_CPM - 수동입력 SKID CLICK] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            Skid_Flag = true;
            pnl_skid.Dock = DockStyle.None;
            pnl_skid.Visible = false;
        }

        private void btm_cancel_Click(object sender, EventArgs e)
        {
            Skid_Flag = false;
            pnl_skid.Dock = DockStyle.None;
            pnl_skid.Visible = false;
        }

        private void frmWork_Stark_FEM_FormClosing(object sender, FormClosingEventArgs e)
        {
            //메모리 해제 구문 추가 20181023 김진성
            try
            {
                GC.Collect();
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWork_Stark_FEM_FormClosing] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
            //구문 추가 END
        }
    }
}
