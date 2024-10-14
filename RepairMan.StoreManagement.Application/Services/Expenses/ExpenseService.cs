using RepairMan.StoreManagement.Application.Contract.Dto.Expenses;
using RepairMan.StoreManagement.Application.Contract.Interfaces.Expenses;
using RepairMan.StoreManagement.Application.Contract.Mappers.Expenses;
using RepairMan.StoreManagement.Domain.Expenses;
using RepairMan.StoreManagement.Localization.Utility.Extentions.Datetime;
using RepairMan.StoreManagement.Localization.Utility.ServiceResponse;

namespace RepairMan.StoreManagement.Application.Services.Expenses
{
    public class ExpenseService : IExpenseService
    {
        #region Constructor

        private readonly IExpenseRepository _repository;
        public ExpenseService(IExpenseRepository repository)
        {
            _repository = repository;
        }

        #endregion

        public async Task<ServiceResponse<List<ExpenseListDto>>> LoadExpenses(ExpenseDto dto)
        {
            var result = new ServiceResponse<List<ExpenseListDto>>();
            try
            {
                var data = await _repository.GetExpenses(dto.Title, dto.PurchaseDateLocal?.ToEn(), dto.offset, dto.limit);

                result.SetData(data.ToDto());
            }
            catch (Exception ex)
            {
                result.SetException(ex.Message);
            }

            return result;
        }

        public async Task<ServiceResponse<bool>> AddExpense(ExpenseCreateDto dto)
        {
            var result = new ServiceResponse<bool>();
            try
            {
                var model = dto.ToModel();
                await _repository.Add(model);
                result.SetData(true);
            }
            catch (Exception ex)
            {
                result.SetException(ex.Message);
            }

            return result;
        }

        public async Task<ServiceResponse<ExpenseUpdateDto>> GetExpense(int expenseId)
        {
            var result = new ServiceResponse<ExpenseUpdateDto>();
            try
            {
                var expense = await _repository.GetById(expenseId);

                if (expense is null)
                    result.SetException("قطعه مورد نظر یافت نشد!");

                result.SetData(expense.ToDto());
            }
            catch (Exception ex)
            {
                result.SetException(ex.Message);
            }

            return result;
        }

        public async Task<ServiceResponse<bool>> UpdateExpense(ExpenseUpdateDto dto)
        {
            var result = new ServiceResponse<bool>();
            try
            {
                var expense = await _repository.GetById(dto.Id);

                if (expense is null)
                    result.SetException("قطعه مورد نظر یافت نشد!");

                expense.Update(dto.Title,
                              dto.Description,
                              dto.Cost,
                              dto.PurchaseDate);

                await _repository.Update(expense);

                result.SetData(true);
            }
            catch (Exception ex)
            {
                result.SetException(ex.Message);
            }

            return result;
        }

        public async Task<ServiceResponse<bool>> Delete(int expenseId)
        {
            var result = new ServiceResponse<bool>();
            try
            {
                var expense = await _repository.GetById(expenseId);
                await _repository.Delete(expense);

                result.SetData(true);
            }
            catch (Exception ex)
            {
                result.SetException(ex.Message);
            }

            return result;
        }
    }
}
