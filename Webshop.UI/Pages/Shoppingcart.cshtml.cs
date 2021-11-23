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
        //This is the shoppingcart. The user can add products and choose which customer it is to go  to Order.
        private readonly DA_Product _products;
        private readonly DA_ShoppingCart _shoppingCart;
        private readonly DA_Customer _customer;

        public ShoppingcartModel(DA_Product Products, DA_ShoppingCart ShoppingCart, DA_Customer Customer)
		{
            _products = Products;
            _shoppingCart = ShoppingCart;
            _customer = Customer;
        }
        public List<Product> CartList { get; set; } = new List<Product>();
        public IEnumerable<Customer> CustomerList { get; set; }
        public void OnGet(int id)
        {
            CustomerList = _customer.LoadAll();

            var items = _shoppingCart.LoadAll();

            //checking to see if the Items list has any products to add to the CartList.
            if (items != null && items.Any())
            { 
                CartList.AddRange(items);
            }

            //Getting the product using ID and adding it to the cartlist.
            if (id != 0)
            {
                var cartItem = _products.GetById(id);
                CartList.Add(cartItem);
                _shoppingCart.Save(cartItem);
            }
        }
       
    }
}
