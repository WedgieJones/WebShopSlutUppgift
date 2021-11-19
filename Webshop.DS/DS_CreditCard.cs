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
    class DS_CreditCard 
    {
        string path = @"C:\Users\Fredrik\Source\Repos\WebShopSlutUppgift\Webshop.DS\JsonFiles\CreditCardjson.json";
       
        public string LoadAll()
        {
            var jsonResponse = File.ReadAllText(path);
            return jsonResponse;
        }
        public IEnumerable<CreditCard> LoadAlls()
        {   
            var jsonResponse = LoadAll();
            return JsonConvert.DeserializeObject<IEnumerable<CreditCard>>(jsonResponse);
        }
      public CreditCard LoadById(int id)
        {
            return LoadAlls().SingleOrDefault(p => p.CreditCardId == id);
        }
    }
}
