using RepairMan.StoreManagement.Domain.Parts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepairMan.StoreManagement.Domain.Categories;

namespace RepairMan.StoreManagement.Data.Repository.Categories
{
    public class CategoryRepository : CrudRepository<Category, int>, ICategoryRepository
    {

    }
}
