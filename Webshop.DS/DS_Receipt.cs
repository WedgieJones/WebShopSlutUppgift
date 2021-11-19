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
    public class DS_Receipt 
    {
        string path = @"C:\Users\Fredrik\Source\Repos\WebShopSlutUppgift\Webshop.DS\JsonFiles\Receiptsjson.json";
        
        public string LoadAll()
        {   
            var jsonResponse = File.ReadAllText(path);
            return jsonResponse;
        }

        public IEnumerable<Receipts> LoadAlls()
        {
            var jsonResponse = LoadAll();
            return JsonConvert.DeserializeObject<IEnumerable<Receipts>>(jsonResponse);
        }

        public Receipts LoadById(int id)
        {
            return LoadAlls().SingleOrDefault(p => p.ReceiptId == id);
        }
    }
}
