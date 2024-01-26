using RepairMan.StoreManagement.Application.Contract.Dto.Expenses;
using RepairMan.StoreManagement.Domain.Expenses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairMan.StoreManagement.Application.Contract.Mappers.Expenses
{
    public static class ExpenseMapper
    {
        public static Expense ToModel(this ExpenseCreateDto dto)
        {
            return new Expense(dto.Title,
                               dto.Description,
                               dto.Cost,
                               dto.PurchaseDate);
        }

        public static List<ExpenseListDto> ToDto(this IEnumerable<Expense>? model)
        {
            if (model is null)
                return new List<ExpenseListDto>();

            return model.Select(x => new ExpenseListDto()
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                Cost = x.Cost,
                PurchaseDate = x.PurchaseDate,
                CreatedOn = x.CreatedOn
            }).ToList();
        }

        public static ExpenseUpdateDto ToDto(this Expense model)
        {
            return new ExpenseUpdateDto()
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                Cost = model.Cost,
                PurchaseDate = model.PurchaseDate
            };
        }
    }
}
