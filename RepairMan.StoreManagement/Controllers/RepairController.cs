using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RepairMan.StoreManagement.Application.Contract.Dto.Repairs;
using RepairMan.StoreManagement.Application.Contract.Interfaces.Repairs;
using RepairMan.StoreManagement.Controllers.Base;
using RepairMan.StoreManagement.Localization.Enums;
using RepairMan.StoreManagement.Localization.Utility.Extentions.Datetime;
using RepairMan.StoreManagement.Localization.Utility.ServiceResponse;

namespace RepairMan.StoreManagement.Controllers
{
    public class RepairController : BaseController
    {
        #region Constrcutor
        private readonly IRepairService _repairService;

        public RepairController(IRepairService repairService)
        {
            _repairService = repairService;
        }

        #endregion

        [Route("/Repair/Index")]
        public IActionResult Index()
        {
            ViewBag.ActivePage = "Repair";

            return View();
        }

        [Route("/Repair/LoadRepairs")]
        public async Task<ActionResult> LoadRepairs(RepairDto dto)
        {
            var data = await _repairService.LoadRepairs(dto).ConfigureAwait(false);

            return Json(data);
        }

        [HttpGet]
        [Route("/Repair/Create")]
        public async Task<ActionResult> Create()
        {
            ViewBag.ActivePage = "Repair";
            var model = new RepairCreateDto();


            return PartialView("Create", model);
        }

        [HttpPost]
        [Route("/Repair/Create")]
        public async Task<ActionResult> Create(RepairCreateDto dto)
        {
            ViewBag.ActivePage = "Repair";

            dto.RepairDate = dto.RepairDateLocal.ToEn();
            var result = await _repairService.AddRepair(dto).ConfigureAwait(false);

            return Json(result);
        }

        [HttpGet]
        [Route("/Repair/Edit")]
        public async Task<ActionResult> Edit(int id)
        {
            ViewBag.ActivePage = "Repair";

            var repair = await _repairService.GetRepair(id).ConfigureAwait(false);
            if (repair.ResultStatus != ResultStatus.Successful)
            {
                repair.SetException("GetDataFailed");
                return Json(repair);
            }

            var model = repair.Data;
            model.RepairDateLocal = model.RepairDate.ToFa();

            return PartialView("Edit", model);
        }

        [HttpPost]
        [Route("/Repair/Edit")]
        public async Task<ActionResult> Edit(RepairUpdateDto dto)
        {
            ViewBag.ActivePage = "Repair";

            dto.RepairDate = dto.RepairDateLocal.ToEn();
            var result = await _repairService.UpdateRepair(dto).ConfigureAwait(false);

            return Json(result);
        }

        [HttpPost]
        [Route("/Repair/Delete")]
        public async Task<ActionResult> Delete(List<int> ids)
        {
            ViewBag.ActivePage = "Repair";

            var result = await _repairService.Delete(ids[0]).ConfigureAwait(false);

            return Json(result);
        }
    }
}
