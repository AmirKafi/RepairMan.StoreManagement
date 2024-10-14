using RepairMan.StoreManagement.Application.Contract.Dto.Expenses;
using RepairMan.StoreManagement.Localization.Utility.ServiceResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairMan.StoreManagement.Application.Contract.Interfaces.Expenses
{
    public interface IExpenseService
    {
        Task<ServiceResponse<List<ExpenseListDto>>> LoadExpenses(ExpenseDto dto);
        Task<ServiceResponse<bool>> AddExpense(ExpenseCreateDto dto);
        Task<ServiceResponse<ExpenseUpdateDto>> GetExpense(int expenseId);
        Task<ServiceResponse<bool>> UpdateExpense(ExpenseUpdateDto dto);
        Task<ServiceResponse<bool>> Delete(int expenseId);
    }
}
