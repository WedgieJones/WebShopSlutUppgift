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
    public  class DA_ShoppingCart : IDataAccess<ShoppingCart>
    {
        private readonly DS_ShoppingCart _shoppingcart;
        //The constructor takes a Datasource to get access to the jsonfile through its methods.
        public DA_ShoppingCart(DS_ShoppingCart shoppingcart)
        {
            _shoppingcart = shoppingcart;
        }
        //LoadAll calls on the LoadAll methos in the datasource to get a string that it deserilizes to a list of objects.
        public IEnumerable<Product> LoadAll()
        {
            var jResponse = _shoppingcart.LoadAll();
            return JsonConvert.DeserializeObject<IEnumerable<Product>>(jResponse);
        }
        //Save copies the existing jsonfile to a variable, checking to see if the file is empty or missing first. If it is missing a new list i created
        //Then it adds the new product to the shoppingcart and serializes the list back to jsonstring and calling the save method in the dataaccess.
        public void Save(Product cartItem)
        {
            var items = LoadAll()?.ToList() ?? new List<Product>();
            items.Add(cartItem);
            var serializedItems = JsonConvert.SerializeObject(items);
            _shoppingcart.Save(serializedItems);
        }
        //Calls the Delete method in the dataaccess class
        public void Delete() 
        {
            _shoppingcart.Delete(); 
        }
        //Not in use
		IEnumerable<ShoppingCart> IDataAccess<ShoppingCart>.LoadAll()
		{
			throw new NotImplementedException();
		}
	}
}
