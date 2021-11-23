using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Webshop.BL;
using Webshop.DA;

namespace Webshop.UI.Pages
{
    public class AllProductsModel : PageModel
    {
        private readonly DA_Product _dataAccess;
		private readonly DA_Customer _Customer;

		public AllProductsModel(DA_Product dataAccess, DA_Customer da_Customer)
        {
            _dataAccess = dataAccess;
			_Customer = da_Customer;
		}
        public IEnumerable<Customer> Customers { get; set; } 
        public Customer Customer { get; set; } = new Customer();
        public IEnumerable<Product> Products { get; set; } = new List<Product>();
        [BindProperty(SupportsGet = true)]
        public string SortTerm { get; set; }
        public void OnGet(string searchTerm)
        {
            Products = _dataAccess.GetByName(searchTerm);
            Customers = _Customer.LoadAll();
        }
        public void OnPostSort(string sortTerm)
        {
            Products = _dataAccess.SortByPrice(sortTerm);

        }

    }
}
