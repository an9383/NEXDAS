using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using Telerik.Reporting;
using Telerik.Reporting.Drawing;

namespace Cmmn
{
	public class DA3300R : Report
	{
		private DetailSection detail;

		private TextBox textBox16;

		private TextBox textBox17;

		private TextBox textBox18;

		private TextBox textBox19;

		private TextBox textBox20;

		private TextBox textBox21;

		private TextBox textBox22;

		private TextBox textBox23;

		private TextBox textBox24;

		private TextBox textBox25;

		private TextBox textBox26;

		private TextBox textBox27;

		private TextBox textBox28;

		private TextBox textBox29;

		private TextBox textBox30;

		private Barcode barcode2;

		private TextBox textBox1;

		private TextBox textBox2;

		private TextBox textBox3;

		private TextBox textBox4;

		private TextBox textBox5;

		private TextBox textBox6;

		private TextBox textBox7;

		private TextBox textBox8;

		private TextBox textBox9;

		private TextBox textBox10;

		private TextBox textBox11;

		private TextBox textBox12;

		private TextBox textBox13;

		private TextBox textBox14;

		private TextBox textBox15;

		private Barcode barcode1;

		private TextBox textBox31;

		private TextBox textBox32;

		private TextBox textBox33;

		private TextBox textBox34;

		private TextBox textBox35;

		private TextBox textBox36;

		private TextBox textBox37;

		private TextBox textBox38;

		private TextBox textBox39;

		private TextBox textBox40;

		private TextBox textBox41;

		private TextBox textBox42;

		private TextBox textBox43;

		private TextBox textBox44;

		private TextBox textBox45;

		private Barcode barcode3;

		private TextBox textBox46;

		private TextBox textBox47;

		private TextBox textBox48;

		private TextBox textBox49;

		private TextBox textBox50;

		private TextBox textBox51;

		private TextBox textBox52;

		private TextBox textBox53;

		private TextBox textBox54;

		private TextBox textBox55;

		private TextBox textBox56;

		private TextBox textBox57;

		private TextBox textBox58;

		private TextBox textBox59;

		private TextBox textBox60;

		private Barcode barcode4;

		private TextBox textBox61;

		private TextBox textBox62;

		private TextBox textBox63;

		private TextBox textBox64;

		private TextBox textBox65;

		private TextBox textBox66;

		private TextBox textBox67;

		private TextBox textBox68;

		private TextBox textBox69;

		private TextBox textBox70;

		private TextBox textBox71;

		private TextBox textBox72;

		private TextBox textBox73;

		private TextBox textBox74;

		private TextBox textBox75;

		private Barcode barcode5;

		private TextBox textBox76;

		private TextBox textBox77;

		private TextBox textBox78;

		private TextBox textBox79;

		private TextBox textBox80;

		private TextBox textBox81;

		private TextBox textBox82;

		private TextBox textBox83;

		private TextBox textBox84;

		private TextBox textBox85;

		private TextBox textBox86;

		private TextBox textBox87;

		private TextBox textBox88;

		private TextBox textBox89;

		private TextBox textBox90;

		private Barcode barcode6;

		private TextBox textBox91;

		private TextBox textBox92;

		private TextBox textBox93;

		private TextBox textBox94;

		private TextBox textBox95;

		private TextBox textBox96;

		private TextBox textBox97;

		private TextBox textBox98;

		private TextBox textBox99;

		private TextBox textBox100;

		private TextBox textBox101;

		private TextBox textBox102;

		private TextBox textBox103;

		private TextBox textBox104;

		private TextBox textBox105;

		private Barcode barcode7;

		private TextBox textBox106;

		private TextBox textBox107;

		private TextBox textBox108;

		private TextBox textBox109;

		private TextBox textBox110;

		private TextBox textBox111;

		private TextBox textBox112;

		private TextBox textBox113;

		private TextBox textBox114;

		private TextBox textBox115;

		private TextBox textBox116;

		private TextBox textBox117;

		private TextBox textBox118;

		private TextBox textBox119;

		private TextBox textBox120;

		private Barcode barcode8;

		public PictureBox pictureBox1;

		public PictureBox pictureBox2;

		public PictureBox pictureBox3;

		public PictureBox pictureBox5;

		public PictureBox pictureBox7;

		public PictureBox pictureBox4;

		public PictureBox pictureBox6;

		public PictureBox pictureBox8;

		private Panel panel2;

		private Panel panel1;

		private Panel panel3;

		private Panel panel4;

		private Panel panel5;

		private Panel panel6;

		private Panel panel7;

		private Panel panel8;

		public DA3300R()
		{
			InitializeComponent();
			pictureBox1.Value = null;
			pictureBox2.Value = null;
			pictureBox3.Value = null;
			pictureBox4.Value = null;
			pictureBox5.Value = null;
			pictureBox6.Value = null;
			pictureBox7.Value = null;
			pictureBox8.Value = null;
		}

