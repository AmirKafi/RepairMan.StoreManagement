using Microsoft.EntityFrameworkCore;
using RepairMan.StoreManagement.Application.Contract.Dto.Repairs;
using RepairMan.StoreManagement.Application.Contract.Dto.Reports;
using RepairMan.StoreManagement.Application.Contract.Interfaces.Reports;
using RepairMan.StoreManagement.Domain.Expenses;
using RepairMan.StoreManagement.Domain.Repairs;
using RepairMan.StoreManagement.Localization.Utility.ServiceResponse;
using System.Linq.Expressions;

namespace RepairMan.StoreManagement.Application.Services.Reports
{
    public class ReportService : IReportService
    {
        #region Constructor
        private readonly IExpenseRepository _expenseRepository;
        private readonly IRepairRepository _repairRepository;

        public ReportService(IRepairRepository repairRepository, IExpenseRepository expenseRepository)
        {
            _repairRepository = repairRepository;
            _expenseRepository = expenseRepository;
        }
        #endregion

        public async Task<ServiceResponse<List<FinancialReportListDto>>> FinancialReport(ReportDto dto)
        {
            var result = new ServiceResponse<List<FinancialReportListDto>>();
            try
            {
                Expression<Func<Expense, bool>> preExpenseFilter = a =>
                (dto.FromDate == null || dto.ToDate == null || (a.PurchaseDate >= dto.FromDate && a.PurchaseDate <= dto.ToDate));

                Expression<Func<Repair, bool>> preRepairFilter = a =>
                (dto.FromDate == null || dto.ToDate == null || (a.RepairDate >= dto.FromDate && a.RepairDate <= dto.ToDate));

                var totalExpenses = _expenseRepository.GetQuerable()
                                                      .Where(preExpenseFilter)
                                                      .Sum(x => x.Cost);

                var totalPartsCost = _repairRepository.GetQuerable()
                                                      .Where(preRepairFilter)
                                                      .Sum(x=> x.RepairCost);

                var totalStoreShares = _repairRepository.GetQuerable()
                                                        .Where(preRepairFilter)
                                                        .Sum(x => x.RepairCost);

                var totalRepairFee = _repairRepository.GetQuerable()
                                                      .Where(preRepairFilter)
                                                      .Sum(x => x.RepairCost);

                //ToFinancialDto(totalExpenses, totalPartsCost, totalStoreShares, totalRepairFee)
                result.SetData(new List<FinancialReportListDto>());
            }
            catch (Exception ex)
            {
                result.SetException(ex.Message);
            }

            return result;
        }
    }
}
