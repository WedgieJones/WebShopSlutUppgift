using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using Webshop.BL;
using Webshop.DA;

namespace Webshop.UI.Pages
{
    public class ReceiptDetailsModel : PageModel
    {
        //Shows the details of the Receipt after the user has chosen it in Userpage.
		private readonly DA_Receipt _Receipt;

		public ReceiptDetailsModel(DA_Receipt da_Receipt)
		{
			_Receipt = da_Receipt;
		}
        public Receipt Receipt { get; set; }= new Receipt();
        public decimal TotalSum;
        public List<Product> Products { get; set; } 
        public void OnGet(Guid ReceiptId)
        {
            //Gathering info to display on HTMLpage
            Receipt = _Receipt.LoadById(ReceiptId);
            Products = Receipt.Order.Products;
            TotalSum = Products.Sum(p => p.CurrentPrice);

        }
    }
}
