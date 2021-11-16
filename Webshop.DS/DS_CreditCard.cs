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
    class DS_CreditCard : IDataSource<CreditCard>
    {
        string path = @"C:\Users\Fredrik\Source\Repos\WebShopSlutUppgift\Webshop.DS\JsonFiles\CreditCardjson.json";
        public void Delete(CreditCard _object)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CreditCard> LoadAll()
        {
            return JsonConvert.DeserializeObject<IEnumerable<CreditCard>>(File.ReadAllText(path));
        }

        public CreditCard LoadById(int id)
        {
            return LoadAll().SingleOrDefault(p => p.CreditCardId == id);
        }

        public void Save(CreditCard _object)
        {
            throw new NotImplementedException();
        }

        public CreditCard Update(CreditCard item)
        {
            throw new NotImplementedException();
        }
    }
}
