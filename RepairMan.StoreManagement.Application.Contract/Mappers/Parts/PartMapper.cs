using RepairMan.StoreManagement.Localization;
using RepairMan.StoreManagement.Application.Contract.Dto.Parts;
using RepairMan.StoreManagement.Domain.Parts;
using System.Linq;
using RepairMan.StoreManagement.Application.Contract.Dto.Categories;
using RepairMan.StoreManagement.Domain.Categories;

namespace RepairMan.StoreManagement.Application.Contract.Mappers.Parts
{
    public static class PartMapper
    {
        public static Part ToModel(this PartCreateDto dto)
        {
            return new Part(dto.Brand,
                            dto.Model,
                            dto.Description,
                            dto.QTY,
                            dto.CategoriesId);
        }

        public static List<PartListDto> ToDto(this IEnumerable<Part>? model)
        {
            if (model is null)
                return new List<PartListDto>();

            return model.Select(x => new PartListDto()
            {
                Id = x.Id,
                Brand = x.Brand,
                Model = x.Model,
                Description = x.Description,
                QTY = x.QTY,
                CategoriesTitle = string.Join(',',x.PartCategories.Select(c => c.Category.Title).ToList()).ToString(),
                CreatedOn = x.CreatedOn,
                CategoriesId = x.PartCategories.Select(c=> c.CategoryId).ToList()
            }).ToList();
        }

        public static PartUpdateDto ToDto(this Part model)
        {
            return new PartUpdateDto()
            {
                Id = model.Id,
                Brand = model.Brand,
                Model = model.Model,
                Description = model.Description,
                QTY = model.QTY,
                CategoriesId = model.PartCategories.Select(c => c.CategoryId).ToList()
            };
        }
    }
}
