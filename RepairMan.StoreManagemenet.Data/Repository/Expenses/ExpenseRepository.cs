using Microsoft.EntityFrameworkCore;
using RepairMan.StoreManagement.Domain.Expenses;
using RepairMan.StoreManagement.Domain.Repairs;
using System.Linq.Expressions;

namespace RepairMan.StoreManagement.Data.Repository.Expenses
{
    public class ExpenseRepository : CrudRepository<Expense, int>, IExpenseRepository
    {
        public async Task<IEnumerable<Expense>> GetExpenses(string? title, DateTime? purchaseDate, int skip = 0, int take = 10)
        {
            Expression<Func<Expense, bool>> preFilter = a =>
                (purchaseDate == null || a.PurchaseDate.Date == purchaseDate) &&
                (title == null || a.Title.Contains(title));

            return await _dbContext.Expenses
                .Where(preFilter)
                .Skip(take * skip)
                .Take(take)
                .AsNoTracking()
                .OrderByDescending(t => t.Id)
                .ToListAsync();
        }
    }
}
