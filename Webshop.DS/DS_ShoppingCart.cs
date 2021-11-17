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
    internal class DS_ShoppingCart : IDataSource<ShoppingCart>
    {
        string path = @"C:\Users\Friedrich Schwann\Desktop\GIT\repos\WebShopSlutUppgift\Webshop.DS\JsonFiles\ShoppingCartjson.json";
        public void Delete(ShoppingCart _object)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ShoppingCart> LoadAll()
        {
            return JsonConvert.DeserializeObject<IEnumerable<ShoppingCart>>(File.ReadAllText(path));
        }

        public ShoppingCart LoadById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(ShoppingCart _object)
        {
            throw new NotImplementedException();
        }

        public ShoppingCart Update(ShoppingCart item)
        {
            throw new NotImplementedException();
        }
    }
}
