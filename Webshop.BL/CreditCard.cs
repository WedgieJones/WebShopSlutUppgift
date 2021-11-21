using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop.BL
{
	public class CreditCard
	{
        public readonly long CreditCardNum;

        public CreditCard(long accNum)
        {
            CreditCardNum = accNum;
        }

    }
}
