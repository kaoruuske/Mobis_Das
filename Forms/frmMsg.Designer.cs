namespace MOBISDAS.Forms
{
    partial class frmMsg
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
            this.pnl_Msg = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_Msg = new System.Windows.Forms.Label();
            this.pnl_Title = new System.Windows.Forms.Panel();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.btn_OK = new MOBISDAS.UI.itCommandButton(this.components);
            this.btn_Cancle = new MOBISDAS.UI.itCommandButton(this.components);
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.timer_Tag_Check = new System.Windows.Forms.Timer(this.components);
            this.pnl_Msg.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnl_Title.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_Msg
            // 
            this.pnl_Msg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.pnl_Msg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnl_Msg.Controls.Add(this.panel1);
            this.pnl_Msg.Controls.Add(this.pnl_Title);
            this.pnl_Msg.Controls.Add(this.btn_OK);
            this.pnl_Msg.Controls.Add(this.btn_Cancle);
            this.pnl_Msg.Location = new System.Drawing.Point(19, 18);
            this.pnl_Msg.Name = "pnl_Msg";
            this.pnl_Msg.Size = new System.Drawing.Size(746, 484);
            this.pnl_Msg.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl_Msg);
            this.panel1.Location = new System.Drawing.Point(28, 107);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(681, 308);
            this.panel1.TabIndex = 5;
            // 
            // lbl_Msg
            // 
            this.lbl_Msg.AutoSize = true;
            this.lbl_Msg.Font = new System.Drawing.Font("HY견고딕", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_Msg.ForeColor = System.Drawing.Color.White;
            this.lbl_Msg.Location = new System.Drawing.Point(6, 10);
            this.lbl_Msg.Name = "lbl_Msg";
            this.lbl_Msg.Size = new System.Drawing.Size(414, 32);
            this.lbl_Msg.TabIndex = 1;
            this.lbl_Msg.Text = "가 작업된 내용이 있습니다";
            // 
            // pnl_Title
            // 
            this.pnl_Title.Controls.Add(this.lbl_Title);
            this.pnl_Title.Font = new System.Drawing.Font("HY견고딕", 42F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.pnl_Title.ForeColor = System.Drawing.Color.Yellow;
            this.pnl_Title.Location = new System.Drawing.Point(28, 11);
            this.pnl_Title.Margin = new System.Windows.Forms.Padding(0);
            this.pnl_Title.Name = "pnl_Title";
            this.pnl_Title.Size = new System.Drawing.Size(681, 83);
            this.pnl_Title.TabIndex = 4;
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.Font = new System.Drawing.Font("HY견고딕", 42F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_Title.ForeColor = System.Drawing.Color.Yellow;
            this.lbl_Title.Location = new System.Drawing.Point(9, 7);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(323, 56);
            this.lbl_Title.TabIndex = 0;
            this.lbl_Title.Text = "재작업 확인";
            // 
            // btn_OK
            // 
            this.btn_OK.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.btn_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_OK.BackColor = System.Drawing.Color.Aqua;
            this.btn_OK.BtnShape = MOBISDAS.UI.itCommandButton.BtnShapeEnum.Rectangle;
            this.btn_OK.BtnStyle = MOBISDAS.UI.itCommandButton.XPStyleEnum.Default;
            this.btn_OK.Font = new System.Drawing.Font("HY견고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_OK.Location = new System.Drawing.Point(352, 418);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(150, 49);
            this.btn_OK.TabIndex = 3;
            this.btn_OK.Text = "확인";
            this.btn_OK.UseVisualStyleBackColor = false;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Cancle
            // 
            this.btn_Cancle.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.btn_Cancle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancle.BackColor = System.Drawing.Color.Aqua;
            this.btn_Cancle.BtnShape = MOBISDAS.UI.itCommandButton.BtnShapeEnum.Rectangle;
            this.btn_Cancle.BtnStyle = MOBISDAS.UI.itCommandButton.XPStyleEnum.Default;
            this.btn_Cancle.Font = new System.Drawing.Font("HY견고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Cancle.Location = new System.Drawing.Point(558, 418);
            this.btn_Cancle.Name = "btn_Cancle";
            this.btn_Cancle.Size = new System.Drawing.Size(150, 49);
            this.btn_Cancle.TabIndex = 2;
            this.btn_Cancle.Text = "취소";
            this.btn_Cancle.UseVisualStyleBackColor = false;
            this.btn_Cancle.Click += new System.EventHandler(this.btn_Cancle_Click);
            // 
            // timer
            // 
            this.timer.Interval = 500;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // timer_Tag_Check
            // 
            this.timer_Tag_Check.Interval = 1000;
            this.timer_Tag_Check.Tick += new System.EventHandler(this.timer_Tag_Check_Tick);
            // 
            // frmMsg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.ClientSize = new System.Drawing.Size(786, 522);
            this.Controls.Add(this.pnl_Msg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMsg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "메세지";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMsg_FormClosing);
            this.Load += new System.EventHandler(this.frmMsg_Load);
            this.pnl_Msg.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnl_Title.ResumeLayout(false);
            this.pnl_Title.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_Msg;
        private UI.itCommandButton btn_Cancle;
        private UI.itCommandButton btn_OK;
        public System.Windows.Forms.Label lbl_Msg;
        public System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Timer timer_Tag_Check;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnl_Title;
    }
}