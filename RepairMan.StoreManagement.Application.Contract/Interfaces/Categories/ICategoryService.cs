using RepairMan.StoreManagement.Localization.Utility.ServiceResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepairMan.StoreManagement.Application.Contract.Dto.Categories;
using RepairMan.StoreManagement.Localization;

namespace RepairMan.StoreManagement.Application.Contract.Interfaces.Categories
{
    public interface ICategoryService
    {
        Task<ServiceResponse<List<CategoryListDto>>> LoadCategories(CategoryDto dto);
        Task<ServiceResponse<List<ComboModel>>> GetAsCombo();
        Task<ServiceResponse<bool>> AddCategory(CategoryCreateDto dto);
        Task<ServiceResponse<bool>> Delete(int categoryId);
    }
}
