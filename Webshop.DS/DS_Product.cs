﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop.BL;

namespace Webshop.DS
{
    public class DS_Product : IDataSource<Product>
    {
        string path = @"C:\Users\Friedrich Schwann\Desktop\GIT\repos\WebShopSlutUppgift\Webshop.DS\JsonFiles\Productjson.json";
        public void Delete(Product _object)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> LoadAll()
        {

            return JsonConvert.DeserializeObject<IEnumerable<Product>>(File.ReadAllText(path));
        }

        public Product LoadById(int id)
        {
           return LoadAll().SingleOrDefault(p => p.ProductId == id);
        }

        public void Save(Product _object)
        {
            throw new NotImplementedException();
        }

        public Product Update(Product item)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Product> SortByPrice(string sortTerm)
        {
            //if (string.IsNullOrEmpty(sortTerm))
            //{
            //    return GetByName(null);
            //}
            //else
            if(sortTerm == "low")
            {
                return JsonConvert.DeserializeObject<IEnumerable<Product>>(File.ReadAllText(path)).OrderBy(p => p.CurrentPrice);
            }
            else
            {
                return JsonConvert.DeserializeObject<IEnumerable<Product>>(File.ReadAllText(path)).OrderByDescending(p => p.CurrentPrice);
            }
            
        }

        public IEnumerable<Product> GetByName(string name)
        {

            if (string.IsNullOrEmpty(name))
            {
                return LoadAll();
            }
            else
            {
                return JsonConvert.DeserializeObject<IEnumerable<Product>>(File.ReadAllText(path)).Where(p => p.ProductName.Contains(name));
            }

        }
    }
}
