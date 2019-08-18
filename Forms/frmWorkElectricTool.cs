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
using System.Reflection;

namespace MOBISDAS.Forms
{
    public partial class frmWorkElectricTool : Form
    {
        private string FileName = null;
        private frmMsg frmMsg = null;

        private int tgdTotalCnt = 0;
        private int tgdToolRecvCnt = 0;
        private int tgdToolOkCnt = 0;

        private string Low_Value = "";
        private string High_Value = "";

        private string slog = "";

        private string commStatus = "";

        public frmWorkElectricTool()
        {            
            InitializeComponent();
        }

        private void frmWorkElectricTool_Shown(object sender, EventArgs e)
        {
            try
            {
                Initialize();       
                // PARAM 정보를 보낸다.
                TagSet();
                BindData();
                Picture_Load();                                                                             
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWorkElectricTool] : frmWorkElectricTool_Shown      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }
        private void Initialize()
        {
            try
            {
                EquipInfo.Tool_Cancle_Rtn = "";
                lbl_Point.Size = new System.Drawing.Size(106, 76);
                this.lbl_Point.Parent = picBox;                

                dataGridView_AlcSet(ref dataGridView_Alc);
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWorkElectricTool] : Initialize     " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }
        public static void SetDoubleBuffered(System.Windows.Forms.Control c)
        {
            Type dgvType = c.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(c, true, null);
        }

        private void BindData()
        {
            DataTable dt = new DataTable();
            DataSet ds;
            try
            {
                lbl_OrderDate.Text = EquipInfo.ORDER_DATE;
                lbl_Commit.Text = EquipInfo.CMT;
                lbl_BodyNo.Text = EquipInfo.BODY_NO;
                lbl_Alc.Text = EquipInfo.ALC;

                //TOOL CHECK 수량 조회;
                ds = new DataSet();
                if (EquipInfo.Virtual == false)
                {
                    Procedure.PPC_LOAD_TOOL(EquipInfo.WORKCENTER, EquipInfo.BODY_NO.Substring(0, 2), EquipInfo.ROUTE_NO, EquipInfo.PART_ID,
                                            EquipInfo.TR_ID, EquipInfo.ASSY_SEQ, EquipInfo.ORDER_DATE, EquipInfo.BODY_NO, EquipInfo.CMT, ref ds);
                }
                else
                {
                    Procedure.PPC_VIRTUAL_LOAD_TOOL(EquipInfo.WORKCENTER, EquipInfo.BODY_NO.Substring(0, 2), EquipInfo.ROUTE_NO, EquipInfo.PART_ID,
                                                    EquipInfo.TR_ID, EquipInfo.ASSY_SEQ, EquipInfo.ORDER_DATE, EquipInfo.BODY_NO, EquipInfo.CMT, ref ds);
                }
                dataGridView_Alc.RowTemplate = null;
                dt.Columns.Add("순서");
                dt.Columns.Add("@@측정값");
                dt.Columns.Add("결과");
               

                tgdTotalCnt = int.Parse(ds.Tables[0].Rows[0]["WORK_QTY"].ToString());
                
                //////
                slog = DateTime.Now + "[frmWorkElectricTool- 작업횟수] :      " + tgdTotalCnt;
                Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                ////// 

                for (int i = 0; i < tgdTotalCnt; i++)
                {
                    dt.Rows.Add(i+1);
                }              
                dataGridView_Alc.DataSource = dt;
                BinddataGridView_AlcSet(ref dataGridView_Alc);
                                     
                Tool_Position();
                ds.Dispose(); 
                
                
                ///////////2013.09.05 툴 체결값을 체크하기전에 한번더 PARM MAIN/MAX 값을 체크한다. ///////////////
                string pHigh_Value = "";
                string pLow_Value = "";

                pHigh_Value = NetRemoting.TagGet(EquipInfo.WORKCENTER + "_" + EquipInfo.ROUTE_NO + "_TOOL_MAX");
                pLow_Value = NetRemoting.TagGet(EquipInfo.WORKCENTER + "_" + EquipInfo.ROUTE_NO + "_TOOL_MIN");

                if (pHigh_Value == "0" || pHigh_Value == "" || pLow_Value == "0" || pLow_Value == "")
                {
                    Dabom.TagAdapter.Item.WorkDataUp datup = new Dabom.TagAdapter.Item.WorkDataUp(EquipInfo.WORKCENTER + "_" + EquipInfo.ROUTE_NO, true);

                    datup.Variables.Add("TOOL_MAX", new VariableItem { VarID = "TOOL_MAX", Value = High_Value });
                    datup.Variables.Add("TOOL_MIN", new VariableItem { VarID = "TOOL_MIN", Value = Low_Value });
                    NetRemoting.Comm_IDSet_Etool(datup);
                }
                //////////////////////////////////////////////////////////////////////////////////////
                
                timer_Tool_Check.Enabled = true;
                //////
                slog = DateTime.Now + "[frmWorkElectricTool TOOL 체결값 체크 시작] :      ";
                Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                ////// 
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWorkElectricTool] : BindData      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }

        private void TagSet()
        {
            string rTR_ID = "";

            try
            {
                
                DataSet ds = new DataSet();
                Procedure.PPC_TOOL_CHECK(EquipInfo.WORKCENTER, EquipInfo.BODY_NO.Substring(0,2), EquipInfo.ROUTE_NO, EquipInfo.PART_ID, ref ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    rTR_ID = NetRemoting.TagGet(EquipInfo.WORKCENTER + "_" + EquipInfo.ROUTE_NO + "_TR_ID");

                    if (rTR_ID == "0" || rTR_ID == "")
                    {
                        High_Value = ds.Tables[0].Rows[0]["MAX_VALUE"].ToString();
                        Low_Value = ds.Tables[0].Rows[0]["MIN_VALUE"].ToString();

                        Dabom.TagAdapter.Item.WorkDataUp datupS = new Dabom.TagAdapter.Item.WorkDataUp(EquipInfo.WORKCENTER + "_" + EquipInfo.ROUTE_NO, true);

                        datupS.Variables.Add("TOOL_MAX", new VariableItem { VarID = "TOOL_MAX", Value = High_Value });
                        datupS.Variables.Add("TOOL_MIN", new VariableItem { VarID = "TOOL_MIN", Value = Low_Value });
                        datupS.Variables.Add("TR_ID", new VariableItem { VarID = "TR_ID", Value = EquipInfo.TR_ID });
                        NetRemoting.Comm_IDSet_Etool(datupS);

                        //////
                        slog = DateTime.Now + "[frmWorkElectricTool TAG MIN/MAX/TR_ID(재전송) 전송] :      " + High_Value + "/" + Low_Value + "/" + EquipInfo.TR_ID;
                        Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                        //////
                    }
                    else
                    {
                        High_Value = ds.Tables[0].Rows[0]["MAX_VALUE"].ToString();
                        Low_Value = ds.Tables[0].Rows[0]["MIN_VALUE"].ToString();

                        Dabom.TagAdapter.Item.WorkDataUp datupT = new Dabom.TagAdapter.Item.WorkDataUp(EquipInfo.WORKCENTER + "_" + EquipInfo.ROUTE_NO, true);

                        datupT.Variables.Add("TOOL_MAX", new VariableItem { VarID = "TOOL_MAX", Value = High_Value });
                        datupT.Variables.Add("TOOL_MIN", new VariableItem { VarID = "TOOL_MIN", Value = Low_Value });
                        datupT.Variables.Add("TR_ID", new VariableItem { VarID = "TR_ID", Value = EquipInfo.TR_ID });
                        NetRemoting.Comm_IDSet_Etool(datupT);

                        //////
                        slog = DateTime.Now + "[frmWorkElectricTool TAG MIN/MAX 전송] :      " + High_Value + "/" + Low_Value;
                        Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                        //////
                    }
                   
                }
                else
                {
                    timer_Tool_Check.Enabled = false;
                    frmMsg = new frmMsg("ERROR", "SPEC 기준정보가 없습니다.");
                    frmMsg.ShowDialog();
                    timer_Tool_Check.Enabled = true;
                }
                ds.Dispose();
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWorkElectricTool] : TagSet     " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }

        //TOOL 체결 해야할 위치 표시 포지션
        private void Tool_Position()
        {
            try
            {
                DataSet ds = new DataSet();
                if (EquipInfo.Virtual == false)
                {
                    Procedure.PPC_TOOL_IMAGE_POSITION(EquipInfo.WORKCENTER, EquipInfo.BODY_NO.Substring(0, 2), EquipInfo.ROUTE_NO, EquipInfo.PART_ID,
                                                           EquipInfo.ASSY_SEQ, EquipInfo.ORDER_DATE, EquipInfo.BODY_NO, EquipInfo.CMT, EquipInfo.TR_ID, ref ds);
                }
                else
                {
                    Procedure.PPC_VIRTUAL_TOOL_IMAGE_POSITION(EquipInfo.WORKCENTER, EquipInfo.BODY_NO.Substring(0, 2), EquipInfo.ROUTE_NO, EquipInfo.PART_ID,
                                                           EquipInfo.ASSY_SEQ, EquipInfo.ORDER_DATE, EquipInfo.BODY_NO, EquipInfo.CMT, EquipInfo.TR_ID, ref ds);
                }

                //////
                slog = DateTime.Now + "[frmWorkElectricTool- TOOL 포지션] :      " + EquipInfo.WORKCENTER+"/"+ EquipInfo.BODY_NO.Substring(0,2)+"/"+ EquipInfo.ROUTE_NO+"/"+ EquipInfo.PART_ID+"/"+
                                                       EquipInfo.ASSY_SEQ + "/" + EquipInfo.ORDER_DATE + "/" + EquipInfo.BODY_NO + "/" + EquipInfo.CMT + "/" + EquipInfo.TR_ID;
                Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                ////// 

                //네모칸 위치 
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > tgdToolOkCnt)
                    {
                        lbl_Point.Left = (pnl_Picture.Width / 100) * int.Parse(ds.Tables[0].Rows[tgdToolOkCnt]["POSX"].ToString());
                        lbl_Point.Top = (pnl_Picture.Height / 100) * int.Parse(ds.Tables[0].Rows[tgdToolOkCnt]["POSY"].ToString());
                        btn_Position.Text = Convert.ToString(tgdToolOkCnt + 1);
                        btn_Position.Left = ((pnl_Picture.Width / 100) * int.Parse(ds.Tables[0].Rows[tgdToolOkCnt]["POSX"].ToString())) - 50;
                        btn_Position.Top = ((pnl_Picture.Height / 100) * int.Parse(ds.Tables[0].Rows[tgdToolOkCnt]["POSY"].ToString())) + 5;
                        timer_Position.Enabled = true;
                    }
                }
                ds.Dispose();
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWorkElectricTool] : Tool_Position     " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }

        private void ProcessToolCheck()
        {
            try
            {
                string Too_Value_Flag = "";
                int ArryCount = 0;

                commStatus = NetRemoting.Comm_IDGet(EquipInfo.WORKCENTER + "_" + EquipInfo.ROUTE_NO);
                if (commStatus != null)
                {
                    
                    Dictionary<string, Dabom.TagAdapter.Item.VariableItem> mVariableItems = (new Dabom.TagAdapter.StateParse(commStatus)).ToVariableItems();//DICTIONARY 넣기

                    //------------------------- 수정 2017.02.21------------------------------------- 
                    VariableItem result = new VariableItem();

                    //string[] Tool_Value = mVariableItems["TOOL_VALUE"].Value.ToString().Split(':');

                    string[] Tool_Value = null;
                    bool exist = mVariableItems.TryGetValue("TOOL_VALUE", out result);

                    if (exist)
                    {
                        Tool_Value = mVariableItems["TOOL_VALUE"].Value.ToString().Split(':');
                    }

                    //--------------------------------------------------------------------------------


                    //if (Tool_Value[0].Equals("") && Tool_Value.Length == 1)
                    if (Tool_Value[0].Equals("") && Tool_Value.Length == 1)
                    {
                        ArryCount = 0;
                        // 2014 11 18 유민호 수정 ---------------------------------------------------------------------------
                        mVariableItems = null;
                        mVariableItems = (new Dabom.TagAdapter.StateParse(commStatus)).ToVariableItems();//DICTIONARY 넣기
                        Tool_Value = mVariableItems["TOOL_VALUE"].Value.ToString().Split(':');
                        ArryCount = Tool_Value.Length;
                        //if (Tool_Value[0].Equals("") && Tool_Value.Length == 1)
                        if (Tool_Value.Length == 1)
                        {
                            ArryCount = 0;
                        }
                        // 여기까지----------------------------------------------------------------------------------------------

                    }
                    else
                        ArryCount = Tool_Value.Length;


                    /////
                    slog = DateTime.Now + "[frmWorkElectricTool] :      " + "mVariableItems 개수  " + Tool_Value.Length + "ArryCount 개수" + ArryCount;
                    Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                    /////


                    //if (ArryCount > tgdToolRecvCnt && ArryCount != 0)
                    if (ArryCount > tgdToolRecvCnt && ArryCount != 0 && tgdTotalCnt != 0)
                    {
                        if (Tool_Value[ArryCount - 1].ToString().Split('_')[1].ToString() != "")
                        {
                            Too_Value_Flag = Tool_Value[ArryCount - 1].ToString().Split('_')[0].ToString();


                            ////
                            slog = DateTime.Now + "[ArryCount & tgdToolRecvCnt & tgdTotalCnt]  :      " + ArryCount +" // " + tgdTotalCnt +" // " + tgdToolRecvCnt + " // " + tgdToolOkCnt;
                            Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                            //// 


                            if (Too_Value_Flag == "Y")
                            {
                                //////
                                slog = DateTime.Now + "[frmWorkElectricTool 측정값 OK] :      " + Tool_Value[ArryCount - 1].ToString().Split('_')[1].ToString() + "@" + tgdToolRecvCnt + "@" + ArryCount;
                                Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                                ////// 

                                if (double.Parse(Tool_Value[ArryCount - 1].ToString().Split('_')[1].ToString()) >= double.Parse(Low_Value) && double.Parse(Tool_Value[ArryCount - 1].ToString().Split('_')[1].ToString()) <= double.Parse(High_Value))
                                {
                                    dataGridView_Alc.Rows[tgdToolOkCnt].Cells["@@측정값"].Value = Tool_Value[ArryCount - 1].ToString().Split('_')[1].ToString();
                                    dataGridView_Alc.Rows[tgdToolOkCnt].Cells["결과"].Value = "OK";
                                    dataGridView_Alc.Rows[tgdToolOkCnt].Cells["결과"].Style.ForeColor = Color.Blue;

                                    tgdToolOkCnt++;
                                    Tool_Position();
                                }
                            }
                            else
                            {
                                //////
                                slog = DateTime.Now + "[frmWorkElectricTool 측정값 NG] :      " + dataGridView_Alc.Rows[tgdToolOkCnt].Cells["@@측정값"].Value;
                                Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                                ////// 

                                dataGridView_Alc.Rows[tgdToolOkCnt].Cells["@@측정값"].Value = Tool_Value[ArryCount - 1].ToString().Split('_')[1].ToString();
                                dataGridView_Alc.Rows[tgdToolOkCnt].Cells["결과"].Value = "NG";
                                dataGridView_Alc.Rows[tgdToolOkCnt].Cells["결과"].Style.ForeColor = Color.Red;
                            }
                            
                            tgdToolRecvCnt++;
                        }
                    }

                  


                    //그리드의 총 로우 수량과 체결 수량이 같으면 폼을 CLOSE 한다.
                    //2017.03.24 예외파트 구별로 인한 화면 멈춤현상 수정 : 전제 그리드 카운트가 0일 때 확인하는 방법
                    if (tgdTotalCnt == tgdToolOkCnt || tgdTotalCnt == 0)
                    {
                        //RESET                        
                        Dabom.TagAdapter.Item.WorkDataUp datup = new Dabom.TagAdapter.Item.WorkDataUp(EquipInfo.WORKCENTER + "_" + EquipInfo.ROUTE_NO, true);
                        datup.Variables.Add("TOOL_VALUE", new VariableItem { VarID = "TOOL_VALUE", Value = "" });
                        datup.Variables.Add("TR_ID", new VariableItem { VarID = "TR_ID", Value = "" });
                        NetRemoting.Comm_IDSet_Etool(datup);
                        //

                        //////
                        slog = DateTime.Now + "[frmWorkElectricTool-TAG TOO_VALUE/TR_ID 초기화 함] :      ";
                        Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                        //////

                        timer_Position.Enabled = false;
                        timer_Tool_Check.Enabled = false;

                        //////
                        slog = DateTime.Now + "[frmWorkElectricTool TOOL 체결값 체크 끝] :      ";
                        Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                        ////// 

                        dataGridView_Alc.Refresh();
                        System.Threading.Thread.Sleep(500);

                        //////
                        slog = DateTime.Now + "[frmWorkElectricTool TOOL 작업 완료됨] :      ";
                        Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                        //////

                        //frmMsg = new frmMsg("WORK_COMPLETE", "작업이 완료 되었습니다!.");
                        //frmMsg.ShowDialog();
                        //frmMessageClose();
                        //System.Threading.Thread.Sleep(500);                       
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWorkElectricTool] : ProcessToolCheck     " + ex;
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
                    }
                    else
                    {
                        //picBox.Load(FileName);
                        //이미지 사이즈 변경 추가 20181024 김진성
                        Bitmap reSizeImg = ResizeImage(FileName);
                        picBox.Image = reSizeImg;
                    }
                    //picBox.Load(DFileName);
                }
                else
                {
                    //picBox.Load(FileName);
                    //picBox.Refresh();
                    //이미지 사이즈 변경 추가 20181024 김진성
                    Bitmap reSizeImg = ResizeImage(FileName);
                    picBox.Image = reSizeImg;
                }
                //////
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWorkElectricTool] : Picture_Load     " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }


        private Bitmap ResizeImage(string fileName) //이미지를 현재 picturebox 사이즈에 맞도록 수정 20181024 김진성
        {
            try
            {
                //image size 변환 추가 20181024 김진성
                int x = picBox.Width;
                int y = picBox.Height;

                Size resize = new Size(x, y);

                Bitmap newImage = new Bitmap(fileName);

                Bitmap resizeImage = new Bitmap(newImage, resize);

                newImage.Dispose();

                return resizeImage;
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWorkElectricTool ResizeImage] :      " + ex;
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
                dataGridView.Columns[0].Width = dataGridView.Width * 22 / 100;
                dataGridView.Columns[1].Width = dataGridView.Width * 46 / 100;
                dataGridView.Columns[2].Width = dataGridView.Width * 78 / 100;
                //행 높이
                int iColumnHeaderHeight = 0;
                if (dataGridView.ColumnHeadersVisible == true)
                {
                    iColumnHeaderHeight = dataGridView.ColumnHeadersHeight;
                }
                if (dataGridView.Rows.Count > 5)
                {
                    dataGridView.DefaultCellStyle.Font = new System.Drawing.Font("HY견고딕", 23.00F, FontStyle.Bold);
                }
                //ROW 높이 그리드에 꽉 차게...
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    int iRowsHeight = (dataGridView.Height - iColumnHeaderHeight) / dataGridView.Rows.Count;
                    dataGridView.Rows[i].Height = iRowsHeight;
                    dataGridView_Alc.Rows[i].Cells["@@측정값"].Value = "";
                }
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWorkElectricTool] : BinddataGridView_AlcSet     " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }

