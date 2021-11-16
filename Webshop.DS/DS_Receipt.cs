using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop.BL;

namespace Webshop.DS
{
    public class DS_Receipt : IDataSource<Receipts>
    {
        string path = @"C:\Users\Fredrik\Source\Repos\WebShopSlutUppgift\Webshop.DS\JsonFiles\Receiptsjson.json";
        public void Delete(Receipts _object)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Receipts> LoadAll()
        {
            return JsonConvert.DeserializeObject<IEnumerable<Receipts>>(path);
        }

        public Receipts LoadById(int id)
        {
            return LoadAll().SingleOrDefault(p => p.ReceiptId == id);
        }

        public void Save(Receipts _object)
        {
            throw new NotImplementedException();
        }

        public Receipts Update(Receipts item)
        {
            throw new NotImplementedException();
        }
    }
}
