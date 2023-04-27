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

            foreach(var i in db.Products)Console.WriteLine(i.Category);


            /*db.Database.Log = Console.WriteLine;

            string sqlUpd = "update products set cost = cost + 100";
            db.Database.ExecuteSqlCommand(sqlUpd);
            
            /*var allCustomer = db.People.OfType<Customer>().ToList();
            foreach(var i in allCustomer) Console.WriteLine(i.Name,i.CustomerType);
            var allSuplier = db.People.OfType<Supplier>().ToList();
            foreach(var i in allSuplier) Console.WriteLine(i.Name,i.GST);*/
            Console.WriteLine("Done..");
        }

        private static void Add1Cus1Sup(ProductsDbContext db)
        {
            var c = new Customer() { CustomerType = "gold", Email = "hehe", Name = "c1", Discount = 8, Mobile = "678",PersonId=12 };
            db.People.Add(c);
            var s = new Supplier() { Email = "dfgh", Name = "alfanso", GST = "jfldfj", Mobile = "30", Rating = 60, PersonId = 22, Address = new Address() };
            db.People.Add(s);
            db.SaveChanges();
        }

        private static void JoinRetrieve(ProductsDbContext db)
        {
            /*var q = from d in db.Products
                                join c in db.Categories on d.Category equals c
                                select new { a = c.Name, b = d };
                        foreach(var d in q)
                        {
                            Console.WriteLine($"{d.b.Name}\t{d.b.Cost}\t{d.a}");
                        }*/

            var q = from d in db.Products //.Include("Category")
                    select d;
            foreach (var d in q)
            {
                Console.WriteLine($"{d.Name}\t{d.Cost}\t{(d.Category == null ? "null" : d.Category.Name)}");
            }
        }

        private static void AddProductExistingCat(ProductsDbContext db)
        {
            Category c = db.Categories.First();
            Product p = new Product() { Name = "Phone2", Description = "Phone only ra", Category = c, Cost = 7410, Owner = "Not me" };
            db.Products.Add(p);
            db.SaveChanges();
        }

        private static void AddProdWithCat(ProductsDbContext db)
        {
            Category c = new Category() { Name = "Cat2" };
            Product p = new Product() { Name = "Phone2", Description = "Phone only", Category = c, Cost = 5670, Owner = "me only" };
            db.Products.Add(p);
            db.SaveChanges();
        }

        private static void UpdateStuff(ProductsDbContext db)
        {
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
