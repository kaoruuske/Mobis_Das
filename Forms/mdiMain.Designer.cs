namespace MOBISDAS
{
    partial class mdiMain
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mdiMain));
            this.lbl_Main_Load = new System.Windows.Forms.Label();
            this.tslDBconnStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.DB = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer_Check = new System.Windows.Forms.Timer(this.components);
            this.lbl_Route_No = new System.Windows.Forms.Label();
            this.lbl_Day = new System.Windows.Forms.Label();
            this.lbl_Time = new System.Windows.Forms.Label();
            this.lbl_DB = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_PLC_Ok = new System.Windows.Forms.Label();
            this.lbl_PLC_End = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_End = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pnl_Wait_Cnt = new System.Windows.Forms.Panel();
            this.lbl_Wait_Cnt = new System.Windows.Forms.Label();
            this.lbl_Wait_Cnt_Title = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_TagServer = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_WireTQR = new MOBISDAS.UI.itCommandButton(this.components);
            this.btn_workboard = new MOBISDAS.UI.itCommandButton(this.components);
            this.btn_Daily_Insp = new MOBISDAS.UI.itCommandButton(this.components);
            this.lbl_Skid = new System.Windows.Forms.Label();
            this.pnl_Main_Load = new System.Windows.Forms.Panel();
            this.bnt_Wait_Cnt = new MOBISDAS.UI.itCommandButton(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.bnt_Close = new MOBISDAS.UI.itCommandButton(this.components);
            this.pnlChild = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.timer_dayInsp = new System.Windows.Forms.Timer(this.components);
            this.pnl_Wait_Cnt.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnl_Main_Load.SuspendLayout();
            this.pnlChild.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_Main_Load
            // 
            this.lbl_Main_Load.AutoSize = true;
            this.lbl_Main_Load.Font = new System.Drawing.Font("HY견고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_Main_Load.ForeColor = System.Drawing.Color.Yellow;
            this.lbl_Main_Load.Location = new System.Drawing.Point(92, 1);
            this.lbl_Main_Load.Name = "lbl_Main_Load";
            this.lbl_Main_Load.Size = new System.Drawing.Size(98, 21);
            this.lbl_Main_Load.TabIndex = 2;
            this.lbl_Main_Load.Text = "[기능 버튼]";
            // 
            // tslDBconnStatus
            // 
            this.tslDBconnStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tslDBconnStatus.Image = ((System.Drawing.Image)(resources.GetObject("tslDBconnStatus.Image")));
            this.tslDBconnStatus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tslDBconnStatus.Name = "tslDBconnStatus";
            this.tslDBconnStatus.Size = new System.Drawing.Size(43, 20);
            this.tslDBconnStatus.Text = "DB";
            this.tslDBconnStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tslDBconnStatus.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // DB
            // 
            this.DB.Image = ((System.Drawing.Image)(resources.GetObject("DB.Image")));
            this.DB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DB.Name = "DB";
            this.DB.Size = new System.Drawing.Size(39, 17);
            this.DB.Text = "DB";
            this.DB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timer_Check
            // 
            this.timer_Check.Enabled = true;
            this.timer_Check.Tick += new System.EventHandler(this.timer_Check_Tick);
            // 
            // lbl_Route_No
            // 
            this.lbl_Route_No.AutoSize = true;
            this.lbl_Route_No.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Route_No.Font = new System.Drawing.Font("HY헤드라인M", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_Route_No.ForeColor = System.Drawing.Color.Goldenrod;
            this.lbl_Route_No.Location = new System.Drawing.Point(199, 18);
            this.lbl_Route_No.Name = "lbl_Route_No";
            this.lbl_Route_No.Size = new System.Drawing.Size(212, 35);
            this.lbl_Route_No.TabIndex = 0;
            this.lbl_Route_No.Text = "[ CPM1-04 ]";
            this.lbl_Route_No.Click += new System.EventHandler(this.bnt_Wait_Cnt_Click);
            // 
            // lbl_Day
            // 
            this.lbl_Day.AutoSize = true;
            this.lbl_Day.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Day.Font = new System.Drawing.Font("HY견고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_Day.ForeColor = System.Drawing.Color.White;
            this.lbl_Day.Location = new System.Drawing.Point(853, 12);
            this.lbl_Day.Name = "lbl_Day";
            this.lbl_Day.Size = new System.Drawing.Size(152, 21);
            this.lbl_Day.TabIndex = 1;
            this.lbl_Day.Text = "2012-11-27";
            this.lbl_Day.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_Time
            // 
            this.lbl_Time.AutoSize = true;
            this.lbl_Time.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Time.Font = new System.Drawing.Font("HY견고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_Time.ForeColor = System.Drawing.Color.White;
            this.lbl_Time.Location = new System.Drawing.Point(883, 41);
            this.lbl_Time.Name = "lbl_Time";
            this.lbl_Time.Size = new System.Drawing.Size(112, 21);
            this.lbl_Time.TabIndex = 2;
            this.lbl_Time.Text = "00:00:00";
            this.lbl_Time.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_DB
            // 
            this.lbl_DB.BackColor = System.Drawing.Color.GreenYellow;
            this.lbl_DB.Location = new System.Drawing.Point(527, 21);
            this.lbl_DB.Name = "lbl_DB";
            this.lbl_DB.Size = new System.Drawing.Size(22, 10);
            this.lbl_DB.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("HY견고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(558, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "DB 연결상태";
            // 
            // lbl_PLC_Ok
            // 
            this.lbl_PLC_Ok.BackColor = System.Drawing.Color.GreenYellow;
            this.lbl_PLC_Ok.Location = new System.Drawing.Point(700, 21);
            this.lbl_PLC_Ok.Name = "lbl_PLC_Ok";
            this.lbl_PLC_Ok.Size = new System.Drawing.Size(22, 10);
            this.lbl_PLC_Ok.TabIndex = 5;
            // 
            // lbl_PLC_End
            // 
            this.lbl_PLC_End.BackColor = System.Drawing.Color.GreenYellow;
            this.lbl_PLC_End.Location = new System.Drawing.Point(700, 51);
            this.lbl_PLC_End.Name = "lbl_PLC_End";
            this.lbl_PLC_End.Size = new System.Drawing.Size(22, 10);
            this.lbl_PLC_End.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("HY견고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(730, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "PLC OK 상태";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("HY견고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(730, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "PLC 작업완료 상태";
            // 
            // lbl_End
            // 
            this.lbl_End.BackColor = System.Drawing.Color.GreenYellow;
            this.lbl_End.Location = new System.Drawing.Point(527, 51);
            this.lbl_End.Name = "lbl_End";
            this.lbl_End.Size = new System.Drawing.Size(22, 10);
            this.lbl_End.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("HY견고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(557, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "전산 작업완료 상태";
            // 
            // pnl_Wait_Cnt
            // 
            this.pnl_Wait_Cnt.BackColor = System.Drawing.Color.Transparent;
            this.pnl_Wait_Cnt.Controls.Add(this.lbl_Wait_Cnt);
            this.pnl_Wait_Cnt.Controls.Add(this.lbl_Wait_Cnt_Title);
            this.pnl_Wait_Cnt.Location = new System.Drawing.Point(14, 3);
            this.pnl_Wait_Cnt.Name = "pnl_Wait_Cnt";
            this.pnl_Wait_Cnt.Size = new System.Drawing.Size(171, 27);
            this.pnl_Wait_Cnt.TabIndex = 13;
            this.pnl_Wait_Cnt.Click += new System.EventHandler(this.bnt_Wait_Cnt_Click);
            // 
            // lbl_Wait_Cnt
            // 
            this.lbl_Wait_Cnt.AutoSize = true;
            this.lbl_Wait_Cnt.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Wait_Cnt.Font = new System.Drawing.Font("HY헤드라인M", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_Wait_Cnt.ForeColor = System.Drawing.Color.Goldenrod;
            this.lbl_Wait_Cnt.Location = new System.Drawing.Point(107, 4);
            this.lbl_Wait_Cnt.Name = "lbl_Wait_Cnt";
            this.lbl_Wait_Cnt.Size = new System.Drawing.Size(31, 19);
            this.lbl_Wait_Cnt.TabIndex = 12;
            this.lbl_Wait_Cnt.Text = "80";
            this.lbl_Wait_Cnt.Click += new System.EventHandler(this.bnt_Wait_Cnt_Click);
            // 
            // lbl_Wait_Cnt_Title
            // 
            this.lbl_Wait_Cnt_Title.AutoSize = true;
            this.lbl_Wait_Cnt_Title.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Wait_Cnt_Title.Font = new System.Drawing.Font("HY헤드라인M", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_Wait_Cnt_Title.ForeColor = System.Drawing.Color.Goldenrod;
            this.lbl_Wait_Cnt_Title.Location = new System.Drawing.Point(16, 4);
            this.lbl_Wait_Cnt_Title.Name = "lbl_Wait_Cnt_Title";
            this.lbl_Wait_Cnt_Title.Size = new System.Drawing.Size(47, 19);
            this.lbl_Wait_Cnt_Title.TabIndex = 11;
            this.lbl_Wait_Cnt_Title.Text = "대기";
            this.lbl_Wait_Cnt_Title.Click += new System.EventHandler(this.bnt_Wait_Cnt_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("HY견고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(450, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 11);
            this.label5.TabIndex = 14;
            this.label5.Text = "TagServer";
            // 
            // lbl_TagServer
            // 
            this.lbl_TagServer.BackColor = System.Drawing.Color.GreenYellow;
            this.lbl_TagServer.Location = new System.Drawing.Point(424, 51);
            this.lbl_TagServer.Name = "lbl_TagServer";
            this.lbl_TagServer.Size = new System.Drawing.Size(22, 10);
            this.lbl_TagServer.TabIndex = 15;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Controls.Add(this.pnl_Wait_Cnt);
            this.panel1.Controls.Add(this.btn_WireTQR);
            this.panel1.Controls.Add(this.btn_workboard);
            this.panel1.Controls.Add(this.btn_Daily_Insp);
            this.panel1.Controls.Add(this.lbl_Skid);
            this.panel1.Controls.Add(this.lbl_TagServer);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lbl_End);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lbl_PLC_End);
            this.panel1.Controls.Add(this.lbl_PLC_Ok);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lbl_DB);
            this.panel1.Controls.Add(this.lbl_Time);
            this.panel1.Controls.Add(this.lbl_Day);
            this.panel1.Controls.Add(this.lbl_Route_No);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1008, 73);
            this.panel1.TabIndex = 0;
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
            // 
            // btn_WireTQR
            // 
            this.btn_WireTQR.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.btn_WireTQR.BtnShape = MOBISDAS.UI.itCommandButton.BtnShapeEnum.Rectangle;
            this.btn_WireTQR.BtnStyle = MOBISDAS.UI.itCommandButton.XPStyleEnum.Default;
            this.btn_WireTQR.Font = new System.Drawing.Font("HY견고딕", 11F);
            this.btn_WireTQR.Location = new System.Drawing.Point(134, 30);
            this.btn_WireTQR.Name = "btn_WireTQR";
            this.btn_WireTQR.Size = new System.Drawing.Size(51, 39);
            this.btn_WireTQR.TabIndex = 22;
            this.btn_WireTQR.Text = "토크";
            this.btn_WireTQR.UseVisualStyleBackColor = true;
            this.btn_WireTQR.Click += new System.EventHandler(this.itCommandButton1_Click);
            // 
            // btn_workboard
            // 
            this.btn_workboard.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.btn_workboard.BtnShape = MOBISDAS.UI.itCommandButton.BtnShapeEnum.Rectangle;
            this.btn_workboard.BtnStyle = MOBISDAS.UI.itCommandButton.XPStyleEnum.Default;
            this.btn_workboard.Font = new System.Drawing.Font("HY견고딕", 11F);
            this.btn_workboard.Location = new System.Drawing.Point(77, 30);
            this.btn_workboard.Name = "btn_workboard";
            this.btn_workboard.Size = new System.Drawing.Size(51, 39);
            this.btn_workboard.TabIndex = 21;
            this.btn_workboard.Text = "표준서";
            this.btn_workboard.UseVisualStyleBackColor = true;
            this.btn_workboard.Click += new System.EventHandler(this.btn_workboard_Click);
            // 
            // btn_Daily_Insp
            // 
            this.btn_Daily_Insp.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.btn_Daily_Insp.BtnShape = MOBISDAS.UI.itCommandButton.BtnShapeEnum.Rectangle;
            this.btn_Daily_Insp.BtnStyle = MOBISDAS.UI.itCommandButton.XPStyleEnum.Default;
            this.btn_Daily_Insp.Font = new System.Drawing.Font("HY견고딕", 11F);
            this.btn_Daily_Insp.Location = new System.Drawing.Point(20, 30);
            this.btn_Daily_Insp.Name = "btn_Daily_Insp";
            this.btn_Daily_Insp.Size = new System.Drawing.Size(51, 39);
            this.btn_Daily_Insp.TabIndex = 19;
            this.btn_Daily_Insp.Text = "일일\r\n점검";
            this.btn_Daily_Insp.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Daily_Insp.UseVisualStyleBackColor = true;
            this.btn_Daily_Insp.Click += new System.EventHandler(this.btn_Daily_Insp_Click);
            // 
            // lbl_Skid
            // 
            this.lbl_Skid.AutoSize = true;
            this.lbl_Skid.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Skid.Font = new System.Drawing.Font("HY견고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_Skid.ForeColor = System.Drawing.Color.White;
            this.lbl_Skid.Location = new System.Drawing.Point(424, 20);
            this.lbl_Skid.Name = "lbl_Skid";
            this.lbl_Skid.Size = new System.Drawing.Size(99, 16);
            this.lbl_Skid.TabIndex = 18;
            this.lbl_Skid.Text = "스키드 상태";
            // 
            // pnl_Main_Load
            // 
            this.pnl_Main_Load.BackColor = System.Drawing.Color.SlateGray;
            this.pnl_Main_Load.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnl_Main_Load.Controls.Add(this.bnt_Wait_Cnt);
            this.pnl_Main_Load.Controls.Add(this.label6);
            this.pnl_Main_Load.Controls.Add(this.bnt_Close);
            this.pnl_Main_Load.Location = new System.Drawing.Point(725, 59);
            this.pnl_Main_Load.Name = "pnl_Main_Load";
            this.pnl_Main_Load.Size = new System.Drawing.Size(280, 72);
            this.pnl_Main_Load.TabIndex = 16;
            this.pnl_Main_Load.Visible = false;
            // 
            // bnt_Wait_Cnt
            // 
            this.bnt_Wait_Cnt.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.bnt_Wait_Cnt.BtnShape = MOBISDAS.UI.itCommandButton.BtnShapeEnum.Rectangle;
            this.bnt_Wait_Cnt.BtnStyle = MOBISDAS.UI.itCommandButton.XPStyleEnum.Default;
            this.bnt_Wait_Cnt.Font = new System.Drawing.Font("HY견고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bnt_Wait_Cnt.Location = new System.Drawing.Point(156, 24);
            this.bnt_Wait_Cnt.Name = "bnt_Wait_Cnt";
            this.bnt_Wait_Cnt.Size = new System.Drawing.Size(113, 39);
            this.bnt_Wait_Cnt.TabIndex = 3;
            this.bnt_Wait_Cnt.Text = "대기수량";
            this.bnt_Wait_Cnt.UseVisualStyleBackColor = true;
            this.bnt_Wait_Cnt.Click += new System.EventHandler(this.bnt_Wait_Cnt_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("HY견고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.ForeColor = System.Drawing.Color.Yellow;
            this.label6.Location = new System.Drawing.Point(92, 1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 19);
            this.label6.TabIndex = 2;
            this.label6.Text = "[기능 버튼]";
            // 
            // bnt_Close
            // 
            this.bnt_Close.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.bnt_Close.BtnShape = MOBISDAS.UI.itCommandButton.BtnShapeEnum.Rectangle;
            this.bnt_Close.BtnStyle = MOBISDAS.UI.itCommandButton.XPStyleEnum.Default;
            this.bnt_Close.Font = new System.Drawing.Font("HY견고딕", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bnt_Close.Location = new System.Drawing.Point(10, 24);
            this.bnt_Close.Name = "bnt_Close";
            this.bnt_Close.Size = new System.Drawing.Size(113, 39);
            this.bnt_Close.TabIndex = 1;
            this.bnt_Close.Text = "종 료";
            this.bnt_Close.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bnt_Close.UseVisualStyleBackColor = true;
            this.bnt_Close.Click += new System.EventHandler(this.bnt_Close_Click);
            // 
            // pnlChild
            // 
            this.pnlChild.BackColor = System.Drawing.Color.White;
            this.pnlChild.Controls.Add(this.pnl_Main_Load);
            this.pnlChild.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChild.Location = new System.Drawing.Point(0, 73);
            this.pnlChild.Margin = new System.Windows.Forms.Padding(0);
            this.pnlChild.Name = "pnlChild";
            this.pnlChild.Size = new System.Drawing.Size(1008, 657);
            this.pnlChild.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlChild, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1008, 730);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // timer_dayInsp
            // 
            this.timer_dayInsp.Enabled = true;
            this.timer_dayInsp.Interval = 50000;
            this.timer_dayInsp.Tick += new System.EventHandler(this.timer_dayInsp_Tick);
            // 
            // mdiMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "mdiMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "공정 프로그램 Ver.2018.10.26";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mdiMain_FormClosing);
            this.Load += new System.EventHandler(this.mdiMain_Load);
            this.pnl_Wait_Cnt.ResumeLayout(false);
            this.pnl_Wait_Cnt.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnl_Main_Load.ResumeLayout(false);
            this.pnl_Main_Load.PerformLayout();
            this.pnlChild.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripStatusLabel tslDBconnStatus;
        private System.Windows.Forms.ToolStripStatusLabel DB;
        private System.Windows.Forms.Label lbl_Main_Load;
        private System.Windows.Forms.Timer timer_Check;
        private System.Windows.Forms.Label lbl_Route_No;
        private System.Windows.Forms.Label lbl_Day;
        private System.Windows.Forms.Label lbl_Time;
        private System.Windows.Forms.Label lbl_DB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_PLC_Ok;
        private System.Windows.Forms.Label lbl_PLC_End;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_End;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnl_Wait_Cnt;
        private System.Windows.Forms.Label lbl_Wait_Cnt;
        private System.Windows.Forms.Label lbl_Wait_Cnt_Title;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_TagServer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlChild;
        private System.Windows.Forms.Panel pnl_Main_Load;
        private UI.itCommandButton bnt_Wait_Cnt;
        private System.Windows.Forms.Label label6;
        private UI.itCommandButton bnt_Close;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbl_Skid;
        private UI.itCommandButton btn_Daily_Insp;
        private System.Windows.Forms.Timer timer_dayInsp;
        private UI.itCommandButton btn_WireTQR;
        private UI.itCommandButton btn_workboard;
    }
}

