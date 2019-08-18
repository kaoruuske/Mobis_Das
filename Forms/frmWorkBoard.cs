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
using System.IO;

namespace MOBISDAS.Forms
{
    public partial class frmWorkBoard : Form
    {
        private string slog = string.Empty;

        private string Manual_CarCode = string.Empty;

        private string CAR_CODE_MANUAL = string.Empty;


        private int nReturn = 0;
        private int nReturn_Old = 1;

        private bool ComboFlag = false;

        DataSet ds = null;

        public frmWorkBoard()
        {
            InitializeComponent();
            EquipInfo.BoardFlag = true;
        }


        private void frmWorkBoard_Load(object sender, EventArgs e)
        {
            nReturn = 0;
//            string slog = DateTime.Now + "[Picture_Load_폼로드 확인용] :      ";
            //Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
            CarCode_Load();
            Image_list_Load();
            Picture_Load(1);
            //EquipInfo.SubFalg = true;
        }

        private void CarCode_Load()
        {
            try
            {
                ds = new DataSet();
                Procedure.PPC_WorkBoard_CarCode(EquipInfo.WORKCENTER,ref ds);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    combx_carcode.DataSource = ds.Tables[0];
                    combx_carcode.DisplayMember = "차량명";
                    combx_carcode.ValueMember = "차량코드";
                }
                nReturn = 0;
                ComboFlag = true;
            }
            catch (Exception ex)
            {
                nReturn = 0;
                timer1.Stop();
                slog = DateTime.Now + "[ImageList_Load_CarCode_Load]  " + ex.Message;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }

