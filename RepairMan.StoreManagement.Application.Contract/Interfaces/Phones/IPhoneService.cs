using RepairMan.StoreManagement.Application.Contract.Dto.Phones;
using RepairMan.StoreManagement.Localization.Utility.ServiceResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairMan.StoreManagement.Application.Contract.Interfaces.Phones
{
    public interface IPhoneService
    {
        Task<ServiceResponse<List<PhoneListDto>>> LoadPhones(PhoneDto dto);
        Task<ServiceResponse<bool>> AddPhone(PhoneCreateDto dto);
        Task<ServiceResponse<PhoneUpdateDto>> GetPhone(int phoneId);
        Task<ServiceResponse<bool>> UpdatePhone(PhoneUpdateDto dto);
        Task<ServiceResponse<bool>> Delete(int phoneId);
        Task<ServiceResponse<bool>> UsePhone(int phoneId);
    }
}
