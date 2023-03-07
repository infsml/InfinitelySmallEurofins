using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqLabs
{
    internal class ObjectLinqs
    {
        static void Main(string[] args)
        {
            List<Product> products = ProductsDB.GetProducts();
            //1. List all products whose price in between 50K to 80K
            Console.WriteLine("1. List all products whose price in between 50K to 80K");
            var q1 = from p in products
                     where p.Price >= 50000 && p.Price <= 80000
                     select p.Name;
            foreach(var i in q1) { Console.WriteLine(i); }
            //2. Extract all products belongs to Laptops catagory
            Console.WriteLine("2. Extract all products belongs to Laptops catagory");
            var q2 = from p in products
                       where p.Catagory.Name == "Laptops"
                       select p.Name;
            foreach(var i in q2) { Console.WriteLine(i); }

            //3. Extract/Show Product Name and Catagory Name only
            Console.WriteLine("3. Extract/Show Product Name and Catagory Name only");
            var q3 = from p in products
                     select new { pn = p.Name, cn = p.Catagory.Name };
            foreach(var i in q3) { Console.WriteLine($"Product {i.pn} Category {i.cn}"); }

            //4. Show the costliest product name 
            Console.WriteLine("4. Show the costliest product name ");
            var q4 = (from p in products
                     orderby p.Price descending
                     select p.Name).First();
            Console.WriteLine(q4);
            //5. Show the cheepest product name and its price
            Console.WriteLine("5. Show the cheepest product name and its price");
            var q5 = (from p in products
                      orderby p.Price
                      select p.Name).First();
            Console.WriteLine(q5);
            //6. Show the 2nd and 3rd product details
            Console.WriteLine("6. Show the 2nd and 3rd product details");
            var q6 = (from p in products
                      select p.Name).Skip(1).Take(2);
            foreach(var i in q6) { Console.WriteLine(i); }
            
            //7. List all products in assending order of their price
            Console.WriteLine("7. List all products in assending order of their price");
            var q7 = (from p in products
                      orderby p.Price
                      select p.Name);
            foreach(var i in q7) { Console.WriteLine(i); }
            //8. Count the no. of products belong to Tablets
            Console.WriteLine("8. Count the no. of products belong to Tablets");
            var q8 = (from p in products
                     where p.Catagory.Name == "Tablets"
                     select p.Name).Count();
            Console.WriteLine(q8);
            //9. Show which catagory has costly product
            Console.WriteLine("9. Show which catagory has costly product");
            var q9 = (from p in products
                      orderby p.Price descending
                      select p.Catagory.Name).First();
            Console.WriteLine(q9);
            //10. Show which catagory has less products
            Console.WriteLine("10. Show which catagory has less products");
            var q10 = (from p in products
                       group p by p.Catagory into grp
                      orderby grp.Count()
                      select grp.Key.Name).First();
            Console.WriteLine(q10);


            /*11. Extract the Product Details based on the catagory and show as below

            Laptops
                Dell XPS 13
                HP 430
            Mobiles
                IPhone 6
                Galaxy S6
            Tablets
                IPad Pro
            */
            Console.WriteLine("11. Extract the Product Details based on the catagory and show as below");
            var q11 = (from p in products
                       group p by p.Catagory into grp
                       select grp);
            foreach(var i in q11) { 
                Console.WriteLine(i.Key.Name);
                foreach(var j in i)
                {
                    Console.WriteLine("\t"+j.Name);
                }
            }
            //12. Extract the Product count based on the catagory and show as below
            Console.WriteLine("12. Extract the Product count based on the catagory and show as below");
            /*
            Laptops : 2
            Mobiles: 2
            Tablets: 1
            */
            var q12 = (from p in products
                       group p by p.Catagory into grp
                       select new { name = grp.Key.Name, cnt = grp.Count() });
            foreach(var i in q12)
            {
                Console.WriteLine($"{i.name}: {i.cnt}");
            }
        }

    }
    class ProductsDB
    {
        public static List<Product> GetProducts()
        {
            Catagory cat1 = new Catagory { CatagoryID = 101, Name = "Laptops" };
            Catagory cat2 = new Catagory { CatagoryID = 201, Name = "Mobiles" };
            Catagory cat3 = new Catagory { CatagoryID = 301, Name = "Tablets" };

            Product p1 = new Product { ProductID = 1, Name = "Dell XPS 13", Catagory = cat1, Price = 90000 };
            Product p2 = new Product { ProductID = 2, Name = "HP 430", Catagory = cat1, Price = 50000 };
            Product p3 = new Product { ProductID = 3, Name = "IPhone 6", Catagory = cat2, Price = 80000 };
            Product p4 = new Product { ProductID = 4, Name = "Galaxy S6", Catagory = cat2, Price = 74000 };
            Product p5 = new Product { ProductID = 5, Name = "IPad Pro", Catagory = cat3, Price = 44000 };

            cat1.Products.Add(p1);
            cat1.Products.Add(p2);
            cat2.Products.Add(p3);
            cat2.Products.Add(p4);
            cat3.Products.Add(p5);

            List<Product> products = new List<Product>();
            products.Add(p1);
            products.Add(p2);
            products.Add(p3);
            products.Add(p4);
            products.Add(p5);

            return products;
        }
    }
    class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public Catagory Catagory { get; set; }
    }
    class Catagory
    {
        public int CatagoryID { get; set; }
        public string Name { get; set; }
        public List<Product> Products = new List<Product>();
    }
}





