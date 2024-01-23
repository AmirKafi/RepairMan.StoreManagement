using RepairMan.StoreManagement.Domain.Categories;
using RepairMan.StoreManagement.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairMan.StoreManagement.Domain.Phones
{
    public interface IPhoneRepository : IReadRepository<Phone, int>, IWriteRepository<Phone, int>, IQueryRepository<Phone, int>, IDeleteRepository<Phone, int>
    {

    }
}
