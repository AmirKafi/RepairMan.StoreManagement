using Microsoft.EntityFrameworkCore;
using RepairMan.StoreManagement.Domain.Categories;
using RepairMan.StoreManagement.Domain.Parts;
using RepairMan.StoreManagement.Domain.Repairs;
using RepairMan.StoreManagement.Localization.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepairMan.StoreManagement.Data.Repository.Repairs
{
    public class RepairRepository : CrudRepository<Repair, int>, IRepairRepository
    {
        public async Task<IEnumerable<Repair>> GetRepairs(string? brand, string? model, DateTime? repairDate, int skip = 0, int take = 10)
        {
            Expression<Func<Repair, bool>> preFilter = a =>
                (repairDate == null || a.RepairDate.Date == repairDate) &&
                (brand == null || a.Brand.Contains(brand)) &&
                (model == null || a.Model.Contains(model));

            return await _dbContext.Repairs
                .Where(preFilter)
                .Skip(take * skip)
                .Take(take)
                .AsNoTracking()
                .OrderByDescending(t => t.Id)
                .ToListAsync();
        }
    }
}
