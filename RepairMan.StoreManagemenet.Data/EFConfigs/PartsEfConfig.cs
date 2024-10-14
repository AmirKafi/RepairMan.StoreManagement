using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepairMan.StoreManagement.Domain.Parts;

namespace RepairMan.StoreManagement.Data.EFConfigs
{
    public class PartsEfConfig:IEntityTypeConfiguration<Part>
    {
        public void Configure(EntityTypeBuilder<Part> builder)
        {
            builder.HasMany(s => s.PartCategories)
                .WithOne(d => d.Part)
                .HasForeignKey(d => d.PartId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
