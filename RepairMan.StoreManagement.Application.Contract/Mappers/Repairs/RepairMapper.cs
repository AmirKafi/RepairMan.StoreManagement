using RepairMan.StoreManagement.Application.Contract.Dto.Repairs;
using RepairMan.StoreManagement.Domain.Repairs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairMan.StoreManagement.Application.Contract.Mappers.Repairs
{
    public static class RepairMapper
    {
        public static Repair ToModel(this RepairCreateDto dto)
        {
            return new Repair(dto.Brand,
                               dto.Model,
                               dto.Description,
                               dto.RepairDate,
                               dto.RepairCost,
                               dto.StoreShareCost);
        }

        public static List<RepairListDto> ToDto(this IEnumerable<Repair>? model)
        {
            if (model is null)
                return new List<RepairListDto>();

            return model.Select(x => new RepairListDto()
            {
                Id = x.Id,
                Brand = x.Brand,
                Model = x.Model,
                Description = x.Description,
                RepairDate = x.RepairDate,
                RepairCost = x.RepairCost,
                StoreShareCost = x.StoreShareCost,
                CreatedOn = x.CreatedOn,
            }).ToList();
        }

        public static RepairUpdateDto ToDto(this Repair model)
        {
            return new RepairUpdateDto()
            {
                Id = model.Id,
                Brand = model.Brand,
                Model = model.Model,
                Description = model.Description,
                StoreShareCost= model.StoreShareCost,
                RepairCost= model.RepairCost,
                RepairDate= model.RepairDate
            };
        }
    }
}
