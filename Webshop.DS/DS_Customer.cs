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
    public class DS_Customer : IDataSource<Customer>
    {
        //LoadAll reads the jsonfile and returns a string containing all the text in the file, and then closes the file.

        public string LoadAll()
        {
            string path = @"C:\Users\Friedrich Schwann\Desktop\GIT\repos\WebShopSlutUppgift\Webshop.DS\JsonFiles\Customerjson.json";
            var jsonResponse = File.ReadAllText(path);
            return jsonResponse;
        }
        //Not in use
		public void Save(string SerilizedItem)
		{
			throw new NotImplementedException();
		}
	}
}
