using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop.BL;

namespace Webshop.DS
{
    class DS_Order : IDataSource<Order>
    {
        string path = @"C:\Users\Fredrik\Source\Repos\WebShopSlutUppgift\Webshop.DS\JsonFiles\Orderjson.json";
        public void Delete(Order _object)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> LoadAll()
        {
            return JsonConvert.DeserializeObject<IEnumerable<Order>>(File.ReadAllText(path));
        }

        public Order LoadById(int id)
        {
            return LoadAll().SingleOrDefault(p => p.OrderId == id);
        }

        public void Save(Order _object)
        {
            throw new NotImplementedException();
        }

        public Order Update(Order item)
        {
            throw new NotImplementedException();
        }
    }
}
