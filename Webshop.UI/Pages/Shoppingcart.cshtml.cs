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
        private readonly DA_Product products;
        private readonly DA_ShoppingCart shoppingCart;

        public ShoppingcartModel(DA_Product _Products, DA_ShoppingCart _ShoppingCart)
		{
            cartList = new List<Product>();
            products = _Products;
            shoppingCart = _ShoppingCart;
        }

        //Save method måste generea en lista från json sen lägga till ny product

        public List<Product> cartList { get; set; }
        public void OnGet(int id)
        {
            var items = shoppingCart.LoadAll().ToList();

            if (items.Count != 0)
            { 
                cartList.AddRange(items);
            }

            if (id != 0)
            {
                var cartItem = products.GetById(id);
                cartList.Add(cartItem);
                shoppingCart.Save(cartItem);
            }

            //samtidigt spara i json
            //=> dataAcceess = Get product by ID
            //add to list.
        }


    }
}
