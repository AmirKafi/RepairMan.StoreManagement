using RepairMan.StoreManagement.Domain.Repairs;
using RepairMan.StoreManagement.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairMan.StoreManagement.Domain.Expenses
{
    public interface IExpenseRepository : IReadRepository<Expense, int>, IWriteRepository<Expense, int>, IQueryRepository<Expense, int>, IDeleteRepository<Expense, int>
    {
        Task<IEnumerable<Expense>> GetExpenses(string? title, DateTime? purchaseDate, int skip = 0, int take = 10);
    }
}
