using Infragistics.Win.Misc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static Cmmn.Common;

namespace Cmmn
{
    public static class ClassMenu
    {
        /// <summary>
        /// 실제 사용할 객체 할당
        /// </summary>
        public static ClassMainMenu classMainMenu;

        #region 메뉴 자체에 대한 처리를 관장하는 클래스
        public class ClassMainMenu
        {
            /// <summary>
            /// 메인메뉴와 연결된 객체를 저장
            /// </summary>
            public clsMenuItem cMainMenu;

            /// <summary>
            /// 서브메뉴 중 앞에 보이는 패널
            /// </summary>
            public Panel pnlVisible = null;

            /// <summary>
            /// 버튼 클릭 이벤트 발생시
            /// </summary>
            public event Cmmn.ButtonBox_Main.ButtonClick eventButtonClick;
            
            /// <summary>
            /// 조건에 맞지 않거나 예상치 못한 에러가 발생하면 발생
            /// </summary>
            public event ExceptionMessage exceptionOccured;

            // Tag 에 대한 정보를 담을 리스트
            List<VisibleItem> items;

            // 조회된 BM0000 의 데이터
            private DataTable dataTable;
            
            /// <summary>
            /// 서브 메뉴를 포함할 컨트롤 - 생성자 호출시 매개변수로 받음
            /// </summary>
            public UltraGroupBox OwnerControl;

            public ClassMainMenu(DataTable dt, ButtonBox_Main btnMain, UltraGroupBox cOwnerControl)
            {
                // 트리 메뉴 생성

                // 메인메뉴 먼저 설정
                DataRow[] dArr = dt.Select("RELCODE1 = 'MainMenu' ", "DISPLAYNO");
                dataTable = dt;
                OwnerControl = cOwnerControl;

                cMainMenu = new clsMenuItem("MainMenu");
                cMainMenu.MenuPanel.Controls.Remove(cMainMenu.BtnMenu);
                cMainMenu.BtnMenu = btnMain;

                cMainMenu.BtnMenu.MainForm = true;
                cMainMenu.BtnMenu.ButtonBoxType = Common.ButtonBoxTypeEnum.Buttons;
                cMainMenu.BtnMenu.CountX = 1;
                cMainMenu.BtnMenu.CountY = 13;
                cMainMenu.BtnMenu.DisplayImage = true;

                cMainMenu.BtnMenu.SetButton();
                cMainMenu.SetEvent();
                cMainMenu.eventButtonClick += BtnMenu_ButtonClickEvent;
                cMainMenu.exceptionOccured += CMainMenu_exceptionOccured;

                items = new List<VisibleItem>();

                int iSeq = 0;

                foreach (DataRow dr in dArr)
                {
                    string sTag = CModule.ToString(dr["RELCODE3"]);
                    string sWhere = CModule.ToString(dr["RELCODE4"]);
                    string sValue = CModule.ToString(dr["RELCODE5"]);
                    string sName = CModule.ToString(dr["CODENAME"]);
                    int iDisplayNo = CModule.ToInt32(dr["DISPLAYNO"]);

                    string sUseFlag = CModule.ToString(dr["USEFLAG"]);

                    VisibleItem v = new VisibleItem(sTag, sWhere, sValue, sUseFlag, iDisplayNo);

                    items.Add(v);

                    if (sUseFlag == "Y")
                    {
                        cMainMenu.BtnMenu[iSeq, 0].Text = sName;
                        cMainMenu.BtnMenu[iSeq, 0].Tag = sTag;

                        DataRow[] dArr2 = dt.Select("RELCODE1 = '" + sTag + "' and USEFLAG = 'Y' ", "DISPLAYNO");

                        if (dArr2.Length > 0)
                        {
                            clsMenuItem c = new clsMenuItem(sTag);
                            c.eventButtonClick += BtnMenu_ButtonClickEvent;
                            c.exceptionOccured += CMainMenu_exceptionOccured;

                            v.cMenu = c;
                            v.cMenu.BtnMenu.Width = cMainMenu.BtnMenu.Width;
                            v.cMenu.BtnMenu.MainForm = true;
                            OwnerControl.Controls.Add(c.MenuPanel);

                            foreach (DataRow tdr in dArr2)
                            {
                                string sTag2 = CModule.ToString(tdr["RELCODE3"]);
                                string sWhere2 = CModule.ToString(tdr["RELCODE4"]);
                                string sValue2 = CModule.ToString(tdr["RELCODE5"]);
                                string sName2 = CModule.ToString(tdr["CODENAME"]);
                                int iDisplayNo2 = CModule.ToInt32(tdr["DISPLAYNO"]);

                                string sUseFlag2 = CModule.ToString(tdr["USEFLAG"]);

                                VisibleItem v2 = new VisibleItem(sTag2, sWhere2, sValue2, sUseFlag2, iDisplayNo2);

                                items.Add(v2);
                            }
                        }
                    }
                    else
                    {
                        cMainMenu.BtnMenu[iSeq, 0].Text = "";
                        cMainMenu.BtnMenu[iSeq, 0].Tag = "";
                    }

                    iSeq++;
                }

                cMainMenu.BtnMenu.RedrawButton();
            }

