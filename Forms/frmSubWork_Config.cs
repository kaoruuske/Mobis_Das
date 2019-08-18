using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MOBISDAS.Common;
using MOBISDAS.UI;
using MOBISDAS.Global;
using MOBISDAS.Database;

namespace MOBISDAS.Forms
{

    public partial class frmSubWork_Config : Form
    {
        private int DisplayMaxRow = 11;
        private string Date = "";
        private string slog = "";

        public frmSubWork_Config(string ORDER_DATE)
        {
            InitializeComponent();
            if (Date == "")
            {
                Date = DateTime.Now.ToString("yyyyMMdd");
            }
            else
            {
                Date = ORDER_DATE;
            }
        }
        
        private void frmSubWork_Config_Shown(object sender, EventArgs e)
        {
            try
            {                
                Initialize();
                BindData();
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmSubWork_Config] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }

        private void Initialize()
        {
            if (EquipInfo.WORKCENTER.Substring(0, 3) == "CPT")
            {
                lbl_title.Text = "트롤리 작업장 작업 조정";
            }
            else
            {
                lbl_title.Text = "SUB 작업장 작업 조정";
            }
            dataGridView_SubSet(ref dataGridView_Sub);          
            lbl_Date_Year.Text = Date.Substring(0, 4);
            lbl_Date_Mon.Text = Date.Substring(4, 2);
            lbl_Date_Day.Text = Date.Substring(6, 2);
            lbl_Commit_No.Text = "";
            
            
        }

        private void BindData()
        {
            try
            {
                //DataSet ds = new DataSet();
                //if (EquipInfo.Virtual == false)
                //{
                //    Procedure.PPC_SUB_WORKORDER(EquipInfo.WORKCENTER, Date, lbl_Commit_No.Text, ref ds);
                //}
                //else
                //{
                //    Procedure.PPC_VIRTUAL_SUB_WORKORDER(EquipInfo.WORKCENTER, Date, lbl_Commit_No.Text, ref ds);
                //}

                DataTable dt = new DataTable();
                dt.Columns.Add("@@TR_ID");
                dt.Columns.Add("일자");
                dt.Columns.Add("CMT");
                dt.Columns.Add("BODY NO");

                dataGridView_Sub.RowTemplate = null;
                dataGridView_Sub.DataSource = dt;
                //dataGridView_Sub.DataSource = ds.Tables[0];

                BinddataGridView_SubSet(ref dataGridView_Sub);

                //ds.Dispose();
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmSubWork_Config] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }

        private void dataGridView_SubSet(ref DataGridView dataGridView)
        {
            try
            {
                //  그리드 Header 설정
                dataGridView.EnableHeadersVisualStyles = false;
                dataGridView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("HY견고딕", 28.00F, FontStyle.Bold);
                dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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
                dataGridView.DefaultCellStyle.Font = new System.Drawing.Font("HY견고딕", 22.00F, FontStyle.Bold);
                dataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //  DefaultCellStyle SETTING
                dataGridView.DefaultCellStyle.BackColor = Color.White;
                dataGridView.DefaultCellStyle.ForeColor = Color.Black;

                dataGridView.BorderStyle = BorderStyle.Fixed3D;
                dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmSubWork_Config] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }

        }

