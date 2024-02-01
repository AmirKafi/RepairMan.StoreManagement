using System.ComponentModel.DataAnnotations;

namespace RepairMan.StoreManagement.Application.Contract.Dto.Repairs.PartsUsed
{
    public class PartsUsedUpdateDto
    {
        public int Id { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "این فیلد اجباری می باشد")]
        public string Title { get; set; }

        [Display(Name = "مبلغ")]
        [Required(ErrorMessage = "این فیلد اجباری می باشد")]
        public Int64 Cost { get; set; }

        [Display(Name = "نوع قطعه")]
        [Required(ErrorMessage = "این فیلد اجباری می باشد")]
        public int CategoryId { get; set; }

        [Display(Name = "تعمیر")]
        public int RepairId { get; set; }
    }
}
