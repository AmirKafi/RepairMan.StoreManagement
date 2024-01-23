using Microsoft.EntityFrameworkCore;
using RepairMan.StoreManagement.Domain.Phones;
using RepairMan.StoreManagement.Domain.Phones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepairMan.StoreManagement.Data.Repository.Phones
{
    public class PhoneRepository : CrudRepository<Phone, int>, IPhoneRepository
    {
        public async Task<IEnumerable<Phone>> GetPhones(string? brand, string? model, int skip = 0, int take = 10)
        {
            Expression<Func<Phone, bool>> preFilter = a =>
                (brand == null || a.Brand.Contains(brand)) &&
                (model == null || a.Model == model);

            return await _dbContext.Phones
                .Where(preFilter)
                .Skip(take * skip)
                .Take(take)
                .AsNoTracking()
                .OrderByDescending(t => t.Id)
                .ToListAsync();
        }
    }
}
