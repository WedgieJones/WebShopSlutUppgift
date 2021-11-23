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
		//The constructor takes a Datasource to get access to the jsonfile through its methods.
		public DA_Customer(DS_Customer Customer)
		{
			_customer = Customer;
		}
		//LoadAll calls on the LoadAll methos in the datasource to get a string that it deserilizes to a list of objects.
		public IEnumerable<Customer> LoadAll()
		{
			var jsonResponse = _customer.LoadAll();
			return JsonConvert.DeserializeObject<IEnumerable<Customer>>(jsonResponse);
		}
		//LoadById calls on LoadAll to get a list of all text in the datasource before searching for the object with a matching objectId
		//and returning a single objcet.
		public Customer LoadById(int id)
		{
			return LoadAll().SingleOrDefault(p => p.CustomerId == id);
		}
	}
}
