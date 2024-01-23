using RepairMan.StoreManagement.Domain.Categories;
using RepairMan.StoreManagement.Domain.Parts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairMan.StoreManagement.Data.Repository.Parts
{
    public class PartCategoryRepository : CrudRepository<PartCategory, int>, IPartCategoryRepository
    {
        public async Task Delete(List<PartCategory> entity)
        {
            _dbContext.RemoveRange(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
