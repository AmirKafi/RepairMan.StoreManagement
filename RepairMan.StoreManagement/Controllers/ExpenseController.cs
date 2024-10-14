using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RepairMan.StoreManagement.Application.Contract.Dto.Expenses;
using RepairMan.StoreManagement.Application.Contract.Interfaces.Categories;
using RepairMan.StoreManagement.Application.Contract.Interfaces.Expenses;
using RepairMan.StoreManagement.Controllers.Base;
using RepairMan.StoreManagement.Localization.Enums;
using RepairMan.StoreManagement.Localization.Utility.Extentions.Datetime;
using RepairMan.StoreManagement.Localization.Utility.ServiceResponse;

namespace RepairMan.StoreManagement.Controllers
{
    public class ExpenseController : BaseController
    {
        #region Constrcutor
        private readonly IExpenseService _expenseService;

        public ExpenseController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        #endregion

        [Route("/Expense/Index")]
        public IActionResult Index()
        {
            ViewBag.ActivePage = "Expense";

            return View();
        }

        [Route("/Expense/LoadExpenses")]
        public async Task<ActionResult> LoadExpenses(ExpenseDto dto)
        {
            var data = await _expenseService.LoadExpenses(dto).ConfigureAwait(false);

            return Json(data);
        }

        [HttpGet]
        [Route("/Expense/Create")]
        public async Task<ActionResult> Create()
        {
            ViewBag.ActivePage = "Expense";
            var model = new ExpenseCreateDto();


            return PartialView("Create", model);
        }

        [HttpPost]
        [Route("/Expense/Create")]
        public async Task<ActionResult> Create(ExpenseCreateDto dto)
        {
            ViewBag.ActivePage = "Expense";


            dto.PurchaseDate = dto.PurchaseDateLocal.ToEn();
            var result = await _expenseService.AddExpense(dto).ConfigureAwait(false);

            return Json(result);
        }

        [HttpGet]
        [Route("/Expense/Edit")]
        public async Task<ActionResult> Edit(int id)
        {
            ViewBag.ActivePage = "Expense";

            var Expense = await _expenseService.GetExpense(id).ConfigureAwait(false);
            if (Expense.ResultStatus != ResultStatus.Successful)
            {
                Expense.SetException("GetDataFailed");
                return Json(Expense);
            }

            var model = Expense.Data;
            model.PurchaseDateLocal = model.PurchaseDate.ToFa();

            return PartialView("Edit", model);
        }

        [HttpPost]
        [Route("/Expense/Edit")]
        public async Task<ActionResult> Edit(ExpenseUpdateDto dto)
        {
            ViewBag.ActivePage = "Expense";

            dto.PurchaseDate = dto.PurchaseDateLocal.ToEn();
            var result = await _expenseService.UpdateExpense(dto).ConfigureAwait(false);

            return Json(result);
        }

        [HttpPost]
        [Route("/Expense/Delete")]
        public async Task<ActionResult> Delete(List<int> ids)
        {
            ViewBag.ActivePage = "Expense";

            var result = await _expenseService.Delete(ids[0]).ConfigureAwait(false);

            return Json(result);
        }
    }
}
