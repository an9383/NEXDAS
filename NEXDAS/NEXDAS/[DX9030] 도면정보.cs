#region [ HEADER AREA ]
/*---------------------------------------------------------------------------------------------*
   Form ID      : DX9030L
   Form Name    : 공지사항
   Name Space   : NEXDAS
   Created Date : 2017-01-01 
   Update Date  :
   Made By      : JWLee
   Description  : 1920 * 1080
 *---------------------------------------------------------------------------------------------*/
#endregion

#region [ USING AREA ]
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using AxAcroPDFLib;

using Cmmn;
#endregion

namespace NEXDAS
{
    public partial class DX9030 : BaseForm
    {
		#region [ MEMBER AREA ]		
		Timer _timer = new Timer();

		private FormInfor FormInformation;
		#endregion

		#region [ CONSTRUCTOR ]
		public DX9030()
        {
            InitializeComponent();

            this.MainForm = false;

            Initialization();

            DoProgress();    
        }
        #endregion
        
        #region [ FORM EVENT ]
        private void DX9030_Shown(object sender, EventArgs e)
        {
			SetButton();
            DoFind();
			
			CloseProgress();
		}

		private void DX9030L_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (_timer != null)
			{
				_timer.Stop();
				_timer.Dispose();
			}
		}
		#endregion

		#region [ EVENT AREA ]
		private void btnConfirm_ButtonClickEvent(Button_Conf sender, ButtonBox_Conf.ButtonClickEventArg e)
		{
			DoProgress();

			try
			{
				switch (CModule.ToString(sender.Tag))
				{
					case "Cancel":
						this.DialogResult = DialogResult.Cancel;
						break;
				}
			}
			catch (Exception ex)
			{
				SetMessage(ex.Message);
			}
			finally
			{
				CloseProgress();
			}
		}

		private void _timer_Tick(object sender, EventArgs e)
		{
			DoFind();
		}

		private void lblBG01_Click(object sender, EventArgs e)
		{
			if (btnConfirm.Visible)
			{
				btnConfirm.Visible = false;
			}
			else
			{
				btnConfirm.Visible = true;
			}			
		}
		#endregion

		#region [ METHOD AREA ]
		private void Initialization()
        {
            this.lblTitle.Text = Common.getLangText("공지사항", "DAS");

			btnConfirm.BorderStyle = BorderStyle.FixedSingle;

			FormInformation = new FormInfor("NEXDAS", this.Name, Common.gsLanguege);
            FormInformation.ManageForm(this);

			Color _clr01 = new Color();

			switch (Common.gsLayout)
			{
				case "BU":
					_clr01 = Color.FromArgb(1, 174, 240);
					break;
				case "RD":
					_clr01 = Color.FromArgb(163, 37, 14);
					break;
				case "BL":
					_clr01 = Color.FromArgb(44, 44, 44);
					break;
			}

			Color _clr02 = new Color();

			switch (Common.gsLayout)
			{
				case "BU":
					_clr02 = Color.FromArgb(200, 230, 255);
					break;
				case "RD":
					_clr02 = Color.FromArgb(248, 202, 191);
					break;
				case "BL":
					_clr02 = Color.FromArgb(197, 197, 197);
					break;
			}

			lblBG01.BackgroundImageLayout = ImageLayout.Stretch;
			lblBG01.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject("DX9030_000");

			btnConfirm.Location = new Point((lblBG01.Location.X - btnConfirm.Width), lblBG01.Location.Y);

			tlpDX9030.BackColor   = _clr01;
			lblFormName.ForeColor = _clr01;

			lblFormName.Text = this.Name;
			
			SetMessage(Common.getLangText("공지사항 입니다. 확인 하세요.", "DAS"));

			btnConfirm.BringToFront();
			btnConfirm.Visible = false;


			_timer.Interval = 5000;
			_timer.Tick += _timer_Tick;
			_timer.Start();
		}

		private void SetButton()
        {
            #region --- btnConfirm Setting ---
            btnConfirm.ButtonBoxType = ButtonBox_Conf.ButtonBoxTypeEnum.Buttons;
            btnConfirm.CountX = 1;
            btnConfirm.CountY = 1;
            btnConfirm.DisplayImage = true;
            btnConfirm.ForeColor = Color.FromArgb(255, 255, 255);
            btnConfirm.BackgroundColor = Color.FromArgb(255, 255, 255);
            btnConfirm.FontData = new Font(Common.gsFontName, 18, FontStyle.Regular);
            btnConfirm.MarginOut = new Padding(5, 5, 5, 5);

			btnConfirm.SetButton();

            btnConfirm[0, 0].Text = Common.getLangText("닫기", "DAS");
            btnConfirm[0, 0].Tag  = "Cancel";

            btnConfirm.RedrawButton();
			#endregion
		}

		private void DoFind()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
				DataTable dtNotice = helper.FillTable("USP_DX9030_S1", CommandType.StoredProcedure
                                   , helper.CreateParameter("AS_PLANTCODE", Common.gsPlantCode, DbType.String, ParameterDirection.Input));

				if (dtNotice.Rows.Count > 0)
				{

				}
            }
            catch (Exception ex)
            {
                SetMessage(ex.Message);
            }
            finally
            {
                helper.Close();
            }
        }
		#endregion

	}
}
