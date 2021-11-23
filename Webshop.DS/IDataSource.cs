using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop.DS
{
	public interface IDataSource<T>
	{
		public string LoadAll();
		public void Save(string SerilizedItem);
		
	}
}
