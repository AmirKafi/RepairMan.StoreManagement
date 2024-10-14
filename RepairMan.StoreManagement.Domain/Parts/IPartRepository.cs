using RepairMan.StoreManagement.Domain.Categories;
using RepairMan.StoreManagement.Localization;
using RepairMan.StoreManagement.Localization.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairMan.StoreManagement.Domain.Parts
{
    public interface IPartRepository : IReadRepository<Part, int>, IWriteRepository<Part, int>, IQueryRepository<Part, int>, IDeleteRepository<Part, int>
    {
        public Task<IEnumerable<Part>> GetParts(string? brand, string? model, int? category, AvailabilityEnum? availability, int skip = 0, int take = 10);
    }
}
