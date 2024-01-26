using RepairMan.StoreManagement.Application.Contract.Dto.Repairs;
using RepairMan.StoreManagement.Localization.Utility.ServiceResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairMan.StoreManagement.Application.Contract.Interfaces.Repairs
{
    public interface IRepairService
    {
        Task<ServiceResponse<List<RepairListDto>>> LoadRepairs(RepairDto dto);
        Task<ServiceResponse<bool>> AddRepair(RepairCreateDto dto);
        Task<ServiceResponse<RepairUpdateDto>> GetRepair(int repairId);
        Task<ServiceResponse<bool>> UpdateRepair(RepairUpdateDto dto);
        Task<ServiceResponse<bool>> Delete(int repairId);
    }
}
