using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace MOBISDAS.Global
{
    public partial class CustomCheckBox : System.Windows.Forms.Control
    {
        private bool _check = false;

        public bool Checked //Check 인지 Checked 인지 테스트하며 확인 할것!
        {
            get
            {
                return _check;
            }
            set
            {
                _check = value;
                Invalidate();
            }
        }

        public CustomCheckBox()
        {
            InitializeComponent();
        }

        public CustomCheckBox(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            Graphics g = pe.Graphics;

            g.FillRectangle(new SolidBrush(Color.Transparent), this.ClientRectangle);

            ControlPaint.DrawCheckBox(g, 1, 1, this.ClientRectangle.Height - 2, this.ClientRectangle.Height - 2, _check ? ButtonState.Checked : ButtonState.Normal);

            g.DrawString(this.Text, this.Font, new SolidBrush(Color.Black), this.ClientRectangle.Height + 2, (this.Height - g.MeasureString(this.Text, this.Font).Height) / 2);
        }

        private void CustomCheckBox_Click(object sender, System.EventArgs e)
        {
            _check = !_check;
            Invalidate();
        }
    }
}
