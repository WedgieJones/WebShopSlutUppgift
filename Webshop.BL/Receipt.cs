using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop.BL
{
	public class Receipt
	{
        public int ReceiptId { get; set; }
        public Order Order { get; set; }
        public DateTimeOffset DateTime { get; set; }
        public CreditCard CreditCard { get; set; }

    }
}
