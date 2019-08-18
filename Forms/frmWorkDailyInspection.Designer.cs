namespace MOBISDAS.Forms
{
    partial class frmWorkDailyInspection
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWorkDailyInspection));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnl_Barcode = new System.Windows.Forms.Panel();
            this.lblWorkValue = new System.Windows.Forms.Label();
            this.lblWorkType = new System.Windows.Forms.Label();
            this.txt_ReciveData = new System.Windows.Forms.TextBox();
            this.lbl_Bacode = new System.Windows.Forms.Label();
            this.btn_Bar_OK = new System.Windows.Forms.Button();
            this.txt_Barcode = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView_Insp = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_RouteNo = new System.Windows.Forms.Label();
            this.lbl_WC_NAME = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_OrderDate = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.tmrToolCheck = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.pnl_Barcode.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Insp)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SandyBrown;
            this.panel1.Controls.Add(this.pnl_Barcode);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(1000, 740);
            this.panel1.TabIndex = 0;
            // 
            // pnl_Barcode
            // 
            this.pnl_Barcode.BackColor = System.Drawing.SystemColors.Control;
            this.pnl_Barcode.Controls.Add(this.lblWorkValue);
            this.pnl_Barcode.Controls.Add(this.lblWorkType);
            this.pnl_Barcode.Controls.Add(this.txt_ReciveData);
            this.pnl_Barcode.Controls.Add(this.lbl_Bacode);
            this.pnl_Barcode.Controls.Add(this.btn_Bar_OK);
            this.pnl_Barcode.Controls.Add(this.txt_Barcode);
            this.pnl_Barcode.Location = new System.Drawing.Point(260, 207);
            this.pnl_Barcode.Name = "pnl_Barcode";
            this.pnl_Barcode.Size = new System.Drawing.Size(307, 145);
            this.pnl_Barcode.TabIndex = 6;
            this.pnl_Barcode.Visible = false;
            // 
            // lblWorkValue
            // 
            this.lblWorkValue.AutoSize = true;
            this.lblWorkValue.Location = new System.Drawing.Point(153, 76);
            this.lblWorkValue.Name = "lblWorkValue";
            this.lblWorkValue.Size = new System.Drawing.Size(0, 12);
            this.lblWorkValue.TabIndex = 16;
            this.lblWorkValue.TextChanged += new System.EventHandler(this.lblWorkValue_TextChanged);
            // 
            // lblWorkType
            // 
            this.lblWorkType.AutoSize = true;
            this.lblWorkType.Location = new System.Drawing.Point(15, 80);
            this.lblWorkType.Name = "lblWorkType";
            this.lblWorkType.Size = new System.Drawing.Size(0, 12);
            this.lblWorkType.TabIndex = 15;
            // 
            // txt_ReciveData
            // 
            this.txt_ReciveData.Location = new System.Drawing.Point(14, 46);
            this.txt_ReciveData.Name = "txt_ReciveData";
            this.txt_ReciveData.Size = new System.Drawing.Size(279, 21);
            this.txt_ReciveData.TabIndex = 14;
            this.txt_ReciveData.TextChanged += new System.EventHandler(this.txt_ReciveData_TextChanged);
            // 
            // lbl_Bacode
            // 
            this.lbl_Bacode.AutoSize = true;
            this.lbl_Bacode.Location = new System.Drawing.Point(12, 13);
            this.lbl_Bacode.Name = "lbl_Bacode";
            this.lbl_Bacode.Size = new System.Drawing.Size(41, 12);
            this.lbl_Bacode.TabIndex = 2;
            this.lbl_Bacode.Text = "바코드";
            // 
            // btn_Bar_OK
            // 
            this.btn_Bar_OK.Location = new System.Drawing.Point(237, 10);
            this.btn_Bar_OK.Name = "btn_Bar_OK";
            this.btn_Bar_OK.Size = new System.Drawing.Size(56, 21);
            this.btn_Bar_OK.TabIndex = 1;
            this.btn_Bar_OK.Text = "OK";
            this.btn_Bar_OK.UseVisualStyleBackColor = true;
            this.btn_Bar_OK.Click += new System.EventHandler(this.btn_Bar_OK_Click);
            // 
            // txt_Barcode
            // 
            this.txt_Barcode.Location = new System.Drawing.Point(61, 10);
            this.txt_Barcode.Name = "txt_Barcode";
            this.txt_Barcode.Size = new System.Drawing.Size(169, 21);
            this.txt_Barcode.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView_Insp, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 10);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.71429F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(980, 720);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.Location = new System.Drawing.Point(0, 682);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(980, 38);
            this.button1.TabIndex = 5;
            this.button1.Text = "닫 기";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView_Insp
            // 
            this.dataGridView_Insp.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Insp.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_Insp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Insp.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_Insp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Insp.Location = new System.Drawing.Point(1, 97);
            this.dataGridView_Insp.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.dataGridView_Insp.Name = "dataGridView_Insp";
            this.dataGridView_Insp.RowTemplate.Height = 23;
            this.dataGridView_Insp.Size = new System.Drawing.Size(979, 585);
            this.dataGridView_Insp.TabIndex = 4;
            this.dataGridView_Insp.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Insp_CellClick);
            this.dataGridView_Insp.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Insp_CellDoubleClick);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.64429F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.37808F));
            this.tableLayoutPanel2.Controls.Add(this.lbl_RouteNo, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.lbl_WC_NAME, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lbl_OrderDate, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(980, 62);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // lbl_RouteNo
            // 
            this.lbl_RouteNo.AutoSize = true;
            this.lbl_RouteNo.BackColor = System.Drawing.Color.LightSkyBlue;
            this.lbl_RouteNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_RouteNo.Font = new System.Drawing.Font("HY견고딕", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_RouteNo.Location = new System.Drawing.Point(750, 24);
            this.lbl_RouteNo.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.lbl_RouteNo.Name = "lbl_RouteNo";
            this.lbl_RouteNo.Size = new System.Drawing.Size(229, 38);
            this.lbl_RouteNo.TabIndex = 6;
            this.lbl_RouteNo.Text = "07";
            this.lbl_RouteNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_WC_NAME
            // 
            this.lbl_WC_NAME.AutoSize = true;
            this.lbl_WC_NAME.BackColor = System.Drawing.Color.White;
            this.lbl_WC_NAME.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_WC_NAME.Font = new System.Drawing.Font("HY견고딕", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_WC_NAME.Location = new System.Drawing.Point(293, 24);
            this.lbl_WC_NAME.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.lbl_WC_NAME.Name = "lbl_WC_NAME";
            this.lbl_WC_NAME.Size = new System.Drawing.Size(456, 38);
            this.lbl_WC_NAME.TabIndex = 5;
            this.lbl_WC_NAME.Text = "K1 운전석 메인 라인";
            this.lbl_WC_NAME.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.SteelBlue;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("HY견고딕", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Image = ((System.Drawing.Image)(resources.GetObject("label3.Image")));
            this.label3.Location = new System.Drawing.Point(750, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(229, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "공정 NO.";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("HY견고딕", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(292, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "일 자";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.SteelBlue;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("HY견고딕", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Image = ((System.Drawing.Image)(resources.GetObject("label2.Image")));
            this.label2.Location = new System.Drawing.Point(293, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(456, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "작업장";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_OrderDate
            // 
            this.lbl_OrderDate.AutoSize = true;
            this.lbl_OrderDate.BackColor = System.Drawing.Color.LightSkyBlue;
            this.lbl_OrderDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_OrderDate.Font = new System.Drawing.Font("HY견고딕", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_OrderDate.Location = new System.Drawing.Point(0, 24);
            this.lbl_OrderDate.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.lbl_OrderDate.Name = "lbl_OrderDate";
            this.lbl_OrderDate.Size = new System.Drawing.Size(292, 38);
            this.lbl_OrderDate.TabIndex = 4;
            this.lbl_OrderDate.Text = "20121011";
            this.lbl_OrderDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // tmrToolCheck
            // 
            this.tmrToolCheck.Enabled = true;
            this.tmrToolCheck.Interval = 500;
            this.tmrToolCheck.Tick += new System.EventHandler(this.tmrToolCheck_Tick);
            // 
            // frmWorkDailyInspection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 740);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmWorkDailyInspection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "자주검사";
            this.TransparencyKey = System.Drawing.Color.Lime;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmWorkDailyInspection_FormClosing);
            this.Shown += new System.EventHandler(this.frmWorkDailyInspection_Shown);
            this.panel1.ResumeLayout(false);
            this.pnl_Barcode.ResumeLayout(false);
            this.pnl_Barcode.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Insp)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_RouteNo;
        private System.Windows.Forms.Label lbl_WC_NAME;
        private System.Windows.Forms.Label lbl_OrderDate;
        private System.Windows.Forms.DataGridView dataGridView_Insp;
        private System.Windows.Forms.Panel pnl_Barcode;
        private System.Windows.Forms.TextBox txt_ReciveData;
        private System.Windows.Forms.Label lbl_Bacode;
        private System.Windows.Forms.Button btn_Bar_OK;
        private System.Windows.Forms.TextBox txt_Barcode;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblWorkValue;
        private System.Windows.Forms.Label lblWorkType;
        private System.Windows.Forms.Timer tmrToolCheck;
    }
}