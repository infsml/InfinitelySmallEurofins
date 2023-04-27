using CrazyProductCatalog.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CrazyProductCatalog.Models.Data
{
    public class CrazyProductDBContext : DbContext
    {
        public CrazyProductDBContext() : base("DefaultConnection") { }
        public DbSet<CrazyProduct> CrazyProducts { get; set;}
    }
}