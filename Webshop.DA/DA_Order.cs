﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop.BL;
using Webshop.DS;

namespace Webshop.DA
{
    public class DA_Order
    {
        private readonly DS_ShoppingCart _shoppingCart;
        private readonly DS_Order _order;

        public DA_Order(DS_ShoppingCart shoppingCart, DS_Order order)
        {
            _shoppingCart = shoppingCart;
            _order = order;
        }
        public IEnumerable<Order> LoadAll()
        {
            return JsonConvert.DeserializeObject<IEnumerable<Order>>(_order.LoadAll());
        }
        public void Save(Order order)
        {
            var items = LoadAll().ToList();
            items.Add(order);
            var serializedItems = JsonConvert.SerializeObject(items);
            _order.Save(serializedItems);
        }
        public void Delete() 
        { 
            _shoppingCart.Delete(); 
        }
        //public void Save(Order order)
        //{
        //    var serilizedOrder = JsonConvert.SerializeObject(order);
        //    _order.Save(serilizedOrder);

        //}
        public IEnumerable<Order> GetById(Guid Orderid)
        {
            return (IEnumerable<Order>)LoadAll().SingleOrDefault(p => p.OrderId.Equals(Orderid));
            //return LoadAll().Where(Guid.ToString().Equals(Orderid));
        }

        //public Dictionary()
        //{
        //    if (OrderDictionary.ContainsKey(customer))
        //    {
        //        return OrderDictionary[customer];
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}
    }
}