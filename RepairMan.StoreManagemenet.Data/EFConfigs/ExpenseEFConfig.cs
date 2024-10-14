using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepairMan.StoreManagement.Domain.Expenses;

namespace RepairMan.StoreManagement.Data.EFConfigs
{
    public class ExpenseEFConfig : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {

        }
    }
}
