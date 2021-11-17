using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop.BL
{
	public class Product
	{
		public Product()
		{

		}
		public Product(int productId)
		{
			ProductId = productId;
		}

		public int ProductId { get; private set; }
		public string ProductName { get; set; }
		public string ProductDescription { get; set; }
		public decimal? CurrentPrice { get; set; }
		public string Image { get; set; }


	}

}
