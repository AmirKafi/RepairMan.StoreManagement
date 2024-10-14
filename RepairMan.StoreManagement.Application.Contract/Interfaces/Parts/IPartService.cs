using RepairMan.StoreManagement.Application.Contract.Dto.Parts;
using RepairMan.StoreManagement.Localization.Utility.ServiceResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairMan.StoreManagement.Application.Contract.Interfaces.Parts
{
    public interface IPartService
    {
        Task<ServiceResponse<List<PartListDto>>> LoadParts(PartDto dto);
        Task<ServiceResponse<bool>> AddPart(PartCreateDto dto);
        Task<ServiceResponse<PartUpdateDto>> GetPart(int partId);
        Task<ServiceResponse<bool>> UpdatePart(PartUpdateDto dto);
        Task<ServiceResponse<bool>> Delete(int partId);
        Task<ServiceResponse<bool>> UsePart(int partId); 
    }
}
