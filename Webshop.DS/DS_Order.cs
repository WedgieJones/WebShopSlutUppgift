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
    public class DS_Order : IDataSource<Order>
    {
        string path = @"C:\Users\Friedrich Schwann\Desktop\GIT\repos\WebShopSlutUppgift\Webshop.DS\JsonFiles\Orderjson.json";
        public string LoadAll()
        {
            var jsonReponse = File.ReadAllText(path);
            return jsonReponse;

        }

        public void Save(string serializedOrder)
        {
            File.WriteAllText(path, serializedOrder);
        }

    }
}
