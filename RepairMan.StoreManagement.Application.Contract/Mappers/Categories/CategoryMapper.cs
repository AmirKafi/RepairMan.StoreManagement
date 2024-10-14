﻿using RepairMan.StoreManagement.Application.Contract.Dto.Categories;
using RepairMan.StoreManagement.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepairMan.StoreManagement.Domain.Categories;

namespace RepairMan.StoreManagement.Application.Contract.Mappers.Categories
{
    public static class CategoryMapper
    {
        public static Category ToModel(this CategoryCreateDto dto)
        {
            return new Category(dto.Title);
        }

        public static List<CategoryListDto> ToDto(this IEnumerable<Category>? model)
        {
            if (model is null)
                return new List<CategoryListDto>();

            return model.Select(x => new CategoryListDto()
            {
                Id = x.Id,
                Title = x.Title,
                CreatedOn = x.CreatedOn
            }).ToList();
        }

        public static CategoryUpdateDto ToDto(this Category model)
        {
            return new CategoryUpdateDto()
            {
                Id = model.Id,
                Title = model.Title
            };
        }
        public static ComboModel ToComboModel(this Category model)
        {
            return new ComboModel()
            {
                Title = model.Title,
                Value = model.Id
            };
        }
    }
}
