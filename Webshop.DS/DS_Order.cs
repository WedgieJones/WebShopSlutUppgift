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
    class DS_Order
    {
        string path = @"C:\Users\Fredrik\Source\Repos\WebShopSlutUppgift\Webshop.DS\JsonFiles\Orderjson.json";
        public string LoadAll()
        {
            var jsonReponse = File.ReadAllText(path);
            return jsonReponse;

        }

        public IEnumerable<Order> LoadAlls()
        {   
            var jsonResponse = LoadAll();
            return JsonConvert.DeserializeObject<IEnumerable<Order>>(jsonResponse);
        }

        //public Order LoadById(int id)
        //{
        //    return LoadAll().SingleOrDefault(p => p. == id);
        //}
    }
}
