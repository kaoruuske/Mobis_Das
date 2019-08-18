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
    public partial class frmWorkInspection : Form
    {
        int InspCnt = 0;
        
        public frmWorkInspection()
        {            
            InitializeComponent();               
        }

        private void frmWorkInspection_Shown(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            lbl_OrderDate.Text = EquipInfo.ORDER_DATE;
            lbl_Commit.Text = EquipInfo.CMT;
            lbl_BodyNo.Text = EquipInfo.BODY_NO;
            lbl_Alc.Text = EquipInfo.ALC;

            DataSet ds = new DataSet();
            Procedure.PPC_INSP_LOAD(EquipInfo.WORKCENTER, EquipInfo.ROUTE_NO, EquipInfo.CAR_CODE,EquipInfo.TR_ID, ref ds);

            /* 
            for (int i = 1; i <= 10; i++)
            {
                foreach (Control ctrl in tableLayoutPanel3.Controls)
                {
                    if (ctrl.GetType() == typeof(Label) && ctrl.Name == "lblInspCode" + i.ToString("0#"))
                    {
                        ctrl.Visible = false;
                    }

                    if (ctrl.GetType() == typeof(Label) && ctrl.Name == "lblInspItem" + i.ToString("0#"))
                    {
                        ctrl.Visible = false;
                    }

                    if (ctrl.GetType() == typeof(MOBISDAS.UI.itCommandButton) && ctrl.Name == "btnInsp" + i.ToString("0#"))
                    {
                        ctrl.Visible = false;
                    }
                    
                } 

   
            }
             */
            InspCnt = ds.Tables[0].Rows.Count;
            for (int i = 1; i <= InspCnt; i++)
            {
                foreach (Control ctrl in tableLayoutPanel3.Controls)
                {
                    if (ctrl.GetType() == typeof(Label) && ctrl.Name == "lblInspCode" + i.ToString("0#"))
                    {
                        ctrl.Visible = true;
                        ((Label)ctrl).Text = ds.Tables[0].Rows[i - 1]["INSP_CODE"].ToString();
                    }

                    else if (ctrl.GetType() == typeof(Label) && ctrl.Name == "lblInspItem" + i.ToString("0#"))
                    {
                        ctrl.Visible = true;
                        ((Label)ctrl).Text = ds.Tables[0].Rows[i - 1]["INSP_NAME"].ToString();
                    }

                    else if (ctrl.GetType() == typeof(MOBISDAS.UI.itCommandButton) && ctrl.Name == "btnInsp" + i.ToString("0#"))
                    {
                        ctrl.Visible = true;
                        ctrl.Enabled = true;
                    }

                } 
            }
           
             
        }

        private void btnInsp01_Click(object sender, EventArgs e)
        {
            if (btnInsp01.Text == "OK")
                btnInsp01.Text = "NG";
            else
                btnInsp01.Text = "OK";
        }

        private void btnInsp02_Click(object sender, EventArgs e)
        {
            if (btnInsp02.Text == "OK")
                btnInsp02.Text = "NG";
            else
                btnInsp02.Text = "OK";
        }

        private void btnInsp03_Click(object sender, EventArgs e)
        {
            if (btnInsp03.Text == "OK")
                btnInsp03.Text = "NG";
            else
                btnInsp03.Text = "OK";
        }

        private void btnInsp04_Click(object sender, EventArgs e)
        {
            if (btnInsp04.Text == "OK")
                btnInsp04.Text = "NG";
            else
                btnInsp04.Text = "OK";
        }

        private void btnInsp05_Click(object sender, EventArgs e)
        {
            if (btnInsp05.Text == "OK")
                btnInsp05.Text = "NG";
            else
                btnInsp05.Text = "OK";
        }

        private void btnInsp06_Click(object sender, EventArgs e)
        {
            if (btnInsp06.Text == "OK")
                btnInsp06.Text = "NG";
            else
                btnInsp06.Text = "OK";
        }

        private void btnInsp07_Click(object sender, EventArgs e)
        {
            if (btnInsp07.Text == "OK")
                btnInsp07.Text = "NG";
            else
                btnInsp07.Text = "OK";
        }

        private void btnInsp08_Click(object sender, EventArgs e)
        {
            if (btnInsp08.Text == "OK")
                btnInsp08.Text = "NG";
            else
                btnInsp08.Text = "OK";
        }

        private void btnInsp09_Click(object sender, EventArgs e)
        {
            if (btnInsp09.Text == "OK")
                btnInsp09.Text = "NG";
            else
                btnInsp09.Text = "OK";
        }

        private void btnInsp10_Click(object sender, EventArgs e)
        {
            if (btnInsp10.Text == "OK")
                btnInsp10.Text = "NG";
            else
                btnInsp10.Text = "OK";
        }

        private void SaveData()
        {
            for (int i = 1; i <= InspCnt; i++)
            {
                string InspCode = "";
                string Result = "";
                foreach (Control ctrl in tableLayoutPanel3.Controls)
                {      
                    if (ctrl.GetType() == typeof(MOBISDAS.UI.itCommandButton) && ctrl.Name == "btnInsp" + i.ToString("0#"))
                    {
                        Result = ctrl.Text;   
                    }

                    if (ctrl.GetType() == typeof(Label) && ctrl.Name == "lblInspCode" + i.ToString("0#"))
                    {
                        InspCode = ctrl.Text;
                    }

                }

                Procedure.PPC_INSP_SAVE(EquipInfo.WORKCENTER, EquipInfo.ROUTE_NO, EquipInfo.CAR_CODE,InspCode,  Result, EquipInfo.TR_ID);
            }
        }

        private void itCommandButton1_Click(object sender, EventArgs e)
        {
            SaveData();
            this.Close();
        }

       

        
    }
}
