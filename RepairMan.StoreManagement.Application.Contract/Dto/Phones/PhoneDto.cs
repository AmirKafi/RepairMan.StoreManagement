using RepairMan.StoreManagement.Localization.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairMan.StoreManagement.Application.Contract.Dto.Phones
{
    public class PhoneDto:BaseDto
    {
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public AvailabilityEnum? Availability { get; set; }
    }
}
