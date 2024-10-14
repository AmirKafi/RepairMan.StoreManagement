using RepairMan.StoreManagement.Domain.Phones;
using RepairMan.StoreManagement.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairMan.StoreManagement.Domain.Repairs
{
    public interface IRepairRepository : IReadRepository<Repair, int>, IWriteRepository<Repair, int>, IQueryRepository<Repair, int>, IDeleteRepository<Repair, int>
    {
        Task<IEnumerable<Repair>> GetRepairs(string? brand, string? model, DateTime? repairDate, int skip = 0, int take = 10);
    }
}
