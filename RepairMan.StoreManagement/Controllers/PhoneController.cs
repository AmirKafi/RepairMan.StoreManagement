using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RepairMan.StoreManagement.Application.Contract.Dto.Phones;
using RepairMan.StoreManagement.Application.Contract.Interfaces.Categories;
using RepairMan.StoreManagement.Application.Contract.Interfaces.Phones;
using RepairMan.StoreManagement.Localization.Utility.ServiceResponse;

namespace RepairMan.StoreManagement.Controllers
{
    public class PhoneController : Controller
    {
        #region Constrcutor
        private readonly IPhoneService _phoneService;
        private readonly ICategoryService _categoryService;

        public PhoneController(IPhoneService phoneService, ICategoryService categoryService)
        {
            _phoneService = phoneService;
            _categoryService = categoryService;
        }

        #endregion

        [Route("/Phone/Index")]
        public IActionResult Index()
        {
            ViewBag.ActivePage = "Phone";

            return View();
        }

        [Route("/Phone/LoadPhones")]
        public async Task<ActionResult> LoadPhones(PhoneDto dto)
        {
            var data = await _phoneService.LoadPhones(dto).ConfigureAwait(false);

            return Json(data);
        }

        [HttpGet]
        [Route("/Phone/Create")]
        public async Task<ActionResult> Create()
        {
            ViewBag.ActivePage = "Phone";
            var model = new PhoneCreateDto();


            var categories = await _categoryService.GetAsCombo().ConfigureAwait(false);

            ViewBag.Categories = categories.Data.Select(x => new SelectListItem()
            {
                Value = x.Value.ToString(),
                Text = x.Title.ToString(),
            }).ToList();

            return PartialView("Create", model);
        }

        [HttpPost]
        [Route("/Phone/Create")]
        public async Task<ActionResult> Create(PhoneCreateDto dto)
        {
            ViewBag.ActivePage = "Phone";


            var result = await _phoneService.AddPhone(dto).ConfigureAwait(false);

            return Json(result);
        }

        [HttpGet]
        [Route("/Phone/Edit")]
        public async Task<ActionResult> Edit(int id)
        {
            ViewBag.ActivePage = "Phone";

            var Phone = await _phoneService.GetPhone(id).ConfigureAwait(false);
            if (Phone.ResultStatus != ResultStatus.Successful)
            {
                Phone.SetException("GetDataFailed");
                return Json(Phone);
            }

            var categories = await _categoryService.GetAsCombo().ConfigureAwait(false);

            ViewBag.Categories = categories.Data.Select(x => new SelectListItem()
            {
                Value = x.Value.ToString(),
                Text = x.Title.ToString(),
            }).ToList();

            var model = Phone.Data;

            return PartialView("Edit", model);
        }

        [HttpPost]
        [Route("/Phone/Edit")]
        public async Task<ActionResult> Edit(PhoneUpdateDto dto)
        {
            ViewBag.ActivePage = "Phone";

            var result = await _phoneService.UpdatePhone(dto).ConfigureAwait(false);

            return Json(result);
        }

        [HttpPost]
        [Route("/Phone/Delete")]
        public async Task<ActionResult> Delete(List<int> ids)
        {
            ViewBag.ActivePage = "Phone";

            var result = await _phoneService.Delete(ids[0]).ConfigureAwait(false);

            return Json(result);
        }
    }
}
