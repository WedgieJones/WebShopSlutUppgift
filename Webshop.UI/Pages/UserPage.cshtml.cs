using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using Webshop.BL;
using Webshop.DA;

namespace Webshop.UI.Pages
{
    public class UserPageModel : PageModel
    {
		private readonly DA_Customer _Customer;
		private readonly DA_Order _Order;
		private readonly DA_Receipt _Receipt;

		public UserPageModel(DA_Customer da_Customer, DA_Order da_Order, DA_Receipt da_Receipt)
		{
			_Customer = da_Customer;
			_Order = da_Order;
			_Receipt = da_Receipt;
		}

        [BindProperty(SupportsGet = true)]
        public int CustomerId { get; set; }
        public List<Customer> CustomerList { get; set; } = new List<Customer>();
        public Customer Customer { get; set; } = new Customer();
        public List<Order> Orders { get; set; } = new List<Order>();
        public List<Receipt> Receipts { get; set; } = new List<Receipt>();

        public void OnGet(int CustomerId)
        {
            CustomerList = _Customer.LoadAll().ToList();
            Customer = _Customer.LoadById(CustomerId);
            Orders = _Order.GetByCustomerIsPaid(CustomerId);
            Receipts = _Receipt.LoadByCustomerId(CustomerId);
        }

    }
}
