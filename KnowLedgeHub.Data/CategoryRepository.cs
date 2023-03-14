using KnowLedgeHub.Domain.Data;
using KnowLedgeHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowLedgeHub.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        KnowLedgeHubDBContext dbContext = new KnowLedgeHubDBContext();
        public void Delete(int id)
        {
            dbContext.categories.Remove(dbContext.categories.Find(id));
            dbContext.SaveChanges();
        }

        public void Edit(Category category)
        {
            dbContext.Entry(category).State = System.Data.Entity.EntityState.Modified;
            dbContext.SaveChanges();
        }

        public List<Category> GetAll()
        {
            return dbContext.categories.ToList();
        }

        public void Save(Category category)
        {
            dbContext.categories.Add(category);
            dbContext.SaveChanges();
        }
    }
}
