using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepairMan.StoreManagement.Domain.Repairs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairMan.StoreManagement.Data.EFConfigs
{
    public class PartsUsedEFConfig : IEntityTypeConfiguration<PartsUsed>
    {
        public void Configure(EntityTypeBuilder<PartsUsed> builder)
        {

        }
    }
}
