using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Webshop.BL;
using Webshop.DA;

namespace Webshop.UI.Pages
{
    public class AllProductsModel : PageModel
    {
		private readonly DA_Product _dataAccess;

		public AllProductsModel(DA_Product dataAccess)
		{
			_dataAccess = dataAccess;
		}
        public IEnumerable<Product> Products { get; set; }
        [BindProperty(SupportsGet =true)]
        public string SortTerm { get; set; }
        public void OnGet(string searchTerm)
        {
            Products = _dataAccess.GetByName(searchTerm);
        }
        public void OnPostSort(string sortTerm)
        {
            Products = _dataAccess.SortByPrice(sortTerm);

        }
    }
}
