using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using Webshop.BL;
using Webshop.DA;

namespace Webshop.UI.Pages
{
    public class ReceiptDetailsModel : PageModel
    {
		private readonly DA_Receipt _Receipt;

		public ReceiptDetailsModel(DA_Receipt da_Receipt)
		{
			_Receipt = da_Receipt;
		}
        public Receipt Receipt { get; set; }= new Receipt();
        public List<Product> Products { get; set; } 
        public void OnGet(Guid ReceiptId)
        {
            Receipt = _Receipt.LoadById(ReceiptId);
            Products = Receipt.Order.Products;
        }
    }
}
