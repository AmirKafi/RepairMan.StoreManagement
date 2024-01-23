using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepairMan.StoreManagement.Domain.Parts;

namespace RepairMan.StoreManagement.Data.EFConfigs
{
    public class PartCategoryEFConfig:IEntityTypeConfiguration<PartCategory>
    {
        public void Configure(EntityTypeBuilder<PartCategory> builder)
        {

            builder.Property(a => a.CategoryId).IsRequired();
            builder.Property(a => a.PartId).IsRequired();

            builder.HasOne(s => s.Part)
                .WithMany(d => d.PartCategories)
                .HasForeignKey(s => s.PartId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.HasOne(x => x.Category)
                .WithMany(a => a.PartCategories)
                .HasForeignKey(a => a.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