            private void CMainMenu_exceptionOccured(object sender, Exception ex)
            {
                exceptionOccured?.Invoke(this, ex);
            }

            private void BtnMenu_ButtonClickEvent(Button_Main sender, ButtonBox_Main.ButtonClickEventArg e)
            {
                eventButtonClick?.Invoke(sender, e);
            }

            /// <summary>
            /// 태그와 해당 태그에 대응되는 조건을 저장. 
            /// 또한 서브메뉴가 있을 경우 해당 서브메뉴 또한 포함
            /// </summary>
            public class VisibleItem
            {
                public string sTag;
                public string sWhere;
                public string sValue;
                public string sUseFlag;
                public int DisplayNo;

                public clsMenuItem cMenu;

                public VisibleItem(string tag, string where, string value, string useflag, int iDisplayNo)
                {
                    sTag = tag;
                    sWhere = where;
                    sValue = value;
                    sUseFlag = useflag;
                    DisplayNo = iDisplayNo;
                }
            }

            /// <summary>
            /// 태그에 해당하는 VisibleItem 을 반환
            /// </summary>
            /// <param name="sTag"></param>
            /// <returns></returns>
            public VisibleItem this[string sTag]
            {
                get
                {
                    foreach (VisibleItem v in items)
                    {
                        if (v.sTag == sTag)
                        {
                            return v;
                        }
                    }

                    return null;
                }
            }

            /// <summary>
            /// Visible 아이템과 대응하는 공통코드의 데이터를 반환
            /// </summary>
            /// <param name="v"></param>
            /// <returns></returns>
            public DataRow[] this[VisibleItem v]
            {
                get
                {
                    return dataTable.Select("RELCODE1 = '" + v.sTag + "' and USEFLAG = 'Y' ", "DISPLAYNO");
                }
            }

            /// <summary>
            /// 서브메뉴가 열려 있을 경우 해당 서브메뉴를 닫아주는 메소드
            /// </summary>
            public void CloseSubForm()
            {
                if (pnlVisible != null)
                {
                    pnlVisible.Visible = false;
                    pnlVisible = null;
                }
            }
        }
        #endregion

        #region 메뉴 처리를 위한 클래스
        public class clsMenuItem
        {
            #region 멤버변수

            private bool bButtonChk = false;

            /// <summary>
            /// 메뉴의 이름
            /// </summary>
            public string Name;
            /// <summary>
            /// 메뉴가 위치하는 패널
            /// </summary>
            public Panel MenuPanel;
            /// <summary>
            /// 메뉴에 대응되는 버튼박스
            /// </summary>
            public ButtonBox_Main BtnMenu;

            /// <summary>
            /// 버튼 클릭 이벤트 발생시 발생 - ClassMainMenu 의 eventButtonClick 이벤트를 발생
            /// </summary>
            public event Cmmn.ButtonBox_Main.ButtonClick eventButtonClick;
            /// <summary>
            /// 버튼 처리시 오류 발생시 발생 - ClassMainMenu 의 exceptionOccured 이벤트를 발생
            /// </summary>
            public event ExceptionMessage exceptionOccured;

            #endregion

            #region 생성자
            /// <summary>
            /// 생성자 - clsMenuItem 의 이름을 매개변수로 받음
            /// </summary>
            /// <param name="sName"></param>
            public clsMenuItem(string sName)
            {
                Name = sName;
                MenuPanel = new Panel();
                BtnMenu = new ButtonBox_Main();

                Initialize();
            }

            /// <summary>
            /// 등록하지 않은 메세지를 연결
            /// </summary>
            public void SetEvent()
            {
                BtnMenu.ButtonClickEvent += BtnMenu_ButtonClickEvent;
            }

