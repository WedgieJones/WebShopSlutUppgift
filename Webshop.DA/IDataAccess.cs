using System.Collections.Generic;
using Webshop.BL;

namespace Webshop.DA
{
	public interface IDataAccess<T>
	{
		IEnumerable<T> LoadAll();
		
	}
}