using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using Webshop.BL;
using Webshop.DA;

namespace Webshop.UI.Pages
{
    public class OrderDetailsModel : PageModel
    {
		private readonly DA_Order _Order;
        public decimal TotalSum;
		public OrderDetailsModel(DA_Order da_Order)
		{
			_Order = da_Order;
		}
        public Order Order { get; set; } = new Order();
        public List<Product> Products { get; set; } 
        
        public void OnGet(Guid OrderId)
        {
            Order = _Order.GetById(OrderId);
            Products = Order.Products;

            TotalSum = Products.Sum(p => p.CurrentPrice);
        }
    }
}
