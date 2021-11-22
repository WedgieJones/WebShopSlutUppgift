using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop.BL;
using Webshop.DS;

namespace Webshop.DA
{
    public class DA_Receipt
    {
        private readonly DS_Receipt _Receipt;
        public DA_Receipt(DS_Receipt ds_Receipt)
        {
            _Receipt = ds_Receipt;
        }
        public IEnumerable<Receipt> LoadAll()
        {
            return JsonConvert.DeserializeObject<IEnumerable<Receipt>>(_Receipt.LoadAll());
        }

        public void Save(Receipt newReceipt)
        {
            var items = LoadAll().ToList();
            items.Add(newReceipt);
            var serializedItems = JsonConvert.SerializeObject(items);
            _Receipt.Save(serializedItems);
        }

        public Receipt LoadById(Guid id)
        {
            return LoadAll().SingleOrDefault(p => p.ReceiptId == id);
        }
    }
}
