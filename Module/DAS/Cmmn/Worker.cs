namespace Cmmn
{
	public class Worker
	{
		public string ID;

		public string Name;

		public string DeptCd;

		public string Phone;

		public Worker(string id, string name)
		{
			ID = id;
			Name = name;
			Phone = "";
			DeptCd = "";
		}

		public Worker(string id, string name, string phone)
		{
			ID = id;
			Name = name;
			Phone = phone;
			DeptCd = "";
		}

		public Worker(string id, string name, string phone, string deptcd)
		{
			ID = id;
			Name = name;
			Phone = phone;
			DeptCd = deptcd;
		}
	}
}
