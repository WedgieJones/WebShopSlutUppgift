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
    public class DA_CreditCard
    {
        private readonly DS_CreditCard _CreditCard;

        public DA_CreditCard(DS_CreditCard ds_CreditCard)
        {
            _CreditCard = ds_CreditCard;
        }
        public IEnumerable<CreditCard> LoadAll()
        {
            
            return JsonConvert.DeserializeObject<IEnumerable<CreditCard>>(_CreditCard.LoadAll());
        }
        public CreditCard LoadById(int id)
        {
            return LoadAll().SingleOrDefault(p => p.CustomerId == id);
        }
    }
}
