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
    public class ShoppingcartModel : PageModel
    {
        private readonly DA_Product _products;
        private readonly DA_ShoppingCart _shoppingCart;
        private readonly DA_Customer _customer;

        public ShoppingcartModel(DA_Product Products, DA_ShoppingCart ShoppingCart, DA_Customer Customer)
		{
            CartList = new List<Product>();
            _products = Products;
            _shoppingCart = ShoppingCart;
            _customer = Customer;
        }
        public List<Product> CartList { get; set; }
        public IEnumerable<Customer> CustomerList { get; set; }
        public Customer Customers { get; set; }
        public void OnGet(int id)
        {
            CustomerList = _customer.LoadAll();

            var items = _shoppingCart.LoadAll().ToList();


            if (items.Count != 0)
            { 
                CartList.AddRange(items);
            }

            if (id != 0)
            {
                var cartItem = _products.GetById(id);
                CartList.Add(cartItem);
                _shoppingCart.Save(cartItem);
            }
        }
       
        //public IActionResult OnPost()
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // do something
        //        return RedirectToPage("Contact");
        //    }
        //    else
        //    {
        //        return Page();
        //    }
        //}
    }
}
