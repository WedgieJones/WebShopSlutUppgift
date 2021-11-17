using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Webshop.BL;

namespace Webshop.UI.Pages
{
    public class ShoppingcartModel : PageModel
    {
		public ShoppingcartModel()
		{

		}

        public IEnumerable<ShoppingCart> Shoppingcart { get; set; }
        public void OnGet()
        {
        }
    }
}
