using RepairMan.StoreManagement.Application.Contract.Dto.Repairs;
using RepairMan.StoreManagement.Application.Contract.Dto.Repairs.PartsUsed;
using RepairMan.StoreManagement.Localization.Utility.ServiceResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairMan.StoreManagement.Application.Contract.Interfaces.Repairs.PartsUsed
{
    public interface IPartsUsedService
    {
        Task<ServiceResponse<List<PartsUsedListDto>>> LoadPartsUsed(PartsUsedDto dto);
        Task<ServiceResponse<bool>> AddPartsUsed(PartsUsedCreateDto dto);
        Task<ServiceResponse<PartsUsedUpdateDto>> GetPartsUsed(int partsUsedId);
        Task<ServiceResponse<bool>> UpdatePartsUsed(PartsUsedUpdateDto dto);
        Task<ServiceResponse<bool>> Delete(int partsUsedId);
    }
}