		private void InitializeComponent()
		{
			StyleRule styleRule = new StyleRule();
			detail = new DetailSection();
			panel2 = new Panel();
			textBox16 = new TextBox();
			textBox17 = new TextBox();
			textBox18 = new TextBox();
			textBox19 = new TextBox();
			textBox20 = new TextBox();
			textBox21 = new TextBox();
			textBox22 = new TextBox();
			textBox23 = new TextBox();
			textBox24 = new TextBox();
			textBox25 = new TextBox();
			textBox26 = new TextBox();
			textBox27 = new TextBox();
			textBox28 = new TextBox();
			textBox29 = new TextBox();
			textBox30 = new TextBox();
			barcode2 = new Barcode();
			pictureBox1 = new PictureBox();
			panel1 = new Panel();
			textBox1 = new TextBox();
			textBox2 = new TextBox();
			textBox3 = new TextBox();
			textBox4 = new TextBox();
			textBox5 = new TextBox();
			textBox6 = new TextBox();
			textBox7 = new TextBox();
			textBox8 = new TextBox();
			textBox9 = new TextBox();
			textBox10 = new TextBox();
			textBox11 = new TextBox();
			textBox12 = new TextBox();
			textBox13 = new TextBox();
			textBox14 = new TextBox();
			textBox15 = new TextBox();
			barcode1 = new Barcode();
			pictureBox2 = new PictureBox();
			panel3 = new Panel();
			textBox31 = new TextBox();
			textBox32 = new TextBox();
			textBox33 = new TextBox();
			textBox34 = new TextBox();
			textBox35 = new TextBox();
			textBox36 = new TextBox();
			textBox37 = new TextBox();
			textBox38 = new TextBox();
			textBox39 = new TextBox();
			textBox40 = new TextBox();
			textBox41 = new TextBox();
			textBox42 = new TextBox();
			textBox43 = new TextBox();
			textBox44 = new TextBox();
			textBox45 = new TextBox();
			barcode3 = new Barcode();
			pictureBox3 = new PictureBox();
			panel4 = new Panel();
			textBox46 = new TextBox();
			textBox47 = new TextBox();
			textBox48 = new TextBox();
			textBox49 = new TextBox();
			textBox50 = new TextBox();
			textBox51 = new TextBox();
			textBox52 = new TextBox();
			textBox53 = new TextBox();
			textBox54 = new TextBox();
			textBox55 = new TextBox();
			textBox56 = new TextBox();
			textBox57 = new TextBox();
			textBox58 = new TextBox();
			textBox59 = new TextBox();
			textBox60 = new TextBox();
			barcode4 = new Barcode();
			pictureBox5 = new PictureBox();
			panel5 = new Panel();
			textBox61 = new TextBox();
			textBox62 = new TextBox();
			textBox63 = new TextBox();
			textBox64 = new TextBox();
			textBox65 = new TextBox();
			textBox66 = new TextBox();
			textBox67 = new TextBox();
			textBox68 = new TextBox();
			textBox69 = new TextBox();
			textBox70 = new TextBox();
			textBox71 = new TextBox();
			textBox72 = new TextBox();
			textBox73 = new TextBox();
			textBox74 = new TextBox();
			textBox75 = new TextBox();
			barcode5 = new Barcode();
			pictureBox7 = new PictureBox();
			panel6 = new Panel();
			textBox76 = new TextBox();
			textBox77 = new TextBox();
			textBox78 = new TextBox();
			textBox79 = new TextBox();
			textBox80 = new TextBox();
			textBox81 = new TextBox();
			textBox82 = new TextBox();
			textBox83 = new TextBox();
			textBox84 = new TextBox();
			textBox85 = new TextBox();
			textBox86 = new TextBox();
			textBox87 = new TextBox();
			textBox88 = new TextBox();
			textBox89 = new TextBox();
			textBox90 = new TextBox();
			barcode6 = new Barcode();
			pictureBox4 = new PictureBox();
			panel7 = new Panel();
			textBox91 = new TextBox();
			textBox92 = new TextBox();
			textBox93 = new TextBox();
			textBox94 = new TextBox();
			textBox95 = new TextBox();
			textBox96 = new TextBox();
			textBox97 = new TextBox();
			textBox98 = new TextBox();
			textBox99 = new TextBox();
			textBox100 = new TextBox();
			textBox101 = new TextBox();
			textBox102 = new TextBox();
			textBox103 = new TextBox();
			textBox104 = new TextBox();
			textBox105 = new TextBox();
			barcode7 = new Barcode();
			pictureBox6 = new PictureBox();
			panel8 = new Panel();
			textBox106 = new TextBox();
			textBox107 = new TextBox();
			textBox108 = new TextBox();
			textBox109 = new TextBox();
			textBox110 = new TextBox();
			textBox111 = new TextBox();
			textBox112 = new TextBox();
			textBox113 = new TextBox();
			textBox114 = new TextBox();
			textBox115 = new TextBox();
			textBox116 = new TextBox();
			textBox117 = new TextBox();
			textBox118 = new TextBox();
			textBox119 = new TextBox();
			textBox120 = new TextBox();
			barcode8 = new Barcode();
			pictureBox8 = new PictureBox();
			((ISupportInitialize)this).BeginInit();
			detail.Height = Unit.Cm(29.0);
			detail.Items.AddRange(new ReportItemBase[8]
			{
				panel2,
				panel1,
				panel3,
				panel4,
				panel5,
				panel6,
				panel7,
				panel8
			});
			detail.Name = "detail";
			detail.Style.BorderStyle.Default = BorderType.Solid;
			detail.Style.BorderWidth.Default = Unit.Point(0.5);
			panel2.Items.AddRange(new ReportItemBase[17]
			{
				textBox16,
				textBox17,
				textBox18,
				textBox19,
				textBox20,
				textBox21,
				textBox22,
				textBox23,
				textBox24,
				textBox25,
				textBox26,
				textBox27,
				textBox28,
				textBox29,
				textBox30,
				barcode2,
				pictureBox1
			});
			panel2.Location = new PointU(Unit.Cm(0.49999994039535522), Unit.Cm(0.099999949336051941));
			panel2.Name = "panel2";
			panel2.Size = new SizeU(Unit.Cm(9.80000114440918), Unit.Cm(6.5));
			panel2.Style.BorderStyle.Default = BorderType.Solid;
			panel2.Style.BorderWidth.Default = Unit.Point(1.0);
			textBox16.Location = new PointU(Unit.Cm(0.00010032494901679456), Unit.Cm(0.00010012308484874666));
			textBox16.Name = "textBox16";
			textBox16.Size = new SizeU(Unit.Cm(5.9997997283935547), Unit.Cm(1.1998000144958496));
			textBox16.Style.BackgroundColor = Color.White;
			textBox16.Style.BorderStyle.Default = BorderType.Solid;
			textBox16.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox16.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox16.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox16.Style.BorderWidth.Top = Unit.Point(1.0);
			textBox16.Style.Font.Bold = true;
			textBox16.Style.Font.Name = "맑은 고딕";
			textBox16.Style.Font.Size = Unit.Point(20.0);
			textBox16.Style.TextAlign = HorizontalAlign.Center;
			textBox16.Style.VerticalAlign = VerticalAlign.Middle;
			textBox16.Value = "부 품 식 별 표";
			textBox17.Location = new PointU(Unit.Cm(5.9998998641967773), Unit.Cm(0.0));
			textBox17.Name = "textBox17";
			textBox17.Size = new SizeU(Unit.Cm(3.800100564956665), Unit.Cm(1.1999003887176514));
			textBox17.Style.BackgroundColor = Color.White;
			textBox17.Style.BorderStyle.Bottom = BorderType.None;
			textBox17.Style.BorderStyle.Default = BorderType.Solid;
			textBox17.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox17.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox17.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox17.Style.BorderWidth.Right = Unit.Point(1.0);
			textBox17.Style.BorderWidth.Top = Unit.Point(1.0);
			textBox17.Style.Font.Bold = true;
			textBox17.Style.Font.Name = "맑은 고딕";
			textBox17.Style.Font.Size = Unit.Point(16.0);
			textBox17.Style.Padding.Left = Unit.Cm(0.0);
			textBox17.Style.Padding.Right = Unit.Cm(0.0);
			textBox17.Style.TextAlign = HorizontalAlign.Center;
			textBox17.Style.VerticalAlign = VerticalAlign.Middle;
			textBox17.Value = "(주)제이에스디";
			textBox18.Location = new PointU(Unit.Cm(0.0), Unit.Cm(1.200100302696228));
			textBox18.Name = "textBox18";
			textBox18.Size = new SizeU(Unit.Cm(1.9998998641967773), Unit.Cm(0.800000011920929));
			textBox18.Style.BackgroundColor = Color.White;
			textBox18.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox18.Style.BorderStyle.Default = BorderType.Solid;
			textBox18.Style.BorderStyle.Top = BorderType.None;
			textBox18.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox18.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox18.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox18.Style.Font.Bold = true;
			textBox18.Style.Font.Name = "맑은 고딕";
			textBox18.Style.Font.Size = Unit.Point(11.0);
			textBox18.Style.TextAlign = HorizontalAlign.Center;
			textBox18.Style.VerticalAlign = VerticalAlign.Middle;
			textBox18.Value = "차     종";
			textBox19.Location = new PointU(Unit.Cm(0.0), Unit.Cm(2.8005001544952393));
			textBox19.Name = "textBox19";
			textBox19.Size = new SizeU(Unit.Cm(1.9998998641967773), Unit.Cm(0.800000011920929));
			textBox19.Style.BackgroundColor = Color.White;
			textBox19.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox19.Style.BorderStyle.Default = BorderType.Solid;
			textBox19.Style.BorderStyle.Top = BorderType.None;
			textBox19.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox19.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox19.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox19.Style.Font.Bold = true;
			textBox19.Style.Font.Name = "맑은 고딕";
			textBox19.Style.Font.Size = Unit.Point(11.0);
			textBox19.Style.TextAlign = HorizontalAlign.Center;
			textBox19.Style.VerticalAlign = VerticalAlign.Middle;
			textBox19.Value = "품     명";
			textBox20.Location = new PointU(Unit.Cm(0.0), Unit.Cm(3.6007006168365479));
			textBox20.Name = "textBox20";
			textBox20.Size = new SizeU(Unit.Cm(1.9998998641967773), Unit.Cm(0.800000011920929));
			textBox20.Style.BackgroundColor = Color.White;
			textBox20.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox20.Style.BorderStyle.Default = BorderType.Solid;
			textBox20.Style.BorderStyle.Top = BorderType.None;
			textBox20.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox20.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox20.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox20.Style.Font.Bold = true;
			textBox20.Style.Font.Name = "맑은 고딕";
			textBox20.Style.Font.Size = Unit.Point(11.0);
			textBox20.Style.TextAlign = HorizontalAlign.Center;
			textBox20.Style.VerticalAlign = VerticalAlign.Middle;
			textBox20.Value = "생산수량";
			textBox21.Location = new PointU(Unit.Cm(0.0), Unit.Cm(4.4009013175964355));
			textBox21.Name = "textBox21";
			textBox21.Size = new SizeU(Unit.Cm(1.9998998641967773), Unit.Cm(0.800000011920929));
			textBox21.Style.BackgroundColor = Color.White;
			textBox21.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox21.Style.BorderStyle.Default = BorderType.Solid;
			textBox21.Style.BorderStyle.Top = BorderType.None;
			textBox21.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox21.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox21.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox21.Style.Font.Bold = true;
			textBox21.Style.Font.Name = "맑은 고딕";
			textBox21.Style.Font.Size = Unit.Point(11.0);
			textBox21.Style.TextAlign = HorizontalAlign.Center;
			textBox21.Style.VerticalAlign = VerticalAlign.Middle;
			textBox21.Value = "생산일자";
			textBox22.Location = new PointU(Unit.Cm(0.0), Unit.Cm(5.2011017799377441));
			textBox22.Name = "textBox22";
			textBox22.Size = new SizeU(Unit.Cm(1.9998998641967773), Unit.Cm(1.2987978458404541));
			textBox22.Style.BackgroundColor = Color.White;
			textBox22.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox22.Style.BorderStyle.Default = BorderType.Solid;
			textBox22.Style.BorderStyle.Right = BorderType.Solid;
			textBox22.Style.BorderStyle.Top = BorderType.None;
			textBox22.Style.BorderWidth.Bottom = Unit.Point(1.0);
			textBox22.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox22.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox22.Style.Font.Bold = true;
			textBox22.Style.Font.Name = "맑은 고딕";
			textBox22.Style.Font.Size = Unit.Point(11.0);
			textBox22.Style.TextAlign = HorizontalAlign.Center;
			textBox22.Style.VerticalAlign = VerticalAlign.Middle;
			textBox22.Value = "LOT NO.";
			textBox23.Location = new PointU(Unit.Cm(0.00010032494901679456), Unit.Cm(2.000300407409668));
			textBox23.Name = "textBox23";
			textBox23.Size = new SizeU(Unit.Cm(1.9998998641967773), Unit.Cm(0.800000011920929));
			textBox23.Style.BackgroundColor = Color.White;
			textBox23.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox23.Style.BorderStyle.Default = BorderType.Solid;
			textBox23.Style.BorderStyle.Top = BorderType.None;
			textBox23.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox23.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox23.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox23.Style.Font.Bold = true;
			textBox23.Style.Font.Name = "맑은 고딕";
			textBox23.Style.Font.Size = Unit.Point(11.0);
			textBox23.Style.TextAlign = HorizontalAlign.Center;
			textBox23.Style.VerticalAlign = VerticalAlign.Middle;
			textBox23.Value = "품     번";
			textBox24.Bindings.Add(new Binding("Value", "=Fields.CARTYPE1"));
			textBox24.Location = new PointU(Unit.Cm(2.0000998973846436), Unit.Cm(1.2001000642776489));
			textBox24.Name = "textBox24";
			textBox24.Size = new SizeU(Unit.Cm(3.9995999336242676), Unit.Cm(0.800000011920929));
			textBox24.Style.BackgroundColor = Color.White;
			textBox24.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox24.Style.BorderStyle.Default = BorderType.Solid;
			textBox24.Style.BorderStyle.Top = BorderType.None;
			textBox24.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox24.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox24.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox24.Style.Font.Bold = true;
			textBox24.Style.Font.Name = "맑은 고딕";
			textBox24.Style.Font.Size = Unit.Point(11.0);
			textBox24.Style.TextAlign = HorizontalAlign.Center;
			textBox24.Style.VerticalAlign = VerticalAlign.Middle;
			textBox24.Value = "";
			textBox25.Bindings.Add(new Binding("Value", "=Fields.ITEMCODE1"));
			textBox25.Location = new PointU(Unit.Cm(2.0001001358032227), Unit.Cm(2.0003006458282471));
			textBox25.Name = "textBox25";
			textBox25.Size = new SizeU(Unit.Cm(3.9995999336242676), Unit.Cm(0.800000011920929));
			textBox25.Style.BackgroundColor = Color.White;
			textBox25.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox25.Style.BorderStyle.Default = BorderType.Solid;
			textBox25.Style.BorderStyle.Top = BorderType.None;
			textBox25.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox25.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox25.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox25.Style.Font.Bold = true;
			textBox25.Style.Font.Name = "맑은 고딕";
			textBox25.Style.Font.Size = Unit.Point(11.0);
			textBox25.Style.TextAlign = HorizontalAlign.Center;
			textBox25.Style.VerticalAlign = VerticalAlign.Middle;
			textBox25.Value = "";
			textBox26.Bindings.Add(new Binding("Value", "=Fields.ITEMNAME1"));
			textBox26.Location = new PointU(Unit.Cm(2.0001001358032227), Unit.Cm(2.8005011081695557));
			textBox26.Name = "textBox26";
			textBox26.Size = new SizeU(Unit.Cm(3.9995999336242676), Unit.Cm(0.800000011920929));
			textBox26.Style.BackgroundColor = Color.White;
			textBox26.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox26.Style.BorderStyle.Default = BorderType.Solid;
			textBox26.Style.BorderStyle.Top = BorderType.Solid;
			textBox26.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox26.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox26.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox26.Style.Font.Bold = true;
			textBox26.Style.Font.Name = "맑은 고딕";
			textBox26.Style.Font.Size = Unit.Point(10.0);
			textBox26.Style.TextAlign = HorizontalAlign.Left;
			textBox26.Style.VerticalAlign = VerticalAlign.Middle;
			textBox26.Value = "";
			textBox27.Bindings.Add(new Binding("Value", "=Fields.QTY1"));
			textBox27.Location = new PointU(Unit.Cm(2.000300407409668), Unit.Cm(3.6007006168365479));
			textBox27.Name = "textBox27";
			textBox27.Size = new SizeU(Unit.Cm(2.9995996952056885), Unit.Cm(0.800000011920929));
			textBox27.Style.BackgroundColor = Color.White;
			textBox27.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox27.Style.BorderStyle.Default = BorderType.Solid;
			textBox27.Style.BorderStyle.Right = BorderType.None;
			textBox27.Style.BorderStyle.Top = BorderType.None;
			textBox27.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox27.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox27.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox27.Style.Font.Bold = true;
			textBox27.Style.Font.Name = "맑은 고딕";
			textBox27.Style.Font.Size = Unit.Point(11.0);
			textBox27.Style.TextAlign = HorizontalAlign.Center;
			textBox27.Style.VerticalAlign = VerticalAlign.Middle;
			textBox27.Value = "";
			textBox28.Bindings.Add(new Binding("Value", "=Fields.UNITCODE1"));
			textBox28.Location = new PointU(Unit.Cm(4.9999003410339355), Unit.Cm(3.6007015705108643));
			textBox28.Name = "textBox28";
			textBox28.Size = new SizeU(Unit.Cm(0.99980008602142334), Unit.Cm(0.800000011920929));
			textBox28.Style.BackgroundColor = Color.White;
			textBox28.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox28.Style.BorderStyle.Default = BorderType.Solid;
			textBox28.Style.BorderStyle.Left = BorderType.None;
			textBox28.Style.BorderStyle.Top = BorderType.None;
			textBox28.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox28.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox28.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox28.Style.Font.Bold = true;
			textBox28.Style.Font.Name = "맑은 고딕";
			textBox28.Style.Font.Size = Unit.Point(11.0);
			textBox28.Style.TextAlign = HorizontalAlign.Center;
			textBox28.Style.VerticalAlign = VerticalAlign.Middle;
			textBox28.Value = "";
			textBox29.Bindings.Add(new Binding("Value", "=Fields.PRODDATE1"));
			textBox29.Location = new PointU(Unit.Cm(2.0001001358032227), Unit.Cm(4.4009017944335938));
			textBox29.Name = "textBox29";
			textBox29.Size = new SizeU(Unit.Cm(4.9997997283935547), Unit.Cm(0.800000011920929));
			textBox29.Style.BackgroundColor = Color.White;
			textBox29.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox29.Style.BorderStyle.Default = BorderType.Solid;
			textBox29.Style.BorderStyle.Top = BorderType.None;
			textBox29.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox29.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox29.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox29.Style.Font.Bold = true;
			textBox29.Style.Font.Name = "맑은 고딕";
			textBox29.Style.Font.Size = Unit.Point(11.0);
			textBox29.Style.TextAlign = HorizontalAlign.Center;
			textBox29.Style.VerticalAlign = VerticalAlign.Middle;
			textBox29.Value = "";
			textBox30.Location = new PointU(Unit.Cm(7.0000996589660645), Unit.Cm(4.4009017944335938));
			textBox30.Name = "textBox30";
			textBox30.Size = new SizeU(Unit.Cm(1.0999007225036621), Unit.Cm(2.0989985466003418));
			textBox30.Style.BackgroundColor = Color.White;
			textBox30.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox30.Style.BorderStyle.Default = BorderType.Solid;
			textBox30.Style.BorderStyle.Left = BorderType.Solid;
			textBox30.Style.BorderStyle.Top = BorderType.None;
			textBox30.Style.BorderWidth.Bottom = Unit.Point(1.0);
			textBox30.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox30.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox30.Style.Font.Bold = true;
			textBox30.Style.Font.Name = "맑은 고딕";
			textBox30.Style.Font.Size = Unit.Point(11.0);
			textBox30.Style.TextAlign = HorizontalAlign.Center;
			textBox30.Style.VerticalAlign = VerticalAlign.Middle;
			textBox30.Value = "검\r\n사";
			barcode2.Bindings.Add(new Binding("Value", "=Fields.LOTNO1"));
			barcode2.Location = new PointU(Unit.Cm(1.9999990463256836), Unit.Cm(5.299799919128418));
			barcode2.Name = "barcode2";
			barcode2.ShowText = true;
			barcode2.Size = new SizeU(Unit.Cm(5.0), Unit.Cm(1.2000000476837158));
			barcode2.Stretch = true;
			barcode2.Style.BorderStyle.Default = BorderType.None;
			barcode2.Style.BorderWidth.Default = Unit.Point(0.5);
			barcode2.Style.Font.Name = "맑은 고딕";
			barcode2.Style.Font.Size = Unit.Point(8.0);
			barcode2.Style.TextAlign = HorizontalAlign.Center;
			barcode2.Style.VerticalAlign = VerticalAlign.Bottom;
			barcode2.Value = "C201704191147X00000129372392";
			pictureBox1.Location = new PointU(Unit.Cm(6.0001988410949707), Unit.Cm(1.2000999450683594));
			pictureBox1.MimeType = "";
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new SizeU(Unit.Cm(3.7998008728027344), Unit.Cm(3.2006008625030518));
			pictureBox1.Sizing = ImageSizeMode.Stretch;
			pictureBox1.Style.BackgroundImage.MimeType = "image/bmp";
			pictureBox1.Style.BackgroundImage.Repeat = BackgroundRepeat.NoRepeat;
			pictureBox1.Style.BorderStyle.Bottom = BorderType.Solid;
			pictureBox1.Style.BorderStyle.Top = BorderType.Solid;
			pictureBox1.Style.BorderWidth.Default = Unit.Point(0.5);
			pictureBox1.Value = "";
			panel1.Items.AddRange(new ReportItemBase[17]
			{
				textBox1,
				textBox2,
				textBox3,
				textBox4,
				textBox5,
				textBox6,
				textBox7,
				textBox8,
				textBox9,
				textBox10,
				textBox11,
				textBox12,
				textBox13,
				textBox14,
				textBox15,
				barcode1,
				pictureBox2
			});
			panel1.Location = new PointU(Unit.Cm(10.649999618530273), Unit.Cm(0.10000000149011612));
			panel1.Name = "panel1";
			panel1.Size = new SizeU(Unit.Cm(9.79990005493164), Unit.Cm(6.5));
			panel1.Style.BorderStyle.Default = BorderType.Solid;
			panel1.Style.BorderWidth.Default = Unit.Point(1.0);
			textBox1.Location = new PointU(Unit.Cm(0.00010032494901679456), Unit.Cm(0.00010012308484874666));
			textBox1.Name = "textBox1";
			textBox1.Size = new SizeU(Unit.Cm(5.9997997283935547), Unit.Cm(1.1998000144958496));
			textBox1.Style.BackgroundColor = Color.White;
			textBox1.Style.BorderStyle.Default = BorderType.Solid;
			textBox1.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox1.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox1.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox1.Style.BorderWidth.Top = Unit.Point(1.0);
			textBox1.Style.Font.Bold = true;
			textBox1.Style.Font.Name = "맑은 고딕";
			textBox1.Style.Font.Size = Unit.Point(20.0);
			textBox1.Style.TextAlign = HorizontalAlign.Center;
			textBox1.Style.VerticalAlign = VerticalAlign.Middle;
			textBox1.Value = "부 품 식 별 표";
			textBox2.Location = new PointU(Unit.Cm(5.9998998641967773), Unit.Cm(0.0));
			textBox2.Name = "textBox2";
			textBox2.Size = new SizeU(Unit.Cm(3.7999999523162842), Unit.Cm(1.2000000476837158));
			textBox2.Style.BackgroundColor = Color.White;
			textBox2.Style.BorderStyle.Bottom = BorderType.None;
			textBox2.Style.BorderStyle.Default = BorderType.Solid;
			textBox2.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox2.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox2.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox2.Style.BorderWidth.Right = Unit.Point(1.0);
			textBox2.Style.BorderWidth.Top = Unit.Point(1.0);
			textBox2.Style.Font.Bold = true;
			textBox2.Style.Font.Name = "맑은 고딕";
			textBox2.Style.Font.Size = Unit.Point(16.0);
			textBox2.Style.Padding.Left = Unit.Cm(0.0);
			textBox2.Style.Padding.Right = Unit.Cm(0.0);
			textBox2.Style.TextAlign = HorizontalAlign.Center;
			textBox2.Style.VerticalAlign = VerticalAlign.Middle;
			textBox2.Value = "(주)제이에스디";
			textBox3.Location = new PointU(Unit.Cm(0.0), Unit.Cm(1.200100302696228));
			textBox3.Name = "textBox3";
			textBox3.Size = new SizeU(Unit.Cm(1.9998998641967773), Unit.Cm(0.800000011920929));
			textBox3.Style.BackgroundColor = Color.White;
			textBox3.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox3.Style.BorderStyle.Default = BorderType.Solid;
			textBox3.Style.BorderStyle.Top = BorderType.None;
			textBox3.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox3.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox3.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox3.Style.Font.Bold = true;
			textBox3.Style.Font.Name = "맑은 고딕";
			textBox3.Style.Font.Size = Unit.Point(11.0);
			textBox3.Style.TextAlign = HorizontalAlign.Center;
			textBox3.Style.VerticalAlign = VerticalAlign.Middle;
			textBox3.Value = "차     종";
			textBox4.Location = new PointU(Unit.Cm(0.0), Unit.Cm(2.8005001544952393));
			textBox4.Name = "textBox4";
			textBox4.Size = new SizeU(Unit.Cm(1.9998998641967773), Unit.Cm(0.800000011920929));
			textBox4.Style.BackgroundColor = Color.White;
			textBox4.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox4.Style.BorderStyle.Default = BorderType.Solid;
			textBox4.Style.BorderStyle.Top = BorderType.None;
			textBox4.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox4.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox4.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox4.Style.Font.Bold = true;
			textBox4.Style.Font.Name = "맑은 고딕";
			textBox4.Style.Font.Size = Unit.Point(11.0);
			textBox4.Style.TextAlign = HorizontalAlign.Center;
			textBox4.Style.VerticalAlign = VerticalAlign.Middle;
			textBox4.Value = "품     명";
			textBox5.Location = new PointU(Unit.Cm(0.0), Unit.Cm(3.6007006168365479));
			textBox5.Name = "textBox5";
			textBox5.Size = new SizeU(Unit.Cm(1.9998998641967773), Unit.Cm(0.800000011920929));
			textBox5.Style.BackgroundColor = Color.White;
			textBox5.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox5.Style.BorderStyle.Default = BorderType.Solid;
			textBox5.Style.BorderStyle.Top = BorderType.None;
			textBox5.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox5.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox5.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox5.Style.Font.Bold = true;
			textBox5.Style.Font.Name = "맑은 고딕";
			textBox5.Style.Font.Size = Unit.Point(11.0);
			textBox5.Style.TextAlign = HorizontalAlign.Center;
			textBox5.Style.VerticalAlign = VerticalAlign.Middle;
			textBox5.Value = "생산수량";
			textBox6.Location = new PointU(Unit.Cm(0.0), Unit.Cm(4.4009013175964355));
			textBox6.Name = "textBox6";
			textBox6.Size = new SizeU(Unit.Cm(1.9998998641967773), Unit.Cm(0.800000011920929));
			textBox6.Style.BackgroundColor = Color.White;
			textBox6.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox6.Style.BorderStyle.Default = BorderType.Solid;
			textBox6.Style.BorderStyle.Top = BorderType.None;
			textBox6.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox6.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox6.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox6.Style.Font.Bold = true;
			textBox6.Style.Font.Name = "맑은 고딕";
			textBox6.Style.Font.Size = Unit.Point(11.0);
			textBox6.Style.TextAlign = HorizontalAlign.Center;
			textBox6.Style.VerticalAlign = VerticalAlign.Middle;
			textBox6.Value = "생산일자";
			textBox7.Location = new PointU(Unit.Cm(0.0), Unit.Cm(5.2011017799377441));
			textBox7.Name = "textBox7";
			textBox7.Size = new SizeU(Unit.Cm(1.9998998641967773), Unit.Cm(1.2987978458404541));
			textBox7.Style.BackgroundColor = Color.White;
			textBox7.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox7.Style.BorderStyle.Default = BorderType.Solid;
			textBox7.Style.BorderStyle.Right = BorderType.Solid;
			textBox7.Style.BorderStyle.Top = BorderType.None;
			textBox7.Style.BorderWidth.Bottom = Unit.Point(1.0);
			textBox7.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox7.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox7.Style.Font.Bold = true;
			textBox7.Style.Font.Name = "맑은 고딕";
			textBox7.Style.Font.Size = Unit.Point(11.0);
			textBox7.Style.TextAlign = HorizontalAlign.Center;
			textBox7.Style.VerticalAlign = VerticalAlign.Middle;
			textBox7.Value = "LOT NO.";
			textBox8.Location = new PointU(Unit.Cm(0.00010032494901679456), Unit.Cm(2.000300407409668));
			textBox8.Name = "textBox8";
			textBox8.Size = new SizeU(Unit.Cm(1.9998998641967773), Unit.Cm(0.800000011920929));
			textBox8.Style.BackgroundColor = Color.White;
			textBox8.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox8.Style.BorderStyle.Default = BorderType.Solid;
			textBox8.Style.BorderStyle.Top = BorderType.None;
			textBox8.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox8.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox8.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox8.Style.Font.Bold = true;
			textBox8.Style.Font.Name = "맑은 고딕";
			textBox8.Style.Font.Size = Unit.Point(11.0);
			textBox8.Style.TextAlign = HorizontalAlign.Center;
			textBox8.Style.VerticalAlign = VerticalAlign.Middle;
			textBox8.Value = "품     번";
			textBox9.Bindings.Add(new Binding("Value", "=Fields.CARTYPE2"));
			textBox9.Location = new PointU(Unit.Cm(2.0000998973846436), Unit.Cm(1.2001000642776489));
			textBox9.Name = "textBox9";
			textBox9.Size = new SizeU(Unit.Cm(3.9995999336242676), Unit.Cm(0.800000011920929));
			textBox9.Style.BackgroundColor = Color.White;
			textBox9.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox9.Style.BorderStyle.Default = BorderType.Solid;
			textBox9.Style.BorderStyle.Top = BorderType.None;
			textBox9.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox9.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox9.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox9.Style.Font.Bold = true;
			textBox9.Style.Font.Name = "맑은 고딕";
			textBox9.Style.Font.Size = Unit.Point(11.0);
			textBox9.Style.TextAlign = HorizontalAlign.Center;
			textBox9.Style.VerticalAlign = VerticalAlign.Middle;
			textBox9.Value = "";
			textBox10.Bindings.Add(new Binding("Value", "=Fields.ITEMCODE2"));
			textBox10.Location = new PointU(Unit.Cm(2.0001001358032227), Unit.Cm(2.0003006458282471));
			textBox10.Name = "textBox10";
			textBox10.Size = new SizeU(Unit.Cm(3.9995999336242676), Unit.Cm(0.800000011920929));
			textBox10.Style.BackgroundColor = Color.White;
			textBox10.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox10.Style.BorderStyle.Default = BorderType.Solid;
			textBox10.Style.BorderStyle.Top = BorderType.None;
			textBox10.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox10.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox10.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox10.Style.Font.Bold = true;
			textBox10.Style.Font.Name = "맑은 고딕";
			textBox10.Style.Font.Size = Unit.Point(11.0);
			textBox10.Style.TextAlign = HorizontalAlign.Center;
			textBox10.Style.VerticalAlign = VerticalAlign.Middle;
			textBox10.Value = "";
			textBox11.Bindings.Add(new Binding("Value", "=Fields.ITEMNAME2"));
			textBox11.Location = new PointU(Unit.Cm(2.0001001358032227), Unit.Cm(2.8005011081695557));
			textBox11.Name = "textBox11";
			textBox11.Size = new SizeU(Unit.Cm(3.9995999336242676), Unit.Cm(0.800000011920929));
			textBox11.Style.BackgroundColor = Color.White;
			textBox11.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox11.Style.BorderStyle.Default = BorderType.Solid;
			textBox11.Style.BorderStyle.Top = BorderType.Solid;
			textBox11.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox11.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox11.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox11.Style.Font.Bold = true;
			textBox11.Style.Font.Name = "맑은 고딕";
			textBox11.Style.Font.Size = Unit.Point(10.0);
			textBox11.Style.TextAlign = HorizontalAlign.Left;
			textBox11.Style.VerticalAlign = VerticalAlign.Middle;
			textBox11.Value = "";
			textBox12.Bindings.Add(new Binding("Value", "=Fields.QTY2"));
			textBox12.Location = new PointU(Unit.Cm(2.000300407409668), Unit.Cm(3.6007006168365479));
			textBox12.Name = "textBox12";
			textBox12.Size = new SizeU(Unit.Cm(2.9995996952056885), Unit.Cm(0.800000011920929));
			textBox12.Style.BackgroundColor = Color.White;
			textBox12.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox12.Style.BorderStyle.Default = BorderType.Solid;
			textBox12.Style.BorderStyle.Right = BorderType.None;
			textBox12.Style.BorderStyle.Top = BorderType.None;
			textBox12.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox12.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox12.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox12.Style.Font.Bold = true;
			textBox12.Style.Font.Name = "맑은 고딕";
			textBox12.Style.Font.Size = Unit.Point(11.0);
			textBox12.Style.TextAlign = HorizontalAlign.Center;
			textBox12.Style.VerticalAlign = VerticalAlign.Middle;
			textBox12.Value = "";
			textBox13.Bindings.Add(new Binding("Value", "=Fields.UNITCODE2"));
			textBox13.Location = new PointU(Unit.Cm(4.9999003410339355), Unit.Cm(3.6007015705108643));
			textBox13.Name = "textBox13";
			textBox13.Size = new SizeU(Unit.Cm(0.99980008602142334), Unit.Cm(0.800000011920929));
			textBox13.Style.BackgroundColor = Color.White;
			textBox13.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox13.Style.BorderStyle.Default = BorderType.Solid;
			textBox13.Style.BorderStyle.Left = BorderType.None;
			textBox13.Style.BorderStyle.Top = BorderType.None;
			textBox13.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox13.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox13.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox13.Style.Font.Bold = true;
			textBox13.Style.Font.Name = "맑은 고딕";
			textBox13.Style.Font.Size = Unit.Point(11.0);
			textBox13.Style.TextAlign = HorizontalAlign.Center;
			textBox13.Style.VerticalAlign = VerticalAlign.Middle;
			textBox13.Value = "";
			textBox14.Bindings.Add(new Binding("Value", "=Fields.PRODDATE2"));
			textBox14.Location = new PointU(Unit.Cm(2.0001001358032227), Unit.Cm(4.4009017944335938));
			textBox14.Name = "textBox14";
			textBox14.Size = new SizeU(Unit.Cm(4.9997997283935547), Unit.Cm(0.800000011920929));
			textBox14.Style.BackgroundColor = Color.White;
			textBox14.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox14.Style.BorderStyle.Default = BorderType.Solid;
			textBox14.Style.BorderStyle.Top = BorderType.None;
			textBox14.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox14.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox14.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox14.Style.Font.Bold = true;
			textBox14.Style.Font.Name = "맑은 고딕";
			textBox14.Style.Font.Size = Unit.Point(11.0);
			textBox14.Style.TextAlign = HorizontalAlign.Center;
			textBox14.Style.VerticalAlign = VerticalAlign.Middle;
			textBox14.Value = "";
			textBox15.Location = new PointU(Unit.Cm(7.0000996589660645), Unit.Cm(4.4009017944335938));
			textBox15.Name = "textBox15";
			textBox15.Size = new SizeU(Unit.Cm(1.1000000238418579), Unit.Cm(2.0999999046325684));
			textBox15.Style.BackgroundColor = Color.White;
			textBox15.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox15.Style.BorderStyle.Default = BorderType.Solid;
			textBox15.Style.BorderStyle.Left = BorderType.Solid;
			textBox15.Style.BorderStyle.Top = BorderType.None;
			textBox15.Style.BorderWidth.Bottom = Unit.Point(1.0);
			textBox15.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox15.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox15.Style.Font.Bold = true;
			textBox15.Style.Font.Name = "맑은 고딕";
			textBox15.Style.Font.Size = Unit.Point(11.0);
			textBox15.Style.TextAlign = HorizontalAlign.Center;
			textBox15.Style.VerticalAlign = VerticalAlign.Middle;
			textBox15.Value = "검\r\n사";
			barcode1.Bindings.Add(new Binding("Value", "=LOTNO2"));
			barcode1.Location = new PointU(Unit.Cm(1.9999990463256836), Unit.Cm(5.299799919128418));
			barcode1.Name = "barcode1";
			barcode1.ShowText = true;
			barcode1.Size = new SizeU(Unit.Cm(5.0), Unit.Cm(1.2000000476837158));
			barcode1.Stretch = true;
			barcode1.Style.BorderStyle.Default = BorderType.None;
			barcode1.Style.BorderWidth.Default = Unit.Point(0.5);
			barcode1.Style.Font.Name = "맑은 고딕";
			barcode1.Style.Font.Size = Unit.Point(8.0);
			barcode1.Style.TextAlign = HorizontalAlign.Center;
			barcode1.Style.VerticalAlign = VerticalAlign.Bottom;
			barcode1.Value = "C201704191147X00000129372392";
			pictureBox2.Location = new PointU(Unit.Cm(6.0004982948303223), Unit.Cm(1.200100302696228));
			pictureBox2.MimeType = "";
			pictureBox2.Name = "pictureBox2";
			pictureBox2.Size = new SizeU(Unit.Cm(3.7994010448455811), Unit.Cm(3.2006008625030518));
			pictureBox2.Sizing = ImageSizeMode.Stretch;
			pictureBox2.Style.BackgroundImage.MimeType = "image/bmp";
			pictureBox2.Style.BackgroundImage.Repeat = BackgroundRepeat.NoRepeat;
			pictureBox2.Style.BorderStyle.Bottom = BorderType.Solid;
			pictureBox2.Style.BorderStyle.Top = BorderType.Solid;
			pictureBox2.Style.BorderWidth.Default = Unit.Point(0.5);
			pictureBox2.Value = "";
			panel3.Items.AddRange(new ReportItemBase[17]
			{
				textBox31,
				textBox32,
				textBox33,
				textBox34,
				textBox35,
				textBox36,
				textBox37,
				textBox38,
				textBox39,
				textBox40,
				textBox41,
				textBox42,
				textBox43,
				textBox44,
				textBox45,
				barcode3,
				pictureBox3
			});
			panel3.Location = new PointU(Unit.Cm(0.49999994039535522), Unit.Cm(7.0999999046325684));
			panel3.Name = "panel3";
			panel3.Size = new SizeU(Unit.Cm(9.80009937286377), Unit.Cm(6.5));
			panel3.Style.BorderStyle.Default = BorderType.Solid;
			panel3.Style.BorderWidth.Default = Unit.Point(1.0);
			textBox31.Location = new PointU(Unit.Cm(0.00010032494901679456), Unit.Cm(0.00010012308484874666));
			textBox31.Name = "textBox31";
			textBox31.Size = new SizeU(Unit.Cm(5.9997997283935547), Unit.Cm(1.1998000144958496));
			textBox31.Style.BackgroundColor = Color.White;
			textBox31.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox31.Style.BorderStyle.Default = BorderType.Solid;
			textBox31.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox31.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox31.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox31.Style.BorderWidth.Top = Unit.Point(1.0);
			textBox31.Style.Font.Bold = true;
			textBox31.Style.Font.Name = "맑은 고딕";
			textBox31.Style.Font.Size = Unit.Point(20.0);
			textBox31.Style.TextAlign = HorizontalAlign.Center;
			textBox31.Style.VerticalAlign = VerticalAlign.Middle;
			textBox31.Value = "부 품 식 별 표";
			textBox32.Location = new PointU(Unit.Cm(5.9998998641967773), Unit.Cm(0.0));
			textBox32.Name = "textBox32";
			textBox32.Size = new SizeU(Unit.Cm(3.7999999523162842), Unit.Cm(1.2000000476837158));
			textBox32.Style.BackgroundColor = Color.White;
			textBox32.Style.BorderStyle.Bottom = BorderType.None;
			textBox32.Style.BorderStyle.Default = BorderType.Solid;
			textBox32.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox32.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox32.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox32.Style.BorderWidth.Right = Unit.Point(1.0);
			textBox32.Style.BorderWidth.Top = Unit.Point(1.0);
			textBox32.Style.Font.Bold = true;
			textBox32.Style.Font.Name = "맑은 고딕";
			textBox32.Style.Font.Size = Unit.Point(16.0);
			textBox32.Style.Padding.Left = Unit.Cm(0.0);
			textBox32.Style.Padding.Right = Unit.Cm(0.0);
			textBox32.Style.TextAlign = HorizontalAlign.Center;
			textBox32.Style.VerticalAlign = VerticalAlign.Middle;
			textBox32.Value = "(주)제이에스디";
			textBox33.Location = new PointU(Unit.Cm(0.0), Unit.Cm(1.200100302696228));
			textBox33.Name = "textBox33";
			textBox33.Size = new SizeU(Unit.Cm(1.9998998641967773), Unit.Cm(0.800000011920929));
			textBox33.Style.BackgroundColor = Color.White;
			textBox33.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox33.Style.BorderStyle.Default = BorderType.Solid;
			textBox33.Style.BorderStyle.Top = BorderType.Solid;
			textBox33.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox33.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox33.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox33.Style.Font.Bold = true;
			textBox33.Style.Font.Name = "맑은 고딕";
			textBox33.Style.Font.Size = Unit.Point(11.0);
			textBox33.Style.TextAlign = HorizontalAlign.Center;
			textBox33.Style.VerticalAlign = VerticalAlign.Middle;
			textBox33.Value = "차     종";
			textBox34.Location = new PointU(Unit.Cm(0.0), Unit.Cm(2.8005001544952393));
			textBox34.Name = "textBox34";
			textBox34.Size = new SizeU(Unit.Cm(1.9998998641967773), Unit.Cm(0.800000011920929));
			textBox34.Style.BackgroundColor = Color.White;
			textBox34.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox34.Style.BorderStyle.Default = BorderType.Solid;
			textBox34.Style.BorderStyle.Top = BorderType.None;
			textBox34.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox34.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox34.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox34.Style.Font.Bold = true;
			textBox34.Style.Font.Name = "맑은 고딕";
			textBox34.Style.Font.Size = Unit.Point(11.0);
			textBox34.Style.TextAlign = HorizontalAlign.Center;
			textBox34.Style.VerticalAlign = VerticalAlign.Middle;
			textBox34.Value = "품     명";
			textBox35.Location = new PointU(Unit.Cm(0.0), Unit.Cm(3.6007006168365479));
			textBox35.Name = "textBox35";
			textBox35.Size = new SizeU(Unit.Cm(1.9998998641967773), Unit.Cm(0.800000011920929));
			textBox35.Style.BackgroundColor = Color.White;
			textBox35.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox35.Style.BorderStyle.Default = BorderType.Solid;
			textBox35.Style.BorderStyle.Top = BorderType.None;
			textBox35.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox35.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox35.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox35.Style.Font.Bold = true;
			textBox35.Style.Font.Name = "맑은 고딕";
			textBox35.Style.Font.Size = Unit.Point(11.0);
			textBox35.Style.TextAlign = HorizontalAlign.Center;
			textBox35.Style.VerticalAlign = VerticalAlign.Middle;
			textBox35.Value = "생산수량";
			textBox36.Location = new PointU(Unit.Cm(0.0), Unit.Cm(4.4009013175964355));
			textBox36.Name = "textBox36";
			textBox36.Size = new SizeU(Unit.Cm(1.9998998641967773), Unit.Cm(0.800000011920929));
			textBox36.Style.BackgroundColor = Color.White;
			textBox36.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox36.Style.BorderStyle.Default = BorderType.Solid;
			textBox36.Style.BorderStyle.Top = BorderType.None;
			textBox36.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox36.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox36.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox36.Style.Font.Bold = true;
			textBox36.Style.Font.Name = "맑은 고딕";
			textBox36.Style.Font.Size = Unit.Point(11.0);
			textBox36.Style.TextAlign = HorizontalAlign.Center;
			textBox36.Style.VerticalAlign = VerticalAlign.Middle;
			textBox36.Value = "생산일자";
			textBox37.Location = new PointU(Unit.Cm(0.0), Unit.Cm(5.2011017799377441));
			textBox37.Name = "textBox37";
			textBox37.Size = new SizeU(Unit.Cm(1.9998998641967773), Unit.Cm(1.2987978458404541));
			textBox37.Style.BackgroundColor = Color.White;
			textBox37.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox37.Style.BorderStyle.Default = BorderType.Solid;
			textBox37.Style.BorderStyle.Right = BorderType.Solid;
			textBox37.Style.BorderStyle.Top = BorderType.None;
			textBox37.Style.BorderWidth.Bottom = Unit.Point(1.0);
			textBox37.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox37.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox37.Style.Font.Bold = true;
			textBox37.Style.Font.Name = "맑은 고딕";
			textBox37.Style.Font.Size = Unit.Point(11.0);
			textBox37.Style.TextAlign = HorizontalAlign.Center;
			textBox37.Style.VerticalAlign = VerticalAlign.Middle;
			textBox37.Value = "LOT NO.";
			textBox38.Location = new PointU(Unit.Cm(0.00010032494901679456), Unit.Cm(2.000300407409668));
			textBox38.Name = "textBox38";
			textBox38.Size = new SizeU(Unit.Cm(1.9998998641967773), Unit.Cm(0.800000011920929));
			textBox38.Style.BackgroundColor = Color.White;
			textBox38.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox38.Style.BorderStyle.Default = BorderType.Solid;
			textBox38.Style.BorderStyle.Top = BorderType.None;
			textBox38.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox38.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox38.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox38.Style.Font.Bold = true;
			textBox38.Style.Font.Name = "맑은 고딕";
			textBox38.Style.Font.Size = Unit.Point(11.0);
			textBox38.Style.TextAlign = HorizontalAlign.Center;
			textBox38.Style.VerticalAlign = VerticalAlign.Middle;
			textBox38.Value = "품     번";
			textBox39.Bindings.Add(new Binding("Value", "=Fields.CARTYPE3"));
			textBox39.Location = new PointU(Unit.Cm(2.0000998973846436), Unit.Cm(1.2001000642776489));
			textBox39.Name = "textBox39";
			textBox39.Size = new SizeU(Unit.Cm(3.9995999336242676), Unit.Cm(0.800000011920929));
			textBox39.Style.BackgroundColor = Color.White;
			textBox39.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox39.Style.BorderStyle.Default = BorderType.Solid;
			textBox39.Style.BorderStyle.Top = BorderType.Solid;
			textBox39.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox39.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox39.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox39.Style.Font.Bold = true;
			textBox39.Style.Font.Name = "맑은 고딕";
			textBox39.Style.Font.Size = Unit.Point(11.0);
			textBox39.Style.TextAlign = HorizontalAlign.Center;
			textBox39.Style.VerticalAlign = VerticalAlign.Middle;
			textBox39.Value = "";
			textBox40.Bindings.Add(new Binding("Value", "=Fields.ITEMCODE3"));
			textBox40.Location = new PointU(Unit.Cm(2.0001001358032227), Unit.Cm(2.0003006458282471));
			textBox40.Name = "textBox40";
			textBox40.Size = new SizeU(Unit.Cm(3.9995999336242676), Unit.Cm(0.800000011920929));
			textBox40.Style.BackgroundColor = Color.White;
			textBox40.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox40.Style.BorderStyle.Default = BorderType.Solid;
			textBox40.Style.BorderStyle.Top = BorderType.None;
			textBox40.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox40.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox40.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox40.Style.Font.Bold = true;
			textBox40.Style.Font.Name = "맑은 고딕";
			textBox40.Style.Font.Size = Unit.Point(11.0);
			textBox40.Style.TextAlign = HorizontalAlign.Center;
			textBox40.Style.VerticalAlign = VerticalAlign.Middle;
			textBox40.Value = "";
			textBox41.Bindings.Add(new Binding("Value", "=Fields.ITEMNAME3"));
			textBox41.Location = new PointU(Unit.Cm(1.9999990463256836), Unit.Cm(2.8006010055541992));
			textBox41.Name = "textBox41";
			textBox41.Size = new SizeU(Unit.Cm(3.9995999336242676), Unit.Cm(0.800000011920929));
			textBox41.Style.BackgroundColor = Color.White;
			textBox41.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox41.Style.BorderStyle.Default = BorderType.Solid;
			textBox41.Style.BorderStyle.Top = BorderType.Solid;
			textBox41.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox41.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox41.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox41.Style.Font.Bold = true;
			textBox41.Style.Font.Name = "맑은 고딕";
			textBox41.Style.Font.Size = Unit.Point(10.0);
			textBox41.Style.TextAlign = HorizontalAlign.Left;
			textBox41.Style.VerticalAlign = VerticalAlign.Middle;
			textBox41.Value = "";
			textBox42.Bindings.Add(new Binding("Value", "=Fields.QTY3"));
			textBox42.Location = new PointU(Unit.Cm(2.000300407409668), Unit.Cm(3.6007006168365479));
			textBox42.Name = "textBox42";
			textBox42.Size = new SizeU(Unit.Cm(2.9995996952056885), Unit.Cm(0.800000011920929));
			textBox42.Style.BackgroundColor = Color.White;
			textBox42.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox42.Style.BorderStyle.Default = BorderType.Solid;
			textBox42.Style.BorderStyle.Right = BorderType.None;
			textBox42.Style.BorderStyle.Top = BorderType.None;
			textBox42.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox42.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox42.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox42.Style.Font.Bold = true;
			textBox42.Style.Font.Name = "맑은 고딕";
			textBox42.Style.Font.Size = Unit.Point(11.0);
			textBox42.Style.TextAlign = HorizontalAlign.Center;
			textBox42.Style.VerticalAlign = VerticalAlign.Middle;
			textBox42.Value = "";
			textBox43.Bindings.Add(new Binding("Value", "=Fields.UNITCODE3"));
			textBox43.Location = new PointU(Unit.Cm(4.9999003410339355), Unit.Cm(3.6007015705108643));
			textBox43.Name = "textBox43";
			textBox43.Size = new SizeU(Unit.Cm(0.99980008602142334), Unit.Cm(0.800000011920929));
			textBox43.Style.BackgroundColor = Color.White;
			textBox43.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox43.Style.BorderStyle.Default = BorderType.Solid;
			textBox43.Style.BorderStyle.Left = BorderType.None;
			textBox43.Style.BorderStyle.Top = BorderType.None;
			textBox43.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox43.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox43.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox43.Style.Font.Bold = true;
			textBox43.Style.Font.Name = "맑은 고딕";
			textBox43.Style.Font.Size = Unit.Point(11.0);
			textBox43.Style.TextAlign = HorizontalAlign.Center;
			textBox43.Style.VerticalAlign = VerticalAlign.Middle;
			textBox43.Value = "";
			textBox44.Bindings.Add(new Binding("Value", "=Fields.PRODDATE3"));
			textBox44.Location = new PointU(Unit.Cm(2.0001001358032227), Unit.Cm(4.4009017944335938));
			textBox44.Name = "textBox44";
			textBox44.Size = new SizeU(Unit.Cm(4.9997997283935547), Unit.Cm(0.800000011920929));
			textBox44.Style.BackgroundColor = Color.White;
			textBox44.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox44.Style.BorderStyle.Default = BorderType.Solid;
			textBox44.Style.BorderStyle.Top = BorderType.None;
			textBox44.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox44.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox44.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox44.Style.Font.Bold = true;
			textBox44.Style.Font.Name = "맑은 고딕";
			textBox44.Style.Font.Size = Unit.Point(11.0);
			textBox44.Style.TextAlign = HorizontalAlign.Center;
			textBox44.Style.VerticalAlign = VerticalAlign.Middle;
			textBox44.Value = "";
			textBox45.Location = new PointU(Unit.Cm(7.0000996589660645), Unit.Cm(4.4009017944335938));
			textBox45.Name = "textBox45";
			textBox45.Size = new SizeU(Unit.Cm(1.1000000238418579), Unit.Cm(2.0999999046325684));
			textBox45.Style.BackgroundColor = Color.White;
			textBox45.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox45.Style.BorderStyle.Default = BorderType.Solid;
			textBox45.Style.BorderStyle.Left = BorderType.Solid;
			textBox45.Style.BorderStyle.Top = BorderType.None;
			textBox45.Style.BorderWidth.Bottom = Unit.Point(1.0);
			textBox45.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox45.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox45.Style.Font.Bold = true;
			textBox45.Style.Font.Name = "맑은 고딕";
			textBox45.Style.Font.Size = Unit.Point(11.0);
			textBox45.Style.TextAlign = HorizontalAlign.Center;
			textBox45.Style.VerticalAlign = VerticalAlign.Middle;
			textBox45.Value = "검\r\n사";
			barcode3.Bindings.Add(new Binding("Value", "=Fields.LOTNO3"));
			barcode3.Location = new PointU(Unit.Cm(1.9999990463256836), Unit.Cm(5.299799919128418));
			barcode3.Name = "barcode3";
			barcode3.ShowText = true;
			barcode3.Size = new SizeU(Unit.Cm(5.0), Unit.Cm(1.2000000476837158));
			barcode3.Stretch = true;
			barcode3.Style.BorderStyle.Default = BorderType.None;
			barcode3.Style.BorderWidth.Default = Unit.Point(0.5);
			barcode3.Style.Font.Name = "맑은 고딕";
			barcode3.Style.Font.Size = Unit.Point(8.0);
			barcode3.Style.TextAlign = HorizontalAlign.Center;
			barcode3.Style.VerticalAlign = VerticalAlign.Bottom;
			barcode3.Value = "C201704191147X00000129372392";
			pictureBox3.Location = new PointU(Unit.Cm(6.0006980895996094), Unit.Cm(1.2002004384994507));
			pictureBox3.MimeType = "";
			pictureBox3.Name = "pictureBox3";
			pictureBox3.Size = new SizeU(Unit.Cm(3.7992024421691895), Unit.Cm(3.2006008625030518));
			pictureBox3.Sizing = ImageSizeMode.Stretch;
			pictureBox3.Style.BackgroundImage.MimeType = "image/bmp";
			pictureBox3.Style.BackgroundImage.Repeat = BackgroundRepeat.NoRepeat;
			pictureBox3.Style.BorderStyle.Bottom = BorderType.Solid;
			pictureBox3.Style.BorderStyle.Top = BorderType.Solid;
			pictureBox3.Style.BorderWidth.Default = Unit.Point(0.5);
			pictureBox3.Value = "";
			panel4.Items.AddRange(new ReportItemBase[17]
			{
				textBox46,
				textBox47,
				textBox48,
				textBox49,
				textBox50,
				textBox51,
				textBox52,
				textBox53,
				textBox54,
				textBox55,
				textBox56,
				textBox57,
				textBox58,
				textBox59,
				textBox60,
				barcode4,
				pictureBox5
			});
			panel4.Location = new PointU(Unit.Cm(0.49999994039535522), Unit.Cm(14.199999809265137));
			panel4.Name = "panel4";
			panel4.Size = new SizeU(Unit.Cm(9.80000114440918), Unit.Cm(6.5));
			panel4.Style.BorderStyle.Default = BorderType.Solid;
			panel4.Style.BorderWidth.Default = Unit.Point(1.0);
			textBox46.Location = new PointU(Unit.Cm(0.00010032494901679456), Unit.Cm(0.00010012308484874666));
			textBox46.Name = "textBox46";
			textBox46.Size = new SizeU(Unit.Cm(5.9997997283935547), Unit.Cm(1.1998000144958496));
			textBox46.Style.BackgroundColor = Color.White;
			textBox46.Style.BorderStyle.Default = BorderType.Solid;
			textBox46.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox46.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox46.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox46.Style.BorderWidth.Top = Unit.Point(1.0);
			textBox46.Style.Font.Bold = true;
			textBox46.Style.Font.Name = "맑은 고딕";
			textBox46.Style.Font.Size = Unit.Point(20.0);
			textBox46.Style.TextAlign = HorizontalAlign.Center;
			textBox46.Style.VerticalAlign = VerticalAlign.Middle;
			textBox46.Value = "부 품 식 별 표";
			textBox47.Location = new PointU(Unit.Cm(5.9998998641967773), Unit.Cm(0.0));
			textBox47.Name = "textBox47";
			textBox47.Size = new SizeU(Unit.Cm(3.7999999523162842), Unit.Cm(1.2000000476837158));
			textBox47.Style.BackgroundColor = Color.White;
			textBox47.Style.BorderStyle.Bottom = BorderType.None;
			textBox47.Style.BorderStyle.Default = BorderType.Solid;
			textBox47.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox47.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox47.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox47.Style.BorderWidth.Right = Unit.Point(1.0);
			textBox47.Style.BorderWidth.Top = Unit.Point(1.0);
			textBox47.Style.Font.Bold = true;
			textBox47.Style.Font.Name = "맑은 고딕";
			textBox47.Style.Font.Size = Unit.Point(16.0);
			textBox47.Style.Padding.Left = Unit.Cm(0.0);
			textBox47.Style.Padding.Right = Unit.Cm(0.0);
			textBox47.Style.TextAlign = HorizontalAlign.Center;
			textBox47.Style.VerticalAlign = VerticalAlign.Middle;
			textBox47.Value = "(주)제이에스디";
			textBox48.Location = new PointU(Unit.Cm(0.0), Unit.Cm(1.200100302696228));
			textBox48.Name = "textBox48";
			textBox48.Size = new SizeU(Unit.Cm(1.9998998641967773), Unit.Cm(0.800000011920929));
			textBox48.Style.BackgroundColor = Color.White;
			textBox48.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox48.Style.BorderStyle.Default = BorderType.Solid;
			textBox48.Style.BorderStyle.Top = BorderType.None;
			textBox48.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox48.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox48.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox48.Style.Font.Bold = true;
			textBox48.Style.Font.Name = "맑은 고딕";
			textBox48.Style.Font.Size = Unit.Point(11.0);
			textBox48.Style.TextAlign = HorizontalAlign.Center;
			textBox48.Style.VerticalAlign = VerticalAlign.Middle;
			textBox48.Value = "차     종";
			textBox49.Location = new PointU(Unit.Cm(0.0), Unit.Cm(2.8005001544952393));
			textBox49.Name = "textBox49";
			textBox49.Size = new SizeU(Unit.Cm(1.9998998641967773), Unit.Cm(0.800000011920929));
			textBox49.Style.BackgroundColor = Color.White;
			textBox49.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox49.Style.BorderStyle.Default = BorderType.Solid;
			textBox49.Style.BorderStyle.Top = BorderType.None;
			textBox49.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox49.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox49.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox49.Style.Font.Bold = true;
			textBox49.Style.Font.Name = "맑은 고딕";
			textBox49.Style.Font.Size = Unit.Point(11.0);
			textBox49.Style.TextAlign = HorizontalAlign.Center;
			textBox49.Style.VerticalAlign = VerticalAlign.Middle;
			textBox49.Value = "품     명";
			textBox50.Location = new PointU(Unit.Cm(0.0), Unit.Cm(3.6007006168365479));
			textBox50.Name = "textBox50";
			textBox50.Size = new SizeU(Unit.Cm(1.9998998641967773), Unit.Cm(0.800000011920929));
			textBox50.Style.BackgroundColor = Color.White;
			textBox50.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox50.Style.BorderStyle.Default = BorderType.Solid;
			textBox50.Style.BorderStyle.Top = BorderType.None;
			textBox50.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox50.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox50.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox50.Style.Font.Bold = true;
			textBox50.Style.Font.Name = "맑은 고딕";
			textBox50.Style.Font.Size = Unit.Point(11.0);
			textBox50.Style.TextAlign = HorizontalAlign.Center;
			textBox50.Style.VerticalAlign = VerticalAlign.Middle;
			textBox50.Value = "생산수량";
			textBox51.Location = new PointU(Unit.Cm(0.0), Unit.Cm(4.4009013175964355));
			textBox51.Name = "textBox51";
			textBox51.Size = new SizeU(Unit.Cm(1.9998998641967773), Unit.Cm(0.800000011920929));
			textBox51.Style.BackgroundColor = Color.White;
			textBox51.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox51.Style.BorderStyle.Default = BorderType.Solid;
			textBox51.Style.BorderStyle.Top = BorderType.None;
			textBox51.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox51.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox51.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox51.Style.Font.Bold = true;
			textBox51.Style.Font.Name = "맑은 고딕";
			textBox51.Style.Font.Size = Unit.Point(11.0);
			textBox51.Style.TextAlign = HorizontalAlign.Center;
			textBox51.Style.VerticalAlign = VerticalAlign.Middle;
			textBox51.Value = "생산일자";
			textBox52.Location = new PointU(Unit.Cm(0.0), Unit.Cm(5.2011017799377441));
			textBox52.Name = "textBox52";
			textBox52.Size = new SizeU(Unit.Cm(1.9998998641967773), Unit.Cm(1.2987978458404541));
			textBox52.Style.BackgroundColor = Color.White;
			textBox52.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox52.Style.BorderStyle.Default = BorderType.Solid;
			textBox52.Style.BorderStyle.Right = BorderType.Solid;
			textBox52.Style.BorderStyle.Top = BorderType.None;
			textBox52.Style.BorderWidth.Bottom = Unit.Point(1.0);
			textBox52.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox52.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox52.Style.Font.Bold = true;
			textBox52.Style.Font.Name = "맑은 고딕";
			textBox52.Style.Font.Size = Unit.Point(11.0);
			textBox52.Style.TextAlign = HorizontalAlign.Center;
			textBox52.Style.VerticalAlign = VerticalAlign.Middle;
			textBox52.Value = "LOT NO.";
			textBox53.Location = new PointU(Unit.Cm(0.00010032494901679456), Unit.Cm(2.000300407409668));
			textBox53.Name = "textBox53";
			textBox53.Size = new SizeU(Unit.Cm(1.9998998641967773), Unit.Cm(0.800000011920929));
			textBox53.Style.BackgroundColor = Color.White;
			textBox53.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox53.Style.BorderStyle.Default = BorderType.Solid;
			textBox53.Style.BorderStyle.Top = BorderType.None;
			textBox53.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox53.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox53.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox53.Style.Font.Bold = true;
			textBox53.Style.Font.Name = "맑은 고딕";
			textBox53.Style.Font.Size = Unit.Point(11.0);
			textBox53.Style.TextAlign = HorizontalAlign.Center;
			textBox53.Style.VerticalAlign = VerticalAlign.Middle;
			textBox53.Value = "품     번";
			textBox54.Bindings.Add(new Binding("Value", "=Fields.CARTYPE5"));
			textBox54.Location = new PointU(Unit.Cm(2.0000998973846436), Unit.Cm(1.2001000642776489));
			textBox54.Name = "textBox54";
			textBox54.Size = new SizeU(Unit.Cm(3.9995999336242676), Unit.Cm(0.800000011920929));
			textBox54.Style.BackgroundColor = Color.White;
			textBox54.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox54.Style.BorderStyle.Default = BorderType.Solid;
			textBox54.Style.BorderStyle.Top = BorderType.None;
			textBox54.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox54.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox54.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox54.Style.Font.Bold = true;
			textBox54.Style.Font.Name = "맑은 고딕";
			textBox54.Style.Font.Size = Unit.Point(11.0);
			textBox54.Style.TextAlign = HorizontalAlign.Center;
			textBox54.Style.VerticalAlign = VerticalAlign.Middle;
			textBox54.Value = "";
			textBox55.Bindings.Add(new Binding("Value", "=Fields.ITEMCODE5"));
			textBox55.Location = new PointU(Unit.Cm(2.0001001358032227), Unit.Cm(2.0003006458282471));
			textBox55.Name = "textBox55";
			textBox55.Size = new SizeU(Unit.Cm(3.9995999336242676), Unit.Cm(0.800000011920929));
			textBox55.Style.BackgroundColor = Color.White;
			textBox55.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox55.Style.BorderStyle.Default = BorderType.Solid;
			textBox55.Style.BorderStyle.Top = BorderType.None;
			textBox55.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox55.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox55.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox55.Style.Font.Bold = true;
			textBox55.Style.Font.Name = "맑은 고딕";
			textBox55.Style.Font.Size = Unit.Point(11.0);
			textBox55.Style.TextAlign = HorizontalAlign.Center;
			textBox55.Style.VerticalAlign = VerticalAlign.Middle;
			textBox55.Value = "";
			textBox56.Bindings.Add(new Binding("Value", "=Fields.ITEMNAME5"));
			textBox56.Location = new PointU(Unit.Cm(2.0001001358032227), Unit.Cm(2.8005011081695557));
			textBox56.Name = "textBox56";
			textBox56.Size = new SizeU(Unit.Cm(3.9995999336242676), Unit.Cm(0.800000011920929));
			textBox56.Style.BackgroundColor = Color.White;
			textBox56.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox56.Style.BorderStyle.Default = BorderType.Solid;
			textBox56.Style.BorderStyle.Top = BorderType.Solid;
			textBox56.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox56.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox56.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox56.Style.Font.Bold = true;
			textBox56.Style.Font.Name = "맑은 고딕";
			textBox56.Style.Font.Size = Unit.Point(10.0);
			textBox56.Style.TextAlign = HorizontalAlign.Left;
			textBox56.Style.VerticalAlign = VerticalAlign.Middle;
			textBox56.Value = "";
			textBox57.Bindings.Add(new Binding("Value", "=Fields.QTY5"));
			textBox57.Location = new PointU(Unit.Cm(2.000300407409668), Unit.Cm(3.6007006168365479));
			textBox57.Name = "textBox57";
			textBox57.Size = new SizeU(Unit.Cm(2.9995996952056885), Unit.Cm(0.800000011920929));
			textBox57.Style.BackgroundColor = Color.White;
			textBox57.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox57.Style.BorderStyle.Default = BorderType.Solid;
			textBox57.Style.BorderStyle.Right = BorderType.None;
			textBox57.Style.BorderStyle.Top = BorderType.None;
			textBox57.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox57.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox57.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox57.Style.Font.Bold = true;
			textBox57.Style.Font.Name = "맑은 고딕";
			textBox57.Style.Font.Size = Unit.Point(11.0);
			textBox57.Style.TextAlign = HorizontalAlign.Center;
			textBox57.Style.VerticalAlign = VerticalAlign.Middle;
			textBox57.Value = "";
			textBox58.Bindings.Add(new Binding("Value", "=Fields.UNITCODE5"));
			textBox58.Location = new PointU(Unit.Cm(4.9999003410339355), Unit.Cm(3.6007015705108643));
			textBox58.Name = "textBox58";
			textBox58.Size = new SizeU(Unit.Cm(0.99980008602142334), Unit.Cm(0.800000011920929));
			textBox58.Style.BackgroundColor = Color.White;
			textBox58.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox58.Style.BorderStyle.Default = BorderType.Solid;
			textBox58.Style.BorderStyle.Left = BorderType.None;
			textBox58.Style.BorderStyle.Top = BorderType.None;
			textBox58.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox58.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox58.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox58.Style.Font.Bold = true;
			textBox58.Style.Font.Name = "맑은 고딕";
			textBox58.Style.Font.Size = Unit.Point(11.0);
			textBox58.Style.TextAlign = HorizontalAlign.Center;
			textBox58.Style.VerticalAlign = VerticalAlign.Middle;
			textBox58.Value = "";
			textBox59.Bindings.Add(new Binding("Value", "=Fields.PRODDATE5"));
			textBox59.Location = new PointU(Unit.Cm(2.0001001358032227), Unit.Cm(4.4009017944335938));
			textBox59.Name = "textBox59";
			textBox59.Size = new SizeU(Unit.Cm(4.9997997283935547), Unit.Cm(0.800000011920929));
			textBox59.Style.BackgroundColor = Color.White;
			textBox59.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox59.Style.BorderStyle.Default = BorderType.Solid;
			textBox59.Style.BorderStyle.Top = BorderType.None;
			textBox59.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox59.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox59.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox59.Style.Font.Bold = true;
			textBox59.Style.Font.Name = "맑은 고딕";
			textBox59.Style.Font.Size = Unit.Point(11.0);
			textBox59.Style.TextAlign = HorizontalAlign.Center;
			textBox59.Style.VerticalAlign = VerticalAlign.Middle;
			textBox59.Value = "";
			textBox60.Location = new PointU(Unit.Cm(7.0000996589660645), Unit.Cm(4.4009017944335938));
			textBox60.Name = "textBox60";
			textBox60.Size = new SizeU(Unit.Cm(1.1000000238418579), Unit.Cm(2.0999999046325684));
			textBox60.Style.BackgroundColor = Color.White;
			textBox60.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox60.Style.BorderStyle.Default = BorderType.Solid;
			textBox60.Style.BorderStyle.Left = BorderType.Solid;
			textBox60.Style.BorderStyle.Top = BorderType.None;
			textBox60.Style.BorderWidth.Bottom = Unit.Point(1.0);
			textBox60.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox60.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox60.Style.Font.Bold = true;
			textBox60.Style.Font.Name = "맑은 고딕";
			textBox60.Style.Font.Size = Unit.Point(11.0);
			textBox60.Style.TextAlign = HorizontalAlign.Center;
			textBox60.Style.VerticalAlign = VerticalAlign.Middle;
			textBox60.Value = "검\r\n사";
			barcode4.Bindings.Add(new Binding("Value", "=Fields.LOTNO5"));
			barcode4.Location = new PointU(Unit.Cm(1.9999990463256836), Unit.Cm(5.299799919128418));
			barcode4.Name = "barcode4";
			barcode4.ShowText = true;
			barcode4.Size = new SizeU(Unit.Cm(5.0), Unit.Cm(1.2000000476837158));
			barcode4.Stretch = true;
			barcode4.Style.BorderStyle.Default = BorderType.None;
			barcode4.Style.BorderWidth.Default = Unit.Point(0.5);
			barcode4.Style.Font.Name = "맑은 고딕";
			barcode4.Style.Font.Size = Unit.Point(8.0);
			barcode4.Style.TextAlign = HorizontalAlign.Center;
			barcode4.Style.VerticalAlign = VerticalAlign.Bottom;
			barcode4.Value = "C201704191147X00000129372392";
			pictureBox5.Location = new PointU(Unit.Cm(5.99970006942749), Unit.Cm(1.2000994682312012));
			pictureBox5.MimeType = "";
			pictureBox5.Name = "pictureBox5";
			pictureBox5.Size = new SizeU(Unit.Cm(3.8003005981445313), Unit.Cm(3.2006008625030518));
			pictureBox5.Sizing = ImageSizeMode.Stretch;
			pictureBox5.Style.BackgroundImage.MimeType = "image/bmp";
			pictureBox5.Style.BackgroundImage.Repeat = BackgroundRepeat.NoRepeat;
			pictureBox5.Style.BorderStyle.Bottom = BorderType.Solid;
			pictureBox5.Style.BorderStyle.Top = BorderType.Solid;
			pictureBox5.Style.BorderWidth.Default = Unit.Point(0.5);
			pictureBox5.Value = "";
			panel5.Items.AddRange(new ReportItemBase[17]
			{
				textBox61,
				textBox62,
				textBox63,
				textBox64,
				textBox65,
				textBox66,
				textBox67,
				textBox68,
				textBox69,
				textBox70,
				textBox71,
				textBox72,
				textBox73,
				textBox74,
				textBox75,
				barcode5,
				pictureBox7
			});
			panel5.Location = new PointU(Unit.Cm(0.49999994039535522), Unit.Cm(21.299999237060547));
			panel5.Name = "panel5";
			panel5.Size = new SizeU(Unit.Cm(9.799901008605957), Unit.Cm(6.5));
			panel5.Style.BorderStyle.Default = BorderType.Solid;
			panel5.Style.BorderWidth.Default = Unit.Point(1.0);
			textBox61.Location = new PointU(Unit.Cm(0.00010032494901679456), Unit.Cm(0.00010012308484874666));
			textBox61.Name = "textBox61";
			textBox61.Size = new SizeU(Unit.Cm(5.9997997283935547), Unit.Cm(1.1998000144958496));
			textBox61.Style.BackgroundColor = Color.White;
			textBox61.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox61.Style.BorderStyle.Default = BorderType.Solid;
			textBox61.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox61.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox61.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox61.Style.BorderWidth.Top = Unit.Point(1.0);
			textBox61.Style.Font.Bold = true;
			textBox61.Style.Font.Name = "맑은 고딕";
			textBox61.Style.Font.Size = Unit.Point(20.0);
			textBox61.Style.TextAlign = HorizontalAlign.Center;
			textBox61.Style.VerticalAlign = VerticalAlign.Middle;
			textBox61.Value = "부 품 식 별 표";
			textBox62.Location = new PointU(Unit.Cm(5.9998998641967773), Unit.Cm(0.0));
			textBox62.Name = "textBox62";
			textBox62.Size = new SizeU(Unit.Cm(3.7999999523162842), Unit.Cm(1.2000000476837158));
			textBox62.Style.BackgroundColor = Color.White;
			textBox62.Style.BorderStyle.Bottom = BorderType.None;
			textBox62.Style.BorderStyle.Default = BorderType.Solid;
			textBox62.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox62.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox62.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox62.Style.BorderWidth.Right = Unit.Point(1.0);
			textBox62.Style.BorderWidth.Top = Unit.Point(1.0);
			textBox62.Style.Font.Bold = true;
			textBox62.Style.Font.Name = "맑은 고딕";
			textBox62.Style.Font.Size = Unit.Point(16.0);
			textBox62.Style.Padding.Left = Unit.Cm(0.0);
			textBox62.Style.Padding.Right = Unit.Cm(0.0);
			textBox62.Style.TextAlign = HorizontalAlign.Center;
			textBox62.Style.VerticalAlign = VerticalAlign.Middle;
			textBox62.Value = "(주)제이에스디";
			textBox63.Location = new PointU(Unit.Cm(0.0), Unit.Cm(1.200100302696228));
			textBox63.Name = "textBox63";
			textBox63.Size = new SizeU(Unit.Cm(1.9998998641967773), Unit.Cm(0.800000011920929));
			textBox63.Style.BackgroundColor = Color.White;
			textBox63.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox63.Style.BorderStyle.Default = BorderType.Solid;
			textBox63.Style.BorderStyle.Top = BorderType.Solid;
			textBox63.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox63.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox63.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox63.Style.Font.Bold = true;
			textBox63.Style.Font.Name = "맑은 고딕";
			textBox63.Style.Font.Size = Unit.Point(11.0);
			textBox63.Style.TextAlign = HorizontalAlign.Center;
			textBox63.Style.VerticalAlign = VerticalAlign.Middle;
			textBox63.Value = "차     종";
			textBox64.Location = new PointU(Unit.Cm(0.0), Unit.Cm(2.8005001544952393));
			textBox64.Name = "textBox64";
			textBox64.Size = new SizeU(Unit.Cm(1.9998998641967773), Unit.Cm(0.800000011920929));
			textBox64.Style.BackgroundColor = Color.White;
			textBox64.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox64.Style.BorderStyle.Default = BorderType.Solid;
			textBox64.Style.BorderStyle.Top = BorderType.None;
			textBox64.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox64.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox64.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox64.Style.Font.Bold = true;
			textBox64.Style.Font.Name = "맑은 고딕";
			textBox64.Style.Font.Size = Unit.Point(11.0);
			textBox64.Style.TextAlign = HorizontalAlign.Center;
			textBox64.Style.VerticalAlign = VerticalAlign.Middle;
			textBox64.Value = "품     명";
			textBox65.Location = new PointU(Unit.Cm(0.0), Unit.Cm(3.6007006168365479));
			textBox65.Name = "textBox65";
			textBox65.Size = new SizeU(Unit.Cm(1.9998998641967773), Unit.Cm(0.800000011920929));
			textBox65.Style.BackgroundColor = Color.White;
			textBox65.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox65.Style.BorderStyle.Default = BorderType.Solid;
			textBox65.Style.BorderStyle.Top = BorderType.None;
			textBox65.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox65.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox65.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox65.Style.Font.Bold = true;
			textBox65.Style.Font.Name = "맑은 고딕";
			textBox65.Style.Font.Size = Unit.Point(11.0);
			textBox65.Style.TextAlign = HorizontalAlign.Center;
			textBox65.Style.VerticalAlign = VerticalAlign.Middle;
			textBox65.Value = "생산수량";
			textBox66.Location = new PointU(Unit.Cm(0.0), Unit.Cm(4.4009013175964355));
			textBox66.Name = "textBox66";
			textBox66.Size = new SizeU(Unit.Cm(1.9998998641967773), Unit.Cm(0.800000011920929));
			textBox66.Style.BackgroundColor = Color.White;
			textBox66.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox66.Style.BorderStyle.Default = BorderType.Solid;
			textBox66.Style.BorderStyle.Top = BorderType.None;
			textBox66.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox66.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox66.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox66.Style.Font.Bold = true;
			textBox66.Style.Font.Name = "맑은 고딕";
			textBox66.Style.Font.Size = Unit.Point(11.0);
			textBox66.Style.TextAlign = HorizontalAlign.Center;
			textBox66.Style.VerticalAlign = VerticalAlign.Middle;
			textBox66.Value = "생산일자";
			textBox67.Location = new PointU(Unit.Cm(0.0), Unit.Cm(5.2011017799377441));
			textBox67.Name = "textBox67";
			textBox67.Size = new SizeU(Unit.Cm(1.9998998641967773), Unit.Cm(1.2987978458404541));
			textBox67.Style.BackgroundColor = Color.White;
			textBox67.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox67.Style.BorderStyle.Default = BorderType.Solid;
			textBox67.Style.BorderStyle.Right = BorderType.Solid;
			textBox67.Style.BorderStyle.Top = BorderType.None;
			textBox67.Style.BorderWidth.Bottom = Unit.Point(1.0);
			textBox67.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox67.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox67.Style.Font.Bold = true;
			textBox67.Style.Font.Name = "맑은 고딕";
			textBox67.Style.Font.Size = Unit.Point(11.0);
			textBox67.Style.TextAlign = HorizontalAlign.Center;
			textBox67.Style.VerticalAlign = VerticalAlign.Middle;
			textBox67.Value = "LOT NO.";
			textBox68.Location = new PointU(Unit.Cm(0.00010032494901679456), Unit.Cm(2.000300407409668));
			textBox68.Name = "textBox68";
			textBox68.Size = new SizeU(Unit.Cm(1.9998998641967773), Unit.Cm(0.800000011920929));
			textBox68.Style.BackgroundColor = Color.White;
			textBox68.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox68.Style.BorderStyle.Default = BorderType.Solid;
			textBox68.Style.BorderStyle.Top = BorderType.None;
			textBox68.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox68.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox68.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox68.Style.Font.Bold = true;
			textBox68.Style.Font.Name = "맑은 고딕";
			textBox68.Style.Font.Size = Unit.Point(11.0);
			textBox68.Style.TextAlign = HorizontalAlign.Center;
			textBox68.Style.VerticalAlign = VerticalAlign.Middle;
			textBox68.Value = "품     번";
			textBox69.Bindings.Add(new Binding("Value", "=Fields.CARTYPE7"));
			textBox69.Location = new PointU(Unit.Cm(2.0000998973846436), Unit.Cm(1.2001000642776489));
			textBox69.Name = "textBox69";
			textBox69.Size = new SizeU(Unit.Cm(3.9995999336242676), Unit.Cm(0.800000011920929));
			textBox69.Style.BackgroundColor = Color.White;
			textBox69.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox69.Style.BorderStyle.Default = BorderType.Solid;
			textBox69.Style.BorderStyle.Top = BorderType.Solid;
			textBox69.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox69.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox69.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox69.Style.Font.Bold = true;
			textBox69.Style.Font.Name = "맑은 고딕";
			textBox69.Style.Font.Size = Unit.Point(11.0);
			textBox69.Style.TextAlign = HorizontalAlign.Center;
			textBox69.Style.VerticalAlign = VerticalAlign.Middle;
			textBox69.Value = "";
			textBox70.Bindings.Add(new Binding("Value", "=Fields.ITEMCODE7"));
			textBox70.Location = new PointU(Unit.Cm(2.0001001358032227), Unit.Cm(2.0003006458282471));
			textBox70.Name = "textBox70";
			textBox70.Size = new SizeU(Unit.Cm(3.9995999336242676), Unit.Cm(0.800000011920929));
			textBox70.Style.BackgroundColor = Color.White;
			textBox70.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox70.Style.BorderStyle.Default = BorderType.Solid;
			textBox70.Style.BorderStyle.Top = BorderType.None;
			textBox70.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox70.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox70.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox70.Style.Font.Bold = true;
			textBox70.Style.Font.Name = "맑은 고딕";
			textBox70.Style.Font.Size = Unit.Point(11.0);
			textBox70.Style.TextAlign = HorizontalAlign.Center;
			textBox70.Style.VerticalAlign = VerticalAlign.Middle;
			textBox70.Value = "";
			textBox71.Bindings.Add(new Binding("Value", "=Fields.ITEMNAME7"));
			textBox71.Location = new PointU(Unit.Cm(2.0001001358032227), Unit.Cm(2.8005011081695557));
			textBox71.Name = "textBox71";
			textBox71.Size = new SizeU(Unit.Cm(3.9995999336242676), Unit.Cm(0.800000011920929));
			textBox71.Style.BackgroundColor = Color.White;
			textBox71.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox71.Style.BorderStyle.Default = BorderType.Solid;
			textBox71.Style.BorderStyle.Top = BorderType.Solid;
			textBox71.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox71.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox71.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox71.Style.Font.Bold = true;
			textBox71.Style.Font.Name = "맑은 고딕";
			textBox71.Style.Font.Size = Unit.Point(10.0);
			textBox71.Style.TextAlign = HorizontalAlign.Left;
			textBox71.Style.VerticalAlign = VerticalAlign.Middle;
			textBox71.Value = "";
			textBox72.Bindings.Add(new Binding("Value", "=Fields.QTY7"));
			textBox72.Location = new PointU(Unit.Cm(2.000300407409668), Unit.Cm(3.6007006168365479));
			textBox72.Name = "textBox72";
			textBox72.Size = new SizeU(Unit.Cm(2.9995996952056885), Unit.Cm(0.800000011920929));
			textBox72.Style.BackgroundColor = Color.White;
			textBox72.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox72.Style.BorderStyle.Default = BorderType.Solid;
			textBox72.Style.BorderStyle.Right = BorderType.None;
			textBox72.Style.BorderStyle.Top = BorderType.None;
			textBox72.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox72.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox72.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox72.Style.Font.Bold = true;
			textBox72.Style.Font.Name = "맑은 고딕";
			textBox72.Style.Font.Size = Unit.Point(11.0);
			textBox72.Style.TextAlign = HorizontalAlign.Center;
			textBox72.Style.VerticalAlign = VerticalAlign.Middle;
			textBox72.Value = "";
			textBox73.Bindings.Add(new Binding("Value", "=Fields.UNITCODE7"));
			textBox73.Location = new PointU(Unit.Cm(4.9999003410339355), Unit.Cm(3.6007015705108643));
			textBox73.Name = "textBox73";
			textBox73.Size = new SizeU(Unit.Cm(0.99980008602142334), Unit.Cm(0.800000011920929));
			textBox73.Style.BackgroundColor = Color.White;
			textBox73.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox73.Style.BorderStyle.Default = BorderType.Solid;
			textBox73.Style.BorderStyle.Left = BorderType.None;
			textBox73.Style.BorderStyle.Top = BorderType.None;
			textBox73.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox73.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox73.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox73.Style.Font.Bold = true;
			textBox73.Style.Font.Name = "맑은 고딕";
			textBox73.Style.Font.Size = Unit.Point(11.0);
			textBox73.Style.TextAlign = HorizontalAlign.Center;
			textBox73.Style.VerticalAlign = VerticalAlign.Middle;
			textBox73.Value = "";
			textBox74.Bindings.Add(new Binding("Value", "=Fields.PRODDATE7"));
			textBox74.Location = new PointU(Unit.Cm(2.0001001358032227), Unit.Cm(4.4009017944335938));
			textBox74.Name = "textBox74";
			textBox74.Size = new SizeU(Unit.Cm(4.9997997283935547), Unit.Cm(0.800000011920929));
			textBox74.Style.BackgroundColor = Color.White;
			textBox74.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox74.Style.BorderStyle.Default = BorderType.Solid;
			textBox74.Style.BorderStyle.Top = BorderType.None;
			textBox74.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox74.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox74.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox74.Style.Font.Bold = true;
			textBox74.Style.Font.Name = "맑은 고딕";
			textBox74.Style.Font.Size = Unit.Point(11.0);
			textBox74.Style.TextAlign = HorizontalAlign.Center;
			textBox74.Style.VerticalAlign = VerticalAlign.Middle;
			textBox74.Value = "";
			textBox75.Location = new PointU(Unit.Cm(7.0000996589660645), Unit.Cm(4.4009017944335938));
			textBox75.Name = "textBox75";
			textBox75.Size = new SizeU(Unit.Cm(1.1000000238418579), Unit.Cm(2.0999999046325684));
			textBox75.Style.BackgroundColor = Color.White;
			textBox75.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox75.Style.BorderStyle.Default = BorderType.Solid;
			textBox75.Style.BorderStyle.Left = BorderType.Solid;
			textBox75.Style.BorderStyle.Top = BorderType.None;
			textBox75.Style.BorderWidth.Bottom = Unit.Point(1.0);
			textBox75.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox75.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox75.Style.Font.Bold = true;
			textBox75.Style.Font.Name = "맑은 고딕";
			textBox75.Style.Font.Size = Unit.Point(11.0);
			textBox75.Style.TextAlign = HorizontalAlign.Center;
			textBox75.Style.VerticalAlign = VerticalAlign.Middle;
			textBox75.Value = "검\r\n사";
			barcode5.Bindings.Add(new Binding("Value", "=Fields.LOTNO7"));
			barcode5.Location = new PointU(Unit.Cm(1.9999990463256836), Unit.Cm(5.299799919128418));
			barcode5.Name = "barcode5";
			barcode5.ShowText = true;
			barcode5.Size = new SizeU(Unit.Cm(5.0), Unit.Cm(1.2000000476837158));
			barcode5.Stretch = true;
			barcode5.Style.BorderStyle.Default = BorderType.None;
			barcode5.Style.BorderWidth.Default = Unit.Point(0.5);
			barcode5.Style.Font.Name = "맑은 고딕";
			barcode5.Style.Font.Size = Unit.Point(8.0);
			barcode5.Style.TextAlign = HorizontalAlign.Center;
			barcode5.Style.VerticalAlign = VerticalAlign.Bottom;
			barcode5.Value = "C201704191147X00000129372392";
			pictureBox7.Location = new PointU(Unit.Cm(5.9995999336242676), Unit.Cm(1.2002012729644775));
			pictureBox7.MimeType = "";
			pictureBox7.Name = "pictureBox7";
			pictureBox7.Size = new SizeU(Unit.Cm(3.8003005981445313), Unit.Cm(3.2006008625030518));
			pictureBox7.Sizing = ImageSizeMode.Stretch;
			pictureBox7.Style.BackgroundImage.MimeType = "image/bmp";
			pictureBox7.Style.BackgroundImage.Repeat = BackgroundRepeat.NoRepeat;
			pictureBox7.Style.BorderStyle.Bottom = BorderType.Solid;
			pictureBox7.Style.BorderStyle.Top = BorderType.Solid;
			pictureBox7.Style.BorderWidth.Default = Unit.Point(0.5);
			pictureBox7.Value = "";
			panel6.Items.AddRange(new ReportItemBase[17]
			{
				textBox76,
				textBox77,
				textBox78,
				textBox79,
				textBox80,
				textBox81,
				textBox82,
				textBox83,
				textBox84,
				textBox85,
				textBox86,
				textBox87,
				textBox88,
				textBox89,
				textBox90,
				barcode6,
				pictureBox4
			});
			panel6.Location = new PointU(Unit.Cm(10.650100708007812), Unit.Cm(7.100100040435791));
			panel6.Name = "panel6";
			panel6.Size = new SizeU(Unit.Cm(9.799901008605957), Unit.Cm(6.5));
			panel6.Style.BorderStyle.Default = BorderType.Solid;
			panel6.Style.BorderWidth.Default = Unit.Point(1.0);
			textBox76.Location = new PointU(Unit.Cm(0.00010032494901679456), Unit.Cm(0.00010012308484874666));
			textBox76.Name = "textBox76";
			textBox76.Size = new SizeU(Unit.Cm(5.9997997283935547), Unit.Cm(1.1998000144958496));
			textBox76.Style.BackgroundColor = Color.White;
			textBox76.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox76.Style.BorderStyle.Default = BorderType.Solid;
			textBox76.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox76.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox76.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox76.Style.BorderWidth.Top = Unit.Point(1.0);
			textBox76.Style.Font.Bold = true;
			textBox76.Style.Font.Name = "맑은 고딕";
			textBox76.Style.Font.Size = Unit.Point(20.0);
			textBox76.Style.TextAlign = HorizontalAlign.Center;
			textBox76.Style.VerticalAlign = VerticalAlign.Middle;
			textBox76.Value = "부 품 식 별 표";
			textBox77.Location = new PointU(Unit.Cm(5.9998998641967773), Unit.Cm(0.0));
			textBox77.Name = "textBox77";
			textBox77.Size = new SizeU(Unit.Cm(3.7999999523162842), Unit.Cm(1.2000000476837158));
			textBox77.Style.BackgroundColor = Color.White;
			textBox77.Style.BorderStyle.Bottom = BorderType.None;
			textBox77.Style.BorderStyle.Default = BorderType.Solid;
			textBox77.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox77.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox77.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox77.Style.BorderWidth.Right = Unit.Point(1.0);
			textBox77.Style.BorderWidth.Top = Unit.Point(1.0);
			textBox77.Style.Font.Bold = true;
			textBox77.Style.Font.Name = "맑은 고딕";
			textBox77.Style.Font.Size = Unit.Point(16.0);
			textBox77.Style.Padding.Left = Unit.Cm(0.0);
			textBox77.Style.Padding.Right = Unit.Cm(0.0);
			textBox77.Style.TextAlign = HorizontalAlign.Center;
			textBox77.Style.VerticalAlign = VerticalAlign.Middle;
			textBox77.Value = "(주)제이에스디";
			textBox78.Location = new PointU(Unit.Cm(0.0), Unit.Cm(1.200100302696228));
			textBox78.Name = "textBox78";
			textBox78.Size = new SizeU(Unit.Cm(1.9998998641967773), Unit.Cm(0.800000011920929));
			textBox78.Style.BackgroundColor = Color.White;
			textBox78.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox78.Style.BorderStyle.Default = BorderType.Solid;
			textBox78.Style.BorderStyle.Top = BorderType.Solid;
			textBox78.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox78.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox78.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox78.Style.Font.Bold = true;
			textBox78.Style.Font.Name = "맑은 고딕";
			textBox78.Style.Font.Size = Unit.Point(11.0);
			textBox78.Style.TextAlign = HorizontalAlign.Center;
			textBox78.Style.VerticalAlign = VerticalAlign.Middle;
			textBox78.Value = "차     종";
			textBox79.Location = new PointU(Unit.Cm(0.0), Unit.Cm(2.8005001544952393));
			textBox79.Name = "textBox79";
			textBox79.Size = new SizeU(Unit.Cm(1.9998998641967773), Unit.Cm(0.800000011920929));
			textBox79.Style.BackgroundColor = Color.White;
			textBox79.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox79.Style.BorderStyle.Default = BorderType.Solid;
			textBox79.Style.BorderStyle.Top = BorderType.None;
			textBox79.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox79.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox79.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox79.Style.Font.Bold = true;
			textBox79.Style.Font.Name = "맑은 고딕";
			textBox79.Style.Font.Size = Unit.Point(11.0);
			textBox79.Style.TextAlign = HorizontalAlign.Center;
			textBox79.Style.VerticalAlign = VerticalAlign.Middle;
			textBox79.Value = "품     명";
			textBox80.Location = new PointU(Unit.Cm(0.0), Unit.Cm(3.6007006168365479));
			textBox80.Name = "textBox80";
			textBox80.Size = new SizeU(Unit.Cm(1.9998998641967773), Unit.Cm(0.800000011920929));
			textBox80.Style.BackgroundColor = Color.White;
			textBox80.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox80.Style.BorderStyle.Default = BorderType.Solid;
			textBox80.Style.BorderStyle.Top = BorderType.None;
			textBox80.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox80.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox80.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox80.Style.Font.Bold = true;
			textBox80.Style.Font.Name = "맑은 고딕";
			textBox80.Style.Font.Size = Unit.Point(11.0);
			textBox80.Style.TextAlign = HorizontalAlign.Center;
			textBox80.Style.VerticalAlign = VerticalAlign.Middle;
			textBox80.Value = "생산수량";
			textBox81.Location = new PointU(Unit.Cm(0.0), Unit.Cm(4.4009013175964355));
			textBox81.Name = "textBox81";
			textBox81.Size = new SizeU(Unit.Cm(1.9998998641967773), Unit.Cm(0.800000011920929));
			textBox81.Style.BackgroundColor = Color.White;
			textBox81.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox81.Style.BorderStyle.Default = BorderType.Solid;
			textBox81.Style.BorderStyle.Top = BorderType.None;
			textBox81.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox81.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox81.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox81.Style.Font.Bold = true;
			textBox81.Style.Font.Name = "맑은 고딕";
			textBox81.Style.Font.Size = Unit.Point(11.0);
			textBox81.Style.TextAlign = HorizontalAlign.Center;
			textBox81.Style.VerticalAlign = VerticalAlign.Middle;
			textBox81.Value = "생산일자";
			textBox82.Location = new PointU(Unit.Cm(0.0), Unit.Cm(5.2011017799377441));
			textBox82.Name = "textBox82";
			textBox82.Size = new SizeU(Unit.Cm(1.9998998641967773), Unit.Cm(1.2987978458404541));
			textBox82.Style.BackgroundColor = Color.White;
			textBox82.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox82.Style.BorderStyle.Default = BorderType.Solid;
			textBox82.Style.BorderStyle.Right = BorderType.Solid;
			textBox82.Style.BorderStyle.Top = BorderType.None;
			textBox82.Style.BorderWidth.Bottom = Unit.Point(1.0);
			textBox82.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox82.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox82.Style.Font.Bold = true;
			textBox82.Style.Font.Name = "맑은 고딕";
			textBox82.Style.Font.Size = Unit.Point(11.0);
			textBox82.Style.TextAlign = HorizontalAlign.Center;
			textBox82.Style.VerticalAlign = VerticalAlign.Middle;
			textBox82.Value = "LOT NO.";
			textBox83.Location = new PointU(Unit.Cm(0.00010032494901679456), Unit.Cm(2.000300407409668));
			textBox83.Name = "textBox83";
			textBox83.Size = new SizeU(Unit.Cm(1.9998998641967773), Unit.Cm(0.800000011920929));
			textBox83.Style.BackgroundColor = Color.White;
			textBox83.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox83.Style.BorderStyle.Default = BorderType.Solid;
			textBox83.Style.BorderStyle.Top = BorderType.None;
			textBox83.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox83.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox83.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox83.Style.Font.Bold = true;
			textBox83.Style.Font.Name = "맑은 고딕";
			textBox83.Style.Font.Size = Unit.Point(11.0);
			textBox83.Style.TextAlign = HorizontalAlign.Center;
			textBox83.Style.VerticalAlign = VerticalAlign.Middle;
			textBox83.Value = "품     번";
			textBox84.Bindings.Add(new Binding("Value", "=Fields.CARTYPE4"));
			textBox84.Location = new PointU(Unit.Cm(2.0000998973846436), Unit.Cm(1.2001000642776489));
			textBox84.Name = "textBox84";
			textBox84.Size = new SizeU(Unit.Cm(3.9995999336242676), Unit.Cm(0.800000011920929));
			textBox84.Style.BackgroundColor = Color.White;
			textBox84.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox84.Style.BorderStyle.Default = BorderType.Solid;
			textBox84.Style.BorderStyle.Top = BorderType.Solid;
			textBox84.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox84.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox84.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox84.Style.Font.Bold = true;
			textBox84.Style.Font.Name = "맑은 고딕";
			textBox84.Style.Font.Size = Unit.Point(11.0);
			textBox84.Style.TextAlign = HorizontalAlign.Center;
			textBox84.Style.VerticalAlign = VerticalAlign.Middle;
			textBox84.Value = "";
			textBox85.Bindings.Add(new Binding("Value", "=Fields.ITEMCODE4"));
			textBox85.Location = new PointU(Unit.Cm(2.0001001358032227), Unit.Cm(2.0003006458282471));
			textBox85.Name = "textBox85";
			textBox85.Size = new SizeU(Unit.Cm(3.9995999336242676), Unit.Cm(0.800000011920929));
			textBox85.Style.BackgroundColor = Color.White;
			textBox85.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox85.Style.BorderStyle.Default = BorderType.Solid;
			textBox85.Style.BorderStyle.Top = BorderType.None;
			textBox85.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox85.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox85.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox85.Style.Font.Bold = true;
			textBox85.Style.Font.Name = "맑은 고딕";
			textBox85.Style.Font.Size = Unit.Point(11.0);
			textBox85.Style.TextAlign = HorizontalAlign.Center;
			textBox85.Style.VerticalAlign = VerticalAlign.Middle;
			textBox85.Value = "";
			textBox86.Bindings.Add(new Binding("Value", "=Fields.ITEMNAME4"));
			textBox86.Location = new PointU(Unit.Cm(2.0001001358032227), Unit.Cm(2.8005011081695557));
			textBox86.Name = "textBox86";
			textBox86.Size = new SizeU(Unit.Cm(3.9995999336242676), Unit.Cm(0.800000011920929));
			textBox86.Style.BackgroundColor = Color.White;
			textBox86.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox86.Style.BorderStyle.Default = BorderType.Solid;
			textBox86.Style.BorderStyle.Top = BorderType.Solid;
			textBox86.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox86.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox86.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox86.Style.Font.Bold = true;
			textBox86.Style.Font.Name = "맑은 고딕";
			textBox86.Style.Font.Size = Unit.Point(10.0);
			textBox86.Style.TextAlign = HorizontalAlign.Left;
			textBox86.Style.VerticalAlign = VerticalAlign.Middle;
			textBox86.Value = "";
			textBox87.Bindings.Add(new Binding("Value", "=Fields.QTY4"));
			textBox87.Location = new PointU(Unit.Cm(2.000300407409668), Unit.Cm(3.6007006168365479));
			textBox87.Name = "textBox87";
			textBox87.Size = new SizeU(Unit.Cm(2.9995996952056885), Unit.Cm(0.800000011920929));
			textBox87.Style.BackgroundColor = Color.White;
			textBox87.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox87.Style.BorderStyle.Default = BorderType.Solid;
			textBox87.Style.BorderStyle.Right = BorderType.None;
			textBox87.Style.BorderStyle.Top = BorderType.None;
			textBox87.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox87.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox87.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox87.Style.Font.Bold = true;
			textBox87.Style.Font.Name = "맑은 고딕";
			textBox87.Style.Font.Size = Unit.Point(11.0);
			textBox87.Style.TextAlign = HorizontalAlign.Center;
			textBox87.Style.VerticalAlign = VerticalAlign.Middle;
			textBox87.Value = "";
			textBox88.Bindings.Add(new Binding("Value", "=Fields.UNITCODE4"));
			textBox88.Location = new PointU(Unit.Cm(4.9999003410339355), Unit.Cm(3.6007015705108643));
			textBox88.Name = "textBox88";
			textBox88.Size = new SizeU(Unit.Cm(0.99980008602142334), Unit.Cm(0.800000011920929));
			textBox88.Style.BackgroundColor = Color.White;
			textBox88.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox88.Style.BorderStyle.Default = BorderType.Solid;
			textBox88.Style.BorderStyle.Left = BorderType.None;
			textBox88.Style.BorderStyle.Top = BorderType.None;
			textBox88.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox88.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox88.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox88.Style.Font.Bold = true;
			textBox88.Style.Font.Name = "맑은 고딕";
			textBox88.Style.Font.Size = Unit.Point(11.0);
			textBox88.Style.TextAlign = HorizontalAlign.Center;
			textBox88.Style.VerticalAlign = VerticalAlign.Middle;
			textBox88.Value = "";
			textBox89.Bindings.Add(new Binding("Value", "=Fields.PRODDATE4"));
			textBox89.Location = new PointU(Unit.Cm(2.0001001358032227), Unit.Cm(4.4009017944335938));
			textBox89.Name = "textBox89";
			textBox89.Size = new SizeU(Unit.Cm(4.9997997283935547), Unit.Cm(0.800000011920929));
			textBox89.Style.BackgroundColor = Color.White;
			textBox89.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox89.Style.BorderStyle.Default = BorderType.Solid;
			textBox89.Style.BorderStyle.Top = BorderType.None;
			textBox89.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox89.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox89.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox89.Style.Font.Bold = true;
			textBox89.Style.Font.Name = "맑은 고딕";
			textBox89.Style.Font.Size = Unit.Point(11.0);
			textBox89.Style.TextAlign = HorizontalAlign.Center;
			textBox89.Style.VerticalAlign = VerticalAlign.Middle;
			textBox89.Value = "";
			textBox90.Location = new PointU(Unit.Cm(7.0000996589660645), Unit.Cm(4.4009017944335938));
			textBox90.Name = "textBox90";
			textBox90.Size = new SizeU(Unit.Cm(1.1000000238418579), Unit.Cm(2.0999999046325684));
			textBox90.Style.BackgroundColor = Color.White;
			textBox90.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox90.Style.BorderStyle.Default = BorderType.Solid;
			textBox90.Style.BorderStyle.Left = BorderType.Solid;
			textBox90.Style.BorderStyle.Top = BorderType.None;
			textBox90.Style.BorderWidth.Bottom = Unit.Point(1.0);
			textBox90.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox90.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox90.Style.Font.Bold = true;
			textBox90.Style.Font.Name = "맑은 고딕";
			textBox90.Style.Font.Size = Unit.Point(11.0);
			textBox90.Style.TextAlign = HorizontalAlign.Center;
			textBox90.Style.VerticalAlign = VerticalAlign.Middle;
			textBox90.Value = "검\r\n사";
			barcode6.Bindings.Add(new Binding("Value", "=Fields.LOTNO4"));
			barcode6.Location = new PointU(Unit.Cm(1.9999990463256836), Unit.Cm(5.299799919128418));
			barcode6.Name = "barcode6";
			barcode6.ShowText = true;
			barcode6.Size = new SizeU(Unit.Cm(5.0), Unit.Cm(1.2000000476837158));
			barcode6.Stretch = true;
			barcode6.Style.BorderStyle.Default = BorderType.None;
			barcode6.Style.BorderWidth.Default = Unit.Point(0.5);
			barcode6.Style.Font.Name = "맑은 고딕";
			barcode6.Style.Font.Size = Unit.Point(8.0);
			barcode6.Style.TextAlign = HorizontalAlign.Center;
			barcode6.Style.VerticalAlign = VerticalAlign.Bottom;
			barcode6.Value = "C201704191147X00000129372392";
			pictureBox4.Location = new PointU(Unit.Cm(6.0003976821899414), Unit.Cm(1.200100302696228));
			pictureBox4.MimeType = "";
			pictureBox4.Name = "pictureBox4";
			pictureBox4.Size = new SizeU(Unit.Cm(3.7995028495788574), Unit.Cm(3.2006008625030518));
			pictureBox4.Sizing = ImageSizeMode.Stretch;
			pictureBox4.Style.BackgroundImage.MimeType = "image/bmp";
			pictureBox4.Style.BackgroundImage.Repeat = BackgroundRepeat.NoRepeat;
			pictureBox4.Style.BorderStyle.Bottom = BorderType.Solid;
			pictureBox4.Style.BorderStyle.Top = BorderType.Solid;
			pictureBox4.Style.BorderWidth.Default = Unit.Point(0.5);
			pictureBox4.Value = "";
			panel7.Items.AddRange(new ReportItemBase[17]
			{
				textBox91,
				textBox92,
				textBox93,
				textBox94,
				textBox95,
				textBox96,
				textBox97,
				textBox98,
				textBox99,
				textBox100,
				textBox101,
				textBox102,
				textBox103,
				textBox104,
				textBox105,
				barcode7,
				pictureBox6
			});
			panel7.Location = new PointU(Unit.Cm(10.649898529052734), Unit.Cm(14.200099945068359));
			panel7.Name = "panel7";
			panel7.Size = new SizeU(Unit.Cm(9.8001022338867187), Unit.Cm(6.5));
			panel7.Style.BorderStyle.Default = BorderType.Solid;
			panel7.Style.BorderWidth.Default = Unit.Point(1.0);
			textBox91.Location = new PointU(Unit.Cm(0.00010032494901679456), Unit.Cm(0.00010012308484874666));
			textBox91.Name = "textBox91";
			textBox91.Size = new SizeU(Unit.Cm(5.9997997283935547), Unit.Cm(1.1998000144958496));
			textBox91.Style.BackgroundColor = Color.White;
			textBox91.Style.BorderStyle.Default = BorderType.Solid;
			textBox91.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox91.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox91.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox91.Style.BorderWidth.Top = Unit.Point(1.0);
			textBox91.Style.Font.Bold = true;
			textBox91.Style.Font.Name = "맑은 고딕";
			textBox91.Style.Font.Size = Unit.Point(20.0);
			textBox91.Style.TextAlign = HorizontalAlign.Center;
			textBox91.Style.VerticalAlign = VerticalAlign.Middle;
			textBox91.Value = "부 품 식 별 표";
			textBox92.Location = new PointU(Unit.Cm(5.9998998641967773), Unit.Cm(0.0));
			textBox92.Name = "textBox92";
			textBox92.Size = new SizeU(Unit.Cm(3.7999999523162842), Unit.Cm(1.2000000476837158));
			textBox92.Style.BackgroundColor = Color.White;
			textBox92.Style.BorderStyle.Bottom = BorderType.None;
			textBox92.Style.BorderStyle.Default = BorderType.Solid;
			textBox92.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox92.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox92.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox92.Style.BorderWidth.Right = Unit.Point(1.0);
			textBox92.Style.BorderWidth.Top = Unit.Point(1.0);
			textBox92.Style.Font.Bold = true;
			textBox92.Style.Font.Name = "맑은 고딕";
			textBox92.Style.Font.Size = Unit.Point(16.0);
			textBox92.Style.Padding.Left = Unit.Cm(0.0);
			textBox92.Style.Padding.Right = Unit.Cm(0.0);
			textBox92.Style.TextAlign = HorizontalAlign.Center;
			textBox92.Style.VerticalAlign = VerticalAlign.Middle;
			textBox92.Value = "(주)제이에스디";
			textBox93.Location = new PointU(Unit.Cm(0.0), Unit.Cm(1.200100302696228));
			textBox93.Name = "textBox93";
			textBox93.Size = new SizeU(Unit.Cm(1.9998998641967773), Unit.Cm(0.800000011920929));
			textBox93.Style.BackgroundColor = Color.White;
			textBox93.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox93.Style.BorderStyle.Default = BorderType.Solid;
			textBox93.Style.BorderStyle.Top = BorderType.None;
			textBox93.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox93.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox93.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox93.Style.Font.Bold = true;
			textBox93.Style.Font.Name = "맑은 고딕";
			textBox93.Style.Font.Size = Unit.Point(11.0);
			textBox93.Style.TextAlign = HorizontalAlign.Center;
			textBox93.Style.VerticalAlign = VerticalAlign.Middle;
			textBox93.Value = "차     종";
			textBox94.Location = new PointU(Unit.Cm(0.0), Unit.Cm(2.8005001544952393));
			textBox94.Name = "textBox94";
			textBox94.Size = new SizeU(Unit.Cm(1.9998998641967773), Unit.Cm(0.800000011920929));
			textBox94.Style.BackgroundColor = Color.White;
			textBox94.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox94.Style.BorderStyle.Default = BorderType.Solid;
			textBox94.Style.BorderStyle.Top = BorderType.None;
			textBox94.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox94.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox94.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox94.Style.Font.Bold = true;
			textBox94.Style.Font.Name = "맑은 고딕";
			textBox94.Style.Font.Size = Unit.Point(11.0);
			textBox94.Style.TextAlign = HorizontalAlign.Center;
			textBox94.Style.VerticalAlign = VerticalAlign.Middle;
			textBox94.Value = "품     명";
			textBox95.Location = new PointU(Unit.Cm(0.0), Unit.Cm(3.6007006168365479));
			textBox95.Name = "textBox95";
			textBox95.Size = new SizeU(Unit.Cm(1.9998998641967773), Unit.Cm(0.800000011920929));
			textBox95.Style.BackgroundColor = Color.White;
			textBox95.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox95.Style.BorderStyle.Default = BorderType.Solid;
			textBox95.Style.BorderStyle.Top = BorderType.None;
			textBox95.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox95.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox95.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox95.Style.Font.Bold = true;
			textBox95.Style.Font.Name = "맑은 고딕";
			textBox95.Style.Font.Size = Unit.Point(11.0);
			textBox95.Style.TextAlign = HorizontalAlign.Center;
			textBox95.Style.VerticalAlign = VerticalAlign.Middle;
			textBox95.Value = "생산수량";
			textBox96.Location = new PointU(Unit.Cm(0.0), Unit.Cm(4.4009013175964355));
			textBox96.Name = "textBox96";
			textBox96.Size = new SizeU(Unit.Cm(1.9998998641967773), Unit.Cm(0.800000011920929));
			textBox96.Style.BackgroundColor = Color.White;
			textBox96.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox96.Style.BorderStyle.Default = BorderType.Solid;
			textBox96.Style.BorderStyle.Top = BorderType.None;
			textBox96.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox96.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox96.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox96.Style.Font.Bold = true;
			textBox96.Style.Font.Name = "맑은 고딕";
			textBox96.Style.Font.Size = Unit.Point(11.0);
			textBox96.Style.TextAlign = HorizontalAlign.Center;
			textBox96.Style.VerticalAlign = VerticalAlign.Middle;
			textBox96.Value = "생산일자";
			textBox97.Location = new PointU(Unit.Cm(0.0), Unit.Cm(5.2011017799377441));
			textBox97.Name = "textBox97";
			textBox97.Size = new SizeU(Unit.Cm(1.9998998641967773), Unit.Cm(1.2987978458404541));
			textBox97.Style.BackgroundColor = Color.White;
			textBox97.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox97.Style.BorderStyle.Default = BorderType.Solid;
			textBox97.Style.BorderStyle.Right = BorderType.Solid;
			textBox97.Style.BorderStyle.Top = BorderType.None;
			textBox97.Style.BorderWidth.Bottom = Unit.Point(1.0);
			textBox97.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox97.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox97.Style.Font.Bold = true;
			textBox97.Style.Font.Name = "맑은 고딕";
			textBox97.Style.Font.Size = Unit.Point(11.0);
			textBox97.Style.TextAlign = HorizontalAlign.Center;
			textBox97.Style.VerticalAlign = VerticalAlign.Middle;
			textBox97.Value = "LOT NO.";
			textBox98.Location = new PointU(Unit.Cm(0.00010032494901679456), Unit.Cm(2.000300407409668));
			textBox98.Name = "textBox98";
			textBox98.Size = new SizeU(Unit.Cm(1.9998998641967773), Unit.Cm(0.800000011920929));
			textBox98.Style.BackgroundColor = Color.White;
			textBox98.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox98.Style.BorderStyle.Default = BorderType.Solid;
			textBox98.Style.BorderStyle.Top = BorderType.None;
			textBox98.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox98.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox98.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox98.Style.Font.Bold = true;
			textBox98.Style.Font.Name = "맑은 고딕";
			textBox98.Style.Font.Size = Unit.Point(11.0);
			textBox98.Style.TextAlign = HorizontalAlign.Center;
			textBox98.Style.VerticalAlign = VerticalAlign.Middle;
			textBox98.Value = "품     번";
			textBox99.Bindings.Add(new Binding("Value", "=Fields.CARTYPE6"));
			textBox99.Location = new PointU(Unit.Cm(2.0000998973846436), Unit.Cm(1.2001000642776489));
			textBox99.Name = "textBox99";
			textBox99.Size = new SizeU(Unit.Cm(3.9995999336242676), Unit.Cm(0.800000011920929));
			textBox99.Style.BackgroundColor = Color.White;
			textBox99.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox99.Style.BorderStyle.Default = BorderType.Solid;
			textBox99.Style.BorderStyle.Top = BorderType.None;
			textBox99.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox99.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox99.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox99.Style.Font.Bold = true;
			textBox99.Style.Font.Name = "맑은 고딕";
			textBox99.Style.Font.Size = Unit.Point(11.0);
			textBox99.Style.TextAlign = HorizontalAlign.Center;
			textBox99.Style.VerticalAlign = VerticalAlign.Middle;
			textBox99.Value = "";
			textBox100.Bindings.Add(new Binding("Value", "=Fields.ITEMCODE6"));
			textBox100.Location = new PointU(Unit.Cm(2.0001001358032227), Unit.Cm(2.0003006458282471));
			textBox100.Name = "textBox100";
			textBox100.Size = new SizeU(Unit.Cm(3.9995999336242676), Unit.Cm(0.800000011920929));
			textBox100.Style.BackgroundColor = Color.White;
			textBox100.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox100.Style.BorderStyle.Default = BorderType.Solid;
			textBox100.Style.BorderStyle.Top = BorderType.None;
			textBox100.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox100.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox100.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox100.Style.Font.Bold = true;
			textBox100.Style.Font.Name = "맑은 고딕";
			textBox100.Style.Font.Size = Unit.Point(11.0);
			textBox100.Style.TextAlign = HorizontalAlign.Center;
			textBox100.Style.VerticalAlign = VerticalAlign.Middle;
			textBox100.Value = "";
			textBox101.Bindings.Add(new Binding("Value", "=Fields.ITEMNAME6"));
			textBox101.Location = new PointU(Unit.Cm(2.0001001358032227), Unit.Cm(2.8005011081695557));
			textBox101.Name = "textBox101";
			textBox101.Size = new SizeU(Unit.Cm(3.9995999336242676), Unit.Cm(0.800000011920929));
			textBox101.Style.BackgroundColor = Color.White;
			textBox101.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox101.Style.BorderStyle.Default = BorderType.Solid;
			textBox101.Style.BorderStyle.Top = BorderType.Solid;
			textBox101.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox101.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox101.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox101.Style.Font.Bold = true;
			textBox101.Style.Font.Name = "맑은 고딕";
			textBox101.Style.Font.Size = Unit.Point(10.0);
			textBox101.Style.TextAlign = HorizontalAlign.Left;
			textBox101.Style.VerticalAlign = VerticalAlign.Middle;
			textBox101.Value = "";
			textBox102.Bindings.Add(new Binding("Value", "=Fields.QTY6"));
			textBox102.Location = new PointU(Unit.Cm(2.000300407409668), Unit.Cm(3.6007006168365479));
			textBox102.Name = "textBox102";
			textBox102.Size = new SizeU(Unit.Cm(2.9995996952056885), Unit.Cm(0.800000011920929));
			textBox102.Style.BackgroundColor = Color.White;
			textBox102.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox102.Style.BorderStyle.Default = BorderType.Solid;
			textBox102.Style.BorderStyle.Right = BorderType.None;
			textBox102.Style.BorderStyle.Top = BorderType.None;
			textBox102.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox102.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox102.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox102.Style.Font.Bold = true;
			textBox102.Style.Font.Name = "맑은 고딕";
			textBox102.Style.Font.Size = Unit.Point(11.0);
			textBox102.Style.TextAlign = HorizontalAlign.Center;
			textBox102.Style.VerticalAlign = VerticalAlign.Middle;
			textBox102.Value = "";
			textBox103.Bindings.Add(new Binding("Value", "=Fields.UNITCODE6"));
			textBox103.Location = new PointU(Unit.Cm(4.9999003410339355), Unit.Cm(3.6007015705108643));
			textBox103.Name = "textBox103";
			textBox103.Size = new SizeU(Unit.Cm(0.99980008602142334), Unit.Cm(0.800000011920929));
			textBox103.Style.BackgroundColor = Color.White;
			textBox103.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox103.Style.BorderStyle.Default = BorderType.Solid;
			textBox103.Style.BorderStyle.Left = BorderType.None;
			textBox103.Style.BorderStyle.Top = BorderType.None;
			textBox103.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox103.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox103.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox103.Style.Font.Bold = true;
			textBox103.Style.Font.Name = "맑은 고딕";
			textBox103.Style.Font.Size = Unit.Point(11.0);
			textBox103.Style.TextAlign = HorizontalAlign.Center;
			textBox103.Style.VerticalAlign = VerticalAlign.Middle;
			textBox103.Value = "";
			textBox104.Bindings.Add(new Binding("Value", "=Fields.PRODDATE6"));
			textBox104.Location = new PointU(Unit.Cm(2.0001001358032227), Unit.Cm(4.4009017944335938));
			textBox104.Name = "textBox104";
			textBox104.Size = new SizeU(Unit.Cm(4.9997997283935547), Unit.Cm(0.800000011920929));
			textBox104.Style.BackgroundColor = Color.White;
			textBox104.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox104.Style.BorderStyle.Default = BorderType.Solid;
			textBox104.Style.BorderStyle.Top = BorderType.None;
			textBox104.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox104.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox104.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox104.Style.Font.Bold = true;
			textBox104.Style.Font.Name = "맑은 고딕";
			textBox104.Style.Font.Size = Unit.Point(11.0);
			textBox104.Style.TextAlign = HorizontalAlign.Center;
			textBox104.Style.VerticalAlign = VerticalAlign.Middle;
			textBox104.Value = "";
			textBox105.Location = new PointU(Unit.Cm(7.0000996589660645), Unit.Cm(4.4009017944335938));
			textBox105.Name = "textBox105";
			textBox105.Size = new SizeU(Unit.Cm(1.1000000238418579), Unit.Cm(2.0999999046325684));
			textBox105.Style.BackgroundColor = Color.White;
			textBox105.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox105.Style.BorderStyle.Default = BorderType.Solid;
			textBox105.Style.BorderStyle.Left = BorderType.Solid;
			textBox105.Style.BorderStyle.Top = BorderType.None;
			textBox105.Style.BorderWidth.Bottom = Unit.Point(1.0);
			textBox105.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox105.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox105.Style.Font.Bold = true;
			textBox105.Style.Font.Name = "맑은 고딕";
			textBox105.Style.Font.Size = Unit.Point(11.0);
			textBox105.Style.TextAlign = HorizontalAlign.Center;
			textBox105.Style.VerticalAlign = VerticalAlign.Middle;
			textBox105.Value = "검\r\n사";
			barcode7.Bindings.Add(new Binding("Value", "=Fields.LOTNO6"));
			barcode7.Location = new PointU(Unit.Cm(1.9999990463256836), Unit.Cm(5.299799919128418));
			barcode7.Name = "barcode7";
			barcode7.ShowText = true;
			barcode7.Size = new SizeU(Unit.Cm(5.0), Unit.Cm(1.2000000476837158));
			barcode7.Stretch = true;
			barcode7.Style.BorderStyle.Default = BorderType.None;
			barcode7.Style.BorderWidth.Default = Unit.Point(0.5);
			barcode7.Style.Font.Name = "맑은 고딕";
			barcode7.Style.Font.Size = Unit.Point(8.0);
			barcode7.Style.TextAlign = HorizontalAlign.Center;
			barcode7.Style.VerticalAlign = VerticalAlign.Bottom;
			barcode7.Value = "C201704191147X00000129372392";
			pictureBox6.Location = new PointU(Unit.Cm(5.9997997283935547), Unit.Cm(1.2001011371612549));
			pictureBox6.MimeType = "";
			pictureBox6.Name = "pictureBox6";
			pictureBox6.Size = new SizeU(Unit.Cm(3.800302267074585), Unit.Cm(3.2006008625030518));
			pictureBox6.Sizing = ImageSizeMode.Stretch;
			pictureBox6.Style.BackgroundImage.MimeType = "image/bmp";
			pictureBox6.Style.BackgroundImage.Repeat = BackgroundRepeat.NoRepeat;
			pictureBox6.Style.BorderStyle.Bottom = BorderType.Solid;
			pictureBox6.Style.BorderStyle.Top = BorderType.Solid;
			pictureBox6.Style.BorderWidth.Default = Unit.Point(0.5);
			pictureBox6.Value = "";
			panel8.Items.AddRange(new ReportItemBase[17]
			{
				textBox106,
				textBox107,
				textBox108,
				textBox109,
				textBox110,
				textBox111,
				textBox112,
				textBox113,
				textBox114,
				textBox115,
				textBox116,
				textBox117,
				textBox118,
				textBox119,
				textBox120,
				barcode8,
				pictureBox8
			});
			panel8.Location = new PointU(Unit.Cm(10.649798393249512), Unit.Cm(21.300100326538086));
			panel8.Name = "panel8";
			panel8.Size = new SizeU(Unit.Cm(9.800201416015625), Unit.Cm(6.5));
			panel8.Style.BorderStyle.Default = BorderType.Solid;
			panel8.Style.BorderWidth.Default = Unit.Point(1.0);
			textBox106.Location = new PointU(Unit.Cm(0.00010032494901679456), Unit.Cm(0.00010012308484874666));
			textBox106.Name = "textBox106";
			textBox106.Size = new SizeU(Unit.Cm(5.9997997283935547), Unit.Cm(1.1998000144958496));
			textBox106.Style.BackgroundColor = Color.White;
			textBox106.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox106.Style.BorderStyle.Default = BorderType.Solid;
			textBox106.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox106.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox106.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox106.Style.BorderWidth.Top = Unit.Point(1.0);
			textBox106.Style.Font.Bold = true;
			textBox106.Style.Font.Name = "맑은 고딕";
			textBox106.Style.Font.Size = Unit.Point(20.0);
			textBox106.Style.TextAlign = HorizontalAlign.Center;
			textBox106.Style.VerticalAlign = VerticalAlign.Middle;
			textBox106.Value = "부 품 식 별 표";
			textBox107.Location = new PointU(Unit.Cm(5.9998998641967773), Unit.Cm(0.0));
			textBox107.Name = "textBox107";
			textBox107.Size = new SizeU(Unit.Cm(3.7999999523162842), Unit.Cm(1.2000000476837158));
			textBox107.Style.BackgroundColor = Color.White;
			textBox107.Style.BorderStyle.Bottom = BorderType.None;
			textBox107.Style.BorderStyle.Default = BorderType.Solid;
			textBox107.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox107.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox107.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox107.Style.BorderWidth.Right = Unit.Point(1.0);
			textBox107.Style.BorderWidth.Top = Unit.Point(1.0);
			textBox107.Style.Font.Bold = true;
			textBox107.Style.Font.Name = "맑은 고딕";
			textBox107.Style.Font.Size = Unit.Point(16.0);
			textBox107.Style.Padding.Left = Unit.Cm(0.0);
			textBox107.Style.Padding.Right = Unit.Cm(0.0);
			textBox107.Style.TextAlign = HorizontalAlign.Center;
			textBox107.Style.VerticalAlign = VerticalAlign.Middle;
			textBox107.Value = "(주)제이에스디";
			textBox108.Location = new PointU(Unit.Cm(0.0), Unit.Cm(1.200100302696228));
			textBox108.Name = "textBox108";
			textBox108.Size = new SizeU(Unit.Cm(1.9998998641967773), Unit.Cm(0.800000011920929));
			textBox108.Style.BackgroundColor = Color.White;
			textBox108.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox108.Style.BorderStyle.Default = BorderType.Solid;
			textBox108.Style.BorderStyle.Top = BorderType.Solid;
			textBox108.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox108.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox108.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox108.Style.Font.Bold = true;
			textBox108.Style.Font.Name = "맑은 고딕";
			textBox108.Style.Font.Size = Unit.Point(11.0);
			textBox108.Style.TextAlign = HorizontalAlign.Center;
			textBox108.Style.VerticalAlign = VerticalAlign.Middle;
			textBox108.Value = "차     종";
			textBox109.Location = new PointU(Unit.Cm(0.0), Unit.Cm(2.8005001544952393));
			textBox109.Name = "textBox109";
			textBox109.Size = new SizeU(Unit.Cm(1.9998998641967773), Unit.Cm(0.800000011920929));
			textBox109.Style.BackgroundColor = Color.White;
			textBox109.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox109.Style.BorderStyle.Default = BorderType.Solid;
			textBox109.Style.BorderStyle.Top = BorderType.None;
			textBox109.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox109.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox109.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox109.Style.Font.Bold = true;
			textBox109.Style.Font.Name = "맑은 고딕";
			textBox109.Style.Font.Size = Unit.Point(11.0);
			textBox109.Style.TextAlign = HorizontalAlign.Center;
			textBox109.Style.VerticalAlign = VerticalAlign.Middle;
			textBox109.Value = "품     명";
			textBox110.Location = new PointU(Unit.Cm(0.0), Unit.Cm(3.6007006168365479));
			textBox110.Name = "textBox110";
			textBox110.Size = new SizeU(Unit.Cm(1.9998998641967773), Unit.Cm(0.800000011920929));
			textBox110.Style.BackgroundColor = Color.White;
			textBox110.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox110.Style.BorderStyle.Default = BorderType.Solid;
			textBox110.Style.BorderStyle.Top = BorderType.None;
			textBox110.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox110.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox110.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox110.Style.Font.Bold = true;
			textBox110.Style.Font.Name = "맑은 고딕";
			textBox110.Style.Font.Size = Unit.Point(11.0);
			textBox110.Style.TextAlign = HorizontalAlign.Center;
			textBox110.Style.VerticalAlign = VerticalAlign.Middle;
			textBox110.Value = "생산수량";
			textBox111.Location = new PointU(Unit.Cm(0.0), Unit.Cm(4.4009013175964355));
			textBox111.Name = "textBox111";
			textBox111.Size = new SizeU(Unit.Cm(1.9998998641967773), Unit.Cm(0.800000011920929));
			textBox111.Style.BackgroundColor = Color.White;
			textBox111.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox111.Style.BorderStyle.Default = BorderType.Solid;
			textBox111.Style.BorderStyle.Top = BorderType.None;
			textBox111.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox111.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox111.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox111.Style.Font.Bold = true;
			textBox111.Style.Font.Name = "맑은 고딕";
			textBox111.Style.Font.Size = Unit.Point(11.0);
			textBox111.Style.TextAlign = HorizontalAlign.Center;
			textBox111.Style.VerticalAlign = VerticalAlign.Middle;
			textBox111.Value = "생산일자";
			textBox112.Location = new PointU(Unit.Cm(0.0), Unit.Cm(5.2011017799377441));
			textBox112.Name = "textBox112";
			textBox112.Size = new SizeU(Unit.Cm(1.9998998641967773), Unit.Cm(1.2987978458404541));
			textBox112.Style.BackgroundColor = Color.White;
			textBox112.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox112.Style.BorderStyle.Default = BorderType.Solid;
			textBox112.Style.BorderStyle.Right = BorderType.Solid;
			textBox112.Style.BorderStyle.Top = BorderType.None;
			textBox112.Style.BorderWidth.Bottom = Unit.Point(1.0);
			textBox112.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox112.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox112.Style.Font.Bold = true;
			textBox112.Style.Font.Name = "맑은 고딕";
			textBox112.Style.Font.Size = Unit.Point(11.0);
			textBox112.Style.TextAlign = HorizontalAlign.Center;
			textBox112.Style.VerticalAlign = VerticalAlign.Middle;
			textBox112.Value = "LOT NO.";
			textBox113.Location = new PointU(Unit.Cm(0.00010032494901679456), Unit.Cm(2.000300407409668));
			textBox113.Name = "textBox113";
			textBox113.Size = new SizeU(Unit.Cm(1.9998998641967773), Unit.Cm(0.800000011920929));
			textBox113.Style.BackgroundColor = Color.White;
			textBox113.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox113.Style.BorderStyle.Default = BorderType.Solid;
			textBox113.Style.BorderStyle.Top = BorderType.None;
			textBox113.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox113.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox113.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox113.Style.Font.Bold = true;
			textBox113.Style.Font.Name = "맑은 고딕";
			textBox113.Style.Font.Size = Unit.Point(11.0);
			textBox113.Style.TextAlign = HorizontalAlign.Center;
			textBox113.Style.VerticalAlign = VerticalAlign.Middle;
			textBox113.Value = "품     번";
			textBox114.Bindings.Add(new Binding("Value", "=Fields.CARTYPE8"));
			textBox114.Location = new PointU(Unit.Cm(2.0000998973846436), Unit.Cm(1.2001000642776489));
			textBox114.Name = "textBox114";
			textBox114.Size = new SizeU(Unit.Cm(3.9995999336242676), Unit.Cm(0.800000011920929));
			textBox114.Style.BackgroundColor = Color.White;
			textBox114.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox114.Style.BorderStyle.Default = BorderType.Solid;
			textBox114.Style.BorderStyle.Top = BorderType.Solid;
			textBox114.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox114.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox114.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox114.Style.Font.Bold = true;
			textBox114.Style.Font.Name = "맑은 고딕";
			textBox114.Style.Font.Size = Unit.Point(11.0);
			textBox114.Style.TextAlign = HorizontalAlign.Center;
			textBox114.Style.VerticalAlign = VerticalAlign.Middle;
			textBox114.Value = "";
			textBox115.Bindings.Add(new Binding("Value", "=Fields.ITEMCODE8"));
			textBox115.Location = new PointU(Unit.Cm(2.0001001358032227), Unit.Cm(2.0003006458282471));
			textBox115.Name = "textBox115";
			textBox115.Size = new SizeU(Unit.Cm(3.9995999336242676), Unit.Cm(0.800000011920929));
			textBox115.Style.BackgroundColor = Color.White;
			textBox115.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox115.Style.BorderStyle.Default = BorderType.Solid;
			textBox115.Style.BorderStyle.Top = BorderType.None;
			textBox115.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox115.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox115.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox115.Style.Font.Bold = true;
			textBox115.Style.Font.Name = "맑은 고딕";
			textBox115.Style.Font.Size = Unit.Point(11.0);
			textBox115.Style.TextAlign = HorizontalAlign.Center;
			textBox115.Style.VerticalAlign = VerticalAlign.Middle;
			textBox115.Value = "";
			textBox116.Bindings.Add(new Binding("Value", "=Fields.ITEMNAME8"));
			textBox116.Location = new PointU(Unit.Cm(2.0001001358032227), Unit.Cm(2.8005011081695557));
			textBox116.Name = "textBox116";
			textBox116.Size = new SizeU(Unit.Cm(3.9995999336242676), Unit.Cm(0.800000011920929));
			textBox116.Style.BackgroundColor = Color.White;
			textBox116.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox116.Style.BorderStyle.Default = BorderType.Solid;
			textBox116.Style.BorderStyle.Top = BorderType.Solid;
			textBox116.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox116.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox116.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox116.Style.Font.Bold = true;
			textBox116.Style.Font.Name = "맑은 고딕";
			textBox116.Style.Font.Size = Unit.Point(10.0);
			textBox116.Style.TextAlign = HorizontalAlign.Left;
			textBox116.Style.VerticalAlign = VerticalAlign.Middle;
			textBox116.Value = "";
			textBox117.Bindings.Add(new Binding("Value", "=Fields.QTY8"));
			textBox117.Location = new PointU(Unit.Cm(2.000300407409668), Unit.Cm(3.6007006168365479));
			textBox117.Name = "textBox117";
			textBox117.Size = new SizeU(Unit.Cm(2.9995996952056885), Unit.Cm(0.800000011920929));
			textBox117.Style.BackgroundColor = Color.White;
			textBox117.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox117.Style.BorderStyle.Default = BorderType.Solid;
			textBox117.Style.BorderStyle.Right = BorderType.None;
			textBox117.Style.BorderStyle.Top = BorderType.None;
			textBox117.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox117.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox117.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox117.Style.Font.Bold = true;
			textBox117.Style.Font.Name = "맑은 고딕";
			textBox117.Style.Font.Size = Unit.Point(11.0);
			textBox117.Style.TextAlign = HorizontalAlign.Center;
			textBox117.Style.VerticalAlign = VerticalAlign.Middle;
			textBox117.Value = "";
			textBox118.Bindings.Add(new Binding("Value", "=Fields.UNITCODE8"));
			textBox118.Location = new PointU(Unit.Cm(4.9999003410339355), Unit.Cm(3.6007015705108643));
			textBox118.Name = "textBox118";
			textBox118.Size = new SizeU(Unit.Cm(0.99980008602142334), Unit.Cm(0.800000011920929));
			textBox118.Style.BackgroundColor = Color.White;
			textBox118.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox118.Style.BorderStyle.Default = BorderType.Solid;
			textBox118.Style.BorderStyle.Left = BorderType.None;
			textBox118.Style.BorderStyle.Top = BorderType.None;
			textBox118.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox118.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox118.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox118.Style.Font.Bold = true;
			textBox118.Style.Font.Name = "맑은 고딕";
			textBox118.Style.Font.Size = Unit.Point(11.0);
			textBox118.Style.TextAlign = HorizontalAlign.Center;
			textBox118.Style.VerticalAlign = VerticalAlign.Middle;
			textBox118.Value = "";
			textBox119.Bindings.Add(new Binding("Value", "=Fields.PRODDATE8"));
			textBox119.Location = new PointU(Unit.Cm(2.0001001358032227), Unit.Cm(4.4009017944335938));
			textBox119.Name = "textBox119";
			textBox119.Size = new SizeU(Unit.Cm(4.9997997283935547), Unit.Cm(0.800000011920929));
			textBox119.Style.BackgroundColor = Color.White;
			textBox119.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox119.Style.BorderStyle.Default = BorderType.Solid;
			textBox119.Style.BorderStyle.Top = BorderType.None;
			textBox119.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox119.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox119.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox119.Style.Font.Bold = true;
			textBox119.Style.Font.Name = "맑은 고딕";
			textBox119.Style.Font.Size = Unit.Point(11.0);
			textBox119.Style.TextAlign = HorizontalAlign.Center;
			textBox119.Style.VerticalAlign = VerticalAlign.Middle;
			textBox119.Value = "";
			textBox120.Location = new PointU(Unit.Cm(7.0000996589660645), Unit.Cm(4.4009017944335938));
			textBox120.Name = "textBox120";
			textBox120.Size = new SizeU(Unit.Cm(1.1000000238418579), Unit.Cm(2.0999999046325684));
			textBox120.Style.BackgroundColor = Color.White;
			textBox120.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox120.Style.BorderStyle.Default = BorderType.Solid;
			textBox120.Style.BorderStyle.Left = BorderType.Solid;
			textBox120.Style.BorderStyle.Top = BorderType.None;
			textBox120.Style.BorderWidth.Bottom = Unit.Point(1.0);
			textBox120.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox120.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox120.Style.Font.Bold = true;
			textBox120.Style.Font.Name = "맑은 고딕";
			textBox120.Style.Font.Size = Unit.Point(11.0);
			textBox120.Style.TextAlign = HorizontalAlign.Center;
			textBox120.Style.VerticalAlign = VerticalAlign.Middle;
			textBox120.Value = "검\r\n사";
			barcode8.Bindings.Add(new Binding("Value", "=Fields.LOTNO8"));
			barcode8.Location = new PointU(Unit.Cm(1.9999990463256836), Unit.Cm(5.299799919128418));
			barcode8.Name = "barcode8";
			barcode8.ShowText = true;
			barcode8.Size = new SizeU(Unit.Cm(5.0), Unit.Cm(1.2000000476837158));
			barcode8.Stretch = true;
			barcode8.Style.BorderStyle.Default = BorderType.None;
			barcode8.Style.BorderWidth.Default = Unit.Point(0.5);
			barcode8.Style.Font.Name = "맑은 고딕";
			barcode8.Style.Font.Size = Unit.Point(8.0);
			barcode8.Style.TextAlign = HorizontalAlign.Center;
			barcode8.Style.VerticalAlign = VerticalAlign.Bottom;
			barcode8.Value = "C201704191147X00000129372392";
			pictureBox8.Location = new PointU(Unit.Cm(5.9998998641967773), Unit.Cm(1.2001011371612549));
			pictureBox8.MimeType = "";
			pictureBox8.Name = "pictureBox8";
			pictureBox8.Size = new SizeU(Unit.Cm(3.800302267074585), Unit.Cm(3.2006008625030518));
			pictureBox8.Sizing = ImageSizeMode.Stretch;
			pictureBox8.Style.BackgroundImage.MimeType = "image/bmp";
			pictureBox8.Style.BackgroundImage.Repeat = BackgroundRepeat.NoRepeat;
			pictureBox8.Style.BorderStyle.Bottom = BorderType.Solid;
			pictureBox8.Style.BorderStyle.Top = BorderType.Solid;
			pictureBox8.Style.BorderWidth.Default = Unit.Point(0.5);
			pictureBox8.Value = "";
			base.DataSource = null;
			base.Items.AddRange(new ReportItemBase[1]
			{
				detail
			});
			base.Name = "DA3300R";
			base.PageSettings.Landscape = false;
			base.PageSettings.Margins = new MarginsU(Unit.Cm(0.0), Unit.Cm(0.0), Unit.Cm(0.30000001192092896), Unit.Cm(0.0));
			base.PageSettings.PaperKind = PaperKind.A4;
			base.Style.BackgroundColor = Color.White;
			base.Style.BorderWidth.Default = Unit.Point(1.0);
			base.Style.Font.Name = "Microsoft Sans Serif";
			styleRule.Selectors.AddRange(new ISelector[2]
			{
				new TypeSelector(typeof(TextItemBase)),
				new TypeSelector(typeof(HtmlTextBox))
			});
			styleRule.Style.Padding.Left = Unit.Point(2.0);
			styleRule.Style.Padding.Right = Unit.Point(2.0);
			base.StyleSheet.AddRange(new StyleRule[1]
			{
				styleRule
			});
			base.Width = Unit.Cm(21.0);
			((ISupportInitialize)this).EndInit();
		}
	}
}
