using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop.BL;
using Webshop.DS;

namespace Webshop.DA
{
	public class DA_Customer : IDataAccess<Customer>
	{
		private readonly DS_Customer _customer;

		public DA_Customer(DS_Customer Customer)
		{
			_customer = Customer;
		}
		public IEnumerable<Customer> LoadAll()
		{
			var jsonResponse = _customer.LoadAll();
			return JsonConvert.DeserializeObject<IEnumerable<Customer>>(jsonResponse);
		}

		public Customer LoadById(int id)
		{
			return LoadAll().SingleOrDefault(p => p.CustomerId == id);
		}
	}
}
