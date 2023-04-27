using KnowLedgeHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowLedgeHub.Domain.Data
{
    public interface ICategoryRepository
    {
        void Save(Category category);
        List<Category> GetAll();
        void Delete(int id);
        void Edit(Category category);
        Category GetById(int id);
    }
}
