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
    class DS_Customer 
    {
        string path = @"C:\Users\Friedrich Schwann\Desktop\GIT\repos\WebShopSlutUppgift\Webshop.DS\JsonFiles\Customerjson.json";
        
        public string LoadAll()
        {
            var jsonResponse = File.ReadAllText(path);
            return jsonResponse;
        }
        public IEnumerable<Customer> LoadAlls()
        {
            var jsonResponse = LoadAll();
            return JsonConvert.DeserializeObject<IEnumerable<Customer>>(jsonResponse);
        }

        public Customer LoadById(int id)
        {
            return LoadAlls().SingleOrDefault(p => p.CustomerId == id);
        }
    }
}
