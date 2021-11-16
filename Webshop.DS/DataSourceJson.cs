using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop.BL;

namespace Webshop.DS
{
	class DataSourceCustomer : DataSourceJson<Customer>
	{
		public DataSourceCustomer()
			: base(@"path to customerjson")
		{ }
	}
	class DataSourceOrder : DataSourceJson<Order>
	{
		public DataSourceOrder()
			: base(@"path to orderjson")
		{ }
	}

    public class DataSourceJson<T>
	{
		private readonly string _path;

		public DataSourceJson(string path)
		{
			_path = path;
		}

		public void Delete(T _object)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<T> LoadAll(string path)
		{
			

		}

		public T LoadById(int id)
		{
			throw new NotImplementedException();
		}

		public void Save(T _object)
		{
			throw new NotImplementedException();
		}

		public T Update(T item)
		{
			throw new NotImplementedException();
		}

		
	}
}
