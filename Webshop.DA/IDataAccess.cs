using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop.DA
{
	public interface IDataAccess <T>
	{
		public IEnumerable<T> LoadAll();
		public T Update(T item);
		public T LoadById(int id);
		public void Save(T _object);
		public void Delete(T _object);

	}
}
