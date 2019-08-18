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
using MOBISDAS.Forms;
using MOBISDAS.Common;
using System.Net;

namespace MOBISDAS
{
    public partial class mdiMain : Form
    {
        private Form _frmLoad;

        public string OKNG = "";
        public string PLC_END = ""; //PLC END
        public string END = ""; // 전산 END

        private string slog = "";

        // 작업표준서관련 유민호 추가
        public static bool open = false;

        private IniFile cFilehandle = new IniFile(Application.StartupPath + "\\INI\\db.ini");
        
        //private string FileName = "";
        //public delegate void toolStripProgressBarSet(int value);

        private frmWorkDailyInspection frmWorkDailyInspection = null;
        public delegate void WorkInpection(Form WorkInspection);

        private frmWorkBoard frmWorkBoard = null;
        public delegate void WorkBoard(Form WorkBoard);
       
        public mdiMain()
        {
            InitializeComponent();            
        }

        private void mdiMain_Load(object sender, EventArgs e)
        {
            try
            {
                Initialize();          
                NetRemoting_Connect();                
                BindData();

                //Thread IMAGEThread = new Thread(new ThreadStart(Image_Down));
                //IMAGEThread.Start();
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[mdiMain] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }
        //private void Image_Down()
        //{
        //    try
        //    {
        //        DataSet ds = new DataSet();
        //        Procedure.PPC_IMAGE_DOWN_LOAD(EquipInfo.WORKCENTER, ref ds);

        //        if (ds.Tables[0].Rows.Count > 0)
        //        {
        //            int Row_Cnt = ds.Tables[0].Rows.Count;

        //            for (int i = 0; i < Row_Cnt; i++)
        //            {
        //                if (i != 0)
        //                {
        //                    //toolStripProgressBar1.Value = (i * 100) / Row_Cnt;
        //                    toolStripProgressBar_Set((i * 100) / Row_Cnt);
        //                }
        //                FileName = ds.Tables[0].Rows[i]["FILE_NAME"].ToString() + ".jpg";
        //                Web_Down();
        //            }
        //            toolStripProgressBar_Set(100);
        //        }
        //        toolStripStatusLabel1.Text = "이미지 다운 완료";
        //        toolStripProgressBar_Set(0);
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        //private void toolStripProgressBar_Set(int value)
        //{
        //    try
        //    {
        //        if (this.toolStripProgressBar1.ProgressBar.InvokeRequired)
        //            this.toolStripProgressBar1.ProgressBar.Invoke(new toolStripProgressBarSet(toolStripProgressBar_Set), new object[] { value });
        //        else
        //            toolStripProgressBar1.Value = value;
        //    }
        //    catch (Exception ex)
        //    {
        //        slog = DateTime.Now + "[frmWorkStart] :      " + ex;
        //        Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
        //    }
        //}

        //private void Web_Down()
        //{
        //    try
        //    {
        //        WebClient wc = new WebClient();

        //        wc.DownloadFile("\\\\10.240.111.40\\MOBISGJ_MES\\files\\" + FileName
        //                           , Application.StartupPath + "\\IMG\\" + FileName);
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        private void DbConnection()
        {
            try
            {
                #region[db 연결]
                if (ivizConn.DatabaseConnect())
                {
                    ivizConn.DBConnctionSave();
                    lbl_DB.BackColor = Color.GreenYellow;
                }
                else
                {
                    lbl_DB.BackColor = Color.Red;
                }
                #endregion
            }
            catch (Exception ex)
            {

            }
        }

        private void Initialize()
        {
            try
            {
                ivizConn.DBConnctionLoad();
                DbConnection();

                //pnl_Main_Load.Enabled = false;
                //pnl_Main_Load.Visible = false;
                lbl_Route_No.Text = "[ " + EquipInfo.WORKCENTER.ToString() + " - " + EquipInfo.ROUTE_NO.ToString() + " ]";

                if (EquipInfo.WORKCENTER.Substring(0, 3) != "CPM" && EquipInfo.WORKCENTER.Substring(0, 3) != "FEM")
                {
                    lbl_DB.Visible = false;
                    lbl_PLC_Ok.Visible = false;
                    lbl_PLC_End.Visible = false;
                    label1.Visible = false;
                    label2.Visible = false;
                    label3.Visible = false;
                    lbl_Skid.Visible = false;
                }
                if (EquipInfo.WORKCENTER.Substring(0, 3) == "FEM")
                {
                    pnl_Wait_Cnt.Visible = true;
                }
                else if (EquipInfo.WORKCENTER.Substring(0, 3) == "CPM")
                {
                    EquipInfo.WAIT_CNT = cFilehandle.IniReadValue("LINE_INFO", "WAIT_CNT", "");
                    if (EquipInfo.WAIT_CNT == "Y")
                    {
                        pnl_Wait_Cnt.Visible = true;
                    }
                    else
                    {
                        pnl_Wait_Cnt.Visible = false;
                    }
                }
                timer_Check.Start();
                //timer_dayInsp.Start();      
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[mdiMain] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }
        private void BindData()
        {
            try
            {
                DataSet ds = new DataSet();
                Procedure.PPC_LINE_INFO(EquipInfo.WORKCENTER, EquipInfo.ROUTE_NO, ref ds);
                EquipInfo.ROUTE_GB = ds.Tables[0].Rows[0]["ROUTE_GB"].ToString().Trim();
                if (EquipInfo.ROUTE_GB == "S")
                {
                    if (EquipInfo.WORKCENTER.Substring(0, 3) == "FEM")
                    {
                        EquipInfo._Frm = "frmWork_Start_FEM";
                        EquipInfo._BFrm = "frmWork_Start_FEM";
                    }
                    else
                    {
                        EquipInfo._Frm = "frmWork_Start_CPM";
                        EquipInfo._BFrm = "frmWork_Start_CPM";
                    }
                }
                else
                {
                    EquipInfo._Frm = "frmWork";
                    EquipInfo._BFrm = "frmWork";

                }

                ds.Dispose();

                FormLoad();
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[mdiMain] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }
        public void FormLoad()
        {
            try
            {                
                if (EquipInfo.ROUTE_GB == "K")
                {
                    _frmLoad = new frmWorkKeeper(this);
                    slog = DateTime.Now + "[메인에서 해당 폼으로 ] :      " + "frmWorkKeeper";
                    Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                }
                else
                {
                    if (EquipInfo.ROUTE_GB != "S")
                    {
                        if ((EquipInfo._BFrm != EquipInfo._Frm) && (EquipInfo._Frm == "frmWorkStart"))
                        {
                            _frmLoad = new frmWorkStart(this);
                            EquipInfo._BFrm = "frmWorkStart";
                        }
                        else
                        {
                            _frmLoad = new frmWork(this);
                            EquipInfo._BFrm = "frmWork";
                        }
                    }
                    else
                    {
                        if (EquipInfo.WORKCENTER.Substring(0, 3) == "CPM")
                        {
                            if ((EquipInfo._BFrm != EquipInfo._Frm) && (EquipInfo._Frm == "frmWorkStart") && EquipInfo._BFrm == "frmWork_Start_CPM")
                            {
                               

                                _frmLoad = new frmWorkStart(this);
                                EquipInfo._BFrm = "frmWorkStart";
                                /////
                                slog = DateTime.Now + "[메인폼에서 해당폼으로] :      " + EquipInfo._BFrm;
                                Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                                ////
                            }
                            else
                            {
                                

                                _frmLoad = new frmWork_Stark_CPM(this);
                                EquipInfo._BFrm = "frmWork_Start_CPM";
                                /////
                                slog = DateTime.Now + "[메인폼에서 해당폼으로] :      " + EquipInfo._BFrm;
                                Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                                ////
                            }
                        }
                        else if (EquipInfo.WORKCENTER.Substring(0, 3) == "FEM")
                        {
                            if ((EquipInfo._BFrm != EquipInfo._Frm) && (EquipInfo._Frm == "frmWorkStart") && EquipInfo._BFrm == "frmWork_Start_FEM")
                            {
                                

                                _frmLoad = new frmWorkStart(this);
                                EquipInfo._BFrm = "frmWorkStart";
                                /////
                                slog = DateTime.Now + "[메인폼에서 해당폼으로] :      " + EquipInfo._BFrm;
                                Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                                ////
                            }
                            else
                            {

                                _frmLoad = new frmWork_Stark_FEM(this);
                                EquipInfo._BFrm = "frmWork_Start_FEM";
                                /////
                                slog = DateTime.Now + "[메인폼에서 해당폼으로] :      " + EquipInfo._BFrm;
                                Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                                //// 2017.09.08 신도혁 메인에서 해당폼으로 로그 남김
                            }
                        }
                    }
                }
                
                slog = DateTime.Now + "[mdiMain 폼로드] :      " + EquipInfo._BFrm;
                Global.EquipInfo.fhLog.TextFileWriteAppend(slog);

                _frmLoad.Show();

                slog = DateTime.Now + "[mdiMain 폼로드] :      " + EquipInfo._BFrm + "SHOW() END";
                Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                
                pnlChild.Controls.Clear();
                pnlChild.Controls.Add(_frmLoad);                          
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[mdiMain] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }

        private void NetRemoting_Connect()
        {
            try
            {
                ivizConn.NetRemoting_Connect();
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[mdiMain] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }

        private void bnt_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }       

        private void timer_Check_Tick(object sender, EventArgs e)
        {
            DataSet ds;
            string TAG_ID = "";
            string V_Mode = "";
            try
            {
                if ((EquipInfo._Frm != "" && EquipInfo._BFrm != "") && (EquipInfo._Frm != EquipInfo._BFrm))
                {
                    slog = DateTime.Now + "[mdiMain 폼 닫기] :      " + EquipInfo._BFrm;
                    Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                    _frmLoad.Close();
                    FormLoad();
                }
             
                if (EquipInfo.Date_Time.Day != DateTime.Now.Day)
                {
                     EquipInfo.fhLog = new Filehandle("./LOG/" +DateTime.Now.Year + "_" + DateTime.Now.Month + "/LOG" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + ".TXT");
                     //EquipInfo.fh_Err_Log = new Filehandle("./Err_LOG/" + DateTime.Now.Year + "_" + DateTime.Now.Month + "/Err_LOG" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + ".TXT");

                     EquipInfo.Date_Time = DateTime.Now;
                }

                if (EquipInfo.WORKCENTER.Substring(0, 3) == "CPM" || EquipInfo.WORKCENTER.Substring(0, 3) == "FEM")
                {
                    OKNG = NetRemoting.TagGet(EquipInfo.WORKCENTER + "_" + EquipInfo.ROUTE_NO + "_OKNG");
                    PLC_END = NetRemoting.TagGet(EquipInfo.WORKCENTER + "_" + EquipInfo.ROUTE_NO + "_PLC_END");
                    END = NetRemoting.TagGet(EquipInfo.WORKCENTER + "_" + EquipInfo.ROUTE_NO + "_END");

                    if (OKNG == "0000")
                    {
                        lbl_PLC_Ok.BackColor = Color.GreenYellow;
                    }
                    else
                    {
                        lbl_PLC_Ok.BackColor = Color.Red;
                    }

                    if (PLC_END == "0001")
                    {
                        lbl_PLC_End.BackColor = Color.GreenYellow;
                    }
                    else
                    {
                        lbl_PLC_End.BackColor = Color.Red;
                    }

                    if (END == "0001")
                    {
                        lbl_End.BackColor = Color.GreenYellow;
                        // 작업표준서 추가 - 유민호
                        if (!open && EquipInfo.Msg_Off == true && EquipInfo.BoardFlag == false && EquipInfo.Auto_Flag == true)
                        {
                            open = true;
                            EquipInfo.BoardFlag = false;

                            btn_workboard_Click(null, null);
                        }
                    }
                    else
                    {
                        lbl_End.BackColor = Color.Red;

                        // 작업표준서 추가 - 유민호
                        if (open)
                        {
                            open = false;
                            frmWorkBoadrClose();
                            EquipInfo.BoardFlag = false;
                        }
                    }
                }
                    /*
                    else if (EquipInfo.WORKCENTER.Substring(0, 3) != "CPM" || EquipInfo.WORKCENTER.Substring(0, 3) != "FEM")
                    {
                        END = NetRemoting.TagGet(EquipInfo.WORKCENTER + "_" + EquipInfo.ROUTE_NO + "_END");

                        if (END == "0001")
                        {
                            lbl_End.BackColor = Color.GreenYellow;
                            // 작업표준서 추가 - 유민호
                            if (!open && EquipInfo.Msg_Off == true)
                            {
                                open = true;
                                btn_workboard_Click(null, null);
                            }
                        }
                        else
                        {
                            lbl_End.BackColor = Color.Red;
                            if (open && EquipInfo.SubFalg == false)
                            {
                                open = false;
                                EquipInfo.SubFalg = false;
                                frmWorkBoadrClose();
                            }
                        }
                    }
                     * */
                lbl_Day.Text = DateTime.Now.ToString("yyyy-MM-dd");
                lbl_Time.Text = DateTime.Now.ToString("HH:mm:ss");
                                
                if (NetRemoting.State() == true)
                {
                    lbl_TagServer.BackColor = Color.GreenYellow;
                }
                else
                {
                    lbl_TagServer.BackColor = Color.Red;
                }

                if (ivizConn.DatabaseConnect() == true)
                {
                    if (EquipInfo.WORKCENTER.Substring(0, 3) == "CPM" || EquipInfo.WORKCENTER.Substring(0, 3) == "FEM")
                    {
                        ds = new DataSet();
                        Procedure.PPC_VW_LINETRK(EquipInfo.WORKCENTER, EquipInfo.ROUTE_NO, ref ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            TAG_ID = ds.Tables[0].Rows[0]["TAG_ID"].ToString();

                            if (TAG_ID != "")
                            {
                                lbl_Skid.Text = "스키드 ON";
                                lbl_Skid.ForeColor = Color.YellowGreen;                                
                            }
                            else
                            {
                                lbl_Skid.Text = "스키드 OFF";
                                lbl_Skid.ForeColor = Color.Red;
                            }
                        }
                        ds.Dispose();
                    }

                    lbl_DB.BackColor = Color.GreenYellow;

                    if (EquipInfo.WORKCENTER.Substring(0, 3) == "CPM" || EquipInfo.WORKCENTER.Substring(0, 3) == "FEM")
                    {
                        ds = new DataSet();
                        Procedure.PPC_ASSY_WAIT_CNT(EquipInfo.WORKCENTER, ref ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            lbl_Wait_Cnt.Text = ds.Tables[0].Rows[0]["ASSY_WAIT_CNT"].ToString();
                        }
                        else
                        {
                            lbl_Wait_Cnt.Text = "0";
                        }                        
                    }
                }
                else
                {
                    lbl_DB.BackColor = Color.Red;
                    //ivizConn.DatabaseConnect();
                }
                //가상서열 모드 체크
                ds = new DataSet();
                Procedure.PPC_LINE_INFO(EquipInfo.WORKCENTER, EquipInfo.ROUTE_NO, ref ds);
                V_Mode = ds.Tables[0].Rows[0]["V_MODE"].ToString().Trim();

                if (EquipInfo._Frm == "frmWork_Start_CPM" || EquipInfo._Frm == "frmWork" || EquipInfo._Frm == "frmWork_Start_FEM")
                {
                    if (V_Mode == "Y")
                    {
                        EquipInfo.Virtual = true;
                    }
                    else
                    {
                        EquipInfo.Virtual = false;
                    }
                }
                ds.Dispose();
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[mdiMain] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }

        private void bnt_Wait_Cnt_Click(object sender, EventArgs e)
        {
            if (pnl_Wait_Cnt.Visible)
            {
                cFilehandle.IniWriteValue("LINE_INFO", "WAIT_CNT", "N");
                pnl_Wait_Cnt.Visible = false;
            }
            else
            {
                cFilehandle.IniWriteValue("LINE_INFO", "WAIT_CNT", "Y");
                pnl_Wait_Cnt.Visible = true;
            }
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            if (pnl_Main_Load.Visible)
            {
                if (EquipInfo.WORKCENTER.Substring(0, 3) != "CPM" && EquipInfo.WORKCENTER.Substring(0, 3) != "FEM")
                {
                    bnt_Wait_Cnt.Enabled = false;
                    bnt_Wait_Cnt.Visible = false;
                }
                pnl_Main_Load.Enabled = false;
                pnl_Main_Load.Visible = false;
            }
            else
            {
                if (EquipInfo.WORKCENTER.Substring(0, 3) != "CPM" && EquipInfo.WORKCENTER.Substring(0, 3) != "FEM")
                {
                    bnt_Wait_Cnt.Enabled = true;
                    bnt_Wait_Cnt.Visible = true;
                }
                pnl_Main_Load.Enabled = true;
                pnl_Main_Load.Visible = true;
            }
        }

        private void mdiMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            slog = DateTime.Now + "[프로그램 종료] :      ";
            Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
            Application.Exit();
        }

        private void timer_dayInsp_Tick(object sender, EventArgs e)
        {
           /* //기존 구문
            if (DateTime.Now.Hour == 19 && DateTime.Now.Minute == 24)
                btn_Daily_Insp_Click(null, null);
            */
            try
            {
                // 20140917 유민호 추가부분
                DataSet dds = new DataSet();
                Procedure.PPC_DAILY_TIME_FLAG_LOAD(EquipInfo.WORKCENTER, ref dds);
                if (dds != null && dds.Tables[0].Rows.Count > 0)
                {
                    if (dds.Tables[0].Rows[0]["HOUR"].ToString() != "" && dds.Tables[0].Rows[0]["MIN"].ToString() != "" && dds.Tables[0].Rows[0]["FLAG"].ToString() != "N")
                    {
                        // 웹으로 추출
                        if (DateTime.Now.Hour.ToString() == dds.Tables[0].Rows[0]["HOUR"].ToString()
                                    && DateTime.Now.Minute.ToString() == dds.Tables[0].Rows[0]["MIN"].ToString()
                                    && dds.Tables[0].Rows[0]["FLAG"].ToString() == "Y")
                        {
                            btn_Daily_Insp_Click(null, null);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[mdiMain_자동일일검사] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }

        private void btn_Daily_Insp_Click(object sender, EventArgs e)
        {
            if (EquipInfo.ROUTE_GB != "K")
            {
                if (EquipInfo._Frm == "frmWork_Start_CPM")
                    ((frmWork_Stark_CPM)_frmLoad).SerialPortClose();
                else if (EquipInfo._Frm == "frmWork_Start_FEM")
                    ((frmWork_Stark_FEM)_frmLoad).SerialPortClose();
                else if (EquipInfo._Frm == "frmWorkStart")
                    ((frmWorkStart)_frmLoad).SerialPortClose();
                else if (EquipInfo._Frm == "frmWork")
                    ((frmWork)_frmLoad).SerialPortClose();
            }
            System.Threading.Thread.Sleep(500);

            timer_dayInsp.Stop();

            DailyInspectionFormLoad();
            frmDailyInspClose();
            timer_dayInsp.Start();

            System.Threading.Thread.Sleep(500);
            if (EquipInfo.ROUTE_GB != "K")
            {
                if (EquipInfo._Frm == "frmWork_Start_CPM")
                    ((frmWork_Stark_CPM)_frmLoad).SerialPortOpen();
                else if (EquipInfo._Frm == "frmWork_Start_FEM")
                    ((frmWork_Stark_FEM)_frmLoad).SerialPortOpen();
                else if (EquipInfo._Frm == "frmWorkStart")
                    ((frmWorkStart)_frmLoad).SerialPortOpen();
                else if (EquipInfo._Frm == "frmWork")
                    ((frmWork)_frmLoad).SerialPortOpen();
            }
        }


        private void DailyInspectionFormLoad()
        {
            try
            {
                if (frmWorkDailyInspection == null)
                {

                    frmWorkDailyInspection = new frmWorkDailyInspection();
                    frmWorkDailyInspection_Set(frmWorkDailyInspection);
                }
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWorkStart] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }

        private void frmWorkDailyInspection_Set(Form _WorkDailyInspection)
        {
            try
            {
                if (this.InvokeRequired)
                    this.Invoke(new WorkInpection(frmWorkDailyInspection_Set), new object[] { _WorkDailyInspection });
                else
                    frmWorkDailyInspection.ShowDialog();
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWorkStart] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }
        private void frmDailyInspClose()
        {
            if (frmWorkDailyInspection != null)
            {
                frmWorkDailyInspection.Close();
                //frmWorkDailyInspection = null;

                //메모리 해제 구문 추가 20181023 김진성
                frmWorkDailyInspection.Dispose();
                frmWorkDailyInspection = null;

                GC.Collect();
                //구문 추가 END
            }
        }

        /// <summary>
        /// v표준서 버튼 클릭-자동
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_workboard_Click(object sender, EventArgs e)
        {

            WorkBoardFormLoad();
            frmWorkBoadrClose();

            System.Threading.Thread.Sleep(500);                                
       
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
                slog = DateTime.Now + "[frmWorkBoard] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }

        /// <summary>
        /// 작업표준서 폼 클로즈
        /// </summary>
        private void frmWorkBoadrClose()
        {
            if (frmWorkBoard != null)
            {
                frmWorkBoard.Close();
                //frmWorkBoard = null;

                //메모리 해제 구문 추가 20181023 김진성
                frmWorkBoard.Dispose();
                frmWorkBoard = null;

                GC.Collect();
                //구문 추가 END
            }
        }

        /// <summary>
        /// 무선토크 렌치 프로그램 실행
        /// </summary>
        private void itCommandButton1_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(@"C:\Program Files\ACS\MOBIS_TORQUE\MOBIS_TORQUE.exe");
                //System.Diagnostics.Process.Start(@"C:\Users\ACS\Desktop\MOBIS_TORQUE(2)\MOBIS_TORQUE\bin\Debug\MOBIS_TORQUE.exe");
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWirelessTorque] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }
    }
}