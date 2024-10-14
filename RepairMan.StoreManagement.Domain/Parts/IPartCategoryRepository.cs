using RepairMan.StoreManagement.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairMan.StoreManagement.Domain.Parts
{
    public interface IPartCategoryRepository : IReadRepository<PartCategory, int>, IWriteRepository<PartCategory, int>, IQueryRepository<PartCategory, int>, IDeleteRepository<PartCategory, int>
    {
        Task Delete(List<PartCategory> entity);
    }
}
