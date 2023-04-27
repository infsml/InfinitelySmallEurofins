using KnowLedgeHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowLedgeHub.Domain
{
    public interface ICategoriesManager
    {
        void CreateCategory(Category category);
        List<Category> ListCategories();
        void EditCategory(Category category);
        void DeleteCategory(int catagoryId);
        Category GetById(int id);
    }
}
