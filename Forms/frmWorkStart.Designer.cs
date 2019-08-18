namespace MOBISDAS.Forms
{
    partial class frmWorkStart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWorkStart));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_Alc = new System.Windows.Forms.Label();
            this.lbl_BodyNo = new System.Windows.Forms.Label();
            this.lbl_Commit = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_OrderDate = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView_Alc = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnl_Barcode = new System.Windows.Forms.Panel();
            this.txt_ReciveData = new System.Windows.Forms.TextBox();
            this.lbl_Bacode = new System.Windows.Forms.Label();
            this.btn_Bar_OK = new System.Windows.Forms.Button();
            this.txt_Barcode = new System.Windows.Forms.TextBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.pnl_Main_Load = new System.Windows.Forms.Panel();
            this.bnt_main = new MOBISDAS.UI.itCommandButton(this.components);
            this.lbl_Main_Load = new System.Windows.Forms.Label();
            this.timer_mpis = new System.Windows.Forms.Timer(this.components);
            this.serialPort2 = new System.IO.Ports.SerialPort(this.components);
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Alc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnl_Barcode.SuspendLayout();
            this.pnl_Main_Load.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(914, 583);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(914, 583);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.Controls.Add(this.lbl_Alc, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.lbl_BodyNo, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.lbl_Commit, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label4, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lbl_OrderDate, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(914, 87);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // lbl_Alc
            // 
            this.lbl_Alc.AutoSize = true;
            this.lbl_Alc.BackColor = System.Drawing.Color.White;
            this.lbl_Alc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Alc.Font = new System.Drawing.Font("HY견고딕", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_Alc.Location = new System.Drawing.Point(775, 34);
            this.lbl_Alc.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.lbl_Alc.Name = "lbl_Alc";
            this.lbl_Alc.Size = new System.Drawing.Size(138, 53);
            this.lbl_Alc.TabIndex = 7;
            this.lbl_Alc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_BodyNo
            // 
            this.lbl_BodyNo.AutoSize = true;
            this.lbl_BodyNo.BackColor = System.Drawing.Color.LightSkyBlue;
            this.lbl_BodyNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_BodyNo.Font = new System.Drawing.Font("HY견고딕", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_BodyNo.Location = new System.Drawing.Point(456, 34);
            this.lbl_BodyNo.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.lbl_BodyNo.Name = "lbl_BodyNo";
            this.lbl_BodyNo.Size = new System.Drawing.Size(318, 53);
            this.lbl_BodyNo.TabIndex = 6;
            this.lbl_BodyNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_BodyNo.Click += new System.EventHandler(this.lbl_BodyNo_Click);
            // 
            // lbl_Commit
            // 
            this.lbl_Commit.AutoSize = true;
            this.lbl_Commit.BackColor = System.Drawing.Color.White;
            this.lbl_Commit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Commit.Font = new System.Drawing.Font("HY견고딕", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_Commit.Location = new System.Drawing.Point(274, 34);
            this.lbl_Commit.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.lbl_Commit.Name = "lbl_Commit";
            this.lbl_Commit.Size = new System.Drawing.Size(181, 53);
            this.lbl_Commit.TabIndex = 5;
            this.lbl_Commit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.SteelBlue;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("HY견고딕", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Image = ((System.Drawing.Image)(resources.GetObject("label4.Image")));
            this.label4.Location = new System.Drawing.Point(775, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 34);
            this.label4.TabIndex = 3;
            this.label4.Text = "ALC";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.SteelBlue;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("HY견고딕", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Image = ((System.Drawing.Image)(resources.GetObject("label3.Image")));
            this.label3.Location = new System.Drawing.Point(456, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(318, 34);
            this.label3.TabIndex = 2;
            this.label3.Text = "BODY NO.";
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
            this.label1.Size = new System.Drawing.Size(273, 34);
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
            this.label2.Location = new System.Drawing.Point(274, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 34);
            this.label2.TabIndex = 1;
            this.label2.Text = "커밋번호";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_OrderDate
            // 
            this.lbl_OrderDate.AutoSize = true;
            this.lbl_OrderDate.BackColor = System.Drawing.Color.LightSkyBlue;
            this.lbl_OrderDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_OrderDate.Font = new System.Drawing.Font("HY견고딕", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_OrderDate.Location = new System.Drawing.Point(0, 34);
            this.lbl_OrderDate.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.lbl_OrderDate.Name = "lbl_OrderDate";
            this.lbl_OrderDate.Size = new System.Drawing.Size(273, 53);
            this.lbl_OrderDate.TabIndex = 4;
            this.lbl_OrderDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_OrderDate.Click += new System.EventHandler(this.lbl_OrderDate_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.dataGridView_Alc, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 87);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 496F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(914, 496);
            this.tableLayoutPanel3.TabIndex = 4;
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
            this.dataGridView_Alc.Location = new System.Drawing.Point(458, 0);
            this.dataGridView_Alc.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.dataGridView_Alc.Name = "dataGridView_Alc";
            this.dataGridView_Alc.RowTemplate.Height = 23;
            this.dataGridView_Alc.Size = new System.Drawing.Size(456, 496);
            this.dataGridView_Alc.TabIndex = 2;
            this.dataGridView_Alc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Alc_CellClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 1);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(457, 495);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
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
            this.pnl_Barcode.Size = new System.Drawing.Size(307, 82);
            this.pnl_Barcode.TabIndex = 5;
            this.pnl_Barcode.Visible = false;
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
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // pnl_Main_Load
            // 
            this.pnl_Main_Load.BackColor = System.Drawing.Color.SlateGray;
            this.pnl_Main_Load.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnl_Main_Load.Controls.Add(this.bnt_main);
            this.pnl_Main_Load.Controls.Add(this.lbl_Main_Load);
            this.pnl_Main_Load.Location = new System.Drawing.Point(356, 231);
            this.pnl_Main_Load.Name = "pnl_Main_Load";
            this.pnl_Main_Load.Size = new System.Drawing.Size(293, 121);
            this.pnl_Main_Load.TabIndex = 8;
            this.pnl_Main_Load.Visible = false;
            // 
            // bnt_main
            // 
            this.bnt_main.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.bnt_main.BtnShape = MOBISDAS.UI.itCommandButton.BtnShapeEnum.Rectangle;
            this.bnt_main.BtnStyle = MOBISDAS.UI.itCommandButton.XPStyleEnum.Default;
            this.bnt_main.Font = new System.Drawing.Font("HY견고딕", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bnt_main.Location = new System.Drawing.Point(38, 47);
            this.bnt_main.Name = "bnt_main";
            this.bnt_main.Size = new System.Drawing.Size(215, 54);
            this.bnt_main.TabIndex = 4;
            this.bnt_main.Text = "메 인";
            this.bnt_main.UseVisualStyleBackColor = true;
            this.bnt_main.Click += new System.EventHandler(this.bnt_main_Click);
            // 
            // lbl_Main_Load
            // 
            this.lbl_Main_Load.AutoSize = true;
            this.lbl_Main_Load.Font = new System.Drawing.Font("HY견고딕", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_Main_Load.ForeColor = System.Drawing.Color.Yellow;
            this.lbl_Main_Load.Location = new System.Drawing.Point(81, 9);
            this.lbl_Main_Load.Name = "lbl_Main_Load";
            this.lbl_Main_Load.Size = new System.Drawing.Size(136, 24);
            this.lbl_Main_Load.TabIndex = 2;
            this.lbl_Main_Load.Text = "[기능 버튼]";
            // 
            // timer_mpis
            // 
            this.timer_mpis.Enabled = true;
            this.timer_mpis.Interval = 500;
            this.timer_mpis.Tick += new System.EventHandler(this.timer_mpis_Tick);
            // 
            // serialPort2
            // 
            this.serialPort2.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort2_DataReceived);
            // 
            // frmWorkStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 583);
            this.Controls.Add(this.pnl_Barcode);
            this.Controls.Add(this.pnl_Main_Load);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmWorkStart";
            this.Text = "작업";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmWorkStart_FormClosing);
            this.Load += new System.EventHandler(this.frmWorkStart_Load);
            this.ClientSizeChanged += new System.EventHandler(this.frmWorkStart_ClientSizeChanged);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Alc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnl_Barcode.ResumeLayout(false);
            this.pnl_Barcode.PerformLayout();
            this.pnl_Main_Load.ResumeLayout(false);
            this.pnl_Main_Load.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lbl_Alc;
        private System.Windows.Forms.Label lbl_BodyNo;
        private System.Windows.Forms.Label lbl_Commit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_OrderDate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dataGridView_Alc;
        private System.Windows.Forms.Panel pnl_Barcode;
        private System.Windows.Forms.Label lbl_Bacode;
        private System.Windows.Forms.Button btn_Bar_OK;
        private System.Windows.Forms.TextBox txt_Barcode;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.TextBox txt_ReciveData;
        private System.Windows.Forms.Panel pnl_Main_Load;
        private UI.itCommandButton bnt_main;
        private System.Windows.Forms.Label lbl_Main_Load;
        private System.Windows.Forms.Timer timer_mpis;
        private System.IO.Ports.SerialPort serialPort2;
    }
}