        /// <summary>
        /// 해당 사양에 대한 이미지 저장 및 갯수 불러오기
        /// </summary>
        private void Image_list_Load()
        {
            try
            {
                timer1.Stop();
                nReturn = 0;
                string szPath = Application.StartupPath + @"\IMG\"+EquipInfo.WORKCENTER + "_" + EquipInfo.H_CAR_CODE+@"\";

                //slog = DateTime.Now + "[Picture_사진 갯수 자동 확인용1] :      " + szPath;
                //Global.EquipInfo.fhLog.TextFileWriteAppend(slog);

                if (Directory.Exists(szPath))
                {
                    string[] pszfileEntries = Directory.GetFiles(szPath);
                    foreach (string szfileName in pszfileEntries)
                    {
                        if (szfileName.Contains(EquipInfo.ROUTE_NO+"공정"))
                        {
                            Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                            nReturn = nReturn + 1;
                        }
                    }
                }
                //slog = DateTime.Now + "[Picture_사진 갯수 자동 확인용2] :      " + nReturn.ToString();
                //Global.EquipInfo.fhLog.TextFileWriteAppend(slog);

                /*
                if (nReturn > 1)
                {

                    timer1.Start();
                }
                 * */

            }
            catch (Exception ex)
            {
                nReturn = 0;
                slog = DateTime.Now + "[ImageList_Load_개발자확인]  "+ex.Message;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }


        /// <summary>
        /// PPC에 저장된 이미지(JPG) 파일 가져오기
        /// </summary>
        private void Picture_Load(int cnt)
        {
            FileStream fs = null;
            try
            {
                timer1.Stop();
                if (Manual_CarCode == "" || Manual_CarCode == "*")
                {
                    //PicBox.ImageLocation = Application.StartupPath + @"\IMG\" + EquipInfo.WORKCENTER+"_"+EquipInfo.CAR_CODE+@"\"+EquipInfo.ROUTE_NO+"공정.gif";
                    //string slog = DateTime.Now + "[Picture_Load] :      " + Application.StartupPath + @"\IMG\" + EquipInfo.WORKCENTER + "_" + EquipInfo.H_CAR_CODE + @"\" + EquipInfo.ROUTE_NO + "공정.jpg";
                    //Global.EquipInfo.fhLog.TextFileWriteAppend(slog);


                    if (EquipInfo.H_CAR_CODE.Length == 2)
                    {
                        pictureBox1.BackgroundImage = null;
                        //pictureBox1.BackgroundImage = Image.FromFile(Application.StartupPath + @"\IMG\" + EquipInfo.WORKCENTER + "_" + EquipInfo.H_CAR_CODE + @"\" + EquipInfo.ROUTE_NO + "공정-" + (cnt + 1).ToString() + ".jpg"); 

                        if (nReturn > 1 && nReturn >= cnt)
                        {
                            //slog = DateTime.Now + "[Picture_Load_개발자확인2-자동]";
                            //Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                            fs = new FileStream(Application.StartupPath + @"\IMG\" + EquipInfo.WORKCENTER + "_" + EquipInfo.H_CAR_CODE + @"\" + EquipInfo.ROUTE_NO + "공정-" + cnt.ToString() + ".jpg", FileMode.Open);
                        }
                        else if(nReturn == 1)
                        {
                            //slog = DateTime.Now + "[Picture_Load_개발자확인2-수동]";
                            //Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                            fs = new FileStream(Application.StartupPath + @"\IMG\" + EquipInfo.WORKCENTER + "_" + EquipInfo.H_CAR_CODE + @"\" + EquipInfo.ROUTE_NO + "공정.jpg", FileMode.Open);
                        }
                        else
                        {
                            // NO Event
                        }

                        if (fs != null)
                        {
                            pictureBox1.BackgroundImage = new System.Drawing.Bitmap(fs);
                            fs.Close();
                        }
                    }
                    else
                    {
                        //slog = DateTime.Now + "[Picture_Load_개발자확인3]";
                        //Global.EquipInfo.fhLog.TextFileWriteAppend(slog);
                    }
                }
                else
                {
                    //slog = DateTime.Now + "[Picture_Load_개발자확인4]";
                    //Global.EquipInfo.fhLog.TextFileWriteAppend(slog);

                    pictureBox1.BackgroundImage = null;
                    //pictureBox1.BackgroundImage = Image.FromFile(Application.StartupPath + @"\IMG\" + EquipInfo.WORKCENTER + "_" + EquipInfo.H_CAR_CODE + @"\" + EquipInfo.ROUTE_NO + "공정-" + (cnt + 1).ToString() + ".jpg"); 
                    if (nReturn > 1 && nReturn >= cnt)
                    {
                        fs = new FileStream(Application.StartupPath + @"\IMG\" + EquipInfo.WORKCENTER + "_" + Manual_CarCode + @"\" + EquipInfo.ROUTE_NO + "공정-" + cnt.ToString() + ".jpg", FileMode.Open);
                    }
                    else if (nReturn == 1)
                    {
                        fs = new FileStream(Application.StartupPath + @"\IMG\" + EquipInfo.WORKCENTER + "_" + Manual_CarCode + @"\" + EquipInfo.ROUTE_NO + "공정.jpg", FileMode.Open);
                    }
                    else
                    {
                        // No Event
                    }

                    if (fs != null)
                    {
                        pictureBox1.BackgroundImage = new System.Drawing.Bitmap(fs);
                        fs.Close();
                    }
                }
                timer1.Start();
            }
            catch (Exception ex)
            {
                timer1.Stop();
                nReturn = 0;
                if (fs != null)
                {
                    fs.Close();
                }
                slog = DateTime.Now + "[frmWorkBoard_이미지 로드] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if (nReturn >= nReturn_Old)
            {
                Picture_Load(nReturn_Old);
                nReturn_Old++;
            }
            else
            {
                nReturn_Old = 1;
                Picture_Load(nReturn_Old);
                nReturn_Old++;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = null;
            EquipInfo.BoardFlag = false;
            timer1.Stop();
            this.Close();
        }

        private void combx_carcode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Manual_CarCode = string.Empty;
                nReturn = 0;
                if (ComboFlag == true && combx_carcode.SelectedValue.ToString() != "*")
                {
                    timer1.Stop();
                    Manual_CarCode = combx_carcode.SelectedValue.ToString();
                    Manual_Image_List();
                    Picture_Load(1);
                    
                }
            }
            catch (Exception ex)
            {
                nReturn = 0;
                slog = DateTime.Now + "[frmWorkBoard_Car_Code] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }

        private void Manual_Image_List()
        {
            try
            {
                nReturn = 0;
                string szPath = Application.StartupPath + @"\IMG\" + EquipInfo.WORKCENTER + "_" + Manual_CarCode + @"\";
                //slog = DateTime.Now + "[Picture_사진 갯수 수동 확인용1] :      " + szPath;
                //Global.EquipInfo.fhLog.TextFileWriteAppend(slog);

                if (Directory.Exists(szPath))
                {
                    string[] pszfileEntries = Directory.GetFiles(szPath);
                    foreach (string szfileName in pszfileEntries)
                    {
                        if (szfileName.Contains(EquipInfo.ROUTE_NO + "공정"))
                        {
                            nReturn = nReturn + 1;
                        }
                    }
                }

                //slog = DateTime.Now + "[Picture_사진 갯수 수동 확인용2] :      " + nReturn;
                //Global.EquipInfo.fhLog.TextFileWriteAppend(slog);

                /*
                if (nReturn > 1)
                {
                    timer1.Start();
                }
                 * */

            }
            catch (Exception ex)
            {
                timer1.Stop();
                nReturn = 0;
                slog = DateTime.Now + "[ImageList_Load_Manual_Image_List]  " + ex.Message;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }

        private void frmWorkBoard_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                nReturn = 0;
                timer1.Stop();
                EquipInfo.BoardFlag = false;
                pictureBox1.Dispose();
                ds.Dispose();


                //메모리 해제 구문 추가 20181023 김진성
                GC.Collect();
                //구문 추가 END
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWorkBoard_FormClosing]  " + ex.Message;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
           

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked)
            {
                EquipInfo.Auto_Flag = true;
            }
            else
	        {
                EquipInfo.Auto_Flag = false;
	        }
        }
    }
}
