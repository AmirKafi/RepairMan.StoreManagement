using System.ComponentModel.DataAnnotations;

namespace RepairMan.StoreManagement.Application.Contract.Dto.Repairs
{
    public class RepairCreateDto
    {
        [Display(Name = "برند")]
        [Required(ErrorMessage = "این فیلد اجباری می باشد")]
        public string Brand { get; set; }

        [Display(Name = "مدل")]
        [Required(ErrorMessage = "این فیلد اجباری می باشد")]
        public string Model { get; set; }

        [Display(Name = "توضیحات")]
        public string? Description { get; set; }

        [Display(Name = "هزینه تعمیر")]
        [Required(ErrorMessage = "این فیلد اجباری می باشد")]
        public Int64 RepairCost { get; set; }

        [Display(Name = "سهم فروشگاه")]
        [Required(ErrorMessage = "این فیلد اجباری می باشد")]
        public Int64 StoreShareCost { get; set; }

        [Display(Name = "مبلغ کل")]
        public Int64 TotalCost { get; set; }

        [Display(Name = "تاریخ")]
        [Required(ErrorMessage = "این فیلد اجباری می باشد")]
        public string RepairDateLocal { get; set; }
        public DateTime RepairDate { get; set; }
    }
}
