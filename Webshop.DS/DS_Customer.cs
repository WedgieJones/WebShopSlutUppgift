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
    class DS_Customer : IDataSource<Customer>
    {
        string path = @"C:\Users\Fredrik\Source\Repos\WebShopSlutUppgift\Webshop.DS\JsonFiles\Customerjson.json";
        public void Delete(Customer _object)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> LoadAll()
        {
              return JsonConvert.DeserializeObject<IEnumerable<Customer>>(File.ReadAllText(path));
        }

        public Customer LoadById(int id)
        {
            return LoadAll().SingleOrDefault(p => p.CustomerId == id);
        }

        public void Save(Customer _object)
        {
            throw new NotImplementedException();
        }

        public Customer Update(Customer item)
        {
            throw new NotImplementedException();
        }
    }
}
