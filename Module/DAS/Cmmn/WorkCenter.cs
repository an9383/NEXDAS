using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Cmmn
{
	public class WorkCenter
	{
        #region 멤버변수
        private List<WorkerList> _ListWorker = new List<WorkerList>();

		private Hashtable _hash;

		private string _PlantCode;
		private string _Code;
		private string _Name;
		private string _OPCode;
		private string _ItemCode;
		private string _ItemName;
		private string _OrderType;
		private string _OrderNO;
		private string _WCStatus;
		private string _WCLastDate;
		private string _StopCode;
		private int _WorkerCount;
		private string _DayNight;
		private string _ShiftGB;
		private string _LotNo;
		
        private double _ProdQtyCal;
		private double _ProdQtyReal;
		private double _ProdQtyMan;
		private double _ProdQty;
		private double _ErrorQty;
		private string _UnitCode;
		private string _NextWork;
		private double _UseQty;

		private string _ZigBeeID;
		private string _ServerIP;
		private string _PostWorkCenterCode;
		private string _ContainPreWC;
		private string _MultiOrderNo;

		private int _OrderCount;

		private string _MoldUse;
		private string _MoldCode;

		private string _DayExtend;

		private double _OrderQty;
		private string _GroupKey;
        private string _OPType;
        private string _DASForm;
        private string _DetFlag;

        private string _PlanNo;
        private int _CheckCount;
        #endregion

        #region 속성 리스트
        public string Code
		{
			get
			{
				return _Code;
			}
			set
			{
				if (_Code != value)
				{
					if (_hash.Contains("WORKCENTERCODE"))
					{
						_hash["WORKCENTERCODE"] = value;
					}
					else
					{
						_hash.Add("WORKCENTERCODE", value);
					}
				}
				_Code = value;
			}
		}

		public string Name
		{
			get
			{
				return _Name;
			}
			set
            {
                if (_Name != value)
                {
                    if (_hash.Contains("WORKCENTERNAME"))
                    {
                        _hash["WORKCENTERNAME"] = value;
                    }
                    else
                    {
                        _hash.Add("WORKCENTERNAME", value);
                    }
                }
                _Name = value;
			}
		}

		public string PlantCode
		{
			get
			{
				return _PlantCode;
			}
			set
			{
				if (_PlantCode != value)
				{
					if (_hash.Contains("PLANTCODE"))
					{
						_hash["PLANTCODE"] = value;
					}
					else
					{
						_hash.Add("PLANTCODE", value);
					}
				}
				_PlantCode = value;
			}
		}

		public string OPCode
		{
			get
			{
				return _OPCode;
			}
			set
			{
				if (_OPCode != value)
				{
					if (_hash.Contains("OPCODE"))
					{
						_hash["OPCODE"] = value;
					}
					else
					{
						_hash.Add("OPCODE", value);
					}
				}
				_OPCode = value;
			}
		}

		public string WCStatus
		{
			get
			{
				return _WCStatus;
			}
			set
			{
				if (_WCStatus != value)
				{
					if (_hash.Contains("WCSTATUS"))
					{
						_hash["WCSTATUS"] = value;
					}
					else
					{
						_hash.Add("WCSTATUS", value);
					}
				}
				_WCStatus = value;
			}
		}

		public string WCLastDate
		{
			get
			{
				return _WCLastDate;
			}
			set
			{
				if (_WCLastDate != value)
				{
					if (_hash.Contains("WCLASTDATE"))
					{
						_hash["WCLASTDATE"] = value;
					}
					else
					{
						_hash.Add("WCLASTDATE", value);
					}
				}
				_WCLastDate = value;
			}
		}

		public string StopCode
		{
			get
			{
				return _StopCode;
			}
			set
			{
				if (_StopCode != value)
				{
					if (_hash.Contains("STOPCODE"))
					{
						_hash["STOPCODE"] = value;
					}
					else
					{
						_hash.Add("STOPCODE", value);
					}
				}
				_StopCode = value;
			}
		}

		public string ItemCode
		{
			get
			{
				return _ItemCode;
			}
			set
			{
				if (_ItemCode != value)
				{
					if (_hash.Contains("ITEMCODE"))
					{
						_hash["ITEMCODE"] = value;
					}
					else
					{
						_hash.Add("ITEMCODE", value);
					}
				}
				_ItemCode = value;
			}
		}

		public string ItemName
		{
			get
			{
				return _ItemName;
			}
			set
			{
				if (_ItemName != value)
				{
					if (_hash.Contains("ITEMNAME"))
					{
						_hash["ITEMNAME"] = value;
					}
					else
					{
						_hash.Add("ITEMNAME", value);
					}
				}
				_ItemName = value;
			}
		}

		public string OrderNO
		{
			get
			{
				return _OrderNO;
			}
			set
			{
				if (_OrderNO != value)
				{
					if (_hash.Contains("ORDERNO"))
					{
						_hash["ORDERNO"] = value;
					}
					else
					{
						_hash.Add("ORDERNO", value);
					}
				}
				_OrderNO = value;
			}
		}

		public int WorkerCount
		{
			get
			{
				return _WorkerCount;
			}
			set
			{
				if (_WorkerCount != value)
				{
					if (_hash.Contains("WORKERCOUNT"))
					{
						_hash["WORKERCOUNT"] = value;
					}
					else
					{
						_hash.Add("WORKERCOUNT", value);
					}
				}
				_WorkerCount = value;
			}
		}

		public string DayNight
		{
			get
			{
				return _DayNight;
			}
			set
			{
				if (_DayNight != value)
				{
					if (_hash.Contains("DAYNIGHT"))
					{
						_hash["DAYNIGHT"] = value;
					}
					else
					{
						_hash.Add("DAYNIGHT", value);
					}
				}
				_DayNight = value;
			}
		}

		public string ShiftGB
		{
			get
			{
				return _ShiftGB;
			}
			set
			{
				if (_ShiftGB != value)
				{
					if (_hash.Contains("SHIFTGB"))
					{
						_hash["SHIFTGB"] = value;
					}
					else
					{
						_hash.Add("SHIFTGB", value);
					}
				}
				_ShiftGB = value;
			}
		}

		public string LotNo
		{
			get
			{
				return _LotNo;
			}
			set
			{
				if (_LotNo != value)
				{
					if (_hash.Contains("LOTNO"))
					{
						_hash["LOTNO"] = value;
					}
					else
					{
						_hash.Add("LOTNO", value);
					}
				}
				_LotNo = value;
			}
		}

		public double ProdQtyCal
		{
			get
			{
				return _ProdQtyCal;
			}
			set
			{
				if (_ProdQtyCal != value)
				{
					if (_hash.Contains("PRODQTYCAL"))
					{
						_hash["PRODQTYCAL"] = value;
					}
					else
					{
						_hash.Add("PRODQTYCAL", value);
					}
				}
				_ProdQtyCal = value;
			}
		}

		public double ProdQtyReal
		{
			get
			{
				return _ProdQtyReal;
			}
			set
			{
				if (_ProdQtyReal != value)
				{
					if (_hash.Contains("PRODQTYREAL"))
					{
						_hash["PRODQTYREAL"] = value;
					}
					else
					{
						_hash.Add("PRODQTYREAL", value);
					}
				}
				_ProdQtyReal = value;
			}
		}

		public double ProdQtyMan
		{
			get
			{
				return _ProdQtyMan;
			}
			set
			{
				if (_ProdQtyMan != value)
				{
					if (_hash.Contains("PRODQTYMAN"))
					{
						_hash["PRODQTYMAN"] = value;
					}
					else
					{
						_hash.Add("PRODQTYMAN", value);
					}
				}
				_ProdQtyMan = value;
			}
		}

		public double ProdQty
		{
			get
			{
				return _ProdQty;
			}
			set
			{
				if (_ProdQty != value)
				{
					if (_hash.Contains("PRODQTY"))
					{
						_hash["PRODQTY"] = value;
					}
					else
					{
						_hash.Add("PRODQTY", value);
					}
				}
				_ProdQty = value;
			}
		}

		public double ErrorQty
		{
			get
			{
				return _ErrorQty;
			}
			set
			{
				if (_ErrorQty != value)
				{
					if (_hash.Contains("ERRORQTY"))
					{
						_hash["ERRORQTY"] = value;
					}
					else
					{
						_hash.Add("ERRORQTY", value);
					}
				}
				_ErrorQty = value;
			}
		}

		public string UnitCode
		{
			get
			{
				return _UnitCode;
			}
			set
			{
				if (_UnitCode != value)
				{
					if (_hash.Contains("UNITCODE"))
					{
						_hash["UNITCODE"] = value;
					}
					else
					{
						_hash.Add("UNITCODE", value);
					}
				}
				_UnitCode = value;
			}
		}

		public string NextWork
		{
			get
			{
				return _NextWork;
			}
			set
			{
				if (_NextWork != value)
				{
					if (_hash.Contains("NEXTWORK"))
					{
						_hash["NEXTWORK"] = value;
					}
					else
					{
						_hash.Add("NEXTWORK", value);
					}
				}
				_NextWork = value;
			}
		}

		public int CheckCount
		{
			get
			{
				return _CheckCount;
			}
			set
			{
				if (_CheckCount != value)
				{
					if (_hash.Contains("CHECKCOUNT"))
					{
						_hash["CHECKCOUNT"] = value;
					}
					else
					{
						_hash.Add("CHECKCOUNT", value);
					}
				}
				_CheckCount = value;
			}
		}

		public double UseQty
		{
			get
			{
				return _UseQty;
			}
			set
			{
				if (_UseQty != value)
				{
					if (_hash.Contains("USEQTY"))
					{
						_hash["USEQTY"] = value;
					}
					else
					{
						_hash.Add("USEQTY", value);
					}
				}
				_UseQty = value;
			}
		}

		public string ZigbeeID
		{
			get
			{
				return _ZigBeeID;
			}
			set
            {
                if (_ZigBeeID != value)
                {
                    if (_hash.Contains("ZIGBEEID"))
                    {
                        _hash["ZIGBEEID"] = value;
                    }
                    else
                    {
                        _hash.Add("ZIGBEEID", value);
                    }
                }
                _ZigBeeID = value;
			}
		}

		public string ServerIP
		{
			get
			{
				return _ServerIP;
			}
			set
            {
                if (_ServerIP != value)
                {
                    if (_hash.Contains("SERVERIP"))
                    {
                        _hash["SERVERIP"] = value;
                    }
                    else
                    {
                        _hash.Add("SERVERIP", value);
                    }
                }

                _ServerIP = value;
			}
		}

		public string PostWorkCenterCode
		{
			get
			{
				return _PostWorkCenterCode;
			}
			set
			{
                if (_PostWorkCenterCode != value)
                {
                    if (_hash.Contains("POSTWORKCENTERCODE"))
                    {
                        _hash["POSTWORKCENTERCODE"] = value;
                    }
                    else
                    {
                        _hash.Add("POSTWORKCENTERCODE", value);
                    }
                }

                _PostWorkCenterCode = value;
            }
		}

		public string ContainPreWC
		{
			get
			{
				return _ContainPreWC;
			}
			set
            {
                if (_ContainPreWC != value)
                {
                    if (_hash.Contains("CONTAINPREWC"))
                    {
                        _hash["CONTAINPREWC"] = value;
                    }
                    else
                    {
                        _hash.Add("CONTAINPREWC", value);
                    }
                }
                _ContainPreWC = value;
			}
		}

		public string MultiOrderNo
		{
			get
			{
				return _MultiOrderNo;
			}
			set
            {
                if (_MultiOrderNo != value)
                {
                    if (_hash.Contains("MULTIORDERNO"))
                    {
                        _hash["MULTIORDERNO"] = value;
                    }
                    else
                    {
                        _hash.Add("MULTIORDERNO", value);
                    }
                }
                _MultiOrderNo = value;
			}
		}

		public double OrderQty
		{
			get
			{
				return _OrderQty;
			}
			set
            {
                if (_OrderQty != value)
                {
                    if (_hash.Contains("ORDERQTY"))
                    {
                        _hash["ORDERQTY"] = value;
                    }
                    else
                    {
                        _hash.Add("ORDERQTY", value);
                    }
                }
                _OrderQty = value;
			}
		}

		public string DayExtend
		{
			get
			{
				return _DayExtend;
			}
			set
			{
				if (_DayExtend != value)
				{
					if (_hash.Contains("DAYEXTEND"))
					{
						_hash["DAYEXTEND"] = value;
					}
					else
					{
						_hash.Add("DAYEXTEND", value);
					}
				}
				_DayExtend = value;
			}
		}

		public int OrderCount
		{
			get
			{
				return _OrderCount;
			}
			set
			{
				if (_OrderCount != value)
				{
					if (_hash.Contains("ORDERCOUNT"))
					{
						_hash["ORDERCOUNT"] = value;
					}
					else
					{
						_hash.Add("ORDERCOUNT", value);
					}
				}
				_OrderCount = value;
			}
		}

		public string MoldUse
		{
			get
			{

				return _MoldUse;
			}
			set
            {
                if (_hash.Contains("MOLDFLAG"))
                {
                    _hash["MOLDFLAG"] = value;
                }
                else
                {
                    _hash.Add("MOLDFLAG", value);
                }

                _MoldUse = value;
			}
		}

		public string MoldCode
		{
			get
			{
				return _MoldCode;
			}
			set
            {
                if (_hash.Contains("MOLDCODE"))
                {
                    _hash["MOLDCODE"] = value;
                }
                else
                {
                    _hash.Add("MOLDCODE", value);
                }
                _MoldCode = value;
			}
		}

		public string OrderType
		{
			get
			{
				return _OrderType;
			}
			set
            {
                if (_hash.Contains("ORDERTYPE"))
                {
                    _hash["ORDERTYPE"] = value;
                }
                else
                {
                    _hash.Add("ORDERTYPE", value);
                }
                _OrderType = value;
			}
		}

		public string GroupKey
		{
			get
			{
				return _GroupKey;
			}
			set
            {
                if (_hash.Contains("GROUPKEY"))
                {
                    _hash["GROUPKEY"] = value;
                }
                else
                {
                    _hash.Add("GROUPKEY", value);
                }
                _GroupKey = value;
			}
		}

        public string OPType
        {
            get
            {
                return _OPType;
            }
            set
            {
                if (_hash.Contains("OPTYPE"))
                {
                    _hash["OPTYPE"] = value;
                }
                else
                {
                    _hash.Add("OPTYPE", value);
                }
                _OPType = value;
            }
        }

        public string DASForm
        {
            get
            {
                return _DASForm;
            }
            set
            {
                if (_hash.Contains("DASFORM"))
                {
                    _hash["DASFORM"] = value;
                }
                else
                {
                    _hash.Add("DASFORM", value);
                }

                _DASForm = value;
            }
        }

        public string DetFlag
        {
            get
            {
                return _DetFlag;
            }
            set
            {
                if (_hash.Contains("DETFLAG"))
                {
                    _hash["DETFLAG"] = value;
                }
                else
                {
                    _hash.Add("DETFLAG", value);
                }

                _DetFlag = value;
            }
        }

        public string PlanNo
        {
            get
            {
                return _PlanNo;
            }
            set
            {
                if (_PlanNo != value)
                {
                    if (_hash.Contains("PLANNO"))
                    {
                        _hash["PLANNO"] = value;
                    }
                    else
                    {
                        _hash.Add("PLANNO", value);
                    }
                }
                _PlanNo = value;
            }
        }

        public string this[string sTag]
        {
            get
            {
                if (_hash.ContainsKey(sTag.ToUpper()))
                {
                    return CModule.ToString(_hash[sTag.ToUpper()]);
                }

                return null;
            }
        }
        #endregion

        public WorkCenter()
		{
			_hash = new Hashtable();
			_ListWorker.Add(new WorkerList(Common.ListWorkerType.SELECT));
			_ListWorker.Add(new WorkerList(Common.ListWorkerType.MACH));
			_ListWorker.Add(new WorkerList(Common.ListWorkerType.PROD));
		}

		public void Clear()
		{
			_hash.Clear();
		}

		public void ClearHash()
		{
			_hash.Clear();
		}

		public int Save()
		{
			DBHelper dBHelper = new DBHelper("", bTrans: true);
			try
			{
				int num = 0;
				if (_hash.Values.Count > 0)
				{
					try
					{
						if (_Code != null && _PlantCode != null && _Code != "" && _PlantCode != "")
						{
							StringBuilder stringBuilder = new StringBuilder();
							stringBuilder.Remove(0, stringBuilder.Length);
							stringBuilder.AppendLine(" UPDATE TPP1700 SET    ");
							foreach (string key in _hash.Keys)
							{
								switch (key)
								{
								case "LINESTATUS":
								case "MODELID":
								case "ITEMCODE":
								case "ITEMNAME":
								case "OPDESCCODE":
								case "ORDERNO":
								case "DAYNIGHT":
								case "SHIFTGB":
								case "LOTNO":
								case "UNITCODE":
								case "SIGNSTATUS":
								case "PRODFLAG":
								case "PLANNO":
								case "DAYEXTEND":
									if (num == 0)
									{
										stringBuilder.AppendLine("  " + key + " = '" + ((_hash[key] == null) ? "" : _hash[key].ToString().Replace("'", "''")) + "'  ");
									}
									else
									{
										stringBuilder.AppendLine(", " + key + " = '" + ((_hash[key] == null) ? "" : _hash[key].ToString().Replace("'", "''")) + "'  ");
									}
									break;
								case "WORKERCNT":
								case "CAVITY":
								case "MACHERRORCOUNT":
									if (num == 0)
									{
										stringBuilder.AppendLine("  " + key + " = " + ((_hash[key] != null) ? Convert.ToInt32(_hash[key]) : 0) + "   ");
									}
									else
									{
										stringBuilder.AppendLine(", " + key + " = " + ((_hash[key] != null) ? Convert.ToInt32(_hash[key]) : 0) + "   ");
									}
									break;
								case "PRODQTYCAL":
								case "PRODQTYREAL":
								case "PRODQTYMAN":
								case "PRODQTY":
								case "ERRORQTY":
								case "ORDERQTY":
								case "REWORKQTY":
								case "USEQTY":
									if (num == 0)
									{
										stringBuilder.AppendLine("  " + key + " = " + ((_hash[key] == null) ? 0.0 : Convert.ToDouble(_hash[key])) + "  ");
									}
									else
									{
										stringBuilder.AppendLine(", " + key + " = " + ((_hash[key] == null) ? 0.0 : Convert.ToDouble(_hash[key])) + "  ");
									}
									break;
								case "LASTLINEDATE":
									if (num == 0)
									{
										stringBuilder.AppendLine("  " + key + " = " + ((_hash[key] == null || _hash[key].ToString() == "") ? "GETDATE()" : ("'" + Convert.ToDateTime(_hash[key]).ToString("yyyy-MM-dd HH:mm:ss") + "' ")));
									}
									else
									{
										stringBuilder.AppendLine(", " + key + " = " + ((_hash[key] == null || _hash[key].ToString() == "") ? "GETDATE()" : ("'" + Convert.ToDateTime(_hash[key]).ToString("yyyy-MM-dd HH:mm:ss") + "' ")));
									}
									break;
								}
								num++;
							}
							stringBuilder.AppendLine("     , LASTDATE = GETDATE()                ");
							stringBuilder.AppendLine(" WHERE PLANTCODE      = '" + PlantCode + "'");
							stringBuilder.AppendLine("   AND WORKCENTERCODE = '" + Code + "'     ");
							int num2 = dBHelper.ExecuteNoneQuery(stringBuilder.ToString());
							num = 0;
							if (num2 == 0)
							{
								string empty = string.Empty;
								string empty2 = string.Empty;
								stringBuilder.Remove(0, stringBuilder.Length);
								stringBuilder.AppendLine(" INSERT INTO TPP1700 (     ");
								empty += "PLANTCODE, WORKCENTERCODE";
								empty2 = empty2 + "'" + _PlantCode + "', '" + _Code + "'";
								foreach (string key2 in _hash.Keys)
								{
									switch (key2)
									{
									case "LINESTATUS":
									case "MODELID":
									case "ITEMCODE":
									case "ITEMNAME":
									case "OPDESCCODE":
									case "ORDERNO":
									case "DAYNIGHT":
									case "SHIFTGB":
									case "LOTNO":
									case "UNITCODE":
									case "SIGNSTATUS":
									case "PRODFLAG":
									case "PLANNO":
										empty = empty + ", " + key2;
										empty2 = empty2 + ", '" + ((_hash[key2] == null) ? "" : _hash[key2].ToString()) + "'";
										break;
									case "WORKERCNT":
									case "CAVITY":
									case "MACHERRORCOUNT":
										empty = empty + ", " + key2;
										empty2 = empty2 + ", " + ((_hash[key2] != null) ? Convert.ToInt32(_hash[key2]) : 0);
										break;
									case "PRODQTYCAL":
									case "PRODQTYREAL":
									case "PRODQTYMAN":
									case "PRODQTY":
									case "ERRORQTY":
									case "ORDERQTY":
									case "REWORKQTY":
									case "USEQTY":
										empty = empty + ", " + key2;
										empty2 = empty2 + ", " + ((_hash[key2] == null) ? 0.0 : Convert.ToDouble(_hash[key2]));
										break;
									case "LASTLINEDATE":
										empty = empty + ", " + key2;
										empty2 = empty2 + ", " + ((_hash[key2] == null) ? "GETDATE()" : ("'" + Convert.ToDateTime(_hash[key2]).ToString("yyyy-MM-dd HH:mm:ss") + "'"));
										break;
									}
									num++;
								}
								stringBuilder.AppendLine(empty + " )                ");
								stringBuilder.AppendLine(" VALUES ( " + empty2 + ") ");
								num2 = dBHelper.ExecuteNoneQuery(stringBuilder.ToString());
							}
							_hash.Clear();
						}
					}
					catch (SqlException ex)
					{
						dBHelper.Rollback();
						return ex.Number;
					}
					catch (Exception)
					{
						dBHelper.Rollback();
						return -1;
					}
					dBHelper.Commit();
					return 0;
				}
				return -2;
			}
			finally
			{
				if (dBHelper.DBConnect.State != 0)
				{
					dBHelper.Close();
				}
			}
		}

		public WorkerList ListWorker(Common.ListWorkerType type)
		{
			foreach (WorkerList item in _ListWorker)
			{
				if (item.ListType == type)
				{
					return item;
				}
			}
			return null;
		}
	}
}
