using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepairMan.StoreManagement.Application.Contract.Dto.Repairs;
using RepairMan.StoreManagement.Application.Contract.Dto.Repairs.PartsUsed;
using RepairMan.StoreManagement.Application.Contract.Interfaces.Categories;
using RepairMan.StoreManagement.Application.Contract.Interfaces.Repairs;
using RepairMan.StoreManagement.Application.Contract.Interfaces.Repairs.PartsUsed;
using RepairMan.StoreManagement.Controllers.Base;
using RepairMan.StoreManagement.Localization.Utility.ServiceResponse;

namespace RepairMan.StoreManagement.Controllers
{
    public class PartsUsedComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.ActivePage = "PartsUsed";

            return View("PartsUsedIndex");
        }
    }
}
