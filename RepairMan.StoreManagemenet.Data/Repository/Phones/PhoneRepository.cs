using RepairMan.StoreManagement.Domain.Phones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairMan.StoreManagement.Data.Repository.Phones
{
    public class PhoneRepository : CrudRepository<Phone, int>, IPhoneRepository
    {

    }
}
