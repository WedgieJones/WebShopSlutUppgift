using System;

namespace Webshop.BL
{
	public class Customer
	{
		
		public int CustomerId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string EmailAddress { get; set; }
		public CreditCard CreditCard { get; set; }
		public string FullName => FirstName + " " + LastName;
		//public List<Guid> orderList 

    }
}
