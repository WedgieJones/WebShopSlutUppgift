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
    public class DA_Order : IDataAccess<Order>
    {
        private readonly DS_ShoppingCart _shoppingCart;
        private readonly DS_Order _order;
        //The constructor takes two Datasources to get access to the jsonfile through its methods. The orderobjects needs access to shoppingcart and order.
        public DA_Order(DS_ShoppingCart shoppingCart, DS_Order order)
        {
            _shoppingCart = shoppingCart;
            _order = order;
        }
        //LoadAll calls on the LoadAll methos in the datasource to get a string that it deserilizes to a list of objects.
        public IEnumerable<Order> LoadAll()
        {
            return JsonConvert.DeserializeObject<IEnumerable<Order>>(_order.LoadAll());
        }
        //Save copies the existing jsonfile to a variable, checking to see if the file is empty or missing first. If it is missing a new list i created
        //Then it adds the new Receipt to the list and serializes the list back to jsonstring and calling the save method in the dataaccess. 
        public void Save(Order order)
        {
            var items = LoadAll()?.ToList()?? new List<Order>();
            items.Add(order);
            var serializedItems = JsonConvert.SerializeObject(items);
            _order.Save(serializedItems);
        }
        public void Delete() 
        { 
            _shoppingCart.Delete(); 
        }
        //LoadById calls on LoadAll to get a list of all text in the datasource before searching for the object with a matching objectId
        //and returning a single objcet.
        public Order LoadById(Guid Orderid)
        {
            return LoadAll().SingleOrDefault(p => p.OrderId == Orderid);
        }
        //LoadById calls on LoadAll to get a list of all text in the datasource before searching for the object with a matching objectId
        //and returning a single objcet.
        public List<Order> GetByCustomerId(int CustomerId)
        {
            return LoadAll().Where(p => p.CustomerId == CustomerId).ToList();
        }
        //LoadById calls on LoadAll to get a list of all text in the datasource before searching for the object with a matching objectId
        //and returning a single objcet.
        public List<Order> GetByisPaid()
		{
            var orders = LoadAll().Where(p => p.IsPaid == false).ToList();
            return orders;
        }
        //LoadById calls on LoadAll to get a list of all text in the datasource before searching for the object with a matching objectId
        //and returning a single objcet.
        public List<Order> GetByCustomerIsPaid(int CustomerId)
        {
            var orders = GetByisPaid().FindAll(p => p.CustomerId == CustomerId);
            return orders;
        }
        //The UpdateOrder changes the isPaid property to match the incoming variable. First it calls the LoadAll to get a list of all objects 
        //then it changes the desired property and serilizes the list before loading back to the datasource via the Save method
        public void UpdateOrder(Guid orderId, bool isPaid)
		{
			var jsonList = LoadAll();
			var order = jsonList.Single(p => p.OrderId.Equals(orderId));
            order.IsPaid = isPaid;
            var serializedItems = JsonConvert.SerializeObject(jsonList);
            _order.Save(serializedItems);
        }

	}
}