            /// <summary>
            /// 컨트롤의 기본 생성 속성을 지정 - DX0000.designer.cs 에서 복사
            /// </summary>
            private void Initialize()
            {
                MenuPanel.BackColor = System.Drawing.Color.Transparent;
                MenuPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                MenuPanel.Controls.Add(this.BtnMenu);
                MenuPanel.Margin = new System.Windows.Forms.Padding(0);
                // 
                // bBtnMenu
                // 
                BtnMenu.AlarmColor = System.Drawing.Color.Empty;
                BtnMenu.BackColor = System.Drawing.Color.White;
                BtnMenu.BackgroundColor = System.Drawing.Color.Empty;
                BtnMenu.BackgroundColor2 = System.Drawing.Color.Empty;
                BtnMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
                BtnMenu.ButtonBoxType = Cmmn.Common.ButtonBoxTypeEnum.Buttons;
                BtnMenu.ButtonInfo = null;
                BtnMenu.ClickBackColor = System.Drawing.Color.Empty;
                BtnMenu.CountX = 1;
                BtnMenu.CountY = 1;
                BtnMenu.CurrentPage = 0;
                BtnMenu.DisableColor = System.Drawing.Color.Empty;
                BtnMenu.DisplayImage = false;
                BtnMenu.Dock = System.Windows.Forms.DockStyle.Right;
                BtnMenu.ExTag = "";
                BtnMenu.Font = new System.Drawing.Font("맑은 고딕", 15F);
                BtnMenu.FontData = null;
                BtnMenu.FontSize = 15F;
                BtnMenu.HAlign = Infragistics.Win.HAlign.Center;
                BtnMenu.Location = new System.Drawing.Point(58, 0);
                BtnMenu.MainForm = false;
                BtnMenu.Margin = new System.Windows.Forms.Padding(0);
                BtnMenu.MarginIn = new System.Windows.Forms.Padding(0);
                BtnMenu.MarginOut = new System.Windows.Forms.Padding(0);
                BtnMenu.MsgAddText = null;
                BtnMenu.MsgControl = null;
                BtnMenu.PageControl = null;
                BtnMenu.ParmN = null;
                BtnMenu.ParmT = null;
                BtnMenu.ParmV = null;
                BtnMenu.ProcedureT = System.Data.CommandType.StoredProcedure;
                BtnMenu.SelectCommand = null;
                BtnMenu.SelectionMode = Cmmn.Common.SelectionModeEnum.Single;
                BtnMenu.SelectProcedureName = null;
                BtnMenu.ButtonClickEvent += BtnMenu_ButtonClickEvent;
            }
            #endregion

            #region 이벤트
            private void BtnMenu_ButtonClickEvent(Button_Main sender, ButtonBox_Main.ButtonClickEventArg e)
            {
                try
                {
                    if (this.bButtonChk)
                    {
                        return;
                    }

                    this.bButtonChk = true;
                    // 버튼클릭이벤트 발생시 해당 메뉴가 포함한 팝업창이 있는지 확인한다.
                    string sTag = CModule.ToString(sender.Tag);

                    string sRelCode4 = classMainMenu[sTag].sWhere;
                    string sRelCode5 = classMainMenu[sTag].sValue;

                    if (ClassMenu.classMainMenu.pnlVisible != null)
                    {
                        if (sender.ParentBox.Parent != ClassMenu.classMainMenu.pnlVisible)
                        {
                            ClassMenu.classMainMenu.pnlVisible.Visible = false;
                            ClassMenu.classMainMenu.pnlVisible = null;

                            return;
                        }
                    }

                    if (sRelCode4 == "WORKCENTERCODE")
                    {
                        if (Common.SelectedWorkCenter == null)
                        {
                            throw new Exception(Common.getLangText("작업장을 선택 하고 진행 하십시오.", "DAS"));
                        }
                    }

                    if (bOpenMenu(sTag))
                    {
                        return;
                    }

                    if (sRelCode4 != "")
                    {
                        string sValue = Common.SelectedWorkCenter[sRelCode4];

                        if (sRelCode4 != "WORKCENTERCODE")
                        {
                            if (sValue == null)
                            {
                                throw new Exception(Common.getLangText("정의에 맞지 않는 값에 대한 코드가 입력되어 있습니다.", "DAS"));
                            }

                            if (sValue != sRelCode5)
                            {
                                throw new Exception(Common.getLangText("조건에 맞지 않아 사용할 수 없는 버튼입니다.", "DAS"));
                            }
                        }
                    }

                    if (ClassMenu.classMainMenu.pnlVisible != null)
                    {
                        ClassMenu.classMainMenu.pnlVisible.Visible = false;
                        ClassMenu.classMainMenu.pnlVisible = null;
                    }
                    eventButtonClick?.Invoke(sender, e);
                }
                catch (Exception ex)
                {
                    exceptionOccured?.Invoke(this, ex);
                }
                finally
                {
                    this.bButtonChk = false;
                }
            }

