using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RepairMan.StoreManagement.Application.Contract.Dto.Categories;
using RepairMan.StoreManagement.Application.Contract.Dto.Parts;
using RepairMan.StoreManagement.Application.Contract.Interfaces.Categories;
using RepairMan.StoreManagement.Application.Contract.Interfaces.Parts;
using RepairMan.StoreManagement.Controllers.Base;
using RepairMan.StoreManagement.Localization.Enums;
using RepairMan.StoreManagement.Localization.Utility.ServiceResponse;

namespace RepairMan.StoreManagement.Controllers
{
    public class PartController : BaseController
    {
        #region Constrcutor
        private readonly IPartService _partService;
        private readonly ICategoryService _categoryService;

        public PartController(IPartService partService, ICategoryService categoryService)
        {
            _partService = partService;
            _categoryService = categoryService;
        }

        #endregion

        [Route("/Part/Index")]
        public async Task<ActionResult> Index()
        {
            ViewBag.ActivePage = "Part";

            var categories = await _categoryService.GetAsCombo().ConfigureAwait(false);
            ViewBag.Categories = ComboToSelectList(categories.Data);
            ((List<SelectListItem>)ViewBag.Categories).Insert(0,new SelectListItem());

            ViewBag.Availabilities = EnumToList(typeof(AvailabilityEnum), null);
            ((List<SelectListItem>)ViewBag.Availabilities).Insert(0, new SelectListItem() { Text = "همه" });

            return View();
        }

        [Route("/Part/LoadParts")]
        public async Task<ActionResult> LoadParts(PartDto dto)
        {
            var data = await _partService.LoadParts(dto).ConfigureAwait(false);

            return Json(data);
        }

        [HttpGet]
        [Route("/Part/Create")]
        public async Task<ActionResult> Create()
        {
            ViewBag.ActivePage = "Part";
            var model = new PartCreateDto();


            var categories = await _categoryService.GetAsCombo().ConfigureAwait(false);
            ViewBag.Categories = ComboToSelectList(categories.Data);

            return PartialView("Create", model);
        }

        [HttpPost]
        [Route("/Part/Create")]
        public async Task<ActionResult> Create(PartCreateDto dto)
        {
            ViewBag.ActivePage = "Part";


            var result = await _partService.AddPart(dto).ConfigureAwait(false);

            return Json(result);
        }

        [HttpGet]
        [Route("/Part/Edit")]
        public async Task<ActionResult> Edit(int id)
        {
            ViewBag.ActivePage = "Part";

            var Part = await _partService.GetPart(id).ConfigureAwait(false);
            if (Part.ResultStatus != ResultStatus.Successful)
            {
                Part.SetException("GetDataFailed");
                return Json(Part);
            }

            var categories = await _categoryService.GetAsCombo().ConfigureAwait(false);
            ViewBag.Categories = categories.Data.Select(x => new SelectListItem()
            {
                Value = x.Value.ToString(),
                Text = x.Title.ToString(),
                Selected = Part.Data.CategoriesId.Contains((int)x.Value)
            }).ToList();

            var model = Part.Data;

            return PartialView("Edit", model);
        }

        [HttpPost]
        [Route("/Part/Edit")]
        public async Task<ActionResult> Edit(PartUpdateDto dto)
        {
            ViewBag.ActivePage = "Part";

            var result = await _partService.UpdatePart(dto).ConfigureAwait(false);

            return Json(result);
        }

        [HttpPost]
        [Route("/Part/Delete")]
        public async Task<ActionResult> Delete(List<int> ids)
        {
            ViewBag.ActivePage = "Part";

            var result = await _partService.Delete(ids[0]).ConfigureAwait(false);

            return Json(result);
        }

        [HttpPost]
        [Route("/Part/UsePart")]
        public async Task<ActionResult> UsePart(int id)
        {
            var result = await _partService.UsePart(id).ConfigureAwait(false);

            return Json(result);
        }
    }
}