        private void dataGridView_AlcSet(ref DataGridView dataGridView)
        {
            try
            {
                //  그리드 Header 설정
                dataGridView.EnableHeadersVisualStyles = false;
                dataGridView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("HY견고딕", 22.00F, FontStyle.Bold);
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

                dataGridView.DefaultCellStyle.Font = new System.Drawing.Font("HY견고딕", 48.00F, FontStyle.Bold);
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
                slog = DateTime.Now + "[frmWorkElectricTool] : dataGridView_AlcSet     " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }
        private void dataGridView_Alc_SizeChanged(object sender, EventArgs e)
        {
            BinddataGridView_AlcSet(ref dataGridView_Alc);
        }

        private void btn_Cancle_Click(object sender, EventArgs e)
        {
            
            //RESET
            Dabom.TagAdapter.Item.WorkDataUp datup = new Dabom.TagAdapter.Item.WorkDataUp(EquipInfo.WORKCENTER + "_" + EquipInfo.ROUTE_NO, true);
            datup.Variables.Add("TOOL_VALUE", new VariableItem { VarID = "TOOL_VALUE", Value = "" });
            NetRemoting.Comm_IDSet_Etool(datup);
            //
            

            timer_Position.Enabled = false;
            timer_Tool_Check.Enabled = false;
            EquipInfo.Tool_Cancle_Rtn = "CANCLE";
            //frmMsg = new frmMsg("TOOL CLOSE", "");
            //frmMsg.ShowDialog();
            this.Close();
        }

        private void timer_Position_Tick(object sender, EventArgs e)
        {
            try
            {
                if (lbl_Point.Visible)
                {
                    lbl_Point.Visible = false;
                }
                else
                {
                    lbl_Point.Visible = true;
                }
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWorkElectricTool] : timer_Position_Tick     " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }

        private void timer_Tool_Check_Tick(object sender, EventArgs e)
        {
            ProcessToolCheck();
        }

        private void dataGridView_Alc_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (e.RowIndex == tgdToolOkCnt)
                {
                    frmNumer frmNumer = new frmNumer(lbl_Number);
                    frmNumer.ShowDialog();
                    if (lbl_Number.Text != "")
                    {

                        if (double.Parse(lbl_Number.Text) >= double.Parse(Low_Value) && double.Parse(lbl_Number.Text) <= double.Parse(High_Value))
                        {
                            //////
                            slog = DateTime.Now + "[frmWorkElectricTool 측정값 OK] : dataGridView_Alc_CellClick     " + lbl_Number.Text;
                            Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                            ////// 

                            dataGridView_Alc.Rows[tgdToolOkCnt].Cells["@@측정값"].Value = lbl_Number.Text;
                            dataGridView_Alc.Rows[tgdToolOkCnt].Cells["결과"].Value = "OK";
                            dataGridView_Alc.Rows[tgdToolOkCnt].Cells["결과"].Style.ForeColor = Color.Blue;
                            tgdToolOkCnt++;
                            tgdToolRecvCnt++;
                            //TOOL 작업 이력 INSERT
                            Procedure.PPC_ETOOL_CHECK_HIST(EquipInfo.WORKCENTER, EquipInfo.TR_ID, EquipInfo.ROUTE_NO, EquipInfo.PART_ID, Convert.ToString(tgdToolOkCnt), lbl_Number.Text, "OK", "M");

                            //////
                            slog = DateTime.Now + "[frmWorkElectricTool OK 판정 INSERT SP] : PPC_ETOOL_CHECK_HIST     " + EquipInfo.WORKCENTER + "/" + EquipInfo.TR_ID + "/" + EquipInfo.ROUTE_NO + "/" + EquipInfo.PART_ID + "/" + Convert.ToString(tgdToolOkCnt) + "/" + lbl_Number.Text + "/" + "OK" + "/" + "M";
                            Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                            //////
                                                    

                            Tool_Position();
                        }
                        else
                        {
                            //////
                            slog = DateTime.Now + "[frmWorkElectricTool 측정값 NG] :      " + double.Parse(lbl_Number.Text);
                            Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                            ////// 

                            dataGridView_Alc.Rows[tgdToolOkCnt].Cells["@@측정값"].Value = lbl_Number.Text;
                            dataGridView_Alc.Rows[tgdToolOkCnt].Cells["결과"].Value = "NG";
                            dataGridView_Alc.Rows[tgdToolOkCnt].Cells["결과"].Style.ForeColor = Color.Red;
                            Procedure.PPC_ETOOL_CHECK_HIST(EquipInfo.WORKCENTER, EquipInfo.TR_ID, EquipInfo.ROUTE_NO, EquipInfo.PART_ID, Convert.ToString(tgdToolOkCnt + 1), lbl_Number.Text, "NG", "M");

                            //////
                            slog = DateTime.Now + "[frmWorkElectricTool NG 판정 INSERT SP] :      " + EquipInfo.WORKCENTER+"/"+ EquipInfo.TR_ID+"/"+ EquipInfo.ROUTE_NO+"/"+ EquipInfo.PART_ID+"/"+ Convert.ToString(tgdToolOkCnt + 1)+"/"+ lbl_Number.Text+"/"+ "NG"+"/"+ "M";
                            Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                            //////

                            return;
                        }

                        if (tgdTotalCnt == tgdToolOkCnt)
                        {

                            //RESET                        
                            Dabom.TagAdapter.Item.WorkDataUp datup = new Dabom.TagAdapter.Item.WorkDataUp(EquipInfo.WORKCENTER + "_" + EquipInfo.ROUTE_NO, true);
                            datup.Variables.Add("TOOL_VALUE", new VariableItem { VarID = "TOOL_VALUE", Value = "" });
                            NetRemoting.Comm_IDSet_Etool(datup);
                            //

                            timer_Position.Enabled = false;
                            timer_Tool_Check.Enabled = false;
                            dataGridView_Alc.Refresh();
                            System.Threading.Thread.Sleep(1000);

                            //////
                            slog = DateTime.Now + "[frmWorkElectricTool TOOL 작업 완료됨] :      ";
                            Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                            //////

                            //frmMsg = new frmMsg("WORK_COMPLETE", "작업이 완료 되었습니다!.");
                            //frmMsg.ShowDialog();
                            //frmMessageClose();
                            //System.Threading.Thread.Sleep(500);
                            this.Close();
                        }
                        lbl_Number.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWorkElectricTool] : dataGridView_Alc_CellClick     " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }
    }
}
