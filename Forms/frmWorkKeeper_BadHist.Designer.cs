namespace MOBISDAS.Forms
{
    partial class frmWorkKeeper_BadHist
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWorkKeeper_BadHist));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView_BadHist = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_BodyNo = new System.Windows.Forms.Label();
            this.lbl_Commit = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_OrderDate = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnPrev = new MOBISDAS.UI.itCommandButton(this.components);
            this.btnNext = new MOBISDAS.UI.itCommandButton(this.components);
            this.btnDel = new MOBISDAS.UI.itCommandButton(this.components);
            this.itCommandButton4 = new MOBISDAS.UI.itCommandButton(this.components);
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_BadHist)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(914, 630);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridView_BadHist, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 10);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(894, 610);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dataGridView_BadHist
            // 
            this.dataGridView_BadHist.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_BadHist.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView_BadHist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_BadHist.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView_BadHist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_BadHist.Location = new System.Drawing.Point(1, 122);
            this.dataGridView_BadHist.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.dataGridView_BadHist.Name = "dataGridView_BadHist";
            this.dataGridView_BadHist.RowTemplate.Height = 23;
            this.dataGridView_BadHist.Size = new System.Drawing.Size(893, 488);
            this.dataGridView_BadHist.TabIndex = 5;
            this.dataGridView_BadHist.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_BadHist_CellClick);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.lbl_BodyNo, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.lbl_Commit, 1, 1);
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
            this.tableLayoutPanel2.Size = new System.Drawing.Size(894, 61);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // lbl_BodyNo
            // 
            this.lbl_BodyNo.AutoSize = true;
            this.lbl_BodyNo.BackColor = System.Drawing.Color.LightSkyBlue;
            this.lbl_BodyNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_BodyNo.Font = new System.Drawing.Font("HY견고딕", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_BodyNo.Location = new System.Drawing.Point(535, 24);
            this.lbl_BodyNo.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.lbl_BodyNo.Name = "lbl_BodyNo";
            this.lbl_BodyNo.Size = new System.Drawing.Size(358, 37);
            this.lbl_BodyNo.TabIndex = 6;
            this.lbl_BodyNo.Text = "CSW 533684";
            this.lbl_BodyNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Commit
            // 
            this.lbl_Commit.AutoSize = true;
            this.lbl_Commit.BackColor = System.Drawing.Color.White;
            this.lbl_Commit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Commit.Font = new System.Drawing.Font("HY견고딕", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_Commit.Location = new System.Drawing.Point(312, 24);
            this.lbl_Commit.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.lbl_Commit.Name = "lbl_Commit";
            this.lbl_Commit.Size = new System.Drawing.Size(222, 37);
            this.lbl_Commit.TabIndex = 5;
            this.lbl_Commit.Text = "6636";
            this.lbl_Commit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.SteelBlue;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("HY견고딕", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Image = ((System.Drawing.Image)(resources.GetObject("label3.Image")));
            this.label3.Location = new System.Drawing.Point(535, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(358, 24);
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
            this.label1.Size = new System.Drawing.Size(311, 24);
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
            this.label2.Location = new System.Drawing.Point(312, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(222, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "커밋번호";
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
            this.lbl_OrderDate.Size = new System.Drawing.Size(311, 37);
            this.lbl_OrderDate.TabIndex = 4;
            this.lbl_OrderDate.Text = "20121011";
            this.lbl_OrderDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.Controls.Add(this.btnPrev, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnNext, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnDel, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.itCommandButton4, 3, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 64);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(888, 55);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // btnPrev
            // 
            this.btnPrev.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.btnPrev.BtnShape = MOBISDAS.UI.itCommandButton.BtnShapeEnum.Rectangle;
            this.btnPrev.BtnStyle = MOBISDAS.UI.itCommandButton.XPStyleEnum.Default;
            this.btnPrev.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPrev.Location = new System.Drawing.Point(3, 3);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(216, 49);
            this.btnPrev.TabIndex = 0;
            this.btnPrev.Text = "이전";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.btnNext.BtnShape = MOBISDAS.UI.itCommandButton.BtnShapeEnum.Rectangle;
            this.btnNext.BtnStyle = MOBISDAS.UI.itCommandButton.XPStyleEnum.Default;
            this.btnNext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNext.Location = new System.Drawing.Point(225, 3);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(216, 49);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "다음";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnDel
            // 
            this.btnDel.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.btnDel.BtnShape = MOBISDAS.UI.itCommandButton.BtnShapeEnum.Rectangle;
            this.btnDel.BtnStyle = MOBISDAS.UI.itCommandButton.XPStyleEnum.Default;
            this.btnDel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDel.Location = new System.Drawing.Point(447, 3);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(216, 49);
            this.btnDel.TabIndex = 2;
            this.btnDel.Text = "삭제";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // itCommandButton4
            // 
            this.itCommandButton4.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.itCommandButton4.BtnShape = MOBISDAS.UI.itCommandButton.BtnShapeEnum.Rectangle;
            this.itCommandButton4.BtnStyle = MOBISDAS.UI.itCommandButton.XPStyleEnum.Default;
            this.itCommandButton4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itCommandButton4.Location = new System.Drawing.Point(669, 3);
            this.itCommandButton4.Name = "itCommandButton4";
            this.itCommandButton4.Size = new System.Drawing.Size(216, 49);
            this.itCommandButton4.TabIndex = 3;
            this.itCommandButton4.Text = "닫기";
            this.itCommandButton4.UseVisualStyleBackColor = true;
            this.itCommandButton4.Click += new System.EventHandler(this.itCommandButton4_Click);
            // 
            // frmWorkKeeper_BadHist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 630);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmWorkKeeper_BadHist";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "툴 작업";
            this.TransparencyKey = System.Drawing.Color.Lime;
            this.Shown += new System.EventHandler(this.frmWorkKeeper_BadHist_Shown);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_BadHist)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lbl_BodyNo;
        private System.Windows.Forms.Label lbl_Commit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_OrderDate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.DataGridView dataGridView_BadHist;
        private UI.itCommandButton btnPrev;
        private UI.itCommandButton btnNext;
        private UI.itCommandButton btnDel;
        private UI.itCommandButton itCommandButton4;
    }
}