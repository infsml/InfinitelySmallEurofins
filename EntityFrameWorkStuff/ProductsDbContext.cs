using EntityFrameWorkStuff.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWorkStuff
{
    public class ProductsDbContext : DbContext
    {
        // configure database
        public ProductsDbContext():base("name=mConnectionString")
        {
            
        }

        // configure tables
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Person> People { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().Map(c =>
            {
                c.MapInheritedProperties();
                c.ToTable("Customers");
            });
            modelBuilder.Entity<Supplier>().Map(c =>
            {
                c.MapInheritedProperties();
                c.ToTable("Suppliers");
            });

            //modelBuilder.Entity<Customer>().MapToStoredProcedures();
            modelBuilder.Types().Configure(t => t.MapToStoredProcedures());
        }
    }
    
}
