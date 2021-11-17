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

		public IEnumerable<Product> Products()
		{
			return _dataSource.LoadAll();
			
		}
		public IEnumerable<Product> GetByName(string productname)
		{
			return _dataSource.GetByName(productname);
		}
		public IEnumerable<Product> SortByPrice(string sortTerm)
		{
			return _dataSource.SortByPrice(sortTerm);
		}
	}
}
