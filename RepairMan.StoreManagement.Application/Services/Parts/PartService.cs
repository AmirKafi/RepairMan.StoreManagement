using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RepairMan.StoreManagement.Application.Contract.Dto.Categories;
using RepairMan.StoreManagement.Application.Contract.Dto.Parts;
using RepairMan.StoreManagement.Application.Contract.Interfaces.Parts;
using RepairMan.StoreManagement.Application.Contract.Mappers.Parts;
using RepairMan.StoreManagement.Domain.Categories;
using RepairMan.StoreManagement.Domain.Parts;
using RepairMan.StoreManagement.Localization.Utility.ServiceResponse;

namespace RepairMan.StoreManagement.Application.Services.Parts
{
    public class PartService:IPartService
    {
        #region Constructor

        private readonly IPartRepository _repository;
        private readonly ICategoryRepository _categoryRepository;
        public PartService(IPartRepository repository, ICategoryRepository categoryRepository)
        {
            _repository = repository;
            _categoryRepository = categoryRepository;
        }

        #endregion

        public async Task<ServiceResponse<List<PartListDto>>> LoadParts(PartDto dto)
        {
            var result = new ServiceResponse<List<PartListDto>>();
            try
            {
                var data = await _repository.GetParts(dto.Brand,dto.Model,dto.offset, dto.limit);

                result.SetData(data.ToDto());
            }
            catch (Exception ex)
            {
                result.SetException(ex.Message);
            }

            return result;
        }

        public async Task<ServiceResponse<bool>> AddPart(PartCreateDto dto)
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

        public async Task<ServiceResponse<PartUpdateDto>> GetPart(int partId)
        {
            var result = new ServiceResponse<PartUpdateDto>();
            try
            {
                var part = await _repository.GetById(partId);

                if (part is null)
                    result.SetException("قطعه مورد نظر یافت نشد!");

                result.SetData(part.ToDto());
            }
            catch (Exception ex)
            {
                result.SetException(ex.Message);
            }

            return result;
        }

        public async Task<ServiceResponse<bool>> UpdatePart(PartUpdateDto dto)
        {
            var result = new ServiceResponse<bool>();
            try
            {
                var part = await _repository.GetQuerable().AsNoTracking().Where(x=> x.Id == dto.Id).FirstOrDefaultAsync();

                if (part is null)
                    result.SetException("قطعه مورد نظر یافت نشد!");

                part.Update(dto.Brand,
                            dto.Model,
                            dto.Description,
                            dto.QTY,
                            dto.CategoriesId);

                result.SetData(true);
            }
            catch (Exception ex)
            {
                result.SetException(ex.Message);
            }

            return result;
        }

        public async Task<ServiceResponse<bool>> Delete(int partId)
        {
            var result = new ServiceResponse<bool>();
            try
            {
                var part = await _repository.GetById(partId);
                await _repository.Delete(part);

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
