using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop.BL;
using Webshop.DS;

namespace Webshop.DA
{
    public  class DA_ShoppingCart
    {
        private readonly DS_ShoppingCart _shoppingcart;

        public DA_ShoppingCart(DS_ShoppingCart shoppingcart)
        {
            _shoppingcart = shoppingcart;
        }
        public IEnumerable<Product> LoadAll()
        {
            var jResponse = _shoppingcart.LoadAll();
            return JsonConvert.DeserializeObject<IEnumerable<Product>>(jResponse);
        }
        public void Save(Product cartItem)
        {
            var items = LoadAll().ToList();
            items.Add(cartItem);
            var serializedItems = JsonConvert.SerializeObject(items);
            _shoppingcart.Save(serializedItems);
        }
        public Product Update( )
        {

            throw new NotImplementedException();
        }



    }
}
