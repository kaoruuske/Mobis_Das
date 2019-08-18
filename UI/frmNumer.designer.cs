namespace MOBISDAS.UI
{
    partial class frmNumer
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
            this.label1 = new System.Windows.Forms.Label();
            this.bnt1 = new MOBISDAS.UI.itCommandButton(this.components);
            this.bnt2 = new MOBISDAS.UI.itCommandButton(this.components);
            this.bnt3 = new MOBISDAS.UI.itCommandButton(this.components);
            this.bnt4 = new MOBISDAS.UI.itCommandButton(this.components);
            this.bnt5 = new MOBISDAS.UI.itCommandButton(this.components);
            this.bnt6 = new MOBISDAS.UI.itCommandButton(this.components);
            this.bnt7 = new MOBISDAS.UI.itCommandButton(this.components);
            this.bnt8 = new MOBISDAS.UI.itCommandButton(this.components);
            this.bnt9 = new MOBISDAS.UI.itCommandButton(this.components);
            this.bntCLS = new MOBISDAS.UI.itCommandButton(this.components);
            this.bntBackSpace = new MOBISDAS.UI.itCommandButton(this.components);
            this.bntOk = new MOBISDAS.UI.itCommandButton(this.components);
            this.bnt0 = new MOBISDAS.UI.itCommandButton(this.components);
            this.bntdot = new MOBISDAS.UI.itCommandButton(this.components);
            this.bntClose = new MOBISDAS.UI.itCommandButton(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxKeyin = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Aquamarine;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("HY견고딕", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(1, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(326, 73);
            this.label1.TabIndex = 2;
            this.label1.Text = "0";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.TextChanged += new System.EventHandler(this.label1_TextChanged);
            // 
            // bnt1
            // 
            this.bnt1.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.bnt1.BtnShape = MOBISDAS.UI.itCommandButton.BtnShapeEnum.Rectangle;
            this.bnt1.BtnStyle = MOBISDAS.UI.itCommandButton.XPStyleEnum.Default;
            this.bnt1.Font = new System.Drawing.Font("HY견고딕", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnt1.Location = new System.Drawing.Point(1, 78);
            this.bnt1.Name = "bnt1";
            this.bnt1.Size = new System.Drawing.Size(78, 50);
            this.bnt1.TabIndex = 3;
            this.bnt1.Text = "1";
            this.bnt1.UseVisualStyleBackColor = true;
            this.bnt1.Click += new System.EventHandler(this.bnt1_Click);
            // 
            // bnt2
            // 
            this.bnt2.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.bnt2.BtnShape = MOBISDAS.UI.itCommandButton.BtnShapeEnum.Rectangle;
            this.bnt2.BtnStyle = MOBISDAS.UI.itCommandButton.XPStyleEnum.Default;
            this.bnt2.Font = new System.Drawing.Font("HY견고딕", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnt2.Location = new System.Drawing.Point(79, 78);
            this.bnt2.Name = "bnt2";
            this.bnt2.Size = new System.Drawing.Size(78, 50);
            this.bnt2.TabIndex = 4;
            this.bnt2.Text = "2";
            this.bnt2.UseVisualStyleBackColor = true;
            this.bnt2.Click += new System.EventHandler(this.bnt2_Click);
            // 
            // bnt3
            // 
            this.bnt3.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.bnt3.BtnShape = MOBISDAS.UI.itCommandButton.BtnShapeEnum.Rectangle;
            this.bnt3.BtnStyle = MOBISDAS.UI.itCommandButton.XPStyleEnum.Default;
            this.bnt3.Font = new System.Drawing.Font("HY견고딕", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnt3.Location = new System.Drawing.Point(157, 78);
            this.bnt3.Name = "bnt3";
            this.bnt3.Size = new System.Drawing.Size(78, 50);
            this.bnt3.TabIndex = 5;
            this.bnt3.Text = "3";
            this.bnt3.UseVisualStyleBackColor = true;
            this.bnt3.Click += new System.EventHandler(this.bnt3_Click);
            // 
            // bnt4
            // 
            this.bnt4.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.bnt4.BtnShape = MOBISDAS.UI.itCommandButton.BtnShapeEnum.Rectangle;
            this.bnt4.BtnStyle = MOBISDAS.UI.itCommandButton.XPStyleEnum.Default;
            this.bnt4.Font = new System.Drawing.Font("HY견고딕", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnt4.Location = new System.Drawing.Point(1, 127);
            this.bnt4.Name = "bnt4";
            this.bnt4.Size = new System.Drawing.Size(78, 50);
            this.bnt4.TabIndex = 6;
            this.bnt4.Text = "4";
            this.bnt4.UseVisualStyleBackColor = true;
            this.bnt4.Click += new System.EventHandler(this.bnt4_Click);
            // 
            // bnt5
            // 
            this.bnt5.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.bnt5.BtnShape = MOBISDAS.UI.itCommandButton.BtnShapeEnum.Rectangle;
            this.bnt5.BtnStyle = MOBISDAS.UI.itCommandButton.XPStyleEnum.Default;
            this.bnt5.Font = new System.Drawing.Font("HY견고딕", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnt5.Location = new System.Drawing.Point(79, 127);
            this.bnt5.Name = "bnt5";
            this.bnt5.Size = new System.Drawing.Size(78, 50);
            this.bnt5.TabIndex = 7;
            this.bnt5.Text = "5";
            this.bnt5.UseVisualStyleBackColor = true;
            this.bnt5.Click += new System.EventHandler(this.bnt5_Click);
            // 
            // bnt6
            // 
            this.bnt6.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.bnt6.BtnShape = MOBISDAS.UI.itCommandButton.BtnShapeEnum.Rectangle;
            this.bnt6.BtnStyle = MOBISDAS.UI.itCommandButton.XPStyleEnum.Default;
            this.bnt6.Font = new System.Drawing.Font("HY견고딕", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnt6.Location = new System.Drawing.Point(157, 127);
            this.bnt6.Name = "bnt6";
            this.bnt6.Size = new System.Drawing.Size(78, 50);
            this.bnt6.TabIndex = 8;
            this.bnt6.Text = "6";
            this.bnt6.UseVisualStyleBackColor = true;
            this.bnt6.Click += new System.EventHandler(this.bnt6_Click);
            // 
            // bnt7
            // 
            this.bnt7.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.bnt7.BtnShape = MOBISDAS.UI.itCommandButton.BtnShapeEnum.Rectangle;
            this.bnt7.BtnStyle = MOBISDAS.UI.itCommandButton.XPStyleEnum.Default;
            this.bnt7.Font = new System.Drawing.Font("HY견고딕", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnt7.Location = new System.Drawing.Point(1, 176);
            this.bnt7.Name = "bnt7";
            this.bnt7.Size = new System.Drawing.Size(78, 51);
            this.bnt7.TabIndex = 9;
            this.bnt7.Text = "7";
            this.bnt7.UseVisualStyleBackColor = true;
            this.bnt7.Click += new System.EventHandler(this.bnt7_Click);
            // 
            // bnt8
            // 
            this.bnt8.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.bnt8.BtnShape = MOBISDAS.UI.itCommandButton.BtnShapeEnum.Rectangle;
            this.bnt8.BtnStyle = MOBISDAS.UI.itCommandButton.XPStyleEnum.Default;
            this.bnt8.Font = new System.Drawing.Font("HY견고딕", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnt8.Location = new System.Drawing.Point(79, 176);
            this.bnt8.Name = "bnt8";
            this.bnt8.Size = new System.Drawing.Size(78, 50);
            this.bnt8.TabIndex = 10;
            this.bnt8.Text = "8";
            this.bnt8.UseVisualStyleBackColor = true;
            this.bnt8.Click += new System.EventHandler(this.bnt8_Click);
            // 
            // bnt9
            // 
            this.bnt9.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.bnt9.BtnShape = MOBISDAS.UI.itCommandButton.BtnShapeEnum.Rectangle;
            this.bnt9.BtnStyle = MOBISDAS.UI.itCommandButton.XPStyleEnum.Default;
            this.bnt9.Font = new System.Drawing.Font("HY견고딕", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnt9.Location = new System.Drawing.Point(157, 176);
            this.bnt9.Name = "bnt9";
            this.bnt9.Size = new System.Drawing.Size(78, 50);
            this.bnt9.TabIndex = 11;
            this.bnt9.Text = "9";
            this.bnt9.UseVisualStyleBackColor = true;
            this.bnt9.Click += new System.EventHandler(this.bnt9_Click);
            // 
            // bntCLS
            // 
            this.bntCLS.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.bntCLS.BtnShape = MOBISDAS.UI.itCommandButton.BtnShapeEnum.Rectangle;
            this.bntCLS.BtnStyle = MOBISDAS.UI.itCommandButton.XPStyleEnum.Default;
            this.bntCLS.Font = new System.Drawing.Font("HY견고딕", 14F, System.Drawing.FontStyle.Bold);
            this.bntCLS.Location = new System.Drawing.Point(235, 78);
            this.bntCLS.Name = "bntCLS";
            this.bntCLS.Size = new System.Drawing.Size(92, 50);
            this.bntCLS.TabIndex = 12;
            this.bntCLS.Text = "CLS";
            this.bntCLS.UseVisualStyleBackColor = true;
            this.bntCLS.Click += new System.EventHandler(this.bntCLS_Click);
            // 
            // bntBackSpace
            // 
            this.bntBackSpace.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.bntBackSpace.BtnShape = MOBISDAS.UI.itCommandButton.BtnShapeEnum.Rectangle;
            this.bntBackSpace.BtnStyle = MOBISDAS.UI.itCommandButton.XPStyleEnum.Default;
            this.bntBackSpace.Font = new System.Drawing.Font("HY견고딕", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntBackSpace.Location = new System.Drawing.Point(235, 127);
            this.bntBackSpace.Name = "bntBackSpace";
            this.bntBackSpace.Size = new System.Drawing.Size(92, 50);
            this.bntBackSpace.TabIndex = 13;
            this.bntBackSpace.Text = "◀";
            this.bntBackSpace.UseVisualStyleBackColor = true;
            this.bntBackSpace.Click += new System.EventHandler(this.bntBackSpace_Click);
            // 
            // bntOk
            // 
            this.bntOk.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.bntOk.BtnShape = MOBISDAS.UI.itCommandButton.BtnShapeEnum.Rectangle;
            this.bntOk.BtnStyle = MOBISDAS.UI.itCommandButton.XPStyleEnum.Default;
            this.bntOk.Font = new System.Drawing.Font("HY견고딕", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntOk.LANGUAGE = false;
            this.bntOk.Location = new System.Drawing.Point(235, 176);
            this.bntOk.Name = "bntOk";
            this.bntOk.Size = new System.Drawing.Size(92, 99);
            this.bntOk.TabIndex = 14;
            this.bntOk.Text = "입력";
            this.bntOk.UseVisualStyleBackColor = true;
            this.bntOk.Click += new System.EventHandler(this.bntOk_Click);
            // 
            // bnt0
            // 
            this.bnt0.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.bnt0.BtnShape = MOBISDAS.UI.itCommandButton.BtnShapeEnum.Rectangle;
            this.bnt0.BtnStyle = MOBISDAS.UI.itCommandButton.XPStyleEnum.Default;
            this.bnt0.Font = new System.Drawing.Font("HY견고딕", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnt0.Location = new System.Drawing.Point(1, 225);
            this.bnt0.Name = "bnt0";
            this.bnt0.Size = new System.Drawing.Size(155, 50);
            this.bnt0.TabIndex = 15;
            this.bnt0.Text = "0";
            this.bnt0.UseVisualStyleBackColor = true;
            this.bnt0.Click += new System.EventHandler(this.bnt0_Click);
            // 
            // bntdot
            // 
            this.bntdot.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.bntdot.BtnShape = MOBISDAS.UI.itCommandButton.BtnShapeEnum.Rectangle;
            this.bntdot.BtnStyle = MOBISDAS.UI.itCommandButton.XPStyleEnum.Default;
            this.bntdot.Font = new System.Drawing.Font("HY견고딕", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntdot.Location = new System.Drawing.Point(157, 225);
            this.bntdot.Name = "bntdot";
            this.bntdot.Size = new System.Drawing.Size(78, 50);
            this.bntdot.TabIndex = 16;
            this.bntdot.Text = ".";
            this.bntdot.UseVisualStyleBackColor = true;
            this.bntdot.Click += new System.EventHandler(this.bntdot_Click);
            // 
            // bntClose
            // 
            this.bntClose.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.bntClose.BtnShape = MOBISDAS.UI.itCommandButton.BtnShapeEnum.Rectangle;
            this.bntClose.BtnStyle = MOBISDAS.UI.itCommandButton.XPStyleEnum.Default;
            this.bntClose.Font = new System.Drawing.Font("HY견고딕", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntClose.LANGUAGE = false;
            this.bntClose.Location = new System.Drawing.Point(1, 276);
            this.bntClose.Name = "bntClose";
            this.bntClose.Size = new System.Drawing.Size(327, 53);
            this.bntClose.TabIndex = 17;
            this.bntClose.Text = "취소";
            this.bntClose.UseVisualStyleBackColor = true;
            this.bntClose.Click += new System.EventHandler(this.bntClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(287, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 12);
            this.label2.TabIndex = 18;
            this.label2.Text = "label2";
            this.label2.Visible = false;
            // 
            // textBoxKeyin
            // 
            this.textBoxKeyin.Location = new System.Drawing.Point(1, 2);
            this.textBoxKeyin.Name = "textBoxKeyin";
            this.textBoxKeyin.Size = new System.Drawing.Size(216, 21);
            this.textBoxKeyin.TabIndex = 55;
            this.textBoxKeyin.TextChanged += new System.EventHandler(this.textBoxKeyin_TextChanged);
            this.textBoxKeyin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxKeyin_KeyDown);
            this.textBoxKeyin.Leave += new System.EventHandler(this.textBoxKeyin_Leave);
            // 
            // frmNumer
            // 
            this.AcceptButton = this.bntOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 331);
            this.ControlBox = false;
            this.Controls.Add(this.textBoxKeyin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bntClose);
            this.Controls.Add(this.bntdot);
            this.Controls.Add(this.bnt0);
            this.Controls.Add(this.bntOk);
            this.Controls.Add(this.bntBackSpace);
            this.Controls.Add(this.bntCLS);
            this.Controls.Add(this.bnt9);
            this.Controls.Add(this.bnt8);
            this.Controls.Add(this.bnt7);
            this.Controls.Add(this.bnt6);
            this.Controls.Add(this.bnt5);
            this.Controls.Add(this.bnt4);
            this.Controls.Add(this.bnt3);
            this.Controls.Add(this.bnt2);
            this.Controls.Add(this.bnt1);
            this.Controls.Add(this.label1);
            this.Name = "frmNumer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Shown += new System.EventHandler(this.frmNumer_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private itCommandButton bnt1;
        private itCommandButton bnt2;
        private itCommandButton bnt3;
        private itCommandButton bnt4;
        private itCommandButton bnt5;
        private itCommandButton bnt6;
        private itCommandButton bnt7;
        private itCommandButton bnt8;
        private itCommandButton bnt9;
        private itCommandButton bntCLS;
        private itCommandButton bntBackSpace;
        private itCommandButton bntOk;
        private itCommandButton bnt0;
        private itCommandButton bntdot;
        private itCommandButton bntClose;
        private System.Windows.Forms.TextBox textBoxKeyin;
    }
}