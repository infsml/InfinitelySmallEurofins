using KnowLedgeHub.Domain.Data;
using KnowLedgeHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowLedgeHub.Domain
{
    public class CatagoriesManager : ICategoriesManager
    {
        ICategoryRepository repo = null;
        public CatagoriesManager(ICategoryRepository repo) { 
            this.repo = repo;
        }
        public void CreateCategory(Category category)
        {
            // apply any business rules

            // call data layer for saving
            repo.Save(category);
        }

        public void DeleteCategory(int catagoryId)
        {
            repo.Delete(catagoryId);
        }

        public void EditCategory(Category category)
        {
            repo.Edit(category);
        }

        public List<Category> ListCategories()
        {
            return repo.GetAll();
        }
        public Category GetById(int id)
        {
            return repo.GetById(id);
        }
    }
}
