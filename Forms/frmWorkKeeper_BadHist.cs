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

namespace MOBISDAS.Forms
{
    public partial class frmWorkKeeper_BadHist : Form
    {
        private string slog = "";
        private frmMsg frmMsg = null;
        public delegate void WorkMsg(Form WorkMsg);
        private int SelectRow = -1;
        public frmWorkKeeper_BadHist()
        {
            InitializeComponent();
        }

        private void frmWorkKeeper_BadHist_Shown(object sender, EventArgs e)
        {
            lbl_OrderDate.Text = EquipInfo.ORDER_DATE;
            lbl_Commit.Text = EquipInfo.CMT;
            lbl_BodyNo.Text = EquipInfo.BODY_NO;
            dataGridView_BadHistcSet(ref dataGridView_BadHist);
            BindData();
            
        }

        private void BindData()
        {
            string tr_id = "";
            DataSet ds = new DataSet();
            SelectRow = -1;
            Procedure.PPC_TRID(EquipInfo.WORKCENTER, lbl_OrderDate.Text, lbl_Commit.Text, lbl_BodyNo.Text, ref ds);

            if (ds.Tables[0].Rows.Count > 0)
                tr_id = ds.Tables[0].Rows[0]["TR_ID"].ToString();
            else
                tr_id = "";
            ds.Dispose();
            if(tr_id != "")
            {
                Procedure.PPC_LOAD_BAD_HIST(EquipInfo.WORKCENTER, tr_id, ref ds);
                dataGridView_BadHist.RowTemplate = null;
                dataGridView_BadHist.DataSource = ds.Tables[0];
                BinddataGridView_BadHistSet(ref dataGridView_BadHist);
                
            }
        }

        private void itCommandButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView_BadHistcSet(ref DataGridView dataGridView)
        {
            try
            {
                //  그리드 Header 설정
                dataGridView.EnableHeadersVisualStyles = false;
                dataGridView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("HY견고딕", 18.00F, FontStyle.Bold);
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

                dataGridView.DefaultCellStyle.Font = new System.Drawing.Font("HY견고딕", 25.00F, FontStyle.Bold);
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

        private void BinddataGridView_BadHistSet(ref DataGridView dataGridView)
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
                dataGridView.Columns[2].Width = dataGridView.Width * 20 / 100;
                dataGridView.Columns[3].Width = dataGridView.Width * 30 / 100;
                dataGridView.Columns[4].Width = dataGridView.Width * 15 / 100;
                dataGridView.Columns[5].Width = dataGridView.Width * 15 / 100;

                int iColumnHeaderHeight = 0;
                if (dataGridView.ColumnHeadersVisible == true)
                {
                    iColumnHeaderHeight = dataGridView.ColumnHeadersHeight;
                }
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    int iRowsHeight = (dataGridView.Height - iColumnHeaderHeight) / dataGridView.Rows.Count;
                    dataGridView.Rows[i].Height = iRowsHeight;
                }
            }
            catch (Exception ex)
            {
                slog = DateTime.Now + "[frmWorkStart] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            string tr_Id = "";
            DataSet ds = new DataSet();
            Procedure.PPC_TRID(EquipInfo.WORKCENTER, lbl_OrderDate.Text, lbl_Commit.Text, lbl_BodyNo.Text, ref ds);

            if (ds.Tables[0].Rows.Count > 0)
                tr_Id = ds.Tables[0].Rows[0]["TR_ID"].ToString();
            else
                tr_Id = "";

            ds.Dispose();

            ds = new DataSet();
            if (tr_Id != "")
            {
                Procedure.PPC_LOAD_PREV_ORDER(EquipInfo.WORKCENTER, tr_Id, ref ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lbl_BodyNo.Text = ds.Tables[0].Rows[0]["BODY_NO"].ToString();
                    lbl_Commit.Text = ds.Tables[0].Rows[0]["COMMIT_NO"].ToString();
                    lbl_OrderDate.Text = ds.Tables[0].Rows[0]["ORDER_DATE"].ToString();

                    BindData();
                }
                else
                {
                    MassageFormLoad("NG", "이전 작업지시가 없습니다.");
                }
            }
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
                slog = DateTime.Now + "[frmWorkKeeper_Bad] :      " + ex;
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
                slog = DateTime.Now + "[frmWorkKeeper_Bad] :      " + ex;
                Global.EquipInfo.fh_Err_Log.TextFileWriteAppend(slog);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            string tr_Id = "";
            DataSet ds = new DataSet();
            Procedure.PPC_TRID(EquipInfo.WORKCENTER, lbl_OrderDate.Text, lbl_Commit.Text, lbl_BodyNo.Text, ref ds);

            if (ds.Tables[0].Rows.Count > 0)
                tr_Id = ds.Tables[0].Rows[0]["TR_ID"].ToString();
            else
                tr_Id = "";

            ds.Dispose();

            ds = new DataSet();
            if (tr_Id != "")
            {
                Procedure.PPC_LOAD_NEXT_ORDER(EquipInfo.WORKCENTER, tr_Id, ref ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lbl_BodyNo.Text = ds.Tables[0].Rows[0]["BODY_NO"].ToString();
                    lbl_Commit.Text = ds.Tables[0].Rows[0]["COMMIT_NO"].ToString();
                    lbl_OrderDate.Text = ds.Tables[0].Rows[0]["ORDER_DATE"].ToString();

                    BindData();
                }
                else
                {
                    MassageFormLoad("NG", "다음 작업지시가 없습니다.");
                }
            }
        }

        private void dataGridView_BadHist_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            for (int i = 0; i < dataGridView_BadHist.Rows.Count; i++)
            {
                dataGridView_BadHist.Rows[i].DefaultCellStyle.BackColor = Color.White;
                dataGridView_BadHist.Rows[i].DefaultCellStyle.SelectionBackColor = Color.White;
            }

            dataGridView_BadHist.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Gold;
            dataGridView_BadHist.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Gold;

            SelectRow = e.RowIndex;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (SelectRow != -1)
            {
                Procedure.PPC_DELETE_BAD_HIST(dataGridView_BadHist.Rows[SelectRow].Cells["@@ROW_STAMP"].Value.ToString());
                BindData();
            }
            else
            {
                MassageFormLoad("NG", "불량 내역을 선택하세요.");
            }
        }

       
    }
}