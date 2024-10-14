using Microsoft.EntityFrameworkCore;
using RepairMan.StoreManagement.Application.Contract.Dto.Repairs;
using RepairMan.StoreManagement.Application.Contract.Interfaces.Repairs;
using RepairMan.StoreManagement.Application.Contract.Mappers.Repairs;
using RepairMan.StoreManagement.Domain.Repairs;
using RepairMan.StoreManagement.Localization.Utility.Extentions.Datetime;
using RepairMan.StoreManagement.Localization.Utility.ServiceResponse;

namespace RepairMan.StoreManagement.Application.Services.Repairs
{
    public class RepairService:IRepairService
    {
        #region Constructor

        private readonly IRepairRepository _repository;
        public RepairService(IRepairRepository repository)
        {
            _repository = repository;
        }

        #endregion

        public async Task<ServiceResponse<List<RepairListDto>>> LoadRepairs(RepairDto dto)
        {
            var result = new ServiceResponse<List<RepairListDto>>();
            try
            {
                var data = await _repository.GetRepairs(dto.Brand, dto.Model, dto.RepairDateLocal?.ToEn(), dto.offset, dto.limit);

                result.SetData(data.ToDto());
            }
            catch (Exception ex)
            {
                result.SetException(ex.Message);
            }

            return result;
        }

        public async Task<ServiceResponse<bool>> AddRepair(RepairCreateDto dto)
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

        public async Task<ServiceResponse<RepairUpdateDto>> GetRepair(int repairId)
        {
            var result = new ServiceResponse<RepairUpdateDto>();
            try
            {
                var repair = await _repository.GetById(repairId);

                if (repair is null)
                    result.SetException("قطعه مورد نظر یافت نشد!");

                result.SetData(repair.ToDto());
            }
            catch (Exception ex)
            {
                result.SetException(ex.Message);
            }

            return result;
        }

        public async Task<ServiceResponse<bool>> UpdateRepair(RepairUpdateDto dto)
        {
            var result = new ServiceResponse<bool>();
            try
            {
                var repair = await _repository.GetById(dto.Id);

                if (repair is null)
                    result.SetException("قطعه مورد نظر یافت نشد!");

                repair.Update(dto.Brand,
                              dto.Model,
                              dto.Description,
                              dto.RepairDate,
                              dto.RepairCost,
                              dto.StoreShareCost);

                await _repository.Update(repair);

                result.SetData(true);
            }
            catch (Exception ex)
            {
                result.SetException(ex.Message);
            }

            return result;
        }

        public async Task<ServiceResponse<bool>> Delete(int repairId)
        {
            var result = new ServiceResponse<bool>();
            try
            {
                var repair = await _repository.GetById(repairId);
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
