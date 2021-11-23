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
    public class DA_Receipt : IDataAccess<Receipt>
    {
        private readonly DS_Receipt _Receipt;
        //The constructor takes a Datasource to get access to the jsonfile through its methods.
        public DA_Receipt(DS_Receipt ds_Receipt)
        {
            _Receipt = ds_Receipt;
        }
        //LoadAll calls on the LoadAll methos in the datasource to get a string that it deserilizes to a list of objects.
        public IEnumerable<Receipt> LoadAll()
        {
            return JsonConvert.DeserializeObject<IEnumerable<Receipt>>(_Receipt.LoadAll());
        }
        //Save copies the existing jsonfile to a variable, checking to see if the file is empty or missing first. If it is missing a new list i created
        //Then it adds the new Receipt to the list and serializes the list back to jsonstring and calling the save method in the dataaccess. 
        public void Save(Receipt newReceipt)
        {
            var items = LoadAll()?.ToList() ?? new List<Receipt>(); ;
            items.Add(newReceipt);
            var serializedItems = JsonConvert.SerializeObject(items);
            _Receipt.Save(serializedItems);
        }
        //LoadById calls on LoadAll to get a list of all text in the datasource before searching for the object with a matching objectId
        //and returning a single objcet.
        public Receipt LoadById(Guid id)
        {
            return LoadAll().SingleOrDefault(p => p.ReceiptId == id);
        }
        //LoadbycustomerId calls on LoadAll to get all text in the REceiptjson. Then it searches for all objects with the matching customerId
        //and return a list of receipts belonging to that customer.
        public List<Receipt> LoadByCustomerId(int CustomerId)
		{
            var Receipts = LoadAll().Where(p => p.Order.CustomerId == CustomerId);
            return Receipts.ToList();
		}
    }
}
