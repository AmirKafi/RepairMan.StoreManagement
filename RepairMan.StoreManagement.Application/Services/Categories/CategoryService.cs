using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RepairMan.StoreManagement.Application.Contract.Dto.Categories;
using RepairMan.StoreManagement.Application.Contract.Interfaces.Categories;
using RepairMan.StoreManagement.Application.Contract.Mappers.Categories;
using RepairMan.StoreManagement.Domain.Categories;
using RepairMan.StoreManagement.Localization;
using RepairMan.StoreManagement.Localization.Utility.ServiceResponse;

namespace RepairMan.StoreManagement.Application.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        #region Constructor
        private readonly ICategoryRepository _repository;
        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        #endregion

        public async Task<ServiceResponse<List<CategoryListDto>>> LoadCategories(CategoryDto dto)
        {
            var result = new ServiceResponse<List<CategoryListDto>>();
            try
            {
                var data = await _repository.GetList(dto.offset, dto.limit);
                result.SetData(data.ToDto());
            }
            catch (Exception ex)
            {
                result.SetException(ex.Message);
            }

            return result;
        }

        public async Task<ServiceResponse<List<CategoryListDto>>> LoadCategories()
        {
            var result = new ServiceResponse<List<CategoryListDto>>();
            try
            {
                var data = _repository.GetQuerable().AsNoTracking().Select(x => new CategoryListDto()
                {
                    Id = x.Id,
                    Title = x.Title
                }).ToList();

                result.SetData(data);
            }
            catch (Exception ex)
            {
                result.SetException(ex.Message);
            }

            return result;
        }

        public async Task<ServiceResponse<bool>> AddCategory(CategoryCreateDto dto)
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

        public async Task<ServiceResponse<bool>> Delete(int categoryId)
        {
            var result = new ServiceResponse<bool>();
            try
            {
                var category = await _repository.GetById(categoryId);
                await _repository.Delete(category);

                result.SetData(true);
            }
            catch (Exception ex)
            {
                result.SetException(ex.Message);
            }

            return result;
        }

        public async Task<ServiceResponse<List<ComboModel>>> GetAsCombo()
        {
            var result = new ServiceResponse<List<ComboModel>>();
            try
            {
                var category = _repository.GetQuerable().AsNoTracking();
                var categories = category.Select(x => x.ToComboModel()).ToList();

                result.SetData(categories);
            }
            catch (Exception ex)
            {
                result.SetException(ex.Message);
            }

            return result;
        }
    }
}
