using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Drawing.Drawing2D;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MOBISDAS.UI
{
    public partial class itCommandButton : System.Windows.Forms.Button
    {
        #region 선언
        public enum XPStyleEnum { Default, Blue, OliveGreen, Silver, Red, Yellow }
        public enum BtnShapeEnum { Rectangle, Ellipse }
        public enum ControlStateEnum { Normal, Hover, Pressed, Default, Disabled }

        //private System.ComponentModel.Container components = null;
        private ControlStateEnum ControlState = ControlStateEnum.Normal;
        private bool bCanClick = false;
        private Point locPoint;
        #endregion

        #region Static members
        private static readonly Size sizeBorderPixelIndent;
        private static readonly Color clrOuterShadow1;
        private static readonly Color clrOuterShadow2;
        private static readonly Color clrBackground1;
        private static readonly Color clrBackground2;
        private static readonly Color clrBorder;
        private static readonly Color clrInnerShadowBottom1;
        private static readonly Color clrInnerShadowBottom2;
        private static readonly Color clrInnerShadowBottom3;
        private static readonly Color clrInnerShadowRight1a;
        private static readonly Color clrInnerShadowRight1b;
        private static readonly Color clrInnerShadowRight2a;
        private static readonly Color clrInnerShadowRight2b;
        private static readonly Color clrInnerShadowBottomPressed1;
        private static readonly Color clrInnerShadowBottomPressed2;
        private static readonly Color clrInnerShadowTopPressed1;
        private static readonly Color clrInnerShadowTopPressed2;
        private static readonly Color clrInnerShadowLeftPressed1;
        private static readonly Color clrInnerShadowLeftPressed2;
        #endregion

        //private string _Text;
        private string _MText;
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                _MText = value;
                //if (_MText == "보전호출")
                //{
                //    string a = "a";
                //}
                //if (Global.WT.L18N != null)
                //{
                //    if (LANGUAGE)
                //    {
                //        base.Text = Global.WT.L18N.Conversion(_MText);
                //    }
                //    else
                //    {
                //        base.Text = _MText;
                //    }
                //}
                //else
                    base.Text = _MText;

                //base.Text = _Text;
            }
        }

        public void ReDraw()
        {
            this.Text = _MText;

        }

        public itCommandButton()
        {
            InitializeComponent();
            base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);

        }
        public itCommandButton(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        static itCommandButton()
        {
            sizeBorderPixelIndent = new Size(4, 4);

            // Normal colors
            clrOuterShadow1 = Color.FromArgb(64, 164, 164, 164);
            clrOuterShadow2 = Color.FromArgb(64, Color.White);
            clrBackground1 = Color.FromArgb(250, 250, 248);
            clrBackground2 = Color.FromArgb(240, 240, 234);
            clrBorder = Color.FromArgb(0, 60, 116);
            clrInnerShadowBottom1 = Color.FromArgb(236, 235, 230);
            clrInnerShadowBottom2 = Color.FromArgb(226, 223, 214);
            clrInnerShadowBottom3 = Color.FromArgb(214, 208, 197);
            clrInnerShadowRight1a = Color.FromArgb(128, 236, 234, 230);
            clrInnerShadowRight1b = Color.FromArgb(128, 224, 220, 212);
            clrInnerShadowRight2a = Color.FromArgb(128, 234, 228, 218);
            clrInnerShadowRight2b = Color.FromArgb(128, 212, 208, 196);

            // Pressed colors
            clrInnerShadowBottomPressed1 = Color.FromArgb(234, 233, 227);
            clrInnerShadowBottomPressed2 = Color.FromArgb(242, 241, 238);
            clrInnerShadowTopPressed1 = Color.FromArgb(209, 204, 193);
            clrInnerShadowTopPressed2 = Color.FromArgb(220, 216, 207);
            clrInnerShadowLeftPressed1 = Color.FromArgb(216, 213, 203);
            clrInnerShadowLeftPressed2 = Color.FromArgb(222, 220, 211);
        }


        #region Properties
        private XPStyleEnum m_btnStyle = XPStyleEnum.Default;
        private bool IsLanguage=true;
        private BtnShapeEnum m_btnShape = BtnShapeEnum.Rectangle;

        public new FlatStyle FlatStyle { get { return base.FlatStyle; } set { base.FlatStyle = FlatStyle.Standard; } }
        public BtnShapeEnum BtnShape { get { return m_btnShape; } set { m_btnShape = value; base.Invalidate(); } }

        [DefaultValue(true), System.ComponentModel.RefreshProperties(RefreshProperties.Repaint)]
        public bool LANGUAGE { get { return IsLanguage; } set { IsLanguage = value; this.Invalidate(); } }
      

        [DefaultValue("Blue"), System.ComponentModel.RefreshProperties(RefreshProperties.Repaint)]
        public XPStyleEnum BtnStyle { get { return m_btnStyle; } set { m_btnStyle = value; this.Invalidate(); } }
        public Point AdjustImageLocation { get { return locPoint; } set { locPoint = value; this.Invalidate(); } }
        private Rectangle BorderRectangle
        {
            get
            {
                Rectangle rc = this.ClientRectangle;
                return new Rectangle(1, 1, rc.Width - 3, rc.Height - 3);
            }
        }
        #endregion

        #region Methods : Override Event OnClick
        protected override void OnClick(EventArgs ea)
        {
            this.Capture = false;
            bCanClick = false;

            if (this.ClientRectangle.Contains(this.PointToClient(Control.MousePosition)))
                ControlState = ControlStateEnum.Hover;
            else
                ControlState = ControlStateEnum.Normal;

            this.Invalidate();

            base.OnClick(ea);
        }
        #endregion

        #region Methods : Override Event OnMouseEnter
        protected override void OnMouseEnter(EventArgs ea)
        {
            base.OnMouseEnter(ea);

            ControlState = ControlStateEnum.Hover;
            this.Invalidate();
        }
        #endregion

        #region Methods : Override Event OnMouseDown
        protected override void OnMouseDown(MouseEventArgs mea)
        {
            base.OnMouseDown(mea);

            if (mea.Button == MouseButtons.Left)
            {
                bCanClick = true;
                ControlState = ControlStateEnum.Pressed;
                this.Invalidate();
            }
        }
        #endregion

        #region Methods : Override Event OnMouseMove
        protected override void OnMouseMove(MouseEventArgs mea)
        {
            base.OnMouseMove(mea);

            if (ClientRectangle.Contains(mea.X, mea.Y))
            {
                if (ControlState == ControlStateEnum.Hover && this.Capture && !bCanClick)
                {
                    bCanClick = true;
                    ControlState = ControlStateEnum.Pressed;
                    this.Invalidate();
                }
            }
            else
            {
                if (ControlState == ControlStateEnum.Pressed)
                {
                    bCanClick = false;
                    ControlState = ControlStateEnum.Hover;
                    this.Invalidate();
                }
            }
        }
        #endregion

        #region Methods : Override Event OnMouseLeave
        protected override void OnMouseLeave(EventArgs ea)
        {
            base.OnMouseLeave(ea);

            ControlState = ControlStateEnum.Normal;
            this.Invalidate();
        }
        #endregion

        #region Methods : Override Event OnPaint
        protected override void OnPaint(PaintEventArgs pea)
        {
            this.OnPaintBackground(pea);
            try
            {
               
                switch (ControlState)
                {
                    case ControlStateEnum.Normal:
                        if (this.Enabled)
                        {
                            if (this.Focused || this.IsDefault)
                            {
                                switch (m_btnShape)
                                {
                                    case BtnShapeEnum.Rectangle: OnDrawDefault(pea.Graphics); break;
                                    case BtnShapeEnum.Ellipse: OnDrawDefaultEllipse(pea.Graphics); break;
                                }
                            }
                            else
                            {
                                switch (m_btnShape)
                                {
                                    case BtnShapeEnum.Rectangle: OnDrawNormal(pea.Graphics); break;
                                    case BtnShapeEnum.Ellipse: OnDrawNormalEllipse(pea.Graphics); break;
                                }
                            }
                        }
                        else
                        {
                            OnDrawDisabled(pea.Graphics);
                        }
                        break;

                    case ControlStateEnum.Hover:
                        switch (m_btnShape)
                        {
                            case BtnShapeEnum.Rectangle: OnDrawHover(pea.Graphics); break;
                            case BtnShapeEnum.Ellipse: OnDrawHoverEllipse(pea.Graphics); break;
                        }
                        break;

                    case ControlStateEnum.Pressed:
                        switch (m_btnShape)
                        {
                            case BtnShapeEnum.Rectangle: OnDrawPressed(pea.Graphics); break;
                            case BtnShapeEnum.Ellipse: OnDrawPressedEllipse(pea.Graphics); break;
                        }
                        break;
                }

                ImageAnimator.UpdateFrames();
                OnDrawTextAndImage(pea.Graphics);
            }
            catch { }
        }
        #endregion

        #region Methods : Override Event OnEnabledChanged
        protected override void OnEnabledChanged(EventArgs ea)
        {
            base.OnEnabledChanged(ea);
            ControlState = ControlStateEnum.Normal;
            this.Invalidate();
        }
        #endregion

        #region Methods : OnDrawNormal (Draws the normal state of the XpButton)
        private void OnDrawNormal(Graphics g)
        {
            DrawNormalButton(g);
        }
        #endregion

        #region Methods : OnDrawHoverEllipse
        private void OnDrawHoverEllipse(Graphics g)
        {
            DrawNormalEllipse(g);
            DrawEllipseHoverBorder(g);
            DrawEllipseBorder(g);
        }
        #endregion

        #region Methods : OnDrawHover (Draws the hover state of the XpButton)
        private void OnDrawHover(Graphics g)
        {
            DrawNormalButton(g);

            Rectangle rcBorder = this.BorderRectangle;

            Pen penTop1 = new Pen(Color.FromArgb(255, 240, 207));
            Pen penTop2 = new Pen(Color.FromArgb(253, 216, 137));

            g.DrawLine(penTop1, rcBorder.Left + 2, rcBorder.Top + 1, rcBorder.Right - 2, rcBorder.Top + 1);
            g.DrawLine(penTop2, rcBorder.Left + 1, rcBorder.Top + 2, rcBorder.Right - 1, rcBorder.Top + 2);

            penTop1.Dispose();
            penTop2.Dispose();

            Pen penBottom1 = new Pen(Color.FromArgb(248, 178, 48));
            Pen penBottom2 = new Pen(Color.FromArgb(229, 151, 0));

            g.DrawLine(penBottom1, rcBorder.Left + 1, rcBorder.Bottom - 2, rcBorder.Right - 1, rcBorder.Bottom - 2);
            g.DrawLine(penBottom2, rcBorder.Left + 2, rcBorder.Bottom - 1, rcBorder.Right - 2, rcBorder.Bottom - 1);

            penBottom1.Dispose();
            penBottom2.Dispose();

            Rectangle rcLeft = new Rectangle(rcBorder.Left + 1, rcBorder.Top + 3, 2, rcBorder.Height - 5);
            Rectangle rcRight = new Rectangle(rcBorder.Right - 2, rcBorder.Top + 3, 2, rcBorder.Height - 5);

            LinearGradientBrush brushSide = new LinearGradientBrush(
                rcLeft, Color.FromArgb(254, 221, 149), Color.FromArgb(249, 180, 53), LinearGradientMode.Vertical);

            g.FillRectangle(brushSide, rcLeft);
            g.FillRectangle(brushSide, rcRight);

            brushSide.Dispose();
        }
        #endregion

        #region Methods : OnDrawPressedEllipse
        private void OnDrawPressedEllipse(Graphics g)
        {
            DrawPressedEllipse(g);
            DrawEllipseBorder(g);
        }
        #endregion

        #region Methods : OnDrawPressed (Draws the pressed state of the XpButton)
        private void OnDrawPressed(Graphics g)
        {
            Rectangle rcBorder = this.BorderRectangle;

            DrawOuterShadow(g);
            Rectangle rcBackground = new Rectangle(rcBorder.X + 1, rcBorder.Y + 1, rcBorder.Width - 1, rcBorder.Height - 1);
            SolidBrush brushBackground = new SolidBrush(Color.FromArgb(226, 225, 218));
            g.FillRectangle(brushBackground, rcBackground);
            brushBackground.Dispose();

            DrawBorder(g);

            Pen penInnerShadowBottomPressed1 = new Pen(clrInnerShadowBottomPressed1);
            Pen penInnerShadowBottomPressed2 = new Pen(clrInnerShadowBottomPressed2);

            g.DrawLine(penInnerShadowBottomPressed1, rcBorder.Left + 1, rcBorder.Bottom - 2, rcBorder.Right - 1, rcBorder.Bottom - 2);
            g.DrawLine(penInnerShadowBottomPressed2, rcBorder.Left + 2, rcBorder.Bottom - 1, rcBorder.Right - 2, rcBorder.Bottom - 1);

            penInnerShadowBottomPressed1.Dispose();
            penInnerShadowBottomPressed2.Dispose();

            Pen penInnerShadowTopPressed1 = new Pen(clrInnerShadowTopPressed1);
            Pen penInnerShadowTopPressed2 = new Pen(clrInnerShadowTopPressed2);

            g.DrawLine(penInnerShadowTopPressed1, rcBorder.Left + 2, rcBorder.Top + 1, rcBorder.Right - 2, rcBorder.Top + 1);
            g.DrawLine(penInnerShadowTopPressed2, rcBorder.Left + 1, rcBorder.Top + 2, rcBorder.Right - 1, rcBorder.Top + 2);

            penInnerShadowTopPressed1.Dispose();
            penInnerShadowTopPressed2.Dispose();

            Pen penInnerShadowLeftPressed1 = new Pen(clrInnerShadowLeftPressed1);
            Pen penInnerShadowLeftPressed2 = new Pen(clrInnerShadowLeftPressed2);

            g.DrawLine(penInnerShadowLeftPressed1, rcBorder.Left + 1, rcBorder.Top + 3, rcBorder.Left + 1, rcBorder.Bottom - 3);
            g.DrawLine(penInnerShadowLeftPressed2, rcBorder.Left + 2, rcBorder.Top + 3, rcBorder.Left + 2, rcBorder.Bottom - 3);

            penInnerShadowLeftPressed1.Dispose();
            penInnerShadowLeftPressed2.Dispose();
        }
        #endregion

        #region Methods : OnDrawNormalEllipse (Draws the default state of the XpButton)
        private void OnDrawNormalEllipse(Graphics g)
        {
            DrawNormalEllipse(g);
            DrawEllipseBorder(g);
        }
        #endregion

        #region Methods : OnDrawDefaultEllipse
        private void OnDrawDefaultEllipse(Graphics g)
        {
            DrawNormalEllipse(g);
            DrawEllipseDefaultBorder(g);
            DrawEllipseBorder(g);
        }
        #endregion


        #region Methods : OnDrawDefault
        private void OnDrawDefault(Graphics g)
        {
            DrawNormalButton(g);

            Rectangle rcBorder = this.BorderRectangle;

            Pen penTop1 = new Pen(Color.FromArgb(206, 231, 255));
            Pen penTop2 = new Pen(Color.FromArgb(188, 212, 246));

            g.DrawLine(penTop1, rcBorder.Left + 2, rcBorder.Top + 1, rcBorder.Right - 2, rcBorder.Top + 1);
            g.DrawLine(penTop2, rcBorder.Left + 1, rcBorder.Top + 2, rcBorder.Right - 1, rcBorder.Top + 2);

            penTop1.Dispose();
            penTop2.Dispose();

            Pen penBottom1 = new Pen(Color.FromArgb(137, 173, 228));
            Pen penBottom2 = new Pen(Color.FromArgb(105, 130, 238));

            g.DrawLine(penBottom1, rcBorder.Left + 1, rcBorder.Bottom - 2, rcBorder.Right - 1, rcBorder.Bottom - 2);
            g.DrawLine(penBottom2, rcBorder.Left + 2, rcBorder.Bottom - 1, rcBorder.Right - 2, rcBorder.Bottom - 1);

            penBottom1.Dispose();
            penBottom2.Dispose();

            Rectangle rcLeft = new Rectangle(rcBorder.Left + 1, rcBorder.Top + 3, 2, rcBorder.Height - 5);
            Rectangle rcRight = new Rectangle(rcBorder.Right - 2, rcBorder.Top + 3, 2, rcBorder.Height - 5);

            LinearGradientBrush brushSide = new LinearGradientBrush(
                rcLeft, Color.FromArgb(186, 211, 245), Color.FromArgb(137, 173, 228), LinearGradientMode.Vertical);

            g.FillRectangle(brushSide, rcLeft);
            g.FillRectangle(brushSide, rcRight);

            brushSide.Dispose();
        }
        #endregion

        #region Methods : OnDrawDisabled (Draws the disabled state of the XpButton)
        private void OnDrawDisabled(Graphics g)
        {
            Rectangle rcBorder = this.BorderRectangle;

            Rectangle rcBackground = new Rectangle(rcBorder.X + 1, rcBorder.Y + 1, rcBorder.Width - 1, rcBorder.Height - 1);
            SolidBrush brushBackground = new SolidBrush(Color.FromArgb(245, 244, 234));

            g.FillRectangle(brushBackground, rcBackground);
            brushBackground.Dispose();

            Pen penBorder = new Pen(Color.FromArgb(201, 199, 186));
            ControlPaint.DrawRoundedRectangle(g, penBorder, rcBorder, sizeBorderPixelIndent);
            penBorder.Dispose();
        }
        #endregion

        #region Methods : OnDrawTextAndImage (Draws the text of the XpButton)
        private void OnDrawTextAndImage(Graphics g)
        {
            SolidBrush brushText;

            if (Enabled) brushText = new SolidBrush(ForeColor);
            else brushText = new SolidBrush(ControlPaint.DisabledForeColor);

            StringFormat sf = ControlPaint.GetStringFormat(this.TextAlign);
            sf.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Show;

            if (this.Image != null)
            {
                Rectangle rc = new Rectangle();
                Point ImagePoint = new Point(6, 4);
                switch (this.ImageAlign)
                {
                    case ContentAlignment.MiddleRight:
                        {
                            rc.Width = this.ClientRectangle.Width - this.Image.Width - 8;
                            rc.Height = this.ClientRectangle.Height;
                            rc.X = 0;
                            rc.Y = 0;
                            ImagePoint.X = rc.Width;
                            ImagePoint.Y = this.ClientRectangle.Height / 2 - Image.Height / 2;
                            break;
                        }
                    case ContentAlignment.TopCenter:
                        {
                            ImagePoint.Y = 2;
                            ImagePoint.X = (this.ClientRectangle.Width - this.Image.Width) / 2;
                            rc.Width = this.ClientRectangle.Width;
                            rc.Height = this.ClientRectangle.Height - this.Image.Height - 4;
                            rc.X = this.ClientRectangle.X;
                            rc.Y = this.Image.Height;
                            break;
                        }
                    case ContentAlignment.MiddleCenter:
                        {
                            ImagePoint.X = (this.ClientRectangle.Width - this.Image.Width) / 2;
                            ImagePoint.Y = (this.ClientRectangle.Height - this.Image.Height) / 2;
                            rc.Width = 0;
                            rc.Height = 0;
                            rc.X = this.ClientRectangle.Width;
                            rc.Y = this.ClientRectangle.Height;
                            break;
                        }
                    default:
                        {
                            ImagePoint.X = 6;
                            ImagePoint.Y = this.ClientRectangle.Height / 2 - Image.Height / 2;
                            rc.Width = this.ClientRectangle.Width - this.Image.Width;
                            rc.Height = this.ClientRectangle.Height;
                            rc.X = this.Image.Width;
                            rc.Y = 0;
                            break;
                        }
                }
                ImagePoint.X += locPoint.X;
                ImagePoint.Y += locPoint.Y;

                if (this.Enabled) g.DrawImage(this.Image, ImagePoint);
                else System.Windows.Forms.ControlPaint.DrawImageDisabled(g, this.Image, ImagePoint.X, ImagePoint.Y, this.BackColor);

                if (ContentAlignment.MiddleCenter != this.ImageAlign)
                    g.DrawString(this.Text, this.Font, brushText, rc, sf);
            }
            else
                g.DrawString(this.Text, this.Font, brushText, this.ClientRectangle, sf);

            brushText.Dispose();
            sf.Dispose();
        }
        #endregion

        #region Methods : DrawPressedEllipse
        private void DrawPressedEllipse(Graphics g)
        {
            Rectangle rcBorder = this.BorderRectangle;
            Rectangle rcBackground = new Rectangle(rcBorder.X + 1, rcBorder.Y + 1, rcBorder.Width - 1, rcBorder.Height - 1);
            SolidBrush brushBackground = new SolidBrush(Color.FromArgb(226, 225, 218));
            g.FillEllipse(brushBackground, rcBackground);
        }
        #endregion

        #region Methods : DrawNormalEllipse
        private void DrawNormalEllipse(Graphics g)
        {
            Rectangle rcBackground = this.BorderRectangle;
            LinearGradientBrush brushBackground = null;
            switch (m_btnStyle)
            {
                case XPStyleEnum.Default:
                    brushBackground = new LinearGradientBrush(rcBackground, clrBackground1, clrBackground2, LinearGradientMode.Vertical);
                    break;
                case XPStyleEnum.Blue:
                    brushBackground = new LinearGradientBrush(rcBackground, Color.FromArgb(248, 252, 253), Color.FromArgb(172, 171, 201), LinearGradientMode.Vertical);
                    break;
                case XPStyleEnum.OliveGreen:
                    brushBackground = new LinearGradientBrush(rcBackground, Color.FromArgb(250, 250, 240), Color.FromArgb(235, 220, 190), LinearGradientMode.Vertical);
                    break;
                case XPStyleEnum.Silver:
                    brushBackground = new LinearGradientBrush(rcBackground, Color.FromArgb(253, 253, 253), Color.FromArgb(205, 205, 205), LinearGradientMode.Vertical);
                    break;
                case XPStyleEnum.Red:
                    brushBackground = new LinearGradientBrush(rcBackground, Color.FromArgb(250, 0, 0), Color.FromArgb(255, 0, 0), LinearGradientMode.Vertical);
                    break;
            }
            float[] relativeIntensities = { 0.0f, 0.008f, 1.0f };
            float[] relativePositions = { 0.0f, 0.22f, 1.0f };

            Blend blend = new Blend();
            blend.Factors = relativeIntensities;
            blend.Positions = relativePositions;
            brushBackground.Blend = blend;
            g.FillEllipse(brushBackground, rcBackground);
        }
        #endregion


        #region Methods : DrawNormalButton (Draws the ordinary look of the XpButton object)
        private void DrawNormalButton(Graphics g)
        {
            Rectangle rcBorder = this.BorderRectangle;

            DrawOuterShadow(g);

            Rectangle rcBackground = new Rectangle(rcBorder.X + 1, rcBorder.Y + 1, rcBorder.Width - 1, rcBorder.Height - 1);
            LinearGradientBrush brushBackground = null;
            switch (m_btnStyle)
            {
                case XPStyleEnum.Default:
                    brushBackground = new LinearGradientBrush(rcBackground, clrBackground1, clrBackground2, LinearGradientMode.Vertical);
                    break;
                case XPStyleEnum.Blue:
                    brushBackground = new LinearGradientBrush(rcBackground, Color.FromArgb(248, 252, 253), Color.FromArgb(100, 100, 201), LinearGradientMode.Vertical);
                    break;
                case XPStyleEnum.OliveGreen:
                    brushBackground = new LinearGradientBrush(rcBackground, Color.FromArgb(250, 250, 240), Color.FromArgb(235, 220, 190), LinearGradientMode.Vertical);
                    break;
                case XPStyleEnum.Silver:
                    brushBackground = new LinearGradientBrush(rcBackground, Color.FromArgb(253, 253, 253), Color.FromArgb(205, 205, 205), LinearGradientMode.Vertical);
                    break;
                case XPStyleEnum.Red :
                    brushBackground = new LinearGradientBrush(rcBackground, Color.FromArgb(255, 0, 0), Color.FromArgb(230, 0, 0), LinearGradientMode.Vertical);
                    break;
                case XPStyleEnum.Yellow :
                    brushBackground = new LinearGradientBrush(rcBackground, Color.Cyan, Color.Cyan, LinearGradientMode.Vertical);
                    break;

            }

            float[] relativeIntensities = { 0.0f, 0.08f, 1.0f };
            float[] relativePositions = { 0.0f, 0.32f, 1.0f };

            Blend blend = new Blend();
            blend.Factors = relativeIntensities;
            blend.Positions = relativePositions;
            brushBackground.Blend = blend;

            g.FillRectangle(brushBackground, rcBackground);
            brushBackground.Dispose();

            DrawBorder(g);

            if (XPStyleEnum.Default == m_btnStyle)
            {
                Pen penInnerShadowBottom1 = new Pen(clrInnerShadowBottom1);
                Pen penInnerShadowBottom2 = new Pen(clrInnerShadowBottom2);
                Pen penInnerShadowBottom3 = new Pen(clrInnerShadowBottom3);

                g.DrawLine(penInnerShadowBottom1, rcBorder.Left + 1, rcBorder.Bottom - 3, rcBorder.Right - 1, rcBorder.Bottom - 3);
                g.DrawLine(penInnerShadowBottom2, rcBorder.Left + 1, rcBorder.Bottom - 2, rcBorder.Right - 1, rcBorder.Bottom - 2);
                g.DrawLine(penInnerShadowBottom3, rcBorder.Left + 2, rcBorder.Bottom - 1, rcBorder.Right - 2, rcBorder.Bottom - 1);

                penInnerShadowBottom1.Dispose();
                penInnerShadowBottom2.Dispose();
                penInnerShadowBottom3.Dispose();

                Point ptInnerShadowRight1a = new Point(rcBorder.Right - 2, rcBorder.Top + 1);
                Point ptInnerShadowRight1b = new Point(rcBorder.Right - 2, rcBorder.Bottom - 1);
                Point ptInnerShadowRight2a = new Point(rcBorder.Right - 1, rcBorder.Top + 2);
                Point ptInnerShadowRight2b = new Point(rcBorder.Right - 1, rcBorder.Bottom - 2);

                LinearGradientBrush brushInnerShadowRight1 = new LinearGradientBrush(
                    ptInnerShadowRight1a, ptInnerShadowRight1b, clrInnerShadowRight1a, clrInnerShadowRight1b);
                Pen penInnerShadowRight1 = new Pen(brushInnerShadowRight1);

                LinearGradientBrush brushInnerShadowRight2 = new LinearGradientBrush(
                    ptInnerShadowRight2a, ptInnerShadowRight2b, clrInnerShadowRight2a, clrInnerShadowRight2b);
                Pen penInnerShadowRight2 = new Pen(brushInnerShadowRight2);

                g.DrawLine(penInnerShadowRight1, ptInnerShadowRight1a, ptInnerShadowRight1b);
                g.DrawLine(penInnerShadowRight2, ptInnerShadowRight2a, ptInnerShadowRight2b);

                penInnerShadowRight1.Dispose();
                penInnerShadowRight2.Dispose();
                brushInnerShadowRight1.Dispose();
                brushInnerShadowRight2.Dispose();

                Pen penTop = new Pen(Color.White);

                g.DrawLine(penTop, rcBorder.Left + 2, rcBorder.Top + 1, rcBorder.Right - 2, rcBorder.Top + 1);
                g.DrawLine(penTop, rcBorder.Left + 1, rcBorder.Top + 2, rcBorder.Right - 1, rcBorder.Top + 2);
                g.DrawLine(penTop, rcBorder.Left + 1, rcBorder.Top + 3, rcBorder.Right - 1, rcBorder.Top + 3);

                penTop.Dispose();
            }
        }
        #endregion

        #region Methods : DrawOuterShadow (Draws the outer shadow of the XpButton object)
        private void DrawOuterShadow(Graphics g)
        {
            LinearGradientBrush brushOuterShadow = new LinearGradientBrush(ClientRectangle, clrOuterShadow1, clrOuterShadow2, LinearGradientMode.Vertical);
            g.FillRectangle(brushOuterShadow, ClientRectangle);
            brushOuterShadow.Dispose();
        }
        #endregion

        #region Methods : DrawEllipseOuterShadow
        private void DrawEllipseOuterShadow(Graphics g)
        {
            LinearGradientBrush brushOuterShadow = new LinearGradientBrush(ClientRectangle, clrOuterShadow1, clrOuterShadow2, LinearGradientMode.Vertical);
            g.FillRectangle(brushOuterShadow, ClientRectangle);
            brushOuterShadow.Dispose();
        }
        #endregion

        #region Methods : DrawBorder (Draws the dark blue border of the XpButton object)
        private void DrawBorder(Graphics g)
        {
            Pen penBorder = new Pen(clrBorder);
            ControlPaint.DrawRoundedRectangle(g, penBorder, this.BorderRectangle, sizeBorderPixelIndent);
            penBorder.Dispose();
        }
        #endregion

        #region Methods : DrawEllipseBorder
        private void DrawEllipseBorder(Graphics g)
        {
            Pen penBorder = new Pen(Color.FromArgb(0, 0, 0));

            SmoothingMode oldSmoothingMode = g.SmoothingMode;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.DrawEllipse(penBorder, this.BorderRectangle);
            g.SmoothingMode = oldSmoothingMode;

            penBorder.Dispose();
        }
        #endregion

        #region Methods : DrawEllipseDefaultBorder
        private void DrawEllipseDefaultBorder(Graphics g)
        {
            Pen penTop2 = new Pen(Color.FromArgb(137, 173, 228), 2);
            Rectangle rcInFrame = new Rectangle(
                this.BorderRectangle.X + 2, this.BorderRectangle.Y + 1, this.BorderRectangle.Width - 4, this.BorderRectangle.Height - 2);

            SmoothingMode oldSmoothingMode = g.SmoothingMode;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.DrawEllipse(penTop2, rcInFrame);
            g.SmoothingMode = oldSmoothingMode;

            penTop2.Dispose();
        }
        #endregion

        #region Methods : DrawEllipseHoverBorder
        private void DrawEllipseHoverBorder(Graphics g)
        {
            Pen penTop2 = new Pen(Color.FromArgb(248, 178, 48), 2);
            Rectangle rcInFrame = new Rectangle(
                this.BorderRectangle.X + 2, this.BorderRectangle.Y + 1, this.BorderRectangle.Width - 4, this.BorderRectangle.Height - 2);

            SmoothingMode oldSmoothingMode = g.SmoothingMode;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.DrawEllipse(penTop2, rcInFrame);
            g.SmoothingMode = oldSmoothingMode;

            penTop2.Dispose();
        }
        #endregion

        #region internal sealed class ControlPaint
        internal class ControlPaint
        {
            public static Color BorderColor { get { return Color.FromArgb(127, 157, 185); } }
            public static Color DisabledBorderColor { get { return Color.FromArgb(201, 199, 186); } }
            public static Color ButtonBorderColor { get { return Color.FromArgb(28, 81, 128); } }
            public static Color DisabledButtonBorderColor { get { return Color.FromArgb(202, 200, 187); } }
            public static Color DisabledBackColor { get { return Color.FromArgb(236, 233, 216); } }
            public static Color DisabledForeColor { get { return Color.FromArgb(161, 161, 146); } }

            public static StringFormat GetStringFormat(ContentAlignment contentAlignment)
            {
                if (!Enum.IsDefined(typeof(ContentAlignment), (int)contentAlignment))
                    throw new System.ComponentModel.InvalidEnumArgumentException("contentAlignment", (int)contentAlignment, typeof(ContentAlignment));

                StringFormat stringFormat = new StringFormat();

                switch (contentAlignment)
                {
                    case ContentAlignment.MiddleCenter:
                        stringFormat.LineAlignment = StringAlignment.Center;
                        stringFormat.Alignment = StringAlignment.Center;
                        break;
                    case ContentAlignment.MiddleLeft:
                        stringFormat.LineAlignment = StringAlignment.Center;
                        stringFormat.Alignment = StringAlignment.Near;
                        break;
                    case ContentAlignment.MiddleRight:
                        stringFormat.LineAlignment = StringAlignment.Center;
                        stringFormat.Alignment = StringAlignment.Far;
                        break;
                    case ContentAlignment.TopCenter:
                        stringFormat.LineAlignment = StringAlignment.Near;
                        stringFormat.Alignment = StringAlignment.Center;
                        break;
                    case ContentAlignment.TopLeft:
                        stringFormat.LineAlignment = StringAlignment.Near;
                        stringFormat.Alignment = StringAlignment.Near;
                        break;
                    case ContentAlignment.TopRight:
                        stringFormat.LineAlignment = StringAlignment.Near;
                        stringFormat.Alignment = StringAlignment.Far;
                        break;
                    case ContentAlignment.BottomCenter:
                        stringFormat.LineAlignment = StringAlignment.Far;
                        stringFormat.Alignment = StringAlignment.Center;
                        break;
                    case ContentAlignment.BottomLeft:
                        stringFormat.LineAlignment = StringAlignment.Far;
                        stringFormat.Alignment = StringAlignment.Near;
                        break;
                    case ContentAlignment.BottomRight:
                        stringFormat.LineAlignment = StringAlignment.Far;
                        stringFormat.Alignment = StringAlignment.Far;
                        break;
                }
                return stringFormat;
            }

            /// <summary>
            /// Draws a rectangle with rounded edges.
            /// </summary>
            /// <param name="g">The System.Drawing.Graphics object to be used to draw the rectangle.</param>
            /// <param name="p">A System.Drawing.Pen object that determines the color, width, and style of the rectangle.</param>
            /// <param name="rc">A System.Drawing.Rectangle structure that represents the rectangle to draw.</param>
            /// <param name="size">Pixel indentation that determines the roundness of the corners.</param>
            public static void DrawRoundedRectangle(Graphics g, Pen p, Rectangle rc, Size size)
            {
                // 1 pixel indent in all sides = Size(4, 4)
                // To make pixel indentation larger, change by a factor of 4,
                // i. e., 2 pixels indent = Size(8, 8);

                SmoothingMode oldSmoothingMode = g.SmoothingMode;
                g.SmoothingMode = SmoothingMode.AntiAlias;

                g.DrawLine(p, rc.Left + size.Width / 2, rc.Top, rc.Right - size.Width / 2, rc.Top);
                g.DrawArc(p, rc.Right - size.Width, rc.Top, size.Width, size.Height, 270, 90);

                g.DrawLine(p, rc.Right, rc.Top + size.Height / 2, rc.Right, rc.Bottom - size.Height / 2);
                g.DrawArc(p, rc.Right - size.Width, rc.Bottom - size.Height, size.Width, size.Height, 0, 90);

                g.DrawLine(p, rc.Right - size.Width / 2, rc.Bottom, rc.Left + size.Width / 2, rc.Bottom);
                g.DrawArc(p, rc.Left, rc.Bottom - size.Height, size.Width, size.Height, 90, 90);

                g.DrawLine(p, rc.Left, rc.Bottom - size.Height / 2, rc.Left, rc.Top + size.Height / 2);
                g.DrawArc(p, rc.Left, rc.Top, size.Width, size.Height, 180, 90);

                g.SmoothingMode = oldSmoothingMode;
            }

            public static void DrawBorder(Graphics g, int x, int y, int width, int height)
            {
                g.DrawRectangle(new Pen(ControlPaint.BorderColor, 0), x, y, width, height);
            }

            public static void EraseExcessOldDropDown(Graphics g, Rectangle newButton)
            {
                g.FillRectangle(new SolidBrush(SystemColors.Window), newButton.X - 2, newButton.Y, 2, newButton.Height + 1);
            }
        }
        #endregion
    }
}
