using System.ComponentModel.DataAnnotations;

namespace RepairMan.StoreManagement.Application.Contract.Dto.Phones;

public class PhoneUpdateDto
{
    public int Id { get; set; }

    [Display(Name = "برند")]
    [Required(ErrorMessage = "این فیلد اجباری می باشد")]
    public string Brand { get; set; }

    [Display(Name = "مدل")]
    [Required(ErrorMessage = "این فیلد اجباری می باشد")]
    public string Model { get; set; }

    [Display(Name = "توضیحات")]
    public string? Description { get; set; }

    [Display(Name = "موجودی")]
    [Required(ErrorMessage = "این فیلد اجباری می باشد")]
    public int Qty { get; set; }
}