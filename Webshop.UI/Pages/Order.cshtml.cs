using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

        public OrderModel(DA_ShoppingCart cartAccess, DA_Customer da_customer)
        {
            totalSum = new List<decimal?>();
            customer = new Customer();
            customerList = new List<Customer>();
            orderList = new List<Product>();
            _cartAccess = cartAccess;
            _customer = da_customer;
        }

        public List<Product> orderList { get; set; }
        public List<Customer> customerList { get; set; }
        public Customer customer { get; set; }
        public List<decimal?> totalSum { get; set; }

        public void OnGet(int id)
        {
            var items = _cartAccess.LoadAll().ToList();
            orderList.AddRange(items);

            var users = _customer.LoadAll().ToList();
            customerList.AddRange(users);

            if (id != 0)
            {
                customer = _customer.LoadById(id);
            }

        }
    }
}
