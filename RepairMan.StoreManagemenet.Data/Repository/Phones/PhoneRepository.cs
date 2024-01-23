using Microsoft.EntityFrameworkCore;
using RepairMan.StoreManagement.Domain.Phones;
using RepairMan.StoreManagement.Domain.Phones;
using RepairMan.StoreManagement.Localization.Enums;
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
        public async Task<IEnumerable<Phone>> GetPhones(string? brand, string? model, AvailabilityEnum? availability, int skip = 0, int take = 10)
        {
            Expression<Func<Phone, bool>> preFilter = a =>
                (availability == null ||((availability == AvailabilityEnum.NotAvailable && a.Qty == 0) || (availability == AvailabilityEnum.Available && a.Qty > 0))) &&
                (brand == null || a.Brand.Contains(brand)) &&
                (model == null || a.Model.Contains(model));

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
