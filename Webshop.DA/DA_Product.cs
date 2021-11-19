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
	public class DA_Product
	{
		private readonly DS_Product _dataSource;

		public DA_Product(DS_Product dataSource)
		{
			_dataSource = dataSource;
		}

		public IEnumerable<Product> LoadAll()
		{
			return JsonConvert.DeserializeObject<IEnumerable<Product>>(_dataSource.LoadAll());
		}
		public Product GetById(int id)
		{
			return LoadAll().SingleOrDefault(p => p.ProductId == id);
		}
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
