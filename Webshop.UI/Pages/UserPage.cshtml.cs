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

		public UserPageModel(DA_Customer da_Customer)
		{
			_Customer = da_Customer;
		}

        [BindProperty(SupportsGet = true)]
        public int CustomerId { get; set; }
        public IEnumerable<Customer> CustomerList { get; set; } = new List<Customer>();
        public void OnGetCustomerId(int CustomerId)
        {
            CustomerList = _Customer.LoadAll();
        }

    }
}
