namespace MOBISDAS.Forms
{
    partial class frmWork
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWork));
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1_RFMain = new System.Windows.Forms.Timer(this.components);
            this.timer_Sub = new System.Windows.Forms.Timer(this.components);
            this.timer_Re = new System.Windows.Forms.Timer(this.components);
            this.pnl_Virtual = new System.Windows.Forms.Panel();
            this.bnt_Virtual = new MOBISDAS.UI.itCommandButton(this.components);
            this.bnt_Original = new MOBISDAS.UI.itCommandButton(this.components);
            this.lbl_Main_Load = new System.Windows.Forms.Label();
            this.pnl_Barcode = new System.Windows.Forms.Panel();
            this.txt_ReciveData = new System.Windows.Forms.TextBox();
            this.lbl_Bacode = new System.Windows.Forms.Label();
            this.btn_Bar_OK = new System.Windows.Forms.Button();
            this.txt_Barcode = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView_Alc = new System.Windows.Forms.DataGridView();
            this.lbl_title1 = new System.Windows.Forms.Label();
            this.lbl_title2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_OrderDate_1 = new System.Windows.Forms.Label();
            this.lbl_OrderDate_2 = new System.Windows.Forms.Label();
            this.lbl_OrderDate_3 = new System.Windows.Forms.Label();
            this.lbl_OrderDate_4 = new System.Windows.Forms.Label();
            this.lbl_Cmt_1 = new System.Windows.Forms.Label();
            this.lbl_OrderDate_5 = new System.Windows.Forms.Label();
            this.lbl_Cmt_2 = new System.Windows.Forms.Label();
            this.lbl_Cmt_3 = new System.Windows.Forms.Label();
            this.lbl_Cmt_4 = new System.Windows.Forms.Label();
            this.lbl_Cmt_5 = new System.Windows.Forms.Label();
            this.lbl_Body_No_1 = new System.Windows.Forms.Label();
            this.lbl_Body_No_2 = new System.Windows.Forms.Label();
            this.lbl_Body_No_3 = new System.Windows.Forms.Label();
            this.lbl_Body_No_4 = new System.Windows.Forms.Label();
            this.lbl_Body_No_5 = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.serialPort2 = new System.IO.Ports.SerialPort(this.components);
            this.pnl_Virtual.SuspendLayout();
            this.pnl_Barcode.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Alc)).BeginInit();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // timer1_RFMain
            // 
            this.timer1_RFMain.Enabled = true;
            this.timer1_RFMain.Interval = 1000;
            this.timer1_RFMain.Tick += new System.EventHandler(this.timer1_RFMain_Tick);
            // 
            // timer_Sub
            // 
            this.timer_Sub.Interval = 10000;
            this.timer_Sub.Tick += new System.EventHandler(this.timer_Sub_Tick);
            // 
            // timer_Re
            // 
            this.timer_Re.Interval = 2000;
            this.timer_Re.Tick += new System.EventHandler(this.timer_Re_Tick);
            // 
            // pnl_Virtual
            // 
            this.pnl_Virtual.BackColor = System.Drawing.Color.SlateGray;
            this.pnl_Virtual.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnl_Virtual.Controls.Add(this.bnt_Virtual);
            this.pnl_Virtual.Controls.Add(this.bnt_Original);
            this.pnl_Virtual.Controls.Add(this.lbl_Main_Load);
            this.pnl_Virtual.Location = new System.Drawing.Point(287, 231);
            this.pnl_Virtual.Name = "pnl_Virtual";
            this.pnl_Virtual.Size = new System.Drawing.Size(430, 121);
            this.pnl_Virtual.TabIndex = 12;
            this.pnl_Virtual.Visible = false;
            // 
            // bnt_Virtual
            // 
            this.bnt_Virtual.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.bnt_Virtual.BtnShape = MOBISDAS.UI.itCommandButton.BtnShapeEnum.Rectangle;
            this.bnt_Virtual.BtnStyle = MOBISDAS.UI.itCommandButton.XPStyleEnum.Default;
            this.bnt_Virtual.Font = new System.Drawing.Font("HY견고딕", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bnt_Virtual.Location = new System.Drawing.Point(225, 47);
            this.bnt_Virtual.Name = "bnt_Virtual";
            this.bnt_Virtual.Size = new System.Drawing.Size(190, 54);
            this.bnt_Virtual.TabIndex = 5;
            this.bnt_Virtual.Text = "가  상";
            this.bnt_Virtual.UseVisualStyleBackColor = true;
            this.bnt_Virtual.Click += new System.EventHandler(this.bnt_Virtual_Click);
            // 
            // bnt_Original
            // 
            this.bnt_Original.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.bnt_Original.BtnShape = MOBISDAS.UI.itCommandButton.BtnShapeEnum.Rectangle;
            this.bnt_Original.BtnStyle = MOBISDAS.UI.itCommandButton.XPStyleEnum.Default;
            this.bnt_Original.Font = new System.Drawing.Font("HY견고딕", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bnt_Original.Location = new System.Drawing.Point(13, 47);
            this.bnt_Original.Name = "bnt_Original";
            this.bnt_Original.Size = new System.Drawing.Size(190, 54);
            this.bnt_Original.TabIndex = 4;
            this.bnt_Original.Text = "정  상";
            this.bnt_Original.UseVisualStyleBackColor = true;
            this.bnt_Original.Click += new System.EventHandler(this.bnt_Original_Click);
            // 
            // lbl_Main_Load
            // 
            this.lbl_Main_Load.AutoSize = true;
            this.lbl_Main_Load.Font = new System.Drawing.Font("HY견고딕", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_Main_Load.ForeColor = System.Drawing.Color.Yellow;
            this.lbl_Main_Load.Location = new System.Drawing.Point(89, 9);
            this.lbl_Main_Load.Name = "lbl_Main_Load";
            this.lbl_Main_Load.Size = new System.Drawing.Size(248, 24);
            this.lbl_Main_Load.TabIndex = 2;
            this.lbl_Main_Load.Text = "[가상 서열 모드 전환]";
            // 
            // pnl_Barcode
            // 
            this.pnl_Barcode.BackColor = System.Drawing.SystemColors.Control;
            this.pnl_Barcode.Controls.Add(this.txt_ReciveData);
            this.pnl_Barcode.Controls.Add(this.lbl_Bacode);
            this.pnl_Barcode.Controls.Add(this.btn_Bar_OK);
            this.pnl_Barcode.Controls.Add(this.txt_Barcode);
            this.pnl_Barcode.Location = new System.Drawing.Point(349, 271);
            this.pnl_Barcode.Name = "pnl_Barcode";
            this.pnl_Barcode.Size = new System.Drawing.Size(307, 83);
            this.pnl_Barcode.TabIndex = 5;
            this.pnl_Barcode.Visible = false;
            // 
            // txt_ReciveData
            // 
            this.txt_ReciveData.Location = new System.Drawing.Point(9, 47);
            this.txt_ReciveData.Name = "txt_ReciveData";
            this.txt_ReciveData.Size = new System.Drawing.Size(294, 21);
            this.txt_ReciveData.TabIndex = 13;
            this.txt_ReciveData.Visible = false;
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
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1004, 583);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 500F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridView_Alc, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbl_title1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbl_title2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1004, 583);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dataGridView_Alc
            // 
            this.dataGridView_Alc.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Alc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_Alc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Alc.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_Alc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Alc.Location = new System.Drawing.Point(501, 58);
            this.dataGridView_Alc.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.dataGridView_Alc.Name = "dataGridView_Alc";
            this.dataGridView_Alc.RowTemplate.Height = 23;
            this.dataGridView_Alc.Size = new System.Drawing.Size(503, 525);
            this.dataGridView_Alc.TabIndex = 3;
            // 
            // lbl_title1
            // 
            this.lbl_title1.AutoSize = true;
            this.lbl_title1.BackColor = System.Drawing.Color.Navy;
            this.lbl_title1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_title1.Font = new System.Drawing.Font("HY견고딕", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_title1.ForeColor = System.Drawing.Color.Yellow;
            this.lbl_title1.Image = ((System.Drawing.Image)(resources.GetObject("lbl_title1.Image")));
            this.lbl_title1.Location = new System.Drawing.Point(0, 0);
            this.lbl_title1.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.lbl_title1.Name = "lbl_title1";
            this.lbl_title1.Size = new System.Drawing.Size(499, 58);
            this.lbl_title1.TabIndex = 4;
            this.lbl_title1.Text = "[서열 리스트]";
            this.lbl_title1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_title1.Click += new System.EventHandler(this.lbl_title1_Click);
            // 
            // lbl_title2
            // 
            this.lbl_title2.AutoSize = true;
            this.lbl_title2.BackColor = System.Drawing.Color.Navy;
            this.lbl_title2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_title2.Font = new System.Drawing.Font("HY견고딕", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_title2.ForeColor = System.Drawing.Color.Yellow;
            this.lbl_title2.Image = ((System.Drawing.Image)(resources.GetObject("lbl_title2.Image")));
            this.lbl_title2.Location = new System.Drawing.Point(501, 0);
            this.lbl_title2.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.lbl_title2.Name = "lbl_title2";
            this.lbl_title2.Size = new System.Drawing.Size(503, 58);
            this.lbl_title2.TabIndex = 5;
            this.lbl_title2.Text = "[작업 리스트]";
            this.lbl_title2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_title2.Click += new System.EventHandler(this.lbl_title2_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.Controls.Add(this.tableLayoutPanel2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 58);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(500, 525);
            this.panel2.TabIndex = 6;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(500, 525);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel3.Controls.Add(this.lbl_OrderDate_1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.lbl_OrderDate_2, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.lbl_OrderDate_3, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.lbl_OrderDate_4, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.lbl_Cmt_1, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.lbl_OrderDate_5, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.lbl_Cmt_2, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.lbl_Cmt_3, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.lbl_Cmt_4, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.lbl_Cmt_5, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.lbl_Body_No_1, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.lbl_Body_No_2, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.lbl_Body_No_3, 2, 2);
            this.tableLayoutPanel3.Controls.Add(this.lbl_Body_No_4, 2, 3);
            this.tableLayoutPanel3.Controls.Add(this.lbl_Body_No_5, 2, 4);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 52);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 5;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(500, 473);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // lbl_OrderDate_1
            // 
            this.lbl_OrderDate_1.BackColor = System.Drawing.Color.White;
            this.lbl_OrderDate_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_OrderDate_1.Font = new System.Drawing.Font("HY견고딕", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_OrderDate_1.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_OrderDate_1.Location = new System.Drawing.Point(0, 1);
            this.lbl_OrderDate_1.Margin = new System.Windows.Forms.Padding(0, 1, 1, 1);
            this.lbl_OrderDate_1.Name = "lbl_OrderDate_1";
            this.lbl_OrderDate_1.Size = new System.Drawing.Size(99, 92);
            this.lbl_OrderDate_1.TabIndex = 4;
            this.lbl_OrderDate_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_OrderDate_2
            // 
            this.lbl_OrderDate_2.BackColor = System.Drawing.Color.White;
            this.lbl_OrderDate_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_OrderDate_2.Font = new System.Drawing.Font("HY견고딕", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_OrderDate_2.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_OrderDate_2.Location = new System.Drawing.Point(0, 95);
            this.lbl_OrderDate_2.Margin = new System.Windows.Forms.Padding(0, 1, 1, 1);
            this.lbl_OrderDate_2.Name = "lbl_OrderDate_2";
            this.lbl_OrderDate_2.Size = new System.Drawing.Size(99, 92);
            this.lbl_OrderDate_2.TabIndex = 7;
            this.lbl_OrderDate_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_OrderDate_3
            // 
            this.lbl_OrderDate_3.BackColor = System.Drawing.Color.Lime;
            this.lbl_OrderDate_3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_OrderDate_3.Font = new System.Drawing.Font("HY견고딕", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_OrderDate_3.Location = new System.Drawing.Point(0, 189);
            this.lbl_OrderDate_3.Margin = new System.Windows.Forms.Padding(0, 1, 1, 1);
            this.lbl_OrderDate_3.Name = "lbl_OrderDate_3";
            this.lbl_OrderDate_3.Size = new System.Drawing.Size(99, 92);
            this.lbl_OrderDate_3.TabIndex = 10;
            this.lbl_OrderDate_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_OrderDate_4
            // 
            this.lbl_OrderDate_4.BackColor = System.Drawing.Color.White;
            this.lbl_OrderDate_4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_OrderDate_4.Font = new System.Drawing.Font("HY견고딕", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_OrderDate_4.Location = new System.Drawing.Point(0, 283);
            this.lbl_OrderDate_4.Margin = new System.Windows.Forms.Padding(0, 1, 1, 1);
            this.lbl_OrderDate_4.Name = "lbl_OrderDate_4";
            this.lbl_OrderDate_4.Size = new System.Drawing.Size(99, 92);
            this.lbl_OrderDate_4.TabIndex = 13;
            this.lbl_OrderDate_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Cmt_1
            // 
            this.lbl_Cmt_1.BackColor = System.Drawing.Color.White;
            this.lbl_Cmt_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Cmt_1.Font = new System.Drawing.Font("HY견고딕", 23.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_Cmt_1.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_Cmt_1.Location = new System.Drawing.Point(100, 1);
            this.lbl_Cmt_1.Margin = new System.Windows.Forms.Padding(0, 1, 1, 1);
            this.lbl_Cmt_1.Name = "lbl_Cmt_1";
            this.lbl_Cmt_1.Size = new System.Drawing.Size(99, 92);
            this.lbl_Cmt_1.TabIndex = 17;
            this.lbl_Cmt_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_OrderDate_5
            // 
            this.lbl_OrderDate_5.BackColor = System.Drawing.Color.White;
            this.lbl_OrderDate_5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_OrderDate_5.Font = new System.Drawing.Font("HY견고딕", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_OrderDate_5.Location = new System.Drawing.Point(0, 377);
            this.lbl_OrderDate_5.Margin = new System.Windows.Forms.Padding(0, 1, 1, 1);
            this.lbl_OrderDate_5.Name = "lbl_OrderDate_5";
            this.lbl_OrderDate_5.Size = new System.Drawing.Size(99, 95);
            this.lbl_OrderDate_5.TabIndex = 16;
            this.lbl_OrderDate_5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Cmt_2
            // 
            this.lbl_Cmt_2.BackColor = System.Drawing.Color.White;
            this.lbl_Cmt_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Cmt_2.Font = new System.Drawing.Font("HY견고딕", 23.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_Cmt_2.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_Cmt_2.Location = new System.Drawing.Point(100, 95);
            this.lbl_Cmt_2.Margin = new System.Windows.Forms.Padding(0, 1, 1, 1);
            this.lbl_Cmt_2.Name = "lbl_Cmt_2";
            this.lbl_Cmt_2.Size = new System.Drawing.Size(99, 92);
            this.lbl_Cmt_2.TabIndex = 18;
            this.lbl_Cmt_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Cmt_3
            // 
            this.lbl_Cmt_3.BackColor = System.Drawing.Color.Lime;
            this.lbl_Cmt_3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Cmt_3.Font = new System.Drawing.Font("HY견고딕", 23.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_Cmt_3.Location = new System.Drawing.Point(100, 189);
            this.lbl_Cmt_3.Margin = new System.Windows.Forms.Padding(0, 1, 1, 1);
            this.lbl_Cmt_3.Name = "lbl_Cmt_3";
            this.lbl_Cmt_3.Size = new System.Drawing.Size(99, 92);
            this.lbl_Cmt_3.TabIndex = 19;
            this.lbl_Cmt_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Cmt_4
            // 
            this.lbl_Cmt_4.BackColor = System.Drawing.Color.White;
            this.lbl_Cmt_4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Cmt_4.Font = new System.Drawing.Font("HY견고딕", 23.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_Cmt_4.Location = new System.Drawing.Point(100, 283);
            this.lbl_Cmt_4.Margin = new System.Windows.Forms.Padding(0, 1, 1, 1);
            this.lbl_Cmt_4.Name = "lbl_Cmt_4";
            this.lbl_Cmt_4.Size = new System.Drawing.Size(99, 92);
            this.lbl_Cmt_4.TabIndex = 20;
            this.lbl_Cmt_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Cmt_5
            // 
            this.lbl_Cmt_5.BackColor = System.Drawing.Color.White;
            this.lbl_Cmt_5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Cmt_5.Font = new System.Drawing.Font("HY견고딕", 23.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_Cmt_5.Location = new System.Drawing.Point(100, 377);
            this.lbl_Cmt_5.Margin = new System.Windows.Forms.Padding(0, 1, 1, 1);
            this.lbl_Cmt_5.Name = "lbl_Cmt_5";
            this.lbl_Cmt_5.Size = new System.Drawing.Size(99, 95);
            this.lbl_Cmt_5.TabIndex = 21;
            this.lbl_Cmt_5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Body_No_1
            // 
            this.lbl_Body_No_1.BackColor = System.Drawing.Color.White;
            this.lbl_Body_No_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Body_No_1.Font = new System.Drawing.Font("HY견고딕", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_Body_No_1.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_Body_No_1.Location = new System.Drawing.Point(200, 1);
            this.lbl_Body_No_1.Margin = new System.Windows.Forms.Padding(0, 1, 1, 1);
            this.lbl_Body_No_1.Name = "lbl_Body_No_1";
            this.lbl_Body_No_1.Size = new System.Drawing.Size(299, 92);
            this.lbl_Body_No_1.TabIndex = 22;
            this.lbl_Body_No_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Body_No_2
            // 
            this.lbl_Body_No_2.BackColor = System.Drawing.Color.White;
            this.lbl_Body_No_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Body_No_2.Font = new System.Drawing.Font("HY견고딕", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_Body_No_2.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_Body_No_2.Location = new System.Drawing.Point(200, 95);
            this.lbl_Body_No_2.Margin = new System.Windows.Forms.Padding(0, 1, 1, 1);
            this.lbl_Body_No_2.Name = "lbl_Body_No_2";
            this.lbl_Body_No_2.Size = new System.Drawing.Size(299, 92);
            this.lbl_Body_No_2.TabIndex = 23;
            this.lbl_Body_No_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Body_No_3
            // 
            this.lbl_Body_No_3.BackColor = System.Drawing.Color.Lime;
            this.lbl_Body_No_3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Body_No_3.Font = new System.Drawing.Font("HY견고딕", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_Body_No_3.Location = new System.Drawing.Point(200, 189);
            this.lbl_Body_No_3.Margin = new System.Windows.Forms.Padding(0, 1, 1, 1);
            this.lbl_Body_No_3.Name = "lbl_Body_No_3";
            this.lbl_Body_No_3.Size = new System.Drawing.Size(299, 92);
            this.lbl_Body_No_3.TabIndex = 24;
            this.lbl_Body_No_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Body_No_3.DoubleClick += new System.EventHandler(this.lbl_Body_No_3_DoubleClick);
            // 
            // lbl_Body_No_4
            // 
            this.lbl_Body_No_4.BackColor = System.Drawing.Color.White;
            this.lbl_Body_No_4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Body_No_4.Font = new System.Drawing.Font("HY견고딕", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_Body_No_4.Location = new System.Drawing.Point(200, 283);
            this.lbl_Body_No_4.Margin = new System.Windows.Forms.Padding(0, 1, 1, 1);
            this.lbl_Body_No_4.Name = "lbl_Body_No_4";
            this.lbl_Body_No_4.Size = new System.Drawing.Size(299, 92);
            this.lbl_Body_No_4.TabIndex = 25;
            this.lbl_Body_No_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Body_No_5
            // 
            this.lbl_Body_No_5.BackColor = System.Drawing.Color.White;
            this.lbl_Body_No_5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Body_No_5.Font = new System.Drawing.Font("HY견고딕", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_Body_No_5.Location = new System.Drawing.Point(200, 377);
            this.lbl_Body_No_5.Margin = new System.Windows.Forms.Padding(0, 1, 1, 1);
            this.lbl_Body_No_5.Name = "lbl_Body_No_5";
            this.lbl_Body_No_5.Size = new System.Drawing.Size(299, 95);
            this.lbl_Body_No_5.TabIndex = 26;
            this.lbl_Body_No_5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel4.Controls.Add(this.label8, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.label7, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(500, 52);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.CornflowerBlue;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("HY견고딕", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(200, 0);
            this.label8.Margin = new System.Windows.Forms.Padding(0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(300, 52);
            this.label8.TabIndex = 3;
            this.label8.Text = "BODY NO";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.CornflowerBlue;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("HY견고딕", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(100, 0);
            this.label7.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 52);
            this.label7.TabIndex = 2;
            this.label7.Text = "CMT";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.CornflowerBlue;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("HY견고딕", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 52);
            this.label6.TabIndex = 1;
            this.label6.Text = "일자";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // serialPort2
            // 
            this.serialPort2.PortName = "COM2";

            // 
            // frmWork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 583);
            this.Controls.Add(this.pnl_Virtual);
            this.Controls.Add(this.pnl_Barcode);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmWork";
            this.Text = "작업지시";
            this.Load += new System.EventHandler(this.frmWork_Load);
            this.ClientSizeChanged += new System.EventHandler(this.frmWork_ClientSizeChanged);
            this.pnl_Virtual.ResumeLayout(false);
            this.pnl_Virtual.PerformLayout();
            this.pnl_Barcode.ResumeLayout(false);
            this.pnl_Barcode.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Alc)).EndInit();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView_Alc;
        private System.Windows.Forms.Label lbl_title1;
        private System.Windows.Forms.Label lbl_title2;
        private System.Windows.Forms.Panel pnl_Barcode;
        private System.Windows.Forms.Label lbl_Bacode;
        private System.Windows.Forms.Button btn_Bar_OK;
        private System.Windows.Forms.TextBox txt_Barcode;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.TextBox txt_ReciveData;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label lbl_OrderDate_1;
        private System.Windows.Forms.Label lbl_OrderDate_2;
        private System.Windows.Forms.Label lbl_OrderDate_3;
        private System.Windows.Forms.Label lbl_OrderDate_4;
        private System.Windows.Forms.Label lbl_Cmt_1;
        private System.Windows.Forms.Label lbl_OrderDate_5;
        private System.Windows.Forms.Label lbl_Cmt_2;
        private System.Windows.Forms.Label lbl_Cmt_3;
        private System.Windows.Forms.Label lbl_Cmt_4;
        private System.Windows.Forms.Label lbl_Cmt_5;
        private System.Windows.Forms.Label lbl_Body_No_1;
        private System.Windows.Forms.Label lbl_Body_No_2;
        private System.Windows.Forms.Label lbl_Body_No_3;
        private System.Windows.Forms.Label lbl_Body_No_4;
        private System.Windows.Forms.Label lbl_Body_No_5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Timer timer1_RFMain;
        private System.Windows.Forms.Timer timer_Sub;
        private System.Windows.Forms.Timer timer_Re;
        private System.Windows.Forms.Panel pnl_Virtual;
        private UI.itCommandButton bnt_Virtual;
        private UI.itCommandButton bnt_Original;
        private System.Windows.Forms.Label lbl_Main_Load;
        private System.IO.Ports.SerialPort serialPort2;
    }
}