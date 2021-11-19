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
    public class DS_Product 
    {
        string path = @"C:\Users\Friedrich Schwann\Desktop\GIT\repos\WebShopSlutUppgift\Webshop.DS\JsonFiles\Productjson.json";
        
        public string LoadAll()
        {
            var jsonResponse = File.ReadAllText(path);
            return jsonResponse;
        }
    }
}
