using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepairMan.StoreManagement.Domain.Categories;

namespace RepairMan.StoreManagement.Data.EFConfigs
{
    public class CategoriesEfConfig:IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {

            builder.HasMany(s => s.PartCategories)
                .WithOne(d => d.Category)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
