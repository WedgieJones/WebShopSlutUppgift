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
	public class DA_Product : IDataAccess<Product>
	{
		private readonly DS_Product _dataSource;
		//The constructor takes a Datasource to get access to the jsonfile through its methods.
		public DA_Product(DS_Product dataSource)
		{
			_dataSource = dataSource;
		}
		//LoadAll calls on the LoadAll methos in the datasource to get a string that it deserilizes to a list of objects.
		public IEnumerable<Product> LoadAll()
		{
			return JsonConvert.DeserializeObject<IEnumerable<Product>>(_dataSource.LoadAll());
		}
		//LoadById calls on LoadAll to get a list of all text in the datasource before searching for the object with a matching objectId
		//and returning a single objcet.
		public Product LoadById(int id)
		{
			return LoadAll().SingleOrDefault(p => p.ProductId == id);
		}
		//GetByName is the searchmethod. First it checks to see if the string parameter is null or empty to avoid error.
		//Then is calls on the LoadAll method to get a full list of all objects in the datasource. Then it checks to see if the variable matches any part of the 
		//of the chosen object property. If it finds this it will return a list of all objects matching the search criteria.
		public IEnumerable<Product> GetByName(string searchTerm)
		{
			if (string.IsNullOrEmpty(searchTerm))
			{
				return LoadAll();
			}
			else
			{
				return LoadAll().Where(p => p.ProductName.Contains(searchTerm));
			}
		}
		//First the LoadAll is called to get a list to sort.
		//The SortByPrice method gets a string value of "low" or "high". If it is low it will sort the chosen property in the list in ascending order
		//otherwise it will sort it descending. Only having 2 options to sort by I chose the if as it is one or the other.
		public IEnumerable<Product> SortByPrice(string sortTerm)
		{
			if (sortTerm == "low")
			{
				return LoadAll().OrderBy(p => p.CurrentPrice);
			}
			else
			{
				return LoadAll().OrderByDescending(p => p.CurrentPrice);
			}
		}
	}
}
