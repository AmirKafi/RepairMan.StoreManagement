using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairMan.StoreManagement.Localization.Enums
{
    public enum AvailabilityEnum
    {
        [Display(Name = "موجود")]
        Available = 1,

        [Display(Name = "نا موجود")]
        NotAvailable
    }
}
