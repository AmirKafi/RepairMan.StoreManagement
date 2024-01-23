using Microsoft.AspNetCore.Mvc;
using RepairMan.StoreManagement.Application.Contract.Dto.Categories;
using RepairMan.StoreManagement.Application.Contract.Interfaces.Categories;
using RepairMan.StoreManagement.Localization.Utility.ServiceResponse;

namespace RepairMan.StoreManagement.Controllers
{
    public class CategoryController : Controller
    {
        #region Constrcutor
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        #endregion

        [Route("/Category/Index")]
        public IActionResult Index()
        {
            ViewBag.ActivePage = "Category";

            return View();
        }

        [Route("/Category/LoadCategories")]
        public async Task<ActionResult> LoadCategories(CategoryDto dto)
        {
            var data = await _categoryService.LoadCategories(dto).ConfigureAwait(false);

            return Json(data);
        }

        [HttpGet]
        [Route("/Category/Create")]
        public async Task<ActionResult> Create()
        {
            ViewBag.ActivePage = "Category";
            var model = new CategoryCreateDto();

            return PartialView("Create", model);
        }

        [HttpPost]
        [Route("/Category/Create")]
        public async Task<ActionResult> Create(CategoryCreateDto dto)
        {
            ViewBag.ActivePage = "Category";


            var result = await _categoryService.AddCategory(dto).ConfigureAwait(false);

            return Json(result);
        }

        [HttpPost]
        [Route("/Category/Delete")]
        public async Task<ActionResult> Delete(List<int> ids)
        {
            ViewBag.ActivePage = "Category";

            var result = await _categoryService.Delete(ids[0]).ConfigureAwait(false);

            return Json(result);
        }
    }
}
