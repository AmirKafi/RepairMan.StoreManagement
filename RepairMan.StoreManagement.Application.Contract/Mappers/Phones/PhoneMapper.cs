using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepairMan.StoreManagement.Application.Contract.Dto.Phones;
using RepairMan.StoreManagement.Domain.Phones;

namespace RepairMan.StoreManagement.Application.Contract.Mappers.Phones
{
    public static class PhoneMapper
    {
        public static Phone ToModel(this PhoneCreateDto dto)
        {
            return new Phone(dto.Brand,
                             dto.Model,
                             dto.Description,
                             dto.Qty);
        }

        public static List<PhoneListDto> ToDto(this IEnumerable<Phone>? model)
        {
            if (model is null)
                return new List<PhoneListDto>();

            return model.Select(x => new PhoneListDto()
            {
                Id = x.Id,
                Brand = x.Brand,
                Model = x.Model,
                Description = x.Description,
                Qty = x.Qty,
                CreatedOn = x.CreatedOn
            }).ToList();
        }

        public static PhoneUpdateDto ToDto(this Phone model)
        {
            return new PhoneUpdateDto()
            {
                Id = model.Id,
                Brand = model.Brand,
                Model = model.Model,
                Description = model.Description,
                Qty = model.Qty
            };
        }
    }
}
