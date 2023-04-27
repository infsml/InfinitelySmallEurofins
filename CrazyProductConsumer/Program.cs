using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using Newtonsoft.Json;

namespace CrazyProductConsumer
{
    public class Program
    {
        static void Main(string[] args)
        {
            string baseURL = "https://localhost:44366/api/CrazyProducts";
            HttpClient client = new HttpClient();
            //string prods = client.GetStringAsync(baseURL).GetAwaiter().GetResult();
            //Console.WriteLine(prods);
            var prods = client.GetAsync(baseURL).Result;
            if(prods.StatusCode==System.Net.HttpStatusCode.OK)
            {
                var content = prods.Content;
                //var pList = content.ReadAsAsync<List<Product>>().Result;

            }
        }
    }
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Category { get; set; }
        public string Country { get; set; }
    }
}
