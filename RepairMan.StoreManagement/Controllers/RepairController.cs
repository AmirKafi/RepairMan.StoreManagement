using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RepairMan.StoreManagement.Application.Contract.Dto.Repairs;
using RepairMan.StoreManagement.Application.Contract.Dto.Repairs.PartsUsed;
using RepairMan.StoreManagement.Application.Contract.Interfaces.Categories;
using RepairMan.StoreManagement.Application.Contract.Interfaces.Repairs;
using RepairMan.StoreManagement.Application.Contract.Interfaces.Repairs.PartsUsed;
using RepairMan.StoreManagement.Controllers.Base;
using RepairMan.StoreManagement.Localization.Enums;
using RepairMan.StoreManagement.Localization.Utility.Extentions.Datetime;
using RepairMan.StoreManagement.Localization.Utility.ServiceResponse;

namespace RepairMan.StoreManagement.Controllers
{
    public class RepairController : BaseController
    {
        #region Constrcutor

        private readonly IPartsUsedService _partsUsedService;
        private readonly ICategoryService _categoryService;
        private readonly IRepairService _repairService;

        public RepairController(IPartsUsedService partsUsedService, ICategoryService categoryService, IRepairService repairService)
        {
            _partsUsedService = partsUsedService;
            _categoryService = categoryService;
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

        #region PartsUsed


        [Route("/PartsUsed/LoadPartsUsed")]
        public async Task<ActionResult> LoadPartsUsed(PartsUsedDto dto)
        {
            var data = new ServiceResponse<List<PartsUsedListDto>>();

            if (dto.RepairId == 0)
                data.SetData(new List<PartsUsedListDto>());
            else
                data = await _partsUsedService.LoadPartsUsed(dto).ConfigureAwait(false);

            return Json(data);
        }

        [HttpGet]
        [Route("/PartsUsed/Create")]
        public async Task<ActionResult> PartsUsedCreate(int repairId)
        {
            ViewBag.ActivePage = "PartsUsed";
            var model = new PartsUsedCreateDto();
            model.RepairId = repairId;

            var categories = await _categoryService.GetAsCombo().ConfigureAwait(false);
            ViewBag.Categories = ComboToSelectList(categories.Data);

            return PartialView("PartsUsedCreate", model);
        }

        [HttpPost]
        [Route("/PartsUsed/Create")]
        public async Task<ActionResult> PartsUsedCreate(PartsUsedCreateDto dto)
        {
            ViewBag.ActivePage = "PartsUsed";

            var result = await _partsUsedService.AddPartsUsed(dto).ConfigureAwait(false);

            return Json(result);
        }

        [HttpGet]
        [Route("/PartsUsed/Edit")]
        public async Task<ActionResult> PartsUsedEdit(int id)
        {
            ViewBag.ActivePage = "PartsUsed";

            var PartsUsed = await _partsUsedService.GetPartsUsed(id).ConfigureAwait(false);
            if (PartsUsed.ResultStatus != ResultStatus.Successful)
            {
                PartsUsed.SetException("GetDataFailed");
                return Json(PartsUsed);
            }

            var model = PartsUsed.Data;

            var categories = await _categoryService.GetAsCombo().ConfigureAwait(false);
            ViewBag.Categories = ComboToSelectList(categories.Data);

            return PartialView("PartsUsedEdit", model);
        }

        [HttpPost]
        [Route("/PartsUsed/Edit")]
        public async Task<ActionResult> PartsUsedEdit(PartsUsedUpdateDto dto)
        {
            ViewBag.ActivePage = "PartsUsed";

            var result = await _partsUsedService.UpdatePartsUsed(dto).ConfigureAwait(false);

            return Json(result);
        }

        [HttpPost]
        [Route("/PartsUsed/Delete")]
        public async Task<ActionResult> PartsUsedDelete(List<int> ids)
        {
            ViewBag.ActivePage = "PartsUsed";

            var result = await _partsUsedService.Delete(ids[0]).ConfigureAwait(false);

            return Json(result);
        }

        #endregion
    }
}
