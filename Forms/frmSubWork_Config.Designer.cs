namespace MOBISDAS.Forms
{
    partial class frmSubWork_Config
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_title = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.bnt_down_p = new MOBISDAS.UI.itCommandButton(this.components);
            this.bnt_down = new MOBISDAS.UI.itCommandButton(this.components);
            this.bnt_up = new MOBISDAS.UI.itCommandButton(this.components);
            this.bnt_up_p = new MOBISDAS.UI.itCommandButton(this.components);
            this.dataGridView_Sub = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_Revision = new MOBISDAS.UI.itCommandButton(this.components);
            this.lbl_Commit_No = new System.Windows.Forms.Label();
            this.bnt_Date_Day_Down = new MOBISDAS.UI.itCommandButton(this.components);
            this.bnt_Date_Day_Up = new MOBISDAS.UI.itCommandButton(this.components);
            this.bnt_Date_Mon_Down = new MOBISDAS.UI.itCommandButton(this.components);
            this.bnt_Date_Mon_Up = new MOBISDAS.UI.itCommandButton(this.components);
            this.bnt_Date_Year_Down = new MOBISDAS.UI.itCommandButton(this.components);
            this.bnt_Date_Year_Up = new MOBISDAS.UI.itCommandButton(this.components);
            this.lbl_Date_Day = new System.Windows.Forms.Label();
            this.lbl_Date_Mon = new System.Windows.Forms.Label();
            this.btn_Load = new MOBISDAS.UI.itCommandButton(this.components);
            this.lbl_Cmt_No = new System.Windows.Forms.Label();
            this.lbl_Date_Year = new System.Windows.Forms.Label();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Cancle = new MOBISDAS.UI.itCommandButton(this.components);
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Sub)).BeginInit();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SandyBrown;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(988, 662);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lbl_title, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 10);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(968, 642);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.BackColor = System.Drawing.SystemColors.HotTrack;
            this.lbl_title.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_title.Font = new System.Drawing.Font("HY견고딕", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_title.ForeColor = System.Drawing.Color.White;
            this.lbl_title.Location = new System.Drawing.Point(0, 0);
            this.lbl_title.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(968, 64);
            this.lbl_title.TabIndex = 0;
            this.lbl_title.Text = "SUB 작업장 작업 조정";
            this.lbl_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 64);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(968, 513);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.dataGridView_Sub, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(629, 513);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Controls.Add(this.bnt_down_p, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.bnt_down, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.bnt_up, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.bnt_up_p, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(566, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 4;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(63, 513);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // bnt_down_p
            // 
            this.bnt_down_p.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.bnt_down_p.BtnShape = MOBISDAS.UI.itCommandButton.BtnShapeEnum.Rectangle;
            this.bnt_down_p.BtnStyle = MOBISDAS.UI.itCommandButton.XPStyleEnum.OliveGreen;
            this.bnt_down_p.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bnt_down_p.Font = new System.Drawing.Font("굴림", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bnt_down_p.ForeColor = System.Drawing.Color.Gray;
            this.bnt_down_p.Location = new System.Drawing.Point(0, 384);
            this.bnt_down_p.Margin = new System.Windows.Forms.Padding(0);
            this.bnt_down_p.Name = "bnt_down_p";
            this.bnt_down_p.Size = new System.Drawing.Size(63, 129);
            this.bnt_down_p.TabIndex = 3;
            this.bnt_down_p.Text = "▼▼";
            this.bnt_down_p.UseVisualStyleBackColor = true;
            this.bnt_down_p.Click += new System.EventHandler(this.bnt_down_p_Click);
            // 
            // bnt_down
            // 
            this.bnt_down.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.bnt_down.BtnShape = MOBISDAS.UI.itCommandButton.BtnShapeEnum.Rectangle;
            this.bnt_down.BtnStyle = MOBISDAS.UI.itCommandButton.XPStyleEnum.OliveGreen;
            this.bnt_down.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bnt_down.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bnt_down.ForeColor = System.Drawing.Color.Gray;
            this.bnt_down.Location = new System.Drawing.Point(0, 256);
            this.bnt_down.Margin = new System.Windows.Forms.Padding(0);
            this.bnt_down.Name = "bnt_down";
            this.bnt_down.Size = new System.Drawing.Size(63, 128);
            this.bnt_down.TabIndex = 2;
            this.bnt_down.Text = "▼";
            this.bnt_down.UseVisualStyleBackColor = true;
            this.bnt_down.Click += new System.EventHandler(this.bnt_down_Click);
            // 
            // bnt_up
            // 
            this.bnt_up.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.bnt_up.BtnShape = MOBISDAS.UI.itCommandButton.BtnShapeEnum.Rectangle;
            this.bnt_up.BtnStyle = MOBISDAS.UI.itCommandButton.XPStyleEnum.OliveGreen;
            this.bnt_up.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bnt_up.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bnt_up.ForeColor = System.Drawing.Color.Gray;
            this.bnt_up.Location = new System.Drawing.Point(0, 128);
            this.bnt_up.Margin = new System.Windows.Forms.Padding(0);
            this.bnt_up.Name = "bnt_up";
            this.bnt_up.Size = new System.Drawing.Size(63, 128);
            this.bnt_up.TabIndex = 1;
            this.bnt_up.Text = "▲";
            this.bnt_up.UseVisualStyleBackColor = true;
            this.bnt_up.Click += new System.EventHandler(this.bnt_up_Click);
            // 
            // bnt_up_p
            // 
            this.bnt_up_p.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.bnt_up_p.BtnShape = MOBISDAS.UI.itCommandButton.BtnShapeEnum.Rectangle;
            this.bnt_up_p.BtnStyle = MOBISDAS.UI.itCommandButton.XPStyleEnum.OliveGreen;
            this.bnt_up_p.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bnt_up_p.Font = new System.Drawing.Font("굴림", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bnt_up_p.ForeColor = System.Drawing.Color.Gray;
            this.bnt_up_p.Location = new System.Drawing.Point(0, 0);
            this.bnt_up_p.Margin = new System.Windows.Forms.Padding(0);
            this.bnt_up_p.Name = "bnt_up_p";
            this.bnt_up_p.Size = new System.Drawing.Size(63, 128);
            this.bnt_up_p.TabIndex = 0;
            this.bnt_up_p.Text = "▲▲";
            this.bnt_up_p.UseVisualStyleBackColor = true;
            this.bnt_up_p.Click += new System.EventHandler(this.bnt_up_p_Click);
            // 
            // dataGridView_Sub
            // 
            this.dataGridView_Sub.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView_Sub.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Sub.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Sub.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_Sub.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridView_Sub.MultiSelect = false;
            this.dataGridView_Sub.Name = "dataGridView_Sub";
            this.dataGridView_Sub.RowTemplate.Height = 23;
            this.dataGridView_Sub.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Sub.Size = new System.Drawing.Size(566, 513);
            this.dataGridView_Sub.TabIndex = 1;
            this.dataGridView_Sub.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Sub_CellClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbl_Commit_No);
            this.panel2.Controls.Add(this.bnt_Date_Day_Down);
            this.panel2.Controls.Add(this.bnt_Date_Day_Up);
            this.panel2.Controls.Add(this.bnt_Date_Mon_Down);
            this.panel2.Controls.Add(this.bnt_Date_Mon_Up);
            this.panel2.Controls.Add(this.bnt_Date_Year_Down);
            this.panel2.Controls.Add(this.bnt_Date_Year_Up);
            this.panel2.Controls.Add(this.lbl_Date_Day);
            this.panel2.Controls.Add(this.lbl_Date_Mon);
            this.panel2.Controls.Add(this.btn_Load);
            this.panel2.Controls.Add(this.lbl_Cmt_No);
            this.panel2.Controls.Add(this.lbl_Date_Year);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(629, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(339, 513);
            this.panel2.TabIndex = 1;
            // 
            // btn_Revision
            // 
            this.btn_Revision.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.btn_Revision.BtnShape = MOBISDAS.UI.itCommandButton.BtnShapeEnum.Rectangle;
            this.btn_Revision.BtnStyle = MOBISDAS.UI.itCommandButton.XPStyleEnum.Default;
            this.btn_Revision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Revision.Font = new System.Drawing.Font("HY견고딕", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Revision.Location = new System.Drawing.Point(3, 3);
            this.btn_Revision.Name = "btn_Revision";
            this.btn_Revision.Size = new System.Drawing.Size(478, 59);
            this.btn_Revision.TabIndex = 15;
            this.btn_Revision.Text = "적   용";
            this.btn_Revision.UseVisualStyleBackColor = true;
            this.btn_Revision.Click += new System.EventHandler(this.btn_Revision_Click);
            // 
            // lbl_Commit_No
            // 
            this.lbl_Commit_No.BackColor = System.Drawing.Color.White;
            this.lbl_Commit_No.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Commit_No.Font = new System.Drawing.Font("HY견고딕", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_Commit_No.Location = new System.Drawing.Point(167, 244);
            this.lbl_Commit_No.Name = "lbl_Commit_No";
            this.lbl_Commit_No.Size = new System.Drawing.Size(158, 44);
            this.lbl_Commit_No.TabIndex = 14;
            this.lbl_Commit_No.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Commit_No.Click += new System.EventHandler(this.lbl_Commit_No_Click);
            // 
            // bnt_Date_Day_Down
            // 
            this.bnt_Date_Day_Down.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.bnt_Date_Day_Down.BtnShape = MOBISDAS.UI.itCommandButton.BtnShapeEnum.Rectangle;
            this.bnt_Date_Day_Down.BtnStyle = MOBISDAS.UI.itCommandButton.XPStyleEnum.Default;
            this.bnt_Date_Day_Down.Font = new System.Drawing.Font("굴림", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bnt_Date_Day_Down.ForeColor = System.Drawing.Color.Gray;
            this.bnt_Date_Day_Down.Location = new System.Drawing.Point(252, 139);
            this.bnt_Date_Day_Down.Name = "bnt_Date_Day_Down";
            this.bnt_Date_Day_Down.Size = new System.Drawing.Size(73, 60);
            this.bnt_Date_Day_Down.TabIndex = 13;
            this.bnt_Date_Day_Down.Text = "▼";
            this.bnt_Date_Day_Down.UseVisualStyleBackColor = true;
            this.bnt_Date_Day_Down.Click += new System.EventHandler(this.bnt_Date_Day_Down_Click);
            // 
            // bnt_Date_Day_Up
            // 
            this.bnt_Date_Day_Up.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.bnt_Date_Day_Up.BtnShape = MOBISDAS.UI.itCommandButton.BtnShapeEnum.Rectangle;
            this.bnt_Date_Day_Up.BtnStyle = MOBISDAS.UI.itCommandButton.XPStyleEnum.Default;
            this.bnt_Date_Day_Up.Font = new System.Drawing.Font("굴림", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bnt_Date_Day_Up.ForeColor = System.Drawing.Color.Gray;
            this.bnt_Date_Day_Up.Location = new System.Drawing.Point(252, 7);
            this.bnt_Date_Day_Up.Name = "bnt_Date_Day_Up";
            this.bnt_Date_Day_Up.Size = new System.Drawing.Size(73, 60);
            this.bnt_Date_Day_Up.TabIndex = 12;
            this.bnt_Date_Day_Up.Text = "▲";
            this.bnt_Date_Day_Up.UseVisualStyleBackColor = true;
            this.bnt_Date_Day_Up.Click += new System.EventHandler(this.bnt_Date_Day_Up_Click);
            // 
            // bnt_Date_Mon_Down
            // 
            this.bnt_Date_Mon_Down.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.bnt_Date_Mon_Down.BtnShape = MOBISDAS.UI.itCommandButton.BtnShapeEnum.Rectangle;
            this.bnt_Date_Mon_Down.BtnStyle = MOBISDAS.UI.itCommandButton.XPStyleEnum.Default;
            this.bnt_Date_Mon_Down.Font = new System.Drawing.Font("굴림", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bnt_Date_Mon_Down.ForeColor = System.Drawing.Color.Gray;
            this.bnt_Date_Mon_Down.Location = new System.Drawing.Point(154, 139);
            this.bnt_Date_Mon_Down.Name = "bnt_Date_Mon_Down";
            this.bnt_Date_Mon_Down.Size = new System.Drawing.Size(73, 60);
            this.bnt_Date_Mon_Down.TabIndex = 11;
            this.bnt_Date_Mon_Down.Text = "▼";
            this.bnt_Date_Mon_Down.UseVisualStyleBackColor = true;
            this.bnt_Date_Mon_Down.Click += new System.EventHandler(this.bnt_Date_Mon_Down_Click);
            // 
            // bnt_Date_Mon_Up
            // 
            this.bnt_Date_Mon_Up.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.bnt_Date_Mon_Up.BtnShape = MOBISDAS.UI.itCommandButton.BtnShapeEnum.Rectangle;
            this.bnt_Date_Mon_Up.BtnStyle = MOBISDAS.UI.itCommandButton.XPStyleEnum.Default;
            this.bnt_Date_Mon_Up.Font = new System.Drawing.Font("굴림", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bnt_Date_Mon_Up.ForeColor = System.Drawing.Color.Gray;
            this.bnt_Date_Mon_Up.Location = new System.Drawing.Point(154, 7);
            this.bnt_Date_Mon_Up.Name = "bnt_Date_Mon_Up";
            this.bnt_Date_Mon_Up.Size = new System.Drawing.Size(73, 60);
            this.bnt_Date_Mon_Up.TabIndex = 10;
            this.bnt_Date_Mon_Up.Text = "▲    ";
            this.bnt_Date_Mon_Up.UseVisualStyleBackColor = true;
            this.bnt_Date_Mon_Up.Click += new System.EventHandler(this.bnt_Date_Mon_Up_Click);
            // 
            // bnt_Date_Year_Down
            // 
            this.bnt_Date_Year_Down.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.bnt_Date_Year_Down.BtnShape = MOBISDAS.UI.itCommandButton.BtnShapeEnum.Rectangle;
            this.bnt_Date_Year_Down.BtnStyle = MOBISDAS.UI.itCommandButton.XPStyleEnum.Default;
            this.bnt_Date_Year_Down.Font = new System.Drawing.Font("굴림", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bnt_Date_Year_Down.ForeColor = System.Drawing.Color.Gray;
            this.bnt_Date_Year_Down.Location = new System.Drawing.Point(17, 139);
            this.bnt_Date_Year_Down.Name = "bnt_Date_Year_Down";
            this.bnt_Date_Year_Down.Size = new System.Drawing.Size(112, 60);
            this.bnt_Date_Year_Down.TabIndex = 9;
            this.bnt_Date_Year_Down.Text = "▼";
            this.bnt_Date_Year_Down.UseVisualStyleBackColor = true;
            this.bnt_Date_Year_Down.Click += new System.EventHandler(this.bnt_Date_Year_Down_Click);
            // 
            // bnt_Date_Year_Up
            // 
            this.bnt_Date_Year_Up.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.bnt_Date_Year_Up.BtnShape = MOBISDAS.UI.itCommandButton.BtnShapeEnum.Rectangle;
            this.bnt_Date_Year_Up.BtnStyle = MOBISDAS.UI.itCommandButton.XPStyleEnum.Default;
            this.bnt_Date_Year_Up.Font = new System.Drawing.Font("굴림", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bnt_Date_Year_Up.ForeColor = System.Drawing.Color.Gray;
            this.bnt_Date_Year_Up.Location = new System.Drawing.Point(17, 7);
            this.bnt_Date_Year_Up.Name = "bnt_Date_Year_Up";
            this.bnt_Date_Year_Up.Size = new System.Drawing.Size(112, 60);
            this.bnt_Date_Year_Up.TabIndex = 8;
            this.bnt_Date_Year_Up.Text = "▲";
            this.bnt_Date_Year_Up.UseVisualStyleBackColor = true;
            this.bnt_Date_Year_Up.Click += new System.EventHandler(this.bnt_Date_Year_Up_Click);
            // 
            // lbl_Date_Day
            // 
            this.lbl_Date_Day.BackColor = System.Drawing.Color.Khaki;
            this.lbl_Date_Day.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Date_Day.Font = new System.Drawing.Font("HY견고딕", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_Date_Day.Location = new System.Drawing.Point(252, 75);
            this.lbl_Date_Day.Name = "lbl_Date_Day";
            this.lbl_Date_Day.Size = new System.Drawing.Size(73, 54);
            this.lbl_Date_Day.TabIndex = 7;
            this.lbl_Date_Day.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Date_Day.Click += new System.EventHandler(this.lbl_Date_Day_Click);
            // 
            // lbl_Date_Mon
            // 
            this.lbl_Date_Mon.BackColor = System.Drawing.Color.Khaki;
            this.lbl_Date_Mon.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Date_Mon.Font = new System.Drawing.Font("HY견고딕", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_Date_Mon.Location = new System.Drawing.Point(154, 75);
            this.lbl_Date_Mon.Name = "lbl_Date_Mon";
            this.lbl_Date_Mon.Size = new System.Drawing.Size(73, 54);
            this.lbl_Date_Mon.TabIndex = 6;
            this.lbl_Date_Mon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Date_Mon.Click += new System.EventHandler(this.lbl_Date_Mon_Click);
            // 
            // btn_Load
            // 
            this.btn_Load.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.btn_Load.BtnShape = MOBISDAS.UI.itCommandButton.BtnShapeEnum.Rectangle;
            this.btn_Load.BtnStyle = MOBISDAS.UI.itCommandButton.XPStyleEnum.Default;
            this.btn_Load.Font = new System.Drawing.Font("HY견고딕", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Load.Location = new System.Drawing.Point(19, 336);
            this.btn_Load.Name = "btn_Load";
            this.btn_Load.Size = new System.Drawing.Size(306, 60);
            this.btn_Load.TabIndex = 5;
            this.btn_Load.Text = "조   회";
            this.btn_Load.UseVisualStyleBackColor = true;
            this.btn_Load.Click += new System.EventHandler(this.btn_Load_Click);
            // 
            // lbl_Cmt_No
            // 
            this.lbl_Cmt_No.BackColor = System.Drawing.Color.SlateGray;
            this.lbl_Cmt_No.Font = new System.Drawing.Font("HY견고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_Cmt_No.ForeColor = System.Drawing.Color.Black;
            this.lbl_Cmt_No.Location = new System.Drawing.Point(19, 244);
            this.lbl_Cmt_No.Name = "lbl_Cmt_No";
            this.lbl_Cmt_No.Size = new System.Drawing.Size(142, 45);
            this.lbl_Cmt_No.TabIndex = 3;
            this.lbl_Cmt_No.Text = "COMMIT NO";
            this.lbl_Cmt_No.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Date_Year
            // 
            this.lbl_Date_Year.BackColor = System.Drawing.Color.Khaki;
            this.lbl_Date_Year.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Date_Year.Font = new System.Drawing.Font("HY견고딕", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_Date_Year.Location = new System.Drawing.Point(17, 75);
            this.lbl_Date_Year.Name = "lbl_Date_Year";
            this.lbl_Date_Year.Size = new System.Drawing.Size(113, 54);
            this.lbl_Date_Year.TabIndex = 1;
            this.lbl_Date_Year.Text = "2012";
            this.lbl_Date_Year.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Date_Year.Click += new System.EventHandler(this.lbl_Date_Year_Click);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.btn_Revision, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.btn_Cancle, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 577);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(968, 65);
            this.tableLayoutPanel5.TabIndex = 2;
            // 
            // btn_Cancle
            // 
            this.btn_Cancle.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.btn_Cancle.BackColor = System.Drawing.Color.Aqua;
            this.btn_Cancle.BtnShape = MOBISDAS.UI.itCommandButton.BtnShapeEnum.Rectangle;
            this.btn_Cancle.BtnStyle = MOBISDAS.UI.itCommandButton.XPStyleEnum.Default;
            this.btn_Cancle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Cancle.Font = new System.Drawing.Font("HY견고딕", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Cancle.Location = new System.Drawing.Point(487, 3);
            this.btn_Cancle.Name = "btn_Cancle";
            this.btn_Cancle.Size = new System.Drawing.Size(478, 59);
            this.btn_Cancle.TabIndex = 4;
            this.btn_Cancle.Text = "닫   기";
            this.btn_Cancle.UseVisualStyleBackColor = false;
            this.btn_Cancle.Click += new System.EventHandler(this.btn_Cancle_Click_1);
            // 
            // frmSubWork_Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 662);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSubWork_Config";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "서열조정";
            this.Shown += new System.EventHandler(this.frmSubWork_Config_Shown);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Sub)).EndInit();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.DataGridView dataGridView_Sub;
        private UI.itCommandButton bnt_down_p;
        private UI.itCommandButton bnt_down;
        private UI.itCommandButton bnt_up;
        private UI.itCommandButton bnt_up_p;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_Date_Year;
        private System.Windows.Forms.Label lbl_Cmt_No;
        private UI.itCommandButton btn_Load;
        private System.Windows.Forms.Label lbl_Date_Mon;
        private System.Windows.Forms.Label lbl_Date_Day;
        private UI.itCommandButton bnt_Date_Year_Down;
        private UI.itCommandButton bnt_Date_Year_Up;
        private UI.itCommandButton bnt_Date_Mon_Up;
        private UI.itCommandButton bnt_Date_Mon_Down;
        private UI.itCommandButton bnt_Date_Day_Up;
        private UI.itCommandButton bnt_Date_Day_Down;
        private System.Windows.Forms.Label lbl_Commit_No;
        private UI.itCommandButton btn_Revision;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private UI.itCommandButton btn_Cancle;
    }
}