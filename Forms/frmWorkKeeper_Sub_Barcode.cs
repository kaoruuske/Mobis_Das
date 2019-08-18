using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MOBISDAS.UI;
using MOBISDAS.Common;
using MOBISDAS.Database;
using MOBISDAS.Global;

namespace MOBISDAS.Forms
{
    public partial class frmWorkKeeper_Sub_Barcode : Form
    {
        private DataRow dataRows = null;

        public frmWorkKeeper_Sub_Barcode(DataRow pdataRows)
        {
            InitializeComponent();
            dataRows = pdataRows;
            EquipInfo.Tool_Cancle_Rtn = "";
            BindData();
        }

        private void BindData()
        {
            try
            {                
                lbl_Part_Name.Text = dataRows["PART_NAME"].ToString();
                lbl_Alc.Text = dataRows["ALC_CODE"].ToString();

                if (dataRows["OK_RESULT"].ToString() == "재작업")
                {
                    lbl_Result.Font = new System.Drawing.Font("HY견고딕", 100.00F, FontStyle.Bold);
                }
                else  if(dataRows["OK_RESULT"].ToString() == "MASTER")
                {
                    lbl_Result.Font = new System.Drawing.Font("HY견고딕", 55.00F, FontStyle.Bold);
                }
                lbl_Result.Text = dataRows["OK_RESULT"].ToString();

                if (dataRows["BARCODE_READ"].ToString().Length <= 4)
                {
                    lbl_Barcode_Read.Font = new System.Drawing.Font("HY견고딕", 110.00F, FontStyle.Bold);
                }
                lbl_Barcode_Read.Text = dataRows["BARCODE_READ"].ToString();
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

        private void lbl_Barcode_Read_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataRows["OK_RESULT"].ToString() == "NG")
                {
                    frmKeyboard frmKeyboard = new frmKeyboard(lbl_Barcode_Read);
                    frmKeyboard.ShowDialog(this);
                    
                    if (lbl_Barcode_Read.Text != "")
                    {
                        if (lbl_Barcode_Read.Text.Length <= 4)
                        {
                            lbl_Barcode_Read.Font = new System.Drawing.Font("HY견고딕", 120.00F, FontStyle.Bold);
                        }
                        ProcessJob();
                    }
                }
            }
            catch (Exception ex)
            {                
            }
        }

        private void ProcessJob()
        {
            try
            {
                DataSet ds = new DataSet();
                Procedure.PPC_PROCESSJOB_ALC(lbl_Barcode_Read.Text, EquipInfo.WORKCENTER, dataRows["ROUTE_NO"].ToString(), dataRows["CAR_CODE"].ToString(), dataRows["PART_ID"].ToString(),
                                         dataRows["BARCODE_INFO"].ToString(),dataRows["BARCODE_READ"].ToString(),dataRows["TR_ID"].ToString(), "R", ref ds);
                if (ds.Tables[0].Rows[0]["OK_NG"].ToString() == "OK")
                {
                    this.Dispose();
                    this.Close();
                }
                else
                {
                    lbl_Barcode_Read.Text = "";
                }
                ds.Dispose();
            }
            catch (Exception ex)
            {                
            }
        }
    }
}
