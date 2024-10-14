using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairMan.StoreManagement.Application.Contract.Dto.Repairs
{
    public class RepairDto:BaseDto
    {
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public string? RepairDateLocal { get; set; }
    }
}
