using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop.BL
{
	public class Order
	{
		//public int OrderId { get; private set; }
		//public DateTimeOffset? OrderDate { get; private set; }

		public List<Product> products { get; set; }
		public Customer Customer { get; set; }	
		public void AddProduct(Product product)
		{
			products.Add(product);
		}

	}
}
