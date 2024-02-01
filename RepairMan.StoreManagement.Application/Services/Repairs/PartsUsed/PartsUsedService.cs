using Microsoft.EntityFrameworkCore;
using RepairMan.StoreManagement.Application.Contract.Dto.Repairs;
using RepairMan.StoreManagement.Application.Contract.Dto.Repairs.PartsUsed;
using RepairMan.StoreManagement.Application.Contract.Interfaces.Repairs.PartsUsed;
using RepairMan.StoreManagement.Application.Contract.Mappers.Repairs.PartsUsed;
using RepairMan.StoreManagement.Domain.Repairs;
using RepairMan.StoreManagement.Localization.Utility.ServiceResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairMan.StoreManagement.Application.Services.Repairs.PartsUsed
{
    public class PartsUsedService : IPartsUsedService
    {
        #region Constructor

        private readonly IPartsUsedRepository _repository;

        public PartsUsedService(IPartsUsedRepository repository)
        {
            _repository = repository;
        }

        #endregion

        public async Task<ServiceResponse<List<PartsUsedListDto>>> LoadPartsUsed(PartsUsedDto dto)
        {
            var result = new ServiceResponse<List<PartsUsedListDto>>();
            try
            {
                var data = await _repository.GetList(dto.RepairId, dto.offset, dto.limit);

                result.SetData(data.ToDto());
            }
            catch (Exception ex)
            {
                result.SetException(ex.Message);
            }

            return result;
        }
        public async Task<ServiceResponse<bool>> AddPartsUsed(PartsUsedCreateDto dto)
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

        public async Task<ServiceResponse<PartsUsedUpdateDto>> GetPartsUsed(int partsUsedId)
        {
            var result = new ServiceResponse<PartsUsedUpdateDto>();
            try
            {
                var partsUsed = await _repository.GetQuerable()
                                                 .Where(x=> x.Id == partsUsedId)
                                                 .Include(x=> x.Repair)
                                                 .Include(x=> x.Category)
                                                 .FirstOrDefaultAsync();

                if (partsUsed is null)
                    result.SetException("قطعه مورد نظر یافت نشد!");

                result.SetData(partsUsed.ToDto());
            }
            catch (Exception ex)
            {
                result.SetException(ex.Message);
            }

            return result;
        }

        public async Task<ServiceResponse<bool>> UpdatePartsUsed(PartsUsedUpdateDto dto)
        {
            var result = new ServiceResponse<bool>();
            try
            {
                var partsUsed = await _repository.GetById(dto.Id);

                if (partsUsed is null)
                    result.SetException("قطعه مورد نظر یافت نشد!");

                partsUsed.Update(dto.Title,
                                 dto.Cost,
                                 dto.RepairId,
                                 dto.CategoryId);

                await _repository.Update(partsUsed);

                result.SetData(true);
            }
            catch (Exception ex)
            {
                result.SetException(ex.Message);
            }

            return result;
        }

        public async Task<ServiceResponse<bool>> Delete(int partsUsedId)
        {
            var result = new ServiceResponse<bool>();
            try
            {
                var repair = await _repository.GetById(partsUsedId);
                await _repository.Delete(repair);

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
