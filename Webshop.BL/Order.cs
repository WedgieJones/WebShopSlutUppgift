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
        //public int OrderId { get; private set; }
        //public DateTimeOffset? OrderDate { get; private set; }
        //public Customer Customer { get; set; }
        public Guid OrderId { get; set; }

        [Required]
        public int? CustomerId { get; set; }
		public List<Product> Products { get; set; }
        public bool IsPaid { get; set; }

        //En order måste innehålla en property IsPaid som kan togglas när kunden har betalat.

    }
}
