using RepairMan.StoreManagement.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairMan.StoreManagement.Domain.Repairs
{
    public interface IPartsUsedRepository : IReadRepository<PartsUsed, int>, IWriteRepository<PartsUsed, int>, IQueryRepository<PartsUsed, int>, IDeleteRepository<PartsUsed, int>
    {
        Task<IEnumerable<PartsUsed>> GetList(int repairId, int skip = 0, int take = 10);
    }
}
