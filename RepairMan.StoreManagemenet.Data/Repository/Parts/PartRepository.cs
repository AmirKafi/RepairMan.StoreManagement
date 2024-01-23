using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RepairMan.StoreManagement.Domain.Parts;
using RepairMan.StoreManagement.Localization.Enums;
using RepairMan.StoreManagement.Localization.Utility.Extentions;

namespace RepairMan.StoreManagement.Data.Repository.Parts
{
    public class PartRepository : CrudRepository<Part, int>, IPartRepository
    {

        public async Task<IEnumerable<Part>> GetParts(string? brand,string? model,int? category,AvailabilityEnum? availability, int skip = 0, int take = 10)
        {
            Expression<Func<Part, bool>> preFilter = a => 
                (availability == null || (availability == AvailabilityEnum.NotAvailable && a.QTY == 0) || (availability == AvailabilityEnum.Available && a.QTY > 0)) &&
                (category == null || a.PartCategories.Any(x=> x.CategoryId == category)) &&
                (brand == null || a.Brand.Contains(brand)) &&
                (model == null || a.Model.Contains(model));

            return await _dbContext.Parts
                .Include(x => x.PartCategories)
                .ThenInclude(x=> x.Category)
                .Where(preFilter)
                .Skip(take * skip)
                .Take(take)
                .AsNoTracking()
                .OrderByDescending(t => t.Id)
                .ToListAsync();
        }

    }
}
