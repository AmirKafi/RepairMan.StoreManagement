using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RepairMan.StoreManagement.Application.Contract.Dto.Phones;
using RepairMan.StoreManagement.Application.Contract.Dto.Phones;
using RepairMan.StoreManagement.Application.Contract.Interfaces.Phones;
using RepairMan.StoreManagement.Application.Contract.Mappers.Phones;
using RepairMan.StoreManagement.Domain.Categories;
using RepairMan.StoreManagement.Domain.Phones;
using RepairMan.StoreManagement.Localization.Utility.ServiceResponse;

namespace RepairMan.StoreManagement.Application.Services.Phones
{
    public class PhoneService:IPhoneService
    {
        #region Constructor

        private readonly IPhoneRepository _repository;
        public PhoneService(IPhoneRepository repository)
        {
            _repository = repository;
        }

        #endregion

        public async Task<ServiceResponse<List<PhoneListDto>>> LoadPhones(PhoneDto dto)
        {
            var result = new ServiceResponse<List<PhoneListDto>>();
            try
            {
                var data = await _repository.GetPhones(dto.Brand,dto.Model,dto.Availability,dto.offset, dto.limit);

                result.SetData(data.ToDto());
            }
            catch (Exception ex)
            {
                result.SetException(ex.Message);
            }

            return result;
        }

        public async Task<ServiceResponse<bool>> AddPhone(PhoneCreateDto dto)
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

        public async Task<ServiceResponse<PhoneUpdateDto>> GetPhone(int phoneId)
        {
            var result = new ServiceResponse<PhoneUpdateDto>();
            try
            {
                var phone = await _repository.GetById(phoneId);

                if (phone is null)
                    result.SetException("قطعه مورد نظر یافت نشد!");

                result.SetData(phone.ToDto());
            }
            catch (Exception ex)
            {
                result.SetException(ex.Message);
            }

            return result;
        }

        public async Task<ServiceResponse<bool>> UpdatePhone(PhoneUpdateDto dto)
        {
            var result = new ServiceResponse<bool>();
            try
            {
                var phone = await _repository.GetQuerable().AsNoTracking().Where(x => x.Id == dto.Id).FirstOrDefaultAsync();

                if (phone is null)
                    result.SetException("قطعه مورد نظر یافت نشد!");

                phone.Update(dto.Brand,
                             dto.Model,
                             dto.Description,
                             dto.Qty);

                await _repository.Update(phone);

                result.SetData(true);
            }
            catch (Exception ex)
            {
                result.SetException(ex.Message);
            }

            return result;
        }

        public async Task<ServiceResponse<bool>> Delete(int phoneId)
        {
            var result = new ServiceResponse<bool>();
            try
            {
                var phone = await _repository.GetById(phoneId);
                await _repository.Delete(phone);

                result.SetData(true);
            }
            catch (Exception ex)
            {
                result.SetException(ex.Message);
            }

            return result;
        }

        public async Task<ServiceResponse<bool>> UsePhone(int phoneId)
        {
            var result = new ServiceResponse<bool>();
            try
            {
                var phone = await _repository.GetQuerable().AsNoTracking().Where(x => x.Id == phoneId).FirstOrDefaultAsync();

                if (phone is null)
                    result.SetException("قطعه مورد نظر یافت نشد!");

                if (phone.Qty == 0)
                    result.SetException("عدم موجودی");
                else
                {
                    phone.UsePhone();
                    await _repository.Update(phone);

                    result.SetData(true);
                }
            }
            catch (Exception ex)
            {
                result.SetException(ex.Message);
            }

            return result;
        }
    }
}
