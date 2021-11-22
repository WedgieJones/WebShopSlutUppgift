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
            order = new Order();
            totalSum = new List<decimal?>();
            customer = new Customer();
            customerList = new List<Customer>();
            orderList = new List<Product>();
            _cartAccess = cartAccess;
            _customer = da_customer;
            _order = da_order;
        }

        public List<Product> orderList { get; set; }
        public List<Customer> customerList { get; set; }
        public Customer customer { get; set; }
        public List<decimal?> totalSum { get; set; }
        public Order order { get; set; }

        public void OnGet(int customerId)
        {
            var items = _cartAccess.LoadAll().ToList();
            orderList.AddRange(items);
           
            order.CustomerId = customerId;
            order.OrderId = Guid.NewGuid();
            order.Products = orderList;
            order.IsPaid = false;
            _order.Save(order);
            var guidOrder = order.OrderId.ToString();

            if (customerId != 0)
            {
                customer = _customer.LoadById(customerId);
            }

        }
    }
}
