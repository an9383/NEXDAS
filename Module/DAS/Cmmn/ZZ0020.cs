using Cmmn.Properties;
using Infragistics.Win;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Cmmn
{
	public class ZZ0020 : Form
	{
		private Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

		private MessageForm _msg = new MessageForm();

		private FormInfor FormInformation;

		private IContainer components = null;

		private GroupBox grbSetting;

		private TextBox txtConnect;

		private TableLayoutPanel tlpButton;

		private Button btnExit;

		private Button btnSave;

		private Button btnTest;
        private zLabel zLabel1;
        private ComboBox cboCompany;
        private zLabel lblLine_01;

		public ZZ0020()
		{
			InitializeComponent();
		}

		private void ZZ0020_Load(object sender, EventArgs e)
		{
			Initialization();
            #if DEBUG
            Dictionary<string, string> dicCompany = new Dictionary<string, string>();
            dicCompany.Add("gl5RnCm96RxdLYHJ0UGXgC4UQ0MluMnrhuQ24xDPxW/pA6oVQkhrunrRlynvMbSf5ByCY0RTpguqIuOL19VvVn3WFTQk/apAPN/QTJN6XUR4vc4Epn+CQK0MuOfOCBfnXiHGvxrMByFCL7vOBFKOHZKeZm8FJkk23vEBfD+kfjAN0S4uDqiyY2PK8v/rjoglbiYPi12hFqeesifIrG8TsNqfMpVMqAxw/9TD80bF1Bk=", "대화산업");
            dicCompany.Add("gl5RnCm96RxdLYHJ0UGXgC4UQ0MluMnrhuQ24xDPxW8TkEmZiJhanlMYaEk80w8K5mdWTtE+yaUitcoK4v697M6OxLuaYpfapU+rVZOq5d0zaHf37/SQXvAJw0Uwd4h552IXmIMvXniZPZGqSFXx+gQYkoQIoPtEk95IVD+Yzon6eXb0G4K0A05Ro8tRxFSJZZFcaDpODef0gPWudaYp9Gmv87I/TRhF/SWWDHgzX+Y=", "영보공업");
            dicCompany.Add("gl5RnCm96RxdLYHJ0UGXgC4UQ0MluMnrhuQ24xDPxW/DzGv9DVoKY8PODTd9jHXfU4uuI7s6UIAMlDp+Xknx9edNKBd8XGd/nxB0lLa2BLSvHd4ISogktkEoVlyqC1capMfhifEmzeZdX11Z/a4G6yuBE7gLu5knJYJCWnfeel0GpWSROAL9XW9lc3xlHvHhFUvhaAkTUrmdiEKaeVaGCnCAe5rlbxuVreKu6uZgb+8=", "유진하이텍");
            dicCompany.Add("gl5RnCm96RxdLYHJ0UGXgFxt+LMiH8Lts3l4nIsy6iYCLz7cu/1uZWu5I38fMJ07SpNSFkq2pcNffSTEc6FLplI/MeTogRwfC35I17EILtp0oqIM8mjgoBbo3aDOAX/trA5oetOAtcc4cj3dqlJTwCfP4R6fy/HOjH4fQWJOEcNd4tc7k6xvl7BqQMPrD/TGyyXwnnMW74DrHykgA5YCRUxBNMfRlfgp5gBLonbitX0OcNQe0tpISgYT4tizh/bL", "우성");
            dicCompany.Add("gl5RnCm96RxdLYHJ0UGXgC4UQ0MluMnrhuQ24xDPxW+yQPC2qI4Vv5LECTId6xqzMxTgAMItvWtFxbXTvvWYEFkfEUqsCpzoD4pBSWDk8NwWrsvkladNHmRUMWh0Xr0FihqYv0ux9+61z5OYvGhzMr9S3peshCWlo2M7MJAOXogI0Yw1a0aeUCYqqsvCwacPGSimQsz57XPaMbx+yYyIDA==", "일렉트로엠");
            dicCompany.Add("gl5RnCm96RxdLYHJ0UGXgMTcpwfp3CZEVwbO10BwdLpxZ2A4S7qwJWWzLTNCkfTiBw1MStnVZuRxld9tyJ3tfdJB6dd/GXBvTedWYZlH6n+UWV244PZhLF/PHQ+R64coeLXhJEeOM065gB3OYw0W/9Rcp8qH4GuqQXSQ99HNFI426Jq2vUb1mcbsmG7P1BLZg1ZzyHTxYhURWkW8cQDiabZqemierhhfZvxZOEKSryg=", "안성우진캠");
            dicCompany.Add("gl5RnCm96RxdLYHJ0UGXgC4UQ0MluMnrhuQ24xDPxW+mQKfhBP2M2BhBcUpdJ90SG6cGCosyCSVNbjE8wquNR7X2c7mO1YHHLZw4L75Rs1KYL8QZTd+VMLkNoq8ipDqNq6r5Vvj1MIBqthcaLXrdgPaodsaxZG81I8FOft7imO+b4L9aXUm+9OSLOsKRx+MhpeZwDFsAyl7bRPYF9M2g7ezlgpdvJYQDc7aXI10UjI8=", "안성우진캠(1.60)");
            dicCompany.Add("gl5RnCm96RxdLYHJ0UGXgC4UQ0MluMnrhuQ24xDPxW/LIlDQlrGUPMpOHXKJbNE6fuwMfgSSPZV0KeKt2GtlN7PjHDqJIGwCPcAQunIsAN8MXh7Soapo/yFk3dN8+TFlAWbIuKZ2/Q/gHNkb//yrtmogR4NHkjx+Iqs2dYfarkb0xocyIFQeI3yohs/D36F4E1Sh7JlTMwYTq//UZKcsnXjzAIAvPwveZXbJuaJhWo0=", "비봉우진캠(2.60)");
            dicCompany.Add("gl5RnCm96RxdLYHJ0UGXgC4UQ0MluMnrhuQ24xDPxW/u0zJyqgJ497M+u4hPkH5o5CYErSHBNKGOCRQ5dAHVFf4VD8NxQNnXhhF6pBYqzoTxvv04i6fwvNrq+gS5lvGN96NRd3DMmI9g8B6d9uK+HchY3ocmZclwppa+C1ADbKA5mJ6f+YW92K6LepWYScBuKtssn1GWSysyVMulO4JNkMUqqV5Sf/u8+KX26B2bmi+H6eKCqJ8U737l7dKr1n5m", "씨와이씨");
            dicCompany.Add("gl5RnCm96RxdLYHJ0UGXgC4UQ0MluMnrhuQ24xDPxW/h2vXbUp92gQgbgFdNyi1ogovuyq5dQ6Iq+DaDaqEWW1ERPQIm+ol4+1yXFi+EnfCkchJR6pri/4w/wJKVnidQTUox5CMmwEeLnwvx3n7ivCHZl9TtTVT7MQlDLpZ/kYwi1eTuS3Wyt5HNVXA89axg1qfz5rRAAqwZngeb5yq2fpEFxOht+ZPRqlHiU1TXsAk=", "다나와컴퓨터");
            dicCompany.Add("gl5RnCm96RxdLYHJ0UGXgEZwjZji7WnqW47W73pis7DJ4RBaTl28XRxE8NQhCewPJSihmkZ1xLdXwbtuEZ4XY/VOKNmav2tEJXREWBGnEwbyQETpUAHK6jttxhGnCa0g58xMUpxGqC7fWCvRLSawaVwrTvAfxly+v6O7f5DfSeQnyBezQ2gAWiMJs7mB8YSbfAC9ptLa7x4s2+IrJNRnokmpeVzeNFXs8pQ4NUhZMUY=", "다나와컴퓨터(도메인)");
            dicCompany.Add("gl5RnCm96RxdLYHJ0UGXgC4UQ0MluMnrhuQ24xDPxW/FOyvI6+7sxd9juGahgwbO45EPbZketTdBv/LxJZqYToqE1BtSIrgcpcItOVb3xpIOnVWoORN1Lo7oMQEF0PghHlztOZcdRVbTsMlJoNr0etbNSZ5Sg3T1kUEgxGAsGYYLqL3nz7tiboaNXp4cGf19lZ9MzT9lNm4ZirpyTI2Y8i5bKYeJUUnoN4XZl2kbWs8=", "엘림");
            dicCompany.Add("gl5RnCm96RxdLYHJ0UGXgJr0gKkaKpE8W0wdmgcMv/UjkGedpuHmRM7RvgJOP4qXD74mMwodwNUZXg/ipmjcq79dQQPngm6Eqq7FR0vvdBQUfIa9wrWdwz9me43Ngq/pqlE5yjkLXVS0d6z3CVtYjvZcXhr4cukqG64fVAd2B8dq333CT7kaFJakhbxsRuRUsbpy6lq2CuzjNi7+w4REOsSOrJq7nmJ63CQl1KeMlZQ=", "카페리즈");
            dicCompany.Add("gl5RnCm96RxdLYHJ0UGXgC4UQ0MluMnrhuQ24xDPxW/Skj58kqZB1uAnaSeQOUSUnZVWvDu7q2oGA2IY3LFooLL3LJYz59ajauMzI8OxLYeaSzghX7rU757RaEItdAK6sIpgdixFk53xo889bgt7JPGzuyvZihGfG0zo/zvuYQur37o4BXhIbHpobG+F/vTvP3GpxRIc+HFN7GplzbbNOZ7lbkTxaHSqusjpPRwF1Qc=", "화승테크");
            dicCompany.Add("gl5RnCm96RxdLYHJ0UGXgC4UQ0MluMnrhuQ24xDPxW88Y1f0g+2QrSKuJKIu9u81pbxyfjke7zF3vZ+j3M3CkbF5+/qH4rQB2thMpqwI7KjTFOyy+QYuzJlVy1KTDKqDK9qSDrY7/1o98FOJ+Pl+2zw0E+yg8PbxPLtQtQ6Jg5pW9xFgMxpjgA8sWLgVlaHG3Xg/UVsCUgvGWX6yzaiLnk04R4E4PXL3X1U56S2qMfo=", "에스에너지");
            dicCompany.Add("gl5RnCm96RxdLYHJ0UGXgLy81zYPYHJAJX/6F/bkyhVKU3z6QqpOdhVexNEdxlI/jp6GjdUGss6+2XMECc0ItgFUAC807w5+UaSjQ+5F9FWYb1UBLEBTQhfLACAvYO+ZH/K5/HvbLAywQKOpO8kLO+VAfFMIgKfE8c4sFowG6rXAx8P/vK9MsKq7iumVmDWb5KD7ts3HiCDtNtWCqeNlXg3h0VlhHWk9NLFC1jJGRPQ=", "영보_TEST");
            dicCompany.Add("gl5RnCm96RxdLYHJ0UGXgLy81zYPYHJAJX/6F/bkyhVKU3z6QqpOdhVexNEdxlI/jp6GjdUGss6+2XMECc0ItgFUAC807w5+UaSjQ+5F9FWYb1UBLEBTQhfLACAvYO+ZR6BuX2fbEUIb1WglNpFDvuGDhTzFm4KSPXP7wB3eoNi7BvH3ruRr9E5uU1SrhVrZKhBqsDWySzEQbXzXdOB22y/nZ7JjwafFxi3jlmqZdkI=", "안성우진캠_TEST");
            dicCompany.Add("gl5RnCm96RxdLYHJ0UGXgLy81zYPYHJAJX/6F/bkyhVKU3z6QqpOdhVexNEdxlI/jp6GjdUGss6+2XMECc0ItgFUAC807w5+UaSjQ+5F9FWYb1UBLEBTQhfLACAvYO+ZMy32Jcv83Vl0CMr27UeSNAOhMODLSGM8YsApfcFsYbjh+t9ESoLFV+nEKgZiBpi6CVoBjkAO0xfiTr4dyHagp4F0SFHLQJUC9F5GKUyFs0A=", "대화_TEST");
            dicCompany.Add("gl5RnCm96RxdLYHJ0UGXgLy81zYPYHJAJX/6F/bkyhVKU3z6QqpOdhVexNEdxlI/jp6GjdUGss6+2XMECc0ItgFUAC807w5+UaSjQ+5F9FWYb1UBLEBTQhfLACAvYO+ZZW04sKv88A6/A1vh8BvlGaALJwtes5+OwuW6XXYZ0Rb+EX11k/WMxOTBDNqU1IwbihZrToK9sNzpuq9ncVRvpKye0Wz/ZYkZm/HyStKC6tU=", "유진_TEST");
            dicCompany.Add("gl5RnCm96RxdLYHJ0UGXgLy81zYPYHJAJX/6F/bkyhVKU3z6QqpOdhVexNEdxlI/jp6GjdUGss6+2XMECc0ItgFUAC807w5+UaSjQ+5F9FWYb1UBLEBTQhfLACAvYO+Z5XCNf2Gql48pMTPHN/dSekiXw+ZNKxgh5aZqkfa6IaFv0bfZkWPsA51/4yDeccANjIPiC/eDJnanyWKB0I8KlRV/8luDjHz6PDO2yYaV+R0=", "씨와이씨_TEST");
            dicCompany.Add("gl5RnCm96RxdLYHJ0UGXgLy81zYPYHJAJX/6F/bkyhVKU3z6QqpOdhVexNEdxlI/jp6GjdUGss6+2XMECc0ItgFUAC807w5+UaSjQ+5F9FWYb1UBLEBTQhfLACAvYO+ZGjYRuZiaQjpq000G0VWNFzTaBdcFm59Fs1n7OMrpPLiftu9gLNgauYpKy01r8h4VA095iegdsBwf3DseZpVAiibfRdp9swvUnii9t0W7fGM=", "일렉트로엠_TEST");
            dicCompany.Add("gl5RnCm96RxdLYHJ0UGXgLy81zYPYHJAJX/6F/bkyhVKU3z6QqpOdhVexNEdxlI/jp6GjdUGss6+2XMECc0ItgFUAC807w5+UaSjQ+5F9FWYb1UBLEBTQhfLACAvYO+Zg+MtjUKN8OHU3M6U4N+77S/wEiL9F9M6XTXOVvo9/RW8r9OcAIz0oZngCh4+qKLMsFs1BbsNfGAuLgiDCQ1iyqRD2u6M6rpVq2g94KaB9pc=", "대선주조_TEST");
            dicCompany.Add("gl5RnCm96RxdLYHJ0UGXgHcuZ9Ei2PW6qoE7KTDrXnnLEchLJmbEpxoiYZjpiNGN9YAAUdIhIoFP8pFURUS/hCnbWnFkZBcNStWKhgzSqfVVkmODRdLm5HMtwmEN9K9WQ/ulXzHC9DqV/Fbd6Otcyr47y7OvYaEEtQLaA9+QAZmqBAqu6O1p6xp7SjO9TKKCHEK6+e2QRdZ4dJmfuhpdmarVA65ffeP1FQagM9iW4F4pJk39RMnIK4pdSxUOmICR", "동양피스톤");
            dicCompany.Add("gl5RnCm96RxdLYHJ0UGXgLy81zYPYHJAJX/6F/bkyhVKU3z6QqpOdhVexNEdxlI/jp6GjdUGss6+2XMECc0ItgFUAC807w5+UaSjQ+5F9FWYb1UBLEBTQhfLACAvYO+ZqScF/ck6FN6eCUgwSgklARpVu7ZMGKZcwJGli1x24bvpDsCM9PaHjoM09SaPs6aRkAGgnPAyODtUCXXKhrx03eXshCium+7lNaLOvH2OI/8gIuaRcs7q2tAwcl57t9We", "동양피스톤_TEST");
            dicCompany.Add("gl5RnCm96RxdLYHJ0UGXgLy81zYPYHJAJX/6F/bkyhVKU3z6QqpOdhVexNEdxlI/jp6GjdUGss6+2XMECc0ItgFUAC807w5+UaSjQ+5F9FWYb1UBLEBTQhfLACAvYO+Zg9P10MaSePgTCFNlH5xEgseqV104HSp8RlIKRmVNFIiCFYW3EG7LCUsNbWusAZdM/TEg3KGQzQT3HQpw0QDi1mFO87lPc/qIxCcwSCnbawM=", "이온폴리스_TEST");
            dicCompany.Add("gl5RnCm96RxdLYHJ0UGXgLy81zYPYHJAJX/6F/bkyhVKU3z6QqpOdhVexNEdxlI/jp6GjdUGss6+2XMECc0ItgFUAC807w5+UaSjQ+5F9FWYb1UBLEBTQhfLACAvYO+ZXFrVkK7UUF6GXBXqA6MOVKSMjj8Y+mj0p6QvmzSjv1/gowsGeAUWNE0PHj3A2YpSkpw/yjSaLXHTxhMZ8ceHkLjSDD02qM2UQ2uQWNI6JRk=", "엘림 TEST");
            dicCompany.Add("gl5RnCm96RxdLYHJ0UGXgLy81zYPYHJAJX/6F/bkyhVKU3z6QqpOdhVexNEdxlI/jp6GjdUGss6+2XMECc0ItgFUAC807w5+UaSjQ+5F9FWYb1UBLEBTQhfLACAvYO+ZBY5aSxnh5lvfA2oByfSeR2H4Zhe9e8c76+WaU3dcHsStiX9dXJluQ4f3M63xUbD6hZFjLdjvdUCFJu6/jaGWY5xBvOd8/ODlQ8ApJIAWGiU=", "카페니즈 TEST");
            dicCompany.Add("gl5RnCm96RxdLYHJ0UGXgLy81zYPYHJAJX/6F/bkyhVKU3z6QqpOdhVexNEdxlI/jp6GjdUGss6+2XMECc0ItgFUAC807w5+UaSjQ+5F9FWYb1UBLEBTQhfLACAvYO+Z4fIWkbGlxT1XbjRYxIWQWo1RbTF+fXY05XgtLy0B1WcsI+Di1OD4Sytc6NTm8fzl7kjRjDBDBpi5dXzoCquRKHkfp8SoX0dU267blxmeuCE=", "단단 TEST");
            dicCompany.Add("gl5RnCm96RxdLYHJ0UGXgLy81zYPYHJAJX/6F/bkyhVKU3z6QqpOdhVexNEdxlI/jp6GjdUGss6+2XMECc0ItgFUAC807w5+UaSjQ+5F9FWYb1UBLEBTQhfLACAvYO+ZL9u+MOxWrlu7eHB4nLnTJrE1/tT4JxwNduSZ2dqO7KZhFN6jOHDcHrb7lTsTz9GUtwlmll0Bau2+cG5hPBhtu72Jljx9KCyNxf0RNV8AIGhLZE/6uRcfhWKS2yblCTGz", "화승테크_TEST");
            dicCompany.Add("gl5RnCm96RxdLYHJ0UGXgLy81zYPYHJAJX/6F/bkyhVKU3z6QqpOdhVexNEdxlI/jp6GjdUGss6+2XMECc0ItgFUAC807w5+UaSjQ+5F9FWYb1UBLEBTQhfLACAvYO+ZhuElT2zhMF1vgPTwqtWvgMQ2QK/T2yA/LgC0ytU5TkPWRrLS7PIE981jGbVNiVGU+1WCf+2WSTsxGsd2ivFCZiIKpA0o+Vu1ub4FTEuE6T4=", "다나와컴퓨터_TEST");
            dicCompany.Add("gl5RnCm96RxdLYHJ0UGXgC5LUghTiCA31a52+eLSw83CCluxXdNE6FgW/sKOtHAkH/UWto0vcpWlY7XRLrVhU57kpHR7mfSoCCvpk9w3C3MOWIMGuHDu+i+WecAk9F2BaictNFaAc0mHrH+86dOCRTipfkjopOuRsZUqw8SFHxyNW2UOcTqBN/ucUZihjVVT9utrQA6uoogO/NH1mNN991es6jogUmgz5rqUX5533AU=", "PLT_KAKAO");
            dicCompany.Add("gl5RnCm96RxdLYHJ0UGXgLy81zYPYHJAJX/6F/bkyhVKU3z6QqpOdhVexNEdxlI/jp6GjdUGss6+2XMECc0ItgFUAC807w5+UaSjQ+5F9FWYb1UBLEBTQhfLACAvYO+ZE4brSbZd7yyNwpbV2h2wPg3CNkbCKnHPr/LAlcZsoxQ5FmwHTgdqfmgDftevxGXjJWBWSh3yAOOKI7W8JVekIIK3U1fZH7cD9tE1gJ5Gg6E=", "TEST");
            dicCompany.Add("gl5RnCm96RxdLYHJ0UGXgC5LUghTiCA31a52+eLSw83CCluxXdNE6FgW/sKOtHAkH/UWto0vcpWlY7XRLrVhU57kpHR7mfSoCCvpk9w3C3N3rMoovpFNH6W3rBmGT61NonAVIIfX6ytv/wkhsRbmXxY4fr2Hx15ADBsaQKY7wFAxnmU32lvdBXBv8QyHoqAkFPRcg+sC2UY1cOS8ZUJUXxqr727jfLo/exeoLtdYW64=", "TEST_KAKAO");
            
            cboCompany.DisplayMember = "Value";
            cboCompany.ValueMember = "Key";
            cboCompany.DataSource = new BindingSource(dicCompany, null);

            string sConStr = CModule.GetAppSetting(CModule.sConnectionString, CModule.sDefualtConnectString);
            txtConnect.Text = sConStr.Trim();
			cboCompany.SelectedValue = sConStr;

            if (cboCompany.SelectedValue == null)
            {
                dicCompany.Add(sConStr, CModule.GetAppSetting("DBConnectionName") );
                cboCompany.DataSource = new BindingSource(dicCompany, null);

                txtConnect.Text = sConStr.Trim();
                cboCompany.SelectedValue = sConStr;
            }
            #else
            cboCompany.Visible = false;
            txtConnect.Text = CModule.GetAppSetting(CModule.sConnectionString, CModule.sDefualtConnectString);
            #endif
        }

        private void btnTest_Click(object sender, EventArgs e)
		{
			try
			{
				btnTest.Enabled = false;
				btnSave.Enabled = false;
				string connectionString = Common.DecryptString(txtConnect.Text.Trim());
				SqlConnection sqlConnection = new SqlConnection(connectionString);
				sqlConnection.Open();
				sqlConnection.Close();
				_msg.Exe_MessageForm("Connection Successful.", MessageBoxButtons.OK, "");
				_msg.ShowDialog();
			}
			catch (Exception ex)
			{
				_msg.Exe_MessageForm(ex.Message, MessageBoxButtons.OK, "");
				_msg.ShowDialog();
			}
			finally
			{
				btnTest.Enabled = true;
				btnSave.Enabled = true;
			}
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			try
			{
				btnTest.Enabled = false;
				btnSave.Enabled = false;
				string connectionString = txtConnect.Text.Trim();

                Cmmn.CModule.SetAppSetting(Cmmn.CModule.sConnectionString, connectionString);
				
                _msg.Exe_MessageForm("Save Complete.", MessageBoxButtons.OK, "");
				_msg.ShowDialog();
				Application.Restart();
			}
			catch (Exception ex)
			{
				_msg.Exe_MessageForm(ex.Message, MessageBoxButtons.OK, "");
				_msg.ShowDialog();
			}
			finally
			{
				btnTest.Enabled = true;
				btnSave.Enabled = true;
			}
		}

		private void btnExit_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
		}

		private void Initialization()
		{
			btnTest.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_ZZ0020_000");
			btnSave.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_ZZ0020_001");
			btnExit.BackgroundImage = (Image)Cmmn.Properties.Resources.ResourceManager.GetObject(Common.gsLayout + "_ZZ0020_002");
			btnTest.BackgroundImageLayout = ImageLayout.Stretch;
			btnSave.BackgroundImageLayout = ImageLayout.Stretch;
			btnExit.BackgroundImageLayout = ImageLayout.Stretch;
			FormInformation = new FormInfor("NEXDAS", base.Name, Common.gsLanguege);
			FormInformation.ManageForm(this);
			Color backColor = default(Color);
			switch (Common.gsLayout)
			{
			case "BU":
				txtConnect.BackColor = Color.FromArgb(200, 230, 255);
				backColor = Color.FromArgb(1, 174, 240);
				break;
			case "RD":
				txtConnect.BackColor = Color.FromArgb(248, 202, 191);
				backColor = Color.FromArgb(163, 37, 14);
				break;
			case "BL":
				txtConnect.BackColor = Color.FromArgb(197, 197, 197);
				backColor = Color.FromArgb(44, 44, 44);
				break;
			}
			lblLine_01.BackColor = backColor;
			btnTest.BackColor = backColor;
			btnSave.BackColor = backColor;
			btnExit.BackColor = backColor;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZZ0020));
            this.grbSetting = new System.Windows.Forms.GroupBox();
            this.zLabel1 = new Cmmn.zLabel();
            this.cboCompany = new System.Windows.Forms.ComboBox();
            this.txtConnect = new System.Windows.Forms.TextBox();
            this.tlpButton = new System.Windows.Forms.TableLayoutPanel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.lblLine_01 = new Cmmn.zLabel();
            this.grbSetting.SuspendLayout();
            this.tlpButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbSetting
            // 
            this.grbSetting.Controls.Add(this.zLabel1);
            this.grbSetting.Controls.Add(this.cboCompany);
            this.grbSetting.Controls.Add(this.txtConnect);
            this.grbSetting.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.grbSetting.Location = new System.Drawing.Point(5, 5);
            this.grbSetting.Margin = new System.Windows.Forms.Padding(0);
            this.grbSetting.Name = "grbSetting";
            this.grbSetting.Padding = new System.Windows.Forms.Padding(0);
            this.grbSetting.Size = new System.Drawing.Size(332, 250);
            this.grbSetting.TabIndex = 26;
            this.grbSetting.TabStop = false;
            this.grbSetting.Text = "Database-Information Setting";
            // 
            // zLabel1
            // 
            this.zLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(175)))), ((int)(((byte)(255)))));
            this.zLabel1.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.zLabel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.zLabel1.ColorContent = System.Drawing.Color.Transparent;
            this.zLabel1.ColorLabel = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(175)))), ((int)(((byte)(255)))));
            this.zLabel1.ColorReadOnly = System.Drawing.Color.Transparent;
            this.zLabel1.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.zLabel1.ForeColor = System.Drawing.Color.White;
            this.zLabel1.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.zLabel1.Location = new System.Drawing.Point(9, 28);
            this.zLabel1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.zLabel1.MoveControl = null;
            this.zLabel1.Name = "zLabel1";
            this.zLabel1.Size = new System.Drawing.Size(109, 24);
            this.zLabel1.TabIndex = 1020;
            this.zLabel1.Text = "Company";
            this.zLabel1.TextHAlign = Infragistics.Win.HAlign.Center;
            this.zLabel1.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.zLabel1.DoubleClick += new System.EventHandler(this.zLabel1_DoubleClick);
            // 
            // cboCompany
            // 
            this.cboCompany.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.cboCompany.FormattingEnabled = true;
            this.cboCompany.Location = new System.Drawing.Point(123, 25);
            this.cboCompany.Margin = new System.Windows.Forms.Padding(0);
            this.cboCompany.Name = "cboCompany";
            this.cboCompany.Size = new System.Drawing.Size(200, 27);
            this.cboCompany.TabIndex = 1019;
            this.cboCompany.SelectedValueChanged += new System.EventHandler(this.cboCompany_SelectedValueChanged);
            // 
            // txtConnect
            // 
            this.txtConnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.txtConnect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConnect.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtConnect.ForeColor = System.Drawing.Color.Black;
            this.txtConnect.Location = new System.Drawing.Point(9, 67);
            this.txtConnect.Margin = new System.Windows.Forms.Padding(0);
            this.txtConnect.Multiline = true;
            this.txtConnect.Name = "txtConnect";
            this.txtConnect.Size = new System.Drawing.Size(314, 173);
            this.txtConnect.TabIndex = 26;
            // 
            // tlpButton
            // 
            this.tlpButton.BackColor = System.Drawing.Color.Transparent;
            this.tlpButton.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetPartial;
            this.tlpButton.ColumnCount = 3;
            this.tlpButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpButton.Controls.Add(this.btnExit, 2, 0);
            this.tlpButton.Controls.Add(this.btnSave, 1, 0);
            this.tlpButton.Controls.Add(this.btnTest, 0, 0);
            this.tlpButton.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tlpButton.Location = new System.Drawing.Point(5, 267);
            this.tlpButton.Margin = new System.Windows.Forms.Padding(0);
            this.tlpButton.Name = "tlpButton";
            this.tlpButton.RowCount = 1;
            this.tlpButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpButton.Size = new System.Drawing.Size(332, 75);
            this.tlpButton.TabIndex = 1020;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(175)))), ((int)(((byte)(255)))));
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Location = new System.Drawing.Point(221, 3);
            this.btnExit.Margin = new System.Windows.Forms.Padding(0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(108, 69);
            this.btnExit.TabIndex = 7;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(175)))), ((int)(((byte)(255)))));
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(112, 3);
            this.btnSave.Margin = new System.Windows.Forms.Padding(0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(106, 69);
            this.btnSave.TabIndex = 6;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnTest
            // 
            this.btnTest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(175)))), ((int)(((byte)(255)))));
            this.btnTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTest.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnTest.FlatAppearance.BorderSize = 0;
            this.btnTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTest.Location = new System.Drawing.Point(3, 3);
            this.btnTest.Margin = new System.Windows.Forms.Padding(0);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(106, 69);
            this.btnTest.TabIndex = 5;
            this.btnTest.UseVisualStyleBackColor = false;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // lblLine_01
            // 
            this.lblLine_01.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.lblLine_01.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            this.lblLine_01.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblLine_01.ColorContent = System.Drawing.Color.Empty;
            this.lblLine_01.ColorLabel = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.lblLine_01.ColorReadOnly = System.Drawing.Color.Empty;
            this.lblLine_01.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLine_01.ForeColor = System.Drawing.Color.Black;
            this.lblLine_01.LabelType = Cmmn.zLabel.LabelTypeEnum.Label;
            this.lblLine_01.Location = new System.Drawing.Point(5, 260);
            this.lblLine_01.Margin = new System.Windows.Forms.Padding(0);
            this.lblLine_01.MoveControl = null;
            this.lblLine_01.Name = "lblLine_01";
            this.lblLine_01.Size = new System.Drawing.Size(332, 2);
            this.lblLine_01.TabIndex = 1019;
            this.lblLine_01.TextHAlign = Infragistics.Win.HAlign.Center;
            this.lblLine_01.TextVAlign = Infragistics.Win.VAlign.Middle;
            // 
            // ZZ0020
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(344, 344);
            this.ControlBox = false;
            this.Controls.Add(this.tlpButton);
            this.Controls.Add(this.lblLine_01);
            this.Controls.Add(this.grbSetting);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ZZ0020";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.ZZ0020_Load);
            this.grbSetting.ResumeLayout(false);
            this.grbSetting.PerformLayout();
            this.tlpButton.ResumeLayout(false);
            this.ResumeLayout(false);

		}

        private void cboCompany_SelectedValueChanged(object sender, EventArgs e)
        {
            txtConnect.Text = CModule.ToString(cboCompany.SelectedValue);
        }

        private void zLabel1_DoubleClick(object sender, EventArgs e)
        {
            DBForm dbform = new DBForm(CModule.ToString(cboCompany.SelectedValue), CModule.ToString(cboCompany.Text));
            dbform.ShowDialog();
        }
    }
}
