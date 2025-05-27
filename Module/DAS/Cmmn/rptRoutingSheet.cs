using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using Telerik.Reporting;
using Telerik.Reporting.Drawing;
using Telerik.Reporting.Processing;

namespace Cmmn
{
	public class rptRoutingSheet : Telerik.Reporting.Report
	{
		private ArrayList SumList = new ArrayList();

		private Telerik.Reporting.DetailSection detail;

		private ReportHeaderSection reportHeaderSection1;

		private Telerik.Reporting.TextBox textBox88;

		private Telerik.Reporting.TextBox textBox95;

		private Telerik.Reporting.TextBox textBox100;

		private Telerik.Reporting.TextBox textBox107;

		private Telerik.Reporting.TextBox textBox108;

		private Telerik.Reporting.TextBox textBox3;

		private Telerik.Reporting.TextBox textBox4;

		private Telerik.Reporting.TextBox textBox7;

		private Telerik.Reporting.TextBox textBox11;

		private Telerik.Reporting.TextBox textBox12;

		private Telerik.Reporting.TextBox textBox15;

		private Telerik.Reporting.TextBox textBox16;

		private Telerik.Reporting.TextBox textBox17;

		private Telerik.Reporting.TextBox textBox19;

		private Telerik.Reporting.TextBox textBox24;

		private Telerik.Reporting.TextBox textBox25;

		private Telerik.Reporting.TextBox textBox26;

		private Telerik.Reporting.TextBox textBox27;

		private Telerik.Reporting.TextBox textBox29;

		private Telerik.Reporting.TextBox textBox30;

		private Telerik.Reporting.TextBox textBox31;

		private Telerik.Reporting.TextBox textBox32;

		private Telerik.Reporting.TextBox textBox33;

		private Telerik.Reporting.Table DataTable;

		private Telerik.Reporting.TextBox textBox5;

		private Telerik.Reporting.TextBox textBox6;

		private Telerik.Reporting.TextBox textBox18;

		private Telerik.Reporting.TextBox textBox34;

		private Telerik.Reporting.TextBox textBox36;

		private Telerik.Reporting.TextBox textBox28;

		private Telerik.Reporting.TextBox textBox21;

		private Telerik.Reporting.TextBox textBox10;

		private Telerik.Reporting.TextBox textBox22;

		private Telerik.Reporting.TextBox textBox23;

		private Telerik.Reporting.TextBox textBox37;

		private Telerik.Reporting.TextBox textBox38;

		private Telerik.Reporting.TextBox textBox39;

		private Telerik.Reporting.TextBox textBox14;

		private Telerik.Reporting.Barcode barcode;

		private Telerik.Reporting.TextBox textBox13;

		private Telerik.Reporting.TextBox textBox94;

		private Telerik.Reporting.TextBox textBox99;

		private Telerik.Reporting.TextBox textBox2;

		private Telerik.Reporting.TextBox textBox1;

		private Telerik.Reporting.TextBox textBox20;

		private Telerik.Reporting.TextBox textBox42;

		private Telerik.Reporting.TextBox textBox45;

		private Telerik.Reporting.TextBox textBox47;

		private Telerik.Reporting.TextBox textBox50;

		private Telerik.Reporting.TextBox textBox51;

		private Telerik.Reporting.TextBox textBox54;

		private Telerik.Reporting.TextBox textBox55;

		private Telerik.Reporting.TextBox textBox56;

		private Telerik.Reporting.TextBox textBox57;

		private Telerik.Reporting.TextBox textBox58;

		private Telerik.Reporting.TextBox textBox59;

		private Telerik.Reporting.TextBox textBox60;

		private Telerik.Reporting.TextBox textBox61;

		private Telerik.Reporting.TextBox textBox64;

		private Telerik.Reporting.TextBox textBox65;

		private Telerik.Reporting.TextBox textBox66;

		private Telerik.Reporting.TextBox textBox67;

		private Telerik.Reporting.TextBox textBox68;

		private Telerik.Reporting.TextBox textBox69;

		private Telerik.Reporting.TextBox textBox70;

		private Telerik.Reporting.TextBox textBox71;

		private Telerik.Reporting.TextBox textBox74;

		private Telerik.Reporting.TextBox textBox75;

		private Telerik.Reporting.TextBox textBox76;

		private Telerik.Reporting.TextBox textBox77;

		private Telerik.Reporting.TextBox textBox78;

		private Telerik.Reporting.TextBox textBox79;

		private Telerik.Reporting.TextBox textBox80;

		private Telerik.Reporting.TextBox textBox81;

		private Telerik.Reporting.TextBox textBox84;

		private Telerik.Reporting.TextBox textBox85;

		private Telerik.Reporting.TextBox textBox86;

		private Telerik.Reporting.TextBox textBox87;

		private Telerik.Reporting.TextBox textBox89;

		private Telerik.Reporting.TextBox textBox90;

		private Telerik.Reporting.TextBox textBox91;

		private Telerik.Reporting.TextBox textBox92;

		private Telerik.Reporting.TextBox textBox97;

		private Telerik.Reporting.TextBox textBox98;

		private Telerik.Reporting.TextBox textBox101;

		private Telerik.Reporting.TextBox textBox102;

		private Telerik.Reporting.TextBox textBox103;

		private Telerik.Reporting.TextBox textBox104;

		private Telerik.Reporting.TextBox textBox105;

		private Telerik.Reporting.TextBox textBox106;

		private Telerik.Reporting.TextBox textBox111;

		private Telerik.Reporting.TextBox textBox112;

		private Telerik.Reporting.TextBox textBox113;

		private Telerik.Reporting.TextBox textBox114;

		private Telerik.Reporting.TextBox textBox115;

		private Telerik.Reporting.TextBox textBox116;

		private Telerik.Reporting.TextBox textBox117;

		private Telerik.Reporting.TextBox textBox118;

		private Telerik.Reporting.TextBox textBox121;

		private Telerik.Reporting.TextBox textBox122;

		private Telerik.Reporting.TextBox textBox123;

		private Telerik.Reporting.TextBox textBox124;

		private Telerik.Reporting.TextBox textBox125;

		private Telerik.Reporting.TextBox textBox126;

		private Telerik.Reporting.TextBox textBox127;

		private Telerik.Reporting.TextBox textBox128;

		private Telerik.Reporting.TextBox textBox131;

		private Telerik.Reporting.TextBox textBox132;

		private Telerik.Reporting.TextBox textBox133;

		private Telerik.Reporting.TextBox textBox134;

		private Telerik.Reporting.TextBox textBox135;

		private Telerik.Reporting.TextBox textBox136;

		private Telerik.Reporting.TextBox textBox137;

		private Telerik.Reporting.TextBox textBox138;

		private Telerik.Reporting.TextBox textBox141;

		private Telerik.Reporting.TextBox textBox142;

		private Telerik.Reporting.TextBox textBox143;

		private Telerik.Reporting.TextBox textBox144;

		private Telerik.Reporting.TextBox textBox145;

		private Telerik.Reporting.TextBox textBox146;

		private Telerik.Reporting.TextBox textBox147;

		private Telerik.Reporting.TextBox textBox148;

		private Telerik.Reporting.TextBox textBox151;

		private Telerik.Reporting.TextBox textBox152;

		private Telerik.Reporting.TextBox textBox153;

		private Telerik.Reporting.TextBox textBox154;

		private Telerik.Reporting.TextBox textBox155;

		private Telerik.Reporting.TextBox textBox156;

		private Telerik.Reporting.TextBox textBox157;

		private Telerik.Reporting.TextBox textBox158;

		private Telerik.Reporting.TextBox textBox161;

		private Telerik.Reporting.TextBox textBox162;

		private Telerik.Reporting.TextBox textBox163;

		private Telerik.Reporting.TextBox textBox164;

		private Telerik.Reporting.TextBox textBox165;

		private Telerik.Reporting.TextBox textBox166;

		private Telerik.Reporting.TextBox textBox167;

		private Telerik.Reporting.TextBox textBox168;

		private Telerik.Reporting.TextBox textBox171;

		private Telerik.Reporting.TextBox textBox172;

		private Telerik.Reporting.TextBox textBox173;

		private Telerik.Reporting.TextBox textBox174;

		private Telerik.Reporting.TextBox textBox175;

		private Telerik.Reporting.TextBox textBox176;

		private Telerik.Reporting.TextBox textBox177;

		private Telerik.Reporting.TextBox textBox178;

		private Telerik.Reporting.TextBox textBox181;

		private Telerik.Reporting.TextBox textBox182;

		private Telerik.Reporting.TextBox textBox183;

		private Telerik.Reporting.TextBox textBox184;

		private Telerik.Reporting.TextBox textBox185;

		private Telerik.Reporting.TextBox textBox186;

		private Telerik.Reporting.TextBox textBox187;

		private Telerik.Reporting.TextBox textBox188;

		private Telerik.Reporting.TextBox textBox191;

		private Telerik.Reporting.TextBox textBox192;

		private Telerik.Reporting.TextBox textBox193;

		private Telerik.Reporting.TextBox textBox194;

		private Telerik.Reporting.TextBox textBox195;

		private Telerik.Reporting.TextBox textBox196;

		private Telerik.Reporting.TextBox textBox197;

		private Telerik.Reporting.TextBox textBox35;

		private Telerik.Reporting.TextBox textBox52;

		private Telerik.Reporting.TextBox textBox62;

		private Telerik.Reporting.TextBox textBox72;

		private Telerik.Reporting.TextBox textBox82;

		private Telerik.Reporting.TextBox textBox93;

		private Telerik.Reporting.TextBox textBox109;

		private Telerik.Reporting.TextBox textBox119;

		private Telerik.Reporting.TextBox textBox129;

		private Telerik.Reporting.TextBox textBox139;

		private Telerik.Reporting.TextBox textBox149;

		private Telerik.Reporting.TextBox textBox159;

		private Telerik.Reporting.TextBox textBox169;

		private Telerik.Reporting.TextBox textBox179;

		private Telerik.Reporting.TextBox textBox189;

		private Telerik.Reporting.TextBox textBox44;

		private Telerik.Reporting.TextBox textBox46;

		private Telerik.Reporting.TextBox textBox41;

		private Telerik.Reporting.TextBox textBox40;

		private Telerik.Reporting.TextBox textBox49;

		private Telerik.Reporting.TextBox textBox48;

		private Telerik.Reporting.Table table1;

		private Telerik.Reporting.TextBox textBox8;

		private Telerik.Reporting.TextBox textBox9;

		private Telerik.Reporting.TextBox textBox43;

		private Telerik.Reporting.TextBox textBox53;

		private Telerik.Reporting.TextBox textBox63;

		private Telerik.Reporting.TextBox textBox73;

		private Telerik.Reporting.TextBox textBox83;

		private Telerik.Reporting.TextBox textBox96;

		private Telerik.Reporting.TextBox textBox110;

		private Telerik.Reporting.TextBox textBox120;

		private Telerik.Reporting.TextBox textBox130;

		private Telerik.Reporting.TextBox textBox140;

		private Telerik.Reporting.TextBox textBox150;

		private Telerik.Reporting.TextBox textBox160;

		private Telerik.Reporting.TextBox textBox170;

		private Telerik.Reporting.TextBox textBox180;

		private Telerik.Reporting.TextBox textBox190;

		private Telerik.Reporting.TextBox textBox198;

		private Telerik.Reporting.TextBox textBox199;

		private Telerik.Reporting.TextBox textBox200;

		private Telerik.Reporting.TextBox textBox201;

		private Telerik.Reporting.TextBox textBox202;

		private Telerik.Reporting.TextBox textBox203;

		private Telerik.Reporting.TextBox textBox204;

		private Telerik.Reporting.TextBox textBox205;

		private Telerik.Reporting.TextBox textBox206;

		private Telerik.Reporting.TextBox textBox207;

		private Telerik.Reporting.TextBox textBox208;

		private Telerik.Reporting.TextBox textBox209;

		private Telerik.Reporting.TextBox textBox210;

		private Telerik.Reporting.TextBox textBox211;

		private Telerik.Reporting.TextBox textBox212;

		private Telerik.Reporting.TextBox textBox309;

		private Telerik.Reporting.TextBox textBox310;

		private Telerik.Reporting.TextBox textBox311;

		private Telerik.Reporting.TextBox textBox324;

		private Telerik.Reporting.TextBox textBox325;

		private Telerik.Reporting.TextBox textBox326;

		private Telerik.Reporting.TextBox textBox327;

		private Telerik.Reporting.TextBox textBox328;

		private Telerik.Reporting.TextBox textBox329;

		private Telerik.Reporting.TextBox textBox330;

		private Telerik.Reporting.TextBox textBox331;

		private Telerik.Reporting.TextBox textBox332;

		private Telerik.Reporting.TextBox textBox333;

		private Telerik.Reporting.TextBox textBox334;

		private Telerik.Reporting.TextBox textBox213;

		public rptRoutingSheet()
		{
			InitializeComponent();
		}

		private void textBox76_ItemDataBound(object sender, EventArgs e)
		{
			int num = Convert.ToInt32(((Telerik.Reporting.Processing.TextBox)sender).Value);
			SumList.Add(num);
		}

		private void textBox46_ItemDataBound(object sender, EventArgs e)
		{
			int num = 0;
			foreach (int sum in SumList)
			{
				num += sum;
			}
			((Telerik.Reporting.Processing.TextBox)sender).Value = num;
			SumList.Clear();
		}

