using KnowLedgeHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowLedgeHub.Data
{
    internal class KnowLedgeHubDBContext : DbContext
    {
        public KnowLedgeHubDBContext() : base("name=DefaultConnection") { }

        public DbSet<Category> categories { get; set; }
        public DbSet<Article> articles { get; set; }
    }
}
