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
using MOBISDAS.Common;
using MOBISDAS.UI;

namespace MOBISDAS.Forms
{
    public partial class frmWorkKeeper_Sub_Tool : Form
    {
        private DataRow dataRows = null;
        private int tgdTotalCnt = 0;
        private int tgdCarrentCnt = 0;

        public frmWorkKeeper_Sub_Tool(DataRow pdataRows)
        {
            InitializeComponent();
            dataRows = pdataRows;
        }

        private void frmWorkKeeper_Sub_Tool_Shown(object sender, EventArgs e)
        {
            EquipInfo.Tool_Cancle_Rtn = "";
            BindData();
        }

        private void BindData()
        {
            DataSet ds;

            try
            {
                dataGridView_ToolSet(ref dataGridView_Tool);
                
                lbl_Part_Name.Text = dataRows["PART_NAME"].ToString();
                if (dataRows["OK_RESULT"].ToString() == "재작업")
                {
                    lbl_Tool_Cnt.Text = dataRows["TOOL_REWORK_CNT"].ToString();
                    lbl_Result.Font = new System.Drawing.Font("HY견고딕", 80.00F, FontStyle.Bold);
                }
                else
                {
                    lbl_Tool_Cnt.Text = dataRows["TOOL_READ_CNT"].ToString();
                }
                lbl_Tool_Omission.Text = Convert.ToString(double.Parse(dataRows["TOOL_INFO_CNT"].ToString()) - double.Parse(dataRows["TOOL_READ_CNT"].ToString()));

                ds = new DataSet();
                Procedure.PPC_TOOL_CHECK(dataRows["WC_ID"].ToString(), dataRows["CAR_CODE"].ToString(), dataRows["ROUTE_NO"].ToString(), dataRows["PART_ID"].ToString(), ref ds);
                lbl_Tool_Min_Value.Text = Convert.ToString(double.Parse(ds.Tables[0].Rows[0]["MIN_VALUE"].ToString()));
                lbl_Tool_Max_Value.Text = Convert.ToString(double.Parse(ds.Tables[0].Rows[0]["MAX_VALUE"].ToString()));
                lbl_Result.Text = dataRows["OK_RESULT"].ToString();

               
                lbl_Result.ForeColor = Color.Red;
                DataTable dt = new DataTable();
                dataGridView_Tool.RowTemplate = null;
                dt.Columns.Add("순서");
                dt.Columns.Add("체결값");
                dt.Columns.Add("결과");

                tgdTotalCnt = int.Parse(dataRows["TOOL_INFO_CNT"].ToString());

                for (int i = 0; i < tgdTotalCnt; i++)
                {
                    dt.Rows.Add(i + 1);
                }
                dataGridView_Tool.DataSource = dt;
                BinddataGridView_ToolSet(ref dataGridView_Tool);
                
                if (dataRows["OK_RESULT"].ToString() == "NG")
                {
                    ds = new DataSet();
                    Procedure.PPC_KEEPER_TOOL_VALUES(dataRows["WC_ID"].ToString(), dataRows["TR_ID"].ToString(),
                                                          dataRows["ROUTE_NO"].ToString(), dataRows["PART_ID"].ToString(), "NG", ref ds);
                    dataGridView_Tool.RowTemplate = null;
                    dataGridView_Tool.DataSource = ds.Tables[0];
                    BinddataGridView_ToolSet(ref dataGridView_Tool);                    
                }
                else
                {
                    ds = new DataSet();
                    Procedure.PPC_KEEPER_TOOL_VALUES(dataRows["WC_ID"].ToString(), dataRows["TR_ID"].ToString(),
                                                          dataRows["ROUTE_NO"].ToString(), dataRows["PART_ID"].ToString(), "OK", ref ds);
                    dataGridView_Tool.RowTemplate = null;
                    dataGridView_Tool.DataSource = ds.Tables[0];
                    BinddataGridView_ToolSet(ref dataGridView_Tool);
                }

                if (dataRows["OK_RESULT"].ToString() == "NG")
                {
                    lbl_Result.ForeColor = Color.Red;
                }
                else
                {
                    lbl_Result.ForeColor = Color.Blue;
                }                          
            }
            catch (Exception ex)
            {

            }

        }
        
