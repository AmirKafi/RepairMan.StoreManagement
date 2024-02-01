using RepairMan.StoreManagement.Application.Contract.Dto.Repairs.PartsUsed;

namespace RepairMan.StoreManagement.Application.Contract.Mappers.Repairs.PartsUsed
{
    public static class PartsUsedMapper
    {
        public static Domain.Repairs.PartsUsed ToModel(this PartsUsedCreateDto dto)
        {
            return new Domain.Repairs.PartsUsed(dto.Title,
                                                dto.Cost,
                                                dto.RepairId,
                                                dto.CategoryId);
        }

        public static List<PartsUsedListDto> ToDto(this IEnumerable<Domain.Repairs.PartsUsed>? model)
        {
            if (model is null)
                return new List<PartsUsedListDto>();

            return model.Select(x => new PartsUsedListDto()
            {
                Id = x.Id,
                Title = x.Title,
                Cost = x.Cost,
                CategoryTitle = x.Category.Title,
                CreatedOn = x.CreatedOn,
            }).ToList();
        }

        public static PartsUsedUpdateDto ToDto(this Domain.Repairs.PartsUsed model)
        {
            return new PartsUsedUpdateDto()
            {
                Id = model.Id,
                Title = model.Title,
                Cost = model.Cost,
                CategoryId = model.CategoryId,
                RepairId = model.RepairId
            };
        }
    }
}
