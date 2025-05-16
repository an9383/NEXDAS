using System.Collections.ObjectModel;

namespace Cmmn
{
	public class WorkerList
	{
		private Collection<Worker> _list;

		public Common.ListWorkerType ListType;

		public Collection<Worker> List => _list;

		public Worker this[string str]
		{
			get
			{
				foreach (Worker item in _list)
				{
					if (item.ID == str)
					{
						return item;
					}
					if (item.Name == str)
					{
						return item;
					}
				}
				return null;
			}
		}

		public string AllWorkerName
		{
			get
			{
				string text = "";
				foreach (Worker item in _list)
				{
					text = ((!(text == "")) ? (text + ", " + item.Name) : (text + item.Name));
				}
				return text;
			}
		}

		public string AllWorkerID
		{
			get
			{
				string text = "";
				foreach (Worker item in _list)
				{
					text = ((!(text == "")) ? (text + ", " + item.ID) : (text + item.ID));
				}
				return text;
			}
		}

		public int WorkerCount => _list.Count;

		public WorkerList()
		{
			_list = new Collection<Worker>();
		}

		public WorkerList(Common.ListWorkerType group)
		{
			_list = new Collection<Worker>();
			ListType = group;
		}

		public void Clear()
		{
			_list.Clear();
		}

		public void AddWorker(string id, string name)
		{
			bool flag = false;
			foreach (Worker item in _list)
			{
				if (item.ID == id)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				_list.Add(new Worker(id, name));
			}
		}

		public void AddWorker(string id, string name, string phone)
		{
			bool flag = false;
			foreach (Worker item in _list)
			{
				if (item.ID == id)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				_list.Add(new Worker(id, name, phone));
			}
		}

		public void RemoveWorker(string id)
		{
			Worker worker = null;
			foreach (Worker item in _list)
			{
				if (item.ID == id)
				{
					worker = item;
					break;
				}
			}
			if (worker != null)
			{
				_list.Remove(worker);
			}
		}
	}
}