        private void dataGridView_ToolSet(ref DataGridView dataGridView)
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

            }

        }
        
        private void BinddataGridView_ToolSet(ref DataGridView dataGridView)
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
                if (dataGridView.ColumnCount > 3)
                {
                    dataGridView.Columns[3].Width = dataGridView.Width * 22 / 100;
                    dataGridView.Columns[5].Width = dataGridView.Width * 46 / 100;
                    dataGridView.Columns[7].Width = dataGridView.Width * 32 / 100;

                }
                else
                {
                    dataGridView.Columns[0].Width = dataGridView.Width * 22 / 100;
                    dataGridView.Columns[1].Width = dataGridView.Width * 46 / 100;
                    dataGridView.Columns[2].Width = dataGridView.Width * 32 / 100;
                }
                //행 높이
                int iColumnHeaderHeight = 0;
                if (dataGridView.ColumnHeadersVisible == true)
                {
                    iColumnHeaderHeight = dataGridView.ColumnHeadersHeight;
                }
                //ROW 높이 그리드에 꽉 차게...
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    int iRowsHeight = (dataGridView.Height - iColumnHeaderHeight) / dataGridView.Rows.Count;
                    dataGridView.Rows[i].Height = iRowsHeight;

                    if (dataGridView.Rows[i].Cells["결과"].Value.ToString() == "NG")
                    {
                        dataGridView.Rows[i].Cells["결과"].Style.ForeColor = Color.Red;
                    }
                    else
                    {
                        dataGridView.Rows[i].Cells["결과"].Style.ForeColor = Color.Blue;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btn_Cancle_Click(object sender, EventArgs e)
        {
            EquipInfo.Tool_Cancle_Rtn = "CANCLE";
            this.Dispose();
            this.Close();
        }

        private void dataGridView_Tool_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                frmNumer frmNumer = new frmNumer(lbl_Tool_Value);             
                frmNumer.ShowDialog();
                if (lbl_Tool_Value.Text != "")
                {
                    dataGridView_Tool.Rows[e.RowIndex].Cells["체결값"].Value = lbl_Tool_Value.Text;
                    ProcessToolCheck(lbl_Tool_Value.Text);
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        private void ProcessToolCheck(string ToolValue)
        {
            try
            {
                //if (tgdTotalCnt > tgdCarrentCnt)
                //{
                    if (double.Parse(ToolValue) >= double.Parse(lbl_Tool_Min_Value.Text) && double.Parse(ToolValue) <= double.Parse(lbl_Tool_Max_Value.Text))
                    {
                        dataGridView_Tool.Rows[tgdCarrentCnt].Cells["체결값"].Value = ToolValue;
                        dataGridView_Tool.Rows[tgdCarrentCnt].Cells["결과"].Value = "OK";
                        dataGridView_Tool.Rows[tgdCarrentCnt].Cells["결과"].Style.ForeColor = Color.Blue;
                        tgdCarrentCnt += 1;
                        //TOOL 작업 이력 INSERT
                        //Procedure.PPC_TOOL_CHECK_HIST(EquipInfo.WORKCENTER, dataRows["TR_ID"].ToString(), dataRows["ROUTE_NO"].ToString(),
                                                       //dataRows["PART_ID"].ToString(), tgdCarrentCnt.ToString(), ToolValue.ToString(),"OK","M");
                    }
                    else
                    {
                        dataGridView_Tool.Rows[tgdCarrentCnt].Cells["결과"].Value = "Error";
                        dataGridView_Tool.Rows[tgdCarrentCnt].Cells["결과"].Style.ForeColor = Color.Red;
                        dataGridView_Tool.Rows[tgdCarrentCnt].Cells["결과"].Style.Font = new System.Drawing.Font("HY견고딕", 30.00F, FontStyle.Bold);
                        //TOOL 작업 이력 INSERT
                        //Procedure.PPC_TOOL_CHECK_HIST(EquipInfo.WORKCENTER, dataRows["TR_ID"].ToString(), dataRows["ROUTE_NO"].ToString(),
                                                       //dataRows["PART_ID"].ToString(), tgdCarrentCnt.ToString(), ToolValue.ToString(), "NG", "M");
                    }
                //}
                //그리드의 총 로우 수량과 체결 수량이 같으면 폼을 CLOSE 한다.
                //if (tgdTotalCnt == tgdCarrentCnt)
                //{
                //    dataGridView_Tool.Refresh();
                //    System.Threading.Thread.Sleep(1000);
                //    this.Dispose();
                //    this.Close();
                //}

            }
            catch (Exception ex)
            {                
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            for (int i = 0; tgdCarrentCnt > i; i++)
            {
                //TOOL 작업 이력 INSERT
                Procedure.PPC_TOOL_CHECK_HIST(EquipInfo.WORKCENTER, dataRows["TR_ID"].ToString(), dataRows["ROUTE_NO"].ToString(),
                dataRows["PART_ID"].ToString(), Convert.ToString(i+1), dataGridView_Tool.Rows[i].Cells["체결값"].Value.ToString(), 
                dataGridView_Tool.Rows[i].Cells["결과"].Value.ToString(), "M");
            }
            //dataGridView_Tool.Refresh();
            System.Threading.Thread.Sleep(1000);
            this.Dispose();
            this.Close();
        }
    }
}
