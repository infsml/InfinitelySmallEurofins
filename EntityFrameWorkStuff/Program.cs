using EntityFrameWorkStuff.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWorkStuff
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Want to save products info into database
            //EF Code first approach

            ProductsDbContext db = new ProductsDbContext();
            var pdu = db.Products.Find(4);
            pdu.Cost = 10000;
            db.SaveChanges();
        }

        private static void DeleteById(ProductsDbContext db)
        {
            var pdl = db.Products.Find(3);
            db.Products.Remove(pdl);
            db.SaveChanges();
        }

        private static void DeleteByName(ProductsDbContext db)
        {
            ShowAll(db);

            db.Products.Remove((from d in db.Products
                                where d.Name == "caim"
                                select d).First());
            db.SaveChanges();
            ShowAll(db);
        }

        private static void ShowAll(ProductsDbContext db)
        {
            var q1 = from d in db.Products
                     select d;
            foreach (var d in q1)
            {
                Console.WriteLine(d.Name);
                Console.WriteLine(d.Description);
                Console.WriteLine(d.Cost);
                Console.WriteLine("");

            }
        }

        private static void AddProductDefault(ProductsDbContext db)
        {
            Product p = new Product() { Name = "caim", Description = "demm", Cost = 40.5 };
            db.Products.Add(p);
            db.SaveChanges();
            Console.WriteLine("Done boi");
        }
    }
}
