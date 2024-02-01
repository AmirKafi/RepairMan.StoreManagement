using Microsoft.EntityFrameworkCore;
using RepairMan.StoreManagement.Domain.Repairs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepairMan.StoreManagement.Data.Repository.Repairs
{
    public class PartsUsedRepository : CrudRepository<PartsUsed, int>, IPartsUsedRepository
    {
        public async Task<IEnumerable<PartsUsed>> GetList(int repairId, int skip = 0, int take = 10)
        {
            return await _dbContext.PartsUsed
                .Include(x=> x.Category)
                .Include(x=> x.Repair)
                .Where(x=> x.RepairId == repairId)
                .Skip(take * skip)
                .Take(take)
                .AsNoTracking()
                .OrderByDescending(t => t.Id)
                .ToListAsync();
        }
    }
}
