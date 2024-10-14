using System.ComponentModel.DataAnnotations;

namespace RepairMan.StoreManagement.Application.Contract.Dto.Expenses
{
    public class ExpenseUpdateDto
    {
        public int Id { get; set; }

        [Display(Name = "عنوان هزینه")]
        [Required(ErrorMessage = "این فیلد اجباری می باشد")]
        public string Title { get; set; }

        [Display(Name = "توضیحات")]
        public string? Description { get; set; }

        [Display(Name = "مبلغ")]
        [Required(ErrorMessage = "این فیلد اجباری می باشد")]
        public Int64 Cost { get; set; }

        [Display(Name = "تاریخ")]
        [Required(ErrorMessage = "این فیلد اجباری می باشد")]
        public string PurchaseDateLocal { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