            /// <summary>
            /// 메뉴 해당 태그에 대해서 메뉴가 있는지 확인하고 서브메뉴가 있으면 서브메뉴를 띄워주고, 아니면 클릭 이벤트를 발생.
            /// </summary>
            /// <param name="sTag"></param>
            /// <returns></returns>
            private bool bOpenMenu(string sTag)
            {
                ClassMainMenu.VisibleItem v = classMainMenu[sTag];
                DataRow[] dArr = classMainMenu[v];

                if (dArr.Length > 0)
                {
                    int iCountSum = 0;

                    foreach (DataRow dr in dArr)
                    {
                        string sRelCode4 = CModule.ToString(dr["RELCODE4"]);
                        string sRelCode5 = CModule.ToString(dr["RELCODE5"]);

                        if (sRelCode4 == "WORKCENTERCODE")
                        {
                            if (Common.SelectedWorkCenter == null)
                            {
                                continue;
                            }
                        }

                        if (sRelCode4 != "")
                        {
                            string sValue = Common.SelectedWorkCenter[sRelCode4];

                            if (sRelCode4 != "WORKCENTERCODE")
                            {
                                if (sValue == null)
                                {
                                    continue;
                                }

                                if (sValue != sRelCode5)
                                {
                                    continue;
                                }
                            }
                        }

                        iCountSum++;
                    }

                    ButtonBox_Main btnM = ClassMenu.classMainMenu.cMainMenu.BtnMenu;

                    int iPos = v.DisplayNo;

                    v.cMenu.MenuPanel.Width = btnM.Width + 15;
                    v.cMenu.MenuPanel.Height = ((btnM.Height) / btnM.CountY) * iCountSum;
                    v.cMenu.MenuPanel.Location = new Point(btnM.Width, btnM[iPos, 0].MappingButton.Bounds.Y);

                    if (classMainMenu.OwnerControl.Height < v.cMenu.MenuPanel.Top + v.cMenu.MenuPanel.Height)
                    {
                        // 위치 변경
                        v.cMenu.MenuPanel.Location = new Point(btnM.Width, btnM[iPos - (iCountSum - 1), 0].MappingButton.Bounds.Y);
                    }

                    // 메뉴 확인
                    if (iCountSum > 0)
                    {
                        v.cMenu.BtnMenu.Size = new Size(btnM.Width, v.cMenu.MenuPanel.Height);

                        v.cMenu.BtnMenu.ButtonBoxType = Common.ButtonBoxTypeEnum.Buttons;
                        v.cMenu.BtnMenu.CountX = 1;
                        v.cMenu.BtnMenu.CountY = iCountSum;
                        v.cMenu.BtnMenu.DisplayImage = true;

                        v.cMenu.BtnMenu.SetButton();
                        v.cMenu.BtnMenu.RedrawButton();

                        int iSeq = 0;

                        foreach (DataRow dr in dArr)
                        {
                            string sRelCode4 = CModule.ToString(dr["RELCODE4"]);
                            string sRelCode5 = CModule.ToString(dr["RELCODE5"]);

                            if (sRelCode4 == "WORKCENTERCODE")
                            {
                                if (Common.SelectedWorkCenter == null)
                                {
                                    continue;
                                }
                            }

                            if (sRelCode4 != "")
                            {
                                string sValue = Common.SelectedWorkCenter[sRelCode4];

                                if (sRelCode4 != "WORKCENTERCODE")
                                {
                                    if (sValue == null)
                                    {
                                        continue;
                                    }

                                    if (sValue != sRelCode5)
                                    {
                                        continue;
                                    }
                                }
                            }

                            v.cMenu.BtnMenu[iSeq, 0].Text = CModule.ToString(dr["CODENAME"]);
                            v.cMenu.BtnMenu[iSeq, 0].Tag = CModule.ToString(dr["RELCODE3"]);

                            iSeq++;
                        }

                        //v.cMenu.BtnMenu.SetButton();
                        v.cMenu.BtnMenu.RedrawButton();

                        ClassMenu.classMainMenu.pnlVisible = v.cMenu.MenuPanel;

                        v.cMenu.MenuPanel.Visible = true;
                        v.cMenu.MenuPanel.BringToFront();

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                return false;
            }
            #endregion
        }
        #endregion

        #region 설정 호출 메소드
        /// <summary>
        /// 메인메뉴 생성 및 처리
        /// </summary>
        /// <param name="btnMain">메인메뉴 객체</param>
        /// <param name="cOwnerControl">SubMenu 를 소유할 컨트롤</param>
        public static void SetDASMenu(ButtonBox_Main btnMain, UltraGroupBox cOwnerControl)
        {
            string s = "SELECT * FROM BM0000 with (NOLOCK) where MAJORCODE = 'DASDISPLAY' and MINORCODE <> '$' and RELCODE2 = '" + Common.gsPlantCode + "' ";

            DBHelper db = new DBHelper(false);

            // BM0000 테이블의 MajorCode : DASDISPLAY 를 조회
            DataTable dt = db.FillTable(s, CommandType.Text);

            classMainMenu = new ClassMainMenu(dt, btnMain, cOwnerControl);
        }
        #endregion
    }
}
