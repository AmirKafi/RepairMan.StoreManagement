using RepairMan.StoreManagement.Domain.Categories;
using RepairMan.StoreManagement.Localization;
using RepairMan.StoreManagement.Localization.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairMan.StoreManagement.Domain.Phones
{
    public interface IPhoneRepository : IReadRepository<Phone, int>, IWriteRepository<Phone, int>, IQueryRepository<Phone, int>, IDeleteRepository<Phone, int>
    {
        public Task<IEnumerable<Phone>> GetPhones(string? brand, string? model, AvailabilityEnum? availability, int skip = 0, int take = 10);
    }
}
