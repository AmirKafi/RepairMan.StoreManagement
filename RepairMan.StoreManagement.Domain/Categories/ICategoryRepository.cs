using RepairMan.StoreManagement.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairMan.StoreManagement.Domain.Categories
{
    public interface ICategoryRepository : IReadRepository<Category, int>, IWriteRepository<Category, int>, IQueryRepository<Category, int>, IDeleteRepository<Category, int>
    {
    }
}
