using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop.BL
{
	public class Order
	{
        
        public Guid OrderId { get; set; }

        [Required]
        public int? CustomerId { get; set; }
		public List<Product> Products { get; set; }
        public bool IsPaid { get; set; }

      

    }
}
