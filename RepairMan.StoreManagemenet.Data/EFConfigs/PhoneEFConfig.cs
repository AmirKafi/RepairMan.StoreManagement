using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepairMan.StoreManagement.Domain.Phones;

namespace RepairMan.StoreManagement.Data.EFConfigs
{
    public class PhoneEFConfig:IEntityTypeConfiguration<Phone>
    {
        public void Configure(EntityTypeBuilder<Phone> builder)
        {

        }
    }
}
