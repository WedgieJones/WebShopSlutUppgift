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
	public class DA_CreditCard : IDataAccess<CreditCard>
	{
		private readonly DS_CreditCard _CreditCard;
		//The constructor takes a Datasource to get access to the jsonfile through its methods.
		public DA_CreditCard(DS_CreditCard ds_CreditCard)
		{
			_CreditCard = ds_CreditCard;
		}
		//LoadAll calls on the LoadAll methos in the datasource to get a string that it deserilizes to a list of objects.
		public IEnumerable<CreditCard> LoadAll()
		{
			return JsonConvert.DeserializeObject<IEnumerable<CreditCard>>(_CreditCard.LoadAll());
		}
		//LoadById calls on LoadAll to get a list of all text in the datasource before searching for the object with a matching objectId
		//and returning a single objcet.
		public CreditCard LoadById(int customerId)
		{
			return LoadAll().SingleOrDefault(p => p.CustomerId == customerId);
		}
	}
}
