using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using Webshop.BL;
using Webshop.DA;

namespace Webshop.UI.Pages
{
    public class OrderModel : PageModel
    {
        private readonly DA_ShoppingCart _cartAccess;
        private readonly DA_Customer _customer;
        private readonly DA_Order _order;

        public OrderModel(DA_ShoppingCart cartAccess, DA_Customer da_customer, DA_Order da_order)
        {
           
            _cartAccess = cartAccess;
            _customer = da_customer;
            _order = da_order;
        }
        
        public List<Product> Products { get; set; } = new List<Product>();
        public Customer Customer { get; set; } = new Customer();
        public decimal TotalSum { get; set; }
        public Order Order { get; set; } = new Order();
        
        public void OnGet(int customerId)
        {
            var items = _cartAccess.LoadAll().ToList();
            Products.AddRange(items);
           
            Order.CustomerId = customerId;
            Order.OrderId = Guid.NewGuid();
            Order.Products = Products;
            Order.IsPaid = false;
            _order.Save(Order);
           
            _cartAccess.Delete();
            
            TotalSum = Products.Sum(p => p.CurrentPrice);

            if (customerId != 0)
            {
                Customer = _customer.LoadById(customerId);
            }

        }
    }
}