        private void BinddataGridView_SubSet(ref DataGridView dataGridView)
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
                dataGridView.Columns[1].Width = dataGridView.Width * 20 / 100;
                dataGridView.Columns[2].Width = dataGridView.Width * 30 / 100;
                dataGridView.Columns[3].Width = dataGridView.Width * 50 / 100;
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    dataGridView.Rows[i].Height = 50;
                }
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmSubWork_Config] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }
        //조회
        private void btn_Load_Click(object sender, EventArgs e)
        {
            Date = lbl_Date_Year.Text + lbl_Date_Mon.Text + lbl_Date_Day.Text;
            DataSet ds = new DataSet();
            if (EquipInfo.Virtual == false)
            {
                Procedure.PPC_SUB_WORKORDER(EquipInfo.WORKCENTER, Date, lbl_Commit_No.Text, ref ds);
            }
            else
            {
                Procedure.PPC_VIRTUAL_SUB_WORKORDER(EquipInfo.WORKCENTER, Date, lbl_Commit_No.Text, ref ds);
            }

            dataGridView_Sub.RowTemplate = null;
            dataGridView_Sub.DataSource = ds.Tables[0];

            BinddataGridView_SubSet(ref dataGridView_Sub);

            ds.Dispose();
        }
        //닫기
        private void btn_Cancle_Click_1(object sender, EventArgs e)
        {
            EquipInfo.R_Rtn = "";
            this.Dispose();
            this.Close();
        }
        //그리드 한줄씩 아래로
        private void bnt_down_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView_Sub.FirstDisplayedScrollingRowIndex < (dataGridView_Sub.Rows.Count - 1) )
                    dataGridView_Sub.FirstDisplayedScrollingRowIndex = dataGridView_Sub.FirstDisplayedScrollingRowIndex + 1;
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmSubWork_Config] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }
        //그리드 한줄씩 위로
        private void bnt_up_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView_Sub.FirstDisplayedScrollingRowIndex > 0)
                    dataGridView_Sub.FirstDisplayedScrollingRowIndex -= 1;
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmSubWork_Config] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }
        //그리드 한페이지 위로
        private void bnt_up_p_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView_Sub.FirstDisplayedScrollingRowIndex - DisplayMaxRow >= 0)
                    dataGridView_Sub.FirstDisplayedScrollingRowIndex -= (DisplayMaxRow - 2);
                else
                    dataGridView_Sub.FirstDisplayedScrollingRowIndex = 0;
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmSubWork_Config] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }
        //그리드 한페이지 아래로
        private void bnt_down_p_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView_Sub.FirstDisplayedScrollingRowIndex + DisplayMaxRow < (dataGridView_Sub.Rows.Count - 1) - DisplayMaxRow)
                    dataGridView_Sub.FirstDisplayedScrollingRowIndex = dataGridView_Sub.FirstDisplayedScrollingRowIndex + (DisplayMaxRow - 2);
                else
                    dataGridView_Sub.FirstDisplayedScrollingRowIndex = dataGridView_Sub.Rows.Count - DisplayMaxRow + 1;
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmSubWork_Config] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }
        //년도 위로
        private void bnt_Date_Year_Up_Click(object sender, EventArgs e)
        {
            lbl_Date_Year.Text = Convert.ToString(int.Parse(lbl_Date_Year.Text) + 1);
        }
        //년도 아래로
        private void bnt_Date_Year_Down_Click(object sender, EventArgs e)
        {
            lbl_Date_Year.Text = Convert.ToString(int.Parse(lbl_Date_Year.Text)  - 1);
        }
        //달 위로
        private void bnt_Date_Mon_Up_Click(object sender, EventArgs e)
        {
            if (int.Parse(lbl_Date_Mon.Text) < 12)
            {
                lbl_Date_Mon.Text = Convert.ToString(int.Parse(lbl_Date_Mon.Text) + 1);
                if (lbl_Date_Mon.Text.Length == 1)
                {
                    lbl_Date_Mon.Text = "0" + lbl_Date_Mon.Text;
                }
            }
            else
            {
                lbl_Date_Mon.Text = "01";
            }
        }
        //달 아래로
        private void bnt_Date_Mon_Down_Click(object sender, EventArgs e)
        {
            if (int.Parse(lbl_Date_Mon.Text) == 1)
            {
                lbl_Date_Mon.Text = "12";
            }
            else
            {
                lbl_Date_Mon.Text = Convert.ToString(int.Parse(lbl_Date_Mon.Text) - 1);
                if (lbl_Date_Mon.Text.Length == 1)
                {
                    lbl_Date_Mon.Text = "0" + lbl_Date_Mon.Text;
                }
            }
        }
        //일 위로
        private void bnt_Date_Day_Up_Click(object sender, EventArgs e)
        {
            if (int.Parse(lbl_Date_Day.Text) < 31)
            {
                lbl_Date_Day.Text = Convert.ToString(int.Parse(lbl_Date_Day.Text) + 1);
                if (lbl_Date_Day.Text.Length == 1)
                {
                    lbl_Date_Day.Text = "0" + lbl_Date_Day.Text;
                }
            }
            else
            {
                lbl_Date_Day.Text = "01";
            }
        }
        //일 아래로
        private void bnt_Date_Day_Down_Click(object sender, EventArgs e)
        {
            if (int.Parse(lbl_Date_Day.Text) == 1)
            {
                lbl_Date_Day.Text = "31";
            }
            else
            {                
                lbl_Date_Day.Text = Convert.ToString(int.Parse(lbl_Date_Day.Text) - 1);
                if (lbl_Date_Day.Text.Length == 1)
                {
                    lbl_Date_Day.Text = "0" + lbl_Date_Day.Text;
                }
            }
        }

        private void lbl_Commit_No_Click(object sender, EventArgs e)
        {
            frmNumer_Load(lbl_Commit_No);
        }

        private void lbl_Date_Year_Click(object sender, EventArgs e)
        {
            frmNumer_Load(lbl_Date_Year);
        }

        private void lbl_Date_Mon_Click(object sender, EventArgs e)
        {
            frmNumer_Load(lbl_Date_Mon);
            if (lbl_Date_Mon.Text.Length == 1)
            {
                lbl_Date_Mon.Text = "0" + lbl_Date_Mon.Text;
            }
        }

        private void lbl_Date_Day_Click(object sender, EventArgs e)
        {
            frmNumer_Load(lbl_Date_Day);
            if (lbl_Date_Day.Text.Length == 1)
            {
                lbl_Date_Day.Text = "0" + lbl_Date_Day.Text;
            }
        }
        private void frmNumer_Load(Label label)
        {
            frmNumer frmNumer = new frmNumer(label);
            frmNumer.ShowDialog();
        }
        private void btn_Revision_Click(object sender, EventArgs e)
        {
            EquipInfo.R_Rtn = "R";
            this.Close();
        }

        private void dataGridView_Sub_CellClick(object sender, DataGridViewCellEventArgs e)
        {
             try
            {
                lbl_Commit_No.Text = dataGridView_Sub.Rows[e.RowIndex].Cells["CMT"].Value.ToString();
                EquipInfo.R_TR_ID = dataGridView_Sub.Rows[e.RowIndex].Cells["@@TR_ID"].Value.ToString();                
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmSubWork_Config] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }
    }
}