		private void InitializeComponent()
		{
			TableGroup tableGroup = new TableGroup();
			TableGroup tableGroup2 = new TableGroup();
			TableGroup tableGroup3 = new TableGroup();
			TableGroup tableGroup4 = new TableGroup();
			TableGroup tableGroup5 = new TableGroup();
			TableGroup tableGroup6 = new TableGroup();
			TableGroup tableGroup7 = new TableGroup();
			TableGroup tableGroup8 = new TableGroup();
			TableGroup tableGroup9 = new TableGroup();
			TableGroup tableGroup10 = new TableGroup();
			TableGroup tableGroup11 = new TableGroup();
			TableGroup tableGroup12 = new TableGroup();
			TableGroup tableGroup13 = new TableGroup();
			TableGroup tableGroup14 = new TableGroup();
			TableGroup tableGroup15 = new TableGroup();
			TableGroup tableGroup16 = new TableGroup();
			TableGroup tableGroup17 = new TableGroup();
			TableGroup tableGroup18 = new TableGroup();
			TableGroup tableGroup19 = new TableGroup();
			TableGroup tableGroup20 = new TableGroup();
			TableGroup tableGroup21 = new TableGroup();
			TableGroup tableGroup22 = new TableGroup();
			TableGroup tableGroup23 = new TableGroup();
			TableGroup tableGroup24 = new TableGroup();
			TableGroup tableGroup25 = new TableGroup();
			TableGroup tableGroup26 = new TableGroup();
			TableGroup tableGroup27 = new TableGroup();
			TableGroup tableGroup28 = new TableGroup();
			TableGroup tableGroup29 = new TableGroup();
			TableGroup tableGroup30 = new TableGroup();
			TableGroup tableGroup31 = new TableGroup();
			TableGroup tableGroup32 = new TableGroup();
			TableGroup tableGroup33 = new TableGroup();
			TableGroup tableGroup34 = new TableGroup();
			TableGroup tableGroup35 = new TableGroup();
			TableGroup tableGroup36 = new TableGroup();
			TableGroup tableGroup37 = new TableGroup();
			TableGroup tableGroup38 = new TableGroup();
			TableGroup tableGroup39 = new TableGroup();
			TableGroup tableGroup40 = new TableGroup();
			TableGroup tableGroup41 = new TableGroup();
			TableGroup tableGroup42 = new TableGroup();
			TableGroup tableGroup43 = new TableGroup();
			TableGroup tableGroup44 = new TableGroup();
			TableGroup tableGroup45 = new TableGroup();
			TableGroup tableGroup46 = new TableGroup();
			TableGroup tableGroup47 = new TableGroup();
			TableGroup tableGroup48 = new TableGroup();
			ReportParameter reportParameter = new ReportParameter();
			StyleRule styleRule = new StyleRule();
			textBox10 = new Telerik.Reporting.TextBox();
			textBox44 = new Telerik.Reporting.TextBox();
			textBox46 = new Telerik.Reporting.TextBox();
			textBox41 = new Telerik.Reporting.TextBox();
			textBox22 = new Telerik.Reporting.TextBox();
			textBox23 = new Telerik.Reporting.TextBox();
			textBox37 = new Telerik.Reporting.TextBox();
			textBox38 = new Telerik.Reporting.TextBox();
			textBox39 = new Telerik.Reporting.TextBox();
			textBox14 = new Telerik.Reporting.TextBox();
			textBox325 = new Telerik.Reporting.TextBox();
			textBox326 = new Telerik.Reporting.TextBox();
			textBox327 = new Telerik.Reporting.TextBox();
			textBox328 = new Telerik.Reporting.TextBox();
			textBox329 = new Telerik.Reporting.TextBox();
			textBox330 = new Telerik.Reporting.TextBox();
			textBox331 = new Telerik.Reporting.TextBox();
			textBox332 = new Telerik.Reporting.TextBox();
			textBox333 = new Telerik.Reporting.TextBox();
			textBox334 = new Telerik.Reporting.TextBox();
			detail = new Telerik.Reporting.DetailSection();
			DataTable = new Telerik.Reporting.Table();
			textBox2 = new Telerik.Reporting.TextBox();
			textBox5 = new Telerik.Reporting.TextBox();
			textBox6 = new Telerik.Reporting.TextBox();
			textBox18 = new Telerik.Reporting.TextBox();
			textBox34 = new Telerik.Reporting.TextBox();
			textBox36 = new Telerik.Reporting.TextBox();
			textBox28 = new Telerik.Reporting.TextBox();
			textBox21 = new Telerik.Reporting.TextBox();
			textBox1 = new Telerik.Reporting.TextBox();
			textBox20 = new Telerik.Reporting.TextBox();
			textBox42 = new Telerik.Reporting.TextBox();
			textBox45 = new Telerik.Reporting.TextBox();
			textBox47 = new Telerik.Reporting.TextBox();
			textBox49 = new Telerik.Reporting.TextBox();
			textBox50 = new Telerik.Reporting.TextBox();
			textBox51 = new Telerik.Reporting.TextBox();
			textBox54 = new Telerik.Reporting.TextBox();
			textBox55 = new Telerik.Reporting.TextBox();
			textBox56 = new Telerik.Reporting.TextBox();
			textBox57 = new Telerik.Reporting.TextBox();
			textBox58 = new Telerik.Reporting.TextBox();
			textBox59 = new Telerik.Reporting.TextBox();
			textBox60 = new Telerik.Reporting.TextBox();
			textBox61 = new Telerik.Reporting.TextBox();
			textBox64 = new Telerik.Reporting.TextBox();
			textBox65 = new Telerik.Reporting.TextBox();
			textBox66 = new Telerik.Reporting.TextBox();
			textBox67 = new Telerik.Reporting.TextBox();
			textBox68 = new Telerik.Reporting.TextBox();
			textBox69 = new Telerik.Reporting.TextBox();
			textBox70 = new Telerik.Reporting.TextBox();
			textBox71 = new Telerik.Reporting.TextBox();
			textBox74 = new Telerik.Reporting.TextBox();
			textBox75 = new Telerik.Reporting.TextBox();
			textBox76 = new Telerik.Reporting.TextBox();
			textBox77 = new Telerik.Reporting.TextBox();
			textBox78 = new Telerik.Reporting.TextBox();
			textBox79 = new Telerik.Reporting.TextBox();
			textBox80 = new Telerik.Reporting.TextBox();
			textBox81 = new Telerik.Reporting.TextBox();
			textBox84 = new Telerik.Reporting.TextBox();
			textBox85 = new Telerik.Reporting.TextBox();
			textBox86 = new Telerik.Reporting.TextBox();
			textBox87 = new Telerik.Reporting.TextBox();
			textBox89 = new Telerik.Reporting.TextBox();
			textBox90 = new Telerik.Reporting.TextBox();
			textBox91 = new Telerik.Reporting.TextBox();
			textBox92 = new Telerik.Reporting.TextBox();
			textBox97 = new Telerik.Reporting.TextBox();
			textBox98 = new Telerik.Reporting.TextBox();
			textBox101 = new Telerik.Reporting.TextBox();
			textBox102 = new Telerik.Reporting.TextBox();
			textBox103 = new Telerik.Reporting.TextBox();
			textBox104 = new Telerik.Reporting.TextBox();
			textBox105 = new Telerik.Reporting.TextBox();
			textBox106 = new Telerik.Reporting.TextBox();
			textBox111 = new Telerik.Reporting.TextBox();
			textBox112 = new Telerik.Reporting.TextBox();
			textBox113 = new Telerik.Reporting.TextBox();
			textBox114 = new Telerik.Reporting.TextBox();
			textBox115 = new Telerik.Reporting.TextBox();
			textBox116 = new Telerik.Reporting.TextBox();
			textBox117 = new Telerik.Reporting.TextBox();
			textBox118 = new Telerik.Reporting.TextBox();
			textBox121 = new Telerik.Reporting.TextBox();
			textBox122 = new Telerik.Reporting.TextBox();
			textBox123 = new Telerik.Reporting.TextBox();
			textBox124 = new Telerik.Reporting.TextBox();
			textBox125 = new Telerik.Reporting.TextBox();
			textBox126 = new Telerik.Reporting.TextBox();
			textBox127 = new Telerik.Reporting.TextBox();
			textBox128 = new Telerik.Reporting.TextBox();
			textBox131 = new Telerik.Reporting.TextBox();
			textBox132 = new Telerik.Reporting.TextBox();
			textBox133 = new Telerik.Reporting.TextBox();
			textBox134 = new Telerik.Reporting.TextBox();
			textBox135 = new Telerik.Reporting.TextBox();
			textBox136 = new Telerik.Reporting.TextBox();
			textBox137 = new Telerik.Reporting.TextBox();
			textBox138 = new Telerik.Reporting.TextBox();
			textBox141 = new Telerik.Reporting.TextBox();
			textBox142 = new Telerik.Reporting.TextBox();
			textBox143 = new Telerik.Reporting.TextBox();
			textBox144 = new Telerik.Reporting.TextBox();
			textBox145 = new Telerik.Reporting.TextBox();
			textBox146 = new Telerik.Reporting.TextBox();
			textBox147 = new Telerik.Reporting.TextBox();
			textBox148 = new Telerik.Reporting.TextBox();
			textBox151 = new Telerik.Reporting.TextBox();
			textBox152 = new Telerik.Reporting.TextBox();
			textBox153 = new Telerik.Reporting.TextBox();
			textBox154 = new Telerik.Reporting.TextBox();
			textBox155 = new Telerik.Reporting.TextBox();
			textBox156 = new Telerik.Reporting.TextBox();
			textBox157 = new Telerik.Reporting.TextBox();
			textBox158 = new Telerik.Reporting.TextBox();
			textBox161 = new Telerik.Reporting.TextBox();
			textBox162 = new Telerik.Reporting.TextBox();
			textBox163 = new Telerik.Reporting.TextBox();
			textBox164 = new Telerik.Reporting.TextBox();
			textBox165 = new Telerik.Reporting.TextBox();
			textBox166 = new Telerik.Reporting.TextBox();
			textBox167 = new Telerik.Reporting.TextBox();
			textBox168 = new Telerik.Reporting.TextBox();
			textBox171 = new Telerik.Reporting.TextBox();
			textBox172 = new Telerik.Reporting.TextBox();
			textBox173 = new Telerik.Reporting.TextBox();
			textBox174 = new Telerik.Reporting.TextBox();
			textBox175 = new Telerik.Reporting.TextBox();
			textBox176 = new Telerik.Reporting.TextBox();
			textBox177 = new Telerik.Reporting.TextBox();
			textBox178 = new Telerik.Reporting.TextBox();
			textBox181 = new Telerik.Reporting.TextBox();
			textBox182 = new Telerik.Reporting.TextBox();
			textBox183 = new Telerik.Reporting.TextBox();
			textBox184 = new Telerik.Reporting.TextBox();
			textBox185 = new Telerik.Reporting.TextBox();
			textBox186 = new Telerik.Reporting.TextBox();
			textBox187 = new Telerik.Reporting.TextBox();
			textBox188 = new Telerik.Reporting.TextBox();
			textBox191 = new Telerik.Reporting.TextBox();
			textBox192 = new Telerik.Reporting.TextBox();
			textBox193 = new Telerik.Reporting.TextBox();
			textBox194 = new Telerik.Reporting.TextBox();
			textBox195 = new Telerik.Reporting.TextBox();
			textBox196 = new Telerik.Reporting.TextBox();
			textBox197 = new Telerik.Reporting.TextBox();
			textBox35 = new Telerik.Reporting.TextBox();
			textBox52 = new Telerik.Reporting.TextBox();
			textBox62 = new Telerik.Reporting.TextBox();
			textBox72 = new Telerik.Reporting.TextBox();
			textBox82 = new Telerik.Reporting.TextBox();
			textBox93 = new Telerik.Reporting.TextBox();
			textBox109 = new Telerik.Reporting.TextBox();
			textBox119 = new Telerik.Reporting.TextBox();
			textBox129 = new Telerik.Reporting.TextBox();
			textBox139 = new Telerik.Reporting.TextBox();
			textBox149 = new Telerik.Reporting.TextBox();
			textBox159 = new Telerik.Reporting.TextBox();
			textBox169 = new Telerik.Reporting.TextBox();
			textBox179 = new Telerik.Reporting.TextBox();
			textBox189 = new Telerik.Reporting.TextBox();
			textBox40 = new Telerik.Reporting.TextBox();
			textBox48 = new Telerik.Reporting.TextBox();
			reportHeaderSection1 = new ReportHeaderSection();
			textBox88 = new Telerik.Reporting.TextBox();
			textBox94 = new Telerik.Reporting.TextBox();
			textBox95 = new Telerik.Reporting.TextBox();
			textBox99 = new Telerik.Reporting.TextBox();
			textBox100 = new Telerik.Reporting.TextBox();
			textBox107 = new Telerik.Reporting.TextBox();
			textBox108 = new Telerik.Reporting.TextBox();
			textBox3 = new Telerik.Reporting.TextBox();
			textBox4 = new Telerik.Reporting.TextBox();
			textBox7 = new Telerik.Reporting.TextBox();
			textBox11 = new Telerik.Reporting.TextBox();
			textBox15 = new Telerik.Reporting.TextBox();
			textBox16 = new Telerik.Reporting.TextBox();
			textBox17 = new Telerik.Reporting.TextBox();
			textBox19 = new Telerik.Reporting.TextBox();
			textBox24 = new Telerik.Reporting.TextBox();
			textBox25 = new Telerik.Reporting.TextBox();
			textBox26 = new Telerik.Reporting.TextBox();
			textBox27 = new Telerik.Reporting.TextBox();
			textBox29 = new Telerik.Reporting.TextBox();
			textBox30 = new Telerik.Reporting.TextBox();
			textBox31 = new Telerik.Reporting.TextBox();
			textBox32 = new Telerik.Reporting.TextBox();
			textBox33 = new Telerik.Reporting.TextBox();
			barcode = new Telerik.Reporting.Barcode();
			textBox13 = new Telerik.Reporting.TextBox();
			textBox12 = new Telerik.Reporting.TextBox();
			textBox213 = new Telerik.Reporting.TextBox();
			table1 = new Telerik.Reporting.Table();
			textBox8 = new Telerik.Reporting.TextBox();
			textBox9 = new Telerik.Reporting.TextBox();
			textBox43 = new Telerik.Reporting.TextBox();
			textBox53 = new Telerik.Reporting.TextBox();
			textBox63 = new Telerik.Reporting.TextBox();
			textBox73 = new Telerik.Reporting.TextBox();
			textBox83 = new Telerik.Reporting.TextBox();
			textBox96 = new Telerik.Reporting.TextBox();
			textBox110 = new Telerik.Reporting.TextBox();
			textBox120 = new Telerik.Reporting.TextBox();
			textBox130 = new Telerik.Reporting.TextBox();
			textBox140 = new Telerik.Reporting.TextBox();
			textBox150 = new Telerik.Reporting.TextBox();
			textBox160 = new Telerik.Reporting.TextBox();
			textBox170 = new Telerik.Reporting.TextBox();
			textBox180 = new Telerik.Reporting.TextBox();
			textBox190 = new Telerik.Reporting.TextBox();
			textBox198 = new Telerik.Reporting.TextBox();
			textBox199 = new Telerik.Reporting.TextBox();
			textBox200 = new Telerik.Reporting.TextBox();
			textBox201 = new Telerik.Reporting.TextBox();
			textBox202 = new Telerik.Reporting.TextBox();
			textBox203 = new Telerik.Reporting.TextBox();
			textBox204 = new Telerik.Reporting.TextBox();
			textBox205 = new Telerik.Reporting.TextBox();
			textBox206 = new Telerik.Reporting.TextBox();
			textBox207 = new Telerik.Reporting.TextBox();
			textBox208 = new Telerik.Reporting.TextBox();
			textBox209 = new Telerik.Reporting.TextBox();
			textBox210 = new Telerik.Reporting.TextBox();
			textBox211 = new Telerik.Reporting.TextBox();
			textBox212 = new Telerik.Reporting.TextBox();
			textBox309 = new Telerik.Reporting.TextBox();
			textBox310 = new Telerik.Reporting.TextBox();
			textBox311 = new Telerik.Reporting.TextBox();
			textBox324 = new Telerik.Reporting.TextBox();
			((ISupportInitialize)this).BeginInit();
			textBox10.Name = "textBox10";
			textBox10.Size = new SizeU(Unit.Cm(0.87650924921035767), Unit.Cm(1.9428565502166748));
			textBox10.Style.BackgroundColor = Color.WhiteSmoke;
			textBox10.Style.BorderColor.Default = Color.Black;
			textBox10.Style.BorderStyle.Default = BorderType.Solid;
			textBox10.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox10.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox10.Style.BorderWidth.Right = Unit.Point(0.5);
			textBox10.Style.BorderWidth.Top = Unit.Point(0.5);
			textBox10.Style.Font.Bold = true;
			textBox10.Style.Font.Name = "맑은 고딕";
			textBox10.Style.Font.Size = Unit.Point(10.0);
			textBox10.Style.TextAlign = HorizontalAlign.Center;
			textBox10.Style.VerticalAlign = VerticalAlign.Middle;
			textBox10.StyleName = "";
			textBox10.Value = "공정\r\n번호";
			textBox44.Name = "textBox44";
			textBox44.Size = new SizeU(Unit.Cm(3.3808207511901855), Unit.Cm(0.97142833471298218));
			textBox44.Style.BackgroundColor = Color.WhiteSmoke;
			textBox44.Style.BorderColor.Default = Color.Black;
			textBox44.Style.BorderStyle.Default = BorderType.Solid;
			textBox44.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox44.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox44.Style.BorderWidth.Right = Unit.Point(0.5);
			textBox44.Style.BorderWidth.Top = Unit.Point(0.5);
			textBox44.Style.Font.Bold = true;
			textBox44.Style.Font.Name = "맑은 고딕";
			textBox44.Style.Font.Size = Unit.Point(10.0);
			textBox44.Style.Padding.Left = Unit.Point(0.0);
			textBox44.Style.Padding.Right = Unit.Point(0.0);
			textBox44.Style.TextAlign = HorizontalAlign.Center;
			textBox44.Style.VerticalAlign = VerticalAlign.Middle;
			textBox44.StyleName = "";
			textBox44.Value = "작업명";
			textBox46.Name = "textBox46";
			textBox46.Size = new SizeU(Unit.Cm(2.5043115615844727), Unit.Cm(0.97142833471298218));
			textBox46.Style.BackgroundColor = Color.WhiteSmoke;
			textBox46.Style.BorderColor.Default = Color.Black;
			textBox46.Style.BorderStyle.Default = BorderType.Solid;
			textBox46.Style.BorderStyle.Top = BorderType.Solid;
			textBox46.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox46.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox46.Style.BorderWidth.Right = Unit.Point(0.5);
			textBox46.Style.BorderWidth.Top = Unit.Point(0.5);
			textBox46.Style.Font.Bold = true;
			textBox46.Style.Font.Name = "맑은 고딕";
			textBox46.Style.Font.Size = Unit.Point(10.0);
			textBox46.Style.TextAlign = HorizontalAlign.Center;
			textBox46.Style.VerticalAlign = VerticalAlign.Middle;
			textBox46.Value = "사용설비";
			textBox41.Name = "textBox41";
			textBox41.Size = new SizeU(Unit.Cm(5.8851323127746582), Unit.Cm(0.97142821550369263));
			textBox41.Style.BackgroundColor = Color.WhiteSmoke;
			textBox41.Style.BorderColor.Default = Color.Black;
			textBox41.Style.BorderStyle.Default = BorderType.Solid;
			textBox41.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox41.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox41.Style.BorderWidth.Right = Unit.Point(0.5);
			textBox41.Style.BorderWidth.Top = Unit.Point(0.5);
			textBox41.Style.Font.Bold = true;
			textBox41.Style.Font.Name = "맑은 고딕";
			textBox41.Style.Font.Size = Unit.Point(10.0);
			textBox41.Style.TextAlign = HorizontalAlign.Center;
			textBox41.Style.VerticalAlign = VerticalAlign.Middle;
			textBox41.StyleName = "";
			textBox41.Value = "작업진행 순서";
			textBox22.Name = "textBox22";
			textBox22.Size = new SizeU(Unit.Cm(0.87150067090988159), Unit.Cm(1.9428565502166748));
			textBox22.Style.BackgroundColor = Color.WhiteSmoke;
			textBox22.Style.BorderColor.Default = Color.Black;
			textBox22.Style.BorderStyle.Default = BorderType.Solid;
			textBox22.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox22.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox22.Style.BorderWidth.Right = Unit.Point(0.5);
			textBox22.Style.BorderWidth.Top = Unit.Point(0.5);
			textBox22.Style.Font.Bold = true;
			textBox22.Style.Font.Name = "맑은 고딕";
			textBox22.Style.Font.Size = Unit.Point(10.0);
			textBox22.Style.TextAlign = HorizontalAlign.Center;
			textBox22.Style.VerticalAlign = VerticalAlign.Middle;
			textBox22.StyleName = "";
			textBox22.Value = "검사\r\n코드";
			textBox23.Name = "textBox23";
			textBox23.Size = new SizeU(Unit.Cm(1.5025873184204102), Unit.Cm(1.9428565502166748));
			textBox23.Style.BackgroundColor = Color.WhiteSmoke;
			textBox23.Style.BorderColor.Default = Color.Black;
			textBox23.Style.BorderStyle.Default = BorderType.Solid;
			textBox23.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox23.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox23.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox23.Style.BorderWidth.Right = Unit.Point(0.5);
			textBox23.Style.BorderWidth.Top = Unit.Point(0.5);
			textBox23.Style.Font.Bold = true;
			textBox23.Style.Font.Name = "맑은 고딕";
			textBox23.Style.Font.Size = Unit.Point(10.0);
			textBox23.Style.TextAlign = HorizontalAlign.Center;
			textBox23.Style.VerticalAlign = VerticalAlign.Middle;
			textBox23.StyleName = "";
			textBox23.Value = "작업\r\n수량";
			textBox37.Name = "textBox37";
			textBox37.Size = new SizeU(Unit.Cm(2.0034506320953369), Unit.Cm(1.9428565502166748));
			textBox37.Style.BackgroundColor = Color.WhiteSmoke;
			textBox37.Style.BorderColor.Default = Color.Black;
			textBox37.Style.BorderStyle.Default = BorderType.Solid;
			textBox37.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox37.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox37.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox37.Style.BorderWidth.Right = Unit.Point(0.5);
			textBox37.Style.BorderWidth.Top = Unit.Point(0.5);
			textBox37.Style.Font.Bold = true;
			textBox37.Style.Font.Name = "맑은 고딕";
			textBox37.Style.Font.Size = Unit.Point(10.0);
			textBox37.Style.TextAlign = HorizontalAlign.Center;
			textBox37.Style.VerticalAlign = VerticalAlign.Middle;
			textBox37.StyleName = "";
			textBox37.Value = "날짜";
			textBox38.Name = "textBox38";
			textBox38.Size = new SizeU(Unit.Cm(1.8031054735183716), Unit.Cm(1.9428565502166748));
			textBox38.Style.BackgroundColor = Color.WhiteSmoke;
			textBox38.Style.BorderColor.Default = Color.Black;
			textBox38.Style.BorderStyle.Default = BorderType.Solid;
			textBox38.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox38.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox38.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox38.Style.BorderWidth.Right = Unit.Point(0.5);
			textBox38.Style.BorderWidth.Top = Unit.Point(0.5);
			textBox38.Style.Font.Bold = true;
			textBox38.Style.Font.Name = "맑은 고딕";
			textBox38.Style.Font.Size = Unit.Point(10.0);
			textBox38.Style.TextAlign = HorizontalAlign.Center;
			textBox38.Style.VerticalAlign = VerticalAlign.Middle;
			textBox38.StyleName = "";
			textBox38.Value = "작업자\r\n/검사자";
			textBox39.Name = "textBox39";
			textBox39.Size = new SizeU(Unit.Cm(4.8038334846496582), Unit.Cm(1.9428565502166748));
			textBox39.Style.BackgroundColor = Color.WhiteSmoke;
			textBox39.Style.BorderColor.Default = Color.Black;
			textBox39.Style.BorderStyle.Default = BorderType.Solid;
			textBox39.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox39.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox39.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox39.Style.BorderWidth.Right = Unit.Point(0.5);
			textBox39.Style.BorderWidth.Top = Unit.Point(0.5);
			textBox39.Style.Font.Bold = true;
			textBox39.Style.Font.Name = "맑은 고딕";
			textBox39.Style.Font.Size = Unit.Point(10.0);
			textBox39.Style.TextAlign = HorizontalAlign.Center;
			textBox39.Style.VerticalAlign = VerticalAlign.Middle;
			textBox39.StyleName = "";
			textBox39.Value = "특이사항 기록";
			textBox14.Name = "textBox14";
			textBox14.Size = new SizeU(Unit.Cm(2.2538812160491943), Unit.Cm(1.9428565502166748));
			textBox14.Style.BackgroundColor = Color.WhiteSmoke;
			textBox14.Style.BorderColor.Default = Color.Black;
			textBox14.Style.BorderStyle.Default = BorderType.Solid;
			textBox14.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox14.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox14.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox14.Style.BorderWidth.Right = Unit.Point(0.5);
			textBox14.Style.BorderWidth.Top = Unit.Point(0.5);
			textBox14.Style.Font.Bold = true;
			textBox14.Style.Font.Name = "맑은 고딕";
			textBox14.Style.Font.Size = Unit.Point(10.0);
			textBox14.Style.TextAlign = HorizontalAlign.Center;
			textBox14.Style.VerticalAlign = VerticalAlign.Middle;
			textBox14.StyleName = "";
			textBox14.Value = "비  고";
			textBox325.Name = "textBox325";
			textBox325.Size = new SizeU(Unit.Cm(0.079021960496902466), Unit.Cm(0.352855920791626));
			textBox325.Style.BackgroundColor = Color.WhiteSmoke;
			textBox325.Style.BorderColor.Default = Color.Black;
			textBox325.Style.BorderStyle.Default = BorderType.Solid;
			textBox325.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox325.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox325.Style.BorderWidth.Right = Unit.Point(0.5);
			textBox325.Style.BorderWidth.Top = Unit.Point(0.5);
			textBox325.Style.Font.Bold = true;
			textBox325.Style.Font.Name = "맑은 고딕";
			textBox325.Style.Font.Size = Unit.Point(10.0);
			textBox325.Style.TextAlign = HorizontalAlign.Center;
			textBox325.Style.VerticalAlign = VerticalAlign.Middle;
			textBox325.StyleName = "";
			textBox326.Name = "textBox326";
			textBox326.Size = new SizeU(Unit.Cm(0.30479881167411804), Unit.Cm(0.17642797529697418));
			textBox326.Style.BackgroundColor = Color.WhiteSmoke;
			textBox326.Style.BorderColor.Default = Color.Black;
			textBox326.Style.BorderStyle.Default = BorderType.Solid;
			textBox326.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox326.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox326.Style.BorderWidth.Right = Unit.Point(0.5);
			textBox326.Style.BorderWidth.Top = Unit.Point(0.5);
			textBox326.Style.Font.Bold = true;
			textBox326.Style.Font.Name = "맑은 고딕";
			textBox326.Style.Font.Size = Unit.Point(10.0);
			textBox326.Style.Padding.Left = Unit.Point(0.0);
			textBox326.Style.Padding.Right = Unit.Point(0.0);
			textBox326.Style.TextAlign = HorizontalAlign.Center;
			textBox326.Style.VerticalAlign = VerticalAlign.Middle;
			textBox326.StyleName = "";
			textBox327.Name = "textBox327";
			textBox327.Size = new SizeU(Unit.Cm(0.22577685117721558), Unit.Cm(0.17642797529697418));
			textBox327.Style.BackgroundColor = Color.WhiteSmoke;
			textBox327.Style.BorderColor.Default = Color.Black;
			textBox327.Style.BorderStyle.Default = BorderType.Solid;
			textBox327.Style.BorderStyle.Top = BorderType.Solid;
			textBox327.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox327.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox327.Style.BorderWidth.Right = Unit.Point(0.5);
			textBox327.Style.BorderWidth.Top = Unit.Point(0.5);
			textBox327.Style.Font.Bold = true;
			textBox327.Style.Font.Name = "맑은 고딕";
			textBox327.Style.Font.Size = Unit.Point(10.0);
			textBox327.Style.TextAlign = HorizontalAlign.Center;
			textBox327.Style.VerticalAlign = VerticalAlign.Middle;
			textBox328.Name = "textBox328";
			textBox328.Size = new SizeU(Unit.Cm(0.53057563304901123), Unit.Cm(0.17642794549465179));
			textBox328.Style.BackgroundColor = Color.WhiteSmoke;
			textBox328.Style.BorderColor.Default = Color.Black;
			textBox328.Style.BorderStyle.Default = BorderType.Solid;
			textBox328.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox328.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox328.Style.BorderWidth.Right = Unit.Point(0.5);
			textBox328.Style.BorderWidth.Top = Unit.Point(0.5);
			textBox328.Style.Font.Bold = true;
			textBox328.Style.Font.Name = "맑은 고딕";
			textBox328.Style.Font.Size = Unit.Point(10.0);
			textBox328.Style.TextAlign = HorizontalAlign.Center;
			textBox328.Style.VerticalAlign = VerticalAlign.Middle;
			textBox328.StyleName = "";
			textBox329.Name = "textBox329";
			textBox329.Size = new SizeU(Unit.Cm(0.0785704106092453), Unit.Cm(0.352855920791626));
			textBox329.Style.BackgroundColor = Color.WhiteSmoke;
			textBox329.Style.BorderColor.Default = Color.Black;
			textBox329.Style.BorderStyle.Default = BorderType.Solid;
			textBox329.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox329.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox329.Style.BorderWidth.Right = Unit.Point(0.5);
			textBox329.Style.BorderWidth.Top = Unit.Point(0.5);
			textBox329.Style.Font.Bold = true;
			textBox329.Style.Font.Name = "맑은 고딕";
			textBox329.Style.Font.Size = Unit.Point(10.0);
			textBox329.Style.TextAlign = HorizontalAlign.Center;
			textBox329.Style.VerticalAlign = VerticalAlign.Middle;
			textBox329.StyleName = "";
			textBox330.Name = "textBox330";
			textBox330.Size = new SizeU(Unit.Cm(0.13546620309352875), Unit.Cm(0.352855920791626));
			textBox330.Style.BackgroundColor = Color.WhiteSmoke;
			textBox330.Style.BorderColor.Default = Color.Black;
			textBox330.Style.BorderStyle.Default = BorderType.Solid;
			textBox330.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox330.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox330.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox330.Style.BorderWidth.Right = Unit.Point(0.5);
			textBox330.Style.BorderWidth.Top = Unit.Point(0.5);
			textBox330.Style.Font.Bold = true;
			textBox330.Style.Font.Name = "맑은 고딕";
			textBox330.Style.Font.Size = Unit.Point(10.0);
			textBox330.Style.TextAlign = HorizontalAlign.Center;
			textBox330.Style.VerticalAlign = VerticalAlign.Middle;
			textBox330.StyleName = "";
			textBox331.Name = "textBox331";
			textBox331.Size = new SizeU(Unit.Cm(0.18062169849872589), Unit.Cm(0.352855920791626));
			textBox331.Style.BackgroundColor = Color.WhiteSmoke;
			textBox331.Style.BorderColor.Default = Color.Black;
			textBox331.Style.BorderStyle.Default = BorderType.Solid;
			textBox331.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox331.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox331.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox331.Style.BorderWidth.Right = Unit.Point(0.5);
			textBox331.Style.BorderWidth.Top = Unit.Point(0.5);
			textBox331.Style.Font.Bold = true;
			textBox331.Style.Font.Name = "맑은 고딕";
			textBox331.Style.Font.Size = Unit.Point(10.0);
			textBox331.Style.TextAlign = HorizontalAlign.Center;
			textBox331.Style.VerticalAlign = VerticalAlign.Middle;
			textBox331.StyleName = "";
			textBox332.Name = "textBox332";
			textBox332.Size = new SizeU(Unit.Cm(0.16255953907966614), Unit.Cm(0.352855920791626));
			textBox332.Style.BackgroundColor = Color.WhiteSmoke;
			textBox332.Style.BorderColor.Default = Color.Black;
			textBox332.Style.BorderStyle.Default = BorderType.Solid;
			textBox332.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox332.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox332.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox332.Style.BorderWidth.Right = Unit.Point(0.5);
			textBox332.Style.BorderWidth.Top = Unit.Point(0.5);
			textBox332.Style.Font.Bold = true;
			textBox332.Style.Font.Name = "맑은 고딕";
			textBox332.Style.Font.Size = Unit.Point(10.0);
			textBox332.Style.TextAlign = HorizontalAlign.Center;
			textBox332.Style.VerticalAlign = VerticalAlign.Middle;
			textBox332.StyleName = "";
			textBox333.Name = "textBox333";
			textBox333.Size = new SizeU(Unit.Cm(0.43309098482131958), Unit.Cm(0.352855920791626));
			textBox333.Style.BackgroundColor = Color.WhiteSmoke;
			textBox333.Style.BorderColor.Default = Color.Black;
			textBox333.Style.BorderStyle.Default = BorderType.Solid;
			textBox333.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox333.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox333.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox333.Style.BorderWidth.Right = Unit.Point(0.5);
			textBox333.Style.BorderWidth.Top = Unit.Point(0.5);
			textBox333.Style.Font.Bold = true;
			textBox333.Style.Font.Name = "맑은 고딕";
			textBox333.Style.Font.Size = Unit.Point(10.0);
			textBox333.Style.TextAlign = HorizontalAlign.Center;
			textBox333.Style.VerticalAlign = VerticalAlign.Middle;
			textBox333.StyleName = "";
			textBox334.Name = "textBox334";
			textBox334.Size = new SizeU(Unit.Cm(0.20319931209087372), Unit.Cm(0.352855920791626));
			textBox334.Style.BackgroundColor = Color.WhiteSmoke;
			textBox334.Style.BorderColor.Default = Color.Black;
			textBox334.Style.BorderStyle.Default = BorderType.Solid;
			textBox334.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox334.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox334.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox334.Style.BorderWidth.Right = Unit.Point(0.5);
			textBox334.Style.BorderWidth.Top = Unit.Point(0.5);
			textBox334.Style.Font.Bold = true;
			textBox334.Style.Font.Name = "맑은 고딕";
			textBox334.Style.Font.Size = Unit.Point(10.0);
			textBox334.Style.TextAlign = HorizontalAlign.Center;
			textBox334.Style.VerticalAlign = VerticalAlign.Middle;
			textBox334.StyleName = "";
			detail.Height = Unit.Cm(0.0);
			detail.Name = "detail";
			detail.Style.BorderStyle.Bottom = BorderType.Solid;
			detail.Style.BorderStyle.Default = BorderType.Solid;
			detail.Style.BorderStyle.Top = BorderType.None;
			detail.Style.BorderWidth.Default = Unit.Point(1.0);
			DataTable.Body.Columns.Add(new TableBodyColumn(Unit.Cm(0.87650936841964722)));
			DataTable.Body.Columns.Add(new TableBodyColumn(Unit.Cm(0.87650936841964722)));
			DataTable.Body.Columns.Add(new TableBodyColumn(Unit.Cm(2.5043103694915771)));
			DataTable.Body.Columns.Add(new TableBodyColumn(Unit.Cm(2.5043103694915771)));
			DataTable.Body.Columns.Add(new TableBodyColumn(Unit.Cm(0.87150079011917114)));
			DataTable.Body.Columns.Add(new TableBodyColumn(Unit.Cm(1.5025873184204102)));
			DataTable.Body.Columns.Add(new TableBodyColumn(Unit.Cm(2.0034506320953369)));
			DataTable.Body.Columns.Add(new TableBodyColumn(Unit.Cm(1.8031057119369507)));
			DataTable.Body.Columns.Add(new TableBodyColumn(Unit.Cm(4.8038330078125)));
			DataTable.Body.Columns.Add(new TableBodyColumn(Unit.Cm(2.2538809776306152)));
			DataTable.Body.Rows.Add(new TableBodyRow(Unit.Cm(1.2899996042251587)));
			DataTable.Body.Rows.Add(new TableBodyRow(Unit.Cm(1.2900000810623169)));
			DataTable.Body.Rows.Add(new TableBodyRow(Unit.Cm(1.2900000810623169)));
			DataTable.Body.Rows.Add(new TableBodyRow(Unit.Cm(1.2900000810623169)));
			DataTable.Body.Rows.Add(new TableBodyRow(Unit.Cm(1.2899996042251587)));
			DataTable.Body.Rows.Add(new TableBodyRow(Unit.Cm(1.2899996042251587)));
			DataTable.Body.Rows.Add(new TableBodyRow(Unit.Cm(1.2899996042251587)));
			DataTable.Body.Rows.Add(new TableBodyRow(Unit.Cm(1.2899996042251587)));
			DataTable.Body.Rows.Add(new TableBodyRow(Unit.Cm(1.2899996042251587)));
			DataTable.Body.Rows.Add(new TableBodyRow(Unit.Cm(1.2899996042251587)));
			DataTable.Body.Rows.Add(new TableBodyRow(Unit.Cm(1.2899996042251587)));
			DataTable.Body.Rows.Add(new TableBodyRow(Unit.Cm(1.2900000810623169)));
			DataTable.Body.Rows.Add(new TableBodyRow(Unit.Cm(1.2899996042251587)));
			DataTable.Body.Rows.Add(new TableBodyRow(Unit.Cm(1.2899996042251587)));
			DataTable.Body.Rows.Add(new TableBodyRow(Unit.Cm(1.2900000810623169)));
			DataTable.Body.Rows.Add(new TableBodyRow(Unit.Cm(1.2900000810623169)));
			DataTable.Body.SetCellContent(0, 3, textBox2);
			DataTable.Body.SetCellContent(0, 6, textBox5);
			DataTable.Body.SetCellContent(0, 0, textBox6);
			DataTable.Body.SetCellContent(0, 4, textBox18);
			DataTable.Body.SetCellContent(0, 5, textBox34);
			DataTable.Body.SetCellContent(0, 7, textBox36);
			DataTable.Body.SetCellContent(0, 8, textBox28);
			DataTable.Body.SetCellContent(0, 9, textBox21);
			DataTable.Body.SetCellContent(0, 1, textBox1, 1, 2);
			DataTable.Body.SetCellContent(1, 0, textBox20);
			DataTable.Body.SetCellContent(1, 3, textBox42);
			DataTable.Body.SetCellContent(1, 5, textBox45);
			DataTable.Body.SetCellContent(1, 6, textBox47);
			DataTable.Body.SetCellContent(1, 8, textBox49);
			DataTable.Body.SetCellContent(1, 9, textBox50);
			DataTable.Body.SetCellContent(2, 0, textBox51);
			DataTable.Body.SetCellContent(2, 3, textBox54);
			DataTable.Body.SetCellContent(2, 4, textBox55);
			DataTable.Body.SetCellContent(2, 5, textBox56);
			DataTable.Body.SetCellContent(2, 6, textBox57);
			DataTable.Body.SetCellContent(2, 7, textBox58);
			DataTable.Body.SetCellContent(2, 8, textBox59);
			DataTable.Body.SetCellContent(2, 9, textBox60);
			DataTable.Body.SetCellContent(3, 0, textBox61);
			DataTable.Body.SetCellContent(3, 3, textBox64);
			DataTable.Body.SetCellContent(3, 4, textBox65);
			DataTable.Body.SetCellContent(3, 5, textBox66);
			DataTable.Body.SetCellContent(3, 6, textBox67);
			DataTable.Body.SetCellContent(3, 7, textBox68);
			DataTable.Body.SetCellContent(3, 8, textBox69);
			DataTable.Body.SetCellContent(3, 9, textBox70);
			DataTable.Body.SetCellContent(4, 0, textBox71);
			DataTable.Body.SetCellContent(4, 3, textBox74);
			DataTable.Body.SetCellContent(4, 4, textBox75);
			DataTable.Body.SetCellContent(4, 5, textBox76);
			DataTable.Body.SetCellContent(4, 6, textBox77);
			DataTable.Body.SetCellContent(4, 7, textBox78);
			DataTable.Body.SetCellContent(4, 8, textBox79);
			DataTable.Body.SetCellContent(4, 9, textBox80);
			DataTable.Body.SetCellContent(5, 0, textBox81);
			DataTable.Body.SetCellContent(5, 3, textBox84);
			DataTable.Body.SetCellContent(5, 4, textBox85);
			DataTable.Body.SetCellContent(5, 5, textBox86);
			DataTable.Body.SetCellContent(5, 6, textBox87);
			DataTable.Body.SetCellContent(5, 7, textBox89);
			DataTable.Body.SetCellContent(5, 8, textBox90);
			DataTable.Body.SetCellContent(5, 9, textBox91);
			DataTable.Body.SetCellContent(6, 0, textBox92);
			DataTable.Body.SetCellContent(6, 3, textBox97);
			DataTable.Body.SetCellContent(6, 4, textBox98);
			DataTable.Body.SetCellContent(6, 5, textBox101);
			DataTable.Body.SetCellContent(6, 6, textBox102);
			DataTable.Body.SetCellContent(6, 7, textBox103);
			DataTable.Body.SetCellContent(6, 8, textBox104);
			DataTable.Body.SetCellContent(6, 9, textBox105);
			DataTable.Body.SetCellContent(7, 0, textBox106);
			DataTable.Body.SetCellContent(7, 3, textBox111);
			DataTable.Body.SetCellContent(7, 4, textBox112);
			DataTable.Body.SetCellContent(7, 5, textBox113);
			DataTable.Body.SetCellContent(7, 6, textBox114);
			DataTable.Body.SetCellContent(7, 7, textBox115);
			DataTable.Body.SetCellContent(7, 8, textBox116);
			DataTable.Body.SetCellContent(7, 9, textBox117);
			DataTable.Body.SetCellContent(8, 0, textBox118);
			DataTable.Body.SetCellContent(8, 3, textBox121);
			DataTable.Body.SetCellContent(8, 4, textBox122);
			DataTable.Body.SetCellContent(8, 5, textBox123);
			DataTable.Body.SetCellContent(8, 6, textBox124);
			DataTable.Body.SetCellContent(8, 7, textBox125);
			DataTable.Body.SetCellContent(8, 8, textBox126);
			DataTable.Body.SetCellContent(8, 9, textBox127);
			DataTable.Body.SetCellContent(9, 0, textBox128);
			DataTable.Body.SetCellContent(9, 3, textBox131);
			DataTable.Body.SetCellContent(9, 4, textBox132);
			DataTable.Body.SetCellContent(9, 5, textBox133);
			DataTable.Body.SetCellContent(9, 6, textBox134);
			DataTable.Body.SetCellContent(9, 7, textBox135);
			DataTable.Body.SetCellContent(9, 8, textBox136);
			DataTable.Body.SetCellContent(9, 9, textBox137);
			DataTable.Body.SetCellContent(10, 0, textBox138);
			DataTable.Body.SetCellContent(10, 3, textBox141);
			DataTable.Body.SetCellContent(10, 4, textBox142);
			DataTable.Body.SetCellContent(10, 5, textBox143);
			DataTable.Body.SetCellContent(10, 6, textBox144);
			DataTable.Body.SetCellContent(10, 7, textBox145);
			DataTable.Body.SetCellContent(10, 8, textBox146);
			DataTable.Body.SetCellContent(10, 9, textBox147);
			DataTable.Body.SetCellContent(11, 0, textBox148);
			DataTable.Body.SetCellContent(11, 3, textBox151);
			DataTable.Body.SetCellContent(11, 4, textBox152);
			DataTable.Body.SetCellContent(11, 5, textBox153);
			DataTable.Body.SetCellContent(11, 6, textBox154);
			DataTable.Body.SetCellContent(11, 7, textBox155);
			DataTable.Body.SetCellContent(11, 8, textBox156);
			DataTable.Body.SetCellContent(11, 9, textBox157);
			DataTable.Body.SetCellContent(12, 0, textBox158);
			DataTable.Body.SetCellContent(12, 3, textBox161);
			DataTable.Body.SetCellContent(12, 4, textBox162);
			DataTable.Body.SetCellContent(12, 5, textBox163);
			DataTable.Body.SetCellContent(12, 6, textBox164);
			DataTable.Body.SetCellContent(12, 7, textBox165);
			DataTable.Body.SetCellContent(12, 8, textBox166);
			DataTable.Body.SetCellContent(12, 9, textBox167);
			DataTable.Body.SetCellContent(13, 0, textBox168);
			DataTable.Body.SetCellContent(13, 3, textBox171);
			DataTable.Body.SetCellContent(13, 4, textBox172);
			DataTable.Body.SetCellContent(13, 5, textBox173);
			DataTable.Body.SetCellContent(13, 6, textBox174);
			DataTable.Body.SetCellContent(13, 7, textBox175);
			DataTable.Body.SetCellContent(13, 8, textBox176);
			DataTable.Body.SetCellContent(13, 9, textBox177);
			DataTable.Body.SetCellContent(14, 0, textBox178);
			DataTable.Body.SetCellContent(14, 3, textBox181);
			DataTable.Body.SetCellContent(14, 4, textBox182);
			DataTable.Body.SetCellContent(14, 5, textBox183);
			DataTable.Body.SetCellContent(14, 6, textBox184);
			DataTable.Body.SetCellContent(14, 7, textBox185);
			DataTable.Body.SetCellContent(14, 8, textBox186);
			DataTable.Body.SetCellContent(14, 9, textBox187);
			DataTable.Body.SetCellContent(15, 0, textBox188);
			DataTable.Body.SetCellContent(15, 3, textBox191);
			DataTable.Body.SetCellContent(15, 4, textBox192);
			DataTable.Body.SetCellContent(15, 5, textBox193);
			DataTable.Body.SetCellContent(15, 6, textBox194);
			DataTable.Body.SetCellContent(15, 7, textBox195);
			DataTable.Body.SetCellContent(15, 8, textBox196);
			DataTable.Body.SetCellContent(15, 9, textBox197);
			DataTable.Body.SetCellContent(1, 1, textBox35, 1, 2);
			DataTable.Body.SetCellContent(2, 1, textBox52, 1, 2);
			DataTable.Body.SetCellContent(3, 1, textBox62, 1, 2);
			DataTable.Body.SetCellContent(4, 1, textBox72, 1, 2);
			DataTable.Body.SetCellContent(5, 1, textBox82, 1, 2);
			DataTable.Body.SetCellContent(6, 1, textBox93, 1, 2);
			DataTable.Body.SetCellContent(7, 1, textBox109, 1, 2);
			DataTable.Body.SetCellContent(8, 1, textBox119, 1, 2);
			DataTable.Body.SetCellContent(9, 1, textBox129, 1, 2);
			DataTable.Body.SetCellContent(10, 1, textBox139, 1, 2);
			DataTable.Body.SetCellContent(11, 1, textBox149, 1, 2);
			DataTable.Body.SetCellContent(12, 1, textBox159, 1, 2);
			DataTable.Body.SetCellContent(13, 1, textBox169, 1, 2);
			DataTable.Body.SetCellContent(14, 1, textBox179, 1, 2);
			DataTable.Body.SetCellContent(15, 1, textBox189, 1, 2);
			DataTable.Body.SetCellContent(1, 4, textBox40);
			DataTable.Body.SetCellContent(1, 7, textBox48);
			tableGroup2.Name = "group2";
			tableGroup.ChildGroups.Add(tableGroup2);
			tableGroup.Name = "group1";
			tableGroup.ReportItem = textBox10;
			tableGroup5.Name = "tableGroup";
			tableGroup6.Name = "group9";
			tableGroup4.ChildGroups.Add(tableGroup5);
			tableGroup4.ChildGroups.Add(tableGroup6);
			tableGroup4.Name = "group17";
			tableGroup4.ReportItem = textBox44;
			tableGroup7.Name = "group10";
			tableGroup7.ReportItem = textBox46;
			tableGroup3.ChildGroups.Add(tableGroup4);
			tableGroup3.ChildGroups.Add(tableGroup7);
			tableGroup3.Name = "group";
			tableGroup3.ReportItem = textBox41;
			tableGroup8.Name = "group3";
			tableGroup8.ReportItem = textBox22;
			tableGroup9.Name = "group5";
			tableGroup9.ReportItem = textBox23;
			tableGroup10.Name = "tableGroup2";
			tableGroup10.ReportItem = textBox37;
			tableGroup11.Name = "group6";
			tableGroup11.ReportItem = textBox38;
			tableGroup12.Name = "group7";
			tableGroup12.ReportItem = textBox39;
			tableGroup13.Name = "group4";
			tableGroup13.ReportItem = textBox14;
			DataTable.ColumnGroups.Add(tableGroup);
			DataTable.ColumnGroups.Add(tableGroup3);
			DataTable.ColumnGroups.Add(tableGroup8);
			DataTable.ColumnGroups.Add(tableGroup9);
			DataTable.ColumnGroups.Add(tableGroup10);
			DataTable.ColumnGroups.Add(tableGroup11);
			DataTable.ColumnGroups.Add(tableGroup12);
			DataTable.ColumnGroups.Add(tableGroup13);
			DataTable.Items.AddRange(new Telerik.Reporting.ReportItemBase[154]
			{
				textBox2,
				textBox5,
				textBox6,
				textBox18,
				textBox34,
				textBox36,
				textBox28,
				textBox21,
				textBox1,
				textBox20,
				textBox42,
				textBox45,
				textBox47,
				textBox49,
				textBox50,
				textBox51,
				textBox54,
				textBox55,
				textBox56,
				textBox57,
				textBox58,
				textBox59,
				textBox60,
				textBox61,
				textBox64,
				textBox65,
				textBox66,
				textBox67,
				textBox68,
				textBox69,
				textBox70,
				textBox71,
				textBox74,
				textBox75,
				textBox76,
				textBox77,
				textBox78,
				textBox79,
				textBox80,
				textBox81,
				textBox84,
				textBox85,
				textBox86,
				textBox87,
				textBox89,
				textBox90,
				textBox91,
				textBox92,
				textBox97,
				textBox98,
				textBox101,
				textBox102,
				textBox103,
				textBox104,
				textBox105,
				textBox106,
				textBox111,
				textBox112,
				textBox113,
				textBox114,
				textBox115,
				textBox116,
				textBox117,
				textBox118,
				textBox121,
				textBox122,
				textBox123,
				textBox124,
				textBox125,
				textBox126,
				textBox127,
				textBox128,
				textBox131,
				textBox132,
				textBox133,
				textBox134,
				textBox135,
				textBox136,
				textBox137,
				textBox138,
				textBox141,
				textBox142,
				textBox143,
				textBox144,
				textBox145,
				textBox146,
				textBox147,
				textBox148,
				textBox151,
				textBox152,
				textBox153,
				textBox154,
				textBox155,
				textBox156,
				textBox157,
				textBox158,
				textBox161,
				textBox162,
				textBox163,
				textBox164,
				textBox165,
				textBox166,
				textBox167,
				textBox168,
				textBox171,
				textBox172,
				textBox173,
				textBox174,
				textBox175,
				textBox176,
				textBox177,
				textBox178,
				textBox181,
				textBox182,
				textBox183,
				textBox184,
				textBox185,
				textBox186,
				textBox187,
				textBox188,
				textBox191,
				textBox192,
				textBox193,
				textBox194,
				textBox195,
				textBox196,
				textBox197,
				textBox35,
				textBox52,
				textBox62,
				textBox72,
				textBox82,
				textBox93,
				textBox109,
				textBox119,
				textBox129,
				textBox139,
				textBox149,
				textBox159,
				textBox169,
				textBox179,
				textBox189,
				textBox40,
				textBox48,
				textBox10,
				textBox41,
				textBox44,
				textBox46,
				textBox22,
				textBox23,
				textBox37,
				textBox38,
				textBox39,
				textBox14
			});
			DataTable.Location = new PointU(Unit.Cm(0.0), Unit.Cm(5.3999996185302734));
			DataTable.Name = "DataTable";
			tableGroup15.Name = "group8";
			tableGroup16.Name = "group11";
			tableGroup17.Name = "group12";
			tableGroup18.Name = "group13";
			tableGroup19.Name = "group14";
			tableGroup20.Name = "group15";
			tableGroup21.Name = "group16";
			tableGroup22.Name = "group18";
			tableGroup23.Name = "group19";
			tableGroup24.Name = "group20";
			tableGroup25.Name = "group21";
			tableGroup26.Name = "group22";
			tableGroup27.Name = "group23";
			tableGroup28.Name = "group24";
			tableGroup29.Name = "group25";
			tableGroup30.Name = "group26";
			tableGroup14.ChildGroups.Add(tableGroup15);
			tableGroup14.ChildGroups.Add(tableGroup16);
			tableGroup14.ChildGroups.Add(tableGroup17);
			tableGroup14.ChildGroups.Add(tableGroup18);
			tableGroup14.ChildGroups.Add(tableGroup19);
			tableGroup14.ChildGroups.Add(tableGroup20);
			tableGroup14.ChildGroups.Add(tableGroup21);
			tableGroup14.ChildGroups.Add(tableGroup22);
			tableGroup14.ChildGroups.Add(tableGroup23);
			tableGroup14.ChildGroups.Add(tableGroup24);
			tableGroup14.ChildGroups.Add(tableGroup25);
			tableGroup14.ChildGroups.Add(tableGroup26);
			tableGroup14.ChildGroups.Add(tableGroup27);
			tableGroup14.ChildGroups.Add(tableGroup28);
			tableGroup14.ChildGroups.Add(tableGroup29);
			tableGroup14.ChildGroups.Add(tableGroup30);
			tableGroup14.Groupings.Add(new Grouping(null));
			tableGroup14.Name = "detailTableGroup";
			DataTable.RowGroups.Add(tableGroup14);
			DataTable.Size = new SizeU(Unit.Cm(19.999998092651367), Unit.Cm(22.582857131958008));
			DataTable.Style.BorderStyle.Bottom = BorderType.Solid;
			DataTable.Style.BorderWidth.Default = Unit.Point(0.5);
			DataTable.Style.Font.Size = Unit.Point(11.0);
			textBox2.CanGrow = false;
			textBox2.Name = "textBox2";
			textBox2.Size = new SizeU(Unit.Cm(2.5043103694915771), Unit.Cm(1.2899999618530273));
			textBox2.Style.BorderColor.Left = Color.Black;
			textBox2.Style.BorderColor.Right = Color.Black;
			textBox2.Style.BorderStyle.Default = BorderType.Solid;
			textBox2.Style.BorderStyle.Top = BorderType.Solid;
			textBox2.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox2.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox2.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox2.Style.BorderWidth.Right = Unit.Point(0.5);
			textBox2.Style.Font.Name = "맑은 고딕";
			textBox2.Style.Font.Size = Unit.Point(10.0);
			textBox2.Style.TextAlign = HorizontalAlign.Left;
			textBox2.Style.VerticalAlign = VerticalAlign.Middle;
			textBox5.CanGrow = false;
			textBox5.Name = "textBox5";
			textBox5.Size = new SizeU(Unit.Cm(2.0034506320953369), Unit.Cm(1.2899999618530273));
			textBox5.Style.BackgroundColor = Color.White;
			textBox5.Style.BorderColor.Left = Color.Black;
			textBox5.Style.BorderColor.Right = Color.Black;
			textBox5.Style.BorderStyle.Default = BorderType.Solid;
			textBox5.Style.BorderStyle.Top = BorderType.Solid;
			textBox5.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox5.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox5.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox5.Style.BorderWidth.Right = Unit.Point(0.5);
			textBox5.Style.Font.Name = "맑은 고딕";
			textBox5.Style.Font.Size = Unit.Point(10.0);
			textBox5.Style.TextAlign = HorizontalAlign.Center;
			textBox5.Style.VerticalAlign = VerticalAlign.Middle;
			textBox6.Bindings.Add(new Binding("Value", "=Fields.TITLE"));
			textBox6.Name = "textBox6";
			textBox6.Size = new SizeU(Unit.Cm(0.87650936841964722), Unit.Cm(1.2899999618530273));
			textBox6.Style.BorderColor.Left = Color.Black;
			textBox6.Style.BorderColor.Right = Color.Black;
			textBox6.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox6.Style.BorderStyle.Default = BorderType.Solid;
			textBox6.Style.BorderStyle.Top = BorderType.Solid;
			textBox6.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox6.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox6.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox6.Style.BorderWidth.Right = Unit.Point(0.5);
			textBox6.Style.Font.Name = "맑은 고딕";
			textBox6.Style.Font.Size = Unit.Point(10.0);
			textBox6.Style.TextAlign = HorizontalAlign.Center;
			textBox6.Style.VerticalAlign = VerticalAlign.Middle;
			textBox6.StyleName = "";
			textBox18.CanGrow = false;
			textBox18.Name = "textBox18";
			textBox18.Size = new SizeU(Unit.Cm(0.87150079011917114), Unit.Cm(1.2899999618530273));
			textBox18.Style.BorderColor.Left = Color.Black;
			textBox18.Style.BorderColor.Right = Color.Black;
			textBox18.Style.BorderStyle.Default = BorderType.Solid;
			textBox18.Style.BorderStyle.Top = BorderType.Solid;
			textBox18.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox18.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox18.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox18.Style.BorderWidth.Right = Unit.Point(0.5);
			textBox18.Style.Font.Name = "맑은 고딕";
			textBox18.Style.Font.Size = Unit.Point(10.0);
			textBox18.Style.TextAlign = HorizontalAlign.Center;
			textBox18.Style.VerticalAlign = VerticalAlign.Middle;
			textBox18.StyleName = "";
			textBox18.Value = "O";
			textBox34.CanGrow = false;
			textBox34.Name = "textBox34";
			textBox34.Size = new SizeU(Unit.Cm(1.5025874376296997), Unit.Cm(1.2899999618530273));
			textBox34.Style.BorderColor.Left = Color.Black;
			textBox34.Style.BorderColor.Right = Color.Black;
			textBox34.Style.BorderStyle.Default = BorderType.Solid;
			textBox34.Style.BorderStyle.Top = BorderType.Solid;
			textBox34.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox34.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox34.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox34.Style.BorderWidth.Right = Unit.Point(0.5);
			textBox34.Style.Font.Name = "맑은 고딕";
			textBox34.Style.Font.Size = Unit.Point(10.0);
			textBox34.Style.TextAlign = HorizontalAlign.Right;
			textBox34.Style.VerticalAlign = VerticalAlign.Middle;
			textBox34.StyleName = "";
			textBox36.CanGrow = false;
			textBox36.Name = "textBox36";
			textBox36.Size = new SizeU(Unit.Cm(1.8031057119369507), Unit.Cm(1.2899999618530273));
			textBox36.Style.BackgroundColor = Color.White;
			textBox36.Style.BorderColor.Left = Color.Black;
			textBox36.Style.BorderColor.Right = Color.Black;
			textBox36.Style.BorderStyle.Default = BorderType.Solid;
			textBox36.Style.BorderStyle.Top = BorderType.Solid;
			textBox36.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox36.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox36.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox36.Style.BorderWidth.Right = Unit.Point(0.5);
			textBox36.Style.Font.Name = "맑은 고딕";
			textBox36.Style.Font.Size = Unit.Point(10.0);
			textBox36.Style.TextAlign = HorizontalAlign.Center;
			textBox36.Style.VerticalAlign = VerticalAlign.Middle;
			textBox36.StyleName = "";
			textBox28.CanGrow = false;
			textBox28.Name = "textBox28";
			textBox28.Size = new SizeU(Unit.Cm(4.8038330078125), Unit.Cm(1.2899999618530273));
			textBox28.Style.BackgroundColor = Color.White;
			textBox28.Style.BorderColor.Left = Color.Black;
			textBox28.Style.BorderColor.Right = Color.Black;
			textBox28.Style.BorderStyle.Default = BorderType.Solid;
			textBox28.Style.BorderStyle.Top = BorderType.Solid;
			textBox28.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox28.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox28.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox28.Style.BorderWidth.Right = Unit.Point(0.5);
			textBox28.Style.Font.Name = "맑은 고딕";
			textBox28.Style.Font.Size = Unit.Point(10.0);
			textBox28.Style.TextAlign = HorizontalAlign.Center;
			textBox28.Style.VerticalAlign = VerticalAlign.Middle;
			textBox28.StyleName = "";
			textBox21.Name = "textBox21";
			textBox21.Size = new SizeU(Unit.Cm(2.2538809776306152), Unit.Cm(1.2899999618530273));
			textBox21.Style.BackgroundColor = Color.White;
			textBox21.Style.BorderColor.Left = Color.Black;
			textBox21.Style.BorderColor.Right = Color.Black;
			textBox21.Style.BorderStyle.Default = BorderType.Solid;
			textBox21.Style.BorderStyle.Top = BorderType.Solid;
			textBox21.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox21.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox21.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox21.Style.BorderWidth.Right = Unit.Point(0.5);
			textBox21.Style.Font.Name = "맑은 고딕";
			textBox21.Style.Font.Size = Unit.Point(10.0);
			textBox21.Style.TextAlign = HorizontalAlign.Center;
			textBox21.Style.VerticalAlign = VerticalAlign.Middle;
			textBox21.StyleName = "";
			textBox1.CanGrow = false;
			textBox1.Name = "textBox1";
			textBox1.Size = new SizeU(Unit.Cm(3.3808197975158691), Unit.Cm(1.2899999618530273));
			textBox1.Style.BorderColor.Left = Color.Black;
			textBox1.Style.BorderColor.Right = Color.Black;
			textBox1.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox1.Style.BorderStyle.Default = BorderType.Solid;
			textBox1.Style.BorderStyle.Top = BorderType.Solid;
			textBox1.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox1.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox1.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox1.Style.BorderWidth.Right = Unit.Point(0.5);
			textBox1.Style.Font.Name = "맑은 고딕";
			textBox1.Style.Font.Size = Unit.Point(10.0);
			textBox1.Style.TextAlign = HorizontalAlign.Left;
			textBox1.Style.VerticalAlign = VerticalAlign.Middle;
			textBox1.Value = "패턴사출";
			textBox20.Name = "textBox20";
			textBox20.Size = new SizeU(Unit.Cm(0.876509428024292), Unit.Cm(1.2899999618530273));
			textBox20.Style.BorderStyle.Default = BorderType.Solid;
			textBox20.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox20.Style.Font.Name = "맑은 고딕";
			textBox20.Style.Font.Size = Unit.Point(10.0);
			textBox20.Style.TextAlign = HorizontalAlign.Center;
			textBox20.Style.VerticalAlign = VerticalAlign.Middle;
			textBox20.StyleName = "";
			textBox42.Name = "textBox42";
			textBox42.Size = new SizeU(Unit.Cm(2.5043103694915771), Unit.Cm(1.2899999618530273));
			textBox42.Style.BorderStyle.Default = BorderType.Solid;
			textBox42.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox42.Style.Font.Name = "맑은 고딕";
			textBox42.Style.Font.Size = Unit.Point(10.0);
			textBox42.Style.VerticalAlign = VerticalAlign.Middle;
			textBox42.StyleName = "";
			textBox45.Name = "textBox45";
			textBox45.Size = new SizeU(Unit.Cm(1.5025874376296997), Unit.Cm(1.2899999618530273));
			textBox45.Style.BorderStyle.Default = BorderType.Solid;
			textBox45.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox45.Style.Font.Name = "맑은 고딕";
			textBox45.Style.Font.Size = Unit.Point(10.0);
			textBox45.Style.TextAlign = HorizontalAlign.Right;
			textBox45.Style.VerticalAlign = VerticalAlign.Middle;
			textBox45.StyleName = "";
			textBox47.Name = "textBox47";
			textBox47.Size = new SizeU(Unit.Cm(2.003450870513916), Unit.Cm(1.2899999618530273));
			textBox47.Style.BackgroundColor = Color.White;
			textBox47.Style.BorderStyle.Default = BorderType.Solid;
			textBox47.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox47.Style.Font.Name = "맑은 고딕";
			textBox47.Style.Font.Size = Unit.Point(10.0);
			textBox47.Style.TextAlign = HorizontalAlign.Center;
			textBox47.Style.VerticalAlign = VerticalAlign.Middle;
			textBox47.StyleName = "";
			textBox49.Name = "textBox49";
			textBox49.Size = new SizeU(Unit.Cm(4.8038330078125), Unit.Cm(1.2899999618530273));
			textBox49.Style.BackgroundColor = Color.White;
			textBox49.Style.BorderStyle.Default = BorderType.Solid;
			textBox49.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox49.Style.Font.Name = "맑은 고딕";
			textBox49.Style.Font.Size = Unit.Point(10.0);
			textBox49.Style.TextAlign = HorizontalAlign.Center;
			textBox49.Style.VerticalAlign = VerticalAlign.Middle;
			textBox49.StyleName = "";
			textBox50.Name = "textBox50";
			textBox50.Size = new SizeU(Unit.Cm(2.2538809776306152), Unit.Cm(1.2899999618530273));
			textBox50.Style.BackgroundColor = Color.White;
			textBox50.Style.BorderStyle.Default = BorderType.Solid;
			textBox50.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox50.Style.Font.Name = "맑은 고딕";
			textBox50.Style.Font.Size = Unit.Point(10.0);
			textBox50.Style.TextAlign = HorizontalAlign.Center;
			textBox50.Style.VerticalAlign = VerticalAlign.Middle;
			textBox50.StyleName = "";
			textBox51.Name = "textBox51";
			textBox51.Size = new SizeU(Unit.Cm(0.87650936841964722), Unit.Cm(1.2899999618530273));
			textBox51.Style.BorderStyle.Default = BorderType.Solid;
			textBox51.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox51.Style.Font.Name = "맑은 고딕";
			textBox51.Style.Font.Size = Unit.Point(10.0);
			textBox51.Style.TextAlign = HorizontalAlign.Center;
			textBox51.Style.VerticalAlign = VerticalAlign.Middle;
			textBox51.StyleName = "";
			textBox54.Name = "textBox54";
			textBox54.Size = new SizeU(Unit.Cm(2.5043103694915771), Unit.Cm(1.2899999618530273));
			textBox54.Style.BorderStyle.Default = BorderType.Solid;
			textBox54.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox54.Style.Font.Name = "맑은 고딕";
			textBox54.Style.Font.Size = Unit.Point(10.0);
			textBox54.Style.VerticalAlign = VerticalAlign.Middle;
			textBox54.StyleName = "";
			textBox55.Name = "textBox55";
			textBox55.Size = new SizeU(Unit.Cm(0.87150079011917114), Unit.Cm(1.2899999618530273));
			textBox55.Style.BorderStyle.Default = BorderType.Solid;
			textBox55.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox55.Style.Font.Name = "맑은 고딕";
			textBox55.Style.Font.Size = Unit.Point(10.0);
			textBox55.Style.TextAlign = HorizontalAlign.Center;
			textBox55.Style.VerticalAlign = VerticalAlign.Middle;
			textBox55.StyleName = "";
			textBox55.Value = "O";
			textBox56.Name = "textBox56";
			textBox56.Size = new SizeU(Unit.Cm(1.5025873184204102), Unit.Cm(1.2899999618530273));
			textBox56.Style.BorderStyle.Default = BorderType.Solid;
			textBox56.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox56.Style.Font.Name = "맑은 고딕";
			textBox56.Style.Font.Size = Unit.Point(10.0);
			textBox56.Style.TextAlign = HorizontalAlign.Right;
			textBox56.Style.VerticalAlign = VerticalAlign.Middle;
			textBox56.StyleName = "";
			textBox57.Name = "textBox57";
			textBox57.Size = new SizeU(Unit.Cm(2.003450870513916), Unit.Cm(1.2899999618530273));
			textBox57.Style.BackgroundColor = Color.White;
			textBox57.Style.BorderStyle.Default = BorderType.Solid;
			textBox57.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox57.Style.Font.Name = "맑은 고딕";
			textBox57.Style.Font.Size = Unit.Point(10.0);
			textBox57.Style.TextAlign = HorizontalAlign.Center;
			textBox57.Style.VerticalAlign = VerticalAlign.Middle;
			textBox57.StyleName = "";
			textBox58.Name = "textBox58";
			textBox58.Size = new SizeU(Unit.Cm(1.8031057119369507), Unit.Cm(1.2899999618530273));
			textBox58.Style.BackgroundColor = Color.White;
			textBox58.Style.BorderStyle.Default = BorderType.Solid;
			textBox58.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox58.Style.Font.Name = "맑은 고딕";
			textBox58.Style.Font.Size = Unit.Point(10.0);
			textBox58.Style.TextAlign = HorizontalAlign.Center;
			textBox58.Style.VerticalAlign = VerticalAlign.Middle;
			textBox58.StyleName = "";
			textBox59.Name = "textBox59";
			textBox59.Size = new SizeU(Unit.Cm(4.8038330078125), Unit.Cm(1.2899999618530273));
			textBox59.Style.BackgroundColor = Color.White;
			textBox59.Style.BorderStyle.Default = BorderType.Solid;
			textBox59.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox59.Style.Font.Name = "맑은 고딕";
			textBox59.Style.Font.Size = Unit.Point(10.0);
			textBox59.Style.TextAlign = HorizontalAlign.Center;
			textBox59.Style.VerticalAlign = VerticalAlign.Middle;
			textBox59.StyleName = "";
			textBox60.Name = "textBox60";
			textBox60.Size = new SizeU(Unit.Cm(2.2538809776306152), Unit.Cm(1.2899999618530273));
			textBox60.Style.BackgroundColor = Color.White;
			textBox60.Style.BorderStyle.Default = BorderType.Solid;
			textBox60.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox60.Style.Font.Name = "맑은 고딕";
			textBox60.Style.Font.Size = Unit.Point(10.0);
			textBox60.Style.TextAlign = HorizontalAlign.Center;
			textBox60.Style.VerticalAlign = VerticalAlign.Middle;
			textBox60.StyleName = "";
			textBox61.Name = "textBox61";
			textBox61.Size = new SizeU(Unit.Cm(0.87650936841964722), Unit.Cm(1.2899998426437378));
			textBox61.Style.BorderStyle.Default = BorderType.Solid;
			textBox61.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox61.Style.Font.Name = "맑은 고딕";
			textBox61.Style.Font.Size = Unit.Point(10.0);
			textBox61.Style.TextAlign = HorizontalAlign.Center;
			textBox61.Style.VerticalAlign = VerticalAlign.Middle;
			textBox61.StyleName = "";
			textBox64.Name = "textBox64";
			textBox64.Size = new SizeU(Unit.Cm(2.5043103694915771), Unit.Cm(1.2899998426437378));
			textBox64.Style.BorderStyle.Default = BorderType.Solid;
			textBox64.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox64.Style.Font.Name = "맑은 고딕";
			textBox64.Style.Font.Size = Unit.Point(10.0);
			textBox64.Style.VerticalAlign = VerticalAlign.Middle;
			textBox64.StyleName = "";
			textBox65.Name = "textBox65";
			textBox65.Size = new SizeU(Unit.Cm(0.87150079011917114), Unit.Cm(1.2899998426437378));
			textBox65.Style.BorderStyle.Default = BorderType.Solid;
			textBox65.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox65.Style.Font.Name = "맑은 고딕";
			textBox65.Style.Font.Size = Unit.Point(10.0);
			textBox65.Style.TextAlign = HorizontalAlign.Center;
			textBox65.Style.VerticalAlign = VerticalAlign.Middle;
			textBox65.StyleName = "";
			textBox65.Value = "O";
			textBox66.Name = "textBox66";
			textBox66.Size = new SizeU(Unit.Cm(1.5025873184204102), Unit.Cm(1.2899998426437378));
			textBox66.Style.BorderStyle.Default = BorderType.Solid;
			textBox66.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox66.Style.Font.Name = "맑은 고딕";
			textBox66.Style.Font.Size = Unit.Point(10.0);
			textBox66.Style.TextAlign = HorizontalAlign.Right;
			textBox66.Style.VerticalAlign = VerticalAlign.Middle;
			textBox66.StyleName = "";
			textBox67.Name = "textBox67";
			textBox67.Size = new SizeU(Unit.Cm(2.003450870513916), Unit.Cm(1.2899998426437378));
			textBox67.Style.BackgroundColor = Color.White;
			textBox67.Style.BorderStyle.Default = BorderType.Solid;
			textBox67.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox67.Style.Font.Name = "맑은 고딕";
			textBox67.Style.Font.Size = Unit.Point(10.0);
			textBox67.Style.TextAlign = HorizontalAlign.Center;
			textBox67.Style.VerticalAlign = VerticalAlign.Middle;
			textBox67.StyleName = "";
			textBox68.Name = "textBox68";
			textBox68.Size = new SizeU(Unit.Cm(1.8031057119369507), Unit.Cm(1.2899998426437378));
			textBox68.Style.BackgroundColor = Color.White;
			textBox68.Style.BorderStyle.Default = BorderType.Solid;
			textBox68.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox68.Style.Font.Name = "맑은 고딕";
			textBox68.Style.Font.Size = Unit.Point(10.0);
			textBox68.Style.TextAlign = HorizontalAlign.Center;
			textBox68.Style.VerticalAlign = VerticalAlign.Middle;
			textBox68.StyleName = "";
			textBox69.Name = "textBox69";
			textBox69.Size = new SizeU(Unit.Cm(4.8038330078125), Unit.Cm(1.2899998426437378));
			textBox69.Style.BackgroundColor = Color.White;
			textBox69.Style.BorderStyle.Default = BorderType.Solid;
			textBox69.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox69.Style.Font.Name = "맑은 고딕";
			textBox69.Style.Font.Size = Unit.Point(10.0);
			textBox69.Style.TextAlign = HorizontalAlign.Center;
			textBox69.Style.VerticalAlign = VerticalAlign.Middle;
			textBox69.StyleName = "";
			textBox70.Name = "textBox70";
			textBox70.Size = new SizeU(Unit.Cm(2.2538809776306152), Unit.Cm(1.2899998426437378));
			textBox70.Style.BackgroundColor = Color.White;
			textBox70.Style.BorderStyle.Default = BorderType.Solid;
			textBox70.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox70.Style.Font.Name = "맑은 고딕";
			textBox70.Style.Font.Size = Unit.Point(10.0);
			textBox70.Style.TextAlign = HorizontalAlign.Center;
			textBox70.Style.VerticalAlign = VerticalAlign.Middle;
			textBox70.StyleName = "";
			textBox71.Name = "textBox71";
			textBox71.Size = new SizeU(Unit.Cm(0.876509428024292), Unit.Cm(1.2899999618530273));
			textBox71.Style.BorderStyle.Default = BorderType.Solid;
			textBox71.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox71.Style.Font.Name = "맑은 고딕";
			textBox71.Style.Font.Size = Unit.Point(10.0);
			textBox71.Style.TextAlign = HorizontalAlign.Center;
			textBox71.Style.VerticalAlign = VerticalAlign.Middle;
			textBox71.StyleName = "";
			textBox74.Name = "textBox74";
			textBox74.Size = new SizeU(Unit.Cm(2.5043103694915771), Unit.Cm(1.2899999618530273));
			textBox74.Style.BorderStyle.Default = BorderType.Solid;
			textBox74.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox74.Style.Font.Name = "맑은 고딕";
			textBox74.Style.Font.Size = Unit.Point(10.0);
			textBox74.Style.VerticalAlign = VerticalAlign.Middle;
			textBox74.StyleName = "";
			textBox75.Name = "textBox75";
			textBox75.Size = new SizeU(Unit.Cm(0.87150084972381592), Unit.Cm(1.2899999618530273));
			textBox75.Style.BorderStyle.Default = BorderType.Solid;
			textBox75.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox75.Style.Font.Name = "맑은 고딕";
			textBox75.Style.Font.Size = Unit.Point(10.0);
			textBox75.Style.TextAlign = HorizontalAlign.Center;
			textBox75.Style.VerticalAlign = VerticalAlign.Middle;
			textBox75.StyleName = "";
			textBox75.Value = "O";
			textBox76.Name = "textBox76";
			textBox76.Size = new SizeU(Unit.Cm(1.5025874376296997), Unit.Cm(1.2899999618530273));
			textBox76.Style.BorderStyle.Default = BorderType.Solid;
			textBox76.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox76.Style.Font.Name = "맑은 고딕";
			textBox76.Style.Font.Size = Unit.Point(10.0);
			textBox76.Style.TextAlign = HorizontalAlign.Right;
			textBox76.Style.VerticalAlign = VerticalAlign.Middle;
			textBox76.StyleName = "";
			textBox77.Name = "textBox77";
			textBox77.Size = new SizeU(Unit.Cm(2.003450870513916), Unit.Cm(1.2899999618530273));
			textBox77.Style.BackgroundColor = Color.White;
			textBox77.Style.BorderStyle.Default = BorderType.Solid;
			textBox77.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox77.Style.Font.Name = "맑은 고딕";
			textBox77.Style.Font.Size = Unit.Point(10.0);
			textBox77.Style.TextAlign = HorizontalAlign.Center;
			textBox77.Style.VerticalAlign = VerticalAlign.Middle;
			textBox77.StyleName = "";
			textBox78.Name = "textBox78";
			textBox78.Size = new SizeU(Unit.Cm(1.8031058311462402), Unit.Cm(1.2899999618530273));
			textBox78.Style.BackgroundColor = Color.White;
			textBox78.Style.BorderStyle.Default = BorderType.Solid;
			textBox78.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox78.Style.Font.Name = "맑은 고딕";
			textBox78.Style.Font.Size = Unit.Point(10.0);
			textBox78.Style.TextAlign = HorizontalAlign.Center;
			textBox78.Style.VerticalAlign = VerticalAlign.Middle;
			textBox78.StyleName = "";
			textBox79.Name = "textBox79";
			textBox79.Size = new SizeU(Unit.Cm(4.8038330078125), Unit.Cm(1.2899999618530273));
			textBox79.Style.BackgroundColor = Color.White;
			textBox79.Style.BorderStyle.Default = BorderType.Solid;
			textBox79.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox79.Style.Font.Name = "맑은 고딕";
			textBox79.Style.Font.Size = Unit.Point(10.0);
			textBox79.Style.TextAlign = HorizontalAlign.Center;
			textBox79.Style.VerticalAlign = VerticalAlign.Middle;
			textBox79.StyleName = "";
			textBox80.Name = "textBox80";
			textBox80.Size = new SizeU(Unit.Cm(2.2538809776306152), Unit.Cm(1.2899999618530273));
			textBox80.Style.BackgroundColor = Color.White;
			textBox80.Style.BorderStyle.Default = BorderType.Solid;
			textBox80.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox80.Style.Font.Name = "맑은 고딕";
			textBox80.Style.Font.Size = Unit.Point(10.0);
			textBox80.Style.TextAlign = HorizontalAlign.Center;
			textBox80.Style.VerticalAlign = VerticalAlign.Middle;
			textBox80.StyleName = "";
			textBox81.Name = "textBox81";
			textBox81.Size = new SizeU(Unit.Cm(0.87650936841964722), Unit.Cm(1.2899999618530273));
			textBox81.Style.BorderStyle.Default = BorderType.Solid;
			textBox81.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox81.Style.Font.Name = "맑은 고딕";
			textBox81.Style.Font.Size = Unit.Point(10.0);
			textBox81.Style.TextAlign = HorizontalAlign.Center;
			textBox81.Style.VerticalAlign = VerticalAlign.Middle;
			textBox81.StyleName = "";
			textBox84.Name = "textBox84";
			textBox84.Size = new SizeU(Unit.Cm(2.5043103694915771), Unit.Cm(1.2899999618530273));
			textBox84.Style.BorderStyle.Default = BorderType.Solid;
			textBox84.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox84.Style.Font.Name = "맑은 고딕";
			textBox84.Style.Font.Size = Unit.Point(10.0);
			textBox84.Style.VerticalAlign = VerticalAlign.Middle;
			textBox84.StyleName = "";
			textBox85.Name = "textBox85";
			textBox85.Size = new SizeU(Unit.Cm(0.87150079011917114), Unit.Cm(1.2899999618530273));
			textBox85.Style.BorderStyle.Default = BorderType.Solid;
			textBox85.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox85.Style.Font.Name = "맑은 고딕";
			textBox85.Style.Font.Size = Unit.Point(10.0);
			textBox85.Style.TextAlign = HorizontalAlign.Center;
			textBox85.Style.VerticalAlign = VerticalAlign.Middle;
			textBox85.StyleName = "";
			textBox85.Value = "O";
			textBox86.Name = "textBox86";
			textBox86.Size = new SizeU(Unit.Cm(1.5025873184204102), Unit.Cm(1.2899999618530273));
			textBox86.Style.BorderStyle.Default = BorderType.Solid;
			textBox86.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox86.Style.Font.Name = "맑은 고딕";
			textBox86.Style.Font.Size = Unit.Point(10.0);
			textBox86.Style.TextAlign = HorizontalAlign.Right;
			textBox86.Style.VerticalAlign = VerticalAlign.Middle;
			textBox86.StyleName = "";
			textBox87.Name = "textBox87";
			textBox87.Size = new SizeU(Unit.Cm(2.003450870513916), Unit.Cm(1.2899999618530273));
			textBox87.Style.BackgroundColor = Color.White;
			textBox87.Style.BorderStyle.Default = BorderType.Solid;
			textBox87.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox87.Style.Font.Name = "맑은 고딕";
			textBox87.Style.Font.Size = Unit.Point(10.0);
			textBox87.Style.TextAlign = HorizontalAlign.Center;
			textBox87.Style.VerticalAlign = VerticalAlign.Middle;
			textBox87.StyleName = "";
			textBox89.Name = "textBox89";
			textBox89.Size = new SizeU(Unit.Cm(1.8031057119369507), Unit.Cm(1.2899999618530273));
			textBox89.Style.BackgroundColor = Color.White;
			textBox89.Style.BorderStyle.Default = BorderType.Solid;
			textBox89.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox89.Style.Font.Name = "맑은 고딕";
			textBox89.Style.Font.Size = Unit.Point(10.0);
			textBox89.Style.TextAlign = HorizontalAlign.Center;
			textBox89.Style.VerticalAlign = VerticalAlign.Middle;
			textBox89.StyleName = "";
			textBox90.Name = "textBox90";
			textBox90.Size = new SizeU(Unit.Cm(4.8038330078125), Unit.Cm(1.2899999618530273));
			textBox90.Style.BackgroundColor = Color.White;
			textBox90.Style.BorderStyle.Default = BorderType.Solid;
			textBox90.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox90.Style.Font.Name = "맑은 고딕";
			textBox90.Style.Font.Size = Unit.Point(10.0);
			textBox90.Style.TextAlign = HorizontalAlign.Center;
			textBox90.Style.VerticalAlign = VerticalAlign.Middle;
			textBox90.StyleName = "";
			textBox91.Name = "textBox91";
			textBox91.Size = new SizeU(Unit.Cm(2.2538809776306152), Unit.Cm(1.2899999618530273));
			textBox91.Style.BackgroundColor = Color.White;
			textBox91.Style.BorderStyle.Default = BorderType.Solid;
			textBox91.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox91.Style.Font.Name = "맑은 고딕";
			textBox91.Style.Font.Size = Unit.Point(10.0);
			textBox91.Style.TextAlign = HorizontalAlign.Center;
			textBox91.Style.VerticalAlign = VerticalAlign.Middle;
			textBox91.StyleName = "";
			textBox92.Name = "textBox92";
			textBox92.Size = new SizeU(Unit.Cm(0.87650936841964722), Unit.Cm(1.2899999618530273));
			textBox92.Style.BorderStyle.Default = BorderType.Solid;
			textBox92.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox92.Style.Font.Name = "맑은 고딕";
			textBox92.Style.Font.Size = Unit.Point(10.0);
			textBox92.Style.TextAlign = HorizontalAlign.Center;
			textBox92.Style.VerticalAlign = VerticalAlign.Middle;
			textBox92.StyleName = "";
			textBox97.Name = "textBox97";
			textBox97.Size = new SizeU(Unit.Cm(2.5043103694915771), Unit.Cm(1.2899999618530273));
			textBox97.Style.BorderStyle.Default = BorderType.Solid;
			textBox97.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox97.Style.Font.Name = "맑은 고딕";
			textBox97.Style.Font.Size = Unit.Point(10.0);
			textBox97.Style.VerticalAlign = VerticalAlign.Middle;
			textBox97.StyleName = "";
			textBox98.Name = "textBox98";
			textBox98.Size = new SizeU(Unit.Cm(0.87150079011917114), Unit.Cm(1.2899999618530273));
			textBox98.Style.BorderStyle.Default = BorderType.Solid;
			textBox98.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox98.Style.Font.Name = "맑은 고딕";
			textBox98.Style.Font.Size = Unit.Point(10.0);
			textBox98.Style.TextAlign = HorizontalAlign.Center;
			textBox98.Style.VerticalAlign = VerticalAlign.Middle;
			textBox98.StyleName = "";
			textBox98.Value = "O";
			textBox101.Name = "textBox101";
			textBox101.Size = new SizeU(Unit.Cm(1.5025873184204102), Unit.Cm(1.2899999618530273));
			textBox101.Style.BorderStyle.Default = BorderType.Solid;
			textBox101.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox101.Style.Font.Name = "맑은 고딕";
			textBox101.Style.Font.Size = Unit.Point(10.0);
			textBox101.Style.TextAlign = HorizontalAlign.Right;
			textBox101.Style.VerticalAlign = VerticalAlign.Middle;
			textBox101.StyleName = "";
			textBox102.Name = "textBox102";
			textBox102.Size = new SizeU(Unit.Cm(2.003450870513916), Unit.Cm(1.2899999618530273));
			textBox102.Style.BackgroundColor = Color.White;
			textBox102.Style.BorderStyle.Default = BorderType.Solid;
			textBox102.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox102.Style.Font.Name = "맑은 고딕";
			textBox102.Style.Font.Size = Unit.Point(10.0);
			textBox102.Style.TextAlign = HorizontalAlign.Center;
			textBox102.Style.VerticalAlign = VerticalAlign.Middle;
			textBox102.StyleName = "";
			textBox103.Name = "textBox103";
			textBox103.Size = new SizeU(Unit.Cm(1.8031057119369507), Unit.Cm(1.2899999618530273));
			textBox103.Style.BackgroundColor = Color.White;
			textBox103.Style.BorderStyle.Default = BorderType.Solid;
			textBox103.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox103.Style.Font.Name = "맑은 고딕";
			textBox103.Style.Font.Size = Unit.Point(10.0);
			textBox103.Style.TextAlign = HorizontalAlign.Center;
			textBox103.Style.VerticalAlign = VerticalAlign.Middle;
			textBox103.StyleName = "";
			textBox104.Name = "textBox104";
			textBox104.Size = new SizeU(Unit.Cm(4.8038330078125), Unit.Cm(1.2899999618530273));
			textBox104.Style.BackgroundColor = Color.White;
			textBox104.Style.BorderStyle.Default = BorderType.Solid;
			textBox104.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox104.Style.Font.Name = "맑은 고딕";
			textBox104.Style.Font.Size = Unit.Point(10.0);
			textBox104.Style.TextAlign = HorizontalAlign.Center;
			textBox104.Style.VerticalAlign = VerticalAlign.Middle;
			textBox104.StyleName = "";
			textBox105.Name = "textBox105";
			textBox105.Size = new SizeU(Unit.Cm(2.2538809776306152), Unit.Cm(1.2899999618530273));
			textBox105.Style.BackgroundColor = Color.White;
			textBox105.Style.BorderStyle.Default = BorderType.Solid;
			textBox105.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox105.Style.Font.Name = "맑은 고딕";
			textBox105.Style.Font.Size = Unit.Point(10.0);
			textBox105.Style.TextAlign = HorizontalAlign.Center;
			textBox105.Style.VerticalAlign = VerticalAlign.Middle;
			textBox105.StyleName = "";
			textBox106.Name = "textBox106";
			textBox106.Size = new SizeU(Unit.Cm(0.876509428024292), Unit.Cm(1.2899999618530273));
			textBox106.Style.BorderStyle.Default = BorderType.Solid;
			textBox106.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox106.Style.Font.Name = "맑은 고딕";
			textBox106.Style.Font.Size = Unit.Point(10.0);
			textBox106.Style.TextAlign = HorizontalAlign.Center;
			textBox106.Style.VerticalAlign = VerticalAlign.Middle;
			textBox106.StyleName = "";
			textBox111.Name = "textBox111";
			textBox111.Size = new SizeU(Unit.Cm(2.5043103694915771), Unit.Cm(1.2899999618530273));
			textBox111.Style.BorderStyle.Default = BorderType.Solid;
			textBox111.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox111.Style.Font.Name = "맑은 고딕";
			textBox111.Style.Font.Size = Unit.Point(10.0);
			textBox111.Style.VerticalAlign = VerticalAlign.Middle;
			textBox111.StyleName = "";
			textBox112.Name = "textBox112";
			textBox112.Size = new SizeU(Unit.Cm(0.87150084972381592), Unit.Cm(1.2899999618530273));
			textBox112.Style.BorderStyle.Default = BorderType.Solid;
			textBox112.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox112.Style.Font.Name = "맑은 고딕";
			textBox112.Style.Font.Size = Unit.Point(10.0);
			textBox112.Style.TextAlign = HorizontalAlign.Center;
			textBox112.Style.VerticalAlign = VerticalAlign.Middle;
			textBox112.StyleName = "";
			textBox112.Value = "I";
			textBox113.Name = "textBox113";
			textBox113.Size = new SizeU(Unit.Cm(1.5025874376296997), Unit.Cm(1.2899999618530273));
			textBox113.Style.BorderStyle.Default = BorderType.Solid;
			textBox113.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox113.Style.Font.Name = "맑은 고딕";
			textBox113.Style.Font.Size = Unit.Point(10.0);
			textBox113.Style.TextAlign = HorizontalAlign.Right;
			textBox113.Style.VerticalAlign = VerticalAlign.Middle;
			textBox113.StyleName = "";
			textBox114.Name = "textBox114";
			textBox114.Size = new SizeU(Unit.Cm(2.003450870513916), Unit.Cm(1.2899999618530273));
			textBox114.Style.BackgroundColor = Color.White;
			textBox114.Style.BorderStyle.Default = BorderType.Solid;
			textBox114.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox114.Style.Font.Name = "맑은 고딕";
			textBox114.Style.Font.Size = Unit.Point(10.0);
			textBox114.Style.TextAlign = HorizontalAlign.Center;
			textBox114.Style.VerticalAlign = VerticalAlign.Middle;
			textBox114.StyleName = "";
			textBox115.Name = "textBox115";
			textBox115.Size = new SizeU(Unit.Cm(1.8031058311462402), Unit.Cm(1.2899999618530273));
			textBox115.Style.BackgroundColor = Color.White;
			textBox115.Style.BorderStyle.Default = BorderType.Solid;
			textBox115.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox115.Style.Font.Name = "맑은 고딕";
			textBox115.Style.Font.Size = Unit.Point(10.0);
			textBox115.Style.TextAlign = HorizontalAlign.Center;
			textBox115.Style.VerticalAlign = VerticalAlign.Middle;
			textBox115.StyleName = "";
			textBox116.Name = "textBox116";
			textBox116.Size = new SizeU(Unit.Cm(4.8038330078125), Unit.Cm(1.2899999618530273));
			textBox116.Style.BackgroundColor = Color.White;
			textBox116.Style.BorderStyle.Default = BorderType.Solid;
			textBox116.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox116.Style.Font.Name = "맑은 고딕";
			textBox116.Style.Font.Size = Unit.Point(10.0);
			textBox116.Style.TextAlign = HorizontalAlign.Center;
			textBox116.Style.VerticalAlign = VerticalAlign.Middle;
			textBox116.StyleName = "";
			textBox117.Name = "textBox117";
			textBox117.Size = new SizeU(Unit.Cm(2.2538809776306152), Unit.Cm(1.2899999618530273));
			textBox117.Style.BackgroundColor = Color.White;
			textBox117.Style.BorderStyle.Default = BorderType.Solid;
			textBox117.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox117.Style.Font.Name = "맑은 고딕";
			textBox117.Style.Font.Size = Unit.Point(10.0);
			textBox117.Style.TextAlign = HorizontalAlign.Center;
			textBox117.Style.VerticalAlign = VerticalAlign.Middle;
			textBox117.StyleName = "";
			textBox118.Name = "textBox118";
			textBox118.Size = new SizeU(Unit.Cm(0.876509428024292), Unit.Cm(1.2899998426437378));
			textBox118.Style.BorderStyle.Default = BorderType.Solid;
			textBox118.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox118.Style.Font.Name = "맑은 고딕";
			textBox118.Style.Font.Size = Unit.Point(10.0);
			textBox118.Style.TextAlign = HorizontalAlign.Center;
			textBox118.Style.VerticalAlign = VerticalAlign.Middle;
			textBox118.StyleName = "";
			textBox121.Name = "textBox121";
			textBox121.Size = new SizeU(Unit.Cm(2.5043103694915771), Unit.Cm(1.2899998426437378));
			textBox121.Style.BorderStyle.Default = BorderType.Solid;
			textBox121.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox121.Style.Font.Name = "맑은 고딕";
			textBox121.Style.Font.Size = Unit.Point(10.0);
			textBox121.Style.VerticalAlign = VerticalAlign.Middle;
			textBox121.StyleName = "";
			textBox122.Name = "textBox122";
			textBox122.Size = new SizeU(Unit.Cm(0.87150084972381592), Unit.Cm(1.2899998426437378));
			textBox122.Style.BorderStyle.Default = BorderType.Solid;
			textBox122.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox122.Style.Font.Name = "맑은 고딕";
			textBox122.Style.Font.Size = Unit.Point(10.0);
			textBox122.Style.TextAlign = HorizontalAlign.Center;
			textBox122.Style.VerticalAlign = VerticalAlign.Middle;
			textBox122.StyleName = "";
			textBox122.Value = "O";
			textBox123.Name = "textBox123";
			textBox123.Size = new SizeU(Unit.Cm(1.5025873184204102), Unit.Cm(1.2899998426437378));
			textBox123.Style.BorderStyle.Default = BorderType.Solid;
			textBox123.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox123.Style.Font.Name = "맑은 고딕";
			textBox123.Style.Font.Size = Unit.Point(10.0);
			textBox123.Style.TextAlign = HorizontalAlign.Right;
			textBox123.Style.VerticalAlign = VerticalAlign.Middle;
			textBox123.StyleName = "";
			textBox124.Name = "textBox124";
			textBox124.Size = new SizeU(Unit.Cm(2.003450870513916), Unit.Cm(1.2899998426437378));
			textBox124.Style.BackgroundColor = Color.White;
			textBox124.Style.BorderStyle.Default = BorderType.Solid;
			textBox124.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox124.Style.Font.Name = "맑은 고딕";
			textBox124.Style.Font.Size = Unit.Point(10.0);
			textBox124.Style.TextAlign = HorizontalAlign.Center;
			textBox124.Style.VerticalAlign = VerticalAlign.Middle;
			textBox124.StyleName = "";
			textBox125.Name = "textBox125";
			textBox125.Size = new SizeU(Unit.Cm(1.8031057119369507), Unit.Cm(1.2899998426437378));
			textBox125.Style.BackgroundColor = Color.White;
			textBox125.Style.BorderStyle.Default = BorderType.Solid;
			textBox125.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox125.Style.Font.Name = "맑은 고딕";
			textBox125.Style.Font.Size = Unit.Point(10.0);
			textBox125.Style.TextAlign = HorizontalAlign.Center;
			textBox125.Style.VerticalAlign = VerticalAlign.Middle;
			textBox125.StyleName = "";
			textBox126.Name = "textBox126";
			textBox126.Size = new SizeU(Unit.Cm(4.8038330078125), Unit.Cm(1.2899998426437378));
			textBox126.Style.BackgroundColor = Color.White;
			textBox126.Style.BorderStyle.Default = BorderType.Solid;
			textBox126.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox126.Style.Font.Name = "맑은 고딕";
			textBox126.Style.Font.Size = Unit.Point(10.0);
			textBox126.Style.TextAlign = HorizontalAlign.Center;
			textBox126.Style.VerticalAlign = VerticalAlign.Middle;
			textBox126.StyleName = "";
			textBox127.Name = "textBox127";
			textBox127.Size = new SizeU(Unit.Cm(2.2538809776306152), Unit.Cm(1.2899998426437378));
			textBox127.Style.BackgroundColor = Color.White;
			textBox127.Style.BorderStyle.Default = BorderType.Solid;
			textBox127.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox127.Style.Font.Name = "맑은 고딕";
			textBox127.Style.Font.Size = Unit.Point(10.0);
			textBox127.Style.TextAlign = HorizontalAlign.Center;
			textBox127.Style.VerticalAlign = VerticalAlign.Middle;
			textBox127.StyleName = "";
			textBox128.Name = "textBox128";
			textBox128.Size = new SizeU(Unit.Cm(0.87650936841964722), Unit.Cm(1.2899999618530273));
			textBox128.Style.BorderStyle.Default = BorderType.Solid;
			textBox128.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox128.Style.Font.Name = "맑은 고딕";
			textBox128.Style.Font.Size = Unit.Point(10.0);
			textBox128.Style.TextAlign = HorizontalAlign.Center;
			textBox128.Style.VerticalAlign = VerticalAlign.Middle;
			textBox128.StyleName = "";
			textBox131.Name = "textBox131";
			textBox131.Size = new SizeU(Unit.Cm(2.5043103694915771), Unit.Cm(1.2899999618530273));
			textBox131.Style.BorderStyle.Default = BorderType.Solid;
			textBox131.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox131.Style.Font.Name = "맑은 고딕";
			textBox131.Style.Font.Size = Unit.Point(10.0);
			textBox131.Style.VerticalAlign = VerticalAlign.Middle;
			textBox131.StyleName = "";
			textBox132.Name = "textBox132";
			textBox132.Size = new SizeU(Unit.Cm(0.87150079011917114), Unit.Cm(1.2899999618530273));
			textBox132.Style.BorderStyle.Default = BorderType.Solid;
			textBox132.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox132.Style.Font.Name = "맑은 고딕";
			textBox132.Style.Font.Size = Unit.Point(10.0);
			textBox132.Style.TextAlign = HorizontalAlign.Center;
			textBox132.Style.VerticalAlign = VerticalAlign.Middle;
			textBox132.StyleName = "";
			textBox132.Value = "O";
			textBox133.Name = "textBox133";
			textBox133.Size = new SizeU(Unit.Cm(1.5025873184204102), Unit.Cm(1.2899999618530273));
			textBox133.Style.BorderStyle.Default = BorderType.Solid;
			textBox133.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox133.Style.Font.Name = "맑은 고딕";
			textBox133.Style.Font.Size = Unit.Point(10.0);
			textBox133.Style.TextAlign = HorizontalAlign.Right;
			textBox133.Style.VerticalAlign = VerticalAlign.Middle;
			textBox133.StyleName = "";
			textBox134.Name = "textBox134";
			textBox134.Size = new SizeU(Unit.Cm(2.003450870513916), Unit.Cm(1.2899999618530273));
			textBox134.Style.BackgroundColor = Color.White;
			textBox134.Style.BorderStyle.Default = BorderType.Solid;
			textBox134.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox134.Style.Font.Name = "맑은 고딕";
			textBox134.Style.Font.Size = Unit.Point(10.0);
			textBox134.Style.TextAlign = HorizontalAlign.Center;
			textBox134.Style.VerticalAlign = VerticalAlign.Middle;
			textBox134.StyleName = "";
			textBox135.Name = "textBox135";
			textBox135.Size = new SizeU(Unit.Cm(1.8031057119369507), Unit.Cm(1.2899999618530273));
			textBox135.Style.BackgroundColor = Color.White;
			textBox135.Style.BorderStyle.Default = BorderType.Solid;
			textBox135.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox135.Style.Font.Name = "맑은 고딕";
			textBox135.Style.Font.Size = Unit.Point(10.0);
			textBox135.Style.TextAlign = HorizontalAlign.Center;
			textBox135.Style.VerticalAlign = VerticalAlign.Middle;
			textBox135.StyleName = "";
			textBox136.Name = "textBox136";
			textBox136.Size = new SizeU(Unit.Cm(4.8038330078125), Unit.Cm(1.2899999618530273));
			textBox136.Style.BackgroundColor = Color.White;
			textBox136.Style.BorderStyle.Default = BorderType.Solid;
			textBox136.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox136.Style.Font.Name = "맑은 고딕";
			textBox136.Style.Font.Size = Unit.Point(10.0);
			textBox136.Style.TextAlign = HorizontalAlign.Center;
			textBox136.Style.VerticalAlign = VerticalAlign.Middle;
			textBox136.StyleName = "";
			textBox137.Name = "textBox137";
			textBox137.Size = new SizeU(Unit.Cm(2.2538809776306152), Unit.Cm(1.2899999618530273));
			textBox137.Style.BackgroundColor = Color.White;
			textBox137.Style.BorderStyle.Default = BorderType.Solid;
			textBox137.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox137.Style.Font.Name = "맑은 고딕";
			textBox137.Style.Font.Size = Unit.Point(10.0);
			textBox137.Style.TextAlign = HorizontalAlign.Center;
			textBox137.Style.VerticalAlign = VerticalAlign.Middle;
			textBox137.StyleName = "";
			textBox138.Name = "textBox138";
			textBox138.Size = new SizeU(Unit.Cm(0.876509428024292), Unit.Cm(1.2899999618530273));
			textBox138.Style.BorderStyle.Default = BorderType.Solid;
			textBox138.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox138.Style.Font.Name = "맑은 고딕";
			textBox138.Style.Font.Size = Unit.Point(10.0);
			textBox138.Style.TextAlign = HorizontalAlign.Center;
			textBox138.Style.VerticalAlign = VerticalAlign.Middle;
			textBox138.StyleName = "";
			textBox141.Name = "textBox141";
			textBox141.Size = new SizeU(Unit.Cm(2.5043103694915771), Unit.Cm(1.2899999618530273));
			textBox141.Style.BorderStyle.Default = BorderType.Solid;
			textBox141.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox141.Style.Font.Name = "맑은 고딕";
			textBox141.Style.Font.Size = Unit.Point(10.0);
			textBox141.Style.VerticalAlign = VerticalAlign.Middle;
			textBox141.StyleName = "";
			textBox142.Name = "textBox142";
			textBox142.Size = new SizeU(Unit.Cm(0.87150084972381592), Unit.Cm(1.2899999618530273));
			textBox142.Style.BorderStyle.Default = BorderType.Solid;
			textBox142.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox142.Style.Font.Name = "맑은 고딕";
			textBox142.Style.Font.Size = Unit.Point(10.0);
			textBox142.Style.TextAlign = HorizontalAlign.Center;
			textBox142.Style.VerticalAlign = VerticalAlign.Middle;
			textBox142.StyleName = "";
			textBox142.Value = "O";
			textBox143.Name = "textBox143";
			textBox143.Size = new SizeU(Unit.Cm(1.5025874376296997), Unit.Cm(1.2899999618530273));
			textBox143.Style.BorderStyle.Default = BorderType.Solid;
			textBox143.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox143.Style.Font.Name = "맑은 고딕";
			textBox143.Style.Font.Size = Unit.Point(10.0);
			textBox143.Style.TextAlign = HorizontalAlign.Right;
			textBox143.Style.VerticalAlign = VerticalAlign.Middle;
			textBox143.StyleName = "";
			textBox144.Name = "textBox144";
			textBox144.Size = new SizeU(Unit.Cm(2.003450870513916), Unit.Cm(1.2899999618530273));
			textBox144.Style.BackgroundColor = Color.White;
			textBox144.Style.BorderStyle.Default = BorderType.Solid;
			textBox144.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox144.Style.Font.Name = "맑은 고딕";
			textBox144.Style.Font.Size = Unit.Point(10.0);
			textBox144.Style.TextAlign = HorizontalAlign.Center;
			textBox144.Style.VerticalAlign = VerticalAlign.Middle;
			textBox144.StyleName = "";
			textBox145.Name = "textBox145";
			textBox145.Size = new SizeU(Unit.Cm(1.8031058311462402), Unit.Cm(1.2899999618530273));
			textBox145.Style.BackgroundColor = Color.White;
			textBox145.Style.BorderStyle.Default = BorderType.Solid;
			textBox145.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox145.Style.Font.Name = "맑은 고딕";
			textBox145.Style.Font.Size = Unit.Point(10.0);
			textBox145.Style.TextAlign = HorizontalAlign.Center;
			textBox145.Style.VerticalAlign = VerticalAlign.Middle;
			textBox145.StyleName = "";
			textBox146.Name = "textBox146";
			textBox146.Size = new SizeU(Unit.Cm(4.8038330078125), Unit.Cm(1.2899999618530273));
			textBox146.Style.BackgroundColor = Color.White;
			textBox146.Style.BorderStyle.Default = BorderType.Solid;
			textBox146.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox146.Style.Font.Name = "맑은 고딕";
			textBox146.Style.Font.Size = Unit.Point(10.0);
			textBox146.Style.TextAlign = HorizontalAlign.Center;
			textBox146.Style.VerticalAlign = VerticalAlign.Middle;
			textBox146.StyleName = "";
			textBox147.Name = "textBox147";
			textBox147.Size = new SizeU(Unit.Cm(2.2538812160491943), Unit.Cm(1.2899999618530273));
			textBox147.Style.BackgroundColor = Color.White;
			textBox147.Style.BorderStyle.Default = BorderType.Solid;
			textBox147.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox147.Style.Font.Name = "맑은 고딕";
			textBox147.Style.Font.Size = Unit.Point(10.0);
			textBox147.Style.TextAlign = HorizontalAlign.Center;
			textBox147.Style.VerticalAlign = VerticalAlign.Middle;
			textBox147.StyleName = "";
			textBox148.Name = "textBox148";
			textBox148.Size = new SizeU(Unit.Cm(0.876509428024292), Unit.Cm(1.2899998426437378));
			textBox148.Style.BorderStyle.Default = BorderType.Solid;
			textBox148.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox148.Style.Font.Name = "맑은 고딕";
			textBox148.Style.Font.Size = Unit.Point(10.0);
			textBox148.Style.TextAlign = HorizontalAlign.Center;
			textBox148.Style.VerticalAlign = VerticalAlign.Middle;
			textBox148.StyleName = "";
			textBox151.Name = "textBox151";
			textBox151.Size = new SizeU(Unit.Cm(2.5043103694915771), Unit.Cm(1.2899998426437378));
			textBox151.Style.BorderStyle.Default = BorderType.Solid;
			textBox151.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox151.Style.Font.Name = "맑은 고딕";
			textBox151.Style.Font.Size = Unit.Point(10.0);
			textBox151.Style.VerticalAlign = VerticalAlign.Middle;
			textBox151.StyleName = "";
			textBox152.Name = "textBox152";
			textBox152.Size = new SizeU(Unit.Cm(0.87150084972381592), Unit.Cm(1.2899998426437378));
			textBox152.Style.BorderStyle.Default = BorderType.Solid;
			textBox152.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox152.Style.Font.Name = "맑은 고딕";
			textBox152.Style.Font.Size = Unit.Point(10.0);
			textBox152.Style.TextAlign = HorizontalAlign.Center;
			textBox152.Style.VerticalAlign = VerticalAlign.Middle;
			textBox152.StyleName = "";
			textBox152.Value = "O";
			textBox153.Name = "textBox153";
			textBox153.Size = new SizeU(Unit.Cm(1.5025874376296997), Unit.Cm(1.2899998426437378));
			textBox153.Style.BorderStyle.Default = BorderType.Solid;
			textBox153.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox153.Style.Font.Name = "맑은 고딕";
			textBox153.Style.Font.Size = Unit.Point(10.0);
			textBox153.Style.TextAlign = HorizontalAlign.Right;
			textBox153.Style.VerticalAlign = VerticalAlign.Middle;
			textBox153.StyleName = "";
			textBox154.Name = "textBox154";
			textBox154.Size = new SizeU(Unit.Cm(2.003450870513916), Unit.Cm(1.2899998426437378));
			textBox154.Style.BackgroundColor = Color.White;
			textBox154.Style.BorderStyle.Default = BorderType.Solid;
			textBox154.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox154.Style.Font.Name = "맑은 고딕";
			textBox154.Style.Font.Size = Unit.Point(10.0);
			textBox154.Style.TextAlign = HorizontalAlign.Center;
			textBox154.Style.VerticalAlign = VerticalAlign.Middle;
			textBox154.StyleName = "";
			textBox155.Name = "textBox155";
			textBox155.Size = new SizeU(Unit.Cm(1.8031058311462402), Unit.Cm(1.2899998426437378));
			textBox155.Style.BackgroundColor = Color.White;
			textBox155.Style.BorderStyle.Default = BorderType.Solid;
			textBox155.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox155.Style.Font.Name = "맑은 고딕";
			textBox155.Style.Font.Size = Unit.Point(10.0);
			textBox155.Style.TextAlign = HorizontalAlign.Center;
			textBox155.Style.VerticalAlign = VerticalAlign.Middle;
			textBox155.StyleName = "";
			textBox156.Name = "textBox156";
			textBox156.Size = new SizeU(Unit.Cm(4.8038330078125), Unit.Cm(1.2899998426437378));
			textBox156.Style.BackgroundColor = Color.White;
			textBox156.Style.BorderStyle.Default = BorderType.Solid;
			textBox156.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox156.Style.Font.Name = "맑은 고딕";
			textBox156.Style.Font.Size = Unit.Point(10.0);
			textBox156.Style.TextAlign = HorizontalAlign.Center;
			textBox156.Style.VerticalAlign = VerticalAlign.Middle;
			textBox156.StyleName = "";
			textBox157.Name = "textBox157";
			textBox157.Size = new SizeU(Unit.Cm(2.2538809776306152), Unit.Cm(1.2899998426437378));
			textBox157.Style.BackgroundColor = Color.White;
			textBox157.Style.BorderStyle.Default = BorderType.Solid;
			textBox157.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox157.Style.Font.Name = "맑은 고딕";
			textBox157.Style.Font.Size = Unit.Point(10.0);
			textBox157.Style.TextAlign = HorizontalAlign.Center;
			textBox157.Style.VerticalAlign = VerticalAlign.Middle;
			textBox157.StyleName = "";
			textBox158.Name = "textBox158";
			textBox158.Size = new SizeU(Unit.Cm(0.87650936841964722), Unit.Cm(1.2899999618530273));
			textBox158.Style.BorderStyle.Default = BorderType.Solid;
			textBox158.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox158.Style.Font.Name = "맑은 고딕";
			textBox158.Style.Font.Size = Unit.Point(10.0);
			textBox158.Style.TextAlign = HorizontalAlign.Center;
			textBox158.Style.VerticalAlign = VerticalAlign.Middle;
			textBox158.StyleName = "";
			textBox161.Name = "textBox161";
			textBox161.Size = new SizeU(Unit.Cm(2.5043103694915771), Unit.Cm(1.2899999618530273));
			textBox161.Style.BorderStyle.Default = BorderType.Solid;
			textBox161.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox161.Style.Font.Name = "맑은 고딕";
			textBox161.Style.Font.Size = Unit.Point(10.0);
			textBox161.Style.VerticalAlign = VerticalAlign.Middle;
			textBox161.StyleName = "";
			textBox162.Name = "textBox162";
			textBox162.Size = new SizeU(Unit.Cm(0.87150079011917114), Unit.Cm(1.2899999618530273));
			textBox162.Style.BorderStyle.Default = BorderType.Solid;
			textBox162.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox162.Style.Font.Name = "맑은 고딕";
			textBox162.Style.Font.Size = Unit.Point(10.0);
			textBox162.Style.TextAlign = HorizontalAlign.Center;
			textBox162.Style.VerticalAlign = VerticalAlign.Middle;
			textBox162.StyleName = "";
			textBox162.Value = "O";
			textBox163.Name = "textBox163";
			textBox163.Size = new SizeU(Unit.Cm(1.5025873184204102), Unit.Cm(1.2899999618530273));
			textBox163.Style.BorderStyle.Default = BorderType.Solid;
			textBox163.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox163.Style.Font.Name = "맑은 고딕";
			textBox163.Style.Font.Size = Unit.Point(10.0);
			textBox163.Style.TextAlign = HorizontalAlign.Right;
			textBox163.Style.VerticalAlign = VerticalAlign.Middle;
			textBox163.StyleName = "";
			textBox164.Name = "textBox164";
			textBox164.Size = new SizeU(Unit.Cm(2.003450870513916), Unit.Cm(1.2899999618530273));
			textBox164.Style.BackgroundColor = Color.White;
			textBox164.Style.BorderStyle.Default = BorderType.Solid;
			textBox164.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox164.Style.Font.Name = "맑은 고딕";
			textBox164.Style.Font.Size = Unit.Point(10.0);
			textBox164.Style.TextAlign = HorizontalAlign.Center;
			textBox164.Style.VerticalAlign = VerticalAlign.Middle;
			textBox164.StyleName = "";
			textBox165.Name = "textBox165";
			textBox165.Size = new SizeU(Unit.Cm(1.8031057119369507), Unit.Cm(1.2899999618530273));
			textBox165.Style.BackgroundColor = Color.White;
			textBox165.Style.BorderStyle.Default = BorderType.Solid;
			textBox165.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox165.Style.Font.Name = "맑은 고딕";
			textBox165.Style.Font.Size = Unit.Point(10.0);
			textBox165.Style.TextAlign = HorizontalAlign.Center;
			textBox165.Style.VerticalAlign = VerticalAlign.Middle;
			textBox165.StyleName = "";
			textBox166.Name = "textBox166";
			textBox166.Size = new SizeU(Unit.Cm(4.8038330078125), Unit.Cm(1.2899999618530273));
			textBox166.Style.BackgroundColor = Color.White;
			textBox166.Style.BorderStyle.Default = BorderType.Solid;
			textBox166.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox166.Style.Font.Name = "맑은 고딕";
			textBox166.Style.Font.Size = Unit.Point(10.0);
			textBox166.Style.TextAlign = HorizontalAlign.Center;
			textBox166.Style.VerticalAlign = VerticalAlign.Middle;
			textBox166.StyleName = "";
			textBox167.Name = "textBox167";
			textBox167.Size = new SizeU(Unit.Cm(2.2538809776306152), Unit.Cm(1.2899999618530273));
			textBox167.Style.BackgroundColor = Color.White;
			textBox167.Style.BorderStyle.Default = BorderType.Solid;
			textBox167.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox167.Style.Font.Name = "맑은 고딕";
			textBox167.Style.Font.Size = Unit.Point(10.0);
			textBox167.Style.TextAlign = HorizontalAlign.Center;
			textBox167.Style.VerticalAlign = VerticalAlign.Middle;
			textBox167.StyleName = "";
			textBox168.Name = "textBox168";
			textBox168.Size = new SizeU(Unit.Cm(0.87650936841964722), Unit.Cm(1.2899999618530273));
			textBox168.Style.BorderStyle.Default = BorderType.Solid;
			textBox168.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox168.Style.Font.Name = "맑은 고딕";
			textBox168.Style.Font.Size = Unit.Point(10.0);
			textBox168.Style.TextAlign = HorizontalAlign.Center;
			textBox168.Style.VerticalAlign = VerticalAlign.Middle;
			textBox168.StyleName = "";
			textBox171.Name = "textBox171";
			textBox171.Size = new SizeU(Unit.Cm(2.5043103694915771), Unit.Cm(1.2899999618530273));
			textBox171.Style.BorderStyle.Default = BorderType.Solid;
			textBox171.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox171.Style.Font.Name = "맑은 고딕";
			textBox171.Style.Font.Size = Unit.Point(10.0);
			textBox171.Style.VerticalAlign = VerticalAlign.Middle;
			textBox171.StyleName = "";
			textBox172.Name = "textBox172";
			textBox172.Size = new SizeU(Unit.Cm(0.87150079011917114), Unit.Cm(1.2899999618530273));
			textBox172.Style.BorderStyle.Default = BorderType.Solid;
			textBox172.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox172.Style.Font.Name = "맑은 고딕";
			textBox172.Style.Font.Size = Unit.Point(10.0);
			textBox172.Style.TextAlign = HorizontalAlign.Center;
			textBox172.Style.VerticalAlign = VerticalAlign.Middle;
			textBox172.StyleName = "";
			textBox172.Value = "O";
			textBox173.Name = "textBox173";
			textBox173.Size = new SizeU(Unit.Cm(1.5025874376296997), Unit.Cm(1.2899999618530273));
			textBox173.Style.BorderStyle.Default = BorderType.Solid;
			textBox173.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox173.Style.Font.Name = "맑은 고딕";
			textBox173.Style.Font.Size = Unit.Point(10.0);
			textBox173.Style.TextAlign = HorizontalAlign.Right;
			textBox173.Style.VerticalAlign = VerticalAlign.Middle;
			textBox173.StyleName = "";
			textBox174.Name = "textBox174";
			textBox174.Size = new SizeU(Unit.Cm(2.0034506320953369), Unit.Cm(1.2899999618530273));
			textBox174.Style.BackgroundColor = Color.White;
			textBox174.Style.BorderStyle.Default = BorderType.Solid;
			textBox174.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox174.Style.Font.Name = "맑은 고딕";
			textBox174.Style.Font.Size = Unit.Point(10.0);
			textBox174.Style.TextAlign = HorizontalAlign.Center;
			textBox174.Style.VerticalAlign = VerticalAlign.Middle;
			textBox174.StyleName = "";
			textBox175.Name = "textBox175";
			textBox175.Size = new SizeU(Unit.Cm(1.8031057119369507), Unit.Cm(1.2899999618530273));
			textBox175.Style.BackgroundColor = Color.White;
			textBox175.Style.BorderStyle.Default = BorderType.Solid;
			textBox175.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox175.Style.Font.Name = "맑은 고딕";
			textBox175.Style.Font.Size = Unit.Point(10.0);
			textBox175.Style.TextAlign = HorizontalAlign.Center;
			textBox175.Style.VerticalAlign = VerticalAlign.Middle;
			textBox175.StyleName = "";
			textBox176.Name = "textBox176";
			textBox176.Size = new SizeU(Unit.Cm(4.8038330078125), Unit.Cm(1.2899999618530273));
			textBox176.Style.BackgroundColor = Color.White;
			textBox176.Style.BorderStyle.Default = BorderType.Solid;
			textBox176.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox176.Style.Font.Name = "맑은 고딕";
			textBox176.Style.Font.Size = Unit.Point(10.0);
			textBox176.Style.TextAlign = HorizontalAlign.Center;
			textBox176.Style.VerticalAlign = VerticalAlign.Middle;
			textBox176.StyleName = "";
			textBox177.Name = "textBox177";
			textBox177.Size = new SizeU(Unit.Cm(2.2538809776306152), Unit.Cm(1.2899999618530273));
			textBox177.Style.BackgroundColor = Color.White;
			textBox177.Style.BorderStyle.Default = BorderType.Solid;
			textBox177.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox177.Style.Font.Name = "맑은 고딕";
			textBox177.Style.Font.Size = Unit.Point(10.0);
			textBox177.Style.TextAlign = HorizontalAlign.Center;
			textBox177.Style.VerticalAlign = VerticalAlign.Middle;
			textBox177.StyleName = "";
			textBox178.Name = "textBox178";
			textBox178.Size = new SizeU(Unit.Cm(0.876509428024292), Unit.Cm(1.2899999618530273));
			textBox178.Style.BorderStyle.Default = BorderType.Solid;
			textBox178.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox178.Style.Font.Name = "맑은 고딕";
			textBox178.Style.Font.Size = Unit.Point(10.0);
			textBox178.Style.TextAlign = HorizontalAlign.Center;
			textBox178.Style.VerticalAlign = VerticalAlign.Middle;
			textBox178.StyleName = "";
			textBox181.Name = "textBox181";
			textBox181.Size = new SizeU(Unit.Cm(2.5043103694915771), Unit.Cm(1.2899999618530273));
			textBox181.Style.BorderStyle.Default = BorderType.Solid;
			textBox181.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox181.Style.Font.Name = "맑은 고딕";
			textBox181.Style.Font.Size = Unit.Point(10.0);
			textBox181.Style.VerticalAlign = VerticalAlign.Middle;
			textBox181.StyleName = "";
			textBox182.Name = "textBox182";
			textBox182.Size = new SizeU(Unit.Cm(0.87150084972381592), Unit.Cm(1.2899999618530273));
			textBox182.Style.BorderStyle.Default = BorderType.Solid;
			textBox182.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox182.Style.Font.Name = "맑은 고딕";
			textBox182.Style.Font.Size = Unit.Point(10.0);
			textBox182.Style.TextAlign = HorizontalAlign.Center;
			textBox182.Style.VerticalAlign = VerticalAlign.Middle;
			textBox182.StyleName = "";
			textBox182.Value = "O";
			textBox183.Name = "textBox183";
			textBox183.Size = new SizeU(Unit.Cm(1.5025874376296997), Unit.Cm(1.2899999618530273));
			textBox183.Style.BorderStyle.Default = BorderType.Solid;
			textBox183.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox183.Style.Font.Name = "맑은 고딕";
			textBox183.Style.Font.Size = Unit.Point(10.0);
			textBox183.Style.TextAlign = HorizontalAlign.Right;
			textBox183.Style.VerticalAlign = VerticalAlign.Middle;
			textBox183.StyleName = "";
			textBox184.Name = "textBox184";
			textBox184.Size = new SizeU(Unit.Cm(2.003450870513916), Unit.Cm(1.2899999618530273));
			textBox184.Style.BackgroundColor = Color.White;
			textBox184.Style.BorderStyle.Default = BorderType.Solid;
			textBox184.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox184.Style.Font.Name = "맑은 고딕";
			textBox184.Style.Font.Size = Unit.Point(10.0);
			textBox184.Style.TextAlign = HorizontalAlign.Center;
			textBox184.Style.VerticalAlign = VerticalAlign.Middle;
			textBox184.StyleName = "";
			textBox185.Name = "textBox185";
			textBox185.Size = new SizeU(Unit.Cm(1.8031058311462402), Unit.Cm(1.2899999618530273));
			textBox185.Style.BackgroundColor = Color.White;
			textBox185.Style.BorderStyle.Default = BorderType.Solid;
			textBox185.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox185.Style.Font.Name = "맑은 고딕";
			textBox185.Style.Font.Size = Unit.Point(10.0);
			textBox185.Style.TextAlign = HorizontalAlign.Center;
			textBox185.Style.VerticalAlign = VerticalAlign.Middle;
			textBox185.StyleName = "";
			textBox186.Name = "textBox186";
			textBox186.Size = new SizeU(Unit.Cm(4.8038330078125), Unit.Cm(1.2899999618530273));
			textBox186.Style.BackgroundColor = Color.White;
			textBox186.Style.BorderStyle.Default = BorderType.Solid;
			textBox186.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox186.Style.Font.Name = "맑은 고딕";
			textBox186.Style.Font.Size = Unit.Point(10.0);
			textBox186.Style.TextAlign = HorizontalAlign.Center;
			textBox186.Style.VerticalAlign = VerticalAlign.Middle;
			textBox186.StyleName = "";
			textBox187.Name = "textBox187";
			textBox187.Size = new SizeU(Unit.Cm(2.2538809776306152), Unit.Cm(1.2899999618530273));
			textBox187.Style.BackgroundColor = Color.White;
			textBox187.Style.BorderStyle.Default = BorderType.Solid;
			textBox187.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox187.Style.Font.Name = "맑은 고딕";
			textBox187.Style.Font.Size = Unit.Point(10.0);
			textBox187.Style.TextAlign = HorizontalAlign.Center;
			textBox187.Style.VerticalAlign = VerticalAlign.Middle;
			textBox187.StyleName = "";
			textBox188.Name = "textBox188";
			textBox188.Size = new SizeU(Unit.Cm(0.87650936841964722), Unit.Cm(1.2899999618530273));
			textBox188.Style.BorderStyle.Default = BorderType.Solid;
			textBox188.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox188.Style.Font.Name = "맑은 고딕";
			textBox188.Style.Font.Size = Unit.Point(10.0);
			textBox188.Style.TextAlign = HorizontalAlign.Center;
			textBox188.Style.VerticalAlign = VerticalAlign.Middle;
			textBox188.StyleName = "";
			textBox191.Name = "textBox191";
			textBox191.Size = new SizeU(Unit.Cm(2.5043103694915771), Unit.Cm(1.2899999618530273));
			textBox191.Style.BorderStyle.Default = BorderType.Solid;
			textBox191.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox191.Style.Font.Name = "맑은 고딕";
			textBox191.Style.Font.Size = Unit.Point(10.0);
			textBox191.Style.VerticalAlign = VerticalAlign.Middle;
			textBox191.StyleName = "";
			textBox192.Name = "textBox192";
			textBox192.Size = new SizeU(Unit.Cm(0.87150079011917114), Unit.Cm(1.2899999618530273));
			textBox192.Style.BorderStyle.Default = BorderType.Solid;
			textBox192.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox192.Style.Font.Name = "맑은 고딕";
			textBox192.Style.Font.Size = Unit.Point(10.0);
			textBox192.Style.TextAlign = HorizontalAlign.Center;
			textBox192.Style.VerticalAlign = VerticalAlign.Middle;
			textBox192.StyleName = "";
			textBox192.Value = "O";
			textBox193.Name = "textBox193";
			textBox193.Size = new SizeU(Unit.Cm(1.5025873184204102), Unit.Cm(1.2899999618530273));
			textBox193.Style.BorderStyle.Default = BorderType.Solid;
			textBox193.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox193.Style.Font.Name = "맑은 고딕";
			textBox193.Style.Font.Size = Unit.Point(10.0);
			textBox193.Style.TextAlign = HorizontalAlign.Right;
			textBox193.Style.VerticalAlign = VerticalAlign.Middle;
			textBox193.StyleName = "";
			textBox194.Name = "textBox194";
			textBox194.Size = new SizeU(Unit.Cm(2.003450870513916), Unit.Cm(1.2899999618530273));
			textBox194.Style.BackgroundColor = Color.White;
			textBox194.Style.BorderStyle.Default = BorderType.Solid;
			textBox194.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox194.Style.Font.Name = "맑은 고딕";
			textBox194.Style.Font.Size = Unit.Point(10.0);
			textBox194.Style.TextAlign = HorizontalAlign.Center;
			textBox194.Style.VerticalAlign = VerticalAlign.Middle;
			textBox194.StyleName = "";
			textBox195.Name = "textBox195";
			textBox195.Size = new SizeU(Unit.Cm(1.8031057119369507), Unit.Cm(1.2899999618530273));
			textBox195.Style.BackgroundColor = Color.White;
			textBox195.Style.BorderStyle.Default = BorderType.Solid;
			textBox195.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox195.Style.Font.Name = "맑은 고딕";
			textBox195.Style.Font.Size = Unit.Point(10.0);
			textBox195.Style.TextAlign = HorizontalAlign.Center;
			textBox195.Style.VerticalAlign = VerticalAlign.Middle;
			textBox195.StyleName = "";
			textBox196.Name = "textBox196";
			textBox196.Size = new SizeU(Unit.Cm(4.8038330078125), Unit.Cm(1.2899999618530273));
			textBox196.Style.BackgroundColor = Color.White;
			textBox196.Style.BorderStyle.Default = BorderType.Solid;
			textBox196.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox196.Style.Font.Name = "맑은 고딕";
			textBox196.Style.Font.Size = Unit.Point(10.0);
			textBox196.Style.TextAlign = HorizontalAlign.Center;
			textBox196.Style.VerticalAlign = VerticalAlign.Middle;
			textBox196.StyleName = "";
			textBox197.Name = "textBox197";
			textBox197.Size = new SizeU(Unit.Cm(2.2538809776306152), Unit.Cm(1.2899999618530273));
			textBox197.Style.BackgroundColor = Color.White;
			textBox197.Style.BorderStyle.Default = BorderType.Solid;
			textBox197.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox197.Style.Font.Name = "맑은 고딕";
			textBox197.Style.Font.Size = Unit.Point(10.0);
			textBox197.Style.TextAlign = HorizontalAlign.Center;
			textBox197.Style.VerticalAlign = VerticalAlign.Middle;
			textBox197.StyleName = "";
			textBox35.Name = "textBox35";
			textBox35.Size = new SizeU(Unit.Cm(3.3808197975158691), Unit.Cm(1.2899999618530273));
			textBox35.Style.BorderStyle.Default = BorderType.Solid;
			textBox35.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox35.Style.Font.Name = "맑은 고딕";
			textBox35.Style.Font.Size = Unit.Point(10.0);
			textBox35.Style.VerticalAlign = VerticalAlign.Middle;
			textBox35.StyleName = "";
			textBox35.Value = "패턴조립세척";
			textBox52.Name = "textBox52";
			textBox52.Size = new SizeU(Unit.Cm(3.3808197975158691), Unit.Cm(1.2899999618530273));
			textBox52.Style.BorderStyle.Default = BorderType.Solid;
			textBox52.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox52.Style.Font.Name = "맑은 고딕";
			textBox52.Style.Font.Size = Unit.Point(10.0);
			textBox52.Style.VerticalAlign = VerticalAlign.Middle;
			textBox52.StyleName = "";
			textBox52.Value = "프라이머리코팅";
			textBox62.Name = "textBox62";
			textBox62.Size = new SizeU(Unit.Cm(3.3808197975158691), Unit.Cm(1.2899998426437378));
			textBox62.Style.BorderStyle.Default = BorderType.Solid;
			textBox62.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox62.Style.Font.Name = "맑은 고딕";
			textBox62.Style.Font.Size = Unit.Point(10.0);
			textBox62.Style.VerticalAlign = VerticalAlign.Middle;
			textBox62.StyleName = "";
			textBox62.Value = "백업코팅";
			textBox72.Name = "textBox72";
			textBox72.Size = new SizeU(Unit.Cm(3.3808197975158691), Unit.Cm(1.2899999618530273));
			textBox72.Style.BorderStyle.Default = BorderType.Solid;
			textBox72.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox72.Style.Font.Name = "맑은 고딕";
			textBox72.Style.Font.Size = Unit.Point(10.0);
			textBox72.Style.VerticalAlign = VerticalAlign.Middle;
			textBox72.StyleName = "";
			textBox72.Value = "디왁싱";
			textBox82.Name = "textBox82";
			textBox82.Size = new SizeU(Unit.Cm(3.3808197975158691), Unit.Cm(1.2899999618530273));
			textBox82.Style.BorderStyle.Default = BorderType.Solid;
			textBox82.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox82.Style.Font.Name = "맑은 고딕";
			textBox82.Style.Font.Size = Unit.Point(10.0);
			textBox82.Style.VerticalAlign = VerticalAlign.Middle;
			textBox82.StyleName = "";
			textBox82.Value = "소성";
			textBox93.Name = "textBox93";
			textBox93.Size = new SizeU(Unit.Cm(3.3808197975158691), Unit.Cm(1.2899999618530273));
			textBox93.Style.BorderStyle.Default = BorderType.Solid;
			textBox93.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox93.Style.Font.Name = "맑은 고딕";
			textBox93.Style.Font.Size = Unit.Point(10.0);
			textBox93.Style.VerticalAlign = VerticalAlign.Middle;
			textBox93.StyleName = "";
			textBox93.Value = "주조";
			textBox109.Name = "textBox109";
			textBox109.Size = new SizeU(Unit.Cm(3.3808197975158691), Unit.Cm(1.2899999618530273));
			textBox109.Style.BorderStyle.Default = BorderType.Solid;
			textBox109.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox109.Style.Font.Name = "맑은 고딕";
			textBox109.Style.Font.Size = Unit.Point(10.0);
			textBox109.Style.VerticalAlign = VerticalAlign.Middle;
			textBox109.StyleName = "";
			textBox109.Value = "성분분석";
			textBox119.Name = "textBox119";
			textBox119.Size = new SizeU(Unit.Cm(3.3808197975158691), Unit.Cm(1.2899998426437378));
			textBox119.Style.BorderStyle.Default = BorderType.Solid;
			textBox119.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox119.Style.Font.Name = "맑은 고딕";
			textBox119.Style.Font.Size = Unit.Point(10.0);
			textBox119.Style.VerticalAlign = VerticalAlign.Middle;
			textBox119.StyleName = "";
			textBox119.Value = "탈사";
			textBox129.Name = "textBox129";
			textBox129.Size = new SizeU(Unit.Cm(3.3808197975158691), Unit.Cm(1.2899999618530273));
			textBox129.Style.BorderStyle.Default = BorderType.Solid;
			textBox129.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox129.Style.Font.Name = "맑은 고딕";
			textBox129.Style.Font.Size = Unit.Point(10.0);
			textBox129.Style.VerticalAlign = VerticalAlign.Middle;
			textBox129.StyleName = "";
			textBox129.Value = "절단";
			textBox139.Name = "textBox139";
			textBox139.Size = new SizeU(Unit.Cm(3.3808197975158691), Unit.Cm(1.2899999618530273));
			textBox139.Style.BorderStyle.Default = BorderType.Solid;
			textBox139.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox139.Style.Font.Name = "맑은 고딕";
			textBox139.Style.Font.Size = Unit.Point(10.0);
			textBox139.Style.VerticalAlign = VerticalAlign.Middle;
			textBox139.StyleName = "";
			textBox139.Value = "에이프론쇼트";
			textBox149.Name = "textBox149";
			textBox149.Size = new SizeU(Unit.Cm(3.3808197975158691), Unit.Cm(1.2899998426437378));
			textBox149.Style.BorderStyle.Default = BorderType.Solid;
			textBox149.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox149.Style.Font.Name = "맑은 고딕";
			textBox149.Style.Font.Size = Unit.Point(10.0);
			textBox149.Style.VerticalAlign = VerticalAlign.Middle;
			textBox149.StyleName = "";
			textBox149.Value = "외관검사";
			textBox159.Name = "textBox159";
			textBox159.Size = new SizeU(Unit.Cm(3.3808197975158691), Unit.Cm(1.2899999618530273));
			textBox159.Style.BorderStyle.Default = BorderType.Solid;
			textBox159.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox159.Style.Font.Name = "맑은 고딕";
			textBox159.Style.Font.Size = Unit.Point(10.0);
			textBox159.Style.VerticalAlign = VerticalAlign.Middle;
			textBox159.StyleName = "";
			textBox159.Value = "게이트연마";
			textBox169.Name = "textBox169";
			textBox169.Size = new SizeU(Unit.Cm(3.3808197975158691), Unit.Cm(1.2899999618530273));
			textBox169.Style.BorderStyle.Default = BorderType.Solid;
			textBox169.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox169.Style.Font.Name = "맑은 고딕";
			textBox169.Style.Font.Size = Unit.Point(10.0);
			textBox169.Style.VerticalAlign = VerticalAlign.Middle;
			textBox169.StyleName = "";
			textBox169.Value = "사상";
			textBox179.Name = "textBox179";
			textBox179.Size = new SizeU(Unit.Cm(3.3808197975158691), Unit.Cm(1.2899999618530273));
			textBox179.Style.BorderStyle.Default = BorderType.Solid;
			textBox179.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox179.Style.Font.Name = "맑은 고딕";
			textBox179.Style.Font.Size = Unit.Point(10.0);
			textBox179.Style.VerticalAlign = VerticalAlign.Middle;
			textBox179.StyleName = "";
			textBox179.Value = "자동 샌딩";
			textBox189.Name = "textBox189";
			textBox189.Size = new SizeU(Unit.Cm(3.3808197975158691), Unit.Cm(1.2899999618530273));
			textBox189.Style.BorderStyle.Default = BorderType.Solid;
			textBox189.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox189.Style.Font.Name = "맑은 고딕";
			textBox189.Style.Font.Size = Unit.Point(10.0);
			textBox189.Style.VerticalAlign = VerticalAlign.Middle;
			textBox189.StyleName = "";
			textBox189.Value = "포장 / 출하";
			textBox40.CanGrow = false;
			textBox40.Name = "textBox40";
			textBox40.Size = new SizeU(Unit.Cm(0.87150084972381592), Unit.Cm(1.2899999618530273));
			textBox40.Style.BorderColor.Left = Color.Black;
			textBox40.Style.BorderColor.Right = Color.Black;
			textBox40.Style.BorderStyle.Default = BorderType.Solid;
			textBox40.Style.BorderStyle.Top = BorderType.Solid;
			textBox40.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox40.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox40.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox40.Style.BorderWidth.Right = Unit.Point(0.5);
			textBox40.Style.Font.Name = "맑은 고딕";
			textBox40.Style.Font.Size = Unit.Point(10.0);
			textBox40.Style.TextAlign = HorizontalAlign.Center;
			textBox40.Style.VerticalAlign = VerticalAlign.Middle;
			textBox40.StyleName = "";
			textBox40.Value = "O";
			textBox48.Name = "textBox48";
			textBox48.Size = new SizeU(Unit.Cm(1.8031058311462402), Unit.Cm(1.2899999618530273));
			textBox48.Value = "";
			reportHeaderSection1.Height = Unit.Cm(27.982858657836914);
			reportHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[29]
			{
				textBox88,
				textBox94,
				textBox95,
				textBox99,
				textBox100,
				textBox107,
				textBox108,
				textBox3,
				textBox4,
				textBox7,
				textBox11,
				textBox15,
				textBox16,
				textBox17,
				textBox19,
				textBox24,
				textBox25,
				textBox26,
				textBox27,
				textBox29,
				textBox30,
				textBox31,
				textBox32,
				textBox33,
				barcode,
				textBox13,
				textBox12,
				textBox213,
				DataTable
			});
			reportHeaderSection1.Name = "reportHeaderSection1";
			textBox88.Location = new PointU(Unit.Cm(0.0), Unit.Cm(4.799799919128418));
			textBox88.Name = "textBox88";
			textBox88.Size = new SizeU(Unit.Cm(19.999898910522461), Unit.Cm(0.60000002384185791));
			textBox88.Style.BackgroundColor = Color.White;
			textBox88.Style.BorderStyle.Default = BorderType.Solid;
			textBox88.Style.BorderStyle.Top = BorderType.None;
			textBox88.Style.Font.Bold = true;
			textBox88.Style.Font.Name = "맑은 고딕";
			textBox88.Style.Font.Size = Unit.Point(9.0);
			textBox88.Style.TextAlign = HorizontalAlign.Left;
			textBox88.Style.VerticalAlign = VerticalAlign.Middle;
			textBox88.Value = "*** 전 공정은 해당 MQS에 따라 작업을 실시하시오. ***";
			textBox94.Bindings.Add(new Binding("Value", "=Fields.ITEMNAME"));
			textBox94.Location = new PointU(Unit.Cm(1.7001998424530029), Unit.Cm(2.3935856819152832));
			textBox94.Name = "textBox94";
			textBox94.Size = new SizeU(Unit.Cm(5.0), Unit.Cm(0.800000011920929));
			textBox94.Style.BackgroundColor = Color.White;
			textBox94.Style.BorderStyle.Default = BorderType.Solid;
			textBox94.Style.BorderStyle.Right = BorderType.None;
			textBox94.Style.BorderStyle.Top = BorderType.None;
			textBox94.Style.BorderWidth.Bottom = Unit.Point(1.0);
			textBox94.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox94.Style.Font.Bold = true;
			textBox94.Style.Font.Name = "맑은 고딕";
			textBox94.Style.Font.Size = Unit.Point(10.0);
			textBox94.Style.TextAlign = HorizontalAlign.Center;
			textBox94.Style.VerticalAlign = VerticalAlign.Middle;
			textBox94.Value = "";
			textBox95.Location = new PointU(Unit.Cm(0.0), Unit.Cm(2.4000000953674316));
			textBox95.Name = "textBox95";
			textBox95.Size = new SizeU(Unit.Cm(1.7000000476837158), Unit.Cm(0.800000011920929));
			textBox95.Style.BackgroundColor = Color.SteelBlue;
			textBox95.Style.BorderStyle.Default = BorderType.Solid;
			textBox95.Style.BorderStyle.Right = BorderType.None;
			textBox95.Style.BorderStyle.Top = BorderType.None;
			textBox95.Style.BorderWidth.Bottom = Unit.Point(1.0);
			textBox95.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox95.Style.Color = Color.White;
			textBox95.Style.Font.Bold = false;
			textBox95.Style.Font.Name = "맑은 고딕";
			textBox95.Style.Font.Size = Unit.Point(10.0);
			textBox95.Style.TextAlign = HorizontalAlign.Center;
			textBox95.Style.VerticalAlign = VerticalAlign.Middle;
			textBox95.Value = "품    명";
			textBox99.Bindings.Add(new Binding("Value", "=Fields.ORDERQTYINFO"));
			textBox99.Location = new PointU(Unit.Cm(1.7001998424530029), Unit.Cm(3.9995994567871094));
			textBox99.Name = "textBox99";
			textBox99.Size = new SizeU(Unit.Cm(5.0), Unit.Cm(0.800000011920929));
			textBox99.Style.BackgroundColor = Color.White;
			textBox99.Style.BorderStyle.Default = BorderType.Solid;
			textBox99.Style.BorderStyle.Right = BorderType.None;
			textBox99.Style.BorderStyle.Top = BorderType.None;
			textBox99.Style.BorderWidth.Bottom = Unit.Point(1.0);
			textBox99.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox99.Style.Font.Bold = false;
			textBox99.Style.Font.Name = "맑은 고딕";
			textBox99.Style.Font.Size = Unit.Point(10.0);
			textBox99.Style.TextAlign = HorizontalAlign.Center;
			textBox99.Style.VerticalAlign = VerticalAlign.Middle;
			textBox99.Value = "";
			textBox100.Location = new PointU(Unit.Cm(0.0), Unit.Cm(4.0));
			textBox100.Name = "textBox100";
			textBox100.Size = new SizeU(Unit.Cm(1.7000000476837158), Unit.Cm(0.800000011920929));
			textBox100.Style.BackgroundColor = Color.SteelBlue;
			textBox100.Style.BorderStyle.Default = BorderType.Solid;
			textBox100.Style.BorderStyle.Right = BorderType.None;
			textBox100.Style.BorderStyle.Top = BorderType.None;
			textBox100.Style.BorderWidth.Bottom = Unit.Point(1.0);
			textBox100.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox100.Style.Color = Color.White;
			textBox100.Style.Font.Bold = false;
			textBox100.Style.Font.Name = "맑은 고딕";
			textBox100.Style.Font.Size = Unit.Point(10.0);
			textBox100.Style.TextAlign = HorizontalAlign.Center;
			textBox100.Style.VerticalAlign = VerticalAlign.Middle;
			textBox100.Value = "작업수량";
			textBox107.Location = new PointU(Unit.Cm(0.0), Unit.Cm(3.2002003192901611));
			textBox107.Name = "textBox107";
			textBox107.Size = new SizeU(Unit.Cm(1.7000000476837158), Unit.Cm(0.800000011920929));
			textBox107.Style.BackgroundColor = Color.SteelBlue;
			textBox107.Style.BorderStyle.Default = BorderType.Solid;
			textBox107.Style.BorderStyle.Right = BorderType.None;
			textBox107.Style.BorderStyle.Top = BorderType.None;
			textBox107.Style.BorderWidth.Bottom = Unit.Point(1.0);
			textBox107.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox107.Style.Color = Color.White;
			textBox107.Style.Font.Bold = false;
			textBox107.Style.Font.Name = "맑은 고딕";
			textBox107.Style.Font.Size = Unit.Point(10.0);
			textBox107.Style.TextAlign = HorizontalAlign.Center;
			textBox107.Style.VerticalAlign = VerticalAlign.Middle;
			textBox107.Value = "재    질";
			textBox108.Bindings.Add(new Binding("Value", "=Fields.MATERIALGRADE"));
			textBox108.Location = new PointU(Unit.Cm(1.7001998424530029), Unit.Cm(3.19939923286438));
			textBox108.Name = "textBox108";
			textBox108.Size = new SizeU(Unit.Cm(5.0), Unit.Cm(0.800000011920929));
			textBox108.Style.BackgroundColor = Color.White;
			textBox108.Style.BorderStyle.Default = BorderType.Solid;
			textBox108.Style.BorderStyle.Right = BorderType.None;
			textBox108.Style.BorderStyle.Top = BorderType.None;
			textBox108.Style.BorderWidth.Bottom = Unit.Point(1.0);
			textBox108.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox108.Style.Font.Bold = true;
			textBox108.Style.Font.Name = "맑은 고딕";
			textBox108.Style.Font.Size = Unit.Point(10.0);
			textBox108.Style.TextAlign = HorizontalAlign.Center;
			textBox108.Style.VerticalAlign = VerticalAlign.Middle;
			textBox108.Value = "";
			textBox3.Location = new PointU(Unit.Cm(0.0), Unit.Cm(0.800000011920929));
			textBox3.Name = "textBox3";
			textBox3.Size = new SizeU(Unit.Cm(10.099798202514648), Unit.Cm(1.5933851003646851));
			textBox3.Style.BackgroundColor = Color.SteelBlue;
			textBox3.Style.BorderStyle.Default = BorderType.Solid;
			textBox3.Style.BorderWidth.Bottom = Unit.Point(1.0);
			textBox3.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox3.Style.Color = Color.White;
			textBox3.Style.Font.Bold = true;
			textBox3.Style.Font.Name = "맑은 고딕";
			textBox3.Style.Font.Size = Unit.Point(18.0);
			textBox3.Style.Font.Underline = true;
			textBox3.Style.TextAlign = HorizontalAlign.Center;
			textBox3.Style.VerticalAlign = VerticalAlign.Middle;
			textBox3.Value = "ROUTINE SHEET";
			textBox4.Location = new PointU(Unit.Cm(8.400599479675293), Unit.Cm(3.1937859058380127));
			textBox4.Name = "textBox4";
			textBox4.Size = new SizeU(Unit.Cm(3.4993984699249268), Unit.Cm(1.5945868492126465));
			textBox4.Style.BackgroundColor = Color.White;
			textBox4.Style.BorderStyle.Default = BorderType.Solid;
			textBox4.Style.BorderStyle.Right = BorderType.None;
			textBox4.Style.BorderStyle.Top = BorderType.None;
			textBox4.Style.BorderWidth.Bottom = Unit.Point(1.0);
			textBox4.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox4.Style.Font.Bold = false;
			textBox4.Style.Font.Name = "맑은 고딕";
			textBox4.Style.Font.Size = Unit.Point(10.0);
			textBox4.Style.TextAlign = HorizontalAlign.Center;
			textBox4.Style.VerticalAlign = VerticalAlign.Middle;
			textBox4.Value = "";
			textBox7.Location = new PointU(Unit.Cm(6.7003998756408691), Unit.Cm(3.19939923286438));
			textBox7.Name = "textBox7";
			textBox7.Size = new SizeU(Unit.Cm(1.7000000476837158), Unit.Cm(1.5945868492126465));
			textBox7.Style.BackgroundColor = Color.SteelBlue;
			textBox7.Style.BorderStyle.Default = BorderType.Solid;
			textBox7.Style.BorderStyle.Right = BorderType.None;
			textBox7.Style.BorderStyle.Top = BorderType.None;
			textBox7.Style.BorderWidth.Bottom = Unit.Point(1.0);
			textBox7.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox7.Style.Color = Color.White;
			textBox7.Style.Font.Bold = false;
			textBox7.Style.Font.Name = "맑은 고딕";
			textBox7.Style.Font.Size = Unit.Point(10.0);
			textBox7.Style.TextAlign = HorizontalAlign.Center;
			textBox7.Style.VerticalAlign = VerticalAlign.Middle;
			textBox7.Value = "비 고";
			textBox11.Location = new PointU(Unit.Cm(6.7003998756408691), Unit.Cm(2.3935856819152832));
			textBox11.Name = "textBox11";
			textBox11.Size = new SizeU(Unit.Cm(1.7000000476837158), Unit.Cm(0.800000011920929));
			textBox11.Style.BackgroundColor = Color.SteelBlue;
			textBox11.Style.BorderStyle.Default = BorderType.Solid;
			textBox11.Style.BorderStyle.Right = BorderType.None;
			textBox11.Style.BorderStyle.Top = BorderType.None;
			textBox11.Style.BorderWidth.Bottom = Unit.Point(1.0);
			textBox11.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox11.Style.Color = Color.White;
			textBox11.Style.Font.Bold = false;
			textBox11.Style.Font.Name = "맑은 고딕";
			textBox11.Style.Font.Size = Unit.Point(10.0);
			textBox11.Style.TextAlign = HorizontalAlign.Center;
			textBox11.Style.VerticalAlign = VerticalAlign.Middle;
			textBox11.Value = "금형 번호";
			textBox15.Location = new PointU(Unit.Cm(10.099998474121094), Unit.Cm(0.800000011920929));
			textBox15.Name = "textBox15";
			textBox15.Size = new SizeU(Unit.Cm(1.7999999523162842), Unit.Cm(1.593384861946106));
			textBox15.Style.BackgroundColor = Color.SteelBlue;
			textBox15.Style.BorderStyle.Default = BorderType.Solid;
			textBox15.Style.BorderStyle.Left = BorderType.None;
			textBox15.Style.BorderStyle.Right = BorderType.None;
			textBox15.Style.BorderStyle.Top = BorderType.Solid;
			textBox15.Style.BorderWidth.Bottom = Unit.Point(1.0);
			textBox15.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox15.Style.Color = Color.White;
			textBox15.Style.Font.Bold = false;
			textBox15.Style.Font.Name = "맑은 고딕";
			textBox15.Style.Font.Size = Unit.Point(10.0);
			textBox15.Style.TextAlign = HorizontalAlign.Center;
			textBox15.Style.VerticalAlign = VerticalAlign.Middle;
			textBox15.Value = "작업지시\r\n번호";
			textBox16.Location = new PointU(Unit.Cm(13.700398445129395), Unit.Cm(2.3935856819152832));
			textBox16.Name = "textBox16";
			textBox16.Size = new SizeU(Unit.Cm(2.25), Unit.Cm(0.800000011920929));
			textBox16.Style.BackgroundColor = Color.White;
			textBox16.Style.BorderStyle.Default = BorderType.Solid;
			textBox16.Style.BorderStyle.Right = BorderType.None;
			textBox16.Style.BorderStyle.Top = BorderType.None;
			textBox16.Style.BorderWidth.Bottom = Unit.Point(1.0);
			textBox16.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox16.Style.Font.Bold = false;
			textBox16.Style.Font.Name = "맑은 고딕";
			textBox16.Style.Font.Size = Unit.Point(7.0);
			textBox16.Style.TextAlign = HorizontalAlign.Center;
			textBox16.Style.VerticalAlign = VerticalAlign.Middle;
			textBox16.Value = "= CDate(NOW())";
			textBox17.Location = new PointU(Unit.Cm(11.900199890136719), Unit.Cm(2.3935856819152832));
			textBox17.Name = "textBox17";
			textBox17.Size = new SizeU(Unit.Cm(1.7999999523162842), Unit.Cm(0.800000011920929));
			textBox17.Style.BackgroundColor = Color.SteelBlue;
			textBox17.Style.BorderStyle.Default = BorderType.Solid;
			textBox17.Style.BorderStyle.Right = BorderType.None;
			textBox17.Style.BorderStyle.Top = BorderType.None;
			textBox17.Style.BorderWidth.Bottom = Unit.Point(1.0);
			textBox17.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox17.Style.Color = Color.White;
			textBox17.Style.Font.Bold = false;
			textBox17.Style.Font.Name = "맑은 고딕";
			textBox17.Style.Font.Size = Unit.Point(10.0);
			textBox17.Style.TextAlign = HorizontalAlign.Center;
			textBox17.Style.VerticalAlign = VerticalAlign.Middle;
			textBox17.Value = "발행일자";
			textBox19.Bindings.Add(new Binding("Value", "=Fields.CUSTINFO"));
			textBox19.Location = new PointU(Unit.Cm(13.700398445129395), Unit.Cm(3.9939861297607422));
			textBox19.Name = "textBox19";
			textBox19.Size = new SizeU(Unit.Cm(2.25), Unit.Cm(0.800000011920929));
			textBox19.Style.BackgroundColor = Color.White;
			textBox19.Style.BorderStyle.Default = BorderType.Solid;
			textBox19.Style.BorderStyle.Right = BorderType.None;
			textBox19.Style.BorderStyle.Top = BorderType.None;
			textBox19.Style.BorderWidth.Bottom = Unit.Point(1.0);
			textBox19.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox19.Style.Font.Bold = false;
			textBox19.Style.Font.Name = "맑은 고딕";
			textBox19.Style.Font.Size = Unit.Point(10.0);
			textBox19.Style.TextAlign = HorizontalAlign.Center;
			textBox19.Style.VerticalAlign = VerticalAlign.Middle;
			textBox19.Value = "";
			textBox24.Location = new PointU(Unit.Cm(11.900199890136719), Unit.Cm(4.0));
			textBox24.Name = "textBox24";
			textBox24.Size = new SizeU(Unit.Cm(1.7999999523162842), Unit.Cm(0.800000011920929));
			textBox24.Style.BackgroundColor = Color.SteelBlue;
			textBox24.Style.BorderStyle.Default = BorderType.Solid;
			textBox24.Style.BorderStyle.Right = BorderType.None;
			textBox24.Style.BorderStyle.Top = BorderType.None;
			textBox24.Style.BorderWidth.Bottom = Unit.Point(1.0);
			textBox24.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox24.Style.Color = Color.White;
			textBox24.Style.Font.Bold = false;
			textBox24.Style.Font.Name = "맑은 고딕";
			textBox24.Style.Font.Size = Unit.Point(10.0);
			textBox24.Style.TextAlign = HorizontalAlign.Center;
			textBox24.Style.VerticalAlign = VerticalAlign.Middle;
			textBox24.Value = "고 객 사";
			textBox25.Location = new PointU(Unit.Cm(11.900199890136719), Unit.Cm(3.1937859058380127));
			textBox25.Name = "textBox25";
			textBox25.Size = new SizeU(Unit.Cm(1.7999999523162842), Unit.Cm(0.800000011920929));
			textBox25.Style.BackgroundColor = Color.SteelBlue;
			textBox25.Style.BorderStyle.Default = BorderType.Solid;
			textBox25.Style.BorderStyle.Right = BorderType.None;
			textBox25.Style.BorderStyle.Top = BorderType.None;
			textBox25.Style.BorderWidth.Bottom = Unit.Point(1.0);
			textBox25.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox25.Style.Color = Color.White;
			textBox25.Style.Font.Bold = false;
			textBox25.Style.Font.Name = "맑은 고딕";
			textBox25.Style.Font.Size = Unit.Point(10.0);
			textBox25.Style.TextAlign = HorizontalAlign.Center;
			textBox25.Style.VerticalAlign = VerticalAlign.Middle;
			textBox25.Value = "목     적";
			textBox26.Location = new PointU(Unit.Cm(13.700400352478027), Unit.Cm(3.1937859058380127));
			textBox26.Name = "textBox26";
			textBox26.Size = new SizeU(Unit.Cm(2.25), Unit.Cm(0.800000011920929));
			textBox26.Style.BackgroundColor = Color.White;
			textBox26.Style.BorderStyle.Default = BorderType.Solid;
			textBox26.Style.BorderStyle.Right = BorderType.None;
			textBox26.Style.BorderStyle.Top = BorderType.None;
			textBox26.Style.BorderWidth.Bottom = Unit.Point(1.0);
			textBox26.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox26.Style.Font.Bold = false;
			textBox26.Style.Font.Name = "맑은 고딕";
			textBox26.Style.Font.Size = Unit.Point(10.0);
			textBox26.Style.TextAlign = HorizontalAlign.Center;
			textBox26.Style.VerticalAlign = VerticalAlign.Middle;
			textBox26.Value = "";
			textBox27.Location = new PointU(Unit.Cm(17.750801086425781), Unit.Cm(3.1937859058380127));
			textBox27.Name = "textBox27";
			textBox27.Size = new SizeU(Unit.Cm(2.249199390411377), Unit.Cm(0.79999983310699463));
			textBox27.Style.BackgroundColor = Color.White;
			textBox27.Style.BorderStyle.Default = BorderType.Solid;
			textBox27.Style.BorderStyle.Right = BorderType.Solid;
			textBox27.Style.BorderStyle.Top = BorderType.None;
			textBox27.Style.BorderWidth.Bottom = Unit.Point(1.0);
			textBox27.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox27.Style.Font.Bold = false;
			textBox27.Style.Font.Name = "맑은 고딕";
			textBox27.Style.Font.Size = Unit.Point(10.0);
			textBox27.Style.TextAlign = HorizontalAlign.Center;
			textBox27.Style.VerticalAlign = VerticalAlign.Middle;
			textBox27.Value = "";
			textBox29.Location = new PointU(Unit.Cm(15.950600624084473), Unit.Cm(3.1937859058380127));
			textBox29.Name = "textBox29";
			textBox29.Size = new SizeU(Unit.Cm(1.7999999523162842), Unit.Cm(0.800000011920929));
			textBox29.Style.BackgroundColor = Color.SteelBlue;
			textBox29.Style.BorderStyle.Default = BorderType.Solid;
			textBox29.Style.BorderStyle.Right = BorderType.None;
			textBox29.Style.BorderStyle.Top = BorderType.None;
			textBox29.Style.BorderWidth.Bottom = Unit.Point(1.0);
			textBox29.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox29.Style.Color = Color.White;
			textBox29.Style.Font.Bold = false;
			textBox29.Style.Font.Name = "맑은 고딕";
			textBox29.Style.Font.Size = Unit.Point(10.0);
			textBox29.Style.TextAlign = HorizontalAlign.Center;
			textBox29.Style.VerticalAlign = VerticalAlign.Middle;
			textBox29.Value = "팀     장";
			textBox30.Location = new PointU(Unit.Cm(15.950600624084473), Unit.Cm(3.9939861297607422));
			textBox30.Name = "textBox30";
			textBox30.Size = new SizeU(Unit.Cm(1.7999999523162842), Unit.Cm(0.800000011920929));
			textBox30.Style.BackgroundColor = Color.SteelBlue;
			textBox30.Style.BorderStyle.Default = BorderType.Solid;
			textBox30.Style.BorderStyle.Right = BorderType.None;
			textBox30.Style.BorderStyle.Top = BorderType.None;
			textBox30.Style.BorderWidth.Bottom = Unit.Point(1.0);
			textBox30.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox30.Style.Color = Color.White;
			textBox30.Style.Font.Bold = false;
			textBox30.Style.Font.Name = "맑은 고딕";
			textBox30.Style.Font.Size = Unit.Point(10.0);
			textBox30.Style.TextAlign = HorizontalAlign.Center;
			textBox30.Style.VerticalAlign = VerticalAlign.Middle;
			textBox30.Value = "수 신 처";
			textBox31.Location = new PointU(Unit.Cm(17.750801086425781), Unit.Cm(3.9939861297607422));
			textBox31.Name = "textBox31";
			textBox31.Size = new SizeU(Unit.Cm(2.249199390411377), Unit.Cm(0.800000011920929));
			textBox31.Style.BackgroundColor = Color.White;
			textBox31.Style.BorderStyle.Default = BorderType.Solid;
			textBox31.Style.BorderStyle.Right = BorderType.Solid;
			textBox31.Style.BorderStyle.Top = BorderType.None;
			textBox31.Style.BorderWidth.Bottom = Unit.Point(1.0);
			textBox31.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox31.Style.Font.Bold = false;
			textBox31.Style.Font.Name = "맑은 고딕";
			textBox31.Style.Font.Size = Unit.Point(10.0);
			textBox31.Style.TextAlign = HorizontalAlign.Center;
			textBox31.Style.VerticalAlign = VerticalAlign.Middle;
			textBox31.Value = "";
			textBox32.Location = new PointU(Unit.Cm(15.950600624084473), Unit.Cm(2.3935856819152832));
			textBox32.Name = "textBox32";
			textBox32.Size = new SizeU(Unit.Cm(1.7999999523162842), Unit.Cm(0.800000011920929));
			textBox32.Style.BackgroundColor = Color.SteelBlue;
			textBox32.Style.BorderStyle.Default = BorderType.Solid;
			textBox32.Style.BorderStyle.Right = BorderType.None;
			textBox32.Style.BorderStyle.Top = BorderType.None;
			textBox32.Style.BorderWidth.Bottom = Unit.Point(1.0);
			textBox32.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox32.Style.Color = Color.White;
			textBox32.Style.Font.Bold = false;
			textBox32.Style.Font.Name = "맑은 고딕";
			textBox32.Style.Font.Size = Unit.Point(10.0);
			textBox32.Style.TextAlign = HorizontalAlign.Center;
			textBox32.Style.VerticalAlign = VerticalAlign.Middle;
			textBox32.Value = "담 당 자";
			textBox33.Bindings.Add(new Binding("Value", "=Fields.USERINFO"));
			textBox33.Location = new PointU(Unit.Cm(17.750801086425781), Unit.Cm(2.3902783393859863));
			textBox33.Name = "textBox33";
			textBox33.Size = new SizeU(Unit.Cm(2.2492003440856934), Unit.Cm(0.80330723524093628));
			textBox33.Style.BackgroundColor = Color.White;
			textBox33.Style.BorderStyle.Default = BorderType.Solid;
			textBox33.Style.BorderStyle.Right = BorderType.Solid;
			textBox33.Style.BorderStyle.Top = BorderType.None;
			textBox33.Style.BorderWidth.Bottom = Unit.Point(1.0);
			textBox33.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox33.Style.Font.Bold = false;
			textBox33.Style.Font.Name = "맑은 고딕";
			textBox33.Style.Font.Size = Unit.Point(10.0);
			textBox33.Style.TextAlign = HorizontalAlign.Center;
			textBox33.Style.VerticalAlign = VerticalAlign.Middle;
			textBox33.Value = "";
			barcode.BarAlign = HorizontalAlign.Center;
			barcode.Bindings.Add(new Binding("Value", "=Fields.ORDERNO"));
			barcode.Location = new PointU(Unit.Cm(11.900198936462402), Unit.Cm(0.800000011920929));
			barcode.Name = "barcode";
			barcode.ShowText = false;
			barcode.Size = new SizeU(Unit.Cm(8.1000003814697266), Unit.Cm(1.190000057220459));
			barcode.Style.BackgroundColor = Color.White;
			barcode.Style.BorderStyle.Bottom = BorderType.None;
			barcode.Style.BorderStyle.Default = BorderType.Solid;
			barcode.Style.BorderWidth.Default = Unit.Point(0.5);
			barcode.Style.Color = Color.Black;
			barcode.Style.Font.Name = "맑은 고딕";
			barcode.Style.Padding.Bottom = Unit.Cm(0.0);
			barcode.Style.Padding.Left = Unit.Cm(0.05000000074505806);
			barcode.Style.Padding.Right = Unit.Cm(0.05000000074505806);
			barcode.Style.Padding.Top = Unit.Cm(0.10000000149011612);
			barcode.Style.TextAlign = HorizontalAlign.Center;
			barcode.Style.VerticalAlign = VerticalAlign.Bottom;
			barcode.Value = "";
			textBox13.Bindings.Add(new Binding("Value", "=Fields.ORDERNO"));
			textBox13.Location = new PointU(Unit.Cm(11.899999618530273), Unit.Cm(1.9900000095367432));
			textBox13.Name = "textBox13";
			textBox13.Size = new SizeU(Unit.Cm(8.1000003814697266), Unit.Cm(0.40000000596046448));
			textBox13.Style.BackgroundColor = Color.White;
			textBox13.Style.BorderStyle.Default = BorderType.Solid;
			textBox13.Style.BorderStyle.Right = BorderType.Solid;
			textBox13.Style.BorderStyle.Top = BorderType.None;
			textBox13.Style.BorderWidth.Bottom = Unit.Point(1.0);
			textBox13.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox13.Style.Font.Bold = true;
			textBox13.Style.Font.Name = "맑은 고딕";
			textBox13.Style.Font.Size = Unit.Point(9.0);
			textBox13.Style.TextAlign = HorizontalAlign.Center;
			textBox13.Style.VerticalAlign = VerticalAlign.Top;
			textBox13.Value = "";
			textBox12.Bindings.Add(new Binding("Value", "=Fields.MOLDCODE"));
			textBox12.Location = new PointU(Unit.Cm(8.400599479675293), Unit.Cm(2.4000000953674316));
			textBox12.Name = "textBox12";
			textBox12.Size = new SizeU(Unit.Cm(3.4993987083435059), Unit.Cm(0.79358565807342529));
			textBox12.Style.BackgroundColor = Color.White;
			textBox12.Style.BorderStyle.Default = BorderType.Solid;
			textBox12.Style.BorderStyle.Right = BorderType.None;
			textBox12.Style.BorderStyle.Top = BorderType.None;
			textBox12.Style.BorderWidth.Bottom = Unit.Point(1.0);
			textBox12.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox12.Style.Font.Bold = true;
			textBox12.Style.Font.Name = "맑은 고딕";
			textBox12.Style.Font.Size = Unit.Point(10.0);
			textBox12.Style.TextAlign = HorizontalAlign.Center;
			textBox12.Style.VerticalAlign = VerticalAlign.Middle;
			textBox12.Value = "";
			textBox213.Bindings.Add(new Binding("Value", "=Fields.REMARK"));
			textBox213.Location = new PointU(Unit.Cm(0.0), Unit.Cm(0.0));
			textBox213.Name = "textBox213";
			textBox213.Size = new SizeU(Unit.Cm(19.999898910522461), Unit.Cm(0.79980009794235229));
			textBox213.Style.BackgroundColor = Color.White;
			textBox213.Style.BorderStyle.Default = BorderType.Solid;
			textBox213.Style.BorderStyle.Right = BorderType.None;
			textBox213.Style.BorderStyle.Top = BorderType.None;
			textBox213.Style.BorderWidth.Bottom = Unit.Point(1.0);
			textBox213.Style.BorderWidth.Left = Unit.Point(1.0);
			textBox213.Style.Font.Bold = false;
			textBox213.Style.Font.Name = "맑은 고딕";
			textBox213.Style.Font.Size = Unit.Point(9.0);
			textBox213.Style.TextAlign = HorizontalAlign.Left;
			textBox213.Style.VerticalAlign = VerticalAlign.Middle;
			textBox213.Value = "";
			table1.Body.Columns.Add(new TableBodyColumn(Unit.Cm(0.079021967947483063)));
			table1.Body.Columns.Add(new TableBodyColumn(Unit.Cm(0.079021967947483063)));
			table1.Body.Columns.Add(new TableBodyColumn(Unit.Cm(0.22577685117721558)));
			table1.Body.Columns.Add(new TableBodyColumn(Unit.Cm(0.22577685117721558)));
			table1.Body.Columns.Add(new TableBodyColumn(Unit.Cm(0.0785704180598259)));
			table1.Body.Columns.Add(new TableBodyColumn(Unit.Cm(0.13546620309352875)));
			table1.Body.Columns.Add(new TableBodyColumn(Unit.Cm(0.18062169849872589)));
			table1.Body.Columns.Add(new TableBodyColumn(Unit.Cm(0.16255953907966614)));
			table1.Body.Columns.Add(new TableBodyColumn(Unit.Cm(0.43309098482131958)));
			table1.Body.Columns.Add(new TableBodyColumn(Unit.Cm(0.20319931209087372)));
			table1.Body.Rows.Add(new TableBodyRow(Unit.Cm(0.23428604006767273)));
			table1.Body.Rows.Add(new TableBodyRow(Unit.Cm(0.2342860996723175)));
			table1.Body.Rows.Add(new TableBodyRow(Unit.Cm(0.2342860996723175)));
			table1.Body.Rows.Add(new TableBodyRow(Unit.Cm(0.23428623378276825)));
			table1.Body.SetCellContent(0, 3, textBox8);
			table1.Body.SetCellContent(0, 6, textBox9);
			table1.Body.SetCellContent(0, 0, textBox43);
			table1.Body.SetCellContent(0, 4, textBox53);
			table1.Body.SetCellContent(0, 5, textBox63);
			table1.Body.SetCellContent(0, 7, textBox73);
			table1.Body.SetCellContent(0, 8, textBox83);
			table1.Body.SetCellContent(0, 9, textBox96);
			table1.Body.SetCellContent(0, 1, textBox110, 1, 2);
			table1.Body.SetCellContent(1, 0, textBox120);
			table1.Body.SetCellContent(1, 3, textBox130);
			table1.Body.SetCellContent(1, 5, textBox140);
			table1.Body.SetCellContent(1, 6, textBox150);
			table1.Body.SetCellContent(1, 7, textBox160);
			table1.Body.SetCellContent(1, 8, textBox170);
			table1.Body.SetCellContent(1, 9, textBox180);
			table1.Body.SetCellContent(2, 0, textBox190);
			table1.Body.SetCellContent(2, 3, textBox198);
			table1.Body.SetCellContent(2, 4, textBox199);
			table1.Body.SetCellContent(2, 5, textBox200);
			table1.Body.SetCellContent(2, 6, textBox201);
			table1.Body.SetCellContent(2, 7, textBox202);
			table1.Body.SetCellContent(2, 8, textBox203);
			table1.Body.SetCellContent(2, 9, textBox204);
			table1.Body.SetCellContent(3, 0, textBox205);
			table1.Body.SetCellContent(3, 3, textBox206);
			table1.Body.SetCellContent(3, 4, textBox207);
			table1.Body.SetCellContent(3, 5, textBox208);
			table1.Body.SetCellContent(3, 6, textBox209);
			table1.Body.SetCellContent(3, 7, textBox210);
			table1.Body.SetCellContent(3, 8, textBox211);
			table1.Body.SetCellContent(3, 9, textBox212);
			table1.Body.SetCellContent(1, 1, textBox309, 1, 2);
			table1.Body.SetCellContent(2, 1, textBox310, 1, 2);
			table1.Body.SetCellContent(3, 1, textBox311, 1, 2);
			table1.Body.SetCellContent(1, 4, textBox324);
			tableGroup32.Name = "group2";
			tableGroup31.ChildGroups.Add(tableGroup32);
			tableGroup31.Name = "group1";
			tableGroup31.ReportItem = textBox325;
			tableGroup35.Name = "tableGroup";
			tableGroup36.Name = "group9";
			tableGroup34.ChildGroups.Add(tableGroup35);
			tableGroup34.ChildGroups.Add(tableGroup36);
			tableGroup34.Name = "group17";
			tableGroup34.ReportItem = textBox326;
			tableGroup37.Name = "group10";
			tableGroup37.ReportItem = textBox327;
			tableGroup33.ChildGroups.Add(tableGroup34);
			tableGroup33.ChildGroups.Add(tableGroup37);
			tableGroup33.Name = "group";
			tableGroup33.ReportItem = textBox328;
			tableGroup38.Name = "group3";
			tableGroup38.ReportItem = textBox329;
			tableGroup39.Name = "group5";
			tableGroup39.ReportItem = textBox330;
			tableGroup40.Name = "tableGroup2";
			tableGroup40.ReportItem = textBox331;
			tableGroup41.Name = "group6";
			tableGroup41.ReportItem = textBox332;
			tableGroup42.Name = "group7";
			tableGroup42.ReportItem = textBox333;
			tableGroup43.Name = "group4";
			tableGroup43.ReportItem = textBox334;
			table1.ColumnGroups.Add(tableGroup31);
			table1.ColumnGroups.Add(tableGroup33);
			table1.ColumnGroups.Add(tableGroup38);
			table1.ColumnGroups.Add(tableGroup39);
			table1.ColumnGroups.Add(tableGroup40);
			table1.ColumnGroups.Add(tableGroup41);
			table1.ColumnGroups.Add(tableGroup42);
			table1.ColumnGroups.Add(tableGroup43);
			table1.Items.AddRange(new Telerik.Reporting.ReportItemBase[46]
			{
				textBox8,
				textBox9,
				textBox43,
				textBox53,
				textBox63,
				textBox73,
				textBox83,
				textBox96,
				textBox110,
				textBox120,
				textBox130,
				textBox140,
				textBox150,
				textBox160,
				textBox170,
				textBox180,
				textBox190,
				textBox198,
				textBox199,
				textBox200,
				textBox201,
				textBox202,
				textBox203,
				textBox204,
				textBox205,
				textBox206,
				textBox207,
				textBox208,
				textBox209,
				textBox210,
				textBox211,
				textBox212,
				textBox309,
				textBox310,
				textBox311,
				textBox324,
				textBox325,
				textBox328,
				textBox326,
				textBox327,
				textBox329,
				textBox330,
				textBox331,
				textBox332,
				textBox333,
				textBox334
			});
			table1.Location = new PointU(Unit.Cm(0.0), Unit.Cm(0.0));
			table1.Name = "table1";
			tableGroup45.Name = "group8";
			tableGroup46.Name = "group11";
			tableGroup47.Name = "group12";
			tableGroup48.Name = "group13";
			tableGroup44.ChildGroups.Add(tableGroup45);
			tableGroup44.ChildGroups.Add(tableGroup46);
			tableGroup44.ChildGroups.Add(tableGroup47);
			tableGroup44.ChildGroups.Add(tableGroup48);
			tableGroup44.Groupings.Add(new Grouping(null));
			tableGroup44.Name = "detailTableGroup";
			table1.RowGroups.Add(tableGroup44);
			table1.Size = new SizeU(Unit.Cm(1.8031057119369507), Unit.Cm(1.290000319480896));
			table1.Style.BackgroundColor = Color.White;
			table1.Style.BorderStyle.Bottom = BorderType.Solid;
			table1.Style.BorderStyle.Default = BorderType.Solid;
			table1.Style.BorderWidth.Default = Unit.Point(0.5);
			table1.Style.Font.Name = "맑은 고딕";
			table1.Style.Font.Size = Unit.Point(10.0);
			table1.Style.TextAlign = HorizontalAlign.Center;
			table1.Style.VerticalAlign = VerticalAlign.Middle;
			table1.StyleName = "";
			textBox8.CanGrow = false;
			textBox8.Name = "textBox8";
			textBox8.Size = new SizeU(Unit.Cm(0.22577685117721558), Unit.Cm(0.23428604006767273));
			textBox8.Style.BorderColor.Left = Color.Black;
			textBox8.Style.BorderColor.Right = Color.Black;
			textBox8.Style.BorderStyle.Default = BorderType.Solid;
			textBox8.Style.BorderStyle.Top = BorderType.Solid;
			textBox8.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox8.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox8.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox8.Style.BorderWidth.Right = Unit.Point(0.5);
			textBox8.Style.Font.Name = "맑은 고딕";
			textBox8.Style.Font.Size = Unit.Point(10.0);
			textBox8.Style.TextAlign = HorizontalAlign.Left;
			textBox8.Style.VerticalAlign = VerticalAlign.Middle;
			textBox9.CanGrow = false;
			textBox9.Name = "textBox9";
			textBox9.Size = new SizeU(Unit.Cm(0.18062169849872589), Unit.Cm(0.23428604006767273));
			textBox9.Style.BackgroundColor = Color.White;
			textBox9.Style.BorderColor.Left = Color.Black;
			textBox9.Style.BorderColor.Right = Color.Black;
			textBox9.Style.BorderStyle.Default = BorderType.Solid;
			textBox9.Style.BorderStyle.Top = BorderType.Solid;
			textBox9.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox9.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox9.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox9.Style.BorderWidth.Right = Unit.Point(0.5);
			textBox9.Style.Font.Name = "맑은 고딕";
			textBox9.Style.Font.Size = Unit.Point(10.0);
			textBox9.Style.TextAlign = HorizontalAlign.Center;
			textBox9.Style.VerticalAlign = VerticalAlign.Middle;
			textBox43.Bindings.Add(new Binding("Value", "=Fields.TITLE"));
			textBox43.Name = "textBox43";
			textBox43.Size = new SizeU(Unit.Cm(0.079021960496902466), Unit.Cm(0.23428604006767273));
			textBox43.Style.BorderColor.Left = Color.Black;
			textBox43.Style.BorderColor.Right = Color.Black;
			textBox43.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox43.Style.BorderStyle.Default = BorderType.Solid;
			textBox43.Style.BorderStyle.Top = BorderType.Solid;
			textBox43.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox43.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox43.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox43.Style.BorderWidth.Right = Unit.Point(0.5);
			textBox43.Style.Font.Name = "맑은 고딕";
			textBox43.Style.Font.Size = Unit.Point(10.0);
			textBox43.Style.TextAlign = HorizontalAlign.Center;
			textBox43.Style.VerticalAlign = VerticalAlign.Middle;
			textBox43.StyleName = "";
			textBox53.CanGrow = false;
			textBox53.Name = "textBox53";
			textBox53.Size = new SizeU(Unit.Cm(0.0785704106092453), Unit.Cm(0.23428604006767273));
			textBox53.Style.BorderColor.Left = Color.Black;
			textBox53.Style.BorderColor.Right = Color.Black;
			textBox53.Style.BorderStyle.Default = BorderType.Solid;
			textBox53.Style.BorderStyle.Top = BorderType.Solid;
			textBox53.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox53.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox53.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox53.Style.BorderWidth.Right = Unit.Point(0.5);
			textBox53.Style.Font.Name = "맑은 고딕";
			textBox53.Style.Font.Size = Unit.Point(10.0);
			textBox53.Style.TextAlign = HorizontalAlign.Center;
			textBox53.Style.VerticalAlign = VerticalAlign.Middle;
			textBox53.StyleName = "";
			textBox63.CanGrow = false;
			textBox63.Name = "textBox63";
			textBox63.Size = new SizeU(Unit.Cm(0.13546620309352875), Unit.Cm(0.23428604006767273));
			textBox63.Style.BorderColor.Left = Color.Black;
			textBox63.Style.BorderColor.Right = Color.Black;
			textBox63.Style.BorderStyle.Default = BorderType.Solid;
			textBox63.Style.BorderStyle.Top = BorderType.Solid;
			textBox63.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox63.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox63.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox63.Style.BorderWidth.Right = Unit.Point(0.5);
			textBox63.Style.Font.Name = "맑은 고딕";
			textBox63.Style.Font.Size = Unit.Point(10.0);
			textBox63.Style.TextAlign = HorizontalAlign.Right;
			textBox63.Style.VerticalAlign = VerticalAlign.Middle;
			textBox63.StyleName = "";
			textBox73.CanGrow = false;
			textBox73.Name = "textBox73";
			textBox73.Size = new SizeU(Unit.Cm(0.16255953907966614), Unit.Cm(0.23428604006767273));
			textBox73.Style.BackgroundColor = Color.White;
			textBox73.Style.BorderColor.Left = Color.Black;
			textBox73.Style.BorderColor.Right = Color.Black;
			textBox73.Style.BorderStyle.Default = BorderType.Solid;
			textBox73.Style.BorderStyle.Top = BorderType.Solid;
			textBox73.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox73.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox73.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox73.Style.BorderWidth.Right = Unit.Point(0.5);
			textBox73.Style.Font.Name = "맑은 고딕";
			textBox73.Style.Font.Size = Unit.Point(10.0);
			textBox73.Style.TextAlign = HorizontalAlign.Center;
			textBox73.Style.VerticalAlign = VerticalAlign.Middle;
			textBox73.StyleName = "";
			textBox83.CanGrow = false;
			textBox83.Name = "textBox83";
			textBox83.Size = new SizeU(Unit.Cm(0.43309098482131958), Unit.Cm(0.23428604006767273));
			textBox83.Style.BackgroundColor = Color.White;
			textBox83.Style.BorderColor.Left = Color.Black;
			textBox83.Style.BorderColor.Right = Color.Black;
			textBox83.Style.BorderStyle.Default = BorderType.Solid;
			textBox83.Style.BorderStyle.Top = BorderType.Solid;
			textBox83.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox83.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox83.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox83.Style.BorderWidth.Right = Unit.Point(0.5);
			textBox83.Style.Font.Name = "맑은 고딕";
			textBox83.Style.Font.Size = Unit.Point(10.0);
			textBox83.Style.TextAlign = HorizontalAlign.Center;
			textBox83.Style.VerticalAlign = VerticalAlign.Middle;
			textBox83.StyleName = "";
			textBox96.Name = "textBox96";
			textBox96.Size = new SizeU(Unit.Cm(0.20319931209087372), Unit.Cm(0.23428604006767273));
			textBox96.Style.BackgroundColor = Color.White;
			textBox96.Style.BorderColor.Left = Color.Black;
			textBox96.Style.BorderColor.Right = Color.Black;
			textBox96.Style.BorderStyle.Default = BorderType.Solid;
			textBox96.Style.BorderStyle.Top = BorderType.Solid;
			textBox96.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox96.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox96.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox96.Style.BorderWidth.Right = Unit.Point(0.5);
			textBox96.Style.Font.Name = "맑은 고딕";
			textBox96.Style.Font.Size = Unit.Point(10.0);
			textBox96.Style.TextAlign = HorizontalAlign.Center;
			textBox96.Style.VerticalAlign = VerticalAlign.Middle;
			textBox96.StyleName = "";
			textBox110.CanGrow = false;
			textBox110.Name = "textBox110";
			textBox110.Size = new SizeU(Unit.Cm(0.30479881167411804), Unit.Cm(0.23428604006767273));
			textBox110.Style.BorderColor.Left = Color.Black;
			textBox110.Style.BorderColor.Right = Color.Black;
			textBox110.Style.BorderStyle.Bottom = BorderType.Solid;
			textBox110.Style.BorderStyle.Default = BorderType.Solid;
			textBox110.Style.BorderStyle.Top = BorderType.Solid;
			textBox110.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox110.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox110.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox110.Style.BorderWidth.Right = Unit.Point(0.5);
			textBox110.Style.Font.Name = "맑은 고딕";
			textBox110.Style.Font.Size = Unit.Point(10.0);
			textBox110.Style.TextAlign = HorizontalAlign.Left;
			textBox110.Style.VerticalAlign = VerticalAlign.Middle;
			textBox120.Name = "textBox120";
			textBox120.Size = new SizeU(Unit.Cm(0.079021960496902466), Unit.Cm(0.2342860996723175));
			textBox120.Style.BorderStyle.Default = BorderType.Solid;
			textBox120.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox120.Style.Font.Name = "맑은 고딕";
			textBox120.Style.Font.Size = Unit.Point(10.0);
			textBox120.Style.TextAlign = HorizontalAlign.Center;
			textBox120.Style.VerticalAlign = VerticalAlign.Middle;
			textBox120.StyleName = "";
			textBox130.Name = "textBox130";
			textBox130.Size = new SizeU(Unit.Cm(0.22577685117721558), Unit.Cm(0.2342860996723175));
			textBox130.Style.BorderStyle.Default = BorderType.Solid;
			textBox130.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox130.Style.Font.Name = "맑은 고딕";
			textBox130.Style.Font.Size = Unit.Point(10.0);
			textBox130.Style.VerticalAlign = VerticalAlign.Middle;
			textBox130.StyleName = "";
			textBox140.Name = "textBox140";
			textBox140.Size = new SizeU(Unit.Cm(0.13546620309352875), Unit.Cm(0.2342860996723175));
			textBox140.Style.BorderStyle.Default = BorderType.Solid;
			textBox140.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox140.Style.Font.Name = "맑은 고딕";
			textBox140.Style.Font.Size = Unit.Point(10.0);
			textBox140.Style.TextAlign = HorizontalAlign.Right;
			textBox140.Style.VerticalAlign = VerticalAlign.Middle;
			textBox140.StyleName = "";
			textBox150.Name = "textBox150";
			textBox150.Size = new SizeU(Unit.Cm(0.18062169849872589), Unit.Cm(0.2342860996723175));
			textBox150.Style.BackgroundColor = Color.White;
			textBox150.Style.BorderStyle.Default = BorderType.Solid;
			textBox150.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox150.Style.Font.Name = "맑은 고딕";
			textBox150.Style.Font.Size = Unit.Point(10.0);
			textBox150.Style.TextAlign = HorizontalAlign.Center;
			textBox150.Style.VerticalAlign = VerticalAlign.Middle;
			textBox150.StyleName = "";
			textBox160.Name = "textBox160";
			textBox160.Size = new SizeU(Unit.Cm(0.16255953907966614), Unit.Cm(0.2342860996723175));
			textBox160.Style.BackgroundColor = Color.White;
			textBox160.Style.BorderStyle.Default = BorderType.Solid;
			textBox160.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox160.Style.Font.Name = "맑은 고딕";
			textBox160.Style.Font.Size = Unit.Point(10.0);
			textBox160.Style.TextAlign = HorizontalAlign.Center;
			textBox160.Style.VerticalAlign = VerticalAlign.Middle;
			textBox160.StyleName = "";
			textBox170.Name = "textBox170";
			textBox170.Size = new SizeU(Unit.Cm(0.43309098482131958), Unit.Cm(0.2342860996723175));
			textBox170.Style.BackgroundColor = Color.White;
			textBox170.Style.BorderStyle.Default = BorderType.Solid;
			textBox170.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox170.Style.Font.Name = "맑은 고딕";
			textBox170.Style.Font.Size = Unit.Point(10.0);
			textBox170.Style.TextAlign = HorizontalAlign.Center;
			textBox170.Style.VerticalAlign = VerticalAlign.Middle;
			textBox170.StyleName = "";
			textBox180.Name = "textBox180";
			textBox180.Size = new SizeU(Unit.Cm(0.20319931209087372), Unit.Cm(0.2342860996723175));
			textBox180.Style.BackgroundColor = Color.White;
			textBox180.Style.BorderStyle.Default = BorderType.Solid;
			textBox180.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox180.Style.Font.Name = "맑은 고딕";
			textBox180.Style.Font.Size = Unit.Point(10.0);
			textBox180.Style.TextAlign = HorizontalAlign.Center;
			textBox180.Style.VerticalAlign = VerticalAlign.Middle;
			textBox180.StyleName = "";
			textBox190.Name = "textBox190";
			textBox190.Size = new SizeU(Unit.Cm(0.079021960496902466), Unit.Cm(0.2342860996723175));
			textBox190.Style.BorderStyle.Default = BorderType.Solid;
			textBox190.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox190.Style.Font.Name = "맑은 고딕";
			textBox190.Style.Font.Size = Unit.Point(10.0);
			textBox190.Style.TextAlign = HorizontalAlign.Center;
			textBox190.Style.VerticalAlign = VerticalAlign.Middle;
			textBox190.StyleName = "";
			textBox198.Name = "textBox198";
			textBox198.Size = new SizeU(Unit.Cm(0.22577685117721558), Unit.Cm(0.2342860996723175));
			textBox198.Style.BorderStyle.Default = BorderType.Solid;
			textBox198.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox198.Style.Font.Name = "맑은 고딕";
			textBox198.Style.Font.Size = Unit.Point(10.0);
			textBox198.Style.VerticalAlign = VerticalAlign.Middle;
			textBox198.StyleName = "";
			textBox199.Name = "textBox199";
			textBox199.Size = new SizeU(Unit.Cm(0.0785704106092453), Unit.Cm(0.2342860996723175));
			textBox199.Style.BorderStyle.Default = BorderType.Solid;
			textBox199.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox199.Style.Font.Name = "맑은 고딕";
			textBox199.Style.Font.Size = Unit.Point(10.0);
			textBox199.Style.TextAlign = HorizontalAlign.Center;
			textBox199.Style.VerticalAlign = VerticalAlign.Middle;
			textBox199.StyleName = "";
			textBox200.Name = "textBox200";
			textBox200.Size = new SizeU(Unit.Cm(0.13546620309352875), Unit.Cm(0.2342860996723175));
			textBox200.Style.BorderStyle.Default = BorderType.Solid;
			textBox200.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox200.Style.Font.Name = "맑은 고딕";
			textBox200.Style.Font.Size = Unit.Point(10.0);
			textBox200.Style.TextAlign = HorizontalAlign.Right;
			textBox200.Style.VerticalAlign = VerticalAlign.Middle;
			textBox200.StyleName = "";
			textBox201.Name = "textBox201";
			textBox201.Size = new SizeU(Unit.Cm(0.18062169849872589), Unit.Cm(0.2342860996723175));
			textBox201.Style.BackgroundColor = Color.White;
			textBox201.Style.BorderStyle.Default = BorderType.Solid;
			textBox201.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox201.Style.Font.Name = "맑은 고딕";
			textBox201.Style.Font.Size = Unit.Point(10.0);
			textBox201.Style.TextAlign = HorizontalAlign.Center;
			textBox201.Style.VerticalAlign = VerticalAlign.Middle;
			textBox201.StyleName = "";
			textBox202.Name = "textBox202";
			textBox202.Size = new SizeU(Unit.Cm(0.16255953907966614), Unit.Cm(0.2342860996723175));
			textBox202.Style.BackgroundColor = Color.White;
			textBox202.Style.BorderStyle.Default = BorderType.Solid;
			textBox202.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox202.Style.Font.Name = "맑은 고딕";
			textBox202.Style.Font.Size = Unit.Point(10.0);
			textBox202.Style.TextAlign = HorizontalAlign.Center;
			textBox202.Style.VerticalAlign = VerticalAlign.Middle;
			textBox202.StyleName = "";
			textBox203.Name = "textBox203";
			textBox203.Size = new SizeU(Unit.Cm(0.43309098482131958), Unit.Cm(0.2342860996723175));
			textBox203.Style.BackgroundColor = Color.White;
			textBox203.Style.BorderStyle.Default = BorderType.Solid;
			textBox203.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox203.Style.Font.Name = "맑은 고딕";
			textBox203.Style.Font.Size = Unit.Point(10.0);
			textBox203.Style.TextAlign = HorizontalAlign.Center;
			textBox203.Style.VerticalAlign = VerticalAlign.Middle;
			textBox203.StyleName = "";
			textBox204.Name = "textBox204";
			textBox204.Size = new SizeU(Unit.Cm(0.20319931209087372), Unit.Cm(0.2342860996723175));
			textBox204.Style.BackgroundColor = Color.White;
			textBox204.Style.BorderStyle.Default = BorderType.Solid;
			textBox204.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox204.Style.Font.Name = "맑은 고딕";
			textBox204.Style.Font.Size = Unit.Point(10.0);
			textBox204.Style.TextAlign = HorizontalAlign.Center;
			textBox204.Style.VerticalAlign = VerticalAlign.Middle;
			textBox204.StyleName = "";
			textBox205.Name = "textBox205";
			textBox205.Size = new SizeU(Unit.Cm(0.079021960496902466), Unit.Cm(0.23428621888160706));
			textBox205.Style.BorderStyle.Default = BorderType.Solid;
			textBox205.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox205.Style.Font.Name = "맑은 고딕";
			textBox205.Style.Font.Size = Unit.Point(10.0);
			textBox205.Style.TextAlign = HorizontalAlign.Center;
			textBox205.Style.VerticalAlign = VerticalAlign.Middle;
			textBox205.StyleName = "";
			textBox206.Name = "textBox206";
			textBox206.Size = new SizeU(Unit.Cm(0.22577685117721558), Unit.Cm(0.23428621888160706));
			textBox206.Style.BorderStyle.Default = BorderType.Solid;
			textBox206.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox206.Style.Font.Name = "맑은 고딕";
			textBox206.Style.Font.Size = Unit.Point(10.0);
			textBox206.Style.VerticalAlign = VerticalAlign.Middle;
			textBox206.StyleName = "";
			textBox207.Name = "textBox207";
			textBox207.Size = new SizeU(Unit.Cm(0.0785704106092453), Unit.Cm(0.23428621888160706));
			textBox207.Style.BorderStyle.Default = BorderType.Solid;
			textBox207.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox207.Style.Font.Name = "맑은 고딕";
			textBox207.Style.Font.Size = Unit.Point(10.0);
			textBox207.Style.TextAlign = HorizontalAlign.Center;
			textBox207.Style.VerticalAlign = VerticalAlign.Middle;
			textBox207.StyleName = "";
			textBox208.Name = "textBox208";
			textBox208.Size = new SizeU(Unit.Cm(0.13546620309352875), Unit.Cm(0.23428621888160706));
			textBox208.Style.BorderStyle.Default = BorderType.Solid;
			textBox208.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox208.Style.Font.Name = "맑은 고딕";
			textBox208.Style.Font.Size = Unit.Point(10.0);
			textBox208.Style.TextAlign = HorizontalAlign.Right;
			textBox208.Style.VerticalAlign = VerticalAlign.Middle;
			textBox208.StyleName = "";
			textBox209.Name = "textBox209";
			textBox209.Size = new SizeU(Unit.Cm(0.18062169849872589), Unit.Cm(0.23428621888160706));
			textBox209.Style.BackgroundColor = Color.White;
			textBox209.Style.BorderStyle.Default = BorderType.Solid;
			textBox209.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox209.Style.Font.Name = "맑은 고딕";
			textBox209.Style.Font.Size = Unit.Point(10.0);
			textBox209.Style.TextAlign = HorizontalAlign.Center;
			textBox209.Style.VerticalAlign = VerticalAlign.Middle;
			textBox209.StyleName = "";
			textBox210.Name = "textBox210";
			textBox210.Size = new SizeU(Unit.Cm(0.16255953907966614), Unit.Cm(0.23428621888160706));
			textBox210.Style.BackgroundColor = Color.White;
			textBox210.Style.BorderStyle.Default = BorderType.Solid;
			textBox210.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox210.Style.Font.Name = "맑은 고딕";
			textBox210.Style.Font.Size = Unit.Point(10.0);
			textBox210.Style.TextAlign = HorizontalAlign.Center;
			textBox210.Style.VerticalAlign = VerticalAlign.Middle;
			textBox210.StyleName = "";
			textBox211.Name = "textBox211";
			textBox211.Size = new SizeU(Unit.Cm(0.43309098482131958), Unit.Cm(0.23428621888160706));
			textBox211.Style.BackgroundColor = Color.White;
			textBox211.Style.BorderStyle.Default = BorderType.Solid;
			textBox211.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox211.Style.Font.Name = "맑은 고딕";
			textBox211.Style.Font.Size = Unit.Point(10.0);
			textBox211.Style.TextAlign = HorizontalAlign.Center;
			textBox211.Style.VerticalAlign = VerticalAlign.Middle;
			textBox211.StyleName = "";
			textBox212.Name = "textBox212";
			textBox212.Size = new SizeU(Unit.Cm(0.20319931209087372), Unit.Cm(0.23428621888160706));
			textBox212.Style.BackgroundColor = Color.White;
			textBox212.Style.BorderStyle.Default = BorderType.Solid;
			textBox212.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox212.Style.Font.Name = "맑은 고딕";
			textBox212.Style.Font.Size = Unit.Point(10.0);
			textBox212.Style.TextAlign = HorizontalAlign.Center;
			textBox212.Style.VerticalAlign = VerticalAlign.Middle;
			textBox212.StyleName = "";
			textBox309.Name = "textBox309";
			textBox309.Size = new SizeU(Unit.Cm(0.30479881167411804), Unit.Cm(0.2342860996723175));
			textBox309.Style.BorderStyle.Default = BorderType.Solid;
			textBox309.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox309.Style.Font.Name = "맑은 고딕";
			textBox309.Style.Font.Size = Unit.Point(10.0);
			textBox309.Style.VerticalAlign = VerticalAlign.Middle;
			textBox309.StyleName = "";
			textBox310.Name = "textBox310";
			textBox310.Size = new SizeU(Unit.Cm(0.30479881167411804), Unit.Cm(0.2342860996723175));
			textBox310.Style.BorderStyle.Default = BorderType.Solid;
			textBox310.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox310.Style.Font.Name = "맑은 고딕";
			textBox310.Style.Font.Size = Unit.Point(10.0);
			textBox310.Style.VerticalAlign = VerticalAlign.Middle;
			textBox310.StyleName = "";
			textBox311.Name = "textBox311";
			textBox311.Size = new SizeU(Unit.Cm(0.30479881167411804), Unit.Cm(0.23428621888160706));
			textBox311.Style.BorderStyle.Default = BorderType.Solid;
			textBox311.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox311.Style.Font.Name = "맑은 고딕";
			textBox311.Style.Font.Size = Unit.Point(10.0);
			textBox311.Style.VerticalAlign = VerticalAlign.Middle;
			textBox311.StyleName = "";
			textBox324.CanGrow = false;
			textBox324.Name = "textBox324";
			textBox324.Size = new SizeU(Unit.Cm(0.0785704106092453), Unit.Cm(0.2342860996723175));
			textBox324.Style.BorderColor.Left = Color.Black;
			textBox324.Style.BorderColor.Right = Color.Black;
			textBox324.Style.BorderStyle.Default = BorderType.Solid;
			textBox324.Style.BorderStyle.Top = BorderType.Solid;
			textBox324.Style.BorderWidth.Bottom = Unit.Point(0.5);
			textBox324.Style.BorderWidth.Default = Unit.Point(0.5);
			textBox324.Style.BorderWidth.Left = Unit.Point(0.5);
			textBox324.Style.BorderWidth.Right = Unit.Point(0.5);
			textBox324.Style.Font.Name = "맑은 고딕";
			textBox324.Style.Font.Size = Unit.Point(10.0);
			textBox324.Style.TextAlign = HorizontalAlign.Center;
			textBox324.Style.VerticalAlign = VerticalAlign.Middle;
			textBox324.StyleName = "";
			base.DataSource = null;
			base.Items.AddRange(new Telerik.Reporting.ReportItemBase[2]
			{
				detail,
				reportHeaderSection1
			});
			base.Name = "ROUTINE_SHEET";
			base.PageSettings.Landscape = false;
			base.PageSettings.Margins = new MarginsU(Unit.Mm(5.0), Unit.Mm(5.0), Unit.Mm(7.5), Unit.Mm(7.5));
			base.PageSettings.PaperKind = PaperKind.A4;
			reportParameter.Name = "TraPlanDate";
			reportParameter.Value = "TraPlanDate.Value";
			base.ReportParameters.Add(reportParameter);
			base.Style.BackgroundColor = Color.White;
			base.Style.BorderStyle.Default = BorderType.Solid;
			base.Style.BorderWidth.Default = Unit.Point(2.0);
			styleRule.Selectors.AddRange(new ISelector[2]
			{
				new TypeSelector(typeof(Telerik.Reporting.TextItemBase)),
				new TypeSelector(typeof(Telerik.Reporting.HtmlTextBox))
			});
			styleRule.Style.Padding.Left = Unit.Point(2.0);
			styleRule.Style.Padding.Right = Unit.Point(2.0);
			base.StyleSheet.AddRange(new StyleRule[1]
			{
				styleRule
			});
			base.Width = Unit.Cm(20.0);
			((ISupportInitialize)this).EndInit();
		}
	}
}
