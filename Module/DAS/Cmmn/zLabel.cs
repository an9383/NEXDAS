using Infragistics.Win;
using Infragistics.Win.Misc;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Cmmn
{
	[DefaultEvent("Click")]
	public class zLabel : UserControl
	{
		public enum LabelTypeEnum
		{
			Label,
			Transparent,
			Content
		}

		private delegate void SetTextCallback(string text);

		private delegate void SetColorCallback(Color color);

		private object _tag;

		private LabelTypeEnum _LabelType;

		private bool _bDrag;

		private Point _pOffset;

		private Control _MoveControl;

		private Color _LabelColor;

		private Color _TransparentColor;

		private Color _ContentColor;

		private IContainer components = null;

		protected UltraLabel label;

        public new event EventHandler Click;
        public new event EventHandler DoubleClick;

        public Color ColorLabel
		{
			get
			{
				return _LabelColor;
			}
			set
			{
				_LabelColor = value;
			}
		}

		public Color ColorReadOnly
		{
			get
			{
				return _TransparentColor;
			}
			set
			{
				_TransparentColor = value;
			}
		}

		public Color ColorContent
		{
			get
			{
				return _ContentColor;
			}
			set
			{
				_ContentColor = value;
			}
		}

		public LabelTypeEnum LabelType
		{
			get
			{
				return _LabelType;
			}
			set
			{
				_LabelType = value;
				switch (value)
				{
				case LabelTypeEnum.Label:
					BackColor = _LabelColor;
					BackGradientStyle = GradientStyle.Default;
					break;
				case LabelTypeEnum.Transparent:
					BackColor = _TransparentColor;
					BackGradientStyle = GradientStyle.None;
					break;
				case LabelTypeEnum.Content:
					BackColor = _ContentColor;
					BackGradientStyle = GradientStyle.None;
					break;
				}
			}
		}

		public GradientStyle BackGradientStyle
		{
			get
			{
				return label.Appearance.BackGradientStyle;
			}
			set
			{
				label.Appearance.BackGradientStyle = value;
			}
		}

		public Control MoveControl
		{
			get
			{
				return _MoveControl;
			}
			set
			{
				_MoveControl = value;
			}
		}

		[Browsable(true)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public override string Text
		{
			get
			{
				return label.Text;
			}
			set
			{
				SetText(value);
			}
		}

		public VAlign TextVAlign
		{
			get
			{
				return label.Appearance.TextVAlign;
			}
			set
			{
				label.Appearance.TextVAlign = value;
			}
		}

		public HAlign TextHAlign
		{
			get
			{
				return label.Appearance.TextHAlign;
			}
			set
			{
				label.Appearance.TextHAlign = value;
			}
		}

		public new object Tag
		{
			get
			{
				return _tag;
			}
			set
			{
				_tag = value;
			}
		}


		public zLabel()
		{
			InitializeComponent();
			SetStyle(ControlStyles.DoubleBuffer, value: true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, value: true);
			SetStyle(ControlStyles.ResizeRedraw, value: true);
			_LabelColor = Color.LightGreen;
			_TransparentColor = Color.Transparent;
			_ContentColor = Color.Transparent;
			label.Dock = DockStyle.Fill;
			LabelType = LabelTypeEnum.Label;
		}

		private void SetText(string text)
		{
			try
			{
				if (label.InvokeRequired)
				{
					SetTextCallback method = SetText;
					Invoke(method, text);
				}
				else
				{
					label.Text = text;
				}
			}
			catch
			{
			}
		}

        private void label_DoubleClick(object sender, EventArgs e)
        {
            if (this.DoubleClick != null)
            {
                this.DoubleClick(this, e);
            }
        }

        private void label_Click(object sender, EventArgs e)
		{
			if (this.Click != null)
			{
				this.Click(this, e);
			}
		}

		private void zLabel_FontChanged(object sender, EventArgs e)
		{
			label.Font = Font;
		}

		private void zLabel_ForeColorChanged(object sender, EventArgs e)
		{
			label.ForeColor = ForeColor;
		}

		private void zLabel_BackColorChanged(object sender, EventArgs e)
		{
			switch (LabelType)
			{
			case LabelTypeEnum.Label:
				_LabelColor = BackColor;
				break;
			case LabelTypeEnum.Transparent:
				_TransparentColor = BackColor;
				break;
			case LabelTypeEnum.Content:
				_ContentColor = BackColor;
				break;
			}
		}

		public void SetColor(Color color)
		{
			if (base.InvokeRequired)
			{
				SetColorCallback method = SetColor;
				Invoke(method, color);
			}
			else
			{
				BackColor = color;
			}
		}

		private void label_MouseMove(object sender, MouseEventArgs e)
		{
			if (_MoveControl != null && _bDrag)
			{
				_MoveControl.Left = e.X + _MoveControl.Left - _pOffset.X;
				_MoveControl.Top = e.Y + _MoveControl.Top - _pOffset.Y;
			}
		}

		private void label_MouseUp(object sender, MouseEventArgs e)
		{
			if (_MoveControl != null)
			{
				_bDrag = false;
			}
		}

		private void label_MouseDown(object sender, MouseEventArgs e)
		{
			if (_MoveControl != null)
			{
				_bDrag = true;
				_pOffset = new Point(e.X, e.Y);
			}
		}

		protected override void Dispose(bool disposing)
		{
			try
			{
				if (disposing && components != null)
				{
					components.Dispose();
				}
				base.Dispose(disposing);
			}
			catch
			{
			}
		}

		private void InitializeComponent()
		{
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            this.label = new Infragistics.Win.Misc.UltraLabel();
            this.SuspendLayout();
            // 
            // label
            // 
            appearance.BackColor = System.Drawing.Color.Transparent;
            appearance.TextHAlignAsString = "Center";
            appearance.TextVAlignAsString = "Middle";
            this.label.Appearance = appearance;
            this.label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.label.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.None;
            this.label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label.Location = new System.Drawing.Point(0, 0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(164, 54);
            this.label.TabIndex = 1;
            this.label.Click += new System.EventHandler(this.label_Click);
            this.label.DoubleClick += new System.EventHandler(this.label_DoubleClick);
            this.label.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label_MouseDown);
            this.label.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label_MouseMove);
            this.label.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label_MouseUp);
            // 
            // zLabel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.label);
            this.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "zLabel";
            this.Size = new System.Drawing.Size(164, 54);
            this.BackColorChanged += new System.EventHandler(this.zLabel_BackColorChanged);
            this.FontChanged += new System.EventHandler(this.zLabel_FontChanged);
            this.ForeColorChanged += new System.EventHandler(this.zLabel_ForeColorChanged);
            this.ResumeLayout(false);

		}

    }
}
