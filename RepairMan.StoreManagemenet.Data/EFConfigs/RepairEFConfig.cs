using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepairMan.StoreManagement.Domain.Repairs;

namespace RepairMan.StoreManagement.Data.EFConfigs
{
    public class RepairEFConfig : IEntityTypeConfiguration<Repair>
    {
        public void Configure(EntityTypeBuilder<Repair> builder)
        {

        }
    }
}
