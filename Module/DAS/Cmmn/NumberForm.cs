using Cmmn.Properties;
using Infragistics.Win;
using Infragistics.Win.UltraWinEditors;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Cmmn
{
	public class NumberForm : Form
	{
		private string sResultString = string.Empty;
		private double dResultDouble = 0.0;

        private string sResultSubString = string.Empty;
        private double dResultSubDouble = 0.0;

        private int iValue = 0;
		private object oCustomSender;
		private FormInfor FormInformation;
		private IContainer components = null;
		private zLabel lblTitle;
		private Panel pnlNum;
		private UltraTextEditor txtContent;
		private zLabel lblHeader;

		private zLabel lblSign;
     
        public double ResultDouble => dResultDouble;
		public string ResultString => sResultString;

        public double ResultSubDouble => dResultSubDouble;
        public string ResultSubString => sResultSubString;
        public string Set_ContentsType;

        MessageForm form;
        private Timer timer = new Timer();
        private Panel panelButtonList;
        private Button btnDot;
        private Button btnOK;
        private Button btn00;
        private Button btnCancel;
        private Button btnClear;
        private Button btnBack;
        private Button btn07;
        private Button btn09;
        private Button btn08;
        private Button btn03;
        private Button btn04;
        private Button btn02;
        private Button btn05;
        private Button btn01;
        private Button btn06;
        private Panel panelSub;
        private UltraTextEditor txtSubContent;
        private zLabel lblSubHeader;
        private zLabel lblSubSign;

        public string LabelTitle
		{
			get
			{
				return lblTitle.Text;
			}
			set
			{
				lblTitle.Text = value;
			}
		}

		public string LabelHeader
		{
			get
			{
				return lblHeader.Text;
			}
			set
			{
				lblHeader.Text = value;
			}
		}

		public string ContentText
		{
			get
			{
				return txtContent.Text;
			}
			set
			{
				txtContent.Text = value;
			}
		}

        /// <summary>
        /// 두번째 라벨 텍스트
        /// </summary>
        public string LabelSubHeader
        {
            get
            {
                return lblSubHeader.Text;
            }
            set
            {
                lblSubHeader.Text = value;
            }
        }

        /// <summary>
        /// 두번째 텍스트 입력 내용
        /// </summary>
        public string ContentSubText
        {
            get
            {
                return txtSubContent.Text;
            }
            set
            {
                txtSubContent.Text = value;
            }
        }

        private UltraTextEditor uText;

		[DllImport("user32.dll")]
		private static extern uint keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        /// <summary>
        /// 숫자 입력창 종류
        /// </summary>
        public enum ContentsType {
            /// <summary>
            /// 입력 텍스트 하나
            /// </summary>
            ONE_TEXT,
            /// <summary>
            /// 입력창 텍스트 둘 ( 생산량 + 양품 )
            /// </summary>
            TWO_TEXT_1,
            /// <summary>
            /// 입력 텍스트 둘 ( 양품 + 불량 )
            /// </summary>
            TWO_TEXT_2,
            /// <summary>
            /// 입력 텍스트 넷 (총생산량 + 소결량 )
            /// 일렉트로엠에서 사용함
            /// </summary>
            TWO_TEXT_4,
                /// <summary>
                /// 입력 텍스트 다섯 (생산량 + 재사용량 )
                /// 일렉트로엠에서 사용함
                /// </summary>
            TWO_TEXT_5
        };

        public NumberForm(ContentsType cType = ContentsType.ONE_TEXT, string sFirstName = "", string sSecondeName = "")
		{
			InitializeComponent();
			Initialization();
        
            txtContent.Text = "";
			base.StartPosition = FormStartPosition.CenterScreen;
			base.TopMost = true;

            uText = txtContent;

            //2020-10-05 일렉트로엠 작업 TWO_TEXT_4 추가작업
            switch (cType)
            {
                case ContentsType.ONE_TEXT:
                    panelSub.Visible = false;
                    this.Height = this.Height - (panelButtonList.Top - panelSub.Top);
                    panelButtonList.Top = panelSub.Top;
                    Set_ContentsType = "1";
                    break;
                case ContentsType.TWO_TEXT_1:
                    lblHeader.Text = sFirstName == "" ? "생산량" : sFirstName;
                    lblSubHeader.Text = sSecondeName == "" ? "불량" : sSecondeName;
                    Set_ContentsType = "2";
                    break;
                case ContentsType.TWO_TEXT_2:
                    lblHeader.Text = sFirstName == "" ? "양품" : sFirstName;
                    lblSubHeader.Text = sSecondeName == "" ? "불량" : sSecondeName;
                    Set_ContentsType = "3";
                    break;
                case ContentsType.TWO_TEXT_4:
                    lblHeader.Text = sFirstName == "" ? "생산량" : sFirstName;
                    lblSubHeader.Text = sSecondeName == "" ? "소결량" : sSecondeName;
                    Set_ContentsType = "4";
                    break;
                case ContentsType.TWO_TEXT_5:
                    lblHeader.Text = sFirstName == "" ? "원재료량" : sFirstName;
                    lblSubHeader.Text = sSecondeName == "" ? "재사용량" : sSecondeName;
                    Set_ContentsType = "5";
                    break;
            }

            timer.Tick += Timer_Tick;
            timer.Interval = 500;
            timer.Start();
		}

        public void SetStartLocation(Common.enumWindowLocation eLoc)
        {
            switch (eLoc)
            {
                case Common.enumWindowLocation.Center:
                    base.StartPosition = FormStartPosition.CenterScreen;
                    break;
                case Common.enumWindowLocation.TopRight:
                    base.StartPosition = FormStartPosition.Manual;
                    base.Location = new Point(this.Owner.Location.X + this.Owner.Size.Width - this.Width, this.Owner.Location.Y);
                    break;
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (!uText.Focused)
            {
                uText.Focus();
            }
        }

        private void NumberForm_Activated(object sender, EventArgs e)
		{
			uText.Focus();

            keybd_event(35, 0, 0, 0);
			keybd_event(35, 0, 2, 0);
		}

        private void txtContent_MouseUp(object sender, MouseEventArgs e)
        {
            UltraTextEditor t = sender as UltraTextEditor;

            if (t != null)
            {
                uText = t;
                uText.Focus();
                keybd_event(35, 0, 0, 0);
                keybd_event(35, 0, 2, 0);
            }
        }

        private void txtContent_Leave(object sender, EventArgs e)
		{
            uText.Focus();
            keybd_event(35, 0, 0, 0);
            keybd_event(35, 0, 2, 0);
		}

        private void txtContent_TextChanged(object sender, EventArgs e)
		{
			int result = 0;

            UltraTextEditor t = sender as UltraTextEditor;

            if (t != null)
            {
                int.TryParse(t.Text.Trim(), out result);
                if (iValue != result)
                {
                    t.Text = CModule.ToString(result);
                    result = iValue;
                }
            }
		}

        private void txtContent_KeyPress(object sender, KeyPressEventArgs e)
        {
            UltraTextEditor t = sender as UltraTextEditor;

            if (t != null)
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    t.Text = t.Text.Trim();
                    Button_Click(btnOK, new EventArgs());
                }
            }
        }

        private void Button_Click(object sender, EventArgs e)
		{
			Button button = (Button)sender;
			string sResult = CModule.ToString(button.Tag).ToUpper();
			ButtonType(sResult);
		}

		private void lblSign_Click(object sender, EventArgs e)
		{
            Cmmn.zLabel z = sender as Cmmn.zLabel;

            if (z != null)
            {
                if (CModule.ToString(z.Tag) == "+")
                {
                    z.Tag = "-";
                    z.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_NumberForm_016");
                }
                else if (CModule.ToString(z.Tag) == "-")
                {
                    z.Tag = "+";
                    z.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_NumberForm_015");
                }
            }
		}

		private void Initialization()
		{
			btn01.Tag = "1";
			btn02.Tag = "2";
			btn03.Tag = "3";
			btn04.Tag = "4";
			btn05.Tag = "5";
			btn06.Tag = "6";
			btn07.Tag = "7";
			btn08.Tag = "8";
			btn09.Tag = "9";
			btn00.Tag = "0";
			btnDot.Tag = ".";
			btnClear.Tag = "CLEAR";
			btnBack.Tag = "←";
			btnOK.Tag = "확인";
			btnCancel.Tag = "취소";
			lblSign.Tag = "+";
			lblSign.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_NumberForm_015");
			btn01.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_NumberForm_001");
			btn02.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_NumberForm_002");
			btn03.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_NumberForm_003");
			btn04.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_NumberForm_004");
			btn05.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_NumberForm_005");
			btn06.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_NumberForm_006");
			btn07.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_NumberForm_007");
			btn08.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_NumberForm_008");
			btn09.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_NumberForm_009");
			btn00.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_NumberForm_000");
			btnDot.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_NumberForm_010");
			btnClear.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_NumberForm_011");
			btnBack.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_NumberForm_012");
			btnOK.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject("NumberForm_013");
			btnCancel.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject("NumberForm_014");
			btnOK.BackColor = Color.FromArgb(54, 248, 255);
			btnCancel.BackColor = Color.FromArgb(255, 97, 28);
			lblSign.BackgroundImageLayout = ImageLayout.Stretch;
			btn01.BackgroundImageLayout = ImageLayout.Stretch;
			btn02.BackgroundImageLayout = ImageLayout.Stretch;
			btn03.BackgroundImageLayout = ImageLayout.Stretch;
			btn04.BackgroundImageLayout = ImageLayout.Stretch;
			btn05.BackgroundImageLayout = ImageLayout.Stretch;
			btn06.BackgroundImageLayout = ImageLayout.Stretch;
			btn07.BackgroundImageLayout = ImageLayout.Stretch;
			btn08.BackgroundImageLayout = ImageLayout.Stretch;
			btn09.BackgroundImageLayout = ImageLayout.Stretch;
			btn00.BackgroundImageLayout = ImageLayout.Stretch;
			btnDot.BackgroundImageLayout = ImageLayout.Stretch;
			btnClear.BackgroundImageLayout = ImageLayout.Stretch;
			btnBack.BackgroundImageLayout = ImageLayout.Stretch;
			btnOK.BackgroundImageLayout = ImageLayout.Stretch;
			btnCancel.BackgroundImageLayout = ImageLayout.Stretch;
			FormInformation = new FormInfor("NEXDAS", base.Name, Common.gsLanguege);
			FormInformation.ManageForm(this);
			Color color = default(Color);
			switch (Common.gsLayout)
			{
			case "BU":
				color = Color.FromArgb(1, 174, 240);
				break;
			case "RD":
				color = Color.FromArgb(163, 37, 14);
				break;
			case "BL":
				color = Color.FromArgb(44, 44, 44);
				break;
			}
			BackColor = color;
			lblTitle.ForeColor = color;
			lblHeader.ForeColor = color;
		}

        private void ButtonType(string sResult)
        {
            if (sResult == "")
            {
                return;
            }
            byte bVk = (byte)sResult[0];
            switch (sResult)
            {
                case ".":
                    if (uText.Text.Trim() == string.Empty)
                    {
                        uText.Text = "0.";
                        uText.Focus();
                        uText.Select(uText.Text.Length, 0);
                    }
                    else if (uText.Text.IndexOf(".") < 0)
                    {
                        keybd_event(190, 0, 0, 0);
                        keybd_event(190, 0, 2, 0);
                    }
                    break;
                case "CLEAR":
                    uText.Text = string.Empty;
                    break;
                case "←":
                    keybd_event(8, 0, 0, 0);
                    keybd_event(8, 0, 2, 0);
                    break;
                case "확인":
                    {
                        if (panelSub.Visible == true)
                        {
                            if (txtSubContent.Text.Trim() == string.Empty)
                            {
                                txtSubContent.Text = "0";
                            }

                            //생산량 불량이면 조건 넣기
                            if (Set_ContentsType == "2")
                            {
                                if (Convert.ToDouble(txtSubContent.Text.Trim()) > Convert.ToDouble(txtContent.Text.Trim()))
                                {
                                    form = new MessageForm("생산수량보다 불량수량이 많습니다.", MessageBoxButtons.OK, "DAS");
                                    form.ShowDialog();
                                    break;
                                }
                            }

                            if (txtContent.Text.Trim() == "")
                            {
                                sResultString = "";
                            }
                            else

                            {
                                sResultString = CModule.ToString(lblSign.Tag) + txtContent.Text.Trim();
                                sResultString = sResultString.Replace("+", "");
                            }

                            if (txtSubContent.Text.Trim() == "")
                            {
                                sResultSubString = "";
                            }
                            else
                            {
                                sResultSubString = CModule.ToString(lblSubSign.Tag) + txtSubContent.Text.Trim();
                                sResultSubString = sResultSubString.Replace("+", "");
                            }

                            dResultDouble = ((sResultString == "") ? 0.0 : CModule.ToDouble(sResultString));
                            sResultSubString = CModule.ToString(lblSubSign.Tag) + txtSubContent.Text.Trim();
                            dResultSubDouble = ((sResultSubString == "") ? 0.0 : CModule.ToDouble(sResultSubString));

                            if (oCustomSender != null)
                            {
                                zLabel zLabel = (zLabel)oCustomSender;
                                zLabel.Text = CModule.ToString(dResultDouble);
                            }
                            base.DialogResult = DialogResult.OK;

                        }
                        else
                        {
                            if (txtContent.Text.Trim() == "")
                            {
                                sResultString = "";
                            }
                            else

                            {
                                sResultString = CModule.ToString(lblSign.Tag) + txtContent.Text.Trim();
                                sResultString = sResultString.Replace("+", "");
                            }

                            dResultDouble = ((sResultString == "") ? 0.0 : CModule.ToDouble(sResultString));

                            if (oCustomSender != null)
                            {
                                zLabel zLabel = (zLabel)oCustomSender;
                                zLabel.Text = CModule.ToString(dResultDouble);
                            }
                            base.DialogResult = DialogResult.OK;

                        }

                        break;
                    }
                case "취소":
                    base.DialogResult = DialogResult.Cancel;
                    break;
                case "00":
                    keybd_event(bVk, 0, 0, 0);
                    keybd_event(bVk, 0, 2, 0);
                    keybd_event(bVk, 0, 0, 0);
                    keybd_event(bVk, 0, 2, 0);
                    break;
                default:
                    keybd_event(bVk, 0, 0, 0);
                    keybd_event(bVk, 0, 2, 0);
                    break;
            }
            uText.Focus();
        }

        protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NumberForm));
            this.pnlNum = new System.Windows.Forms.Panel();
            this.panelSub = new System.Windows.Forms.Panel();
            this.txtSubContent = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblSubHeader = new Cmmn.zLabel();
            this.lblSubSign = new Cmmn.zLabel();
            this.panelButtonList = new System.Windows.Forms.Panel();
            this.btnDot = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btn00 = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btn07 = new System.Windows.Forms.Button();
            this.btn09 = new System.Windows.Forms.Button();
            this.btn08 = new System.Windows.Forms.Button();
            this.btn03 = new System.Windows.Forms.Button();
            this.btn04 = new System.Windows.Forms.Button();
            this.btn02 = new System.Windows.Forms.Button();
            this.btn05 = new System.Windows.Forms.Button();
            this.btn01 = new System.Windows.Forms.Button();
            this.btn06 = new System.Windows.Forms.Button();
            this.txtContent = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblHeader = new Cmmn.zLabel();
            this.lblSign = new Cmmn.zLabel();
            this.lblTitle = new Cmmn.zLabel();
            this.pnlNum.SuspendLayout();
            this.panelSub.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubContent)).BeginInit();
            this.panelButtonList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtContent)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlNum
            // 
            this.pnlNum.BackColor = System.Drawing.Color.Transparent;
            this.pnlNum.Controls.Add(this.panelSub);
            this.pnlNum.Controls.Add(this.panelButtonList);
            this.pnlNum.Controls.Add(this.txtContent);
            this.pnlNum.Controls.Add(this.lblHeader);
            this.pnlNum.Controls.Add(this.lblSign);
            this.pnlNum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNum.Location = new System.Drawing.Point(0, 98);
            this.pnlNum.Margin = new System.Windows.Forms.Padding(0);
            this.pnlNum.Name = "pnlNum";
            this.pnlNum.Size = new System.Drawing.Size(682, 429);
            this.pnlNum.TabIndex = 34;
            // 
            // panelSub
            // 
            this.panelSub.Controls.Add(this.txtSubContent);
            this.panelSub.Controls.Add(this.lblSubHeader);
            this.panelSub.Controls.Add(this.lblSubSign);
            this.panelSub.Location = new System.Drawing.Point(8, 82);
            this.panelSub.Name = "panelSub";
            this.panelSub.Size = new System.Drawing.Size(666, 76);
            this.panelSub.TabIndex = 36;
            // 
            // txtSubContent
            // 
            appearance.BackColor = System.Drawing.Color.Black;
            appearance.ForeColor = System.Drawing.Color.Gold;
            appearance.TextHAlignAsString = "Right";
            appearance.TextVAlignAsString = "Middle";
            this.txtSubContent.Appearance = appearance;
            this.txtSubContent.BackColor = System.Drawing.Color.Black;
            this.txtSubContent.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtSubContent.Font = new System.Drawing.Font("맑은 고딕", 24F, System.Drawing.FontStyle.Bold);
            this.txtSubContent.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtSubContent.Location = new System.Drawing.Point(232, 3);
            this.txtSubContent.Margin = new System.Windows.Forms.Padding(0);
            this.txtSubContent.Multiline = true;
            this.txtSubContent.Name = "txtSubContent";
            this.txtSubContent.Size = new System.Drawing.Size(434, 70);
            this.txtSubContent.TabIndex = 37;
            this.txtSubContent.TextChanged += new System.EventHandler(this.txtContent_TextChanged);
            this.txtSubContent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtContent_KeyPress);
            this.txtSubContent.Leave += new System.EventHandler(this.txtContent_Leave);
            this.txtSubContent.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txtContent_MouseUp);
            // 
            // lblSubHeader
            // 
            this.lblSubHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblSubHeader.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblSubHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblSubHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSubHeader.ColorContent = System.Drawing.Color.Transparent;
            this.lblSubHeader.ColorLabel = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblSubHeader.ColorReadOnly = System.Drawing.Color.Transparent;
            this.lblSubHeader.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold);
            this.lblSubHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.lblSubHeader.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblSubHeader.Location = new System.Drawing.Point(0, 3);
            this.lblSubHeader.Margin = new System.Windows.Forms.Padding(0);
            this.lblSubHeader.MoveControl = null;
            this.lblSubHeader.Name = "lblSubHeader";
            this.lblSubHeader.Size = new System.Drawing.Size(134, 70);
            this.lblSubHeader.TabIndex = 35;
            this.lblSubHeader.TextHAlign = Infragistics.Win.HAlign.Center;
            this.lblSubHeader.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // lblSubSign
            // 
            this.lblSubSign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.lblSubSign.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblSubSign.BackgroundImage = global::Cmmn.Properties.Resources.BU_NumberForm_015;
            this.lblSubSign.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblSubSign.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSubSign.ColorContent = System.Drawing.Color.Transparent;
            this.lblSubSign.ColorLabel = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.lblSubSign.ColorReadOnly = System.Drawing.Color.Transparent;
            this.lblSubSign.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSubSign.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.lblSubSign.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblSubSign.Location = new System.Drawing.Point(133, 3);
            this.lblSubSign.Margin = new System.Windows.Forms.Padding(0);
            this.lblSubSign.MoveControl = null;
            this.lblSubSign.Name = "lblSubSign";
            this.lblSubSign.Size = new System.Drawing.Size(100, 70);
            this.lblSubSign.TabIndex = 36;
            this.lblSubSign.TextHAlign = Infragistics.Win.HAlign.Center;
            this.lblSubSign.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.lblSubSign.Click += new System.EventHandler(this.lblSign_Click);
            // 
            // panelButtonList
            // 
            this.panelButtonList.Controls.Add(this.btnDot);
            this.panelButtonList.Controls.Add(this.btnOK);
            this.panelButtonList.Controls.Add(this.btn00);
            this.panelButtonList.Controls.Add(this.btnCancel);
            this.panelButtonList.Controls.Add(this.btnClear);
            this.panelButtonList.Controls.Add(this.btnBack);
            this.panelButtonList.Controls.Add(this.btn07);
            this.panelButtonList.Controls.Add(this.btn09);
            this.panelButtonList.Controls.Add(this.btn08);
            this.panelButtonList.Controls.Add(this.btn03);
            this.panelButtonList.Controls.Add(this.btn04);
            this.panelButtonList.Controls.Add(this.btn02);
            this.panelButtonList.Controls.Add(this.btn05);
            this.panelButtonList.Controls.Add(this.btn01);
            this.panelButtonList.Controls.Add(this.btn06);
            this.panelButtonList.Location = new System.Drawing.Point(8, 156);
            this.panelButtonList.Name = "panelButtonList";
            this.panelButtonList.Size = new System.Drawing.Size(666, 261);
            this.panelButtonList.TabIndex = 35;
            // 
            // btnDot
            // 
            this.btnDot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.btnDot.BackgroundImage = global::Cmmn.Properties.Resources.BU_NumberForm_010;
            this.btnDot.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDot.CausesValidation = false;
            this.btnDot.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnDot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDot.Font = new System.Drawing.Font("맑은 고딕", 25F);
            this.btnDot.ForeColor = System.Drawing.Color.Gray;
            this.btnDot.Location = new System.Drawing.Point(264, 175);
            this.btnDot.Margin = new System.Windows.Forms.Padding(0);
            this.btnDot.Name = "btnDot";
            this.btnDot.Size = new System.Drawing.Size(134, 86);
            this.btnDot.TabIndex = 44;
            this.btnDot.UseVisualStyleBackColor = false;
            this.btnDot.Click += new System.EventHandler(this.Button_Click);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.btnOK.BackgroundImage = global::Cmmn.Properties.Resources.NumberForm_013;
            this.btnOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOK.CausesValidation = false;
            this.btnOK.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("맑은 고딕", 20F);
            this.btnOK.ForeColor = System.Drawing.Color.Black;
            this.btnOK.Location = new System.Drawing.Point(530, 5);
            this.btnOK.Margin = new System.Windows.Forms.Padding(0);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(134, 86);
            this.btnOK.TabIndex = 41;
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.Button_Click);
            // 
            // btn00
            // 
            this.btn00.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.btn00.BackgroundImage = global::Cmmn.Properties.Resources.BU_NumberForm_000;
            this.btn00.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn00.CausesValidation = false;
            this.btn00.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btn00.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn00.Font = new System.Drawing.Font("맑은 고딕", 25F);
            this.btn00.ForeColor = System.Drawing.Color.Gray;
            this.btn00.Location = new System.Drawing.Point(131, 175);
            this.btn00.Margin = new System.Windows.Forms.Padding(0);
            this.btn00.Name = "btn00";
            this.btn00.Size = new System.Drawing.Size(134, 86);
            this.btn00.TabIndex = 42;
            this.btn00.UseVisualStyleBackColor = false;
            this.btn00.Click += new System.EventHandler(this.Button_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(97)))), ((int)(((byte)(28)))));
            this.btnCancel.BackgroundImage = global::Cmmn.Properties.Resources.NumberForm_014;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancel.CausesValidation = false;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("맑은 고딕", 20F);
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(530, 90);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(134, 86);
            this.btnCancel.TabIndex = 43;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.Button_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.btnClear.BackgroundImage = global::Cmmn.Properties.Resources.BU_NumberForm_011;
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClear.CausesValidation = false;
            this.btnClear.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("맑은 고딕", 18F);
            this.btnClear.ForeColor = System.Drawing.Color.Gray;
            this.btnClear.Location = new System.Drawing.Point(397, 175);
            this.btnClear.Margin = new System.Windows.Forms.Padding(0);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(134, 86);
            this.btnClear.TabIndex = 37;
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.Button_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.btnBack.BackgroundImage = global::Cmmn.Properties.Resources.BU_NumberForm_012;
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBack.CausesValidation = false;
            this.btnBack.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("맑은 고딕", 25F);
            this.btnBack.ForeColor = System.Drawing.Color.Gray;
            this.btnBack.Location = new System.Drawing.Point(530, 175);
            this.btnBack.Margin = new System.Windows.Forms.Padding(0);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(134, 86);
            this.btnBack.TabIndex = 33;
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.Button_Click);
            // 
            // btn07
            // 
            this.btn07.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.btn07.BackgroundImage = global::Cmmn.Properties.Resources.BU_NumberForm_007;
            this.btn07.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn07.CausesValidation = false;
            this.btn07.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btn07.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn07.Font = new System.Drawing.Font("맑은 고딕", 25F);
            this.btn07.ForeColor = System.Drawing.Color.Gray;
            this.btn07.Location = new System.Drawing.Point(264, 90);
            this.btn07.Margin = new System.Windows.Forms.Padding(0);
            this.btn07.Name = "btn07";
            this.btn07.Size = new System.Drawing.Size(134, 86);
            this.btn07.TabIndex = 30;
            this.btn07.UseVisualStyleBackColor = false;
            this.btn07.Click += new System.EventHandler(this.Button_Click);
            // 
            // btn09
            // 
            this.btn09.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.btn09.BackgroundImage = global::Cmmn.Properties.Resources.BU_NumberForm_009;
            this.btn09.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn09.CausesValidation = false;
            this.btn09.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btn09.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn09.Font = new System.Drawing.Font("맑은 고딕", 25F);
            this.btn09.ForeColor = System.Drawing.Color.Gray;
            this.btn09.Location = new System.Drawing.Point(-2, 175);
            this.btn09.Margin = new System.Windows.Forms.Padding(0);
            this.btn09.Name = "btn09";
            this.btn09.Size = new System.Drawing.Size(134, 86);
            this.btn09.TabIndex = 32;
            this.btn09.UseVisualStyleBackColor = false;
            this.btn09.Click += new System.EventHandler(this.Button_Click);
            // 
            // btn08
            // 
            this.btn08.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.btn08.BackgroundImage = global::Cmmn.Properties.Resources.BU_NumberForm_008;
            this.btn08.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn08.CausesValidation = false;
            this.btn08.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btn08.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn08.Font = new System.Drawing.Font("맑은 고딕", 25F);
            this.btn08.ForeColor = System.Drawing.Color.Gray;
            this.btn08.Location = new System.Drawing.Point(397, 90);
            this.btn08.Margin = new System.Windows.Forms.Padding(0);
            this.btn08.Name = "btn08";
            this.btn08.Size = new System.Drawing.Size(134, 86);
            this.btn08.TabIndex = 31;
            this.btn08.UseVisualStyleBackColor = false;
            this.btn08.Click += new System.EventHandler(this.Button_Click);
            // 
            // btn03
            // 
            this.btn03.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.btn03.BackgroundImage = global::Cmmn.Properties.Resources.BU_NumberForm_003;
            this.btn03.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn03.CausesValidation = false;
            this.btn03.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btn03.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn03.Font = new System.Drawing.Font("맑은 고딕", 25F);
            this.btn03.ForeColor = System.Drawing.Color.Gray;
            this.btn03.Location = new System.Drawing.Point(264, 5);
            this.btn03.Margin = new System.Windows.Forms.Padding(0);
            this.btn03.Name = "btn03";
            this.btn03.Size = new System.Drawing.Size(134, 86);
            this.btn03.TabIndex = 40;
            this.btn03.UseVisualStyleBackColor = false;
            this.btn03.Click += new System.EventHandler(this.Button_Click);
            // 
            // btn04
            // 
            this.btn04.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.btn04.BackgroundImage = global::Cmmn.Properties.Resources.BU_NumberForm_004;
            this.btn04.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn04.CausesValidation = false;
            this.btn04.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btn04.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn04.Font = new System.Drawing.Font("맑은 고딕", 25F);
            this.btn04.ForeColor = System.Drawing.Color.Gray;
            this.btn04.Location = new System.Drawing.Point(397, 5);
            this.btn04.Margin = new System.Windows.Forms.Padding(0);
            this.btn04.Name = "btn04";
            this.btn04.Size = new System.Drawing.Size(134, 86);
            this.btn04.TabIndex = 34;
            this.btn04.UseVisualStyleBackColor = false;
            this.btn04.Click += new System.EventHandler(this.Button_Click);
            // 
            // btn02
            // 
            this.btn02.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.btn02.BackgroundImage = global::Cmmn.Properties.Resources.BU_NumberForm_002;
            this.btn02.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn02.CausesValidation = false;
            this.btn02.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btn02.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn02.Font = new System.Drawing.Font("맑은 고딕", 25F);
            this.btn02.ForeColor = System.Drawing.Color.Gray;
            this.btn02.Location = new System.Drawing.Point(131, 5);
            this.btn02.Margin = new System.Windows.Forms.Padding(0);
            this.btn02.Name = "btn02";
            this.btn02.Size = new System.Drawing.Size(134, 86);
            this.btn02.TabIndex = 39;
            this.btn02.UseVisualStyleBackColor = false;
            this.btn02.Click += new System.EventHandler(this.Button_Click);
            // 
            // btn05
            // 
            this.btn05.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.btn05.BackgroundImage = global::Cmmn.Properties.Resources.BU_NumberForm_005;
            this.btn05.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn05.CausesValidation = false;
            this.btn05.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btn05.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn05.Font = new System.Drawing.Font("맑은 고딕", 25F);
            this.btn05.ForeColor = System.Drawing.Color.Gray;
            this.btn05.Location = new System.Drawing.Point(-2, 90);
            this.btn05.Margin = new System.Windows.Forms.Padding(0);
            this.btn05.Name = "btn05";
            this.btn05.Size = new System.Drawing.Size(134, 86);
            this.btn05.TabIndex = 35;
            this.btn05.UseVisualStyleBackColor = false;
            this.btn05.Click += new System.EventHandler(this.Button_Click);
            // 
            // btn01
            // 
            this.btn01.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.btn01.BackgroundImage = global::Cmmn.Properties.Resources.BU_NumberForm_001;
            this.btn01.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn01.CausesValidation = false;
            this.btn01.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btn01.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn01.Font = new System.Drawing.Font("맑은 고딕", 25F);
            this.btn01.ForeColor = System.Drawing.Color.Gray;
            this.btn01.Location = new System.Drawing.Point(-2, 5);
            this.btn01.Margin = new System.Windows.Forms.Padding(0);
            this.btn01.Name = "btn01";
            this.btn01.Size = new System.Drawing.Size(134, 86);
            this.btn01.TabIndex = 38;
            this.btn01.UseVisualStyleBackColor = false;
            this.btn01.Click += new System.EventHandler(this.Button_Click);
            // 
            // btn06
            // 
            this.btn06.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.btn06.BackgroundImage = global::Cmmn.Properties.Resources.BU_NumberForm_006;
            this.btn06.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn06.CausesValidation = false;
            this.btn06.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btn06.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn06.Font = new System.Drawing.Font("맑은 고딕", 25F);
            this.btn06.ForeColor = System.Drawing.Color.Gray;
            this.btn06.Location = new System.Drawing.Point(131, 90);
            this.btn06.Margin = new System.Windows.Forms.Padding(0);
            this.btn06.Name = "btn06";
            this.btn06.Size = new System.Drawing.Size(134, 86);
            this.btn06.TabIndex = 36;
            this.btn06.UseVisualStyleBackColor = false;
            this.btn06.Click += new System.EventHandler(this.Button_Click);
            // 
            // txtContent
            // 
            appearance1.BackColor = System.Drawing.Color.Black;
            appearance1.ForeColor = System.Drawing.Color.Gold;
            appearance1.TextHAlignAsString = "Right";
            appearance1.TextVAlignAsString = "Middle";
            this.txtContent.Appearance = appearance1;
            this.txtContent.BackColor = System.Drawing.Color.Black;
            this.txtContent.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtContent.Font = new System.Drawing.Font("맑은 고딕", 24F, System.Drawing.FontStyle.Bold);
            this.txtContent.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtContent.Location = new System.Drawing.Point(240, 8);
            this.txtContent.Margin = new System.Windows.Forms.Padding(0);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(434, 70);
            this.txtContent.TabIndex = 31;
            this.txtContent.TextChanged += new System.EventHandler(this.txtContent_TextChanged);
            this.txtContent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtContent_KeyPress);
            this.txtContent.Leave += new System.EventHandler(this.txtContent_Leave);
            this.txtContent.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txtContent_MouseUp);
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblHeader.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHeader.ColorContent = System.Drawing.Color.Transparent;
            this.lblHeader.ColorLabel = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblHeader.ColorReadOnly = System.Drawing.Color.Transparent;
            this.lblHeader.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.lblHeader.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblHeader.Location = new System.Drawing.Point(8, 8);
            this.lblHeader.Margin = new System.Windows.Forms.Padding(0);
            this.lblHeader.MoveControl = null;
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(134, 70);
            this.lblHeader.TabIndex = 2;
            this.lblHeader.Text = "입력 숫자";
            this.lblHeader.TextHAlign = Infragistics.Win.HAlign.Center;
            this.lblHeader.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // lblSign
            // 
            this.lblSign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.lblSign.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblSign.BackgroundImage = global::Cmmn.Properties.Resources.BU_NumberForm_015;
            this.lblSign.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblSign.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSign.ColorContent = System.Drawing.Color.Transparent;
            this.lblSign.ColorLabel = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.lblSign.ColorReadOnly = System.Drawing.Color.Transparent;
            this.lblSign.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSign.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.lblSign.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblSign.Location = new System.Drawing.Point(141, 8);
            this.lblSign.Margin = new System.Windows.Forms.Padding(0);
            this.lblSign.MoveControl = null;
            this.lblSign.Name = "lblSign";
            this.lblSign.Size = new System.Drawing.Size(100, 70);
            this.lblSign.TabIndex = 30;
            this.lblSign.TextHAlign = Infragistics.Win.HAlign.Center;
            this.lblSign.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.lblSign.Click += new System.EventHandler(this.lblSign_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.White;
            this.lblTitle.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblTitle.ColorContent = System.Drawing.Color.Transparent;
            this.lblTitle.ColorLabel = System.Drawing.Color.White;
            this.lblTitle.ColorReadOnly = System.Drawing.Color.Transparent;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("맑은 고딕", 25F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.lblTitle.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle.MoveControl = this;
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(682, 98);
            this.lblTitle.TabIndex = 33;
            this.lblTitle.Text = "숫자 입력";
            this.lblTitle.TextHAlign = Infragistics.Win.HAlign.Center;
            this.lblTitle.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // NumberForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(682, 527);
            this.ControlBox = false;
            this.Controls.Add(this.pnlNum);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NumberForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Activated += new System.EventHandler(this.NumberForm_Activated);
            this.pnlNum.ResumeLayout(false);
            this.pnlNum.PerformLayout();
            this.panelSub.ResumeLayout(false);
            this.panelSub.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubContent)).EndInit();
            this.panelButtonList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtContent)).EndInit();
            this.ResumeLayout(false);

		}
    }
}
