using System;

namespace Webshop.BL
{
	public class Customer
	{
		public Customer()
		{

		}
		public Customer(int customerId)
		{
			CustomerId = customerId;
		}
		public int CustomerId { get; private set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string EmailAddress { get; set; }
		
				
	}
}
